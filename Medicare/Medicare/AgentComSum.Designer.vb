<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgentComSum
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
        Me.dgvACDetails = New System.Windows.Forms.DataGridView
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
        Me.llXport2Xcel = New System.Windows.Forms.LinkLabel
        Me.gbACDetails.SuspendLayout()
        CType(Me.dgvACDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSearch.SuspendLayout()
        Me.fowAgentLevel.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbACDetails
        '
        Me.gbACDetails.Controls.Add(Me.dgvACDetails)
        Me.gbACDetails.Location = New System.Drawing.Point(12, 172)
        Me.gbACDetails.Name = "gbACDetails"
        Me.gbACDetails.Size = New System.Drawing.Size(877, 325)
        Me.gbACDetails.TabIndex = 5
        Me.gbACDetails.TabStop = False
        Me.gbACDetails.Text = "Agents Summary Details"
        '
        'dgvACDetails
        '
        Me.dgvACDetails.AllowUserToAddRows = False
        Me.dgvACDetails.AllowUserToDeleteRows = False
        Me.dgvACDetails.AllowUserToOrderColumns = True
        Me.dgvACDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvACDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvACDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvACDetails.Name = "dgvACDetails"
        Me.dgvACDetails.Size = New System.Drawing.Size(871, 306)
        Me.dgvACDetails.TabIndex = 0
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
        Me.gbSearch.Location = New System.Drawing.Point(147, 23)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(614, 134)
        Me.gbSearch.TabIndex = 4
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
        Me.cbProduct.Items.AddRange(New Object() {"CUEPACSCARE", "CUEPACS PA"})
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
        'llXport2Xcel
        '
        Me.llXport2Xcel.AutoSize = True
        Me.llXport2Xcel.Location = New System.Drawing.Point(808, 156)
        Me.llXport2Xcel.Name = "llXport2Xcel"
        Me.llXport2Xcel.Size = New System.Drawing.Size(78, 13)
        Me.llXport2Xcel.TabIndex = 6
        Me.llXport2Xcel.TabStop = True
        Me.llXport2Xcel.Text = "Export to Excel"
        '
        'AgentComSum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 509)
        Me.Controls.Add(Me.llXport2Xcel)
        Me.Controls.Add(Me.gbACDetails)
        Me.Controls.Add(Me.gbSearch)
        Me.Name = "AgentComSum"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agent Commission Summary"
        Me.gbACDetails.ResumeLayout(False)
        CType(Me.dgvACDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.fowAgentLevel.ResumeLayout(False)
        Me.fowAgentLevel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents llXport2Xcel As System.Windows.Forms.LinkLabel
End Class
