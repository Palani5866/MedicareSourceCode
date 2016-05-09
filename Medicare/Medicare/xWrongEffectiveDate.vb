Public Class xWrongEffectiveDate
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub xWrongEffectiveDate_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub xWrongEffectiveDate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tsReport_txtDate_From.Text = Format(Now(), "dd/MM/yyyy")
    End Sub
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tsReport_txtDate_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Effective date  (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        End If
        If IsDate(Me.tsReport_txtDate_From.Text) = False Then
            MsgBox("Please do key in the Effective date in the right format (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        Else
            Me.BINDDATA()
        End If
    End Sub
    Private Sub BINDDATA()
        Me.dgvForm.DataSource = Nothing
        Me.dgvForm.DataMember = Nothing
        Dim var_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
        Dim var_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
        Dim var_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
        Dim var_Date As String = var_Month & "/" & var_Day & "/" & var_Year
        Dim dt As New DataTable
        dt = _objBusi.getDetails("WED", var_Date, "", "", "", "", Conn)

        With Me.dgvForm
            .DataSource = dt
            .Columns(0).HeaderText = "IC "
            .Columns(1).HeaderText = "FULL NAME"
            .Columns(2).HeaderText = "POLICY #"
            .Columns(3).HeaderText = "EFFECTIVE DATE"
            .Columns(4).HeaderText = "DEDUCTION CODE"
            .Columns(5).HeaderText = "PREMIUM AMOUNT"
            .Columns(6).HeaderText = "FILE #"
            .Columns(7).HeaderText = "DEDUCTION MONTH"
            .Columns(8).HeaderText = "RECEIVING MONTH"

            .Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(5).DefaultCellStyle.Format = "#,#00.00"

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
            Dim xls_wks_name As String = ""
            xls_workbook.Worksheets.Add()
            xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim
            With xls_workbook.Worksheets(xls_wks_name)
                .Cells(1, 1) = "WRONG EFFECTIVE DATE LISTING"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "POLICY #"
                .Cells(4, 5) = "EFFECTIVE DATE"
                .Cells(4, 6) = "DEDUCTION CODE"
                .Cells(4, 7) = "PREMIUM AMOUNT"
                .Cells(4, 8) = "FILE #"
                .Cells(4, 9) = "DEDUCTION MONTH"
                .Cells(4, 10) = "RECEIVING MONTH"
                Dim xls_row_counter As Integer = 5
                Dim var_name_count As Integer = 0

                Do While var_name_count < Me.dgvForm.Rows.Count - 1
                    .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 4).ToString.Trim
                    .Cells(xls_row_counter, 2) = "'" & Me.dgvForm.Rows(var_name_count).Cells(0).Value
                    .Cells(xls_row_counter, 3) = "'" & Me.dgvForm.Rows(var_name_count).Cells(1).Value.ToString.Trim
                    .Cells(xls_row_counter, 4) = Me.dgvForm.Rows(var_name_count).Cells(2).Value
                    .Cells(xls_row_counter, 5) = "'" & Format(Me.dgvForm.Rows(var_name_count).Cells(3).Value, "dd/MM/yyyy")
                    .Cells(xls_row_counter, 6) = "'" & Me.dgvForm.Rows(var_name_count).Cells(4).Value
                    .Cells(xls_row_counter, 7) = "'" & Format(Me.dgvForm.Rows(var_name_count).Cells(5).Value, "#,#00.00")
                    .Cells(xls_row_counter, 8) = "'" & Me.dgvForm.Rows(var_name_count).Cells(6).Value
                    .Cells(xls_row_counter, 9) = "'" & Me.dgvForm.Rows(var_name_count).Cells(7).Value
                    .Cells(xls_row_counter, 10) = "'" & Me.dgvForm.Rows(var_name_count).Cells(8).Value

                    xls_row_counter += 1
                    var_name_count += 1
                Loop
            End With
            MsgBox("Exporting records to WRONG EFFECTIVE CHANGE completed.")
            xls_file.Visible = True
        End If
    End Sub
End Class