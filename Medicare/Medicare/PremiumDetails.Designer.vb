<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PremiumDetails
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
        Me.dgvPremiumDetails = New System.Windows.Forms.DataGridView
        Me.lblREFID = New System.Windows.Forms.Label
        CType(Me.dgvPremiumDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPremiumDetails
        '
        Me.dgvPremiumDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPremiumDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPremiumDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvPremiumDetails.Name = "dgvPremiumDetails"
        Me.dgvPremiumDetails.Size = New System.Drawing.Size(946, 490)
        Me.dgvPremiumDetails.TabIndex = 0
        '
        'lblREFID
        '
        Me.lblREFID.AutoSize = True
        Me.lblREFID.Location = New System.Drawing.Point(519, 415)
        Me.lblREFID.Name = "lblREFID"
        Me.lblREFID.Size = New System.Drawing.Size(39, 13)
        Me.lblREFID.TabIndex = 1
        Me.lblREFID.Text = "REFID"
        Me.lblREFID.Visible = False
        '
        'PremiumDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 490)
        Me.Controls.Add(Me.lblREFID)
        Me.Controls.Add(Me.dgvPremiumDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "PremiumDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Premium Requested Details"
        CType(Me.dgvPremiumDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvPremiumDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblREFID As System.Windows.Forms.Label
End Class
