<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelSum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelSum))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tslblDateFrm = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.tslblDateTo = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.tsS = New System.Windows.Forms.ToolStripSeparator
        Me.dgvCancelSum = New System.Windows.Forms.DataGridView
        Me.lblP5 = New System.Windows.Forms.Label
        Me.lblP4 = New System.Windows.Forms.Label
        Me.lblP3 = New System.Windows.Forms.Label
        Me.lblP2 = New System.Windows.Forms.Label
        Me.lblP1 = New System.Windows.Forms.Label
        Me.CR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CCANGKASA = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CCFAMA = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CCSIRIM = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CCOTHERS = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CPAANGKASA = New System.Windows.Forms.DataGridViewLinkColumn
        Me.CPAOTHERS = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tolForm.SuspendLayout()
        CType(Me.dgvCancelSum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblDateFrm, Me.tstxtDateFrom, Me.tslblDateTo, Me.tstxtDateTo, Me.tsbtnGo, Me.tsbExport2Xcel, Me.tsS})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tolForm.Size = New System.Drawing.Size(965, 25)
        Me.tolForm.TabIndex = 4
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
        'dgvCancelSum
        '
        Me.dgvCancelSum.AllowUserToAddRows = False
        Me.dgvCancelSum.AllowUserToDeleteRows = False
        Me.dgvCancelSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCancelSum.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CR, Me.CCANGKASA, Me.CCFAMA, Me.CCSIRIM, Me.CCOTHERS, Me.CPAANGKASA, Me.CPAOTHERS})
        Me.dgvCancelSum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCancelSum.Location = New System.Drawing.Point(0, 25)
        Me.dgvCancelSum.Name = "dgvCancelSum"
        Me.dgvCancelSum.Size = New System.Drawing.Size(965, 306)
        Me.dgvCancelSum.TabIndex = 5
        '
        'lblP5
        '
        Me.lblP5.AutoSize = True
        Me.lblP5.Location = New System.Drawing.Point(608, 158)
        Me.lblP5.Name = "lblP5"
        Me.lblP5.Size = New System.Drawing.Size(20, 13)
        Me.lblP5.TabIndex = 14
        Me.lblP5.Text = "P5"
        Me.lblP5.Visible = False
        '
        'lblP4
        '
        Me.lblP4.AutoSize = True
        Me.lblP4.Location = New System.Drawing.Point(476, 190)
        Me.lblP4.Name = "lblP4"
        Me.lblP4.Size = New System.Drawing.Size(20, 13)
        Me.lblP4.TabIndex = 13
        Me.lblP4.Text = "P4"
        Me.lblP4.Visible = False
        '
        'lblP3
        '
        Me.lblP3.AutoSize = True
        Me.lblP3.Location = New System.Drawing.Point(445, 150)
        Me.lblP3.Name = "lblP3"
        Me.lblP3.Size = New System.Drawing.Size(20, 13)
        Me.lblP3.TabIndex = 12
        Me.lblP3.Text = "P3"
        Me.lblP3.Visible = False
        '
        'lblP2
        '
        Me.lblP2.AutoSize = True
        Me.lblP2.Location = New System.Drawing.Point(437, 142)
        Me.lblP2.Name = "lblP2"
        Me.lblP2.Size = New System.Drawing.Size(20, 13)
        Me.lblP2.TabIndex = 11
        Me.lblP2.Text = "P2"
        Me.lblP2.Visible = False
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(337, 127)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 10
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'CR
        '
        Me.CR.DataPropertyName = "CR"
        Me.CR.HeaderText = "Cancellation Reason"
        Me.CR.Name = "CR"
        '
        'CCANGKASA
        '
        Me.CCANGKASA.DataPropertyName = "CCANGKASA"
        Me.CCANGKASA.HeaderText = "CC ANGKASA - (0531 & 0532) (0511 & 0512)"
        Me.CCANGKASA.Name = "CCANGKASA"
        '
        'CCFAMA
        '
        Me.CCFAMA.DataPropertyName = "CCFAMA"
        Me.CCFAMA.HeaderText = "CC FAMA - (1531 & 1532) (1511 & 1512)"
        Me.CCFAMA.Name = "CCFAMA"
        '
        'CCSIRIM
        '
        Me.CCSIRIM.DataPropertyName = "CCSIRIM"
        Me.CCSIRIM.HeaderText = "CC SIRIM - (2531 & 2532) (2511 & 2512)"
        Me.CCSIRIM.Name = "CCSIRIM"
        '
        'CCOTHERS
        '
        Me.CCOTHERS.DataPropertyName = "CCOTHERS"
        Me.CCOTHERS.HeaderText = "CC OTHERS - (9531 & 9532) (9511 & 9512)"
        Me.CCOTHERS.Name = "CCOTHERS"
        '
        'CPAANGKASA
        '
        Me.CPAANGKASA.DataPropertyName = "CPAANGKASA"
        Me.CPAANGKASA.HeaderText = "CPA ANGKASA - (0550 & 0551) (0513 & 0514)"
        Me.CPAANGKASA.Name = "CPAANGKASA"
        '
        'CPAOTHERS
        '
        Me.CPAOTHERS.DataPropertyName = "CPAOTHERS"
        Me.CPAOTHERS.HeaderText = "CPA OTHERS - (9550 & 9551) (9513 & 9514)"
        Me.CPAOTHERS.Name = "CPAOTHERS"
        '
        'frmCancelSum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 331)
        Me.Controls.Add(Me.lblP5)
        Me.Controls.Add(Me.lblP4)
        Me.Controls.Add(Me.lblP3)
        Me.Controls.Add(Me.lblP2)
        Me.Controls.Add(Me.lblP1)
        Me.Controls.Add(Me.dgvCancelSum)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "frmCancelSum"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancellation Summary"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvCancelSum, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvCancelSum As System.Windows.Forms.DataGridView
    Friend WithEvents lblP5 As System.Windows.Forms.Label
    Friend WithEvents lblP4 As System.Windows.Forms.Label
    Friend WithEvents lblP3 As System.Windows.Forms.Label
    Friend WithEvents lblP2 As System.Windows.Forms.Label
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents CR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCANGKASA As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CCFAMA As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CCSIRIM As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CCOTHERS As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CPAANGKASA As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CPAOTHERS As System.Windows.Forms.DataGridViewLinkColumn
End Class
