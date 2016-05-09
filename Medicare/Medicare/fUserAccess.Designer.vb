<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fUserAccess
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
        Me.dgvUsers = New System.Windows.Forms.DataGridView
        Me.gbUserDetails = New System.Windows.Forms.GroupBox
        Me.gbAddUsers = New System.Windows.Forms.GroupBox
        Me.lblID = New System.Windows.Forms.Label
        Me.gbAccess = New System.Windows.Forms.GroupBox
        Me.chkAdminLevel = New System.Windows.Forms.CheckedListBox
        Me.chkAdminModule = New System.Windows.Forms.CheckBox
        Me.chkPremiumModule = New System.Windows.Forms.CheckBox
        Me.chkMemberModule = New System.Windows.Forms.CheckBox
        Me.chkProposerModule = New System.Windows.Forms.CheckBox
        Me.chkCSLevel = New System.Windows.Forms.CheckedListBox
        Me.chkPremiumLevel = New System.Windows.Forms.CheckedListBox
        Me.chkMemberLevel = New System.Windows.Forms.CheckedListBox
        Me.chkProposerLevel = New System.Windows.Forms.CheckedListBox
        Me.gbAddUser = New System.Windows.Forms.GroupBox
        Me.dtpExpiryDate = New System.Windows.Forms.DateTimePicker
        Me.lblExpiryDate1 = New System.Windows.Forms.Label
        Me.lblExpiryDate = New System.Windows.Forms.Label
        Me.txtFullName = New System.Windows.Forms.TextBox
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.lblUserID = New System.Windows.Forms.Label
        Me.lblStatus1 = New System.Windows.Forms.Label
        Me.lblUserID1 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblFullName = New System.Windows.Forms.Label
        Me.lblFullName1 = New System.Windows.Forms.Label
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.txtPWD = New System.Windows.Forms.TextBox
        Me.lblPWD = New System.Windows.Forms.Label
        Me.lblPWD1 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.chkCS = New System.Windows.Forms.CheckBox
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbUserDetails.SuspendLayout()
        Me.gbAddUsers.SuspendLayout()
        Me.gbAccess.SuspendLayout()
        Me.gbAddUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUsers
        '
        Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsers.Location = New System.Drawing.Point(10, 19)
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.Size = New System.Drawing.Size(1125, 126)
        Me.dgvUsers.TabIndex = 5
        '
        'gbUserDetails
        '
        Me.gbUserDetails.Controls.Add(Me.dgvUsers)
        Me.gbUserDetails.Location = New System.Drawing.Point(12, 12)
        Me.gbUserDetails.Name = "gbUserDetails"
        Me.gbUserDetails.Size = New System.Drawing.Size(1141, 161)
        Me.gbUserDetails.TabIndex = 6
        Me.gbUserDetails.TabStop = False
        Me.gbUserDetails.Text = "Users Details"
        '
        'gbAddUsers
        '
        Me.gbAddUsers.Controls.Add(Me.lblID)
        Me.gbAddUsers.Controls.Add(Me.gbAccess)
        Me.gbAddUsers.Controls.Add(Me.gbAddUser)
        Me.gbAddUsers.Controls.Add(Me.btnCancel)
        Me.gbAddUsers.Controls.Add(Me.btnSubmit)
        Me.gbAddUsers.Location = New System.Drawing.Point(12, 234)
        Me.gbAddUsers.Name = "gbAddUsers"
        Me.gbAddUsers.Size = New System.Drawing.Size(1135, 501)
        Me.gbAddUsers.TabIndex = 7
        Me.gbAddUsers.TabStop = False
        Me.gbAddUsers.Text = "Add/Edit Users"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(1072, 468)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 72
        Me.lblID.Text = "ID"
        Me.lblID.Visible = False
        '
        'gbAccess
        '
        Me.gbAccess.Controls.Add(Me.chkCS)
        Me.gbAccess.Controls.Add(Me.chkAdminLevel)
        Me.gbAccess.Controls.Add(Me.chkAdminModule)
        Me.gbAccess.Controls.Add(Me.chkPremiumModule)
        Me.gbAccess.Controls.Add(Me.chkMemberModule)
        Me.gbAccess.Controls.Add(Me.chkProposerModule)
        Me.gbAccess.Controls.Add(Me.chkCSLevel)
        Me.gbAccess.Controls.Add(Me.chkPremiumLevel)
        Me.gbAccess.Controls.Add(Me.chkMemberLevel)
        Me.gbAccess.Controls.Add(Me.chkProposerLevel)
        Me.gbAccess.Location = New System.Drawing.Point(10, 202)
        Me.gbAccess.Name = "gbAccess"
        Me.gbAccess.Size = New System.Drawing.Size(1115, 255)
        Me.gbAccess.TabIndex = 62
        Me.gbAccess.TabStop = False
        Me.gbAccess.Text = "User Permissions"
        '
        'chkAdminLevel
        '
        Me.chkAdminLevel.FormattingEnabled = True
        Me.chkAdminLevel.Items.AddRange(New Object() {"(View / Edit) Member", "(View / Edit) Dependents", "(View / Edit) Nominee", "(View / Edit) Exclusion Clause", "(View / Edit) Policy", "(Reports) Staff Activity Report", "(Reports) Staff Activity Details", "(Reports) Export Policy Details", "(Add) Dependents", "(Add) Nominee", "(Add) Exclusion Clause", "Renewal Listing", "Supense Account Settlement", "Shortfalls Settlement", "Reinstate of Policy", "Reports (Agent Summary)", "Reports (Followup Listing)", "View / Edit Member", "View Member Details"})
        Me.chkAdminLevel.Location = New System.Drawing.Point(732, 69)
        Me.chkAdminLevel.Name = "chkAdminLevel"
        Me.chkAdminLevel.Size = New System.Drawing.Size(372, 79)
        Me.chkAdminLevel.TabIndex = 49
        Me.chkAdminLevel.Visible = False
        '
        'chkAdminModule
        '
        Me.chkAdminModule.AutoSize = True
        Me.chkAdminModule.Location = New System.Drawing.Point(732, 32)
        Me.chkAdminModule.Name = "chkAdminModule"
        Me.chkAdminModule.Size = New System.Drawing.Size(93, 17)
        Me.chkAdminModule.TabIndex = 48
        Me.chkAdminModule.Text = "Admin Module"
        Me.chkAdminModule.UseVisualStyleBackColor = True
        '
        'chkPremiumModule
        '
        Me.chkPremiumModule.AutoSize = True
        Me.chkPremiumModule.Location = New System.Drawing.Point(365, 32)
        Me.chkPremiumModule.Name = "chkPremiumModule"
        Me.chkPremiumModule.Size = New System.Drawing.Size(104, 17)
        Me.chkPremiumModule.TabIndex = 46
        Me.chkPremiumModule.Text = "Premium Module"
        Me.chkPremiumModule.UseVisualStyleBackColor = True
        '
        'chkMemberModule
        '
        Me.chkMemberModule.AutoSize = True
        Me.chkMemberModule.Location = New System.Drawing.Point(189, 32)
        Me.chkMemberModule.Name = "chkMemberModule"
        Me.chkMemberModule.Size = New System.Drawing.Size(102, 17)
        Me.chkMemberModule.TabIndex = 45
        Me.chkMemberModule.Text = "Member Module"
        Me.chkMemberModule.UseVisualStyleBackColor = True
        '
        'chkProposerModule
        '
        Me.chkProposerModule.AutoSize = True
        Me.chkProposerModule.Location = New System.Drawing.Point(15, 32)
        Me.chkProposerModule.Name = "chkProposerModule"
        Me.chkProposerModule.Size = New System.Drawing.Size(106, 17)
        Me.chkProposerModule.TabIndex = 43
        Me.chkProposerModule.Text = "Proposer Module"
        Me.chkProposerModule.UseVisualStyleBackColor = True
        '
        'chkCSLevel
        '
        Me.chkCSLevel.FormattingEnabled = True
        Me.chkCSLevel.Items.AddRange(New Object() {"View All", "(Endorsement) Change of Postal Address", "(Endorsement) Change of Personal Details", "(Endorsement) Dependents (Add/Edit/Delete)", "(Endorsement) Nominee (Add/Edit/Delete)", "(Endorsement) Exclusion Clause (Add/Edit/Delete)", "(Endorsement) View / Edit Member", "(Followup) Incomplete", "(Followup) UW", "(Followup) Pending Renewal", "(Followup) Retirees", "Yearly Renewal", "Print Letters", "(Reports) Followup Summary", "(Reports) Endorsement Summary", "(Reports) Submission to Insurer"})
        Me.chkCSLevel.Location = New System.Drawing.Point(365, 154)
        Me.chkCSLevel.Name = "chkCSLevel"
        Me.chkCSLevel.Size = New System.Drawing.Size(361, 79)
        Me.chkCSLevel.TabIndex = 42
        Me.chkCSLevel.Visible = False
        '
        'chkPremiumLevel
        '
        Me.chkPremiumLevel.FormattingEnabled = True
        Me.chkPremiumLevel.Items.AddRange(New Object() {"View All", "(Monthly) Biro Angkasa", "(Monthly) Others", "(Yearly) Premium Request", "(Yearly) Premium Update", "(Endorsement) Change of Plan Code", "(Endorsement) Change of Request Amount", "Cancellation of Policy", "(Increase Premium) CC", "(Increase Premium) CPA", "(Decrease Premium) CC", "(Decrease Premium) CPA", "(Exceeding Coverage Age) CC", "(Exceeding Coverage Age) CPA", "(Follow up) Non Payment", "Print Letters", "(Reports) 13-Months", "(Reports) Suspension Account", "(Reports) Shortfalls", "(Reports) Agent Commission", "(Reports) Premium Collections - Angkasa (By Receiving Month)", "(Reports) Submission to Insurer", "(Reports) Recovered Shortfalls", "(Reports) New Premium Not Received From Deduction Agency"})
        Me.chkPremiumLevel.Location = New System.Drawing.Point(15, 154)
        Me.chkPremiumLevel.Name = "chkPremiumLevel"
        Me.chkPremiumLevel.Size = New System.Drawing.Size(344, 79)
        Me.chkPremiumLevel.TabIndex = 41
        Me.chkPremiumLevel.Visible = False
        '
        'chkMemberLevel
        '
        Me.chkMemberLevel.FormattingEnabled = True
        Me.chkMemberLevel.Items.AddRange(New Object() {"View All", "(Endorsement) Change of POlicy", "(Endorsement) Change of File No", "(Upload) Policy No", "(Upload) Address", "(Upload) Client No", "(Upload) IC/DOB/PHONE", "(Download) Blank Policy No", "(Download) Blank Address", "(Download) Blank Client No", "(Download) Blank IC/DOB/PHONE", "(Send) Email", "(Send) SMS", "Print Letters", "(Reports) Followup Listing"})
        Me.chkMemberLevel.Location = New System.Drawing.Point(365, 69)
        Me.chkMemberLevel.Name = "chkMemberLevel"
        Me.chkMemberLevel.Size = New System.Drawing.Size(361, 79)
        Me.chkMemberLevel.TabIndex = 40
        Me.chkMemberLevel.Visible = False
        '
        'chkProposerLevel
        '
        Me.chkProposerLevel.FormattingEnabled = True
        Me.chkProposerLevel.Items.AddRange(New Object() {"New", "Verify Proposer", "Submissions", "(View) ALL Verified Proposers ", "(View) ALL Proposers", "(Letters) Acknowledgement", "(Letters) Deferment", "(Letters) Reject", "(Letters) Underwriting", "(Send mail) Incomplete", "(Send mail) Acknowledgement", "(Reports) Production"})
        Me.chkProposerLevel.Location = New System.Drawing.Point(15, 69)
        Me.chkProposerLevel.Name = "chkProposerLevel"
        Me.chkProposerLevel.Size = New System.Drawing.Size(344, 79)
        Me.chkProposerLevel.TabIndex = 39
        Me.chkProposerLevel.Visible = False
        '
        'gbAddUser
        '
        Me.gbAddUser.Controls.Add(Me.dtpExpiryDate)
        Me.gbAddUser.Controls.Add(Me.lblExpiryDate1)
        Me.gbAddUser.Controls.Add(Me.lblExpiryDate)
        Me.gbAddUser.Controls.Add(Me.txtFullName)
        Me.gbAddUser.Controls.Add(Me.cbStatus)
        Me.gbAddUser.Controls.Add(Me.lblUserID)
        Me.gbAddUser.Controls.Add(Me.lblStatus1)
        Me.gbAddUser.Controls.Add(Me.lblUserID1)
        Me.gbAddUser.Controls.Add(Me.lblStatus)
        Me.gbAddUser.Controls.Add(Me.lblFullName)
        Me.gbAddUser.Controls.Add(Me.lblFullName1)
        Me.gbAddUser.Controls.Add(Me.txtUserID)
        Me.gbAddUser.Controls.Add(Me.txtPWD)
        Me.gbAddUser.Controls.Add(Me.lblPWD)
        Me.gbAddUser.Controls.Add(Me.lblPWD1)
        Me.gbAddUser.Location = New System.Drawing.Point(284, 19)
        Me.gbAddUser.Name = "gbAddUser"
        Me.gbAddUser.Size = New System.Drawing.Size(660, 177)
        Me.gbAddUser.TabIndex = 61
        Me.gbAddUser.TabStop = False
        Me.gbAddUser.Text = "User Details"
        '
        'dtpExpiryDate
        '
        Me.dtpExpiryDate.Location = New System.Drawing.Point(158, 118)
        Me.dtpExpiryDate.Name = "dtpExpiryDate"
        Me.dtpExpiryDate.Size = New System.Drawing.Size(226, 20)
        Me.dtpExpiryDate.TabIndex = 73
        '
        'lblExpiryDate1
        '
        Me.lblExpiryDate1.AutoSize = True
        Me.lblExpiryDate1.Location = New System.Drawing.Point(118, 120)
        Me.lblExpiryDate1.Name = "lblExpiryDate1"
        Me.lblExpiryDate1.Size = New System.Drawing.Size(10, 13)
        Me.lblExpiryDate1.TabIndex = 72
        Me.lblExpiryDate1.Text = ":"
        '
        'lblExpiryDate
        '
        Me.lblExpiryDate.AutoSize = True
        Me.lblExpiryDate.Location = New System.Drawing.Point(35, 120)
        Me.lblExpiryDate.Name = "lblExpiryDate"
        Me.lblExpiryDate.Size = New System.Drawing.Size(61, 13)
        Me.lblExpiryDate.TabIndex = 71
        Me.lblExpiryDate.Text = "Expiry Date"
        '
        'txtFullName
        '
        Me.txtFullName.AcceptsTab = True
        Me.txtFullName.Location = New System.Drawing.Point(158, 28)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(226, 20)
        Me.txtFullName.TabIndex = 2
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        Me.cbStatus.Location = New System.Drawing.Point(158, 144)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(226, 21)
        Me.cbStatus.TabIndex = 60
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Location = New System.Drawing.Point(35, 62)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(43, 13)
        Me.lblUserID.TabIndex = 0
        Me.lblUserID.Text = "User ID"
        '
        'lblStatus1
        '
        Me.lblStatus1.AutoSize = True
        Me.lblStatus1.Location = New System.Drawing.Point(118, 148)
        Me.lblStatus1.Name = "lblStatus1"
        Me.lblStatus1.Size = New System.Drawing.Size(10, 13)
        Me.lblStatus1.TabIndex = 59
        Me.lblStatus1.Text = ":"
        '
        'lblUserID1
        '
        Me.lblUserID1.AutoSize = True
        Me.lblUserID1.Location = New System.Drawing.Point(118, 62)
        Me.lblUserID1.Name = "lblUserID1"
        Me.lblUserID1.Size = New System.Drawing.Size(10, 13)
        Me.lblUserID1.TabIndex = 1
        Me.lblUserID1.Text = ":"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(35, 149)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 58
        Me.lblStatus.Text = "Status"
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Location = New System.Drawing.Point(35, 28)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(54, 13)
        Me.lblFullName.TabIndex = 3
        Me.lblFullName.Text = "Full Name"
        '
        'lblFullName1
        '
        Me.lblFullName1.AutoSize = True
        Me.lblFullName1.Location = New System.Drawing.Point(118, 28)
        Me.lblFullName1.Name = "lblFullName1"
        Me.lblFullName1.Size = New System.Drawing.Size(10, 13)
        Me.lblFullName1.TabIndex = 4
        Me.lblFullName1.Text = ":"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(158, 59)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(226, 20)
        Me.txtUserID.TabIndex = 5
        '
        'txtPWD
        '
        Me.txtPWD.Location = New System.Drawing.Point(158, 90)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Size = New System.Drawing.Size(226, 20)
        Me.txtPWD.TabIndex = 8
        Me.txtPWD.UseSystemPasswordChar = True
        '
        'lblPWD
        '
        Me.lblPWD.AutoSize = True
        Me.lblPWD.Location = New System.Drawing.Point(35, 93)
        Me.lblPWD.Name = "lblPWD"
        Me.lblPWD.Size = New System.Drawing.Size(53, 13)
        Me.lblPWD.TabIndex = 6
        Me.lblPWD.Text = "Password"
        '
        'lblPWD1
        '
        Me.lblPWD1.AutoSize = True
        Me.lblPWD1.Location = New System.Drawing.Point(118, 93)
        Me.lblPWD1.Name = "lblPWD1"
        Me.lblPWD1.Size = New System.Drawing.Size(10, 13)
        Me.lblPWD1.TabIndex = 7
        Me.lblPWD1.Text = ":"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(638, 463)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(98, 23)
        Me.btnCancel.TabIndex = 56
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(511, 463)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(103, 23)
        Me.btnSubmit.TabIndex = 55
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(678, 179)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(561, 179)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(456, 179)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 12
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'chkCS
        '
        Me.chkCS.AutoSize = True
        Me.chkCS.Location = New System.Drawing.Point(528, 32)
        Me.chkCS.Name = "chkCS"
        Me.chkCS.Size = New System.Drawing.Size(109, 17)
        Me.chkCS.TabIndex = 50
        Me.chkCS.Text = "Customer Service"
        Me.chkCS.UseVisualStyleBackColor = True
        '
        'fUserAccess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1165, 748)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.gbAddUsers)
        Me.Controls.Add(Me.gbUserDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fUserAccess"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fUserAccess"
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbUserDetails.ResumeLayout(False)
        Me.gbAddUsers.ResumeLayout(False)
        Me.gbAddUsers.PerformLayout()
        Me.gbAccess.ResumeLayout(False)
        Me.gbAccess.PerformLayout()
        Me.gbAddUser.ResumeLayout(False)
        Me.gbAddUser.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvUsers As System.Windows.Forms.DataGridView
    Friend WithEvents gbUserDetails As System.Windows.Forms.GroupBox
    Friend WithEvents gbAddUsers As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents lblUserID1 As System.Windows.Forms.Label
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents lblFullName1 As System.Windows.Forms.Label
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents txtPWD As System.Windows.Forms.TextBox
    Friend WithEvents lblPWD1 As System.Windows.Forms.Label
    Friend WithEvents lblPWD As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents gbAddUser As System.Windows.Forms.GroupBox
    Friend WithEvents gbAccess As System.Windows.Forms.GroupBox
    Friend WithEvents chkCSLevel As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkPremiumLevel As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkMemberLevel As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkProposerLevel As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkPremiumModule As System.Windows.Forms.CheckBox
    Friend WithEvents chkMemberModule As System.Windows.Forms.CheckBox
    Friend WithEvents chkProposerModule As System.Windows.Forms.CheckBox
    Friend WithEvents dtpExpiryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblExpiryDate1 As System.Windows.Forms.Label
    Friend WithEvents lblExpiryDate As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents chkAdminLevel As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkAdminModule As System.Windows.Forms.CheckBox
    Friend WithEvents chkCS As System.Windows.Forms.CheckBox
End Class
