Public Class grdBLANK_PolicyNo_Template_Export
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub grdBLANK_PolicyNo_Template_Export_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub grdBLANK_PolicyNo_Template_Export_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        If Me.lblRQS1.Text.Trim() = "NEW" Then
            Me.Text = ""
        Else
            Me.Text = ""
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
        Dim dt As New DataTable
        dt = _objBusi.getDetails_I("POLICYNO", Me.lblRQS1.Text.ToString.Trim(), Me.tsReport_txtDeductionCode_From.Text.Trim, Me.tsReport_txtDeductionCode_To.Text.Trim, "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvForm
                .DataSource = dt

                .Columns(0).Visible = False
                .Columns(1).HeaderText = "File No."
                .Columns(2).HeaderText = "Full Name"
                .Columns(3).HeaderText = "IC"
                .Columns(4).HeaderText = "Deduction Code"
                .Columns(5).HeaderText = "Submission Date"
                .Columns(6).HeaderText = "Effective Date"
                .Columns(7).HeaderText = "Cancellation Date"

                .Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns(6).DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns(7).DefaultCellStyle.Format = "dd/MM/yyyy"

                Me.ssReport_RecordCount.Text = "Record #: " & Me.dgvForm.RowCount.ToString
                Me.ssReport_RecordCount.Visible = True
            End With
        End If
    End Sub
    Private Sub tsReport_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Export.Click
        xPort2Xcel()

    End Sub
    Private Sub xPort2Xcel()
        If Me.dgvForm.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)

            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

            xls_workbook = xls_file.Workbooks.Add

            Dim var_name_count As Integer = 0
            Dim xls_wks_name As String = ""
            Dim xls_row_counter As Integer = 6

            Dim var_Deduction_Code As String = ""

            xls_workbook.Worksheets.Add()

            xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

            With xls_workbook.Worksheets(xls_wks_name)
                If Me.lblRQS1.Text.Trim() = "NEW" Then
                    .Cells(1, 1) = "EXPORT TEMPLATE: BLANK Policy/Certificate No (NEW)"
                Else
                    .Cells(1, 1) = "EXPORT TEMPLATE: BLANK Policy/Certificate No (OLD)"
                End If

                .Cells(2, 1) = "AS AT " & Format(Now(), "dd/MM/yyyy").ToString
                .Cells(3, 1) = "DEDUCTION CODE: " & _
                               Me.dgvForm.Rows(var_name_count).Cells("Deduction_Code").Value.ToString.Trim

                .Cells(5, 1) = "SYSTEM ID"
                .Cells(5, 2) = "FILE NO."
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "IC"
                .Cells(5, 5) = "DEDUCTION CODE"
                .Cells(5, 6) = "SUBMISSION DATE"
                .Cells(5, 7) = "EFFECTIVE DATE"
                .Cells(5, 8) = "CANCELLATION DATE"
                .Cells(5, 9) = "OLD POLICY / CERTIFICATE NO."
                .Cells(5, 10) = "NEW POLICY / CERTIFICATE NO."

                .Columns(1).NumberFormat = "@"
                .Columns(2).NumberFormat = "@"
                .Columns(3).NumberFormat = "@"
                .Columns(4).NumberFormat = "@"
                .Columns(5).NumberFormat = "@"
                .Columns(6).NumberFormat = "dd/MM/yyyy"
                .Columns(7).NumberFormat = "dd/MM/yyyy"
                .Columns(8).NumberFormat = "dd/MM/yyyy"
                xls_row_counter = 6
            End With
            Do While var_name_count < Me.dgvForm.RowCount
                With Me.dgvForm.Rows(var_name_count)
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = "'" & .Cells("ID").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = "'" & .Cells("Angkasa_FileNo").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = .Cells("Full_Name").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = "'" & .Cells("IC_New").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & .Cells("Deduction_Code").Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & .Cells("Submission_Date").Value
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "'" & .Cells("Effective_Date").Value
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 8) = "'" & .Cells("Cancellation_Date").Value
                End With

                xls_row_counter += 1
                var_name_count += 1
            Loop
            MsgBox("Exporting records to TEMPLATE: BLANK Policy/Certificate No completed.")
            xls_file.Visible = True
        End If
    End Sub
End Class