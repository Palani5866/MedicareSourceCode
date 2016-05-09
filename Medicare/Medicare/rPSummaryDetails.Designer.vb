<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rPSummaryDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rPSummaryDetails))
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.tsbtnPrint = New System.Windows.Forms.ToolStripButton
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.dgvSummaryDetails = New System.Windows.Forms.DataGridView
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblDateFrom = New System.Windows.Forms.Label
        Me.lblDateTo = New System.Windows.Forms.Label
        Me.lblPLAN = New System.Windows.Forms.Label
        Me.lblAgentCode = New System.Windows.Forms.Label
        Me.lblTYPE = New System.Windows.Forms.Label
        Me.lblSearchBy = New System.Windows.Forms.Label
        Me.tsSearch.SuspendLayout()
        CType(Me.dgvSummaryDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnPrint, Me.btnXPort})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(848, 25)
        Me.tsSearch.TabIndex = 6
        Me.tsSearch.Text = "ToolStrip"
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
        Me.btnXPort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnXPort.Image = CType(resources.GetObject("btnXPort.Image"), System.Drawing.Image)
        Me.btnXPort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnXPort.Name = "btnXPort"
        Me.btnXPort.Size = New System.Drawing.Size(60, 22)
        Me.btnXPort.Text = "Export"
        '
        'dgvSummaryDetails
        '
        Me.dgvSummaryDetails.AllowUserToAddRows = False
        Me.dgvSummaryDetails.AllowUserToDeleteRows = False
        Me.dgvSummaryDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSummaryDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSummaryDetails.Location = New System.Drawing.Point(0, 25)
        Me.dgvSummaryDetails.Name = "dgvSummaryDetails"
        Me.dgvSummaryDetails.ReadOnly = True
        Me.dgvSummaryDetails.Size = New System.Drawing.Size(848, 523)
        Me.dgvSummaryDetails.TabIndex = 7
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(359, 303)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(50, 13)
        Me.lblStatus.TabIndex = 8
        Me.lblStatus.Text = "STATUS"
        Me.lblStatus.Visible = False
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(397, 217)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(67, 13)
        Me.lblDateFrom.TabIndex = 9
        Me.lblDateFrom.Text = "DATEFROM"
        Me.lblDateFrom.Visible = False
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(483, 217)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(43, 13)
        Me.lblDateTo.TabIndex = 10
        Me.lblDateTo.Text = "DateTo"
        Me.lblDateTo.Visible = False
        '
        'lblPLAN
        '
        Me.lblPLAN.AutoSize = True
        Me.lblPLAN.Location = New System.Drawing.Point(313, 232)
        Me.lblPLAN.Name = "lblPLAN"
        Me.lblPLAN.Size = New System.Drawing.Size(35, 13)
        Me.lblPLAN.TabIndex = 11
        Me.lblPLAN.Text = "PLAN"
        Me.lblPLAN.Visible = False
        '
        'lblAgentCode
        '
        Me.lblAgentCode.AutoSize = True
        Me.lblAgentCode.Location = New System.Drawing.Point(399, 268)
        Me.lblAgentCode.Name = "lblAgentCode"
        Me.lblAgentCode.Size = New System.Drawing.Size(74, 13)
        Me.lblAgentCode.TabIndex = 12
        Me.lblAgentCode.Text = "AGENTCODE"
        Me.lblAgentCode.Visible = False
        '
        'lblTYPE
        '
        Me.lblTYPE.AutoSize = True
        Me.lblTYPE.Location = New System.Drawing.Point(536, 314)
        Me.lblTYPE.Name = "lblTYPE"
        Me.lblTYPE.Size = New System.Drawing.Size(35, 13)
        Me.lblTYPE.TabIndex = 13
        Me.lblTYPE.Text = "TYPE"
        Me.lblTYPE.Visible = False
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.Location = New System.Drawing.Point(632, 268)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(65, 13)
        Me.lblSearchBy.TabIndex = 14
        Me.lblSearchBy.Text = "SEARCHBY"
        Me.lblSearchBy.Visible = False
        '
        'rPSummaryDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 548)
        Me.Controls.Add(Me.lblSearchBy)
        Me.Controls.Add(Me.lblTYPE)
        Me.Controls.Add(Me.lblAgentCode)
        Me.Controls.Add(Me.lblPLAN)
        Me.Controls.Add(Me.lblDateTo)
        Me.Controls.Add(Me.lblDateFrom)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.dgvSummaryDetails)
        Me.Controls.Add(Me.tsSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "rPSummaryDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proposer Summary Details"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        CType(Me.dgvSummaryDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnXPort As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvSummaryDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblDateFrom As System.Windows.Forms.Label
    Friend WithEvents lblDateTo As System.Windows.Forms.Label
    Friend WithEvents lblPLAN As System.Windows.Forms.Label
    Friend WithEvents lblAgentCode As System.Windows.Forms.Label
    Friend WithEvents lblTYPE As System.Windows.Forms.Label
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
End Class
