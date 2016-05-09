Public Class rPSummaryDetails
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub rPSummaryDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub rPSummaryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        If Me.lblTYPE.Text.Trim() = "AS" Then
            ASBINDDATA()
        Else
            BINDDATA()
        End If
    End Sub
    Private Sub ASBINDDATA()
        Dim FromDay As String = Convert.ToDateTime(Me.lblDateFrom.Text).Day
        Dim FromMonth As String = Convert.ToDateTime(Me.lblDateFrom.Text).Month
        Dim FromYear As String = Convert.ToDateTime(Me.lblDateFrom.Text).Year
        Dim DateFrom As String = FromMonth & "/" & FromDay & "/" & FromYear

        Dim ToDay As String = Convert.ToDateTime(Me.lblDateTo.Text).Day
        Dim ToMonth As String = Convert.ToDateTime(Me.lblDateTo.Text).Month
        Dim ToYear As String = Convert.ToDateTime(Me.lblDateTo.Text).Year
        Dim DateTo As String = ToMonth & "/" & ToDay & "/" & ToYear
        Dim dt As New DataTable
        dt = _objBusi.getSummaryReports("PROPOSER", DateFrom, DateTo, Me.lblStatus.Text.ToString(), Me.lblAgentCode.Text.Trim(), Me.lblPLAN.Text.Trim(), "", "", Me.lblSearchBy.Text.Trim(), "", "AGENTSUMMARYDETAILS", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvSummaryDetails
                .DataSource = dt
            End With
        Else
            MsgBox("No Record Found")
        End If
    End Sub
    Private Sub BINDDATA()
        Dim FromDay As String = Convert.ToDateTime(Me.lblDateFrom.Text).Day
        Dim FromMonth As String = Convert.ToDateTime(Me.lblDateFrom.Text).Month
        Dim FromYear As String = Convert.ToDateTime(Me.lblDateFrom.Text).Year
        Dim DateFrom As String = FromMonth & "/" & FromDay & "/" & FromYear

        Dim ToDay As String = Convert.ToDateTime(Me.lblDateTo.Text).Day
        Dim ToMonth As String = Convert.ToDateTime(Me.lblDateTo.Text).Month
        Dim ToYear As String = Convert.ToDateTime(Me.lblDateTo.Text).Year
        Dim DateTo As String = ToMonth & "/" & ToDay & "/" & ToYear
        Dim dt As New DataTable
        dt = _objBusi.getSummaryReports("PROPOSER", DateFrom, DateTo, Me.lblStatus.Text.ToString().Trim(), Me.lblPLAN.Text.Trim(), "", "", "", Me.lblSearchBy.Text.Trim(), Me.lblAgentCode.Text.ToString.Trim(), "SUMMARYDETAILS", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvSummaryDetails
                .DataSource = dt
            End With
        Else
            MsgBox("No Record Found")
        End If
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvSummaryDetails.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PRODUCTION SUMMARY DETAIL REPORT"
                .Cells(2, 1) = "STATUS : " & Me.lblStatus.Text.Trim()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "PLAN TYPE"
                .Cells(4, 6) = "STATUS"
                .Cells(4, 7) = "DECLINE REASON"
                .Cells(4, 8) = "FILE NO"
                .Cells(4, 9) = "PROPOSAL RECEIVED DATE"
                .Cells(4, 10) = "VERIFIED ON"
                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvSummaryDetails.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(8).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: PRODUCTION SUMMARY DETAIL REPORT")
            xApp.Visible = True
        Else
            MsgBox("No Record found!")
        End If
    End Sub
    Private Sub ASXPort2Xcel()
        If Me.dgvSummaryDetails.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "AGENT PRODUCTION SUMMARY DETAIL REPORT"
                .Cells(2, 1) = "AGENT CODE : " & Me.lblAgentCode.Text.Trim()
                .Cells(3, 1) = "AGENT NAME : " & Me.dgvSummaryDetails.Rows(0).Cells(1).Value.ToString.Trim
                .Cells(4, 1) = "EXPORTED ON : " & Now()

                .Cells(6, 1) = "NO"
                .Cells(6, 2) = "FILE NO"
                .Cells(6, 3) = "PROPOSAL RECEIVED DATE"
                .Cells(6, 4) = "SUBMISSION DATE"
                .Cells(6, 5) = "POLICY START DATE"
                .Cells(6, 6) = "POLICY END DATE"
                .Cells(6, 7) = "IC"
                .Cells(6, 8) = "FULL NAME"
                .Cells(6, 9) = "PLAN TYPE"
                .Cells(6, 10) = "STATUS"
                .Cells(6, 11) = "DECLINE REASON"

                Dim xRowCount As Integer = 7
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvSummaryDetails.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 6).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(11).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            MsgBox("No Record found!")
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
        If Me.lblTYPE.Text.Trim() = "AS" Then
            ASXPort2Xcel()
        Else
            XPort2Xcel()
        End If
    End Sub
End Class