Public Class PremiumDetails
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
    Private Sub PremiumDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub PremiumDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.fPremium("CC", Me.lblREFID.Text.ToString.Trim(), "", "", "", "", "", "", "", "D", "INCREASE", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvPremiumDetails
                .DataSource = dt
                .Columns(0).Visible = False 'ID
            End With
        End If
    End Sub
End Class