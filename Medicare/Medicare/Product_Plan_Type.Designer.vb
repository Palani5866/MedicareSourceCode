<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Product_Plan_Type
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
        Me.lblProductPlanID = New System.Windows.Forms.Label
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.gbProductPlan = New System.Windows.Forms.GroupBox
        Me.NoOfTimes1 = New System.Windows.Forms.Label
        Me.cbNoOfTimes = New System.Windows.Forms.ComboBox
        Me.lblNoofTimes = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblStatus1 = New System.Windows.Forms.Label
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.txtProductPlan = New System.Windows.Forms.TextBox
        Me.lblProductPlan1 = New System.Windows.Forms.Label
        Me.lblProductPlan = New System.Windows.Forms.Label
        Me.gbProductPlanDetails = New System.Windows.Forms.GroupBox
        Me.dgvProductPlan = New System.Windows.Forms.DataGridView
        Me.gbProductPlan.SuspendLayout()
        Me.gbProductPlanDetails.SuspendLayout()
        CType(Me.dgvProductPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblProductPlanID
        '
        Me.lblProductPlanID.AutoSize = True
        Me.lblProductPlanID.Location = New System.Drawing.Point(69, 424)
        Me.lblProductPlanID.Name = "lblProductPlanID"
        Me.lblProductPlanID.Size = New System.Drawing.Size(18, 13)
        Me.lblProductPlanID.TabIndex = 17
        Me.lblProductPlanID.Text = "ID"
        Me.lblProductPlanID.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(445, 170)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(323, 170)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 15
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(215, 170)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 14
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'gbProductPlan
        '
        Me.gbProductPlan.Controls.Add(Me.NoOfTimes1)
        Me.gbProductPlan.Controls.Add(Me.cbNoOfTimes)
        Me.gbProductPlan.Controls.Add(Me.lblNoofTimes)
        Me.gbProductPlan.Controls.Add(Me.btnCancel)
        Me.gbProductPlan.Controls.Add(Me.btnSubmit)
        Me.gbProductPlan.Controls.Add(Me.lblStatus1)
        Me.gbProductPlan.Controls.Add(Me.cbStatus)
        Me.gbProductPlan.Controls.Add(Me.lblStatus)
        Me.gbProductPlan.Controls.Add(Me.txtProductPlan)
        Me.gbProductPlan.Controls.Add(Me.lblProductPlan1)
        Me.gbProductPlan.Controls.Add(Me.lblProductPlan)
        Me.gbProductPlan.Location = New System.Drawing.Point(33, 219)
        Me.gbProductPlan.Name = "gbProductPlan"
        Me.gbProductPlan.Size = New System.Drawing.Size(728, 188)
        Me.gbProductPlan.TabIndex = 13
        Me.gbProductPlan.TabStop = False
        Me.gbProductPlan.Text = "Add Product Name"
        '
        'NoOfTimes1
        '
        Me.NoOfTimes1.AutoSize = True
        Me.NoOfTimes1.Location = New System.Drawing.Point(226, 72)
        Me.NoOfTimes1.Name = "NoOfTimes1"
        Me.NoOfTimes1.Size = New System.Drawing.Size(10, 13)
        Me.NoOfTimes1.TabIndex = 68
        Me.NoOfTimes1.Text = ":"
        '
        'cbNoOfTimes
        '
        Me.cbNoOfTimes.FormattingEnabled = True
        Me.cbNoOfTimes.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cbNoOfTimes.Location = New System.Drawing.Point(262, 69)
        Me.cbNoOfTimes.Name = "cbNoOfTimes"
        Me.cbNoOfTimes.Size = New System.Drawing.Size(265, 21)
        Me.cbNoOfTimes.TabIndex = 67
        '
        'lblNoofTimes
        '
        Me.lblNoofTimes.AutoSize = True
        Me.lblNoofTimes.Location = New System.Drawing.Point(86, 77)
        Me.lblNoofTimes.Name = "lblNoofTimes"
        Me.lblNoofTimes.Size = New System.Drawing.Size(134, 13)
        Me.lblNoofTimes.TabIndex = 66
        Me.lblNoofTimes.Text = "No of Times Policy allowed"
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
        Me.lblStatus1.Location = New System.Drawing.Point(226, 105)
        Me.lblStatus1.Name = "lblStatus1"
        Me.lblStatus1.Size = New System.Drawing.Size(10, 13)
        Me.lblStatus1.TabIndex = 60
        Me.lblStatus1.Text = ":"
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        Me.cbStatus.Location = New System.Drawing.Point(262, 102)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(265, 21)
        Me.cbStatus.TabIndex = 59
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(86, 105)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 58
        Me.lblStatus.Text = "Status"
        '
        'txtProductPlan
        '
        Me.txtProductPlan.Location = New System.Drawing.Point(262, 37)
        Me.txtProductPlan.Name = "txtProductPlan"
        Me.txtProductPlan.Size = New System.Drawing.Size(265, 20)
        Me.txtProductPlan.TabIndex = 2
        '
        'lblProductPlan1
        '
        Me.lblProductPlan1.AutoSize = True
        Me.lblProductPlan1.Location = New System.Drawing.Point(226, 37)
        Me.lblProductPlan1.Name = "lblProductPlan1"
        Me.lblProductPlan1.Size = New System.Drawing.Size(10, 13)
        Me.lblProductPlan1.TabIndex = 1
        Me.lblProductPlan1.Text = ":"
        '
        'lblProductPlan
        '
        Me.lblProductPlan.AutoSize = True
        Me.lblProductPlan.Location = New System.Drawing.Point(86, 37)
        Me.lblProductPlan.Name = "lblProductPlan"
        Me.lblProductPlan.Size = New System.Drawing.Size(82, 13)
        Me.lblProductPlan.TabIndex = 0
        Me.lblProductPlan.Text = "Product Name *"
        '
        'gbProductPlanDetails
        '
        Me.gbProductPlanDetails.Controls.Add(Me.dgvProductPlan)
        Me.gbProductPlanDetails.Location = New System.Drawing.Point(33, 19)
        Me.gbProductPlanDetails.Name = "gbProductPlanDetails"
        Me.gbProductPlanDetails.Size = New System.Drawing.Size(728, 144)
        Me.gbProductPlanDetails.TabIndex = 12
        Me.gbProductPlanDetails.TabStop = False
        Me.gbProductPlanDetails.Text = "Product Name Details"
        '
        'dgvProductPlan
        '
        Me.dgvProductPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductPlan.Location = New System.Drawing.Point(23, 20)
        Me.dgvProductPlan.Name = "dgvProductPlan"
        Me.dgvProductPlan.Size = New System.Drawing.Size(666, 105)
        Me.dgvProductPlan.TabIndex = 0
        '
        'Product_Plan_Type
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 478)
        Me.Controls.Add(Me.lblProductPlanID)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.gbProductPlan)
        Me.Controls.Add(Me.gbProductPlanDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Product_Plan_Type"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product Name"
        Me.gbProductPlan.ResumeLayout(False)
        Me.gbProductPlan.PerformLayout()
        Me.gbProductPlanDetails.ResumeLayout(False)
        CType(Me.dgvProductPlan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProductPlanID As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents gbProductPlan As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblStatus1 As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtProductPlan As System.Windows.Forms.TextBox
    Friend WithEvents lblProductPlan1 As System.Windows.Forms.Label
    Friend WithEvents lblProductPlan As System.Windows.Forms.Label
    Friend WithEvents gbProductPlanDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvProductPlan As System.Windows.Forms.DataGridView
    Friend WithEvents NoOfTimes1 As System.Windows.Forms.Label
    Friend WithEvents cbNoOfTimes As System.Windows.Forms.ComboBox
    Friend WithEvents lblNoofTimes As System.Windows.Forms.Label
End Class
