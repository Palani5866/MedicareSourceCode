<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fXcessPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fXcessPayment))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsLetters_lblLetter = New System.Windows.Forms.ToolStripLabel
        Me.tsSuspense_cbType = New System.Windows.Forms.ToolStripComboBox
        Me.tstxtName = New System.Windows.Forms.ToolStripTextBox
        Me.tsSuspense_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.gbXcessPaymentDetails = New System.Windows.Forms.GroupBox
        Me.dgvExcessPaymentDetails = New System.Windows.Forms.DataGridView
        Me.gbExcessPaymentAction = New System.Windows.Forms.GroupBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks1 = New System.Windows.Forms.Label
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.lblID = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblChequeDate1 = New System.Windows.Forms.Label
        Me.lblChequeDate = New System.Windows.Forms.Label
        Me.dtpChequeDate = New System.Windows.Forms.DateTimePicker
        Me.txtChequeAmount = New System.Windows.Forms.TextBox
        Me.lblChequeAmount1 = New System.Windows.Forms.Label
        Me.lblChequeAmount = New System.Windows.Forms.Label
        Me.txtChequeNo = New System.Windows.Forms.TextBox
        Me.lblChequeNo1 = New System.Windows.Forms.Label
        Me.lblChequeNo = New System.Windows.Forms.Label
        Me.flpA2T = New System.Windows.Forms.FlowLayoutPanel
        Me.rbA2T2Refound = New System.Windows.Forms.RadioButton
        Me.rbA2T2Knockoff = New System.Windows.Forms.RadioButton
        Me.rbA2TClient = New System.Windows.Forms.RadioButton
        Me.lblToRefound1 = New System.Windows.Forms.Label
        Me.lblToRefound = New System.Windows.Forms.Label
        Me.gbExcessPaymentClosedDetails = New System.Windows.Forms.GroupBox
        Me.dgvClosedList = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        Me.gbXcessPaymentDetails.SuspendLayout()
        CType(Me.dgvExcessPaymentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExcessPaymentAction.SuspendLayout()
        Me.flpA2T.SuspendLayout()
        Me.gbExcessPaymentClosedDetails.SuspendLayout()
        CType(Me.dgvClosedList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLetters_lblLetter, Me.tsSuspense_cbType, Me.tstxtName, Me.tsSuspense_Go, Me.tsReport_Div1, Me.tsbtnXport2Xcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(909, 25)
        Me.tsReport.TabIndex = 11
        Me.tsReport.Text = "ToolStrip"
        '
        'tsLetters_lblLetter
        '
        Me.tsLetters_lblLetter.Name = "tsLetters_lblLetter"
        Me.tsLetters_lblLetter.Size = New System.Drawing.Size(55, 22)
        Me.tsLetters_lblLetter.Text = "Search by"
        '
        'tsSuspense_cbType
        '
        Me.tsSuspense_cbType.Items.AddRange(New Object() {"", "IC", "FULL NAME"})
        Me.tsSuspense_cbType.MaxLength = 10
        Me.tsSuspense_cbType.Name = "tsSuspense_cbType"
        Me.tsSuspense_cbType.Size = New System.Drawing.Size(100, 25)
        '
        'tstxtName
        '
        Me.tstxtName.Name = "tstxtName"
        Me.tstxtName.Size = New System.Drawing.Size(200, 25)
        '
        'tsSuspense_Go
        '
        Me.tsSuspense_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSuspense_Go.Image = CType(resources.GetObject("tsSuspense_Go.Image"), System.Drawing.Image)
        Me.tsSuspense_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSuspense_Go.Name = "tsSuspense_Go"
        Me.tsSuspense_Go.Size = New System.Drawing.Size(24, 22)
        Me.tsSuspense_Go.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnXport2Xcel
        '
        Me.tsbtnXport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnXport2Xcel.Image = CType(resources.GetObject("tsbtnXport2Xcel.Image"), System.Drawing.Image)
        Me.tsbtnXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnXport2Xcel.Name = "tsbtnXport2Xcel"
        Me.tsbtnXport2Xcel.Size = New System.Drawing.Size(84, 22)
        Me.tsbtnXport2Xcel.Text = "Export to Excel"
        '
        'gbXcessPaymentDetails
        '
        Me.gbXcessPaymentDetails.Controls.Add(Me.dgvExcessPaymentDetails)
        Me.gbXcessPaymentDetails.Location = New System.Drawing.Point(0, 28)
        Me.gbXcessPaymentDetails.Name = "gbXcessPaymentDetails"
        Me.gbXcessPaymentDetails.Size = New System.Drawing.Size(909, 152)
        Me.gbXcessPaymentDetails.TabIndex = 12
        Me.gbXcessPaymentDetails.TabStop = False
        Me.gbXcessPaymentDetails.Text = "Excess Payment Details"
        '
        'dgvExcessPaymentDetails
        '
        Me.dgvExcessPaymentDetails.AllowUserToAddRows = False
        Me.dgvExcessPaymentDetails.AllowUserToDeleteRows = False
        Me.dgvExcessPaymentDetails.AllowUserToOrderColumns = True
        Me.dgvExcessPaymentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExcessPaymentDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExcessPaymentDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvExcessPaymentDetails.Name = "dgvExcessPaymentDetails"
        Me.dgvExcessPaymentDetails.Size = New System.Drawing.Size(903, 133)
        Me.dgvExcessPaymentDetails.TabIndex = 0
        '
        'gbExcessPaymentAction
        '
        Me.gbExcessPaymentAction.Controls.Add(Me.txtRemarks)
        Me.gbExcessPaymentAction.Controls.Add(Me.lblRemarks1)
        Me.gbExcessPaymentAction.Controls.Add(Me.lblRemarks)
        Me.gbExcessPaymentAction.Controls.Add(Me.lblID)
        Me.gbExcessPaymentAction.Controls.Add(Me.btnCancel)
        Me.gbExcessPaymentAction.Controls.Add(Me.btnSubmit)
        Me.gbExcessPaymentAction.Controls.Add(Me.lblChequeDate1)
        Me.gbExcessPaymentAction.Controls.Add(Me.lblChequeDate)
        Me.gbExcessPaymentAction.Controls.Add(Me.dtpChequeDate)
        Me.gbExcessPaymentAction.Controls.Add(Me.txtChequeAmount)
        Me.gbExcessPaymentAction.Controls.Add(Me.lblChequeAmount1)
        Me.gbExcessPaymentAction.Controls.Add(Me.lblChequeAmount)
        Me.gbExcessPaymentAction.Controls.Add(Me.txtChequeNo)
        Me.gbExcessPaymentAction.Controls.Add(Me.lblChequeNo1)
        Me.gbExcessPaymentAction.Controls.Add(Me.lblChequeNo)
        Me.gbExcessPaymentAction.Controls.Add(Me.flpA2T)
        Me.gbExcessPaymentAction.Controls.Add(Me.lblToRefound1)
        Me.gbExcessPaymentAction.Controls.Add(Me.lblToRefound)
        Me.gbExcessPaymentAction.Location = New System.Drawing.Point(3, 186)
        Me.gbExcessPaymentAction.Name = "gbExcessPaymentAction"
        Me.gbExcessPaymentAction.Size = New System.Drawing.Size(906, 243)
        Me.gbExcessPaymentAction.TabIndex = 13
        Me.gbExcessPaymentAction.TabStop = False
        Me.gbExcessPaymentAction.Text = "Action to take"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(296, 134)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtRemarks.Size = New System.Drawing.Size(323, 51)
        Me.txtRemarks.TabIndex = 46
        '
        'lblRemarks1
        '
        Me.lblRemarks1.AutoSize = True
        Me.lblRemarks1.Location = New System.Drawing.Point(263, 134)
        Me.lblRemarks1.Name = "lblRemarks1"
        Me.lblRemarks1.Size = New System.Drawing.Size(10, 13)
        Me.lblRemarks1.TabIndex = 45
        Me.lblRemarks1.Text = ":"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(152, 134)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(49, 13)
        Me.lblRemarks.TabIndex = 44
        Me.lblRemarks.Text = "Remarks"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(537, 196)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 43
        Me.lblID.Text = "ID"
        Me.lblID.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(420, 199)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 42
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(317, 199)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 41
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblChequeDate1
        '
        Me.lblChequeDate1.AutoSize = True
        Me.lblChequeDate1.Location = New System.Drawing.Point(263, 83)
        Me.lblChequeDate1.Name = "lblChequeDate1"
        Me.lblChequeDate1.Size = New System.Drawing.Size(10, 13)
        Me.lblChequeDate1.TabIndex = 40
        Me.lblChequeDate1.Text = ":"
        '
        'lblChequeDate
        '
        Me.lblChequeDate.AutoSize = True
        Me.lblChequeDate.Location = New System.Drawing.Point(152, 83)
        Me.lblChequeDate.Name = "lblChequeDate"
        Me.lblChequeDate.Size = New System.Drawing.Size(83, 13)
        Me.lblChequeDate.TabIndex = 39
        Me.lblChequeDate.Text = "Reference Date"
        '
        'dtpChequeDate
        '
        Me.dtpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpChequeDate.Location = New System.Drawing.Point(296, 81)
        Me.dtpChequeDate.Name = "dtpChequeDate"
        Me.dtpChequeDate.Size = New System.Drawing.Size(120, 20)
        Me.dtpChequeDate.TabIndex = 38
        '
        'txtChequeAmount
        '
        Me.txtChequeAmount.Location = New System.Drawing.Point(296, 108)
        Me.txtChequeAmount.Name = "txtChequeAmount"
        Me.txtChequeAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtChequeAmount.Size = New System.Drawing.Size(120, 20)
        Me.txtChequeAmount.TabIndex = 37
        '
        'lblChequeAmount1
        '
        Me.lblChequeAmount1.AutoSize = True
        Me.lblChequeAmount1.Location = New System.Drawing.Point(263, 108)
        Me.lblChequeAmount1.Name = "lblChequeAmount1"
        Me.lblChequeAmount1.Size = New System.Drawing.Size(10, 13)
        Me.lblChequeAmount1.TabIndex = 36
        Me.lblChequeAmount1.Text = ":"
        '
        'lblChequeAmount
        '
        Me.lblChequeAmount.AutoSize = True
        Me.lblChequeAmount.Location = New System.Drawing.Point(152, 108)
        Me.lblChequeAmount.Name = "lblChequeAmount"
        Me.lblChequeAmount.Size = New System.Drawing.Size(43, 13)
        Me.lblChequeAmount.TabIndex = 35
        Me.lblChequeAmount.Text = "Amount"
        '
        'txtChequeNo
        '
        Me.txtChequeNo.Location = New System.Drawing.Point(296, 55)
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(120, 20)
        Me.txtChequeNo.TabIndex = 34
        '
        'lblChequeNo1
        '
        Me.lblChequeNo1.AutoSize = True
        Me.lblChequeNo1.Location = New System.Drawing.Point(263, 55)
        Me.lblChequeNo1.Name = "lblChequeNo1"
        Me.lblChequeNo1.Size = New System.Drawing.Size(10, 13)
        Me.lblChequeNo1.TabIndex = 33
        Me.lblChequeNo1.Text = ":"
        '
        'lblChequeNo
        '
        Me.lblChequeNo.AutoSize = True
        Me.lblChequeNo.Location = New System.Drawing.Point(152, 55)
        Me.lblChequeNo.Name = "lblChequeNo"
        Me.lblChequeNo.Size = New System.Drawing.Size(67, 13)
        Me.lblChequeNo.TabIndex = 32
        Me.lblChequeNo.Text = "Reference #"
        '
        'flpA2T
        '
        Me.flpA2T.Controls.Add(Me.rbA2T2Refound)
        Me.flpA2T.Controls.Add(Me.rbA2T2Knockoff)
        Me.flpA2T.Controls.Add(Me.rbA2TClient)
        Me.flpA2T.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpA2T.Location = New System.Drawing.Point(296, 19)
        Me.flpA2T.Name = "flpA2T"
        Me.flpA2T.Size = New System.Drawing.Size(323, 29)
        Me.flpA2T.TabIndex = 31
        '
        'rbA2T2Refound
        '
        Me.rbA2T2Refound.AutoSize = True
        Me.rbA2T2Refound.Checked = True
        Me.rbA2T2Refound.Location = New System.Drawing.Point(3, 3)
        Me.rbA2T2Refound.Name = "rbA2T2Refound"
        Me.rbA2T2Refound.Size = New System.Drawing.Size(76, 17)
        Me.rbA2T2Refound.TabIndex = 0
        Me.rbA2T2Refound.TabStop = True
        Me.rbA2T2Refound.Text = "To Refund"
        Me.rbA2T2Refound.UseVisualStyleBackColor = True
        '
        'rbA2T2Knockoff
        '
        Me.rbA2T2Knockoff.AutoSize = True
        Me.rbA2T2Knockoff.Location = New System.Drawing.Point(85, 3)
        Me.rbA2T2Knockoff.Name = "rbA2T2Knockoff"
        Me.rbA2T2Knockoff.Size = New System.Drawing.Size(73, 17)
        Me.rbA2T2Knockoff.TabIndex = 1
        Me.rbA2T2Knockoff.Text = "Knock Off"
        Me.rbA2T2Knockoff.UseVisualStyleBackColor = True
        '
        'rbA2TClient
        '
        Me.rbA2TClient.AutoSize = True
        Me.rbA2TClient.Location = New System.Drawing.Point(164, 3)
        Me.rbA2TClient.Name = "rbA2TClient"
        Me.rbA2TClient.Size = New System.Drawing.Size(146, 17)
        Me.rbA2TClient.TabIndex = 2
        Me.rbA2TClient.Text = "Client Can't Be Contacted"
        Me.rbA2TClient.UseVisualStyleBackColor = True
        '
        'lblToRefound1
        '
        Me.lblToRefound1.AutoSize = True
        Me.lblToRefound1.Location = New System.Drawing.Point(263, 26)
        Me.lblToRefound1.Name = "lblToRefound1"
        Me.lblToRefound1.Size = New System.Drawing.Size(10, 13)
        Me.lblToRefound1.TabIndex = 1
        Me.lblToRefound1.Text = ":"
        '
        'lblToRefound
        '
        Me.lblToRefound.AutoSize = True
        Me.lblToRefound.Location = New System.Drawing.Point(152, 26)
        Me.lblToRefound.Name = "lblToRefound"
        Me.lblToRefound.Size = New System.Drawing.Size(77, 13)
        Me.lblToRefound.TabIndex = 0
        Me.lblToRefound.Text = "Action to Take"
        '
        'gbExcessPaymentClosedDetails
        '
        Me.gbExcessPaymentClosedDetails.Controls.Add(Me.dgvClosedList)
        Me.gbExcessPaymentClosedDetails.Location = New System.Drawing.Point(3, 435)
        Me.gbExcessPaymentClosedDetails.Name = "gbExcessPaymentClosedDetails"
        Me.gbExcessPaymentClosedDetails.Size = New System.Drawing.Size(903, 191)
        Me.gbExcessPaymentClosedDetails.TabIndex = 14
        Me.gbExcessPaymentClosedDetails.TabStop = False
        Me.gbExcessPaymentClosedDetails.Text = "Excess Payment Close Details"
        '
        'dgvClosedList
        '
        Me.dgvClosedList.AllowUserToAddRows = False
        Me.dgvClosedList.AllowUserToDeleteRows = False
        Me.dgvClosedList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClosedList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClosedList.Location = New System.Drawing.Point(3, 16)
        Me.dgvClosedList.Name = "dgvClosedList"
        Me.dgvClosedList.ReadOnly = True
        Me.dgvClosedList.Size = New System.Drawing.Size(897, 172)
        Me.dgvClosedList.TabIndex = 0
        '
        'fXcessPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 635)
        Me.Controls.Add(Me.gbExcessPaymentClosedDetails)
        Me.Controls.Add(Me.gbExcessPaymentAction)
        Me.Controls.Add(Me.gbXcessPaymentDetails)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fXcessPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Excess Payment Details"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.gbXcessPaymentDetails.ResumeLayout(False)
        CType(Me.dgvExcessPaymentDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExcessPaymentAction.ResumeLayout(False)
        Me.gbExcessPaymentAction.PerformLayout()
        Me.flpA2T.ResumeLayout(False)
        Me.flpA2T.PerformLayout()
        Me.gbExcessPaymentClosedDetails.ResumeLayout(False)
        CType(Me.dgvClosedList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsLetters_lblLetter As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsSuspense_cbType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tstxtName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsSuspense_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnXport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbXcessPaymentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvExcessPaymentDetails As System.Windows.Forms.DataGridView
    Friend WithEvents gbExcessPaymentAction As System.Windows.Forms.GroupBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblChequeDate1 As System.Windows.Forms.Label
    Friend WithEvents lblChequeDate As System.Windows.Forms.Label
    Friend WithEvents dtpChequeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtChequeAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblChequeAmount1 As System.Windows.Forms.Label
    Friend WithEvents lblChequeAmount As System.Windows.Forms.Label
    Friend WithEvents txtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents lblChequeNo1 As System.Windows.Forms.Label
    Friend WithEvents lblChequeNo As System.Windows.Forms.Label
    Friend WithEvents flpA2T As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbA2T2Refound As System.Windows.Forms.RadioButton
    Friend WithEvents rbA2T2Knockoff As System.Windows.Forms.RadioButton
    Friend WithEvents rbA2TClient As System.Windows.Forms.RadioButton
    Friend WithEvents lblToRefound1 As System.Windows.Forms.Label
    Friend WithEvents lblToRefound As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks1 As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents gbExcessPaymentClosedDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvClosedList As System.Windows.Forms.DataGridView
End Class
