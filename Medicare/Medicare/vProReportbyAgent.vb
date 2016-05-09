Public Class vProReportbyAgent
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim sSearchBy As String
    Private Sub vProReportbyAgent_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If

    End Sub
    Private Sub vProReportbyAgent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.txtDateFrom.Text = Format(Now(), "dd/MM/yyyy")
        Me.txtDateTo.Text = Format(Now(), "dd/MM/yyyy")
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        If fVerify() Then
            sBindData()
        End If
    End Sub
    Private Function fVerify() As Boolean
        If Me.tscbSearchBy.SelectedIndex = -1 Then
            MsgBox("Please select the search by")
            Return False
        End If
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
                MsgBox("Please do key in the Expiry Date (To) in the right format (dd/mm/yyyy).")
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
    Private Sub sBindData()
        Dim FromDay As String = Convert.ToDateTime(Me.txtDateFrom.Text).Day
        Dim FromMonth As String = Convert.ToDateTime(Me.txtDateFrom.Text).Month
        Dim FromYear As String = Convert.ToDateTime(Me.txtDateFrom.Text).Year
        Dim DateFrom As String = FromMonth & "/" & FromDay & "/" & FromYear

        Dim ToDay As String = Convert.ToDateTime(Me.txtDateTo.Text).Day
        Dim ToMonth As String = Convert.ToDateTime(Me.txtDateTo.Text).Month
        Dim ToYear As String = Convert.ToDateTime(Me.txtDateTo.Text).Year
        Dim DateTo As String = ToMonth & "/" & ToDay & "/" & ToYear
        Dim dt As New DataTable
        Select Case Me.tscbSearchBy.SelectedIndex
            Case 0
                sSearchBy = "PRD"
            Case 1
                sSearchBy = "SD"
        End Select
        dt = _objBusi.getSummaryReports("PROPOSER", DateFrom, DateTo, "", "", "", "", "", "", sSearchBy, "AGENTSUMMARY", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvSummary
                .DataSource = dt
            End With
        Else
            MsgBox("No record found!")
            Me.dgvSummary.DataSource = dt
        End If
    End Sub
    Private Sub btnXPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXPort.Click
        XPort2Xcel()
    End Sub
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
                .Cells(1, 1) = "AGENT PRODUCTION SUMMARY REPORT"
                .Cells(2, 1) = "Date From : " & Me.txtDateFrom.Text.Trim() & " To : " & Me.txtDateTo.Text.Trim()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "AGENT CODE"
                .Cells(4, 3) = "AGENT NAME"
                .Cells(4, 4) = "TOTAL"
                .Cells(4, 5) = "CUEPACS CARE TOTAL"
                .Cells(4, 6) = "CUEPACS CARE (EMPLPYEE AND FAMILY)"
                .Cells(4, 7) = "CUEPACS CARE (EMPLOYEE ONLY)"
                .Cells(4, 8) = "CUEPACS PA TOTAL"
                .Cells(4, 9) = "CUEPACS PA (PLAN A)"
                .Cells(4, 10) = "CUEPACS PA (PLAN B)"
                .Cells(4, 11) = "REMARKS"

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
                    .Cells(xRowCount, 11) = "'" & ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: AGENT PRODUCTION SUMMARY REPORT")
            xApp.Visible = True
        End If
    End Sub
    Private Sub dgvSummary_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSummary.CellContentClick
        With Me.dgvSummary
            If e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim vPSD As New rPSummaryDetails
                vPSD.lblStatus.Text = "ALL"
                vPSD.lblAgentCode.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                vPSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                vPSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                vPSD.lblSearchBy.Text = sSearchBy
                vPSD.lblTYPE.Text = "AS"
                vPSD.Show()
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(3).Value = "0" Then
                    Dim vPSD As New rPSummaryDetails
                    vPSD.lblStatus.Text = "CC"
                    vPSD.lblAgentCode.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                    vPSD.lblSearchBy.Text = sSearchBy
                    vPSD.lblPLAN.Text = "ALL"
                    vPSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vPSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vPSD.lblTYPE.Text = "AS"
                    vPSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(4).Value = "0" Then
                    Dim vPSD As New rPSummaryDetails
                    vPSD.lblStatus.Text = "CC"
                    vPSD.lblAgentCode.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                    vPSD.lblPLAN.Text = "EMPLOYEE AND FAMILY ONLY"
                    vPSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vPSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vPSD.lblTYPE.Text = "AS"
                    vPSD.lblSearchBy.Text = sSearchBy
                    vPSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(5).Value = "0" Then
                    Dim vPSD As New rPSummaryDetails
                    vPSD.lblStatus.Text = "CC"
                    vPSD.lblAgentCode.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                    vPSD.lblPLAN.Text = "EMPLOYEE ONLY"
                    vPSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vPSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vPSD.lblTYPE.Text = "AS"
                    vPSD.lblSearchBy.Text = sSearchBy
                    vPSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 6 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(6).Value = "0" Then
                    Dim vPSD As New rPSummaryDetails
                    vPSD.lblStatus.Text = "CPA"
                    vPSD.lblAgentCode.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                    vPSD.lblPLAN.Text = "ALL"
                    vPSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vPSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vPSD.lblTYPE.Text = "AS"
                    vPSD.lblSearchBy.Text = sSearchBy
                    vPSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 7 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(7).Value = "0" Then
                    Dim vPSD As New rPSummaryDetails
                    vPSD.lblStatus.Text = "CPA"
                    vPSD.lblAgentCode.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                    vPSD.lblPLAN.Text = "CUEPACS PA PLAN A"
                    vPSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vPSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vPSD.lblTYPE.Text = "AS"
                    vPSD.lblSearchBy.Text = sSearchBy
                    vPSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 8 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(8).Value = "0" Then
                    Dim vPSD As New rPSummaryDetails
                    vPSD.lblStatus.Text = "CPA"
                    vPSD.lblAgentCode.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                    vPSD.lblPLAN.Text = "CUEPACS PA PLAN B"
                    vPSD.lblDateFrom.Text = Me.txtDateFrom.Text.Trim()
                    vPSD.lblDateTo.Text = Me.txtDateTo.Text.Trim()
                    vPSD.lblTYPE.Text = "AS"
                    vPSD.lblSearchBy.Text = sSearchBy
                    vPSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
    End Sub
End Class