<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PremiumSummaryReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PremiumSummaryReport))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsbtnExporttoExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvPSR = New System.Windows.Forms.DataGridView
        Me.PLANCODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pamember = New System.Windows.Forms.DataGridViewLinkColumn
        Me.paspouse = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pachild12 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pachild18 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pachild23 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.paachild23 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pbmember = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pbspouse = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pbchild12 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pbchild18 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pbchild23 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pbachild23 = New System.Windows.Forms.DataGridViewLinkColumn
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
        Me.tsReport.Size = New System.Drawing.Size(961, 25)
        Me.tsReport.TabIndex = 15
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
        Me.dgvPSR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PLANCODE, Me.pamember, Me.paspouse, Me.pachild12, Me.pachild18, Me.pachild23, Me.paachild23, Me.pbmember, Me.pbspouse, Me.pbchild12, Me.pbchild18, Me.pbchild23, Me.pbachild23})
        Me.dgvPSR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPSR.Location = New System.Drawing.Point(0, 25)
        Me.dgvPSR.Name = "dgvPSR"
        Me.dgvPSR.ReadOnly = True
        Me.dgvPSR.Size = New System.Drawing.Size(961, 459)
        Me.dgvPSR.TabIndex = 16
        '
        'PLANCODE
        '
        Me.PLANCODE.DataPropertyName = "plancode"
        Me.PLANCODE.HeaderText = "PLAN CODE"
        Me.PLANCODE.Name = "PLANCODE"
        Me.PLANCODE.ReadOnly = True
        '
        'pamember
        '
        Me.pamember.DataPropertyName = "pamember"
        Me.pamember.HeaderText = "MEMBER"
        Me.pamember.Name = "pamember"
        Me.pamember.ReadOnly = True
        Me.pamember.Text = "View"
        Me.pamember.ToolTipText = "View"
        '
        'paspouse
        '
        Me.paspouse.DataPropertyName = "paspouse"
        Me.paspouse.HeaderText = "SPOUSE"
        Me.paspouse.Name = "paspouse"
        Me.paspouse.ReadOnly = True
        '
        'pachild12
        '
        Me.pachild12.DataPropertyName = "pachild12"
        Me.pachild12.HeaderText = "CHILD UNDER 12"
        Me.pachild12.Name = "pachild12"
        Me.pachild12.ReadOnly = True
        '
        'pachild18
        '
        Me.pachild18.DataPropertyName = "pachild18"
        Me.pachild18.HeaderText = "CHILD UNDER 18"
        Me.pachild18.Name = "pachild18"
        Me.pachild18.ReadOnly = True
        '
        'pachild23
        '
        Me.pachild23.DataPropertyName = "pachild23"
        Me.pachild23.HeaderText = "CHILD UNDER 23"
        Me.pachild23.Name = "pachild23"
        Me.pachild23.ReadOnly = True
        '
        'paachild23
        '
        Me.paachild23.DataPropertyName = "paachild23"
        Me.paachild23.HeaderText = "CHILD ABOVE 23"
        Me.paachild23.Name = "paachild23"
        Me.paachild23.ReadOnly = True
        '
        'pbmember
        '
        Me.pbmember.DataPropertyName = "pbmember"
        Me.pbmember.HeaderText = "MEMBER"
        Me.pbmember.Name = "pbmember"
        Me.pbmember.ReadOnly = True
        '
        'pbspouse
        '
        Me.pbspouse.DataPropertyName = "pbspouse"
        Me.pbspouse.HeaderText = "SPOUSE"
        Me.pbspouse.Name = "pbspouse"
        Me.pbspouse.ReadOnly = True
        '
        'pbchild12
        '
        Me.pbchild12.DataPropertyName = "pbchild12"
        Me.pbchild12.HeaderText = "CHILD UNDER 12"
        Me.pbchild12.Name = "pbchild12"
        Me.pbchild12.ReadOnly = True
        '
        'pbchild18
        '
        Me.pbchild18.DataPropertyName = "pbchild18"
        Me.pbchild18.HeaderText = "CHILD UNDER 18"
        Me.pbchild18.Name = "pbchild18"
        Me.pbchild18.ReadOnly = True
        '
        'pbchild23
        '
        Me.pbchild23.DataPropertyName = "pbchild23"
        Me.pbchild23.HeaderText = "CHILD UNDER 23"
        Me.pbchild23.Name = "pbchild23"
        Me.pbchild23.ReadOnly = True
        '
        'pbachild23
        '
        Me.pbachild23.DataPropertyName = "pbachild23"
        Me.pbachild23.HeaderText = "CHILD ABOVE 23"
        Me.pbachild23.Name = "pbachild23"
        Me.pbachild23.ReadOnly = True
        '
        'PremiumSummaryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 484)
        Me.Controls.Add(Me.dgvPSR)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "PremiumSummaryReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Premium Summary Report"
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
    Friend WithEvents pamember As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents paspouse As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pachild12 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pachild18 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pachild23 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents paachild23 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pbmember As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pbspouse As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pbchild12 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pbchild18 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pbchild23 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pbachild23 As System.Windows.Forms.DataGridViewLinkColumn
End Class
