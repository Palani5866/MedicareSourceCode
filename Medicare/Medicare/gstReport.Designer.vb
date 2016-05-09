<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gstReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gstReport))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslblRMonth = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_ddlMonth = New System.Windows.Forms.ToolStripComboBox
        Me.btnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvGST = New System.Windows.Forms.DataGridView
        Me.btnExport2Excel = New System.Windows.Forms.ToolStripButton
        Me.tsReport.SuspendLayout()
        CType(Me.dgvGST, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblRMonth, Me.tsReport_ddlMonth, Me.btnGo, Me.tsReport_Div1, Me.btnExport2Excel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1022, 25)
        Me.tsReport.TabIndex = 4
        Me.tsReport.Text = "ToolStrip"
        '
        'tslblRMonth
        '
        Me.tslblRMonth.Name = "tslblRMonth"
        Me.tslblRMonth.Size = New System.Drawing.Size(93, 22)
        Me.tslblRMonth.Text = "Receiving Month :"
        '
        'tsReport_ddlMonth
        '
        Me.tsReport_ddlMonth.Name = "tsReport_ddlMonth"
        Me.tsReport_ddlMonth.Size = New System.Drawing.Size(75, 25)
        '
        'btnGo
        '
        Me.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(32, 22)
        Me.btnGo.Text = "Go.."
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'dgvGST
        '
        Me.dgvGST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGST.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGST.Location = New System.Drawing.Point(0, 25)
        Me.dgvGST.Name = "dgvGST"
        Me.dgvGST.Size = New System.Drawing.Size(1022, 415)
        Me.dgvGST.TabIndex = 5
        '
        'btnExport2Excel
        '
        Me.btnExport2Excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnExport2Excel.Image = CType(resources.GetObject("btnExport2Excel.Image"), System.Drawing.Image)
        Me.btnExport2Excel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport2Excel.Name = "btnExport2Excel"
        Me.btnExport2Excel.Size = New System.Drawing.Size(84, 22)
        Me.btnExport2Excel.Text = "Export to Excel"
        '
        'gstReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 440)
        Me.Controls.Add(Me.dgvGST)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "gstReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GST Report"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvGST, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblRMonth As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_ddlMonth As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExport2Excel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvGST As System.Windows.Forms.DataGridView
End Class
