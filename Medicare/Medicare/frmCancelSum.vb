Public Class frmCancelSum
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Dim DateTo, DateFrom As String
#End Region
    Private Sub frmCancelSum_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If

    End Sub
    Private Sub frmCancelSum_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tstxtDateFrom.Text = Format(Now(), "dd/MM/yyyy")
        Me.tstxtDateTo.Text = Format(Now(), "dd/MM/yyyy")
    End Sub
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        If fVerify() Then
            BINDDATA()
        End If
    End Sub
    Private Sub BINDDATA()
        Dim FromDay As String = Convert.ToDateTime(Me.tstxtDateFrom.Text).Day
        Dim FromMonth As String = Convert.ToDateTime(Me.tstxtDateFrom.Text).Month
        Dim FromYear As String = Convert.ToDateTime(Me.tstxtDateFrom.Text).Year
        DateFrom = FromMonth & "/" & FromDay & "/" & FromYear

        Dim ToDay As String = Convert.ToDateTime(Me.tstxtDateTo.Text).Day
        Dim ToMonth As String = Convert.ToDateTime(Me.tstxtDateTo.Text).Month
        Dim ToYear As String = Convert.ToDateTime(Me.tstxtDateTo.Text).Year
        DateTo = ToMonth & "/" & ToDay & "/" & ToYear

        Dim dt As DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _ObjBusi.getDetails_IX(Me.lblP1.Text.ToString.Trim(), DateFrom, DateTo, "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvCancelSum
                .DataSource = dt
            End With
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
    Private Sub dgvCancelSum_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCancelSum.CellContentClick
        With Me.dgvCancelSum
            If e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(1).Value = "0" Then
                    Dim vSFD As New frmSummaryDetails
                    vSFD.lblP1.Text = "CSD"
                    vSFD.lblP2.Text = DateFrom
                    vSFD.lblP3.Text = DateTo
                    vSFD.lblP4.Text = .Rows(e.RowIndex).Cells(0).Value.ToString.Trim()
                    vSFD.lblP5.Text = "CCANGKASA"
                    vSFD.lblRTYPE.Text = Me.lblP1.Text.ToString.Trim()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(2).Value = "0" Then
                    Dim vSFD As New frmSummaryDetails
                    vSFD.lblP1.Text = "CSD"
                    vSFD.lblP2.Text = DateFrom
                    vSFD.lblP3.Text = DateTo
                    vSFD.lblP4.Text = .Rows(e.RowIndex).Cells(0).Value.ToString.Trim()
                    vSFD.lblP5.Text = "CCFAMA"
                    vSFD.lblRTYPE.Text = Me.lblP1.Text.ToString.Trim()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(3).Value = "0" Then
                    Dim vSFD As New frmSummaryDetails
                    vSFD.lblP1.Text = "CSD"
                    vSFD.lblP2.Text = DateFrom
                    vSFD.lblP3.Text = DateTo
                    vSFD.lblP4.Text = .Rows(e.RowIndex).Cells(0).Value.ToString.Trim()
                    vSFD.lblP5.Text = "CCSIRIM"
                    vSFD.lblRTYPE.Text = Me.lblP1.Text.ToString.Trim()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(4).Value = "0" Then
                    Dim vSFD As New frmSummaryDetails
                    vSFD.lblP1.Text = "CSD"
                    vSFD.lblP2.Text = DateFrom
                    vSFD.lblP3.Text = DateTo
                    vSFD.lblP4.Text = .Rows(e.RowIndex).Cells(0).Value.ToString.Trim()
                    vSFD.lblP5.Text = "CCOTHERS"
                    vSFD.lblRTYPE.Text = Me.lblP1.Text.ToString.Trim()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(5).Value = "0" Then
                    Dim vSFD As New frmSummaryDetails
                    vSFD.lblP1.Text = "CSD"
                    vSFD.lblP2.Text = DateFrom
                    vSFD.lblP3.Text = DateTo
                    vSFD.lblP4.Text = .Rows(e.RowIndex).Cells(0).Value.ToString.Trim()
                    vSFD.lblP5.Text = "CPAANGKASA"
                    vSFD.lblRTYPE.Text = Me.lblP1.Text.ToString.Trim()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 6 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(6).Value = "0" Then
                    Dim vSFD As New frmSummaryDetails
                    vSFD.lblP1.Text = "CSD"
                    vSFD.lblP2.Text = DateFrom
                    vSFD.lblP3.Text = DateTo
                    vSFD.lblP4.Text = .Rows(e.RowIndex).Cells(0).Value.ToString.Trim()
                    vSFD.lblP5.Text = "CPAOTHERS"
                    vSFD.lblRTYPE.Text = Me.lblP1.Text.ToString.Trim()
                    vSFD.Show()
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
End Class