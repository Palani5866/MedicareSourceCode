Public Class Product_Setup
    Dim Conn As DbConnection = New SqlConnection()
    Dim ProductCodeID, PremiumCodeID As String
    Dim _objBusi As New Business
    Private Sub Product_Setup_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Product_Setup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        popupCB()
        getProductDetails()

        Me.gbPremiumCode.Enabled = False
        Me.gbDeductionCode.Enabled = False
        Me.gbMain.Visible = False
        Me.txtFilePrefix.Enabled = False

    End Sub
    Private Sub popupCB()
        For i As Integer = 1 To 100
            Me.cbAgeLimit.Items.Add(i)
        Next

        Dim _scInsurer As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        Dim _ds As New DataSet
        _scInsurer.CommandType = CommandType.Text
        _scInsurer.CommandText = "Select * from tb_insurer where status='Active'"
        Dim _sda As New SqlDataAdapter(_scInsurer)
        _sda.Fill(_ds, "tb_insurer")
        Me.cbInsurerName.DataSource = _ds.Tables(0)
        Me.cbInsurerName.DisplayMember = "Insurer_name"
        Me.cbInsurerName.ValueMember = "tb_insurer_id"
       
        Dim _scPro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        Dim _dsPro As New DataSet
        _scPro.CommandType = CommandType.Text
        _scPro.CommandText = "Select * from tb_product_type where status='Active'"
        Dim _sdaPro As New SqlDataAdapter(_scPro)
        _sdaPro.Fill(_dsPro, "tb_product_type")
        Me.cbProductType.DataSource = _dsPro.Tables(0)
        Me.cbProductType.DisplayMember = "product_type"
        Me.cbProductType.ValueMember = "tb_product_type_id"
        
        Dim _scPlan As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        Dim _dsPlan As New DataSet
        _scPlan.CommandType = CommandType.Text
        _scPlan.CommandText = "Select * from tb_plan_type where status='Active'"
        Dim _sdaPlan As New SqlDataAdapter(_scPlan)
        _sdaPlan.Fill(_dsPlan, "tb_plan_type")
        Me.cbPlanType.DataSource = _dsPlan.Tables(0)
        Me.cbPlanType.DisplayMember = "plan_type"
        Me.cbPlanType.ValueMember = "plan_type"
        
        Dim _scProPlan As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        Dim _dsProPlan As New DataSet
        _scProPlan.CommandType = CommandType.Text
        _scProPlan.CommandText = "Select * from tb_product_plan_type where status='Active'"
        Dim _sdaProPlan As New SqlDataAdapter(_scProPlan)
        _sdaProPlan.Fill(_dsProPlan, "tb_product_plan_type")
        Me.cbProductName.DataSource = _dsProPlan.Tables(0)
        Me.cbProductName.DisplayMember = "product_plan_type"
        Me.cbProductName.ValueMember = "tb_product_plan_type_id"
       
        Dim _scPremium As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        Dim _dsPremium As New DataSet
        _scPremium.CommandType = CommandType.Text
        _scPremium.CommandText = "Select Distinct Premium_Code from tb_premium_table"
        Dim _sdaPremium As New SqlDataAdapter(_scPremium)
        _sdaPremium.Fill(_dsPremium, "tb_premium_table")
        Me.cbPremiumCode.DataSource = _dsPremium.Tables(0)
        Me.cbPremiumCode.DisplayMember = "Premium_Code"
        Me.cbPremiumCode.ValueMember = "Premium_Code"
       
        Dim _scReceivedFrom As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        Dim _dsReceivedFrom As New DataSet
        _scReceivedFrom.CommandType = CommandType.Text
        _scReceivedFrom.CommandText = "SELECT Payment_Method FROM sys_PaymentMethod  ORDER BY Payment_Method"
        Dim _sdaReceivedFrom As New SqlDataAdapter(_scReceivedFrom)
        _sdaReceivedFrom.Fill(_dsReceivedFrom, "sys_PaymentMethod")
        Me.cbDReceivedFrom.DataSource = _dsReceivedFrom.Tables(0)
        Me.cbDReceivedFrom.DisplayMember = "Payment_Method"
        Me.cbDReceivedFrom.ValueMember = "Payment_Method"


        Me.cbStatus.SelectedIndex = 0
        Me.cbDReceivedFrom.SelectedIndex = 0
        Me.cbDReceivedBy.SelectedIndex = 0
    End Sub
    Private Sub btnAddProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddProduct.Click
        If Me.txtProductCode.Text.ToString.Trim() = "" Then
            MsgBox("Product Code Can't be Blank!")
            Me.txtProductCode.Focus()
            Exit Sub
        End If
        If Not Me.cbAgeLimit.SelectedIndex > 0 Then
            MsgBox("Required Age Limit!")
            Me.cbAgeLimit.Focus()
            Exit Sub
        End If
        Dim dt As New DataTable
        dt = _objBusi.getDetails("PC", Me.txtProductCode.Text.Trim(), "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Me.txtProductCode.Focus()
            Me.txtProductCode.ForeColor = Color.Red
            MsgBox("Product code already exists!")
            Exit Sub
        End If
        Dim Policy_Type, ID, Status As String
        If Me.rbGroup.Checked Then
            Policy_Type = "Group"
        ElseIf Me.rbInd.Checked Then
            Policy_Type = "Individual"
        End If
        Status = Me.cbStatus.SelectedIndex
        Select Case Status
            Case "0"
                Status = "Active"
            Case "1"
                Status = "Inactive"
        End Select
        ID = Guid.NewGuid.ToString
        ProductCodeID = ID
        Dim scIns As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
        scIns.CommandType = CommandType.Text
        Try
            scIns.CommandText = "INSERT INTO tb_Product_Code (ID, Product_Code, Product_Name, Insurer_Name, Policy_Type, Product_Type, Plan_Type, Description, Age_Limit, Status, Created_Dt, Created_By)" & _
                                        " Values('" & ID & "', '" & Me.txtProductCode.Text.Trim() & "','" & Me.cbProductName.SelectedValue & "', '" & _
                                        Me.cbInsurerName.SelectedValue & "', '" & Policy_Type & "', '" & Me.cbProductType.SelectedValue & "', '" & _
                                        Me.cbPlanType.SelectedValue & "', '" & Me.txtDescription.Text.Trim() & "', '" & Me.cbAgeLimit.Text & "', '" & Status & "', '" & Format(Now(), "MM/dd/yyyy") & "', '" & My.Settings.Username & "')"

            scIns.ExecuteNonQuery()

            Me.lblProductCode.Text = Me.txtProductCode.Text.Trim()
            MsgBox("Successful Inserted the Product...")
            Me.gbPremiumCode.Enabled = True
            Me.btnAddProduct.Enabled = False
        Catch ex As Exception
            MsgBox("Product Code already exists or Error while creating Product Code Please check with your Admin!")
        End Try
    End Sub
    Private Sub btnResetProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetProduct.Click
        Me.btnAddProduct.Enabled = True
    End Sub
    Private Sub btnAddPremiumCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPremiumCode.Click
        Dim Product_Code, ID, Premium_Code As String
        Premium_Code = Me.cbPremiumCode.SelectedValue.ToString.Trim()

        Product_Code = Me.lblProductCode.Text.Trim()
        ID = Guid.NewGuid.ToString
        PremiumCodeID = ID

        Dim scPUPs As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        scPUPs.CommandType = CommandType.Text
        scPUPs.CommandText = "UPDATE tb_Product_Code SET Premium_Code='" & Premium_Code & "' WHERE ID='" & ProductCodeID & "'"
        scPUPs.ExecuteNonQuery()


        Me.lblDProductCode.Text = Product_Code
        MsgBox("Successful Inserted the Premium Code...")
        Me.gbDeductionCode.Enabled = True
        Me.btnAddProduct.Enabled = False
        Me.btnAddPremiumCode.Enabled = False
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.btnSubmit.Name = "Update" Then
            Update_Product()
        Else
            Insert_Product()
        End If
    End Sub
    Private Sub Insert_Product()
        If Me.txtFilePrefix.Text.Trim = "" Then
            MsgBox("Required File Prefix..!")
            Me.txtFilePrefix.Focus()
            Exit Sub
        End If
        If Me.txtDeductionCode.Text.ToString.Trim() = "" Then
            MsgBox("Deduction Code Can't be Blank!")
            Me.txtDeductionCode.Focus()
            Exit Sub
        End If
        Dim Product_Code, Received_by, Received_From As String
        Select Case Me.cbDReceivedBy.SelectedIndex
            Case "0"
                Received_by = "Medicare Care"
            Case "1"
                Received_by = "Test1"
            Case "2"
                Received_by = "Test2"
        End Select
        Received_From = Me.cbDReceivedFrom.SelectedValue
        Product_Code = Me.lblDProductCode.Text.Trim() & "-" & Me.txtDeductionCode.Text.Trim()
        Dim scIns As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
        scIns.CommandType = CommandType.Text
        scIns.CommandText = "INSERT INTO tb_Deduction_Code (ID, Product_Code, Deduction_Code, Received_By, Received_From)" & _
                            " Values('" & Guid.NewGuid.ToString & "', '" & Product_Code & "','" & Me.txtDeductionCode.Text.Trim() & "', '" & _
                            Received_by & "', '" & Received_From & "')"
        scIns.ExecuteNonQuery()

        Dim scUps As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
        scUps.CommandType = CommandType.Text
        scUps.CommandText = "UPDATE tb_Product_Code SET Product_Code='" & Product_Code & "' WHERE ID='" & ProductCodeID & "'"
        scUps.ExecuteNonQuery()
        Dim dt As New DataTable
        dt = _objBusi.getDetails("CHECKPREFIX", Me.txtFilePrefix.Text.ToString.Trim(), "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
        Else
            Try
                Dim sP As String()
                sP = Product_Code.ToString.Split("-")
                Dim cmdFP As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
                cmdFP.CommandType = CommandType.Text
                cmdFP.CommandText = "INSERT INTO TB_FILENO (PRODUCT_CODE, FILE_PREFIX, LAST_FILENO) VALUES('" & sP(0).ToString.Trim() & "', '" & Me.txtFilePrefix.Text.ToString.Trim() & "', '0')"
                cmdFP.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        End If
        MsgBox("Successful Inserted  Rroduct Code...")
        Me.gbDeductionCode.Enabled = True
        Me.btnNew.Enabled = True
        Me.btnEdit.Enabled = True
        Me.btnDelete.Enabled = True
        gbMain.Visible = False
        Me.Close()
    End Sub
    Private Sub Update_Product()
        Dim Status, Policy_Type, Product_Code, Received_by, Received_From As String
        If Not Me.cbAgeLimit.SelectedIndex > 0 Then
            MsgBox("Required Age Limit!")
            Me.cbAgeLimit.Focus()
            Exit Sub
        End If
        If Me.rbGroup.Checked Then
            Policy_Type = "Group"
        ElseIf Me.rbInd.Checked Then
            Policy_Type = "Individual"
        End If
        Select Case Me.cbDReceivedBy.SelectedIndex
            Case "0"
                Received_by = "Medicare Care"
            Case "1"
                Received_by = "Test1"
            Case "2"
                Received_by = "Test2"
        End Select
        Received_From = Me.cbDReceivedFrom.SelectedValue
        Status = Me.cbStatus.SelectedIndex
        Select Case status
            Case "0"
                status = "Active"
            Case "1"
                status = "Inactive"
        End Select
        Product_Code = Me.txtProductCode.Text
        Dim scUps As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
        scUps.CommandType = CommandType.Text
        scUps.CommandText = "UPDATE tb_Product_Code SET Product_Name='" & Me.cbProductName.SelectedValue & "', Insurer_Name='" & Me.cbInsurerName.SelectedValue & "'," & _
                        " Policy_Type='" & Policy_Type & "', Product_Type='" & Me.cbProductType.SelectedValue & "', Plan_Type='" & Me.cbPlanType.SelectedValue & "'," & _
                        " Description='" & Me.txtDescription.Text.Trim() & "', Age_Limit='" & Me.cbAgeLimit.Text.Trim() & "', Status='" & Status & "' WHERE id='" & Me.lblRefID.Text.Trim() & "'"
        scUps.ExecuteNonQuery()

        Dim scDUps As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
        scDUps.CommandType = CommandType.Text
        scDUps.CommandText = "UPDATE tb_Deduction_Code SET Received_By='" & Received_by & "', Received_From='" & Received_From & "' WHERE Product_Code='" & Me.txtProductCode.Text & "'"
        scDUps.ExecuteNonQuery()

        MsgBox("Successful Updated the Deduction Code...")
        Me.gbDeductionCode.Enabled = True
        Me.btnNew.Enabled = True
        Me.btnEdit.Enabled = True
        Me.btnDelete.Enabled = True
        gbMain.Visible = False
        getProductDetails()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub getProductDetails()
        Dim scGet As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        scGet.CommandType = CommandType.Text
        scGet.CommandText = "SELECT a.PRODUCT_CODE, a.Description FROM tb_product_code a " & _
                            " inner join tb_deduction_code c on a.product_code=c.product_code"
        Dim sda As New SqlDataAdapter(scGet)
        Dim ds As New DataSet
        sda.Fill(ds, "tb_product_code")
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvProductDetails
                .DataSource = ds
                .DataMember = "tb_product_code"
                .Columns(0).HeaderText = "Product Code"
                .Columns(1).HeaderText = "Description"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.Name = "Submit"
        Me.gbMain.Visible = True
        gbProduct.Visible = True
        Me.btnEdit.Enabled = False
        Me.btnDelete.Enabled = False
        Me.btnNew.Enabled = True
        Me.txtFilePrefix.Enabled = True
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvProductDetails.SelectedRows.Count > 0 Then
            Dim pro_id As String
            pro_id = Me.dgvProductDetails.SelectedRows(0).Cells(0).Value.ToString.Trim
            Dim _sqlCmdget_Pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            _sqlCmdget_Pro.CommandType = CommandType.Text
            _sqlCmdget_Pro.CommandText = "SELECT * FROM tb_product_code a " & _
                                        " inner join tb_deduction_code c on a.product_code=c.product_code where a.product_code='" & pro_id & "'"
            Dim adp As New SqlDataAdapter(_sqlCmdget_Pro)
            Dim ds As New DataSet
            adp.Fill(ds, "tb_product_code")
            Me.lblPCode.Text = ds.Tables(0).Rows(0)("Product_Code")

            Me.lblRefID.Text = ds.Tables(0).Rows(0)("ID").ToString.Trim()
            Me.txtProductCode.Text = ds.Tables(0).Rows(0)("Product_Code")
            Me.lblProductCode.Text = ds.Tables(0).Rows(0)("Product_Code")
            Me.lblDProductCode.Text = ds.Tables(0).Rows(0)("Product_Code")
            If Not IsDBNull(ds.Tables(0).Rows(0)("Age_Limit")) Then
                Me.cbAgeLimit.Text = ds.Tables(0).Rows(0)("Age_Limit")
            End If


            Me.cbProductName.SelectedValue = ds.Tables(0).Rows(0)("product_name")
            If ds.Tables(0).Rows(0)("policy_type") = "Group" Then
                Me.rbGroup.Checked = True
            ElseIf ds.Tables(0).Rows(0)("policy_type") = "Individual" Then
                Me.rbInd.Checked = True
            End If
            If Not ds.Tables(0).Rows(0)("Product_Type") = "" Then
                Me.cbProductType.SelectedValue = ds.Tables(0).Rows(0)("Product_Type")
            End If
            Me.cbPlanType.SelectedValue = ds.Tables(0).Rows(0)("Plan_Type")
            If Not IsDBNull(ds.Tables(0).Rows(0)("Description")) Then
                Me.txtDescription.Text = ds.Tables(0).Rows(0)("Description")
            End If
            If ds.Tables(0).Rows(0)("status") = "Active" Then
                Me.cbStatus.SelectedIndex = 0
            Else
                Me.cbStatus.SelectedIndex = 1
            End If

            Me.cbPremiumCode.SelectedValue = ds.Tables(0).Rows(0)("Premium_Code")

            PremiumDetails(ds.Tables(0).Rows(0)("Premium_Code"))


            Me.txtDeductionCode.Text = ds.Tables(0).Rows(0)("Deduction_Code")
            Select Case ds.Tables(0).Rows(0)("Received_By")
                Case "Medicare Care"
                    Me.cbDReceivedBy.SelectedIndex = 0
                Case "Test1"
                    Me.cbDReceivedBy.SelectedIndex = 1
                Case "Test2"
                    Me.cbDReceivedBy.SelectedIndex = 2
            End Select
            Select Case ds.Tables(0).Rows(0)("Received_From")
                Case "Angkasa"
                    Me.cbDReceivedFrom.SelectedIndex = 0
                Case "Test1"
                    Me.cbDReceivedFrom.SelectedIndex = 1
                Case "Test2"
                    Me.cbDReceivedFrom.SelectedIndex = 2
            End Select
            gbMain.Visible = True
            gbProduct.Visible = True
            Me.gbPremiumCode.Enabled = True
            Me.gbDeductionCode.Enabled = True
            Me.btnSubmit.Text = "Update"
            Me.btnSubmit.Name = "Update"
            Me.btnNew.Enabled = False
            Me.btnDelete.Enabled = False
            Me.btnAddProduct.Enabled = False
            Me.btnAddPremiumCode.Enabled = False
            Me.btnResetPremiumCode.Enabled = False
            Me.btnResetProduct.Enabled = False
            Me.txtProductCode.Enabled = False
            Me.txtDeductionCode.Enabled = False
            Me.cbPremiumCode.Enabled = False
            Me.btnEdit.Enabled = False
        Else
            MsgBox("Please select the row for edit!")
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dgvProductDetails.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to delete?", vbYesNo, "Delete") = vbYes Then
                Dim pro_id, sRes As String
                pro_id = Me.dgvProductDetails.SelectedRows(0).Cells(0).Value.ToString.Trim
                Dim _sqlCmddel_pro As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                _sqlCmddel_pro.CommandType = CommandType.Text
                _sqlCmddel_pro.CommandText = "Delete FROM tb_product_code where product_code='" & pro_id & "'"
                sRes = _sqlCmddel_pro.ExecuteNonQuery()

                Dim scDelD As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                scDelD.CommandType = CommandType.Text
                scDelD.CommandText = "DELETE from tb_deduction_code where product_code='" & pro_id & "'"
                scDelD.ExecuteNonQuery()

                If sRes = "1" Then
                    MsgBox("Successfully Deleted the Product!")
                    getProductDetails()
                Else
                    MsgBox("Error while Deleting the Product! or Currently our server busy please try again..")
                End If
            End If
        Else
            MsgBox("Please select the row for Delete!")
        End If
    End Sub
    Private Sub cbPremiumCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPremiumCode.SelectedIndexChanged
        Dim PremiumCode As String
        PremiumCode = Me.cbPremiumCode.SelectedValue.ToString()
        If Not PremiumCode = "" Then
            PremiumDetails(PremiumCode)
        End If
    End Sub
    Private Sub PremiumDetails(ByVal Premium_Code As String)
        Dim _ds As New DataSet
        Dim _scGetAgePremiumTable As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scGetAgePremiumTable.CommandType = CommandType.Text
        _scGetAgePremiumTable.CommandText = "select id, Premium_Code, Participant_type, age_limit, Premium_amt, Payment_Mode from tb_premium_table where Premium_Code='" & Premium_Code & "'"
        Dim _sdaGetAgePremiumTable As New SqlDataAdapter(_scGetAgePremiumTable)
        _sdaGetAgePremiumTable.Fill(_ds, "tb_premium_table")
        With Me.dgvPremiumCode
            .DataSource = _ds
            .DataMember = "tb_premium_table"
            .Columns(0).Visible = False 'id
            .Columns(1).HeaderText = "Premium Code"
            .Columns(2).HeaderText = "Participant Type"
            .Columns(3).HeaderText = "Age Limit"
            .Columns(4).HeaderText = "Premium Amount"
            .Columns(5).HeaderText = "Payment Mode"
            .Columns(4).DefaultCellStyle.Format = "#,#00.00"
        End With
    End Sub
    Private Sub cbProductName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProductName.SelectedIndexChanged
        Me.txtProductCode.Text = Me.cbProductName.Text.ToString().Trim()
    End Sub
End Class