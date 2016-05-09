<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Plan_Type
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
        Me.lblPlanID = New System.Windows.Forms.Label
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.gbPlan = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblStatus1 = New System.Windows.Forms.Label
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.txtPlan = New System.Windows.Forms.TextBox
        Me.lblPlan1 = New System.Windows.Forms.Label
        Me.lblPlan = New System.Windows.Forms.Label
        Me.gbPlanDetails = New System.Windows.Forms.GroupBox
        Me.dgvPlan = New System.Windows.Forms.DataGridView
        Me.gbPlan.SuspendLayout()
        Me.gbPlanDetails.SuspendLayout()
        CType(Me.dgvPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPlanID
        '
        Me.lblPlanID.AutoSize = True
        Me.lblPlanID.Location = New System.Drawing.Point(79, 430)
        Me.lblPlanID.Name = "lblPlanID"
        Me.lblPlanID.Size = New System.Drawing.Size(18, 13)
        Me.lblPlanID.TabIndex = 11
        Me.lblPlanID.Text = "ID"
        Me.lblPlanID.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(455, 176)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(333, 176)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(225, 176)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 8
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'gbPlan
        '
        Me.gbPlan.Controls.Add(Me.btnCancel)
        Me.gbPlan.Controls.Add(Me.btnSubmit)
        Me.gbPlan.Controls.Add(Me.lblStatus1)
        Me.gbPlan.Controls.Add(Me.cbStatus)
        Me.gbPlan.Controls.Add(Me.lblStatus)
        Me.gbPlan.Controls.Add(Me.txtPlan)
        Me.gbPlan.Controls.Add(Me.lblPlan1)
        Me.gbPlan.Controls.Add(Me.lblPlan)
        Me.gbPlan.Location = New System.Drawing.Point(43, 225)
        Me.gbPlan.Name = "gbPlan"
        Me.gbPlan.Size = New System.Drawing.Size(728, 188)
        Me.gbPlan.TabIndex = 7
        Me.gbPlan.TabStop = False
        Me.gbPlan.Text = "Add Plan Type"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(363, 137)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 62
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(249, 137)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 61
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblStatus1
        '
        Me.lblStatus1.AutoSize = True
        Me.lblStatus1.Location = New System.Drawing.Point(226, 84)
        Me.lblStatus1.Name = "lblStatus1"
        Me.lblStatus1.Size = New System.Drawing.Size(10, 13)
        Me.lblStatus1.TabIndex = 60
        Me.lblStatus1.Text = ":"
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        Me.cbStatus.Location = New System.Drawing.Point(262, 81)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(265, 21)
        Me.cbStatus.TabIndex = 59
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(115, 84)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 58
        Me.lblStatus.Text = "Status"
        '
        'txtPlan
        '
        Me.txtPlan.Location = New System.Drawing.Point(262, 37)
        Me.txtPlan.Name = "txtPlan"
        Me.txtPlan.Size = New System.Drawing.Size(265, 20)
        Me.txtPlan.TabIndex = 2
        '
        'lblPlan1
        '
        Me.lblPlan1.AutoSize = True
        Me.lblPlan1.Location = New System.Drawing.Point(226, 37)
        Me.lblPlan1.Name = "lblPlan1"
        Me.lblPlan1.Size = New System.Drawing.Size(10, 13)
        Me.lblPlan1.TabIndex = 1
        Me.lblPlan1.Text = ":"
        '
        'lblPlan
        '
        Me.lblPlan.AutoSize = True
        Me.lblPlan.Location = New System.Drawing.Point(115, 37)
        Me.lblPlan.Name = "lblPlan"
        Me.lblPlan.Size = New System.Drawing.Size(62, 13)
        Me.lblPlan.TabIndex = 0
        Me.lblPlan.Text = "Plan Type *"
        '
        'gbPlanDetails
        '
        Me.gbPlanDetails.Controls.Add(Me.dgvPlan)
        Me.gbPlanDetails.Location = New System.Drawing.Point(43, 25)
        Me.gbPlanDetails.Name = "gbPlanDetails"
        Me.gbPlanDetails.Size = New System.Drawing.Size(728, 144)
        Me.gbPlanDetails.TabIndex = 6
        Me.gbPlanDetails.TabStop = False
        Me.gbPlanDetails.Text = "Plan Type Details"
        '
        'dgvPlan
        '
        Me.dgvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPlan.Location = New System.Drawing.Point(23, 20)
        Me.dgvPlan.Name = "dgvPlan"
        Me.dgvPlan.Size = New System.Drawing.Size(666, 105)
        Me.dgvPlan.TabIndex = 0
        '
        'Plan_Type
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 470)
        Me.Controls.Add(Me.lblPlanID)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.gbPlan)
        Me.Controls.Add(Me.gbPlanDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Plan_Type"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plan_Type"
        Me.gbPlan.ResumeLayout(False)
        Me.gbPlan.PerformLayout()
        Me.gbPlanDetails.ResumeLayout(False)
        CType(Me.dgvPlan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPlanID As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents gbPlan As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblStatus1 As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtPlan As System.Windows.Forms.TextBox
    Friend WithEvents lblPlan1 As System.Windows.Forms.Label
    Friend WithEvents lblPlan As System.Windows.Forms.Label
    Friend WithEvents gbPlanDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPlan As System.Windows.Forms.DataGridView
End Class
