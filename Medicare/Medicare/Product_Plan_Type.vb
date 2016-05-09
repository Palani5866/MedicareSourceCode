
Public Class Product_Plan_Type
    Dim Conn As DbConnection = New SqlConnection
    Private Sub Product_Plan_Type_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Product_Plan_Type_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        getProduct_PlanDetails()
        Me.gbProductPlan.Visible = False
        Me.cbStatus.SelectedIndex = 0
        Me.cbNoOfTimes.SelectedIndex = 0
    End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()
    End Sub
    Private Sub getProduct_PlanDetails()
        Dim _ds As New DataSet
        Dim _scGetProduct_Plan As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scGetProduct_Plan.CommandType = CommandType.Text
        _scGetProduct_Plan.CommandText = "select tb_Product_Plan_type_id, Product_Plan_type, No_of_Times, status from tb_Product_Plan_type"
        Dim _sdaGetProduct_Plan As New SqlDataAdapter(_scGetProduct_Plan)
        _sdaGetProduct_Plan.Fill(_ds, "tb_Product_Plan_type")
        With Me.dgvProductPlan
            .DataSource = _ds
            .DataMember = "tb_Product_Plan_type"
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Product Plan Type"
            .Columns(2).HeaderText = "No of Time Policy Allowed"
            .Columns(3).HeaderText = "Status"
        End With
    End Sub
    Private Sub Clear()
        Me.txtProductPlan.Text = ""
        Me.cbStatus.SelectedIndex = -1
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.btnSubmit.Name = "Update" Then
            Update_Product_Plan_Type()
        Else
            Insert_Product_Plan_Type()
        End If
    End Sub
#Region "Insert"
    Private Sub Insert_Product_Plan_Type()
        Dim status, Product_Plan_type, No_of_Times As String
        If Me.txtProductPlan.Text.ToString.Trim() = "" Then
            MsgBox("Product Plan Type Can't be Blank!")
            Me.txtProductPlan.Focus()
            Exit Sub
        End If
        Product_Plan_type = Me.txtProductPlan.Text.ToString.Trim()
        No_of_Times = Me.cbNoOfTimes.SelectedIndex
        Select Case No_of_Times
            Case "0"
                No_of_Times = "1"
            Case "1"
                No_of_Times = "2"
            Case "2"
                No_of_Times = "3"
            Case "3"
                No_of_Times = "4"
            Case "4"
                No_of_Times = "5"
        End Select
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
        _scIns.CommandText = "Insert into tb_Product_Plan_type (Product_Plan_type, No_of_Times, status, created_dt, created_by) " & _
                            "Values ('" & Product_Plan_type & "', '" & No_of_Times & "', '" & status & "', '" & Format(Now(), "MM/dd/yyyy") & "', '" & My.Settings.Username & "')"
        sRes = _scIns.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Succesfully Inserted Product_Plan Type")
            getProduct_PlanDetails()
            Clear()
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
            gbProductPlan.Visible = False
        Else
            MsgBox("Error while Inserting Product Plan Type")
        End If
    End Sub
#End Region
#Region "Update"
    Private Sub Update_Product_Plan_Type()
        Dim status, Product_Plan_type, No_of_Times, sRes As String
        If Me.txtProductPlan.Text.ToString.Trim() = "" Then
            MsgBox("Product Plan Type Can't be Blank!")
            Me.txtProductPlan.Focus()
            Exit Sub
        End If
        Product_Plan_type = Me.txtProductPlan.Text.ToString.Trim()
        No_of_Times = Me.cbNoOfTimes.SelectedIndex
        Select Case No_of_Times
            Case "0"
                No_of_Times = "1"
            Case "1"
                No_of_Times = "2"
            Case "2"
                No_of_Times = "3"
            Case "3"
                No_of_Times = "4"
            Case "4"
                No_of_Times = "5"
        End Select
        status = Me.cbStatus.SelectedIndex
        Select Case status
            Case "0"
                status = "Active"
            Case "1"
                status = "Inactive"
        End Select
        Dim _scUps As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scUps.CommandType = CommandType.Text
        _scUps.CommandText = "Update tb_Product_Plan_type Set Product_Plan_type='" & Product_Plan_type & "', No_of_Times='" & No_of_Times & "', status='" & status & "', modified_dt='" & Format(Now(), "MM/dd/yyyy") & "', modified_by='" & My.Settings.Username & "' where tb_Product_Plan_type_id='" & Me.lblProductPlanID.Text & "'"
        sRes = _scUps.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Succesfully updated Product Plan Type")
            getProduct_PlanDetails()
            Clear()
            Me.btnNew.Enabled = True
            Me.btnDelete.Enabled = True
            gbProductPlan.Visible = False
        Else
            MsgBox("Error while Updating Product Plan Type")
        End If
    End Sub
