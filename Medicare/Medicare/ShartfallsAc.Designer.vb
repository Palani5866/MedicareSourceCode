<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShartfallsAc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShartfallsAc))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsLetters_lblLetter = New System.Windows.Forms.ToolStripLabel
        Me.tsSuspense_cbType = New System.Windows.Forms.ToolStripComboBox
        Me.tstxtName = New System.Windows.Forms.ToolStripTextBox
        Me.tsSuspense_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.gbShortfallsAmounts = New System.Windows.Forms.GroupBox
        Me.lblDM = New System.Windows.Forms.Label
        Me.lblNOKPL = New System.Windows.Forms.Label
        Me.lblNoK = New System.Windows.Forms.Label
        Me.lblIC = New System.Windows.Forms.Label
        Me.txtRef = New System.Windows.Forms.TextBox
        Me.lblRef1 = New System.Windows.Forms.Label
        Me.lblRef = New System.Windows.Forms.Label
        Me.txtMethodofPay = New System.Windows.Forms.TextBox
        Me.lblMethodOfPayment1 = New System.Windows.Forms.Label
        Me.lblMethodOfPayment = New System.Windows.Forms.Label
        Me.txtDeductionMonthTo = New System.Windows.Forms.TextBox
        Me.lblDP12 = New System.Windows.Forms.Label
        Me.lblDP1 = New System.Windows.Forms.Label
        Me.lblID = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.lblChequeAmount1 = New System.Windows.Forms.Label
        Me.lblAmount = New System.Windows.Forms.Label
        Me.txtDeductionMonthFrm = New System.Windows.Forms.TextBox
        Me.lblChequeNo1 = New System.Windows.Forms.Label
        Me.lblDeductionPeriod = New System.Windows.Forms.Label
        Me.flpA2T = New System.Windows.Forms.FlowLayoutPanel
        Me.rbRequest2DA = New System.Windows.Forms.RadioButton
        Me.rbClientPaidDirect = New System.Windows.Forms.RadioButton
        Me.lblToRefound1 = New System.Windows.Forms.Label
        Me.lblToRefound = New System.Windows.Forms.Label
        Me.gbShortfallsDetails = New System.Windows.Forms.GroupBox
        Me.dgvShortfallsDetails = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        Me.gbShortfallsAmounts.SuspendLayout()
        Me.flpA2T.SuspendLayout()
        Me.gbShortfallsDetails.SuspendLayout()
        CType(Me.dgvShortfallsDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLetters_lblLetter, Me.tsSuspense_cbType, Me.tstxtName, Me.tsSuspense_Go, Me.tsReport_Div1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(682, 25)
        Me.tsReport.TabIndex = 10
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
        'gbShortfallsAmounts
        '
        Me.gbShortfallsAmounts.Controls.Add(Me.lblDM)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblNOKPL)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblNoK)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblIC)
        Me.gbShortfallsAmounts.Controls.Add(Me.txtRef)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblRef1)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblRef)
        Me.gbShortfallsAmounts.Controls.Add(Me.txtMethodofPay)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblMethodOfPayment1)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblMethodOfPayment)
        Me.gbShortfallsAmounts.Controls.Add(Me.txtDeductionMonthTo)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblDP12)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblDP1)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblID)
        Me.gbShortfallsAmounts.Controls.Add(Me.btnCancel)
        Me.gbShortfallsAmounts.Controls.Add(Me.btnSubmit)
        Me.gbShortfallsAmounts.Controls.Add(Me.txtAmount)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblChequeAmount1)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblAmount)
        Me.gbShortfallsAmounts.Controls.Add(Me.txtDeductionMonthFrm)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblChequeNo1)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblDeductionPeriod)
        Me.gbShortfallsAmounts.Controls.Add(Me.flpA2T)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblToRefound1)
        Me.gbShortfallsAmounts.Controls.Add(Me.lblToRefound)
        Me.gbShortfallsAmounts.Location = New System.Drawing.Point(10, 203)
        Me.gbShortfallsAmounts.Name = "gbShortfallsAmounts"
        Me.gbShortfallsAmounts.Size = New System.Drawing.Size(655, 216)
        Me.gbShortfallsAmounts.TabIndex = 13
        Me.gbShortfallsAmounts.TabStop = False
        Me.gbShortfallsAmounts.Text = "Action To Take"
        '
        'lblDM
        '
        Me.lblDM.AutoSize = True
        Me.lblDM.Location = New System.Drawing.Point(520, 177)
        Me.lblDM.Name = "lblDM"
        Me.lblDM.Size = New System.Drawing.Size(24, 13)
        Me.lblDM.TabIndex = 56
        Me.lblDM.Text = "DM"
        Me.lblDM.Visible = False
        '
        'lblNOKPL
        '
        Me.lblNOKPL.AutoSize = True
        Me.lblNOKPL.Location = New System.Drawing.Point(471, 177)
        Me.lblNOKPL.Name = "lblNOKPL"
        Me.lblNOKPL.Size = New System.Drawing.Size(35, 13)
        Me.lblNOKPL.TabIndex = 55
        Me.lblNOKPL.Text = "NKPL"
        Me.lblNOKPL.Visible = False
        '
        'lblNoK
        '
        Me.lblNoK.AutoSize = True
        Me.lblNoK.Location = New System.Drawing.Point(435, 177)
        Me.lblNoK.Name = "lblNoK"
        Me.lblNoK.Size = New System.Drawing.Size(22, 13)
        Me.lblNoK.TabIndex = 54
        Me.lblNoK.Text = "NK"
        Me.lblNoK.Visible = False
        '
        'lblIC
        '
        Me.lblIC.AutoSize = True
        Me.lblIC.Location = New System.Drawing.Point(398, 177)
        Me.lblIC.Name = "lblIC"
        Me.lblIC.Size = New System.Drawing.Size(17, 13)
        Me.lblIC.TabIndex = 53
        Me.lblIC.Text = "IC"
        Me.lblIC.Visible = False
        '
        'txtRef
        '
        Me.txtRef.Location = New System.Drawing.Point(198, 138)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtRef.Size = New System.Drawing.Size(323, 20)
        Me.txtRef.TabIndex = 52
        '
        'lblRef1
        '
        Me.lblRef1.AutoSize = True
        Me.lblRef1.Location = New System.Drawing.Point(165, 138)
        Me.lblRef1.Name = "lblRef1"
        Me.lblRef1.Size = New System.Drawing.Size(10, 13)
        Me.lblRef1.TabIndex = 51
        Me.lblRef1.Text = ":"
        '
        'lblRef
        '
        Me.lblRef.AutoSize = True
        Me.lblRef.Location = New System.Drawing.Point(25, 138)
        Me.lblRef.Name = "lblRef"
        Me.lblRef.Size = New System.Drawing.Size(60, 13)
        Me.lblRef.TabIndex = 50
        Me.lblRef.Text = "Reference "
        '
        'txtMethodofPay
        '
        Me.txtMethodofPay.Location = New System.Drawing.Point(198, 112)
        Me.txtMethodofPay.Name = "txtMethodofPay"
        Me.txtMethodofPay.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMethodofPay.Size = New System.Drawing.Size(323, 20)
        Me.txtMethodofPay.TabIndex = 49
        '
        'lblMethodOfPayment1
        '
        Me.lblMethodOfPayment1.AutoSize = True
        Me.lblMethodOfPayment1.Location = New System.Drawing.Point(165, 112)
        Me.lblMethodOfPayment1.Name = "lblMethodOfPayment1"
        Me.lblMethodOfPayment1.Size = New System.Drawing.Size(10, 13)
        Me.lblMethodOfPayment1.TabIndex = 48
        Me.lblMethodOfPayment1.Text = ":"
        '
        'lblMethodOfPayment
        '
        Me.lblMethodOfPayment.AutoSize = True
        Me.lblMethodOfPayment.Location = New System.Drawing.Point(25, 112)
        Me.lblMethodOfPayment.Name = "lblMethodOfPayment"
        Me.lblMethodOfPayment.Size = New System.Drawing.Size(101, 13)
        Me.lblMethodOfPayment.TabIndex = 47
        Me.lblMethodOfPayment.Text = "Method Of Payment"
        '
        'txtDeductionMonthTo
        '
        Me.txtDeductionMonthTo.Location = New System.Drawing.Point(401, 55)
        Me.txtDeductionMonthTo.Name = "txtDeductionMonthTo"
        Me.txtDeductionMonthTo.Size = New System.Drawing.Size(120, 20)
        Me.txtDeductionMonthTo.TabIndex = 46
        '
        'lblDP12
        '
        Me.lblDP12.AutoSize = True
        Me.lblDP12.Location = New System.Drawing.Point(368, 58)
        Me.lblDP12.Name = "lblDP12"
        Me.lblDP12.Size = New System.Drawing.Size(10, 13)
        Me.lblDP12.TabIndex = 45
        Me.lblDP12.Text = ":"
        '
        'lblDP1
        '
        Me.lblDP1.AutoSize = True
        Me.lblDP1.Location = New System.Drawing.Point(330, 58)
        Me.lblDP1.Name = "lblDP1"
        Me.lblDP1.Size = New System.Drawing.Size(20, 13)
        Me.lblDP1.TabIndex = 44
        Me.lblDP1.Text = "To"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(537, 152)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 43
        Me.lblID.Text = "ID"
        Me.lblID.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(290, 172)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 42
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(187, 172)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 41
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(198, 86)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAmount.Size = New System.Drawing.Size(120, 20)
        Me.txtAmount.TabIndex = 37
        '
        'lblChequeAmount1
        '
        Me.lblChequeAmount1.AutoSize = True
        Me.lblChequeAmount1.Location = New System.Drawing.Point(165, 86)
        Me.lblChequeAmount1.Name = "lblChequeAmount1"
        Me.lblChequeAmount1.Size = New System.Drawing.Size(10, 13)
        Me.lblChequeAmount1.TabIndex = 36
        Me.lblChequeAmount1.Text = ":"
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Location = New System.Drawing.Point(25, 86)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(43, 13)
        Me.lblAmount.TabIndex = 35
        Me.lblAmount.Text = "Amount"
        '
        'txtDeductionMonthFrm
        '
        Me.txtDeductionMonthFrm.Location = New System.Drawing.Point(198, 55)
        Me.txtDeductionMonthFrm.Name = "txtDeductionMonthFrm"
        Me.txtDeductionMonthFrm.Size = New System.Drawing.Size(120, 20)
        Me.txtDeductionMonthFrm.TabIndex = 34
        '
        'lblChequeNo1
        '
        Me.lblChequeNo1.AutoSize = True
        Me.lblChequeNo1.Location = New System.Drawing.Point(165, 55)
        Me.lblChequeNo1.Name = "lblChequeNo1"
        Me.lblChequeNo1.Size = New System.Drawing.Size(10, 13)
        Me.lblChequeNo1.TabIndex = 33
        Me.lblChequeNo1.Text = ":"
        '
        'lblDeductionPeriod
        '
        Me.lblDeductionPeriod.AutoSize = True
        Me.lblDeductionPeriod.Location = New System.Drawing.Point(25, 55)
        Me.lblDeductionPeriod.Name = "lblDeductionPeriod"
        Me.lblDeductionPeriod.Size = New System.Drawing.Size(121, 13)
        Me.lblDeductionPeriod.TabIndex = 32
        Me.lblDeductionPeriod.Text = "Deduction Period (From)"
        '
        'flpA2T
        '
        Me.flpA2T.Controls.Add(Me.rbRequest2DA)
        Me.flpA2T.Controls.Add(Me.rbClientPaidDirect)
        Me.flpA2T.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpA2T.Location = New System.Drawing.Point(198, 19)
        Me.flpA2T.Name = "flpA2T"
        Me.flpA2T.Size = New System.Drawing.Size(323, 29)
        Me.flpA2T.TabIndex = 31
        '
        'rbRequest2DA
        '
        Me.rbRequest2DA.AutoSize = True
        Me.rbRequest2DA.Checked = True
        Me.rbRequest2DA.Location = New System.Drawing.Point(3, 3)
        Me.rbRequest2DA.Name = "rbRequest2DA"
        Me.rbRequest2DA.Size = New System.Drawing.Size(180, 17)
        Me.rbRequest2DA.TabIndex = 0
        Me.rbRequest2DA.TabStop = True
        Me.rbRequest2DA.Text = "Requested to Deduction Agency"
        Me.rbRequest2DA.UseVisualStyleBackColor = True
        '
        'rbClientPaidDirect
        '
        Me.rbClientPaidDirect.AutoSize = True
        Me.rbClientPaidDirect.Location = New System.Drawing.Point(189, 3)
        Me.rbClientPaidDirect.Name = "rbClientPaidDirect"
        Me.rbClientPaidDirect.Size = New System.Drawing.Size(106, 17)
        Me.rbClientPaidDirect.TabIndex = 1
        Me.rbClientPaidDirect.Text = "Client Paid Direct"
        Me.rbClientPaidDirect.UseVisualStyleBackColor = True
        '
        'lblToRefound1
        '
        Me.lblToRefound1.AutoSize = True
        Me.lblToRefound1.Location = New System.Drawing.Point(165, 26)
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
        'gbShortfallsDetails
        '
        Me.gbShortfallsDetails.Controls.Add(Me.dgvShortfallsDetails)
        Me.gbShortfallsDetails.Location = New System.Drawing.Point(10, 28)
        Me.gbShortfallsDetails.Name = "gbShortfallsDetails"
        Me.gbShortfallsDetails.Size = New System.Drawing.Size(655, 169)
        Me.gbShortfallsDetails.TabIndex = 12
        Me.gbShortfallsDetails.TabStop = False
        Me.gbShortfallsDetails.Text = "Short Falls Amount Details"
        '
        'dgvShortfallsDetails
        '
        Me.dgvShortfallsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortfallsDetails.Location = New System.Drawing.Point(6, 19)
        Me.dgvShortfallsDetails.Name = "dgvShortfallsDetails"
        Me.dgvShortfallsDetails.Size = New System.Drawing.Size(628, 134)
        Me.dgvShortfallsDetails.TabIndex = 0
        '
        'ShartfallsAc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 433)
        Me.Controls.Add(Me.gbShortfallsAmounts)
        Me.Controls.Add(Me.gbShortfallsDetails)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ShartfallsAc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Falls Settlement"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.gbShortfallsAmounts.ResumeLayout(False)
        Me.gbShortfallsAmounts.PerformLayout()
        Me.flpA2T.ResumeLayout(False)
        Me.flpA2T.PerformLayout()
        Me.gbShortfallsDetails.ResumeLayout(False)
        CType(Me.dgvShortfallsDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsLetters_lblLetter As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsSuspense_cbType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tstxtName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsSuspense_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbShortfallsAmounts As System.Windows.Forms.GroupBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblChequeAmount1 As System.Windows.Forms.Label
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents txtDeductionMonthFrm As System.Windows.Forms.TextBox
    Friend WithEvents lblChequeNo1 As System.Windows.Forms.Label
    Friend WithEvents lblDeductionPeriod As System.Windows.Forms.Label
    Friend WithEvents flpA2T As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbRequest2DA As System.Windows.Forms.RadioButton
    Friend WithEvents rbClientPaidDirect As System.Windows.Forms.RadioButton
    Friend WithEvents lblToRefound1 As System.Windows.Forms.Label
    Friend WithEvents lblToRefound As System.Windows.Forms.Label
    Friend WithEvents gbShortfallsDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvShortfallsDetails As System.Windows.Forms.DataGridView
    Friend WithEvents txtDeductionMonthTo As System.Windows.Forms.TextBox
    Friend WithEvents lblDP12 As System.Windows.Forms.Label
    Friend WithEvents lblDP1 As System.Windows.Forms.Label
    Friend WithEvents txtMethodofPay As System.Windows.Forms.TextBox
    Friend WithEvents lblMethodOfPayment1 As System.Windows.Forms.Label
    Friend WithEvents lblMethodOfPayment As System.Windows.Forms.Label
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents lblRef1 As System.Windows.Forms.Label
    Friend WithEvents lblRef As System.Windows.Forms.Label
    Friend WithEvents lblIC As System.Windows.Forms.Label
    Friend WithEvents lblNoK As System.Windows.Forms.Label
    Friend WithEvents lblNOKPL As System.Windows.Forms.Label
    Friend WithEvents lblDM As System.Windows.Forms.Label
End Class
