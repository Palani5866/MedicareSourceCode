Public Class vShortFalls
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
    Private Sub vShortFalls_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub vShortFalls_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.fShortFalls("SHORTFALL", Me.lblREFID.Text.ToString.Trim(), "", "", "", "", "", "", "", Me.lblREF2.Text.Trim(), "DETAILS", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvShortFallDetails
                .DataSource = dt
                .Columns(0).Visible = False 'ID
            End With
        End If
    End Sub
End Class