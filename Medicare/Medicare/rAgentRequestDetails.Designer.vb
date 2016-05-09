<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rAgentRequestDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rAgentRequestDetails))
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.lblDateFrom = New System.Windows.Forms.ToolStripLabel
        Me.txtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.txtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.btnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnPrint = New System.Windows.Forms.ToolStripButton
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.gbAgentRequestDetails = New System.Windows.Forms.GroupBox
        Me.dgvAgentRequestDetails = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AGENTCODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GEFORM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CCFORM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CPAFORM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BIRO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NOMINATION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FLYERSCC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FLYERSCPA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BOOKLETCC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BOOKLETCPA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POSTERCC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POSTERCPA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NAMECARD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BUNTINGCC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BUNTINGCPA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.REQUESTDATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STATUS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.REMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Edit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.ACTION = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Verification = New System.Windows.Forms.DataGridViewLinkColumn
        Me.gbAgentApprovedDetails = New System.Windows.Forms.GroupBox
        Me.dgvAgentApprovedDetails = New System.Windows.Forms.DataGridView
        Me.PostedDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Submit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.gbAgentClosedDetails = New System.Windows.Forms.GroupBox
        Me.dgvAgentClosedDetails = New System.Windows.Forms.DataGridView
        Me.tsSearch.SuspendLayout()
        Me.gbAgentRequestDetails.SuspendLayout()
        CType(Me.dgvAgentRequestDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgentApprovedDetails.SuspendLayout()
        CType(Me.dgvAgentApprovedDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgentClosedDetails.SuspendLayout()
        CType(Me.dgvAgentClosedDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDateFrom, Me.txtDateFrom, Me.ToolStripLabel, Me.txtDateTo, Me.btnGo, Me.tsReport_Div1, Me.tsbtnPrint, Me.btnXPort})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(1247, 25)
        Me.tsSearch.TabIndex = 8
        Me.tsSearch.Text = "ToolStrip"
        '
        'lblDateFrom
        '
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(154, 22)
        Me.lblDateFrom.Text = "Date - From (dd/mm/yyyy):"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.MaxLength = 10
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripLabel
        '
        Me.ToolStripLabel.Name = "ToolStripLabel"
        Me.ToolStripLabel.Size = New System.Drawing.Size(140, 22)
        Me.ToolStripLabel.Text = "Date - To (dd/mm/yyyy):"
        '
        'txtDateTo
        '
        Me.txtDateTo.MaxLength = 10
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(100, 25)
        '
        'btnGo
        '
        Me.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(26, 22)
        Me.btnGo.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnPrint
        '
        Me.tsbtnPrint.Image = Global.Medicare.My.Resources.Resources._100
        Me.tsbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnPrint.Name = "tsbtnPrint"
        Me.tsbtnPrint.Size = New System.Drawing.Size(52, 22)
        Me.tsbtnPrint.Text = "Print"
        Me.tsbtnPrint.Visible = False
        '
        'btnXPort
        '
        Me.btnXPort.Image = CType(resources.GetObject("btnXPort.Image"), System.Drawing.Image)
        Me.btnXPort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnXPort.Name = "btnXPort"
        Me.btnXPort.Size = New System.Drawing.Size(60, 22)
        Me.btnXPort.Text = "Export"
        '
        'gbAgentRequestDetails
        '
        Me.gbAgentRequestDetails.Controls.Add(Me.dgvAgentRequestDetails)
        Me.gbAgentRequestDetails.Location = New System.Drawing.Point(0, 28)
        Me.gbAgentRequestDetails.Name = "gbAgentRequestDetails"
        Me.gbAgentRequestDetails.Size = New System.Drawing.Size(1247, 197)
        Me.gbAgentRequestDetails.TabIndex = 9
        Me.gbAgentRequestDetails.TabStop = False
        Me.gbAgentRequestDetails.Text = "Agent Request Details"
        '
        'dgvAgentRequestDetails
        '
        Me.dgvAgentRequestDetails.AllowUserToAddRows = False
        Me.dgvAgentRequestDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAgentRequestDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.AGENTCODE, Me.GEFORM, Me.CCFORM, Me.CPAFORM, Me.BIRO, Me.NOMINATION, Me.FLYERSCC, Me.FLYERSCPA, Me.BOOKLETCC, Me.BOOKLETCPA, Me.POSTERCC, Me.POSTERCPA, Me.NAMECARD, Me.BUNTINGCC, Me.BUNTINGCPA, Me.REQUESTDATE, Me.STATUS, Me.REMARKS, Me.Edit, Me.ACTION, Me.Verification})
        Me.dgvAgentRequestDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAgentRequestDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvAgentRequestDetails.Name = "dgvAgentRequestDetails"
        Me.dgvAgentRequestDetails.Size = New System.Drawing.Size(1241, 178)
        Me.dgvAgentRequestDetails.TabIndex = 0
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'AGENTCODE
        '
        Me.AGENTCODE.DataPropertyName = "AGENTCODE"
        Me.AGENTCODE.HeaderText = "AGENT CODE"
        Me.AGENTCODE.Name = "AGENTCODE"
        '
        'GEFORM
        '
        Me.GEFORM.DataPropertyName = "GEFORM"
        Me.GEFORM.HeaderText = "GEFORM"
        Me.GEFORM.Name = "GEFORM"
        '
        'CCFORM
        '
        Me.CCFORM.DataPropertyName = "CCFORM"
        Me.CCFORM.HeaderText = "CCFORM"
        Me.CCFORM.Name = "CCFORM"
        '
        'CPAFORM
        '
        Me.CPAFORM.DataPropertyName = "CPAFORM"
        Me.CPAFORM.HeaderText = "CPAFORM"
        Me.CPAFORM.Name = "CPAFORM"
        '
        'BIRO
        '
        Me.BIRO.DataPropertyName = "BIRO"
        Me.BIRO.HeaderText = "BIRO"
        Me.BIRO.Name = "BIRO"
        '
        'NOMINATION
        '
        Me.NOMINATION.DataPropertyName = "NOMINATION"
        Me.NOMINATION.HeaderText = "NOMINATION"
        Me.NOMINATION.Name = "NOMINATION"
        '
        'FLYERSCC
        '
        Me.FLYERSCC.DataPropertyName = "FLYERSCC"
        Me.FLYERSCC.HeaderText = "FLYERSCC"
        Me.FLYERSCC.Name = "FLYERSCC"
        '
        'FLYERSCPA
        '
        Me.FLYERSCPA.DataPropertyName = "FLYERSCPA"
        Me.FLYERSCPA.HeaderText = "FLYERSCPA"
        Me.FLYERSCPA.Name = "FLYERSCPA"
        '
        'BOOKLETCC
        '
        Me.BOOKLETCC.DataPropertyName = "BOOKLETCC"
        Me.BOOKLETCC.HeaderText = "BOOKLETCC"
        Me.BOOKLETCC.Name = "BOOKLETCC"
        '
        'BOOKLETCPA
        '
        Me.BOOKLETCPA.DataPropertyName = "BOOKLETCPA"
        Me.BOOKLETCPA.HeaderText = "BOOKLETCPA"
        Me.BOOKLETCPA.Name = "BOOKLETCPA"
        '
        'POSTERCC
        '
        Me.POSTERCC.DataPropertyName = "POSTERCC"
        Me.POSTERCC.HeaderText = "POSTERCC"
        Me.POSTERCC.Name = "POSTERCC"
        '
        'POSTERCPA
        '
        Me.POSTERCPA.DataPropertyName = "POSTERCPA"
        Me.POSTERCPA.HeaderText = "POSTERCPA"
        Me.POSTERCPA.Name = "POSTERCPA"
        '
        'NAMECARD
        '
        Me.NAMECARD.DataPropertyName = "NAMECARD"
        Me.NAMECARD.HeaderText = "NAMECARD"
        Me.NAMECARD.Name = "NAMECARD"
        '
        'BUNTINGCC
        '
        Me.BUNTINGCC.DataPropertyName = "BUNTINGCC"
        Me.BUNTINGCC.HeaderText = "BUNTINGCC"
        Me.BUNTINGCC.Name = "BUNTINGCC"
        '
        'BUNTINGCPA
        '
        Me.BUNTINGCPA.DataPropertyName = "BUNTINGCPA"
        Me.BUNTINGCPA.HeaderText = "BUNTINGCPA"
        Me.BUNTINGCPA.Name = "BUNTINGCPA"
        '
        'REQUESTDATE
        '
        Me.REQUESTDATE.DataPropertyName = "REQUESTDATE"
        Me.REQUESTDATE.HeaderText = "REQUESTDATE"
        Me.REQUESTDATE.Name = "REQUESTDATE"
        Me.REQUESTDATE.ReadOnly = True
        '
        'STATUS
        '
        Me.STATUS.DataPropertyName = "STATUS"
        Me.STATUS.HeaderText = "STATUS"
        Me.STATUS.Name = "STATUS"
        Me.STATUS.ReadOnly = True
        '
        'REMARKS
        '
        Me.REMARKS.HeaderText = "REMARKS"
        Me.REMARKS.Name = "REMARKS"
        '
        'Edit
        '
        Me.Edit.HeaderText = "EDIT"
        Me.Edit.Name = "Edit"
        Me.Edit.Text = "Edit"
        Me.Edit.ToolTipText = "Edit"
        Me.Edit.UseColumnTextForLinkValue = True
        '
        'ACTION
        '
        Me.ACTION.HeaderText = "ACTION"
        Me.ACTION.Name = "ACTION"
        Me.ACTION.Text = "Update"
        Me.ACTION.ToolTipText = "Update"
        Me.ACTION.UseColumnTextForLinkValue = True
        '
        'Verification
        '
        Me.Verification.HeaderText = "Verification"
        Me.Verification.Name = "Verification"
        Me.Verification.Text = "Approved"
        Me.Verification.ToolTipText = "Approved"
        Me.Verification.UseColumnTextForLinkValue = True
        '
        'gbAgentApprovedDetails
        '
        Me.gbAgentApprovedDetails.Controls.Add(Me.dgvAgentApprovedDetails)
        Me.gbAgentApprovedDetails.Location = New System.Drawing.Point(0, 231)
        Me.gbAgentApprovedDetails.Name = "gbAgentApprovedDetails"
        Me.gbAgentApprovedDetails.Size = New System.Drawing.Size(1247, 210)
        Me.gbAgentApprovedDetails.TabIndex = 10
        Me.gbAgentApprovedDetails.TabStop = False
        Me.gbAgentApprovedDetails.Text = "Agent Verified/Approved Details"
        '
        'dgvAgentApprovedDetails
        '
        Me.dgvAgentApprovedDetails.AllowUserToAddRows = False
        Me.dgvAgentApprovedDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAgentApprovedDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PostedDate, Me.Submit})
        Me.dgvAgentApprovedDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAgentApprovedDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvAgentApprovedDetails.Name = "dgvAgentApprovedDetails"
        Me.dgvAgentApprovedDetails.Size = New System.Drawing.Size(1241, 191)
        Me.dgvAgentApprovedDetails.TabIndex = 0
        '
        'PostedDate
        '
        Me.PostedDate.HeaderText = "Posted Date (dd/MM/yyyy)"
        Me.PostedDate.Name = "PostedDate"
        '
        'Submit
        '
        Me.Submit.HeaderText = "Action"
        Me.Submit.Name = "Submit"
        Me.Submit.Text = "Post"
        Me.Submit.ToolTipText = "Post"
        Me.Submit.UseColumnTextForLinkValue = True
        '
        'gbAgentClosedDetails
        '
        Me.gbAgentClosedDetails.Controls.Add(Me.dgvAgentClosedDetails)
        Me.gbAgentClosedDetails.Location = New System.Drawing.Point(3, 447)
        Me.gbAgentClosedDetails.Name = "gbAgentClosedDetails"
        Me.gbAgentClosedDetails.Size = New System.Drawing.Size(1247, 210)
        Me.gbAgentClosedDetails.TabIndex = 11
        Me.gbAgentClosedDetails.TabStop = False
        Me.gbAgentClosedDetails.Text = "Agent Closed Request Details"
        '
        'dgvAgentClosedDetails
        '
        Me.dgvAgentClosedDetails.AllowUserToAddRows = False
        Me.dgvAgentClosedDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAgentClosedDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAgentClosedDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvAgentClosedDetails.Name = "dgvAgentClosedDetails"
        Me.dgvAgentClosedDetails.Size = New System.Drawing.Size(1241, 191)
        Me.dgvAgentClosedDetails.TabIndex = 0
        '
        'rAgentRequestDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1247, 666)
        Me.Controls.Add(Me.gbAgentClosedDetails)
        Me.Controls.Add(Me.gbAgentApprovedDetails)
        Me.Controls.Add(Me.gbAgentRequestDetails)
        Me.Controls.Add(Me.tsSearch)
        Me.Name = "rAgentRequestDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agent Request Details"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        Me.gbAgentRequestDetails.ResumeLayout(False)
        CType(Me.dgvAgentRequestDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgentApprovedDetails.ResumeLayout(False)
        CType(Me.dgvAgentApprovedDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgentClosedDetails.ResumeLayout(False)
        CType(Me.dgvAgentClosedDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDateFrom As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtDateFrom As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtDateTo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnXPort As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbAgentRequestDetails As System.Windows.Forms.GroupBox
    Friend WithEvents gbAgentApprovedDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvAgentRequestDetails As System.Windows.Forms.DataGridView
    Friend WithEvents dgvAgentApprovedDetails As System.Windows.Forms.DataGridView
    Friend WithEvents gbAgentClosedDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvAgentClosedDetails As System.Windows.Forms.DataGridView
    Friend WithEvents PostedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Submit As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AGENTCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GEFORM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCFORM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CPAFORM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BIRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMINATION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FLYERSCC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FLYERSCPA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BOOKLETCC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BOOKLETCPA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POSTERCC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POSTERCPA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NAMECARD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BUNTINGCC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BUNTINGCPA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REQUESTDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATUS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REMARKS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ACTION As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Verification As System.Windows.Forms.DataGridViewLinkColumn
End Class
