<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dependant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dependant))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_Filter = New System.Windows.Forms.ToolStripComboBox
        Me.tsb_Filter_Param = New System.Windows.Forms.ToolStripTextBox
        Me.tsb_Filter_Go = New System.Windows.Forms.ToolStripButton
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.gbMemberDetails = New System.Windows.Forms.GroupBox
        Me.gbDDetails = New System.Windows.Forms.GroupBox
        Me.dgvDDetails = New System.Windows.Forms.DataGridView
        Me.gbPolicyDetails = New System.Windows.Forms.GroupBox
        Me.dgvPolicyDetails = New System.Windows.Forms.DataGridView
        Me.lblAdmin = New System.Windows.Forms.Label
        Me.tolForm.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMemberDetails.SuspendLayout()
        Me.gbDDetails.SuspendLayout()
        CType(Me.dgvDDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPolicyDetails.SuspendLayout()
        CType(Me.dgvPolicyDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Filter, Me.tsb_Filter_Param, Me.tsb_Filter_Go})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(1135, 25)
        Me.tolForm.TabIndex = 3
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
        'dgvForm
        '
        Me.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvForm.Location = New System.Drawing.Point(15, 19)
        Me.dgvForm.Name = "dgvForm"
        Me.dgvForm.Size = New System.Drawing.Size(1078, 150)
        Me.dgvForm.TabIndex = 4
        '
        'gbMemberDetails
        '
        Me.gbMemberDetails.Controls.Add(Me.dgvForm)
        Me.gbMemberDetails.Location = New System.Drawing.Point(0, 38)
        Me.gbMemberDetails.Name = "gbMemberDetails"
        Me.gbMemberDetails.Size = New System.Drawing.Size(1123, 187)
        Me.gbMemberDetails.TabIndex = 5
        Me.gbMemberDetails.TabStop = False
        Me.gbMemberDetails.Text = "Member Details"
        '
        'gbDDetails
        '
        Me.gbDDetails.Controls.Add(Me.dgvDDetails)
        Me.gbDDetails.Location = New System.Drawing.Point(0, 419)
        Me.gbDDetails.Name = "gbDDetails"
        Me.gbDDetails.Size = New System.Drawing.Size(1123, 154)
        Me.gbDDetails.TabIndex = 6
        Me.gbDDetails.TabStop = False
        Me.gbDDetails.Text = "Dependant Details"
        Me.gbDDetails.Visible = False
        '
        'dgvDDetails
        '
        Me.dgvDDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDDetails.Location = New System.Drawing.Point(15, 19)
        Me.dgvDDetails.Name = "dgvDDetails"
        Me.dgvDDetails.Size = New System.Drawing.Size(1078, 112)
        Me.dgvDDetails.TabIndex = 0
        '
        'gbPolicyDetails
        '
        Me.gbPolicyDetails.Controls.Add(Me.dgvPolicyDetails)
        Me.gbPolicyDetails.Location = New System.Drawing.Point(0, 247)
        Me.gbPolicyDetails.Name = "gbPolicyDetails"
        Me.gbPolicyDetails.Size = New System.Drawing.Size(1123, 154)
        Me.gbPolicyDetails.TabIndex = 7
        Me.gbPolicyDetails.TabStop = False
        Me.gbPolicyDetails.Text = "Policy Details"
        Me.gbPolicyDetails.Visible = False
        '
        'dgvPolicyDetails
        '
        Me.dgvPolicyDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPolicyDetails.Location = New System.Drawing.Point(15, 19)
        Me.dgvPolicyDetails.Name = "dgvPolicyDetails"
        Me.dgvPolicyDetails.Size = New System.Drawing.Size(1078, 112)
        Me.dgvPolicyDetails.TabIndex = 0
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.Location = New System.Drawing.Point(1053, 570)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(10, 13)
        Me.lblAdmin.TabIndex = 8
        Me.lblAdmin.Text = "."
        Me.lblAdmin.Visible = False
        '
        'Dependant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 582)
        Me.Controls.Add(Me.lblAdmin)
        Me.Controls.Add(Me.gbPolicyDetails)
        Me.Controls.Add(Me.gbDDetails)
        Me.Controls.Add(Me.gbMemberDetails)
        Me.Controls.Add(Me.tolForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Dependant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dependant"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMemberDetails.ResumeLayout(False)
        Me.gbDDetails.ResumeLayout(False)
        CType(Me.dgvDDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPolicyDetails.ResumeLayout(False)
        CType(Me.dgvPolicyDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Filter As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsb_Filter_Param As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsb_Filter_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents gbMemberDetails As System.Windows.Forms.GroupBox
    Friend WithEvents gbDDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDDetails As System.Windows.Forms.DataGridView
    Friend WithEvents gbPolicyDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPolicyDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblAdmin As System.Windows.Forms.Label
End Class
