<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdBorang2_79
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(grdBorang2_79))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsbXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.tolForm.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbXport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tolForm.Size = New System.Drawing.Size(784, 25)
        Me.tolForm.TabIndex = 7
        Me.tolForm.Text = "ToolStrip1"
        '
        'tsbXport2Xcel
        '
        Me.tsbXport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbXport2Xcel.Image = CType(resources.GetObject("tsbXport2Xcel.Image"), System.Drawing.Image)
        Me.tsbXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbXport2Xcel.Name = "tsbXport2Xcel"
        Me.tsbXport2Xcel.Size = New System.Drawing.Size(87, 22)
        Me.tsbXport2Xcel.Text = "Export to Excel "
        '
        'dgvForm
        '
        Me.dgvForm.AllowUserToAddRows = False
        Me.dgvForm.AllowUserToDeleteRows = False
        Me.dgvForm.AllowUserToOrderColumns = True
        Me.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvForm.Location = New System.Drawing.Point(0, 25)
        Me.dgvForm.MultiSelect = False
        Me.dgvForm.Name = "dgvForm"
        Me.dgvForm.ReadOnly = True
        Me.dgvForm.Size = New System.Drawing.Size(784, 539)
        Me.dgvForm.TabIndex = 8
        '
        'grdBorang2_79
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.tolForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdBorang2_79"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Borang 2/79 List"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbXport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
End Class
