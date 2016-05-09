<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fViewDetails
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
        Me.dgvVD = New System.Windows.Forms.DataGridView
        Me.lblP1 = New System.Windows.Forms.Label
        Me.lblP2 = New System.Windows.Forms.Label
        Me.lblREFTYPE = New System.Windows.Forms.Label
        Me.lblP3 = New System.Windows.Forms.Label
        CType(Me.dgvVD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvVD
        '
        Me.dgvVD.AllowUserToAddRows = False
        Me.dgvVD.AllowUserToDeleteRows = False
        Me.dgvVD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVD.Location = New System.Drawing.Point(0, 0)
        Me.dgvVD.Name = "dgvVD"
        Me.dgvVD.ReadOnly = True
        Me.dgvVD.Size = New System.Drawing.Size(901, 360)
        Me.dgvVD.TabIndex = 0
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(429, 123)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 1
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'lblP2
        '
        Me.lblP2.AutoSize = True
        Me.lblP2.Location = New System.Drawing.Point(440, 174)
        Me.lblP2.Name = "lblP2"
        Me.lblP2.Size = New System.Drawing.Size(20, 13)
        Me.lblP2.TabIndex = 2
        Me.lblP2.Text = "P2"
        Me.lblP2.Visible = False
        '
        'lblREFTYPE
        '
        Me.lblREFTYPE.AutoSize = True
        Me.lblREFTYPE.Location = New System.Drawing.Point(448, 182)
        Me.lblREFTYPE.Name = "lblREFTYPE"
        Me.lblREFTYPE.Size = New System.Drawing.Size(56, 13)
        Me.lblREFTYPE.TabIndex = 3
        Me.lblREFTYPE.Text = "REFTYPE"
        Me.lblREFTYPE.Visible = False
        '
        'lblP3
        '
        Me.lblP3.AutoSize = True
        Me.lblP3.Location = New System.Drawing.Point(524, 123)
        Me.lblP3.Name = "lblP3"
        Me.lblP3.Size = New System.Drawing.Size(20, 13)
        Me.lblP3.TabIndex = 4
        Me.lblP3.Text = "P3"
        Me.lblP3.Visible = False
        '
        'fViewDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 360)
        Me.Controls.Add(Me.lblP3)
        Me.Controls.Add(Me.lblREFTYPE)
        Me.Controls.Add(Me.lblP2)
        Me.Controls.Add(Me.lblP1)
        Me.Controls.Add(Me.dgvVD)
        Me.Name = "fViewDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Details"
        CType(Me.dgvVD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvVD As System.Windows.Forms.DataGridView
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents lblP2 As System.Windows.Forms.Label
    Friend WithEvents lblREFTYPE As System.Windows.Forms.Label
    Friend WithEvents lblP3 As System.Windows.Forms.Label
End Class
