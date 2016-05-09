Public Class ftShortfall
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Private Sub ftShortfall_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub ftShortfall_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _ObjBusi.getDetails_II("SHORTFALL", "", "", "", "", "", "", "", "", "", "TS", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvShortfall
                .DataSource = dt


                .Columns(13).DefaultCellStyle.Format = "#,##0.00"
                .Columns(14).DefaultCellStyle.Format = "#,##0.00"
                .Columns(15).DefaultCellStyle.Format = "#,##0.00"
                .Columns(16).DefaultCellStyle.Format = "#,##0.00"

                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                Me.tslblTot.Text = "Total Record # : " & dt.Rows.Count.ToString.Trim()
            End With
        Else
            MsgBox("No record found")
            Me.dgvShortfall.DataSource = dt
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
    Private Sub dgvShortfall_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShortfall.CellContentClick
        With Me.dgvShortfall
            Dim s As String
            s = .Rows(e.RowIndex).Cells(4).Value.ToString()
            If e.ColumnIndex = 13 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(13).Value = "0" Then
                    Dim vSFD As New rShortFallSummaryDetails
                    vSFD.lblRTYPE.Text = "TOTSHORT"
                    vSFD.lblRTYPE1.Text = .Rows(e.RowIndex).Cells(4).Value.ToString()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 14 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(14).Value = "0" Then
                    Dim vSFD As New rShortFallSummaryDetails
                    vSFD.lblRTYPE.Text = "TOTREQUESTED"
                    vSFD.lblRTYPE1.Text = .Rows(e.RowIndex).Cells(4).Value.ToString()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 15 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(15).Value = "0" Then
                    Dim vSFD As New rShortFallSummaryDetails
                    vSFD.lblRTYPE.Text = "TOTRECOVERED"
                    vSFD.lblRTYPE1.Text = .Rows(e.RowIndex).Cells(4).Value.ToString()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(0).Value = "" Then
                    MsgBox("Please select the declaration!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(1).Value = "" Then
                    MsgBox("Please select the action!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(2).Value = "" Then
                    MsgBox("Please do key in Remarks!")
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(4).Value) Then
                    Dim sRes As String
                    sRes = _ObjBusi.spUpdate("INSERTPP", .Rows(e.RowIndex).Cells(4).Value.ToString.Trim(), "SHORTFALLS", .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(2).Value.ToString.Trim(), "", My.Settings.Username.ToUpper.ToString.Trim(), "SHORTFALLS", "", "SHORTFALLS", Conn)
                    _ObjBusi.spUpdate("UPDATEPP", .Rows(e.RowIndex).Cells(5).Value.ToString.Trim(), "SHORTFALLS", .Rows(e.RowIndex).Cells(4).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(5).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(6).Value.ToString.Trim(), "", My.Settings.Username.ToUpper.ToString.Trim(), "", "", "SHORTFALLS", Conn)
                    If sRes = "1" Then
                        MsgBox("Successfully Submitted!")
                        BINDDATA()
                    End If
                End If
            End If
        End With
    End Sub
End Class