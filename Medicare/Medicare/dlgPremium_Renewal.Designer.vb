<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgPremium_Renewal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgPremium_Renewal))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_Filter = New System.Windows.Forms.ToolStripComboBox
        Me.tsb_Filter_Param = New System.Windows.Forms.ToolStripTextBox
        Me.tsb_Filter_Go = New System.Windows.Forms.ToolStripButton
        Me.dgvPolicies = New System.Windows.Forms.DataGridView
        Me.txtRenewal_Premium = New System.Windows.Forms.TextBox
        Me.lblRenewal_Premium = New System.Windows.Forms.Label
        Me.txtPolicy_ExpiryDate = New System.Windows.Forms.TextBox
        Me.lblPolicy_ExpiryDate = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtL2_Plan_Code = New System.Windows.Forms.TextBox
        Me.lblL2_Plan_Code = New System.Windows.Forms.Label
        Me.txtFileNo = New System.Windows.Forms.TextBox
        Me.lblFileNo = New System.Windows.Forms.Label
        Me.txtNRIC = New System.Windows.Forms.TextBox
        Me.lblNRIC = New System.Windows.Forms.Label
        Me.lblMemberPolicy_ID = New System.Windows.Forms.Label
        Me.GrpBox_Payment_Details = New System.Windows.Forms.GroupBox
        Me.fowProposer_Race = New System.Windows.Forms.FlowLayoutPanel
        Me.rdCash = New System.Windows.Forms.RadioButton
        Me.rdCheque = New System.Windows.Forms.RadioButton
        Me.rdCC = New System.Windows.Forms.RadioButton
        Me.dtpRequestedDate = New System.Windows.Forms.DateTimePicker
        Me.lblRequestedDate = New System.Windows.Forms.Label
        Me.txtRenewal_Premium_New = New System.Windows.Forms.TextBox
        Me.lblRenewal_Premium_New = New System.Windows.Forms.Label
        Me.GrpBox_Payment_Details_Cash = New System.Windows.Forms.GroupBox
        Me.txtPayment_Cash_Receipt_IssuedBy = New System.Windows.Forms.TextBox
        Me.lblPayment_Cash_Receipt_IssuedBy = New System.Windows.Forms.Label
        Me.txtPayment_Cash_Receipt_No = New System.Windows.Forms.TextBox
        Me.lblPayment_Cash_Receipt_No = New System.Windows.Forms.Label
        Me.GrpBox_Payment_Details_Cheque = New System.Windows.Forms.GroupBox
        Me.txtPayment_Cheque_Receipt_No = New System.Windows.Forms.TextBox
        Me.lblPayment_Cheque_Receipt_No = New System.Windows.Forms.Label
        Me.txtPayment_Cheque_No = New System.Windows.Forms.TextBox
        Me.lblPayment_Cheque_No = New System.Windows.Forms.Label
        Me.GrpBox_Payment_Details_CreditCard = New System.Windows.Forms.GroupBox
        Me.txtPayment_CreditCard_Inv_No = New System.Windows.Forms.TextBox
        Me.lblPayment_CreditCard_Inv_No = New System.Windows.Forms.Label
        Me.txtPayment_CreditCard_BatchNo = New System.Windows.Forms.TextBox
        Me.lblPayment_CreditCard_BatchNo = New System.Windows.Forms.Label
        Me.txtPayment_CreditCard_ApprCode = New System.Windows.Forms.TextBox
        Me.lblPayment_CreditCard_ApprCode = New System.Windows.Forms.Label
        Me.lblPayment_Method = New System.Windows.Forms.Label
        Me.txtAge = New System.Windows.Forms.TextBox
        Me.lblAge = New System.Windows.Forms.Label
        Me.txtPolicy_EffectiveDate = New System.Windows.Forms.TextBox
        Me.lblPolicy_EffectiveDate = New System.Windows.Forms.Label
        Me.txtDOB = New System.Windows.Forms.TextBox
        Me.lblDOB = New System.Windows.Forms.Label
        Me.btnPrint_YearlyLetter = New System.Windows.Forms.Button
        Me.txtGST = New System.Windows.Forms.TextBox
        Me.lblGST = New System.Windows.Forms.Label
        Me.txtTotalPremium = New System.Windows.Forms.TextBox
        Me.lblTotalPremium = New System.Windows.Forms.Label
        Me.cbGST = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tolForm.SuspendLayout()
        CType(Me.dgvPolicies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBox_Payment_Details.SuspendLayout()
        Me.fowProposer_Race.SuspendLayout()
        Me.GrpBox_Payment_Details_Cash.SuspendLayout()
        Me.GrpBox_Payment_Details_Cheque.SuspendLayout()
        Me.GrpBox_Payment_Details_CreditCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(560, 604)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 22
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Filter, Me.tsb_Filter_Param, Me.tsb_Filter_Go})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(718, 25)
        Me.tolForm.TabIndex = 0
        Me.tolForm.Text = "ToolStrip1"
        '
        'tsb_Filter
        '
        Me.tsb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tsb_Filter.Items.AddRange(New Object() {"", "IC", "Full Name"})
        Me.tsb_Filter.Name = "tsb_Filter"
        Me.tsb_Filter.Size = New System.Drawing.Size(100, 25)
        '
        'tsb_Filter_Param
        '
        Me.tsb_Filter_Param.MaxLength = 50
        Me.tsb_Filter_Param.Name = "tsb_Filter_Param"
        Me.tsb_Filter_Param.Size = New System.Drawing.Size(250, 25)
        '
        'tsb_Filter_Go
        '
        Me.tsb_Filter_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Filter_Go.Image = CType(resources.GetObject("tsb_Filter_Go.Image"), System.Drawing.Image)
        Me.tsb_Filter_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Filter_Go.Name = "tsb_Filter_Go"
        Me.tsb_Filter_Go.Size = New System.Drawing.Size(34, 22)
        Me.tsb_Filter_Go.Text = "GO.."
        Me.tsb_Filter_Go.ToolTipText = "Go"
        '
        'dgvPolicies
        '
        Me.dgvPolicies.AllowUserToAddRows = False
        Me.dgvPolicies.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPolicies.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPolicies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPolicies.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPolicies.Location = New System.Drawing.Point(9, 28)
        Me.dgvPolicies.Name = "dgvPolicies"
        Me.dgvPolicies.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPolicies.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPolicies.Size = New System.Drawing.Size(694, 121)
        Me.dgvPolicies.TabIndex = 1
        '
        'txtRenewal_Premium
        '
        Me.txtRenewal_Premium.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRenewal_Premium.Location = New System.Drawing.Point(327, 238)
        Me.txtRenewal_Premium.MaxLength = 6
        Me.txtRenewal_Premium.Name = "txtRenewal_Premium"
        Me.txtRenewal_Premium.ReadOnly = True
        Me.txtRenewal_Premium.Size = New System.Drawing.Size(75, 20)
        Me.txtRenewal_Premium.TabIndex = 15
        Me.txtRenewal_Premium.TabStop = False
        Me.txtRenewal_Premium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRenewal_Premium
        '
        Me.lblRenewal_Premium.AutoSize = True
        Me.lblRenewal_Premium.Location = New System.Drawing.Point(226, 242)
        Me.lblRenewal_Premium.Name = "lblRenewal_Premium"
        Me.lblRenewal_Premium.Size = New System.Drawing.Size(95, 13)
        Me.lblRenewal_Premium.TabIndex = 14
        Me.lblRenewal_Premium.Text = "Renewal Premium:"
        '
        'txtPolicy_ExpiryDate
        '
        Me.txtPolicy_ExpiryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicy_ExpiryDate.Location = New System.Drawing.Point(327, 264)
        Me.txtPolicy_ExpiryDate.Name = "txtPolicy_ExpiryDate"
        Me.txtPolicy_ExpiryDate.ReadOnly = True
        Me.txtPolicy_ExpiryDate.Size = New System.Drawing.Size(75, 20)
        Me.txtPolicy_ExpiryDate.TabIndex = 19
        Me.txtPolicy_ExpiryDate.TabStop = False
        '
        'lblPolicy_ExpiryDate
        '
        Me.lblPolicy_ExpiryDate.AutoSize = True
        Me.lblPolicy_ExpiryDate.Location = New System.Drawing.Point(257, 268)
        Me.lblPolicy_ExpiryDate.Name = "lblPolicy_ExpiryDate"
        Me.lblPolicy_ExpiryDate.Size = New System.Drawing.Size(64, 13)
        Me.lblPolicy_ExpiryDate.TabIndex = 18
        Me.lblPolicy_ExpiryDate.Text = "Expiry Date:"
        '
        'txtName
        '
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(134, 186)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(445, 20)
        Me.txtName.TabIndex = 5
        Me.txtName.TabStop = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(6, 190)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(112, 13)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Full Name As in NRIC:"
        '
        'txtL2_Plan_Code
        '
        Me.txtL2_Plan_Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtL2_Plan_Code.Location = New System.Drawing.Point(134, 238)
        Me.txtL2_Plan_Code.MaxLength = 4
        Me.txtL2_Plan_Code.Name = "txtL2_Plan_Code"
        Me.txtL2_Plan_Code.ReadOnly = True
        Me.txtL2_Plan_Code.Size = New System.Drawing.Size(61, 20)
        Me.txtL2_Plan_Code.TabIndex = 13
        Me.txtL2_Plan_Code.TabStop = False
        '
        'lblL2_Plan_Code
        '
        Me.lblL2_Plan_Code.AutoSize = True
        Me.lblL2_Plan_Code.Location = New System.Drawing.Point(6, 242)
        Me.lblL2_Plan_Code.Name = "lblL2_Plan_Code"
        Me.lblL2_Plan_Code.Size = New System.Drawing.Size(103, 13)
        Me.lblL2_Plan_Code.TabIndex = 12
        Me.lblL2_Plan_Code.Text = "Plan Code (Level 2):"
        '
        'txtFileNo
        '
        Me.txtFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileNo.Location = New System.Drawing.Point(134, 161)
        Me.txtFileNo.MaxLength = 20
        Me.txtFileNo.Name = "txtFileNo"
        Me.txtFileNo.ReadOnly = True
        Me.txtFileNo.Size = New System.Drawing.Size(135, 20)
        Me.txtFileNo.TabIndex = 3
        Me.txtFileNo.TabStop = False
        '
        'lblFileNo
        '
        Me.lblFileNo.AutoSize = True
        Me.lblFileNo.Location = New System.Drawing.Point(6, 165)
        Me.lblFileNo.Name = "lblFileNo"
        Me.lblFileNo.Size = New System.Drawing.Size(43, 13)
        Me.lblFileNo.TabIndex = 2
        Me.lblFileNo.Text = "File No:"
        '
        'txtNRIC
        '
        Me.txtNRIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNRIC.Location = New System.Drawing.Point(134, 212)
        Me.txtNRIC.MaxLength = 13
        Me.txtNRIC.Name = "txtNRIC"
        Me.txtNRIC.ReadOnly = True
        Me.txtNRIC.Size = New System.Drawing.Size(109, 20)
        Me.txtNRIC.TabIndex = 7
        Me.txtNRIC.TabStop = False
        '
        'lblNRIC
        '
        Me.lblNRIC.AutoSize = True
        Me.lblNRIC.Location = New System.Drawing.Point(6, 216)
        Me.lblNRIC.Name = "lblNRIC"
        Me.lblNRIC.Size = New System.Drawing.Size(67, 13)
        Me.lblNRIC.TabIndex = 6
        Me.lblNRIC.Text = "New I/C No:"
        '
        'lblMemberPolicy_ID
        '
        Me.lblMemberPolicy_ID.AutoSize = True
        Me.lblMemberPolicy_ID.Location = New System.Drawing.Point(6, 616)
        Me.lblMemberPolicy_ID.Name = "lblMemberPolicy_ID"
        Me.lblMemberPolicy_ID.Size = New System.Drawing.Size(34, 13)
        Me.lblMemberPolicy_ID.TabIndex = 21
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.lblMemberPolicy_ID.Visible = False
        '
        'GrpBox_Payment_Details
        '
        Me.GrpBox_Payment_Details.Controls.Add(Me.cbGST)
        Me.GrpBox_Payment_Details.Controls.Add(Me.txtTotalPremium)
        Me.GrpBox_Payment_Details.Controls.Add(Me.lblTotalPremium)
        Me.GrpBox_Payment_Details.Controls.Add(Me.txtGST)
        Me.GrpBox_Payment_Details.Controls.Add(Me.lblGST)
        Me.GrpBox_Payment_Details.Controls.Add(Me.fowProposer_Race)
        Me.GrpBox_Payment_Details.Controls.Add(Me.dtpRequestedDate)
        Me.GrpBox_Payment_Details.Controls.Add(Me.lblRequestedDate)
        Me.GrpBox_Payment_Details.Controls.Add(Me.txtRenewal_Premium_New)
        Me.GrpBox_Payment_Details.Controls.Add(Me.lblRenewal_Premium_New)
        Me.GrpBox_Payment_Details.Controls.Add(Me.GrpBox_Payment_Details_Cash)
        Me.GrpBox_Payment_Details.Controls.Add(Me.GrpBox_Payment_Details_Cheque)
        Me.GrpBox_Payment_Details.Controls.Add(Me.GrpBox_Payment_Details_CreditCard)
        Me.GrpBox_Payment_Details.Controls.Add(Me.lblPayment_Method)
        Me.GrpBox_Payment_Details.Enabled = False
        Me.GrpBox_Payment_Details.Location = New System.Drawing.Point(9, 292)
        Me.GrpBox_Payment_Details.Name = "GrpBox_Payment_Details"
        Me.GrpBox_Payment_Details.Size = New System.Drawing.Size(694, 309)
        Me.GrpBox_Payment_Details.TabIndex = 20
        Me.GrpBox_Payment_Details.TabStop = False
        Me.GrpBox_Payment_Details.Text = "Payment Details"
        '
        'fowProposer_Race
        '
        Me.fowProposer_Race.Controls.Add(Me.rdCash)
        Me.fowProposer_Race.Controls.Add(Me.rdCheque)
        Me.fowProposer_Race.Controls.Add(Me.rdCC)
        Me.fowProposer_Race.Location = New System.Drawing.Point(122, 51)
        Me.fowProposer_Race.Name = "fowProposer_Race"
        Me.fowProposer_Race.Size = New System.Drawing.Size(227, 23)
        Me.fowProposer_Race.TabIndex = 18
        '
        'rdCash
        '
        Me.rdCash.AutoSize = True
        Me.rdCash.Location = New System.Drawing.Point(3, 3)
        Me.rdCash.Name = "rdCash"
        Me.rdCash.Size = New System.Drawing.Size(49, 17)
        Me.rdCash.TabIndex = 0
        Me.rdCash.TabStop = True
        Me.rdCash.Text = "Cash"
        Me.rdCash.UseVisualStyleBackColor = True
        '
        'rdCheque
        '
        Me.rdCheque.AutoSize = True
        Me.rdCheque.Location = New System.Drawing.Point(58, 3)
        Me.rdCheque.Name = "rdCheque"
        Me.rdCheque.Size = New System.Drawing.Size(62, 17)
        Me.rdCheque.TabIndex = 1
        Me.rdCheque.TabStop = True
        Me.rdCheque.Text = "Cheque"
        Me.rdCheque.UseVisualStyleBackColor = True
        '
        'rdCC
        '
        Me.rdCC.AutoSize = True
        Me.rdCC.Location = New System.Drawing.Point(126, 3)
        Me.rdCC.Name = "rdCC"
        Me.rdCC.Size = New System.Drawing.Size(77, 17)
        Me.rdCC.TabIndex = 2
        Me.rdCC.TabStop = True
        Me.rdCC.Text = "Credit Card"
        Me.rdCC.UseVisualStyleBackColor = True
        '
        'dtpRequestedDate
        '
        Me.dtpRequestedDate.Location = New System.Drawing.Point(125, 25)
        Me.dtpRequestedDate.Name = "dtpRequestedDate"
        Me.dtpRequestedDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpRequestedDate.TabIndex = 1
        '
        'lblRequestedDate
        '
        Me.lblRequestedDate.AutoSize = True
        Me.lblRequestedDate.Location = New System.Drawing.Point(14, 29)
        Me.lblRequestedDate.Name = "lblRequestedDate"
        Me.lblRequestedDate.Size = New System.Drawing.Size(76, 13)
        Me.lblRequestedDate.TabIndex = 0
        Me.lblRequestedDate.Text = "Request Date:"
        '
        'txtRenewal_Premium_New
        '
        Me.txtRenewal_Premium_New.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRenewal_Premium_New.Location = New System.Drawing.Point(523, 24)
        Me.txtRenewal_Premium_New.MaxLength = 6
        Me.txtRenewal_Premium_New.Name = "txtRenewal_Premium_New"
        Me.txtRenewal_Premium_New.ReadOnly = True
        Me.txtRenewal_Premium_New.Size = New System.Drawing.Size(75, 20)
        Me.txtRenewal_Premium_New.TabIndex = 6
        Me.txtRenewal_Premium_New.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRenewal_Premium_New
        '
        Me.lblRenewal_Premium_New.AutoSize = True
        Me.lblRenewal_Premium_New.Location = New System.Drawing.Point(405, 27)
        Me.lblRenewal_Premium_New.Name = "lblRenewal_Premium_New"
        Me.lblRenewal_Premium_New.Size = New System.Drawing.Size(81, 13)
        Me.lblRenewal_Premium_New.TabIndex = 5
        Me.lblRenewal_Premium_New.Text = "Premium (New):"
        '
        'GrpBox_Payment_Details_Cash
        '
        Me.GrpBox_Payment_Details_Cash.Controls.Add(Me.txtPayment_Cash_Receipt_IssuedBy)
        Me.GrpBox_Payment_Details_Cash.Controls.Add(Me.lblPayment_Cash_Receipt_IssuedBy)
        Me.GrpBox_Payment_Details_Cash.Controls.Add(Me.txtPayment_Cash_Receipt_No)
        Me.GrpBox_Payment_Details_Cash.Controls.Add(Me.lblPayment_Cash_Receipt_No)
        Me.GrpBox_Payment_Details_Cash.Enabled = False
        Me.GrpBox_Payment_Details_Cash.Location = New System.Drawing.Point(9, 238)
        Me.GrpBox_Payment_Details_Cash.Name = "GrpBox_Payment_Details_Cash"
        Me.GrpBox_Payment_Details_Cash.Size = New System.Drawing.Size(679, 58)
        Me.GrpBox_Payment_Details_Cash.TabIndex = 9
        Me.GrpBox_Payment_Details_Cash.TabStop = False
        Me.GrpBox_Payment_Details_Cash.Text = "Cash"
        '
        'txtPayment_Cash_Receipt_IssuedBy
        '
        Me.txtPayment_Cash_Receipt_IssuedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPayment_Cash_Receipt_IssuedBy.Location = New System.Drawing.Point(279, 21)
        Me.txtPayment_Cash_Receipt_IssuedBy.MaxLength = 50
        Me.txtPayment_Cash_Receipt_IssuedBy.Name = "txtPayment_Cash_Receipt_IssuedBy"
        Me.txtPayment_Cash_Receipt_IssuedBy.Size = New System.Drawing.Size(241, 20)
        Me.txtPayment_Cash_Receipt_IssuedBy.TabIndex = 3
        '
        'lblPayment_Cash_Receipt_IssuedBy
        '
        Me.lblPayment_Cash_Receipt_IssuedBy.AutoSize = True
        Me.lblPayment_Cash_Receipt_IssuedBy.Location = New System.Drawing.Point(217, 25)
        Me.lblPayment_Cash_Receipt_IssuedBy.Name = "lblPayment_Cash_Receipt_IssuedBy"
        Me.lblPayment_Cash_Receipt_IssuedBy.Size = New System.Drawing.Size(56, 13)
        Me.lblPayment_Cash_Receipt_IssuedBy.TabIndex = 2
        Me.lblPayment_Cash_Receipt_IssuedBy.Text = "Issued By:"
        '
        'txtPayment_Cash_Receipt_No
        '
        Me.txtPayment_Cash_Receipt_No.Location = New System.Drawing.Point(88, 21)
        Me.txtPayment_Cash_Receipt_No.MaxLength = 50
        Me.txtPayment_Cash_Receipt_No.Name = "txtPayment_Cash_Receipt_No"
        Me.txtPayment_Cash_Receipt_No.Size = New System.Drawing.Size(123, 20)
        Me.txtPayment_Cash_Receipt_No.TabIndex = 1
        '
        'lblPayment_Cash_Receipt_No
        '
        Me.lblPayment_Cash_Receipt_No.AutoSize = True
        Me.lblPayment_Cash_Receipt_No.Location = New System.Drawing.Point(18, 25)
        Me.lblPayment_Cash_Receipt_No.Name = "lblPayment_Cash_Receipt_No"
        Me.lblPayment_Cash_Receipt_No.Size = New System.Drawing.Size(64, 13)
        Me.lblPayment_Cash_Receipt_No.TabIndex = 0
        Me.lblPayment_Cash_Receipt_No.Text = "Receipt No:"
        '
        'GrpBox_Payment_Details_Cheque
        '
        Me.GrpBox_Payment_Details_Cheque.Controls.Add(Me.txtPayment_Cheque_Receipt_No)
        Me.GrpBox_Payment_Details_Cheque.Controls.Add(Me.lblPayment_Cheque_Receipt_No)
        Me.GrpBox_Payment_Details_Cheque.Controls.Add(Me.txtPayment_Cheque_No)
        Me.GrpBox_Payment_Details_Cheque.Controls.Add(Me.lblPayment_Cheque_No)
        Me.GrpBox_Payment_Details_Cheque.Enabled = False
        Me.GrpBox_Payment_Details_Cheque.Location = New System.Drawing.Point(9, 178)
        Me.GrpBox_Payment_Details_Cheque.Name = "GrpBox_Payment_Details_Cheque"
        Me.GrpBox_Payment_Details_Cheque.Size = New System.Drawing.Size(679, 54)
        Me.GrpBox_Payment_Details_Cheque.TabIndex = 8
        Me.GrpBox_Payment_Details_Cheque.TabStop = False
        Me.GrpBox_Payment_Details_Cheque.Text = "Cheque"
        '
        'txtPayment_Cheque_Receipt_No
        '
        Me.txtPayment_Cheque_Receipt_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPayment_Cheque_Receipt_No.Location = New System.Drawing.Point(424, 20)
        Me.txtPayment_Cheque_Receipt_No.MaxLength = 10
        Me.txtPayment_Cheque_Receipt_No.Name = "txtPayment_Cheque_Receipt_No"
        Me.txtPayment_Cheque_Receipt_No.Size = New System.Drawing.Size(70, 20)
        Me.txtPayment_Cheque_Receipt_No.TabIndex = 3
        '
        'lblPayment_Cheque_Receipt_No
        '
        Me.lblPayment_Cheque_Receipt_No.AutoSize = True
        Me.lblPayment_Cheque_Receipt_No.Location = New System.Drawing.Point(354, 24)
        Me.lblPayment_Cheque_Receipt_No.Name = "lblPayment_Cheque_Receipt_No"
        Me.lblPayment_Cheque_Receipt_No.Size = New System.Drawing.Size(64, 13)
        Me.lblPayment_Cheque_Receipt_No.TabIndex = 2
        Me.lblPayment_Cheque_Receipt_No.Text = "Receipt No:"
        '
        'txtPayment_Cheque_No
        '
        Me.txtPayment_Cheque_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPayment_Cheque_No.Location = New System.Drawing.Point(88, 21)
        Me.txtPayment_Cheque_No.MaxLength = 50
        Me.txtPayment_Cheque_No.Name = "txtPayment_Cheque_No"
        Me.txtPayment_Cheque_No.Size = New System.Drawing.Size(215, 20)
        Me.txtPayment_Cheque_No.TabIndex = 1
        '
        'lblPayment_Cheque_No
        '
        Me.lblPayment_Cheque_No.AutoSize = True
        Me.lblPayment_Cheque_No.Location = New System.Drawing.Point(18, 25)
        Me.lblPayment_Cheque_No.Name = "lblPayment_Cheque_No"
        Me.lblPayment_Cheque_No.Size = New System.Drawing.Size(64, 13)
        Me.lblPayment_Cheque_No.TabIndex = 0
        Me.lblPayment_Cheque_No.Text = "Cheque No:"
        '
        'GrpBox_Payment_Details_CreditCard
        '
        Me.GrpBox_Payment_Details_CreditCard.Controls.Add(Me.txtPayment_CreditCard_Inv_No)
        Me.GrpBox_Payment_Details_CreditCard.Controls.Add(Me.lblPayment_CreditCard_Inv_No)
        Me.GrpBox_Payment_Details_CreditCard.Controls.Add(Me.txtPayment_CreditCard_BatchNo)
        Me.GrpBox_Payment_Details_CreditCard.Controls.Add(Me.lblPayment_CreditCard_BatchNo)
        Me.GrpBox_Payment_Details_CreditCard.Controls.Add(Me.txtPayment_CreditCard_ApprCode)
        Me.GrpBox_Payment_Details_CreditCard.Controls.Add(Me.lblPayment_CreditCard_ApprCode)
        Me.GrpBox_Payment_Details_CreditCard.Enabled = False
        Me.GrpBox_Payment_Details_CreditCard.Location = New System.Drawing.Point(9, 117)
        Me.GrpBox_Payment_Details_CreditCard.Name = "GrpBox_Payment_Details_CreditCard"
        Me.GrpBox_Payment_Details_CreditCard.Size = New System.Drawing.Size(679, 55)
        Me.GrpBox_Payment_Details_CreditCard.TabIndex = 7
        Me.GrpBox_Payment_Details_CreditCard.TabStop = False
        Me.GrpBox_Payment_Details_CreditCard.Text = "Credit Card"
        '
        'txtPayment_CreditCard_Inv_No
        '
        Me.txtPayment_CreditCard_Inv_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPayment_CreditCard_Inv_No.Location = New System.Drawing.Point(595, 20)
        Me.txtPayment_CreditCard_Inv_No.MaxLength = 10
        Me.txtPayment_CreditCard_Inv_No.Name = "txtPayment_CreditCard_Inv_No"
        Me.txtPayment_CreditCard_Inv_No.Size = New System.Drawing.Size(70, 20)
        Me.txtPayment_CreditCard_Inv_No.TabIndex = 5
        '
        'lblPayment_CreditCard_Inv_No
        '
        Me.lblPayment_CreditCard_Inv_No.AutoSize = True
        Me.lblPayment_CreditCard_Inv_No.Location = New System.Drawing.Point(527, 24)
        Me.lblPayment_CreditCard_Inv_No.Name = "lblPayment_CreditCard_Inv_No"
        Me.lblPayment_CreditCard_Inv_No.Size = New System.Drawing.Size(62, 13)
        Me.lblPayment_CreditCard_Inv_No.TabIndex = 4
        Me.lblPayment_CreditCard_Inv_No.Text = "Invoice No:"
        '
        'txtPayment_CreditCard_BatchNo
        '
        Me.txtPayment_CreditCard_BatchNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPayment_CreditCard_BatchNo.Location = New System.Drawing.Point(88, 20)
        Me.txtPayment_CreditCard_BatchNo.MaxLength = 50
        Me.txtPayment_CreditCard_BatchNo.Name = "txtPayment_CreditCard_BatchNo"
        Me.txtPayment_CreditCard_BatchNo.Size = New System.Drawing.Size(215, 20)
        Me.txtPayment_CreditCard_BatchNo.TabIndex = 1
        '
        'lblPayment_CreditCard_BatchNo
        '
        Me.lblPayment_CreditCard_BatchNo.AutoSize = True
        Me.lblPayment_CreditCard_BatchNo.Location = New System.Drawing.Point(18, 24)
        Me.lblPayment_CreditCard_BatchNo.Name = "lblPayment_CreditCard_BatchNo"
        Me.lblPayment_CreditCard_BatchNo.Size = New System.Drawing.Size(55, 13)
        Me.lblPayment_CreditCard_BatchNo.TabIndex = 0
        Me.lblPayment_CreditCard_BatchNo.Text = "Batch No:"
        '
        'txtPayment_CreditCard_ApprCode
        '
        Me.txtPayment_CreditCard_ApprCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPayment_CreditCard_ApprCode.Location = New System.Drawing.Point(424, 20)
        Me.txtPayment_CreditCard_ApprCode.MaxLength = 10
        Me.txtPayment_CreditCard_ApprCode.Name = "txtPayment_CreditCard_ApprCode"
        Me.txtPayment_CreditCard_ApprCode.Size = New System.Drawing.Size(70, 20)
        Me.txtPayment_CreditCard_ApprCode.TabIndex = 3
        '
        'lblPayment_CreditCard_ApprCode
        '
        Me.lblPayment_CreditCard_ApprCode.AutoSize = True
        Me.lblPayment_CreditCard_ApprCode.Location = New System.Drawing.Point(338, 24)
        Me.lblPayment_CreditCard_ApprCode.Name = "lblPayment_CreditCard_ApprCode"
        Me.lblPayment_CreditCard_ApprCode.Size = New System.Drawing.Size(80, 13)
        Me.lblPayment_CreditCard_ApprCode.TabIndex = 2
        Me.lblPayment_CreditCard_ApprCode.Text = "Approval Code:"
        '
        'lblPayment_Method
        '
        Me.lblPayment_Method.AutoSize = True
        Me.lblPayment_Method.Location = New System.Drawing.Point(14, 55)
        Me.lblPayment_Method.Name = "lblPayment_Method"
        Me.lblPayment_Method.Size = New System.Drawing.Size(102, 13)
        Me.lblPayment_Method.TabIndex = 2
        Me.lblPayment_Method.Tag = ""
        Me.lblPayment_Method.Text = "Method of Payment:"
        '
        'txtAge
        '
        Me.txtAge.Location = New System.Drawing.Point(481, 212)
        Me.txtAge.MaxLength = 3
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ReadOnly = True
        Me.txtAge.Size = New System.Drawing.Size(42, 20)
        Me.txtAge.TabIndex = 11
        Me.txtAge.TabStop = False
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Location = New System.Drawing.Point(446, 216)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(29, 13)
        Me.lblAge.TabIndex = 10
        Me.lblAge.Text = "Age:"
        '
        'txtPolicy_EffectiveDate
        '
        Me.txtPolicy_EffectiveDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicy_EffectiveDate.Location = New System.Drawing.Point(134, 264)
        Me.txtPolicy_EffectiveDate.Name = "txtPolicy_EffectiveDate"
        Me.txtPolicy_EffectiveDate.ReadOnly = True
        Me.txtPolicy_EffectiveDate.Size = New System.Drawing.Size(75, 20)
        Me.txtPolicy_EffectiveDate.TabIndex = 17
        Me.txtPolicy_EffectiveDate.TabStop = False
        '
        'lblPolicy_EffectiveDate
        '
        Me.lblPolicy_EffectiveDate.AutoSize = True
        Me.lblPolicy_EffectiveDate.Location = New System.Drawing.Point(6, 268)
        Me.lblPolicy_EffectiveDate.Name = "lblPolicy_EffectiveDate"
        Me.lblPolicy_EffectiveDate.Size = New System.Drawing.Size(94, 13)
        Me.lblPolicy_EffectiveDate.TabIndex = 16
        Me.lblPolicy_EffectiveDate.Text = "1st Payment Date:"
        '
        'txtDOB
        '
        Me.txtDOB.Location = New System.Drawing.Point(327, 212)
        Me.txtDOB.MaxLength = 3
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.ReadOnly = True
        Me.txtDOB.Size = New System.Drawing.Size(75, 20)
        Me.txtDOB.TabIndex = 9
        Me.txtDOB.TabStop = False
        '
        'lblDOB
        '
        Me.lblDOB.AutoSize = True
        Me.lblDOB.Location = New System.Drawing.Point(252, 216)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(69, 13)
        Me.lblDOB.TabIndex = 8
        Me.lblDOB.Text = "Date of Birth:"
        '
        'btnPrint_YearlyLetter
        '
        Me.btnPrint_YearlyLetter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint_YearlyLetter.AutoSize = True
        Me.btnPrint_YearlyLetter.Enabled = False
        Me.btnPrint_YearlyLetter.Location = New System.Drawing.Point(421, 607)
        Me.btnPrint_YearlyLetter.Name = "btnPrint_YearlyLetter"
        Me.btnPrint_YearlyLetter.Size = New System.Drawing.Size(139, 23)
        Me.btnPrint_YearlyLetter.TabIndex = 23
        Me.btnPrint_YearlyLetter.Text = "Print Yearly Letter"
        Me.btnPrint_YearlyLetter.UseVisualStyleBackColor = True
        '
        'txtGST
        '
        Me.txtGST.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGST.Location = New System.Drawing.Point(523, 48)
        Me.txtGST.MaxLength = 6
        Me.txtGST.Name = "txtGST"
        Me.txtGST.ReadOnly = True
        Me.txtGST.Size = New System.Drawing.Size(75, 20)
        Me.txtGST.TabIndex = 20
        Me.txtGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGST
        '
        Me.lblGST.AutoSize = True
        Me.lblGST.Location = New System.Drawing.Point(405, 51)
        Me.lblGST.Name = "lblGST"
        Me.lblGST.Size = New System.Drawing.Size(52, 13)
        Me.lblGST.TabIndex = 19
        Me.lblGST.Text = "GST 6% :"
        '
        'txtTotalPremium
        '
        Me.txtTotalPremium.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPremium.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPremium.Location = New System.Drawing.Point(523, 95)
        Me.txtTotalPremium.MaxLength = 6
        Me.txtTotalPremium.Name = "txtTotalPremium"
        Me.txtTotalPremium.ReadOnly = True
        Me.txtTotalPremium.Size = New System.Drawing.Size(75, 20)
        Me.txtTotalPremium.TabIndex = 22
        Me.txtTotalPremium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalPremium
        '
        Me.lblTotalPremium.AutoSize = True
        Me.lblTotalPremium.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPremium.Location = New System.Drawing.Point(405, 98)
        Me.lblTotalPremium.Name = "lblTotalPremium"
        Me.lblTotalPremium.Size = New System.Drawing.Size(95, 13)
        Me.lblTotalPremium.TabIndex = 21
        Me.lblTotalPremium.Text = "Total Premium :"
        '
        'cbGST
        '
        Me.cbGST.AutoSize = True
        Me.cbGST.Checked = True
        Me.cbGST.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbGST.Location = New System.Drawing.Point(463, 51)
        Me.cbGST.Name = "cbGST"
        Me.cbGST.Size = New System.Drawing.Size(15, 14)
        Me.cbGST.TabIndex = 23
        Me.cbGST.UseVisualStyleBackColor = True
        '
        'dlgPremium_Renewal
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(718, 645)
        Me.Controls.Add(Me.btnPrint_YearlyLetter)
        Me.Controls.Add(Me.txtDOB)
        Me.Controls.Add(Me.lblDOB)
        Me.Controls.Add(Me.txtPolicy_EffectiveDate)
        Me.Controls.Add(Me.lblPolicy_EffectiveDate)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.GrpBox_Payment_Details)
        Me.Controls.Add(Me.lblMemberPolicy_ID)
        Me.Controls.Add(Me.txtRenewal_Premium)
        Me.Controls.Add(Me.lblRenewal_Premium)
        Me.Controls.Add(Me.txtPolicy_ExpiryDate)
        Me.Controls.Add(Me.lblPolicy_ExpiryDate)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtL2_Plan_Code)
        Me.Controls.Add(Me.lblL2_Plan_Code)
        Me.Controls.Add(Me.txtFileNo)
        Me.Controls.Add(Me.lblFileNo)
        Me.Controls.Add(Me.txtNRIC)
        Me.Controls.Add(Me.lblNRIC)
        Me.Controls.Add(Me.dgvPolicies)
        Me.Controls.Add(Me.tolForm)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "dlgPremium_Renewal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Premium - Yearly Renewal"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvPolicies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpBox_Payment_Details.ResumeLayout(False)
        Me.GrpBox_Payment_Details.PerformLayout()
        Me.fowProposer_Race.ResumeLayout(False)
        Me.fowProposer_Race.PerformLayout()
        Me.GrpBox_Payment_Details_Cash.ResumeLayout(False)
        Me.GrpBox_Payment_Details_Cash.PerformLayout()
        Me.GrpBox_Payment_Details_Cheque.ResumeLayout(False)
        Me.GrpBox_Payment_Details_Cheque.PerformLayout()
        Me.GrpBox_Payment_Details_CreditCard.ResumeLayout(False)
        Me.GrpBox_Payment_Details_CreditCard.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Filter As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsb_Filter_Param As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsb_Filter_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvPolicies As System.Windows.Forms.DataGridView
    Friend WithEvents txtRenewal_Premium As System.Windows.Forms.TextBox
    Friend WithEvents lblRenewal_Premium As System.Windows.Forms.Label
    Friend WithEvents txtPolicy_ExpiryDate As System.Windows.Forms.TextBox
    Friend WithEvents lblPolicy_ExpiryDate As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtL2_Plan_Code As System.Windows.Forms.TextBox
    Friend WithEvents lblL2_Plan_Code As System.Windows.Forms.Label
    Friend WithEvents txtFileNo As System.Windows.Forms.TextBox
    Friend WithEvents lblFileNo As System.Windows.Forms.Label
    Friend WithEvents txtNRIC As System.Windows.Forms.TextBox
    Friend WithEvents lblNRIC As System.Windows.Forms.Label
    Friend WithEvents lblMemberPolicy_ID As System.Windows.Forms.Label
    Friend WithEvents GrpBox_Payment_Details As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBox_Payment_Details_Cash As System.Windows.Forms.GroupBox
    Friend WithEvents txtPayment_Cash_Receipt_IssuedBy As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cash_Receipt_IssuedBy As System.Windows.Forms.Label
    Friend WithEvents txtPayment_Cash_Receipt_No As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cash_Receipt_No As System.Windows.Forms.Label
    Friend WithEvents GrpBox_Payment_Details_Cheque As System.Windows.Forms.GroupBox
    Friend WithEvents txtPayment_Cheque_No As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cheque_No As System.Windows.Forms.Label
    Friend WithEvents GrpBox_Payment_Details_CreditCard As System.Windows.Forms.GroupBox
    Friend WithEvents txtPayment_CreditCard_BatchNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_CreditCard_BatchNo As System.Windows.Forms.Label
    Friend WithEvents txtPayment_CreditCard_ApprCode As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Method As System.Windows.Forms.Label
    Friend WithEvents lblPayment_CreditCard_ApprCode As System.Windows.Forms.Label
    Friend WithEvents txtRenewal_Premium_New As System.Windows.Forms.TextBox
    Friend WithEvents lblRenewal_Premium_New As System.Windows.Forms.Label
    Friend WithEvents lblRequestedDate As System.Windows.Forms.Label
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents txtPolicy_EffectiveDate As System.Windows.Forms.TextBox
    Friend WithEvents lblPolicy_EffectiveDate As System.Windows.Forms.Label
    Friend WithEvents txtDOB As System.Windows.Forms.TextBox
    Friend WithEvents lblDOB As System.Windows.Forms.Label
    Friend WithEvents txtPayment_Cheque_Receipt_No As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cheque_Receipt_No As System.Windows.Forms.Label
    Friend WithEvents txtPayment_CreditCard_Inv_No As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_CreditCard_Inv_No As System.Windows.Forms.Label
    Friend WithEvents btnPrint_YearlyLetter As System.Windows.Forms.Button
    Friend WithEvents fowProposer_Race As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdCash As System.Windows.Forms.RadioButton
    Friend WithEvents rdCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rdCC As System.Windows.Forms.RadioButton
    Friend WithEvents txtGST As System.Windows.Forms.TextBox
    Friend WithEvents lblGST As System.Windows.Forms.Label
    Friend WithEvents txtTotalPremium As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalPremium As System.Windows.Forms.Label
    Friend WithEvents cbGST As System.Windows.Forms.CheckBox

End Class
