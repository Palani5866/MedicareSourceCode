Public Class SearchAgent
    Dim Conn As DbConnection = New SqlConnection
    Private Sub SearchAgent_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub SearchAgent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        getAgentdetails()
    End Sub
#Region "Agent Details"
    Private Sub getAgentdetails()
        Dim _sqlCmdget_ins As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _sqlCmdget_ins.CommandType = CommandType.Text
        _sqlCmdget_ins.CommandText = "SELECT tb_Agent_id, Agent_Code, Agent_name FROM tb_Agent where (Manager is null or Manager=1)  and status='Active' order by agent_code"
        Dim adp As New SqlDataAdapter(_sqlCmdget_ins)
        Dim ds As New DataSet
        adp.Fill(ds, "tb_Agent")
        With Me.dgvAgentDetails
            .DataSource = ds
            .DataMember = "tb_Agent"
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Agent Code"
            .Columns(2).HeaderText = "Agent Name"
        End With
    End Sub
#End Region
    Private Sub dgvAgentDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAgentDetails.CellDoubleClick
        With Me.dgvAgentDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Dim _ds As New DataSet
            Dim _scGetPlan As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            _scGetPlan.CommandType = CommandType.Text
            _scGetPlan.CommandText = "SELECT TB_AGENT_ID, AGENT_CODE, Product_Name , Percentage FROM TB_AGENT WHERE Manager_ID='" & .CurrentRow.Cells(0).Value.ToString & "'  and status='Active' order by agent_code "
            Dim _sdaGetPlan As New SqlDataAdapter(_scGetPlan)
            _sdaGetPlan.Fill(_ds, "TB_AGENT")
            With Me.dgvAgentLevelDetails
                .DataSource = _ds
                .DataMember = "TB_AGENT"
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "AGENT CODE"
                .Columns(2).HeaderText = "PRODUCT NAME"
                .Columns(3).HeaderText = "PERCENTAGE"
            End With
        End With
    End Sub
    Private Sub dgvAgentLevelDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAgentLevelDetails.CellDoubleClick
        With Me.dgvAgentDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            If Me.dgvAgentLevelDetails.SelectedRows.Count > 0 Then
                Clipboard.SetDataObject(Me.dgvAgentLevelDetails.SelectedRows(0).Cells(0).Value.ToString.Trim())
                Me.Close()
            End If
        End With
    End Sub
End Class