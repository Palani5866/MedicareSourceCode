<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class r13M
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(r13M))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblDeductionCode_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_From = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblDeductionCode_To = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_To = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripcmbYear = New System.Windows.Forms.ToolStripComboBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.dgvR13M = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        CType(Me.dgvR13M, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblDeductionCode_From, Me.tsReport_txtDeductionCode_From, Me.tsReport_lblDeductionCode_To, Me.tsReport_txtDeductionCode_To, Me.ToolStripLabel1, Me.ToolStripcmbYear, Me.tsbtnGo, Me.tsReport_Div1, Me.tsXport2Xcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(844, 25)
        Me.tsReport.TabIndex = 4
        Me.tsReport.Text = "c"
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
        'ToolStripcmbYear
        '
        Me.ToolStripcmbYear.Name = "ToolStripcmbYear"
        Me.ToolStripcmbYear.Size = New System.Drawing.Size(121, 25)
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(24, 22)
        Me.tsbtnGo.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsXport2Xcel
        '
        Me.tsXport2Xcel.Image = CType(resources.GetObject("tsXport2Xcel.Image"), System.Drawing.Image)
        Me.tsXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsXport2Xcel.Name = "tsXport2Xcel"
        Me.tsXport2Xcel.Size = New System.Drawing.Size(100, 20)
        Me.tsXport2Xcel.Text = "Export to Excel"
        '
        'dgvR13M
        '
        Me.dgvR13M.AllowUserToAddRows = False
        Me.dgvR13M.AllowUserToDeleteRows = False
        Me.dgvR13M.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvR13M.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvR13M.Location = New System.Drawing.Point(0, 25)
        Me.dgvR13M.Name = "dgvR13M"
        Me.dgvR13M.ReadOnly = True
        Me.dgvR13M.Size = New System.Drawing.Size(844, 436)
        Me.dgvR13M.TabIndex = 5
        '
        'r13M
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 461)
        Me.Controls.Add(Me.dgvR13M)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "r13M"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Policy Premium Statement for Insurer"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvR13M, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblDeductionCode_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_From As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_lblDeductionCode_To As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_To As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripcmbYear As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsXport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvR13M As System.Windows.Forms.DataGridView
End Class
