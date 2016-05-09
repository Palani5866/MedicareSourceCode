<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vAgent_Commission
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
        Me.gbSearch = New System.Windows.Forms.GroupBox
        Me.txtRMTO = New System.Windows.Forms.TextBox
        Me.txtRMFROM = New System.Windows.Forms.TextBox
        Me.lblSearchBy1 = New System.Windows.Forms.Label
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.fowAgentLevel = New System.Windows.Forms.FlowLayoutPanel
        Me.rbSubmissionofDate = New System.Windows.Forms.RadioButton
        Me.rbEffectiveDate = New System.Windows.Forms.RadioButton
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
        Me.cbAgent = New System.Windows.Forms.ComboBox
        Me.lblAgent1 = New System.Windows.Forms.Label
        Me.lblAgent = New System.Windows.Forms.Label
        Me.cbSupervisor = New System.Windows.Forms.ComboBox
        Me.lblSupervisor1 = New System.Windows.Forms.Label
        Me.lblSupervisor = New System.Windows.Forms.Label
        Me.cbManager = New System.Windows.Forms.ComboBox
        Me.lblManager1 = New System.Windows.Forms.Label
        Me.lblManager = New System.Windows.Forms.Label
        Me.gbACDetails = New System.Windows.Forms.GroupBox
        Me.dgvACDetails = New System.Windows.Forms.DataGridView
        Me.llXport2Xcel = New System.Windows.Forms.LinkLabel
        Me.gbSearch.SuspendLayout()
        Me.fowAgentLevel.SuspendLayout()
        Me.gbACDetails.SuspendLayout()
        CType(Me.dgvACDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.gbSearch.Controls.Add(Me.cbAgent)
        Me.gbSearch.Controls.Add(Me.lblAgent1)
        Me.gbSearch.Controls.Add(Me.lblAgent)
        Me.gbSearch.Controls.Add(Me.cbSupervisor)
        Me.gbSearch.Controls.Add(Me.lblSupervisor1)
        Me.gbSearch.Controls.Add(Me.lblSupervisor)
        Me.gbSearch.Controls.Add(Me.cbManager)
        Me.gbSearch.Controls.Add(Me.lblManager1)
        Me.gbSearch.Controls.Add(Me.lblManager)
        Me.gbSearch.Location = New System.Drawing.Point(137, 12)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(598, 257)
        Me.gbSearch.TabIndex = 0
        Me.gbSearch.TabStop = False
        Me.gbSearch.Text = "Search Agent Commission"
        '
        'txtRMTO
        '
        Me.txtRMTO.Location = New System.Drawing.Point(421, 182)
        Me.txtRMTO.Name = "txtRMTO"
        Me.txtRMTO.Size = New System.Drawing.Size(100, 20)
        Me.txtRMTO.TabIndex = 92
        '
        'txtRMFROM
        '
        Me.txtRMFROM.Location = New System.Drawing.Point(243, 183)
        Me.txtRMFROM.Name = "txtRMFROM"
        Me.txtRMFROM.Size = New System.Drawing.Size(100, 20)
        Me.txtRMFROM.TabIndex = 91
        '
        'lblSearchBy1
        '
        Me.lblSearchBy1.AutoSize = True
        Me.lblSearchBy1.Location = New System.Drawing.Point(202, 127)
        Me.lblSearchBy1.Name = "lblSearchBy1"
        Me.lblSearchBy1.Size = New System.Drawing.Size(10, 13)
        Me.lblSearchBy1.TabIndex = 90
        Me.lblSearchBy1.Text = ":"
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.Location = New System.Drawing.Point(54, 127)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(56, 13)
        Me.lblSearchBy.TabIndex = 89
        Me.lblSearchBy.Text = "Search By"
        '
        'fowAgentLevel
        '
        Me.fowAgentLevel.Controls.Add(Me.rbSubmissionofDate)
        Me.fowAgentLevel.Controls.Add(Me.rbEffectiveDate)
        Me.fowAgentLevel.Controls.Add(Me.rbReceivedMonth)
        Me.fowAgentLevel.Controls.Add(Me.rbReceivedDate)
        Me.fowAgentLevel.Location = New System.Drawing.Point(240, 127)
        Me.fowAgentLevel.Name = "fowAgentLevel"
        Me.fowAgentLevel.Size = New System.Drawing.Size(316, 49)
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
        'rbEffectiveDate
        '
        Me.rbEffectiveDate.AutoSize = True
        Me.rbEffectiveDate.Location = New System.Drawing.Point(113, 3)
        Me.rbEffectiveDate.Name = "rbEffectiveDate"
        Me.rbEffectiveDate.Size = New System.Drawing.Size(93, 17)
        Me.rbEffectiveDate.TabIndex = 1
        Me.rbEffectiveDate.TabStop = True
        Me.rbEffectiveDate.Text = "Effective Date"
        Me.rbEffectiveDate.UseVisualStyleBackColor = True
        '
        'rbReceivedMonth
        '
        Me.rbReceivedMonth.AutoSize = True
        Me.rbReceivedMonth.Location = New System.Drawing.Point(3, 26)
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
        Me.rbReceivedDate.Location = New System.Drawing.Point(113, 26)
        Me.rbReceivedDate.Name = "rbReceivedDate"
        Me.rbReceivedDate.Size = New System.Drawing.Size(141, 17)
        Me.rbReceivedDate.TabIndex = 3
        Me.rbReceivedDate.TabStop = True
        Me.rbReceivedDate.Text = "Proposal Received Date"
        Me.rbReceivedDate.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(274, 218)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 27
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblPeriodTo
        '
        Me.lblPeriodTo.AutoSize = True
        Me.lblPeriodTo.Location = New System.Drawing.Point(386, 186)
        Me.lblPeriodTo.Name = "lblPeriodTo"
        Me.lblPeriodTo.Size = New System.Drawing.Size(20, 13)
        Me.lblPeriodTo.TabIndex = 26
        Me.lblPeriodTo.Text = "To"
        '
        'dtpPeriodTo
        '
        Me.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPeriodTo.Location = New System.Drawing.Point(421, 182)
        Me.dtpPeriodTo.Name = "dtpPeriodTo"
        Me.dtpPeriodTo.Size = New System.Drawing.Size(135, 20)
        Me.dtpPeriodTo.TabIndex = 25
        '
        'dtpPeriodFrm
        '
        Me.dtpPeriodFrm.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPeriodFrm.Location = New System.Drawing.Point(240, 183)
        Me.dtpPeriodFrm.Name = "dtpPeriodFrm"
        Me.dtpPeriodFrm.Size = New System.Drawing.Size(135, 20)
        Me.dtpPeriodFrm.TabIndex = 24
        '
        'lblPeriod1
        '
        Me.lblPeriod1.AutoSize = True
        Me.lblPeriod1.Location = New System.Drawing.Point(202, 186)
        Me.lblPeriod1.Name = "lblPeriod1"
        Me.lblPeriod1.Size = New System.Drawing.Size(10, 13)
        Me.lblPeriod1.TabIndex = 13
        Me.lblPeriod1.Text = ":"
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(54, 186)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(105, 13)
        Me.lblPeriod.TabIndex = 12
        Me.lblPeriod.Text = "Period of Submission"
        '
        'cbProduct
        '
        Me.cbProduct.FormattingEnabled = True
        Me.cbProduct.Location = New System.Drawing.Point(240, 100)
        Me.cbProduct.Name = "cbProduct"
        Me.cbProduct.Size = New System.Drawing.Size(316, 21)
        Me.cbProduct.TabIndex = 11
        '
        'lblProduct1
        '
        Me.lblProduct1.AutoSize = True
        Me.lblProduct1.Location = New System.Drawing.Point(202, 100)
        Me.lblProduct1.Name = "lblProduct1"
        Me.lblProduct1.Size = New System.Drawing.Size(10, 13)
        Me.lblProduct1.TabIndex = 10
        Me.lblProduct1.Text = ":"
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(54, 103)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(44, 13)
        Me.lblProduct.TabIndex = 9
        Me.lblProduct.Text = "Product"
        '
        'cbAgent
        '
        Me.cbAgent.FormattingEnabled = True
        Me.cbAgent.Location = New System.Drawing.Point(240, 73)
        Me.cbAgent.Name = "cbAgent"
        Me.cbAgent.Size = New System.Drawing.Size(316, 21)
        Me.cbAgent.TabIndex = 8
        '
        'lblAgent1
        '
        Me.lblAgent1.AutoSize = True
        Me.lblAgent1.Location = New System.Drawing.Point(202, 76)
        Me.lblAgent1.Name = "lblAgent1"
        Me.lblAgent1.Size = New System.Drawing.Size(10, 13)
        Me.lblAgent1.TabIndex = 7
        Me.lblAgent1.Text = ":"
        '
        'lblAgent
        '
        Me.lblAgent.AutoSize = True
        Me.lblAgent.Location = New System.Drawing.Point(54, 76)
        Me.lblAgent.Name = "lblAgent"
        Me.lblAgent.Size = New System.Drawing.Size(35, 13)
        Me.lblAgent.TabIndex = 6
        Me.lblAgent.Text = "Agent"
        '
        'cbSupervisor
        '
        Me.cbSupervisor.FormattingEnabled = True
        Me.cbSupervisor.Location = New System.Drawing.Point(240, 46)
        Me.cbSupervisor.Name = "cbSupervisor"
        Me.cbSupervisor.Size = New System.Drawing.Size(316, 21)
        Me.cbSupervisor.TabIndex = 5
        '
        'lblSupervisor1
        '
        Me.lblSupervisor1.AutoSize = True
        Me.lblSupervisor1.Location = New System.Drawing.Point(202, 48)
        Me.lblSupervisor1.Name = "lblSupervisor1"
        Me.lblSupervisor1.Size = New System.Drawing.Size(10, 13)
        Me.lblSupervisor1.TabIndex = 4
        Me.lblSupervisor1.Text = ":"
        '
        'lblSupervisor
        '
        Me.lblSupervisor.AutoSize = True
        Me.lblSupervisor.Location = New System.Drawing.Point(54, 48)
        Me.lblSupervisor.Name = "lblSupervisor"
        Me.lblSupervisor.Size = New System.Drawing.Size(57, 13)
        Me.lblSupervisor.TabIndex = 3
        Me.lblSupervisor.Text = "Supervisor"
        '
        'cbManager
        '
        Me.cbManager.FormattingEnabled = True
        Me.cbManager.Items.AddRange(New Object() {"ALL"})
        Me.cbManager.Location = New System.Drawing.Point(240, 19)
        Me.cbManager.Name = "cbManager"
        Me.cbManager.Size = New System.Drawing.Size(316, 21)
        Me.cbManager.TabIndex = 2
        '
        'lblManager1
        '
        Me.lblManager1.AutoSize = True
        Me.lblManager1.Location = New System.Drawing.Point(202, 27)
        Me.lblManager1.Name = "lblManager1"
        Me.lblManager1.Size = New System.Drawing.Size(10, 13)
        Me.lblManager1.TabIndex = 1
        Me.lblManager1.Text = ":"
        '
        'lblManager
        '
        Me.lblManager.AutoSize = True
        Me.lblManager.Location = New System.Drawing.Point(54, 27)
        Me.lblManager.Name = "lblManager"
        Me.lblManager.Size = New System.Drawing.Size(49, 13)
        Me.lblManager.TabIndex = 0
        Me.lblManager.Text = "Manager"
        '
        'gbACDetails
        '
        Me.gbACDetails.Controls.Add(Me.dgvACDetails)
        Me.gbACDetails.Location = New System.Drawing.Point(3, 269)
        Me.gbACDetails.Name = "gbACDetails"
        Me.gbACDetails.Size = New System.Drawing.Size(881, 249)
        Me.gbACDetails.TabIndex = 1
        Me.gbACDetails.TabStop = False
        Me.gbACDetails.Text = "Agent Commission Details"
        '
        'dgvACDetails
        '
        Me.dgvACDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvACDetails.Location = New System.Drawing.Point(23, 19)
        Me.dgvACDetails.Name = "dgvACDetails"
        Me.dgvACDetails.Size = New System.Drawing.Size(838, 216)
        Me.dgvACDetails.TabIndex = 0
        '
        'llXport2Xcel
        '
        Me.llXport2Xcel.AutoSize = True
        Me.llXport2Xcel.Location = New System.Drawing.Point(815, 256)
        Me.llXport2Xcel.Name = "llXport2Xcel"
        Me.llXport2Xcel.Size = New System.Drawing.Size(78, 13)
        Me.llXport2Xcel.TabIndex = 2
        Me.llXport2Xcel.TabStop = True
        Me.llXport2Xcel.Text = "Export to Excel"
        '
        'vAgent_Commission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 534)
        Me.Controls.Add(Me.llXport2Xcel)
        Me.Controls.Add(Me.gbACDetails)
        Me.Controls.Add(Me.gbSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "vAgent_Commission"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agent Commission Statment"
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.fowAgentLevel.ResumeLayout(False)
        Me.fowAgentLevel.PerformLayout()
        Me.gbACDetails.ResumeLayout(False)
        CType(Me.dgvACDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents gbACDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lblManager1 As System.Windows.Forms.Label
    Friend WithEvents lblManager As System.Windows.Forms.Label
    Friend WithEvents dgvACDetails As System.Windows.Forms.DataGridView
    Friend WithEvents cbSupervisor As System.Windows.Forms.ComboBox
    Friend WithEvents lblSupervisor1 As System.Windows.Forms.Label
    Friend WithEvents lblSupervisor As System.Windows.Forms.Label
    Friend WithEvents cbManager As System.Windows.Forms.ComboBox
    Friend WithEvents cbAgent As System.Windows.Forms.ComboBox
    Friend WithEvents lblAgent1 As System.Windows.Forms.Label
    Friend WithEvents lblAgent As System.Windows.Forms.Label
    Friend WithEvents cbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents lblProduct1 As System.Windows.Forms.Label
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents lblPeriod1 As System.Windows.Forms.Label
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblPeriodTo As System.Windows.Forms.Label
    Friend WithEvents dtpPeriodTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPeriodFrm As System.Windows.Forms.DateTimePicker
    Friend WithEvents llXport2Xcel As System.Windows.Forms.LinkLabel
    Friend WithEvents lblSearchBy1 As System.Windows.Forms.Label
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents fowAgentLevel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbSubmissionofDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbEffectiveDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbReceivedMonth As System.Windows.Forms.RadioButton
    Friend WithEvents txtRMTO As System.Windows.Forms.TextBox
    Friend WithEvents txtRMFROM As System.Windows.Forms.TextBox
    Friend WithEvents rbReceivedDate As System.Windows.Forms.RadioButton
End Class
