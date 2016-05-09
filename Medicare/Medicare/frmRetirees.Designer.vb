<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetirees
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRetirees))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslblYR = New System.Windows.Forms.ToolStripLabel
        Me.tscbYR = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tstbtnGo = New System.Windows.Forms.ToolStripButton
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.January = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblRTYPE1 = New System.Windows.Forms.Label
        Me.lblTOTJAN = New System.Windows.Forms.Label
        Me.lnklblJanXport = New System.Windows.Forms.LinkLabel
        Me.lblRTYPE = New System.Windows.Forms.Label
        Me.dgvJanR = New System.Windows.Forms.DataGridView
        Me.February = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblTOTFEB = New System.Windows.Forms.Label
        Me.lnklblFEBXport = New System.Windows.Forms.LinkLabel
        Me.March = New System.Windows.Forms.TabPage
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblTOTMARCH = New System.Windows.Forms.Label
        Me.lnklblMARCHXport = New System.Windows.Forms.LinkLabel
        Me.April = New System.Windows.Forms.TabPage
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.lblTOTAPRIL = New System.Windows.Forms.Label
        Me.lnklblAPRILXport = New System.Windows.Forms.LinkLabel
        Me.May = New System.Windows.Forms.TabPage
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.lblTOTMAY = New System.Windows.Forms.Label
        Me.lnklblMAYXport = New System.Windows.Forms.LinkLabel
        Me.June = New System.Windows.Forms.TabPage
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.lblTOTJUNE = New System.Windows.Forms.Label
        Me.lnklblJUNEXport = New System.Windows.Forms.LinkLabel
        Me.July = New System.Windows.Forms.TabPage
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.lblTOTJULY = New System.Windows.Forms.Label
        Me.lnklblJULYXport = New System.Windows.Forms.LinkLabel
        Me.August = New System.Windows.Forms.TabPage
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.lblTOTAUGUST = New System.Windows.Forms.Label
        Me.lnklblAUGUSTXport = New System.Windows.Forms.LinkLabel
        Me.September = New System.Windows.Forms.TabPage
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.lblTOTSEP = New System.Windows.Forms.Label
        Me.lnklblSEPXport = New System.Windows.Forms.LinkLabel
        Me.October = New System.Windows.Forms.TabPage
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.lblTOTOCT = New System.Windows.Forms.Label
        Me.lnklblOCTXport = New System.Windows.Forms.LinkLabel
        Me.November = New System.Windows.Forms.TabPage
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.lblTOTNOV = New System.Windows.Forms.Label
        Me.lnklblNOVXport = New System.Windows.Forms.LinkLabel
        Me.December = New System.Windows.Forms.TabPage
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.lblTOTDEC = New System.Windows.Forms.Label
        Me.lnklblDECXport = New System.Windows.Forms.LinkLabel
        Me.Comments = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReminderDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Action = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AssignTo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Submit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Print = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvFebR = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewLinkColumn1 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn2 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn3 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvMarR = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn4 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewLinkColumn4 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn5 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn6 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvAprR = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn5 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn6 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewLinkColumn7 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn8 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn9 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvMayR = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn7 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn8 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewLinkColumn10 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn11 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn12 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvJuneR = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn9 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn10 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewLinkColumn13 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn14 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn15 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvJulyR = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn11 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn12 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewLinkColumn16 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn17 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn18 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvAugR = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn13 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn14 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewLinkColumn19 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn20 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn21 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvSepR = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn15 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn16 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewLinkColumn22 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn23 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn24 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvOctR = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn17 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn18 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewLinkColumn25 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn26 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn27 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvNovR = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn19 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn20 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewLinkColumn28 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn29 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn30 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvDecR = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn21 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn22 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewLinkColumn31 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn32 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn33 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsReport.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.January.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvJanR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.February.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.March.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.April.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.May.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.June.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.July.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.August.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.September.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.October.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.November.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.December.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.dgvFebR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMarR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAprR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMayR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvJuneR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvJulyR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAugR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSepR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOctR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNovR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDecR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblYR, Me.tscbYR, Me.ToolStripSeparator1, Me.tstbtnGo})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1019, 25)
        Me.tsReport.TabIndex = 13
        Me.tsReport.Text = "ToolStrip"
        '
        'tslblYR
        '
        Me.tslblYR.Name = "tslblYR"
        Me.tslblYR.Size = New System.Drawing.Size(36, 22)
        Me.tslblYR.Text = "Year :"
        '
        'tscbYR
        '
        Me.tscbYR.Name = "tscbYR"
        Me.tscbYR.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tstbtnGo
        '
        Me.tstbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tstbtnGo.Image = CType(resources.GetObject("tstbtnGo.Image"), System.Drawing.Image)
        Me.tstbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tstbtnGo.Name = "tstbtnGo"
        Me.tstbtnGo.Size = New System.Drawing.Size(35, 22)
        Me.tstbtnGo.Text = "Go..."
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.January)
        Me.TabControl1.Controls.Add(Me.February)
        Me.TabControl1.Controls.Add(Me.March)
        Me.TabControl1.Controls.Add(Me.April)
        Me.TabControl1.Controls.Add(Me.May)
        Me.TabControl1.Controls.Add(Me.June)
        Me.TabControl1.Controls.Add(Me.July)
        Me.TabControl1.Controls.Add(Me.August)
        Me.TabControl1.Controls.Add(Me.September)
        Me.TabControl1.Controls.Add(Me.October)
        Me.TabControl1.Controls.Add(Me.November)
        Me.TabControl1.Controls.Add(Me.December)
        Me.TabControl1.Location = New System.Drawing.Point(0, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1012, 389)
        Me.TabControl1.TabIndex = 14
        '
        'January
        '
        Me.January.Controls.Add(Me.Panel1)
        Me.January.Location = New System.Drawing.Point(4, 22)
        Me.January.Name = "January"
        Me.January.Padding = New System.Windows.Forms.Padding(3)
        Me.January.Size = New System.Drawing.Size(1004, 363)
        Me.January.TabIndex = 0
        Me.January.Text = "January"
        Me.January.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblRTYPE1)
        Me.Panel1.Controls.Add(Me.lblTOTJAN)
        Me.Panel1.Controls.Add(Me.lnklblJanXport)
        Me.Panel1.Controls.Add(Me.lblRTYPE)
        Me.Panel1.Controls.Add(Me.dgvJanR)
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(995, 604)
        Me.Panel1.TabIndex = 0
        '
        'lblRTYPE1
        '
        Me.lblRTYPE1.AutoSize = True
        Me.lblRTYPE1.Location = New System.Drawing.Point(516, 83)
        Me.lblRTYPE1.Name = "lblRTYPE1"
        Me.lblRTYPE1.Size = New System.Drawing.Size(49, 13)
        Me.lblRTYPE1.TabIndex = 8
        Me.lblRTYPE1.Text = "RTYPE1"
        Me.lblRTYPE1.Visible = False
        '
        'lblTOTJAN
        '
        Me.lblTOTJAN.AutoSize = True
        Me.lblTOTJAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTJAN.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTJAN.Location = New System.Drawing.Point(610, 9)
        Me.lblTOTJAN.Name = "lblTOTJAN"
        Me.lblTOTJAN.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTJAN.TabIndex = 7
        Me.lblTOTJAN.Text = "TOT"
        '
        'lnklblJanXport
        '
        Me.lnklblJanXport.AutoSize = True
        Me.lnklblJanXport.Location = New System.Drawing.Point(904, 8)
        Me.lnklblJanXport.Name = "lnklblJanXport"
        Me.lnklblJanXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblJanXport.TabIndex = 6
        Me.lnklblJanXport.TabStop = True
        Me.lnklblJanXport.Text = "Export to Excel"
        '
        'lblRTYPE
        '
        Me.lblRTYPE.AutoSize = True
        Me.lblRTYPE.Location = New System.Drawing.Point(333, 83)
        Me.lblRTYPE.Name = "lblRTYPE"
        Me.lblRTYPE.Size = New System.Drawing.Size(43, 13)
        Me.lblRTYPE.TabIndex = 5
        Me.lblRTYPE.Text = "RTYPE"
        Me.lblRTYPE.Visible = False
        '
        'dgvJanR
        '
        Me.dgvJanR.AllowUserToAddRows = False
        Me.dgvJanR.AllowUserToDeleteRows = False
        Me.dgvJanR.AllowUserToOrderColumns = True
        Me.dgvJanR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJanR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Comments, Me.ReminderDate, Me.Action, Me.AssignTo, Me.Submit, Me.View, Me.Print})
        Me.dgvJanR.Location = New System.Drawing.Point(3, 33)
        Me.dgvJanR.Name = "dgvJanR"
        Me.dgvJanR.Size = New System.Drawing.Size(979, 318)
        Me.dgvJanR.TabIndex = 4
        '
        'February
        '
        Me.February.Controls.Add(Me.Panel2)
        Me.February.Location = New System.Drawing.Point(4, 22)
        Me.February.Name = "February"
        Me.February.Padding = New System.Windows.Forms.Padding(3)
        Me.February.Size = New System.Drawing.Size(1004, 363)
        Me.February.TabIndex = 1
        Me.February.Text = "February"
        Me.February.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvFebR)
        Me.Panel2.Controls.Add(Me.lblTOTFEB)
        Me.Panel2.Controls.Add(Me.lnklblFEBXport)
        Me.Panel2.Location = New System.Drawing.Point(5, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(995, 609)
        Me.Panel2.TabIndex = 1
        '
        'lblTOTFEB
        '
        Me.lblTOTFEB.AutoSize = True
        Me.lblTOTFEB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTFEB.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTFEB.Location = New System.Drawing.Point(605, 12)
        Me.lblTOTFEB.Name = "lblTOTFEB"
        Me.lblTOTFEB.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTFEB.TabIndex = 9
        Me.lblTOTFEB.Text = "TOT"
        '
        'lnklblFEBXport
        '
        Me.lnklblFEBXport.AutoSize = True
        Me.lnklblFEBXport.Location = New System.Drawing.Point(899, 11)
        Me.lnklblFEBXport.Name = "lnklblFEBXport"
        Me.lnklblFEBXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblFEBXport.TabIndex = 8
        Me.lnklblFEBXport.TabStop = True
        Me.lnklblFEBXport.Text = "Export to Excel"
        '
        'March
        '
        Me.March.Controls.Add(Me.Panel3)
        Me.March.Location = New System.Drawing.Point(4, 22)
        Me.March.Name = "March"
        Me.March.Padding = New System.Windows.Forms.Padding(3)
        Me.March.Size = New System.Drawing.Size(1004, 363)
        Me.March.TabIndex = 2
        Me.March.Text = "March"
        Me.March.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgvMarR)
        Me.Panel3.Controls.Add(Me.lblTOTMARCH)
        Me.Panel3.Controls.Add(Me.lnklblMARCHXport)
        Me.Panel3.Location = New System.Drawing.Point(5, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(995, 606)
        Me.Panel3.TabIndex = 1
        '
        'lblTOTMARCH
        '
        Me.lblTOTMARCH.AutoSize = True
        Me.lblTOTMARCH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTMARCH.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTMARCH.Location = New System.Drawing.Point(609, 12)
        Me.lblTOTMARCH.Name = "lblTOTMARCH"
        Me.lblTOTMARCH.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTMARCH.TabIndex = 9
        Me.lblTOTMARCH.Text = "TOT"
        '
        'lnklblMARCHXport
        '
        Me.lnklblMARCHXport.AutoSize = True
        Me.lnklblMARCHXport.Location = New System.Drawing.Point(903, 11)
        Me.lnklblMARCHXport.Name = "lnklblMARCHXport"
        Me.lnklblMARCHXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblMARCHXport.TabIndex = 8
        Me.lnklblMARCHXport.TabStop = True
        Me.lnklblMARCHXport.Text = "Export to Excel"
        '
        'April
        '
        Me.April.Controls.Add(Me.Panel4)
        Me.April.Location = New System.Drawing.Point(4, 22)
        Me.April.Name = "April"
        Me.April.Padding = New System.Windows.Forms.Padding(3)
        Me.April.Size = New System.Drawing.Size(1004, 363)
        Me.April.TabIndex = 3
        Me.April.Text = "April"
        Me.April.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgvAprR)
        Me.Panel4.Controls.Add(Me.lblTOTAPRIL)
        Me.Panel4.Controls.Add(Me.lnklblAPRILXport)
        Me.Panel4.Location = New System.Drawing.Point(5, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(995, 606)
        Me.Panel4.TabIndex = 1
        '
        'lblTOTAPRIL
        '
        Me.lblTOTAPRIL.AutoSize = True
        Me.lblTOTAPRIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTAPRIL.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTAPRIL.Location = New System.Drawing.Point(611, 12)
        Me.lblTOTAPRIL.Name = "lblTOTAPRIL"
        Me.lblTOTAPRIL.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTAPRIL.TabIndex = 9
        Me.lblTOTAPRIL.Text = "TOT"
        '
        'lnklblAPRILXport
        '
        Me.lnklblAPRILXport.AutoSize = True
        Me.lnklblAPRILXport.Location = New System.Drawing.Point(905, 11)
        Me.lnklblAPRILXport.Name = "lnklblAPRILXport"
        Me.lnklblAPRILXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblAPRILXport.TabIndex = 8
        Me.lnklblAPRILXport.TabStop = True
        Me.lnklblAPRILXport.Text = "Export to Excel"
        '
        'May
        '
        Me.May.Controls.Add(Me.Panel5)
        Me.May.Location = New System.Drawing.Point(4, 22)
        Me.May.Name = "May"
        Me.May.Padding = New System.Windows.Forms.Padding(3)
        Me.May.Size = New System.Drawing.Size(1004, 363)
        Me.May.TabIndex = 4
        Me.May.Text = "May"
        Me.May.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dgvMayR)
        Me.Panel5.Controls.Add(Me.lblTOTMAY)
        Me.Panel5.Controls.Add(Me.lnklblMAYXport)
        Me.Panel5.Location = New System.Drawing.Point(5, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(995, 606)
        Me.Panel5.TabIndex = 1
        '
        'lblTOTMAY
        '
        Me.lblTOTMAY.AutoSize = True
        Me.lblTOTMAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTMAY.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTMAY.Location = New System.Drawing.Point(610, 13)
        Me.lblTOTMAY.Name = "lblTOTMAY"
        Me.lblTOTMAY.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTMAY.TabIndex = 9
        Me.lblTOTMAY.Text = "TOT"
        '
        'lnklblMAYXport
        '
        Me.lnklblMAYXport.AutoSize = True
        Me.lnklblMAYXport.Location = New System.Drawing.Point(904, 12)
        Me.lnklblMAYXport.Name = "lnklblMAYXport"
        Me.lnklblMAYXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblMAYXport.TabIndex = 8
        Me.lnklblMAYXport.TabStop = True
        Me.lnklblMAYXport.Text = "Export to Excel"
        '
        'June
        '
        Me.June.Controls.Add(Me.Panel6)
        Me.June.Location = New System.Drawing.Point(4, 22)
        Me.June.Name = "June"
        Me.June.Padding = New System.Windows.Forms.Padding(3)
        Me.June.Size = New System.Drawing.Size(1004, 363)
        Me.June.TabIndex = 5
        Me.June.Text = "June"
        Me.June.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.dgvJuneR)
        Me.Panel6.Controls.Add(Me.lblTOTJUNE)
        Me.Panel6.Controls.Add(Me.lnklblJUNEXport)
        Me.Panel6.Location = New System.Drawing.Point(5, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(995, 606)
        Me.Panel6.TabIndex = 1
        '
        'lblTOTJUNE
        '
        Me.lblTOTJUNE.AutoSize = True
        Me.lblTOTJUNE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTJUNE.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTJUNE.Location = New System.Drawing.Point(608, 13)
        Me.lblTOTJUNE.Name = "lblTOTJUNE"
        Me.lblTOTJUNE.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTJUNE.TabIndex = 9
        Me.lblTOTJUNE.Text = "TOT"
        '
        'lnklblJUNEXport
        '
        Me.lnklblJUNEXport.AutoSize = True
        Me.lnklblJUNEXport.Location = New System.Drawing.Point(902, 12)
        Me.lnklblJUNEXport.Name = "lnklblJUNEXport"
        Me.lnklblJUNEXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblJUNEXport.TabIndex = 8
        Me.lnklblJUNEXport.TabStop = True
        Me.lnklblJUNEXport.Text = "Export to Excel"
        '
        'July
        '
        Me.July.Controls.Add(Me.Panel7)
        Me.July.Location = New System.Drawing.Point(4, 22)
        Me.July.Name = "July"
        Me.July.Padding = New System.Windows.Forms.Padding(3)
        Me.July.Size = New System.Drawing.Size(1004, 363)
        Me.July.TabIndex = 6
        Me.July.Text = "July"
        Me.July.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.dgvJulyR)
        Me.Panel7.Controls.Add(Me.lblTOTJULY)
        Me.Panel7.Controls.Add(Me.lnklblJULYXport)
        Me.Panel7.Location = New System.Drawing.Point(5, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(995, 606)
        Me.Panel7.TabIndex = 1
        '
        'lblTOTJULY
        '
        Me.lblTOTJULY.AutoSize = True
        Me.lblTOTJULY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTJULY.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTJULY.Location = New System.Drawing.Point(604, 12)
        Me.lblTOTJULY.Name = "lblTOTJULY"
        Me.lblTOTJULY.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTJULY.TabIndex = 9
        Me.lblTOTJULY.Text = "TOT"
        '
        'lnklblJULYXport
        '
        Me.lnklblJULYXport.AutoSize = True
        Me.lnklblJULYXport.Location = New System.Drawing.Point(898, 11)
        Me.lnklblJULYXport.Name = "lnklblJULYXport"
        Me.lnklblJULYXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblJULYXport.TabIndex = 8
        Me.lnklblJULYXport.TabStop = True
        Me.lnklblJULYXport.Text = "Export to Excel"
        '
        'August
        '
        Me.August.Controls.Add(Me.Panel8)
        Me.August.Location = New System.Drawing.Point(4, 22)
        Me.August.Name = "August"
        Me.August.Padding = New System.Windows.Forms.Padding(3)
        Me.August.Size = New System.Drawing.Size(1004, 363)
        Me.August.TabIndex = 7
        Me.August.Text = "August"
        Me.August.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.dgvAugR)
        Me.Panel8.Controls.Add(Me.lblTOTAUGUST)
        Me.Panel8.Controls.Add(Me.lnklblAUGUSTXport)
        Me.Panel8.Location = New System.Drawing.Point(5, 4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(995, 606)
        Me.Panel8.TabIndex = 1
        '
        'lblTOTAUGUST
        '
        Me.lblTOTAUGUST.AutoSize = True
        Me.lblTOTAUGUST.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTAUGUST.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTAUGUST.Location = New System.Drawing.Point(609, 14)
        Me.lblTOTAUGUST.Name = "lblTOTAUGUST"
        Me.lblTOTAUGUST.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTAUGUST.TabIndex = 9
        Me.lblTOTAUGUST.Text = "TOT"
        '
        'lnklblAUGUSTXport
        '
        Me.lnklblAUGUSTXport.AutoSize = True
        Me.lnklblAUGUSTXport.Location = New System.Drawing.Point(903, 13)
        Me.lnklblAUGUSTXport.Name = "lnklblAUGUSTXport"
        Me.lnklblAUGUSTXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblAUGUSTXport.TabIndex = 8
        Me.lnklblAUGUSTXport.TabStop = True
        Me.lnklblAUGUSTXport.Text = "Export to Excel"
        '
        'September
        '
        Me.September.Controls.Add(Me.Panel9)
        Me.September.Location = New System.Drawing.Point(4, 22)
        Me.September.Name = "September"
        Me.September.Padding = New System.Windows.Forms.Padding(3)
        Me.September.Size = New System.Drawing.Size(1004, 363)
        Me.September.TabIndex = 8
        Me.September.Text = "September"
        Me.September.UseVisualStyleBackColor = True
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.dgvSepR)
        Me.Panel9.Controls.Add(Me.lblTOTSEP)
        Me.Panel9.Controls.Add(Me.lnklblSEPXport)
        Me.Panel9.Location = New System.Drawing.Point(5, 4)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(995, 609)
        Me.Panel9.TabIndex = 1
        '
        'lblTOTSEP
        '
        Me.lblTOTSEP.AutoSize = True
        Me.lblTOTSEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTSEP.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTSEP.Location = New System.Drawing.Point(609, 16)
        Me.lblTOTSEP.Name = "lblTOTSEP"
        Me.lblTOTSEP.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTSEP.TabIndex = 9
        Me.lblTOTSEP.Text = "TOT"
        '
        'lnklblSEPXport
        '
        Me.lnklblSEPXport.AutoSize = True
        Me.lnklblSEPXport.Location = New System.Drawing.Point(903, 15)
        Me.lnklblSEPXport.Name = "lnklblSEPXport"
        Me.lnklblSEPXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblSEPXport.TabIndex = 8
        Me.lnklblSEPXport.TabStop = True
        Me.lnklblSEPXport.Text = "Export to Excel"
        '
        'October
        '
        Me.October.Controls.Add(Me.Panel10)
        Me.October.Location = New System.Drawing.Point(4, 22)
        Me.October.Name = "October"
        Me.October.Padding = New System.Windows.Forms.Padding(3)
        Me.October.Size = New System.Drawing.Size(1004, 363)
        Me.October.TabIndex = 9
        Me.October.Text = "October"
        Me.October.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.dgvOctR)
        Me.Panel10.Controls.Add(Me.lblTOTOCT)
        Me.Panel10.Controls.Add(Me.lnklblOCTXport)
        Me.Panel10.Location = New System.Drawing.Point(5, 4)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(995, 606)
        Me.Panel10.TabIndex = 1
        '
        'lblTOTOCT
        '
        Me.lblTOTOCT.AutoSize = True
        Me.lblTOTOCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTOCT.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTOCT.Location = New System.Drawing.Point(601, 19)
        Me.lblTOTOCT.Name = "lblTOTOCT"
        Me.lblTOTOCT.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTOCT.TabIndex = 9
        Me.lblTOTOCT.Text = "TOT"
        '
        'lnklblOCTXport
        '
        Me.lnklblOCTXport.AutoSize = True
        Me.lnklblOCTXport.Location = New System.Drawing.Point(895, 18)
        Me.lnklblOCTXport.Name = "lnklblOCTXport"
        Me.lnklblOCTXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblOCTXport.TabIndex = 8
        Me.lnklblOCTXport.TabStop = True
        Me.lnklblOCTXport.Text = "Export to Excel"
        '
        'November
        '
        Me.November.Controls.Add(Me.Panel11)
        Me.November.Location = New System.Drawing.Point(4, 22)
        Me.November.Name = "November"
        Me.November.Padding = New System.Windows.Forms.Padding(3)
        Me.November.Size = New System.Drawing.Size(1004, 363)
        Me.November.TabIndex = 10
        Me.November.Text = "November"
        Me.November.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.dgvNovR)
        Me.Panel11.Controls.Add(Me.lblTOTNOV)
        Me.Panel11.Controls.Add(Me.lnklblNOVXport)
        Me.Panel11.Location = New System.Drawing.Point(5, 4)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(995, 606)
        Me.Panel11.TabIndex = 1
        '
        'lblTOTNOV
        '
        Me.lblTOTNOV.AutoSize = True
        Me.lblTOTNOV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTNOV.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTNOV.Location = New System.Drawing.Point(606, 15)
        Me.lblTOTNOV.Name = "lblTOTNOV"
        Me.lblTOTNOV.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTNOV.TabIndex = 9
        Me.lblTOTNOV.Text = "TOT"
        '
        'lnklblNOVXport
        '
        Me.lnklblNOVXport.AutoSize = True
        Me.lnklblNOVXport.Location = New System.Drawing.Point(900, 14)
        Me.lnklblNOVXport.Name = "lnklblNOVXport"
        Me.lnklblNOVXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblNOVXport.TabIndex = 8
        Me.lnklblNOVXport.TabStop = True
        Me.lnklblNOVXport.Text = "Export to Excel"
        '
        'December
        '
        Me.December.Controls.Add(Me.Panel12)
        Me.December.Location = New System.Drawing.Point(4, 22)
        Me.December.Name = "December"
        Me.December.Padding = New System.Windows.Forms.Padding(3)
        Me.December.Size = New System.Drawing.Size(1004, 363)
        Me.December.TabIndex = 11
        Me.December.Text = "December"
        Me.December.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.dgvDecR)
        Me.Panel12.Controls.Add(Me.lblTOTDEC)
        Me.Panel12.Controls.Add(Me.lnklblDECXport)
        Me.Panel12.Location = New System.Drawing.Point(5, 4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(995, 606)
        Me.Panel12.TabIndex = 1
        '
        'lblTOTDEC
        '
        Me.lblTOTDEC.AutoSize = True
        Me.lblTOTDEC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTDEC.ForeColor = System.Drawing.Color.Blue
        Me.lblTOTDEC.Location = New System.Drawing.Point(608, 15)
        Me.lblTOTDEC.Name = "lblTOTDEC"
        Me.lblTOTDEC.Size = New System.Drawing.Size(32, 13)
        Me.lblTOTDEC.TabIndex = 9
        Me.lblTOTDEC.Text = "TOT"
        '
        'lnklblDECXport
        '
        Me.lnklblDECXport.AutoSize = True
        Me.lnklblDECXport.Location = New System.Drawing.Point(902, 14)
        Me.lnklblDECXport.Name = "lnklblDECXport"
        Me.lnklblDECXport.Size = New System.Drawing.Size(78, 13)
        Me.lnklblDECXport.TabIndex = 8
        Me.lnklblDECXport.TabStop = True
        Me.lnklblDECXport.Text = "Export to Excel"
        '
        'Comments
        '
        Me.Comments.HeaderText = "Comments"
        Me.Comments.Name = "Comments"
        '
        'ReminderDate
        '
        Me.ReminderDate.HeaderText = "Reminder Date"
        Me.ReminderDate.Name = "ReminderDate"
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.Action.Name = "Action"
        '
        'AssignTo
        '
        Me.AssignTo.HeaderText = "Assign To"
        Me.AssignTo.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.AssignTo.Name = "AssignTo"
        '
        'Submit
        '
        Me.Submit.HeaderText = "Submit"
        Me.Submit.Name = "Submit"
        Me.Submit.Text = "Submit"
        Me.Submit.ToolTipText = "Submit"
        Me.Submit.UseColumnTextForLinkValue = True
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.Text = "View"
        Me.View.ToolTipText = "View"
        Me.View.UseColumnTextForLinkValue = True
        '
        'Print
        '
        Me.Print.HeaderText = "Print"
        Me.Print.Name = "Print"
        Me.Print.Text = "Print"
        Me.Print.ToolTipText = "Print"
        Me.Print.UseColumnTextForLinkValue = True
        '
        'dgvFebR
        '
        Me.dgvFebR.AllowUserToAddRows = False
        Me.dgvFebR.AllowUserToDeleteRows = False
        Me.dgvFebR.AllowUserToOrderColumns = True
        Me.dgvFebR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFebR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewComboBoxColumn1, Me.DataGridViewComboBoxColumn2, Me.DataGridViewLinkColumn1, Me.DataGridViewLinkColumn2, Me.DataGridViewLinkColumn3})
        Me.dgvFebR.Location = New System.Drawing.Point(3, 37)
        Me.dgvFebR.Name = "dgvFebR"
        Me.dgvFebR.Size = New System.Drawing.Size(979, 316)
        Me.dgvFebR.TabIndex = 10
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Reminder Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn1.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.HeaderText = "Assign To"
        Me.DataGridViewComboBoxColumn2.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        '
        'DataGridViewLinkColumn1
        '
        Me.DataGridViewLinkColumn1.HeaderText = "Submit"
        Me.DataGridViewLinkColumn1.Name = "DataGridViewLinkColumn1"
        Me.DataGridViewLinkColumn1.Text = "Submit"
        Me.DataGridViewLinkColumn1.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn1.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn2
        '
        Me.DataGridViewLinkColumn2.HeaderText = "View"
        Me.DataGridViewLinkColumn2.Name = "DataGridViewLinkColumn2"
        Me.DataGridViewLinkColumn2.Text = "View"
        Me.DataGridViewLinkColumn2.ToolTipText = "View"
        Me.DataGridViewLinkColumn2.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn3
        '
        Me.DataGridViewLinkColumn3.HeaderText = "Print"
        Me.DataGridViewLinkColumn3.Name = "DataGridViewLinkColumn3"
        Me.DataGridViewLinkColumn3.Text = "Print"
        Me.DataGridViewLinkColumn3.ToolTipText = "Print"
        Me.DataGridViewLinkColumn3.UseColumnTextForLinkValue = True
        '
        'dgvMarR
        '
        Me.dgvMarR.AllowUserToAddRows = False
        Me.dgvMarR.AllowUserToDeleteRows = False
        Me.dgvMarR.AllowUserToOrderColumns = True
        Me.dgvMarR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMarR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewComboBoxColumn3, Me.DataGridViewComboBoxColumn4, Me.DataGridViewLinkColumn4, Me.DataGridViewLinkColumn5, Me.DataGridViewLinkColumn6})
        Me.dgvMarR.Location = New System.Drawing.Point(8, 35)
        Me.dgvMarR.Name = "dgvMarR"
        Me.dgvMarR.Size = New System.Drawing.Size(979, 318)
        Me.dgvMarR.TabIndex = 11
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Reminder Date"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewComboBoxColumn3
        '
        Me.DataGridViewComboBoxColumn3.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn3.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
        '
        'DataGridViewComboBoxColumn4
        '
        Me.DataGridViewComboBoxColumn4.HeaderText = "Assign To"
        Me.DataGridViewComboBoxColumn4.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.DataGridViewComboBoxColumn4.Name = "DataGridViewComboBoxColumn4"
        '
        'DataGridViewLinkColumn4
        '
        Me.DataGridViewLinkColumn4.HeaderText = "Submit"
        Me.DataGridViewLinkColumn4.Name = "DataGridViewLinkColumn4"
        Me.DataGridViewLinkColumn4.Text = "Submit"
        Me.DataGridViewLinkColumn4.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn4.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn5
        '
        Me.DataGridViewLinkColumn5.HeaderText = "View"
        Me.DataGridViewLinkColumn5.Name = "DataGridViewLinkColumn5"
        Me.DataGridViewLinkColumn5.Text = "View"
        Me.DataGridViewLinkColumn5.ToolTipText = "View"
        Me.DataGridViewLinkColumn5.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn6
        '
        Me.DataGridViewLinkColumn6.HeaderText = "Print"
        Me.DataGridViewLinkColumn6.Name = "DataGridViewLinkColumn6"
        Me.DataGridViewLinkColumn6.Text = "Print"
        Me.DataGridViewLinkColumn6.ToolTipText = "Print"
        Me.DataGridViewLinkColumn6.UseColumnTextForLinkValue = True
        '
        'dgvAprR
        '
        Me.dgvAprR.AllowUserToAddRows = False
        Me.dgvAprR.AllowUserToDeleteRows = False
        Me.dgvAprR.AllowUserToOrderColumns = True
        Me.dgvAprR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAprR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewComboBoxColumn5, Me.DataGridViewComboBoxColumn6, Me.DataGridViewLinkColumn7, Me.DataGridViewLinkColumn8, Me.DataGridViewLinkColumn9})
        Me.dgvAprR.Location = New System.Drawing.Point(8, 39)
        Me.dgvAprR.Name = "dgvAprR"
        Me.dgvAprR.Size = New System.Drawing.Size(979, 314)
        Me.dgvAprR.TabIndex = 11
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Reminder Date"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewComboBoxColumn5
        '
        Me.DataGridViewComboBoxColumn5.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn5.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.DataGridViewComboBoxColumn5.Name = "DataGridViewComboBoxColumn5"
        '
        'DataGridViewComboBoxColumn6
        '
        Me.DataGridViewComboBoxColumn6.HeaderText = "Assign To"
        Me.DataGridViewComboBoxColumn6.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.DataGridViewComboBoxColumn6.Name = "DataGridViewComboBoxColumn6"
        '
        'DataGridViewLinkColumn7
        '
        Me.DataGridViewLinkColumn7.HeaderText = "Submit"
        Me.DataGridViewLinkColumn7.Name = "DataGridViewLinkColumn7"
        Me.DataGridViewLinkColumn7.Text = "Submit"
        Me.DataGridViewLinkColumn7.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn7.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn8
        '
        Me.DataGridViewLinkColumn8.HeaderText = "View"
        Me.DataGridViewLinkColumn8.Name = "DataGridViewLinkColumn8"
        Me.DataGridViewLinkColumn8.Text = "View"
        Me.DataGridViewLinkColumn8.ToolTipText = "View"
        Me.DataGridViewLinkColumn8.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn9
        '
        Me.DataGridViewLinkColumn9.HeaderText = "Print"
        Me.DataGridViewLinkColumn9.Name = "DataGridViewLinkColumn9"
        Me.DataGridViewLinkColumn9.Text = "Print"
        Me.DataGridViewLinkColumn9.ToolTipText = "Print"
        Me.DataGridViewLinkColumn9.UseColumnTextForLinkValue = True
        '
        'dgvMayR
        '
        Me.dgvMayR.AllowUserToAddRows = False
        Me.dgvMayR.AllowUserToDeleteRows = False
        Me.dgvMayR.AllowUserToOrderColumns = True
        Me.dgvMayR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMayR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewComboBoxColumn7, Me.DataGridViewComboBoxColumn8, Me.DataGridViewLinkColumn10, Me.DataGridViewLinkColumn11, Me.DataGridViewLinkColumn12})
        Me.dgvMayR.Location = New System.Drawing.Point(8, 38)
        Me.dgvMayR.Name = "dgvMayR"
        Me.dgvMayR.Size = New System.Drawing.Size(979, 315)
        Me.dgvMayR.TabIndex = 11
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Reminder Date"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewComboBoxColumn7
        '
        Me.DataGridViewComboBoxColumn7.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn7.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.DataGridViewComboBoxColumn7.Name = "DataGridViewComboBoxColumn7"
        '
        'DataGridViewComboBoxColumn8
        '
        Me.DataGridViewComboBoxColumn8.HeaderText = "Assign To"
        Me.DataGridViewComboBoxColumn8.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.DataGridViewComboBoxColumn8.Name = "DataGridViewComboBoxColumn8"
        '
        'DataGridViewLinkColumn10
        '
        Me.DataGridViewLinkColumn10.HeaderText = "Submit"
        Me.DataGridViewLinkColumn10.Name = "DataGridViewLinkColumn10"
        Me.DataGridViewLinkColumn10.Text = "Submit"
        Me.DataGridViewLinkColumn10.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn10.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn11
        '
        Me.DataGridViewLinkColumn11.HeaderText = "View"
        Me.DataGridViewLinkColumn11.Name = "DataGridViewLinkColumn11"
        Me.DataGridViewLinkColumn11.Text = "View"
        Me.DataGridViewLinkColumn11.ToolTipText = "View"
        Me.DataGridViewLinkColumn11.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn12
        '
        Me.DataGridViewLinkColumn12.HeaderText = "Print"
        Me.DataGridViewLinkColumn12.Name = "DataGridViewLinkColumn12"
        Me.DataGridViewLinkColumn12.Text = "Print"
        Me.DataGridViewLinkColumn12.ToolTipText = "Print"
        Me.DataGridViewLinkColumn12.UseColumnTextForLinkValue = True
        '
        'dgvJuneR
        '
        Me.dgvJuneR.AllowUserToAddRows = False
        Me.dgvJuneR.AllowUserToDeleteRows = False
        Me.dgvJuneR.AllowUserToOrderColumns = True
        Me.dgvJuneR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJuneR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewComboBoxColumn9, Me.DataGridViewComboBoxColumn10, Me.DataGridViewLinkColumn13, Me.DataGridViewLinkColumn14, Me.DataGridViewLinkColumn15})
        Me.dgvJuneR.Location = New System.Drawing.Point(8, 40)
        Me.dgvJuneR.Name = "dgvJuneR"
        Me.dgvJuneR.Size = New System.Drawing.Size(979, 313)
        Me.dgvJuneR.TabIndex = 11
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Reminder Date"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewComboBoxColumn9
        '
        Me.DataGridViewComboBoxColumn9.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn9.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.DataGridViewComboBoxColumn9.Name = "DataGridViewComboBoxColumn9"
        '
        'DataGridViewComboBoxColumn10
        '
        Me.DataGridViewComboBoxColumn10.HeaderText = "Assign To"
        Me.DataGridViewComboBoxColumn10.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.DataGridViewComboBoxColumn10.Name = "DataGridViewComboBoxColumn10"
        '
        'DataGridViewLinkColumn13
        '
        Me.DataGridViewLinkColumn13.HeaderText = "Submit"
        Me.DataGridViewLinkColumn13.Name = "DataGridViewLinkColumn13"
        Me.DataGridViewLinkColumn13.Text = "Submit"
        Me.DataGridViewLinkColumn13.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn13.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn14
        '
        Me.DataGridViewLinkColumn14.HeaderText = "View"
        Me.DataGridViewLinkColumn14.Name = "DataGridViewLinkColumn14"
        Me.DataGridViewLinkColumn14.Text = "View"
        Me.DataGridViewLinkColumn14.ToolTipText = "View"
        Me.DataGridViewLinkColumn14.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn15
        '
        Me.DataGridViewLinkColumn15.HeaderText = "Print"
        Me.DataGridViewLinkColumn15.Name = "DataGridViewLinkColumn15"
        Me.DataGridViewLinkColumn15.Text = "Print"
        Me.DataGridViewLinkColumn15.ToolTipText = "Print"
        Me.DataGridViewLinkColumn15.UseColumnTextForLinkValue = True
        '
        'dgvJulyR
        '
        Me.dgvJulyR.AllowUserToAddRows = False
        Me.dgvJulyR.AllowUserToDeleteRows = False
        Me.dgvJulyR.AllowUserToOrderColumns = True
        Me.dgvJulyR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJulyR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewComboBoxColumn11, Me.DataGridViewComboBoxColumn12, Me.DataGridViewLinkColumn16, Me.DataGridViewLinkColumn17, Me.DataGridViewLinkColumn18})
        Me.dgvJulyR.Location = New System.Drawing.Point(8, 36)
        Me.dgvJulyR.Name = "dgvJulyR"
        Me.dgvJulyR.Size = New System.Drawing.Size(979, 317)
        Me.dgvJulyR.TabIndex = 11
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Reminder Date"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewComboBoxColumn11
        '
        Me.DataGridViewComboBoxColumn11.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn11.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.DataGridViewComboBoxColumn11.Name = "DataGridViewComboBoxColumn11"
        '
        'DataGridViewComboBoxColumn12
        '
        Me.DataGridViewComboBoxColumn12.HeaderText = "Assign To"
        Me.DataGridViewComboBoxColumn12.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.DataGridViewComboBoxColumn12.Name = "DataGridViewComboBoxColumn12"
        '
        'DataGridViewLinkColumn16
        '
        Me.DataGridViewLinkColumn16.HeaderText = "Submit"
        Me.DataGridViewLinkColumn16.Name = "DataGridViewLinkColumn16"
        Me.DataGridViewLinkColumn16.Text = "Submit"
        Me.DataGridViewLinkColumn16.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn16.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn17
        '
        Me.DataGridViewLinkColumn17.HeaderText = "View"
        Me.DataGridViewLinkColumn17.Name = "DataGridViewLinkColumn17"
        Me.DataGridViewLinkColumn17.Text = "View"
        Me.DataGridViewLinkColumn17.ToolTipText = "View"
        Me.DataGridViewLinkColumn17.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn18
        '
        Me.DataGridViewLinkColumn18.HeaderText = "Print"
        Me.DataGridViewLinkColumn18.Name = "DataGridViewLinkColumn18"
        Me.DataGridViewLinkColumn18.Text = "Print"
        Me.DataGridViewLinkColumn18.ToolTipText = "Print"
        Me.DataGridViewLinkColumn18.UseColumnTextForLinkValue = True
        '
        'dgvAugR
        '
        Me.dgvAugR.AllowUserToAddRows = False
        Me.dgvAugR.AllowUserToDeleteRows = False
        Me.dgvAugR.AllowUserToOrderColumns = True
        Me.dgvAugR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAugR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewComboBoxColumn13, Me.DataGridViewComboBoxColumn14, Me.DataGridViewLinkColumn19, Me.DataGridViewLinkColumn20, Me.DataGridViewLinkColumn21})
        Me.dgvAugR.Location = New System.Drawing.Point(8, 37)
        Me.dgvAugR.Name = "dgvAugR"
        Me.dgvAugR.Size = New System.Drawing.Size(979, 316)
        Me.dgvAugR.TabIndex = 11
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Reminder Date"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewComboBoxColumn13
        '
        Me.DataGridViewComboBoxColumn13.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn13.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.DataGridViewComboBoxColumn13.Name = "DataGridViewComboBoxColumn13"
        '
        'DataGridViewComboBoxColumn14
        '
        Me.DataGridViewComboBoxColumn14.HeaderText = "Assign To"
        Me.DataGridViewComboBoxColumn14.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.DataGridViewComboBoxColumn14.Name = "DataGridViewComboBoxColumn14"
        '
        'DataGridViewLinkColumn19
        '
        Me.DataGridViewLinkColumn19.HeaderText = "Submit"
        Me.DataGridViewLinkColumn19.Name = "DataGridViewLinkColumn19"
        Me.DataGridViewLinkColumn19.Text = "Submit"
        Me.DataGridViewLinkColumn19.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn19.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn20
        '
        Me.DataGridViewLinkColumn20.HeaderText = "View"
        Me.DataGridViewLinkColumn20.Name = "DataGridViewLinkColumn20"
        Me.DataGridViewLinkColumn20.Text = "View"
        Me.DataGridViewLinkColumn20.ToolTipText = "View"
        Me.DataGridViewLinkColumn20.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn21
        '
        Me.DataGridViewLinkColumn21.HeaderText = "Print"
        Me.DataGridViewLinkColumn21.Name = "DataGridViewLinkColumn21"
        Me.DataGridViewLinkColumn21.Text = "Print"
        Me.DataGridViewLinkColumn21.ToolTipText = "Print"
        Me.DataGridViewLinkColumn21.UseColumnTextForLinkValue = True
        '
        'dgvSepR
        '
        Me.dgvSepR.AllowUserToAddRows = False
        Me.dgvSepR.AllowUserToDeleteRows = False
        Me.dgvSepR.AllowUserToOrderColumns = True
        Me.dgvSepR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSepR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewComboBoxColumn15, Me.DataGridViewComboBoxColumn16, Me.DataGridViewLinkColumn22, Me.DataGridViewLinkColumn23, Me.DataGridViewLinkColumn24})
        Me.dgvSepR.Location = New System.Drawing.Point(8, 39)
        Me.dgvSepR.Name = "dgvSepR"
        Me.dgvSepR.Size = New System.Drawing.Size(979, 314)
        Me.dgvSepR.TabIndex = 11
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "Reminder Date"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewComboBoxColumn15
        '
        Me.DataGridViewComboBoxColumn15.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn15.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.DataGridViewComboBoxColumn15.Name = "DataGridViewComboBoxColumn15"
        '
        'DataGridViewComboBoxColumn16
        '
        Me.DataGridViewComboBoxColumn16.HeaderText = "Assign To"
        Me.DataGridViewComboBoxColumn16.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.DataGridViewComboBoxColumn16.Name = "DataGridViewComboBoxColumn16"
        '
        'DataGridViewLinkColumn22
        '
        Me.DataGridViewLinkColumn22.HeaderText = "Submit"
        Me.DataGridViewLinkColumn22.Name = "DataGridViewLinkColumn22"
        Me.DataGridViewLinkColumn22.Text = "Submit"
        Me.DataGridViewLinkColumn22.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn22.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn23
        '
        Me.DataGridViewLinkColumn23.HeaderText = "View"
        Me.DataGridViewLinkColumn23.Name = "DataGridViewLinkColumn23"
        Me.DataGridViewLinkColumn23.Text = "View"
        Me.DataGridViewLinkColumn23.ToolTipText = "View"
        Me.DataGridViewLinkColumn23.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn24
        '
        Me.DataGridViewLinkColumn24.HeaderText = "Print"
        Me.DataGridViewLinkColumn24.Name = "DataGridViewLinkColumn24"
        Me.DataGridViewLinkColumn24.Text = "Print"
        Me.DataGridViewLinkColumn24.ToolTipText = "Print"
        Me.DataGridViewLinkColumn24.UseColumnTextForLinkValue = True
        '
        'dgvOctR
        '
        Me.dgvOctR.AllowUserToAddRows = False
        Me.dgvOctR.AllowUserToDeleteRows = False
        Me.dgvOctR.AllowUserToOrderColumns = True
        Me.dgvOctR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOctR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewComboBoxColumn17, Me.DataGridViewComboBoxColumn18, Me.DataGridViewLinkColumn25, Me.DataGridViewLinkColumn26, Me.DataGridViewLinkColumn27})
        Me.dgvOctR.Location = New System.Drawing.Point(8, 43)
        Me.dgvOctR.Name = "dgvOctR"
        Me.dgvOctR.Size = New System.Drawing.Size(979, 310)
        Me.dgvOctR.TabIndex = 11
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "Reminder Date"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewComboBoxColumn17
        '
        Me.DataGridViewComboBoxColumn17.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn17.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.DataGridViewComboBoxColumn17.Name = "DataGridViewComboBoxColumn17"
        '
        'DataGridViewComboBoxColumn18
        '
        Me.DataGridViewComboBoxColumn18.HeaderText = "Assign To"
        Me.DataGridViewComboBoxColumn18.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.DataGridViewComboBoxColumn18.Name = "DataGridViewComboBoxColumn18"
        '
        'DataGridViewLinkColumn25
        '
        Me.DataGridViewLinkColumn25.HeaderText = "Submit"
        Me.DataGridViewLinkColumn25.Name = "DataGridViewLinkColumn25"
        Me.DataGridViewLinkColumn25.Text = "Submit"
        Me.DataGridViewLinkColumn25.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn25.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn26
        '
        Me.DataGridViewLinkColumn26.HeaderText = "View"
        Me.DataGridViewLinkColumn26.Name = "DataGridViewLinkColumn26"
        Me.DataGridViewLinkColumn26.Text = "View"
        Me.DataGridViewLinkColumn26.ToolTipText = "View"
        Me.DataGridViewLinkColumn26.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn27
        '
        Me.DataGridViewLinkColumn27.HeaderText = "Print"
        Me.DataGridViewLinkColumn27.Name = "DataGridViewLinkColumn27"
        Me.DataGridViewLinkColumn27.Text = "Print"
        Me.DataGridViewLinkColumn27.ToolTipText = "Print"
        Me.DataGridViewLinkColumn27.UseColumnTextForLinkValue = True
        '
        'dgvNovR
        '
        Me.dgvNovR.AllowUserToAddRows = False
        Me.dgvNovR.AllowUserToDeleteRows = False
        Me.dgvNovR.AllowUserToOrderColumns = True
        Me.dgvNovR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNovR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewComboBoxColumn19, Me.DataGridViewComboBoxColumn20, Me.DataGridViewLinkColumn28, Me.DataGridViewLinkColumn29, Me.DataGridViewLinkColumn30})
        Me.dgvNovR.Location = New System.Drawing.Point(8, 40)
        Me.dgvNovR.Name = "dgvNovR"
        Me.dgvNovR.Size = New System.Drawing.Size(979, 313)
        Me.dgvNovR.TabIndex = 11
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "Reminder Date"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        '
        'DataGridViewComboBoxColumn19
        '
        Me.DataGridViewComboBoxColumn19.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn19.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.DataGridViewComboBoxColumn19.Name = "DataGridViewComboBoxColumn19"
        '
        'DataGridViewComboBoxColumn20
        '
        Me.DataGridViewComboBoxColumn20.HeaderText = "Assign To"
        Me.DataGridViewComboBoxColumn20.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.DataGridViewComboBoxColumn20.Name = "DataGridViewComboBoxColumn20"
        '
        'DataGridViewLinkColumn28
        '
        Me.DataGridViewLinkColumn28.HeaderText = "Submit"
        Me.DataGridViewLinkColumn28.Name = "DataGridViewLinkColumn28"
        Me.DataGridViewLinkColumn28.Text = "Submit"
        Me.DataGridViewLinkColumn28.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn28.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn29
        '
        Me.DataGridViewLinkColumn29.HeaderText = "View"
        Me.DataGridViewLinkColumn29.Name = "DataGridViewLinkColumn29"
        Me.DataGridViewLinkColumn29.Text = "View"
        Me.DataGridViewLinkColumn29.ToolTipText = "View"
        Me.DataGridViewLinkColumn29.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn30
        '
        Me.DataGridViewLinkColumn30.HeaderText = "Print"
        Me.DataGridViewLinkColumn30.Name = "DataGridViewLinkColumn30"
        Me.DataGridViewLinkColumn30.Text = "Print"
        Me.DataGridViewLinkColumn30.ToolTipText = "Print"
        Me.DataGridViewLinkColumn30.UseColumnTextForLinkValue = True
        '
        'dgvDecR
        '
        Me.dgvDecR.AllowUserToAddRows = False
        Me.dgvDecR.AllowUserToDeleteRows = False
        Me.dgvDecR.AllowUserToOrderColumns = True
        Me.dgvDecR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDecR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewComboBoxColumn21, Me.DataGridViewComboBoxColumn22, Me.DataGridViewLinkColumn31, Me.DataGridViewLinkColumn32, Me.DataGridViewLinkColumn33})
        Me.dgvDecR.Location = New System.Drawing.Point(8, 39)
        Me.dgvDecR.Name = "dgvDecR"
        Me.dgvDecR.Size = New System.Drawing.Size(979, 314)
        Me.dgvDecR.TabIndex = 11
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "Comments"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.HeaderText = "Reminder Date"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        '
        'DataGridViewComboBoxColumn21
        '
        Me.DataGridViewComboBoxColumn21.HeaderText = "Action"
        Me.DataGridViewComboBoxColumn21.Items.AddRange(New Object() {"CANCEL POLICY"})
        Me.DataGridViewComboBoxColumn21.Name = "DataGridViewComboBoxColumn21"
        '
        'DataGridViewComboBoxColumn22
        '
        Me.DataGridViewComboBoxColumn22.HeaderText = "Assign To"
        Me.DataGridViewComboBoxColumn22.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.DataGridViewComboBoxColumn22.Name = "DataGridViewComboBoxColumn22"
        '
        'DataGridViewLinkColumn31
        '
        Me.DataGridViewLinkColumn31.HeaderText = "Submit"
        Me.DataGridViewLinkColumn31.Name = "DataGridViewLinkColumn31"
        Me.DataGridViewLinkColumn31.Text = "Submit"
        Me.DataGridViewLinkColumn31.ToolTipText = "Submit"
        Me.DataGridViewLinkColumn31.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn32
        '
        Me.DataGridViewLinkColumn32.HeaderText = "View"
        Me.DataGridViewLinkColumn32.Name = "DataGridViewLinkColumn32"
        Me.DataGridViewLinkColumn32.Text = "View"
        Me.DataGridViewLinkColumn32.ToolTipText = "View"
        Me.DataGridViewLinkColumn32.UseColumnTextForLinkValue = True
        '
        'DataGridViewLinkColumn33
        '
        Me.DataGridViewLinkColumn33.HeaderText = "Print"
        Me.DataGridViewLinkColumn33.Name = "DataGridViewLinkColumn33"
        Me.DataGridViewLinkColumn33.Text = "Print"
        Me.DataGridViewLinkColumn33.ToolTipText = "Print"
        Me.DataGridViewLinkColumn33.UseColumnTextForLinkValue = True
        '
        'frmRetirees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 423)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "frmRetirees"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retirees"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.January.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvJanR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.February.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.March.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.April.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.May.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.June.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.July.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.August.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.September.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.October.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.November.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.December.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        CType(Me.dgvFebR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMarR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAprR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMayR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvJuneR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvJulyR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAugR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSepR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOctR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNovR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDecR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblYR As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbYR As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents January As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblRTYPE1 As System.Windows.Forms.Label
    Friend WithEvents lblTOTJAN As System.Windows.Forms.Label
    Friend WithEvents lnklblJanXport As System.Windows.Forms.LinkLabel
    Friend WithEvents lblRTYPE As System.Windows.Forms.Label
    Friend WithEvents dgvJanR As System.Windows.Forms.DataGridView
    Friend WithEvents February As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblTOTFEB As System.Windows.Forms.Label
    Friend WithEvents lnklblFEBXport As System.Windows.Forms.LinkLabel
    Friend WithEvents March As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblTOTMARCH As System.Windows.Forms.Label
    Friend WithEvents lnklblMARCHXport As System.Windows.Forms.LinkLabel
    Friend WithEvents April As System.Windows.Forms.TabPage
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblTOTAPRIL As System.Windows.Forms.Label
    Friend WithEvents lnklblAPRILXport As System.Windows.Forms.LinkLabel
    Friend WithEvents May As System.Windows.Forms.TabPage
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblTOTMAY As System.Windows.Forms.Label
    Friend WithEvents lnklblMAYXport As System.Windows.Forms.LinkLabel
    Friend WithEvents June As System.Windows.Forms.TabPage
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblTOTJUNE As System.Windows.Forms.Label
    Friend WithEvents lnklblJUNEXport As System.Windows.Forms.LinkLabel
    Friend WithEvents July As System.Windows.Forms.TabPage
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents lblTOTJULY As System.Windows.Forms.Label
    Friend WithEvents lnklblJULYXport As System.Windows.Forms.LinkLabel
    Friend WithEvents August As System.Windows.Forms.TabPage
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents lblTOTAUGUST As System.Windows.Forms.Label
    Friend WithEvents lnklblAUGUSTXport As System.Windows.Forms.LinkLabel
    Friend WithEvents September As System.Windows.Forms.TabPage
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents lblTOTSEP As System.Windows.Forms.Label
    Friend WithEvents lnklblSEPXport As System.Windows.Forms.LinkLabel
    Friend WithEvents October As System.Windows.Forms.TabPage
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents lblTOTOCT As System.Windows.Forms.Label
    Friend WithEvents lnklblOCTXport As System.Windows.Forms.LinkLabel
    Friend WithEvents November As System.Windows.Forms.TabPage
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents lblTOTNOV As System.Windows.Forms.Label
    Friend WithEvents lnklblNOVXport As System.Windows.Forms.LinkLabel
    Friend WithEvents December As System.Windows.Forms.TabPage
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents lblTOTDEC As System.Windows.Forms.Label
    Friend WithEvents lnklblDECXport As System.Windows.Forms.LinkLabel
    Friend WithEvents Comments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReminderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Action As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AssignTo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Submit As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Print As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvFebR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewLinkColumn1 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn2 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn3 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvMarR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewLinkColumn4 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn5 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn6 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvAprR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn5 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn6 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewLinkColumn7 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn8 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn9 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvMayR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn7 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn8 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewLinkColumn10 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn11 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn12 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvJuneR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn9 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn10 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewLinkColumn13 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn14 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn15 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvJulyR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn11 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn12 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewLinkColumn16 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn17 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn18 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvAugR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn13 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn14 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewLinkColumn19 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn20 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn21 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvSepR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn15 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn16 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewLinkColumn22 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn23 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn24 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvOctR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn17 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn18 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewLinkColumn25 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn26 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn27 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvNovR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn19 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn20 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewLinkColumn28 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn29 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn30 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvDecR As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn21 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn22 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewLinkColumn31 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn32 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn33 As System.Windows.Forms.DataGridViewLinkColumn
End Class
