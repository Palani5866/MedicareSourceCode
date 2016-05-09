<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ffShortFall
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ffShortFall))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tslblTot = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.dgvShortfall = New System.Windows.Forms.DataGridView
        Me.lblPREMIUM = New System.Windows.Forms.Label
        Me.lblREFID = New System.Windows.Forms.Label
        Me.gbDecision = New System.Windows.Forms.GroupBox
        Me.dtpEffective_Date = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblRemark = New System.Windows.Forms.Label
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.cmbCancellation_Reason = New System.Windows.Forms.ComboBox
        Me.lblRequestedDate = New System.Windows.Forms.Label
        Me.lblCancellation_Reason = New System.Windows.Forms.Label
        Me.dtpPolicy_CancellationDate = New System.Windows.Forms.DateTimePicker
        Me.dtpRequestedDate = New System.Windows.Forms.DateTimePicker
        Me.lblPolicy_CancellationDate = New System.Windows.Forms.Label
        Me.lblRID = New System.Windows.Forms.Label
        Me.lblP1 = New System.Windows.Forms.Label
        Me.gbPolicyDetails = New System.Windows.Forms.GroupBox
        Me.dgvPolicyDetails = New System.Windows.Forms.DataGridView
        Me.lblID = New System.Windows.Forms.Label
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.REFID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASSIGN_TO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASSIGN_ON = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASSIGN_BY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IC_NEW = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FULL_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Birth_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PCODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PHOUSE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POFFICE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PMOBILE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NON_PAYMENT = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT_SHORT = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT_SHORT_NR = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT_SHORT_R = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT_SHORT_RECOVER = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT_BAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reason = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Action = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Submit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tolForm.SuspendLayout()
        CType(Me.dgvShortfall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDecision.SuspendLayout()
        Me.gbPolicyDetails.SuspendLayout()
        CType(Me.dgvPolicyDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblTot, Me.ToolStripSeparator1, Me.tsbExport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tolForm.Size = New System.Drawing.Size(1153, 25)
        Me.tolForm.TabIndex = 13
        Me.tolForm.Text = "ToolStrip1"
        '
        'tslblTot
        '
        Me.tslblTot.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.tslblTot.ForeColor = System.Drawing.Color.Blue
        Me.tslblTot.Name = "tslblTot"
        Me.tslblTot.Size = New System.Drawing.Size(84, 22)
        Me.tslblTot.Text = "Total Records"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbExport2Xcel
        '
        Me.tsbExport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbExport2Xcel.Image = CType(resources.GetObject("tsbExport2Xcel.Image"), System.Drawing.Image)
        Me.tsbExport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExport2Xcel.Name = "tsbExport2Xcel"
        Me.tsbExport2Xcel.Size = New System.Drawing.Size(87, 22)
        Me.tsbExport2Xcel.Text = "Export to Excel"
        Me.tsbExport2Xcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvShortfall
        '
        Me.dgvShortfall.AllowUserToAddRows = False
        Me.dgvShortfall.AllowUserToOrderColumns = True
        Me.dgvShortfall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortfall.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.REFID, Me.ASSIGN_TO, Me.ASSIGN_ON, Me.ASSIGN_BY, Me.IC_NEW, Me.FULL_NAME, Me.Birth_Date, Me.PCODE, Me.PTYPE, Me.FNO, Me.PHOUSE, Me.POFFICE, Me.PMOBILE, Me.EMAIL, Me.NON_PAYMENT, Me.TOT_SHORT, Me.TOT_SHORT_NR, Me.TOT_SHORT_R, Me.TOT_SHORT_RECOVER, Me.TOT_BAL, Me.Reason, Me.Action, Me.Remarks, Me.Submit})
        Me.dgvShortfall.Location = New System.Drawing.Point(12, 28)
        Me.dgvShortfall.Name = "dgvShortfall"
        Me.dgvShortfall.Size = New System.Drawing.Size(1138, 182)
        Me.dgvShortfall.TabIndex = 15
        '
        'lblPREMIUM
        '
        Me.lblPREMIUM.AutoSize = True
        Me.lblPREMIUM.Location = New System.Drawing.Point(966, 605)
        Me.lblPREMIUM.Name = "lblPREMIUM"
        Me.lblPREMIUM.Size = New System.Drawing.Size(58, 13)
        Me.lblPREMIUM.TabIndex = 19
        Me.lblPREMIUM.Text = "PREMIUM"
        Me.lblPREMIUM.Visible = False
        '
        'lblREFID
        '
        Me.lblREFID.AutoSize = True
        Me.lblREFID.Location = New System.Drawing.Point(921, 605)
        Me.lblREFID.Name = "lblREFID"
        Me.lblREFID.Size = New System.Drawing.Size(39, 13)
        Me.lblREFID.TabIndex = 18
        Me.lblREFID.Text = "REFID"
        Me.lblREFID.Visible = False
        '
        'gbDecision
        '
        Me.gbDecision.Controls.Add(Me.dtpEffective_Date)
        Me.gbDecision.Controls.Add(Me.Label1)
        Me.gbDecision.Controls.Add(Me.btnPrint)
        Me.gbDecision.Controls.Add(Me.btnCancel)
        Me.gbDecision.Controls.Add(Me.btnSubmit)
        Me.gbDecision.Controls.Add(Me.lblRemark)
        Me.gbDecision.Controls.Add(Me.txtRemark)
        Me.gbDecision.Controls.Add(Me.cmbCancellation_Reason)
        Me.gbDecision.Controls.Add(Me.lblRequestedDate)
        Me.gbDecision.Controls.Add(Me.lblCancellation_Reason)
        Me.gbDecision.Controls.Add(Me.dtpPolicy_CancellationDate)
        Me.gbDecision.Controls.Add(Me.dtpRequestedDate)
        Me.gbDecision.Controls.Add(Me.lblPolicy_CancellationDate)
        Me.gbDecision.Location = New System.Drawing.Point(264, 439)
        Me.gbDecision.Name = "gbDecision"
        Me.gbDecision.Size = New System.Drawing.Size(593, 206)
        Me.gbDecision.TabIndex = 17
        Me.gbDecision.TabStop = False
        Me.gbDecision.Text = "Decisions"
        '
        'dtpEffective_Date
        '
        Me.dtpEffective_Date.Location = New System.Drawing.Point(170, 142)
        Me.dtpEffective_Date.Name = "dtpEffective_Date"
        Me.dtpEffective_Date.Size = New System.Drawing.Size(200, 20)
        Me.dtpEffective_Date.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Effective Date:"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(180, 177)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 18
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(342, 177)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(261, 177)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 16
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblRemark
        '
        Me.lblRemark.AutoSize = True
        Me.lblRemark.Location = New System.Drawing.Point(25, 105)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(47, 13)
        Me.lblRemark.TabIndex = 14
        Me.lblRemark.Text = "Remark:"
        '
        'txtRemark
        '
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Location = New System.Drawing.Point(170, 101)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(393, 35)
        Me.txtRemark.TabIndex = 15
        '
        'cmbCancellation_Reason
        '
        Me.cmbCancellation_Reason.FormattingEnabled = True
        Me.cmbCancellation_Reason.Items.AddRange(New Object() {"User request to cancel", "Non-Payment", "Change to Yearly", "Angkasa Payment > 60%", "NO DEDUCTION FROM ANGKASA", "Non-Payment Cannot Contact", "Change to Angkasa / Others", "Incomplete Angkasa"})
        Me.cmbCancellation_Reason.Location = New System.Drawing.Point(170, 74)
        Me.cmbCancellation_Reason.Name = "cmbCancellation_Reason"
        Me.cmbCancellation_Reason.Size = New System.Drawing.Size(393, 21)
        Me.cmbCancellation_Reason.TabIndex = 13
        '
        'lblRequestedDate
        '
        Me.lblRequestedDate.AutoSize = True
        Me.lblRequestedDate.Location = New System.Drawing.Point(25, 26)
        Me.lblRequestedDate.Name = "lblRequestedDate"
        Me.lblRequestedDate.Size = New System.Drawing.Size(88, 13)
        Me.lblRequestedDate.TabIndex = 8
        Me.lblRequestedDate.Text = "Requested Date:"
        '
        'lblCancellation_Reason
        '
        Me.lblCancellation_Reason.AutoSize = True
        Me.lblCancellation_Reason.Location = New System.Drawing.Point(25, 78)
        Me.lblCancellation_Reason.Name = "lblCancellation_Reason"
        Me.lblCancellation_Reason.Size = New System.Drawing.Size(108, 13)
        Me.lblCancellation_Reason.TabIndex = 12
        Me.lblCancellation_Reason.Text = "Cancellation Reason:"
        '
        'dtpPolicy_CancellationDate
        '
        Me.dtpPolicy_CancellationDate.Location = New System.Drawing.Point(170, 48)
        Me.dtpPolicy_CancellationDate.Name = "dtpPolicy_CancellationDate"
        Me.dtpPolicy_CancellationDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpPolicy_CancellationDate.TabIndex = 11
        '
        'dtpRequestedDate
        '
        Me.dtpRequestedDate.Location = New System.Drawing.Point(170, 22)
        Me.dtpRequestedDate.Name = "dtpRequestedDate"
        Me.dtpRequestedDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpRequestedDate.TabIndex = 9
        '
        'lblPolicy_CancellationDate
        '
        Me.lblPolicy_CancellationDate.AutoSize = True
        Me.lblPolicy_CancellationDate.Location = New System.Drawing.Point(25, 52)
        Me.lblPolicy_CancellationDate.Name = "lblPolicy_CancellationDate"
        Me.lblPolicy_CancellationDate.Size = New System.Drawing.Size(94, 13)
        Me.lblPolicy_CancellationDate.TabIndex = 10
        Me.lblPolicy_CancellationDate.Text = "Cancellation Date:"
        '
        'lblRID
        '
        Me.lblRID.AutoSize = True
        Me.lblRID.Location = New System.Drawing.Point(1030, 605)
        Me.lblRID.Name = "lblRID"
        Me.lblRID.Size = New System.Drawing.Size(26, 13)
        Me.lblRID.TabIndex = 20
        Me.lblRID.Text = "RID"
        Me.lblRID.Visible = False
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(1062, 605)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 21
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'gbPolicyDetails
        '
        Me.gbPolicyDetails.Controls.Add(Me.dgvPolicyDetails)
        Me.gbPolicyDetails.Location = New System.Drawing.Point(12, 216)
        Me.gbPolicyDetails.Name = "gbPolicyDetails"
        Me.gbPolicyDetails.Size = New System.Drawing.Size(1129, 215)
        Me.gbPolicyDetails.TabIndex = 22
        Me.gbPolicyDetails.TabStop = False
        Me.gbPolicyDetails.Text = "Policy Details"
        '
        'dgvPolicyDetails
        '
        Me.dgvPolicyDetails.AllowUserToAddRows = False
        Me.dgvPolicyDetails.AllowUserToDeleteRows = False
        Me.dgvPolicyDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPolicyDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPolicyDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvPolicyDetails.Name = "dgvPolicyDetails"
        Me.dgvPolicyDetails.Size = New System.Drawing.Size(1123, 196)
        Me.dgvPolicyDetails.TabIndex = 0
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(948, 518)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 23
        Me.lblID.Text = "ID"
        Me.lblID.Visible = False
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'REFID
        '
        Me.REFID.DataPropertyName = "REFID"
        Me.REFID.HeaderText = "RID"
        Me.REFID.Name = "REFID"
        Me.REFID.Visible = False
        '
        'ASSIGN_TO
        '
        Me.ASSIGN_TO.DataPropertyName = "ASSIGN_TO"
        Me.ASSIGN_TO.HeaderText = "ASSIGN TO"
        Me.ASSIGN_TO.Name = "ASSIGN_TO"
        '
        'ASSIGN_ON
        '
        Me.ASSIGN_ON.DataPropertyName = "ASSIGN_ON"
        Me.ASSIGN_ON.HeaderText = "ASSIGN ON"
        Me.ASSIGN_ON.Name = "ASSIGN_ON"
        '
        'ASSIGN_BY
        '
        Me.ASSIGN_BY.DataPropertyName = "ASSIGN_BY"
        Me.ASSIGN_BY.HeaderText = "ASSIGN BY"
        Me.ASSIGN_BY.Name = "ASSIGN_BY"
        '
        'IC_NEW
        '
        Me.IC_NEW.DataPropertyName = "IC_NEW"
        Me.IC_NEW.HeaderText = "IC"
        Me.IC_NEW.Name = "IC_NEW"
        '
        'FULL_NAME
        '
        Me.FULL_NAME.DataPropertyName = "FULL_NAME"
        Me.FULL_NAME.HeaderText = "Full Name"
        Me.FULL_NAME.Name = "FULL_NAME"
        '
        'Birth_Date
        '
        Me.Birth_Date.DataPropertyName = "Birth_Date"
        Me.Birth_Date.HeaderText = "DOB"
        Me.Birth_Date.Name = "Birth_Date"
        '
        'PCODE
        '
        Me.PCODE.DataPropertyName = "PCODE"
        Me.PCODE.HeaderText = "PLAN CODE"
        Me.PCODE.Name = "PCODE"
        '
        'PTYPE
        '
        Me.PTYPE.DataPropertyName = "PTYPE"
        Me.PTYPE.HeaderText = "PLAN TYPE"
        Me.PTYPE.Name = "PTYPE"
        '
        'FNO
        '
        Me.FNO.DataPropertyName = "FNO"
        Me.FNO.HeaderText = "FILE NO"
        Me.FNO.Name = "FNO"
        '
        'PHOUSE
        '
        Me.PHOUSE.DataPropertyName = "PHOUSE"
        Me.PHOUSE.HeaderText = "PHONE HOUSE"
        Me.PHOUSE.Name = "PHOUSE"
        '
        'POFFICE
        '
        Me.POFFICE.DataPropertyName = "POFFICE"
        Me.POFFICE.HeaderText = "PHONE OFFICE"
        Me.POFFICE.Name = "POFFICE"
        '
        'PMOBILE
        '
        Me.PMOBILE.DataPropertyName = "PMOBILE"
        Me.PMOBILE.HeaderText = "PHONE MOBILE"
        Me.PMOBILE.Name = "PMOBILE"
        '
        'EMAIL
        '
        Me.EMAIL.DataPropertyName = "EMAIL"
        Me.EMAIL.HeaderText = "EMAIL"
        Me.EMAIL.Name = "EMAIL"
        '
        'NON_PAYMENT
        '
        Me.NON_PAYMENT.DataPropertyName = "NON_PAYMENT"
        Me.NON_PAYMENT.HeaderText = "NON PAYMENT"
        Me.NON_PAYMENT.Name = "NON_PAYMENT"
        Me.NON_PAYMENT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NON_PAYMENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TOT_SHORT
        '
        Me.TOT_SHORT.DataPropertyName = "TOT_SHORT"
        Me.TOT_SHORT.HeaderText = "TOTAL SHORT"
        Me.TOT_SHORT.Name = "TOT_SHORT"
        Me.TOT_SHORT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TOT_SHORT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TOT_SHORT_NR
        '
        Me.TOT_SHORT_NR.DataPropertyName = "TOT_SHORT_NR"
        Me.TOT_SHORT_NR.HeaderText = "TOTAL SHORT NOT REQUESTED"
        Me.TOT_SHORT_NR.Name = "TOT_SHORT_NR"
        '
        'TOT_SHORT_R
        '
        Me.TOT_SHORT_R.DataPropertyName = "TOT_SHORT_R"
        Me.TOT_SHORT_R.HeaderText = "TOTAL SHORT REQUESTED"
        Me.TOT_SHORT_R.Name = "TOT_SHORT_R"
        '
        'TOT_SHORT_RECOVER
        '
        Me.TOT_SHORT_RECOVER.DataPropertyName = "TOT_SHORT_RECOVER"
        Me.TOT_SHORT_RECOVER.HeaderText = "TOTAL SHORT RECOVERED"
        Me.TOT_SHORT_RECOVER.Name = "TOT_SHORT_RECOVER"
        '
        'TOT_BAL
        '
        Me.TOT_BAL.DataPropertyName = "TOT_BAL"
        Me.TOT_BAL.HeaderText = "TOTAL BALANCE"
        Me.TOT_BAL.Name = "TOT_BAL"
        '
        'Reason
        '
        Me.Reason.HeaderText = "Action"
        Me.Reason.Items.AddRange(New Object() {"PREMIUM REQUEST", "CONTACT POLICY HOLDER"})
        Me.Reason.Name = "Reason"
        '
        'Action
        '
        Me.Action.HeaderText = "Assign To"
        Me.Action.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.Action.Name = "Action"
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        '
        'Submit
        '
        Me.Submit.HeaderText = "Submit"
        Me.Submit.Name = "Submit"
        Me.Submit.Text = "Submit"
        Me.Submit.ToolTipText = "Submit"
        Me.Submit.UseColumnTextForLinkValue = True
        '
        'ffShortFall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 657)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.gbPolicyDetails)
        Me.Controls.Add(Me.lblP1)
        Me.Controls.Add(Me.lblRID)
        Me.Controls.Add(Me.lblPREMIUM)
        Me.Controls.Add(Me.lblREFID)
        Me.Controls.Add(Me.gbDecision)
        Me.Controls.Add(Me.dgvShortfall)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "ffShortFall"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Fall (Finance)"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvShortfall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDecision.ResumeLayout(False)
        Me.gbDecision.PerformLayout()
        Me.gbPolicyDetails.ResumeLayout(False)
        CType(Me.dgvPolicyDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblTot As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvShortfall As System.Windows.Forms.DataGridView
    Friend WithEvents lblPREMIUM As System.Windows.Forms.Label
    Friend WithEvents lblREFID As System.Windows.Forms.Label
    Friend WithEvents gbDecision As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEffective_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents cmbCancellation_Reason As System.Windows.Forms.ComboBox
    Friend WithEvents lblRequestedDate As System.Windows.Forms.Label
    Friend WithEvents lblCancellation_Reason As System.Windows.Forms.Label
    Friend WithEvents dtpPolicy_CancellationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPolicy_CancellationDate As System.Windows.Forms.Label
    Friend WithEvents lblRID As System.Windows.Forms.Label
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents gbPolicyDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPolicyDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASSIGN_TO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASSIGN_ON As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASSIGN_BY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IC_NEW As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FULL_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Birth_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PHOUSE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POFFICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PMOBILE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NON_PAYMENT As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT_SHORT As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT_SHORT_NR As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT_SHORT_R As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT_SHORT_RECOVER As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT_BAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reason As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Action As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Submit As System.Windows.Forms.DataGridViewLinkColumn
End Class
