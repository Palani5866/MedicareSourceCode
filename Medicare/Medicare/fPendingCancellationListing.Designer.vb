<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPendingCancellationListing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fPendingCancellationListing))
        Me.gbPendingCancellationListing = New System.Windows.Forms.GroupBox
        Me.dgvPendingCancellationListing = New System.Windows.Forms.DataGridView
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslblTOT = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnExporttoExcel = New System.Windows.Forms.ToolStripButton
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
        Me.Reason = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Action = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Submit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.gbPendingCancellationListing.SuspendLayout()
        CType(Me.dgvPendingCancellationListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsReport.SuspendLayout()
        Me.gbDecision.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPendingCancellationListing
        '
        Me.gbPendingCancellationListing.Controls.Add(Me.dgvPendingCancellationListing)
        Me.gbPendingCancellationListing.Location = New System.Drawing.Point(0, 28)
        Me.gbPendingCancellationListing.Name = "gbPendingCancellationListing"
        Me.gbPendingCancellationListing.Size = New System.Drawing.Size(1112, 289)
        Me.gbPendingCancellationListing.TabIndex = 0
        Me.gbPendingCancellationListing.TabStop = False
        Me.gbPendingCancellationListing.Text = "Pending Cancellation Listing"
        '
        'dgvPendingCancellationListing
        '
        Me.dgvPendingCancellationListing.AllowUserToAddRows = False
        Me.dgvPendingCancellationListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendingCancellationListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reason, Me.Action, Me.Remarks, Me.Submit})
        Me.dgvPendingCancellationListing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingCancellationListing.Location = New System.Drawing.Point(3, 16)
        Me.dgvPendingCancellationListing.Name = "dgvPendingCancellationListing"
        Me.dgvPendingCancellationListing.Size = New System.Drawing.Size(1106, 270)
        Me.dgvPendingCancellationListing.TabIndex = 0
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblTOT, Me.ToolStripSeparator1, Me.tsbtnExporttoExcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsReport.Size = New System.Drawing.Size(1119, 25)
        Me.tsReport.TabIndex = 7
        Me.tsReport.Text = "ToolStrip"
        '
        'tslblTOT
        '
        Me.tslblTOT.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.tslblTOT.ForeColor = System.Drawing.Color.Blue
        Me.tslblTOT.Name = "tslblTOT"
        Me.tslblTOT.Size = New System.Drawing.Size(84, 22)
        Me.tslblTOT.Text = "Total Records"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'lblPREMIUM
        '
        Me.lblPREMIUM.AutoSize = True
        Me.lblPREMIUM.Location = New System.Drawing.Point(891, 371)
        Me.lblPREMIUM.Name = "lblPREMIUM"
        Me.lblPREMIUM.Size = New System.Drawing.Size(58, 13)
        Me.lblPREMIUM.TabIndex = 15
        Me.lblPREMIUM.Text = "PREMIUM"
        Me.lblPREMIUM.Visible = False
        '
        'lblREFID
        '
        Me.lblREFID.AutoSize = True
        Me.lblREFID.Location = New System.Drawing.Point(891, 349)
        Me.lblREFID.Name = "lblREFID"
        Me.lblREFID.Size = New System.Drawing.Size(39, 13)
        Me.lblREFID.TabIndex = 14
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
        Me.gbDecision.Location = New System.Drawing.Point(226, 323)
        Me.gbDecision.Name = "gbDecision"
        Me.gbDecision.Size = New System.Drawing.Size(593, 206)
        Me.gbDecision.TabIndex = 13
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
        'Reason
        '
        Me.Reason.HeaderText = "Reason"
        Me.Reason.Items.AddRange(New Object() {"Bankrupt", "Change Dept", "Deceased", "Insufficient Salary", "No Payment Without Reason", "Paid Direct To Union/Self", "Resign", "Retired", "Unpaid Leave"})
        Me.Reason.Name = "Reason"
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.Items.AddRange(New Object() {"Tele Marketing", "Premium", "Ignore"})
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
        'fPendingCancellationListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 545)
        Me.Controls.Add(Me.lblPREMIUM)
        Me.Controls.Add(Me.lblREFID)
        Me.Controls.Add(Me.gbDecision)
        Me.Controls.Add(Me.tsReport)
        Me.Controls.Add(Me.gbPendingCancellationListing)
        Me.Name = "fPendingCancellationListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending Cancellation Listing Details"
        Me.gbPendingCancellationListing.ResumeLayout(False)
        CType(Me.dgvPendingCancellationListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.gbDecision.ResumeLayout(False)
        Me.gbDecision.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbPendingCancellationListing As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPendingCancellationListing As System.Windows.Forms.DataGridView
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnExporttoExcel As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents tslblTOT As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Reason As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Action As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Submit As System.Windows.Forms.DataGridViewLinkColumn
End Class
