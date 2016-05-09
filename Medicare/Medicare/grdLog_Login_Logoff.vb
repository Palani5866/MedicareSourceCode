Public Class grdLog_Login_Logoff
    Dim Conn As DbConnection = New SqlConnection

    Private Sub grdLog_Login_Logoff_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub grdLog_Login_Logoff_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Populate_Grid()
    End Sub

    Private Sub Populate_Grid()
       
        Dim cmd_Log_Details As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmd_Log_Details.CommandType = CommandType.Text
        cmd_Log_Details.CommandText = "SELECT TOP(20) Log_Date, Activity_Detail " & _
                                      "FROM log_User " & _
                                      "WHERE Username = '" & My.Settings.Username.Trim & "' " & _
                                      "ORDER BY Log_Date DESC"
        Dim ds_Log As New DataSet


        Dim da_Log_Details As New SqlDataAdapter(cmd_Log_Details)
        da_Log_Details.Fill(ds_Log, "log_User")

        With Me.dgvForm
            .DataSource = ds_Log
            .DataMember = "log_User"

            .Columns(0).HeaderText = "Date"
            .Columns(1).HeaderText = "Activity"

            .Columns(0).DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss"

            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        End With
    End Sub

End Class