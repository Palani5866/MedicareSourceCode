Public Class grdReport_Premium_Not_ReceivedFrAgency_Monthly
    Dim Conn As DbConnection = New SqlConnection

    Private Sub grdReport_Premium_Not_ReceivedFrAgency_Monthly_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub grdReport_Premium_Not_ReceivedFrAgency_Monthly_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindMonths()
    End Sub

    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tsReport_txtDeductionCode_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Deduction Code (From).")
            Me.tsReport_txtDeductionCode_From.Focus()
            Exit Sub
        End If

        If Len(Me.tsReport_txtDeductionCode_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the Deduction Code (To).")
            Me.tsReport_ddlMonth.Focus()
            Exit Sub
        End If

        If Len(Me.tsReport_ddlMonth.SelectedItem.ToString.Trim) = 0 Then
            MsgBox("Please do key in the Month.")
            Me.tsReport_ddlMonth.Focus()
            Exit Sub
        End If
        Me.Populate_Grid()
    End Sub
    Private Sub BindMonths()
        Dim aMonth As New ArrayList
        Dim p1YR, p2Yr, cYr, f1Yr, f2Yr, p1M, p2M, cM, f1M, f2M As String
        For p1I As Integer = 0 To 11
            p1M = "0" & p1I + 1
            If p1M.Length = 3 Then
                p1M = p1M.Substring(1, 2)
            End If
            p1YR = Now.Year() - 2 & p1M
            aMonth.Add(p1YR)
        Next
        For p2I As Integer = 0 To 11
            p2M = "0" & p2I + 1
            If p2M.Length = 3 Then
                p2M = p2M.Substring(1, 2)
            End If
            p2Yr = Now.Year() - 1 & p2M
            aMonth.Add(p2Yr)
        Next
        For cI As Integer = 0 To 11
            cM = "0" & cI + 1
            If cM.Length = 3 Then
                cM = cM.Substring(1, 2)
            End If
            cYr = Now.Year() & cM
            aMonth.Add(cYr)
        Next
        For f1I As Integer = 0 To 11
            f1M = "0" & f1I + 1
            If f1M.Length = 3 Then
                f1M = f1M.Substring(1, 2)
            End If
            f1Yr = Now.Year() + 1 & f1M
            aMonth.Add(f1Yr)
        Next
        For f2I As Integer = 0 To 11
            f2M = "0" & f2I + 1
            If f2M.Length = 3 Then
                f2M = f2M.Substring(1, 2)
            End If
            f2Yr = Now.Year() + 2 & f2M
            aMonth.Add(f2Yr)
        Next
        Me.tsReport_ddlMonth.ComboBox.DataSource = aMonth
    End Sub
    Private Sub Populate_Grid()
        Me.dgvForm.DataSource = Nothing
        Me.dgvForm.DataMember = Nothing
        Dim cmdSelect_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Policy.CommandType = CommandType.Text


        cmdSelect_Policy.CommandText = "SELECT a.ID, a.Angkasa_FileNo, b.Full_Name, b.IC_New, a.Deduction_Code, a.Deduction_Amount, " & _
                                       "a.Agent_Code, a.Submission_Date, a.Effective_Date, a.Cancellation_Date, b.phone_mobile, " & _
                                       "b.phone_hse, b.phone_off, email FROM dt_member_policy a " & _
                                       "INNER JOIN dt_member b ON a.Member_id=b.ID WHERE a.deduction_code NOT LIKE 'Y%' " & _
                                       "AND a.deduction_code BETWEEN '" & Me.tsReport_txtDeductionCode_From.Text.Trim & "' " & _
                                       "AND '" & Me.tsReport_txtDeductionCode_To.Text.Trim & "' and a.status='INFORCE' " & _
                                       "ORDER BY Deduction_Code, Angkasa_FileNo"



        Dim da_NoPremium_Policy As New SqlDataAdapter(cmdSelect_Policy)

        Dim cmdSelect_MonthlyDeduction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MonthlyDeduction.CommandType = CommandType.Text
        cmdSelect_MonthlyDeduction.CommandText = "SELECT Member_Policy_ID, Angkasa_Bulan_Potongan " & _
                                                 "FROM dt_Member_Policy_MonthlyDeduction " & _
                                                 "ORDER BY Angkasa_Bulan_Potongan DESC"
        Dim da_MonthlyDeduction As New SqlDataAdapter(cmdSelect_MonthlyDeduction)


        Dim ds_InsurerReport As New DataSet

        da_NoPremium_Policy.Fill(ds_InsurerReport, "dt_member_policy")
        da_MonthlyDeduction.Fill(ds_InsurerReport, "dt_Member_Policy_MonthlyDeduction")

        Dim dr_InsurerReport_MonthlyDeductions As DataRow()
        Dim var_name_count As Integer = 0
        Dim var_LastDeduction As String = Me.tsReport_ddlMonth.ComboBox.SelectedValue.ToString.Trim()
        With ds_InsurerReport.Tables("dt_member_policy")
            Do While var_name_count < .Rows.Count
                With ds_InsurerReport.Tables("dt_member_policy").Rows(var_name_count)
                    dr_InsurerReport_MonthlyDeductions = ds_InsurerReport.Tables("dt_Member_Policy_MonthlyDeduction").Select("Member_Policy_ID = '" & _
                                                                                                                     .Item("ID").ToString.Trim & "'")

                    If dr_InsurerReport_MonthlyDeductions.Length > 0 Then
                        If Val(dr_InsurerReport_MonthlyDeductions(0).Item("Angkasa_Bulan_Potongan").ToString.Trim) <= Val(var_LastDeduction) Then
                            Me.dgvForm.Rows.Add()
                            Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(0).Value = .Item("Angkasa_FileNo").ToString.Trim
                            Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(1).Value = .Item("Full_Name").ToString.Trim
                            Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(2).Value = .Item("IC_New").ToString.Trim
                            Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(3).Value = .Item("Deduction_Code").ToString.Trim
                            Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(4).Value = Format(.Item("Deduction_Amount"), "#,#00.00")
                            Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(5).Value = .Item("Agent_Code").ToString.Trim
                            If IsDBNull(.Item("Submission_Date")) = False Then
                                Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(6).Value = Format(.Item("Submission_Date"), "dd/MM/yyyy")
                            End If
                            If IsDBNull(.Item("Effective_Date")) = False Then
                                Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(7).Value = Format(.Item("Effective_Date"), "dd/MM/yyyy")
                            End If
                            If IsDBNull(.Item("Cancellation_Date")) = False Then
                                Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(8).Value = Format(.Item("Cancellation_Date"), "dd/MM/yyyy")
                            End If
                            Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(9).Value = dr_InsurerReport_MonthlyDeductions(0).Item("Angkasa_Bulan_Potongan").ToString.Trim
                            Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(10).Value = .Item("phone_mobile").ToString.Trim
                            Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(11).Value = .Item("phone_hse").ToString.Trim
                            Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(12).Value = .Item("phone_off").ToString.Trim
                            Me.dgvForm.Rows(Me.dgvForm.Rows.Count - 1).Cells(13).Value = .Item("email").ToString.Trim
                        End If
                    End If
                End With
                var_name_count += 1
            Loop
        End With

        Me.ssReport_RecordCount.Text = "Record #: " & Me.dgvForm.RowCount.ToString
        Me.ssReport_RecordCount.Visible = True

    End Sub

    Private Sub tsReport_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Export.Click
        If Me.dgvForm.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)

            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

            xls_workbook = xls_file.Workbooks.Add

            Dim var_name_count As Integer = 0
            Dim xls_wks_name As String = ""
            Dim xls_row_counter As Integer = 7

            Dim var_Deduction_Code As String = ""

            Do While var_name_count < Me.dgvForm.RowCount
                With Me.dgvForm.Rows(var_name_count)
                    If var_Deduction_Code <> .Cells("Deduction_Code").Value.ToString.Trim Then
                        xls_workbook.Worksheets.Add()

                        xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

                        With xls_workbook.Worksheets(xls_wks_name)
                            .Cells(1, 1) = "PREMIUM NOT RECEIVED STATEMENT FROM SALARY DEDUCTION AGENCY"
                            .Cells(2, 1) = "AS AT " & Format(Now(), "dd/MM/yyyy").ToString
                            .Cells(3, 1) = "DEDUCTION CODE: " & _
                                           Me.dgvForm.Rows(var_name_count).Cells("Deduction_Code").Value.ToString.Trim

                            .Cells(6, 1) = "FILE NO."
                            .Cells(6, 2) = "FULL NAME"
                            .Cells(6, 3) = "IC"
                            .Cells(6, 4) = "DEDUCTION CODE"
                            .Cells(6, 5) = "DEDUCTION AMOUNT"
                            .Cells(6, 6) = "AGENT CODE"
                            .Cells(6, 7) = "SUBMISSION DATE"
                            .Cells(6, 8) = "EFFECTIVE DATE"
                            .Cells(6, 9) = "CANCELLATION DATE"
                            .Cells(6, 10) = "LAST DEDUCTION MONTH"
                            .Cells(6, 11) = "Mobile #"
                            .Cells(6, 12) = "Phone #"
                            .Cells(6, 13) = "Office Contact #"
                            .Cells(6, 14) = "Email"

                            .Columns(1).NumberFormat = "@"
                            .Columns(2).NumberFormat = "@"
                            .Columns(3).NumberFormat = "@"
                            .Columns(4).NumberFormat = "@"
                            .Columns(5).NumberFormat = "@"
                            .Columns(6).NumberFormat = "@"
                            .Columns(7).NumberFormat = "dd/MM/yyyy"
                            .Columns(8).NumberFormat = "dd/MM/yyyy"
                            .Columns(9).NumberFormat = "dd/MM/yyyy"
                            .Columns(10).NumberFormat = "@"
                        End With

                        xls_row_counter = 7
                        var_Deduction_Code = .Cells("Deduction_Code").Value.ToString.Trim
                    End If

                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = "'" & .Cells("Angkasa_FileNo").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = .Cells("Full_Name").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = "'" & .Cells("IC_New").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = "'" & .Cells("Deduction_Code").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & .Cells("Deduction_Amount").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & .Cells("Agent_Code").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "'" & .Cells("Submission_Date").Value
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 8) = "'" & .Cells("Effective_Date").Value
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 9) = "'" & .Cells("Cancellation_Date").Value
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 10) = "'" & .Cells("Last_Deduction_Month").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 11) = "'" & .Cells(10).Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 12) = "'" & .Cells(11).Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 13) = "'" & .Cells(12).Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 14) = "'" & .Cells(13).Value.ToString.Trim
                End With

                xls_row_counter += 1
                var_name_count += 1
            Loop
            MsgBox("Exporting records to PREMIUM NOT RECEIVED STATEMENT FROM SALARY DEDUCTION AGENCY completed.")
            xls_file.Visible = True
        End If
    End Sub

End Class