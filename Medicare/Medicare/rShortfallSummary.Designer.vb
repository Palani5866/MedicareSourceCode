<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rShortfallSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rShortfallSummary))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.ssReport = New System.Windows.Forms.StatusStrip
        Me.ssReport_RecordCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ssReport_Parameter = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvShortfall = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fullname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.plan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.totshort = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TotalNoPayment = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TotalAmount = New System.Windows.Forms.DataGridViewLinkColumn
        Me.totrequested = New System.Windows.Forms.DataGridViewLinkColumn
        Me.totrecovered = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tolForm.SuspendLayout()
        Me.ssReport.SuspendLayout()
        CType(Me.dgvShortfall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbExport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tolForm.Size = New System.Drawing.Size(1172, 25)
        Me.tolForm.TabIndex = 2
        Me.tolForm.Text = "ToolStrip1"
        '
        'tsbExport2Xcel
        '
        Me.tsbExport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbExport2Xcel.Image = CType(resources.GetObject("tsbExport2Xcel.Image"), System.Drawing.Image)
        Me.tsbExport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExport2Xcel.Name = "tsbExport2Xcel"
        Me.tsbExport2Xcel.Size = New System.Drawing.Size(84, 22)
        Me.tsbExport2Xcel.Text = "Export to Excel"
        Me.tsbExport2Xcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ssReport
        '
        Me.ssReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssReport_RecordCount, Me.ssReport_Parameter})
        Me.ssReport.Location = New System.Drawing.Point(0, 251)
        Me.ssReport.Name = "ssReport"
        Me.ssReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssReport.Size = New System.Drawing.Size(1172, 22)
        Me.ssReport.TabIndex = 7
        Me.ssReport.Text = "StatusStrip"
        '
        'ssReport_RecordCount
        '
        Me.ssReport_RecordCount.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ssReport_RecordCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ssReport_RecordCount.Name = "ssReport_RecordCount"
        Me.ssReport_RecordCount.Size = New System.Drawing.Size(4, 17)
        Me.ssReport_RecordCount.Visible = False
        '
        'ssReport_Parameter
        '
        Me.ssReport_Parameter.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ssReport_Parameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ssReport_Parameter.Name = "ssReport_Parameter"
        Me.ssReport_Parameter.Size = New System.Drawing.Size(4, 17)
        Me.ssReport_Parameter.Visible = False
        '
        'dgvShortfall
        '
        Me.dgvShortfall.AllowUserToAddRows = False
        Me.dgvShortfall.AllowUserToDeleteRows = False
        Me.dgvShortfall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortfall.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.ic, Me.fullname, Me.plan, Me.totshort, Me.TotalNoPayment, Me.TotalAmount, Me.totrequested, Me.totrecovered, Me.Balance})
        Me.dgvShortfall.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShortfall.Location = New System.Drawing.Point(0, 25)
        Me.dgvShortfall.Name = "dgvShortfall"
        Me.dgvShortfall.ReadOnly = True
        Me.dgvShortfall.Size = New System.Drawing.Size(1172, 226)
        Me.dgvShortfall.TabIndex = 8
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'ic
        '
        Me.ic.DataPropertyName = "ic"
        Me.ic.HeaderText = "IC"
        Me.ic.Name = "ic"
        Me.ic.ReadOnly = True
        '
        'fullname
        '
        Me.fullname.DataPropertyName = "fullname"
        Me.fullname.HeaderText = "Full Name"
        Me.fullname.Name = "fullname"
        Me.fullname.ReadOnly = True
        '
        'plan
        '
        Me.plan.DataPropertyName = "plan"
        Me.plan.HeaderText = "PLAN"
        Me.plan.Name = "plan"
        Me.plan.ReadOnly = True
        '
        'totshort
        '
        Me.totshort.DataPropertyName = "totshort"
        Me.totshort.HeaderText = "Total Short"
        Me.totshort.Name = "totshort"
        Me.totshort.ReadOnly = True
        Me.totshort.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.totshort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TotalNoPayment
        '
        Me.TotalNoPayment.HeaderText = "Total Non Payment"
        Me.TotalNoPayment.Name = "TotalNoPayment"
        Me.TotalNoPayment.ReadOnly = True
        '
        'TotalAmount
        '
        Me.TotalAmount.HeaderText = "Total Amount"
        Me.TotalAmount.Name = "TotalAmount"
        Me.TotalAmount.ReadOnly = True
        '
        'totrequested
        '
        Me.totrequested.DataPropertyName = "totrequested"
        Me.totrequested.HeaderText = "Total Requested"
        Me.totrequested.Name = "totrequested"
        Me.totrequested.ReadOnly = True
        Me.totrequested.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.totrequested.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'totrecovered
        '
        Me.totrecovered.DataPropertyName = "totrecovered"
        Me.totrecovered.HeaderText = "Total Recovered"
        Me.totrecovered.Name = "totrecovered"
        Me.totrecovered.ReadOnly = True
        '
        'Balance
        '
        Me.Balance.HeaderText = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.ReadOnly = True
        '
        'rShortfallSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1172, 273)
        Me.Controls.Add(Me.dgvShortfall)
        Me.Controls.Add(Me.ssReport)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "rShortfallSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shortfall Summary"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.ssReport.ResumeLayout(False)
        Me.ssReport.PerformLayout()
        CType(Me.dgvShortfall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssReport As System.Windows.Forms.StatusStrip
    Friend WithEvents ssReport_RecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssReport_Parameter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvShortfall As System.Windows.Forms.DataGridView
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fullname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents plan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totshort As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TotalNoPayment As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TotalAmount As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents totrequested As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents totrecovered As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Balance As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
