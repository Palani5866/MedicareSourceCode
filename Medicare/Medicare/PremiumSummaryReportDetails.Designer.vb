<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PremiumSummaryReportDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PremiumSummaryReportDetails))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsbtnExporttoExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvPSRDetails = New System.Windows.Forms.DataGridView
        Me.lblP1 = New System.Windows.Forms.Label
        Me.lblP2 = New System.Windows.Forms.Label
        Me.lblP3 = New System.Windows.Forms.Label
        Me.lblP4 = New System.Windows.Forms.Label
        Me.lblP5 = New System.Windows.Forms.Label
        Me.tslblTotalRecords = New System.Windows.Forms.ToolStripLabel
        Me.tsReport.SuspendLayout()
        CType(Me.dgvPSRDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnExporttoExcel, Me.ToolStripSeparator1, Me.tslblTotalRecords})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsReport.Size = New System.Drawing.Size(1108, 25)
        Me.tsReport.TabIndex = 16
        Me.tsReport.Text = "ToolStrip"
        '
        'tsbtnExporttoExcel
        '
        Me.tsbtnExporttoExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnExporttoExcel.Image = CType(resources.GetObject("tsbtnExporttoExcel.Image"), System.Drawing.Image)
        Me.tsbtnExporttoExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExporttoExcel.Name = "tsbtnExporttoExcel"
        Me.tsbtnExporttoExcel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsbtnExporttoExcel.Size = New System.Drawing.Size(84, 22)
        Me.tsbtnExporttoExcel.Text = "Export to Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'dgvPSRDetails
        '
        Me.dgvPSRDetails.AllowUserToAddRows = False
        Me.dgvPSRDetails.AllowUserToDeleteRows = False
        Me.dgvPSRDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPSRDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPSRDetails.Location = New System.Drawing.Point(0, 25)
        Me.dgvPSRDetails.Name = "dgvPSRDetails"
        Me.dgvPSRDetails.ReadOnly = True
        Me.dgvPSRDetails.Size = New System.Drawing.Size(1108, 485)
        Me.dgvPSRDetails.TabIndex = 17
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(296, 85)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 18
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'lblP2
        '
        Me.lblP2.AutoSize = True
        Me.lblP2.Location = New System.Drawing.Point(322, 85)
        Me.lblP2.Name = "lblP2"
        Me.lblP2.Size = New System.Drawing.Size(20, 13)
        Me.lblP2.TabIndex = 19
        Me.lblP2.Text = "P2"
        Me.lblP2.Visible = False
        '
        'lblP3
        '
        Me.lblP3.AutoSize = True
        Me.lblP3.Location = New System.Drawing.Point(348, 85)
        Me.lblP3.Name = "lblP3"
        Me.lblP3.Size = New System.Drawing.Size(20, 13)
        Me.lblP3.TabIndex = 20
        Me.lblP3.Text = "P3"
        Me.lblP3.Visible = False
        '
        'lblP4
        '
        Me.lblP4.AutoSize = True
        Me.lblP4.Location = New System.Drawing.Point(374, 85)
        Me.lblP4.Name = "lblP4"
        Me.lblP4.Size = New System.Drawing.Size(20, 13)
        Me.lblP4.TabIndex = 21
        Me.lblP4.Text = "P4"
        Me.lblP4.Visible = False
        '
        'lblP5
        '
        Me.lblP5.AutoSize = True
        Me.lblP5.Location = New System.Drawing.Point(400, 85)
        Me.lblP5.Name = "lblP5"
        Me.lblP5.Size = New System.Drawing.Size(20, 13)
        Me.lblP5.TabIndex = 22
        Me.lblP5.Text = "P5"
        Me.lblP5.Visible = False
        '
        'tslblTotalRecords
        '
        Me.tslblTotalRecords.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.tslblTotalRecords.ForeColor = System.Drawing.Color.Blue
        Me.tslblTotalRecords.Name = "tslblTotalRecords"
        Me.tslblTotalRecords.Size = New System.Drawing.Size(85, 22)
        Me.tslblTotalRecords.Text = "Total Records"
        '
        'PremiumSummaryReportDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1108, 510)
        Me.Controls.Add(Me.lblP5)
        Me.Controls.Add(Me.lblP4)
        Me.Controls.Add(Me.lblP3)
        Me.Controls.Add(Me.lblP2)
        Me.Controls.Add(Me.lblP1)
        Me.Controls.Add(Me.dgvPSRDetails)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "PremiumSummaryReportDetails"
        Me.Text = "Premium Summary Report Details"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvPSRDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnExporttoExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvPSRDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents lblP2 As System.Windows.Forms.Label
    Friend WithEvents lblP3 As System.Windows.Forms.Label
    Friend WithEvents lblP4 As System.Windows.Forms.Label
    Friend WithEvents lblP5 As System.Windows.Forms.Label
    Friend WithEvents tslblTotalRecords As System.Windows.Forms.ToolStripLabel
End Class
