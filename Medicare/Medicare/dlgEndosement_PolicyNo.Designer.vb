<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEndosement_PolicyNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgEndosement_PolicyNo))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_Filter = New System.Windows.Forms.ToolStripComboBox
        Me.tsb_Filter_Param = New System.Windows.Forms.ToolStripTextBox
        Me.tsb_Filter_Go = New System.Windows.Forms.ToolStripButton
        Me.dgvPolicies = New System.Windows.Forms.DataGridView
        Me.lblMemberPolicy_ID = New System.Windows.Forms.Label
        Me.txtPolicy_CancellationDate = New System.Windows.Forms.TextBox
        Me.lblPolicy_CancellationDate = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gbUpload = New System.Windows.Forms.GroupBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnUpload = New System.Windows.Forms.Button
        Me.txtBrowse = New System.Windows.Forms.TextBox
        Me.txtDocName = New System.Windows.Forms.TextBox
        Me.lblDoc = New System.Windows.Forms.Label
        Me.lblDocName1 = New System.Windows.Forms.Label
        Me.lblDoc1 = New System.Windows.Forms.Label
        Me.lblDocName = New System.Windows.Forms.Label
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.txtNewPolicyNo = New System.Windows.Forms.TextBox
        Me.lblNewPolicyNo = New System.Windows.Forms.Label
        Me.dtpEffective_Date = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPolicyNo = New System.Windows.Forms.TextBox
        Me.lblPolicyNo = New System.Windows.Forms.Label
        Me.lblRemark = New System.Windows.Forms.Label
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.lblRequestedDate = New System.Windows.Forms.Label
        Me.dtpRequestedDate = New System.Windows.Forms.DateTimePicker
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
        Me.lblOldPolicyNO = New System.Windows.Forms.Label
        Me.lblNewPolicyNo1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tolForm.SuspendLayout()
        CType(Me.dgvPolicies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbUpload.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(433, 541)
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
        Me.tolForm.Size = New System.Drawing.Size(594, 25)
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
        Me.dgvPolicies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPolicies.Location = New System.Drawing.Point(9, 28)
        Me.dgvPolicies.Name = "dgvPolicies"
        Me.dgvPolicies.ReadOnly = True
        Me.dgvPolicies.Size = New System.Drawing.Size(570, 121)
        Me.dgvPolicies.TabIndex = 2
        '
        'lblMemberPolicy_ID
        '
        Me.lblMemberPolicy_ID.AutoSize = True
        Me.lblMemberPolicy_ID.Location = New System.Drawing.Point(248, 553)
        Me.lblMemberPolicy_ID.Name = "lblMemberPolicy_ID"
        Me.lblMemberPolicy_ID.Size = New System.Drawing.Size(34, 13)
        Me.lblMemberPolicy_ID.TabIndex = 18
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.lblMemberPolicy_ID.Visible = False
        '
        'txtPolicy_CancellationDate
        '
        Me.txtPolicy_CancellationDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicy_CancellationDate.Location = New System.Drawing.Point(332, 258)
        Me.txtPolicy_CancellationDate.Name = "txtPolicy_CancellationDate"
        Me.txtPolicy_CancellationDate.ReadOnly = True
        Me.txtPolicy_CancellationDate.Size = New System.Drawing.Size(75, 20)
        Me.txtPolicy_CancellationDate.TabIndex = 16
        Me.txtPolicy_CancellationDate.TabStop = False
        '
        'lblPolicy_CancellationDate
        '
        Me.lblPolicy_CancellationDate.AutoSize = True
        Me.lblPolicy_CancellationDate.Location = New System.Drawing.Point(225, 262)
        Me.lblPolicy_CancellationDate.Name = "lblPolicy_CancellationDate"
        Me.lblPolicy_CancellationDate.Size = New System.Drawing.Size(94, 13)
        Me.lblPolicy_CancellationDate.TabIndex = 15
        Me.lblPolicy_CancellationDate.Text = "Cancellation Date:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbUpload)
        Me.GroupBox1.Controls.Add(Me.txtNewPolicyNo)
        Me.GroupBox1.Controls.Add(Me.lblNewPolicyNo)
        Me.GroupBox1.Controls.Add(Me.dtpEffective_Date)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPolicyNo)
        Me.GroupBox1.Controls.Add(Me.lblPolicyNo)
        Me.GroupBox1.Controls.Add(Me.lblRemark)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.lblRequestedDate)
        Me.GroupBox1.Controls.Add(Me.dtpRequestedDate)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 284)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(570, 254)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Change"
        '
        'gbUpload
        '
        Me.gbUpload.Controls.Add(Me.btnClear)
        Me.gbUpload.Controls.Add(Me.btnUpload)
        Me.gbUpload.Controls.Add(Me.txtBrowse)
        Me.gbUpload.Controls.Add(Me.txtDocName)
        Me.gbUpload.Controls.Add(Me.lblDoc)
        Me.gbUpload.Controls.Add(Me.lblDocName1)
        Me.gbUpload.Controls.Add(Me.lblDoc1)
        Me.gbUpload.Controls.Add(Me.lblDocName)
        Me.gbUpload.Controls.Add(Me.btnBrowse)
        Me.gbUpload.Location = New System.Drawing.Point(15, 146)
        Me.gbUpload.Name = "gbUpload"
        Me.gbUpload.Size = New System.Drawing.Size(542, 100)
        Me.gbUpload.TabIndex = 19
        Me.gbUpload.TabStop = False
        Me.gbUpload.Text = "Upload Document"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(275, 70)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(66, 23)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(183, 70)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(66, 23)
        Me.btnUpload.TabIndex = 7
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'txtBrowse
        '
        Me.txtBrowse.Location = New System.Drawing.Point(145, 18)
        Me.txtBrowse.Name = "txtBrowse"
        Me.txtBrowse.ReadOnly = True
        Me.txtBrowse.Size = New System.Drawing.Size(319, 20)
        Me.txtBrowse.TabIndex = 2
        '
        'txtDocName
        '
        Me.txtDocName.Location = New System.Drawing.Point(145, 44)
        Me.txtDocName.Name = "txtDocName"
        Me.txtDocName.Size = New System.Drawing.Size(319, 20)
        Me.txtDocName.TabIndex = 6
        '
        'lblDoc
        '
        Me.lblDoc.AutoSize = True
        Me.lblDoc.Location = New System.Drawing.Point(7, 21)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(56, 13)
        Me.lblDoc.TabIndex = 0
        Me.lblDoc.Text = "Document"
        '
        'lblDocName1
        '
        Me.lblDocName1.AutoSize = True
        Me.lblDocName1.Location = New System.Drawing.Point(112, 47)
        Me.lblDocName1.Name = "lblDocName1"
        Me.lblDocName1.Size = New System.Drawing.Size(10, 13)
        Me.lblDocName1.TabIndex = 5
        Me.lblDocName1.Text = ":"
        '
        'lblDoc1
        '
        Me.lblDoc1.AutoSize = True
        Me.lblDoc1.Location = New System.Drawing.Point(112, 21)
        Me.lblDoc1.Name = "lblDoc1"
        Me.lblDoc1.Size = New System.Drawing.Size(10, 13)
        Me.lblDoc1.TabIndex = 1
        Me.lblDoc1.Text = ":"
        '
        'lblDocName
        '
        Me.lblDocName.AutoSize = True
        Me.lblDocName.Location = New System.Drawing.Point(7, 47)
        Me.lblDocName.Name = "lblDocName"
        Me.lblDocName.Size = New System.Drawing.Size(87, 13)
        Me.lblDocName.TabIndex = 4
        Me.lblDocName.Text = "Document Name"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(467, 16)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(69, 23)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.Text = "Browse.."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtNewPolicyNo
        '
        Me.txtNewPolicyNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPolicyNo.Location = New System.Drawing.Point(424, 46)
        Me.txtNewPolicyNo.MaxLength = 20
        Me.txtNewPolicyNo.Name = "txtNewPolicyNo"
        Me.txtNewPolicyNo.Size = New System.Drawing.Size(109, 20)
        Me.txtNewPolicyNo.TabIndex = 18
        '
        'lblNewPolicyNo
        '
        Me.lblNewPolicyNo.AutoSize = True
        Me.lblNewPolicyNo.Location = New System.Drawing.Point(296, 50)
        Me.lblNewPolicyNo.Name = "lblNewPolicyNo"
        Me.lblNewPolicyNo.Size = New System.Drawing.Size(99, 13)
        Me.lblNewPolicyNo.TabIndex = 17
        Me.lblNewPolicyNo.Text = "New Certificate No:"
        '
        'dtpEffective_Date
        '
        Me.dtpEffective_Date.Location = New System.Drawing.Point(161, 119)
        Me.dtpEffective_Date.Name = "dtpEffective_Date"
        Me.dtpEffective_Date.Size = New System.Drawing.Size(201, 20)
        Me.dtpEffective_Date.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Effective Date:"
        '
        'txtPolicyNo
        '
        Me.txtPolicyNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicyNo.Location = New System.Drawing.Point(162, 45)
        Me.txtPolicyNo.MaxLength = 20
        Me.txtPolicyNo.Name = "txtPolicyNo"
        Me.txtPolicyNo.Size = New System.Drawing.Size(109, 20)
        Me.txtPolicyNo.TabIndex = 3
        '
        'lblPolicyNo
        '
        Me.lblPolicyNo.AutoSize = True
        Me.lblPolicyNo.Location = New System.Drawing.Point(34, 49)
        Me.lblPolicyNo.Name = "lblPolicyNo"
        Me.lblPolicyNo.Size = New System.Drawing.Size(93, 13)
        Me.lblPolicyNo.TabIndex = 2
        Me.lblPolicyNo.Text = "Old Certificate No:"
        '
        'lblRemark
        '
        Me.lblRemark.AutoSize = True
        Me.lblRemark.Location = New System.Drawing.Point(34, 75)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(47, 13)
        Me.lblRemark.TabIndex = 4
        Me.lblRemark.Text = "Remark:"
        '
        'txtRemark
        '
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Location = New System.Drawing.Point(162, 71)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(393, 35)
        Me.txtRemark.TabIndex = 5
        '
        'lblRequestedDate
        '
        Me.lblRequestedDate.AutoSize = True
        Me.lblRequestedDate.Location = New System.Drawing.Point(34, 23)
        Me.lblRequestedDate.Name = "lblRequestedDate"
        Me.lblRequestedDate.Size = New System.Drawing.Size(88, 13)
        Me.lblRequestedDate.TabIndex = 0
        Me.lblRequestedDate.Text = "Requested Date:"
        '
        'dtpRequestedDate
        '
        Me.dtpRequestedDate.Location = New System.Drawing.Point(162, 19)
        Me.dtpRequestedDate.Name = "dtpRequestedDate"
        Me.dtpRequestedDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpRequestedDate.TabIndex = 1
        '
        'txtRequested_Amount_Old
        '
        Me.txtRequested_Amount_Old.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequested_Amount_Old.Location = New System.Drawing.Point(332, 232)
        Me.txtRequested_Amount_Old.MaxLength = 6
        Me.txtRequested_Amount_Old.Name = "txtRequested_Amount_Old"
        Me.txtRequested_Amount_Old.ReadOnly = True
        Me.txtRequested_Amount_Old.Size = New System.Drawing.Size(75, 20)
        Me.txtRequested_Amount_Old.TabIndex = 12
        Me.txtRequested_Amount_Old.TabStop = False
        Me.txtRequested_Amount_Old.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRequested_Amount_Old
        '
        Me.lblRequested_Amount_Old.AutoSize = True
        Me.lblRequested_Amount_Old.Location = New System.Drawing.Point(225, 236)
        Me.lblRequested_Amount_Old.Name = "lblRequested_Amount_Old"
        Me.lblRequested_Amount_Old.Size = New System.Drawing.Size(101, 13)
        Me.lblRequested_Amount_Old.TabIndex = 11
        Me.lblRequested_Amount_Old.Text = "Requested Amount:"
        '
        'txtPolicy_EffectiveDate_Old
        '
        Me.txtPolicy_EffectiveDate_Old.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicy_EffectiveDate_Old.Location = New System.Drawing.Point(134, 258)
        Me.txtPolicy_EffectiveDate_Old.Name = "txtPolicy_EffectiveDate_Old"
        Me.txtPolicy_EffectiveDate_Old.ReadOnly = True
        Me.txtPolicy_EffectiveDate_Old.Size = New System.Drawing.Size(75, 20)
        Me.txtPolicy_EffectiveDate_Old.TabIndex = 14
        Me.txtPolicy_EffectiveDate_Old.TabStop = False
        '
        'lblPolicy_EffectiveDate_Old
        '
        Me.lblPolicy_EffectiveDate_Old.AutoSize = True
        Me.lblPolicy_EffectiveDate_Old.Location = New System.Drawing.Point(6, 262)
        Me.lblPolicy_EffectiveDate_Old.Name = "lblPolicy_EffectiveDate_Old"
        Me.lblPolicy_EffectiveDate_Old.Size = New System.Drawing.Size(94, 13)
        Me.lblPolicy_EffectiveDate_Old.TabIndex = 13
        Me.lblPolicy_EffectiveDate_Old.Text = "1st Payment Date:"
        '
        'txtName
        '
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(134, 180)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(445, 20)
        Me.txtName.TabIndex = 6
        Me.txtName.TabStop = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(6, 184)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(112, 13)
        Me.lblName.TabIndex = 5
        Me.lblName.Text = "Full Name As in NRIC:"
        '
        'txtL2_Plan_Code_Old
        '
        Me.txtL2_Plan_Code_Old.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtL2_Plan_Code_Old.Location = New System.Drawing.Point(134, 232)
        Me.txtL2_Plan_Code_Old.MaxLength = 4
        Me.txtL2_Plan_Code_Old.Name = "txtL2_Plan_Code_Old"
        Me.txtL2_Plan_Code_Old.ReadOnly = True
        Me.txtL2_Plan_Code_Old.Size = New System.Drawing.Size(61, 20)
        Me.txtL2_Plan_Code_Old.TabIndex = 10
        Me.txtL2_Plan_Code_Old.TabStop = False
        '
        'lblL2_Plan_Code_Old
        '
        Me.lblL2_Plan_Code_Old.AutoSize = True
        Me.lblL2_Plan_Code_Old.Location = New System.Drawing.Point(6, 236)
        Me.lblL2_Plan_Code_Old.Name = "lblL2_Plan_Code_Old"
        Me.lblL2_Plan_Code_Old.Size = New System.Drawing.Size(122, 13)
        Me.lblL2_Plan_Code_Old.TabIndex = 9
        Me.lblL2_Plan_Code_Old.Text = "Old Plan Code (Level 2):"
        '
        'txtFileNo
        '
        Me.txtFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileNo.Location = New System.Drawing.Point(134, 155)
        Me.txtFileNo.MaxLength = 20
        Me.txtFileNo.Name = "txtFileNo"
        Me.txtFileNo.ReadOnly = True
        Me.txtFileNo.Size = New System.Drawing.Size(135, 20)
        Me.txtFileNo.TabIndex = 4
        Me.txtFileNo.TabStop = False
        '
        'lblFileNo
        '
        Me.lblFileNo.AutoSize = True
        Me.lblFileNo.Location = New System.Drawing.Point(6, 159)
        Me.lblFileNo.Name = "lblFileNo"
        Me.lblFileNo.Size = New System.Drawing.Size(43, 13)
        Me.lblFileNo.TabIndex = 3
        Me.lblFileNo.Text = "File No:"
        '
        'txtNRIC
        '
        Me.txtNRIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNRIC.Location = New System.Drawing.Point(134, 206)
        Me.txtNRIC.MaxLength = 13
        Me.txtNRIC.Name = "txtNRIC"
        Me.txtNRIC.ReadOnly = True
        Me.txtNRIC.Size = New System.Drawing.Size(109, 20)
        Me.txtNRIC.TabIndex = 8
        Me.txtNRIC.TabStop = False
        '
        'lblNRIC
        '
        Me.lblNRIC.AutoSize = True
        Me.lblNRIC.Location = New System.Drawing.Point(6, 210)
        Me.lblNRIC.Name = "lblNRIC"
        Me.lblNRIC.Size = New System.Drawing.Size(67, 13)
        Me.lblNRIC.TabIndex = 7
        Me.lblNRIC.Text = "New I/C No:"
        '
        'lblOldPolicyNO
        '
        Me.lblOldPolicyNO.AutoSize = True
        Me.lblOldPolicyNO.Location = New System.Drawing.Point(283, 553)
        Me.lblOldPolicyNO.Name = "lblOldPolicyNO"
        Me.lblOldPolicyNO.Size = New System.Drawing.Size(67, 13)
        Me.lblOldPolicyNO.TabIndex = 19
        Me.lblOldPolicyNO.Text = "OldPolicyNO"
        Me.lblOldPolicyNO.Visible = False
        '
        'lblNewPolicyNo1
        '
        Me.lblNewPolicyNo1.AutoSize = True
        Me.lblNewPolicyNo1.Location = New System.Drawing.Point(356, 554)
        Me.lblNewPolicyNo1.Name = "lblNewPolicyNo1"
        Me.lblNewPolicyNo1.Size = New System.Drawing.Size(71, 13)
        Me.lblNewPolicyNo1.TabIndex = 20
        Me.lblNewPolicyNo1.Text = "NewPolicyNo"
        Me.lblNewPolicyNo1.Visible = False
        '
        'dlgEndosement_PolicyNo
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(594, 573)
        Me.Controls.Add(Me.lblNewPolicyNo1)
        Me.Controls.Add(Me.lblOldPolicyNO)
        Me.Controls.Add(Me.txtPolicy_CancellationDate)
        Me.Controls.Add(Me.lblPolicy_CancellationDate)
        Me.Controls.Add(Me.GroupBox1)
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
        Me.Controls.Add(Me.lblMemberPolicy_ID)
        Me.Controls.Add(Me.dgvPolicies)
        Me.Controls.Add(Me.tolForm)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "dlgEndosement_PolicyNo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Endorsement - Policy/Certificate No"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvPolicies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbUpload.ResumeLayout(False)
        Me.gbUpload.PerformLayout()
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
    Friend WithEvents lblMemberPolicy_ID As System.Windows.Forms.Label
    Friend WithEvents txtPolicy_CancellationDate As System.Windows.Forms.TextBox
    Friend WithEvents lblPolicy_CancellationDate As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPolicyNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPolicyNo As System.Windows.Forms.Label
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents lblRequestedDate As System.Windows.Forms.Label
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
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
    Friend WithEvents dtpEffective_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblOldPolicyNO As System.Windows.Forms.Label
    Friend WithEvents txtNewPolicyNo As System.Windows.Forms.TextBox
    Friend WithEvents lblNewPolicyNo As System.Windows.Forms.Label
    Friend WithEvents lblNewPolicyNo1 As System.Windows.Forms.Label
    Friend WithEvents gbUpload As System.Windows.Forms.GroupBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents txtBrowse As System.Windows.Forms.TextBox
    Friend WithEvents txtDocName As System.Windows.Forms.TextBox
    Friend WithEvents lblDoc As System.Windows.Forms.Label
    Friend WithEvents lblDocName1 As System.Windows.Forms.Label
    Friend WithEvents lblDoc1 As System.Windows.Forms.Label
    Friend WithEvents lblDocName As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button

End Class
