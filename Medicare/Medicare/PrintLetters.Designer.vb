<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintLetters
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblTotPremium = New System.Windows.Forms.Label
        Me.lblGST = New System.Windows.Forms.Label
        Me.lblPremium = New System.Windows.Forms.Label
        Me.lblOSPremium = New System.Windows.Forms.Label
        Me.lblOSGST = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblOSGST)
        Me.Panel1.Controls.Add(Me.lblOSPremium)
        Me.Panel1.Controls.Add(Me.lblTotPremium)
        Me.Panel1.Controls.Add(Me.lblGST)
        Me.Panel1.Controls.Add(Me.lblPremium)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1171, 579)
        Me.Panel1.TabIndex = 1
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
        'PrintLetters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1171, 579)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "PrintLetters"
        Me.Text = "PrintLetters"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTotPremium As System.Windows.Forms.Label
    Friend WithEvents lblGST As System.Windows.Forms.Label
    Friend WithEvents lblPremium As System.Windows.Forms.Label
    Friend WithEvents lblOSGST As System.Windows.Forms.Label
    Friend WithEvents lblOSPremium As System.Windows.Forms.Label
End Class
