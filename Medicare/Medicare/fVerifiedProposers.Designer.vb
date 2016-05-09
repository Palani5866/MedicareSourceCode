<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fVerifiedProposers
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
        Me.lblPlanCode = New System.Windows.Forms.Label
        Me.cbPlanCode = New System.Windows.Forms.ComboBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.lblPlanCode1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblPlanCode
        '
        Me.lblPlanCode.AutoSize = True
        Me.lblPlanCode.Location = New System.Drawing.Point(12, 31)
        Me.lblPlanCode.Name = "lblPlanCode"
        Me.lblPlanCode.Size = New System.Drawing.Size(59, 13)
        Me.lblPlanCode.TabIndex = 0
        Me.lblPlanCode.Text = "Plan Code "
        '
        'cbPlanCode
        '
        Me.cbPlanCode.FormattingEnabled = True
        Me.cbPlanCode.Location = New System.Drawing.Point(114, 28)
        Me.cbPlanCode.Name = "cbPlanCode"
        Me.cbPlanCode.Size = New System.Drawing.Size(243, 21)
        Me.cbPlanCode.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(159, 64)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblPlanCode1
        '
        Me.lblPlanCode1.AutoSize = True
        Me.lblPlanCode1.Location = New System.Drawing.Point(88, 31)
        Me.lblPlanCode1.Name = "lblPlanCode1"
        Me.lblPlanCode1.Size = New System.Drawing.Size(10, 13)
        Me.lblPlanCode1.TabIndex = 3
        Me.lblPlanCode1.Text = ":"
        '
        'fVerifiedProposers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 105)
        Me.Controls.Add(Me.lblPlanCode1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cbPlanCode)
        Me.Controls.Add(Me.lblPlanCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fVerifiedProposers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verified Proposers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPlanCode As System.Windows.Forms.Label
    Friend WithEvents cbPlanCode As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblPlanCode1 As System.Windows.Forms.Label
End Class
