<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fbYearlyRenewal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fbYearlyRenewal))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblDate_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_From = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblDate_To = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_To = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.gbRenewalListing = New System.Windows.Forms.GroupBox
        Me.dgvClientIDDetails = New System.Windows.Forms.DataGridView
        Me.GrpBox_Payment_Details = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
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
        Me.colCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tsReport.SuspendLayout()
        Me.gbRenewalListing.SuspendLayout()
        CType(Me.dgvClientIDDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBox_Payment_Details.SuspendLayout()
        Me.fowProposer_Race.SuspendLayout()
        Me.GrpBox_Payment_Details_Cash.SuspendLayout()
        Me.GrpBox_Payment_Details_Cheque.SuspendLayout()
        Me.GrpBox_Payment_Details_CreditCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblDate_From, Me.tsReport_txtDate_From, Me.tsReport_lblDate_To, Me.tsReport_txtDate_To, Me.tsReport_Go, Me.tsReport_Div1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(731, 25)
        Me.tsReport.TabIndex = 2
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblDate_From
        '
        Me.tsReport_lblDate_From.Name = "tsReport_lblDate_From"
        Me.tsReport_lblDate_From.Size = New System.Drawing.Size(183, 22)
        Me.tsReport_lblDate_From.Text = "Renewal Date - From (dd/mm/yyyy):"
        '
        'tsReport_txtDate_From
        '
        Me.tsReport_txtDate_From.MaxLength = 10
        Me.tsReport_txtDate_From.Name = "tsReport_txtDate_From"
        Me.tsReport_txtDate_From.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_lblDate_To
        '
        Me.tsReport_lblDate_To.Name = "tsReport_lblDate_To"
        Me.tsReport_lblDate_To.Size = New System.Drawing.Size(171, 22)
        Me.tsReport_lblDate_To.Text = "Renewal Date - To (dd/mm/yyyy):"
        '
        'tsReport_txtDate_To
        '
        Me.tsReport_txtDate_To.MaxLength = 10
        Me.tsReport_txtDate_To.Name = "tsReport_txtDate_To"
        Me.tsReport_txtDate_To.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_Go
        '
        Me.tsReport_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsReport_Go.Image = CType(resources.GetObject("tsReport_Go.Image"), System.Drawing.Image)
        Me.tsReport_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Go.Name = "tsReport_Go"
        Me.tsReport_Go.Size = New System.Drawing.Size(24, 22)
        Me.tsReport_Go.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'gbRenewalListing
        '
        Me.gbRenewalListing.Controls.Add(Me.dgvClientIDDetails)
        Me.gbRenewalListing.Location = New System.Drawing.Point(0, 28)
        Me.gbRenewalListing.Name = "gbRenewalListing"
        Me.gbRenewalListing.Size = New System.Drawing.Size(729, 249)
        Me.gbRenewalListing.TabIndex = 3
        Me.gbRenewalListing.TabStop = False
        Me.gbRenewalListing.Text = "Yearly renewal listing"
        '
        'dgvClientIDDetails
        '
        Me.dgvClientIDDetails.AllowUserToAddRows = False
        Me.dgvClientIDDetails.AllowUserToDeleteRows = False
        Me.dgvClientIDDetails.AllowUserToOrderColumns = True
        Me.dgvClientIDDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClientIDDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheck})
        Me.dgvClientIDDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvClientIDDetails.MultiSelect = False
        Me.dgvClientIDDetails.Name = "dgvClientIDDetails"
        Me.dgvClientIDDetails.Size = New System.Drawing.Size(716, 230)
        Me.dgvClientIDDetails.TabIndex = 10
        Me.dgvClientIDDetails.UseWaitCursor = True
        '
        'GrpBox_Payment_Details
        '
        Me.GrpBox_Payment_Details.Controls.Add(Me.btnCancel)
        Me.GrpBox_Payment_Details.Controls.Add(Me.btnSubmit)
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
        Me.GrpBox_Payment_Details.Location = New System.Drawing.Point(3, 283)
        Me.GrpBox_Payment_Details.Name = "GrpBox_Payment_Details"
        Me.GrpBox_Payment_Details.Size = New System.Drawing.Size(726, 321)
        Me.GrpBox_Payment_Details.TabIndex = 21
        Me.GrpBox_Payment_Details.TabStop = False
        Me.GrpBox_Payment_Details.Text = "Payment Details"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(343, 282)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(252, 282)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 19
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'fowProposer_Race
        '
        Me.fowProposer_Race.Controls.Add(Me.rdCash)
        Me.fowProposer_Race.Controls.Add(Me.rdCheque)
        Me.fowProposer_Race.Controls.Add(Me.rdCC)
        Me.fowProposer_Race.Location = New System.Drawing.Point(123, 51)
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
        Me.dtpRequestedDate.Location = New System.Drawing.Point(126, 25)
        Me.dtpRequestedDate.Name = "dtpRequestedDate"
        Me.dtpRequestedDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpRequestedDate.TabIndex = 1
        '
        'lblRequestedDate
        '
        Me.lblRequestedDate.AutoSize = True
        Me.lblRequestedDate.Location = New System.Drawing.Point(15, 29)
        Me.lblRequestedDate.Name = "lblRequestedDate"
        Me.lblRequestedDate.Size = New System.Drawing.Size(76, 13)
        Me.lblRequestedDate.TabIndex = 0
        Me.lblRequestedDate.Text = "Request Date:"
        '
        'txtRenewal_Premium_New
        '
        Me.txtRenewal_Premium_New.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRenewal_Premium_New.Location = New System.Drawing.Point(473, 51)
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
        Me.lblRenewal_Premium_New.Location = New System.Drawing.Point(386, 55)
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
        Me.GrpBox_Payment_Details_Cash.Location = New System.Drawing.Point(10, 201)
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
        Me.GrpBox_Payment_Details_Cheque.Location = New System.Drawing.Point(10, 141)
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
        Me.GrpBox_Payment_Details_CreditCard.Location = New System.Drawing.Point(10, 80)
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
        Me.lblPayment_Method.Location = New System.Drawing.Point(15, 55)
        Me.lblPayment_Method.Name = "lblPayment_Method"
        Me.lblPayment_Method.Size = New System.Drawing.Size(102, 13)
        Me.lblPayment_Method.TabIndex = 2
        Me.lblPayment_Method.Tag = ""
        Me.lblPayment_Method.Text = "Method of Payment:"
        '
        'colCheck
        '
        Me.colCheck.FalseValue = "F"
        Me.colCheck.HeaderText = "(Tick)"
        Me.colCheck.IndeterminateValue = ""
        Me.colCheck.Name = "colCheck"
        Me.colCheck.TrueValue = "T"
        Me.colCheck.Width = 50
        '
        'fbYearlyRenewal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 606)
        Me.Controls.Add(Me.GrpBox_Payment_Details)
        Me.Controls.Add(Me.gbRenewalListing)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "fbYearlyRenewal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bulk Yearly Renewal"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.gbRenewalListing.ResumeLayout(False)
        CType(Me.dgvClientIDDetails, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblDate_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDate_From As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_lblDate_To As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDate_To As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbRenewalListing As System.Windows.Forms.GroupBox
    Friend WithEvents dgvClientIDDetails As System.Windows.Forms.DataGridView
    Friend WithEvents GrpBox_Payment_Details As System.Windows.Forms.GroupBox
    Friend WithEvents fowProposer_Race As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdCash As System.Windows.Forms.RadioButton
    Friend WithEvents rdCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rdCC As System.Windows.Forms.RadioButton
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRequestedDate As System.Windows.Forms.Label
    Friend WithEvents txtRenewal_Premium_New As System.Windows.Forms.TextBox
    Friend WithEvents lblRenewal_Premium_New As System.Windows.Forms.Label
    Friend WithEvents GrpBox_Payment_Details_Cash As System.Windows.Forms.GroupBox
    Friend WithEvents txtPayment_Cash_Receipt_IssuedBy As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cash_Receipt_IssuedBy As System.Windows.Forms.Label
    Friend WithEvents txtPayment_Cash_Receipt_No As System.Windows.Forms.TextBox
    Friend WithEvents lblPayment_Cash_Receipt_No As System.Windows.Forms.Label
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
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents colCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
