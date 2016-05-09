Public Class grdBLANK_Address_Template_Export
    Dim Conn As DbConnection = New SqlConnection

    Private Sub grdBLANK_Address_Template_Export_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub grdBLANK_Address_Template_Export_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
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

        Me.Populate_Grid()
    End Sub

    Private Sub Populate_Grid()
        Me.dgvForm.DataSource = Nothing
        Me.dgvForm.DataMember = Nothing

        Dim cmdSelect_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Policy.CommandType = CommandType.Text
        cmdSelect_Policy.CommandText = "SELECT Angkasa_FileNo, Full_Name, IC_New, Deduction_Code, Agent_Code, " & _
                                       "Submission_Date, Effective_Date, Cancellation_Date " & _
                                       "FROM vi_Member_Policy_with_PostalAddress " & _
                                       "WHERE (Postal_Address_L1 Is Null) " & _
                                       "AND (Deduction_Code BETWEEN '" & Me.tsReport_txtDeductionCode_From.Text.Trim & "' " & _
                                       "AND '" & Me.tsReport_txtDeductionCode_To.Text.Trim & "') " & _
                                       "OR (LEN(Postal_Address_L1) = 0) " & _
                                       "AND (Deduction_Code BETWEEN '" & Me.tsReport_txtDeductionCode_From.Text.Trim & "' " & _
                                       "AND '" & Me.tsReport_txtDeductionCode_To.Text.Trim & "') " & _
                                       "ORDER BY Deduction_Code, Angkasa_FileNo"

        Dim da_Policy As New SqlDataAdapter(cmdSelect_Policy)

        Dim ds_Template As New DataSet
        da_Policy.Fill(ds_Template, "vi_Member_Policy_with_PostalAddress")

        With Me.dgvForm
            .DataSource = ds_Template
            .DataMember = "vi_Member_Policy_with_PostalAddress"

            .Columns(0).HeaderText = "File No."
            .Columns(1).HeaderText = "Full Name"
            .Columns(2).HeaderText = "IC"
            .Columns(3).HeaderText = "Deduction Code"
            .Columns(4).HeaderText = "Agent Code"
            .Columns(5).HeaderText = "Submission Date"
            .Columns(6).HeaderText = "Effective Date"
            .Columns(7).HeaderText = "Cancellation Date"

            .Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(6).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(7).DefaultCellStyle.Format = "dd/MM/yyyy"

            Me.ssReport_RecordCount.Text = "Record #: " & Me.dgvForm.RowCount.ToString
            Me.ssReport_RecordCount.Visible = True
        End With
    End Sub

    Private Sub tsReport_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Export.Click
        If Me.dgvForm.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)

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
                            .Cells(1, 1) = "EXPORT TEMPLATE: BLANK Addresses"
                            .Cells(2, 1) = "AS AT " & Format(Now(), "dd/MM/yyyy").ToString
                            .Cells(3, 1) = "DEDUCTION CODE: " & _
                                           Me.dgvForm.Rows(var_name_count).Cells("Deduction_Code").Value.ToString.Trim

                            .Cells(5, 1) = "FILE NO."
                            .Cells(5, 2) = "FULL NAME"
                            .Cells(5, 3) = "IC"
                            .Cells(5, 4) = "DEDUCTION CODE"
                            .Cells(5, 5) = "AGENT CODE"
                            .Cells(5, 6) = "SUBMISSION DATE"
                            .Cells(5, 7) = "EFFECTIVE DATE"
                            .Cells(5, 8) = "CANCELLATION DATE"
                            .Columns(1).NumberFormat = "@"
                            .Columns(2).NumberFormat = "@"
                            .Columns(3).NumberFormat = "@"
                            .Columns(4).NumberFormat = "@"
                            .Columns(5).NumberFormat = "@"
                            .Columns(6).NumberFormat = "dd/MM/yyyy"
                            .Columns(7).NumberFormat = "dd/MM/yyyy"
                            .Columns(8).NumberFormat = "dd/MM/yyyy"
                        End With

                        xls_row_counter = 6
                        var_Deduction_Code = .Cells("Deduction_Code").Value.ToString.Trim
                    End If

                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = "'" & .Cells("Angkasa_FileNo").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = .Cells("Full_Name").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = "'" & .Cells("IC_New").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = "'" & .Cells("Deduction_Code").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & .Cells("Agent_Code").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & .Cells("Submission_Date").Value
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "'" & .Cells("Effective_Date").Value
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 8) = "'" & .Cells("Cancellation_Date").Value
                End With

                xls_row_counter += 1
                var_name_count += 1
            Loop

            MsgBox("Exporting records to TEMPLATE: BLANK Address completed.")
            xls_file.Visible = True
        End If

    End Sub
End Class