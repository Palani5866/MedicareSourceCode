<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPremiumIncrease
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fPremiumIncrease))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvForm = New System.Windows.Forms.DataGridView
        Me.colDeduction_BatchSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblMonth = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_ddlMonth = New System.Windows.Forms.ToolStripComboBox
        Me.tsReport_lblDeductionCode_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_From = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_To = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvPIRequested = New System.Windows.Forms.DataGridView
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Upload = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Download = New System.Windows.Forms.DataGridViewButtonColumn
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblRF1 = New System.Windows.Forms.Label
        Me.lblRF2 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsReport.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPIRequested, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvForm)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1066, 287)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pending Request for Premium Increase"
        '
        'dgvForm
        '
        Me.dgvForm.AllowUserToAddRows = False
        Me.dgvForm.AllowUserToDeleteRows = False
        Me.dgvForm.AllowUserToOrderColumns = True
        Me.dgvForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvForm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDeduction_BatchSelected})
        Me.dgvForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvForm.Location = New System.Drawing.Point(3, 16)
        Me.dgvForm.MultiSelect = False
        Me.dgvForm.Name = "dgvForm"
        Me.dgvForm.Size = New System.Drawing.Size(1060, 268)
        Me.dgvForm.TabIndex = 6
        '
        'colDeduction_BatchSelected
        '
        Me.colDeduction_BatchSelected.FalseValue = "F"
        Me.colDeduction_BatchSelected.HeaderText = "(Tick)"
        Me.colDeduction_BatchSelected.IndeterminateValue = ""
        Me.colDeduction_BatchSelected.Name = "colDeduction_BatchSelected"
        Me.colDeduction_BatchSelected.TrueValue = "T"
        Me.colDeduction_BatchSelected.Width = 50
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblMonth, Me.tsReport_ddlMonth, Me.tsReport_lblDeductionCode_From, Me.tsReport_txtDeductionCode_From, Me.ToolStripLabel1, Me.tsReport_txtDeductionCode_To, Me.tsReport_Go, Me.tsReport_Div1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1072, 25)
        Me.tsReport.TabIndex = 1
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblMonth
        '
        Me.tsReport_lblMonth.Name = "tsReport_lblMonth"
        Me.tsReport_lblMonth.Size = New System.Drawing.Size(132, 22)
        Me.tsReport_lblMonth.Text = "Premium Increase Month :"
        '
        'tsReport_ddlMonth
        '
        Me.tsReport_ddlMonth.Name = "tsReport_ddlMonth"
        Me.tsReport_ddlMonth.Size = New System.Drawing.Size(75, 25)
        '
        'tsReport_lblDeductionCode_From
        '
        Me.tsReport_lblDeductionCode_From.Name = "tsReport_lblDeductionCode_From"
        Me.tsReport_lblDeductionCode_From.Size = New System.Drawing.Size(121, 22)
        Me.tsReport_lblDeductionCode_From.Text = "Deduction Code - From:"
        '
        'tsReport_txtDeductionCode_From
        '
        Me.tsReport_txtDeductionCode_From.MaxLength = 10
        Me.tsReport_txtDeductionCode_From.Name = "tsReport_txtDeductionCode_From"
        Me.tsReport_txtDeductionCode_From.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(109, 22)
        Me.ToolStripLabel1.Text = "Deduction Code - To:"
        '
        'tsReport_txtDeductionCode_To
        '
        Me.tsReport_txtDeductionCode_To.MaxLength = 10
        Me.tsReport_txtDeductionCode_To.Name = "tsReport_txtDeductionCode_To"
        Me.tsReport_txtDeductionCode_To.Size = New System.Drawing.Size(100, 25)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvPIRequested)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 355)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1060, 179)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Requested Premium Increase"
        '
        'dgvPIRequested
        '
        Me.dgvPIRequested.AllowUserToAddRows = False
        Me.dgvPIRequested.AllowUserToDeleteRows = False
        Me.dgvPIRequested.AllowUserToOrderColumns = True
        Me.dgvPIRequested.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPIRequested.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.View, Me.Upload, Me.Download})
        Me.dgvPIRequested.Location = New System.Drawing.Point(22, 23)
        Me.dgvPIRequested.Name = "dgvPIRequested"
        Me.dgvPIRequested.Size = New System.Drawing.Size(1032, 150)
        Me.dgvPIRequested.TabIndex = 0
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
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(503, 319)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 3
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblRF1
        '
        Me.lblRF1.AutoSize = True
        Me.lblRF1.Location = New System.Drawing.Point(629, 328)
        Me.lblRF1.Name = "lblRF1"
        Me.lblRF1.Size = New System.Drawing.Size(27, 13)
        Me.lblRF1.TabIndex = 4
        Me.lblRF1.Text = "RF1"
        Me.lblRF1.Visible = False
        '
        'lblRF2
        '
        Me.lblRF2.AutoSize = True
        Me.lblRF2.Location = New System.Drawing.Point(662, 329)
        Me.lblRF2.Name = "lblRF2"
        Me.lblRF2.Size = New System.Drawing.Size(27, 13)
        Me.lblRF2.TabIndex = 5
        Me.lblRF2.Text = "RF2"
        Me.lblRF2.Visible = False
        '
        'fPremiumIncrease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1072, 546)
        Me.Controls.Add(Me.lblRF2)
        Me.Controls.Add(Me.lblRF1)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.tsReport)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fPremiumIncrease"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Premium Increase"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvPIRequested, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblMonth As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_ddlMonth As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsReport_lblDeductionCode_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_From As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_To As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblRF1 As System.Windows.Forms.Label
    Friend WithEvents lblRF2 As System.Windows.Forms.Label
    Friend WithEvents dgvForm As System.Windows.Forms.DataGridView
    Friend WithEvents colDeduction_BatchSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgvPIRequested As System.Windows.Forms.DataGridView
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Upload As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Download As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
