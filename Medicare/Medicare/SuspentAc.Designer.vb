<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuspentAc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SuspentAc))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsLetters_lblLetter = New System.Windows.Forms.ToolStripLabel
        Me.tsSuspense_cbType = New System.Windows.Forms.ToolStripComboBox
        Me.tstxtName = New System.Windows.Forms.ToolStripTextBox
        Me.tsSuspense_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.gbSuspentDetails = New System.Windows.Forms.GroupBox
        Me.dgvSuspenseDetails = New System.Windows.Forms.DataGridView
        Me.gbSuspentAmounts = New System.Windows.Forms.GroupBox
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
        Me.tsReport.SuspendLayout()
        Me.gbSuspentDetails.SuspendLayout()
        CType(Me.dgvSuspenseDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSuspentAmounts.SuspendLayout()
        Me.flpA2T.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLetters_lblLetter, Me.tsSuspense_cbType, Me.tstxtName, Me.tsSuspense_Go, Me.tsReport_Div1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(679, 25)
        Me.tsReport.TabIndex = 9
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
        'gbSuspentDetails
        '
        Me.gbSuspentDetails.Controls.Add(Me.dgvSuspenseDetails)
        Me.gbSuspentDetails.Location = New System.Drawing.Point(12, 28)
        Me.gbSuspentDetails.Name = "gbSuspentDetails"
        Me.gbSuspentDetails.Size = New System.Drawing.Size(655, 152)
        Me.gbSuspentDetails.TabIndex = 10
        Me.gbSuspentDetails.TabStop = False
        Me.gbSuspentDetails.Text = "Suspense Amount Details"
        '
        'dgvSuspenseDetails
        '
        Me.dgvSuspenseDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSuspenseDetails.Location = New System.Drawing.Point(6, 19)
        Me.dgvSuspenseDetails.Name = "dgvSuspenseDetails"
        Me.dgvSuspenseDetails.Size = New System.Drawing.Size(632, 120)
        Me.dgvSuspenseDetails.TabIndex = 0
        '
        'gbSuspentAmounts
        '
        Me.gbSuspentAmounts.Controls.Add(Me.lblID)
        Me.gbSuspentAmounts.Controls.Add(Me.btnCancel)
        Me.gbSuspentAmounts.Controls.Add(Me.btnSubmit)
        Me.gbSuspentAmounts.Controls.Add(Me.lblChequeDate1)
        Me.gbSuspentAmounts.Controls.Add(Me.lblChequeDate)
        Me.gbSuspentAmounts.Controls.Add(Me.dtpChequeDate)
        Me.gbSuspentAmounts.Controls.Add(Me.txtChequeAmount)
        Me.gbSuspentAmounts.Controls.Add(Me.lblChequeAmount1)
        Me.gbSuspentAmounts.Controls.Add(Me.lblChequeAmount)
        Me.gbSuspentAmounts.Controls.Add(Me.txtChequeNo)
        Me.gbSuspentAmounts.Controls.Add(Me.lblChequeNo1)
        Me.gbSuspentAmounts.Controls.Add(Me.lblChequeNo)
        Me.gbSuspentAmounts.Controls.Add(Me.flpA2T)
        Me.gbSuspentAmounts.Controls.Add(Me.lblToRefound1)
        Me.gbSuspentAmounts.Controls.Add(Me.lblToRefound)
        Me.gbSuspentAmounts.Location = New System.Drawing.Point(12, 203)
        Me.gbSuspentAmounts.Name = "gbSuspentAmounts"
        Me.gbSuspentAmounts.Size = New System.Drawing.Size(655, 190)
        Me.gbSuspentAmounts.TabIndex = 11
        Me.gbSuspentAmounts.TabStop = False
        Me.gbSuspentAmounts.Text = "Action To Take"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(537, 153)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 43
        Me.lblID.Text = "ID"
        Me.lblID.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(293, 148)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 42
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(190, 148)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 41
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblChequeDate1
        '
        Me.lblChequeDate1.AutoSize = True
        Me.lblChequeDate1.Location = New System.Drawing.Point(136, 83)
        Me.lblChequeDate1.Name = "lblChequeDate1"
        Me.lblChequeDate1.Size = New System.Drawing.Size(10, 13)
        Me.lblChequeDate1.TabIndex = 40
        Me.lblChequeDate1.Text = ":"
        '
        'lblChequeDate
        '
        Me.lblChequeDate.AutoSize = True
        Me.lblChequeDate.Location = New System.Drawing.Point(25, 83)
        Me.lblChequeDate.Name = "lblChequeDate"
        Me.lblChequeDate.Size = New System.Drawing.Size(70, 13)
        Me.lblChequeDate.TabIndex = 39
        Me.lblChequeDate.Text = "Cheque Date"
        '
        'dtpChequeDate
        '
        Me.dtpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpChequeDate.Location = New System.Drawing.Point(169, 81)
        Me.dtpChequeDate.Name = "dtpChequeDate"
        Me.dtpChequeDate.Size = New System.Drawing.Size(120, 20)
        Me.dtpChequeDate.TabIndex = 38
        '
        'txtChequeAmount
        '
        Me.txtChequeAmount.Location = New System.Drawing.Point(169, 108)
        Me.txtChequeAmount.Name = "txtChequeAmount"
        Me.txtChequeAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtChequeAmount.Size = New System.Drawing.Size(120, 20)
        Me.txtChequeAmount.TabIndex = 37
        '
        'lblChequeAmount1
        '
        Me.lblChequeAmount1.AutoSize = True
        Me.lblChequeAmount1.Location = New System.Drawing.Point(136, 108)
        Me.lblChequeAmount1.Name = "lblChequeAmount1"
        Me.lblChequeAmount1.Size = New System.Drawing.Size(10, 13)
        Me.lblChequeAmount1.TabIndex = 36
        Me.lblChequeAmount1.Text = ":"
        '
        'lblChequeAmount
        '
        Me.lblChequeAmount.AutoSize = True
        Me.lblChequeAmount.Location = New System.Drawing.Point(25, 108)
        Me.lblChequeAmount.Name = "lblChequeAmount"
        Me.lblChequeAmount.Size = New System.Drawing.Size(83, 13)
        Me.lblChequeAmount.TabIndex = 35
        Me.lblChequeAmount.Text = "Cheque Amount"
        '
        'txtChequeNo
        '
        Me.txtChequeNo.Location = New System.Drawing.Point(169, 55)
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(120, 20)
        Me.txtChequeNo.TabIndex = 34
        '
        'lblChequeNo1
        '
        Me.lblChequeNo1.AutoSize = True
        Me.lblChequeNo1.Location = New System.Drawing.Point(136, 55)
        Me.lblChequeNo1.Name = "lblChequeNo1"
        Me.lblChequeNo1.Size = New System.Drawing.Size(10, 13)
        Me.lblChequeNo1.TabIndex = 33
        Me.lblChequeNo1.Text = ":"
        '
        'lblChequeNo
        '
        Me.lblChequeNo.AutoSize = True
        Me.lblChequeNo.Location = New System.Drawing.Point(25, 55)
        Me.lblChequeNo.Name = "lblChequeNo"
        Me.lblChequeNo.Size = New System.Drawing.Size(61, 13)
        Me.lblChequeNo.TabIndex = 32
        Me.lblChequeNo.Text = "Cheque No"
        '
        'flpA2T
        '
        Me.flpA2T.Controls.Add(Me.rbA2T2Refound)
        Me.flpA2T.Controls.Add(Me.rbA2T2Knockoff)
        Me.flpA2T.Controls.Add(Me.rbA2TClient)
        Me.flpA2T.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpA2T.Location = New System.Drawing.Point(169, 19)
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
        Me.lblToRefound1.Location = New System.Drawing.Point(136, 26)
        Me.lblToRefound1.Name = "lblToRefound1"
        Me.lblToRefound1.Size = New System.Drawing.Size(10, 13)
        Me.lblToRefound1.TabIndex = 1
        Me.lblToRefound1.Text = ":"
        '
        'lblToRefound
        '
        Me.lblToRefound.AutoSize = True
        Me.lblToRefound.Location = New System.Drawing.Point(25, 26)
        Me.lblToRefound.Name = "lblToRefound"
        Me.lblToRefound.Size = New System.Drawing.Size(77, 13)
        Me.lblToRefound.TabIndex = 0
        Me.lblToRefound.Text = "Action to Take"
        '
        'SuspentAc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 414)
        Me.Controls.Add(Me.gbSuspentAmounts)
        Me.Controls.Add(Me.gbSuspentDetails)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "SuspentAc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Suspense Account"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.gbSuspentDetails.ResumeLayout(False)
        CType(Me.dgvSuspenseDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSuspentAmounts.ResumeLayout(False)
        Me.gbSuspentAmounts.PerformLayout()
        Me.flpA2T.ResumeLayout(False)
        Me.flpA2T.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsLetters_lblLetter As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsSuspense_cbType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tstxtName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsSuspense_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbSuspentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSuspenseDetails As System.Windows.Forms.DataGridView
    Friend WithEvents gbSuspentAmounts As System.Windows.Forms.GroupBox
    Friend WithEvents lblToRefound As System.Windows.Forms.Label
    Friend WithEvents flpA2T As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbA2T2Refound As System.Windows.Forms.RadioButton
    Friend WithEvents rbA2T2Knockoff As System.Windows.Forms.RadioButton
    Friend WithEvents rbA2TClient As System.Windows.Forms.RadioButton
    Friend WithEvents lblChequeNo As System.Windows.Forms.Label
    Friend WithEvents lblChequeNo1 As System.Windows.Forms.Label
    Friend WithEvents lblToRefound1 As System.Windows.Forms.Label
    Friend WithEvents txtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents txtChequeAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblChequeAmount1 As System.Windows.Forms.Label
    Friend WithEvents lblChequeAmount As System.Windows.Forms.Label
    Friend WithEvents lblChequeDate1 As System.Windows.Forms.Label
    Friend WithEvents lblChequeDate As System.Windows.Forms.Label
    Friend WithEvents dtpChequeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblID As System.Windows.Forms.Label
End Class
