<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShortFallfollowup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShortFallfollowup))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblMonth = New System.Windows.Forms.ToolStripLabel
        Me.ddlDCode = New System.Windows.Forms.ToolStripComboBox
        Me.btnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tslblTotalRecords = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.dgvShortFalls = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblREF1 = New System.Windows.Forms.Label
        Me.gbShortClosedDetails = New System.Windows.Forms.GroupBox
        Me.lbXport2Xcel = New System.Windows.Forms.LinkLabel
        Me.dgvShortfallsClosed = New System.Windows.Forms.DataGridView
        Me.gbRequestedDetails = New System.Windows.Forms.GroupBox
        Me.dgvRSFR = New System.Windows.Forms.DataGridView
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Upload = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Download = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tslblRequestBatchNo = New System.Windows.Forms.ToolStripLabel
        Me.tscbRequestBatchNo = New System.Windows.Forms.ToolStripComboBox
        Me.tsbtnRequestbatchNo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsReport.SuspendLayout()
        CType(Me.dgvShortFalls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbShortClosedDetails.SuspendLayout()
        CType(Me.dgvShortfallsClosed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRequestedDetails.SuspendLayout()
        CType(Me.dgvRSFR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblMonth, Me.ddlDCode, Me.btnGo, Me.tsReport_Div1, Me.tslblTotalRecords, Me.ToolStripSeparator2, Me.tsbtnXport2Xcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(946, 25)
        Me.tsReport.TabIndex = 5
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblMonth
        '
        Me.tsReport_lblMonth.Name = "tsReport_lblMonth"
        Me.tsReport_lblMonth.Size = New System.Drawing.Size(93, 22)
        Me.tsReport_lblMonth.Text = "Deduction Code : "
        '
        'ddlDCode
        '
        Me.ddlDCode.Name = "ddlDCode"
        Me.ddlDCode.Size = New System.Drawing.Size(75, 25)
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
        'tslblTotalRecords
        '
        Me.tslblTotalRecords.Name = "tslblTotalRecords"
        Me.tslblTotalRecords.Size = New System.Drawing.Size(80, 22)
        Me.tslblTotalRecords.Text = "Total Records :"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnXport2Xcel
        '
        Me.tsbtnXport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnXport2Xcel.Image = CType(resources.GetObject("tsbtnXport2Xcel.Image"), System.Drawing.Image)
        Me.tsbtnXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnXport2Xcel.Name = "tsbtnXport2Xcel"
        Me.tsbtnXport2Xcel.Size = New System.Drawing.Size(84, 22)
        Me.tsbtnXport2Xcel.Text = "Export to Excel"
        '
        'dgvShortFalls
        '
        Me.dgvShortFalls.AllowUserToAddRows = False
        Me.dgvShortFalls.AllowUserToDeleteRows = False
        Me.dgvShortFalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortFalls.Location = New System.Drawing.Point(0, 28)
        Me.dgvShortFalls.Name = "dgvShortFalls"
        Me.dgvShortFalls.ReadOnly = True
        Me.dgvShortFalls.Size = New System.Drawing.Size(946, 220)
        Me.dgvShortFalls.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(655, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "REF1"
        Me.Label1.Visible = False
        '
        'lblREF1
        '
        Me.lblREF1.AutoSize = True
        Me.lblREF1.Location = New System.Drawing.Point(554, 103)
        Me.lblREF1.Name = "lblREF1"
        Me.lblREF1.Size = New System.Drawing.Size(34, 13)
        Me.lblREF1.TabIndex = 8
        Me.lblREF1.Text = "REF1"
        Me.lblREF1.Visible = False
        '
        'gbShortClosedDetails
        '
        Me.gbShortClosedDetails.Controls.Add(Me.lbXport2Xcel)
        Me.gbShortClosedDetails.Controls.Add(Me.dgvShortfallsClosed)
        Me.gbShortClosedDetails.Location = New System.Drawing.Point(0, 505)
        Me.gbShortClosedDetails.Name = "gbShortClosedDetails"
        Me.gbShortClosedDetails.Size = New System.Drawing.Size(943, 249)
        Me.gbShortClosedDetails.TabIndex = 10
        Me.gbShortClosedDetails.TabStop = False
        Me.gbShortClosedDetails.Text = "Short Falls Closed Details"
        '
        'lbXport2Xcel
        '
        Me.lbXport2Xcel.AutoSize = True
        Me.lbXport2Xcel.Location = New System.Drawing.Point(856, 13)
        Me.lbXport2Xcel.Name = "lbXport2Xcel"
        Me.lbXport2Xcel.Size = New System.Drawing.Size(78, 13)
        Me.lbXport2Xcel.TabIndex = 8
        Me.lbXport2Xcel.TabStop = True
        Me.lbXport2Xcel.Text = "Export to Excel"
        '
        'dgvShortfallsClosed
        '
        Me.dgvShortfallsClosed.AllowUserToAddRows = False
        Me.dgvShortfallsClosed.AllowUserToDeleteRows = False
        Me.dgvShortfallsClosed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortfallsClosed.Location = New System.Drawing.Point(6, 29)
        Me.dgvShortfallsClosed.Name = "dgvShortfallsClosed"
        Me.dgvShortfallsClosed.ReadOnly = True
        Me.dgvShortfallsClosed.Size = New System.Drawing.Size(928, 211)
        Me.dgvShortfallsClosed.TabIndex = 7
        '
        'gbRequestedDetails
        '
        Me.gbRequestedDetails.Controls.Add(Me.dgvRSFR)
        Me.gbRequestedDetails.Controls.Add(Me.ToolStrip1)
        Me.gbRequestedDetails.Location = New System.Drawing.Point(0, 254)
        Me.gbRequestedDetails.Name = "gbRequestedDetails"
        Me.gbRequestedDetails.Size = New System.Drawing.Size(946, 245)
        Me.gbRequestedDetails.TabIndex = 11
        Me.gbRequestedDetails.TabStop = False
        Me.gbRequestedDetails.Text = "Requested Details"
        '
        'dgvRSFR
        '
        Me.dgvRSFR.AllowUserToAddRows = False
        Me.dgvRSFR.AllowUserToDeleteRows = False
        Me.dgvRSFR.AllowUserToOrderColumns = True
        Me.dgvRSFR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRSFR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.View, Me.Upload, Me.Download})
        Me.dgvRSFR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRSFR.Location = New System.Drawing.Point(3, 41)
        Me.dgvRSFR.Name = "dgvRSFR"
        Me.dgvRSFR.Size = New System.Drawing.Size(940, 201)
        Me.dgvRSFR.TabIndex = 8
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
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblRequestBatchNo, Me.tscbRequestBatchNo, Me.tsbtnRequestbatchNo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(940, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip"
        '
        'tslblRequestBatchNo
        '
        Me.tslblRequestBatchNo.Name = "tslblRequestBatchNo"
        Me.tslblRequestBatchNo.Size = New System.Drawing.Size(112, 22)
        Me.tslblRequestBatchNo.Text = "Requested Batch No :"
        '
        'tscbRequestBatchNo
        '
        Me.tscbRequestBatchNo.Name = "tscbRequestBatchNo"
        Me.tscbRequestBatchNo.Size = New System.Drawing.Size(125, 25)
        '
        'tsbtnRequestbatchNo
        '
        Me.tsbtnRequestbatchNo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnRequestbatchNo.Image = CType(resources.GetObject("tsbtnRequestbatchNo.Image"), System.Drawing.Image)
        Me.tsbtnRequestbatchNo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnRequestbatchNo.Name = "tsbtnRequestbatchNo"
        Me.tsbtnRequestbatchNo.Size = New System.Drawing.Size(24, 22)
        Me.tsbtnRequestbatchNo.Text = "Go"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'frmShortFallfollowup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 757)
        Me.Controls.Add(Me.gbRequestedDetails)
        Me.Controls.Add(Me.gbShortClosedDetails)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblREF1)
        Me.Controls.Add(Me.dgvShortFalls)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmShortFallfollowup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Fall Follow up"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvShortFalls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbShortClosedDetails.ResumeLayout(False)
        Me.gbShortClosedDetails.PerformLayout()
        CType(Me.dgvShortfallsClosed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRequestedDetails.ResumeLayout(False)
        Me.gbRequestedDetails.PerformLayout()
        CType(Me.dgvRSFR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblMonth As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ddlDCode As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslblTotalRecords As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnXport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvShortFalls As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblREF1 As System.Windows.Forms.Label
    Friend WithEvents gbShortClosedDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lbXport2Xcel As System.Windows.Forms.LinkLabel
    Friend WithEvents dgvShortfallsClosed As System.Windows.Forms.DataGridView
    Friend WithEvents gbRequestedDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvRSFR As System.Windows.Forms.DataGridView
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Upload As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Download As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblRequestBatchNo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbRequestBatchNo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsbtnRequestbatchNo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
