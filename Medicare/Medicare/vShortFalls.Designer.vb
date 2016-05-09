<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vShortFalls
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
        Me.dgvShortFallDetails = New System.Windows.Forms.DataGridView
        Me.lblREFID = New System.Windows.Forms.Label
        Me.lblRefType = New System.Windows.Forms.Label
        Me.lblREF2 = New System.Windows.Forms.Label
        CType(Me.dgvShortFallDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvShortFallDetails
        '
        Me.dgvShortFallDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortFallDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShortFallDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvShortFallDetails.Name = "dgvShortFallDetails"
        Me.dgvShortFallDetails.Size = New System.Drawing.Size(938, 496)
        Me.dgvShortFallDetails.TabIndex = 1
        '
        'lblREFID
        '
        Me.lblREFID.AutoSize = True
        Me.lblREFID.Location = New System.Drawing.Point(450, 242)
        Me.lblREFID.Name = "lblREFID"
        Me.lblREFID.Size = New System.Drawing.Size(39, 13)
        Me.lblREFID.TabIndex = 2
        Me.lblREFID.Text = "REFID"
        Me.lblREFID.Visible = False
        '
        'lblRefType
        '
        Me.lblRefType.AutoSize = True
        Me.lblRefType.Location = New System.Drawing.Point(636, 172)
        Me.lblRefType.Name = "lblRefType"
        Me.lblRefType.Size = New System.Drawing.Size(48, 13)
        Me.lblRefType.TabIndex = 3
        Me.lblRefType.Text = "RefType"
        Me.lblRefType.Visible = False
        '
        'lblREF2
        '
        Me.lblREF2.AutoSize = True
        Me.lblREF2.Location = New System.Drawing.Point(588, 287)
        Me.lblREF2.Name = "lblREF2"
        Me.lblREF2.Size = New System.Drawing.Size(34, 13)
        Me.lblREF2.TabIndex = 4
        Me.lblREF2.Text = "REF2"
        Me.lblREF2.Visible = False
        '
        'vShortFalls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 496)
        Me.Controls.Add(Me.lblREF2)
        Me.Controls.Add(Me.lblRefType)
        Me.Controls.Add(Me.lblREFID)
        Me.Controls.Add(Me.dgvShortFallDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "vShortFalls"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Falls Details"
        CType(Me.dgvShortFallDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvShortFallDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblREFID As System.Windows.Forms.Label
    Friend WithEvents lblRefType As System.Windows.Forms.Label
    Friend WithEvents lblREF2 As System.Windows.Forms.Label
End Class
