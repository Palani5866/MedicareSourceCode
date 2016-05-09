<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdReport_Premium_Payment2Insurer_13months
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(grdReport_Premium_Payment2Insurer_13months))
        Me.ssReport = New System.Windows.Forms.StatusStrip
        Me.ssReport_RecordCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ssReport_Parameter = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.tsReport_lblDeductionCode_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_From = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblDeductionCode_To = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_To = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.ToolStripcmbYear = New System.Windows.Forms.ToolStripComboBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Export = New System.Windows.Forms.ToolStripButton
        Me.ssReport.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssReport
        '
        Me.ssReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssReport_RecordCount, Me.ssReport_Parameter})
        Me.ssReport.Location = New System.Drawing.Point(0, 542)
        Me.ssReport.Name = "ssReport"
        Me.ssReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssReport.Size = New System.Drawing.Size(784, 22)
        Me.ssReport.TabIndex = 2
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
        Me.dgvForm.TabIndex = 4
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(33, 22)
        Me.ToolStripLabel1.Text = "Year:"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblDeductionCode_From, Me.tsReport_txtDeductionCode_From, Me.tsReport_lblDeductionCode_To, Me.tsReport_txtDeductionCode_To, Me.ToolStripLabel1, Me.ToolStripcmbYear, Me.tsReport_Go, Me.tsReport_Div1, Me.tsReport_Export})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(784, 25)
        Me.tsReport.TabIndex = 3
        Me.tsReport.Text = "c"
        '
        'ToolStripcmbYear
        '
        Me.ToolStripcmbYear.Name = "ToolStripcmbYear"
        Me.ToolStripcmbYear.Size = New System.Drawing.Size(121, 25)
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
        'tsReport_Export
        '
        Me.tsReport_Export.Image = CType(resources.GetObject("tsReport_Export.Image"), System.Drawing.Image)
        Me.tsReport_Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Export.Name = "tsReport_Export"
        Me.tsReport_Export.Size = New System.Drawing.Size(59, 22)
        Me.tsReport_Export.Text = "Export"
        '
        'grdReport_Premium_Payment2Insurer_13months
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.tsReport)
        Me.Controls.Add(Me.ssReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdReport_Premium_Payment2Insurer_13months"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report: 13-months Premium Payment Statement to Insurer"
        Me.ssReport.ResumeLayout(False)
        Me.ssReport.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssReport As System.Windows.Forms.StatusStrip
    Friend WithEvents ssReport_Parameter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssReport_RecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents tsReport_lblDeductionCode_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_From As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_lblDeductionCode_To As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_To As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsReport_Export As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripcmbYear As System.Windows.Forms.ToolStripComboBox
End Class
