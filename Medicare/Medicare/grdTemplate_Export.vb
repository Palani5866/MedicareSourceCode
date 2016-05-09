Public Class grdTemplate_Export
    Dim Conn As DbConnection = New SqlConnection

    Private Sub grdTemplate_Export_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub grdTemplate_Export_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        If Me.lblType.Text.Trim() = "YR" Then
            Me.Text = "Export Template: Yearly Salary Deduction (SIRIM/FAMA/OTHERS)"
        Else
            Me.Text = "Export Template: Monthly Salary Deduction (SIRIM/FAMA/OTHERS)"
        End If
    End Sub

    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tsReport_txtDeductionCode_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Deduction Code (From).")
            Me.tsReport_txtDeductionCode_From.Focus()
            Exit Sub
        End If

        If Len(Me.tsReport_txtDeductionCode_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the Deduction Code (To).")
            Me.tsReport_txtDeductionCode_To.Focus()
            Exit Sub
        End If
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Me.Populate_Grid()
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
    End Sub

    Private Sub Populate_Grid()
        Me.dgvForm.DataSource = Nothing
        Me.dgvForm.DataMember = Nothing


        Dim cmdSelect_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Policy.CommandType = CommandType.Text
        If Me.lblType.Text = "YR" Then
            cmdSelect_Policy.CommandText = "SELECT ID, Angkasa_FileNo, Full_Name, IC_New, Deduction_Code, Deduction_Amount, " & _
                                                   "Submission_Date, Effective_Date, cancellation_date " & _
                                                   "FROM vi_Member_Policy_v3 " & _
                                                   "WHERE Deduction_Code Like 'Y%' " & _
                                                   "AND Deduction_Code BETWEEN '" & Me.tsReport_txtDeductionCode_From.Text.Trim & "' " & _
                                                   "AND '" & Me.tsReport_txtDeductionCode_To.Text.Trim & "' " & _
                                                   "ORDER BY Deduction_Code, Angkasa_FileNo"
        Else
            cmdSelect_Policy.CommandText = "SELECT ID, Angkasa_FileNo, Full_Name, IC_New, Deduction_Code, Deduction_Amount, " & _
                                       "Submission_Date, Effective_Date " & _
                                       "FROM vi_Member_Policy_v3 " & _
                                       "WHERE Deduction_Code NOT Like 'Y%' " & _
                                       "AND Cancellation_Date Is Null " & _
                                       "AND Deduction_Code BETWEEN '" & Me.tsReport_txtDeductionCode_From.Text.Trim & "' " & _
                                       "AND '" & Me.tsReport_txtDeductionCode_To.Text.Trim & "' " & _
                                       "ORDER BY Deduction_Code, Angkasa_FileNo"
        End If


        Dim da_Policy As New SqlDataAdapter(cmdSelect_Policy)


        Dim ds_Template As New DataSet
        da_Policy.Fill(ds_Template, "vi_Member_Policy_v3")

        With Me.dgvForm
            .DataSource = ds_Template
            .DataMember = "vi_Member_Policy_v3"

            .Columns(0).Visible = False

            .Columns(1).HeaderText = "File No."
            .Columns(2).HeaderText = "Full Name"
            .Columns(3).HeaderText = "IC"
            .Columns(4).HeaderText = "Deduction Code"
            .Columns(5).HeaderText = "Deduction Amount"
            .Columns(6).HeaderText = "Submission Date"
            .Columns(7).HeaderText = "Effective Date"
            If Me.lblType.Text = "YR" Then
                .Columns(8).HeaderText = "Cancellation Date"
                .Columns(8).DefaultCellStyle.Format = "dd/MM/yyyy"
            End If


            .Columns(5).DefaultCellStyle.Format = "#,#00.00"
            .Columns(6).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(7).DefaultCellStyle.Format = "dd/MM/yyyy"

            Me.ssReport_RecordCount.Text = "Record #: " & Me.dgvForm.RowCount.ToString
            Me.ssReport_RecordCount.Visible = True
        End With
    End Sub

    Private Sub tsReport_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Export.Click
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        xPort2Xcel()
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If Me.lblType.Text = "YR" Then
            MsgBox("Exporting records to TEMPLATE: YEARLY DEDUCTION completed.")
        Else
            MsgBox("Exporting records to TEMPLATE: MONTHLY SALARY DEDUCTION completed.")
        End If
    End Sub
    Private Sub xPort2Xcel()
        If Me.dgvForm.RowCount > 0 Then


            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

            xls_workbook = xls_file.Workbooks.Add

            Dim var_name_count As Integer = 0
            Dim xls_wks_name As String = ""
            Dim xls_row_counter As Integer = 6

            Dim var_Deduction_Code As String = ""

            Do While var_name_count < Me.dgvForm.RowCount
                With Me.dgvForm.Rows(var_name_count)
                    If var_Deduction_Code <> .Cells("Deduction_Code").Value.ToString.Trim Then
                        xls_workbook.Worksheets.Add()

                        xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

                        With xls_workbook.Worksheets(xls_wks_name)
                            If Me.lblType.Text = "YR" Then
                                .Cells(1, 1) = "EXPORT TEMPLATE: YEARLY DEDUCTION"
                            Else
                                .Cells(1, 1) = "EXPORT TEMPLATE: MONTHLY SALARY DEDUCTION"
                            End If

                            .Cells(2, 1) = "AS AT " & Format(Now(), "dd/MM/yyyy").ToString
                            .Cells(3, 1) = "DEDUCTION CODE: " & _
                                           Me.dgvForm.Rows(var_name_count).Cells("Deduction_Code").Value.ToString.Trim

                            .Cells(5, 1) = "SYSTEM ID"
                            .Cells(5, 2) = "FILE NO."
                            .Cells(5, 3) = "FULL NAME"
                            .Cells(5, 4) = "IC"
                            .Cells(5, 5) = "DEDUCTION CODE"
                            .Cells(5, 6) = "DEDUCTION AMOUNT"
                            .Cells(5, 7) = "SUBMISSION DATE"
                            .Cells(5, 8) = "EFFECTIVE DATE"
                            If Me.lblType.Text = "YR" Then
                                .Cells(5, 9) = "CANCELLATION DATE"
                                .Columns(9).NumberFormat = "dd/MM/yyyy"
                            End If


                            .Columns(1).NumberFormat = "@"
                            .Columns(2).NumberFormat = "@"
                            .Columns(3).NumberFormat = "@"
                            .Columns(4).NumberFormat = "@"
                            .Columns(5).NumberFormat = "@"
                            .Columns(6).NumberFormat = "@"
                            .Columns(7).NumberFormat = "dd/MM/yyyy"
                            .Columns(8).NumberFormat = "dd/MM/yyyy"
                        End With

                        xls_row_counter = 6
                        var_Deduction_Code = .Cells("Deduction_Code").Value.ToString.Trim
                    End If

                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = "'" & .Cells("ID").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = "'" & .Cells("Angkasa_FileNo").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = .Cells("Full_Name").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = "'" & .Cells("IC_New").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & .Cells("Deduction_Code").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & Format(.Cells("Deduction_Amount").Value, "#,#00.00")
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "'" & .Cells("Submission_Date").Value
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 8) = "'" & .Cells("Effective_Date").Value
                    If Me.lblType.Text = "YR" Then
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 9) = "'" & .Cells("Cancellation_Date").Value
                    End If
                End With

                xls_row_counter += 1
                var_name_count += 1
            Loop
            xls_file.Visible = True
        Else
            MsgBox("No Record Found!")
        End If
    End Sub
#Region "Progress Bar"
    Private Shared SharedData As New SharedObject()
    Protected Overridable Sub StartMarqueeThread()
        Dim t As New Threading.Thread(AddressOf ShowMarqueeForm)
        t.Start()
    End Sub
    Protected Overridable Sub ShowMarqueeForm()
        Dim L As New Loading()
        L.Show()
        L.Update()
        Do
            SyncLock SharedData
                If SharedData.ReadyToHideMarquee Then
                    Exit Do
                End If
            End SyncLock
            Application.DoEvents()
        Loop
    End Sub
    Private Class SharedObject
        Public ReadyToHideMarquee As Boolean
    End Class
#End Region
End Class