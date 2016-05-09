<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xWrongPremium
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(xWrongPremium))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsSearchBy1 = New System.Windows.Forms.ToolStripLabel
        Me.tstxt_SearchBy1 = New System.Windows.Forms.ToolStripTextBox
        Me.tslblSearchBy2 = New System.Windows.Forms.ToolStripLabel
        Me.tstxt_SearchBy2 = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtn_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtn_Export = New System.Windows.Forms.ToolStripButton
        Me.lblPTYPE = New System.Windows.Forms.Label
        Me.dgvBlank = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        CType(Me.dgvBlank, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSearchBy1, Me.tstxt_SearchBy1, Me.tslblSearchBy2, Me.tstxt_SearchBy2, Me.tsbtn_Go, Me.tsReport_Div1, Me.tsbtn_Export})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(877, 25)
        Me.tsReport.TabIndex = 6
        Me.tsReport.Text = "ToolStrip"
        '
        'tsSearchBy1
        '
        Me.tsSearchBy1.Name = "tsSearchBy1"
        Me.tsSearchBy1.Size = New System.Drawing.Size(113, 22)
        Me.tsSearchBy1.Text = "Deduction Code From "
        '
        'tstxt_SearchBy1
        '
        Me.tstxt_SearchBy1.MaxLength = 10
        Me.tstxt_SearchBy1.Name = "tstxt_SearchBy1"
        Me.tstxt_SearchBy1.Size = New System.Drawing.Size(100, 25)
        '
        'tslblSearchBy2
        '
        Me.tslblSearchBy2.Name = "tslblSearchBy2"
        Me.tslblSearchBy2.Size = New System.Drawing.Size(98, 22)
        Me.tslblSearchBy2.Text = "Deduction Code To"
        '
        'tstxt_SearchBy2
        '
        Me.tstxt_SearchBy2.MaxLength = 10
        Me.tstxt_SearchBy2.Name = "tstxt_SearchBy2"
        Me.tstxt_SearchBy2.Size = New System.Drawing.Size(100, 25)
        '
        'tsbtn_Go
        '
        Me.tsbtn_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtn_Go.Image = CType(resources.GetObject("tsbtn_Go.Image"), System.Drawing.Image)
        Me.tsbtn_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn_Go.Name = "tsbtn_Go"
        Me.tsbtn_Go.Size = New System.Drawing.Size(24, 22)
        Me.tsbtn_Go.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtn_Export
        '
        Me.tsbtn_Export.Image = CType(resources.GetObject("tsbtn_Export.Image"), System.Drawing.Image)
        Me.tsbtn_Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn_Export.Name = "tsbtn_Export"
        Me.tsbtn_Export.Size = New System.Drawing.Size(59, 22)
        Me.tsbtn_Export.Text = "Export"
        '
        'lblPTYPE
        '
        Me.lblPTYPE.AutoSize = True
        Me.lblPTYPE.Location = New System.Drawing.Point(823, 532)
        Me.lblPTYPE.Name = "lblPTYPE"
        Me.lblPTYPE.Size = New System.Drawing.Size(42, 13)
        Me.lblPTYPE.TabIndex = 19
        Me.lblPTYPE.Text = "PTYPE"
        Me.lblPTYPE.Visible = False
        '
        'dgvBlank
        '
        Me.dgvBlank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBlank.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBlank.Location = New System.Drawing.Point(0, 25)
        Me.dgvBlank.Name = "dgvBlank"
        Me.dgvBlank.Size = New System.Drawing.Size(877, 529)
        Me.dgvBlank.TabIndex = 18
        '
        'xWrongPremium
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 554)
        Me.Controls.Add(Me.lblPTYPE)
        Me.Controls.Add(Me.dgvBlank)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "xWrongPremium"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export Wrong Premium"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvBlank, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsSearchBy1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxt_SearchBy1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tslblSearchBy2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxt_SearchBy2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbtn_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtn_Export As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPTYPE As System.Windows.Forms.Label
    Friend WithEvents dgvBlank As System.Windows.Forms.DataGridView
End Class
