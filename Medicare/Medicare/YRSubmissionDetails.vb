Public Class YRSubmissionDetails
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub YRSubmissionDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub YRSubmissionDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
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
    Private Sub BINDDATA()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _objBusi.getDetails_VI("YRSD", Me.lblBATCHNO.Text.Trim(), Me.lblSTATUS.Text.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()

        If dt.Rows.Count > 0 Then
            With Me.dgvYRS
                .DataSource = dt
            End With
            Me.tslblTotalRecords.Text = "Total Records : " & dt.Rows.Count
        Else
            MsgBox("No Record found")
            Me.dgvYRS.DataSource = dt
            Me.tslblTotalRecords.Text = "Total Records : 0"
        End If
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvYRS.Rows.Count > 0 Then
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "YEARLY RENEWAL REQUEST/SUBMISSION DETAILS "
                .Cells(2, 1) = "EXPORT ON : " & Now()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE NO"
                .Cells(4, 3) = "IC"
                .Cells(4, 4) = "FULL NAME"
                .Cells(4, 5) = "PLAN CODE"
                .Cells(4, 6) = "PLAN TYPE"
                .Cells(4, 7) = "PREMIUM"
                .Cells(4, 8) = "STATUS"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                SharedData.ReadyToHideMarquee = False
                StartMarqueeThread()
                Do While iCount < Me.dgvYRS.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvYRS.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvYRS.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvYRS.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvYRS.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvYRS.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvYRS.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvYRS.Rows(iCount).Cells(6).Value.ToString.Trim
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
    Private Sub btnXPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXPort.Click
        XPort2Xcel()
    End Sub
End Class