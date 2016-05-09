<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class femdb
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblNRIC = New System.Windows.Forms.Label
        Me.txtNRIC = New System.Windows.Forms.TextBox
        Me.btnProcess = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblNote = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblNRIC
        '
        Me.lblNRIC.AutoSize = True
        Me.lblNRIC.Location = New System.Drawing.Point(12, 48)
        Me.lblNRIC.Name = "lblNRIC"
        Me.lblNRIC.Size = New System.Drawing.Size(36, 13)
        Me.lblNRIC.TabIndex = 0
        Me.lblNRIC.Text = "NRIC "
        '
        'txtNRIC
        '
        Me.txtNRIC.Location = New System.Drawing.Point(70, 45)
        Me.txtNRIC.MaxLength = 13
        Me.txtNRIC.Name = "txtNRIC"
        Me.txtNRIC.Size = New System.Drawing.Size(176, 20)
        Me.txtNRIC.TabIndex = 1
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(252, 42)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(75, 23)
        Me.btnProcess.TabIndex = 2
        Me.btnProcess.Text = "Process"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = ":"
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.ForeColor = System.Drawing.Color.Red
        Me.lblNote.Location = New System.Drawing.Point(10, 8)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(259, 20)
        Me.lblNote.TabIndex = 4
        Me.lblNote.Text = "Note : Only Policy Holder NRIC "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(10, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Ex : C123456789 / P/R/GXXXXX"
        '
        'femdb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(365, 115)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.txtNRIC)
        Me.Controls.Add(Me.lblNRIC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "femdb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Instant Process"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNRIC As System.Windows.Forms.Label
    Friend WithEvents txtNRIC As System.Windows.Forms.TextBox
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
