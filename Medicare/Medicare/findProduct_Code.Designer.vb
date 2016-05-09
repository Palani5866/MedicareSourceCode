<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class findProduct_Code
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
        Me.dgvProductDetails = New System.Windows.Forms.DataGridView
        Me.lblREF1 = New System.Windows.Forms.Label
        CType(Me.dgvProductDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvProductDetails
        '
        Me.dgvProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvProductDetails.Name = "dgvProductDetails"
        Me.dgvProductDetails.Size = New System.Drawing.Size(506, 494)
        Me.dgvProductDetails.TabIndex = 0
        '
        'lblREF1
        '
        Me.lblREF1.AutoSize = True
        Me.lblREF1.Location = New System.Drawing.Point(312, 228)
        Me.lblREF1.Name = "lblREF1"
        Me.lblREF1.Size = New System.Drawing.Size(34, 13)
        Me.lblREF1.TabIndex = 1
        Me.lblREF1.Text = "REF1"
        Me.lblREF1.Visible = False
        '
        'findProduct_Code
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 494)
        Me.Controls.Add(Me.lblREF1)
        Me.Controls.Add(Me.dgvProductDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "findProduct_Code"
        Me.Text = "findProduct_Code"
        CType(Me.dgvProductDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProductDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblREF1 As System.Windows.Forms.Label
End Class
