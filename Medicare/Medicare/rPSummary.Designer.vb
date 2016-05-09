<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rPSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rPSummary))
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.lblStaff = New System.Windows.Forms.ToolStripLabel
        Me.cbStaff = New System.Windows.Forms.ToolStripComboBox
        Me.lblDateFrom = New System.Windows.Forms.ToolStripLabel
        Me.txtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.txtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.btnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnPrint = New System.Windows.Forms.ToolStripButton
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.dgvSummary = New System.Windows.Forms.DataGridView
        Me.PLANCODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pTot = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pNV = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pV = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pR = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pD = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pU = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pPU = New System.Windows.Forms.DataGridViewLinkColumn
        Me.pA = New System.Windows.Forms.DataGridViewLinkColumn
        Me.SubmittedToAngkasa = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsSearch.SuspendLayout()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStaff, Me.cbStaff, Me.lblDateFrom, Me.txtDateFrom, Me.ToolStripLabel, Me.txtDateTo, Me.btnGo, Me.tsReport_Div1, Me.tsbtnPrint, Me.btnXPort})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(1184, 25)
        Me.tsSearch.TabIndex = 5
        Me.tsSearch.Text = "ToolStrip"
        '
        'lblStaff
        '
        Me.lblStaff.Name = "lblStaff"
        Me.lblStaff.Size = New System.Drawing.Size(72, 22)
        Me.lblStaff.Text = "Staff Name :"
        Me.lblStaff.Visible = False
        '
        'cbStaff
        '
        Me.cbStaff.Name = "cbStaff"
        Me.cbStaff.Size = New System.Drawing.Size(121, 25)
        Me.cbStaff.Visible = False
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
        'dgvSummary
        '
        Me.dgvSummary.AllowUserToAddRows = False
        Me.dgvSummary.AllowUserToDeleteRows = False
        Me.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSummary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PLANCODE, Me.pTot, Me.pNV, Me.pV, Me.pR, Me.pD, Me.pU, Me.pPU, Me.pA, Me.SubmittedToAngkasa})
        Me.dgvSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSummary.Location = New System.Drawing.Point(0, 25)
        Me.dgvSummary.Name = "dgvSummary"
        Me.dgvSummary.ReadOnly = True
        Me.dgvSummary.Size = New System.Drawing.Size(1184, 248)
        Me.dgvSummary.TabIndex = 6
        '
        'PLANCODE
        '
        Me.PLANCODE.DataPropertyName = "PCODE"
        Me.PLANCODE.HeaderText = "PLAN CODE"
        Me.PLANCODE.Name = "PLANCODE"
        Me.PLANCODE.ReadOnly = True
        '
        'pTot
        '
        Me.pTot.DataPropertyName = "TOT"
        Me.pTot.HeaderText = "Total"
        Me.pTot.Name = "pTot"
        Me.pTot.ReadOnly = True
        Me.pTot.Text = "View"
        Me.pTot.ToolTipText = "View"
        '
        'pNV
        '
        Me.pNV.DataPropertyName = "NVP"
        Me.pNV.HeaderText = "Not Verified"
        Me.pNV.Name = "pNV"
        Me.pNV.ReadOnly = True
        '
        'pV
        '
        Me.pV.DataPropertyName = "TOTVERIFIED"
        Me.pV.HeaderText = "Verified"
        Me.pV.Name = "pV"
        Me.pV.ReadOnly = True
        '
        'pR
        '
        Me.pR.DataPropertyName = "TOT1R"
        Me.pR.HeaderText = "Rejected"
        Me.pR.Name = "pR"
        Me.pR.ReadOnly = True
        '
        'pD
        '
        Me.pD.DataPropertyName = "TOT1D"
        Me.pD.HeaderText = "In Complete"
        Me.pD.Name = "pD"
        Me.pD.ReadOnly = True
        '
        'pU
        '
        Me.pU.DataPropertyName = "TOT1U"
        Me.pU.HeaderText = "Underwriting (Client)"
        Me.pU.Name = "pU"
        Me.pU.ReadOnly = True
        '
        'pPU
        '
        Me.pPU.DataPropertyName = "TOT1PU"
        Me.pPU.HeaderText = "Underwriting (CIMB)"
        Me.pPU.Name = "pPU"
        Me.pPU.ReadOnly = True
        '
        'pA
        '
        Me.pA.DataPropertyName = "TOT1A"
        Me.pA.HeaderText = "Approved (Ready for Submission)"
        Me.pA.Name = "pA"
        Me.pA.ReadOnly = True
        '
        'SubmittedToAngkasa
        '
        Me.SubmittedToAngkasa.DataPropertyName = "TOTSA"
        Me.SubmittedToAngkasa.HeaderText = "Submitted To Deduction Agency"
        Me.SubmittedToAngkasa.Name = "SubmittedToAngkasa"
        Me.SubmittedToAngkasa.ReadOnly = True
        '
        'rPSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 273)
        Me.Controls.Add(Me.dgvSummary)
        Me.Controls.Add(Me.tsSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "rPSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proposer Summary"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDateFrom As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtDateFrom As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txtDateTo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnXPort As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvSummary As System.Windows.Forms.DataGridView
    Friend WithEvents PLANCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pTot As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pNV As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pV As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pR As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pD As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pU As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pPU As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents pA As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents SubmittedToAngkasa As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblStaff As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cbStaff As System.Windows.Forms.ToolStripComboBox
End Class
