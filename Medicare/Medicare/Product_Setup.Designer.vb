<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Product_Setup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbMain = New System.Windows.Forms.GroupBox
        Me.gbDeductionCode = New System.Windows.Forms.GroupBox
        Me.lblStatus1 = New System.Windows.Forms.Label
        Me.lblPCode = New System.Windows.Forms.Label
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblPP2 = New System.Windows.Forms.Label
        Me.txtDeductionCode = New System.Windows.Forms.TextBox
        Me.lblDDeductionCode1 = New System.Windows.Forms.Label
        Me.lblDDeductionCode = New System.Windows.Forms.Label
        Me.lblDProductCode = New System.Windows.Forms.Label
        Me.cbDReceivedBy = New System.Windows.Forms.ComboBox
        Me.lblDReceivedBy1 = New System.Windows.Forms.Label
        Me.lblDReceivedBy = New System.Windows.Forms.Label
        Me.cbDReceivedFrom = New System.Windows.Forms.ComboBox
        Me.lblDReceivedFrom1 = New System.Windows.Forms.Label
        Me.lblDReceivedFrom = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.gbPremiumCode = New System.Windows.Forms.GroupBox
        Me.dgvPremiumCode = New System.Windows.Forms.DataGridView
        Me.lblPP1 = New System.Windows.Forms.Label
        Me.lblProductCode = New System.Windows.Forms.Label
        Me.cbPremiumCode = New System.Windows.Forms.ComboBox
        Me.lblPremiumCode1 = New System.Windows.Forms.Label
        Me.lblPremiumCode = New System.Windows.Forms.Label
        Me.btnResetPremiumCode = New System.Windows.Forms.Button
        Me.btnAddPremiumCode = New System.Windows.Forms.Button
        Me.gbProduct = New System.Windows.Forms.GroupBox
        Me.cbAgeLimit = New System.Windows.Forms.ComboBox
        Me.lblAgeLimit1 = New System.Windows.Forms.Label
        Me.lblAgeLimit = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.lblDescription1 = New System.Windows.Forms.Label
        Me.lblDescription = New System.Windows.Forms.Label
        Me.txtProductCode = New System.Windows.Forms.TextBox
        Me.lblPProductCode1 = New System.Windows.Forms.Label
        Me.lblPProductCode = New System.Windows.Forms.Label
        Me.cbPlanType = New System.Windows.Forms.ComboBox
        Me.lblPlan1 = New System.Windows.Forms.Label
        Me.lblPlan = New System.Windows.Forms.Label
        Me.cbProductName = New System.Windows.Forms.ComboBox
        Me.lblProPlan1 = New System.Windows.Forms.Label
        Me.lblProPlan = New System.Windows.Forms.Label
        Me.cbProductType = New System.Windows.Forms.ComboBox
        Me.lblProType1 = New System.Windows.Forms.Label
        Me.lblProType = New System.Windows.Forms.Label
        Me.btnResetProduct = New System.Windows.Forms.Button
        Me.btnAddProduct = New System.Windows.Forms.Button
        Me.flpIns = New System.Windows.Forms.FlowLayoutPanel
        Me.rbGroup = New System.Windows.Forms.RadioButton
        Me.rbInd = New System.Windows.Forms.RadioButton
        Me.lblInsurType1 = New System.Windows.Forms.Label
        Me.lblInsurType = New System.Windows.Forms.Label
        Me.cbInsurerName = New System.Windows.Forms.ComboBox
        Me.lblInsurer1 = New System.Windows.Forms.Label
        Me.lblInsurer = New System.Windows.Forms.Label
        Me.dgvProductDetails = New System.Windows.Forms.DataGridView
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.txtFilePrefix = New System.Windows.Forms.TextBox
        Me.lblFilePrefix1 = New System.Windows.Forms.Label
        Me.lblFilePrefix = New System.Windows.Forms.Label
        Me.lblRefID = New System.Windows.Forms.Label
        Me.gbMain.SuspendLayout()
        Me.gbDeductionCode.SuspendLayout()
        Me.gbPremiumCode.SuspendLayout()
        CType(Me.dgvPremiumCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProduct.SuspendLayout()
        Me.flpIns.SuspendLayout()
        CType(Me.dgvProductDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.gbDeductionCode)
        Me.gbMain.Controls.Add(Me.gbPremiumCode)
        Me.gbMain.Controls.Add(Me.gbProduct)
        Me.gbMain.Location = New System.Drawing.Point(12, 174)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(920, 599)
        Me.gbMain.TabIndex = 0
        Me.gbMain.TabStop = False
        Me.gbMain.Text = "Product Set up"
        '
        'gbDeductionCode
        '
        Me.gbDeductionCode.Controls.Add(Me.lblStatus1)
        Me.gbDeductionCode.Controls.Add(Me.lblPCode)
        Me.gbDeductionCode.Controls.Add(Me.cbStatus)
        Me.gbDeductionCode.Controls.Add(Me.lblStatus)
        Me.gbDeductionCode.Controls.Add(Me.lblPP2)
        Me.gbDeductionCode.Controls.Add(Me.txtDeductionCode)
        Me.gbDeductionCode.Controls.Add(Me.lblDDeductionCode1)
        Me.gbDeductionCode.Controls.Add(Me.lblDDeductionCode)
        Me.gbDeductionCode.Controls.Add(Me.lblDProductCode)
        Me.gbDeductionCode.Controls.Add(Me.cbDReceivedBy)
        Me.gbDeductionCode.Controls.Add(Me.lblDReceivedBy1)
        Me.gbDeductionCode.Controls.Add(Me.lblDReceivedBy)
        Me.gbDeductionCode.Controls.Add(Me.cbDReceivedFrom)
        Me.gbDeductionCode.Controls.Add(Me.lblDReceivedFrom1)
        Me.gbDeductionCode.Controls.Add(Me.lblDReceivedFrom)
        Me.gbDeductionCode.Controls.Add(Me.btnCancel)
        Me.gbDeductionCode.Controls.Add(Me.btnSubmit)
        Me.gbDeductionCode.Location = New System.Drawing.Point(29, 443)
        Me.gbDeductionCode.Name = "gbDeductionCode"
        Me.gbDeductionCode.Size = New System.Drawing.Size(846, 139)
        Me.gbDeductionCode.TabIndex = 80
        Me.gbDeductionCode.TabStop = False
        Me.gbDeductionCode.Text = "Add Deduction Code"
        '
        'lblStatus1
        '
        Me.lblStatus1.AutoSize = True
        Me.lblStatus1.Location = New System.Drawing.Point(557, 63)
        Me.lblStatus1.Name = "lblStatus1"
        Me.lblStatus1.Size = New System.Drawing.Size(10, 13)
        Me.lblStatus1.TabIndex = 66
        Me.lblStatus1.Text = ":"
        '
        'lblPCode
        '
        Me.lblPCode.AutoSize = True
        Me.lblPCode.Location = New System.Drawing.Point(812, 108)
        Me.lblPCode.Name = "lblPCode"
        Me.lblPCode.Size = New System.Drawing.Size(18, 13)
        Me.lblPCode.TabIndex = 81
        Me.lblPCode.Text = "ID"
        Me.lblPCode.Visible = False
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        Me.cbStatus.Location = New System.Drawing.Point(604, 60)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(226, 21)
        Me.cbStatus.TabIndex = 65
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(434, 63)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 64
        Me.lblStatus.Text = "Status"
        '
        'lblPP2
        '
        Me.lblPP2.AutoSize = True
        Me.lblPP2.Location = New System.Drawing.Point(529, 16)
        Me.lblPP2.Name = "lblPP2"
        Me.lblPP2.Size = New System.Drawing.Size(78, 13)
        Me.lblPP2.TabIndex = 89
        Me.lblPP2.Text = "Product Code :"
        '
        'txtDeductionCode
        '
        Me.txtDeductionCode.Location = New System.Drawing.Point(189, 33)
        Me.txtDeductionCode.Name = "txtDeductionCode"
        Me.txtDeductionCode.Size = New System.Drawing.Size(226, 20)
        Me.txtDeductionCode.TabIndex = 84
        '
        'lblDDeductionCode1
        '
        Me.lblDDeductionCode1.AutoSize = True
        Me.lblDDeductionCode1.Location = New System.Drawing.Point(142, 32)
        Me.lblDDeductionCode1.Name = "lblDDeductionCode1"
        Me.lblDDeductionCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblDDeductionCode1.TabIndex = 83
        Me.lblDDeductionCode1.Text = ":"
        '
        'lblDDeductionCode
        '
        Me.lblDDeductionCode.AutoSize = True
        Me.lblDDeductionCode.Location = New System.Drawing.Point(19, 32)
        Me.lblDDeductionCode.Name = "lblDDeductionCode"
        Me.lblDDeductionCode.Size = New System.Drawing.Size(84, 13)
        Me.lblDDeductionCode.TabIndex = 82
        Me.lblDDeductionCode.Text = "Deduction Code"
        '
        'lblDProductCode
        '
        Me.lblDProductCode.AutoSize = True
        Me.lblDProductCode.Location = New System.Drawing.Point(613, 16)
        Me.lblDProductCode.Name = "lblDProductCode"
        Me.lblDProductCode.Size = New System.Drawing.Size(18, 13)
        Me.lblDProductCode.TabIndex = 80
        Me.lblDProductCode.Text = "ID"
        '
        'cbDReceivedBy
        '
        Me.cbDReceivedBy.FormattingEnabled = True
        Me.cbDReceivedBy.Items.AddRange(New Object() {"Medicare Care", "Test1", "Test2"})
        Me.cbDReceivedBy.Location = New System.Drawing.Point(604, 33)
        Me.cbDReceivedBy.Name = "cbDReceivedBy"
        Me.cbDReceivedBy.Size = New System.Drawing.Size(226, 21)
        Me.cbDReceivedBy.TabIndex = 78
        '
        'lblDReceivedBy1
        '
        Me.lblDReceivedBy1.AutoSize = True
        Me.lblDReceivedBy1.Location = New System.Drawing.Point(556, 36)
        Me.lblDReceivedBy1.Name = "lblDReceivedBy1"
        Me.lblDReceivedBy1.Size = New System.Drawing.Size(10, 13)
        Me.lblDReceivedBy1.TabIndex = 77
        Me.lblDReceivedBy1.Text = ":"
        '
        'lblDReceivedBy
        '
        Me.lblDReceivedBy.AutoSize = True
        Me.lblDReceivedBy.Location = New System.Drawing.Point(434, 36)
        Me.lblDReceivedBy.Name = "lblDReceivedBy"
        Me.lblDReceivedBy.Size = New System.Drawing.Size(68, 13)
        Me.lblDReceivedBy.TabIndex = 76
        Me.lblDReceivedBy.Text = "Received By"
        '
        'cbDReceivedFrom
        '
        Me.cbDReceivedFrom.FormattingEnabled = True
        Me.cbDReceivedFrom.Location = New System.Drawing.Point(189, 59)
        Me.cbDReceivedFrom.Name = "cbDReceivedFrom"
        Me.cbDReceivedFrom.Size = New System.Drawing.Size(226, 21)
        Me.cbDReceivedFrom.TabIndex = 75
        '
        'lblDReceivedFrom1
        '
        Me.lblDReceivedFrom1.AutoSize = True
        Me.lblDReceivedFrom1.Location = New System.Drawing.Point(142, 59)
        Me.lblDReceivedFrom1.Name = "lblDReceivedFrom1"
        Me.lblDReceivedFrom1.Size = New System.Drawing.Size(10, 13)
        Me.lblDReceivedFrom1.TabIndex = 74
        Me.lblDReceivedFrom1.Text = ":"
        '
        'lblDReceivedFrom
        '
        Me.lblDReceivedFrom.AutoSize = True
        Me.lblDReceivedFrom.Location = New System.Drawing.Point(19, 59)
        Me.lblDReceivedFrom.Name = "lblDReceivedFrom"
        Me.lblDReceivedFrom.Size = New System.Drawing.Size(79, 13)
        Me.lblDReceivedFrom.TabIndex = 73
        Me.lblDReceivedFrom.Text = "Received From"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(458, 98)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(340, 98)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 24
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'gbPremiumCode
        '
        Me.gbPremiumCode.Controls.Add(Me.lblRefID)
        Me.gbPremiumCode.Controls.Add(Me.dgvPremiumCode)
        Me.gbPremiumCode.Controls.Add(Me.lblPP1)
        Me.gbPremiumCode.Controls.Add(Me.lblProductCode)
        Me.gbPremiumCode.Controls.Add(Me.cbPremiumCode)
        Me.gbPremiumCode.Controls.Add(Me.lblPremiumCode1)
        Me.gbPremiumCode.Controls.Add(Me.lblPremiumCode)
        Me.gbPremiumCode.Controls.Add(Me.btnResetPremiumCode)
        Me.gbPremiumCode.Controls.Add(Me.btnAddPremiumCode)
        Me.gbPremiumCode.Location = New System.Drawing.Point(29, 259)
        Me.gbPremiumCode.Name = "gbPremiumCode"
        Me.gbPremiumCode.Size = New System.Drawing.Size(846, 178)
        Me.gbPremiumCode.TabIndex = 79
        Me.gbPremiumCode.TabStop = False
        Me.gbPremiumCode.Text = "Add Premium Code"
        '
        'dgvPremiumCode
        '
        Me.dgvPremiumCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPremiumCode.Location = New System.Drawing.Point(14, 56)
        Me.dgvPremiumCode.Name = "dgvPremiumCode"
        Me.dgvPremiumCode.Size = New System.Drawing.Size(798, 75)
        Me.dgvPremiumCode.TabIndex = 89
        '
        'lblPP1
        '
        Me.lblPP1.AutoSize = True
        Me.lblPP1.Location = New System.Drawing.Point(529, 16)
        Me.lblPP1.Name = "lblPP1"
        Me.lblPP1.Size = New System.Drawing.Size(78, 13)
        Me.lblPP1.TabIndex = 88
        Me.lblPP1.Text = "Product Code :"
        '
        'lblProductCode
        '
        Me.lblProductCode.AutoSize = True
        Me.lblProductCode.Location = New System.Drawing.Point(613, 16)
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Size = New System.Drawing.Size(18, 13)
        Me.lblProductCode.TabIndex = 79
        Me.lblProductCode.Text = "ID"
        '
        'cbPremiumCode
        '
        Me.cbPremiumCode.FormattingEnabled = True
        Me.cbPremiumCode.Location = New System.Drawing.Point(189, 19)
        Me.cbPremiumCode.Name = "cbPremiumCode"
        Me.cbPremiumCode.Size = New System.Drawing.Size(226, 21)
        Me.cbPremiumCode.TabIndex = 78
        '
        'lblPremiumCode1
        '
        Me.lblPremiumCode1.AutoSize = True
        Me.lblPremiumCode1.Location = New System.Drawing.Point(141, 22)
        Me.lblPremiumCode1.Name = "lblPremiumCode1"
        Me.lblPremiumCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblPremiumCode1.TabIndex = 77
        Me.lblPremiumCode1.Text = ":"
        '
        'lblPremiumCode
        '
        Me.lblPremiumCode.AutoSize = True
        Me.lblPremiumCode.Location = New System.Drawing.Point(23, 22)
        Me.lblPremiumCode.Name = "lblPremiumCode"
        Me.lblPremiumCode.Size = New System.Drawing.Size(75, 13)
        Me.lblPremiumCode.TabIndex = 76
        Me.lblPremiumCode.Text = "Premium Code"
        '
        'btnResetPremiumCode
        '
        Me.btnResetPremiumCode.Location = New System.Drawing.Point(458, 137)
        Me.btnResetPremiumCode.Name = "btnResetPremiumCode"
        Me.btnResetPremiumCode.Size = New System.Drawing.Size(75, 23)
        Me.btnResetPremiumCode.TabIndex = 25
        Me.btnResetPremiumCode.Text = "Reset"
        Me.btnResetPremiumCode.UseVisualStyleBackColor = True
        '
        'btnAddPremiumCode
        '
        Me.btnAddPremiumCode.Location = New System.Drawing.Point(340, 137)
        Me.btnAddPremiumCode.Name = "btnAddPremiumCode"
        Me.btnAddPremiumCode.Size = New System.Drawing.Size(75, 23)
        Me.btnAddPremiumCode.TabIndex = 24
        Me.btnAddPremiumCode.Text = "Add"
        Me.btnAddPremiumCode.UseVisualStyleBackColor = True
        '
        'gbProduct
        '
        Me.gbProduct.Controls.Add(Me.cbAgeLimit)
        Me.gbProduct.Controls.Add(Me.lblAgeLimit1)
        Me.gbProduct.Controls.Add(Me.lblAgeLimit)
        Me.gbProduct.Controls.Add(Me.txtDescription)
        Me.gbProduct.Controls.Add(Me.lblDescription1)
        Me.gbProduct.Controls.Add(Me.lblDescription)
        Me.gbProduct.Controls.Add(Me.txtProductCode)
        Me.gbProduct.Controls.Add(Me.lblPProductCode1)
        Me.gbProduct.Controls.Add(Me.lblPProductCode)
        Me.gbProduct.Controls.Add(Me.cbPlanType)
        Me.gbProduct.Controls.Add(Me.lblPlan1)
        Me.gbProduct.Controls.Add(Me.lblPlan)
        Me.gbProduct.Controls.Add(Me.cbProductName)
        Me.gbProduct.Controls.Add(Me.lblProPlan1)
        Me.gbProduct.Controls.Add(Me.lblProPlan)
        Me.gbProduct.Controls.Add(Me.cbProductType)
        Me.gbProduct.Controls.Add(Me.lblProType1)
        Me.gbProduct.Controls.Add(Me.lblProType)
        Me.gbProduct.Controls.Add(Me.btnResetProduct)
        Me.gbProduct.Controls.Add(Me.btnAddProduct)
        Me.gbProduct.Controls.Add(Me.flpIns)
        Me.gbProduct.Controls.Add(Me.lblInsurType1)
        Me.gbProduct.Controls.Add(Me.lblInsurType)
        Me.gbProduct.Controls.Add(Me.cbInsurerName)
        Me.gbProduct.Controls.Add(Me.lblInsurer1)
        Me.gbProduct.Controls.Add(Me.lblInsurer)
        Me.gbProduct.Location = New System.Drawing.Point(29, 19)
        Me.gbProduct.Name = "gbProduct"
        Me.gbProduct.Size = New System.Drawing.Size(846, 234)
        Me.gbProduct.TabIndex = 1
        Me.gbProduct.TabStop = False
        Me.gbProduct.Text = "Add Product Details"
        '
        'cbAgeLimit
        '
        Me.cbAgeLimit.FormattingEnabled = True
        Me.cbAgeLimit.Location = New System.Drawing.Point(182, 106)
        Me.cbAgeLimit.Name = "cbAgeLimit"
        Me.cbAgeLimit.Size = New System.Drawing.Size(226, 21)
        Me.cbAgeLimit.TabIndex = 87
        '
        'lblAgeLimit1
        '
        Me.lblAgeLimit1.AutoSize = True
        Me.lblAgeLimit1.Location = New System.Drawing.Point(134, 111)
        Me.lblAgeLimit1.Name = "lblAgeLimit1"
        Me.lblAgeLimit1.Size = New System.Drawing.Size(10, 13)
        Me.lblAgeLimit1.TabIndex = 86
        Me.lblAgeLimit1.Text = ":"
        '
        'lblAgeLimit
        '
        Me.lblAgeLimit.AutoSize = True
        Me.lblAgeLimit.Location = New System.Drawing.Point(11, 111)
        Me.lblAgeLimit.Name = "lblAgeLimit"
        Me.lblAgeLimit.Size = New System.Drawing.Size(50, 13)
        Me.lblAgeLimit.TabIndex = 85
        Me.lblAgeLimit.Text = "Age Limit"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(182, 133)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(630, 61)
        Me.txtDescription.TabIndex = 84
        '
        'lblDescription1
        '
        Me.lblDescription1.AutoSize = True
        Me.lblDescription1.Location = New System.Drawing.Point(135, 132)
        Me.lblDescription1.Name = "lblDescription1"
        Me.lblDescription1.Size = New System.Drawing.Size(10, 13)
        Me.lblDescription1.TabIndex = 83
        Me.lblDescription1.Text = ":"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(12, 132)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(100, 13)
        Me.lblDescription.TabIndex = 82
        Me.lblDescription.Text = "Product Description"
        '
        'txtProductCode
        '
        Me.txtProductCode.Location = New System.Drawing.Point(182, 26)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(226, 20)
        Me.txtProductCode.TabIndex = 81
        '
        'lblPProductCode1
        '
        Me.lblPProductCode1.AutoSize = True
        Me.lblPProductCode1.Location = New System.Drawing.Point(135, 25)
        Me.lblPProductCode1.Name = "lblPProductCode1"
        Me.lblPProductCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblPProductCode1.TabIndex = 80
        Me.lblPProductCode1.Text = ":"
        '
        'lblPProductCode
        '
        Me.lblPProductCode.AutoSize = True
        Me.lblPProductCode.Location = New System.Drawing.Point(12, 25)
        Me.lblPProductCode.Name = "lblPProductCode"
        Me.lblPProductCode.Size = New System.Drawing.Size(72, 13)
        Me.lblPProductCode.TabIndex = 79
        Me.lblPProductCode.Text = "Product Code"
        '
        'cbPlanType
        '
        Me.cbPlanType.FormattingEnabled = True
        Me.cbPlanType.Location = New System.Drawing.Point(586, 87)
        Me.cbPlanType.Name = "cbPlanType"
        Me.cbPlanType.Size = New System.Drawing.Size(226, 21)
        Me.cbPlanType.TabIndex = 78
        '
        'lblPlan1
        '
        Me.lblPlan1.AutoSize = True
        Me.lblPlan1.Location = New System.Drawing.Point(540, 87)
        Me.lblPlan1.Name = "lblPlan1"
        Me.lblPlan1.Size = New System.Drawing.Size(10, 13)
        Me.lblPlan1.TabIndex = 77
        Me.lblPlan1.Text = ":"
        '
        'lblPlan
        '
        Me.lblPlan.AutoSize = True
        Me.lblPlan.Location = New System.Drawing.Point(433, 87)
        Me.lblPlan.Name = "lblPlan"
        Me.lblPlan.Size = New System.Drawing.Size(55, 13)
        Me.lblPlan.TabIndex = 76
        Me.lblPlan.Text = "Plan Type"
        '
        'cbProductName
        '
        Me.cbProductName.FormattingEnabled = True
        Me.cbProductName.Location = New System.Drawing.Point(586, 25)
        Me.cbProductName.Name = "cbProductName"
        Me.cbProductName.Size = New System.Drawing.Size(226, 21)
        Me.cbProductName.TabIndex = 75
        '
        'lblProPlan1
        '
        Me.lblProPlan1.AutoSize = True
        Me.lblProPlan1.Location = New System.Drawing.Point(540, 29)
        Me.lblProPlan1.Name = "lblProPlan1"
        Me.lblProPlan1.Size = New System.Drawing.Size(10, 13)
        Me.lblProPlan1.TabIndex = 74
        Me.lblProPlan1.Text = ":"
        '
        'lblProPlan
        '
        Me.lblProPlan.AutoSize = True
        Me.lblProPlan.Location = New System.Drawing.Point(433, 29)
        Me.lblProPlan.Name = "lblProPlan"
        Me.lblProPlan.Size = New System.Drawing.Size(75, 13)
        Me.lblProPlan.TabIndex = 73
        Me.lblProPlan.Text = "Product Name"
        '
        'cbProductType
        '
        Me.cbProductType.FormattingEnabled = True
        Me.cbProductType.Location = New System.Drawing.Point(182, 79)
        Me.cbProductType.Name = "cbProductType"
        Me.cbProductType.Size = New System.Drawing.Size(226, 21)
        Me.cbProductType.TabIndex = 66
        '
        'lblProType1
        '
        Me.lblProType1.AutoSize = True
        Me.lblProType1.Location = New System.Drawing.Point(134, 84)
        Me.lblProType1.Name = "lblProType1"
        Me.lblProType1.Size = New System.Drawing.Size(10, 13)
        Me.lblProType1.TabIndex = 65
        Me.lblProType1.Text = ":"
        '
        'lblProType
        '
        Me.lblProType.AutoSize = True
        Me.lblProType.Location = New System.Drawing.Point(11, 84)
        Me.lblProType.Name = "lblProType"
        Me.lblProType.Size = New System.Drawing.Size(71, 13)
        Me.lblProType.TabIndex = 64
        Me.lblProType.Text = "Product Type"
        '
        'btnResetProduct
        '
        Me.btnResetProduct.Location = New System.Drawing.Point(458, 200)
        Me.btnResetProduct.Name = "btnResetProduct"
        Me.btnResetProduct.Size = New System.Drawing.Size(75, 23)
        Me.btnResetProduct.TabIndex = 25
        Me.btnResetProduct.Text = "Reset"
        Me.btnResetProduct.UseVisualStyleBackColor = True
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Location = New System.Drawing.Point(340, 200)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(75, 23)
        Me.btnAddProduct.TabIndex = 24
        Me.btnAddProduct.Text = "Add"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'flpIns
        '
        Me.flpIns.Controls.Add(Me.rbGroup)
        Me.flpIns.Controls.Add(Me.rbInd)
        Me.flpIns.Location = New System.Drawing.Point(591, 52)
        Me.flpIns.Name = "flpIns"
        Me.flpIns.Size = New System.Drawing.Size(221, 29)
        Me.flpIns.TabIndex = 7
        '
        'rbGroup
        '
        Me.rbGroup.AutoSize = True
        Me.rbGroup.Checked = True
        Me.rbGroup.Location = New System.Drawing.Point(3, 3)
        Me.rbGroup.Name = "rbGroup"
        Me.rbGroup.Size = New System.Drawing.Size(54, 17)
        Me.rbGroup.TabIndex = 5
        Me.rbGroup.TabStop = True
        Me.rbGroup.Text = "Group"
        Me.rbGroup.UseVisualStyleBackColor = True
        '
        'rbInd
        '
        Me.rbInd.AutoSize = True
        Me.rbInd.Location = New System.Drawing.Point(63, 3)
        Me.rbInd.Name = "rbInd"
        Me.rbInd.Size = New System.Drawing.Size(70, 17)
        Me.rbInd.TabIndex = 6
        Me.rbInd.TabStop = True
        Me.rbInd.Text = "Individual"
        Me.rbInd.UseVisualStyleBackColor = True
        '
        'lblInsurType1
        '
        Me.lblInsurType1.AutoSize = True
        Me.lblInsurType1.Location = New System.Drawing.Point(540, 60)
        Me.lblInsurType1.Name = "lblInsurType1"
        Me.lblInsurType1.Size = New System.Drawing.Size(10, 13)
        Me.lblInsurType1.TabIndex = 4
        Me.lblInsurType1.Text = ":"
        '
        'lblInsurType
        '
        Me.lblInsurType.AutoSize = True
        Me.lblInsurType.Location = New System.Drawing.Point(433, 60)
        Me.lblInsurType.Name = "lblInsurType"
        Me.lblInsurType.Size = New System.Drawing.Size(66, 13)
        Me.lblInsurType.TabIndex = 3
        Me.lblInsurType.Text = "Policy Type*"
        '
        'cbInsurerName
        '
        Me.cbInsurerName.FormattingEnabled = True
        Me.cbInsurerName.Location = New System.Drawing.Point(182, 52)
        Me.cbInsurerName.Name = "cbInsurerName"
        Me.cbInsurerName.Size = New System.Drawing.Size(226, 21)
        Me.cbInsurerName.TabIndex = 2
        '
        'lblInsurer1
        '
        Me.lblInsurer1.AutoSize = True
        Me.lblInsurer1.Location = New System.Drawing.Point(134, 50)
        Me.lblInsurer1.Name = "lblInsurer1"
        Me.lblInsurer1.Size = New System.Drawing.Size(10, 13)
        Me.lblInsurer1.TabIndex = 1
        Me.lblInsurer1.Text = ":"
        '
        'lblInsurer
        '
        Me.lblInsurer.AutoSize = True
        Me.lblInsurer.Location = New System.Drawing.Point(12, 50)
        Me.lblInsurer.Name = "lblInsurer"
        Me.lblInsurer.Size = New System.Drawing.Size(77, 13)
        Me.lblInsurer.TabIndex = 0
        Me.lblInsurer.Text = "Insurer Name *"
        '
        'dgvProductDetails
        '
        Me.dgvProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductDetails.Location = New System.Drawing.Point(13, 13)
        Me.dgvProductDetails.Name = "dgvProductDetails"
        Me.dgvProductDetails.Size = New System.Drawing.Size(919, 118)
        Me.dgvProductDetails.TabIndex = 1
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(346, 146)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 25)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(438, 146)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 25)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(528, 146)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtFilePrefix
        '
        Me.txtFilePrefix.Location = New System.Drawing.Point(818, 151)
        Me.txtFilePrefix.Name = "txtFilePrefix"
        Me.txtFilePrefix.Size = New System.Drawing.Size(114, 20)
        Me.txtFilePrefix.TabIndex = 87
        '
        'lblFilePrefix1
        '
        Me.lblFilePrefix1.AutoSize = True
        Me.lblFilePrefix1.Location = New System.Drawing.Point(802, 154)
        Me.lblFilePrefix1.Name = "lblFilePrefix1"
        Me.lblFilePrefix1.Size = New System.Drawing.Size(10, 13)
        Me.lblFilePrefix1.TabIndex = 86
        Me.lblFilePrefix1.Text = ":"
        '
        'lblFilePrefix
        '
        Me.lblFilePrefix.AutoSize = True
        Me.lblFilePrefix.Location = New System.Drawing.Point(744, 154)
        Me.lblFilePrefix.Name = "lblFilePrefix"
        Me.lblFilePrefix.Size = New System.Drawing.Size(52, 13)
        Me.lblFilePrefix.TabIndex = 85
        Me.lblFilePrefix.Text = "File Prefix"
        '
        'lblRefID
        '
        Me.lblRefID.AutoSize = True
        Me.lblRefID.Location = New System.Drawing.Point(689, 19)
        Me.lblRefID.Name = "lblRefID"
        Me.lblRefID.Size = New System.Drawing.Size(39, 13)
        Me.lblRefID.TabIndex = 90
        Me.lblRefID.Text = "REFID"
        Me.lblRefID.Visible = False
        '
        'Product_Setup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 785)
        Me.Controls.Add(Me.txtFilePrefix)
        Me.Controls.Add(Me.lblFilePrefix1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblFilePrefix)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.dgvProductDetails)
        Me.Controls.Add(Me.gbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Product_Setup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product_Setup"
        Me.gbMain.ResumeLayout(False)
        Me.gbDeductionCode.ResumeLayout(False)
        Me.gbDeductionCode.PerformLayout()
        Me.gbPremiumCode.ResumeLayout(False)
        Me.gbPremiumCode.PerformLayout()
        CType(Me.dgvPremiumCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProduct.ResumeLayout(False)
        Me.gbProduct.PerformLayout()
        Me.flpIns.ResumeLayout(False)
        Me.flpIns.PerformLayout()
        CType(Me.dgvProductDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbMain As System.Windows.Forms.GroupBox
    Friend WithEvents gbProduct As System.Windows.Forms.GroupBox
    Friend WithEvents cbPlanType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlan1 As System.Windows.Forms.Label
    Friend WithEvents lblPlan As System.Windows.Forms.Label
    Friend WithEvents cbProductName As System.Windows.Forms.ComboBox
    Friend WithEvents lblProPlan1 As System.Windows.Forms.Label
    Friend WithEvents lblProPlan As System.Windows.Forms.Label
    Friend WithEvents cbProductType As System.Windows.Forms.ComboBox
    Friend WithEvents lblProType1 As System.Windows.Forms.Label
    Friend WithEvents lblProType As System.Windows.Forms.Label
    Friend WithEvents btnResetProduct As System.Windows.Forms.Button
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents flpIns As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbGroup As System.Windows.Forms.RadioButton
    Friend WithEvents rbInd As System.Windows.Forms.RadioButton
    Friend WithEvents lblInsurType1 As System.Windows.Forms.Label
    Friend WithEvents lblInsurType As System.Windows.Forms.Label
    Friend WithEvents cbInsurerName As System.Windows.Forms.ComboBox
    Friend WithEvents lblInsurer1 As System.Windows.Forms.Label
    Friend WithEvents lblInsurer As System.Windows.Forms.Label
    Friend WithEvents gbPremiumCode As System.Windows.Forms.GroupBox
    Friend WithEvents cbPremiumCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblPremiumCode1 As System.Windows.Forms.Label
    Friend WithEvents lblPremiumCode As System.Windows.Forms.Label
    Friend WithEvents btnResetPremiumCode As System.Windows.Forms.Button
    Friend WithEvents btnAddPremiumCode As System.Windows.Forms.Button
    Friend WithEvents gbDeductionCode As System.Windows.Forms.GroupBox
    Friend WithEvents cbDReceivedBy As System.Windows.Forms.ComboBox
    Friend WithEvents lblDReceivedBy1 As System.Windows.Forms.Label
    Friend WithEvents lblDReceivedBy As System.Windows.Forms.Label
    Friend WithEvents cbDReceivedFrom As System.Windows.Forms.ComboBox
    Friend WithEvents lblDReceivedFrom1 As System.Windows.Forms.Label
    Friend WithEvents lblDReceivedFrom As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblProductCode As System.Windows.Forms.Label
    Friend WithEvents lblDProductCode As System.Windows.Forms.Label
    Friend WithEvents lblPProductCode1 As System.Windows.Forms.Label
    Friend WithEvents lblPProductCode As System.Windows.Forms.Label
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDeductionCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDDeductionCode1 As System.Windows.Forms.Label
    Friend WithEvents lblDDeductionCode As System.Windows.Forms.Label
    Friend WithEvents lblPP2 As System.Windows.Forms.Label
    Friend WithEvents lblPP1 As System.Windows.Forms.Label
    Friend WithEvents dgvProductDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lblPCode As System.Windows.Forms.Label
    Friend WithEvents dgvPremiumCode As System.Windows.Forms.DataGridView
    Friend WithEvents lblStatus1 As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription1 As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtFilePrefix As System.Windows.Forms.TextBox
    Friend WithEvents lblFilePrefix1 As System.Windows.Forms.Label
    Friend WithEvents lblFilePrefix As System.Windows.Forms.Label
    Friend WithEvents cbAgeLimit As System.Windows.Forms.ComboBox
    Friend WithEvents lblAgeLimit1 As System.Windows.Forms.Label
    Friend WithEvents lblAgeLimit As System.Windows.Forms.Label
    Friend WithEvents lblRefID As System.Windows.Forms.Label
End Class
