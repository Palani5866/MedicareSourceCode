<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdBLANK_PolicyNo_Template_Export
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(grdBLANK_PolicyNo_Template_Export))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblDeductionCode_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_From = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblDeductionCode_To = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_To = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsReport_Export = New System.Windows.Forms.ToolStripButton
        Me.ssReport = New System.Windows.Forms.StatusStrip
        Me.ssReport_RecordCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ssReport_Parameter = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.lblRQS1 = New System.Windows.Forms.Label
        Me.tsReport.SuspendLayout()
        Me.ssReport.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblDeductionCode_From, Me.tsReport_txtDeductionCode_From, Me.tsReport_lblDeductionCode_To, Me.tsReport_txtDeductionCode_To, Me.tsReport_Go, Me.tsReport_Div1, Me.tsReport_Export})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(784, 25)
        Me.tsReport.TabIndex = 2
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblDeductionCode_From
        '
        Me.tsReport_lblDeductionCode_From.Name = "tsReport_lblDeductionCode_From"
        Me.tsReport_lblDeductionCode_From.Size = New System.Drawing.Size(121, 22)
        Me.tsReport_lblDeductionCode_From.Text = "Deduction Code - From:"
        '
        'tsReport_txtDeductionCode_From
        '
        Me.tsReport_txtDeductionCode_From.MaxLength = 10
        Me.tsReport_txtDeductionCode_From.Name = "tsReport_txtDeductionCode_From"
        Me.tsReport_txtDeductionCode_From.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_lblDeductionCode_To
        '
        Me.tsReport_lblDeductionCode_To.Name = "tsReport_lblDeductionCode_To"
        Me.tsReport_lblDeductionCode_To.Size = New System.Drawing.Size(109, 22)
        Me.tsReport_lblDeductionCode_To.Text = "Deduction Code - To:"
        '
        'tsReport_txtDeductionCode_To
        '
        Me.tsReport_txtDeductionCode_To.MaxLength = 10
        Me.tsReport_txtDeductionCode_To.Name = "tsReport_txtDeductionCode_To"
        Me.tsReport_txtDeductionCode_To.Size = New System.Drawing.Size(100, 25)
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
        'tsReport_Export
        '
        Me.tsReport_Export.Image = CType(resources.GetObject("tsReport_Export.Image"), System.Drawing.Image)
        Me.tsReport_Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Export.Name = "tsReport_Export"
        Me.tsReport_Export.Size = New System.Drawing.Size(59, 22)
        Me.tsReport_Export.Text = "Export"
        '
        'ssReport
        '
        Me.ssReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssReport_RecordCount, Me.ssReport_Parameter})
        Me.ssReport.Location = New System.Drawing.Point(0, 542)
        Me.ssReport.Name = "ssReport"
        Me.ssReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssReport.Size = New System.Drawing.Size(784, 22)
        Me.ssReport.TabIndex = 4
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
        Me.dgvForm.TabIndex = 8
        '
        'lblRQS1
        '
        Me.lblRQS1.AutoSize = True
        Me.lblRQS1.Location = New System.Drawing.Point(424, 310)
        Me.lblRQS1.Name = "lblRQS1"
        Me.lblRQS1.Size = New System.Drawing.Size(30, 13)
        Me.lblRQS1.TabIndex = 9
        Me.lblRQS1.Text = "RQS"
        Me.lblRQS1.Visible = False
        '
        'grdBLANK_PolicyNo_Template_Export
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.Controls.Add(Me.lblRQS1)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.ssReport)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdBLANK_PolicyNo_Template_Export"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export Template: BLANK Policy/Certificate No"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.ssReport.ResumeLayout(False)
        Me.ssReport.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsReport_Export As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssReport As System.Windows.Forms.StatusStrip
    Friend WithEvents ssReport_RecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssReport_Parameter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsReport_lblDeductionCode_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_From As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_lblDeductionCode_To As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_To As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents lblRQS1 As System.Windows.Forms.Label
End Class
