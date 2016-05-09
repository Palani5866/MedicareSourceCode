<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSummaryDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSummaryDetails))
        Me.lblP1 = New System.Windows.Forms.Label
        Me.lblP2 = New System.Windows.Forms.Label
        Me.lblP3 = New System.Windows.Forms.Label
        Me.lblP4 = New System.Windows.Forms.Label
        Me.lblP5 = New System.Windows.Forms.Label
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.tsS = New System.Windows.Forms.ToolStripSeparator
        Me.tslblRCount = New System.Windows.Forms.ToolStripLabel
        Me.dgvSummaryDetails = New System.Windows.Forms.DataGridView
        Me.lblRTYPE = New System.Windows.Forms.Label
        Me.tolForm.SuspendLayout()
        CType(Me.dgvSummaryDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(484, 171)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 1
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'lblP2
        '
        Me.lblP2.AutoSize = True
        Me.lblP2.Location = New System.Drawing.Point(484, 208)
        Me.lblP2.Name = "lblP2"
        Me.lblP2.Size = New System.Drawing.Size(20, 13)
        Me.lblP2.TabIndex = 2
        Me.lblP2.Text = "P2"
        Me.lblP2.Visible = False
        '
        'lblP3
        '
        Me.lblP3.AutoSize = True
        Me.lblP3.Location = New System.Drawing.Point(484, 238)
        Me.lblP3.Name = "lblP3"
        Me.lblP3.Size = New System.Drawing.Size(20, 13)
        Me.lblP3.TabIndex = 3
        Me.lblP3.Text = "P3"
        Me.lblP3.Visible = False
        '
        'lblP4
        '
        Me.lblP4.AutoSize = True
        Me.lblP4.Location = New System.Drawing.Point(484, 271)
        Me.lblP4.Name = "lblP4"
        Me.lblP4.Size = New System.Drawing.Size(20, 13)
        Me.lblP4.TabIndex = 4
        Me.lblP4.Text = "P4"
        Me.lblP4.Visible = False
        '
        'lblP5
        '
        Me.lblP5.AutoSize = True
        Me.lblP5.Location = New System.Drawing.Point(484, 305)
        Me.lblP5.Name = "lblP5"
        Me.lblP5.Size = New System.Drawing.Size(20, 13)
        Me.lblP5.TabIndex = 5
        Me.lblP5.Text = "P5"
        Me.lblP5.Visible = False
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbExport2Xcel, Me.tsS, Me.tslblRCount})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tolForm.Size = New System.Drawing.Size(989, 25)
        Me.tolForm.TabIndex = 6
        Me.tolForm.Text = "ToolStrip1"
        '
        'tsbExport2Xcel
        '
        Me.tsbExport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbExport2Xcel.Image = CType(resources.GetObject("tsbExport2Xcel.Image"), System.Drawing.Image)
        Me.tsbExport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExport2Xcel.Name = "tsbExport2Xcel"
        Me.tsbExport2Xcel.Size = New System.Drawing.Size(87, 22)
        Me.tsbExport2Xcel.Text = "Export to Excel"
        Me.tsbExport2Xcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tsS
        '
        Me.tsS.Name = "tsS"
        Me.tsS.Size = New System.Drawing.Size(6, 25)
        '
        'tslblRCount
        '
        Me.tslblRCount.Name = "tslblRCount"
        Me.tslblRCount.Size = New System.Drawing.Size(94, 22)
        Me.tslblRCount.Text = "Total Records : 0"
        '
        'dgvSummaryDetails
        '
        Me.dgvSummaryDetails.AllowUserToAddRows = False
        Me.dgvSummaryDetails.AllowUserToDeleteRows = False
        Me.dgvSummaryDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSummaryDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSummaryDetails.Location = New System.Drawing.Point(0, 25)
        Me.dgvSummaryDetails.Name = "dgvSummaryDetails"
        Me.dgvSummaryDetails.Size = New System.Drawing.Size(989, 403)
        Me.dgvSummaryDetails.TabIndex = 7
        '
        'lblRTYPE
        '
        Me.lblRTYPE.Location = New System.Drawing.Point(421, 135)
        Me.lblRTYPE.Name = "lblRTYPE"
        Me.lblRTYPE.Size = New System.Drawing.Size(39, 13)
        Me.lblRTYPE.TabIndex = 0
        Me.lblRTYPE.Text = "RTYPE"
        Me.lblRTYPE.Visible = False
        '
        'frmSummaryDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 428)
        Me.Controls.Add(Me.lblRTYPE)
        Me.Controls.Add(Me.dgvSummaryDetails)
        Me.Controls.Add(Me.tolForm)
        Me.Controls.Add(Me.lblP5)
        Me.Controls.Add(Me.lblP4)
        Me.Controls.Add(Me.lblP3)
        Me.Controls.Add(Me.lblP2)
        Me.Controls.Add(Me.lblP1)
        Me.Name = "frmSummaryDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Summary Details"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvSummaryDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents lblP2 As System.Windows.Forms.Label
    Friend WithEvents lblP3 As System.Windows.Forms.Label
    Friend WithEvents lblP4 As System.Windows.Forms.Label
    Friend WithEvents lblP5 As System.Windows.Forms.Label
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsS As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslblRCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dgvSummaryDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblRTYPE As System.Windows.Forms.Label
End Class
