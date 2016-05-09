<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vProReportbyAgent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(vProReportbyAgent))
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.lblDateFrom = New System.Windows.Forms.ToolStripLabel
        Me.txtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.txtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.btnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.dgvSummary = New System.Windows.Forms.DataGridView
        Me.AGENTCODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AGENTNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CCTOT = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CCEF = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CCI = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CPATOT = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CPAPLANA = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CPAPLANB = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tslblSearchBy = New System.Windows.Forms.ToolStripLabel
        Me.tscbSearchBy = New System.Windows.Forms.ToolStripComboBox
        Me.tsSearch.SuspendLayout()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblSearchBy, Me.tscbSearchBy, Me.lblDateFrom, Me.txtDateFrom, Me.ToolStripLabel, Me.txtDateTo, Me.btnGo, Me.tsReport_Div1, Me.btnXPort})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(1002, 25)
        Me.tsSearch.TabIndex = 6
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
        'btnGo
        '
        Me.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(26, 22)
        Me.btnGo.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'btnXPort
        '
        Me.btnXPort.Image = CType(resources.GetObject("btnXPort.Image"), System.Drawing.Image)
        Me.btnXPort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnXPort.Name = "btnXPort"
        Me.btnXPort.Size = New System.Drawing.Size(60, 22)
        Me.btnXPort.Text = "Export"
        '
        'dgvSummary
        '
        Me.dgvSummary.AllowUserToAddRows = False
        Me.dgvSummary.AllowUserToDeleteRows = False
        Me.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSummary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AGENTCODE, Me.AGENTNAME, Me.Total, Me.CCTOT, Me.CCEF, Me.CCI, Me.CPATOT, Me.CPAPLANA, Me.CPAPLANB})
        Me.dgvSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSummary.Location = New System.Drawing.Point(0, 25)
        Me.dgvSummary.Name = "dgvSummary"
        Me.dgvSummary.ReadOnly = True
        Me.dgvSummary.Size = New System.Drawing.Size(1002, 408)
        Me.dgvSummary.TabIndex = 7
        '
        'AGENTCODE
        '
        Me.AGENTCODE.DataPropertyName = "ACODE"
        Me.AGENTCODE.HeaderText = "AGENTCODE"
        Me.AGENTCODE.Name = "AGENTCODE"
        Me.AGENTCODE.ReadOnly = True
        '
        'AGENTNAME
        '
        Me.AGENTNAME.DataPropertyName = "ANAME"
        Me.AGENTNAME.HeaderText = "AGENT NAME"
        Me.AGENTNAME.Name = "AGENTNAME"
        Me.AGENTNAME.ReadOnly = True
        '
        'Total
        '
        Me.Total.DataPropertyName = "TOTAL"
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Text = ""
        '
        'CCTOT
        '
        Me.CCTOT.DataPropertyName = "CCTOT"
        Me.CCTOT.HeaderText = "CUEPACS CARE TOTAL"
        Me.CCTOT.Name = "CCTOT"
        Me.CCTOT.ReadOnly = True
        Me.CCTOT.Text = ""
        '
        'CCEF
        '
        Me.CCEF.DataPropertyName = "CCF"
        Me.CCEF.HeaderText = "CC FAMILY"
        Me.CCEF.Name = "CCEF"
        Me.CCEF.ReadOnly = True
        Me.CCEF.Text = ""
        '
        'CCI
        '
        Me.CCI.DataPropertyName = "CCI"
        Me.CCI.HeaderText = "CC INDIVIDUAL"
        Me.CCI.Name = "CCI"
        Me.CCI.ReadOnly = True
        Me.CCI.Text = ""
        '
        'CPATOT
        '
        Me.CPATOT.DataPropertyName = "CPATOT"
        Me.CPATOT.HeaderText = "CPA TOTAL"
        Me.CPATOT.Name = "CPATOT"
        Me.CPATOT.ReadOnly = True
        Me.CPATOT.Text = ""
        '
        'CPAPLANA
        '
        Me.CPAPLANA.DataPropertyName = "CPAPLANA"
        Me.CPAPLANA.HeaderText = "CPA PLAN A"
        Me.CPAPLANA.Name = "CPAPLANA"
        Me.CPAPLANA.ReadOnly = True
        Me.CPAPLANA.Text = ""
        '
        'CPAPLANB
        '
        Me.CPAPLANB.DataPropertyName = "CPAPLANB"
        Me.CPAPLANB.HeaderText = "CPA PLAN B"
        Me.CPAPLANB.Name = "CPAPLANB"
        Me.CPAPLANB.ReadOnly = True
        Me.CPAPLANB.Text = ""
        '
        'tslblSearchBy
        '
        Me.tslblSearchBy.Name = "tslblSearchBy"
        Me.tslblSearchBy.Size = New System.Drawing.Size(64, 22)
        Me.tslblSearchBy.Text = "Search By :"
        '
        'tscbSearchBy
        '
        Me.tscbSearchBy.Items.AddRange(New Object() {"PROPOSAL RECEIVED DATE", "SUBMISSION DATE"})
        Me.tscbSearchBy.Name = "tscbSearchBy"
        Me.tscbSearchBy.Size = New System.Drawing.Size(221, 25)
        '
        'vProReportbyAgent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 433)
        Me.Controls.Add(Me.dgvSummary)
        Me.Controls.Add(Me.tsSearch)
        Me.Name = "vProReportbyAgent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Producation Report by Agent"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnXPort As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvSummary As System.Windows.Forms.DataGridView
    Friend WithEvents AGENTCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AGENTNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CCTOT As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CCEF As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CCI As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CPATOT As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CPAPLANA As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CPAPLANB As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents tslblSearchBy As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbSearchBy As System.Windows.Forms.ToolStripComboBox
End Class
