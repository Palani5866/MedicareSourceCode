<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEndosement_L2_Plan_Code
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgEndosement_L2_Plan_Code))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_Filter = New System.Windows.Forms.ToolStripComboBox
        Me.tsb_Filter_Param = New System.Windows.Forms.ToolStripTextBox
        Me.tsb_Filter_Go = New System.Windows.Forms.ToolStripButton
        Me.dgvPolicies = New System.Windows.Forms.DataGridView
        Me.txtRequested_Amount_Old = New System.Windows.Forms.TextBox
        Me.lblRequested_Amount_Old = New System.Windows.Forms.Label
        Me.lblPolicy_CancellationDate = New System.Windows.Forms.Label
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblPlanCodeLevel2 = New System.Windows.Forms.Label
        Me.txtPlanCodeLevel2 = New System.Windows.Forms.TextBox
        Me.txtPlanCodeAmt = New System.Windows.Forms.TextBox
        Me.txtPlanCode = New System.Windows.Forms.TextBox
        Me.btnPlan = New System.Windows.Forms.Button
        Me.dtpEffective_Date = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblRequestedDate = New System.Windows.Forms.Label
        Me.dtpRequestedDate = New System.Windows.Forms.DateTimePicker
        Me.lblRequested_Amount_New = New System.Windows.Forms.Label
        Me.lblL2_Plan_Code_New = New System.Windows.Forms.Label
        Me.dtpPolicy_CancellationDate_Old = New System.Windows.Forms.DateTimePicker
        Me.lblRemark = New System.Windows.Forms.Label
        Me.lblMemberPolicy_ID = New System.Windows.Forms.Label
        Me.btnDependent_Add = New System.Windows.Forms.Button
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(543, 568)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 16
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
        Me.tolForm.Size = New System.Drawing.Size(701, 25)
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
        'dgvPolicies
        '
        Me.dgvPolicies.AllowUserToAddRows = False
        Me.dgvPolicies.AllowUserToDeleteRows = False
        Me.dgvPolicies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPolicies.Location = New System.Drawing.Point(9, 28)
        Me.dgvPolicies.Name = "dgvPolicies"
        Me.dgvPolicies.ReadOnly = True
        Me.dgvPolicies.Size = New System.Drawing.Size(680, 121)
        Me.dgvPolicies.TabIndex = 1
        '
        'txtRequested_Amount_Old
        '
        Me.txtRequested_Amount_Old.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequested_Amount_Old.Location = New System.Drawing.Point(338, 235)
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
        Me.lblRequested_Amount_Old.Location = New System.Drawing.Point(231, 239)
        Me.lblRequested_Amount_Old.Name = "lblRequested_Amount_Old"
        Me.lblRequested_Amount_Old.Size = New System.Drawing.Size(101, 13)
        Me.lblRequested_Amount_Old.TabIndex = 10
        Me.lblRequested_Amount_Old.Text = "Requested Amount:"
        '
        'lblPolicy_CancellationDate
        '
        Me.lblPolicy_CancellationDate.AutoSize = True
        Me.lblPolicy_CancellationDate.Location = New System.Drawing.Point(13, 49)
        Me.lblPolicy_CancellationDate.Name = "lblPolicy_CancellationDate"
        Me.lblPolicy_CancellationDate.Size = New System.Drawing.Size(103, 13)
        Me.lblPolicy_CancellationDate.TabIndex = 2
        Me.lblPolicy_CancellationDate.Text = "Plan Changed Date:"
        '
        'txtPolicy_EffectiveDate_Old
        '
        Me.txtPolicy_EffectiveDate_Old.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolicy_EffectiveDate_Old.Location = New System.Drawing.Point(140, 261)
        Me.txtPolicy_EffectiveDate_Old.Name = "txtPolicy_EffectiveDate_Old"
        Me.txtPolicy_EffectiveDate_Old.ReadOnly = True
        Me.txtPolicy_EffectiveDate_Old.Size = New System.Drawing.Size(75, 20)
        Me.txtPolicy_EffectiveDate_Old.TabIndex = 13
        Me.txtPolicy_EffectiveDate_Old.TabStop = False
        '
        'lblPolicy_EffectiveDate_Old
        '
        Me.lblPolicy_EffectiveDate_Old.AutoSize = True
        Me.lblPolicy_EffectiveDate_Old.Location = New System.Drawing.Point(12, 265)
        Me.lblPolicy_EffectiveDate_Old.Name = "lblPolicy_EffectiveDate_Old"
        Me.lblPolicy_EffectiveDate_Old.Size = New System.Drawing.Size(94, 13)
        Me.lblPolicy_EffectiveDate_Old.TabIndex = 12
        Me.lblPolicy_EffectiveDate_Old.Text = "1st Payment Date:"
        '
        'txtName
        '
        Me.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(140, 183)
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
        Me.lblName.Location = New System.Drawing.Point(12, 187)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(112, 13)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Full Name As in NRIC:"
        '
        'txtL2_Plan_Code_Old
        '
        Me.txtL2_Plan_Code_Old.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtL2_Plan_Code_Old.Location = New System.Drawing.Point(140, 235)
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
        Me.lblL2_Plan_Code_Old.Location = New System.Drawing.Point(12, 239)
        Me.lblL2_Plan_Code_Old.Name = "lblL2_Plan_Code_Old"
        Me.lblL2_Plan_Code_Old.Size = New System.Drawing.Size(122, 13)
        Me.lblL2_Plan_Code_Old.TabIndex = 8
        Me.lblL2_Plan_Code_Old.Text = "Old Plan Code (Level 2):"
        '
        'txtFileNo
        '
        Me.txtFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileNo.Location = New System.Drawing.Point(140, 158)
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
        Me.lblFileNo.Location = New System.Drawing.Point(12, 162)
        Me.lblFileNo.Name = "lblFileNo"
        Me.lblFileNo.Size = New System.Drawing.Size(43, 13)
        Me.lblFileNo.TabIndex = 2
        Me.lblFileNo.Text = "File No:"
        '
        'txtNRIC
        '
        Me.txtNRIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNRIC.Location = New System.Drawing.Point(140, 209)
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
        Me.lblNRIC.Location = New System.Drawing.Point(12, 213)
        Me.lblNRIC.Name = "lblNRIC"
        Me.lblNRIC.Size = New System.Drawing.Size(67, 13)
        Me.lblNRIC.TabIndex = 6
        Me.lblNRIC.Text = "New I/C No:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbUpload)
        Me.GroupBox1.Controls.Add(Me.lblPlanCodeLevel2)
        Me.GroupBox1.Controls.Add(Me.txtPlanCodeLevel2)
        Me.GroupBox1.Controls.Add(Me.txtPlanCodeAmt)
        Me.GroupBox1.Controls.Add(Me.txtPlanCode)
        Me.GroupBox1.Controls.Add(Me.btnPlan)
        Me.GroupBox1.Controls.Add(Me.dtpEffective_Date)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblRequestedDate)
        Me.GroupBox1.Controls.Add(Me.dtpRequestedDate)
        Me.GroupBox1.Controls.Add(Me.lblRequested_Amount_New)
        Me.GroupBox1.Controls.Add(Me.lblL2_Plan_Code_New)
        Me.GroupBox1.Controls.Add(Me.dtpPolicy_CancellationDate_Old)
        Me.GroupBox1.Controls.Add(Me.lblRemark)
        Me.GroupBox1.Controls.Add(Me.lblPolicy_CancellationDate)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 285)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(680, 279)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Change"
        '
        'lblPlanCodeLevel2
        '
        Me.lblPlanCodeLevel2.AutoSize = True
        Me.lblPlanCodeLevel2.Location = New System.Drawing.Point(288, 104)
        Me.lblPlanCodeLevel2.Name = "lblPlanCodeLevel2"
        Me.lblPlanCodeLevel2.Size = New System.Drawing.Size(106, 13)
        Me.lblPlanCodeLevel2.TabIndex = 19
        Me.lblPlanCodeLevel2.Text = "Plan Code Level (2) :"
        '
        'txtPlanCodeLevel2
        '
        Me.txtPlanCodeLevel2.Location = New System.Drawing.Point(410, 101)
        Me.txtPlanCodeLevel2.Name = "txtPlanCodeLevel2"
        Me.txtPlanCodeLevel2.Size = New System.Drawing.Size(254, 20)
        Me.txtPlanCodeLevel2.TabIndex = 18
        '
        'txtPlanCodeAmt
        '
        Me.txtPlanCodeAmt.Location = New System.Drawing.Point(141, 101)
        Me.txtPlanCodeAmt.Name = "txtPlanCodeAmt"
        Me.txtPlanCodeAmt.Size = New System.Drawing.Size(99, 20)
        Me.txtPlanCodeAmt.TabIndex = 17
        '
        'txtPlanCode
        '
        Me.txtPlanCode.Location = New System.Drawing.Point(140, 75)
        Me.txtPlanCode.Name = "txtPlanCode"
        Me.txtPlanCode.Size = New System.Drawing.Size(258, 20)
        Me.txtPlanCode.TabIndex = 16
        '
        'btnPlan
        '
        Me.btnPlan.Location = New System.Drawing.Point(404, 72)
        Me.btnPlan.Name = "btnPlan"
        Me.btnPlan.Size = New System.Drawing.Size(32, 23)
        Me.btnPlan.TabIndex = 15
        Me.btnPlan.Text = "..."
        Me.btnPlan.UseVisualStyleBackColor = True
        '
        'dtpEffective_Date
        '
        Me.dtpEffective_Date.Location = New System.Drawing.Point(141, 141)
        Me.dtpEffective_Date.Name = "dtpEffective_Date"
        Me.dtpEffective_Date.Size = New System.Drawing.Size(200, 20)
        Me.dtpEffective_Date.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 145)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Effective Date:"
        '
        'lblRequestedDate
        '
        Me.lblRequestedDate.AutoSize = True
        Me.lblRequestedDate.Location = New System.Drawing.Point(13, 23)
        Me.lblRequestedDate.Name = "lblRequestedDate"
        Me.lblRequestedDate.Size = New System.Drawing.Size(76, 13)
        Me.lblRequestedDate.TabIndex = 0
        Me.lblRequestedDate.Text = "Request Date:"
        '
        'dtpRequestedDate
        '
        Me.dtpRequestedDate.Location = New System.Drawing.Point(141, 19)
        Me.dtpRequestedDate.Name = "dtpRequestedDate"
        Me.dtpRequestedDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpRequestedDate.TabIndex = 1
        '
        'lblRequested_Amount_New
        '
        Me.lblRequested_Amount_New.AutoSize = True
        Me.lblRequested_Amount_New.Location = New System.Drawing.Point(13, 102)
        Me.lblRequested_Amount_New.Name = "lblRequested_Amount_New"
        Me.lblRequested_Amount_New.Size = New System.Drawing.Size(101, 13)
        Me.lblRequested_Amount_New.TabIndex = 7
        Me.lblRequested_Amount_New.Text = "Requested Amount:"
        '
        'lblL2_Plan_Code_New
        '
        Me.lblL2_Plan_Code_New.AutoSize = True
        Me.lblL2_Plan_Code_New.Location = New System.Drawing.Point(13, 75)
        Me.lblL2_Plan_Code_New.Name = "lblL2_Plan_Code_New"
        Me.lblL2_Plan_Code_New.Size = New System.Drawing.Size(81, 13)
        Me.lblL2_Plan_Code_New.TabIndex = 5
        Me.lblL2_Plan_Code_New.Text = "New Plan Code"
        '
        'dtpPolicy_CancellationDate_Old
        '
        Me.dtpPolicy_CancellationDate_Old.Location = New System.Drawing.Point(141, 45)
        Me.dtpPolicy_CancellationDate_Old.Name = "dtpPolicy_CancellationDate_Old"
        Me.dtpPolicy_CancellationDate_Old.Size = New System.Drawing.Size(200, 20)
        Me.dtpPolicy_CancellationDate_Old.TabIndex = 3
        '
        'lblRemark
        '
        Me.lblRemark.AutoSize = True
        Me.lblRemark.ForeColor = System.Drawing.Color.Red
        Me.lblRemark.Location = New System.Drawing.Point(347, 49)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(141, 13)
        Me.lblRemark.TabIndex = 4
        Me.lblRemark.Text = "** Old Plan Code (Level 2) **"
        Me.lblRemark.Visible = False
        '
        'lblMemberPolicy_ID
        '
        Me.lblMemberPolicy_ID.AutoSize = True
        Me.lblMemberPolicy_ID.Location = New System.Drawing.Point(379, 585)
        Me.lblMemberPolicy_ID.Name = "lblMemberPolicy_ID"
        Me.lblMemberPolicy_ID.Size = New System.Drawing.Size(34, 13)
        Me.lblMemberPolicy_ID.TabIndex = 15
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.lblMemberPolicy_ID.Visible = False
        '
        'btnDependent_Add
        '
        Me.btnDependent_Add.Location = New System.Drawing.Point(431, 570)
        Me.btnDependent_Add.Name = "btnDependent_Add"
        Me.btnDependent_Add.Size = New System.Drawing.Size(106, 26)
        Me.btnDependent_Add.TabIndex = 33
        Me.btnDependent_Add.Text = "Add Dependents"
        Me.btnDependent_Add.UseVisualStyleBackColor = True
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
        Me.gbUpload.Location = New System.Drawing.Point(17, 167)
        Me.gbUpload.Name = "gbUpload"
        Me.gbUpload.Size = New System.Drawing.Size(647, 100)
        Me.gbUpload.TabIndex = 20
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
        Me.txtBrowse.Location = New System.Drawing.Point(123, 18)
        Me.txtBrowse.Name = "txtBrowse"
        Me.txtBrowse.ReadOnly = True
        Me.txtBrowse.Size = New System.Drawing.Size(348, 20)
        Me.txtBrowse.TabIndex = 2
        '
        'txtDocName
        '
        Me.txtDocName.Location = New System.Drawing.Point(123, 44)
        Me.txtDocName.Name = "txtDocName"
        Me.txtDocName.Size = New System.Drawing.Size(348, 20)
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
        Me.lblDocName1.Location = New System.Drawing.Point(98, 47)
        Me.lblDocName1.Name = "lblDocName1"
        Me.lblDocName1.Size = New System.Drawing.Size(10, 13)
        Me.lblDocName1.TabIndex = 5
        Me.lblDocName1.Text = ":"
        '
        'lblDoc1
        '
        Me.lblDoc1.AutoSize = True
        Me.lblDoc1.Location = New System.Drawing.Point(98, 21)
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
        Me.btnBrowse.Location = New System.Drawing.Point(477, 16)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(69, 23)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.Text = "Browse.."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'dlgEndosement_L2_Plan_Code
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(701, 602)
        Me.Controls.Add(Me.btnDependent_Add)
        Me.Controls.Add(Me.lblMemberPolicy_ID)
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
        Me.Controls.Add(Me.dgvPolicies)
        Me.Controls.Add(Me.tolForm)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "dlgEndosement_L2_Plan_Code"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Endorsement - Plan Code (Level 2)"
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
    Friend WithEvents txtRequested_Amount_Old As System.Windows.Forms.TextBox
    Friend WithEvents lblRequested_Amount_Old As System.Windows.Forms.Label
    Friend WithEvents lblPolicy_CancellationDate As System.Windows.Forms.Label
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMemberPolicy_ID As System.Windows.Forms.Label
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents dtpPolicy_CancellationDate_Old As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRequested_Amount_New As System.Windows.Forms.Label
    Friend WithEvents lblL2_Plan_Code_New As System.Windows.Forms.Label
    Friend WithEvents lblRequestedDate As System.Windows.Forms.Label
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnDependent_Add As System.Windows.Forms.Button
    Friend WithEvents dtpEffective_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPlanCodeAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtPlanCode As System.Windows.Forms.TextBox
    Friend WithEvents btnPlan As System.Windows.Forms.Button
    Friend WithEvents txtPlanCodeLevel2 As System.Windows.Forms.TextBox
    Friend WithEvents lblPlanCodeLevel2 As System.Windows.Forms.Label
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
