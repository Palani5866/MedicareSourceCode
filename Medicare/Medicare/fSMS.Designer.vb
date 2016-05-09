<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSMS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fSMS))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslblBatchNo = New System.Windows.Forms.ToolStripLabel
        Me.tsddlBatchNo = New System.Windows.Forms.ToolStripComboBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvSMS = New System.Windows.Forms.DataGridView
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Upload = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Download = New System.Windows.Forms.DataGridViewButtonColumn
        Me.lblRF1 = New System.Windows.Forms.Label
        Me.lblRF2 = New System.Windows.Forms.Label
        Me.tsReport.SuspendLayout()
        CType(Me.dgvSMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblBatchNo, Me.tsddlBatchNo, Me.tsReport_Go, Me.tsReport_Div1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(587, 25)
        Me.tsReport.TabIndex = 3
        Me.tsReport.Text = "ToolStrip"
        '
        'tslblBatchNo
        '
        Me.tslblBatchNo.Name = "tslblBatchNo"
        Me.tslblBatchNo.Size = New System.Drawing.Size(57, 22)
        Me.tslblBatchNo.Text = "Batch No :"
        '
        'tsddlBatchNo
        '
        Me.tsddlBatchNo.Name = "tsddlBatchNo"
        Me.tsddlBatchNo.Size = New System.Drawing.Size(125, 25)
        '
        'tsReport_Go
        '
        Me.tsReport_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsReport_Go.Image = CType(resources.GetObject("tsReport_Go.Image"), System.Drawing.Image)
        Me.tsReport_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Go.Name = "tsReport_Go"
        Me.tsReport_Go.Size = New System.Drawing.Size(24, 22)
        Me.tsReport_Go.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'dgvSMS
        '
        Me.dgvSMS.AllowUserToAddRows = False
        Me.dgvSMS.AllowUserToDeleteRows = False
        Me.dgvSMS.AllowUserToOrderColumns = True
        Me.dgvSMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSMS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.View, Me.Upload, Me.Download})
        Me.dgvSMS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSMS.Location = New System.Drawing.Point(0, 25)
        Me.dgvSMS.Name = "dgvSMS"
        Me.dgvSMS.Size = New System.Drawing.Size(587, 204)
        Me.dgvSMS.TabIndex = 4
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.Text = "View"
        Me.View.ToolTipText = "View"
        Me.View.UseColumnTextForLinkValue = True
        '
        'Upload
        '
        Me.Upload.HeaderText = "Upload Request File"
        Me.Upload.Name = "Upload"
        Me.Upload.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Upload.Text = "Upload"
        Me.Upload.ToolTipText = "Upload"
        Me.Upload.UseColumnTextForLinkValue = True
        '
        'Download
        '
        Me.Download.HeaderText = "Download File"
        Me.Download.Name = "Download"
        Me.Download.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Download.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Download.Text = "Download"
        Me.Download.ToolTipText = "Download"
        Me.Download.UseColumnTextForButtonValue = True
        '
        'lblRF1
        '
        Me.lblRF1.AutoSize = True
        Me.lblRF1.Location = New System.Drawing.Point(548, 207)
        Me.lblRF1.Name = "lblRF1"
        Me.lblRF1.Size = New System.Drawing.Size(27, 13)
        Me.lblRF1.TabIndex = 5
        Me.lblRF1.Text = "RF1"
        Me.lblRF1.Visible = False
        '
        'lblRF2
        '
        Me.lblRF2.AutoSize = True
        Me.lblRF2.Location = New System.Drawing.Point(515, 207)
        Me.lblRF2.Name = "lblRF2"
        Me.lblRF2.Size = New System.Drawing.Size(27, 13)
        Me.lblRF2.TabIndex = 8
        Me.lblRF2.Text = "RF2"
        Me.lblRF2.Visible = False
        '
        'fSMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 229)
        Me.Controls.Add(Me.lblRF2)
        Me.Controls.Add(Me.lblRF1)
        Me.Controls.Add(Me.dgvSMS)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fSMS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SMS Send Confirmation Details"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvSMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblBatchNo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsddlBatchNo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvSMS As System.Windows.Forms.DataGridView
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Upload As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Download As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lblRF1 As System.Windows.Forms.Label
    Friend WithEvents lblRF2 As System.Windows.Forms.Label
End Class
