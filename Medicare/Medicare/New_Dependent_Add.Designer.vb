<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class New_Dependent_Add
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
        Me.lblPolicyID = New System.Windows.Forms.Label
        Me.lblMemberID = New System.Windows.Forms.Label
        Me.gbAddDependant = New System.Windows.Forms.GroupBox
        Me.btnTitle = New System.Windows.Forms.Button
        Me.txtDependent_FirstName = New System.Windows.Forms.TextBox
        Me.lblEffectiveDate1 = New System.Windows.Forms.Label
        Me.dtpEffectiveDate = New System.Windows.Forms.DateTimePicker
        Me.lblEffectiveDate = New System.Windows.Forms.Label
        Me.txtDependent_Title = New System.Windows.Forms.TextBox
        Me.lblDependent_Height = New System.Windows.Forms.Label
        Me.lblDependent_Occupation = New System.Windows.Forms.Label
        Me.lblDependent_Sex = New System.Windows.Forms.Label
        Me.lblDependent_Race = New System.Windows.Forms.Label
        Me.btnDependent_Title = New System.Windows.Forms.Button
        Me.txtDependent_Occupation = New System.Windows.Forms.TextBox
        Me.txtDependent_Height = New System.Windows.Forms.TextBox
        Me.fowDependent_Race = New System.Windows.Forms.FlowLayoutPanel
        Me.rdiDependent_Race_Malay = New System.Windows.Forms.RadioButton
        Me.rdiDependent_Race_Chinese = New System.Windows.Forms.RadioButton
        Me.rdiDependent_Race_Indian = New System.Windows.Forms.RadioButton
        Me.rdiDependent_Race_Others = New System.Windows.Forms.RadioButton
        Me.fowDependent_Sex = New System.Windows.Forms.FlowLayoutPanel
        Me.rdiDependent_Sex_Male = New System.Windows.Forms.RadioButton
        Me.rdiDependent_Sex_Female = New System.Windows.Forms.RadioButton
        Me.txtDependent_NRIC = New System.Windows.Forms.TextBox
        Me.lblDependent_DOB = New System.Windows.Forms.Label
        Me.lblDependent_Title = New System.Windows.Forms.Label
        Me.lblDependent_FirstName = New System.Windows.Forms.Label
        Me.cmbDependent_Relationship = New System.Windows.Forms.ComboBox
        Me.lblDependent_Relationship = New System.Windows.Forms.Label
        Me.lblDependent_Department = New System.Windows.Forms.Label
        Me.txtDependent_Department = New System.Windows.Forms.TextBox
        Me.txtDependent_Weight = New System.Windows.Forms.TextBox
        Me.lblDependent_Weight = New System.Windows.Forms.Label
        Me.txtDependent_Age = New System.Windows.Forms.TextBox
        Me.lblDependent_Age = New System.Windows.Forms.Label
        Me.lblDependent_ArmForceID = New System.Windows.Forms.Label
        Me.txtDependent_ArmForceID = New System.Windows.Forms.TextBox
        Me.lblDependent_MaritalStatus = New System.Windows.Forms.Label
        Me.fowDependent_MaritalStatus = New System.Windows.Forms.FlowLayoutPanel
        Me.rdiDependent_MaritalStatus_Single = New System.Windows.Forms.RadioButton
        Me.rdiDependent_MaritalStatus_Married = New System.Windows.Forms.RadioButton
        Me.rdiDependent_MaritalStatus_Widowed = New System.Windows.Forms.RadioButton
        Me.rdiDependent_MaritalStatus_Divorced = New System.Windows.Forms.RadioButton
        Me.dtpDependent_DOB = New System.Windows.Forms.DateTimePicker
        Me.txtDependent_OldIC = New System.Windows.Forms.TextBox
        Me.lblDependent_OldIC = New System.Windows.Forms.Label
        Me.lblDependent_NRIC1 = New System.Windows.Forms.Label
        Me.btnDependent_Add = New System.Windows.Forms.Button
        Me.lblAdmin = New System.Windows.Forms.Label
        Me.gbAddDependant.SuspendLayout()
        Me.fowDependent_Race.SuspendLayout()
        Me.fowDependent_Sex.SuspendLayout()
        Me.fowDependent_MaritalStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPolicyID
        '
        Me.lblPolicyID.AutoSize = True
        Me.lblPolicyID.Location = New System.Drawing.Point(42, 407)
        Me.lblPolicyID.Name = "lblPolicyID"
        Me.lblPolicyID.Size = New System.Drawing.Size(56, 13)
        Me.lblPolicyID.TabIndex = 111
        Me.lblPolicyID.Text = "POLICYID"
        Me.lblPolicyID.Visible = False
        '
        'lblMemberID
        '
        Me.lblMemberID.AutoSize = True
        Me.lblMemberID.Location = New System.Drawing.Point(153, 407)
        Me.lblMemberID.Name = "lblMemberID"
        Me.lblMemberID.Size = New System.Drawing.Size(65, 13)
        Me.lblMemberID.TabIndex = 112
        Me.lblMemberID.Text = "MEMBERID"
        Me.lblMemberID.Visible = False
        '
        'gbAddDependant
        '
        Me.gbAddDependant.Controls.Add(Me.btnTitle)
        Me.gbAddDependant.Controls.Add(Me.txtDependent_FirstName)
        Me.gbAddDependant.Controls.Add(Me.lblEffectiveDate1)
        Me.gbAddDependant.Controls.Add(Me.dtpEffectiveDate)
        Me.gbAddDependant.Controls.Add(Me.lblEffectiveDate)
        Me.gbAddDependant.Controls.Add(Me.txtDependent_Title)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_Height)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_Occupation)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_Sex)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_Race)
        Me.gbAddDependant.Controls.Add(Me.btnDependent_Title)
        Me.gbAddDependant.Controls.Add(Me.txtDependent_Occupation)
        Me.gbAddDependant.Controls.Add(Me.txtDependent_Height)
        Me.gbAddDependant.Controls.Add(Me.fowDependent_Race)
        Me.gbAddDependant.Controls.Add(Me.fowDependent_Sex)
        Me.gbAddDependant.Controls.Add(Me.txtDependent_NRIC)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_DOB)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_Title)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_FirstName)
        Me.gbAddDependant.Controls.Add(Me.cmbDependent_Relationship)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_Relationship)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_Department)
        Me.gbAddDependant.Controls.Add(Me.txtDependent_Department)
        Me.gbAddDependant.Controls.Add(Me.txtDependent_Weight)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_Weight)
        Me.gbAddDependant.Controls.Add(Me.txtDependent_Age)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_Age)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_ArmForceID)
        Me.gbAddDependant.Controls.Add(Me.txtDependent_ArmForceID)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_MaritalStatus)
        Me.gbAddDependant.Controls.Add(Me.fowDependent_MaritalStatus)
        Me.gbAddDependant.Controls.Add(Me.dtpDependent_DOB)
        Me.gbAddDependant.Controls.Add(Me.txtDependent_OldIC)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_OldIC)
        Me.gbAddDependant.Controls.Add(Me.lblDependent_NRIC1)
        Me.gbAddDependant.Controls.Add(Me.btnDependent_Add)
        Me.gbAddDependant.Location = New System.Drawing.Point(6, 23)
        Me.gbAddDependant.Name = "gbAddDependant"
        Me.gbAddDependant.Size = New System.Drawing.Size(872, 369)
        Me.gbAddDependant.TabIndex = 116
        Me.gbAddDependant.TabStop = False
        Me.gbAddDependant.Text = "Add Dependent Details"
        '
        'btnTitle
        '
        Me.btnTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTitle.Location = New System.Drawing.Point(301, 27)
        Me.btnTitle.Name = "btnTitle"
        Me.btnTitle.Size = New System.Drawing.Size(25, 20)
        Me.btnTitle.TabIndex = 151
        Me.btnTitle.Text = "..."
        Me.btnTitle.UseVisualStyleBackColor = True
        '
        'txtDependent_FirstName
        '
        Me.txtDependent_FirstName.BackColor = System.Drawing.Color.LightGray
        Me.txtDependent_FirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDependent_FirstName.Location = New System.Drawing.Point(174, 53)
        Me.txtDependent_FirstName.MaxLength = 50
        Me.txtDependent_FirstName.Name = "txtDependent_FirstName"
        Me.txtDependent_FirstName.Size = New System.Drawing.Size(450, 20)
        Me.txtDependent_FirstName.TabIndex = 150
        '
        'lblEffectiveDate1
        '
        Me.lblEffectiveDate1.AutoSize = True
        Me.lblEffectiveDate1.Location = New System.Drawing.Point(460, 278)
        Me.lblEffectiveDate1.Name = "lblEffectiveDate1"
        Me.lblEffectiveDate1.Size = New System.Drawing.Size(10, 13)
        Me.lblEffectiveDate1.TabIndex = 149
        Me.lblEffectiveDate1.Text = ":"
        '
        'dtpEffectiveDate
        '
        Me.dtpEffectiveDate.Location = New System.Drawing.Point(483, 274)
        Me.dtpEffectiveDate.Name = "dtpEffectiveDate"
        Me.dtpEffectiveDate.Size = New System.Drawing.Size(206, 20)
        Me.dtpEffectiveDate.TabIndex = 148
        '
        'lblEffectiveDate
        '
        Me.lblEffectiveDate.AutoSize = True
        Me.lblEffectiveDate.Location = New System.Drawing.Point(368, 278)
        Me.lblEffectiveDate.Name = "lblEffectiveDate"
        Me.lblEffectiveDate.Size = New System.Drawing.Size(75, 13)
        Me.lblEffectiveDate.TabIndex = 147
        Me.lblEffectiveDate.Text = "Effective Date"
        '
        'txtDependent_Title
        '
        Me.txtDependent_Title.Location = New System.Drawing.Point(174, 26)
        Me.txtDependent_Title.MaxLength = 10
        Me.txtDependent_Title.Name = "txtDependent_Title"
        Me.txtDependent_Title.ReadOnly = True
        Me.txtDependent_Title.Size = New System.Drawing.Size(121, 20)
        Me.txtDependent_Title.TabIndex = 117
        Me.txtDependent_Title.TabStop = False
        '
        'lblDependent_Height
        '
        Me.lblDependent_Height.AutoSize = True
        Me.lblDependent_Height.Location = New System.Drawing.Point(56, 222)
        Me.lblDependent_Height.Name = "lblDependent_Height"
        Me.lblDependent_Height.Size = New System.Drawing.Size(64, 13)
        Me.lblDependent_Height.TabIndex = 138
        Me.lblDependent_Height.Text = "Height (cm):"
        '
        'lblDependent_Occupation
        '
        Me.lblDependent_Occupation.AutoSize = True
        Me.lblDependent_Occupation.Location = New System.Drawing.Point(56, 248)
        Me.lblDependent_Occupation.Name = "lblDependent_Occupation"
        Me.lblDependent_Occupation.Size = New System.Drawing.Size(65, 13)
        Me.lblDependent_Occupation.TabIndex = 142
        Me.lblDependent_Occupation.Text = "Occupation:"
        '
        'lblDependent_Sex
        '
        Me.lblDependent_Sex.AutoSize = True
        Me.lblDependent_Sex.Location = New System.Drawing.Point(56, 194)
        Me.lblDependent_Sex.Name = "lblDependent_Sex"
        Me.lblDependent_Sex.Size = New System.Drawing.Size(28, 13)
        Me.lblDependent_Sex.TabIndex = 136
        Me.lblDependent_Sex.Text = "Sex:"
        '
        'lblDependent_Race
        '
        Me.lblDependent_Race.AutoSize = True
        Me.lblDependent_Race.Location = New System.Drawing.Point(56, 136)
        Me.lblDependent_Race.Name = "lblDependent_Race"
        Me.lblDependent_Race.Size = New System.Drawing.Size(36, 13)
        Me.lblDependent_Race.TabIndex = 130
        Me.lblDependent_Race.Text = "Race:"
        '
        'btnDependent_Title
        '
        Me.btnDependent_Title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDependent_Title.Location = New System.Drawing.Point(301, 27)
        Me.btnDependent_Title.Name = "btnDependent_Title"
        Me.btnDependent_Title.Size = New System.Drawing.Size(25, 0)
        Me.btnDependent_Title.TabIndex = 118
        Me.btnDependent_Title.Text = "..."
        Me.btnDependent_Title.UseVisualStyleBackColor = True
        '
        'txtDependent_Occupation
        '
        Me.txtDependent_Occupation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDependent_Occupation.Location = New System.Drawing.Point(174, 244)
        Me.txtDependent_Occupation.MaxLength = 50
        Me.txtDependent_Occupation.Name = "txtDependent_Occupation"
        Me.txtDependent_Occupation.Size = New System.Drawing.Size(145, 20)
        Me.txtDependent_Occupation.TabIndex = 143
        '
        'txtDependent_Height
        '
        Me.txtDependent_Height.BackColor = System.Drawing.Color.LightGray
        Me.txtDependent_Height.Location = New System.Drawing.Point(174, 218)
        Me.txtDependent_Height.Name = "txtDependent_Height"
        Me.txtDependent_Height.Size = New System.Drawing.Size(100, 20)
        Me.txtDependent_Height.TabIndex = 139
        '
        'fowDependent_Race
        '
        Me.fowDependent_Race.Controls.Add(Me.rdiDependent_Race_Malay)
        Me.fowDependent_Race.Controls.Add(Me.rdiDependent_Race_Chinese)
        Me.fowDependent_Race.Controls.Add(Me.rdiDependent_Race_Indian)
        Me.fowDependent_Race.Controls.Add(Me.rdiDependent_Race_Others)
        Me.fowDependent_Race.Location = New System.Drawing.Point(174, 131)
        Me.fowDependent_Race.Name = "fowDependent_Race"
        Me.fowDependent_Race.Size = New System.Drawing.Size(288, 23)
        Me.fowDependent_Race.TabIndex = 131
        '
        'rdiDependent_Race_Malay
        '
        Me.rdiDependent_Race_Malay.AutoSize = True
        Me.rdiDependent_Race_Malay.Location = New System.Drawing.Point(3, 3)
        Me.rdiDependent_Race_Malay.Name = "rdiDependent_Race_Malay"
        Me.rdiDependent_Race_Malay.Size = New System.Drawing.Size(53, 17)
        Me.rdiDependent_Race_Malay.TabIndex = 0
        Me.rdiDependent_Race_Malay.TabStop = True
        Me.rdiDependent_Race_Malay.Text = "Malay"
        Me.rdiDependent_Race_Malay.UseVisualStyleBackColor = True
        '
        'rdiDependent_Race_Chinese
        '
        Me.rdiDependent_Race_Chinese.AutoSize = True
        Me.rdiDependent_Race_Chinese.Location = New System.Drawing.Point(62, 3)
        Me.rdiDependent_Race_Chinese.Name = "rdiDependent_Race_Chinese"
        Me.rdiDependent_Race_Chinese.Size = New System.Drawing.Size(63, 17)
        Me.rdiDependent_Race_Chinese.TabIndex = 1
        Me.rdiDependent_Race_Chinese.TabStop = True
        Me.rdiDependent_Race_Chinese.Text = "Chinese"
        Me.rdiDependent_Race_Chinese.UseVisualStyleBackColor = True
        '
        'rdiDependent_Race_Indian
        '
        Me.rdiDependent_Race_Indian.AutoSize = True
        Me.rdiDependent_Race_Indian.Location = New System.Drawing.Point(131, 3)
        Me.rdiDependent_Race_Indian.Name = "rdiDependent_Race_Indian"
        Me.rdiDependent_Race_Indian.Size = New System.Drawing.Size(54, 17)
        Me.rdiDependent_Race_Indian.TabIndex = 2
        Me.rdiDependent_Race_Indian.TabStop = True
        Me.rdiDependent_Race_Indian.Text = "Indian"
        Me.rdiDependent_Race_Indian.UseVisualStyleBackColor = True
        '
        'rdiDependent_Race_Others
        '
        Me.rdiDependent_Race_Others.AutoSize = True
        Me.rdiDependent_Race_Others.Location = New System.Drawing.Point(191, 3)
        Me.rdiDependent_Race_Others.Name = "rdiDependent_Race_Others"
        Me.rdiDependent_Race_Others.Size = New System.Drawing.Size(56, 17)
        Me.rdiDependent_Race_Others.TabIndex = 3
        Me.rdiDependent_Race_Others.TabStop = True
        Me.rdiDependent_Race_Others.Text = "Others"
        Me.rdiDependent_Race_Others.UseVisualStyleBackColor = True
        '
        'fowDependent_Sex
        '
        Me.fowDependent_Sex.Controls.Add(Me.rdiDependent_Sex_Male)
        Me.fowDependent_Sex.Controls.Add(Me.rdiDependent_Sex_Female)
        Me.fowDependent_Sex.Location = New System.Drawing.Point(174, 189)
        Me.fowDependent_Sex.Name = "fowDependent_Sex"
        Me.fowDependent_Sex.Size = New System.Drawing.Size(288, 23)
        Me.fowDependent_Sex.TabIndex = 137
        '
        'rdiDependent_Sex_Male
        '
        Me.rdiDependent_Sex_Male.AutoSize = True
        Me.rdiDependent_Sex_Male.Location = New System.Drawing.Point(3, 3)
        Me.rdiDependent_Sex_Male.Name = "rdiDependent_Sex_Male"
        Me.rdiDependent_Sex_Male.Size = New System.Drawing.Size(48, 17)
        Me.rdiDependent_Sex_Male.TabIndex = 0
        Me.rdiDependent_Sex_Male.TabStop = True
        Me.rdiDependent_Sex_Male.Text = "Male"
        Me.rdiDependent_Sex_Male.UseVisualStyleBackColor = True
        '
        'rdiDependent_Sex_Female
        '
        Me.rdiDependent_Sex_Female.AutoSize = True
        Me.rdiDependent_Sex_Female.Location = New System.Drawing.Point(57, 3)
        Me.rdiDependent_Sex_Female.Name = "rdiDependent_Sex_Female"
        Me.rdiDependent_Sex_Female.Size = New System.Drawing.Size(59, 17)
        Me.rdiDependent_Sex_Female.TabIndex = 1
        Me.rdiDependent_Sex_Female.TabStop = True
        Me.rdiDependent_Sex_Female.Text = "Female"
        Me.rdiDependent_Sex_Female.UseVisualStyleBackColor = True
        '
        'txtDependent_NRIC
        '
        Me.txtDependent_NRIC.BackColor = System.Drawing.Color.LightGray
        Me.txtDependent_NRIC.Location = New System.Drawing.Point(174, 105)
        Me.txtDependent_NRIC.MaxLength = 13
        Me.txtDependent_NRIC.Name = "txtDependent_NRIC"
        Me.txtDependent_NRIC.Size = New System.Drawing.Size(200, 20)
        Me.txtDependent_NRIC.TabIndex = 125
        '
        'lblDependent_DOB
        '
        Me.lblDependent_DOB.AutoSize = True
        Me.lblDependent_DOB.Location = New System.Drawing.Point(56, 83)
        Me.lblDependent_DOB.Name = "lblDependent_DOB"
        Me.lblDependent_DOB.Size = New System.Drawing.Size(69, 13)
        Me.lblDependent_DOB.TabIndex = 120
        Me.lblDependent_DOB.Text = "Date of Birth:"
        '
        'lblDependent_Title
        '
        Me.lblDependent_Title.AutoSize = True
        Me.lblDependent_Title.Location = New System.Drawing.Point(56, 30)
        Me.lblDependent_Title.Name = "lblDependent_Title"
        Me.lblDependent_Title.Size = New System.Drawing.Size(30, 13)
        Me.lblDependent_Title.TabIndex = 116
        Me.lblDependent_Title.Text = "Title:"
        '
        'lblDependent_FirstName
        '
        Me.lblDependent_FirstName.AutoSize = True
        Me.lblDependent_FirstName.Location = New System.Drawing.Point(56, 57)
        Me.lblDependent_FirstName.Name = "lblDependent_FirstName"
        Me.lblDependent_FirstName.Size = New System.Drawing.Size(112, 13)
        Me.lblDependent_FirstName.TabIndex = 119
        Me.lblDependent_FirstName.Text = "Full Name As in NRIC:"
        '
        'cmbDependent_Relationship
        '
        Me.cmbDependent_Relationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDependent_Relationship.FormattingEnabled = True
        Me.cmbDependent_Relationship.Items.AddRange(New Object() {"Spouse", "Children"})
        Me.cmbDependent_Relationship.Location = New System.Drawing.Point(174, 273)
        Me.cmbDependent_Relationship.Name = "cmbDependent_Relationship"
        Me.cmbDependent_Relationship.Size = New System.Drawing.Size(121, 21)
        Me.cmbDependent_Relationship.TabIndex = 135
        '
        'lblDependent_Relationship
        '
        Me.lblDependent_Relationship.AutoSize = True
        Me.lblDependent_Relationship.Location = New System.Drawing.Point(57, 281)
        Me.lblDependent_Relationship.Name = "lblDependent_Relationship"
        Me.lblDependent_Relationship.Size = New System.Drawing.Size(68, 13)
        Me.lblDependent_Relationship.TabIndex = 134
        Me.lblDependent_Relationship.Text = "Relationship:"
        '
        'lblDependent_Department
        '
        Me.lblDependent_Department.AutoSize = True
        Me.lblDependent_Department.Location = New System.Drawing.Point(401, 248)
        Me.lblDependent_Department.Name = "lblDependent_Department"
        Me.lblDependent_Department.Size = New System.Drawing.Size(65, 13)
        Me.lblDependent_Department.TabIndex = 144
        Me.lblDependent_Department.Text = "Department:"
        '
        'txtDependent_Department
        '
        Me.txtDependent_Department.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDependent_Department.Location = New System.Drawing.Point(483, 244)
        Me.txtDependent_Department.MaxLength = 50
        Me.txtDependent_Department.Name = "txtDependent_Department"
        Me.txtDependent_Department.Size = New System.Drawing.Size(239, 20)
        Me.txtDependent_Department.TabIndex = 145
        '
        'txtDependent_Weight
        '
        Me.txtDependent_Weight.BackColor = System.Drawing.Color.LightGray
        Me.txtDependent_Weight.Location = New System.Drawing.Point(483, 218)
        Me.txtDependent_Weight.Name = "txtDependent_Weight"
        Me.txtDependent_Weight.Size = New System.Drawing.Size(100, 20)
        Me.txtDependent_Weight.TabIndex = 141
        '
        'lblDependent_Weight
        '
        Me.lblDependent_Weight.AutoSize = True
        Me.lblDependent_Weight.Location = New System.Drawing.Point(401, 222)
        Me.lblDependent_Weight.Name = "lblDependent_Weight"
        Me.lblDependent_Weight.Size = New System.Drawing.Size(65, 13)
        Me.lblDependent_Weight.TabIndex = 140
        Me.lblDependent_Weight.Text = "Weight (kg):"
        '
        'txtDependent_Age
        '
        Me.txtDependent_Age.Location = New System.Drawing.Point(483, 79)
        Me.txtDependent_Age.MaxLength = 3
        Me.txtDependent_Age.Name = "txtDependent_Age"
        Me.txtDependent_Age.ReadOnly = True
        Me.txtDependent_Age.Size = New System.Drawing.Size(42, 20)
        Me.txtDependent_Age.TabIndex = 123
        Me.txtDependent_Age.TabStop = False
        '
        'lblDependent_Age
        '
        Me.lblDependent_Age.AutoSize = True
        Me.lblDependent_Age.Location = New System.Drawing.Point(401, 83)
        Me.lblDependent_Age.Name = "lblDependent_Age"
        Me.lblDependent_Age.Size = New System.Drawing.Size(29, 13)
        Me.lblDependent_Age.TabIndex = 122
        Me.lblDependent_Age.Text = "Age:"
        '
        'lblDependent_ArmForceID
        '
        Me.lblDependent_ArmForceID.AutoSize = True
        Me.lblDependent_ArmForceID.Location = New System.Drawing.Point(610, 109)
        Me.lblDependent_ArmForceID.Name = "lblDependent_ArmForceID"
        Me.lblDependent_ArmForceID.Size = New System.Drawing.Size(80, 13)
        Me.lblDependent_ArmForceID.TabIndex = 128
        Me.lblDependent_ArmForceID.Text = "Policy/Army ID:"
        '
        'txtDependent_ArmForceID
        '
        Me.txtDependent_ArmForceID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDependent_ArmForceID.Location = New System.Drawing.Point(696, 105)
        Me.txtDependent_ArmForceID.MaxLength = 10
        Me.txtDependent_ArmForceID.Name = "txtDependent_ArmForceID"
        Me.txtDependent_ArmForceID.Size = New System.Drawing.Size(121, 20)
        Me.txtDependent_ArmForceID.TabIndex = 129
        '
        'lblDependent_MaritalStatus
        '
        Me.lblDependent_MaritalStatus.AutoSize = True
        Me.lblDependent_MaritalStatus.Location = New System.Drawing.Point(56, 165)
        Me.lblDependent_MaritalStatus.Name = "lblDependent_MaritalStatus"
        Me.lblDependent_MaritalStatus.Size = New System.Drawing.Size(74, 13)
        Me.lblDependent_MaritalStatus.TabIndex = 132
        Me.lblDependent_MaritalStatus.Text = "Marital Status:"
        '
        'fowDependent_MaritalStatus
        '
        Me.fowDependent_MaritalStatus.Controls.Add(Me.rdiDependent_MaritalStatus_Single)
        Me.fowDependent_MaritalStatus.Controls.Add(Me.rdiDependent_MaritalStatus_Married)
        Me.fowDependent_MaritalStatus.Controls.Add(Me.rdiDependent_MaritalStatus_Widowed)
        Me.fowDependent_MaritalStatus.Controls.Add(Me.rdiDependent_MaritalStatus_Divorced)
        Me.fowDependent_MaritalStatus.Location = New System.Drawing.Point(174, 160)
        Me.fowDependent_MaritalStatus.Name = "fowDependent_MaritalStatus"
        Me.fowDependent_MaritalStatus.Size = New System.Drawing.Size(288, 23)
        Me.fowDependent_MaritalStatus.TabIndex = 133
        '
        'rdiDependent_MaritalStatus_Single
        '
        Me.rdiDependent_MaritalStatus_Single.AutoSize = True
        Me.rdiDependent_MaritalStatus_Single.Location = New System.Drawing.Point(3, 3)
        Me.rdiDependent_MaritalStatus_Single.Name = "rdiDependent_MaritalStatus_Single"
        Me.rdiDependent_MaritalStatus_Single.Size = New System.Drawing.Size(54, 17)
        Me.rdiDependent_MaritalStatus_Single.TabIndex = 0
        Me.rdiDependent_MaritalStatus_Single.TabStop = True
        Me.rdiDependent_MaritalStatus_Single.Text = "Single"
        Me.rdiDependent_MaritalStatus_Single.UseVisualStyleBackColor = True
        '
        'rdiDependent_MaritalStatus_Married
        '
        Me.rdiDependent_MaritalStatus_Married.AutoSize = True
        Me.rdiDependent_MaritalStatus_Married.Location = New System.Drawing.Point(63, 3)
        Me.rdiDependent_MaritalStatus_Married.Name = "rdiDependent_MaritalStatus_Married"
        Me.rdiDependent_MaritalStatus_Married.Size = New System.Drawing.Size(60, 17)
        Me.rdiDependent_MaritalStatus_Married.TabIndex = 1
        Me.rdiDependent_MaritalStatus_Married.TabStop = True
        Me.rdiDependent_MaritalStatus_Married.Text = "Married"
        Me.rdiDependent_MaritalStatus_Married.UseVisualStyleBackColor = True
        '
        'rdiDependent_MaritalStatus_Widowed
        '
        Me.rdiDependent_MaritalStatus_Widowed.AutoSize = True
        Me.rdiDependent_MaritalStatus_Widowed.Location = New System.Drawing.Point(129, 3)
        Me.rdiDependent_MaritalStatus_Widowed.Name = "rdiDependent_MaritalStatus_Widowed"
        Me.rdiDependent_MaritalStatus_Widowed.Size = New System.Drawing.Size(70, 17)
        Me.rdiDependent_MaritalStatus_Widowed.TabIndex = 2
        Me.rdiDependent_MaritalStatus_Widowed.TabStop = True
        Me.rdiDependent_MaritalStatus_Widowed.Text = "Widowed"
        Me.rdiDependent_MaritalStatus_Widowed.UseVisualStyleBackColor = True
        '
        'rdiDependent_MaritalStatus_Divorced
        '
        Me.rdiDependent_MaritalStatus_Divorced.AutoSize = True
        Me.rdiDependent_MaritalStatus_Divorced.Location = New System.Drawing.Point(205, 3)
        Me.rdiDependent_MaritalStatus_Divorced.Name = "rdiDependent_MaritalStatus_Divorced"
        Me.rdiDependent_MaritalStatus_Divorced.Size = New System.Drawing.Size(68, 17)
        Me.rdiDependent_MaritalStatus_Divorced.TabIndex = 3
        Me.rdiDependent_MaritalStatus_Divorced.TabStop = True
        Me.rdiDependent_MaritalStatus_Divorced.Text = "Divorced"
        Me.rdiDependent_MaritalStatus_Divorced.UseVisualStyleBackColor = True
        '
        'dtpDependent_DOB
        '
        Me.dtpDependent_DOB.Location = New System.Drawing.Point(174, 79)
        Me.dtpDependent_DOB.Name = "dtpDependent_DOB"
        Me.dtpDependent_DOB.Size = New System.Drawing.Size(200, 20)
        Me.dtpDependent_DOB.TabIndex = 121
        '
        'txtDependent_OldIC
        '
        Me.txtDependent_OldIC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDependent_OldIC.Location = New System.Drawing.Point(483, 105)
        Me.txtDependent_OldIC.MaxLength = 10
        Me.txtDependent_OldIC.Name = "txtDependent_OldIC"
        Me.txtDependent_OldIC.Size = New System.Drawing.Size(121, 20)
        Me.txtDependent_OldIC.TabIndex = 127
        '
        'lblDependent_OldIC
        '
        Me.lblDependent_OldIC.AutoSize = True
        Me.lblDependent_OldIC.Location = New System.Drawing.Point(401, 109)
        Me.lblDependent_OldIC.Name = "lblDependent_OldIC"
        Me.lblDependent_OldIC.Size = New System.Drawing.Size(61, 13)
        Me.lblDependent_OldIC.TabIndex = 126
        Me.lblDependent_OldIC.Text = "Old I/C No:"
        '
        'lblDependent_NRIC1
        '
        Me.lblDependent_NRIC1.AutoSize = True
        Me.lblDependent_NRIC1.Location = New System.Drawing.Point(56, 109)
        Me.lblDependent_NRIC1.Name = "lblDependent_NRIC1"
        Me.lblDependent_NRIC1.Size = New System.Drawing.Size(67, 13)
        Me.lblDependent_NRIC1.TabIndex = 124
        Me.lblDependent_NRIC1.Text = "New I/C No:"
        '
        'btnDependent_Add
        '
        Me.btnDependent_Add.Location = New System.Drawing.Point(341, 326)
        Me.btnDependent_Add.Name = "btnDependent_Add"
        Me.btnDependent_Add.Size = New System.Drawing.Size(106, 23)
        Me.btnDependent_Add.TabIndex = 146
        Me.btnDependent_Add.Text = "Add Dependents"
        Me.btnDependent_Add.UseVisualStyleBackColor = True
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.Location = New System.Drawing.Point(397, 407)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(42, 13)
        Me.lblAdmin.TabIndex = 117
        Me.lblAdmin.Text = "ADMIN"
        Me.lblAdmin.Visible = False
        '
        'New_Dependent_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 443)
        Me.Controls.Add(Me.lblAdmin)
        Me.Controls.Add(Me.gbAddDependant)
        Me.Controls.Add(Me.lblMemberID)
        Me.Controls.Add(Me.lblPolicyID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "New_Dependent_Add"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Dependent New "
        Me.gbAddDependant.ResumeLayout(False)
        Me.gbAddDependant.PerformLayout()
        Me.fowDependent_Race.ResumeLayout(False)
        Me.fowDependent_Race.PerformLayout()
        Me.fowDependent_Sex.ResumeLayout(False)
        Me.fowDependent_Sex.PerformLayout()
        Me.fowDependent_MaritalStatus.ResumeLayout(False)
        Me.fowDependent_MaritalStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPolicyID As System.Windows.Forms.Label
    Friend WithEvents lblMemberID As System.Windows.Forms.Label
    Friend WithEvents gbAddDependant As System.Windows.Forms.GroupBox
    Friend WithEvents lblEffectiveDate1 As System.Windows.Forms.Label
    Friend WithEvents dtpEffectiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEffectiveDate As System.Windows.Forms.Label
    Friend WithEvents txtDependent_Title As System.Windows.Forms.TextBox
    Friend WithEvents lblDependent_Height As System.Windows.Forms.Label
    Friend WithEvents lblDependent_Occupation As System.Windows.Forms.Label
    Friend WithEvents lblDependent_Sex As System.Windows.Forms.Label
    Friend WithEvents lblDependent_Race As System.Windows.Forms.Label
    Friend WithEvents btnDependent_Title As System.Windows.Forms.Button
    Friend WithEvents txtDependent_Occupation As System.Windows.Forms.TextBox
    Friend WithEvents txtDependent_Height As System.Windows.Forms.TextBox
    Friend WithEvents fowDependent_Race As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdiDependent_Race_Malay As System.Windows.Forms.RadioButton
    Friend WithEvents rdiDependent_Race_Chinese As System.Windows.Forms.RadioButton
    Friend WithEvents rdiDependent_Race_Indian As System.Windows.Forms.RadioButton
    Friend WithEvents rdiDependent_Race_Others As System.Windows.Forms.RadioButton
    Friend WithEvents fowDependent_Sex As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdiDependent_Sex_Male As System.Windows.Forms.RadioButton
    Friend WithEvents rdiDependent_Sex_Female As System.Windows.Forms.RadioButton
    Friend WithEvents txtDependent_NRIC As System.Windows.Forms.TextBox
    Friend WithEvents lblDependent_DOB As System.Windows.Forms.Label
    Friend WithEvents lblDependent_Title As System.Windows.Forms.Label
    Friend WithEvents lblDependent_FirstName As System.Windows.Forms.Label
    Friend WithEvents cmbDependent_Relationship As System.Windows.Forms.ComboBox
    Friend WithEvents lblDependent_Relationship As System.Windows.Forms.Label
    Friend WithEvents lblDependent_Department As System.Windows.Forms.Label
    Friend WithEvents txtDependent_Department As System.Windows.Forms.TextBox
    Friend WithEvents txtDependent_Weight As System.Windows.Forms.TextBox
    Friend WithEvents lblDependent_Weight As System.Windows.Forms.Label
    Friend WithEvents txtDependent_Age As System.Windows.Forms.TextBox
    Friend WithEvents lblDependent_Age As System.Windows.Forms.Label
    Friend WithEvents lblDependent_ArmForceID As System.Windows.Forms.Label
    Friend WithEvents txtDependent_ArmForceID As System.Windows.Forms.TextBox
    Friend WithEvents lblDependent_MaritalStatus As System.Windows.Forms.Label
    Friend WithEvents fowDependent_MaritalStatus As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdiDependent_MaritalStatus_Single As System.Windows.Forms.RadioButton
    Friend WithEvents rdiDependent_MaritalStatus_Married As System.Windows.Forms.RadioButton
    Friend WithEvents rdiDependent_MaritalStatus_Widowed As System.Windows.Forms.RadioButton
    Friend WithEvents rdiDependent_MaritalStatus_Divorced As System.Windows.Forms.RadioButton
    Friend WithEvents dtpDependent_DOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDependent_OldIC As System.Windows.Forms.TextBox
    Friend WithEvents lblDependent_OldIC As System.Windows.Forms.Label
    Friend WithEvents lblDependent_NRIC1 As System.Windows.Forms.Label
    Friend WithEvents btnDependent_Add As System.Windows.Forms.Button
    Friend WithEvents txtDependent_FirstName As System.Windows.Forms.TextBox
    Friend WithEvents btnTitle As System.Windows.Forms.Button
    Friend WithEvents lblAdmin As System.Windows.Forms.Label
End Class