#End Region
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.gbProductPlan.Visible = True
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.Name = "Submit"
        Me.btnEdit.Enabled = False
        Me.btnDelete.Enabled = False
        Me.cbNoOfTimes.SelectedIndex = 0
        Me.cbStatus.SelectedIndex = 0
    End Sub
    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvProductPlan.SelectedRows.Count > 0 Then
            Dim pro_id As Integer
            Dim No_of_Times As String
            pro_id = Me.dgvProductPlan.SelectedRows(0).Cells(0).Value.ToString.Trim
            Dim _sqlCmdget_Pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            _sqlCmdget_Pro.CommandType = CommandType.Text
            _sqlCmdget_Pro.CommandText = "SELECT * FROM tb_Product_Plan_type where tb_Product_Plan_type_id='" & pro_id & "'"
            Dim adp As New SqlDataAdapter(_sqlCmdget_Pro)
            Dim ds As New DataSet
            adp.Fill(ds, "tb_Product_Plan_type")
            Me.lblProductPlanID.Text = ds.Tables(0).Rows(0)("tb_Product_Plan_type_id")
            Me.lblProductPlanID.Visible = False
            Me.txtProductPlan.Text = ds.Tables(0).Rows(0)("Product_Plan_type")
            If Not IsDBNull(ds.Tables(0).Rows(0)("No_of_Times")) Then
                No_of_Times = ds.Tables(0).Rows(0)("No_of_Times")
            Else
                No_of_Times = "1"
            End If

            Select Case No_of_Times
                Case "1"
                    Me.cbNoOfTimes.SelectedIndex = 0
                Case "2"
                    Me.cbNoOfTimes.SelectedIndex = 1
                Case "3"
                    Me.cbNoOfTimes.SelectedIndex = 2
                Case "4"
                    Me.cbNoOfTimes.SelectedIndex = 3
                Case "5"
                    Me.cbNoOfTimes.SelectedIndex = 4
            End Select
            If ds.Tables(0).Rows(0)("status") = "Active" Then
                Me.cbStatus.SelectedIndex = 0
            Else
                Me.cbStatus.SelectedIndex = 1
            End If
            gbProductPlan.Visible = True
            Me.btnSubmit.Text = "Update"
            Me.btnSubmit.Name = "Update"
            Me.btnNew.Enabled = False
            Me.btnDelete.Enabled = False
        Else
            MsgBox("Please select the row for edit!")
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dgvProductPlan.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to delete?", vbYesNo, "Delete") = vbYes Then
                Dim pro_id As Integer
                Dim sRes As String
                pro_id = Me.dgvProductPlan.SelectedRows(0).Cells(0).Value.ToString.Trim
                Dim _sqlCmddel_pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmddel_pro.CommandType = CommandType.Text
                _sqlCmddel_pro.CommandText = "Delete FROM tb_Product_Plan_type where tb_Product_Plan_type_id='" & pro_id & "'"
                sRes = _sqlCmddel_pro.ExecuteNonQuery()
                If sRes = "1" Then
                    MsgBox("Successfully Deleted the Product Plan Type!")
                    getProduct_PlanDetails()
                Else
                    MsgBox("Error while Deleting the Product_Plan Type! or Currently our server busy please try again..")
                End If
            End If
        Else
            MsgBox("Please select the row for Delete!")
        End If
    End Sub
End Class