<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class afPolicy
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
        Me.lblAdmin = New System.Windows.Forms.Label
        Me.lblPolicyID = New System.Windows.Forms.Label
        Me.lblMemberID = New System.Windows.Forms.Label
        Me.gbPolicyDetails = New System.Windows.Forms.GroupBox
        Me.gbYearly = New System.Windows.Forms.GroupBox
        Me.GrpBox_Payment_Details = New System.Windows.Forms.GroupBox
        Me.dtpRequestedDate = New System.Windows.Forms.DateTimePicker
        Me.lblRequestedDate = New System.Windows.Forms.Label
        Me.txtRenewal_Premium_New = New System.Windows.Forms.TextBox
        Me.lblRenewal_Premium_New = New System.Windows.Forms.Label
        Me.GrpBox_Payment_Details_Cash = New System.Windows.Forms.GroupBox
        Me.txtPayment_Cash_Receipt_IssuedBy = New System.Windows.Forms.TextBox
        Me.lblPayment_Cash_Receipt_IssuedBy = New System.Windows.Forms.Label
        Me.txtPayment_Cash_Receipt_No = New System.Windows.Forms.TextBox
        Me.lblPayment_Cash_Receipt_No = New System.Windows.Forms.Label
        Me.btnPayment_Method = New System.Windows.Forms.Button
        Me.txtPayment_Method = New System.Windows.Forms.TextBox
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
        Me.gbPolicy = New System.Windows.Forms.GroupBox
        Me.lblEDate1 = New System.Windows.Forms.Label
        Me.lblEDate = New System.Windows.Forms.Label
        Me.dtpEDate = New System.Windows.Forms.DateTimePicker
        Me.txtAgentCode = New System.Windows.Forms.TextBox
        Me.lblCDate = New System.Windows.Forms.Label
        Me.lblAgentCode1 = New System.Windows.Forms.Label
        Me.lblCDate1 = New System.Windows.Forms.Label
        Me.lblAgentCode = New System.Windows.Forms.Label
        Me.dtpCDate = New System.Windows.Forms.DateTimePicker
        Me.txtAFileNo = New System.Windows.Forms.TextBox
        Me.lblAFileNo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.lblDeductionCode = New System.Windows.Forms.Label
        Me.lblRenewalID = New System.Windows.Forms.Label
        Me.lblPCODE = New System.Windows.Forms.Label
        Me.gbPolicyDetails.SuspendLayout()
        Me.gbYearly.SuspendLayout()
        Me.GrpBox_Payment_Details.SuspendLayout()
        Me.GrpBox_Payment_Details_Cash.SuspendLayout()
        Me.GrpBox_Payment_Details_Cheque.SuspendLayout()
        Me.GrpBox_Payment_Details_CreditCard.SuspendLayout()
        Me.gbPolicy.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.Location = New System.Drawing.Point(223, 573)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(10, 13)
        Me.lblAdmin.TabIndex = 0
        Me.lblAdmin.Text = "."
        Me.lblAdmin.Visible = False
        '
        'lblPolicyID
        '
        Me.lblPolicyID.AutoSize = True
        Me.lblPolicyID.Location = New System.Drawing.Point(109, 573)
        Me.lblPolicyID.Name = "lblPolicyID"
        Me.lblPolicyID.Size = New System.Drawing.Size(46, 13)
        Me.lblPolicyID.TabIndex = 1
        Me.lblPolicyID.Text = "PolicyID"
        Me.lblPolicyID.Visible = False
        '
        'lblMemberID
        '
        Me.lblMemberID.AutoSize = True
        Me.lblMemberID.Location = New System.Drawing.Point(161, 573)
        Me.lblMemberID.Name = "lblMemberID"
        Me.lblMemberID.Size = New System.Drawing.Size(56, 13)
        Me.lblMemberID.TabIndex = 2
        Me.lblMemberID.Text = "MemberID"
        Me.lblMemberID.Visible = False
        '
        'gbPolicyDetails
        '
        Me.gbPolicyDetails.Controls.Add(Me.gbYearly)
        Me.gbPolicyDetails.Controls.Add(Me.gbPolicy)
        Me.gbPolicyDetails.Controls.Add(Me.btnCancel)
        Me.gbPolicyDetails.Controls.Add(Me.btnUpdate)
        Me.gbPolicyDetails.Location = New System.Drawing.Point(23, 25)
        Me.gbPolicyDetails.Name = "gbPolicyDetails"
        Me.gbPolicyDetails.Size = New System.Drawing.Size(817, 545)
        Me.gbPolicyDetails.TabIndex = 3
        Me.gbPolicyDetails.TabStop = False
        Me.gbPolicyDetails.Text = "Policy Details"
        '
        'gbYearly
        '
        Me.gbYearly.Controls.Add(Me.GrpBox_Payment_Details)
        Me.gbYearly.Location = New System.Drawing.Point(24, 190)
        Me.gbYearly.Name = "gbYearly"
        Me.gbYearly.Size = New System.Drawing.Size(744, 304)
        Me.gbYearly.TabIndex = 87
        Me.gbYearly.TabStop = False
        Me.gbYearly.Text = "Yearly Renewal Details"
        '
        'GrpBox_Payment_Details
        '
        Me.GrpBox_Payment_Details.Controls.Add(Me.dtpRequestedDate)
        Me.GrpBox_Payment_Details.Controls.Add(Me.lblRequestedDate)
        Me.GrpBox_Payment_Details.Controls.Add(Me.txtRenewal_Premium_New)
        Me.GrpBox_Payment_Details.Controls.Add(Me.lblRenewal_Premium_New)
        Me.GrpBox_Payment_Details.Controls.Add(Me.GrpBox_Payment_Details_Cash)
        Me.GrpBox_Payment_Details.Controls.Add(Me.btnPayment_Method)
        Me.GrpBox_Payment_Details.Controls.Add(Me.txtPayment_Method)
        Me.GrpBox_Payment_Details.Controls.Add(Me.GrpBox_Payment_Details_Cheque)
        Me.GrpBox_Payment_Details.Controls.Add(Me.GrpBox_Payment_Details_CreditCard)
        Me.GrpBox_Payment_Details.Controls.Add(Me.lblPayment_Method)
        Me.GrpBox_Payment_Details.Enabled = False
        Me.GrpBox_Payment_Details.Location = New System.Drawing.Point(16, 19)
        Me.GrpBox_Payment_Details.Name = "GrpBox_Payment_Details"
        Me.GrpBox_Payment_Details.Size = New System.Drawing.Size(694, 270)
        Me.GrpBox_Payment_Details.TabIndex = 22
        Me.GrpBox_Payment_Details.TabStop = False
        Me.GrpBox_Payment_Details.Text = "Payment Details"
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
        Me.txtRenewal_Premium_New.Location = New System.Drawing.Point(472, 51)
        Me.txtRenewal_Premium_New.MaxLength = 6
        Me.txtRenewal_Premium_New.Name = "txtRenewal_Premium_New"
        Me.txtRenewal_Premium_New.Size = New System.Drawing.Size(75, 20)
        Me.txtRenewal_Premium_New.TabIndex = 6
        Me.txtRenewal_Premium_New.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRenewal_Premium_New
        '
        Me.lblRenewal_Premium_New.AutoSize = True
        Me.lblRenewal_Premium_New.Location = New System.Drawing.Point(385, 55)
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
        Me.GrpBox_Payment_Details_Cash.Location = New System.Drawing.Point(9, 201)
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
        Me.txtPayment_Cash_Receipt_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPayment_Cash_Receipt_No.Location = New System.Drawing.Point(88, 21)
        Me.txtPayment_Cash_Receipt_No.MaxLength = 10
        Me.txtPayment_Cash_Receipt_No.Name = "txtPayment_Cash_Receipt_No"
        Me.txtPayment_Cash_Receipt_No.Size = New System.Drawing.Size(70, 20)
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
        'btnPayment_Method
        '
        Me.btnPayment_Method.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPayment_Method.Location = New System.Drawing.Point(336, 52)
        Me.btnPayment_Method.Name = "btnPayment_Method"
        Me.btnPayment_Method.Size = New System.Drawing.Size(25, 19)
        Me.btnPayment_Method.TabIndex = 4
        Me.btnPayment_Method.Text = "..."
        Me.btnPayment_Method.UseVisualStyleBackColor = True
        '
        'txtPayment_Method
        '
        Me.txtPayment_Method.Location = New System.Drawing.Point(122, 51)
        Me.txtPayment_Method.MaxLength = 10
        Me.txtPayment_Method.Name = "txtPayment_Method"
        Me.txtPayment_Method.ReadOnly = True
        Me.txtPayment_Method.Size = New System.Drawing.Size(208, 20)
        Me.txtPayment_Method.TabIndex = 3
        Me.txtPayment_Method.TabStop = False
        '
        'GrpBox_Payment_Details_Cheque
        '
        Me.GrpBox_Payment_Details_Cheque.Controls.Add(Me.txtPayment_Cheque_Receipt_No)
        Me.GrpBox_Payment_Details_Cheque.Controls.Add(Me.lblPayment_Cheque_Receipt_No)
        Me.GrpBox_Payment_Details_Cheque.Controls.Add(Me.txtPayment_Cheque_No)
        Me.GrpBox_Payment_Details_Cheque.Controls.Add(Me.lblPayment_Cheque_No)
        Me.GrpBox_Payment_Details_Cheque.Enabled = False
        Me.GrpBox_Payment_Details_Cheque.Location = New System.Drawing.Point(9, 141)
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
        Me.GrpBox_Payment_Details_CreditCard.Location = New System.Drawing.Point(9, 80)
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
        'gbPolicy
        '
        Me.gbPolicy.Controls.Add(Me.lblEDate1)
        Me.gbPolicy.Controls.Add(Me.lblEDate)
        Me.gbPolicy.Controls.Add(Me.dtpEDate)
        Me.gbPolicy.Controls.Add(Me.txtAgentCode)
        Me.gbPolicy.Controls.Add(Me.lblCDate)
        Me.gbPolicy.Controls.Add(Me.lblAgentCode1)
        Me.gbPolicy.Controls.Add(Me.lblCDate1)
        Me.gbPolicy.Controls.Add(Me.lblAgentCode)
        Me.gbPolicy.Controls.Add(Me.dtpCDate)
        Me.gbPolicy.Controls.Add(Me.txtAFileNo)
        Me.gbPolicy.Controls.Add(Me.lblAFileNo)
        Me.gbPolicy.Controls.Add(Me.Label1)
        Me.gbPolicy.Location = New System.Drawing.Point(182, 19)
        Me.gbPolicy.Name = "gbPolicy"
        Me.gbPolicy.Size = New System.Drawing.Size(480, 156)
        Me.gbPolicy.TabIndex = 86
        Me.gbPolicy.TabStop = False
        Me.gbPolicy.Text = "Policy Details"
        '
        'lblEDate1
        '
        Me.lblEDate1.AutoSize = True
        Me.lblEDate1.Location = New System.Drawing.Point(152, 33)
        Me.lblEDate1.Name = "lblEDate1"
        Me.lblEDate1.Size = New System.Drawing.Size(10, 13)
        Me.lblEDate1.TabIndex = 1
        Me.lblEDate1.Text = ":"
        '
        'lblEDate
        '
        Me.lblEDate.AutoSize = True
        Me.lblEDate.Location = New System.Drawing.Point(25, 33)
        Me.lblEDate.Name = "lblEDate"
        Me.lblEDate.Size = New System.Drawing.Size(71, 13)
        Me.lblEDate.TabIndex = 0
        Me.lblEDate.Text = "Effictive Date"
        '
        'dtpEDate
        '
        Me.dtpEDate.Location = New System.Drawing.Point(189, 29)
        Me.dtpEDate.Name = "dtpEDate"
        Me.dtpEDate.Size = New System.Drawing.Size(244, 20)
        Me.dtpEDate.TabIndex = 74
        '
        'txtAgentCode
        '
        Me.txtAgentCode.Location = New System.Drawing.Point(189, 113)
        Me.txtAgentCode.Name = "txtAgentCode"
        Me.txtAgentCode.Size = New System.Drawing.Size(244, 20)
        Me.txtAgentCode.TabIndex = 83
        '
        'lblCDate
        '
        Me.lblCDate.AutoSize = True
        Me.lblCDate.Location = New System.Drawing.Point(25, 61)
        Me.lblCDate.Name = "lblCDate"
        Me.lblCDate.Size = New System.Drawing.Size(91, 13)
        Me.lblCDate.TabIndex = 75
        Me.lblCDate.Text = "Cancellation Date"
        '
        'lblAgentCode1
        '
        Me.lblAgentCode1.AutoSize = True
        Me.lblAgentCode1.Location = New System.Drawing.Point(152, 113)
        Me.lblAgentCode1.Name = "lblAgentCode1"
        Me.lblAgentCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblAgentCode1.TabIndex = 82
        Me.lblAgentCode1.Text = ":"
        '
        'lblCDate1
        '
        Me.lblCDate1.AutoSize = True
        Me.lblCDate1.Location = New System.Drawing.Point(152, 61)
        Me.lblCDate1.Name = "lblCDate1"
        Me.lblCDate1.Size = New System.Drawing.Size(10, 13)
        Me.lblCDate1.TabIndex = 76
        Me.lblCDate1.Text = ":"
        '
        'lblAgentCode
        '
        Me.lblAgentCode.AutoSize = True
        Me.lblAgentCode.Location = New System.Drawing.Point(25, 113)
        Me.lblAgentCode.Name = "lblAgentCode"
        Me.lblAgentCode.Size = New System.Drawing.Size(63, 13)
        Me.lblAgentCode.TabIndex = 81
        Me.lblAgentCode.Text = "Agent Code"
        '
        'dtpCDate
        '
        Me.dtpCDate.Location = New System.Drawing.Point(189, 57)
        Me.dtpCDate.Name = "dtpCDate"
        Me.dtpCDate.Size = New System.Drawing.Size(244, 20)
        Me.dtpCDate.TabIndex = 77
        '
        'txtAFileNo
        '
        Me.txtAFileNo.Location = New System.Drawing.Point(189, 87)
        Me.txtAFileNo.Name = "txtAFileNo"
        Me.txtAFileNo.Size = New System.Drawing.Size(244, 20)
        Me.txtAFileNo.TabIndex = 80
        '
        'lblAFileNo
        '
        Me.lblAFileNo.AutoSize = True
        Me.lblAFileNo.Location = New System.Drawing.Point(25, 87)
        Me.lblAFileNo.Name = "lblAFileNo"
        Me.lblAFileNo.Size = New System.Drawing.Size(78, 13)
        Me.lblAFileNo.TabIndex = 78
        Me.lblAFileNo.Text = "Angkasa File #"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(152, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = ":"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(371, 508)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 85
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(273, 508)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 84
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lblDeductionCode
        '
        Me.lblDeductionCode.AutoSize = True
        Me.lblDeductionCode.Location = New System.Drawing.Point(299, 573)
        Me.lblDeductionCode.Name = "lblDeductionCode"
        Me.lblDeductionCode.Size = New System.Drawing.Size(81, 13)
        Me.lblDeductionCode.TabIndex = 4
        Me.lblDeductionCode.Text = "DeductionCode"
        Me.lblDeductionCode.Visible = False
        '
        'lblRenewalID
        '
        Me.lblRenewalID.AutoSize = True
        Me.lblRenewalID.Location = New System.Drawing.Point(396, 573)
        Me.lblRenewalID.Name = "lblRenewalID"
        Me.lblRenewalID.Size = New System.Drawing.Size(88, 13)
        Me.lblRenewalID.TabIndex = 5
        Me.lblRenewalID.Text = "PolicyRenewalID"
        Me.lblRenewalID.Visible = False
        '
        'lblPCODE
        '
        Me.lblPCODE.AutoSize = True
        Me.lblPCODE.Location = New System.Drawing.Point(536, 573)
        Me.lblPCODE.Name = "lblPCODE"
        Me.lblPCODE.Size = New System.Drawing.Size(44, 13)
        Me.lblPCODE.TabIndex = 6
        Me.lblPCODE.Text = "PCODE"
        Me.lblPCODE.Visible = False
        '
        'afPolicy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 595)
        Me.Controls.Add(Me.lblPCODE)
        Me.Controls.Add(Me.lblRenewalID)
        Me.Controls.Add(Me.lblDeductionCode)
        Me.Controls.Add(Me.gbPolicyDetails)
        Me.Controls.Add(Me.lblMemberID)
        Me.Controls.Add(Me.lblPolicyID)
        Me.Controls.Add(Me.lblAdmin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "afPolicy"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Policy Details"
        Me.gbPolicyDetails.ResumeLayout(False)
        Me.gbYearly.ResumeLayout(False)
        Me.GrpBox_Payment_Details.ResumeLayout(False)
        Me.GrpBox_Payment_Details.PerformLayout()
        Me.GrpBox_Payment_Details_Cash.ResumeLayout(False)
        Me.GrpBox_Payment_Details_Cash.PerformLayout()
        Me.GrpBox_Payment_Details_Cheque.ResumeLayout(False)
        Me.GrpBox_Payment_Details_Cheque.PerformLayout()
        Me.GrpBox_Payment_Details_CreditCard.ResumeLayout(False)
        Me.GrpBox_Payment_Details_CreditCard.PerformLayout()
        Me.gbPolicy.ResumeLayout(False)
        Me.gbPolicy.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAdmin As System.Windows.Forms.Label
    Friend WithEvents lblPolicyID As System.Windows.Forms.Label
    Friend WithEvents lblMemberID As System.Windows.Forms.Label
    Friend WithEvents gbPolicyDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lblEDate1 As System.Windows.Forms.Label
    Friend WithEvents lblEDate As System.Windows.Forms.Label
    Friend WithEvents dtpCDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCDate1 As System.Windows.Forms.Label
    Friend WithEvents lblCDate As System.Windows.Forms.Label
    Friend WithEvents dtpEDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAFileNo As System.Windows.Forms.Label
    Friend WithEvents txtAFileNo As System.Windows.Forms.TextBox
    Friend WithEvents txtAgentCode As System.Windows.Forms.TextBox
    Friend WithEvents lblAgentCode1 As System.Windows.Forms.Label
    Friend WithEvents lblAgentCode As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents gbPolicy As System.Windows.Forms.GroupBox
    Friend WithEvents gbYearly As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBox_Payment_Details As System.Windows.Forms.GroupBox
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRequestedDate As System.Windows.Forms.Label
    Friend WithEvents txtRenewal_Premium_New As System.Windows.Forms.TextBox
    Friend WithEvents lblRenewal_Premium_New As System.Windows.Forms.Label
    Friend WithEvents GrpBox_Payment_Details_Cash As System.Windows.Forms.GroupBox
    Friend WithEvents txtPayment_Cash_Receipt_IssuedBy As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cash_Receipt_IssuedBy As System.Windows.Forms.Label
    Friend WithEvents txtPayment_Cash_Receipt_No As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cash_Receipt_No As System.Windows.Forms.Label
    Friend WithEvents btnPayment_Method As System.Windows.Forms.Button
    Friend WithEvents txtPayment_Method As System.Windows.Forms.TextBox
    Friend WithEvents GrpBox_Payment_Details_Cheque As System.Windows.Forms.GroupBox
    Friend WithEvents txtPayment_Cheque_Receipt_No As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cheque_Receipt_No As System.Windows.Forms.Label
    Friend WithEvents txtPayment_Cheque_No As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cheque_No As System.Windows.Forms.Label
    Friend WithEvents GrpBox_Payment_Details_CreditCard As System.Windows.Forms.GroupBox
    Friend WithEvents txtPayment_CreditCard_Inv_No As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_CreditCard_Inv_No As System.Windows.Forms.Label
    Friend WithEvents txtPayment_CreditCard_BatchNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_CreditCard_BatchNo As System.Windows.Forms.Label
    Friend WithEvents txtPayment_CreditCard_ApprCode As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_CreditCard_ApprCode As System.Windows.Forms.Label
    Friend WithEvents lblPayment_Method As System.Windows.Forms.Label
    Friend WithEvents lblDeductionCode As System.Windows.Forms.Label
    Friend WithEvents lblRenewalID As System.Windows.Forms.Label
    Friend WithEvents lblPCODE As System.Windows.Forms.Label
End Class
