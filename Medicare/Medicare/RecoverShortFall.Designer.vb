<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecoverShortFall
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
        Me.lblREFID = New System.Windows.Forms.Label
        Me.lblNRIC = New System.Windows.Forms.Label
        Me.lblNRIC1 = New System.Windows.Forms.Label
        Me.txtNRIC = New System.Windows.Forms.TextBox
        Me.txtFullName = New System.Windows.Forms.TextBox
        Me.lblFullName1 = New System.Windows.Forms.Label
        Me.lblFullName = New System.Windows.Forms.Label
        Me.txtDeductionCode = New System.Windows.Forms.TextBox
        Me.lblDeductionCode1 = New System.Windows.Forms.Label
        Me.lblDeductionCode = New System.Windows.Forms.Label
        Me.txtShortAmt = New System.Windows.Forms.TextBox
        Me.lblShortAmt1 = New System.Windows.Forms.Label
        Me.lblShortAmt = New System.Windows.Forms.Label
        Me.flpPM = New System.Windows.Forms.FlowLayoutPanel
        Me.rbRA = New System.Windows.Forms.RadioButton
        Me.rbCP = New System.Windows.Forms.RadioButton
        Me.rbIgnor = New System.Windows.Forms.RadioButton
        Me.lblRecoverType = New System.Windows.Forms.Label
        Me.lblRecoverType1 = New System.Windows.Forms.Label
        Me.txtRPTo = New System.Windows.Forms.TextBox
        Me.lblRPTo1 = New System.Windows.Forms.Label
        Me.lblRPTo = New System.Windows.Forms.Label
        Me.txtRPFrm = New System.Windows.Forms.TextBox
        Me.lblRPfrm1 = New System.Windows.Forms.Label
        Me.lblRPfrm = New System.Windows.Forms.Label
        Me.txtRequestedAmt = New System.Windows.Forms.TextBox
        Me.lblRequestedAmt1 = New System.Windows.Forms.Label
        Me.lblRequestedAmt = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks1 = New System.Windows.Forms.Label
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.txtDCode = New System.Windows.Forms.TextBox
        Me.lblDCode1 = New System.Windows.Forms.Label
        Me.lblDCode = New System.Windows.Forms.Label
        Me.txtRecoveredAmt = New System.Windows.Forms.TextBox
        Me.lblRecoveredAmt1 = New System.Windows.Forms.Label
        Me.lblRecoveredAmt = New System.Windows.Forms.Label
        Me.txtPaymentRefNo = New System.Windows.Forms.TextBox
        Me.lblPaymentRefNo1 = New System.Windows.Forms.Label
        Me.lblPaymentRefNo = New System.Windows.Forms.Label
        Me.lblREFPMNTH = New System.Windows.Forms.Label
        Me.lblBATCHNO = New System.Windows.Forms.Label
        Me.lblREF1 = New System.Windows.Forms.Label
        Me.flpPM.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblREFID
        '
        Me.lblREFID.AutoSize = True
        Me.lblREFID.Location = New System.Drawing.Point(542, 241)
        Me.lblREFID.Name = "lblREFID"
        Me.lblREFID.Size = New System.Drawing.Size(39, 13)
        Me.lblREFID.TabIndex = 0
        Me.lblREFID.Text = "REFID"
        Me.lblREFID.Visible = False
        '
        'lblNRIC
        '
        Me.lblNRIC.AutoSize = True
        Me.lblNRIC.Location = New System.Drawing.Point(25, 23)
        Me.lblNRIC.Name = "lblNRIC"
        Me.lblNRIC.Size = New System.Drawing.Size(33, 13)
        Me.lblNRIC.TabIndex = 1
        Me.lblNRIC.Text = "NRIC"
        '
        'lblNRIC1
        '
        Me.lblNRIC1.AutoSize = True
        Me.lblNRIC1.Location = New System.Drawing.Point(112, 23)
        Me.lblNRIC1.Name = "lblNRIC1"
        Me.lblNRIC1.Size = New System.Drawing.Size(10, 13)
        Me.lblNRIC1.TabIndex = 2
        Me.lblNRIC1.Text = ":"
        '
        'txtNRIC
        '
        Me.txtNRIC.Location = New System.Drawing.Point(128, 20)
        Me.txtNRIC.MaxLength = 13
        Me.txtNRIC.Name = "txtNRIC"
        Me.txtNRIC.ReadOnly = True
        Me.txtNRIC.Size = New System.Drawing.Size(126, 20)
        Me.txtNRIC.TabIndex = 3
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(363, 20)
        Me.txtFullName.MaxLength = 200
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.ReadOnly = True
        Me.txtFullName.Size = New System.Drawing.Size(235, 20)
        Me.txtFullName.TabIndex = 6
        '
        'lblFullName1
        '
        Me.lblFullName1.AutoSize = True
        Me.lblFullName1.Location = New System.Drawing.Point(347, 23)
        Me.lblFullName1.Name = "lblFullName1"
        Me.lblFullName1.Size = New System.Drawing.Size(10, 13)
        Me.lblFullName1.TabIndex = 5
        Me.lblFullName1.Text = ":"
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Location = New System.Drawing.Point(270, 23)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(54, 13)
        Me.lblFullName.TabIndex = 4
        Me.lblFullName.Text = "Full Name"
        '
        'txtDeductionCode
        '
        Me.txtDeductionCode.Location = New System.Drawing.Point(128, 42)
        Me.txtDeductionCode.MaxLength = 5
        Me.txtDeductionCode.Name = "txtDeductionCode"
        Me.txtDeductionCode.ReadOnly = True
        Me.txtDeductionCode.Size = New System.Drawing.Size(126, 20)
        Me.txtDeductionCode.TabIndex = 9
        '
        'lblDeductionCode1
        '
        Me.lblDeductionCode1.AutoSize = True
        Me.lblDeductionCode1.Location = New System.Drawing.Point(112, 45)
        Me.lblDeductionCode1.Name = "lblDeductionCode1"
        Me.lblDeductionCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblDeductionCode1.TabIndex = 8
        Me.lblDeductionCode1.Text = ":"
        '
        'lblDeductionCode
        '
        Me.lblDeductionCode.AutoSize = True
        Me.lblDeductionCode.Location = New System.Drawing.Point(25, 45)
        Me.lblDeductionCode.Name = "lblDeductionCode"
        Me.lblDeductionCode.Size = New System.Drawing.Size(84, 13)
        Me.lblDeductionCode.TabIndex = 7
        Me.lblDeductionCode.Text = "Deduction Code"
        '
        'txtShortAmt
        '
        Me.txtShortAmt.Location = New System.Drawing.Point(363, 42)
        Me.txtShortAmt.MaxLength = 13
        Me.txtShortAmt.Name = "txtShortAmt"
        Me.txtShortAmt.ReadOnly = True
        Me.txtShortAmt.Size = New System.Drawing.Size(78, 20)
        Me.txtShortAmt.TabIndex = 12
        Me.txtShortAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblShortAmt1
        '
        Me.lblShortAmt1.AutoSize = True
        Me.lblShortAmt1.Location = New System.Drawing.Point(347, 45)
        Me.lblShortAmt1.Name = "lblShortAmt1"
        Me.lblShortAmt1.Size = New System.Drawing.Size(10, 13)
        Me.lblShortAmt1.TabIndex = 11
        Me.lblShortAmt1.Text = ":"
        '
        'lblShortAmt
        '
        Me.lblShortAmt.AutoSize = True
        Me.lblShortAmt.Location = New System.Drawing.Point(270, 45)
        Me.lblShortAmt.Name = "lblShortAmt"
        Me.lblShortAmt.Size = New System.Drawing.Size(71, 13)
        Me.lblShortAmt.TabIndex = 10
        Me.lblShortAmt.Text = "Short Amount"
        '
        'flpPM
        '
        Me.flpPM.Controls.Add(Me.rbRA)
        Me.flpPM.Controls.Add(Me.rbCP)
        Me.flpPM.Controls.Add(Me.rbIgnor)
        Me.flpPM.Location = New System.Drawing.Point(128, 68)
        Me.flpPM.Name = "flpPM"
        Me.flpPM.Size = New System.Drawing.Size(470, 25)
        Me.flpPM.TabIndex = 13
        '
        'rbRA
        '
        Me.rbRA.AutoSize = True
        Me.rbRA.Checked = True
        Me.rbRA.Location = New System.Drawing.Point(3, 3)
        Me.rbRA.Name = "rbRA"
        Me.rbRA.Size = New System.Drawing.Size(168, 17)
        Me.rbRA.TabIndex = 2
        Me.rbRA.TabStop = True
        Me.rbRA.Text = "Request to Deduction Agency"
        Me.rbRA.UseVisualStyleBackColor = True
        '
        'rbCP
        '
        Me.rbCP.AutoSize = True
        Me.rbCP.Location = New System.Drawing.Point(177, 3)
        Me.rbCP.Name = "rbCP"
        Me.rbCP.Size = New System.Drawing.Size(109, 17)
        Me.rbCP.TabIndex = 1
        Me.rbCP.Text = "Direct Pay (Client)"
        Me.rbCP.UseVisualStyleBackColor = True
        '
        'rbIgnor
        '
        Me.rbIgnor.AutoSize = True
        Me.rbIgnor.Location = New System.Drawing.Point(292, 3)
        Me.rbIgnor.Name = "rbIgnor"
        Me.rbIgnor.Size = New System.Drawing.Size(55, 17)
        Me.rbIgnor.TabIndex = 3
        Me.rbIgnor.Text = "Ignore"
        Me.rbIgnor.UseVisualStyleBackColor = True
        '
        'lblRecoverType
        '
        Me.lblRecoverType.AutoSize = True
        Me.lblRecoverType.Location = New System.Drawing.Point(25, 73)
        Me.lblRecoverType.Name = "lblRecoverType"
        Me.lblRecoverType.Size = New System.Drawing.Size(75, 13)
        Me.lblRecoverType.TabIndex = 14
        Me.lblRecoverType.Text = "Recover Type"
        '
        'lblRecoverType1
        '
        Me.lblRecoverType1.AutoSize = True
        Me.lblRecoverType1.Location = New System.Drawing.Point(112, 73)
        Me.lblRecoverType1.Name = "lblRecoverType1"
        Me.lblRecoverType1.Size = New System.Drawing.Size(10, 13)
        Me.lblRecoverType1.TabIndex = 15
        Me.lblRecoverType1.Text = ":"
        '
        'txtRPTo
        '
        Me.txtRPTo.Location = New System.Drawing.Point(391, 98)
        Me.txtRPTo.MaxLength = 6
        Me.txtRPTo.Name = "txtRPTo"
        Me.txtRPTo.Size = New System.Drawing.Size(78, 20)
        Me.txtRPTo.TabIndex = 21
        '
        'lblRPTo1
        '
        Me.lblRPTo1.AutoSize = True
        Me.lblRPTo1.Location = New System.Drawing.Point(375, 101)
        Me.lblRPTo1.Name = "lblRPTo1"
        Me.lblRPTo1.Size = New System.Drawing.Size(10, 13)
        Me.lblRPTo1.TabIndex = 20
        Me.lblRPTo1.Text = ":"
        '
        'lblRPTo
        '
        Me.lblRPTo.AutoSize = True
        Me.lblRPTo.Location = New System.Drawing.Point(270, 101)
        Me.lblRPTo.Name = "lblRPTo"
        Me.lblRPTo.Size = New System.Drawing.Size(109, 13)
        Me.lblRPTo.TabIndex = 19
        Me.lblRPTo.Text = "Recovered Period To"
        '
        'txtRPFrm
        '
        Me.txtRPFrm.Location = New System.Drawing.Point(156, 98)
        Me.txtRPFrm.MaxLength = 6
        Me.txtRPFrm.Name = "txtRPFrm"
        Me.txtRPFrm.Size = New System.Drawing.Size(78, 20)
        Me.txtRPFrm.TabIndex = 18
        '
        'lblRPfrm1
        '
        Me.lblRPfrm1.AutoSize = True
        Me.lblRPfrm1.Location = New System.Drawing.Point(140, 101)
        Me.lblRPfrm1.Name = "lblRPfrm1"
        Me.lblRPfrm1.Size = New System.Drawing.Size(10, 13)
        Me.lblRPfrm1.TabIndex = 17
        Me.lblRPfrm1.Text = ":"
        '
        'lblRPfrm
        '
        Me.lblRPfrm.AutoSize = True
        Me.lblRPfrm.Location = New System.Drawing.Point(25, 101)
        Me.lblRPfrm.Name = "lblRPfrm"
        Me.lblRPfrm.Size = New System.Drawing.Size(119, 13)
        Me.lblRPfrm.TabIndex = 16
        Me.lblRPfrm.Text = "Recovered Period From"
        '
        'txtRequestedAmt
        '
        Me.txtRequestedAmt.Location = New System.Drawing.Point(156, 121)
        Me.txtRequestedAmt.MaxLength = 10
        Me.txtRequestedAmt.Name = "txtRequestedAmt"
        Me.txtRequestedAmt.Size = New System.Drawing.Size(78, 20)
        Me.txtRequestedAmt.TabIndex = 24
        Me.txtRequestedAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRequestedAmt1
        '
        Me.lblRequestedAmt1.AutoSize = True
        Me.lblRequestedAmt1.Location = New System.Drawing.Point(140, 124)
        Me.lblRequestedAmt1.Name = "lblRequestedAmt1"
        Me.lblRequestedAmt1.Size = New System.Drawing.Size(10, 13)
        Me.lblRequestedAmt1.TabIndex = 23
        Me.lblRequestedAmt1.Text = ":"
        '
        'lblRequestedAmt
        '
        Me.lblRequestedAmt.AutoSize = True
        Me.lblRequestedAmt.Location = New System.Drawing.Point(25, 124)
        Me.lblRequestedAmt.Name = "lblRequestedAmt"
        Me.lblRequestedAmt.Size = New System.Drawing.Size(98, 13)
        Me.lblRequestedAmt.TabIndex = 22
        Me.lblRequestedAmt.Text = "Requested Amount"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(156, 178)
        Me.txtRemarks.MaxLength = 2000
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(442, 50)
        Me.txtRemarks.TabIndex = 27
        '
        'lblRemarks1
        '
        Me.lblRemarks1.AutoSize = True
        Me.lblRemarks1.Location = New System.Drawing.Point(140, 181)
        Me.lblRemarks1.Name = "lblRemarks1"
        Me.lblRemarks1.Size = New System.Drawing.Size(10, 13)
        Me.lblRemarks1.TabIndex = 26
        Me.lblRemarks1.Text = ":"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(25, 181)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(49, 13)
        Me.lblRemarks.TabIndex = 25
        Me.lblRemarks.Text = "Remarks"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(282, 236)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 28
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(366, 236)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(195, 236)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 30
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        Me.btnPrint.Visible = False
        '
        'txtDCode
        '
        Me.txtDCode.Location = New System.Drawing.Point(391, 121)
        Me.txtDCode.MaxLength = 13
        Me.txtDCode.Name = "txtDCode"
        Me.txtDCode.ReadOnly = True
        Me.txtDCode.Size = New System.Drawing.Size(78, 20)
        Me.txtDCode.TabIndex = 33
        Me.txtDCode.Text = "0599"
        '
        'lblDCode1
        '
        Me.lblDCode1.AutoSize = True
        Me.lblDCode1.Location = New System.Drawing.Point(375, 124)
        Me.lblDCode1.Name = "lblDCode1"
        Me.lblDCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblDCode1.TabIndex = 32
        Me.lblDCode1.Text = ":"
        '
        'lblDCode
        '
        Me.lblDCode.AutoSize = True
        Me.lblDCode.Location = New System.Drawing.Point(285, 124)
        Me.lblDCode.Name = "lblDCode"
        Me.lblDCode.Size = New System.Drawing.Size(84, 13)
        Me.lblDCode.TabIndex = 31
        Me.lblDCode.Text = "Deduction Code"
        '
        'txtRecoveredAmt
        '
        Me.txtRecoveredAmt.Location = New System.Drawing.Point(391, 147)
        Me.txtRecoveredAmt.MaxLength = 6
        Me.txtRecoveredAmt.Name = "txtRecoveredAmt"
        Me.txtRecoveredAmt.Size = New System.Drawing.Size(78, 20)
        Me.txtRecoveredAmt.TabIndex = 39
        '
        'lblRecoveredAmt1
        '
        Me.lblRecoveredAmt1.AutoSize = True
        Me.lblRecoveredAmt1.Location = New System.Drawing.Point(375, 150)
        Me.lblRecoveredAmt1.Name = "lblRecoveredAmt1"
        Me.lblRecoveredAmt1.Size = New System.Drawing.Size(10, 13)
        Me.lblRecoveredAmt1.TabIndex = 38
        Me.lblRecoveredAmt1.Text = ":"
        '
        'lblRecoveredAmt
        '
        Me.lblRecoveredAmt.AutoSize = True
        Me.lblRecoveredAmt.Location = New System.Drawing.Point(270, 150)
        Me.lblRecoveredAmt.Name = "lblRecoveredAmt"
        Me.lblRecoveredAmt.Size = New System.Drawing.Size(99, 13)
        Me.lblRecoveredAmt.TabIndex = 37
        Me.lblRecoveredAmt.Text = "Recovered Amount"
        '
        'txtPaymentRefNo
        '
        Me.txtPaymentRefNo.Location = New System.Drawing.Point(156, 147)
        Me.txtPaymentRefNo.MaxLength = 6
        Me.txtPaymentRefNo.Name = "txtPaymentRefNo"
        Me.txtPaymentRefNo.Size = New System.Drawing.Size(78, 20)
        Me.txtPaymentRefNo.TabIndex = 36
        '
        'lblPaymentRefNo1
        '
        Me.lblPaymentRefNo1.AutoSize = True
        Me.lblPaymentRefNo1.Location = New System.Drawing.Point(140, 150)
        Me.lblPaymentRefNo1.Name = "lblPaymentRefNo1"
        Me.lblPaymentRefNo1.Size = New System.Drawing.Size(10, 13)
        Me.lblPaymentRefNo1.TabIndex = 35
        Me.lblPaymentRefNo1.Text = ":"
        '
        'lblPaymentRefNo
        '
        Me.lblPaymentRefNo.AutoSize = True
        Me.lblPaymentRefNo.Location = New System.Drawing.Point(25, 150)
        Me.lblPaymentRefNo.Name = "lblPaymentRefNo"
        Me.lblPaymentRefNo.Size = New System.Drawing.Size(81, 13)
        Me.lblPaymentRefNo.TabIndex = 34
        Me.lblPaymentRefNo.Text = "Payment Ref # "
        '
        'lblREFPMNTH
        '
        Me.lblREFPMNTH.AutoSize = True
        Me.lblREFPMNTH.Location = New System.Drawing.Point(457, 241)
        Me.lblREFPMNTH.Name = "lblREFPMNTH"
        Me.lblREFPMNTH.Size = New System.Drawing.Size(67, 13)
        Me.lblREFPMNTH.TabIndex = 40
        Me.lblREFPMNTH.Text = "REFPMNTH"
        Me.lblREFPMNTH.Visible = False
        '
        'lblBATCHNO
        '
        Me.lblBATCHNO.AutoSize = True
        Me.lblBATCHNO.Location = New System.Drawing.Point(83, 241)
        Me.lblBATCHNO.Name = "lblBATCHNO"
        Me.lblBATCHNO.Size = New System.Drawing.Size(59, 13)
        Me.lblBATCHNO.TabIndex = 41
        Me.lblBATCHNO.Text = "BATCHNO"
        Me.lblBATCHNO.Visible = False
        '
        'lblREF1
        '
        Me.lblREF1.AutoSize = True
        Me.lblREF1.Location = New System.Drawing.Point(25, 236)
        Me.lblREF1.Name = "lblREF1"
        Me.lblREF1.Size = New System.Drawing.Size(34, 13)
        Me.lblREF1.TabIndex = 42
        Me.lblREF1.Text = "REF1"
        Me.lblREF1.Visible = False
        '
        'RecoverShortFall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 278)
        Me.Controls.Add(Me.lblREF1)
        Me.Controls.Add(Me.lblBATCHNO)
        Me.Controls.Add(Me.lblREFPMNTH)
        Me.Controls.Add(Me.txtRecoveredAmt)
        Me.Controls.Add(Me.lblRecoveredAmt1)
        Me.Controls.Add(Me.lblRecoveredAmt)
        Me.Controls.Add(Me.txtPaymentRefNo)
        Me.Controls.Add(Me.lblPaymentRefNo1)
        Me.Controls.Add(Me.lblPaymentRefNo)
        Me.Controls.Add(Me.txtDCode)
        Me.Controls.Add(Me.lblDCode1)
        Me.Controls.Add(Me.lblDCode)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks1)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.txtRequestedAmt)
        Me.Controls.Add(Me.lblRequestedAmt1)
        Me.Controls.Add(Me.lblRequestedAmt)
        Me.Controls.Add(Me.txtRPTo)
        Me.Controls.Add(Me.lblRPTo1)
        Me.Controls.Add(Me.lblRPTo)
        Me.Controls.Add(Me.txtRPFrm)
        Me.Controls.Add(Me.lblRPfrm1)
        Me.Controls.Add(Me.lblRPfrm)
        Me.Controls.Add(Me.lblRecoverType1)
        Me.Controls.Add(Me.lblRecoverType)
        Me.Controls.Add(Me.flpPM)
        Me.Controls.Add(Me.txtShortAmt)
        Me.Controls.Add(Me.lblShortAmt1)
        Me.Controls.Add(Me.lblShortAmt)
        Me.Controls.Add(Me.txtDeductionCode)
        Me.Controls.Add(Me.lblDeductionCode1)
        Me.Controls.Add(Me.lblDeductionCode)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.lblFullName1)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.txtNRIC)
        Me.Controls.Add(Me.lblNRIC1)
        Me.Controls.Add(Me.lblNRIC)
        Me.Controls.Add(Me.lblREFID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "RecoverShortFall"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Falls Request "
        Me.flpPM.ResumeLayout(False)
        Me.flpPM.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblREFID As System.Windows.Forms.Label
    Friend WithEvents lblNRIC As System.Windows.Forms.Label
    Friend WithEvents lblNRIC1 As System.Windows.Forms.Label
    Friend WithEvents txtNRIC As System.Windows.Forms.TextBox
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents lblFullName1 As System.Windows.Forms.Label
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents txtDeductionCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDeductionCode1 As System.Windows.Forms.Label
    Friend WithEvents lblDeductionCode As System.Windows.Forms.Label
    Friend WithEvents txtShortAmt As System.Windows.Forms.TextBox
    Friend WithEvents lblShortAmt1 As System.Windows.Forms.Label
    Friend WithEvents lblShortAmt As System.Windows.Forms.Label
    Friend WithEvents flpPM As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbRA As System.Windows.Forms.RadioButton
    Friend WithEvents rbCP As System.Windows.Forms.RadioButton
    Friend WithEvents lblRecoverType As System.Windows.Forms.Label
    Friend WithEvents lblRecoverType1 As System.Windows.Forms.Label
    Friend WithEvents rbIgnor As System.Windows.Forms.RadioButton
    Friend WithEvents txtRPTo As System.Windows.Forms.TextBox
    Friend WithEvents lblRPTo1 As System.Windows.Forms.Label
    Friend WithEvents lblRPTo As System.Windows.Forms.Label
    Friend WithEvents txtRPFrm As System.Windows.Forms.TextBox
    Friend WithEvents lblRPfrm1 As System.Windows.Forms.Label
    Friend WithEvents lblRPfrm As System.Windows.Forms.Label
    Friend WithEvents txtRequestedAmt As System.Windows.Forms.TextBox
    Friend WithEvents lblRequestedAmt1 As System.Windows.Forms.Label
    Friend WithEvents lblRequestedAmt As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks1 As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents txtDCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDCode1 As System.Windows.Forms.Label
    Friend WithEvents lblDCode As System.Windows.Forms.Label
    Friend WithEvents txtRecoveredAmt As System.Windows.Forms.TextBox
    Friend WithEvents lblRecoveredAmt1 As System.Windows.Forms.Label
    Friend WithEvents lblRecoveredAmt As System.Windows.Forms.Label
    Friend WithEvents txtPaymentRefNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPaymentRefNo1 As System.Windows.Forms.Label
    Friend WithEvents lblPaymentRefNo As System.Windows.Forms.Label
    Friend WithEvents lblREFPMNTH As System.Windows.Forms.Label
    Friend WithEvents lblBATCHNO As System.Windows.Forms.Label
    Friend WithEvents lblREF1 As System.Windows.Forms.Label
End Class
