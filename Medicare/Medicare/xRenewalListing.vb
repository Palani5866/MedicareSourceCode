Public Class xRenewalListing
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub xRenewalListing_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub xRenewalListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tsReport_txtDate_From.Text = Format(Now(), "dd/MM/yyyy")
        Me.tsReport_txtDate_To.Text = Format(Now(), "dd/MM/yyyy")
    End Sub
    Private Sub BINDDATA()
        Dim var_Renew_From_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
        Dim var_Renew_From_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
        Dim var_Renew_From_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
        Dim var_Renewal_Date_From As String = var_Renew_From_Month & "/" & var_Renew_From_Day & "/" & var_Renew_From_Year

        Dim var_Renew_To_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
        Dim var_Renew_To_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
        Dim var_Renew_To_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
        Dim var_Renewal_Date_To As String = var_Renew_To_Month & "/" & var_Renew_To_Day & "/" & var_Renew_To_Year

        Dim dt As New DataTable
        dt = _objBusi.getDetails("RENEWAL", var_Renewal_Date_From, var_Renewal_Date_To, "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvRenewal
                .DataSource = dt
                .Columns(0).HeaderText = "POLICY #"
                .Columns(1).HeaderText = "FULL NAME"
                .Columns(2).HeaderText = "IC"
                .Columns(3).HeaderText = "DEDUCTION AMOUNT"
                .Columns(4).HeaderText = "PLAN"
                .Columns(5).HeaderText = "EXPIRY DATE"
                .Columns(6).HeaderText = "FILE #"
                .Columns(7).HeaderText = "TELE PHONE"

                .Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns(3).DefaultCellStyle.Format = "#,#00.00"
            End With
        End If
    End Sub

    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tsReport_txtDate_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Renewal From date (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        End If

        If Len(Me.tsReport_txtDate_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the Renewal To date (dd/mm/yyyy).")
            Me.tsReport_txtDate_To.Focus()
            Exit Sub
        End If

        If IsDate(Me.tsReport_txtDate_From.Text) = False Then
            MsgBox("Please do key in the Renewal From date in the right format (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        Else
            If IsDate(Me.tsReport_txtDate_To.Text) = False Then
                MsgBox("Please do key in the Renewal To date in the right format (dd/mm/yyyy).")
                Me.tsReport_txtDate_To.Focus()
                Exit Sub
            Else
                If Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Date >= Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Date Then
                    Me.BINDDATA()
                Else
                    MsgBox("Renewal To date is < Renewal From date.")
                    Me.tsReport_txtDate_To.Focus()
                    Exit Sub
                End If

            End If
        End If
    End Sub
    Private Sub tsReport_Xport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Xport.Click
        If Me.dgvRenewal.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
            xls_workbook = xls_file.Workbooks.Add
            Dim xls_wks_name As String = ""
            xls_workbook.Worksheets.Add()
            xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim
            With xls_workbook.Worksheets(xls_wks_name)
                .Cells(1, 1) = "RENEWAL LISTING"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "POLICY #"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "IC"
                .Cells(4, 5) = "GROSS PREMIUM"
                .Cells(4, 6) = "PLAN"
                .Cells(4, 7) = "EXPIRY DATE"
                .Cells(4, 8) = "FILE #"
                .Cells(4, 9) = "TELE PHONE"
                Dim xls_row_counter As Integer = 5
                Dim var_name_count As Integer = 0

                Do While var_name_count < Me.dgvRenewal.Rows.Count - 1
                    .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 4).ToString.Trim
                    .Cells(xls_row_counter, 2) = "'" & Me.dgvRenewal.Rows(var_name_count).Cells(0).Value
                    .Cells(xls_row_counter, 3) = "'" & Me.dgvRenewal.Rows(var_name_count).Cells(1).Value.ToString.Trim
                    .Cells(xls_row_counter, 4) = Me.dgvRenewal.Rows(var_name_count).Cells(2).Value
                    .Cells(xls_row_counter, 5) = "'" & Format(Me.dgvRenewal.Rows(var_name_count).Cells(3).Value, "#,#00.00")
                    .Cells(xls_row_counter, 6) = "'" & Me.dgvRenewal.Rows(var_name_count).Cells(4).Value
                    .Cells(xls_row_counter, 7) = "'" & Format(Me.dgvRenewal.Rows(var_name_count).Cells(5).Value, "dd/MM/yyyy")
                    .Cells(xls_row_counter, 8) = "'" & Me.dgvRenewal.Rows(var_name_count).Cells(6).Value
                    .Cells(xls_row_counter, 9) = "'" & Me.dgvRenewal.Rows(var_name_count).Cells(7).Value
                    xls_row_counter += 1
                    var_name_count += 1
                Loop
            End With
            MsgBox("Exporting records to PRENEWAL LISTING completed.")
            xls_file.Visible = True
        End If
    End Sub

End Class