<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdProposer2Submit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(grdProposer2Submit))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_ProcessSubmission = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_ProcessSubmission_Yearly = New System.Windows.Forms.ToolStripButton
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.colDeduction_BatchSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.lblParam = New System.Windows.Forms.Label
        Me.tolForm.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_ProcessSubmission, Me.ToolStripSeparator1, Me.tsb_ProcessSubmission_Yearly})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(784, 25)
        Me.tolForm.TabIndex = 0
        Me.tolForm.Text = "ToolStrip1"
        '
        'tsb_ProcessSubmission
        '
        Me.tsb_ProcessSubmission.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_ProcessSubmission.Image = CType(resources.GetObject("tsb_ProcessSubmission.Image"), System.Drawing.Image)
        Me.tsb_ProcessSubmission.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_ProcessSubmission.Name = "tsb_ProcessSubmission"
        Me.tsb_ProcessSubmission.Size = New System.Drawing.Size(239, 22)
        Me.tsb_ProcessSubmission.Text = "Process Submission to Salary Deduction Agency"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_ProcessSubmission_Yearly
        '
        Me.tsb_ProcessSubmission_Yearly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_ProcessSubmission_Yearly.Image = CType(resources.GetObject("tsb_ProcessSubmission_Yearly.Image"), System.Drawing.Image)
        Me.tsb_ProcessSubmission_Yearly.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_ProcessSubmission_Yearly.Name = "tsb_ProcessSubmission_Yearly"
        Me.tsb_ProcessSubmission_Yearly.Size = New System.Drawing.Size(227, 22)
        Me.tsb_ProcessSubmission_Yearly.Text = "Process Submission to Insurer (Yearly Cases)"
        Me.tsb_ProcessSubmission_Yearly.ToolTipText = "Process Submission (Yearly)"
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
        Me.dgvForm.Size = New System.Drawing.Size(784, 539)
        Me.dgvForm.TabIndex = 1
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
        'lblParam
        '
        Me.lblParam.AutoSize = True
        Me.lblParam.Location = New System.Drawing.Point(66, 551)
        Me.lblParam.Name = "lblParam"
        Me.lblParam.Size = New System.Drawing.Size(37, 13)
        Me.lblParam.TabIndex = 2
        Me.lblParam.Text = "Param"
        Me.lblParam.Visible = False
        '
        'grdProposer2Submit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.Controls.Add(Me.lblParam)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.tolForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdProposer2Submit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List of Proposers to be Submit"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_ProcessSubmission As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents colDeduction_BatchSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsb_ProcessSubmission_Yearly As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblParam As System.Windows.Forms.Label
End Class
