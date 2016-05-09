<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nominee
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
        Me.lblGUID = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblAdmin = New System.Windows.Forms.Label
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.gbNominee_Add = New System.Windows.Forms.GroupBox
        Me.txtNAdd4 = New System.Windows.Forms.TextBox
        Me.txtNAdd3 = New System.Windows.Forms.TextBox
        Me.btnNState = New System.Windows.Forms.Button
        Me.txtNState = New System.Windows.Forms.TextBox
        Me.lblNState = New System.Windows.Forms.Label
        Me.txtNPoscode = New System.Windows.Forms.TextBox
        Me.lblNPoscode = New System.Windows.Forms.Label
        Me.lblNTown = New System.Windows.Forms.Label
        Me.txtNTown = New System.Windows.Forms.TextBox
        Me.txtNAdd2 = New System.Windows.Forms.TextBox
        Me.txtNAdd1 = New System.Windows.Forms.TextBox
        Me.lblNPostalAdd = New System.Windows.Forms.Label
        Me.cbMemberAdd = New System.Windows.Forms.CheckBox
        Me.lblEffectiveDate1 = New System.Windows.Forms.Label
        Me.dtpEffectiveDate = New System.Windows.Forms.DateTimePicker
        Me.lblEffectiveDate = New System.Windows.Forms.Label
        Me.cbRelationship = New System.Windows.Forms.ComboBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblNominee_Relationship1 = New System.Windows.Forms.Label
        Me.lblNominee_NRIC1 = New System.Windows.Forms.Label
        Me.lblNominee_DOB1 = New System.Windows.Forms.Label
        Me.lblNominee_Name1 = New System.Windows.Forms.Label
        Me.lblNominee_Title1 = New System.Windows.Forms.Label
        Me.txtNominee_SharePercentage = New System.Windows.Forms.TextBox
        Me.lblNominee_SharePercentage = New System.Windows.Forms.Label
        Me.btnNominee_Title = New System.Windows.Forms.Button
        Me.txtNominee_Title = New System.Windows.Forms.TextBox
        Me.lblNominee_Relationship = New System.Windows.Forms.Label
        Me.dtpNominee_DOB = New System.Windows.Forms.DateTimePicker
        Me.txtNominee_NRIC = New System.Windows.Forms.TextBox
        Me.lblNominee_NRIC = New System.Windows.Forms.Label
        Me.lblNominee_DOB = New System.Windows.Forms.Label
        Me.lblNominee_Title = New System.Windows.Forms.Label
        Me.txtNominee_Name = New System.Windows.Forms.TextBox
        Me.lblNominee_Name = New System.Windows.Forms.Label
        Me.lblNomineeID = New System.Windows.Forms.Label
        Me.lblMemberID = New System.Windows.Forms.Label
        Me.lblID = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.gbNominee_Add.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblGUID
        '
        Me.lblGUID.AutoSize = True
        Me.lblGUID.Location = New System.Drawing.Point(68, 471)
        Me.lblGUID.Name = "lblGUID"
        Me.lblGUID.Size = New System.Drawing.Size(18, 13)
        Me.lblGUID.TabIndex = 0
        Me.lblGUID.Text = "ID"
        Me.lblGUID.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAdmin)
        Me.GroupBox1.Controls.Add(Me.lblRemarks)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.gbNominee_Add)
        Me.GroupBox1.Controls.Add(Me.cbMemberAdd)
        Me.GroupBox1.Controls.Add(Me.lblEffectiveDate1)
        Me.GroupBox1.Controls.Add(Me.dtpEffectiveDate)
        Me.GroupBox1.Controls.Add(Me.lblEffectiveDate)
        Me.GroupBox1.Controls.Add(Me.cbRelationship)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnSubmit)
        Me.GroupBox1.Controls.Add(Me.lblNominee_Relationship1)
        Me.GroupBox1.Controls.Add(Me.lblNominee_NRIC1)
        Me.GroupBox1.Controls.Add(Me.lblNominee_DOB1)
        Me.GroupBox1.Controls.Add(Me.lblNominee_Name1)
        Me.GroupBox1.Controls.Add(Me.lblNominee_Title1)
        Me.GroupBox1.Controls.Add(Me.txtNominee_SharePercentage)
        Me.GroupBox1.Controls.Add(Me.lblNominee_SharePercentage)
        Me.GroupBox1.Controls.Add(Me.btnNominee_Title)
        Me.GroupBox1.Controls.Add(Me.txtNominee_Title)
        Me.GroupBox1.Controls.Add(Me.lblNominee_Relationship)
        Me.GroupBox1.Controls.Add(Me.dtpNominee_DOB)
        Me.GroupBox1.Controls.Add(Me.txtNominee_NRIC)
        Me.GroupBox1.Controls.Add(Me.lblNominee_NRIC)
        Me.GroupBox1.Controls.Add(Me.lblNominee_DOB)
        Me.GroupBox1.Controls.Add(Me.lblNominee_Title)
        Me.GroupBox1.Controls.Add(Me.txtNominee_Name)
        Me.GroupBox1.Controls.Add(Me.lblNominee_Name)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(709, 456)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Nominee Details"
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.Location = New System.Drawing.Point(517, 427)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(10, 13)
        Me.lblAdmin.TabIndex = 5
        Me.lblAdmin.Text = "."
        Me.lblAdmin.Visible = False
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(19, 383)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(55, 13)
        Me.lblRemarks.TabIndex = 48
        Me.lblRemarks.Text = "Remarks :"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(148, 380)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(450, 36)
        Me.txtRemarks.TabIndex = 47
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(423, 427)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 46
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'gbNominee_Add
        '
        Me.gbNominee_Add.Controls.Add(Me.txtNAdd4)
        Me.gbNominee_Add.Controls.Add(Me.txtNAdd3)
        Me.gbNominee_Add.Controls.Add(Me.btnNState)
        Me.gbNominee_Add.Controls.Add(Me.txtNState)
        Me.gbNominee_Add.Controls.Add(Me.lblNState)
        Me.gbNominee_Add.Controls.Add(Me.txtNPoscode)
        Me.gbNominee_Add.Controls.Add(Me.lblNPoscode)
        Me.gbNominee_Add.Controls.Add(Me.lblNTown)
        Me.gbNominee_Add.Controls.Add(Me.txtNTown)
        Me.gbNominee_Add.Controls.Add(Me.txtNAdd2)
        Me.gbNominee_Add.Controls.Add(Me.txtNAdd1)
        Me.gbNominee_Add.Controls.Add(Me.lblNPostalAdd)
        Me.gbNominee_Add.Location = New System.Drawing.Point(19, 155)
        Me.gbNominee_Add.Name = "gbNominee_Add"
        Me.gbNominee_Add.Size = New System.Drawing.Size(662, 180)
        Me.gbNominee_Add.TabIndex = 45
        Me.gbNominee_Add.TabStop = False
        '
        'txtNAdd4
        '
        Me.txtNAdd4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNAdd4.Location = New System.Drawing.Point(129, 95)
        Me.txtNAdd4.MaxLength = 100
        Me.txtNAdd4.Name = "txtNAdd4"
        Me.txtNAdd4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNAdd4.Size = New System.Drawing.Size(508, 20)
        Me.txtNAdd4.TabIndex = 11
        '
        'txtNAdd3
        '
        Me.txtNAdd3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNAdd3.Location = New System.Drawing.Point(129, 69)
        Me.txtNAdd3.MaxLength = 100
        Me.txtNAdd3.Name = "txtNAdd3"
        Me.txtNAdd3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNAdd3.Size = New System.Drawing.Size(508, 20)
        Me.txtNAdd3.TabIndex = 10
        '
        'btnNState
        '
        Me.btnNState.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNState.Location = New System.Drawing.Point(311, 147)
        Me.btnNState.Name = "btnNState"
        Me.btnNState.Size = New System.Drawing.Size(25, 20)
        Me.btnNState.TabIndex = 9
        Me.btnNState.Text = "..."
        Me.btnNState.UseVisualStyleBackColor = True
        '
        'txtNState
        '
        Me.txtNState.Location = New System.Drawing.Point(129, 147)
        Me.txtNState.MaxLength = 10
        Me.txtNState.Name = "txtNState"
        Me.txtNState.ReadOnly = True
        Me.txtNState.Size = New System.Drawing.Size(176, 20)
        Me.txtNState.TabIndex = 8
        Me.txtNState.TabStop = False
        '
        'lblNState
        '
        Me.lblNState.AutoSize = True
        Me.lblNState.Location = New System.Drawing.Point(11, 150)
        Me.lblNState.Name = "lblNState"
        Me.lblNState.Size = New System.Drawing.Size(35, 13)
        Me.lblNState.TabIndex = 7
        Me.lblNState.Text = "State:"
        '
        'txtNPoscode
        '
        Me.txtNPoscode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNPoscode.Location = New System.Drawing.Point(458, 148)
        Me.txtNPoscode.MaxLength = 5
        Me.txtNPoscode.Name = "txtNPoscode"
        Me.txtNPoscode.Size = New System.Drawing.Size(100, 20)
        Me.txtNPoscode.TabIndex = 6
        '
        'lblNPoscode
        '
        Me.lblNPoscode.AutoSize = True
        Me.lblNPoscode.Location = New System.Drawing.Point(391, 152)
        Me.lblNPoscode.Name = "lblNPoscode"
        Me.lblNPoscode.Size = New System.Drawing.Size(55, 13)
        Me.lblNPoscode.TabIndex = 5
        Me.lblNPoscode.Text = "Postcode:"
        '
        'lblNTown
        '
        Me.lblNTown.AutoSize = True
        Me.lblNTown.Location = New System.Drawing.Point(11, 125)
        Me.lblNTown.Name = "lblNTown"
        Me.lblNTown.Size = New System.Drawing.Size(37, 13)
        Me.lblNTown.TabIndex = 3
        Me.lblNTown.Text = "Town:"
        '
        'txtNTown
        '
        Me.txtNTown.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNTown.Location = New System.Drawing.Point(129, 121)
        Me.txtNTown.MaxLength = 50
        Me.txtNTown.Name = "txtNTown"
        Me.txtNTown.Size = New System.Drawing.Size(176, 20)
        Me.txtNTown.TabIndex = 4
        '
        'txtNAdd2
        '
        Me.txtNAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNAdd2.Location = New System.Drawing.Point(129, 43)
        Me.txtNAdd2.MaxLength = 100
        Me.txtNAdd2.Name = "txtNAdd2"
        Me.txtNAdd2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNAdd2.Size = New System.Drawing.Size(508, 20)
        Me.txtNAdd2.TabIndex = 2
        '
        'txtNAdd1
        '
        Me.txtNAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNAdd1.Location = New System.Drawing.Point(129, 17)
        Me.txtNAdd1.MaxLength = 100
        Me.txtNAdd1.Name = "txtNAdd1"
        Me.txtNAdd1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNAdd1.Size = New System.Drawing.Size(508, 20)
        Me.txtNAdd1.TabIndex = 1
        '
        'lblNPostalAdd
        '
        Me.lblNPostalAdd.AutoSize = True
        Me.lblNPostalAdd.Location = New System.Drawing.Point(11, 21)
        Me.lblNPostalAdd.Name = "lblNPostalAdd"
        Me.lblNPostalAdd.Size = New System.Drawing.Size(80, 13)
        Me.lblNPostalAdd.TabIndex = 0
        Me.lblNPostalAdd.Text = "Postal Address:"
        '
        'cbMemberAdd
        '
        Me.cbMemberAdd.AutoSize = True
        Me.cbMemberAdd.Location = New System.Drawing.Point(441, 132)
        Me.cbMemberAdd.Name = "cbMemberAdd"
        Me.cbMemberAdd.Size = New System.Drawing.Size(149, 17)
        Me.cbMemberAdd.TabIndex = 44
        Me.cbMemberAdd.Text = "Same as Member Address"
        Me.cbMemberAdd.UseVisualStyleBackColor = True
        '
        'lblEffectiveDate1
        '
        Me.lblEffectiveDate1.AutoSize = True
        Me.lblEffectiveDate1.Location = New System.Drawing.Point(380, 357)
        Me.lblEffectiveDate1.Name = "lblEffectiveDate1"
        Me.lblEffectiveDate1.Size = New System.Drawing.Size(10, 13)
        Me.lblEffectiveDate1.TabIndex = 43
        Me.lblEffectiveDate1.Text = ":"
        '
        'dtpEffectiveDate
        '
        Me.dtpEffectiveDate.Location = New System.Drawing.Point(398, 353)
        Me.dtpEffectiveDate.Name = "dtpEffectiveDate"
        Me.dtpEffectiveDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEffectiveDate.TabIndex = 42
        '
        'lblEffectiveDate
        '
        Me.lblEffectiveDate.AutoSize = True
        Me.lblEffectiveDate.Location = New System.Drawing.Point(288, 357)
        Me.lblEffectiveDate.Name = "lblEffectiveDate"
        Me.lblEffectiveDate.Size = New System.Drawing.Size(75, 13)
        Me.lblEffectiveDate.TabIndex = 41
        Me.lblEffectiveDate.Text = "Effective Date"
        '
        'cbRelationship
        '
        Me.cbRelationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRelationship.FormattingEnabled = True
        Me.cbRelationship.Items.AddRange(New Object() {"Spouse", "Children", "Relative", "Others"})
        Me.cbRelationship.Location = New System.Drawing.Point(206, 134)
        Me.cbRelationship.Name = "cbRelationship"
        Me.cbRelationship.Size = New System.Drawing.Size(200, 21)
        Me.cbRelationship.TabIndex = 40
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(331, 427)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 39
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(243, 427)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 38
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblNominee_Relationship1
        '
        Me.lblNominee_Relationship1.AutoSize = True
        Me.lblNominee_Relationship1.Location = New System.Drawing.Point(157, 137)
        Me.lblNominee_Relationship1.Name = "lblNominee_Relationship1"
        Me.lblNominee_Relationship1.Size = New System.Drawing.Size(10, 13)
        Me.lblNominee_Relationship1.TabIndex = 35
        Me.lblNominee_Relationship1.Text = ":"
        '
        'lblNominee_NRIC1
        '
        Me.lblNominee_NRIC1.AutoSize = True
        Me.lblNominee_NRIC1.Location = New System.Drawing.Point(157, 111)
        Me.lblNominee_NRIC1.Name = "lblNominee_NRIC1"
        Me.lblNominee_NRIC1.Size = New System.Drawing.Size(10, 13)
        Me.lblNominee_NRIC1.TabIndex = 34
        Me.lblNominee_NRIC1.Text = ":"
        '
        'lblNominee_DOB1
        '
        Me.lblNominee_DOB1.AutoSize = True
        Me.lblNominee_DOB1.Location = New System.Drawing.Point(157, 85)
        Me.lblNominee_DOB1.Name = "lblNominee_DOB1"
        Me.lblNominee_DOB1.Size = New System.Drawing.Size(10, 13)
        Me.lblNominee_DOB1.TabIndex = 33
        Me.lblNominee_DOB1.Text = ":"
        '
        'lblNominee_Name1
        '
        Me.lblNominee_Name1.AutoSize = True
        Me.lblNominee_Name1.Location = New System.Drawing.Point(157, 55)
        Me.lblNominee_Name1.Name = "lblNominee_Name1"
        Me.lblNominee_Name1.Size = New System.Drawing.Size(10, 13)
        Me.lblNominee_Name1.TabIndex = 32
        Me.lblNominee_Name1.Text = ":"
        '
        'lblNominee_Title1
        '
        Me.lblNominee_Title1.AutoSize = True
        Me.lblNominee_Title1.Location = New System.Drawing.Point(157, 32)
        Me.lblNominee_Title1.Name = "lblNominee_Title1"
        Me.lblNominee_Title1.Size = New System.Drawing.Size(10, 13)
        Me.lblNominee_Title1.TabIndex = 31
        Me.lblNominee_Title1.Text = ":"
        '
        'txtNominee_SharePercentage
        '
        Me.txtNominee_SharePercentage.Location = New System.Drawing.Point(148, 354)
        Me.txtNominee_SharePercentage.MaxLength = 5
        Me.txtNominee_SharePercentage.Name = "txtNominee_SharePercentage"
        Me.txtNominee_SharePercentage.Size = New System.Drawing.Size(121, 20)
        Me.txtNominee_SharePercentage.TabIndex = 30
        '
        'lblNominee_SharePercentage
        '
        Me.lblNominee_SharePercentage.AutoSize = True
        Me.lblNominee_SharePercentage.Location = New System.Drawing.Point(19, 360)
        Me.lblNominee_SharePercentage.Name = "lblNominee_SharePercentage"
        Me.lblNominee_SharePercentage.Size = New System.Drawing.Size(55, 13)
        Me.lblNominee_SharePercentage.TabIndex = 29
        Me.lblNominee_SharePercentage.Text = "Share (%):"
        '
        'btnNominee_Title
        '
        Me.btnNominee_Title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNominee_Title.Location = New System.Drawing.Point(333, 29)
        Me.btnNominee_Title.Name = "btnNominee_Title"
        Me.btnNominee_Title.Size = New System.Drawing.Size(25, 20)
        Me.btnNominee_Title.TabIndex = 18
        Me.btnNominee_Title.Text = "..."
        Me.btnNominee_Title.UseVisualStyleBackColor = True
        '
        'txtNominee_Title
        '
        Me.txtNominee_Title.Location = New System.Drawing.Point(206, 28)
        Me.txtNominee_Title.MaxLength = 10
        Me.txtNominee_Title.Name = "txtNominee_Title"
        Me.txtNominee_Title.ReadOnly = True
        Me.txtNominee_Title.Size = New System.Drawing.Size(121, 20)
        Me.txtNominee_Title.TabIndex = 17
        Me.txtNominee_Title.TabStop = False
        '
        'lblNominee_Relationship
        '
        Me.lblNominee_Relationship.AutoSize = True
        Me.lblNominee_Relationship.Location = New System.Drawing.Point(19, 137)
        Me.lblNominee_Relationship.Name = "lblNominee_Relationship"
        Me.lblNominee_Relationship.Size = New System.Drawing.Size(65, 13)
        Me.lblNominee_Relationship.TabIndex = 25
        Me.lblNominee_Relationship.Text = "Relationship"
        '
        'dtpNominee_DOB
        '
        Me.dtpNominee_DOB.Location = New System.Drawing.Point(206, 81)
        Me.dtpNominee_DOB.Name = "dtpNominee_DOB"
        Me.dtpNominee_DOB.Size = New System.Drawing.Size(200, 20)
        Me.dtpNominee_DOB.TabIndex = 22
        '
        'txtNominee_NRIC
        '
        Me.txtNominee_NRIC.Location = New System.Drawing.Point(206, 107)
        Me.txtNominee_NRIC.MaxLength = 12
        Me.txtNominee_NRIC.Name = "txtNominee_NRIC"
        Me.txtNominee_NRIC.Size = New System.Drawing.Size(200, 20)
        Me.txtNominee_NRIC.TabIndex = 24
        '
        'lblNominee_NRIC
        '
        Me.lblNominee_NRIC.AutoSize = True
        Me.lblNominee_NRIC.Location = New System.Drawing.Point(19, 111)
        Me.lblNominee_NRIC.Name = "lblNominee_NRIC"
        Me.lblNominee_NRIC.Size = New System.Drawing.Size(64, 13)
        Me.lblNominee_NRIC.TabIndex = 23
        Me.lblNominee_NRIC.Text = "New I/C No"
        '
        'lblNominee_DOB
        '
        Me.lblNominee_DOB.AutoSize = True
        Me.lblNominee_DOB.Location = New System.Drawing.Point(19, 85)
        Me.lblNominee_DOB.Name = "lblNominee_DOB"
        Me.lblNominee_DOB.Size = New System.Drawing.Size(66, 13)
        Me.lblNominee_DOB.TabIndex = 21
        Me.lblNominee_DOB.Text = "Date of Birth"
        '
        'lblNominee_Title
        '
        Me.lblNominee_Title.AutoSize = True
        Me.lblNominee_Title.Location = New System.Drawing.Point(19, 32)
        Me.lblNominee_Title.Name = "lblNominee_Title"
        Me.lblNominee_Title.Size = New System.Drawing.Size(30, 13)
        Me.lblNominee_Title.TabIndex = 16
        Me.lblNominee_Title.Text = "Title "
        '
        'txtNominee_Name
        '
        Me.txtNominee_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNominee_Name.Location = New System.Drawing.Point(206, 55)
        Me.txtNominee_Name.MaxLength = 50
        Me.txtNominee_Name.Name = "txtNominee_Name"
        Me.txtNominee_Name.Size = New System.Drawing.Size(450, 20)
        Me.txtNominee_Name.TabIndex = 20
        '
        'lblNominee_Name
        '
        Me.lblNominee_Name.AutoSize = True
        Me.lblNominee_Name.Location = New System.Drawing.Point(19, 59)
        Me.lblNominee_Name.Name = "lblNominee_Name"
        Me.lblNominee_Name.Size = New System.Drawing.Size(109, 13)
        Me.lblNominee_Name.TabIndex = 19
        Me.lblNominee_Name.Text = "Full Name As in NRIC"
        '
        'lblNomineeID
        '
        Me.lblNomineeID.AutoSize = True
        Me.lblNomineeID.Location = New System.Drawing.Point(139, 471)
        Me.lblNomineeID.Name = "lblNomineeID"
        Me.lblNomineeID.Size = New System.Drawing.Size(60, 13)
        Me.lblNomineeID.TabIndex = 2
        Me.lblNomineeID.Text = "NomineeID"
        Me.lblNomineeID.Visible = False
        '
        'lblMemberID
        '
        Me.lblMemberID.AutoSize = True
        Me.lblMemberID.Location = New System.Drawing.Point(252, 471)
        Me.lblMemberID.Name = "lblMemberID"
        Me.lblMemberID.Size = New System.Drawing.Size(56, 13)
        Me.lblMemberID.TabIndex = 3
        Me.lblMemberID.Text = "MemberID"
        Me.lblMemberID.Visible = False
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(342, 471)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 4
        Me.lblID.Text = "ID"
        Me.lblID.Visible = False
        '
        'Nominee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 493)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.lblMemberID)
        Me.Controls.Add(Me.lblNomineeID)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblGUID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Nominee"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nominee"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbNominee_Add.ResumeLayout(False)
        Me.gbNominee_Add.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGUID As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNominee_Title1 As System.Windows.Forms.Label
    Friend WithEvents txtNominee_SharePercentage As System.Windows.Forms.TextBox
    Friend WithEvents lblNominee_SharePercentage As System.Windows.Forms.Label
    Friend WithEvents btnNominee_Title As System.Windows.Forms.Button
    Friend WithEvents txtNominee_Title As System.Windows.Forms.TextBox
    Friend WithEvents lblNominee_Relationship As System.Windows.Forms.Label
    Friend WithEvents dtpNominee_DOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNominee_NRIC As System.Windows.Forms.TextBox
    Friend WithEvents lblNominee_NRIC As System.Windows.Forms.Label
    Friend WithEvents lblNominee_DOB As System.Windows.Forms.Label
    Friend WithEvents lblNominee_Title As System.Windows.Forms.Label
    Friend WithEvents txtNominee_Name As System.Windows.Forms.TextBox
    Friend WithEvents lblNominee_Name As System.Windows.Forms.Label
    Friend WithEvents lblNominee_Name1 As System.Windows.Forms.Label
    Friend WithEvents lblNominee_NRIC1 As System.Windows.Forms.Label
    Friend WithEvents lblNominee_DOB1 As System.Windows.Forms.Label
    Friend WithEvents lblNominee_Relationship1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblNomineeID As System.Windows.Forms.Label
    Friend WithEvents cbRelationship As System.Windows.Forms.ComboBox
    Friend WithEvents lblEffectiveDate1 As System.Windows.Forms.Label
    Friend WithEvents dtpEffectiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEffectiveDate As System.Windows.Forms.Label
    Friend WithEvents lblMemberID As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblAdmin As System.Windows.Forms.Label
    Friend WithEvents cbMemberAdd As System.Windows.Forms.CheckBox
    Friend WithEvents gbNominee_Add As System.Windows.Forms.GroupBox
    Friend WithEvents btnNState As System.Windows.Forms.Button
    Friend WithEvents txtNState As System.Windows.Forms.TextBox
    Friend WithEvents lblNState As System.Windows.Forms.Label
    Friend WithEvents txtNPoscode As System.Windows.Forms.TextBox
    Friend WithEvents lblNPoscode As System.Windows.Forms.Label
    Friend WithEvents lblNTown As System.Windows.Forms.Label
    Friend WithEvents txtNTown As System.Windows.Forms.TextBox
    Friend WithEvents txtNAdd2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNAdd1 As System.Windows.Forms.TextBox
    Friend WithEvents lblNPostalAdd As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtNAdd3 As System.Windows.Forms.TextBox
    Friend WithEvents txtNAdd4 As System.Windows.Forms.TextBox
End Class
