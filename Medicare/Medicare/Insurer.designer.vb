<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Insurer
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
        Me.gbInsurer = New System.Windows.Forms.GroupBox
        Me.btnState = New System.Windows.Forms.Button
        Me.btnAddContact = New System.Windows.Forms.Button
        Me.txtInsurerCode = New System.Windows.Forms.TextBox
        Me.lblInsurerCode1 = New System.Windows.Forms.Label
        Me.lblInsurerCode = New System.Windows.Forms.Label
        Me.txtPostcode = New System.Windows.Forms.TextBox
        Me.lblPostcode1 = New System.Windows.Forms.Label
        Me.lblPostcode = New System.Windows.Forms.Label
        Me.txtTown = New System.Windows.Forms.TextBox
        Me.lblTown1 = New System.Windows.Forms.Label
        Me.lblTown = New System.Windows.Forms.Label
        Me.lblInsurerId = New System.Windows.Forms.Label
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.lblStatus1 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.txtState = New System.Windows.Forms.TextBox
        Me.lblState1 = New System.Windows.Forms.Label
        Me.lblState = New System.Windows.Forms.Label
        Me.txtAdd2 = New System.Windows.Forms.TextBox
        Me.lblAdd2_1 = New System.Windows.Forms.Label
        Me.lblAdd2 = New System.Windows.Forms.Label
        Me.txtAdd1 = New System.Windows.Forms.TextBox
        Me.lblAdd1_1 = New System.Windows.Forms.Label
        Me.lblAdd1 = New System.Windows.Forms.Label
        Me.txtInsurer = New System.Windows.Forms.TextBox
        Me.lblInsurer1 = New System.Windows.Forms.Label
        Me.lblInsurer = New System.Windows.Forms.Label
        Me.gbView = New System.Windows.Forms.GroupBox
        Me.dgvInsurer = New System.Windows.Forms.DataGridView
        Me.tb_insurer_id = New System.Windows.Forms.DataGridViewLinkColumn
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnEditContacts = New System.Windows.Forms.Button
        Me.gbInsurer.SuspendLayout()
        Me.gbView.SuspendLayout()
        CType(Me.dgvInsurer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbInsurer
        '
        Me.gbInsurer.Controls.Add(Me.btnState)
        Me.gbInsurer.Controls.Add(Me.btnAddContact)
        Me.gbInsurer.Controls.Add(Me.txtInsurerCode)
        Me.gbInsurer.Controls.Add(Me.lblInsurerCode1)
        Me.gbInsurer.Controls.Add(Me.lblInsurerCode)
        Me.gbInsurer.Controls.Add(Me.txtPostcode)
        Me.gbInsurer.Controls.Add(Me.lblPostcode1)
        Me.gbInsurer.Controls.Add(Me.lblPostcode)
        Me.gbInsurer.Controls.Add(Me.txtTown)
        Me.gbInsurer.Controls.Add(Me.lblTown1)
        Me.gbInsurer.Controls.Add(Me.lblTown)
        Me.gbInsurer.Controls.Add(Me.lblInsurerId)
        Me.gbInsurer.Controls.Add(Me.cbStatus)
        Me.gbInsurer.Controls.Add(Me.lblStatus1)
        Me.gbInsurer.Controls.Add(Me.lblStatus)
        Me.gbInsurer.Controls.Add(Me.btnCancel)
        Me.gbInsurer.Controls.Add(Me.btnSubmit)
        Me.gbInsurer.Controls.Add(Me.txtState)
        Me.gbInsurer.Controls.Add(Me.lblState1)
        Me.gbInsurer.Controls.Add(Me.lblState)
        Me.gbInsurer.Controls.Add(Me.txtAdd2)
        Me.gbInsurer.Controls.Add(Me.lblAdd2_1)
        Me.gbInsurer.Controls.Add(Me.lblAdd2)
        Me.gbInsurer.Controls.Add(Me.txtAdd1)
        Me.gbInsurer.Controls.Add(Me.lblAdd1_1)
        Me.gbInsurer.Controls.Add(Me.lblAdd1)
        Me.gbInsurer.Controls.Add(Me.txtInsurer)
        Me.gbInsurer.Controls.Add(Me.lblInsurer1)
        Me.gbInsurer.Controls.Add(Me.lblInsurer)
        Me.gbInsurer.Location = New System.Drawing.Point(12, 189)
        Me.gbInsurer.Name = "gbInsurer"
        Me.gbInsurer.Size = New System.Drawing.Size(701, 350)
        Me.gbInsurer.TabIndex = 2
        Me.gbInsurer.TabStop = False
        Me.gbInsurer.Text = "Add Insurer"
        '
        'btnState
        '
        Me.btnState.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnState.Location = New System.Drawing.Point(394, 173)
        Me.btnState.Name = "btnState"
        Me.btnState.Size = New System.Drawing.Size(54, 23)
        Me.btnState.TabIndex = 69
        Me.btnState.Text = "..."
        Me.btnState.UseVisualStyleBackColor = True
        '
        'btnAddContact
        '
        Me.btnAddContact.Location = New System.Drawing.Point(121, 296)
        Me.btnAddContact.Name = "btnAddContact"
        Me.btnAddContact.Size = New System.Drawing.Size(116, 23)
        Me.btnAddContact.TabIndex = 68
        Me.btnAddContact.Text = "Add Contacts"
        Me.btnAddContact.UseVisualStyleBackColor = True
        '
        'txtInsurerCode
        '
        Me.txtInsurerCode.Location = New System.Drawing.Point(228, 207)
        Me.txtInsurerCode.Name = "txtInsurerCode"
        Me.txtInsurerCode.Size = New System.Drawing.Size(220, 20)
        Me.txtInsurerCode.TabIndex = 67
        '
        'lblInsurerCode1
        '
        Me.lblInsurerCode1.AutoSize = True
        Me.lblInsurerCode1.Location = New System.Drawing.Point(198, 206)
        Me.lblInsurerCode1.Name = "lblInsurerCode1"
        Me.lblInsurerCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblInsurerCode1.TabIndex = 66
        Me.lblInsurerCode1.Text = ":"
        '
        'lblInsurerCode
        '
        Me.lblInsurerCode.AutoSize = True
        Me.lblInsurerCode.Location = New System.Drawing.Point(116, 207)
        Me.lblInsurerCode.Name = "lblInsurerCode"
        Me.lblInsurerCode.Size = New System.Drawing.Size(74, 13)
        Me.lblInsurerCode.TabIndex = 65
        Me.lblInsurerCode.Text = "Insurer Code *"
        '
        'txtPostcode
        '
        Me.txtPostcode.Location = New System.Drawing.Point(228, 143)
        Me.txtPostcode.MaxLength = 5
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(220, 20)
        Me.txtPostcode.TabIndex = 64
        '
        'lblPostcode1
        '
        Me.lblPostcode1.AutoSize = True
        Me.lblPostcode1.Location = New System.Drawing.Point(198, 142)
        Me.lblPostcode1.Name = "lblPostcode1"
        Me.lblPostcode1.Size = New System.Drawing.Size(10, 13)
        Me.lblPostcode1.TabIndex = 63
        Me.lblPostcode1.Text = ":"
        '
        'lblPostcode
        '
        Me.lblPostcode.AutoSize = True
        Me.lblPostcode.Location = New System.Drawing.Point(116, 143)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(63, 13)
        Me.lblPostcode.TabIndex = 62
        Me.lblPostcode.Text = "Post Code *"
        '
        'txtTown
        '
        Me.txtTown.Location = New System.Drawing.Point(228, 119)
        Me.txtTown.Name = "txtTown"
        Me.txtTown.Size = New System.Drawing.Size(220, 20)
        Me.txtTown.TabIndex = 61
        '
        'lblTown1
        '
        Me.lblTown1.AutoSize = True
        Me.lblTown1.Location = New System.Drawing.Point(198, 118)
        Me.lblTown1.Name = "lblTown1"
        Me.lblTown1.Size = New System.Drawing.Size(10, 13)
        Me.lblTown1.TabIndex = 60
        Me.lblTown1.Text = ":"
        '
        'lblTown
        '
        Me.lblTown.AutoSize = True
        Me.lblTown.Location = New System.Drawing.Point(116, 119)
        Me.lblTown.Name = "lblTown"
        Me.lblTown.Size = New System.Drawing.Size(34, 13)
        Me.lblTown.TabIndex = 59
        Me.lblTown.Text = "Town"
        '
        'lblInsurerId
        '
        Me.lblInsurerId.AutoSize = True
        Me.lblInsurerId.Location = New System.Drawing.Point(478, 28)
        Me.lblInsurerId.Name = "lblInsurerId"
        Me.lblInsurerId.Size = New System.Drawing.Size(0, 13)
        Me.lblInsurerId.TabIndex = 58
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        Me.cbStatus.Location = New System.Drawing.Point(228, 245)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(220, 21)
        Me.cbStatus.TabIndex = 57
        '
        'lblStatus1
        '
        Me.lblStatus1.AutoSize = True
        Me.lblStatus1.Location = New System.Drawing.Point(198, 252)
        Me.lblStatus1.Name = "lblStatus1"
        Me.lblStatus1.Size = New System.Drawing.Size(10, 13)
        Me.lblStatus1.TabIndex = 56
        Me.lblStatus1.Text = ":"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(116, 253)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 55
        Me.lblStatus.Text = "Status"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(389, 296)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(98, 23)
        Me.btnCancel.TabIndex = 54
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(266, 296)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(103, 23)
        Me.btnSubmit.TabIndex = 53
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(228, 174)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(160, 20)
        Me.txtState.TabIndex = 40
        '
        'lblState1
        '
        Me.lblState1.AutoSize = True
        Me.lblState1.Location = New System.Drawing.Point(198, 173)
        Me.lblState1.Name = "lblState1"
        Me.lblState1.Size = New System.Drawing.Size(10, 13)
        Me.lblState1.TabIndex = 39
        Me.lblState1.Text = ":"
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(116, 174)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(32, 13)
        Me.lblState.TabIndex = 38
        Me.lblState.Text = "State"
        '
        'txtAdd2
        '
        Me.txtAdd2.Location = New System.Drawing.Point(228, 88)
        Me.txtAdd2.Name = "txtAdd2"
        Me.txtAdd2.Size = New System.Drawing.Size(220, 20)
        Me.txtAdd2.TabIndex = 37
        '
        'lblAdd2_1
        '
        Me.lblAdd2_1.AutoSize = True
        Me.lblAdd2_1.Location = New System.Drawing.Point(198, 87)
        Me.lblAdd2_1.Name = "lblAdd2_1"
        Me.lblAdd2_1.Size = New System.Drawing.Size(10, 13)
        Me.lblAdd2_1.TabIndex = 36
        Me.lblAdd2_1.Text = ":"
        '
        'lblAdd2
        '
        Me.lblAdd2.AutoSize = True
        Me.lblAdd2.Location = New System.Drawing.Point(116, 88)
        Me.lblAdd2.Name = "lblAdd2"
        Me.lblAdd2.Size = New System.Drawing.Size(54, 13)
        Me.lblAdd2.TabIndex = 35
        Me.lblAdd2.Text = "Address 2"
        '
        'txtAdd1
        '
        Me.txtAdd1.Location = New System.Drawing.Point(228, 61)
        Me.txtAdd1.Name = "txtAdd1"
        Me.txtAdd1.Size = New System.Drawing.Size(220, 20)
        Me.txtAdd1.TabIndex = 34
        '
        'lblAdd1_1
        '
        Me.lblAdd1_1.AutoSize = True
        Me.lblAdd1_1.Location = New System.Drawing.Point(198, 60)
        Me.lblAdd1_1.Name = "lblAdd1_1"
        Me.lblAdd1_1.Size = New System.Drawing.Size(10, 13)
        Me.lblAdd1_1.TabIndex = 33
        Me.lblAdd1_1.Text = ":"
        '
        'lblAdd1
        '
        Me.lblAdd1.AutoSize = True
        Me.lblAdd1.Location = New System.Drawing.Point(116, 61)
        Me.lblAdd1.Name = "lblAdd1"
        Me.lblAdd1.Size = New System.Drawing.Size(61, 13)
        Me.lblAdd1.TabIndex = 32
        Me.lblAdd1.Text = "Address 1 *"
        '
        'txtInsurer
        '
        Me.txtInsurer.Location = New System.Drawing.Point(228, 29)
        Me.txtInsurer.Name = "txtInsurer"
        Me.txtInsurer.Size = New System.Drawing.Size(220, 20)
        Me.txtInsurer.TabIndex = 31
        '
        'lblInsurer1
        '
        Me.lblInsurer1.AutoSize = True
        Me.lblInsurer1.Location = New System.Drawing.Point(198, 28)
        Me.lblInsurer1.Name = "lblInsurer1"
        Me.lblInsurer1.Size = New System.Drawing.Size(10, 13)
        Me.lblInsurer1.TabIndex = 30
        Me.lblInsurer1.Text = ":"
        '
        'lblInsurer
        '
        Me.lblInsurer.AutoSize = True
        Me.lblInsurer.Location = New System.Drawing.Point(116, 29)
        Me.lblInsurer.Name = "lblInsurer"
        Me.lblInsurer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblInsurer.Size = New System.Drawing.Size(77, 13)
        Me.lblInsurer.TabIndex = 29
        Me.lblInsurer.Text = "Insurer Name *"
        '
        'gbView
        '
        Me.gbView.Controls.Add(Me.dgvInsurer)
        Me.gbView.Location = New System.Drawing.Point(12, 7)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(701, 146)
        Me.gbView.TabIndex = 3
        Me.gbView.TabStop = False
        Me.gbView.Text = "Insurer Details"
        '
        'dgvInsurer
        '
        Me.dgvInsurer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInsurer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tb_insurer_id})
        Me.dgvInsurer.Location = New System.Drawing.Point(7, 19)
        Me.dgvInsurer.Name = "dgvInsurer"
        Me.dgvInsurer.Size = New System.Drawing.Size(688, 121)
        Me.dgvInsurer.TabIndex = 4
        '
        'tb_insurer_id
        '
        Me.tb_insurer_id.HeaderText = "Contacts"
        Me.tb_insurer_id.Name = "tb_insurer_id"
        Me.tb_insurer_id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tb_insurer_id.Text = "View"
        Me.tb_insurer_id.ToolTipText = "View"
        Me.tb_insurer_id.UseColumnTextForLinkValue = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(173, 160)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 4
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(278, 160)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(395, 160)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEditContacts
        '
        Me.btnEditContacts.Location = New System.Drawing.Point(493, 160)
        Me.btnEditContacts.Name = "btnEditContacts"
        Me.btnEditContacts.Size = New System.Drawing.Size(94, 23)
        Me.btnEditContacts.TabIndex = 7
        Me.btnEditContacts.Text = "Edit Contacts"
        Me.btnEditContacts.UseVisualStyleBackColor = True
        '
        'Insurer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 561)
        Me.Controls.Add(Me.btnEditContacts)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.gbInsurer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Insurer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insurer"
        Me.gbInsurer.ResumeLayout(False)
        Me.gbInsurer.PerformLayout()
        Me.gbView.ResumeLayout(False)
        CType(Me.dgvInsurer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbInsurer As System.Windows.Forms.GroupBox
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents lblState1 As System.Windows.Forms.Label
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents txtAdd2 As System.Windows.Forms.TextBox
    Friend WithEvents lblAdd2_1 As System.Windows.Forms.Label
    Friend WithEvents lblAdd2 As System.Windows.Forms.Label
    Friend WithEvents txtAdd1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAdd1_1 As System.Windows.Forms.Label
    Friend WithEvents lblAdd1 As System.Windows.Forms.Label
    Friend WithEvents txtInsurer As System.Windows.Forms.TextBox
    Friend WithEvents lblInsurer1 As System.Windows.Forms.Label
    Friend WithEvents lblInsurer As System.Windows.Forms.Label
    Friend WithEvents gbView As System.Windows.Forms.GroupBox
    Friend WithEvents dgvInsurer As System.Windows.Forms.DataGridView
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lblInsurerId As System.Windows.Forms.Label
    Friend WithEvents txtTown As System.Windows.Forms.TextBox
    Friend WithEvents lblTown1 As System.Windows.Forms.Label
    Friend WithEvents lblTown As System.Windows.Forms.Label
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents lblPostcode1 As System.Windows.Forms.Label
    Friend WithEvents lblPostcode As System.Windows.Forms.Label
    Friend WithEvents txtInsurerCode As System.Windows.Forms.TextBox
    Friend WithEvents lblInsurerCode1 As System.Windows.Forms.Label
    Friend WithEvents lblInsurerCode As System.Windows.Forms.Label
    Friend WithEvents btnEditContacts As System.Windows.Forms.Button
    Friend WithEvents btnAddContact As System.Windows.Forms.Button
    Friend WithEvents tb_insurer_id As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents btnState As System.Windows.Forms.Button
End Class
