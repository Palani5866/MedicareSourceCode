Public Class rSummaryReports
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub rSummaryReports_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub rSummaryReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        If Me.lblSTYPE.Text = "SIN" Then
            Me.Text = "Summary Details for Incomplete"
            Me.dgvSummaryReport.Columns(0).HeaderText = "TOTAL"
            Me.dgvSummaryReport.Columns(1).HeaderText = "TOTAL INCOMPLETE FOLLOWUP"
            Me.dgvSummaryReport.Columns(2).HeaderText = "TOTAL INCOMPLETE NOT FOLLOWUP"
            Me.dgvSummaryReport.Columns(3).HeaderText = "TOTAL INCOMPLETE SELF CLOSED"
            Me.dgvSummaryReport.Columns(4).HeaderText = "TOTAL INCOMPLETE FOLLOWUP CLOSED"
            Me.dgvSummaryReport.Columns(5).HeaderText = "TOTAL INCOMPLETE FOLLOWUP NOT CLOSED"
        ElseIf Me.lblSTYPE.Text = "SNP" Then
            Me.Text = "Summary Details for Non Payment Details"
            Me.dgvSummaryReport.Columns(0).HeaderText = "TOTAL"
            Me.dgvSummaryReport.Columns(1).HeaderText = "TOTAL INFORCE"
            Me.dgvSummaryReport.Columns(2).HeaderText = "TOTAL CANCELLED"
            Me.dgvSummaryReport.Columns(3).Visible = False
            Me.dgvSummaryReport.Columns(4).Visible = False
            Me.dgvSummaryReport.Columns(5).Visible = False
        ElseIf Me.lblSTYPE.Text = "SSF" Then
            Me.Text = "Summary Details for Short Fall Details"
            

            Me.dgvSummaryReport.Columns(0).HeaderText = "TOTAL"
            Me.dgvSummaryReport.Columns(1).HeaderText = "TOTAL INFORCE"
            Me.dgvSummaryReport.Columns(2).HeaderText = "TOTAL CANCELLED"
            Me.dgvSummaryReport.Columns(3).Visible = False
            Me.dgvSummaryReport.Columns(4).Visible = False
            Me.dgvSummaryReport.Columns(5).Visible = False
        ElseIf Me.lblSTYPE.Text = "SRETIREES" Then
            Me.Text = "Summary Details for Retirees"
           

            Me.dgvSummaryReport.Columns(0).HeaderText = "TOTAL"
            Me.dgvSummaryReport.Columns(1).HeaderText = "TOTAL INFORCE"
            Me.dgvSummaryReport.Columns(2).HeaderText = "TOTAL CANCELLED"
            Me.dgvSummaryReport.Columns(3).Visible = False
            Me.dgvSummaryReport.Columns(4).Visible = False
            Me.dgvSummaryReport.Columns(5).Visible = False
        Else
            Me.Text = "Summary Details for Underwriting"
            Me.dgvSummaryReport.Columns(0).HeaderText = "TOTAL"
            Me.dgvSummaryReport.Columns(1).HeaderText = "TOTAL UNDERWRITING FOLLOWUP"
            Me.dgvSummaryReport.Columns(2).HeaderText = "TOTAL UNDERWRITING NOT FOLLOWUP"
            Me.dgvSummaryReport.Columns(3).HeaderText = "TOTAL UNDERWRITING SELF CLOSED"
            Me.dgvSummaryReport.Columns(4).HeaderText = "TOTAL UNDERWRITING FOLLOWUP CLOSED"
            Me.dgvSummaryReport.Columns(5).HeaderText = "TOTAL UNDERWRITING FOLLOWUP NOT CLOSED"
        End If
        Me.txtDateFrom.Text = Format(Now(), "dd/MM/yyyy")
        Me.txtDateTo.Text = Format(Now(), "dd/MM/yyyy")
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
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _objBusi.getDetails_VII("PROPOSER", DateFrom, DateTo, "", "", "", "", "", "", "", Me.lblSTYPE.Text.ToString.Trim(), Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvSummaryReport
                .DataSource = dt
            End With
        Else
            MsgBox("No record found!")
            Me.dgvSummaryReport.DataSource = dt
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
    Private Sub btnXPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXPort.Click
        If Me.lblSTYPE.Text = "SIN" Then
            XPort2Xcel()
        Else
            UWXPort2Xcel()
        End If
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvSummaryReport.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()

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

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvSummaryReport.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvSummaryReport.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvSummaryReport.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvSummaryReport.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvSummaryReport.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvSummaryReport.Rows(iCount).Cells(4).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()

            xApp.Visible = True
        End If
    End Sub
    Private Sub UWXPort2Xcel()
        If Me.dgvSummaryReport.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()

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
                .Cells(4, 3) = "TOTAL UNDERWRITING"
                .Cells(4, 4) = "TOTAL UNDERWRITING FOLLOW UP"
                .Cells(4, 5) = "TOTAL UNDERWRITING NOT FOLLOW UP"
                .Cells(4, 6) = "TOTAL UNDERWRITING FOLLOW UP CLOSED"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvSummaryReport.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvSummaryReport.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvSummaryReport.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvSummaryReport.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvSummaryReport.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvSummaryReport.Rows(iCount).Cells(4).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With

            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        End If
    End Sub
    Private Sub dgvSummaryReport_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSummaryReport.CellContentClick
        With Me.dgvSummaryReport
            If e.ColumnIndex = 1 Then
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
                    If Me.lblSTYPE.Text = "SIN" Then
                        vFSD.lblP5.Text = "TOTAL1D"
                    ElseIf Me.lblSTYPE.Text = "SNP" Then
                        vFSD.lblP5.Text = "TOTAL1NP"
                        vFSD.lblP1.Text = "MEMBER"
                    ElseIf Me.lblSTYPE.Text = "SSF" Then
                        vFSD.lblP5.Text = "TOTAL1SF"
                        vFSD.lblP1.Text = "MEMBER"
                    ElseIf Me.lblSTYPE.Text = "SRETIREES" Then
                        vFSD.lblP5.Text = "TOTAL1RETIREES"
                        vFSD.lblP1.Text = "MEMBER"
                    Else
                        vFSD.lblP5.Text = "TOTAL1U"
                    End If
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
                    If Me.lblSTYPE.Text = "SIN" Then
                        vFSD.lblP5.Text = "TOTAL12D"
                    ElseIf Me.lblSTYPE.Text = "SNP" Then
                        vFSD.lblP5.Text = "TOTAL12NP"
                        vFSD.lblP1.Text = "MEMBER"
                    ElseIf Me.lblSTYPE.Text = "SSF" Then
                        vFSD.lblP5.Text = "TOTAL12SF"
                        vFSD.lblP1.Text = "MEMBER"
                    ElseIf Me.lblSTYPE.Text = "SRETIREES" Then
                        vFSD.lblP5.Text = "TOTAL12RETIREES"
                        vFSD.lblP1.Text = "MEMBER"
                    Else
                        vFSD.lblP5.Text = "TOTAL12U"
                    End If

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
                    If Me.lblSTYPE.Text = "SIN" Then
                        vFSD.lblP5.Text = "TOTAL13D"
                    ElseIf Me.lblSTYPE.Text = "SNP" Then
                        vFSD.lblP5.Text = "TOTAL13NP"
                        vFSD.lblP1.Text = "MEMBER"
                    ElseIf Me.lblSTYPE.Text = "SSF" Then
                        vFSD.lblP5.Text = "TOTAL13SF"
                        vFSD.lblP1.Text = "MEMBER"
                    ElseIf Me.lblSTYPE.Text = "SRETIREES" Then
                        vFSD.lblP5.Text = "TOTAL13RETIREES"
                        vFSD.lblP1.Text = "MEMBER"
                    Else
                        vFSD.lblP5.Text = "TOTAL13U"
                    End If

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
                    If Me.lblSTYPE.Text = "SIN" Then
                        vFSD.lblP5.Text = "TOTAL14D"
                    ElseIf Me.lblSTYPE.Text = "SNP" Then
                        vFSD.lblP5.Text = "TOTAL14NP"
                        vFSD.lblP1.Text = "MEMBER"
                    ElseIf Me.lblSTYPE.Text = "SSF" Then
                        vFSD.lblP5.Text = "TOTAL14SF"
                        vFSD.lblP1.Text = "MEMBER"
                    ElseIf Me.lblSTYPE.Text = "SRETIREES" Then
                        vFSD.lblP5.Text = "TOTAL14RETIREES"
                        vFSD.lblP1.Text = "MEMBER"
                    Else
                        vFSD.lblP5.Text = "TOTAL14U"
                    End If

                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 5 Then
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
                    If Me.lblSTYPE.Text = "SIN" Then
                        vFSD.lblP5.Text = "TOTAL15D"
                    ElseIf Me.lblSTYPE.Text = "SNP" Then
                        vFSD.lblP5.Text = "TOTAL15NP"
                        vFSD.lblP1.Text = "MEMBER"
                    ElseIf Me.lblSTYPE.Text = "SSF" Then
                        vFSD.lblP5.Text = "TOTAL15SF"
                        vFSD.lblP1.Text = "MEMBER"
                    ElseIf Me.lblSTYPE.Text = "SRETIREES" Then
                        vFSD.lblP5.Text = "TOTAL15RETIREES"
                        vFSD.lblP1.Text = "MEMBER"
                    Else
                        vFSD.lblP5.Text = "TOTAL15U"
                    End If

                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
    End Sub
End Class