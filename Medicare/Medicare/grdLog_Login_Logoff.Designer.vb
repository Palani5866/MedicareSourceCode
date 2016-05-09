<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdLog_Login_Logoff
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
        Me.dgvForm = New System.Windows.Forms.DataGridView
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvForm
        '
        Me.dgvForm.AllowUserToAddRows = False
        Me.dgvForm.AllowUserToDeleteRows = False
        Me.dgvForm.AllowUserToOrderColumns = True
        Me.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvForm.Location = New System.Drawing.Point(0, 0)
        Me.dgvForm.Name = "dgvForm"
        Me.dgvForm.ReadOnly = True
        Me.dgvForm.Size = New System.Drawing.Size(584, 564)
        Me.dgvForm.TabIndex = 0
        '
        'grdLog_Login_Logoff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 564)
        Me.Controls.Add(Me.dgvForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdLog_Login_Logoff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log: Login / Logoff"
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
End Class
