<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Renewal_Yr_Submission
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Renewal_Yr_Submission))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblDate_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_From = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblDate_To = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDate_To = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvYrRenewalSub = New System.Windows.Forms.DataGridView
        Me.gbRenewal = New System.Windows.Forms.GroupBox
        Me.gbYrRenewalPending = New System.Windows.Forms.GroupBox
        Me.llXport2Xcel = New System.Windows.Forms.LinkLabel
        Me.cbAll = New System.Windows.Forms.CheckBox
        Me.dgvYrRenewalPend = New System.Windows.Forms.DataGridView
        Me.colYrRSStatus = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsReport.SuspendLayout()
        CType(Me.dgvYrRenewalSub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRenewal.SuspendLayout()
        Me.gbYrRenewalPending.SuspendLayout()
        CType(Me.dgvYrRenewalPend, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblDate_From, Me.tsReport_txtDate_From, Me.tsReport_lblDate_To, Me.tsReport_txtDate_To, Me.tsReport_Go, Me.tsReport_Div1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1045, 25)
        Me.tsReport.TabIndex = 2
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblDate_From
        '
        Me.tsReport_lblDate_From.Name = "tsReport_lblDate_From"
        Me.tsReport_lblDate_From.Size = New System.Drawing.Size(183, 22)
        Me.tsReport_lblDate_From.Text = "Renewal Date - From (dd/mm/yyyy):"
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
        Me.tsReport_lblDate_To.Size = New System.Drawing.Size(171, 22)
        Me.tsReport_lblDate_To.Text = "Renewal Date - To (dd/mm/yyyy):"
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
        'dgvYrRenewalSub
        '
        Me.dgvYrRenewalSub.AllowUserToAddRows = False
        Me.dgvYrRenewalSub.AllowUserToDeleteRows = False
        Me.dgvYrRenewalSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYrRenewalSub.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.View})
        Me.dgvYrRenewalSub.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvYrRenewalSub.Location = New System.Drawing.Point(3, 16)
        Me.dgvYrRenewalSub.Name = "dgvYrRenewalSub"
        Me.dgvYrRenewalSub.Size = New System.Drawing.Size(1008, 183)
        Me.dgvYrRenewalSub.TabIndex = 3
        '
        'gbRenewal
        '
        Me.gbRenewal.Controls.Add(Me.dgvYrRenewalSub)
        Me.gbRenewal.Location = New System.Drawing.Point(12, 323)
        Me.gbRenewal.Name = "gbRenewal"
        Me.gbRenewal.Size = New System.Drawing.Size(1014, 202)
        Me.gbRenewal.TabIndex = 4
        Me.gbRenewal.TabStop = False
        Me.gbRenewal.Text = "Submitted"
        '
        'gbYrRenewalPending
        '
        Me.gbYrRenewalPending.Controls.Add(Me.btnUpdate)
        Me.gbYrRenewalPending.Controls.Add(Me.llXport2Xcel)
        Me.gbYrRenewalPending.Controls.Add(Me.cbAll)
        Me.gbYrRenewalPending.Controls.Add(Me.dgvYrRenewalPend)
        Me.gbYrRenewalPending.Location = New System.Drawing.Point(12, 28)
        Me.gbYrRenewalPending.Name = "gbYrRenewalPending"
        Me.gbYrRenewalPending.Size = New System.Drawing.Size(1014, 289)
        Me.gbYrRenewalPending.TabIndex = 5
        Me.gbYrRenewalPending.TabStop = False
        Me.gbYrRenewalPending.Text = "Pending"
        '
        'llXport2Xcel
        '
        Me.llXport2Xcel.AutoSize = True
        Me.llXport2Xcel.Location = New System.Drawing.Point(904, 24)
        Me.llXport2Xcel.Name = "llXport2Xcel"
        Me.llXport2Xcel.Size = New System.Drawing.Size(78, 13)
        Me.llXport2Xcel.TabIndex = 2
        Me.llXport2Xcel.TabStop = True
        Me.llXport2Xcel.Text = "Export to Excel"
        '
        'cbAll
        '
        Me.cbAll.AutoSize = True
        Me.cbAll.Location = New System.Drawing.Point(41, 24)
        Me.cbAll.Name = "cbAll"
        Me.cbAll.Size = New System.Drawing.Size(70, 17)
        Me.cbAll.TabIndex = 1
        Me.cbAll.Text = "Select All"
        Me.cbAll.UseVisualStyleBackColor = True
        '
        'dgvYrRenewalPend
        '
        Me.dgvYrRenewalPend.AllowUserToAddRows = False
        Me.dgvYrRenewalPend.AllowUserToDeleteRows = False
        Me.dgvYrRenewalPend.AllowUserToOrderColumns = True
        Me.dgvYrRenewalPend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYrRenewalPend.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colYrRSStatus})
        Me.dgvYrRenewalPend.Location = New System.Drawing.Point(23, 47)
        Me.dgvYrRenewalPend.Name = "dgvYrRenewalPend"
        Me.dgvYrRenewalPend.Size = New System.Drawing.Size(967, 194)
        Me.dgvYrRenewalPend.TabIndex = 0
        '
        'colYrRSStatus
        '
        Me.colYrRSStatus.FalseValue = "0"
        Me.colYrRSStatus.HeaderText = "Status"
        Me.colYrRSStatus.Name = "colYrRSStatus"
        Me.colYrRSStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colYrRSStatus.TrueValue = "1"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(433, 252)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Submit"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.Text = "View"
        Me.View.ToolTipText = "View"
        Me.View.UseColumnTextForLinkValue = True
        '
        'Renewal_Yr_Submission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 537)
        Me.Controls.Add(Me.gbYrRenewalPending)
        Me.Controls.Add(Me.gbRenewal)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Renewal_Yr_Submission"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Renewal Yearly Submission"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvYrRenewalSub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRenewal.ResumeLayout(False)
        Me.gbYrRenewalPending.ResumeLayout(False)
        Me.gbYrRenewalPending.PerformLayout()
        CType(Me.dgvYrRenewalPend, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvYrRenewalSub As System.Windows.Forms.DataGridView
    Friend WithEvents gbRenewal As System.Windows.Forms.GroupBox
    Friend WithEvents gbYrRenewalPending As System.Windows.Forms.GroupBox
    Friend WithEvents dgvYrRenewalPend As System.Windows.Forms.DataGridView
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents colYrRSStatus As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cbAll As System.Windows.Forms.CheckBox
    Friend WithEvents llXport2Xcel As System.Windows.Forms.LinkLabel
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
End Class
