<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xRenewalListing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(xRenewalListing))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblDate_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_From = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblDate_To = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_To = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsReport_Xport = New System.Windows.Forms.ToolStripButton
        Me.dgvRenewal = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        CType(Me.dgvRenewal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblDate_From, Me.tsReport_txtDate_From, Me.tsReport_lblDate_To, Me.tsReport_txtDate_To, Me.tsReport_Go, Me.tsReport_Div1, Me.tsReport_Xport})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(908, 25)
        Me.tsReport.TabIndex = 3
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblDate_From
        '
        Me.tsReport_lblDate_From.Name = "tsReport_lblDate_From"
        Me.tsReport_lblDate_From.Size = New System.Drawing.Size(183, 22)
        Me.tsReport_lblDate_From.Text = "Renewal Date - From (dd/mm/yyyy):"
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
        Me.tsReport_lblDate_To.Size = New System.Drawing.Size(171, 22)
        Me.tsReport_lblDate_To.Text = "Renewal Date - To (dd/mm/yyyy):"
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
        'tsReport_Xport
        '
        Me.tsReport_Xport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsReport_Xport.Image = CType(resources.GetObject("tsReport_Xport.Image"), System.Drawing.Image)
        Me.tsReport_Xport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Xport.Name = "tsReport_Xport"
        Me.tsReport_Xport.Size = New System.Drawing.Size(84, 22)
        Me.tsReport_Xport.Text = "Export to Excel"
        '
        'dgvRenewal
        '
        Me.dgvRenewal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRenewal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRenewal.Location = New System.Drawing.Point(0, 25)
        Me.dgvRenewal.Name = "dgvRenewal"
        Me.dgvRenewal.Size = New System.Drawing.Size(908, 498)
        Me.dgvRenewal.TabIndex = 4
        '
        'xRenewalListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 523)
        Me.Controls.Add(Me.dgvRenewal)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "xRenewalListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Renewal Listing"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvRenewal, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvRenewal As System.Windows.Forms.DataGridView
    Friend WithEvents tsReport_Xport As System.Windows.Forms.ToolStripButton
End Class
