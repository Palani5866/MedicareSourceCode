Public Class rAgentRequestDetails
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub rAgentRequestDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub rAgentRequestDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.txtDateFrom.Text = Format(Now(), "dd/MM/yyyy")
        Me.txtDateTo.Text = Format(Now(), "dd/MM/yyyy")
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
    Private Sub BINDDATA()
        Dim FromDay As String = Convert.ToDateTime(Me.txtDateFrom.Text).Day
        Dim FromMonth As String = Convert.ToDateTime(Me.txtDateFrom.Text).Month
        Dim FromYear As String = Convert.ToDateTime(Me.txtDateFrom.Text).Year
        Dim DateFrom As String = FromMonth & "/" & FromDay & "/" & FromYear

        Dim ToDay As String = Convert.ToDateTime(Me.txtDateTo.Text).Day
        Dim ToMonth As String = Convert.ToDateTime(Me.txtDateTo.Text).Month
        Dim ToYear As String = Convert.ToDateTime(Me.txtDateTo.Text).Year
        Dim DateTo As String = ToMonth & "/" & ToDay & "/" & ToYear
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        ds = _objBusi.getDSDetails_VII("AGENTREQUEST", DateFrom, DateTo, "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvAgentRequestDetails
                .DataSource = ds.Tables(0)
                .Columns(2).ReadOnly = True
                .Columns(4).ReadOnly = True
                .Columns(5).ReadOnly = True
                .Columns(6).ReadOnly = True
                .Columns(7).ReadOnly = True
                .Columns(8).ReadOnly = True
                .Columns(9).ReadOnly = True
                .Columns(10).ReadOnly = True
                .Columns(11).ReadOnly = True
                .Columns(12).ReadOnly = True
                .Columns(13).ReadOnly = True
                .Columns(14).ReadOnly = True
                .Columns(15).ReadOnly = True
                .Columns(16).ReadOnly = True
                .Columns(17).ReadOnly = True
                .Columns(18).ReadOnly = True
                .Columns(19).ReadOnly = True
                .Columns(20).ReadOnly = True
                .Columns(21).ReadOnly = True
            End With
        Else
            Me.dgvAgentRequestDetails.DataSource = ds.Tables(0)
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvAgentApprovedDetails
                .DataSource = ds.Tables(1)
                .Columns(2).Visible = False
                .Columns(0).DisplayIndex = 19
                .Columns(1).DisplayIndex = 19

            End With
        Else
            Me.dgvAgentApprovedDetails.DataSource = ds.Tables(1)
        End If

        If ds.Tables(2).Rows.Count > 0 Then
            With Me.dgvAgentClosedDetails
                .DataSource = ds.Tables(2)
                .Columns(0).Visible = False
            End With
        Else
            Me.dgvAgentClosedDetails.DataSource = ds.Tables(2)
        End If
    End Sub
    Private Sub dgvAgentRequestDetails_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAgentRequestDetails.CellContentClick
        With Me.dgvAgentRequestDetails
            If e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(4).Value) Then
                    .Columns(1).ReadOnly = False
                    .Columns(2).ReadOnly = False
                    .Columns(3).ReadOnly = False
                    .Columns(4).ReadOnly = False
                    .Columns(5).ReadOnly = False
                    .Columns(6).ReadOnly = False
                    .Columns(7).ReadOnly = False
                    .Columns(8).ReadOnly = False
                    .Columns(9).ReadOnly = False
                    .Columns(10).ReadOnly = False
                    .Columns(11).ReadOnly = False
                    .Columns(12).ReadOnly = False
                    .Columns(13).ReadOnly = False
                    .Columns(14).ReadOnly = False
                    .Columns(15).ReadOnly = False
                    .Columns(16).ReadOnly = False
                    .Columns(17).ReadOnly = False
                    .Columns(18).ReadOnly = False
                    .Columns(19).ReadOnly = False
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(4).Value) Then
                    Dim sRes As String
                    SharedData.ReadyToHideMarquee = False
                    StartMarqueeThread()
                    sRes = _objBusi.IUAGENTREQUEST("UPDATE", .Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(6).Value.ToString().Trim(), "0", .Rows(e.RowIndex).Cells(7).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(8).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(9).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(10).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(11).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(12).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(13).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(14).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(15).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(16).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(17).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(18).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(19).Value.ToString().Trim(), "", "", "", "", "", "", "", "", "", My.Settings.Username.ToUpper.ToString.Trim(), Conn)
                    SyncLock SharedData
                        SharedData.ReadyToHideMarquee = True
                    End SyncLock
                    Application.DoEvents()
                    If sRes = "1" Then
                        MsgBox("Agent updated successfully!")
                        BINDDATA()
                    Else
                        MsgBox("Error while updating Agent Request details!")
                        Exit Sub
                    End If
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(4).Value) Then
                    Dim sRes As String
                    SharedData.ReadyToHideMarquee = False
                    StartMarqueeThread()
                    sRes = _objBusi.IUAGENTREQUEST("APPROVED", .Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(6).Value.ToString().Trim(), "0", .Rows(e.RowIndex).Cells(7).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(8).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(9).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(10).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(11).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(12).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(13).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(14).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(15).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(16).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(17).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(18).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(19).Value.ToString().Trim(), "", "", "", "", "", "", "", My.Settings.Username.ToUpper.ToString.Trim(), "", My.Settings.Username.ToUpper.ToString.Trim(), Conn)
                    SyncLock SharedData
                        SharedData.ReadyToHideMarquee = True
                    End SyncLock
                    Application.DoEvents()
                    If sRes = "1" Then
                        MsgBox("Agent Request Approved!")
                        BINDDATA()
                    Else
                        MsgBox("Error while approved Agent Request details!")
                        Exit Sub
                    End If
                Else
                    MsgBox("No Record Found")
                End If
            End If

        End With
    End Sub
    Private Sub dgvAgentApprovedDetails_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAgentApprovedDetails.CellContentClick
        With Me.dgvAgentApprovedDetails
            If e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(2).Value) Then
                    If IsNothing(.Rows(e.RowIndex).Cells(0).Value) Then
                        MsgBox("Required Posted Date")
                        Exit Sub
                    End If
                    If IsDate(.Rows(e.RowIndex).Cells(0).Value) = False Then
                        MsgBox("Please do key in the Date (Posted) in the right format (dd/MM/yyyy).")
                        Exit Sub
                    End If
                    Dim PostDate As Date
                    PostDate = Convert.ToDateTime(.Rows(e.RowIndex).Cells(0).Value)
                    Dim sRes As String
                    SharedData.ReadyToHideMarquee = False
                    StartMarqueeThread()
                    sRes = _objBusi.IUAGENTREQUEST("POSTED", .Rows(e.RowIndex).Cells(2).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(6).Value.ToString().Trim(), "0", .Rows(e.RowIndex).Cells(7).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(8).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(9).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(10).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(11).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(12).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(13).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(14).Value.ToString().Trim(), "0", "0", "0", "0", "0", "", "", "", "", "", "", Format(PostDate, "MM/dd/yyyy"), My.Settings.Username.ToUpper.ToString.Trim(), "", My.Settings.Username.ToUpper.ToString.Trim(), Conn)
                    SyncLock SharedData
                        SharedData.ReadyToHideMarquee = True
                    End SyncLock
                    Application.DoEvents()
                    If sRes = "1" Then
                        MsgBox("Agent Request Approved!")
                        BINDDATA()
                    Else
                        MsgBox("Error while approved Agent Request details!")
                        Exit Sub
                    End If
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
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

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        BINDDATA()
    End Sub
    Private Sub btnXPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXPort.Click
        XPort2Xcel()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvAgentRequestDetails.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()

            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "AGENT REQUEST DETAILS"
                .Cells(2, 1) = "AGENT CODE " & Me.dgvAgentRequestDetails.Rows(0).Cells(5).Value.ToString.Trim

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "GC FORM"
                .Cells(4, 3) = "CCFORM"
                .Cells(4, 4) = "CPAFORM"
                .Cells(4, 5) = "BIRO"
                .Cells(4, 6) = "NOMINATION"
                .Cells(4, 7) = "FLYERSCC"
                .Cells(4, 8) = "FLYERSCPA"
                .Cells(4, 9) = "BOOKLETCC"
                .Cells(4, 10) = "BOOKLETCPA"
                .Cells(4, 11) = "POSTERCC"
                .Cells(4, 12) = "POSTERCPA"
                .Cells(4, 13) = "NAMECARD"
                .Cells(4, 14) = "BUNTINGCC"
                .Cells(4, 15) = "BUNTINGCPA"
                .Cells(4, 16) = "REQUESTDATE"
                .Cells(4, 17) = "STATUS"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvAgentRequestDetails.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(17).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(18).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(19).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(20).Value.ToString.Trim
                    .Cells(xRowCount, 17) = "'" & Me.dgvAgentRequestDetails.Rows(iCount).Cells(21).Value.ToString.Trim
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