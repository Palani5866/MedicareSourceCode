<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rYrlySummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rYrlySummary))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslblYr = New System.Windows.Forms.ToolStripLabel
        Me.tsddlYr = New System.Windows.Forms.ToolStripComboBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvYS = New System.Windows.Forms.DataGridView
        Me.tsbtnXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.tsReport.SuspendLayout()
        CType(Me.dgvYS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblYr, Me.tsddlYr, Me.tsReport_Go, Me.tsReport_Div1, Me.tsbtnXport2Xcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(866, 25)
        Me.tsReport.TabIndex = 4
        Me.tsReport.Text = "ToolStrip"
        '
        'tslblYr
        '
        Me.tslblYr.Name = "tslblYr"
        Me.tslblYr.Size = New System.Drawing.Size(36, 22)
        Me.tslblYr.Text = "Year :"
        '
        'tsddlYr
        '
        Me.tsddlYr.Name = "tsddlYr"
        Me.tsddlYr.Size = New System.Drawing.Size(125, 25)
        '
        'tsReport_Go
        '
        Me.tsReport_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsReport_Go.Image = CType(resources.GetObject("tsReport_Go.Image"), System.Drawing.Image)
        Me.tsReport_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Go.Name = "tsReport_Go"
        Me.tsReport_Go.Size = New System.Drawing.Size(24, 22)
        Me.tsReport_Go.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'dgvYS
        '
        Me.dgvYS.AllowUserToAddRows = False
        Me.dgvYS.AllowUserToDeleteRows = False
        Me.dgvYS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvYS.Location = New System.Drawing.Point(0, 25)
        Me.dgvYS.Name = "dgvYS"
        Me.dgvYS.ReadOnly = True
        Me.dgvYS.Size = New System.Drawing.Size(866, 345)
        Me.dgvYS.TabIndex = 5
        '
        'tsbtnXport2Xcel
        '
        Me.tsbtnXport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnXport2Xcel.Image = CType(resources.GetObject("tsbtnXport2Xcel.Image"), System.Drawing.Image)
        Me.tsbtnXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnXport2Xcel.Name = "tsbtnXport2Xcel"
        Me.tsbtnXport2Xcel.Size = New System.Drawing.Size(84, 22)
        Me.tsbtnXport2Xcel.Text = "Export to Excel"
        '
        'rYrlySummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 370)
        Me.Controls.Add(Me.dgvYS)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "rYrlySummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Yearly Summary Report"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvYS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblYr As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsddlYr As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvYS As System.Windows.Forms.DataGridView
    Friend WithEvents tsbtnXport2Xcel As System.Windows.Forms.ToolStripButton
End Class
