<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fEndorsSubmission
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fEndorsSubmission))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblDate_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_From = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblDate_To = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_To = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.gbPS = New System.Windows.Forms.GroupBox
        Me.lblTotalRecords = New System.Windows.Forms.Label
        Me.lblREFNO = New System.Windows.Forms.Label
        Me.llXport2Xcel = New System.Windows.Forms.LinkLabel
        Me.btnPSSubmit = New System.Windows.Forms.Button
        Me.cbAll = New System.Windows.Forms.CheckBox
        Me.dgvEPS = New System.Windows.Forms.DataGridView
        Me.colYrRSStatus = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.cmsEPS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsEPSDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvEPAI = New System.Windows.Forms.DataGridView
        Me.Approved = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.cmsEPAI = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsEPAIDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tslblESBatchNo = New System.Windows.Forms.ToolStripLabel
        Me.tscbESBatchNo = New System.Windows.Forms.ToolStripComboBox
        Me.tsbtnESGo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnPAISubmit = New System.Windows.Forms.ToolStripButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvEAI = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        Me.gbPS.SuspendLayout()
        CType(Me.dgvEPS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsEPS.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvEPAI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsEPAI.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvEAI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblDate_From, Me.tsReport_txtDate_From, Me.tsReport_lblDate_To, Me.tsReport_txtDate_To, Me.tsReport_Go, Me.tsReport_Div1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1001, 25)
        Me.tsReport.TabIndex = 8
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblDate_From
        '
        Me.tsReport_lblDate_From.Name = "tsReport_lblDate_From"
        Me.tsReport_lblDate_From.Size = New System.Drawing.Size(185, 22)
        Me.tsReport_lblDate_From.Text = "Effective Date - From (dd/mm/yyyy):"
        '
        'tsReport_txtDate_From
        '
        Me.tsReport_txtDate_From.MaxLength = 10
        Me.tsReport_txtDate_From.Name = "tsReport_txtDate_From"
        Me.tsReport_txtDate_From.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_lblDate_To
        '
        Me.tsReport_lblDate_To.Name = "tsReport_lblDate_To"
        Me.tsReport_lblDate_To.Size = New System.Drawing.Size(173, 22)
        Me.tsReport_lblDate_To.Text = "Effective Date - To (dd/mm/yyyy):"
        '
        'tsReport_txtDate_To
        '
        Me.tsReport_txtDate_To.MaxLength = 10
        Me.tsReport_txtDate_To.Name = "tsReport_txtDate_To"
        Me.tsReport_txtDate_To.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_Go
        '
        Me.tsReport_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsReport_Go.Image = CType(resources.GetObject("tsReport_Go.Image"), System.Drawing.Image)
        Me.tsReport_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Go.Name = "tsReport_Go"
        Me.tsReport_Go.Size = New System.Drawing.Size(24, 22)
        Me.tsReport_Go.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'gbPS
        '
        Me.gbPS.Controls.Add(Me.lblTotalRecords)
        Me.gbPS.Controls.Add(Me.lblREFNO)
        Me.gbPS.Controls.Add(Me.llXport2Xcel)
        Me.gbPS.Controls.Add(Me.btnPSSubmit)
        Me.gbPS.Controls.Add(Me.cbAll)
        Me.gbPS.Controls.Add(Me.dgvEPS)
        Me.gbPS.Location = New System.Drawing.Point(0, 29)
        Me.gbPS.Name = "gbPS"
        Me.gbPS.Size = New System.Drawing.Size(994, 238)
        Me.gbPS.TabIndex = 9
        Me.gbPS.TabStop = False
        Me.gbPS.Text = "Pending Submission"
        '
        'lblTotalRecords
        '
        Me.lblTotalRecords.AutoSize = True
        Me.lblTotalRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRecords.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalRecords.Location = New System.Drawing.Point(622, 27)
        Me.lblTotalRecords.Name = "lblTotalRecords"
        Me.lblTotalRecords.Size = New System.Drawing.Size(99, 13)
        Me.lblTotalRecords.TabIndex = 6
        Me.lblTotalRecords.Text = "Total Records : "
        '
        'lblREFNO
        '
        Me.lblREFNO.AutoSize = True
        Me.lblREFNO.Location = New System.Drawing.Point(756, 21)
        Me.lblREFNO.Name = "lblREFNO"
        Me.lblREFNO.Size = New System.Drawing.Size(44, 13)
        Me.lblREFNO.TabIndex = 5
        Me.lblREFNO.Text = "REFNO"
        Me.lblREFNO.Visible = False
        '
        'llXport2Xcel
        '
        Me.llXport2Xcel.AutoSize = True
        Me.llXport2Xcel.Location = New System.Drawing.Point(903, 21)
        Me.llXport2Xcel.Name = "llXport2Xcel"
        Me.llXport2Xcel.Size = New System.Drawing.Size(78, 13)
        Me.llXport2Xcel.TabIndex = 4
        Me.llXport2Xcel.TabStop = True
        Me.llXport2Xcel.Text = "Export to Excel"
        '
        'btnPSSubmit
        '
        Me.btnPSSubmit.Location = New System.Drawing.Point(815, 19)
        Me.btnPSSubmit.Name = "btnPSSubmit"
        Me.btnPSSubmit.Size = New System.Drawing.Size(66, 23)
        Me.btnPSSubmit.TabIndex = 3
        Me.btnPSSubmit.Text = "Submit"
        Me.btnPSSubmit.UseVisualStyleBackColor = True
        '
        'cbAll
        '
        Me.cbAll.AutoSize = True
        Me.cbAll.Location = New System.Drawing.Point(12, 27)
        Me.cbAll.Name = "cbAll"
        Me.cbAll.Size = New System.Drawing.Size(70, 17)
        Me.cbAll.TabIndex = 2
        Me.cbAll.Text = "Select All"
        Me.cbAll.UseVisualStyleBackColor = True
        '
        'dgvEPS
        '
        Me.dgvEPS.AllowUserToAddRows = False
        Me.dgvEPS.AllowUserToDeleteRows = False
        Me.dgvEPS.AllowUserToOrderColumns = True
        Me.dgvEPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEPS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colYrRSStatus})
        Me.dgvEPS.ContextMenuStrip = Me.cmsEPS
        Me.dgvEPS.Location = New System.Drawing.Point(6, 53)
        Me.dgvEPS.Name = "dgvEPS"
        Me.dgvEPS.Size = New System.Drawing.Size(975, 179)
        Me.dgvEPS.TabIndex = 1
        '
        'colYrRSStatus
        '
        Me.colYrRSStatus.FalseValue = "0"
        Me.colYrRSStatus.HeaderText = "Tick"
        Me.colYrRSStatus.Name = "colYrRSStatus"
        Me.colYrRSStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colYrRSStatus.TrueValue = "1"
        '
        'cmsEPS
        '
        Me.cmsEPS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsEPSDelete})
        Me.cmsEPS.Name = "cmsPA"
        Me.cmsEPS.Size = New System.Drawing.Size(117, 26)
        '
        'cmsEPSDelete
        '
        Me.cmsEPSDelete.Name = "cmsEPSDelete"
        Me.cmsEPSDelete.Size = New System.Drawing.Size(116, 22)
        Me.cmsEPSDelete.Text = "Delete"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvEPAI)
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 274)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(994, 235)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pending Approval List from Insurer"
        '
        'dgvEPAI
        '
        Me.dgvEPAI.AllowUserToAddRows = False
        Me.dgvEPAI.AllowUserToDeleteRows = False
        Me.dgvEPAI.AllowUserToOrderColumns = True
        Me.dgvEPAI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEPAI.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Approved})
        Me.dgvEPAI.ContextMenuStrip = Me.cmsEPAI
        Me.dgvEPAI.Location = New System.Drawing.Point(3, 44)
        Me.dgvEPAI.Name = "dgvEPAI"
        Me.dgvEPAI.Size = New System.Drawing.Size(988, 179)
        Me.dgvEPAI.TabIndex = 10
        '
        'Approved
        '
        Me.Approved.FalseValue = "0"
        Me.Approved.HeaderText = "Tick"
        Me.Approved.Name = "Approved"
        Me.Approved.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approved.TrueValue = "1"
        '
        'cmsEPAI
        '
        Me.cmsEPAI.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsEPAIDelete})
        Me.cmsEPAI.Name = "cmsPA"
        Me.cmsEPAI.Size = New System.Drawing.Size(153, 48)
        '
        'cmsEPAIDelete
        '
        Me.cmsEPAIDelete.Name = "cmsEPAIDelete"
        Me.cmsEPAIDelete.Size = New System.Drawing.Size(152, 22)
        Me.cmsEPAIDelete.Text = "Delete"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblESBatchNo, Me.tscbESBatchNo, Me.tsbtnESGo, Me.ToolStripSeparator1, Me.btnPAISubmit})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(988, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip"
        '
        'tslblESBatchNo
        '
        Me.tslblESBatchNo.Name = "tslblESBatchNo"
        Me.tslblESBatchNo.Size = New System.Drawing.Size(112, 22)
        Me.tslblESBatchNo.Text = "Submission Batch No :"
        '
        'tscbESBatchNo
        '
        Me.tscbESBatchNo.MaxLength = 10
        Me.tscbESBatchNo.Name = "tscbESBatchNo"
        Me.tscbESBatchNo.Size = New System.Drawing.Size(175, 25)
        '
        'tsbtnESGo
        '
        Me.tsbtnESGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnESGo.Image = CType(resources.GetObject("tsbtnESGo.Image"), System.Drawing.Image)
        Me.tsbtnESGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnESGo.Name = "tsbtnESGo"
        Me.tsbtnESGo.Size = New System.Drawing.Size(24, 22)
        Me.tsbtnESGo.Text = "Go"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnPAISubmit
        '
        Me.btnPAISubmit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnPAISubmit.Image = CType(resources.GetObject("btnPAISubmit.Image"), System.Drawing.Image)
        Me.btnPAISubmit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPAISubmit.Name = "btnPAISubmit"
        Me.btnPAISubmit.Size = New System.Drawing.Size(43, 22)
        Me.btnPAISubmit.Text = "Submit"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvEAI)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 515)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(994, 183)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Aprroved List from Insurer"
        '
        'dgvEAI
        '
        Me.dgvEAI.AllowUserToAddRows = False
        Me.dgvEAI.AllowUserToDeleteRows = False
        Me.dgvEAI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEAI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEAI.Location = New System.Drawing.Point(3, 16)
        Me.dgvEAI.Name = "dgvEAI"
        Me.dgvEAI.Size = New System.Drawing.Size(988, 164)
        Me.dgvEAI.TabIndex = 0
        '
        'fEndorsSubmission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 703)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbPS)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "fEndorsSubmission"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Endorsement Submission"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.gbPS.ResumeLayout(False)
        Me.gbPS.PerformLayout()
        CType(Me.dgvEPS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsEPS.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvEPAI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsEPAI.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvEAI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblDate_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDate_From As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_lblDate_To As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDate_To As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbPS As System.Windows.Forms.GroupBox
    Friend WithEvents dgvEPS As System.Windows.Forms.DataGridView
    Friend WithEvents cbAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnPSSubmit As System.Windows.Forms.Button
    Friend WithEvents llXport2Xcel As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblESBatchNo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbESBatchNo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsbtnESGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvEPAI As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvEAI As System.Windows.Forms.DataGridView
    Friend WithEvents colYrRSStatus As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lblREFNO As System.Windows.Forms.Label
    Friend WithEvents lblTotalRecords As System.Windows.Forms.Label
    Friend WithEvents btnPAISubmit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Approved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmsEPS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsEPSDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsEPAI As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsEPAIDelete As System.Windows.Forms.ToolStripMenuItem
End Class
