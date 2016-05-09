Public Class fClientRequestSubmission
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Dim varDate_From, varDate_To As String
    Private Sub fClientRequestSubmission_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fClientRequestSubmission_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tstxtDate_From.Text = Format(Now(), "dd/MM/yyyy")
        Me.tstxtDate_To.Text = Format(Now(), "dd/MM/yyyy")
    End Sub
    Private Sub BINDDATA()
        Dim varFrom_Day As String = Convert.ToDateTime(Me.tstxtDate_From.Text).Day
        Dim varFrom_Month As String = Convert.ToDateTime(Me.tstxtDate_From.Text).Month
        Dim varFrom_Year As String = Convert.ToDateTime(Me.tstxtDate_From.Text).Year
        varDate_From = varFrom_Month & "/" & varFrom_Day & "/" & varFrom_Year

        Dim varTo_Day As String = Convert.ToDateTime(Me.tstxtDate_To.Text).Day
        Dim varTo_Month As String = Convert.ToDateTime(Me.tstxtDate_To.Text).Month
        Dim varTo_Year As String = Convert.ToDateTime(Me.tstxtDate_To.Text).Year
        varDate_To = varTo_Month & "/" & varTo_Day & "/" & varTo_Year
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()

        ds = _ObjBusi.getDsDetails_VI("CRPS", varDate_From, varDate_To, "", "", "", "", "", "", "", "", Conn)

        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()

        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvPendingSubmission
                .DataSource = ds.Tables(0)
                .Columns(1).Visible = False
            End With
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvPendingPost
                .DataSource = ds.Tables(1)

                .Columns(0).DisplayIndex = 11
                .Columns(1).DisplayIndex = 11
                .Columns(2).DisplayIndex = 11
                .Columns(3).DisplayIndex = 11
                .Columns(4).Visible = False
            End With
        End If
        If ds.Tables(2).Rows.Count > 0 Then
            With Me.dgvPostedDetails
                .DataSource = ds.Tables(2)
                .Columns(0).Visible = False
            End With
        End If
    End Sub
#Region "Progress Bar"
    'SharedData.ReadyToHideMarquee = False
    'StartMarqueeThread()
    'EVENTS PLACE
    'SyncLock SharedData
    'SharedData.ReadyToHideMarquee = True
    'End SyncLock
    'Application.DoEvents()
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
        If Len(Me.tstxtDate_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Request Date (From) (dd/mm/yyyy).")
            Me.tstxtDate_From.Focus()
            Exit Sub
        End If

        If Len(Me.tstxtDate_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the Request Date (To) (dd/mm/yyyy).")
            Me.tstxtDate_To.Focus()
            Exit Sub
        End If

        If IsDate(Me.tstxtDate_From.Text) = False Then
            MsgBox("Please do key in the Request Date (From) in the right format (dd/mm/yyyy).")
            Me.tstxtDate_From.Focus()
            Exit Sub
        Else
            If IsDate(Me.tstxtDate_To.Text) = False Then
                MsgBox("Please do key in the Request Date (To) in the right format (dd/mm/yyyy).")
                Me.tstxtDate_To.Focus()
                Exit Sub
            Else
                If Convert.ToDateTime(Me.tstxtDate_To.Text).Date >= Convert.ToDateTime(Me.tstxtDate_From.Text).Date Then
                    BINDDATA()
                Else
                    MsgBox("Request Date (To) is < Request Date (From).")
                    Me.tstxtDate_To.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim sRes As String
        Dim dgvRowCount As Integer
        Dim sBatchNo As String
        sBatchNo = "CR" & Format(Now.Date, "yyMMdd") & "-" & Format(Now, "HHmmss")
        With Me.dgvPendingSubmission
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            
            Do While dgvRowCount < .Rows.Count
                If .Rows(dgvRowCount).Cells(0).Value Then
                    sRes = _ObjBusi.spUpdate("CR", .Rows(dgvRowCount).Cells(1).Value.ToString.Trim(), sBatchNo, My.Settings.Username.ToUpper.ToString.Trim(), "", "", "", "", "", "", "", Conn)
                End If
                dgvRowCount += 1
            Loop
        End With
        If sRes = "1" Then
            MsgBox("Successfully Submitted")
        End If
        XPort2Xcel()
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()

        BINDDATA()
    End Sub
    Private Sub tsbtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExport.Click
        XPort2Xcel()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvPendingSubmission.RowCount > 0 Then
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook

            xWB = xApp.Workbooks.Add
            Dim drCount, XRowCount As Integer
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & (xWB.Worksheets.Count).ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "SUBMISSION TO INSURER"
                .Cells(2, 1) = "FOR REQUEST DATE FROM  " & varDate_From & " To " & varDate_To

                .Cells(4, 1) = "#"
                .Cells(4, 2) = "FULL NAME"
                .Cells(4, 3) = "IC"
            End With
            XRowCount = 5
            Do While drCount < Me.dgvPendingSubmission.Rows.Count
                With Me.dgvPendingSubmission.Rows(drCount)
                    If .Cells(0).Value Then
                        xWB.Worksheets(xWName).Cells(XRowCount, 1) = "'" & (XRowCount - 5).ToString.Trim
                        xWB.Worksheets(xWName).Cells(XRowCount, 2) = .Cells(4).Value.ToString.Trim()
                        xWB.Worksheets(xWName).Cells(XRowCount, 3) = "'" & .Cells(3).Value.ToString.Trim().Replace("C", "")
                        XRowCount += 1
                    End If
                End With
                drCount += 1
            Loop
            xApp.Visible = True
        End If
    End Sub
    Private Sub dgvPendingPost_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendingPost.CellContentClick
        With Me.dgvPendingPost
            If e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(4).Value) Then
                    Dim sRes As String
                    If .Rows(e.RowIndex).Cells(0).Value = "" Then
                        MsgBox("Please do key in the Posted Date!")
                        Exit Sub
                    End If
                    If IsDate(.Rows(e.RowIndex).Cells(0).Value) = False Then
                        MsgBox("Please do key in the Posted Date in the right format (dd/MM/yyyy).")
                        Exit Sub
                    End If
                    If .Rows(e.RowIndex).Cells(1).Value = "" Then
                        MsgBox("Please do key in the remarks!")
                        Exit Sub
                    End If
                    Dim pDate As Date
                    Dim sDate As String
                    pDate = Convert.ToDateTime(.Rows(e.RowIndex).Cells(0).Value)
                    sDate = Format(pDate, "MM/dd/yyyy")
                    SharedData.ReadyToHideMarquee = False
                    StartMarqueeThread()
                    sRes = _ObjBusi.spUpdate("CR", .Rows(e.RowIndex).Cells(4).Value.ToString(), sDate, .Rows(e.RowIndex).Cells(1).Value.ToString(), My.Settings.Username.ToUpper.ToString.Trim(), "", "", "", "", "", "P", Conn)
                    SyncLock SharedData
                        SharedData.ReadyToHideMarquee = True
                    End SyncLock
                    Application.DoEvents()
                    If sRes = "1" Then
                        MsgBox("Sucessfully Posted")
                        BINDDATA()
                    End If
                End If
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(4).Value) Then
                    PrintLetters.PrintProposer("CR.rpt", .Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "CLIENTREQUEST")
                End If
            End If
        End With
    End Sub
End Class