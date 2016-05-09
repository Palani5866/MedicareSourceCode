<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ccPremiumSummaryReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ccPremiumSummaryReport))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsbtnExporttoExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvPSR = New System.Windows.Forms.DataGridView
        Me.PLANCODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.F18TO55 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.F56TO60 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.I18TO55 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.I56TO60 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsReport.SuspendLayout()
        CType(Me.dgvPSR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnExporttoExcel, Me.ToolStripSeparator1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsReport.Size = New System.Drawing.Size(1017, 25)
        Me.tsReport.TabIndex = 16
        Me.tsReport.Text = "ToolStrip"
        '
        'tsbtnExporttoExcel
        '
        Me.tsbtnExporttoExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnExporttoExcel.Image = CType(resources.GetObject("tsbtnExporttoExcel.Image"), System.Drawing.Image)
        Me.tsbtnExporttoExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExporttoExcel.Name = "tsbtnExporttoExcel"
        Me.tsbtnExporttoExcel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsbtnExporttoExcel.Size = New System.Drawing.Size(84, 22)
        Me.tsbtnExporttoExcel.Text = "Export to Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'dgvPSR
        '
        Me.dgvPSR.AllowUserToAddRows = False
        Me.dgvPSR.AllowUserToDeleteRows = False
        Me.dgvPSR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPSR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PLANCODE, Me.F18TO55, Me.F56TO60, Me.I18TO55, Me.I56TO60})
        Me.dgvPSR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPSR.Location = New System.Drawing.Point(0, 25)
        Me.dgvPSR.Name = "dgvPSR"
        Me.dgvPSR.ReadOnly = True
        Me.dgvPSR.Size = New System.Drawing.Size(1017, 487)
        Me.dgvPSR.TabIndex = 17
        '
        'PLANCODE
        '
        Me.PLANCODE.DataPropertyName = "plancode"
        Me.PLANCODE.HeaderText = "PLAN CODE"
        Me.PLANCODE.Name = "PLANCODE"
        Me.PLANCODE.ReadOnly = True
        '
        'F18TO55
        '
        Me.F18TO55.DataPropertyName = "F18TO55"
        Me.F18TO55.HeaderText = "FAMILY 18 TO 55"
        Me.F18TO55.Name = "F18TO55"
        Me.F18TO55.ReadOnly = True
        Me.F18TO55.Text = "View"
        Me.F18TO55.ToolTipText = "View"
        '
        'F56TO60
        '
        Me.F56TO60.DataPropertyName = "F56TO60"
        Me.F56TO60.HeaderText = "FAMILY 56 TO 60"
        Me.F56TO60.Name = "F56TO60"
        Me.F56TO60.ReadOnly = True
        '
        'I18TO55
        '
        Me.I18TO55.DataPropertyName = "I18TO55"
        Me.I18TO55.HeaderText = "INDIVIDUAL 18 TO 55"
        Me.I18TO55.Name = "I18TO55"
        Me.I18TO55.ReadOnly = True
        '
        'I56TO60
        '
        Me.I56TO60.DataPropertyName = "I56TO60"
        Me.I56TO60.HeaderText = "INDIVIDUAL 56 TO 60"
        Me.I56TO60.Name = "I56TO60"
        Me.I56TO60.ReadOnly = True
        '
        'ccPremiumSummaryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 512)
        Me.Controls.Add(Me.dgvPSR)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ccPremiumSummaryReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Premium Summary Report (Cuepacsc Care)"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvPSR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnExporttoExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvPSR As System.Windows.Forms.DataGridView
    Friend WithEvents PLANCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F18TO55 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents F56TO60 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents I18TO55 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents I56TO60 As System.Windows.Forms.DataGridViewLinkColumn
End Class
