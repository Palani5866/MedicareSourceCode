<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rSummaryReports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rSummaryReports))
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.lblDateFrom = New System.Windows.Forms.ToolStripLabel
        Me.txtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.txtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvSummaryReport = New System.Windows.Forms.DataGridView
        Me.lblSTYPE = New System.Windows.Forms.Label
        Me.btnGo = New System.Windows.Forms.ToolStripButton
        Me.tsbtnPrint = New System.Windows.Forms.ToolStripButton
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TOTAL1 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTAL12 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTAL13 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTAL14 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTFNC = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsSearch.SuspendLayout()
        CType(Me.dgvSummaryReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDateFrom, Me.txtDateFrom, Me.ToolStripLabel, Me.txtDateTo, Me.btnGo, Me.tsReport_Div1, Me.tsbtnPrint, Me.btnXPort})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(940, 25)
        Me.tsSearch.TabIndex = 7
        Me.tsSearch.Text = "ToolStrip"
        '
        'lblDateFrom
        '
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(154, 22)
        Me.lblDateFrom.Text = "Date - From (dd/mm/yyyy):"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.MaxLength = 10
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripLabel
        '
        Me.ToolStripLabel.Name = "ToolStripLabel"
        Me.ToolStripLabel.Size = New System.Drawing.Size(140, 22)
        Me.ToolStripLabel.Text = "Date - To (dd/mm/yyyy):"
        '
        'txtDateTo
        '
        Me.txtDateTo.MaxLength = 10
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'dgvSummaryReport
        '
        Me.dgvSummaryReport.AllowUserToAddRows = False
        Me.dgvSummaryReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSummaryReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TOTAL, Me.TOTAL1, Me.TOTAL12, Me.TOTAL13, Me.TOTAL14, Me.TOTFNC})
        Me.dgvSummaryReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSummaryReport.Location = New System.Drawing.Point(0, 25)
        Me.dgvSummaryReport.Name = "dgvSummaryReport"
        Me.dgvSummaryReport.Size = New System.Drawing.Size(940, 352)
        Me.dgvSummaryReport.TabIndex = 8
        '
        'lblSTYPE
        '
        Me.lblSTYPE.AutoSize = True
        Me.lblSTYPE.Location = New System.Drawing.Point(596, 98)
        Me.lblSTYPE.Name = "lblSTYPE"
        Me.lblSTYPE.Size = New System.Drawing.Size(42, 13)
        Me.lblSTYPE.TabIndex = 9
        Me.lblSTYPE.Text = "STYPE"
        Me.lblSTYPE.Visible = False
        '
        'btnGo
        '
        Me.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(26, 22)
        Me.btnGo.Text = "Go"
        '
        'tsbtnPrint
        '
        Me.tsbtnPrint.Image = Global.Medicare.My.Resources.Resources._100
        Me.tsbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnPrint.Name = "tsbtnPrint"
        Me.tsbtnPrint.Size = New System.Drawing.Size(52, 22)
        Me.tsbtnPrint.Text = "Print"
        Me.tsbtnPrint.Visible = False
        '
        'btnXPort
        '
        Me.btnXPort.Image = CType(resources.GetObject("btnXPort.Image"), System.Drawing.Image)
        Me.btnXPort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnXPort.Name = "btnXPort"
        Me.btnXPort.Size = New System.Drawing.Size(60, 22)
        Me.btnXPort.Text = "Export"
        '
        'TOTAL
        '
        Me.TOTAL.DataPropertyName = "TOTAL"
        Me.TOTAL.HeaderText = "TOTAL"
        Me.TOTAL.Name = "TOTAL"
        Me.TOTAL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TOTAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TOTAL1
        '
        Me.TOTAL1.DataPropertyName = "TOTAL1"
        Me.TOTAL1.HeaderText = "TOTAL FOLLOWUP"
        Me.TOTAL1.Name = "TOTAL1"
        '
        'TOTAL12
        '
        Me.TOTAL12.DataPropertyName = "TOTAL12"
        Me.TOTAL12.HeaderText = "TOTAL NOT FOLLOWUP"
        Me.TOTAL12.Name = "TOTAL12"
        '
        'TOTAL13
        '
        Me.TOTAL13.DataPropertyName = "TOTAL13"
        Me.TOTAL13.HeaderText = "TOTAL  SELF CLOSED"
        Me.TOTAL13.Name = "TOTAL13"
        '
        'TOTAL14
        '
        Me.TOTAL14.DataPropertyName = "TOTAL14"
        Me.TOTAL14.HeaderText = "TOTAL FOLLOWUP  CLOSED"
        Me.TOTAL14.Name = "TOTAL14"
        '
        'TOTFNC
        '
        Me.TOTFNC.DataPropertyName = "TOTAL15"
        Me.TOTFNC.HeaderText = "TOTAL FOLLOWUP NOT CLOSED"
        Me.TOTFNC.Name = "TOTFNC"
        Me.TOTFNC.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TOTFNC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'rSummaryReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 377)
        Me.Controls.Add(Me.lblSTYPE)
        Me.Controls.Add(Me.dgvSummaryReport)
        Me.Controls.Add(Me.tsSearch)
        Me.Name = "rSummaryReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Summary Reports"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        CType(Me.dgvSummaryReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDateFrom As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtDateFrom As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtDateTo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnXPort As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvSummaryReport As System.Windows.Forms.DataGridView
    Friend WithEvents lblSTYPE As System.Windows.Forms.Label
    Friend WithEvents TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTAL1 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTAL12 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTAL13 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTAL14 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTFNC As System.Windows.Forms.DataGridViewLinkColumn
End Class
