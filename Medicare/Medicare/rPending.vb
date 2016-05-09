Public Class rPending
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
#End Region
#Region "Page Events"
    Private Sub rPending_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub rPending_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tstxtDateFrom.Text = Format(Now(), "dd/MM/yyyy")
        Me.tstxtDateTo.Text = Format(Now(), "dd/MM/yyyy")

        Select Case Me.lblRTYPE.Text.ToString.Trim()
            Case "INCOMPLETE"
                Me.Text = "PROPOSAL INCOMPLETE LISTING"
            Case "UW"
                Me.Text = "PROPOSAL UNDERWRITING LISTING"
            Case "DEDUCTION"
                Me.Text = "SUBMITTED PROPOSAL PENDING DEDUCTION LISTING"
            Case "REJECTED60"
                Me.Text = "PROPOSAL REJECTED 60 % LISTING"
        End Select
    End Sub
#End Region
#Region "Data Bind"
    Private Sub BINDDATA()
        Dim FromDay As String = Convert.ToDateTime(Me.tstxtDateFrom.Text).Day
        Dim FromMonth As String = Convert.ToDateTime(Me.tstxtDateFrom.Text).Month
        Dim FromYear As String = Convert.ToDateTime(Me.tstxtDateFrom.Text).Year
        Dim DateFrom As String = FromMonth & "/" & FromDay & "/" & FromYear

        Dim ToDay As String = Convert.ToDateTime(Me.tstxtDateTo.Text).Day
        Dim ToMonth As String = Convert.ToDateTime(Me.tstxtDateTo.Text).Month
        Dim ToYear As String = Convert.ToDateTime(Me.tstxtDateTo.Text).Year
        Dim DateTo As String = ToMonth & "/" & ToDay & "/" & ToYear

        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _ObjBusi.getDetails_II("PPENDING", Me.lblRTYPE.Text.ToString.Trim(), DateFrom, DateTo, "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvPendingDetails
                .DataSource = dt
                Me.ssReport_RecordCount.Text = "Record #: " & dt.Rows.Count.ToString.Trim()
                Me.ssReport_RecordCount.Visible = True
            End With
        Else
            MsgBox("No record found")
            Me.ssReport_RecordCount.Visible = True
            Me.ssReport_RecordCount.Text = "Record #: 0"
            Me.dgvPendingDetails.DataSource = dt
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub tsbExport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExport2Xcel.Click
        Select Case Me.lblRTYPE.Text.ToString.Trim()
            Case "DEDUCTION"
                XPort2XcelI()
            Case Else
                XPort2Xcel()
        End Select
    End Sub
#End Region
#Region "Export to Excel"
    Private Sub XPort2Xcel()
        If Me.dgvPendingDetails.Rows.Count > 0 Then
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
                    Case "INCOMPLETE"
                        .Cells(1, 1) = "PROPOSAL INCOMPLETE LISTING"
                    Case "UW"
                        .Cells(1, 1) = "PROPOSAL UNDERWRITING LISTING"
                    Case "DEDUCTION"
                        .Cells(1, 1) = "PROPOSAL PENDING DEDUCTION LISTING"
                    Case "REJECTED60"
                        .Cells(1, 1) = "PROPOSAL REJECTED 60 % LISTING"
                End Select
                .Cells(2, 1) = "Exported On : " & Now()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE NO"
                .Cells(4, 3) = "PROPOSER IC"
                .Cells(4, 4) = "FULL NAME"
                .Cells(4, 5) = "DOB"
                .Cells(4, 6) = "PLAN"
                .Cells(4, 7) = "PLAN TYPE"
                .Cells(4, 8) = "PREMIUM"
                .Cells(4, 9) = "PROPOSAL RECEIVED DATE"
                .Cells(4, 10) = "PROPOSAL SIGNED DATE"
                .Cells(4, 11) = "CREATED ON"
                .Cells(4, 12) = "CREATED BY"
                .Cells(4, 13) = "VERIFIED ON"
                .Cells(4, 14) = "VERIFIED BY"
                .Cells(4, 15) = "STATUS"
                .Cells(4, 16) = "REMARKS"
                .Cells(4, 17) = "ADD1"
                .Cells(4, 18) = "ADD2"
                .Cells(4, 19) = "ADD3"
                .Cells(4, 20) = "ADD4"
                .Cells(4, 21) = "TOWN"
                .Cells(4, 22) = "POST CODE"
                .Cells(4, 23) = "STATE"
                .Cells(4, 24) = "PHONE HOUSE"
                .Cells(4, 25) = "PHONE MOBILE"
                .Cells(4, 26) = "PHONE OFFICE"
                .Cells(4, 27) = "EMAIL"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvPendingDetails.RowCount

                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 17) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 18) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 19) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(17).Value.ToString.Trim
                    .Cells(xRowCount, 20) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(18).Value.ToString.Trim
                    .Cells(xRowCount, 21) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(19).Value.ToString.Trim
                    .Cells(xRowCount, 22) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(20).Value.ToString.Trim
                    .Cells(xRowCount, 23) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(21).Value.ToString.Trim
                    .Cells(xRowCount, 24) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(22).Value.ToString.Trim
                    .Cells(xRowCount, 25) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(23).Value.ToString.Trim
                    .Cells(xRowCount, 26) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(24).Value.ToString.Trim
                    .Cells(xRowCount, 27) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(25).Value.ToString.Trim
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
    Private Sub XPort2XcelI()
        If Me.dgvPendingDetails.Rows.Count > 0 Then
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
                    Case "INCOMPLETE"
                        .Cells(1, 1) = "PROPOSAL INCOMPLETE LISTING"
                    Case "UW"
                        .Cells(1, 1) = "PROPOSAL UNDERWRITING LISTING"
                    Case "DEDUCTION"
                        .Cells(1, 1) = "SUBMITTED PROPOSAL PENDING DEDUCTION LISTING"
                    Case "REJECTED60"
                        .Cells(1, 1) = "PROPOSAL REJECTED 60 % LISTING"
                End Select
                .Cells(2, 1) = "Exported On : " & Now()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE NO"
                .Cells(4, 3) = "PROPOSER IC"
                .Cells(4, 4) = "FULL NAME"
                .Cells(4, 5) = "DOB"
                .Cells(4, 6) = "PLAN"
                .Cells(4, 7) = "PLAN TYPE"
                .Cells(4, 8) = "PREMIUM"
                .Cells(4, 9) = "SUBMISSION DATE"
                .Cells(4, 10) = "CREATED ON"
                .Cells(4, 11) = "CREATED BY"
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
                .Cells(4, 23) = "REMARKS"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvPendingDetails.RowCount

                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 17) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 18) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 19) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(17).Value.ToString.Trim
                    .Cells(xRowCount, 20) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(18).Value.ToString.Trim
                    .Cells(xRowCount, 21) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(19).Value.ToString.Trim
                    .Cells(xRowCount, 22) = "'" & Me.dgvPendingDetails.Rows(iCount).Cells(20).Value.ToString.Trim
                    .Cells(xRowCount, 23) = " "
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
#End Region
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
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        If fVerify() Then
            BINDDATA()
        End If
    End Sub
    Private Function fVerify() As Boolean
        If Len(Me.tstxtDateFrom.Text.Trim) = 0 Then
            MsgBox("Please do key in the Date (From) (dd/mm/yyyy).")
            Me.tstxtDateFrom.Focus()
            Return False
        End If
        If Len(Me.tstxtDateTo.Text.Trim) = 0 Then
            MsgBox("Please do key in the Date (To) (dd/mm/yyyy).")
            Me.tstxtDateTo.Focus()
            Return False
        End If
        If IsDate(Me.tstxtDateFrom.Text) = False Then
            MsgBox("Please do key in the Date (From) in the right format (dd/mm/yyyy).")
            Me.tstxtDateFrom.Focus()
            Exit Function
        Else
            If IsDate(Me.tstxtDateTo.Text) = False Then
                MsgBox("Please do key in the  Date (To) in the right format (dd/mm/yyyy).")
                Me.tstxtDateTo.Focus()
                Exit Function
            Else
                If Not Convert.ToDateTime(Me.tstxtDateTo.Text).Date >= Convert.ToDateTime(Me.tstxtDateFrom.Text).Date Then
                    MsgBox("Date (To) is < Date (From).")
                    Me.tstxtDateTo.Focus()
                    Return False
                End If
            End If
        End If
        Return True
    End Function
End Class