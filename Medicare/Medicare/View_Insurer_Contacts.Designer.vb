<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class View_Insurer_Contacts
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
        Me.dgvInsurerContacts = New System.Windows.Forms.DataGridView
        Me.lblInsurerID = New System.Windows.Forms.Label
        CType(Me.dgvInsurerContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvInsurerContacts
        '
        Me.dgvInsurerContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInsurerContacts.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsurerContacts.Name = "dgvInsurerContacts"
        Me.dgvInsurerContacts.Size = New System.Drawing.Size(586, 188)
        Me.dgvInsurerContacts.TabIndex = 0
        '
        'lblInsurerID
        '
        Me.lblInsurerID.AutoSize = True
        Me.lblInsurerID.Location = New System.Drawing.Point(226, 203)
        Me.lblInsurerID.Name = "lblInsurerID"
        Me.lblInsurerID.Size = New System.Drawing.Size(18, 13)
        Me.lblInsurerID.TabIndex = 1
        Me.lblInsurerID.Text = "ID"
        Me.lblInsurerID.Visible = False
        '
        'View_Insurer_Contacts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 228)
        Me.Controls.Add(Me.lblInsurerID)
        Me.Controls.Add(Me.dgvInsurerContacts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "View_Insurer_Contacts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View_Insurer_Contacts"
        CType(Me.dgvInsurerContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvInsurerContacts As System.Windows.Forms.DataGridView
    Friend WithEvents lblInsurerID As System.Windows.Forms.Label
End Class
