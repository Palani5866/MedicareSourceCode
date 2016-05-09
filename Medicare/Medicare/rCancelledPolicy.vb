Public Class rCancelledPolicy
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub rCancelledPolicy_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub rCancelledPolicy_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tsReport_txtDate_From.Text = Format(Now(), "dd/MM/yyyy")
        Me.tsReport_txtDate_To.Text = Format(Now(), "dd/MM/yyyy")
    End Sub
    Private Sub BINDDATA()
        Me.dgvForm.DataSource = Nothing
        Me.dgvForm.DataMember = Nothing

        Dim var_Log_From_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
        Dim var_Log_From_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
        Dim var_Log_From_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
        Dim var_Log_Date_From As String = var_Log_From_Month & "/" & var_Log_From_Day & "/" & var_Log_From_Year

        Dim var_Log_To_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
        Dim var_Log_To_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
        Dim var_Log_To_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
        Dim var_Log_Date_To As String = var_Log_To_Month & "/" & var_Log_To_Day & "/" & var_Log_To_Year

        Dim dt As New DataTable
        dt = _objBusi.getDetails_I("CANCELPOLICY", var_Log_Date_From, var_Log_Date_To, "", "", "", "", "", "", "", "", Conn)

        If dt.Rows.Count > 0 Then
            With Me.dgvForm
                .DataSource = dt
            End With
        Else
            MsgBox("No record found")
            Me.dgvForm.DataSource = dt
        End If
    End Sub
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        
        If Len(Me.tsReport_txtDate_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Effective Date (From) (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        End If
        If Len(Me.tsReport_txtDate_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the Effective Date (To) (dd/mm/yyyy).")
            Me.tsReport_txtDate_To.Focus()
            Exit Sub
        End If
        If IsDate(Me.tsReport_txtDate_From.Text) = False Then
            MsgBox("Please do key in the Effective Date (From) in the right format (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        Else
            If IsDate(Me.tsReport_txtDate_To.Text) = False Then
                MsgBox("Please do key in the Effective Date (To) in the right format (dd/mm/yyyy).")
                Me.tsReport_txtDate_To.Focus()
                Exit Sub
            Else
                If Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Date >= Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Date Then
                    BINDDATA()
                Else
                    MsgBox("Effective Date (To) is < Effective Date (From).")
                    Me.tsReport_txtDate_To.Focus()
                    Exit Sub
                End If

            End If
        End If
    End Sub
    Private Sub tsReport_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Export.Click
        XPort2Xcel()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvForm.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY CANCELATION LISTING DETAILS"
                .Cells(2, 1) = "Cancellation Date From : " & Me.tsReport_txtDate_From.Text.Trim() & " To : " & Me.tsReport_txtDate_To.Text.Trim()
                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "FILE NO"
                .Cells(5, 3) = "IC"
                .Cells(5, 4) = "FULL NAME"
                .Cells(5, 5) = "PLAN CODE"
                .Cells(5, 6) = "PLAN TYPE"
                .Cells(5, 7) = "EFFECTIVE DATE"
                .Cells(5, 8) = "CANCELLATION DATE"
                .Cells(5, 9) = "CANCELLATION REASON"
                .Cells(5, 10) = "REMARKS"


                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvForm.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvForm.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvForm.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvForm.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvForm.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvForm.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvForm.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvForm.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvForm.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvForm.Rows(iCount).Cells(8).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: PRODUCTION SUMMARY REPORT")
            xApp.Visible = True
        End If
    End Sub
End Class