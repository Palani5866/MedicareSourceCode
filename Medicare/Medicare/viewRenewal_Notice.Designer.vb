<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewRenewal_Notice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewRenewal_Notice))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblDate_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_From = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblDate_To = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_To = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnPrint = New System.Windows.Forms.ToolStripButton
        Me.dgvRenewal_Notice = New System.Windows.Forms.DataGridView
        Me.Print = New System.Windows.Forms.DataGridViewLinkColumn
        Me.lblRecordCount = New System.Windows.Forms.Label
        Me.lblRenewalUWID = New System.Windows.Forms.Label
        Me.tsReport.SuspendLayout()
        CType(Me.dgvRenewal_Notice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblDate_From, Me.tsReport_txtDate_From, Me.tsReport_lblDate_To, Me.tsReport_txtDate_To, Me.tsReport_Go, Me.tsReport_Div1, Me.tsbtnPrint})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(897, 25)
        Me.tsReport.TabIndex = 4
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblDate_From
        '
        Me.tsReport_lblDate_From.Name = "tsReport_lblDate_From"
        Me.tsReport_lblDate_From.Size = New System.Drawing.Size(172, 22)
        Me.tsReport_lblDate_From.Text = "Expiry Date - From (dd/mm/yyyy):"
        '
        'tsReport_txtDate_From
        '
        Me.tsReport_txtDate_From.MaxLength = 10
        Me.tsReport_txtDate_From.Name = "tsReport_txtDate_From"
        Me.tsReport_txtDate_From.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_lblDate_To
        '
        Me.tsReport_lblDate_To.Name = "tsReport_lblDate_To"
        Me.tsReport_lblDate_To.Size = New System.Drawing.Size(160, 22)
        Me.tsReport_lblDate_To.Text = "Expiry Date - To (dd/mm/yyyy):"
        '
        'tsReport_txtDate_To
        '
        Me.tsReport_txtDate_To.MaxLength = 10
        Me.tsReport_txtDate_To.Name = "tsReport_txtDate_To"
        Me.tsReport_txtDate_To.Size = New System.Drawing.Size(100, 25)
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
        'tsbtnPrint
        '
        Me.tsbtnPrint.Image = Global.Medicare.My.Resources.Resources._100
        Me.tsbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnPrint.Name = "tsbtnPrint"
        Me.tsbtnPrint.Size = New System.Drawing.Size(49, 22)
        Me.tsbtnPrint.Text = "Print"
        Me.tsbtnPrint.Visible = False
        '
        'dgvRenewal_Notice
        '
        Me.dgvRenewal_Notice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRenewal_Notice.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Print})
        Me.dgvRenewal_Notice.Location = New System.Drawing.Point(1, 28)
        Me.dgvRenewal_Notice.Name = "dgvRenewal_Notice"
        Me.dgvRenewal_Notice.Size = New System.Drawing.Size(896, 293)
        Me.dgvRenewal_Notice.TabIndex = 5
        '
        'Print
        '
        Me.Print.HeaderText = "Print"
        Me.Print.Name = "Print"
        Me.Print.Text = "Print"
        Me.Print.ToolTipText = "Print"
        Me.Print.UseColumnTextForLinkValue = True
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Location = New System.Drawing.Point(8, 334)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(58, 13)
        Me.lblRecordCount.TabIndex = 6
        Me.lblRecordCount.Text = "Record # :"
        '
        'lblRenewalUWID
        '
        Me.lblRenewalUWID.AutoSize = True
        Me.lblRenewalUWID.Location = New System.Drawing.Point(120, 334)
        Me.lblRenewalUWID.Name = "lblRenewalUWID"
        Me.lblRenewalUWID.Size = New System.Drawing.Size(18, 13)
        Me.lblRenewalUWID.TabIndex = 7
        Me.lblRenewalUWID.Text = "ID"
        Me.lblRenewalUWID.Visible = False
        '
        'viewRenewal_Notice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 356)
        Me.Controls.Add(Me.lblRenewalUWID)
        Me.Controls.Add(Me.lblRecordCount)
        Me.Controls.Add(Me.dgvRenewal_Notice)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "viewRenewal_Notice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Renewal Notice / UW"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvRenewal_Notice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblDate_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDate_From As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_lblDate_To As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDate_To As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvRenewal_Notice As System.Windows.Forms.DataGridView
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents lblRenewalUWID As System.Windows.Forms.Label
    Friend WithEvents Print As System.Windows.Forms.DataGridViewLinkColumn
End Class
