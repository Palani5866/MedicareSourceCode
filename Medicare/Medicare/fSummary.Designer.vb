<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fSummary))
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.lblDateFrom = New System.Windows.Forms.ToolStripLabel
        Me.txtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.txtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.btnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnPrint = New System.Windows.Forms.ToolStripButton
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.lblP5 = New System.Windows.Forms.Label
        Me.lblP4 = New System.Windows.Forms.Label
        Me.lblP3 = New System.Windows.Forms.Label
        Me.lblP2 = New System.Windows.Forms.Label
        Me.lblP1 = New System.Windows.Forms.Label
        Me.dgvSummary = New System.Windows.Forms.DataGridView
        Me.TOTAL = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTAL1D = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTAL1DFUP = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT1DNFUP = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTAL1DFUPC = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTAL1U = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTAL1UFUP = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOT1UNFUP = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTALIUFUPC = New System.Windows.Forms.DataGridViewLinkColumn
        Me.dgvMFS = New System.Windows.Forms.DataGridView
        Me.DataGridViewLinkColumn1 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn2 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn3 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn4 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.DataGridViewLinkColumn5 = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsSearch.SuspendLayout()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMFS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDateFrom, Me.txtDateFrom, Me.ToolStripLabel, Me.txtDateTo, Me.btnGo, Me.tsReport_Div1, Me.tsbtnPrint, Me.btnXPort})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(967, 25)
        Me.tsSearch.TabIndex = 6
        Me.tsSearch.Text = "ToolStrip"
        '
        'lblDateFrom
        '
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(139, 22)
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
        Me.ToolStripLabel.Size = New System.Drawing.Size(127, 22)
        Me.ToolStripLabel.Text = "Date - To (dd/mm/yyyy):"
        '
        'txtDateTo
        '
        Me.txtDateTo.MaxLength = 10
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(100, 25)
        '
        'btnGo
        '
        Me.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(24, 22)
        Me.btnGo.Text = "Go"
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
        'btnXPort
        '
        Me.btnXPort.Image = CType(resources.GetObject("btnXPort.Image"), System.Drawing.Image)
        Me.btnXPort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnXPort.Name = "btnXPort"
        Me.btnXPort.Size = New System.Drawing.Size(59, 22)
        Me.btnXPort.Text = "Export"
        '
        'lblP5
        '
        Me.lblP5.AutoSize = True
        Me.lblP5.Location = New System.Drawing.Point(877, 493)
        Me.lblP5.Name = "lblP5"
        Me.lblP5.Size = New System.Drawing.Size(20, 13)
        Me.lblP5.TabIndex = 13
        Me.lblP5.Text = "P5"
        Me.lblP5.Visible = False
        '
        'lblP4
        '
        Me.lblP4.AutoSize = True
        Me.lblP4.Location = New System.Drawing.Point(851, 493)
        Me.lblP4.Name = "lblP4"
        Me.lblP4.Size = New System.Drawing.Size(20, 13)
        Me.lblP4.TabIndex = 12
        Me.lblP4.Text = "P4"
        Me.lblP4.Visible = False
        '
        'lblP3
        '
        Me.lblP3.AutoSize = True
        Me.lblP3.Location = New System.Drawing.Point(825, 493)
        Me.lblP3.Name = "lblP3"
        Me.lblP3.Size = New System.Drawing.Size(20, 13)
        Me.lblP3.TabIndex = 11
        Me.lblP3.Text = "P3"
        Me.lblP3.Visible = False
        '
        'lblP2
        '
        Me.lblP2.AutoSize = True
        Me.lblP2.Location = New System.Drawing.Point(799, 493)
        Me.lblP2.Name = "lblP2"
        Me.lblP2.Size = New System.Drawing.Size(20, 13)
        Me.lblP2.TabIndex = 10
        Me.lblP2.Text = "P2"
        Me.lblP2.Visible = False
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(773, 493)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 9
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'dgvSummary
        '
        Me.dgvSummary.AllowUserToAddRows = False
        Me.dgvSummary.AllowUserToDeleteRows = False
        Me.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSummary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TOTAL, Me.TOTAL1D, Me.TOTAL1DFUP, Me.TOT1DNFUP, Me.TOTAL1DFUPC, Me.TOTAL1U, Me.TOTAL1UFUP, Me.TOT1UNFUP, Me.TOTALIUFUPC})
        Me.dgvSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSummary.Location = New System.Drawing.Point(0, 25)
        Me.dgvSummary.Name = "dgvSummary"
        Me.dgvSummary.ReadOnly = True
        Me.dgvSummary.Size = New System.Drawing.Size(967, 490)
        Me.dgvSummary.TabIndex = 8
        '
        'TOTAL
        '
        Me.TOTAL.DataPropertyName = "TOTAL"
        Me.TOTAL.HeaderText = "TOTAL"
        Me.TOTAL.Name = "TOTAL"
        Me.TOTAL.ReadOnly = True
        Me.TOTAL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TOTAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TOTAL1D
        '
        Me.TOTAL1D.DataPropertyName = "TOT1D"
        Me.TOTAL1D.HeaderText = "TOTAL INCOMPLETE"
        Me.TOTAL1D.Name = "TOTAL1D"
        Me.TOTAL1D.ReadOnly = True
        '
        'TOTAL1DFUP
        '
        Me.TOTAL1DFUP.DataPropertyName = "TOT1DFUP"
        Me.TOTAL1DFUP.HeaderText = "TOTAL INCOMPLETE FOLLOWUP"
        Me.TOTAL1DFUP.Name = "TOTAL1DFUP"
        Me.TOTAL1DFUP.ReadOnly = True
        '
        'TOT1DNFUP
        '
        Me.TOT1DNFUP.DataPropertyName = "TOT1DNFUP"
        Me.TOT1DNFUP.HeaderText = "TOTAL INCOMPLETE NOT FOLLOWUP"
        Me.TOT1DNFUP.Name = "TOT1DNFUP"
        Me.TOT1DNFUP.ReadOnly = True
        Me.TOT1DNFUP.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TOT1DNFUP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TOTAL1DFUPC
        '
        Me.TOTAL1DFUPC.DataPropertyName = "TOT1DFUPC"
        Me.TOTAL1DFUPC.HeaderText = "TOTAL FOLLOWUP CLOSED"
        Me.TOTAL1DFUPC.Name = "TOTAL1DFUPC"
        Me.TOTAL1DFUPC.ReadOnly = True
        '
        'TOTAL1U
        '
        Me.TOTAL1U.DataPropertyName = "TOT1U"
        Me.TOTAL1U.HeaderText = "TOTAL UW"
        Me.TOTAL1U.Name = "TOTAL1U"
        Me.TOTAL1U.ReadOnly = True
        '
        'TOTAL1UFUP
        '
        Me.TOTAL1UFUP.DataPropertyName = "TOT1UFUP"
        Me.TOTAL1UFUP.HeaderText = "TOTAL UW FOLLOWUP"
        Me.TOTAL1UFUP.Name = "TOTAL1UFUP"
        Me.TOTAL1UFUP.ReadOnly = True
        '
        'TOT1UNFUP
        '
        Me.TOT1UNFUP.DataPropertyName = "TOT1UNFUP"
        Me.TOT1UNFUP.HeaderText = "TOTAL UW NOT FOLLOWUP"
        Me.TOT1UNFUP.Name = "TOT1UNFUP"
        Me.TOT1UNFUP.ReadOnly = True
        Me.TOT1UNFUP.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TOT1UNFUP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TOTALIUFUPC
        '
        Me.TOTALIUFUPC.DataPropertyName = "TOT1UFUPC"
        Me.TOTALIUFUPC.HeaderText = "TOTAL UW FOLLOWUP CLOSED"
        Me.TOTALIUFUPC.Name = "TOTALIUFUPC"
        Me.TOTALIUFUPC.ReadOnly = True
        '
        'dgvMFS
        '
        Me.dgvMFS.AllowUserToAddRows = False
        Me.dgvMFS.AllowUserToDeleteRows = False
        Me.dgvMFS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMFS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewLinkColumn1, Me.DataGridViewLinkColumn2, Me.DataGridViewLinkColumn3, Me.DataGridViewLinkColumn4, Me.DataGridViewLinkColumn5})
        Me.dgvMFS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMFS.Location = New System.Drawing.Point(0, 25)
        Me.dgvMFS.Name = "dgvMFS"
        Me.dgvMFS.ReadOnly = True
        Me.dgvMFS.Size = New System.Drawing.Size(967, 490)
        Me.dgvMFS.TabIndex = 14
        '
        'DataGridViewLinkColumn1
        '
        Me.DataGridViewLinkColumn1.DataPropertyName = "TOTAL"
        Me.DataGridViewLinkColumn1.HeaderText = "TOTAL"
        Me.DataGridViewLinkColumn1.Name = "DataGridViewLinkColumn1"
        Me.DataGridViewLinkColumn1.ReadOnly = True
        Me.DataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewLinkColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewLinkColumn2
        '
        Me.DataGridViewLinkColumn2.DataPropertyName = "TOTPRFUP"
        Me.DataGridViewLinkColumn2.HeaderText = "TOTAL PENDING RENEWAL FOLLOW UP"
        Me.DataGridViewLinkColumn2.Name = "DataGridViewLinkColumn2"
        Me.DataGridViewLinkColumn2.ReadOnly = True
        '
        'DataGridViewLinkColumn3
        '
        Me.DataGridViewLinkColumn3.DataPropertyName = "TOTPRNFUP"
        Me.DataGridViewLinkColumn3.HeaderText = "TOTAL PENDING RENEWAL NOT FOLLOW UP"
        Me.DataGridViewLinkColumn3.Name = "DataGridViewLinkColumn3"
        Me.DataGridViewLinkColumn3.ReadOnly = True
        '
        'DataGridViewLinkColumn4
        '
        Me.DataGridViewLinkColumn4.DataPropertyName = "TOTPRFUPSC"
        Me.DataGridViewLinkColumn4.HeaderText = "PENDING RENEWAL FOLLOW UP SUCCESSFUL CLOSED"
        Me.DataGridViewLinkColumn4.Name = "DataGridViewLinkColumn4"
        Me.DataGridViewLinkColumn4.ReadOnly = True
        Me.DataGridViewLinkColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewLinkColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewLinkColumn5
        '
        Me.DataGridViewLinkColumn5.DataPropertyName = "TOTPRFUPNSC"
        Me.DataGridViewLinkColumn5.HeaderText = "PENDING RENEWAL FOLLOW UP UNSUCCESSFUL CLOSED"
        Me.DataGridViewLinkColumn5.Name = "DataGridViewLinkColumn5"
        Me.DataGridViewLinkColumn5.ReadOnly = True
        '
        'fSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 515)
        Me.Controls.Add(Me.dgvMFS)
        Me.Controls.Add(Me.lblP5)
        Me.Controls.Add(Me.lblP4)
        Me.Controls.Add(Me.lblP3)
        Me.Controls.Add(Me.lblP2)
        Me.Controls.Add(Me.lblP1)
        Me.Controls.Add(Me.dgvSummary)
        Me.Controls.Add(Me.tsSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Follow up Summary"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMFS, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblP5 As System.Windows.Forms.Label
    Friend WithEvents lblP4 As System.Windows.Forms.Label
    Friend WithEvents lblP3 As System.Windows.Forms.Label
    Friend WithEvents lblP2 As System.Windows.Forms.Label
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents dgvSummary As System.Windows.Forms.DataGridView
    Friend WithEvents TOTAL As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTAL1D As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTAL1DFUP As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT1DNFUP As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTAL1DFUPC As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTAL1U As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTAL1UFUP As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOT1UNFUP As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTALIUFUPC As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents dgvMFS As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewLinkColumn1 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn2 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn3 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn4 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewLinkColumn5 As System.Windows.Forms.DataGridViewLinkColumn
End Class
