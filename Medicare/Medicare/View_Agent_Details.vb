Public Class View_Agent_Details
    Dim Conn As DbConnection = New SqlConnection
    Private Sub View_Agent_Details_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub View_Agent_Details_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.getAgentContactDetails(Me.lblAID.Text)
    End Sub
    Private Sub getAgentContactDetails(ByVal ins_id As String)
        Dim _scGet As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scGet.CommandType = CommandType.Text
        _scGet.CommandText = "SELECT Agent_Name, Designation, Add1 + ', ' + Add2 + ', ' + Town + ', ' + State + ', ' + PostCode as Address, BankAc, Email, Tel, Spouse_Name, Spouse_Tel  FROM tb_agent where tb_agent_id='" & ins_id & "'"
        Dim _sda As New SqlDataAdapter(_scGet)
        Dim ds As New DataSet
        _sda.Fill(ds, "tb_agent")
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvAgentDetails
                .DataSource = ds
                .DataMember = "tb_agent"
                .Columns(0).HeaderText = "Name"
                .Columns(1).HeaderText = "Designation"
                .Columns(2).HeaderText = "Address"
                .Columns(3).HeaderText = "Bank A/c"
                .Columns(4).HeaderText = "Email"
                .Columns(5).HeaderText = "Telephone #"
                .Columns(6).HeaderText = "Spouse Name"
                .Columns(7).HeaderText = "Spouse Telephone #"
            End With

        Else
            MsgBox("No Agent Info")
            Me.Close()
        End If
    End Sub
End Class