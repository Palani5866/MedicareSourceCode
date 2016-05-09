<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fAgentRequest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fAgentRequest))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tslblSearchBy = New System.Windows.Forms.ToolStripLabel
        Me.tscbSearchBy = New System.Windows.Forms.ToolStripComboBox
        Me.tstxtSearchBy = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.gbAgentDetails = New System.Windows.Forms.GroupBox
        Me.dgvAgentDetails = New System.Windows.Forms.DataGridView
        Me.gbAgentRequest = New System.Windows.Forms.GroupBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblRequestDate1 = New System.Windows.Forms.Label
        Me.dtpRequestDate = New System.Windows.Forms.DateTimePicker
        Me.lblRequestDate = New System.Windows.Forms.Label
        Me.lblACODE = New System.Windows.Forms.Label
        Me.lblAID = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.lblGEForms = New System.Windows.Forms.Label
        Me.txtGEForms = New System.Windows.Forms.TextBox
        Me.txtCCForms = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCPAForms = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBiro = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtNomination = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtFlyersCC = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtNameCard = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPosterCPA = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPosterCC = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtBookLetCPA = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtBookLetCC = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtFlyersCPA = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtBuntingCPA = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtBuntingCC = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.gbAgentDetails.SuspendLayout()
        CType(Me.dgvAgentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgentRequest.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblSearchBy, Me.tscbSearchBy, Me.tstxtSearchBy, Me.ToolStripSeparator1, Me.tsbtnGo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(992, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tslblSearchBy
        '
        Me.tslblSearchBy.Name = "tslblSearchBy"
        Me.tslblSearchBy.Size = New System.Drawing.Size(64, 22)
        Me.tslblSearchBy.Text = "Search By :"
        '
        'tscbSearchBy
        '
        Me.tscbSearchBy.Items.AddRange(New Object() {"AGENT CODE ", "FULL NAME"})
        Me.tscbSearchBy.Name = "tscbSearchBy"
        Me.tscbSearchBy.Size = New System.Drawing.Size(121, 25)
        '
        'tstxtSearchBy
        '
        Me.tstxtSearchBy.Name = "tstxtSearchBy"
        Me.tstxtSearchBy.Size = New System.Drawing.Size(300, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'gbAgentDetails
        '
        Me.gbAgentDetails.Controls.Add(Me.dgvAgentDetails)
        Me.gbAgentDetails.Location = New System.Drawing.Point(0, 28)
        Me.gbAgentDetails.Name = "gbAgentDetails"
        Me.gbAgentDetails.Size = New System.Drawing.Size(992, 177)
        Me.gbAgentDetails.TabIndex = 3
        Me.gbAgentDetails.TabStop = False
        Me.gbAgentDetails.Text = "Agent Details"
        '
        'dgvAgentDetails
        '
        Me.dgvAgentDetails.AllowUserToAddRows = False
        Me.dgvAgentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAgentDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAgentDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvAgentDetails.Name = "dgvAgentDetails"
        Me.dgvAgentDetails.Size = New System.Drawing.Size(986, 158)
        Me.dgvAgentDetails.TabIndex = 0
        '
        'gbAgentRequest
        '
        Me.gbAgentRequest.Controls.Add(Me.txtBuntingCPA)
        Me.gbAgentRequest.Controls.Add(Me.Label15)
        Me.gbAgentRequest.Controls.Add(Me.txtBuntingCC)
        Me.gbAgentRequest.Controls.Add(Me.Label16)
        Me.gbAgentRequest.Controls.Add(Me.txtNameCard)
        Me.gbAgentRequest.Controls.Add(Me.Label9)
        Me.gbAgentRequest.Controls.Add(Me.txtPosterCPA)
        Me.gbAgentRequest.Controls.Add(Me.Label10)
        Me.gbAgentRequest.Controls.Add(Me.txtPosterCC)
        Me.gbAgentRequest.Controls.Add(Me.Label11)
        Me.gbAgentRequest.Controls.Add(Me.txtBookLetCPA)
        Me.gbAgentRequest.Controls.Add(Me.Label12)
        Me.gbAgentRequest.Controls.Add(Me.txtBookLetCC)
        Me.gbAgentRequest.Controls.Add(Me.Label13)
        Me.gbAgentRequest.Controls.Add(Me.txtFlyersCPA)
        Me.gbAgentRequest.Controls.Add(Me.Label14)
        Me.gbAgentRequest.Controls.Add(Me.txtFlyersCC)
        Me.gbAgentRequest.Controls.Add(Me.Label8)
        Me.gbAgentRequest.Controls.Add(Me.txtNomination)
        Me.gbAgentRequest.Controls.Add(Me.Label7)
        Me.gbAgentRequest.Controls.Add(Me.txtBiro)
        Me.gbAgentRequest.Controls.Add(Me.Label6)
        Me.gbAgentRequest.Controls.Add(Me.txtCPAForms)
        Me.gbAgentRequest.Controls.Add(Me.Label5)
        Me.gbAgentRequest.Controls.Add(Me.txtCCForms)
        Me.gbAgentRequest.Controls.Add(Me.Label1)
        Me.gbAgentRequest.Controls.Add(Me.txtGEForms)
        Me.gbAgentRequest.Controls.Add(Me.lblGEForms)
        Me.gbAgentRequest.Controls.Add(Me.txtRemarks)
        Me.gbAgentRequest.Controls.Add(Me.Label3)
        Me.gbAgentRequest.Controls.Add(Me.Label4)
        Me.gbAgentRequest.Controls.Add(Me.Label2)
        Me.gbAgentRequest.Controls.Add(Me.lblRequestDate1)
        Me.gbAgentRequest.Controls.Add(Me.dtpRequestDate)
        Me.gbAgentRequest.Controls.Add(Me.lblRequestDate)
        Me.gbAgentRequest.Controls.Add(Me.lblACODE)
        Me.gbAgentRequest.Controls.Add(Me.lblAID)
        Me.gbAgentRequest.Controls.Add(Me.btnCancel)
        Me.gbAgentRequest.Controls.Add(Me.btnSubmit)
        Me.gbAgentRequest.Location = New System.Drawing.Point(6, 212)
        Me.gbAgentRequest.Name = "gbAgentRequest"
        Me.gbAgentRequest.Size = New System.Drawing.Size(976, 340)
        Me.gbAgentRequest.TabIndex = 4
        Me.gbAgentRequest.TabStop = False
        Me.gbAgentRequest.Text = "Agent Request"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(193, 197)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(637, 61)
        Me.txtRemarks.TabIndex = 57
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(56, 197)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Remarks"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(56, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Request For"
        '
        'lblRequestDate1
        '
        Me.lblRequestDate1.AutoSize = True
        Me.lblRequestDate1.Location = New System.Drawing.Point(149, 31)
        Me.lblRequestDate1.Name = "lblRequestDate1"
        Me.lblRequestDate1.Size = New System.Drawing.Size(10, 13)
        Me.lblRequestDate1.TabIndex = 51
        Me.lblRequestDate1.Text = ":"
        '
        'dtpRequestDate
        '
        Me.dtpRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRequestDate.Location = New System.Drawing.Point(193, 28)
        Me.dtpRequestDate.Name = "dtpRequestDate"
        Me.dtpRequestDate.Size = New System.Drawing.Size(135, 20)
        Me.dtpRequestDate.TabIndex = 50
        '
        'lblRequestDate
        '
        Me.lblRequestDate.AutoSize = True
        Me.lblRequestDate.Location = New System.Drawing.Point(56, 31)
        Me.lblRequestDate.Name = "lblRequestDate"
        Me.lblRequestDate.Size = New System.Drawing.Size(73, 13)
        Me.lblRequestDate.TabIndex = 49
        Me.lblRequestDate.Text = "Request Date"
        '
        'lblACODE
        '
        Me.lblACODE.AutoSize = True
        Me.lblACODE.Location = New System.Drawing.Point(667, 33)
        Me.lblACODE.Name = "lblACODE"
        Me.lblACODE.Size = New System.Drawing.Size(44, 13)
        Me.lblACODE.TabIndex = 48
        Me.lblACODE.Text = "ACODE"
        Me.lblACODE.Visible = False
        '
        'lblAID
        '
        Me.lblAID.AutoSize = True
        Me.lblAID.Location = New System.Drawing.Point(612, 33)
        Me.lblAID.Name = "lblAID"
        Me.lblAID.Size = New System.Drawing.Size(25, 13)
        Me.lblAID.TabIndex = 47
        Me.lblAID.Text = "AID"
        Me.lblAID.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(476, 291)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(395, 291)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 0
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(32, 22)
        Me.tsbtnGo.Text = "Go.."
        '
        'lblGEForms
        '
        Me.lblGEForms.AutoSize = True
        Me.lblGEForms.Location = New System.Drawing.Point(190, 90)
        Me.lblGEForms.Name = "lblGEForms"
        Me.lblGEForms.Size = New System.Drawing.Size(53, 13)
        Me.lblGEForms.TabIndex = 58
        Me.lblGEForms.Text = "GE Forms"
        '
        'txtGEForms
        '
        Me.txtGEForms.Location = New System.Drawing.Point(193, 106)
        Me.txtGEForms.Name = "txtGEForms"
        Me.txtGEForms.Size = New System.Drawing.Size(79, 20)
        Me.txtGEForms.TabIndex = 60
        '
        'txtCCForms
        '
        Me.txtCCForms.Location = New System.Drawing.Point(286, 106)
        Me.txtCCForms.Name = "txtCCForms"
        Me.txtCCForms.Size = New System.Drawing.Size(79, 20)
        Me.txtCCForms.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(283, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "CC Forms"
        '
        'txtCPAForms
        '
        Me.txtCPAForms.Location = New System.Drawing.Point(383, 106)
        Me.txtCPAForms.Name = "txtCPAForms"
        Me.txtCPAForms.Size = New System.Drawing.Size(79, 20)
        Me.txtCPAForms.TabIndex = 64
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(380, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "CPA Forms"
        '
        'txtBiro
        '
        Me.txtBiro.Location = New System.Drawing.Point(484, 106)
        Me.txtBiro.Name = "txtBiro"
        Me.txtBiro.Size = New System.Drawing.Size(79, 20)
        Me.txtBiro.TabIndex = 66
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(481, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 13)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "Biro"
        '
        'txtNomination
        '
        Me.txtNomination.Location = New System.Drawing.Point(581, 106)
        Me.txtNomination.Name = "txtNomination"
        Me.txtNomination.Size = New System.Drawing.Size(79, 20)
        Me.txtNomination.TabIndex = 68
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(578, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "Nomination"
        '
        'txtFlyersCC
        '
        Me.txtFlyersCC.Location = New System.Drawing.Point(666, 106)
        Me.txtFlyersCC.Name = "txtFlyersCC"
        Me.txtFlyersCC.Size = New System.Drawing.Size(79, 20)
        Me.txtFlyersCC.TabIndex = 70
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(663, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Flyers CC"
        '
        'txtNameCard
        '
        Me.txtNameCard.Location = New System.Drawing.Point(573, 156)
        Me.txtNameCard.Name = "txtNameCard"
        Me.txtNameCard.Size = New System.Drawing.Size(79, 20)
        Me.txtNameCard.TabIndex = 82
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(570, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "Name Card"
        '
        'txtPosterCPA
        '
        Me.txtPosterCPA.Location = New System.Drawing.Point(488, 156)
        Me.txtPosterCPA.Name = "txtPosterCPA"
        Me.txtPosterCPA.Size = New System.Drawing.Size(79, 20)
        Me.txtPosterCPA.TabIndex = 80
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(485, 140)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 79
        Me.Label10.Text = "Poster CPA"
        '
        'txtPosterCC
        '
        Me.txtPosterCC.Location = New System.Drawing.Point(391, 156)
        Me.txtPosterCC.Name = "txtPosterCC"
        Me.txtPosterCC.Size = New System.Drawing.Size(79, 20)
        Me.txtPosterCC.TabIndex = 78
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(388, 140)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Poster CC"
        '
        'txtBookLetCPA
        '
        Me.txtBookLetCPA.Location = New System.Drawing.Point(290, 156)
        Me.txtBookLetCPA.Name = "txtBookLetCPA"
        Me.txtBookLetCPA.Size = New System.Drawing.Size(79, 20)
        Me.txtBookLetCPA.TabIndex = 76
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(287, 140)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Book Let CPA"
        '
        'txtBookLetCC
        '
        Me.txtBookLetCC.Location = New System.Drawing.Point(193, 156)
        Me.txtBookLetCC.Name = "txtBookLetCC"
        Me.txtBookLetCC.Size = New System.Drawing.Size(79, 20)
        Me.txtBookLetCC.TabIndex = 74
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(190, 140)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "Book Let CC"
        '
        'txtFlyersCPA
        '
        Me.txtFlyersCPA.Location = New System.Drawing.Point(751, 106)
        Me.txtFlyersCPA.Name = "txtFlyersCPA"
        Me.txtFlyersCPA.Size = New System.Drawing.Size(79, 20)
        Me.txtFlyersCPA.TabIndex = 72
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(757, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 71
        Me.Label14.Text = "Flyers CPA"
        '
        'txtBuntingCPA
        '
        Me.txtBuntingCPA.Location = New System.Drawing.Point(751, 156)
        Me.txtBuntingCPA.Name = "txtBuntingCPA"
        Me.txtBuntingCPA.Size = New System.Drawing.Size(79, 20)
        Me.txtBuntingCPA.TabIndex = 86
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(748, 140)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 85
        Me.Label15.Text = "Bunting CPA"
        '
        'txtBuntingCC
        '
        Me.txtBuntingCC.Location = New System.Drawing.Point(666, 156)
        Me.txtBuntingCC.Name = "txtBuntingCC"
        Me.txtBuntingCC.Size = New System.Drawing.Size(79, 20)
        Me.txtBuntingCC.TabIndex = 84
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(663, 140)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 83
        Me.Label16.Text = "Bunting CC"
        '
        'fAgentRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 564)
        Me.Controls.Add(Me.gbAgentRequest)
        Me.Controls.Add(Me.gbAgentDetails)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "fAgentRequest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agent Request"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbAgentDetails.ResumeLayout(False)
        CType(Me.dgvAgentDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgentRequest.ResumeLayout(False)
        Me.gbAgentRequest.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblSearchBy As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbSearchBy As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tstxtSearchBy As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbAgentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvAgentDetails As System.Windows.Forms.DataGridView
    Friend WithEvents gbAgentRequest As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblACODE As System.Windows.Forms.Label
    Friend WithEvents lblAID As System.Windows.Forms.Label
    Friend WithEvents lblRequestDate1 As System.Windows.Forms.Label
    Friend WithEvents dtpRequestDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRequestDate As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblGEForms As System.Windows.Forms.Label
    Friend WithEvents txtGEForms As System.Windows.Forms.TextBox
    Friend WithEvents txtNameCard As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPosterCPA As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPosterCC As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtBookLetCPA As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBookLetCC As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFlyersCPA As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFlyersCC As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNomination As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBiro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCPAForms As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCCForms As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBuntingCPA As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtBuntingCC As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
