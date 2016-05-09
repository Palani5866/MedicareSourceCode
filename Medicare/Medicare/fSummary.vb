Public Class fSummary
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub fSummary_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.txtDateFrom.Text = Format(Now(), "dd/MM/yyyy")
        Me.txtDateTo.Text = Format(Now(), "dd/MM/yyyy")
        If Me.lblP1.Text.Trim() = "MEMBER" Then
            Me.dgvMFS.Visible = True
            Me.dgvSummary.Visible = False
        Else
            Me.dgvMFS.Visible = False
            Me.dgvSummary.Visible = True
        End If
    End Sub
    Private Sub fBindData()
        Dim FromDay As String = Convert.ToDateTime(Me.txtDateFrom.Text).Day
        Dim FromMonth As String = Convert.ToDateTime(Me.txtDateFrom.Text).Month
        Dim FromYear As String = Convert.ToDateTime(Me.txtDateFrom.Text).Year
        Dim DateFrom As String = FromMonth & "/" & FromDay & "/" & FromYear

        Dim ToDay As String = Convert.ToDateTime(Me.txtDateTo.Text).Day
        Dim ToMonth As String = Convert.ToDateTime(Me.txtDateTo.Text).Month
        Dim ToYear As String = Convert.ToDateTime(Me.txtDateTo.Text).Year
        Dim DateTo As String = ToMonth & "/" & ToDay & "/" & ToYear
        Dim dt As New DataTable
        If Me.lblP1.Text.Trim() = "MEMBER" Then
            dt = _objBusi.getDetails_I("FSUMMARY", DateFrom, DateTo, "", "", "", "", "", "", "MEMBER", "SUMMARY", Conn)
            If dt.Rows.Count > 0 Then
                With Me.dgvMFS
                    .DataSource = dt
                End With
            Else
                MsgBox("No record found!")
                Me.dgvMFS.DataSource = dt
            End If
        Else
            dt = _objBusi.getDetails_I("FSUMMARY", DateFrom, DateTo, "", "", "", "", "", "", "PROPOSER", "SUMMARY", Conn)
            If dt.Rows.Count > 0 Then
                With Me.dgvSummary
                    .DataSource = dt
                End With
            Else
                MsgBox("No record found!")
                Me.dgvSummary.DataSource = dt
            End If
        End If
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        If fVerify() Then
            fBindData()
        End If
    End Sub
    Private Function fVerify() As Boolean
        If Len(Me.txtDateFrom.Text.Trim) = 0 Then
            MsgBox("Please do key in the Date (From) (dd/mm/yyyy).")
            Me.txtDateFrom.Focus()
            Return False
        End If
        If Len(Me.txtDateTo.Text.Trim) = 0 Then
            MsgBox("Please do key in the Date (To) (dd/mm/yyyy).")
            Me.txtDateTo.Focus()
            Return False
        End If
        If IsDate(Me.txtDateFrom.Text) = False Then
            MsgBox("Please do key in the Date (From) in the right format (dd/mm/yyyy).")
            Me.txtDateFrom.Focus()
            Exit Function
        Else
            If IsDate(Me.txtDateTo.Text) = False Then
                MsgBox("Please do key in the Date (To) in the right format (dd/mm/yyyy).")
                Me.txtDateTo.Focus()
                Exit Function
            Else
                If Not Convert.ToDateTime(Me.txtDateTo.Text).Date >= Convert.ToDateTime(Me.txtDateFrom.Text).Date Then
                    MsgBox("Date (To) is < Date (From).")
                    Me.txtDateTo.Focus()
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Private Sub XPort2Xcel()
        If Me.dgvSummary.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "FOLLOW UP SUMMARY REPORT"
                .Cells(2, 1) = "Date From : " & Me.txtDateFrom.Text.Trim() & " To : " & Me.txtDateTo.Text.Trim()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "TOTAL"
                .Cells(4, 3) = "TOTAL INCOMPLETE"
                .Cells(4, 4) = "TOTAL INCOMPLETE FOLLOW UP"
                .Cells(4, 5) = "TOTAL INCOMPLETE NOT FOLLOW UP"
                .Cells(4, 6) = "TOTAL INCOMPLETE FOLLOW UP CLOSED"
                .Cells(4, 7) = "TOTAL UW"
                .Cells(4, 8) = "TOTAL UW FOLLOW UP"
                .Cells(4, 9) = "TOTAL UW NOT FOLLOW UP"
                .Cells(4, 10) = "TOTAL UW FOLLOW UP CLOSED"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvSummary.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvSummary.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvSummary.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvSummary.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvSummary.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvSummary.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvSummary.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvSummary.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvSummary.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvSummary.Rows(iCount).Cells(8).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: FOLLOW UP SUMMARY REPORT")
            xApp.Visible = True
        End If
    End Sub
    Private Sub MXPort2Xcel()
        If Me.dgvMFS.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "FOLLOW UP SUMMARY REPORT"
                .Cells(2, 1) = "Date From : " & Me.txtDateFrom.Text.Trim() & " To : " & Me.txtDateTo.Text.Trim()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "TOTAL PENDING RENEWAL"
                .Cells(4, 3) = "TOTAL PENDING RENEWAL FOLLOW UP"
                .Cells(4, 4) = "TOTAL PENDING RENEWAL NOT FOLLOW UP"
                .Cells(4, 5) = "TOTAL PENDING RENEWAL FOLLOW UP SUCCESSFUL CLOSED"
                .Cells(4, 6) = "TOTAL PENDING RENEWAL FOLLOW UP UNSUCCESSFUL CLOSED"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvMFS.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvMFS.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvMFS.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvMFS.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvMFS.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvMFS.Rows(iCount).Cells(4).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: FOLLOWUP SUMMARY REPORT")
            xApp.Visible = True
        End If
    End Sub
    Private Sub btnXPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXPort.Click
        If Me.lblP1.Text.Trim() = "MEMBER" Then
            MXPort2Xcel()
        Else
            XPort2Xcel()
        End If
    End Sub
    Private Sub dgvSummary_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSummary.CellContentClick
        With Me.dgvSummary
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim vFSD As New fSummaryDetails
                vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                vFSD.lblP1.Text = ""
                vFSD.lblP2.Text = ""
                vFSD.lblP3.Text = ""
                vFSD.lblP4.Text = ""
                vFSD.lblP5.Text = "TOTAL"
                vFSD.Show()
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(1).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = ""
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOT1D"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(2).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = ""
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOT1DFUP"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(3).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = ""
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOT1DNFUP"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(4).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = ""
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOT1DFUPC"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(5).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = ""
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOT1U"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 6 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(6).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = ""
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOT1UFUP"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 7 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(7).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = ""
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOT1UNFUP"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 8 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(8).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = ""
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOT1UFUPC"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
    End Sub
    Private Sub dgvMFS_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMFS.CellContentClick
        With Me.dgvMFS
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim vFSD As New fSummaryDetails
                vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                vFSD.lblP1.Text = Me.lblP1.Text.Trim()
                vFSD.lblP2.Text = ""
                vFSD.lblP3.Text = ""
                vFSD.lblP4.Text = ""
                vFSD.lblP5.Text = "TOTAL"
                vFSD.Show()
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(1).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = Me.lblP1.Text.Trim()
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOTPRFUP"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(2).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = Me.lblP1.Text.Trim()
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOTPRNFUP"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(3).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = Me.lblP1.Text.Trim()
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOTPRFUPSC"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(4).Value = "0" Then
                    Dim vFSD As New fSummaryDetails
                    vFSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vFSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vFSD.lblP1.Text = Me.lblP1.Text.Trim()
                    vFSD.lblP2.Text = ""
                    vFSD.lblP3.Text = ""
                    vFSD.lblP4.Text = ""
                    vFSD.lblP5.Text = "TOTPRFUPNSC"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
    End Sub
End Class