<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search_Member
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Search_Member))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_Filter = New System.Windows.Forms.ToolStripComboBox
        Me.tsb_Filter_Param = New System.Windows.Forms.ToolStripTextBox
        Me.tsb_Filter_Go = New System.Windows.Forms.ToolStripButton
        Me.dgvMember = New System.Windows.Forms.DataGridView
        Me.gbMemberDetails = New System.Windows.Forms.GroupBox
        Me.gbPolicyDetails = New System.Windows.Forms.GroupBox
        Me.dgvPolicyDetails = New System.Windows.Forms.DataGridView
        Me.lblAdmin = New System.Windows.Forms.Label
        Me.tolForm.SuspendLayout()
        CType(Me.dgvMember, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMemberDetails.SuspendLayout()
        Me.gbPolicyDetails.SuspendLayout()
        CType(Me.dgvPolicyDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Filter, Me.tsb_Filter_Param, Me.tsb_Filter_Go})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(790, 25)
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
        'dgvMember
        '
        Me.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMember.Location = New System.Drawing.Point(6, 19)
        Me.dgvMember.Name = "dgvMember"
        Me.dgvMember.Size = New System.Drawing.Size(754, 199)
        Me.dgvMember.TabIndex = 5
        '
        'gbMemberDetails
        '
        Me.gbMemberDetails.Controls.Add(Me.dgvMember)
        Me.gbMemberDetails.Location = New System.Drawing.Point(12, 38)
        Me.gbMemberDetails.Name = "gbMemberDetails"
        Me.gbMemberDetails.Size = New System.Drawing.Size(766, 224)
        Me.gbMemberDetails.TabIndex = 6
        Me.gbMemberDetails.TabStop = False
        Me.gbMemberDetails.Text = "Member Details"
        '
        'gbPolicyDetails
        '
        Me.gbPolicyDetails.Controls.Add(Me.dgvPolicyDetails)
        Me.gbPolicyDetails.Location = New System.Drawing.Point(12, 280)
        Me.gbPolicyDetails.Name = "gbPolicyDetails"
        Me.gbPolicyDetails.Size = New System.Drawing.Size(766, 193)
        Me.gbPolicyDetails.TabIndex = 7
        Me.gbPolicyDetails.TabStop = False
        Me.gbPolicyDetails.Text = "Member Policies Details"
        '
        'dgvPolicyDetails
        '
        Me.dgvPolicyDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPolicyDetails.Location = New System.Drawing.Point(6, 19)
        Me.dgvPolicyDetails.Name = "dgvPolicyDetails"
        Me.dgvPolicyDetails.Size = New System.Drawing.Size(754, 154)
        Me.dgvPolicyDetails.TabIndex = 6
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.Location = New System.Drawing.Point(633, 471)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(35, 13)
        Me.lblAdmin.TabIndex = 8
        Me.lblAdmin.Text = "admin"
        Me.lblAdmin.Visible = False
        '
        'Search_Member
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 485)
        Me.Controls.Add(Me.lblAdmin)
        Me.Controls.Add(Me.gbPolicyDetails)
        Me.Controls.Add(Me.gbMemberDetails)
        Me.Controls.Add(Me.tolForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Search_Member"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search_Member"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvMember, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMemberDetails.ResumeLayout(False)
        Me.gbPolicyDetails.ResumeLayout(False)
        CType(Me.dgvPolicyDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Filter As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsb_Filter_Param As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsb_Filter_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvMember As System.Windows.Forms.DataGridView
    Friend WithEvents gbMemberDetails As System.Windows.Forms.GroupBox
    Friend WithEvents gbPolicyDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPolicyDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblAdmin As System.Windows.Forms.Label
End Class
