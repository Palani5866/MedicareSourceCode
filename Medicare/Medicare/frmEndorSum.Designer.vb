<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEndorSum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEndorSum))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tslblDateFrm = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.tslblDateTo = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsbExport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.tsS = New System.Windows.Forms.ToolStripSeparator
        Me.dgvEndorSum = New System.Windows.Forms.DataGridView
        Me.BATCHNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TOTNOOFCASES = New System.Windows.Forms.DataGridViewLinkColumn
        Me.RFI = New System.Windows.Forms.DataGridViewLinkColumn
        Me.PWI = New System.Windows.Forms.DataGridViewLinkColumn
        Me.lblP1 = New System.Windows.Forms.Label
        Me.lblP2 = New System.Windows.Forms.Label
        Me.lblP3 = New System.Windows.Forms.Label
        Me.lblP4 = New System.Windows.Forms.Label
        Me.lblP5 = New System.Windows.Forms.Label
        Me.tolForm.SuspendLayout()
        CType(Me.dgvEndorSum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblDateFrm, Me.tstxtDateFrom, Me.tslblDateTo, Me.tstxtDateTo, Me.tsbtnGo, Me.tsbExport2Xcel, Me.tsS})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tolForm.Size = New System.Drawing.Size(885, 25)
        Me.tolForm.TabIndex = 3
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
        'dgvEndorSum
        '
        Me.dgvEndorSum.AllowUserToAddRows = False
        Me.dgvEndorSum.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEndorSum.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEndorSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEndorSum.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BATCHNO, Me.TOTNOOFCASES, Me.RFI, Me.PWI})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEndorSum.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEndorSum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEndorSum.Location = New System.Drawing.Point(0, 25)
        Me.dgvEndorSum.Name = "dgvEndorSum"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEndorSum.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEndorSum.Size = New System.Drawing.Size(885, 237)
        Me.dgvEndorSum.TabIndex = 4
        '
        'BATCHNO
        '
        Me.BATCHNO.DataPropertyName = "BATCHNO"
        Me.BATCHNO.HeaderText = "BATCHNO"
        Me.BATCHNO.Name = "BATCHNO"
        '
        'TOTNOOFCASES
        '
        Me.TOTNOOFCASES.DataPropertyName = "TOTNOOFCASES"
        Me.TOTNOOFCASES.HeaderText = "TOTAL NO OF CASES"
        Me.TOTNOOFCASES.Name = "TOTNOOFCASES"
        '
        'RFI
        '
        Me.RFI.DataPropertyName = "RFI"
        Me.RFI.HeaderText = "RECEIVED FROM INSURER"
        Me.RFI.Name = "RFI"
        '
        'PWI
        '
        Me.PWI.DataPropertyName = "PWI"
        Me.PWI.HeaderText = "PENDING WITH INSURER"
        Me.PWI.Name = "PWI"
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(332, 110)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 5
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'lblP2
        '
        Me.lblP2.AutoSize = True
        Me.lblP2.Location = New System.Drawing.Point(432, 125)
        Me.lblP2.Name = "lblP2"
        Me.lblP2.Size = New System.Drawing.Size(20, 13)
        Me.lblP2.TabIndex = 6
        Me.lblP2.Text = "P2"
        Me.lblP2.Visible = False
        '
        'lblP3
        '
        Me.lblP3.AutoSize = True
        Me.lblP3.Location = New System.Drawing.Point(440, 133)
        Me.lblP3.Name = "lblP3"
        Me.lblP3.Size = New System.Drawing.Size(20, 13)
        Me.lblP3.TabIndex = 7
        Me.lblP3.Text = "P3"
        Me.lblP3.Visible = False
        '
        'lblP4
        '
        Me.lblP4.AutoSize = True
        Me.lblP4.Location = New System.Drawing.Point(471, 173)
        Me.lblP4.Name = "lblP4"
        Me.lblP4.Size = New System.Drawing.Size(20, 13)
        Me.lblP4.TabIndex = 8
        Me.lblP4.Text = "P4"
        Me.lblP4.Visible = False
        '
        'lblP5
        '
        Me.lblP5.AutoSize = True
        Me.lblP5.Location = New System.Drawing.Point(603, 141)
        Me.lblP5.Name = "lblP5"
        Me.lblP5.Size = New System.Drawing.Size(20, 13)
        Me.lblP5.TabIndex = 9
        Me.lblP5.Text = "P5"
        Me.lblP5.Visible = False
        '
        'frmEndorSum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 262)
        Me.Controls.Add(Me.lblP5)
        Me.Controls.Add(Me.lblP4)
        Me.Controls.Add(Me.lblP3)
        Me.Controls.Add(Me.lblP2)
        Me.Controls.Add(Me.lblP1)
        Me.Controls.Add(Me.dgvEndorSum)
        Me.Controls.Add(Me.tolForm)
        Me.Name = "frmEndorSum"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Endorsement Summary"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvEndorSum, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvEndorSum As System.Windows.Forms.DataGridView
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents lblP2 As System.Windows.Forms.Label
    Friend WithEvents lblP3 As System.Windows.Forms.Label
    Friend WithEvents lblP4 As System.Windows.Forms.Label
    Friend WithEvents lblP5 As System.Windows.Forms.Label
    Friend WithEvents BATCHNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTNOOFCASES As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents RFI As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents PWI As System.Windows.Forms.DataGridViewLinkColumn
End Class
