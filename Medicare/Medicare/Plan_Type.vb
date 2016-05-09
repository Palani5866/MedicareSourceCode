
Public Class Plan_Type
    Dim Conn As DbConnection = New SqlConnection
    Private Sub Plan_Type_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Plan_Type_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        getPlanDetails()
        Me.gbPlan.Visible = False
        Me.cbStatus.SelectedIndex = 0
    End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()
    End Sub
    Private Sub getPlanDetails()
        Dim _ds As New DataSet
        Dim _scGetPlan As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scGetPlan.CommandType = CommandType.Text
        _scGetPlan.CommandText = "select tb_Plan_type_id, Plan_type,status from tb_Plan_type"
        Dim _sdaGetPlan As New SqlDataAdapter(_scGetPlan)
        _sdaGetPlan.Fill(_ds, "tb_Plan_type")
        With Me.dgvPlan
            .DataSource = _ds
            .DataMember = "tb_Plan_type"
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Plan Type"
            .Columns(2).HeaderText = "Status"
        End With
    End Sub
    Private Sub Clear()
        Me.txtPlan.Text = ""
        Me.cbStatus.SelectedIndex = -1
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.btnSubmit.Name = "Update" Then
            Update_Plan_Type()
        Else
            Insert_Plan_Type()
        End If
    End Sub
#Region "Insert"
    Private Sub Insert_Plan_Type()
        Dim status, Plan_type As String
        If Me.txtPlan.Text.ToString.Trim() = "" Then
            MsgBox("Plan Type Can't be Blank!")
            Me.txtPlan.Focus()
            Exit Sub
        End If
        Plan_type = Me.txtPlan.Text.ToString.Trim()
        status = Me.cbStatus.SelectedIndex
        Select Case status
            Case "0"
                status = "Active"
            Case "1"
                status = "Inactive"
        End Select
        Dim sRes As String
        Dim _scIns As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scIns.CommandType = CommandType.Text
        _scIns.CommandText = "Insert into tb_Plan_type (Plan_type, status, created_dt, created_by) " & _
                            "Values ('" & Plan_type & "', '" & status & "', '" & Format(Now(), "MM/dd/yyyy") & "', '" & My.Settings.Username & "')"
        sRes = _scIns.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Succesfully Inserted Plan Type")
            getPlanDetails()
            Clear()
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
            gbPlan.Visible = False
        Else
            MsgBox("Error while Inserting Plan Type")
        End If
    End Sub
#End Region
#Region "Update"
    Private Sub Update_Plan_Type()
        Dim status, Plan_type, sRes As String
        If Me.txtPlan.Text.ToString.Trim() = "" Then
            MsgBox("Plan Type Can't be Blank!")
            Me.txtPlan.Focus()
            Exit Sub
        End If
        Plan_type = Me.txtPlan.Text.ToString.Trim()
        status = Me.cbStatus.SelectedIndex
        Select Case status
            Case "0"
                status = "Active"
            Case "1"
                status = "Inactive"
        End Select
        Dim _scUps As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scUps.CommandType = CommandType.Text
        _scUps.CommandText = "Update tb_Plan_type Set Plan_type='" & Plan_type & "', status='" & status & "', modified_dt='" & Format(Now(), "MM/dd/yyyy") & "', modified_by='" & My.Settings.Username & "' where tb_Plan_type_id='" & Me.lblPlanID.Text & "'"
        sRes = _scUps.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Succesfully updated Plan Type")
            getPlanDetails()
            Clear()
            Me.btnNew.Enabled = True
            Me.btnDelete.Enabled = True
            gbPlan.Visible = False
        Else
            MsgBox("Error while Updating Plan Type")
        End If
    End Sub
#End Region
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.gbPlan.Visible = True
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.Name = "Submit"
        Me.btnEdit.Enabled = False
        Me.btnDelete.Enabled = False
    End Sub
    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvPlan.SelectedRows.Count > 0 Then
            Dim pro_id As Integer
            pro_id = Me.dgvPlan.SelectedRows(0).Cells(0).Value.ToString.Trim
            Dim _sqlCmdget_Pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            _sqlCmdget_Pro.CommandType = CommandType.Text
            _sqlCmdget_Pro.CommandText = "SELECT * FROM tb_Plan_type where tb_Plan_type_id='" & pro_id & "'"
            Dim adp As New SqlDataAdapter(_sqlCmdget_Pro)
            Dim ds As New DataSet
            adp.Fill(ds, "tb_Plan_type")
            Me.lblPlanID.Text = ds.Tables(0).Rows(0)("tb_Plan_type_id")
            Me.lblPlanID.Visible = False
            Me.txtPlan.Text = ds.Tables(0).Rows(0)("Plan_type")
            If ds.Tables(0).Rows(0)("status") = "Active" Then
                Me.cbStatus.SelectedIndex = 0
            Else
                Me.cbStatus.SelectedIndex = 1
            End If
            gbPlan.Visible = True
            Me.btnSubmit.Text = "Update"
            Me.btnSubmit.Name = "Update"
            Me.btnNew.Enabled = False
            Me.btnDelete.Enabled = False
        Else
            MsgBox("Please select the row for edit!")
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dgvPlan.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to delete?", vbYesNo, "Delete") = vbYes Then
                Dim pro_id As Integer
                Dim sRes As String
                pro_id = Me.dgvPlan.SelectedRows(0).Cells(0).Value.ToString.Trim
                Dim _sqlCmddel_pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmddel_pro.CommandType = CommandType.Text
                _sqlCmddel_pro.CommandText = "Delete FROM tb_Plan_type where tb_Plan_type_id='" & pro_id & "'"
                sRes = _sqlCmddel_pro.ExecuteNonQuery()
                If sRes = "1" Then
                    MsgBox("Successfully Deleted the Plan Type!")
                    getPlanDetails()
                Else
                    MsgBox("Error while Deleting the Plan Type! or Currently our server busy please try again..")
                End If
            End If
        Else
            MsgBox("Please select the row for delete!")
        End If
    End Sub
End Class