<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rPending
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rPending))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.tslblDateFrm = New System.Windows.Forms.ToolStripLabel
        Me.dgvPendingDetails = New System.Windows.Forms.DataGridView
        Me.lblRTYPE = New System.Windows.Forms.Label
        Me.ssReport = New System.Windows.Forms.StatusStrip
        Me.ssReport_RecordCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ssReport_Parameter = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstxtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.tslblDateTo = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsS = New System.Windows.Forms.ToolStripSeparator
        Me.tolForm.SuspendLayout()
        CType(Me.dgvPendingDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblDateFrm, Me.tstxtDateFrom, Me.tslblDateTo, Me.tstxtDateTo, Me.tsbtnGo, Me.tsbExport2Xcel, Me.tsS})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tolForm.Size = New System.Drawing.Size(1063, 25)
        Me.tolForm.TabIndex = 1
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
        'tslblDateFrm
        '
        Me.tslblDateFrm.Name = "tslblDateFrm"
        Me.tslblDateFrm.Size = New System.Drawing.Size(135, 22)
        Me.tslblDateFrm.Text = "Date From (dd/MM/yyyy) :"
        '
        'dgvPendingDetails
        '
        Me.dgvPendingDetails.AllowUserToAddRows = False
        Me.dgvPendingDetails.AllowUserToDeleteRows = False
        Me.dgvPendingDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendingDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingDetails.Location = New System.Drawing.Point(0, 25)
        Me.dgvPendingDetails.Name = "dgvPendingDetails"
        Me.dgvPendingDetails.ReadOnly = True
        Me.dgvPendingDetails.Size = New System.Drawing.Size(1063, 455)
        Me.dgvPendingDetails.TabIndex = 4
        '
        'lblRTYPE
        '
        Me.lblRTYPE.AutoSize = True
        Me.lblRTYPE.Location = New System.Drawing.Point(598, 240)
        Me.lblRTYPE.Name = "lblRTYPE"
        Me.lblRTYPE.Size = New System.Drawing.Size(43, 13)
        Me.lblRTYPE.TabIndex = 5
        Me.lblRTYPE.Text = "RTYPE"
        Me.lblRTYPE.Visible = False
        '
        'ssReport
        '
        Me.ssReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssReport_RecordCount, Me.ssReport_Parameter})
        Me.ssReport.Location = New System.Drawing.Point(0, 458)
        Me.ssReport.Name = "ssReport"
        Me.ssReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssReport.Size = New System.Drawing.Size(1063, 22)
        Me.ssReport.TabIndex = 6
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
        'tstxtDateFrom
        '
        Me.tstxtDateFrom.Name = "tstxtDateFrom"
        Me.tstxtDateFrom.Size = New System.Drawing.Size(100, 25)
        '
        'tslblDateTo
        '
        Me.tslblDateTo.Name = "tslblDateTo"
        Me.tslblDateTo.Size = New System.Drawing.Size(123, 22)
        Me.tslblDateTo.Text = "Date To (dd/MM/yyyy) :"
        '
        'tstxtDateTo
        '
        Me.tstxtDateTo.Name = "tstxtDateTo"
        Me.tstxtDateTo.Size = New System.Drawing.Size(100, 25)
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(32, 22)
        Me.tsbtnGo.Text = "Go.."
        '
        'tsS
        '
        Me.tsS.Name = "tsS"
        Me.tsS.Size = New System.Drawing.Size(6, 25)
        '
        'rPending
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1063, 480)
        Me.Controls.Add(Me.ssReport)
        Me.Controls.Add(Me.lblRTYPE)
        Me.Controls.Add(Me.dgvPendingDetails)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "rPending"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending Incomplete"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvPendingDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssReport.ResumeLayout(False)
        Me.ssReport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvPendingDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblRTYPE As System.Windows.Forms.Label
    Friend WithEvents ssReport As System.Windows.Forms.StatusStrip
    Friend WithEvents ssReport_RecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssReport_Parameter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblDateFrm As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDateFrom As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tslblDateTo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDateTo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsS As System.Windows.Forms.ToolStripSeparator
End Class
