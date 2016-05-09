<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdLog_Daily_Activities
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(grdLog_Daily_Activities))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_Export = New System.Windows.Forms.ToolStripButton
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_Export})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(584, 25)
        Me.tsReport.TabIndex = 2
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_Export
        '
        Me.tsReport_Export.Enabled = False
        Me.tsReport_Export.Image = CType(resources.GetObject("tsReport_Export.Image"), System.Drawing.Image)
        Me.tsReport_Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Export.Name = "tsReport_Export"
        Me.tsReport_Export.Size = New System.Drawing.Size(59, 22)
        Me.tsReport_Export.Text = "Export"
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
        Me.dgvForm.Size = New System.Drawing.Size(584, 539)
        Me.dgvForm.TabIndex = 3
        '
        'grdLog_Daily_Activities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 564)
        Me.Controls.Add(Me.dgvForm)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdLog_Daily_Activities"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log: Daily Activities"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_Export As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
End Class
