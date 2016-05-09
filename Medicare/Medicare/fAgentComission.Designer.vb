<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fAgentComission
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
        Me.gbACDetails = New System.Windows.Forms.GroupBox
        Me.cbSelectAll = New System.Windows.Forms.CheckBox
        Me.btnDiscard = New System.Windows.Forms.Button
        Me.btnSend = New System.Windows.Forms.Button
        Me.dgvACDetails = New System.Windows.Forms.DataGridView
        Me.Tick = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.gbSearch = New System.Windows.Forms.GroupBox
        Me.txtRMTO = New System.Windows.Forms.TextBox
        Me.txtRMFROM = New System.Windows.Forms.TextBox
        Me.lblSearchBy1 = New System.Windows.Forms.Label
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.fowAgentLevel = New System.Windows.Forms.FlowLayoutPanel
        Me.rbSubmissionofDate = New System.Windows.Forms.RadioButton
        Me.rbReceivedMonth = New System.Windows.Forms.RadioButton
        Me.rbReceivedDate = New System.Windows.Forms.RadioButton
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblPeriodTo = New System.Windows.Forms.Label
        Me.dtpPeriodTo = New System.Windows.Forms.DateTimePicker
        Me.dtpPeriodFrm = New System.Windows.Forms.DateTimePicker
        Me.lblPeriod1 = New System.Windows.Forms.Label
        Me.lblPeriod = New System.Windows.Forms.Label
        Me.cbProduct = New System.Windows.Forms.ComboBox
        Me.lblProduct1 = New System.Windows.Forms.Label
        Me.lblProduct = New System.Windows.Forms.Label
        Me.dgvSentMail = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblOSGST = New System.Windows.Forms.Label
        Me.lblOSPremium = New System.Windows.Forms.Label
        Me.lblTotPremium = New System.Windows.Forms.Label
        Me.lblGST = New System.Windows.Forms.Label
        Me.lblPremium = New System.Windows.Forms.Label
        Me.gbACDetails.SuspendLayout()
        CType(Me.dgvACDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSearch.SuspendLayout()
        Me.fowAgentLevel.SuspendLayout()
        CType(Me.dgvSentMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbACDetails
        '
        Me.gbACDetails.Controls.Add(Me.cbSelectAll)
        Me.gbACDetails.Controls.Add(Me.btnDiscard)
        Me.gbACDetails.Controls.Add(Me.btnSend)
        Me.gbACDetails.Controls.Add(Me.dgvACDetails)
        Me.gbACDetails.Location = New System.Drawing.Point(24, 167)
        Me.gbACDetails.Name = "gbACDetails"
        Me.gbACDetails.Size = New System.Drawing.Size(877, 291)
        Me.gbACDetails.TabIndex = 3
        Me.gbACDetails.TabStop = False
        Me.gbACDetails.Text = "Agents Details"
        '
        'cbSelectAll
        '
        Me.cbSelectAll.AutoSize = True
        Me.cbSelectAll.Location = New System.Drawing.Point(23, 25)
        Me.cbSelectAll.Name = "cbSelectAll"
        Me.cbSelectAll.Size = New System.Drawing.Size(70, 17)
        Me.cbSelectAll.TabIndex = 32
        Me.cbSelectAll.Text = "Select All"
        Me.cbSelectAll.UseVisualStyleBackColor = True
        '
        'btnDiscard
        '
        Me.btnDiscard.Location = New System.Drawing.Point(791, 19)
        Me.btnDiscard.Name = "btnDiscard"
        Me.btnDiscard.Size = New System.Drawing.Size(59, 23)
        Me.btnDiscard.TabIndex = 31
        Me.btnDiscard.Text = "Discard"
        Me.btnDiscard.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(712, 19)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(59, 23)
        Me.btnSend.TabIndex = 30
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'dgvACDetails
        '
        Me.dgvACDetails.AllowUserToAddRows = False
        Me.dgvACDetails.AllowUserToDeleteRows = False
        Me.dgvACDetails.AllowUserToOrderColumns = True
        Me.dgvACDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvACDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tick, Me.View})
        Me.dgvACDetails.Location = New System.Drawing.Point(23, 55)
        Me.dgvACDetails.Name = "dgvACDetails"
        Me.dgvACDetails.Size = New System.Drawing.Size(838, 216)
        Me.dgvACDetails.TabIndex = 0
        '
        'Tick
        '
        Me.Tick.FalseValue = "0"
        Me.Tick.HeaderText = "Tick"
        Me.Tick.Name = "Tick"
        Me.Tick.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Tick.TrueValue = "1"
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.Text = "View"
        Me.View.ToolTipText = "View"
        Me.View.UseColumnTextForLinkValue = True
        '
        'gbSearch
        '
        Me.gbSearch.Controls.Add(Me.txtRMTO)
        Me.gbSearch.Controls.Add(Me.txtRMFROM)
        Me.gbSearch.Controls.Add(Me.lblSearchBy1)
        Me.gbSearch.Controls.Add(Me.lblSearchBy)
        Me.gbSearch.Controls.Add(Me.fowAgentLevel)
        Me.gbSearch.Controls.Add(Me.btnSubmit)
        Me.gbSearch.Controls.Add(Me.lblPeriodTo)
        Me.gbSearch.Controls.Add(Me.dtpPeriodTo)
        Me.gbSearch.Controls.Add(Me.dtpPeriodFrm)
        Me.gbSearch.Controls.Add(Me.lblPeriod1)
        Me.gbSearch.Controls.Add(Me.lblPeriod)
        Me.gbSearch.Controls.Add(Me.cbProduct)
        Me.gbSearch.Controls.Add(Me.lblProduct1)
        Me.gbSearch.Controls.Add(Me.lblProduct)
        Me.gbSearch.Location = New System.Drawing.Point(134, 12)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(614, 134)
        Me.gbSearch.TabIndex = 2
        Me.gbSearch.TabStop = False
        Me.gbSearch.Text = "Search Agent Commission"
        '
        'txtRMTO
        '
        Me.txtRMTO.Location = New System.Drawing.Point(396, 86)
        Me.txtRMTO.Name = "txtRMTO"
        Me.txtRMTO.Size = New System.Drawing.Size(100, 20)
        Me.txtRMTO.TabIndex = 92
        '
        'txtRMFROM
        '
        Me.txtRMFROM.Location = New System.Drawing.Point(218, 87)
        Me.txtRMFROM.Name = "txtRMFROM"
        Me.txtRMFROM.Size = New System.Drawing.Size(100, 20)
        Me.txtRMFROM.TabIndex = 91
        '
        'lblSearchBy1
        '
        Me.lblSearchBy1.AutoSize = True
        Me.lblSearchBy1.Location = New System.Drawing.Point(177, 51)
        Me.lblSearchBy1.Name = "lblSearchBy1"
        Me.lblSearchBy1.Size = New System.Drawing.Size(10, 13)
        Me.lblSearchBy1.TabIndex = 90
        Me.lblSearchBy1.Text = ":"
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.Location = New System.Drawing.Point(29, 51)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(56, 13)
        Me.lblSearchBy.TabIndex = 89
        Me.lblSearchBy.Text = "Search By"
        '
        'fowAgentLevel
        '
        Me.fowAgentLevel.Controls.Add(Me.rbSubmissionofDate)
        Me.fowAgentLevel.Controls.Add(Me.rbReceivedMonth)
        Me.fowAgentLevel.Controls.Add(Me.rbReceivedDate)
        Me.fowAgentLevel.Location = New System.Drawing.Point(215, 51)
        Me.fowAgentLevel.Name = "fowAgentLevel"
        Me.fowAgentLevel.Size = New System.Drawing.Size(381, 24)
        Me.fowAgentLevel.TabIndex = 88
        '
        'rbSubmissionofDate
        '
        Me.rbSubmissionofDate.AutoSize = True
        Me.rbSubmissionofDate.Location = New System.Drawing.Point(3, 3)
        Me.rbSubmissionofDate.Name = "rbSubmissionofDate"
        Me.rbSubmissionofDate.Size = New System.Drawing.Size(104, 17)
        Me.rbSubmissionofDate.TabIndex = 0
        Me.rbSubmissionofDate.TabStop = True
        Me.rbSubmissionofDate.Text = "Submission Date"
        Me.rbSubmissionofDate.UseVisualStyleBackColor = True
        '
        'rbReceivedMonth
        '
        Me.rbReceivedMonth.AutoSize = True
        Me.rbReceivedMonth.Location = New System.Drawing.Point(113, 3)
        Me.rbReceivedMonth.Name = "rbReceivedMonth"
        Me.rbReceivedMonth.Size = New System.Drawing.Size(104, 17)
        Me.rbReceivedMonth.TabIndex = 2
        Me.rbReceivedMonth.TabStop = True
        Me.rbReceivedMonth.Text = "Received Month"
        Me.rbReceivedMonth.UseVisualStyleBackColor = True
        '
        'rbReceivedDate
        '
        Me.rbReceivedDate.AutoSize = True
        Me.rbReceivedDate.Location = New System.Drawing.Point(223, 3)
        Me.rbReceivedDate.Name = "rbReceivedDate"
        Me.rbReceivedDate.Size = New System.Drawing.Size(141, 17)
        Me.rbReceivedDate.TabIndex = 3
        Me.rbReceivedDate.TabStop = True
        Me.rbReceivedDate.Text = "Proposal Received Date"
        Me.rbReceivedDate.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(537, 84)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(59, 23)
        Me.btnSubmit.TabIndex = 27
        Me.btnSubmit.Text = "Go..."
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblPeriodTo
        '
        Me.lblPeriodTo.AutoSize = True
        Me.lblPeriodTo.Location = New System.Drawing.Point(361, 90)
        Me.lblPeriodTo.Name = "lblPeriodTo"
        Me.lblPeriodTo.Size = New System.Drawing.Size(20, 13)
        Me.lblPeriodTo.TabIndex = 26
        Me.lblPeriodTo.Text = "To"
        '
        'dtpPeriodTo
        '
        Me.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPeriodTo.Location = New System.Drawing.Point(396, 86)
        Me.dtpPeriodTo.Name = "dtpPeriodTo"
        Me.dtpPeriodTo.Size = New System.Drawing.Size(135, 20)
        Me.dtpPeriodTo.TabIndex = 25
        '
        'dtpPeriodFrm
        '
        Me.dtpPeriodFrm.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPeriodFrm.Location = New System.Drawing.Point(215, 87)
        Me.dtpPeriodFrm.Name = "dtpPeriodFrm"
        Me.dtpPeriodFrm.Size = New System.Drawing.Size(135, 20)
        Me.dtpPeriodFrm.TabIndex = 24
        '
        'lblPeriod1
        '
        Me.lblPeriod1.AutoSize = True
        Me.lblPeriod1.Location = New System.Drawing.Point(177, 90)
        Me.lblPeriod1.Name = "lblPeriod1"
        Me.lblPeriod1.Size = New System.Drawing.Size(10, 13)
        Me.lblPeriod1.TabIndex = 13
        Me.lblPeriod1.Text = ":"
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(29, 90)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(105, 13)
        Me.lblPeriod.TabIndex = 12
        Me.lblPeriod.Text = "Period of Submission"
        '
        'cbProduct
        '
        Me.cbProduct.FormattingEnabled = True
        Me.cbProduct.Items.AddRange(New Object() {"All", "CUEPACSCARE", "CUEPACS PA"})
        Me.cbProduct.Location = New System.Drawing.Point(215, 24)
        Me.cbProduct.Name = "cbProduct"
        Me.cbProduct.Size = New System.Drawing.Size(381, 21)
        Me.cbProduct.TabIndex = 11
        '
        'lblProduct1
        '
        Me.lblProduct1.AutoSize = True
        Me.lblProduct1.Location = New System.Drawing.Point(177, 24)
        Me.lblProduct1.Name = "lblProduct1"
        Me.lblProduct1.Size = New System.Drawing.Size(10, 13)
        Me.lblProduct1.TabIndex = 10
        Me.lblProduct1.Text = ":"
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(29, 27)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(44, 13)
        Me.lblProduct.TabIndex = 9
        Me.lblProduct.Text = "Product"
        '
        'dgvSentMail
        '
        Me.dgvSentMail.AllowUserToAddRows = False
        Me.dgvSentMail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSentMail.Location = New System.Drawing.Point(815, 96)
        Me.dgvSentMail.Name = "dgvSentMail"
        Me.dgvSentMail.Size = New System.Drawing.Size(94, 50)
        Me.dgvSentMail.TabIndex = 4
        Me.dgvSentMail.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblOSGST)
        Me.Panel1.Controls.Add(Me.lblOSPremium)
        Me.Panel1.Controls.Add(Me.lblTotPremium)
        Me.Panel1.Controls.Add(Me.lblGST)
        Me.Panel1.Controls.Add(Me.lblPremium)
        Me.Panel1.Location = New System.Drawing.Point(12, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(94, 54)
        Me.Panel1.TabIndex = 5
        '
        'lblOSGST
        '
        Me.lblOSGST.AutoSize = True
        Me.lblOSGST.Location = New System.Drawing.Point(646, 283)
        Me.lblOSGST.Name = "lblOSGST"
        Me.lblOSGST.Size = New System.Drawing.Size(44, 13)
        Me.lblOSGST.TabIndex = 4
        Me.lblOSGST.Text = "OSGST"
        Me.lblOSGST.Visible = False
        '
        'lblOSPremium
        '
        Me.lblOSPremium.AutoSize = True
        Me.lblOSPremium.Location = New System.Drawing.Point(562, 283)
        Me.lblOSPremium.Name = "lblOSPremium"
        Me.lblOSPremium.Size = New System.Drawing.Size(62, 13)
        Me.lblOSPremium.TabIndex = 3
        Me.lblOSPremium.Text = "OSPremium"
        Me.lblOSPremium.Visible = False
        '
        'lblTotPremium
        '
        Me.lblTotPremium.AutoSize = True
        Me.lblTotPremium.Location = New System.Drawing.Point(499, 151)
        Me.lblTotPremium.Name = "lblTotPremium"
        Me.lblTotPremium.Size = New System.Drawing.Size(71, 13)
        Me.lblTotPremium.TabIndex = 2
        Me.lblTotPremium.Text = "TotalPremium"
        Me.lblTotPremium.Visible = False
        '
        'lblGST
        '
        Me.lblGST.AutoSize = True
        Me.lblGST.Location = New System.Drawing.Point(414, 151)
        Me.lblGST.Name = "lblGST"
        Me.lblGST.Size = New System.Drawing.Size(29, 13)
        Me.lblGST.TabIndex = 1
        Me.lblGST.Text = "GST"
        Me.lblGST.Visible = False
        '
        'lblPremium
        '
        Me.lblPremium.AutoSize = True
        Me.lblPremium.Location = New System.Drawing.Point(327, 151)
        Me.lblPremium.Name = "lblPremium"
        Me.lblPremium.Size = New System.Drawing.Size(47, 13)
        Me.lblPremium.TabIndex = 0
        Me.lblPremium.Text = "Premium"
        Me.lblPremium.Visible = False
        '
        'fAgentComission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 470)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvSentMail)
        Me.Controls.Add(Me.gbACDetails)
        Me.Controls.Add(Me.gbSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fAgentComission"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agent Comission Detail (Send Email)"
        Me.gbACDetails.ResumeLayout(False)
        Me.gbACDetails.PerformLayout()
        CType(Me.dgvACDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.fowAgentLevel.ResumeLayout(False)
        Me.fowAgentLevel.PerformLayout()
        CType(Me.dgvSentMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbACDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvACDetails As System.Windows.Forms.DataGridView
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents txtRMTO As System.Windows.Forms.TextBox
    Friend WithEvents txtRMFROM As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchBy1 As System.Windows.Forms.Label
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents fowAgentLevel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbSubmissionofDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbReceivedMonth As System.Windows.Forms.RadioButton
    Friend WithEvents rbReceivedDate As System.Windows.Forms.RadioButton
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblPeriodTo As System.Windows.Forms.Label
    Friend WithEvents dtpPeriodTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPeriodFrm As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPeriod1 As System.Windows.Forms.Label
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents cbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents lblProduct1 As System.Windows.Forms.Label
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents btnDiscard As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents cbSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents dgvSentMail As System.Windows.Forms.DataGridView
    Friend WithEvents Tick As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblOSGST As System.Windows.Forms.Label
    Friend WithEvents lblOSPremium As System.Windows.Forms.Label
    Friend WithEvents lblTotPremium As System.Windows.Forms.Label
    Friend WithEvents lblGST As System.Windows.Forms.Label
    Friend WithEvents lblPremium As System.Windows.Forms.Label
End Class
