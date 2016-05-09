<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vCS
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
        Me.dgvFDetails = New System.Windows.Forms.DataGridView
        Me.lblPID = New System.Windows.Forms.Label
        Me.lblType = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        CType(Me.dgvFDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFDetails
        '
        Me.dgvFDetails.AllowUserToAddRows = False
        Me.dgvFDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvFDetails.Name = "dgvFDetails"
        Me.dgvFDetails.Size = New System.Drawing.Size(637, 477)
        Me.dgvFDetails.TabIndex = 0
        '
        'lblPID
        '
        Me.lblPID.AutoSize = True
        Me.lblPID.Location = New System.Drawing.Point(612, 464)
        Me.lblPID.Name = "lblPID"
        Me.lblPID.Size = New System.Drawing.Size(25, 13)
        Me.lblPID.TabIndex = 1
        Me.lblPID.Text = "PID"
        Me.lblPID.Visible = False
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(568, 464)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(35, 13)
        Me.lblType.TabIndex = 2
        Me.lblType.Text = "TYPE"
        Me.lblType.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(499, 464)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(50, 13)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "STATUS"
        Me.lblStatus.Visible = False
        '
        'vCS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 477)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.lblPID)
        Me.Controls.Add(Me.dgvFDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "vCS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Follow up Details"
        CType(Me.dgvFDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvFDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblPID As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
End Class
