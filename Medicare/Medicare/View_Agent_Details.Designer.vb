<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class View_Agent_Details
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
        Me.dgvAgentDetails = New System.Windows.Forms.DataGridView
        Me.lblAID = New System.Windows.Forms.Label
        CType(Me.dgvAgentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAgentDetails
        '
        Me.dgvAgentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAgentDetails.Location = New System.Drawing.Point(3, 13)
        Me.dgvAgentDetails.Name = "dgvAgentDetails"
        Me.dgvAgentDetails.Size = New System.Drawing.Size(888, 144)
        Me.dgvAgentDetails.TabIndex = 0
        '
        'lblAID
        '
        Me.lblAID.AutoSize = True
        Me.lblAID.Location = New System.Drawing.Point(305, 170)
        Me.lblAID.Name = "lblAID"
        Me.lblAID.Size = New System.Drawing.Size(18, 13)
        Me.lblAID.TabIndex = 1
        Me.lblAID.Text = "ID"
        Me.lblAID.Visible = False
        '
        'View_Agent_Details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 187)
        Me.Controls.Add(Me.lblAID)
        Me.Controls.Add(Me.dgvAgentDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "View_Agent_Details"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Agent Details"
        CType(Me.dgvAgentDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvAgentDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblAID As System.Windows.Forms.Label
End Class
