<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Add_Dependant_New
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Add_Dependant_New))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_Filter = New System.Windows.Forms.ToolStripComboBox
        Me.tsb_Filter_Param = New System.Windows.Forms.ToolStripTextBox
        Me.tsb_Filter_Go = New System.Windows.Forms.ToolStripButton
        Me.gbMemberDetails = New System.Windows.Forms.GroupBox
        Me.dgvMemberDetails = New System.Windows.Forms.DataGridView
        Me.gbPolicyDetails = New System.Windows.Forms.GroupBox
        Me.dgvPolicyDetails = New System.Windows.Forms.DataGridView
        Me.lblAdmin = New System.Windows.Forms.Label
        Me.tolForm.SuspendLayout()
        Me.gbMemberDetails.SuspendLayout()
        CType(Me.dgvMemberDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPolicyDetails.SuspendLayout()
        CType(Me.dgvPolicyDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Filter, Me.tsb_Filter_Param, Me.tsb_Filter_Go})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(912, 25)
        Me.tolForm.TabIndex = 4
        Me.tolForm.Text = "ToolStrip1"
        '
        'tsb_Filter
        '
        Me.tsb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tsb_Filter.Items.AddRange(New Object() {"", "IC", "Full Name"})
        Me.tsb_Filter.Name = "tsb_Filter"
        Me.tsb_Filter.Size = New System.Drawing.Size(100, 25)
        '
        'tsb_Filter_Param
        '
        Me.tsb_Filter_Param.MaxLength = 50
        Me.tsb_Filter_Param.Name = "tsb_Filter_Param"
        Me.tsb_Filter_Param.Size = New System.Drawing.Size(250, 25)
        '
        'tsb_Filter_Go
        '
        Me.tsb_Filter_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Filter_Go.Image = CType(resources.GetObject("tsb_Filter_Go.Image"), System.Drawing.Image)
        Me.tsb_Filter_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Filter_Go.Name = "tsb_Filter_Go"
        Me.tsb_Filter_Go.Size = New System.Drawing.Size(34, 22)
        Me.tsb_Filter_Go.Text = "GO.."
        Me.tsb_Filter_Go.ToolTipText = "Go"
        '
        'gbMemberDetails
        '
        Me.gbMemberDetails.Controls.Add(Me.dgvMemberDetails)
        Me.gbMemberDetails.Location = New System.Drawing.Point(0, 54)
        Me.gbMemberDetails.Name = "gbMemberDetails"
        Me.gbMemberDetails.Size = New System.Drawing.Size(912, 167)
        Me.gbMemberDetails.TabIndex = 5
        Me.gbMemberDetails.TabStop = False
        Me.gbMemberDetails.Text = "Member Details"
        '
        'dgvMemberDetails
        '
        Me.dgvMemberDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMemberDetails.Location = New System.Drawing.Point(12, 19)
        Me.dgvMemberDetails.Name = "dgvMemberDetails"
        Me.dgvMemberDetails.Size = New System.Drawing.Size(888, 131)
        Me.dgvMemberDetails.TabIndex = 5
        '
        'gbPolicyDetails
        '
        Me.gbPolicyDetails.Controls.Add(Me.dgvPolicyDetails)
        Me.gbPolicyDetails.Location = New System.Drawing.Point(0, 250)
        Me.gbPolicyDetails.Name = "gbPolicyDetails"
        Me.gbPolicyDetails.Size = New System.Drawing.Size(912, 167)
        Me.gbPolicyDetails.TabIndex = 6
        Me.gbPolicyDetails.TabStop = False
        Me.gbPolicyDetails.Text = "Policy Details"
        '
        'dgvPolicyDetails
        '
        Me.dgvPolicyDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPolicyDetails.Location = New System.Drawing.Point(12, 19)
        Me.dgvPolicyDetails.Name = "dgvPolicyDetails"
        Me.dgvPolicyDetails.Size = New System.Drawing.Size(888, 131)
        Me.dgvPolicyDetails.TabIndex = 5
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.Location = New System.Drawing.Point(604, 424)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(35, 13)
        Me.lblAdmin.TabIndex = 7
        Me.lblAdmin.Text = "admin"
        Me.lblAdmin.Visible = False
        '
        'Add_Dependant_New
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 443)
        Me.Controls.Add(Me.lblAdmin)
        Me.Controls.Add(Me.gbPolicyDetails)
        Me.Controls.Add(Me.gbMemberDetails)
        Me.Controls.Add(Me.tolForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Add_Dependant_New"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Dependent New"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.gbMemberDetails.ResumeLayout(False)
        CType(Me.dgvMemberDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPolicyDetails.ResumeLayout(False)
        CType(Me.dgvPolicyDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Filter As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsb_Filter_Param As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsb_Filter_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbMemberDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMemberDetails As System.Windows.Forms.DataGridView
    Friend WithEvents gbPolicyDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPolicyDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblAdmin As System.Windows.Forms.Label
End Class
