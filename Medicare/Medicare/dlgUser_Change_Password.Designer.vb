<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgUser_Change_Password
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.lblUser_Password_Old = New System.Windows.Forms.Label
        Me.txtUser_Password_Old = New System.Windows.Forms.TextBox
        Me.txtUser_Password_New = New System.Windows.Forms.TextBox
        Me.lblUser_Password_New = New System.Windows.Forms.Label
        Me.txtUser_Password_New_Final = New System.Windows.Forms.TextBox
        Me.lblUser_Password_New_Final = New System.Windows.Forms.Label
        Me.lblUser_Password_Remark = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 97)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'lblUser_Password_Old
        '
        Me.lblUser_Password_Old.AutoSize = True
        Me.lblUser_Password_Old.Location = New System.Drawing.Point(16, 16)
        Me.lblUser_Password_Old.Name = "lblUser_Password_Old"
        Me.lblUser_Password_Old.Size = New System.Drawing.Size(75, 13)
        Me.lblUser_Password_Old.TabIndex = 0
        Me.lblUser_Password_Old.Text = "Old Password:"
        '
        'txtUser_Password_Old
        '
        Me.txtUser_Password_Old.Location = New System.Drawing.Point(141, 12)
        Me.txtUser_Password_Old.MaxLength = 10
        Me.txtUser_Password_Old.Name = "txtUser_Password_Old"
        Me.txtUser_Password_Old.Size = New System.Drawing.Size(162, 20)
        Me.txtUser_Password_Old.TabIndex = 1
        '
        'txtUser_Password_New
        '
        Me.txtUser_Password_New.Location = New System.Drawing.Point(141, 38)
        Me.txtUser_Password_New.MaxLength = 10
        Me.txtUser_Password_New.Name = "txtUser_Password_New"
        Me.txtUser_Password_New.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUser_Password_New.Size = New System.Drawing.Size(162, 20)
        Me.txtUser_Password_New.TabIndex = 3
        '
        'lblUser_Password_New
        '
        Me.lblUser_Password_New.AutoSize = True
        Me.lblUser_Password_New.Location = New System.Drawing.Point(16, 42)
        Me.lblUser_Password_New.Name = "lblUser_Password_New"
        Me.lblUser_Password_New.Size = New System.Drawing.Size(81, 13)
        Me.lblUser_Password_New.TabIndex = 2
        Me.lblUser_Password_New.Text = "New Password:"
        '
        'txtUser_Password_New_Final
        '
        Me.txtUser_Password_New_Final.Location = New System.Drawing.Point(141, 64)
        Me.txtUser_Password_New_Final.MaxLength = 10
        Me.txtUser_Password_New_Final.Name = "txtUser_Password_New_Final"
        Me.txtUser_Password_New_Final.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUser_Password_New_Final.Size = New System.Drawing.Size(162, 20)
        Me.txtUser_Password_New_Final.TabIndex = 5
        '
        'lblUser_Password_New_Final
        '
        Me.lblUser_Password_New_Final.AutoSize = True
        Me.lblUser_Password_New_Final.Location = New System.Drawing.Point(16, 68)
        Me.lblUser_Password_New_Final.Name = "lblUser_Password_New_Final"
        Me.lblUser_Password_New_Final.Size = New System.Drawing.Size(119, 13)
        Me.lblUser_Password_New_Final.TabIndex = 4
        Me.lblUser_Password_New_Final.Text = "Confirm New Password:"
        '
        'lblUser_Password_Remark
        '
        Me.lblUser_Password_Remark.AutoSize = True
        Me.lblUser_Password_Remark.ForeColor = System.Drawing.Color.Red
        Me.lblUser_Password_Remark.Location = New System.Drawing.Point(308, 42)
        Me.lblUser_Password_Remark.Name = "lblUser_Password_Remark"
        Me.lblUser_Password_Remark.Size = New System.Drawing.Size(111, 13)
        Me.lblUser_Password_Remark.TabIndex = 7
        Me.lblUser_Password_Remark.Text = "**Max 10 characters**"
        '
        'dlgUser_Change_Password
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 138)
        Me.Controls.Add(Me.lblUser_Password_Remark)
        Me.Controls.Add(Me.txtUser_Password_New_Final)
        Me.Controls.Add(Me.lblUser_Password_New_Final)
        Me.Controls.Add(Me.txtUser_Password_New)
        Me.Controls.Add(Me.lblUser_Password_New)
        Me.Controls.Add(Me.txtUser_Password_Old)
        Me.Controls.Add(Me.lblUser_Password_Old)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgUser_Change_Password"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change a Password"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblUser_Password_Old As System.Windows.Forms.Label
    Friend WithEvents txtUser_Password_Old As System.Windows.Forms.TextBox
    Friend WithEvents txtUser_Password_New As System.Windows.Forms.TextBox
    Friend WithEvents lblUser_Password_New As System.Windows.Forms.Label
    Friend WithEvents txtUser_Password_New_Final As System.Windows.Forms.TextBox
    Friend WithEvents lblUser_Password_New_Final As System.Windows.Forms.Label
    Friend WithEvents lblUser_Password_Remark As System.Windows.Forms.Label

End Class
