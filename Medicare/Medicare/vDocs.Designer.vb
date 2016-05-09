<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vDocs
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
        Me.dgvDocView = New System.Windows.Forms.DataGridView
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.lblP1 = New System.Windows.Forms.Label
        CType(Me.dgvDocView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDocView
        '
        Me.dgvDocView.AllowUserToAddRows = False
        Me.dgvDocView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.View})
        Me.dgvDocView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDocView.Location = New System.Drawing.Point(0, 0)
        Me.dgvDocView.Name = "dgvDocView"
        Me.dgvDocView.Size = New System.Drawing.Size(609, 183)
        Me.dgvDocView.TabIndex = 0
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.Text = "View"
        Me.View.ToolTipText = "View"
        Me.View.UseColumnTextForLinkValue = True
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(369, 53)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 1
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'vDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 183)
        Me.Controls.Add(Me.lblP1)
        Me.Controls.Add(Me.dgvDocView)
        Me.Name = "vDocs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Documents"
        CType(Me.dgvDocView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDocView As System.Windows.Forms.DataGridView
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents lblP1 As System.Windows.Forms.Label
End Class
