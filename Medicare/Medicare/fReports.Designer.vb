<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fReports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fReports))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.tscbStaffName = New System.Windows.Forms.ToolStripComboBox
        Me.tsReport_lblDate_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_From = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblDate_To = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_To = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.gbStaffActivity = New System.Windows.Forms.GroupBox
        Me.dgvStaffActivityDetails = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        Me.gbStaffActivity.SuspendLayout()
        CType(Me.dgvStaffActivityDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.tscbStaffName, Me.tsReport_lblDate_From, Me.tsReport_txtDate_From, Me.tsReport_lblDate_To, Me.tsReport_txtDate_To, Me.tsReport_Go, Me.tsReport_Div1, Me.tsbXport2Xcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(808, 25)
        Me.tsReport.TabIndex = 8
        Me.tsReport.Text = "ToolStrip"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(71, 22)
        Me.ToolStripLabel1.Text = "Staff Name  :"
        '
        'tscbStaffName
        '
        Me.tscbStaffName.Name = "tscbStaffName"
        Me.tscbStaffName.Size = New System.Drawing.Size(121, 25)
        '
        'tsReport_lblDate_From
        '
        Me.tsReport_lblDate_From.Name = "tsReport_lblDate_From"
        Me.tsReport_lblDate_From.Size = New System.Drawing.Size(139, 22)
        Me.tsReport_lblDate_From.Text = "Date - From (dd/mm/yyyy):"
        '
        'tsReport_txtDate_From
        '
        Me.tsReport_txtDate_From.MaxLength = 10
        Me.tsReport_txtDate_From.Name = "tsReport_txtDate_From"
        Me.tsReport_txtDate_From.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_lblDate_To
        '
        Me.tsReport_lblDate_To.Name = "tsReport_lblDate_To"
        Me.tsReport_lblDate_To.Size = New System.Drawing.Size(127, 22)
        Me.tsReport_lblDate_To.Text = "Date - To (dd/mm/yyyy):"
        '
        'tsReport_txtDate_To
        '
        Me.tsReport_txtDate_To.MaxLength = 10
        Me.tsReport_txtDate_To.Name = "tsReport_txtDate_To"
        Me.tsReport_txtDate_To.Size = New System.Drawing.Size(100, 25)
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
        'tsbXport2Xcel
        '
        Me.tsbXport2Xcel.Image = CType(resources.GetObject("tsbXport2Xcel.Image"), System.Drawing.Image)
        Me.tsbXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbXport2Xcel.Name = "tsbXport2Xcel"
        Me.tsbXport2Xcel.Size = New System.Drawing.Size(100, 22)
        Me.tsbXport2Xcel.Text = "Export to Excel"
        '
        'gbStaffActivity
        '
        Me.gbStaffActivity.Controls.Add(Me.dgvStaffActivityDetails)
        Me.gbStaffActivity.Location = New System.Drawing.Point(12, 28)
        Me.gbStaffActivity.Name = "gbStaffActivity"
        Me.gbStaffActivity.Size = New System.Drawing.Size(784, 336)
        Me.gbStaffActivity.TabIndex = 9
        Me.gbStaffActivity.TabStop = False
        Me.gbStaffActivity.Text = "Staff Activity Details"
        '
        'dgvStaffActivityDetails
        '
        Me.dgvStaffActivityDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStaffActivityDetails.Location = New System.Drawing.Point(17, 30)
        Me.dgvStaffActivityDetails.Name = "dgvStaffActivityDetails"
        Me.dgvStaffActivityDetails.Size = New System.Drawing.Size(750, 288)
        Me.dgvStaffActivityDetails.TabIndex = 0
        '
        'fReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 376)
        Me.Controls.Add(Me.gbStaffActivity)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Staff Activities"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.gbStaffActivity.ResumeLayout(False)
        CType(Me.dgvStaffActivityDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblDate_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDate_From As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_lblDate_To As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDate_To As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbXport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbStaffName As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents gbStaffActivity As System.Windows.Forms.GroupBox
    Friend WithEvents dgvStaffActivityDetails As System.Windows.Forms.DataGridView
End Class
