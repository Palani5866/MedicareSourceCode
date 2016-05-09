<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Insurer_Contact_Details
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
        Me.gbContactDetails = New System.Windows.Forms.GroupBox
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.txtCFax = New System.Windows.Forms.TextBox
        Me.lblCFax1 = New System.Windows.Forms.Label
        Me.lblCFax = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.txtCEmail = New System.Windows.Forms.TextBox
        Me.lblCEmail1 = New System.Windows.Forms.Label
        Me.lblCEmail = New System.Windows.Forms.Label
        Me.txtCTel = New System.Windows.Forms.TextBox
        Me.lblCTel1 = New System.Windows.Forms.Label
        Me.lblCTel = New System.Windows.Forms.Label
        Me.txtCDesig = New System.Windows.Forms.TextBox
        Me.lblCDesig1 = New System.Windows.Forms.Label
        Me.lblCDesig = New System.Windows.Forms.Label
        Me.txtCName = New System.Windows.Forms.TextBox
        Me.lblCName1 = New System.Windows.Forms.Label
        Me.lblCName = New System.Windows.Forms.Label
        Me.gbInsurerContactDetails = New System.Windows.Forms.GroupBox
        Me.dgvCDetails = New System.Windows.Forms.DataGridView
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.lblCContactID = New System.Windows.Forms.Label
        Me.lbltbInsurerContactID = New System.Windows.Forms.Label
        Me.gbContactDetails.SuspendLayout()
        Me.gbInsurerContactDetails.SuspendLayout()
        CType(Me.dgvCDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbContactDetails
        '
        Me.gbContactDetails.Controls.Add(Me.btnSubmit)
        Me.gbContactDetails.Controls.Add(Me.txtCFax)
        Me.gbContactDetails.Controls.Add(Me.lblCFax1)
        Me.gbContactDetails.Controls.Add(Me.lblCFax)
        Me.gbContactDetails.Controls.Add(Me.btnAdd)
        Me.gbContactDetails.Controls.Add(Me.txtCEmail)
        Me.gbContactDetails.Controls.Add(Me.lblCEmail1)
        Me.gbContactDetails.Controls.Add(Me.lblCEmail)
        Me.gbContactDetails.Controls.Add(Me.txtCTel)
        Me.gbContactDetails.Controls.Add(Me.lblCTel1)
        Me.gbContactDetails.Controls.Add(Me.lblCTel)
        Me.gbContactDetails.Controls.Add(Me.txtCDesig)
        Me.gbContactDetails.Controls.Add(Me.lblCDesig1)
        Me.gbContactDetails.Controls.Add(Me.lblCDesig)
        Me.gbContactDetails.Controls.Add(Me.txtCName)
        Me.gbContactDetails.Controls.Add(Me.lblCName1)
        Me.gbContactDetails.Controls.Add(Me.lblCName)
        Me.gbContactDetails.Location = New System.Drawing.Point(13, 227)
        Me.gbContactDetails.Name = "gbContactDetails"
        Me.gbContactDetails.Size = New System.Drawing.Size(654, 236)
        Me.gbContactDetails.TabIndex = 66
        Me.gbContactDetails.TabStop = False
        Me.gbContactDetails.Text = "Contact Details"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(303, 187)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(101, 23)
        Me.btnSubmit.TabIndex = 64
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtCFax
        '
        Me.txtCFax.Location = New System.Drawing.Point(233, 112)
        Me.txtCFax.MaxLength = 14
        Me.txtCFax.Name = "txtCFax"
        Me.txtCFax.Size = New System.Drawing.Size(220, 20)
        Me.txtCFax.TabIndex = 63
        '
        'lblCFax1
        '
        Me.lblCFax1.AutoSize = True
        Me.lblCFax1.Location = New System.Drawing.Point(203, 111)
        Me.lblCFax1.Name = "lblCFax1"
        Me.lblCFax1.Size = New System.Drawing.Size(10, 13)
        Me.lblCFax1.TabIndex = 62
        Me.lblCFax1.Text = ":"
        '
        'lblCFax
        '
        Me.lblCFax.AutoSize = True
        Me.lblCFax.Location = New System.Drawing.Point(121, 112)
        Me.lblCFax.Name = "lblCFax"
        Me.lblCFax.Size = New System.Drawing.Size(34, 13)
        Me.lblCFax.TabIndex = 61
        Me.lblCFax.Text = "Fax #"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(185, 187)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 23)
        Me.btnAdd.TabIndex = 59
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtCEmail
        '
        Me.txtCEmail.Location = New System.Drawing.Point(233, 140)
        Me.txtCEmail.Name = "txtCEmail"
        Me.txtCEmail.Size = New System.Drawing.Size(220, 20)
        Me.txtCEmail.TabIndex = 58
        '
        'lblCEmail1
        '
        Me.lblCEmail1.AutoSize = True
        Me.lblCEmail1.Location = New System.Drawing.Point(203, 139)
        Me.lblCEmail1.Name = "lblCEmail1"
        Me.lblCEmail1.Size = New System.Drawing.Size(10, 13)
        Me.lblCEmail1.TabIndex = 57
        Me.lblCEmail1.Text = ":"
        '
        'lblCEmail
        '
        Me.lblCEmail.AutoSize = True
        Me.lblCEmail.Location = New System.Drawing.Point(121, 140)
        Me.lblCEmail.Name = "lblCEmail"
        Me.lblCEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblCEmail.TabIndex = 56
        Me.lblCEmail.Text = "Email"
        '
        'txtCTel
        '
        Me.txtCTel.Location = New System.Drawing.Point(233, 83)
        Me.txtCTel.MaxLength = 14
        Me.txtCTel.Name = "txtCTel"
        Me.txtCTel.Size = New System.Drawing.Size(220, 20)
        Me.txtCTel.TabIndex = 55
        '
        'lblCTel1
        '
        Me.lblCTel1.AutoSize = True
        Me.lblCTel1.Location = New System.Drawing.Point(203, 82)
        Me.lblCTel1.Name = "lblCTel1"
        Me.lblCTel1.Size = New System.Drawing.Size(10, 13)
        Me.lblCTel1.TabIndex = 54
        Me.lblCTel1.Text = ":"
        '
        'lblCTel
        '
        Me.lblCTel.AutoSize = True
        Me.lblCTel.Location = New System.Drawing.Point(121, 83)
        Me.lblCTel.Name = "lblCTel"
        Me.lblCTel.Size = New System.Drawing.Size(32, 13)
        Me.lblCTel.TabIndex = 53
        Me.lblCTel.Text = "Tel #"
        '
        'txtCDesig
        '
        Me.txtCDesig.Location = New System.Drawing.Point(233, 55)
        Me.txtCDesig.Name = "txtCDesig"
        Me.txtCDesig.Size = New System.Drawing.Size(220, 20)
        Me.txtCDesig.TabIndex = 52
        '
        'lblCDesig1
        '
        Me.lblCDesig1.AutoSize = True
        Me.lblCDesig1.Location = New System.Drawing.Point(203, 54)
        Me.lblCDesig1.Name = "lblCDesig1"
        Me.lblCDesig1.Size = New System.Drawing.Size(10, 13)
        Me.lblCDesig1.TabIndex = 51
        Me.lblCDesig1.Text = ":"
        '
        'lblCDesig
        '
        Me.lblCDesig.AutoSize = True
        Me.lblCDesig.Location = New System.Drawing.Point(118, 55)
        Me.lblCDesig.Name = "lblCDesig"
        Me.lblCDesig.Size = New System.Drawing.Size(70, 13)
        Me.lblCDesig.TabIndex = 50
        Me.lblCDesig.Text = "Designation *"
        '
        'txtCName
        '
        Me.txtCName.Location = New System.Drawing.Point(233, 29)
        Me.txtCName.Name = "txtCName"
        Me.txtCName.Size = New System.Drawing.Size(220, 20)
        Me.txtCName.TabIndex = 49
        '
        'lblCName1
        '
        Me.lblCName1.AutoSize = True
        Me.lblCName1.Location = New System.Drawing.Point(203, 28)
        Me.lblCName1.Name = "lblCName1"
        Me.lblCName1.Size = New System.Drawing.Size(10, 13)
        Me.lblCName1.TabIndex = 48
        Me.lblCName1.Text = ":"
        '
        'lblCName
        '
        Me.lblCName.AutoSize = True
        Me.lblCName.Location = New System.Drawing.Point(118, 28)
        Me.lblCName.Name = "lblCName"
        Me.lblCName.Size = New System.Drawing.Size(42, 13)
        Me.lblCName.TabIndex = 47
        Me.lblCName.Text = "Name *"
        '
        'gbInsurerContactDetails
        '
        Me.gbInsurerContactDetails.Controls.Add(Me.dgvCDetails)
        Me.gbInsurerContactDetails.Location = New System.Drawing.Point(13, 13)
        Me.gbInsurerContactDetails.Name = "gbInsurerContactDetails"
        Me.gbInsurerContactDetails.Size = New System.Drawing.Size(653, 140)
        Me.gbInsurerContactDetails.TabIndex = 67
        Me.gbInsurerContactDetails.TabStop = False
        Me.gbInsurerContactDetails.Text = "Insurer Contact Details"
        '
        'dgvCDetails
        '
        Me.dgvCDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCDetails.Location = New System.Drawing.Point(20, 29)
        Me.dgvCDetails.Name = "dgvCDetails"
        Me.dgvCDetails.Size = New System.Drawing.Size(614, 92)
        Me.dgvCDetails.TabIndex = 61
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(198, 169)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 68
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(326, 169)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 69
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblCContactID
        '
        Me.lblCContactID.AutoSize = True
        Me.lblCContactID.Location = New System.Drawing.Point(504, 470)
        Me.lblCContactID.Name = "lblCContactID"
        Me.lblCContactID.Size = New System.Drawing.Size(0, 13)
        Me.lblCContactID.TabIndex = 70
        '
        'lbltbInsurerContactID
        '
        Me.lbltbInsurerContactID.AutoSize = True
        Me.lbltbInsurerContactID.Location = New System.Drawing.Point(353, 470)
        Me.lbltbInsurerContactID.Name = "lbltbInsurerContactID"
        Me.lbltbInsurerContactID.Size = New System.Drawing.Size(0, 13)
        Me.lbltbInsurerContactID.TabIndex = 71
        '
        'Insurer_Contact_Details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 484)
        Me.Controls.Add(Me.lbltbInsurerContactID)
        Me.Controls.Add(Me.lblCContactID)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.gbInsurerContactDetails)
        Me.Controls.Add(Me.gbContactDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Insurer_Contact_Details"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insurer_Contact_Details"
        Me.gbContactDetails.ResumeLayout(False)
        Me.gbContactDetails.PerformLayout()
        Me.gbInsurerContactDetails.ResumeLayout(False)
        CType(Me.dgvCDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbContactDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtCFax As System.Windows.Forms.TextBox
    Friend WithEvents lblCFax1 As System.Windows.Forms.Label
    Friend WithEvents lblCFax As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtCEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblCEmail1 As System.Windows.Forms.Label
    Friend WithEvents lblCEmail As System.Windows.Forms.Label
    Friend WithEvents txtCTel As System.Windows.Forms.TextBox
    Friend WithEvents lblCTel1 As System.Windows.Forms.Label
    Friend WithEvents lblCTel As System.Windows.Forms.Label
    Friend WithEvents txtCDesig As System.Windows.Forms.TextBox
    Friend WithEvents lblCDesig1 As System.Windows.Forms.Label
    Friend WithEvents lblCDesig As System.Windows.Forms.Label
    Friend WithEvents txtCName As System.Windows.Forms.TextBox
    Friend WithEvents lblCName1 As System.Windows.Forms.Label
    Friend WithEvents lblCName As System.Windows.Forms.Label
    Friend WithEvents gbInsurerContactDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblCContactID As System.Windows.Forms.Label
    Friend WithEvents lbltbInsurerContactID As System.Windows.Forms.Label
End Class
