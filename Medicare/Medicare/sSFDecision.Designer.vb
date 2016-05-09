<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sSFDecision
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
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks1 = New System.Windows.Forms.Label
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.lblRecoverType1 = New System.Windows.Forms.Label
        Me.lblRecoverType = New System.Windows.Forms.Label
        Me.flpPM = New System.Windows.Forms.FlowLayoutPanel
        Me.rbC2Y = New System.Windows.Forms.RadioButton
        Me.rbCP = New System.Windows.Forms.RadioButton
        Me.rbIgnor = New System.Windows.Forms.RadioButton
        Me.txtDeductionCode = New System.Windows.Forms.TextBox
        Me.lblDeductionCode1 = New System.Windows.Forms.Label
        Me.lblDeductionCode = New System.Windows.Forms.Label
        Me.txtFullName = New System.Windows.Forms.TextBox
        Me.lblFullName1 = New System.Windows.Forms.Label
        Me.lblFullName = New System.Windows.Forms.Label
        Me.txtNRIC = New System.Windows.Forms.TextBox
        Me.lblNRIC1 = New System.Windows.Forms.Label
        Me.lblNRIC = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.lblPlanCode1 = New System.Windows.Forms.Label
        Me.lblPlanCode = New System.Windows.Forms.Label
        Me.lblREF1 = New System.Windows.Forms.Label
        Me.lblREF2 = New System.Windows.Forms.Label
        Me.flpPM.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(118, 95)
        Me.txtRemarks.MaxLength = 2000
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(442, 50)
        Me.txtRemarks.TabIndex = 66
        '
        'lblRemarks1
        '
        Me.lblRemarks1.AutoSize = True
        Me.lblRemarks1.Location = New System.Drawing.Point(99, 95)
        Me.lblRemarks1.Name = "lblRemarks1"
        Me.lblRemarks1.Size = New System.Drawing.Size(10, 13)
        Me.lblRemarks1.TabIndex = 65
        Me.lblRemarks1.Text = ":"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(12, 98)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(49, 13)
        Me.lblRemarks.TabIndex = 64
        Me.lblRemarks.Text = "Remarks"
        '
        'lblRecoverType1
        '
        Me.lblRecoverType1.AutoSize = True
        Me.lblRecoverType1.Location = New System.Drawing.Point(99, 69)
        Me.lblRecoverType1.Name = "lblRecoverType1"
        Me.lblRecoverType1.Size = New System.Drawing.Size(10, 13)
        Me.lblRecoverType1.TabIndex = 54
        Me.lblRecoverType1.Text = ":"
        '
        'lblRecoverType
        '
        Me.lblRecoverType.AutoSize = True
        Me.lblRecoverType.Location = New System.Drawing.Point(12, 69)
        Me.lblRecoverType.Name = "lblRecoverType"
        Me.lblRecoverType.Size = New System.Drawing.Size(75, 13)
        Me.lblRecoverType.TabIndex = 53
        Me.lblRecoverType.Text = "Recover Type"
        '
        'flpPM
        '
        Me.flpPM.Controls.Add(Me.rbC2Y)
        Me.flpPM.Controls.Add(Me.rbCP)
        Me.flpPM.Controls.Add(Me.rbIgnor)
        Me.flpPM.Location = New System.Drawing.Point(115, 64)
        Me.flpPM.Name = "flpPM"
        Me.flpPM.Size = New System.Drawing.Size(470, 25)
        Me.flpPM.TabIndex = 52
        '
        'rbC2Y
        '
        Me.rbC2Y.AutoSize = True
        Me.rbC2Y.Checked = True
        Me.rbC2Y.Location = New System.Drawing.Point(3, 3)
        Me.rbC2Y.Name = "rbC2Y"
        Me.rbC2Y.Size = New System.Drawing.Size(106, 17)
        Me.rbC2Y.TabIndex = 2
        Me.rbC2Y.TabStop = True
        Me.rbC2Y.Text = "Change to Yearly"
        Me.rbC2Y.UseVisualStyleBackColor = True
        '
        'rbCP
        '
        Me.rbCP.AutoSize = True
        Me.rbCP.Location = New System.Drawing.Point(115, 3)
        Me.rbCP.Name = "rbCP"
        Me.rbCP.Size = New System.Drawing.Size(89, 17)
        Me.rbCP.TabIndex = 1
        Me.rbCP.Text = "Cancel Policy"
        Me.rbCP.UseVisualStyleBackColor = True
        '
        'rbIgnor
        '
        Me.rbIgnor.AutoSize = True
        Me.rbIgnor.Location = New System.Drawing.Point(210, 3)
        Me.rbIgnor.Name = "rbIgnor"
        Me.rbIgnor.Size = New System.Drawing.Size(55, 17)
        Me.rbIgnor.TabIndex = 3
        Me.rbIgnor.Text = "Ignore"
        Me.rbIgnor.UseVisualStyleBackColor = True
        '
        'txtDeductionCode
        '
        Me.txtDeductionCode.Location = New System.Drawing.Point(115, 38)
        Me.txtDeductionCode.MaxLength = 5
        Me.txtDeductionCode.Name = "txtDeductionCode"
        Me.txtDeductionCode.ReadOnly = True
        Me.txtDeductionCode.Size = New System.Drawing.Size(126, 20)
        Me.txtDeductionCode.TabIndex = 48
        '
        'lblDeductionCode1
        '
        Me.lblDeductionCode1.AutoSize = True
        Me.lblDeductionCode1.Location = New System.Drawing.Point(99, 41)
        Me.lblDeductionCode1.Name = "lblDeductionCode1"
        Me.lblDeductionCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblDeductionCode1.TabIndex = 47
        Me.lblDeductionCode1.Text = ":"
        '
        'lblDeductionCode
        '
        Me.lblDeductionCode.AutoSize = True
        Me.lblDeductionCode.Location = New System.Drawing.Point(12, 41)
        Me.lblDeductionCode.Name = "lblDeductionCode"
        Me.lblDeductionCode.Size = New System.Drawing.Size(84, 13)
        Me.lblDeductionCode.TabIndex = 46
        Me.lblDeductionCode.Text = "Deduction Code"
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(350, 16)
        Me.txtFullName.MaxLength = 200
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.ReadOnly = True
        Me.txtFullName.Size = New System.Drawing.Size(235, 20)
        Me.txtFullName.TabIndex = 45
        '
        'lblFullName1
        '
        Me.lblFullName1.AutoSize = True
        Me.lblFullName1.Location = New System.Drawing.Point(334, 19)
        Me.lblFullName1.Name = "lblFullName1"
        Me.lblFullName1.Size = New System.Drawing.Size(10, 13)
        Me.lblFullName1.TabIndex = 44
        Me.lblFullName1.Text = ":"
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Location = New System.Drawing.Point(247, 19)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(54, 13)
        Me.lblFullName.TabIndex = 43
        Me.lblFullName.Text = "Full Name"
        '
        'txtNRIC
        '
        Me.txtNRIC.Location = New System.Drawing.Point(115, 16)
        Me.txtNRIC.MaxLength = 13
        Me.txtNRIC.Name = "txtNRIC"
        Me.txtNRIC.ReadOnly = True
        Me.txtNRIC.Size = New System.Drawing.Size(126, 20)
        Me.txtNRIC.TabIndex = 42
        '
        'lblNRIC1
        '
        Me.lblNRIC1.AutoSize = True
        Me.lblNRIC1.Location = New System.Drawing.Point(99, 19)
        Me.lblNRIC1.Name = "lblNRIC1"
        Me.lblNRIC1.Size = New System.Drawing.Size(10, 13)
        Me.lblNRIC1.TabIndex = 41
        Me.lblNRIC1.Text = ":"
        '
        'lblNRIC
        '
        Me.lblNRIC.AutoSize = True
        Me.lblNRIC.Location = New System.Drawing.Point(12, 19)
        Me.lblNRIC.Name = "lblNRIC"
        Me.lblNRIC.Size = New System.Drawing.Size(33, 13)
        Me.lblNRIC.TabIndex = 40
        Me.lblNRIC.Text = "NRIC"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(303, 159)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 68
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(219, 159)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 67
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(350, 38)
        Me.TextBox1.MaxLength = 5
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(235, 20)
        Me.TextBox1.TabIndex = 71
        '
        'lblPlanCode1
        '
        Me.lblPlanCode1.AutoSize = True
        Me.lblPlanCode1.Location = New System.Drawing.Point(334, 41)
        Me.lblPlanCode1.Name = "lblPlanCode1"
        Me.lblPlanCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblPlanCode1.TabIndex = 70
        Me.lblPlanCode1.Text = ":"
        '
        'lblPlanCode
        '
        Me.lblPlanCode.AutoSize = True
        Me.lblPlanCode.Location = New System.Drawing.Point(247, 41)
        Me.lblPlanCode.Name = "lblPlanCode"
        Me.lblPlanCode.Size = New System.Drawing.Size(56, 13)
        Me.lblPlanCode.TabIndex = 69
        Me.lblPlanCode.Text = "Plan Code"
        '
        'lblREF1
        '
        Me.lblREF1.AutoSize = True
        Me.lblREF1.Location = New System.Drawing.Point(446, 169)
        Me.lblREF1.Name = "lblREF1"
        Me.lblREF1.Size = New System.Drawing.Size(34, 13)
        Me.lblREF1.TabIndex = 72
        Me.lblREF1.Text = "REF1"
        Me.lblREF1.Visible = False
        '
        'lblREF2
        '
        Me.lblREF2.AutoSize = True
        Me.lblREF2.Location = New System.Drawing.Point(495, 169)
        Me.lblREF2.Name = "lblREF2"
        Me.lblREF2.Size = New System.Drawing.Size(34, 13)
        Me.lblREF2.TabIndex = 73
        Me.lblREF2.Text = "REF2"
        Me.lblREF2.Visible = False
        '
        'sSFDecision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 194)
        Me.Controls.Add(Me.lblREF2)
        Me.Controls.Add(Me.lblREF1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblPlanCode1)
        Me.Controls.Add(Me.lblPlanCode)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks1)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.lblRecoverType1)
        Me.Controls.Add(Me.lblRecoverType)
        Me.Controls.Add(Me.flpPM)
        Me.Controls.Add(Me.txtDeductionCode)
        Me.Controls.Add(Me.lblDeductionCode1)
        Me.Controls.Add(Me.lblDeductionCode)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.lblFullName1)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.txtNRIC)
        Me.Controls.Add(Me.lblNRIC1)
        Me.Controls.Add(Me.lblNRIC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "sSFDecision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Fall Decision Making"
        Me.flpPM.ResumeLayout(False)
        Me.flpPM.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks1 As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents lblRecoverType1 As System.Windows.Forms.Label
    Friend WithEvents lblRecoverType As System.Windows.Forms.Label
    Friend WithEvents flpPM As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbC2Y As System.Windows.Forms.RadioButton
    Friend WithEvents rbCP As System.Windows.Forms.RadioButton
    Friend WithEvents rbIgnor As System.Windows.Forms.RadioButton
    Friend WithEvents txtDeductionCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDeductionCode1 As System.Windows.Forms.Label
    Friend WithEvents lblDeductionCode As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents lblFullName1 As System.Windows.Forms.Label
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents txtNRIC As System.Windows.Forms.TextBox
    Friend WithEvents lblNRIC1 As System.Windows.Forms.Label
    Friend WithEvents lblNRIC As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblPlanCode1 As System.Windows.Forms.Label
    Friend WithEvents lblPlanCode As System.Windows.Forms.Label
    Friend WithEvents lblREF1 As System.Windows.Forms.Label
    Friend WithEvents lblREF2 As System.Windows.Forms.Label
End Class
