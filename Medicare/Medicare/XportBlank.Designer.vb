<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XportBlank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XportBlank))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsSearchBy = New System.Windows.Forms.ToolStripLabel
        Me.tscbSearchBy = New System.Windows.Forms.ToolStripComboBox
        Me.tsSearchBy1 = New System.Windows.Forms.ToolStripLabel
        Me.tscb_SearchBy1 = New System.Windows.Forms.ToolStripComboBox
        Me.tsbtn_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtn_Export = New System.Windows.Forms.ToolStripButton
        Me.ssReport = New System.Windows.Forms.StatusStrip
        Me.ssReport_RecordCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ssReport_Parameter = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvBlank = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        Me.ssReport.SuspendLayout()
        CType(Me.dgvBlank, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSearchBy, Me.tscbSearchBy, Me.tsSearchBy1, Me.tscb_SearchBy1, Me.tsbtn_Go, Me.tsReport_Div1, Me.tsbtn_Export})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(926, 25)
        Me.tsReport.TabIndex = 4
        Me.tsReport.Text = "ToolStrip"
        '
        'tsSearchBy
        '
        Me.tsSearchBy.Name = "tsSearchBy"
        Me.tsSearchBy.Size = New System.Drawing.Size(166, 22)
        Me.tsSearchBy.Text = "Search By (Member/Spouse/Dep)"
        '
        'tscbSearchBy
        '
        Me.tscbSearchBy.Items.AddRange(New Object() {"", "MEMBER", "SPOUSE", "DEPENDENTS"})
        Me.tscbSearchBy.MaxLength = 10
        Me.tscbSearchBy.Name = "tscbSearchBy"
        Me.tscbSearchBy.Size = New System.Drawing.Size(150, 25)
        '
        'tsSearchBy1
        '
        Me.tsSearchBy1.Name = "tsSearchBy1"
        Me.tsSearchBy1.Size = New System.Drawing.Size(102, 22)
        Me.tsSearchBy1.Text = "Search By (IC/DOB)"
        '
        'tscb_SearchBy1
        '
        Me.tscb_SearchBy1.Items.AddRange(New Object() {"", "IC", "DOB", "PHONE"})
        Me.tscb_SearchBy1.MaxLength = 10
        Me.tscb_SearchBy1.Name = "tscb_SearchBy1"
        Me.tscb_SearchBy1.Size = New System.Drawing.Size(100, 25)
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
        'ssReport
        '
        Me.ssReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssReport_RecordCount, Me.ssReport_Parameter})
        Me.ssReport.Location = New System.Drawing.Point(0, 500)
        Me.ssReport.Name = "ssReport"
        Me.ssReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssReport.Size = New System.Drawing.Size(926, 22)
        Me.ssReport.TabIndex = 14
        Me.ssReport.Text = "StatusStrip"
        '
        'ssReport_RecordCount
        '
        Me.ssReport_RecordCount.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ssReport_RecordCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ssReport_RecordCount.Name = "ssReport_RecordCount"
        Me.ssReport_RecordCount.Size = New System.Drawing.Size(4, 17)
        Me.ssReport_RecordCount.Visible = False
        '
        'ssReport_Parameter
        '
        Me.ssReport_Parameter.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ssReport_Parameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ssReport_Parameter.Name = "ssReport_Parameter"
        Me.ssReport_Parameter.Size = New System.Drawing.Size(4, 17)
        Me.ssReport_Parameter.Visible = False
        '
        'dgvBlank
        '
        Me.dgvBlank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBlank.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBlank.Location = New System.Drawing.Point(0, 25)
        Me.dgvBlank.Name = "dgvBlank"
        Me.dgvBlank.Size = New System.Drawing.Size(926, 475)
        Me.dgvBlank.TabIndex = 15
        '
        'XportBlank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 522)
        Me.Controls.Add(Me.dgvBlank)
        Me.Controls.Add(Me.ssReport)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "XportBlank"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export Blank "
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.ssReport.ResumeLayout(False)
        Me.ssReport.PerformLayout()
        CType(Me.dgvBlank, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsSearchBy As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsbtn_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtn_Export As System.Windows.Forms.ToolStripButton
    Friend WithEvents tscbSearchBy As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tscb_SearchBy1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsSearchBy1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ssReport As System.Windows.Forms.StatusStrip
    Friend WithEvents ssReport_RecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssReport_Parameter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvBlank As System.Windows.Forms.DataGridView
End Class
