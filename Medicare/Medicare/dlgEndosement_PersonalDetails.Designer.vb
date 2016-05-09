<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEndosement_PersonalDetails
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgEndosement_PersonalDetails))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_Filter = New System.Windows.Forms.ToolStripComboBox
        Me.tsb_Filter_Param = New System.Windows.Forms.ToolStripTextBox
        Me.tsb_Filter_Go = New System.Windows.Forms.ToolStripButton
        Me.dgvPolicies = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpEffective_Date = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPhone_Hse = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPhone_Office = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPhone_MobileNo = New System.Windows.Forms.TextBox
        Me.lblMember_Sex = New System.Windows.Forms.Label
        Me.fowMember_Sex = New System.Windows.Forms.FlowLayoutPanel
        Me.rdiMember_Sex_Male = New System.Windows.Forms.RadioButton
        Me.rdiMember_Sex_Female = New System.Windows.Forms.RadioButton
        Me.lblMember_MaritalStatus = New System.Windows.Forms.Label
        Me.fowMember_MaritalStatus = New System.Windows.Forms.FlowLayoutPanel
        Me.rdiMember_MaritalStatus_Single = New System.Windows.Forms.RadioButton
        Me.rdiMember_MaritalStatus_Married = New System.Windows.Forms.RadioButton
        Me.rdiMember_MaritalStatus_Widowed = New System.Windows.Forms.RadioButton
        Me.rdiMember_MaritalStatus_Divorced = New System.Windows.Forms.RadioButton
        Me.fowMember_Race = New System.Windows.Forms.FlowLayoutPanel
        Me.rdiMember_Race_Malay = New System.Windows.Forms.RadioButton
        Me.rdiMember_Race_Chinese = New System.Windows.Forms.RadioButton
        Me.rdiMember_Race_Indian = New System.Windows.Forms.RadioButton
        Me.rdiMember_Race_Others = New System.Windows.Forms.RadioButton
        Me.lblMember_Race = New System.Windows.Forms.Label
        Me.txtMember_Age = New System.Windows.Forms.TextBox
        Me.lblMember_Age = New System.Windows.Forms.Label
        Me.dtpMember_DOB = New System.Windows.Forms.DateTimePicker
        Me.lblMember_DOB = New System.Windows.Forms.Label
        Me.txtMember_Name = New System.Windows.Forms.TextBox
        Me.lblMember_Name = New System.Windows.Forms.Label
        Me.btnTitle = New System.Windows.Forms.Button
        Me.txtMember_Title = New System.Windows.Forms.TextBox
        Me.lblRemark = New System.Windows.Forms.Label
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.lblRequestedDate = New System.Windows.Forms.Label
        Me.dtpRequestedDate = New System.Windows.Forms.DateTimePicker
        Me.lblMember_Title = New System.Windows.Forms.Label
        Me.txtRequested_Amount = New System.Windows.Forms.TextBox
        Me.lblRequested_Amount = New System.Windows.Forms.Label
        Me.txtPolicy_EffectiveDate = New System.Windows.Forms.TextBox
        Me.lblPolicy_EffectiveDate = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtL2_Plan_Code = New System.Windows.Forms.TextBox
        Me.lblL2_Plan_Code = New System.Windows.Forms.Label
        Me.txtFileNo = New System.Windows.Forms.TextBox
        Me.lblFileNo = New System.Windows.Forms.Label
        Me.txtNRIC = New System.Windows.Forms.TextBox
        Me.lblNRIC = New System.Windows.Forms.Label
        Me.lblMemberPolicy_ID = New System.Windows.Forms.Label
        Me.lblMember_ID = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tolForm.SuspendLayout()
        CType(Me.dgvPolicies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.fowMember_Sex.SuspendLayout()
        Me.fowMember_MaritalStatus.SuspendLayout()
        Me.fowMember_Race.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(613, 615)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Filter, Me.tsb_Filter_Param, Me.tsb_Filter_Go})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(771, 25)
        Me.tolForm.TabIndex = 1
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
        'dgvPolicies
        '
        Me.dgvPolicies.AllowUserToAddRows = False
        Me.dgvPolicies.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPolicies.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPolicies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPolicies.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPolicies.Location = New System.Drawing.Point(9, 31)
        Me.dgvPolicies.Name = "dgvPolicies"
        Me.dgvPolicies.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPolicies.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPolicies.Size = New System.Drawing.Size(750, 121)
        Me.dgvPolicies.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpEffective_Date)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPhone_Hse)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtPhone_Office)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPhone_MobileNo)
        Me.GroupBox1.Controls.Add(Me.lblMember_Sex)
        Me.GroupBox1.Controls.Add(Me.fowMember_Sex)
        Me.GroupBox1.Controls.Add(Me.lblMember_MaritalStatus)
        Me.GroupBox1.Controls.Add(Me.fowMember_MaritalStatus)
        Me.GroupBox1.Controls.Add(Me.fowMember_Race)
        Me.GroupBox1.Controls.Add(Me.lblMember_Race)
        Me.GroupBox1.Controls.Add(Me.txtMember_Age)
        Me.GroupBox1.Controls.Add(Me.lblMember_Age)
        Me.GroupBox1.Controls.Add(Me.dtpMember_DOB)
        Me.GroupBox1.Controls.Add(Me.lblMember_DOB)
        Me.GroupBox1.Controls.Add(Me.txtMember_Name)
        Me.GroupBox1.Controls.Add(Me.lblMember_Name)
        Me.GroupBox1.Controls.Add(Me.btnTitle)
        Me.GroupBox1.Controls.Add(Me.txtMember_Title)
        Me.GroupBox1.Controls.Add(Me.lblRemark)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.lblRequestedDate)
        Me.GroupBox1.Controls.Add(Me.dtpRequestedDate)
        Me.GroupBox1.Controls.Add(Me.lblMember_Title)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 294)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(750, 315)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Change"
        '
        'dtpEffective_Date
        '
        Me.dtpEffective_Date.Location = New System.Drawing.Point(125, 289)
        Me.dtpEffective_Date.Name = "dtpEffective_Date"
        Me.dtpEffective_Date.Size = New System.Drawing.Size(200, 20)
        Me.dtpEffective_Date.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 293)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Effective Date:"
        '
        'txtPhone_Hse
        '
        Me.txtPhone_Hse.Location = New System.Drawing.Point(125, 252)
        Me.txtPhone_Hse.Name = "txtPhone_Hse"
        Me.txtPhone_Hse.Size = New System.Drawing.Size(121, 20)
        Me.txtPhone_Hse.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Phone(House) :"
        '
        'txtPhone_Office
        '
        Me.txtPhone_Office.Location = New System.Drawing.Point(576, 253)
        Me.txtPhone_Office.Name = "txtPhone_Office"
        Me.txtPhone_Office.Size = New System.Drawing.Size(121, 20)
        Me.txtPhone_Office.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(492, 252)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Phone(Office) :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(267, 253)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Phone(Mobile) :"
        '
        'txtPhone_MobileNo
        '
        Me.txtPhone_MobileNo.Location = New System.Drawing.Point(354, 253)
        Me.txtPhone_MobileNo.Name = "txtPhone_MobileNo"
        Me.txtPhone_MobileNo.Size = New System.Drawing.Size(121, 20)
        Me.txtPhone_MobileNo.TabIndex = 28
        '
        'lblMember_Sex
        '
        Me.lblMember_Sex.AutoSize = True
        Me.lblMember_Sex.Location = New System.Drawing.Point(7, 180)
        Me.lblMember_Sex.Name = "lblMember_Sex"
        Me.lblMember_Sex.Size = New System.Drawing.Size(28, 13)
        Me.lblMember_Sex.TabIndex = 26
        Me.lblMember_Sex.Text = "Sex:"
        '
        'fowMember_Sex
        '
        Me.fowMember_Sex.Controls.Add(Me.rdiMember_Sex_Male)
        Me.fowMember_Sex.Controls.Add(Me.rdiMember_Sex_Female)
        Me.fowMember_Sex.Location = New System.Drawing.Point(125, 175)
        Me.fowMember_Sex.Name = "fowMember_Sex"
        Me.fowMember_Sex.Size = New System.Drawing.Size(288, 23)
        Me.fowMember_Sex.TabIndex = 27
        '
        'rdiMember_Sex_Male
        '
        Me.rdiMember_Sex_Male.AutoSize = True
        Me.rdiMember_Sex_Male.Location = New System.Drawing.Point(3, 3)
        Me.rdiMember_Sex_Male.Name = "rdiMember_Sex_Male"
        Me.rdiMember_Sex_Male.Size = New System.Drawing.Size(48, 17)
        Me.rdiMember_Sex_Male.TabIndex = 0
        Me.rdiMember_Sex_Male.TabStop = True
        Me.rdiMember_Sex_Male.Text = "Male"
        Me.rdiMember_Sex_Male.UseVisualStyleBackColor = True
        '
        'rdiMember_Sex_Female
        '
        Me.rdiMember_Sex_Female.AutoSize = True
        Me.rdiMember_Sex_Female.Location = New System.Drawing.Point(57, 3)
        Me.rdiMember_Sex_Female.Name = "rdiMember_Sex_Female"
        Me.rdiMember_Sex_Female.Size = New System.Drawing.Size(59, 17)
        Me.rdiMember_Sex_Female.TabIndex = 1
        Me.rdiMember_Sex_Female.TabStop = True
        Me.rdiMember_Sex_Female.Text = "Female"
        Me.rdiMember_Sex_Female.UseVisualStyleBackColor = True
        '
        'lblMember_MaritalStatus
        '
        Me.lblMember_MaritalStatus.AutoSize = True
        Me.lblMember_MaritalStatus.Location = New System.Drawing.Point(7, 151)
        Me.lblMember_MaritalStatus.Name = "lblMember_MaritalStatus"
        Me.lblMember_MaritalStatus.Size = New System.Drawing.Size(74, 13)
        Me.lblMember_MaritalStatus.TabIndex = 24
        Me.lblMember_MaritalStatus.Text = "Marital Status:"
        '
        'fowMember_MaritalStatus
        '
        Me.fowMember_MaritalStatus.Controls.Add(Me.rdiMember_MaritalStatus_Single)
        Me.fowMember_MaritalStatus.Controls.Add(Me.rdiMember_MaritalStatus_Married)
        Me.fowMember_MaritalStatus.Controls.Add(Me.rdiMember_MaritalStatus_Widowed)
        Me.fowMember_MaritalStatus.Controls.Add(Me.rdiMember_MaritalStatus_Divorced)
        Me.fowMember_MaritalStatus.Location = New System.Drawing.Point(125, 146)
        Me.fowMember_MaritalStatus.Name = "fowMember_MaritalStatus"
        Me.fowMember_MaritalStatus.Size = New System.Drawing.Size(288, 23)
        Me.fowMember_MaritalStatus.TabIndex = 25
        '
        'rdiMember_MaritalStatus_Single
        '
        Me.rdiMember_MaritalStatus_Single.AutoSize = True
        Me.rdiMember_MaritalStatus_Single.Location = New System.Drawing.Point(3, 3)
        Me.rdiMember_MaritalStatus_Single.Name = "rdiMember_MaritalStatus_Single"
        Me.rdiMember_MaritalStatus_Single.Size = New System.Drawing.Size(54, 17)
        Me.rdiMember_MaritalStatus_Single.TabIndex = 0
        Me.rdiMember_MaritalStatus_Single.TabStop = True
        Me.rdiMember_MaritalStatus_Single.Text = "Single"
        Me.rdiMember_MaritalStatus_Single.UseVisualStyleBackColor = True
        '
        'rdiMember_MaritalStatus_Married
        '
        Me.rdiMember_MaritalStatus_Married.AutoSize = True
        Me.rdiMember_MaritalStatus_Married.Location = New System.Drawing.Point(63, 3)
        Me.rdiMember_MaritalStatus_Married.Name = "rdiMember_MaritalStatus_Married"
        Me.rdiMember_MaritalStatus_Married.Size = New System.Drawing.Size(60, 17)
        Me.rdiMember_MaritalStatus_Married.TabIndex = 1
        Me.rdiMember_MaritalStatus_Married.TabStop = True
        Me.rdiMember_MaritalStatus_Married.Text = "Married"
        Me.rdiMember_MaritalStatus_Married.UseVisualStyleBackColor = True
        '
        'rdiMember_MaritalStatus_Widowed
        '
        Me.rdiMember_MaritalStatus_Widowed.AutoSize = True
        Me.rdiMember_MaritalStatus_Widowed.Location = New System.Drawing.Point(129, 3)
        Me.rdiMember_MaritalStatus_Widowed.Name = "rdiMember_MaritalStatus_Widowed"
        Me.rdiMember_MaritalStatus_Widowed.Size = New System.Drawing.Size(70, 17)
        Me.rdiMember_MaritalStatus_Widowed.TabIndex = 2
        Me.rdiMember_MaritalStatus_Widowed.TabStop = True
        Me.rdiMember_MaritalStatus_Widowed.Text = "Widowed"
        Me.rdiMember_MaritalStatus_Widowed.UseVisualStyleBackColor = True
        '
        'rdiMember_MaritalStatus_Divorced
        '
        Me.rdiMember_MaritalStatus_Divorced.AutoSize = True
        Me.rdiMember_MaritalStatus_Divorced.Location = New System.Drawing.Point(205, 3)
        Me.rdiMember_MaritalStatus_Divorced.Name = "rdiMember_MaritalStatus_Divorced"
        Me.rdiMember_MaritalStatus_Divorced.Size = New System.Drawing.Size(68, 17)
        Me.rdiMember_MaritalStatus_Divorced.TabIndex = 3
        Me.rdiMember_MaritalStatus_Divorced.TabStop = True
        Me.rdiMember_MaritalStatus_Divorced.Text = "Divorced"
        Me.rdiMember_MaritalStatus_Divorced.UseVisualStyleBackColor = True
        '
        'fowMember_Race
        '
        Me.fowMember_Race.Controls.Add(Me.rdiMember_Race_Malay)
        Me.fowMember_Race.Controls.Add(Me.rdiMember_Race_Chinese)
        Me.fowMember_Race.Controls.Add(Me.rdiMember_Race_Indian)
        Me.fowMember_Race.Controls.Add(Me.rdiMember_Race_Others)
        Me.fowMember_Race.Location = New System.Drawing.Point(125, 117)
        Me.fowMember_Race.Name = "fowMember_Race"
        Me.fowMember_Race.Size = New System.Drawing.Size(288, 23)
        Me.fowMember_Race.TabIndex = 23
        '
        'rdiMember_Race_Malay
        '
        Me.rdiMember_Race_Malay.AutoSize = True
        Me.rdiMember_Race_Malay.Location = New System.Drawing.Point(3, 3)
        Me.rdiMember_Race_Malay.Name = "rdiMember_Race_Malay"
        Me.rdiMember_Race_Malay.Size = New System.Drawing.Size(53, 17)
        Me.rdiMember_Race_Malay.TabIndex = 0
        Me.rdiMember_Race_Malay.TabStop = True
        Me.rdiMember_Race_Malay.Text = "Malay"
        Me.rdiMember_Race_Malay.UseVisualStyleBackColor = True
        '
        'rdiMember_Race_Chinese
        '
        Me.rdiMember_Race_Chinese.AutoSize = True
        Me.rdiMember_Race_Chinese.Location = New System.Drawing.Point(62, 3)
        Me.rdiMember_Race_Chinese.Name = "rdiMember_Race_Chinese"
        Me.rdiMember_Race_Chinese.Size = New System.Drawing.Size(63, 17)
        Me.rdiMember_Race_Chinese.TabIndex = 1
        Me.rdiMember_Race_Chinese.TabStop = True
        Me.rdiMember_Race_Chinese.Text = "Chinese"
        Me.rdiMember_Race_Chinese.UseVisualStyleBackColor = True
        '
        'rdiMember_Race_Indian
        '
        Me.rdiMember_Race_Indian.AutoSize = True
        Me.rdiMember_Race_Indian.Location = New System.Drawing.Point(131, 3)
        Me.rdiMember_Race_Indian.Name = "rdiMember_Race_Indian"
        Me.rdiMember_Race_Indian.Size = New System.Drawing.Size(54, 17)
        Me.rdiMember_Race_Indian.TabIndex = 2
        Me.rdiMember_Race_Indian.TabStop = True
        Me.rdiMember_Race_Indian.Text = "Indian"
        Me.rdiMember_Race_Indian.UseVisualStyleBackColor = True
        '
        'rdiMember_Race_Others
        '
        Me.rdiMember_Race_Others.AutoSize = True
        Me.rdiMember_Race_Others.Location = New System.Drawing.Point(191, 3)
        Me.rdiMember_Race_Others.Name = "rdiMember_Race_Others"
        Me.rdiMember_Race_Others.Size = New System.Drawing.Size(56, 17)
        Me.rdiMember_Race_Others.TabIndex = 3
        Me.rdiMember_Race_Others.TabStop = True
        Me.rdiMember_Race_Others.Text = "Others"
        Me.rdiMember_Race_Others.UseVisualStyleBackColor = True
        '
        'lblMember_Race
        '
        Me.lblMember_Race.AutoSize = True
        Me.lblMember_Race.Location = New System.Drawing.Point(7, 122)
        Me.lblMember_Race.Name = "lblMember_Race"
        Me.lblMember_Race.Size = New System.Drawing.Size(36, 13)
        Me.lblMember_Race.TabIndex = 22
        Me.lblMember_Race.Text = "Race:"
        '
        'txtMember_Age
        '
        Me.txtMember_Age.Location = New System.Drawing.Point(387, 91)
        Me.txtMember_Age.MaxLength = 3
        Me.txtMember_Age.Name = "txtMember_Age"
        Me.txtMember_Age.ReadOnly = True
        Me.txtMember_Age.Size = New System.Drawing.Size(42, 20)
        Me.txtMember_Age.TabIndex = 21
        Me.txtMember_Age.TabStop = False
        '
        'lblMember_Age
        '
        Me.lblMember_Age.AutoSize = True
        Me.lblMember_Age.Location = New System.Drawing.Point(352, 95)
        Me.lblMember_Age.Name = "lblMember_Age"
        Me.lblMember_Age.Size = New System.Drawing.Size(29, 13)
        Me.lblMember_Age.TabIndex = 20
        Me.lblMember_Age.Text = "Age:"
        '
        'dtpMember_DOB
        '
        Me.dtpMember_DOB.Location = New System.Drawing.Point(125, 91)
        Me.dtpMember_DOB.Name = "dtpMember_DOB"
        Me.dtpMember_DOB.Size = New System.Drawing.Size(200, 20)
        Me.dtpMember_DOB.TabIndex = 19
        '
        'lblMember_DOB
        '
        Me.lblMember_DOB.AutoSize = True
        Me.lblMember_DOB.Location = New System.Drawing.Point(7, 95)
        Me.lblMember_DOB.Name = "lblMember_DOB"
        Me.lblMember_DOB.Size = New System.Drawing.Size(69, 13)
        Me.lblMember_DOB.TabIndex = 18
        Me.lblMember_DOB.Text = "Date of Birth:"
        '
        'txtMember_Name
        '
        Me.txtMember_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMember_Name.Location = New System.Drawing.Point(125, 65)
        Me.txtMember_Name.MaxLength = 50
        Me.txtMember_Name.Name = "txtMember_Name"
        Me.txtMember_Name.Size = New System.Drawing.Size(502, 20)
        Me.txtMember_Name.TabIndex = 17
        '
        'lblMember_Name
        '
        Me.lblMember_Name.AutoSize = True
        Me.lblMember_Name.Location = New System.Drawing.Point(7, 69)
        Me.lblMember_Name.Name = "lblMember_Name"
        Me.lblMember_Name.Size = New System.Drawing.Size(112, 13)
        Me.lblMember_Name.TabIndex = 16
        Me.lblMember_Name.Text = "Full Name As in NRIC:"
        '
        'btnTitle
        '
        Me.btnTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTitle.Location = New System.Drawing.Point(252, 40)
        Me.btnTitle.Name = "btnTitle"
        Me.btnTitle.Size = New System.Drawing.Size(25, 19)
        Me.btnTitle.TabIndex = 15
        Me.btnTitle.Text = "..."
        Me.btnTitle.UseVisualStyleBackColor = True
        '
        'txtMember_Title
        '
        Me.txtMember_Title.Location = New System.Drawing.Point(125, 39)
        Me.txtMember_Title.MaxLength = 10
        Me.txtMember_Title.Name = "txtMember_Title"
        Me.txtMember_Title.ReadOnly = True
        Me.txtMember_Title.Size = New System.Drawing.Size(121, 20)
        Me.txtMember_Title.TabIndex = 14
        Me.txtMember_Title.TabStop = False
        '
        'lblRemark
        '
        Me.lblRemark.AutoSize = True
        Me.lblRemark.Location = New System.Drawing.Point(7, 208)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(47, 13)
        Me.lblRemark.TabIndex = 12
        Me.lblRemark.Text = "Remark:"
        '
        'txtRemark
        '
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Location = New System.Drawing.Point(125, 204)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(619, 35)
        Me.txtRemark.TabIndex = 13
        '
        'lblRequestedDate
        '
        Me.lblRequestedDate.AutoSize = True
        Me.lblRequestedDate.Location = New System.Drawing.Point(7, 17)
        Me.lblRequestedDate.Name = "lblRequestedDate"
        Me.lblRequestedDate.Size = New System.Drawing.Size(76, 13)
        Me.lblRequestedDate.TabIndex = 0
        Me.lblRequestedDate.Text = "Request Date:"
        '
        'dtpRequestedDate
        '
        Me.dtpRequestedDate.Location = New System.Drawing.Point(125, 13)
        Me.dtpRequestedDate.Name = "dtpRequestedDate"
        Me.dtpRequestedDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpRequestedDate.TabIndex = 1
        '
        'lblMember_Title
        '
        Me.lblMember_Title.AutoSize = True
        Me.lblMember_Title.Location = New System.Drawing.Point(7, 43)
        Me.lblMember_Title.Name = "lblMember_Title"
        Me.lblMember_Title.Size = New System.Drawing.Size(30, 13)
        Me.lblMember_Title.TabIndex = 2
        Me.lblMember_Title.Text = "Title:"
        '
        'txtRequested_Amount
        '
        Me.txtRequested_Amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequested_Amount.Location = New System.Drawing.Point(332, 244)
        Me.txtRequested_Amount.MaxLength = 6
        Me.txtRequested_Amount.Name = "txtRequested_Amount"
        Me.txtRequested_Amount.ReadOnly = True
        Me.txtRequested_Amount.Size = New System.Drawing.Size(75, 20)
        Me.txtRequested_Amount.TabIndex = 24
        Me.txtRequested_Amount.TabStop = False
        Me.txtRequested_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRequested_Amount
        '
        Me.lblRequested_Amount.AutoSize = True
        Me.lblRequested_Amount.Location = New System.Drawing.Point(225, 248)
        Me.lblRequested_Amount.Name = "lblRequested_Amount"
        Me.lblRequested_Amount.Size = New System.Drawing.Size(101, 13)
        Me.lblRequested_Amount.TabIndex = 23
        Me.lblRequested_Amount.Text = "Requested Amount:"
        '
        'txtPolicy_EffectiveDate
        '
        Me.txtPolicy_EffectiveDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicy_EffectiveDate.Location = New System.Drawing.Point(134, 270)
        Me.txtPolicy_EffectiveDate.Name = "txtPolicy_EffectiveDate"
        Me.txtPolicy_EffectiveDate.ReadOnly = True
        Me.txtPolicy_EffectiveDate.Size = New System.Drawing.Size(75, 20)
        Me.txtPolicy_EffectiveDate.TabIndex = 26
        Me.txtPolicy_EffectiveDate.TabStop = False
        '
        'lblPolicy_EffectiveDate
        '
        Me.lblPolicy_EffectiveDate.AutoSize = True
        Me.lblPolicy_EffectiveDate.Location = New System.Drawing.Point(6, 274)
        Me.lblPolicy_EffectiveDate.Name = "lblPolicy_EffectiveDate"
        Me.lblPolicy_EffectiveDate.Size = New System.Drawing.Size(94, 13)
        Me.lblPolicy_EffectiveDate.TabIndex = 25
        Me.lblPolicy_EffectiveDate.Text = "1st Payment Date:"
        '
        'txtName
        '
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(134, 192)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(445, 20)
        Me.txtName.TabIndex = 18
        Me.txtName.TabStop = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(6, 196)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(112, 13)
        Me.lblName.TabIndex = 17
        Me.lblName.Text = "Full Name As in NRIC:"
        '
        'txtL2_Plan_Code
        '
        Me.txtL2_Plan_Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtL2_Plan_Code.Location = New System.Drawing.Point(134, 244)
        Me.txtL2_Plan_Code.MaxLength = 4
        Me.txtL2_Plan_Code.Name = "txtL2_Plan_Code"
        Me.txtL2_Plan_Code.ReadOnly = True
        Me.txtL2_Plan_Code.Size = New System.Drawing.Size(61, 20)
        Me.txtL2_Plan_Code.TabIndex = 22
        Me.txtL2_Plan_Code.TabStop = False
        '
        'lblL2_Plan_Code
        '
        Me.lblL2_Plan_Code.AutoSize = True
        Me.lblL2_Plan_Code.Location = New System.Drawing.Point(6, 248)
        Me.lblL2_Plan_Code.Name = "lblL2_Plan_Code"
        Me.lblL2_Plan_Code.Size = New System.Drawing.Size(103, 13)
        Me.lblL2_Plan_Code.TabIndex = 21
        Me.lblL2_Plan_Code.Text = "Plan Code (Level 2):"
        '
        'txtFileNo
        '
        Me.txtFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileNo.Location = New System.Drawing.Point(134, 167)
        Me.txtFileNo.MaxLength = 20
        Me.txtFileNo.Name = "txtFileNo"
        Me.txtFileNo.ReadOnly = True
        Me.txtFileNo.Size = New System.Drawing.Size(135, 20)
        Me.txtFileNo.TabIndex = 16
        Me.txtFileNo.TabStop = False
        '
        'lblFileNo
        '
        Me.lblFileNo.AutoSize = True
        Me.lblFileNo.Location = New System.Drawing.Point(6, 171)
        Me.lblFileNo.Name = "lblFileNo"
        Me.lblFileNo.Size = New System.Drawing.Size(43, 13)
        Me.lblFileNo.TabIndex = 15
        Me.lblFileNo.Text = "File No:"
        '
        'txtNRIC
        '
        Me.txtNRIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNRIC.Location = New System.Drawing.Point(134, 218)
        Me.txtNRIC.MaxLength = 13
        Me.txtNRIC.Name = "txtNRIC"
        Me.txtNRIC.ReadOnly = True
        Me.txtNRIC.Size = New System.Drawing.Size(109, 20)
        Me.txtNRIC.TabIndex = 20
        Me.txtNRIC.TabStop = False
        '
        'lblNRIC
        '
        Me.lblNRIC.AutoSize = True
        Me.lblNRIC.Location = New System.Drawing.Point(6, 222)
        Me.lblNRIC.Name = "lblNRIC"
        Me.lblNRIC.Size = New System.Drawing.Size(67, 13)
        Me.lblNRIC.TabIndex = 19
        Me.lblNRIC.Text = "New I/C No:"
        '
        'lblMemberPolicy_ID
        '
        Me.lblMemberPolicy_ID.AutoSize = True
        Me.lblMemberPolicy_ID.Location = New System.Drawing.Point(6, 631)
        Me.lblMemberPolicy_ID.Name = "lblMemberPolicy_ID"
        Me.lblMemberPolicy_ID.Size = New System.Drawing.Size(34, 13)
        Me.lblMemberPolicy_ID.TabIndex = 29
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.lblMemberPolicy_ID.Visible = False
        '
        'lblMember_ID
        '
        Me.lblMember_ID.AutoSize = True
        Me.lblMember_ID.Location = New System.Drawing.Point(6, 615)
        Me.lblMember_ID.Name = "lblMember_ID"
        Me.lblMember_ID.Size = New System.Drawing.Size(34, 13)
        Me.lblMember_ID.TabIndex = 28
        Me.lblMember_ID.Text = "GUID"
        Me.lblMember_ID.Visible = False
        '
        'dlgEndosement_PersonalDetails
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(771, 646)
        Me.Controls.Add(Me.lblMemberPolicy_ID)
        Me.Controls.Add(Me.lblMember_ID)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtRequested_Amount)
        Me.Controls.Add(Me.lblRequested_Amount)
        Me.Controls.Add(Me.txtPolicy_EffectiveDate)
        Me.Controls.Add(Me.lblPolicy_EffectiveDate)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtL2_Plan_Code)
        Me.Controls.Add(Me.lblL2_Plan_Code)
        Me.Controls.Add(Me.txtFileNo)
        Me.Controls.Add(Me.lblFileNo)
        Me.Controls.Add(Me.txtNRIC)
        Me.Controls.Add(Me.lblNRIC)
        Me.Controls.Add(Me.dgvPolicies)
        Me.Controls.Add(Me.tolForm)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgEndosement_PersonalDetails"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Endorsement - Change of Policy Holder's Personal Details"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvPolicies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.fowMember_Sex.ResumeLayout(False)
        Me.fowMember_Sex.PerformLayout()
        Me.fowMember_MaritalStatus.ResumeLayout(False)
        Me.fowMember_MaritalStatus.PerformLayout()
        Me.fowMember_Race.ResumeLayout(False)
        Me.fowMember_Race.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Filter As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsb_Filter_Param As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsb_Filter_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvPolicies As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents lblRequestedDate As System.Windows.Forms.Label
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblMember_Title As System.Windows.Forms.Label
    Friend WithEvents txtRequested_Amount As System.Windows.Forms.TextBox
    Friend WithEvents lblRequested_Amount As System.Windows.Forms.Label
    Friend WithEvents txtPolicy_EffectiveDate As System.Windows.Forms.TextBox
    Friend WithEvents lblPolicy_EffectiveDate As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtL2_Plan_Code As System.Windows.Forms.TextBox
    Friend WithEvents lblL2_Plan_Code As System.Windows.Forms.Label
    Friend WithEvents txtFileNo As System.Windows.Forms.TextBox
    Friend WithEvents lblFileNo As System.Windows.Forms.Label
    Friend WithEvents txtNRIC As System.Windows.Forms.TextBox
    Friend WithEvents lblNRIC As System.Windows.Forms.Label
    Friend WithEvents btnTitle As System.Windows.Forms.Button
    Friend WithEvents txtMember_Title As System.Windows.Forms.TextBox
    Friend WithEvents txtMember_Name As System.Windows.Forms.TextBox
    Friend WithEvents lblMember_Name As System.Windows.Forms.Label
    Friend WithEvents txtMember_Age As System.Windows.Forms.TextBox
    Friend WithEvents lblMember_Age As System.Windows.Forms.Label
    Friend WithEvents dtpMember_DOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblMember_DOB As System.Windows.Forms.Label
    Friend WithEvents fowMember_Race As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdiMember_Race_Malay As System.Windows.Forms.RadioButton
    Friend WithEvents rdiMember_Race_Chinese As System.Windows.Forms.RadioButton
    Friend WithEvents rdiMember_Race_Indian As System.Windows.Forms.RadioButton
    Friend WithEvents rdiMember_Race_Others As System.Windows.Forms.RadioButton
    Friend WithEvents lblMember_Race As System.Windows.Forms.Label
    Friend WithEvents lblMember_MaritalStatus As System.Windows.Forms.Label
    Friend WithEvents fowMember_MaritalStatus As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdiMember_MaritalStatus_Single As System.Windows.Forms.RadioButton
    Friend WithEvents rdiMember_MaritalStatus_Married As System.Windows.Forms.RadioButton
    Friend WithEvents rdiMember_MaritalStatus_Widowed As System.Windows.Forms.RadioButton
    Friend WithEvents rdiMember_MaritalStatus_Divorced As System.Windows.Forms.RadioButton
    Friend WithEvents lblMember_Sex As System.Windows.Forms.Label
    Friend WithEvents fowMember_Sex As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdiMember_Sex_Male As System.Windows.Forms.RadioButton
    Friend WithEvents rdiMember_Sex_Female As System.Windows.Forms.RadioButton
    Friend WithEvents lblMemberPolicy_ID As System.Windows.Forms.Label
    Friend WithEvents lblMember_ID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPhone_MobileNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPhone_Office As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone_Hse As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpEffective_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
