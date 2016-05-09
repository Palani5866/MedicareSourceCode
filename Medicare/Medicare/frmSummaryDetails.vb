Public Class frmSummaryDetails
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
#End Region
    Private Sub frmSummaryDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frmSummaryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
        Select Case Me.lblRTYPE.Text.ToString.Trim()
            Case "PDS"
                Me.Text = "PENDING DEDUCTION SUMMARY"
            Case "NCS"
                Me.Text = "NEW POLICY SUMMARY"
            Case "EPS"
                Me.Text = "EXISTING POLICY SUMMARY"
            Case "SS"
                Me.Text = "SUBMISSION SUMMARY (TO DEDUCTION AGENCIES)"
            Case "CS"
                Me.Text = "CANCELLATION SUMMARY REPORT"
            Case "ES"
                Me.Text = "ENDORSEMENT SUMMARY REPORT"
        End Select
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _ObjBusi.getDetails_IX(Me.lblP1.Text.ToString.Trim(), Me.lblP2.Text.ToString.Trim(), Me.lblP3.Text.ToString.Trim(), Me.lblP4.Text.Trim(), Me.lblP5.Text.ToString().Trim(), "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvSummaryDetails
                .DataSource = dt
                Me.tslblRCount.Text = "Total Records : " & dt.Rows.Count
            End With
        Else
            Me.dgvSummaryDetails.DataSource = dt
            Me.tslblRCount.Text = "Total Records : 0 "
            MsgBox("No Record Found!")
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
    Private Sub tsbExport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExport2Xcel.Click
        If Me.lblRTYPE.Text.ToString.Trim() = "CS" Then
            XPort2XcelCS()
        ElseIf Me.lblRTYPE.Text.ToString.Trim() = "ES" Then
            XPort2XcelES()
        Else
            XPort2Xcel()
        End If

    End Sub
    Private Sub XPort2XcelES()
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
                .Cells(1, 1) = "ENDORSEMENT SUMMARY DETAILS"
                .Cells(2, 1) = "Exported On : " & Now()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "EFFECTIVE DATE"
                .Cells(4, 3) = "FILE NO"
                .Cells(4, 4) = "FULL NAME"
                .Cells(4, 5) = "IC"
                .Cells(4, 6) = "DEDUCTION CODE"
                .Cells(4, 7) = "POLICY NO"
                .Cells(4, 8) = "REQUEST DATE"
                .Cells(4, 9) = "ENDORSEMENT DETAILS"
                .Cells(4, 10) = "POLICY EXPIRY DATE"
                .Cells(4, 11) = "ENDORS BY"
                .Cells(4, 12) = "REMARKS"

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
                    .Cells(xRowCount, 11) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(10).Value.ToString.Trim
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
    Private Sub XPort2XcelCS()
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
                .Cells(1, 1) = "CANCELLATION SUMMARY DETAILS"
                .Cells(2, 1) = "Exported On : " & Now()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE NO"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "IC"
                .Cells(4, 5) = "DOB"
                .Cells(4, 6) = "PLAN"
                .Cells(4, 7) = "PLAN TYPE"
                .Cells(4, 8) = "PREMIUM"
                .Cells(4, 9) = "POLICY START DATE"
                .Cells(4, 10) = "POLICY CANCEL DATE"
                .Cells(4, 11) = "CANCELLATION REASON"
                .Cells(4, 12) = "ADD1"
                .Cells(4, 13) = "ADD2"
                .Cells(4, 14) = "ADD3"
                .Cells(4, 15) = "ADD4"
                .Cells(4, 16) = "TOWN"
                .Cells(4, 17) = "POST CODE"
                .Cells(4, 18) = "STATE"
                .Cells(4, 19) = "PHONE HOUSE"
                .Cells(4, 20) = "PHONE MOBILE"
                .Cells(4, 21) = "PHONE OFFICE"
                .Cells(4, 22) = "EMAIL"

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
                    .Cells(xRowCount, 11) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 17) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 18) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 19) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(17).Value.ToString.Trim
                    .Cells(xRowCount, 20) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(18).Value.ToString.Trim
                    .Cells(xRowCount, 21) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(19).Value.ToString.Trim
                    .Cells(xRowCount, 22) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(20).Value.ToString.Trim
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
    Private Sub XPort2Xcel()
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
                Select Case Me.lblRTYPE.Text.ToString.Trim()
                    Case "PDS"
                        .Cells(1, 1) = "PENDING DEDUCTION SUMMARY"
                    Case "NCS"
                        .Cells(1, 1) = "NEW POLICY SUMMARY"
                    Case "EPS"
                        .Cells(1, 1) = "EXISTING POLICY SUMMARY"
                    Case "SS"
                        .Cells(1, 1) = "SUBMISSION SUMMARY (TO DEDUCTION AGENCIES)"
                    Case "ES"
                        .Cells(1, 1) = "ENDORSEMENT SUMMARY DETAILS"
                End Select
                .Cells(2, 1) = "Exported On : " & Now()
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE NO"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "IC"
                .Cells(4, 5) = "DOB"
                .Cells(4, 6) = "PLAN"
                .Cells(4, 7) = "PLAN TYPE"
                .Cells(4, 8) = "PREMIUM"
                Select Case Me.lblRTYPE.Text.ToString.Trim()
                    Case "NCS", "EPS"
                        .Cells(4, 9) = "POLICY START DATE"
                    Case Else
                        .Cells(4, 9) = "SUBMISSION DATE"
                End Select
                .Cells(4, 10) = "SUBMITTED ON"
                .Cells(4, 11) = "SUBMITTED BY"
                .Cells(4, 12) = "ADD1"
                .Cells(4, 13) = "ADD2"
                .Cells(4, 14) = "ADD3"
                .Cells(4, 15) = "ADD4"
                .Cells(4, 16) = "TOWN"
                .Cells(4, 17) = "POST CODE"
                .Cells(4, 18) = "STATE"
                .Cells(4, 19) = "PHONE HOUSE"
                .Cells(4, 20) = "PHONE MOBILE"
                .Cells(4, 21) = "PHONE OFFICE"
                .Cells(4, 22) = "EMAIL"

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
                    .Cells(xRowCount, 11) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 17) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 18) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 19) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(17).Value.ToString.Trim
                    .Cells(xRowCount, 20) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(18).Value.ToString.Trim
                    .Cells(xRowCount, 21) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(19).Value.ToString.Trim
                    .Cells(xRowCount, 22) = "'" & Me.dgvSummaryDetails.Rows(iCount).Cells(20).Value.ToString.Trim
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
End Class