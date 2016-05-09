Public Class fViewDetails
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Private Sub fViewDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fViewDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _ObjBusi.getDetails_VIII("VD", Me.lblP1.Text.ToString.Trim(), Me.lblP2.Text.ToString.Trim(), Me.lblP3.Text.ToString.Trim(), "", "", "", "", "", "", Me.lblREFTYPE.Text.ToString.Trim(), Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvVD
                .DataSource = dt
            End With
        Else
            MsgBox("No record found!")
            Me.dgvVD.DataSource = dt
        End If
    End Sub
End Class