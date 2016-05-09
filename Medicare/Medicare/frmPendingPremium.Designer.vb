<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendingPremium
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPendingPremium))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslbldtFrom = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.tslbldtTo = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnExporttoExcel = New System.Windows.Forms.ToolStripButton
        Me.gbNonPaymentDetails = New System.Windows.Forms.GroupBox
        Me.lblREFTYPE = New System.Windows.Forms.Label
        Me.dgvPNONPayment = New System.Windows.Forms.DataGridView
        Me.Reason = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AssignTo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Submit = New System.Windows.Forms.DataGridViewLinkColumn
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
        Me.gbPa = New System.Windows.Forms.GroupBox
        Me.dgvPaymentDetails = New System.Windows.Forms.DataGridView
        Me.lblREFID = New System.Windows.Forms.Label
        Me.lblPREMIUM = New System.Windows.Forms.Label
        Me.lblRID = New System.Windows.Forms.Label
        Me.tsReport.SuspendLayout()
        Me.gbNonPaymentDetails.SuspendLayout()
        CType(Me.dgvPNONPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDecision.SuspendLayout()
        Me.gbPa.SuspendLayout()
        CType(Me.dgvPaymentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslbldtFrom, Me.tstxtDateFrom, Me.tslbldtTo, Me.tstxtDateTo, Me.tsbtnGo, Me.tsReport_Div1, Me.tsbtnExporttoExcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1095, 25)
        Me.tsReport.TabIndex = 7
        Me.tsReport.Text = "ToolStrip"
        '
        'tslbldtFrom
        '
        Me.tslbldtFrom.Name = "tslbldtFrom"
        Me.tslbldtFrom.Size = New System.Drawing.Size(146, 22)
        Me.tslbldtFrom.Text = "Date From (dd/mm/yyyy):"
        Me.tslbldtFrom.Visible = False
        '
        'tstxtDateFrom
        '
        Me.tstxtDateFrom.MaxLength = 10
        Me.tstxtDateFrom.Name = "tstxtDateFrom"
        Me.tstxtDateFrom.Size = New System.Drawing.Size(100, 25)
        Me.tstxtDateFrom.Visible = False
        '
        'tslbldtTo
        '
        Me.tslbldtTo.Name = "tslbldtTo"
        Me.tslbldtTo.Size = New System.Drawing.Size(132, 22)
        Me.tslbldtTo.Text = "Date To (dd/mm/yyyy):"
        Me.tslbldtTo.Visible = False
        '
        'tstxtDateTo
        '
        Me.tstxtDateTo.MaxLength = 10
        Me.tstxtDateTo.Name = "tstxtDateTo"
        Me.tstxtDateTo.ReadOnly = True
        Me.tstxtDateTo.Size = New System.Drawing.Size(100, 25)
        Me.tstxtDateTo.Visible = False
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(26, 22)
        Me.tsbtnGo.Text = "Go"
        Me.tsbtnGo.Visible = False
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnExporttoExcel
        '
        Me.tsbtnExporttoExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnExporttoExcel.Image = CType(resources.GetObject("tsbtnExporttoExcel.Image"), System.Drawing.Image)
        Me.tsbtnExporttoExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExporttoExcel.Name = "tsbtnExporttoExcel"
        Me.tsbtnExporttoExcel.Size = New System.Drawing.Size(87, 22)
        Me.tsbtnExporttoExcel.Text = "Export to Excel"
        '
        'gbNonPaymentDetails
        '
        Me.gbNonPaymentDetails.Controls.Add(Me.lblREFTYPE)
        Me.gbNonPaymentDetails.Controls.Add(Me.dgvPNONPayment)
        Me.gbNonPaymentDetails.Location = New System.Drawing.Point(0, 28)
        Me.gbNonPaymentDetails.Name = "gbNonPaymentDetails"
        Me.gbNonPaymentDetails.Size = New System.Drawing.Size(1092, 207)
        Me.gbNonPaymentDetails.TabIndex = 8
        Me.gbNonPaymentDetails.TabStop = False
        Me.gbNonPaymentDetails.Text = "Non Payment Details"
        '
        'lblREFTYPE
        '
        Me.lblREFTYPE.AutoSize = True
        Me.lblREFTYPE.Location = New System.Drawing.Point(364, 104)
        Me.lblREFTYPE.Name = "lblREFTYPE"
        Me.lblREFTYPE.Size = New System.Drawing.Size(56, 13)
        Me.lblREFTYPE.TabIndex = 1
        Me.lblREFTYPE.Text = "REFTYPE"
        Me.lblREFTYPE.Visible = False
        '
        'dgvPNONPayment
        '
        Me.dgvPNONPayment.AllowUserToAddRows = False
        Me.dgvPNONPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPNONPayment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reason, Me.AssignTo, Me.Remarks, Me.Submit})
        Me.dgvPNONPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPNONPayment.Location = New System.Drawing.Point(3, 16)
        Me.dgvPNONPayment.Name = "dgvPNONPayment"
        Me.dgvPNONPayment.Size = New System.Drawing.Size(1086, 188)
        Me.dgvPNONPayment.TabIndex = 0
        '
        'Reason
        '
        Me.Reason.HeaderText = "Reason"
        Me.Reason.Items.AddRange(New Object() {"Bankrupt", "Change Dept", "Deceased", "Insufficient Salary", "No Payment Without Reason", "Paid Direct To Union/Self", "Resign", "Retired", "Unpaid Leave"})
        Me.Reason.Name = "Reason"
        '
        'AssignTo
        '
        Me.AssignTo.HeaderText = "Action"
        Me.AssignTo.Items.AddRange(New Object() {"Tele Marketing", "Premium", "Ignore"})
        Me.AssignTo.Name = "AssignTo"
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
        Me.Submit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Submit.Text = "Submit"
        Me.Submit.ToolTipText = "Submit"
        Me.Submit.UseColumnTextForLinkValue = True
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
        Me.gbDecision.Location = New System.Drawing.Point(249, 241)
        Me.gbDecision.Name = "gbDecision"
        Me.gbDecision.Size = New System.Drawing.Size(593, 206)
        Me.gbDecision.TabIndex = 9
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
        'gbPa
        '
        Me.gbPa.Controls.Add(Me.dgvPaymentDetails)
        Me.gbPa.Location = New System.Drawing.Point(3, 453)
        Me.gbPa.Name = "gbPa"
        Me.gbPa.Size = New System.Drawing.Size(1092, 156)
        Me.gbPa.TabIndex = 10
        Me.gbPa.TabStop = False
        Me.gbPa.Text = "Non Payment Details"
        '
        'dgvPaymentDetails
        '
        Me.dgvPaymentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPaymentDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPaymentDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvPaymentDetails.Name = "dgvPaymentDetails"
        Me.dgvPaymentDetails.Size = New System.Drawing.Size(1086, 137)
        Me.dgvPaymentDetails.TabIndex = 0
        '
        'lblREFID
        '
        Me.lblREFID.AutoSize = True
        Me.lblREFID.Location = New System.Drawing.Point(914, 267)
        Me.lblREFID.Name = "lblREFID"
        Me.lblREFID.Size = New System.Drawing.Size(39, 13)
        Me.lblREFID.TabIndex = 11
        Me.lblREFID.Text = "REFID"
        Me.lblREFID.Visible = False
        '
        'lblPREMIUM
        '
        Me.lblPREMIUM.AutoSize = True
        Me.lblPREMIUM.Location = New System.Drawing.Point(914, 289)
        Me.lblPREMIUM.Name = "lblPREMIUM"
        Me.lblPREMIUM.Size = New System.Drawing.Size(58, 13)
        Me.lblPREMIUM.TabIndex = 12
        Me.lblPREMIUM.Text = "PREMIUM"
        Me.lblPREMIUM.Visible = False
        '
        'lblRID
        '
        Me.lblRID.AutoSize = True
        Me.lblRID.Location = New System.Drawing.Point(914, 315)
        Me.lblRID.Name = "lblRID"
        Me.lblRID.Size = New System.Drawing.Size(26, 13)
        Me.lblRID.TabIndex = 13
        Me.lblRID.Text = "RID"
        Me.lblRID.Visible = False
        '
        'frmPendingPremium
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 621)
        Me.Controls.Add(Me.lblRID)
        Me.Controls.Add(Me.lblPREMIUM)
        Me.Controls.Add(Me.lblREFID)
        Me.Controls.Add(Me.gbPa)
        Me.Controls.Add(Me.gbDecision)
        Me.Controls.Add(Me.gbNonPaymentDetails)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmPendingPremium"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending Premium (Non Payment)"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.gbNonPaymentDetails.ResumeLayout(False)
        Me.gbNonPaymentDetails.PerformLayout()
        CType(Me.dgvPNONPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDecision.ResumeLayout(False)
        Me.gbDecision.PerformLayout()
        Me.gbPa.ResumeLayout(False)
        CType(Me.dgvPaymentDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tslbldtFrom As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDateFrom As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tslbldtTo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDateTo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnExporttoExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbNonPaymentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lblREFTYPE As System.Windows.Forms.Label
    Friend WithEvents dgvPNONPayment As System.Windows.Forms.DataGridView
    Friend WithEvents gbDecision As System.Windows.Forms.GroupBox
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents cmbCancellation_Reason As System.Windows.Forms.ComboBox
    Friend WithEvents lblRequestedDate As System.Windows.Forms.Label
    Friend WithEvents lblCancellation_Reason As System.Windows.Forms.Label
    Friend WithEvents dtpPolicy_CancellationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPolicy_CancellationDate As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents gbPa As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPaymentDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblREFID As System.Windows.Forms.Label
    Friend WithEvents dtpEffective_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPREMIUM As System.Windows.Forms.Label
    Friend WithEvents Reason As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AssignTo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Submit As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents lblRID As System.Windows.Forms.Label
End Class
