<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEndosement_PostalAddress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgEndosement_PostalAddress))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpEffective_Date = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblRemark = New System.Windows.Forms.Label
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.lblRequestedDate = New System.Windows.Forms.Label
        Me.btnState = New System.Windows.Forms.Button
        Me.dtpRequestedDate = New System.Windows.Forms.DateTimePicker
        Me.txtMember_State = New System.Windows.Forms.TextBox
        Me.lblMember_State = New System.Windows.Forms.Label
        Me.txtMember_Postcode = New System.Windows.Forms.TextBox
        Me.lblMember_Postcode = New System.Windows.Forms.Label
        Me.lblMember_Town = New System.Windows.Forms.Label
        Me.txtMember_City = New System.Windows.Forms.TextBox
        Me.txtMember_AddressL2 = New System.Windows.Forms.TextBox
        Me.txtMember_AddressL1 = New System.Windows.Forms.TextBox
        Me.lblMember_Address = New System.Windows.Forms.Label
        Me.lblMember_ID = New System.Windows.Forms.Label
        Me.txtRequested_Amount_Old = New System.Windows.Forms.TextBox
        Me.lblRequested_Amount_Old = New System.Windows.Forms.Label
        Me.txtPolicy_EffectiveDate_Old = New System.Windows.Forms.TextBox
        Me.lblPolicy_EffectiveDate_Old = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtL2_Plan_Code_Old = New System.Windows.Forms.TextBox
        Me.lblL2_Plan_Code_Old = New System.Windows.Forms.Label
        Me.txtFileNo = New System.Windows.Forms.TextBox
        Me.lblFileNo = New System.Windows.Forms.Label
        Me.txtNRIC = New System.Windows.Forms.TextBox
        Me.lblNRIC = New System.Windows.Forms.Label
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_Filter = New System.Windows.Forms.ToolStripComboBox
        Me.tsb_Filter_Param = New System.Windows.Forms.ToolStripTextBox
        Me.tsb_Filter_Go = New System.Windows.Forms.ToolStripButton
        Me.OK_Button = New System.Windows.Forms.Button
        Me.dgvPolicies = New System.Windows.Forms.DataGridView
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.lblMemberPolicy_ID = New System.Windows.Forms.Label
        Me.txtAdd3 = New System.Windows.Forms.TextBox
        Me.txtAdd4 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.tolForm.SuspendLayout()
        CType(Me.dgvPolicies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAdd4)
        Me.GroupBox1.Controls.Add(Me.txtAdd3)
        Me.GroupBox1.Controls.Add(Me.dtpEffective_Date)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblRemark)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.lblRequestedDate)
        Me.GroupBox1.Controls.Add(Me.btnState)
        Me.GroupBox1.Controls.Add(Me.dtpRequestedDate)
        Me.GroupBox1.Controls.Add(Me.txtMember_State)
        Me.GroupBox1.Controls.Add(Me.lblMember_State)
        Me.GroupBox1.Controls.Add(Me.txtMember_Postcode)
        Me.GroupBox1.Controls.Add(Me.lblMember_Postcode)
        Me.GroupBox1.Controls.Add(Me.lblMember_Town)
        Me.GroupBox1.Controls.Add(Me.txtMember_City)
        Me.GroupBox1.Controls.Add(Me.txtMember_AddressL2)
        Me.GroupBox1.Controls.Add(Me.txtMember_AddressL1)
        Me.GroupBox1.Controls.Add(Me.lblMember_Address)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 294)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(750, 285)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Change"
        '
        'dtpEffective_Date
        '
        Me.dtpEffective_Date.Location = New System.Drawing.Point(93, 251)
        Me.dtpEffective_Date.Name = "dtpEffective_Date"
        Me.dtpEffective_Date.Size = New System.Drawing.Size(200, 20)
        Me.dtpEffective_Date.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 255)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Effective Date:"
        '
        'lblRemark
        '
        Me.lblRemark.AutoSize = True
        Me.lblRemark.Location = New System.Drawing.Point(7, 200)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(47, 13)
        Me.lblRemark.TabIndex = 12
        Me.lblRemark.Text = "Remark:"
        '
        'txtRemark
        '
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Location = New System.Drawing.Point(93, 196)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(649, 35)
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
        'btnState
        '
        Me.btnState.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnState.Location = New System.Drawing.Point(275, 171)
        Me.btnState.Name = "btnState"
        Me.btnState.Size = New System.Drawing.Size(25, 20)
        Me.btnState.TabIndex = 11
        Me.btnState.Text = "..."
        Me.btnState.UseVisualStyleBackColor = True
        '
        'dtpRequestedDate
        '
        Me.dtpRequestedDate.Location = New System.Drawing.Point(93, 13)
        Me.dtpRequestedDate.Name = "dtpRequestedDate"
        Me.dtpRequestedDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpRequestedDate.TabIndex = 1
        '
        'txtMember_State
        '
        Me.txtMember_State.Location = New System.Drawing.Point(93, 171)
        Me.txtMember_State.MaxLength = 10
        Me.txtMember_State.Name = "txtMember_State"
        Me.txtMember_State.ReadOnly = True
        Me.txtMember_State.Size = New System.Drawing.Size(176, 20)
        Me.txtMember_State.TabIndex = 10
        Me.txtMember_State.TabStop = False
        '
        'lblMember_State
        '
        Me.lblMember_State.AutoSize = True
        Me.lblMember_State.Location = New System.Drawing.Point(7, 175)
        Me.lblMember_State.Name = "lblMember_State"
        Me.lblMember_State.Size = New System.Drawing.Size(35, 13)
        Me.lblMember_State.TabIndex = 9
        Me.lblMember_State.Text = "State:"
        '
        'txtMember_Postcode
        '
        Me.txtMember_Postcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMember_Postcode.Location = New System.Drawing.Point(387, 144)
        Me.txtMember_Postcode.MaxLength = 5
        Me.txtMember_Postcode.Name = "txtMember_Postcode"
        Me.txtMember_Postcode.Size = New System.Drawing.Size(100, 20)
        Me.txtMember_Postcode.TabIndex = 8
        '
        'lblMember_Postcode
        '
        Me.lblMember_Postcode.AutoSize = True
        Me.lblMember_Postcode.Location = New System.Drawing.Point(320, 148)
        Me.lblMember_Postcode.Name = "lblMember_Postcode"
        Me.lblMember_Postcode.Size = New System.Drawing.Size(55, 13)
        Me.lblMember_Postcode.TabIndex = 7
        Me.lblMember_Postcode.Text = "Postcode:"
        '
        'lblMember_Town
        '
        Me.lblMember_Town.AutoSize = True
        Me.lblMember_Town.Location = New System.Drawing.Point(7, 148)
        Me.lblMember_Town.Name = "lblMember_Town"
        Me.lblMember_Town.Size = New System.Drawing.Size(37, 13)
        Me.lblMember_Town.TabIndex = 5
        Me.lblMember_Town.Text = "Town:"
        '
        'txtMember_City
        '
        Me.txtMember_City.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMember_City.Location = New System.Drawing.Point(93, 144)
        Me.txtMember_City.MaxLength = 50
        Me.txtMember_City.Name = "txtMember_City"
        Me.txtMember_City.Size = New System.Drawing.Size(176, 20)
        Me.txtMember_City.TabIndex = 6
        '
        'txtMember_AddressL2
        '
        Me.txtMember_AddressL2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMember_AddressL2.Location = New System.Drawing.Point(93, 65)
        Me.txtMember_AddressL2.MaxLength = 30
        Me.txtMember_AddressL2.Name = "txtMember_AddressL2"
        Me.txtMember_AddressL2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMember_AddressL2.Size = New System.Drawing.Size(649, 20)
        Me.txtMember_AddressL2.TabIndex = 4
        '
        'txtMember_AddressL1
        '
        Me.txtMember_AddressL1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMember_AddressL1.Location = New System.Drawing.Point(93, 39)
        Me.txtMember_AddressL1.MaxLength = 30
        Me.txtMember_AddressL1.Name = "txtMember_AddressL1"
        Me.txtMember_AddressL1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMember_AddressL1.Size = New System.Drawing.Size(649, 20)
        Me.txtMember_AddressL1.TabIndex = 3
        '
        'lblMember_Address
        '
        Me.lblMember_Address.AutoSize = True
        Me.lblMember_Address.Location = New System.Drawing.Point(7, 43)
        Me.lblMember_Address.Name = "lblMember_Address"
        Me.lblMember_Address.Size = New System.Drawing.Size(80, 13)
        Me.lblMember_Address.TabIndex = 2
        Me.lblMember_Address.Text = "Postal Address:"
        '
        'lblMember_ID
        '
        Me.lblMember_ID.AutoSize = True
        Me.lblMember_ID.Location = New System.Drawing.Point(6, 573)
        Me.lblMember_ID.Name = "lblMember_ID"
        Me.lblMember_ID.Size = New System.Drawing.Size(34, 13)
        Me.lblMember_ID.TabIndex = 16
        Me.lblMember_ID.Text = "GUID"
        Me.lblMember_ID.Visible = False
        '
        'txtRequested_Amount_Old
        '
        Me.txtRequested_Amount_Old.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequested_Amount_Old.Location = New System.Drawing.Point(332, 244)
        Me.txtRequested_Amount_Old.MaxLength = 6
        Me.txtRequested_Amount_Old.Name = "txtRequested_Amount_Old"
        Me.txtRequested_Amount_Old.ReadOnly = True
        Me.txtRequested_Amount_Old.Size = New System.Drawing.Size(75, 20)
        Me.txtRequested_Amount_Old.TabIndex = 11
        Me.txtRequested_Amount_Old.TabStop = False
        Me.txtRequested_Amount_Old.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRequested_Amount_Old
        '
        Me.lblRequested_Amount_Old.AutoSize = True
        Me.lblRequested_Amount_Old.Location = New System.Drawing.Point(225, 248)
        Me.lblRequested_Amount_Old.Name = "lblRequested_Amount_Old"
        Me.lblRequested_Amount_Old.Size = New System.Drawing.Size(101, 13)
        Me.lblRequested_Amount_Old.TabIndex = 10
        Me.lblRequested_Amount_Old.Text = "Requested Amount:"
        '
        'txtPolicy_EffectiveDate_Old
        '
        Me.txtPolicy_EffectiveDate_Old.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicy_EffectiveDate_Old.Location = New System.Drawing.Point(134, 270)
        Me.txtPolicy_EffectiveDate_Old.Name = "txtPolicy_EffectiveDate_Old"
        Me.txtPolicy_EffectiveDate_Old.ReadOnly = True
        Me.txtPolicy_EffectiveDate_Old.Size = New System.Drawing.Size(75, 20)
        Me.txtPolicy_EffectiveDate_Old.TabIndex = 13
        Me.txtPolicy_EffectiveDate_Old.TabStop = False
        '
        'lblPolicy_EffectiveDate_Old
        '
        Me.lblPolicy_EffectiveDate_Old.AutoSize = True
        Me.lblPolicy_EffectiveDate_Old.Location = New System.Drawing.Point(6, 274)
        Me.lblPolicy_EffectiveDate_Old.Name = "lblPolicy_EffectiveDate_Old"
        Me.lblPolicy_EffectiveDate_Old.Size = New System.Drawing.Size(94, 13)
        Me.lblPolicy_EffectiveDate_Old.TabIndex = 12
        Me.lblPolicy_EffectiveDate_Old.Text = "1st Payment Date:"
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
        Me.txtName.TabIndex = 5
        Me.txtName.TabStop = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(6, 196)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(112, 13)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Full Name As in NRIC:"
        '
        'txtL2_Plan_Code_Old
        '
        Me.txtL2_Plan_Code_Old.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtL2_Plan_Code_Old.Location = New System.Drawing.Point(134, 244)
        Me.txtL2_Plan_Code_Old.MaxLength = 4
        Me.txtL2_Plan_Code_Old.Name = "txtL2_Plan_Code_Old"
        Me.txtL2_Plan_Code_Old.ReadOnly = True
        Me.txtL2_Plan_Code_Old.Size = New System.Drawing.Size(61, 20)
        Me.txtL2_Plan_Code_Old.TabIndex = 9
        Me.txtL2_Plan_Code_Old.TabStop = False
        '
        'lblL2_Plan_Code_Old
        '
        Me.lblL2_Plan_Code_Old.AutoSize = True
        Me.lblL2_Plan_Code_Old.Location = New System.Drawing.Point(6, 248)
        Me.lblL2_Plan_Code_Old.Name = "lblL2_Plan_Code_Old"
        Me.lblL2_Plan_Code_Old.Size = New System.Drawing.Size(122, 13)
        Me.lblL2_Plan_Code_Old.TabIndex = 8
        Me.lblL2_Plan_Code_Old.Text = "Old Plan Code (Level 2):"
        '
        'txtFileNo
        '
        Me.txtFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileNo.Location = New System.Drawing.Point(134, 167)
        Me.txtFileNo.MaxLength = 20
        Me.txtFileNo.Name = "txtFileNo"
        Me.txtFileNo.ReadOnly = True
        Me.txtFileNo.Size = New System.Drawing.Size(135, 20)
        Me.txtFileNo.TabIndex = 3
        Me.txtFileNo.TabStop = False
        '
        'lblFileNo
        '
        Me.lblFileNo.AutoSize = True
        Me.lblFileNo.Location = New System.Drawing.Point(6, 171)
        Me.lblFileNo.Name = "lblFileNo"
        Me.lblFileNo.Size = New System.Drawing.Size(43, 13)
        Me.lblFileNo.TabIndex = 2
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
        Me.txtNRIC.TabIndex = 7
        Me.txtNRIC.TabStop = False
        '
        'lblNRIC
        '
        Me.lblNRIC.AutoSize = True
        Me.lblNRIC.Location = New System.Drawing.Point(6, 222)
        Me.lblNRIC.Name = "lblNRIC"
        Me.lblNRIC.Size = New System.Drawing.Size(67, 13)
        Me.lblNRIC.TabIndex = 6
        Me.lblNRIC.Text = "New I/C No:"
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Filter, Me.tsb_Filter_Param, Me.tsb_Filter_Go})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(771, 25)
        Me.tolForm.TabIndex = 0
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
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'dgvPolicies
        '
        Me.dgvPolicies.AllowUserToAddRows = False
        Me.dgvPolicies.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPolicies.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPolicies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPolicies.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPolicies.Location = New System.Drawing.Point(9, 31)
        Me.dgvPolicies.Name = "dgvPolicies"
        Me.dgvPolicies.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPolicies.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPolicies.Size = New System.Drawing.Size(750, 121)
        Me.dgvPolicies.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(613, 582)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 15
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
        'lblMemberPolicy_ID
        '
        Me.lblMemberPolicy_ID.AutoSize = True
        Me.lblMemberPolicy_ID.Location = New System.Drawing.Point(46, 573)
        Me.lblMemberPolicy_ID.Name = "lblMemberPolicy_ID"
        Me.lblMemberPolicy_ID.Size = New System.Drawing.Size(34, 13)
        Me.lblMemberPolicy_ID.TabIndex = 17
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.lblMemberPolicy_ID.Visible = False
        '
        'txtAdd3
        '
        Me.txtAdd3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdd3.Location = New System.Drawing.Point(93, 90)
        Me.txtAdd3.MaxLength = 30
        Me.txtAdd3.Name = "txtAdd3"
        Me.txtAdd3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAdd3.Size = New System.Drawing.Size(649, 20)
        Me.txtAdd3.TabIndex = 19
        '
        'txtAdd4
        '
        Me.txtAdd4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdd4.Location = New System.Drawing.Point(93, 116)
        Me.txtAdd4.MaxLength = 30
        Me.txtAdd4.Name = "txtAdd4"
        Me.txtAdd4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAdd4.Size = New System.Drawing.Size(649, 20)
        Me.txtAdd4.TabIndex = 20
        '
        'dlgEndosement_PostalAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 613)
        Me.Controls.Add(Me.lblMemberPolicy_ID)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblMember_ID)
        Me.Controls.Add(Me.txtRequested_Amount_Old)
        Me.Controls.Add(Me.lblRequested_Amount_Old)
        Me.Controls.Add(Me.txtPolicy_EffectiveDate_Old)
        Me.Controls.Add(Me.lblPolicy_EffectiveDate_Old)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtL2_Plan_Code_Old)
        Me.Controls.Add(Me.lblL2_Plan_Code_Old)
        Me.Controls.Add(Me.txtFileNo)
        Me.Controls.Add(Me.lblFileNo)
        Me.Controls.Add(Me.txtNRIC)
        Me.Controls.Add(Me.lblNRIC)
        Me.Controls.Add(Me.tolForm)
        Me.Controls.Add(Me.dgvPolicies)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgEndosement_PostalAddress"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Endorsement - Change of Postal Address"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvPolicies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMember_ID As System.Windows.Forms.Label
    Friend WithEvents txtRequested_Amount_Old As System.Windows.Forms.TextBox
    Friend WithEvents lblRequested_Amount_Old As System.Windows.Forms.Label
    Friend WithEvents txtPolicy_EffectiveDate_Old As System.Windows.Forms.TextBox
    Friend WithEvents lblPolicy_EffectiveDate_Old As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtL2_Plan_Code_Old As System.Windows.Forms.TextBox
    Friend WithEvents lblL2_Plan_Code_Old As System.Windows.Forms.Label
    Friend WithEvents txtFileNo As System.Windows.Forms.TextBox
    Friend WithEvents lblFileNo As System.Windows.Forms.Label
    Friend WithEvents txtNRIC As System.Windows.Forms.TextBox
    Friend WithEvents lblNRIC As System.Windows.Forms.Label
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Filter As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsb_Filter_Param As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsb_Filter_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents dgvPolicies As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txtMember_State As System.Windows.Forms.TextBox
    Friend WithEvents lblMember_State As System.Windows.Forms.Label
    Friend WithEvents txtMember_Postcode As System.Windows.Forms.TextBox
    Friend WithEvents lblMember_Postcode As System.Windows.Forms.Label
    Friend WithEvents lblMember_Town As System.Windows.Forms.Label
    Friend WithEvents txtMember_City As System.Windows.Forms.TextBox
    Friend WithEvents txtMember_AddressL2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMember_AddressL1 As System.Windows.Forms.TextBox
    Friend WithEvents lblMember_Address As System.Windows.Forms.Label
    Friend WithEvents btnState As System.Windows.Forms.Button
    Friend WithEvents lblMemberPolicy_ID As System.Windows.Forms.Label
    Friend WithEvents lblRequestedDate As System.Windows.Forms.Label
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents dtpEffective_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAdd4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAdd3 As System.Windows.Forms.TextBox

End Class
