Public Class rSA
   
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim dFrom, d2 As String
    Private Sub rSA_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub rSA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindCB()
        Me.tsReport_txtDate_From.Text = Now().Date
        Me.tsReport_txtDate_To.Text = Now().Date
    End Sub
    Private Sub BindCB()
        Dim dt As New DataTable
        dt = _objBusi.getDetails_I("USER", "", "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow
            dr = dt.NewRow()
            dr("UserID") = "ALL"
            dr("Full_Name") = "ALL"
            dt.Rows.InsertAt(dr, 0)
            Me.tscbStaffName.ComboBox.DataSource = dt
            Me.tscbStaffName.ComboBox.DisplayMember = "Full_Name"
            Me.tscbStaffName.ComboBox.ValueMember = "UserID"
        End If
    End Sub

    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tscbStaffName.Text.Trim) = 0 Then
            MsgBox("Required Staff Name.")
            Me.tscbStaffName.Focus()
            Exit Sub
        End If

        If Len(Me.tsReport_txtDate_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the From date (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        End If

        If Len(Me.tsReport_txtDate_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the To date (dd/mm/yyyy).")
            Me.tsReport_txtDate_To.Focus()
            Exit Sub
        End If

        If IsDate(Me.tsReport_txtDate_From.Text) = False Then
            MsgBox("Please do key in the From date in the right format (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        Else
            If IsDate(Me.tsReport_txtDate_To.Text) = False Then
                MsgBox("Please do key in the To date in the right format (dd/mm/yyyy).")
                Me.tsReport_txtDate_To.Focus()
                Exit Sub
            Else
                If Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Date >= Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Date Then
                    Me.BindData()
                Else
                    MsgBox("To date is < From date.")
                    Me.tsReport_txtDate_To.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub BindData()
        Dim FrmD As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
        Dim FrmM As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
        Dim FrmY As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
        Dim DFrm As String = FrmM & "/" & FrmD & "/" & FrmY

        Dim ToD As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
        Dim ToM As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
        Dim ToY As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
        Dim DTo As String = ToM & "/" & ToD & "/" & ToY
        dFrom = DFrm
        d2 = DTo
        Dim dt As New DataTable
        If Me.tscbStaffName.Text = "ALL" Then
            dt = _objBusi.getDetails_I("USER", DFrm, DTo, Me.tscbStaffName.Text.Trim(), "", "", "", "", "", "ALL", "SA", Conn)
        Else
            dt = _objBusi.getDetails_I("USER", DFrm, DTo, Me.tscbStaffName.Text.Trim(), "", "", "", "", "", "BYUSER", "SA", Conn)
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvSA
                .DataSource = dt
            End With
        Else
            Me.dgvSA.DataSource = dt
            MsgBox("No record found")
        End If
    End Sub
    Sub Xport2Xcel()
        If Me.dgvSA.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "Staff Activity Report "
                .Cells(2, 1) = "Staff Name : " & Me.tscbStaffName.Text.Trim()
                .Cells(3, 1) = "Date From :" & dFrom & " To : " & d2

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "DATE"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "TOTAL"
                .Cells(5, 5) = "VERIFIED"
                .Cells(5, 6) = "CC INDIVIDUAL"
                .Cells(5, 7) = "CC FAMILY"
                .Cells(5, 8) = "CC TOTAL"
                .Cells(5, 9) = "C PA PLAN A"
                .Cells(5, 10) = "C PA PLAN B"
                .Cells(5, 11) = "C PA TOTAL"


                Dim xRowCount As Integer = 6
                Dim drgvRowCount As Integer = 0

                Do While drgvRowCount < dgvSA.Rows.Count
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dgvSA.Rows(drgvRowCount).Cells(0).Value
                    .Cells(xRowCount, 3) = "'" & dgvSA.Rows(drgvRowCount).Cells(1).Value
                    .Cells(xRowCount, 4) = "'" & dgvSA.Rows(drgvRowCount).Cells(2).Value
                    .Cells(xRowCount, 5) = "'" & dgvSA.Rows(drgvRowCount).Cells(3).Value
                    .Cells(xRowCount, 6) = "'" & dgvSA.Rows(drgvRowCount).Cells(4).Value
                    .Cells(xRowCount, 7) = "'" & dgvSA.Rows(drgvRowCount).Cells(5).Value
                    .Cells(xRowCount, 8) = "'" & dgvSA.Rows(drgvRowCount).Cells(6).Value
                    .Cells(xRowCount, 9) = "'" & dgvSA.Rows(drgvRowCount).Cells(7).Value
                    .Cells(xRowCount, 10) = "'" & dgvSA.Rows(drgvRowCount).Cells(8).Value
                    .Cells(xRowCount, 11) = "'" & dgvSA.Rows(drgvRowCount).Cells(9).Value
                    xRowCount += 1
                    drgvRowCount += 1
                Loop
            End With
            MsgBox("Exporting records to Staff Activity Details completed.")
            xApp.Visible = True
        End If
    End Sub
    Private Sub tsbXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbXport2Xcel.Click
        Xport2Xcel()
    End Sub
End Class