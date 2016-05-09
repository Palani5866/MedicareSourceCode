<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rShortFallSummaryDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rShortFallSummaryDetails))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.ssReport = New System.Windows.Forms.StatusStrip
        Me.ssReport_RecordCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ssReport_Parameter = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvShortfallDetails = New System.Windows.Forms.DataGridView
        Me.lblRTYPE = New System.Windows.Forms.Label
        Me.lblRTYPE1 = New System.Windows.Forms.Label
        Me.tolForm.SuspendLayout()
        Me.ssReport.SuspendLayout()
        CType(Me.dgvShortfallDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbExport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tolForm.Size = New System.Drawing.Size(949, 25)
        Me.tolForm.TabIndex = 3
        Me.tolForm.Text = "ToolStrip1"
        '
        'tsbExport2Xcel
        '
        Me.tsbExport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbExport2Xcel.Image = CType(resources.GetObject("tsbExport2Xcel.Image"), System.Drawing.Image)
        Me.tsbExport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExport2Xcel.Name = "tsbExport2Xcel"
        Me.tsbExport2Xcel.Size = New System.Drawing.Size(84, 22)
        Me.tsbExport2Xcel.Text = "Export to Excel"
        Me.tsbExport2Xcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ssReport
        '
        Me.ssReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssReport_RecordCount, Me.ssReport_Parameter})
        Me.ssReport.Location = New System.Drawing.Point(0, 451)
        Me.ssReport.Name = "ssReport"
        Me.ssReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssReport.Size = New System.Drawing.Size(949, 22)
        Me.ssReport.TabIndex = 8
        Me.ssReport.Text = "StatusStrip"
        '
        'ssReport_RecordCount
        '
        Me.ssReport_RecordCount.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ssReport_RecordCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ssReport_RecordCount.Name = "ssReport_RecordCount"
        Me.ssReport_RecordCount.Size = New System.Drawing.Size(4, 17)
        Me.ssReport_RecordCount.Visible = False
        '
        'ssReport_Parameter
        '
        Me.ssReport_Parameter.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ssReport_Parameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ssReport_Parameter.Name = "ssReport_Parameter"
        Me.ssReport_Parameter.Size = New System.Drawing.Size(4, 17)
        Me.ssReport_Parameter.Visible = False
        '
        'dgvShortfallDetails
        '
        Me.dgvShortfallDetails.AllowUserToAddRows = False
        Me.dgvShortfallDetails.AllowUserToDeleteRows = False
        Me.dgvShortfallDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortfallDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShortfallDetails.Location = New System.Drawing.Point(0, 25)
        Me.dgvShortfallDetails.Name = "dgvShortfallDetails"
        Me.dgvShortfallDetails.ReadOnly = True
        Me.dgvShortfallDetails.Size = New System.Drawing.Size(949, 426)
        Me.dgvShortfallDetails.TabIndex = 9
        '
        'lblRTYPE
        '
        Me.lblRTYPE.AutoSize = True
        Me.lblRTYPE.Location = New System.Drawing.Point(334, 153)
        Me.lblRTYPE.Name = "lblRTYPE"
        Me.lblRTYPE.Size = New System.Drawing.Size(43, 13)
        Me.lblRTYPE.TabIndex = 10
        Me.lblRTYPE.Text = "RTYPE"
        Me.lblRTYPE.Visible = False
        '
        'lblRTYPE1
        '
        Me.lblRTYPE1.AutoSize = True
        Me.lblRTYPE1.Location = New System.Drawing.Point(398, 153)
        Me.lblRTYPE1.Name = "lblRTYPE1"
        Me.lblRTYPE1.Size = New System.Drawing.Size(49, 13)
        Me.lblRTYPE1.TabIndex = 11
        Me.lblRTYPE1.Text = "RTYPE1"
        Me.lblRTYPE1.Visible = False
        '
        'rShortFallSummaryDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 473)
        Me.Controls.Add(Me.lblRTYPE1)
        Me.Controls.Add(Me.lblRTYPE)
        Me.Controls.Add(Me.dgvShortfallDetails)
        Me.Controls.Add(Me.ssReport)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "rShortFallSummaryDetails"
        Me.Text = "Shortfall Summary Details"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.ssReport.ResumeLayout(False)
        Me.ssReport.PerformLayout()
        CType(Me.dgvShortfallDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssReport As System.Windows.Forms.StatusStrip
    Friend WithEvents ssReport_RecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssReport_Parameter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvShortfallDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblRTYPE As System.Windows.Forms.Label
    Friend WithEvents lblRTYPE1 As System.Windows.Forms.Label
End Class
