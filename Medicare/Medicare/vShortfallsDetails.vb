Public Class vShortfallsDetails
    Dim Conn As DbConnection = New SqlConnection()
    Dim _objBusi As New Business
    Private Sub vShortfallsDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub vShortfallsDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As DataTable
        dt = _objBusi.fShortFalls("SUMMARY", "", "", "", "", "", "", "", "", "", "SUMMARY", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvSD
                .DataSource = dt
            End With
        Else
            MsgBox("No Record Found")
            Me.dgvSD.DataSource = dt
        End If
    End Sub
    
End Class