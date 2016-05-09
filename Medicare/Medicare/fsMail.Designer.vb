<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fsMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fsMail))
        Me.gbUW = New System.Windows.Forms.GroupBox
        Me.cbMaklumatAhliKTL = New System.Windows.Forms.CheckBox
        Me.cbBorangAngkasaBPA179TCMT = New System.Windows.Forms.CheckBox
        Me.cbBorangAngkasaBPA179TD = New System.Windows.Forms.CheckBox
        Me.cbBorangPermohonanTL = New System.Windows.Forms.CheckBox
        Me.cbSalinanSlipGTJTD = New System.Windows.Forms.CheckBox
        Me.cbSalinanKPTD = New System.Windows.Forms.CheckBox
        Me.gbSendMail = New System.Windows.Forms.GroupBox
        Me.lblType = New System.Windows.Forms.Label
        Me.dgvSendMailDetails = New System.Windows.Forms.DataGridView
        Me.SendMail = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btnSend = New System.Windows.Forms.Button
        Me.btnDiscard = New System.Windows.Forms.Button
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_Filter = New System.Windows.Forms.ToolStripComboBox
        Me.tsb_Filter_Param = New System.Windows.Forms.ToolStripTextBox
        Me.tsb_Filter_Go = New System.Windows.Forms.ToolStripButton
        Me.gbUW.SuspendLayout()
        Me.gbSendMail.SuspendLayout()
        CType(Me.dgvSendMailDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tolForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbUW
        '
        Me.gbUW.Controls.Add(Me.cbMaklumatAhliKTL)
        Me.gbUW.Controls.Add(Me.cbBorangAngkasaBPA179TCMT)
        Me.gbUW.Controls.Add(Me.cbBorangAngkasaBPA179TD)
        Me.gbUW.Controls.Add(Me.cbBorangPermohonanTL)
        Me.gbUW.Controls.Add(Me.cbSalinanSlipGTJTD)
        Me.gbUW.Controls.Add(Me.cbSalinanKPTD)
        Me.gbUW.Location = New System.Drawing.Point(12, 28)
        Me.gbUW.Name = "gbUW"
        Me.gbUW.Size = New System.Drawing.Size(823, 73)
        Me.gbUW.TabIndex = 0
        Me.gbUW.TabStop = False
        Me.gbUW.Text = "Check List for Incomplete"
        '
        'cbMaklumatAhliKTL
        '
        Me.cbMaklumatAhliKTL.AutoSize = True
        Me.cbMaklumatAhliKTL.Location = New System.Drawing.Point(592, 42)
        Me.cbMaklumatAhliKTL.Name = "cbMaklumatAhliKTL"
        Me.cbMaklumatAhliKTL.Size = New System.Drawing.Size(212, 17)
        Me.cbMaklumatAhliKTL.TabIndex = 5
        Me.cbMaklumatAhliKTL.Text = "Maklumat Ahli Keluarga Tidak Lengkap"
        Me.cbMaklumatAhliKTL.UseVisualStyleBackColor = True
        '
        'cbBorangAngkasaBPA179TCMT
        '
        Me.cbBorangAngkasaBPA179TCMT.AutoSize = True
        Me.cbBorangAngkasaBPA179TCMT.Location = New System.Drawing.Point(251, 42)
        Me.cbBorangAngkasaBPA179TCMT.Name = "cbBorangAngkasaBPA179TCMT"
        Me.cbBorangAngkasaBPA179TCMT.Size = New System.Drawing.Size(316, 17)
        Me.cbBorangAngkasaBPA179TCMT.TabIndex = 4
        Me.cbBorangAngkasaBPA179TCMT.Text = "Borang Angkasa BPA 1/79 Tiada Cop Majikan/Tandatangan"
        Me.cbBorangAngkasaBPA179TCMT.UseVisualStyleBackColor = True
        '
        'cbBorangAngkasaBPA179TD
        '
        Me.cbBorangAngkasaBPA179TD.AutoSize = True
        Me.cbBorangAngkasaBPA179TD.Location = New System.Drawing.Point(6, 42)
        Me.cbBorangAngkasaBPA179TD.Name = "cbBorangAngkasaBPA179TD"
        Me.cbBorangAngkasaBPA179TD.Size = New System.Drawing.Size(239, 17)
        Me.cbBorangAngkasaBPA179TD.TabIndex = 3
        Me.cbBorangAngkasaBPA179TD.Text = "Borang Angkasa BPA 1/79 Tidak Disertakan"
        Me.cbBorangAngkasaBPA179TD.UseVisualStyleBackColor = True
        '
        'cbBorangPermohonanTL
        '
        Me.cbBorangPermohonanTL.AutoSize = True
        Me.cbBorangPermohonanTL.Location = New System.Drawing.Point(592, 19)
        Me.cbBorangPermohonanTL.Name = "cbBorangPermohonanTL"
        Me.cbBorangPermohonanTL.Size = New System.Drawing.Size(198, 17)
        Me.cbBorangPermohonanTL.TabIndex = 2
        Me.cbBorangPermohonanTL.Text = "Borang Permohonan Tidak Lengkap"
        Me.cbBorangPermohonanTL.UseVisualStyleBackColor = True
        '
        'cbSalinanSlipGTJTD
        '
        Me.cbSalinanSlipGTJTD.AutoSize = True
        Me.cbSalinanSlipGTJTD.Location = New System.Drawing.Point(251, 19)
        Me.cbSalinanSlipGTJTD.Name = "cbSalinanSlipGTJTD"
        Me.cbSalinanSlipGTJTD.Size = New System.Drawing.Size(251, 17)
        Me.cbSalinanSlipGTJTD.TabIndex = 1
        Me.cbSalinanSlipGTJTD.Text = "Salinan Slip Gaji Terkini & Jelas Tidak Disertakan"
        Me.cbSalinanSlipGTJTD.UseVisualStyleBackColor = True
        '
        'cbSalinanKPTD
        '
        Me.cbSalinanKPTD.AutoSize = True
        Me.cbSalinanKPTD.Location = New System.Drawing.Point(6, 19)
        Me.cbSalinanKPTD.Name = "cbSalinanKPTD"
        Me.cbSalinanKPTD.Size = New System.Drawing.Size(167, 17)
        Me.cbSalinanKPTD.TabIndex = 0
        Me.cbSalinanKPTD.Text = "Salinan K/P Tidak Disertakan"
        Me.cbSalinanKPTD.UseVisualStyleBackColor = True
        '
        'gbSendMail
        '
        Me.gbSendMail.Controls.Add(Me.lblType)
        Me.gbSendMail.Controls.Add(Me.dgvSendMailDetails)
        Me.gbSendMail.Location = New System.Drawing.Point(12, 107)
        Me.gbSendMail.Name = "gbSendMail"
        Me.gbSendMail.Size = New System.Drawing.Size(823, 411)
        Me.gbSendMail.TabIndex = 1
        Me.gbSendMail.TabStop = False
        Me.gbSendMail.Text = "Send E-Mail"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(531, 164)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(35, 13)
        Me.lblType.TabIndex = 1
        Me.lblType.Text = "TYPE"
        Me.lblType.Visible = False
        '
        'dgvSendMailDetails
        '
        Me.dgvSendMailDetails.AllowUserToAddRows = False
        Me.dgvSendMailDetails.AllowUserToDeleteRows = False
        Me.dgvSendMailDetails.AllowUserToOrderColumns = True
        Me.dgvSendMailDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSendMailDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SendMail})
        Me.dgvSendMailDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSendMailDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvSendMailDetails.Name = "dgvSendMailDetails"
        Me.dgvSendMailDetails.Size = New System.Drawing.Size(817, 392)
        Me.dgvSendMailDetails.TabIndex = 0
        '
        'SendMail
        '
        Me.SendMail.FalseValue = "F"
        Me.SendMail.HeaderText = "(Tick)"
        Me.SendMail.Name = "SendMail"
        Me.SendMail.TrueValue = "T"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(327, 525)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 2
        Me.btnSend.Text = "Send "
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'btnDiscard
        '
        Me.btnDiscard.Location = New System.Drawing.Point(408, 525)
        Me.btnDiscard.Name = "btnDiscard"
        Me.btnDiscard.Size = New System.Drawing.Size(75, 23)
        Me.btnDiscard.TabIndex = 3
        Me.btnDiscard.Text = "Discard"
        Me.btnDiscard.UseVisualStyleBackColor = True
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Filter, Me.tsb_Filter_Param, Me.tsb_Filter_Go})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(856, 25)
        Me.tolForm.TabIndex = 4
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
        'fsMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 551)
        Me.Controls.Add(Me.tolForm)
        Me.Controls.Add(Me.btnDiscard)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.gbSendMail)
        Me.Controls.Add(Me.gbUW)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fsMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Send mail"
        Me.gbUW.ResumeLayout(False)
        Me.gbUW.PerformLayout()
        Me.gbSendMail.ResumeLayout(False)
        Me.gbSendMail.PerformLayout()
        CType(Me.dgvSendMailDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbUW As System.Windows.Forms.GroupBox
    Friend WithEvents cbSalinanKPTD As System.Windows.Forms.CheckBox
    Friend WithEvents cbBorangPermohonanTL As System.Windows.Forms.CheckBox
    Friend WithEvents cbSalinanSlipGTJTD As System.Windows.Forms.CheckBox
    Friend WithEvents cbMaklumatAhliKTL As System.Windows.Forms.CheckBox
    Friend WithEvents cbBorangAngkasaBPA179TCMT As System.Windows.Forms.CheckBox
    Friend WithEvents cbBorangAngkasaBPA179TD As System.Windows.Forms.CheckBox
    Friend WithEvents gbSendMail As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSendMailDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnDiscard As System.Windows.Forms.Button
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents SendMail As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Filter As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsb_Filter_Param As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsb_Filter_Go As System.Windows.Forms.ToolStripButton
End Class
