<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShortfallRequest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShortfallRequest))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tslblTot = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.gbRe_Assign = New System.Windows.Forms.GroupBox
        Me.dgvSFR = New System.Windows.Forms.DataGridView
        Me.Upload = New System.Windows.Forms.DataGridViewLinkColumn
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Request = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Submit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.gbPendingDecision = New System.Windows.Forms.GroupBox
        Me.dgvPendingDecision = New System.Windows.Forms.DataGridView
        Me.gbPa = New System.Windows.Forms.GroupBox
        Me.dgvPendingConfirmation = New System.Windows.Forms.DataGridView
        Me.pcView = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Confirm = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tolForm.SuspendLayout()
        Me.gbRe_Assign.SuspendLayout()
        CType(Me.dgvSFR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPendingDecision.SuspendLayout()
        CType(Me.dgvPendingDecision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPa.SuspendLayout()
        CType(Me.dgvPendingConfirmation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblTot, Me.ToolStripSeparator1, Me.tsbExport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tolForm.Size = New System.Drawing.Size(1096, 25)
        Me.tolForm.TabIndex = 12
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
        'gbRe_Assign
        '
        Me.gbRe_Assign.Controls.Add(Me.dgvSFR)
        Me.gbRe_Assign.Location = New System.Drawing.Point(3, 26)
        Me.gbRe_Assign.Name = "gbRe_Assign"
        Me.gbRe_Assign.Size = New System.Drawing.Size(1089, 217)
        Me.gbRe_Assign.TabIndex = 13
        Me.gbRe_Assign.TabStop = False
        Me.gbRe_Assign.Text = "Short Fall Request"
        '
        'dgvSFR
        '
        Me.dgvSFR.AllowUserToAddRows = False
        Me.dgvSFR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSFR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Upload, Me.View, Me.Remarks, Me.Request, Me.Submit})
        Me.dgvSFR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSFR.Location = New System.Drawing.Point(3, 16)
        Me.dgvSFR.Name = "dgvSFR"
        Me.dgvSFR.Size = New System.Drawing.Size(1083, 198)
        Me.dgvSFR.TabIndex = 1
        '
        'Upload
        '
        Me.Upload.HeaderText = "Upload"
        Me.Upload.Name = "Upload"
        Me.Upload.Text = "Upload"
        Me.Upload.ToolTipText = "Upload"
        Me.Upload.UseColumnTextForLinkValue = True
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.Text = "View"
        Me.View.ToolTipText = "View"
        Me.View.UseColumnTextForLinkValue = True
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        '
        'Request
        '
        Me.Request.HeaderText = "Request"
        Me.Request.Items.AddRange(New Object() {"REQUEST", "IGNORE"})
        Me.Request.Name = "Request"
        Me.Request.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Request.ToolTipText = "Request"
        '
        'Submit
        '
        Me.Submit.HeaderText = "Submit"
        Me.Submit.Name = "Submit"
        Me.Submit.Text = "Submit"
        Me.Submit.ToolTipText = "Submit"
        Me.Submit.UseColumnTextForLinkValue = True
        '
        'gbPendingDecision
        '
        Me.gbPendingDecision.Controls.Add(Me.dgvPendingDecision)
        Me.gbPendingDecision.Location = New System.Drawing.Point(3, 484)
        Me.gbPendingDecision.Name = "gbPendingDecision"
        Me.gbPendingDecision.Size = New System.Drawing.Size(1086, 203)
        Me.gbPendingDecision.TabIndex = 18
        Me.gbPendingDecision.TabStop = False
        Me.gbPendingDecision.Text = "Short Fall Details (Confirmed / Pending Decision) "
        '
        'dgvPendingDecision
        '
        Me.dgvPendingDecision.AllowUserToAddRows = False
        Me.dgvPendingDecision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendingDecision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingDecision.Location = New System.Drawing.Point(3, 16)
        Me.dgvPendingDecision.Name = "dgvPendingDecision"
        Me.dgvPendingDecision.Size = New System.Drawing.Size(1080, 184)
        Me.dgvPendingDecision.TabIndex = 0
        '
        'gbPa
        '
        Me.gbPa.Controls.Add(Me.dgvPendingConfirmation)
        Me.gbPa.Location = New System.Drawing.Point(3, 249)
        Me.gbPa.Name = "gbPa"
        Me.gbPa.Size = New System.Drawing.Size(1086, 229)
        Me.gbPa.TabIndex = 17
        Me.gbPa.TabStop = False
        Me.gbPa.Text = "Short Fall Pending Confirmation"
        '
        'dgvPendingConfirmation
        '
        Me.dgvPendingConfirmation.AllowUserToAddRows = False
        Me.dgvPendingConfirmation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendingConfirmation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcView, Me.Confirm})
        Me.dgvPendingConfirmation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingConfirmation.Location = New System.Drawing.Point(3, 16)
        Me.dgvPendingConfirmation.Name = "dgvPendingConfirmation"
        Me.dgvPendingConfirmation.Size = New System.Drawing.Size(1080, 210)
        Me.dgvPendingConfirmation.TabIndex = 0
        '
        'pcView
        '
        Me.pcView.HeaderText = "View"
        Me.pcView.Name = "pcView"
        Me.pcView.Text = "View"
        Me.pcView.ToolTipText = "View"
        Me.pcView.UseColumnTextForLinkValue = True
        '
        'Confirm
        '
        Me.Confirm.HeaderText = "Confirm"
        Me.Confirm.Name = "Confirm"
        Me.Confirm.Text = "Confirm"
        Me.Confirm.ToolTipText = "Confirm"
        Me.Confirm.UseColumnTextForLinkValue = True
        '
        'frmShortfallRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 691)
        Me.Controls.Add(Me.gbPendingDecision)
        Me.Controls.Add(Me.gbPa)
        Me.Controls.Add(Me.gbRe_Assign)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "frmShortfallRequest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Fall Details"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.gbRe_Assign.ResumeLayout(False)
        CType(Me.dgvSFR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPendingDecision.ResumeLayout(False)
        CType(Me.dgvPendingDecision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPa.ResumeLayout(False)
        CType(Me.dgvPendingConfirmation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblTot As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbRe_Assign As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSFR As System.Windows.Forms.DataGridView
    Friend WithEvents gbPendingDecision As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPendingDecision As System.Windows.Forms.DataGridView
    Friend WithEvents gbPa As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPendingConfirmation As System.Windows.Forms.DataGridView
    Friend WithEvents pcView As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Confirm As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Upload As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Request As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Submit As System.Windows.Forms.DataGridViewLinkColumn
End Class
