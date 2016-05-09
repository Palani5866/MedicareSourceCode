<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PremiumTable
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
        Me.gbMain = New System.Windows.Forms.GroupBox
        Me.lblPremiumID = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblPremiumCode1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvPremiumDetails = New System.Windows.Forms.DataGridView
        Me.Edit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Delete = New System.Windows.Forms.DataGridViewLinkColumn
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.txtPremiumCode = New System.Windows.Forms.TextBox
        Me.lblPremiumCode = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.dtpExpiry_Date = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpEffective_Date = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.lblPlanType = New System.Windows.Forms.Label
        Me.cbPaymentMode = New System.Windows.Forms.ComboBox
        Me.lblPaymentMode = New System.Windows.Forms.Label
        Me.cbParticipantType = New System.Windows.Forms.ComboBox
        Me.cbAgeTo = New System.Windows.Forms.ComboBox
        Me.txtPremiumAmt = New System.Windows.Forms.TextBox
        Me.lblPremiumAmt = New System.Windows.Forms.Label
        Me.lblAgeLimit = New System.Windows.Forms.Label
        Me.cbAgeFrm = New System.Windows.Forms.ComboBox
        Me.lblAgeLimit2 = New System.Windows.Forms.Label
        Me.gbPremiumDetails = New System.Windows.Forms.GroupBox
        Me.dgvPremium = New System.Windows.Forms.DataGridView
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.gbMain.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPremiumDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbPremiumDetails.SuspendLayout()
        CType(Me.dgvPremium, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.lblPremiumID)
        Me.gbMain.Controls.Add(Me.btnCancel)
        Me.gbMain.Controls.Add(Me.lblPremiumCode1)
        Me.gbMain.Controls.Add(Me.GroupBox2)
        Me.gbMain.Controls.Add(Me.btnSubmit)
        Me.gbMain.Controls.Add(Me.txtPremiumCode)
        Me.gbMain.Controls.Add(Me.lblPremiumCode)
        Me.gbMain.Controls.Add(Me.GroupBox1)
        Me.gbMain.Location = New System.Drawing.Point(12, 154)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(1053, 411)
        Me.gbMain.TabIndex = 31
        Me.gbMain.TabStop = False
        Me.gbMain.Text = "Add Premium Details"
        '
        'lblPremiumID
        '
        Me.lblPremiumID.AutoSize = True
        Me.lblPremiumID.Location = New System.Drawing.Point(950, 16)
        Me.lblPremiumID.Name = "lblPremiumID"
        Me.lblPremiumID.Size = New System.Drawing.Size(18, 13)
        Me.lblPremiumID.TabIndex = 28
        Me.lblPremiumID.Text = "ID"
        Me.lblPremiumID.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(532, 366)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 37
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblPremiumCode1
        '
        Me.lblPremiumCode1.AutoSize = True
        Me.lblPremiumCode1.Location = New System.Drawing.Point(117, 33)
        Me.lblPremiumCode1.Name = "lblPremiumCode1"
        Me.lblPremiumCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblPremiumCode1.TabIndex = 36
        Me.lblPremiumCode1.Text = ":"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvPremiumDetails)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 200)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1019, 160)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Premium Details"
        '
        'dgvPremiumDetails
        '
        Me.dgvPremiumDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPremiumDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Edit, Me.Delete})
        Me.dgvPremiumDetails.Location = New System.Drawing.Point(18, 31)
        Me.dgvPremiumDetails.Name = "dgvPremiumDetails"
        Me.dgvPremiumDetails.Size = New System.Drawing.Size(972, 107)
        Me.dgvPremiumDetails.TabIndex = 30
        '
        'Edit
        '
        Me.Edit.HeaderText = "Edit/Update"
        Me.Edit.Name = "Edit"
        Me.Edit.Text = "Edit/Update"
        Me.Edit.ToolTipText = "Edit/Update"
        Me.Edit.UseColumnTextForLinkValue = True
        '
        'Delete
        '
        Me.Delete.HeaderText = "Delete"
        Me.Delete.Name = "Delete"
        Me.Delete.Text = "Delete"
        Me.Delete.ToolTipText = "Delete"
        Me.Delete.UseColumnTextForLinkValue = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(428, 366)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 33
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtPremiumCode
        '
        Me.txtPremiumCode.Location = New System.Drawing.Point(149, 30)
        Me.txtPremiumCode.Name = "txtPremiumCode"
        Me.txtPremiumCode.Size = New System.Drawing.Size(273, 20)
        Me.txtPremiumCode.TabIndex = 35
        '
        'lblPremiumCode
        '
        Me.lblPremiumCode.AutoSize = True
        Me.lblPremiumCode.Location = New System.Drawing.Point(18, 33)
        Me.lblPremiumCode.Name = "lblPremiumCode"
        Me.lblPremiumCode.Size = New System.Drawing.Size(75, 13)
        Me.lblPremiumCode.TabIndex = 32
        Me.lblPremiumCode.Text = "Premuim Code"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbStatus)
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Controls.Add(Me.dtpExpiry_Date)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpEffective_Date)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.lblPlanType)
        Me.GroupBox1.Controls.Add(Me.cbPaymentMode)
        Me.GroupBox1.Controls.Add(Me.lblPaymentMode)
        Me.GroupBox1.Controls.Add(Me.cbParticipantType)
        Me.GroupBox1.Controls.Add(Me.cbAgeTo)
        Me.GroupBox1.Controls.Add(Me.txtPremiumAmt)
        Me.GroupBox1.Controls.Add(Me.lblPremiumAmt)
        Me.GroupBox1.Controls.Add(Me.lblAgeLimit)
        Me.GroupBox1.Controls.Add(Me.cbAgeFrm)
        Me.GroupBox1.Controls.Add(Me.lblAgeLimit2)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1019, 138)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Participants"
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.cbStatus.Location = New System.Drawing.Point(582, 66)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(150, 21)
        Me.cbStatus.TabIndex = 33
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(539, 68)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(43, 13)
        Me.lblStatus.TabIndex = 32
        Me.lblStatus.Text = "Status :"
        '
        'dtpExpiry_Date
        '
        Me.dtpExpiry_Date.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.dtpExpiry_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpiry_Date.Location = New System.Drawing.Point(334, 66)
        Me.dtpExpiry_Date.Name = "dtpExpiry_Date"
        Me.dtpExpiry_Date.Size = New System.Drawing.Size(150, 20)
        Me.dtpExpiry_Date.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(262, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Expiry Date :"
        '
        'dtpEffective_Date
        '
        Me.dtpEffective_Date.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.dtpEffective_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEffective_Date.Location = New System.Drawing.Point(93, 66)
        Me.dtpEffective_Date.Name = "dtpEffective_Date"
        Me.dtpEffective_Date.Size = New System.Drawing.Size(153, 20)
        Me.dtpEffective_Date.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Effective Date :"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(445, 100)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 27
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblPlanType
        '
        Me.lblPlanType.AutoSize = True
        Me.lblPlanType.Location = New System.Drawing.Point(6, 35)
        Me.lblPlanType.Name = "lblPlanType"
        Me.lblPlanType.Size = New System.Drawing.Size(90, 13)
        Me.lblPlanType.TabIndex = 25
        Me.lblPlanType.Text = "Participant Type :"
        '
        'cbPaymentMode
        '
        Me.cbPaymentMode.FormattingEnabled = True
        Me.cbPaymentMode.Location = New System.Drawing.Point(849, 31)
        Me.cbPaymentMode.Name = "cbPaymentMode"
        Me.cbPaymentMode.Size = New System.Drawing.Size(150, 21)
        Me.cbPaymentMode.TabIndex = 24
        '
        'lblPaymentMode
        '
        Me.lblPaymentMode.AutoSize = True
        Me.lblPaymentMode.Location = New System.Drawing.Point(756, 36)
        Me.lblPaymentMode.Name = "lblPaymentMode"
        Me.lblPaymentMode.Size = New System.Drawing.Size(84, 13)
        Me.lblPaymentMode.TabIndex = 22
        Me.lblPaymentMode.Text = "Payment Mode :"
        '
        'cbParticipantType
        '
        Me.cbParticipantType.FormattingEnabled = True
        Me.cbParticipantType.Items.AddRange(New Object() {"MEMBER", "SPOUSE", "CHILD"})
        Me.cbParticipantType.Location = New System.Drawing.Point(96, 30)
        Me.cbParticipantType.Name = "cbParticipantType"
        Me.cbParticipantType.Size = New System.Drawing.Size(150, 21)
        Me.cbParticipantType.TabIndex = 26
        '
        'cbAgeTo
        '
        Me.cbAgeTo.FormattingEnabled = True
        Me.cbAgeTo.Location = New System.Drawing.Point(418, 30)
        Me.cbAgeTo.Name = "cbAgeTo"
        Me.cbAgeTo.Size = New System.Drawing.Size(66, 21)
        Me.cbAgeTo.TabIndex = 18
        '
        'txtPremiumAmt
        '
        Me.txtPremiumAmt.Location = New System.Drawing.Point(582, 31)
        Me.txtPremiumAmt.Name = "txtPremiumAmt"
        Me.txtPremiumAmt.Size = New System.Drawing.Size(150, 20)
        Me.txtPremiumAmt.TabIndex = 21
        Me.txtPremiumAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPremiumAmt
        '
        Me.lblPremiumAmt.AutoSize = True
        Me.lblPremiumAmt.Location = New System.Drawing.Point(490, 34)
        Me.lblPremiumAmt.Name = "lblPremiumAmt"
        Me.lblPremiumAmt.Size = New System.Drawing.Size(92, 13)
        Me.lblPremiumAmt.TabIndex = 19
        Me.lblPremiumAmt.Text = "Premium Amount :"
        '
        'lblAgeLimit
        '
        Me.lblAgeLimit.AutoSize = True
        Me.lblAgeLimit.Location = New System.Drawing.Point(262, 32)
        Me.lblAgeLimit.Name = "lblAgeLimit"
        Me.lblAgeLimit.Size = New System.Drawing.Size(56, 13)
        Me.lblAgeLimit.TabIndex = 14
        Me.lblAgeLimit.Text = "Age Limit :"
        '
        'cbAgeFrm
        '
        Me.cbAgeFrm.FormattingEnabled = True
        Me.cbAgeFrm.Location = New System.Drawing.Point(334, 30)
        Me.cbAgeFrm.Name = "cbAgeFrm"
        Me.cbAgeFrm.Size = New System.Drawing.Size(62, 21)
        Me.cbAgeFrm.TabIndex = 16
        '
        'lblAgeLimit2
        '
        Me.lblAgeLimit2.AutoSize = True
        Me.lblAgeLimit2.Location = New System.Drawing.Point(402, 32)
        Me.lblAgeLimit2.Name = "lblAgeLimit2"
        Me.lblAgeLimit2.Size = New System.Drawing.Size(10, 13)
        Me.lblAgeLimit2.TabIndex = 17
        Me.lblAgeLimit2.Text = "-"
        '
        'gbPremiumDetails
        '
        Me.gbPremiumDetails.Controls.Add(Me.dgvPremium)
        Me.gbPremiumDetails.Controls.Add(Me.btnDelete)
        Me.gbPremiumDetails.Controls.Add(Me.btnEdit)
        Me.gbPremiumDetails.Controls.Add(Me.btnNew)
        Me.gbPremiumDetails.Location = New System.Drawing.Point(192, 2)
        Me.gbPremiumDetails.Name = "gbPremiumDetails"
        Me.gbPremiumDetails.Size = New System.Drawing.Size(670, 146)
        Me.gbPremiumDetails.TabIndex = 32
        Me.gbPremiumDetails.TabStop = False
        Me.gbPremiumDetails.Text = "Premium Table Details"
        '
        'dgvPremium
        '
        Me.dgvPremium.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPremium.Location = New System.Drawing.Point(21, 16)
        Me.dgvPremium.Name = "dgvPremium"
        Me.dgvPremium.Size = New System.Drawing.Size(622, 95)
        Me.dgvPremium.TabIndex = 31
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(397, 117)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 29
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(275, 117)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 28
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(148, 117)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 27
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'PremiumTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 582)
        Me.Controls.Add(Me.gbPremiumDetails)
        Me.Controls.Add(Me.gbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "PremiumTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PremiumTable"
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvPremiumDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbPremiumDetails.ResumeLayout(False)
        CType(Me.dgvPremium, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbMain As System.Windows.Forms.GroupBox
    Friend WithEvents lblPremiumCode1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPremiumDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtPremiumCode As System.Windows.Forms.TextBox
    Friend WithEvents lblPremiumCode As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblPlanType As System.Windows.Forms.Label
    Friend WithEvents cbPaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblPaymentMode As System.Windows.Forms.Label
    Friend WithEvents cbParticipantType As System.Windows.Forms.ComboBox
    Friend WithEvents cbAgeTo As System.Windows.Forms.ComboBox
    Friend WithEvents txtPremiumAmt As System.Windows.Forms.TextBox
    Friend WithEvents lblPremiumAmt As System.Windows.Forms.Label
    Friend WithEvents lblAgeLimit As System.Windows.Forms.Label
    Friend WithEvents cbAgeFrm As System.Windows.Forms.ComboBox
    Friend WithEvents lblAgeLimit2 As System.Windows.Forms.Label
    Friend WithEvents gbPremiumDetails As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents dgvPremium As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblPremiumID As System.Windows.Forms.Label
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Delete As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dtpExpiry_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpEffective_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
End Class
