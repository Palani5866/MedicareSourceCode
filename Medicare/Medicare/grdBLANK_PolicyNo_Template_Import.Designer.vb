<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdBLANK_PolicyNo_Template_Import
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(grdBLANK_PolicyNo_Template_Import))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslblPPDate = New System.Windows.Forms.ToolStripLabel
        Me.tstxtPPDate = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_File_Open = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsReport_Import = New System.Windows.Forms.ToolStripButton
        Me.ssReport = New System.Windows.Forms.StatusStrip
        Me.ssReport_RecordCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ssReport_Parameter = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.ofdCert2Upload = New System.Windows.Forms.OpenFileDialog
        Me.lblRQS1 = New System.Windows.Forms.Label
        Me.tstxtPEDate = New System.Windows.Forms.ToolStripTextBox
        Me.tslblPEDate = New System.Windows.Forms.ToolStripLabel
        Me.tsReport.SuspendLayout()
        Me.ssReport.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblPPDate, Me.tstxtPPDate, Me.tslblPEDate, Me.tstxtPEDate, Me.tsReport_File_Open, Me.tsReport_Div1, Me.tsReport_Import})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(784, 25)
        Me.tsReport.TabIndex = 3
        Me.tsReport.Text = "ToolStrip"
        '
        'tslblPPDate
        '
        Me.tslblPPDate.Name = "tslblPPDate"
        Me.tslblPPDate.Size = New System.Drawing.Size(174, 22)
        Me.tslblPPDate.Text = "Policy Posted Date  (dd/mm/yyyy):"
        '
        'tstxtPPDate
        '
        Me.tstxtPPDate.MaxLength = 10
        Me.tstxtPPDate.Name = "tstxtPPDate"
        Me.tstxtPPDate.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_File_Open
        '
        Me.tsReport_File_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsReport_File_Open.Image = CType(resources.GetObject("tsReport_File_Open.Image"), System.Drawing.Image)
        Me.tsReport_File_Open.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_File_Open.Name = "tsReport_File_Open"
        Me.tsReport_File_Open.Size = New System.Drawing.Size(23, 22)
        Me.tsReport_File_Open.Text = "&Open"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsReport_Import
        '
        Me.tsReport_Import.Image = CType(resources.GetObject("tsReport_Import.Image"), System.Drawing.Image)
        Me.tsReport_Import.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Import.Name = "tsReport_Import"
        Me.tsReport_Import.Size = New System.Drawing.Size(96, 22)
        Me.tsReport_Import.Text = "Import/Upload"
        '
        'ssReport
        '
        Me.ssReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssReport_RecordCount, Me.ssReport_Parameter})
        Me.ssReport.Location = New System.Drawing.Point(0, 542)
        Me.ssReport.Name = "ssReport"
        Me.ssReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssReport.Size = New System.Drawing.Size(784, 22)
        Me.ssReport.TabIndex = 5
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
        Me.dgvForm.ReadOnly = True
        Me.dgvForm.Size = New System.Drawing.Size(784, 517)
        Me.dgvForm.TabIndex = 9
        '
        'lblRQS1
        '
        Me.lblRQS1.AutoSize = True
        Me.lblRQS1.Location = New System.Drawing.Point(570, 365)
        Me.lblRQS1.Name = "lblRQS1"
        Me.lblRQS1.Size = New System.Drawing.Size(46, 13)
        Me.lblRQS1.TabIndex = 10
        Me.lblRQS1.Text = "lblRQS1"
        Me.lblRQS1.Visible = False
        '
        'tstxtPEDate
        '
        Me.tstxtPEDate.MaxLength = 10
        Me.tstxtPEDate.Name = "tstxtPEDate"
        Me.tstxtPEDate.Size = New System.Drawing.Size(100, 25)
        '
        'tslblPEDate
        '
        Me.tslblPEDate.Name = "tslblPEDate"
        Me.tslblPEDate.Size = New System.Drawing.Size(207, 22)
        Me.tslblPEDate.Text = "Policy No's Effective Date  (dd/mm/yyyy):"
        '
        'grdBLANK_PolicyNo_Template_Import
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.Controls.Add(Me.lblRQS1)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.ssReport)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdBLANK_PolicyNo_Template_Import"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import/Upload Template: BLANK Policy/Certificate No"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.ssReport.ResumeLayout(False)
        Me.ssReport.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsReport_Import As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssReport As System.Windows.Forms.StatusStrip
    Friend WithEvents ssReport_RecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssReport_Parameter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents tsReport_File_Open As System.Windows.Forms.ToolStripButton
    Friend WithEvents ofdCert2Upload As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tslblPPDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtPPDate As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents lblRQS1 As System.Windows.Forms.Label
    Friend WithEvents tslblPEDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtPEDate As System.Windows.Forms.ToolStripTextBox
End Class
