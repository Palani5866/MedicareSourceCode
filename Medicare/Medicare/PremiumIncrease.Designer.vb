<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PremiumIncrease
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PremiumIncrease))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblMonth = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_ddlMonth = New System.Windows.Forms.ToolStripComboBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.ssReport = New System.Windows.Forms.StatusStrip
        Me.ssReport_RecordCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ssReport_Parameter = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.lblRF1 = New System.Windows.Forms.Label
        Me.tsReport.SuspendLayout()
        Me.ssReport.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblMonth, Me.tsReport_ddlMonth, Me.tsReport_Go, Me.tsReport_Div1, Me.btnXport2Xcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1057, 25)
        Me.tsReport.TabIndex = 3
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblMonth
        '
        Me.tsReport_lblMonth.Name = "tsReport_lblMonth"
        Me.tsReport_lblMonth.Size = New System.Drawing.Size(132, 22)
        Me.tsReport_lblMonth.Text = "Premium Increase Month :"
        '
        'tsReport_ddlMonth
        '
        Me.tsReport_ddlMonth.Name = "tsReport_ddlMonth"
        Me.tsReport_ddlMonth.Size = New System.Drawing.Size(75, 25)
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
        'btnXport2Xcel
        '
        Me.btnXport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnXport2Xcel.Image = CType(resources.GetObject("btnXport2Xcel.Image"), System.Drawing.Image)
        Me.btnXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnXport2Xcel.Name = "btnXport2Xcel"
        Me.btnXport2Xcel.Size = New System.Drawing.Size(84, 22)
        Me.btnXport2Xcel.Text = "Export to Excel"
        '
        'ssReport
        '
        Me.ssReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssReport_RecordCount, Me.ssReport_Parameter})
        Me.ssReport.Location = New System.Drawing.Point(0, 452)
        Me.ssReport.Name = "ssReport"
        Me.ssReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssReport.Size = New System.Drawing.Size(1057, 22)
        Me.ssReport.TabIndex = 7
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
        'dgvForm
        '
        Me.dgvForm.AllowUserToAddRows = False
        Me.dgvForm.AllowUserToDeleteRows = False
        Me.dgvForm.AllowUserToOrderColumns = True
        Me.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvForm.Location = New System.Drawing.Point(0, 25)
        Me.dgvForm.MultiSelect = False
        Me.dgvForm.Name = "dgvForm"
        Me.dgvForm.Size = New System.Drawing.Size(1057, 427)
        Me.dgvForm.TabIndex = 8
        '
        'lblRF1
        '
        Me.lblRF1.AutoSize = True
        Me.lblRF1.Location = New System.Drawing.Point(515, 231)
        Me.lblRF1.Name = "lblRF1"
        Me.lblRF1.Size = New System.Drawing.Size(27, 13)
        Me.lblRF1.TabIndex = 9
        Me.lblRF1.Text = "RF1"
        Me.lblRF1.Visible = False
        '
        'PremiumIncrease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 474)
        Me.Controls.Add(Me.lblRF1)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.ssReport)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "PremiumIncrease"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Premium Increase"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.ssReport.ResumeLayout(False)
        Me.ssReport.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblMonth As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_ddlMonth As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnXport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssReport As System.Windows.Forms.StatusStrip
    Friend WithEvents ssReport_RecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssReport_Parameter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents lblRF1 As System.Windows.Forms.Label
End Class
