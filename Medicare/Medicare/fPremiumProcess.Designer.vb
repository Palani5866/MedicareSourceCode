<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPremiumProcess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fPremiumProcess))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblMonth = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_ddlMonth = New System.Windows.Forms.ToolStripComboBox
        Me.btnSubmit = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.colDeduction_BatchSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.lblREF1 = New System.Windows.Forms.Label
        Me.lblREF2 = New System.Windows.Forms.Label
        Me.tsReport.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblMonth, Me.tsReport_ddlMonth, Me.btnSubmit, Me.tsReport_Div1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(809, 25)
        Me.tsReport.TabIndex = 3
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblMonth
        '
        Me.tsReport_lblMonth.Name = "tsReport_lblMonth"
        Me.tsReport_lblMonth.Size = New System.Drawing.Size(127, 22)
        Me.tsReport_lblMonth.Text = "Premium Process Month :"
        '
        'tsReport_ddlMonth
        '
        Me.tsReport_ddlMonth.Name = "tsReport_ddlMonth"
        Me.tsReport_ddlMonth.Size = New System.Drawing.Size(75, 25)
        '
        'btnSubmit
        '
        Me.btnSubmit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSubmit.Image = CType(resources.GetObject("btnSubmit.Image"), System.Drawing.Image)
        Me.btnSubmit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(43, 22)
        Me.btnSubmit.Text = "Submit"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'dgvForm
        '
        Me.dgvForm.AllowUserToAddRows = False
        Me.dgvForm.AllowUserToDeleteRows = False
        Me.dgvForm.AllowUserToOrderColumns = True
        Me.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvForm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDeduction_BatchSelected})
        Me.dgvForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvForm.Location = New System.Drawing.Point(0, 25)
        Me.dgvForm.MultiSelect = False
        Me.dgvForm.Name = "dgvForm"
        Me.dgvForm.Size = New System.Drawing.Size(809, 503)
        Me.dgvForm.TabIndex = 8
        '
        'colDeduction_BatchSelected
        '
        Me.colDeduction_BatchSelected.FalseValue = "F"
        Me.colDeduction_BatchSelected.HeaderText = "(Tick)"
        Me.colDeduction_BatchSelected.IndeterminateValue = ""
        Me.colDeduction_BatchSelected.Name = "colDeduction_BatchSelected"
        Me.colDeduction_BatchSelected.TrueValue = "T"
        Me.colDeduction_BatchSelected.Width = 50
        '
        'lblREF1
        '
        Me.lblREF1.AutoSize = True
        Me.lblREF1.Location = New System.Drawing.Point(365, 171)
        Me.lblREF1.Name = "lblREF1"
        Me.lblREF1.Size = New System.Drawing.Size(34, 13)
        Me.lblREF1.TabIndex = 9
        Me.lblREF1.Text = "REF1"
        Me.lblREF1.Visible = False
        '
        'lblREF2
        '
        Me.lblREF2.AutoSize = True
        Me.lblREF2.Location = New System.Drawing.Point(428, 171)
        Me.lblREF2.Name = "lblREF2"
        Me.lblREF2.Size = New System.Drawing.Size(34, 13)
        Me.lblREF2.TabIndex = 10
        Me.lblREF2.Text = "REF2"
        Me.lblREF2.Visible = False
        '
        'fPremiumProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 528)
        Me.Controls.Add(Me.lblREF2)
        Me.Controls.Add(Me.lblREF1)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fPremiumProcess"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Premium Process"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblMonth As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_ddlMonth As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnSubmit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents colDeduction_BatchSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lblREF1 As System.Windows.Forms.Label
    Friend WithEvents lblREF2 As System.Windows.Forms.Label
End Class
