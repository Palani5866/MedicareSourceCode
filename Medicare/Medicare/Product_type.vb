
Public Class Product_type
    Dim Conn As DbConnection = New SqlConnection
    Private Sub Product_type_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Product_type_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        getProductDetails()
        Me.gbProduct.Visible = False
        Me.cbStatus.SelectedIndex = 0
    End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()
    End Sub
    Private Sub getProductDetails()
        Dim _ds As New DataSet
        Dim _scGetProduct As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scGetProduct.CommandType = CommandType.Text
        _scGetProduct.CommandText = "select tb_product_type_id, product_type,status from tb_product_type"
        Dim _sdaGetProduct As New SqlDataAdapter(_scGetProduct)
        _sdaGetProduct.Fill(_ds, "tb_product_type")
        With Me.dgvProduct
            .DataSource = _ds
            .DataMember = "tb_product_type"
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Product Type"
            .Columns(2).HeaderText = "Status"
        End With
    End Sub
    Private Sub Clear()
        Me.txtProduct.Text = ""
        Me.cbStatus.SelectedIndex = -1
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.btnSubmit.Name = "Update" Then
            Update_Product_Type()
        Else
            Insert_Product_Type()
        End If
    End Sub
#Region "Insert"
    Private Sub Insert_Product_Type()
        Dim status, product_type As String
        If Me.txtProduct.Text.ToString.Trim() = "" Then
            MsgBox("Product Type Can't be Blank!")
            Me.txtProduct.Focus()
            Exit Sub
        End If
        product_type = Me.txtProduct.Text.ToString.Trim()
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
        _scIns.CommandText = "Insert into tb_product_type (product_type, status, created_dt, created_by) " & _
                            "Values ('" & product_type & "', '" & status & "', '" & Format(Now(), "MM/dd/yyyy") & "', '" & My.Settings.Username & "')"
        sRes = _scIns.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Succesfully Inserted Product Type")
            getProductDetails()
            Clear()
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
            gbProduct.Visible = False
        Else
            MsgBox("Error while Inserting Product Type")
        End If
    End Sub
#End Region
#Region "Update"
    Private Sub Update_Product_Type()
        Dim status, product_type, sRes As String
        If Me.txtProduct.Text.ToString.Trim() = "" Then
            MsgBox("Product Type Can't be Blank!")
            Me.txtProduct.Focus()
            Exit Sub
        End If
        product_type = Me.txtProduct.Text.ToString.Trim()
        status = Me.cbStatus.SelectedIndex
        Select Case status
            Case "0"
                status = "Active"
            Case "1"
                status = "Inactive"
        End Select
        Dim _scUps As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scUps.CommandType = CommandType.Text
        _scUps.CommandText = "Update tb_product_type Set product_type='" & product_type & "', status='" & status & "', modified_dt='" & Format(Now(), "MM/dd/yyyy") & "', modified_by='" & My.Settings.Username & "' where tb_product_type_id='" & Me.lblProductID.Text & "'"
        sRes = _scUps.ExecuteNonQuery()
        If sRes = "1" Then
            MsgBox("Succesfully updated Product Type")
            getProductDetails()
            Clear()
            Me.btnNew.Enabled = True
            Me.btnDelete.Enabled = True
            gbProduct.Visible = False
        Else
            MsgBox("Error while Updating Product Type")
        End If
    End Sub
#End Region
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.gbProduct.Visible = True
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.Name = "Submit"
        Me.btnEdit.Enabled = False
        Me.btnDelete.Enabled = False
        Me.cbStatus.SelectedIndex = 0
    End Sub
    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvProduct.SelectedRows.Count > 0 Then
            Dim pro_id As Integer
            pro_id = Me.dgvProduct.SelectedRows(0).Cells(0).Value.ToString.Trim
            Dim _sqlCmdget_Pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            _sqlCmdget_Pro.CommandType = CommandType.Text
            _sqlCmdget_Pro.CommandText = "SELECT * FROM tb_product_type where tb_product_type_id='" & pro_id & "'"
            Dim adp As New SqlDataAdapter(_sqlCmdget_Pro)
            Dim ds As New DataSet
            adp.Fill(ds, "tb_product_type")
            Me.lblProductID.Text = ds.Tables(0).Rows(0)("tb_product_type_id")
            Me.lblProductID.Visible = False
            Me.txtProduct.Text = ds.Tables(0).Rows(0)("product_type")
            If ds.Tables(0).Rows(0)("status") = "Active" Then
                Me.cbStatus.SelectedIndex = 0
            Else
                Me.cbStatus.SelectedIndex = 1
            End If
            gbProduct.Visible = True
            Me.btnSubmit.Text = "Update"
            Me.btnSubmit.Name = "Update"
            Me.btnNew.Enabled = False
            Me.btnDelete.Enabled = False
        Else
            MsgBox("Please select the row for edit!")
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dgvProduct.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to delete?", vbYesNo, "Delete") = vbYes Then
                Dim pro_id As Integer
                Dim sRes As String
                pro_id = Me.dgvProduct.SelectedRows(0).Cells(0).Value.ToString.Trim
                Dim _sqlCmddel_pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmddel_pro.CommandType = CommandType.Text
                _sqlCmddel_pro.CommandText = "Delete FROM tb_product_type where tb_product_type_id='" & pro_id & "'"
                sRes = _sqlCmddel_pro.ExecuteNonQuery()
                If sRes = "1" Then
                    MsgBox("Successfully Deleted the Product Type!")
                    getProductDetails()
                Else
                    MsgBox("Error while Deleting the Product Type! or Currently our server busy please try again..")
                End If
            End If
        Else
            MsgBox("Please select the row for Delete!")
        End If
    End Sub
End Class