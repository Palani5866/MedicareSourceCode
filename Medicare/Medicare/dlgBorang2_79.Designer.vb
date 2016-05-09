<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgBorang2_79
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.lblNRIC = New System.Windows.Forms.Label
        Me.txtNRIC = New System.Windows.Forms.TextBox
        Me.txtAngkasa_FileNo = New System.Windows.Forms.TextBox
        Me.lblAngkasa_FileNo = New System.Windows.Forms.Label
        Me.txtDeduction_Month = New System.Windows.Forms.TextBox
        Me.lblDeduction_Month = New System.Windows.Forms.Label
        Me.txtDeduction_Code = New System.Windows.Forms.TextBox
        Me.lblDeduction_Code = New System.Windows.Forms.Label
        Me.txtDeduction_Amount = New System.Windows.Forms.TextBox
        Me.lblDeduction_Amount = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtBatch_No = New System.Windows.Forms.TextBox
        Me.lblBatch_No = New System.Windows.Forms.Label
        Me.txtReceiving_Month = New System.Windows.Forms.TextBox
        Me.lblReceiving_Month = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdiRT_SuspendAccount = New System.Windows.Forms.RadioButton
        Me.rdiRT_StampDuty = New System.Windows.Forms.RadioButton
        Me.rdiRT_GE_DeductionCode = New System.Windows.Forms.RadioButton
        Me.rdiRT_CR = New System.Windows.Forms.RadioButton
        Me.rdiRT_CR_Prior01012009 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cb0599 = New System.Windows.Forms.CheckBox
        Me.chkGT_Wrong_RequestedAmount = New System.Windows.Forms.CheckBox
        Me.chkGT_Reprocess = New System.Windows.Forms.CheckBox
        Me.chkGT_Old_DeductionCode_Old_Premium = New System.Windows.Forms.CheckBox
        Me.chkGT_Wrong_DeductionAmount = New System.Windows.Forms.CheckBox
        Me.chkGT_Wrong_DeductionCode = New System.Windows.Forms.CheckBox
        Me.txtPolicy_EffectiveDate = New System.Windows.Forms.TextBox
        Me.lblPolicy_EffectiveDate = New System.Windows.Forms.Label
        Me.txtPolicy_CancellationDate = New System.Windows.Forms.TextBox
        Me.lblPolicy_CancellationDate = New System.Windows.Forms.Label
        Me.lblDeduction_Code_OldValue = New System.Windows.Forms.Label
        Me.lblRecord_Status = New System.Windows.Forms.Label
        Me.lblMemberPolicy_ID = New System.Windows.Forms.Label
        Me.txtRequested_Amount = New System.Windows.Forms.TextBox
        Me.lblRequested_Amount = New System.Windows.Forms.Label
        Me.lblRequested_Amount_OldValue = New System.Windows.Forms.Label
        Me.cbIgnore = New System.Windows.Forms.CheckBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(436, 487)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 24
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
        'lblNRIC
        '
        Me.lblNRIC.AutoSize = True
        Me.lblNRIC.Location = New System.Drawing.Point(10, 16)
        Me.lblNRIC.Name = "lblNRIC"
        Me.lblNRIC.Size = New System.Drawing.Size(67, 13)
        Me.lblNRIC.TabIndex = 0
        Me.lblNRIC.Text = "New I/C No:"
        '
        'txtNRIC
        '
        Me.txtNRIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNRIC.Location = New System.Drawing.Point(128, 12)
        Me.txtNRIC.MaxLength = 13
        Me.txtNRIC.Name = "txtNRIC"
        Me.txtNRIC.ReadOnly = True
        Me.txtNRIC.Size = New System.Drawing.Size(109, 20)
        Me.txtNRIC.TabIndex = 1
        Me.txtNRIC.TabStop = False
        '
        'txtAngkasa_FileNo
        '
        Me.txtAngkasa_FileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAngkasa_FileNo.Location = New System.Drawing.Point(128, 38)
        Me.txtAngkasa_FileNo.MaxLength = 20
        Me.txtAngkasa_FileNo.Name = "txtAngkasa_FileNo"
        Me.txtAngkasa_FileNo.ReadOnly = True
        Me.txtAngkasa_FileNo.Size = New System.Drawing.Size(135, 20)
        Me.txtAngkasa_FileNo.TabIndex = 3
        Me.txtAngkasa_FileNo.TabStop = False
        '
        'lblAngkasa_FileNo
        '
        Me.lblAngkasa_FileNo.AutoSize = True
        Me.lblAngkasa_FileNo.Location = New System.Drawing.Point(10, 43)
        Me.lblAngkasa_FileNo.Name = "lblAngkasa_FileNo"
        Me.lblAngkasa_FileNo.Size = New System.Drawing.Size(85, 13)
        Me.lblAngkasa_FileNo.TabIndex = 2
        Me.lblAngkasa_FileNo.Text = "Angkasa File No"
        '
        'txtDeduction_Month
        '
        Me.txtDeduction_Month.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeduction_Month.Location = New System.Drawing.Point(313, 118)
        Me.txtDeduction_Month.MaxLength = 6
        Me.txtDeduction_Month.Name = "txtDeduction_Month"
        Me.txtDeduction_Month.ReadOnly = True
        Me.txtDeduction_Month.Size = New System.Drawing.Size(75, 20)
        Me.txtDeduction_Month.TabIndex = 15
        Me.txtDeduction_Month.TabStop = False
        '
        'lblDeduction_Month
        '
        Me.lblDeduction_Month.AutoSize = True
        Me.lblDeduction_Month.Location = New System.Drawing.Point(220, 122)
        Me.lblDeduction_Month.Name = "lblDeduction_Month"
        Me.lblDeduction_Month.Size = New System.Drawing.Size(92, 13)
        Me.lblDeduction_Month.TabIndex = 14
        Me.lblDeduction_Month.Text = "Deduction Month:"
        '
        'txtDeduction_Code
        '
        Me.txtDeduction_Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeduction_Code.Location = New System.Drawing.Point(128, 66)
        Me.txtDeduction_Code.MaxLength = 4
        Me.txtDeduction_Code.Name = "txtDeduction_Code"
        Me.txtDeduction_Code.ReadOnly = True
        Me.txtDeduction_Code.Size = New System.Drawing.Size(61, 20)
        Me.txtDeduction_Code.TabIndex = 5
        Me.txtDeduction_Code.TabStop = False
        '
        'lblDeduction_Code
        '
        Me.lblDeduction_Code.AutoSize = True
        Me.lblDeduction_Code.Location = New System.Drawing.Point(10, 70)
        Me.lblDeduction_Code.Name = "lblDeduction_Code"
        Me.lblDeduction_Code.Size = New System.Drawing.Size(87, 13)
        Me.lblDeduction_Code.TabIndex = 4
        Me.lblDeduction_Code.Text = "Deduction Code:"
        '
        'txtDeduction_Amount
        '
        Me.txtDeduction_Amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeduction_Amount.Location = New System.Drawing.Point(310, 66)
        Me.txtDeduction_Amount.MaxLength = 6
        Me.txtDeduction_Amount.Name = "txtDeduction_Amount"
        Me.txtDeduction_Amount.ReadOnly = True
        Me.txtDeduction_Amount.Size = New System.Drawing.Size(75, 20)
        Me.txtDeduction_Amount.TabIndex = 7
        Me.txtDeduction_Amount.TabStop = False
        Me.txtDeduction_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDeduction_Amount
        '
        Me.lblDeduction_Amount.AutoSize = True
        Me.lblDeduction_Amount.Location = New System.Drawing.Point(209, 70)
        Me.lblDeduction_Amount.Name = "lblDeduction_Amount"
        Me.lblDeduction_Amount.Size = New System.Drawing.Size(98, 13)
        Me.lblDeduction_Amount.TabIndex = 6
        Me.lblDeduction_Amount.Text = "Deduction Amount:"
        '
        'txtName
        '
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(128, 92)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(445, 20)
        Me.txtName.TabIndex = 11
        Me.txtName.TabStop = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(10, 96)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(112, 13)
        Me.lblName.TabIndex = 10
        Me.lblName.Text = "Full Name As in NRIC:"
        '
        'txtBatch_No
        '
        Me.txtBatch_No.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBatch_No.Location = New System.Drawing.Point(128, 118)
        Me.txtBatch_No.MaxLength = 5
        Me.txtBatch_No.Name = "txtBatch_No"
        Me.txtBatch_No.ReadOnly = True
        Me.txtBatch_No.Size = New System.Drawing.Size(75, 20)
        Me.txtBatch_No.TabIndex = 13
        Me.txtBatch_No.TabStop = False
        '
        'lblBatch_No
        '
        Me.lblBatch_No.AutoSize = True
        Me.lblBatch_No.Location = New System.Drawing.Point(10, 122)
        Me.lblBatch_No.Name = "lblBatch_No"
        Me.lblBatch_No.Size = New System.Drawing.Size(55, 13)
        Me.lblBatch_No.TabIndex = 12
        Me.lblBatch_No.Text = "Batch No:"
        '
        'txtReceiving_Month
        '
        Me.txtReceiving_Month.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceiving_Month.Location = New System.Drawing.Point(498, 118)
        Me.txtReceiving_Month.MaxLength = 6
        Me.txtReceiving_Month.Name = "txtReceiving_Month"
        Me.txtReceiving_Month.ReadOnly = True
        Me.txtReceiving_Month.Size = New System.Drawing.Size(75, 20)
        Me.txtReceiving_Month.TabIndex = 17
        Me.txtReceiving_Month.TabStop = False
        '
        'lblReceiving_Month
        '
        Me.lblReceiving_Month.AutoSize = True
        Me.lblReceiving_Month.Location = New System.Drawing.Point(405, 122)
        Me.lblReceiving_Month.Name = "lblReceiving_Month"
        Me.lblReceiving_Month.Size = New System.Drawing.Size(91, 13)
        Me.lblReceiving_Month.TabIndex = 16
        Me.lblReceiving_Month.Text = "Receiving Month:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdiRT_SuspendAccount)
        Me.GroupBox1.Controls.Add(Me.rdiRT_StampDuty)
        Me.GroupBox1.Controls.Add(Me.rdiRT_GE_DeductionCode)
        Me.GroupBox1.Controls.Add(Me.rdiRT_CR)
        Me.GroupBox1.Controls.Add(Me.rdiRT_CR_Prior01012009)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(13, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(565, 144)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Action: Transfer to Permanent Suspend Account"
        '
        'rdiRT_SuspendAccount
        '
        Me.rdiRT_SuspendAccount.AutoSize = True
        Me.rdiRT_SuspendAccount.Location = New System.Drawing.Point(13, 88)
        Me.rdiRT_SuspendAccount.Name = "rdiRT_SuspendAccount"
        Me.rdiRT_SuspendAccount.Size = New System.Drawing.Size(162, 17)
        Me.rdiRT_SuspendAccount.TabIndex = 3
        Me.rdiRT_SuspendAccount.Text = "Angkasa's Suspend Account"
        Me.rdiRT_SuspendAccount.UseVisualStyleBackColor = True
        '
        'rdiRT_StampDuty
        '
        Me.rdiRT_StampDuty.AutoSize = True
        Me.rdiRT_StampDuty.Location = New System.Drawing.Point(13, 65)
        Me.rdiRT_StampDuty.Name = "rdiRT_StampDuty"
        Me.rdiRT_StampDuty.Size = New System.Drawing.Size(194, 17)
        Me.rdiRT_StampDuty.TabIndex = 2
        Me.rdiRT_StampDuty.Text = "Stamp Duty (Prior 1st January 2008)"
        Me.rdiRT_StampDuty.UseVisualStyleBackColor = True
        '
        'rdiRT_GE_DeductionCode
        '
        Me.rdiRT_GE_DeductionCode.AutoSize = True
        Me.rdiRT_GE_DeductionCode.Location = New System.Drawing.Point(13, 42)
        Me.rdiRT_GE_DeductionCode.Name = "rdiRT_GE_DeductionCode"
        Me.rdiRT_GE_DeductionCode.Size = New System.Drawing.Size(120, 17)
        Me.rdiRT_GE_DeductionCode.TabIndex = 1
        Me.rdiRT_GE_DeductionCode.Text = "GE Deduction Code"
        Me.rdiRT_GE_DeductionCode.UseVisualStyleBackColor = True
        '
        'rdiRT_CR
        '
        Me.rdiRT_CR.AutoSize = True
        Me.rdiRT_CR.Location = New System.Drawing.Point(13, 111)
        Me.rdiRT_CR.Name = "rdiRT_CR"
        Me.rdiRT_CR.Size = New System.Drawing.Size(312, 17)
        Me.rdiRT_CR.TabIndex = 4
        Me.rdiRT_CR.Text = "Cancelled / Retired policy but monthly deduction still goes on"
        Me.rdiRT_CR.UseVisualStyleBackColor = True
        '
        'rdiRT_CR_Prior01012009
        '
        Me.rdiRT_CR_Prior01012009.AutoSize = True
        Me.rdiRT_CR_Prior01012009.Location = New System.Drawing.Point(13, 19)
        Me.rdiRT_CR_Prior01012009.Name = "rdiRT_CR_Prior01012009"
        Me.rdiRT_CR_Prior01012009.Size = New System.Drawing.Size(254, 17)
        Me.rdiRT_CR_Prior01012009.TabIndex = 0
        Me.rdiRT_CR_Prior01012009.Text = "Cancelled / Retired policy prior 1st January 2009"
        Me.rdiRT_CR_Prior01012009.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtRemarks)
        Me.GroupBox2.Controls.Add(Me.lblRemarks)
        Me.GroupBox2.Controls.Add(Me.cbIgnore)
        Me.GroupBox2.Controls.Add(Me.cb0599)
        Me.GroupBox2.Controls.Add(Me.chkGT_Wrong_RequestedAmount)
        Me.GroupBox2.Controls.Add(Me.chkGT_Reprocess)
        Me.GroupBox2.Controls.Add(Me.chkGT_Old_DeductionCode_Old_Premium)
        Me.GroupBox2.Controls.Add(Me.chkGT_Wrong_DeductionAmount)
        Me.GroupBox2.Controls.Add(Me.chkGT_Wrong_DeductionCode)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Green
        Me.GroupBox2.Location = New System.Drawing.Point(13, 320)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(566, 161)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Action: Transfer to Policy Holder's Account"
        '
        'cb0599
        '
        Me.cb0599.AutoSize = True
        Me.cb0599.Location = New System.Drawing.Point(300, 65)
        Me.cb0599.Name = "cb0599"
        Me.cb0599.Size = New System.Drawing.Size(50, 17)
        Me.cb0599.TabIndex = 5
        Me.cb0599.Text = "0599"
        Me.cb0599.UseVisualStyleBackColor = True
        '
        'chkGT_Wrong_RequestedAmount
        '
        Me.chkGT_Wrong_RequestedAmount.AutoSize = True
        Me.chkGT_Wrong_RequestedAmount.Location = New System.Drawing.Point(14, 65)
        Me.chkGT_Wrong_RequestedAmount.Name = "chkGT_Wrong_RequestedAmount"
        Me.chkGT_Wrong_RequestedAmount.Size = New System.Drawing.Size(152, 17)
        Me.chkGT_Wrong_RequestedAmount.TabIndex = 4
        Me.chkGT_Wrong_RequestedAmount.TabStop = False
        Me.chkGT_Wrong_RequestedAmount.Text = "Wrong Requested Amount"
        Me.chkGT_Wrong_RequestedAmount.UseVisualStyleBackColor = True
        '
        'chkGT_Reprocess
        '
        Me.chkGT_Reprocess.AutoSize = True
        Me.chkGT_Reprocess.Location = New System.Drawing.Point(301, 42)
        Me.chkGT_Reprocess.Name = "chkGT_Reprocess"
        Me.chkGT_Reprocess.Size = New System.Drawing.Size(250, 17)
        Me.chkGT_Reprocess.TabIndex = 3
        Me.chkGT_Reprocess.TabStop = False
        Me.chkGT_Reprocess.Text = "Reprocessing after updating of Member's Policy"
        Me.chkGT_Reprocess.UseVisualStyleBackColor = True
        '
        'chkGT_Old_DeductionCode_Old_Premium
        '
        Me.chkGT_Old_DeductionCode_Old_Premium.AutoSize = True
        Me.chkGT_Old_DeductionCode_Old_Premium.Location = New System.Drawing.Point(301, 19)
        Me.chkGT_Old_DeductionCode_Old_Premium.Name = "chkGT_Old_DeductionCode_Old_Premium"
        Me.chkGT_Old_DeductionCode_Old_Premium.Size = New System.Drawing.Size(235, 17)
        Me.chkGT_Old_DeductionCode_Old_Premium.TabIndex = 2
        Me.chkGT_Old_DeductionCode_Old_Premium.TabStop = False
        Me.chkGT_Old_DeductionCode_Old_Premium.Text = "Old Deduction Code, Old Deduction Amount"
        Me.chkGT_Old_DeductionCode_Old_Premium.UseVisualStyleBackColor = True
        '
        'chkGT_Wrong_DeductionAmount
        '
        Me.chkGT_Wrong_DeductionAmount.AutoSize = True
        Me.chkGT_Wrong_DeductionAmount.Location = New System.Drawing.Point(14, 42)
        Me.chkGT_Wrong_DeductionAmount.Name = "chkGT_Wrong_DeductionAmount"
        Me.chkGT_Wrong_DeductionAmount.Size = New System.Drawing.Size(149, 17)
        Me.chkGT_Wrong_DeductionAmount.TabIndex = 1
        Me.chkGT_Wrong_DeductionAmount.TabStop = False
        Me.chkGT_Wrong_DeductionAmount.Text = "Wrong Deduction Amount"
        Me.chkGT_Wrong_DeductionAmount.UseVisualStyleBackColor = True
        '
        'chkGT_Wrong_DeductionCode
        '
        Me.chkGT_Wrong_DeductionCode.AutoSize = True
        Me.chkGT_Wrong_DeductionCode.Location = New System.Drawing.Point(14, 19)
        Me.chkGT_Wrong_DeductionCode.Name = "chkGT_Wrong_DeductionCode"
        Me.chkGT_Wrong_DeductionCode.Size = New System.Drawing.Size(86, 17)
        Me.chkGT_Wrong_DeductionCode.TabIndex = 0
        Me.chkGT_Wrong_DeductionCode.TabStop = False
        Me.chkGT_Wrong_DeductionCode.Text = "Wrong Code"
        Me.chkGT_Wrong_DeductionCode.UseVisualStyleBackColor = True
        '
        'txtPolicy_EffectiveDate
        '
        Me.txtPolicy_EffectiveDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicy_EffectiveDate.Location = New System.Drawing.Point(128, 144)
        Me.txtPolicy_EffectiveDate.Name = "txtPolicy_EffectiveDate"
        Me.txtPolicy_EffectiveDate.ReadOnly = True
        Me.txtPolicy_EffectiveDate.Size = New System.Drawing.Size(75, 20)
        Me.txtPolicy_EffectiveDate.TabIndex = 19
        Me.txtPolicy_EffectiveDate.TabStop = False
        '
        'lblPolicy_EffectiveDate
        '
        Me.lblPolicy_EffectiveDate.AutoSize = True
        Me.lblPolicy_EffectiveDate.Location = New System.Drawing.Point(10, 148)
        Me.lblPolicy_EffectiveDate.Name = "lblPolicy_EffectiveDate"
        Me.lblPolicy_EffectiveDate.Size = New System.Drawing.Size(78, 13)
        Me.lblPolicy_EffectiveDate.TabIndex = 18
        Me.lblPolicy_EffectiveDate.Text = "Effective Date:"
        '
        'txtPolicy_CancellationDate
        '
        Me.txtPolicy_CancellationDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicy_CancellationDate.Location = New System.Drawing.Point(313, 144)
        Me.txtPolicy_CancellationDate.Name = "txtPolicy_CancellationDate"
        Me.txtPolicy_CancellationDate.ReadOnly = True
        Me.txtPolicy_CancellationDate.Size = New System.Drawing.Size(140, 20)
        Me.txtPolicy_CancellationDate.TabIndex = 21
        Me.txtPolicy_CancellationDate.TabStop = False
        '
        'lblPolicy_CancellationDate
        '
        Me.lblPolicy_CancellationDate.AutoSize = True
        Me.lblPolicy_CancellationDate.Location = New System.Drawing.Point(220, 148)
        Me.lblPolicy_CancellationDate.Name = "lblPolicy_CancellationDate"
        Me.lblPolicy_CancellationDate.Size = New System.Drawing.Size(94, 13)
        Me.lblPolicy_CancellationDate.TabIndex = 20
        Me.lblPolicy_CancellationDate.Text = "Cancellation Date:"
        '
        'lblDeduction_Code_OldValue
        '
        Me.lblDeduction_Code_OldValue.AutoSize = True
        Me.lblDeduction_Code_OldValue.ForeColor = System.Drawing.Color.Red
        Me.lblDeduction_Code_OldValue.Location = New System.Drawing.Point(96, 69)
        Me.lblDeduction_Code_OldValue.Name = "lblDeduction_Code_OldValue"
        Me.lblDeduction_Code_OldValue.Size = New System.Drawing.Size(31, 13)
        Me.lblDeduction_Code_OldValue.TabIndex = 27
        Me.lblDeduction_Code_OldValue.Text = "0000"
        Me.lblDeduction_Code_OldValue.Visible = False
        '
        'lblRecord_Status
        '
        Me.lblRecord_Status.AutoSize = True
        Me.lblRecord_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecord_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecord_Status.Location = New System.Drawing.Point(394, 15)
        Me.lblRecord_Status.Name = "lblRecord_Status"
        Me.lblRecord_Status.Size = New System.Drawing.Size(41, 15)
        Me.lblRecord_Status.TabIndex = 25
        Me.lblRecord_Status.Text = "Label3"
        '
        'lblMemberPolicy_ID
        '
        Me.lblMemberPolicy_ID.AutoSize = True
        Me.lblMemberPolicy_ID.Location = New System.Drawing.Point(382, 487)
        Me.lblMemberPolicy_ID.Name = "lblMemberPolicy_ID"
        Me.lblMemberPolicy_ID.Size = New System.Drawing.Size(34, 13)
        Me.lblMemberPolicy_ID.TabIndex = 26
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.lblMemberPolicy_ID.Visible = False
        '
        'txtRequested_Amount
        '
        Me.txtRequested_Amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequested_Amount.Location = New System.Drawing.Point(498, 66)
        Me.txtRequested_Amount.MaxLength = 6
        Me.txtRequested_Amount.Name = "txtRequested_Amount"
        Me.txtRequested_Amount.ReadOnly = True
        Me.txtRequested_Amount.Size = New System.Drawing.Size(75, 20)
        Me.txtRequested_Amount.TabIndex = 9
        Me.txtRequested_Amount.TabStop = False
        Me.txtRequested_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRequested_Amount
        '
        Me.lblRequested_Amount.AutoSize = True
        Me.lblRequested_Amount.Location = New System.Drawing.Point(391, 70)
        Me.lblRequested_Amount.Name = "lblRequested_Amount"
        Me.lblRequested_Amount.Size = New System.Drawing.Size(101, 13)
        Me.lblRequested_Amount.TabIndex = 8
        Me.lblRequested_Amount.Text = "Requested Amount:"
        '
        'lblRequested_Amount_OldValue
        '
        Me.lblRequested_Amount_OldValue.AutoSize = True
        Me.lblRequested_Amount_OldValue.ForeColor = System.Drawing.Color.Red
        Me.lblRequested_Amount_OldValue.Location = New System.Drawing.Point(495, 50)
        Me.lblRequested_Amount_OldValue.Name = "lblRequested_Amount_OldValue"
        Me.lblRequested_Amount_OldValue.Size = New System.Drawing.Size(31, 13)
        Me.lblRequested_Amount_OldValue.TabIndex = 28
        Me.lblRequested_Amount_OldValue.Text = "0000"
        Me.lblRequested_Amount_OldValue.Visible = False
        '
        'cbIgnore
        '
        Me.cbIgnore.AutoSize = True
        Me.cbIgnore.Location = New System.Drawing.Point(372, 65)
        Me.cbIgnore.Name = "cbIgnore"
        Me.cbIgnore.Size = New System.Drawing.Size(56, 17)
        Me.cbIgnore.TabIndex = 6
        Me.cbIgnore.Text = "Ignore"
        Me.cbIgnore.UseVisualStyleBackColor = True
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(10, 95)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(55, 13)
        Me.lblRemarks.TabIndex = 7
        Me.lblRemarks.Text = "Remarks :"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(66, 95)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(485, 51)
        Me.txtRemarks.TabIndex = 8
        '
        'dlgBorang2_79
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(594, 528)
        Me.Controls.Add(Me.lblRequested_Amount_OldValue)
        Me.Controls.Add(Me.txtRequested_Amount)
        Me.Controls.Add(Me.lblRequested_Amount)
        Me.Controls.Add(Me.lblMemberPolicy_ID)
        Me.Controls.Add(Me.lblRecord_Status)
        Me.Controls.Add(Me.lblDeduction_Code_OldValue)
        Me.Controls.Add(Me.txtPolicy_CancellationDate)
        Me.Controls.Add(Me.lblPolicy_CancellationDate)
        Me.Controls.Add(Me.txtPolicy_EffectiveDate)
        Me.Controls.Add(Me.lblPolicy_EffectiveDate)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtReceiving_Month)
        Me.Controls.Add(Me.lblReceiving_Month)
        Me.Controls.Add(Me.txtBatch_No)
        Me.Controls.Add(Me.lblBatch_No)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtDeduction_Amount)
        Me.Controls.Add(Me.lblDeduction_Amount)
        Me.Controls.Add(Me.txtDeduction_Code)
        Me.Controls.Add(Me.lblDeduction_Code)
        Me.Controls.Add(Me.txtDeduction_Month)
        Me.Controls.Add(Me.lblDeduction_Month)
        Me.Controls.Add(Me.txtAngkasa_FileNo)
        Me.Controls.Add(Me.lblAngkasa_FileNo)
        Me.Controls.Add(Me.txtNRIC)
        Me.Controls.Add(Me.lblNRIC)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgBorang2_79"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Borang 2/79"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblNRIC As System.Windows.Forms.Label
    Friend WithEvents txtNRIC As System.Windows.Forms.TextBox
    Friend WithEvents txtAngkasa_FileNo As System.Windows.Forms.TextBox
    Friend WithEvents lblAngkasa_FileNo As System.Windows.Forms.Label
    Friend WithEvents txtDeduction_Month As System.Windows.Forms.TextBox
    Friend WithEvents lblDeduction_Month As System.Windows.Forms.Label
    Friend WithEvents txtDeduction_Code As System.Windows.Forms.TextBox
    Friend WithEvents lblDeduction_Code As System.Windows.Forms.Label
    Friend WithEvents txtDeduction_Amount As System.Windows.Forms.TextBox
    Friend WithEvents lblDeduction_Amount As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtBatch_No As System.Windows.Forms.TextBox
    Friend WithEvents lblBatch_No As System.Windows.Forms.Label
    Friend WithEvents txtReceiving_Month As System.Windows.Forms.TextBox
    Friend WithEvents lblReceiving_Month As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdiRT_CR_Prior01012009 As System.Windows.Forms.RadioButton
    Friend WithEvents rdiRT_CR As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkGT_Wrong_DeductionAmount As System.Windows.Forms.CheckBox
    Friend WithEvents chkGT_Wrong_DeductionCode As System.Windows.Forms.CheckBox
    Friend WithEvents rdiRT_GE_DeductionCode As System.Windows.Forms.RadioButton
    Friend WithEvents txtPolicy_EffectiveDate As System.Windows.Forms.TextBox
    Friend WithEvents lblPolicy_EffectiveDate As System.Windows.Forms.Label
    Friend WithEvents txtPolicy_CancellationDate As System.Windows.Forms.TextBox
    Friend WithEvents lblPolicy_CancellationDate As System.Windows.Forms.Label
    Friend WithEvents lblDeduction_Code_OldValue As System.Windows.Forms.Label
    Friend WithEvents lblRecord_Status As System.Windows.Forms.Label
    Friend WithEvents lblMemberPolicy_ID As System.Windows.Forms.Label
    Friend WithEvents chkGT_Old_DeductionCode_Old_Premium As System.Windows.Forms.CheckBox
    Friend WithEvents rdiRT_StampDuty As System.Windows.Forms.RadioButton
    Friend WithEvents chkGT_Reprocess As System.Windows.Forms.CheckBox
    Friend WithEvents rdiRT_SuspendAccount As System.Windows.Forms.RadioButton
    Friend WithEvents chkGT_Wrong_RequestedAmount As System.Windows.Forms.CheckBox
    Friend WithEvents txtRequested_Amount As System.Windows.Forms.TextBox
    Friend WithEvents lblRequested_Amount As System.Windows.Forms.Label
    Friend WithEvents lblRequested_Amount_OldValue As System.Windows.Forms.Label
    Friend WithEvents cb0599 As System.Windows.Forms.CheckBox
    Friend WithEvents cbIgnore As System.Windows.Forms.CheckBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label

End Class
