<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YrFollowupSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(YrFollowupSummary))
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.lblDateFrom = New System.Windows.Forms.ToolStripLabel
        Me.txtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.txtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.btnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnPrint = New System.Windows.Forms.ToolStripButton
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.dgvYRFS = New System.Windows.Forms.DataGridView
        Me.TOTAL = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTALRENEWED = New System.Windows.Forms.DataGridViewLinkColumn
        Me.SELFRENEWED = New System.Windows.Forms.DataGridViewLinkColumn
        Me.FURENEWED = New System.Windows.Forms.DataGridViewLinkColumn
        Me.FUNRENEWED = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTALFU = New System.Windows.Forms.DataGridViewLinkColumn
        Me.NFU = New System.Windows.Forms.DataGridViewLinkColumn
        Me.FUBUTLAPSE = New System.Windows.Forms.DataGridViewLinkColumn
        Me.AUTOLAPSE = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTALLAPSE = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CHANGEPLANOROTHERS = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTALNOTRENEWED = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsSearch.SuspendLayout()
        CType(Me.dgvYRFS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDateFrom, Me.txtDateFrom, Me.ToolStripLabel, Me.txtDateTo, Me.btnGo, Me.tsReport_Div1, Me.tsbtnPrint, Me.btnXPort})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(906, 25)
        Me.tsSearch.TabIndex = 7
        Me.tsSearch.Text = "ToolStrip"
        '
        'lblDateFrom
        '
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(200, 22)
        Me.lblDateFrom.Text = "Cancellation Date - From (dd/mm/yyyy):"
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
        Me.ToolStripLabel.Size = New System.Drawing.Size(188, 22)
        Me.ToolStripLabel.Text = "Cancellation Date - To (dd/mm/yyyy):"
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
        'dgvYRFS
        '
        Me.dgvYRFS.AllowUserToAddRows = False
        Me.dgvYRFS.AllowUserToDeleteRows = False
        Me.dgvYRFS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYRFS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TOTAL, Me.TOTALRENEWED, Me.SELFRENEWED, Me.FURENEWED, Me.FUNRENEWED, Me.TOTALFU, Me.NFU, Me.FUBUTLAPSE, Me.AUTOLAPSE, Me.TOTALLAPSE, Me.CHANGEPLANOROTHERS, Me.TOTALNOTRENEWED})
        Me.dgvYRFS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvYRFS.Location = New System.Drawing.Point(0, 25)
        Me.dgvYRFS.Name = "dgvYRFS"
        Me.dgvYRFS.Size = New System.Drawing.Size(906, 352)
        Me.dgvYRFS.TabIndex = 8
        '
        'TOTAL
        '
        Me.TOTAL.DataPropertyName = "TOTAL"
        Me.TOTAL.HeaderText = "TOTAL"
        Me.TOTAL.Name = "TOTAL"
        '
        'TOTALRENEWED
        '
        Me.TOTALRENEWED.DataPropertyName = "TOTALRENEWED"
        Me.TOTALRENEWED.HeaderText = "TOTAL RENEWED"
        Me.TOTALRENEWED.Name = "TOTALRENEWED"
        '
        'SELFRENEWED
        '
        Me.SELFRENEWED.DataPropertyName = "SELFRENEWED"
        Me.SELFRENEWED.HeaderText = "SELF RENEWED"
        Me.SELFRENEWED.Name = "SELFRENEWED"
        '
        'FURENEWED
        '
        Me.FURENEWED.DataPropertyName = "FURENEWED"
        Me.FURENEWED.HeaderText = "FOLLOW UP RENEWED"
        Me.FURENEWED.Name = "FURENEWED"
        '
        'FUNRENEWED
        '
        Me.FUNRENEWED.DataPropertyName = "FUNRENEWED"
        Me.FUNRENEWED.HeaderText = "FOLLOW UP NOT RENEWED"
        Me.FUNRENEWED.Name = "FUNRENEWED"
        '
        'TOTALFU
        '
        Me.TOTALFU.DataPropertyName = "TOTALFU"
        Me.TOTALFU.HeaderText = "TOTAL FOLLOW UP"
        Me.TOTALFU.Name = "TOTALFU"
        '
        'NFU
        '
        Me.NFU.DataPropertyName = "NFU"
        Me.NFU.HeaderText = "NOT FOLLOW UP"
        Me.NFU.Name = "NFU"
        '
        'FUBUTLAPSE
        '
        Me.FUBUTLAPSE.DataPropertyName = "FUBUTLAPSE"
        Me.FUBUTLAPSE.HeaderText = "FOLLOW UP BUT LAPSE"
        Me.FUBUTLAPSE.Name = "FUBUTLAPSE"
        '
        'AUTOLAPSE
        '
        Me.AUTOLAPSE.DataPropertyName = "AUTOLAPSE"
        Me.AUTOLAPSE.HeaderText = "AUTO LAPSE"
        Me.AUTOLAPSE.Name = "AUTOLAPSE"
        '
        'TOTALLAPSE
        '
        Me.TOTALLAPSE.DataPropertyName = "TOTALLAPSE"
        Me.TOTALLAPSE.HeaderText = "TOTAL LAPSE"
        Me.TOTALLAPSE.Name = "TOTALLAPSE"
        '
        'CHANGEPLANOROTHERS
        '
        Me.CHANGEPLANOROTHERS.DataPropertyName = "CHANGEPLANOROTHERS"
        Me.CHANGEPLANOROTHERS.HeaderText = "CHANGE PLAN / CANCEL /OTHERS"
        Me.CHANGEPLANOROTHERS.Name = "CHANGEPLANOROTHERS"
        '
        'TOTALNOTRENEWED
        '
        Me.TOTALNOTRENEWED.DataPropertyName = "TOTALNOTRENEWED"
        Me.TOTALNOTRENEWED.HeaderText = "TOTAL NOT RENEWED"
        Me.TOTALNOTRENEWED.Name = "TOTALNOTRENEWED"
        '
        'YrFollowupSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 377)
        Me.Controls.Add(Me.dgvYRFS)
        Me.Controls.Add(Me.tsSearch)
        Me.Name = "YrFollowupSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Follow up Summary for Yearly"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        CType(Me.dgvYRFS, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvYRFS As System.Windows.Forms.DataGridView
    Friend WithEvents TOTAL As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTALRENEWED As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents SELFRENEWED As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents FURENEWED As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents FUNRENEWED As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTALFU As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents NFU As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents FUBUTLAPSE As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents AUTOLAPSE As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTALLAPSE As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CHANGEPLANOROTHERS As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTALNOTRENEWED As System.Windows.Forms.DataGridViewLinkColumn
End Class
