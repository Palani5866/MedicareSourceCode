<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Premium_Type
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
        Me.lblPremiumID = New System.Windows.Forms.Label
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.gbPremium = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblStatus1 = New System.Windows.Forms.Label
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.txtPremium = New System.Windows.Forms.TextBox
        Me.lblPremium1 = New System.Windows.Forms.Label
        Me.lblPremium = New System.Windows.Forms.Label
        Me.gbPremiumDetails = New System.Windows.Forms.GroupBox
        Me.dgvPremium = New System.Windows.Forms.DataGridView
        Me.gbPremium.SuspendLayout()
        Me.gbPremiumDetails.SuspendLayout()
        CType(Me.dgvPremium, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPremiumID
        '
        Me.lblPremiumID.AutoSize = True
        Me.lblPremiumID.Location = New System.Drawing.Point(67, 426)
        Me.lblPremiumID.Name = "lblPremiumID"
        Me.lblPremiumID.Size = New System.Drawing.Size(18, 13)
        Me.lblPremiumID.TabIndex = 11
        Me.lblPremiumID.Text = "ID"
        Me.lblPremiumID.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(443, 172)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(321, 172)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(213, 172)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 8
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'gbPremium
        '
        Me.gbPremium.Controls.Add(Me.btnCancel)
        Me.gbPremium.Controls.Add(Me.btnSubmit)
        Me.gbPremium.Controls.Add(Me.lblStatus1)
        Me.gbPremium.Controls.Add(Me.cbStatus)
        Me.gbPremium.Controls.Add(Me.lblStatus)
        Me.gbPremium.Controls.Add(Me.txtPremium)
        Me.gbPremium.Controls.Add(Me.lblPremium1)
        Me.gbPremium.Controls.Add(Me.lblPremium)
        Me.gbPremium.Location = New System.Drawing.Point(31, 221)
        Me.gbPremium.Name = "gbPremium"
        Me.gbPremium.Size = New System.Drawing.Size(728, 188)
        Me.gbPremium.TabIndex = 7
        Me.gbPremium.TabStop = False
        Me.gbPremium.Text = "Add Payment Mode"
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
        'txtPremium
        '
        Me.txtPremium.Location = New System.Drawing.Point(262, 37)
        Me.txtPremium.Name = "txtPremium"
        Me.txtPremium.Size = New System.Drawing.Size(265, 20)
        Me.txtPremium.TabIndex = 2
        '
        'lblPremium1
        '
        Me.lblPremium1.AutoSize = True
        Me.lblPremium1.Location = New System.Drawing.Point(226, 37)
        Me.lblPremium1.Name = "lblPremium1"
        Me.lblPremium1.Size = New System.Drawing.Size(10, 13)
        Me.lblPremium1.TabIndex = 1
        Me.lblPremium1.Text = ":"
        '
        'lblPremium
        '
        Me.lblPremium.AutoSize = True
        Me.lblPremium.Location = New System.Drawing.Point(115, 37)
        Me.lblPremium.Name = "lblPremium"
        Me.lblPremium.Size = New System.Drawing.Size(85, 13)
        Me.lblPremium.TabIndex = 0
        Me.lblPremium.Text = "Payment Mode *"
        '
        'gbPremiumDetails
        '
        Me.gbPremiumDetails.Controls.Add(Me.dgvPremium)
        Me.gbPremiumDetails.Location = New System.Drawing.Point(31, 21)
        Me.gbPremiumDetails.Name = "gbPremiumDetails"
        Me.gbPremiumDetails.Size = New System.Drawing.Size(728, 144)
        Me.gbPremiumDetails.TabIndex = 6
        Me.gbPremiumDetails.TabStop = False
        Me.gbPremiumDetails.Text = "Payment Mode Details"
        '
        'dgvPremium
        '
        Me.dgvPremium.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPremium.Location = New System.Drawing.Point(23, 20)
        Me.dgvPremium.Name = "dgvPremium"
        Me.dgvPremium.Size = New System.Drawing.Size(666, 105)
        Me.dgvPremium.TabIndex = 0
        '
        'Premium_Type
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 456)
        Me.Controls.Add(Me.lblPremiumID)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.gbPremium)
        Me.Controls.Add(Me.gbPremiumDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Premium_Type"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment Mode"
        Me.gbPremium.ResumeLayout(False)
        Me.gbPremium.PerformLayout()
        Me.gbPremiumDetails.ResumeLayout(False)
        CType(Me.dgvPremium, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPremiumID As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents gbPremium As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblStatus1 As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtPremium As System.Windows.Forms.TextBox
    Friend WithEvents lblPremium1 As System.Windows.Forms.Label
    Friend WithEvents lblPremium As System.Windows.Forms.Label
    Friend WithEvents gbPremiumDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPremium As System.Windows.Forms.DataGridView
End Class
