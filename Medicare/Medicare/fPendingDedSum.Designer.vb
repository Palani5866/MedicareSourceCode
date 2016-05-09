<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPendingDedSum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fPendingDedSum))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tslblDateFrm = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.tslblDateTo = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.tsS = New System.Windows.Forms.ToolStripSeparator
        Me.dgvPDetails = New System.Windows.Forms.DataGridView
        Me.lblP1 = New System.Windows.Forms.Label
        Me.CCANGKASA = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CCFAMA = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CCSIRIM = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CCOTHERS = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CPAANGKASA = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CPAOTHERS = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tolForm.SuspendLayout()
        CType(Me.dgvPDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblDateFrm, Me.tstxtDateFrom, Me.tslblDateTo, Me.tstxtDateTo, Me.tsbtnGo, Me.tsbExport2Xcel, Me.tsS})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tolForm.Size = New System.Drawing.Size(988, 25)
        Me.tolForm.TabIndex = 2
        Me.tolForm.Text = "ToolStrip1"
        '
        'tslblDateFrm
        '
        Me.tslblDateFrm.Name = "tslblDateFrm"
        Me.tslblDateFrm.Size = New System.Drawing.Size(149, 22)
        Me.tslblDateFrm.Text = "Date From (dd/MM/yyyy) :"
        '
        'tstxtDateFrom
        '
        Me.tstxtDateFrom.Name = "tstxtDateFrom"
        Me.tstxtDateFrom.Size = New System.Drawing.Size(100, 25)
        '
        'tslblDateTo
        '
        Me.tslblDateTo.Name = "tslblDateTo"
        Me.tslblDateTo.Size = New System.Drawing.Size(135, 22)
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
        'tsbExport2Xcel
        '
        Me.tsbExport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbExport2Xcel.Image = CType(resources.GetObject("tsbExport2Xcel.Image"), System.Drawing.Image)
        Me.tsbExport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExport2Xcel.Name = "tsbExport2Xcel"
        Me.tsbExport2Xcel.Size = New System.Drawing.Size(87, 22)
        Me.tsbExport2Xcel.Text = "Export to Excel"
        Me.tsbExport2Xcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tsS
        '
        Me.tsS.Name = "tsS"
        Me.tsS.Size = New System.Drawing.Size(6, 25)
        '
        'dgvPDetails
        '
        Me.dgvPDetails.AllowUserToAddRows = False
        Me.dgvPDetails.AllowUserToDeleteRows = False
        Me.dgvPDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CCANGKASA, Me.CCFAMA, Me.CCSIRIM, Me.CCOTHERS, Me.CPAANGKASA, Me.CPAOTHERS})
        Me.dgvPDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPDetails.Location = New System.Drawing.Point(0, 25)
        Me.dgvPDetails.Name = "dgvPDetails"
        Me.dgvPDetails.ReadOnly = True
        Me.dgvPDetails.Size = New System.Drawing.Size(988, 337)
        Me.dgvPDetails.TabIndex = 5
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(403, 138)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 6
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'CCANGKASA
        '
        Me.CCANGKASA.DataPropertyName = "CCANGKASA"
        Me.CCANGKASA.HeaderText = "CC ANGKASA - (0531 & 0532) (0511 & 0512)"
        Me.CCANGKASA.Name = "CCANGKASA"
        Me.CCANGKASA.ReadOnly = True
        Me.CCANGKASA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CCANGKASA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'CCFAMA
        '
        Me.CCFAMA.DataPropertyName = "CCFAMA"
        Me.CCFAMA.HeaderText = "CC FAMA - (1531 & 1532) (1511 & 1512)"
        Me.CCFAMA.Name = "CCFAMA"
        Me.CCFAMA.ReadOnly = True
        '
        'CCSIRIM
        '
        Me.CCSIRIM.DataPropertyName = "CCSIRIM"
        Me.CCSIRIM.HeaderText = "CC SIRIM - (2531 & 2532) (2511 & 2512)"
        Me.CCSIRIM.Name = "CCSIRIM"
        Me.CCSIRIM.ReadOnly = True
        '
        'CCOTHERS
        '
        Me.CCOTHERS.DataPropertyName = "CCOTHERS"
        Me.CCOTHERS.HeaderText = "CC OTHERS - (9531 & 9532) (9511 & 9512)"
        Me.CCOTHERS.Name = "CCOTHERS"
        Me.CCOTHERS.ReadOnly = True
        '
        'CPAANGKASA
        '
        Me.CPAANGKASA.DataPropertyName = "CPAANGKASA"
        Me.CPAANGKASA.HeaderText = "CPA ANGKASA - (0550 & 0551) (0513 & 0514)"
        Me.CPAANGKASA.Name = "CPAANGKASA"
        Me.CPAANGKASA.ReadOnly = True
        '
        'CPAOTHERS
        '
        Me.CPAOTHERS.DataPropertyName = "CPAOTHERS"
        Me.CPAOTHERS.HeaderText = "CPA OTHERS - (9550 & 9551) (9513 & 9514)"
        Me.CPAOTHERS.Name = "CPAOTHERS"
        Me.CPAOTHERS.ReadOnly = True
        '
        'fPendingDedSum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 362)
        Me.Controls.Add(Me.lblP1)
        Me.Controls.Add(Me.dgvPDetails)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "fPendingDedSum"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending Deduction Summary Details"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvPDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblDateFrm As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDateFrom As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tslblDateTo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDateTo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsS As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvPDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents CCANGKASA As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CCFAMA As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CCSIRIM As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CCOTHERS As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CPAANGKASA As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CPAOTHERS As System.Windows.Forms.DataGridViewLinkColumn
End Class
