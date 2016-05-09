<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fYrInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fYrInvoice))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslblPlanType = New System.Windows.Forms.ToolStripLabel
        Me.tscbPlanType = New System.Windows.Forms.ToolStripComboBox
        Me.tslblYR = New System.Windows.Forms.ToolStripLabel
        Me.tscbYR = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tslblMonth = New System.Windows.Forms.ToolStripLabel
        Me.tscbMonth = New System.Windows.Forms.ToolStripComboBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tslblRecordCounter = New System.Windows.Forms.ToolStripLabel
        Me.dgvYrInvoice = New System.Windows.Forms.DataGridView
        Me.gbYRPremiumUpdate = New System.Windows.Forms.GroupBox
        Me.dgvYRPremiumUpdate = New System.Windows.Forms.DataGridView
        Me.CHEQUENO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RECEIPTNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Browse = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fileBrowse = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Submit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.View = New System.Windows.Forms.DataGridViewLinkColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvYRPremiumClosed = New System.Windows.Forms.DataGridView
        Me.cView = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsbtnXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsReport.SuspendLayout()
        CType(Me.dgvYrInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbYRPremiumUpdate.SuspendLayout()
        CType(Me.dgvYRPremiumUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvYRPremiumClosed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblPlanType, Me.tscbPlanType, Me.tslblYR, Me.tscbYR, Me.ToolStripSeparator2, Me.tslblMonth, Me.tscbMonth, Me.tsbtnGo, Me.tsReport_Div1, Me.tsbtnExport, Me.ToolStripSeparator1, Me.tslblRecordCounter, Me.ToolStripSeparator3, Me.tsbtnXport2Xcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(972, 25)
        Me.tsReport.TabIndex = 2
        Me.tsReport.Text = "ToolStrip"
        '
        'tslblPlanType
        '
        Me.tslblPlanType.Name = "tslblPlanType"
        Me.tslblPlanType.Size = New System.Drawing.Size(59, 22)
        Me.tslblPlanType.Text = "Plan Type"
        '
        'tscbPlanType
        '
        Me.tscbPlanType.Name = "tscbPlanType"
        Me.tscbPlanType.Size = New System.Drawing.Size(221, 25)
        '
        'tslblYR
        '
        Me.tslblYR.Name = "tslblYR"
        Me.tslblYR.Size = New System.Drawing.Size(30, 22)
        Me.tslblYR.Text = "Year"
        '
        'tscbYR
        '
        Me.tscbYR.Name = "tscbYR"
        Me.tscbYR.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tslblMonth
        '
        Me.tslblMonth.Name = "tslblMonth"
        Me.tslblMonth.Size = New System.Drawing.Size(49, 22)
        Me.tslblMonth.Text = "Month :"
        '
        'tscbMonth
        '
        Me.tscbMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.tscbMonth.Name = "tscbMonth"
        Me.tscbMonth.Size = New System.Drawing.Size(121, 25)
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(26, 22)
        Me.tsbtnGo.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnExport
        '
        Me.tsbtnExport.Image = CType(resources.GetObject("tsbtnExport.Image"), System.Drawing.Image)
        Me.tsbtnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExport.Name = "tsbtnExport"
        Me.tsbtnExport.Size = New System.Drawing.Size(65, 22)
        Me.tsbtnExport.Text = "Submit"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tslblRecordCounter
        '
        Me.tslblRecordCounter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.tslblRecordCounter.Name = "tslblRecordCounter"
        Me.tslblRecordCounter.Size = New System.Drawing.Size(82, 22)
        Me.tslblRecordCounter.Text = "Total Records :"
        '
        'dgvYrInvoice
        '
        Me.dgvYrInvoice.AllowUserToAddRows = False
        Me.dgvYrInvoice.AllowUserToDeleteRows = False
        Me.dgvYrInvoice.AllowUserToOrderColumns = True
        Me.dgvYrInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYrInvoice.Location = New System.Drawing.Point(17, 25)
        Me.dgvYrInvoice.MultiSelect = False
        Me.dgvYrInvoice.Name = "dgvYrInvoice"
        Me.dgvYrInvoice.ReadOnly = True
        Me.dgvYrInvoice.Size = New System.Drawing.Size(932, 160)
        Me.dgvYrInvoice.TabIndex = 10
        '
        'gbYRPremiumUpdate
        '
        Me.gbYRPremiumUpdate.Controls.Add(Me.dgvYRPremiumUpdate)
        Me.gbYRPremiumUpdate.Location = New System.Drawing.Point(17, 191)
        Me.gbYRPremiumUpdate.Name = "gbYRPremiumUpdate"
        Me.gbYRPremiumUpdate.Size = New System.Drawing.Size(932, 173)
        Me.gbYRPremiumUpdate.TabIndex = 11
        Me.gbYRPremiumUpdate.TabStop = False
        Me.gbYRPremiumUpdate.Text = "Yearly Premium Update "
        '
        'dgvYRPremiumUpdate
        '
        Me.dgvYRPremiumUpdate.AllowUserToAddRows = False
        Me.dgvYRPremiumUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYRPremiumUpdate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHEQUENO, Me.RECEIPTNO, Me.Browse, Me.fileBrowse, Me.Submit, Me.View})
        Me.dgvYRPremiumUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvYRPremiumUpdate.Location = New System.Drawing.Point(3, 16)
        Me.dgvYRPremiumUpdate.Name = "dgvYRPremiumUpdate"
        Me.dgvYRPremiumUpdate.Size = New System.Drawing.Size(926, 154)
        Me.dgvYRPremiumUpdate.TabIndex = 0
        '
        'CHEQUENO
        '
        Me.CHEQUENO.HeaderText = "CHEQUE NO"
        Me.CHEQUENO.Name = "CHEQUENO"
        '
        'RECEIPTNO
        '
        Me.RECEIPTNO.HeaderText = "RECEIPT NO"
        Me.RECEIPTNO.Name = "RECEIPTNO"
        '
        'Browse
        '
        Me.Browse.HeaderText = "File"
        Me.Browse.Name = "Browse"
        Me.Browse.ReadOnly = True
        '
        'fileBrowse
        '
        Me.fileBrowse.HeaderText = "Browse"
        Me.fileBrowse.Name = "fileBrowse"
        Me.fileBrowse.ReadOnly = True
        Me.fileBrowse.Text = "Browse"
        Me.fileBrowse.ToolTipText = "Browse"
        Me.fileBrowse.UseColumnTextForLinkValue = True
        '
        'Submit
        '
        Me.Submit.HeaderText = "Submit"
        Me.Submit.Name = "Submit"
        Me.Submit.ReadOnly = True
        Me.Submit.Text = "Submit"
        Me.Submit.ToolTipText = "Submit"
        Me.Submit.UseColumnTextForLinkValue = True
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.ReadOnly = True
        Me.View.Text = "View"
        Me.View.ToolTipText = "View"
        Me.View.UseColumnTextForLinkValue = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvYRPremiumClosed)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 370)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(932, 173)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Yearly Premium Closed "
        '
        'dgvYRPremiumClosed
        '
        Me.dgvYRPremiumClosed.AllowUserToAddRows = False
        Me.dgvYRPremiumClosed.AllowUserToDeleteRows = False
        Me.dgvYRPremiumClosed.AllowUserToOrderColumns = True
        Me.dgvYRPremiumClosed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYRPremiumClosed.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cView})
        Me.dgvYRPremiumClosed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvYRPremiumClosed.Location = New System.Drawing.Point(3, 16)
        Me.dgvYRPremiumClosed.Name = "dgvYRPremiumClosed"
        Me.dgvYRPremiumClosed.ReadOnly = True
        Me.dgvYRPremiumClosed.Size = New System.Drawing.Size(926, 154)
        Me.dgvYRPremiumClosed.TabIndex = 0
        '
        'cView
        '
        Me.cView.HeaderText = "View"
        Me.cView.Name = "cView"
        Me.cView.ReadOnly = True
        Me.cView.Text = "View"
        Me.cView.ToolTipText = "View"
        Me.cView.UseColumnTextForLinkValue = True
        '
        'tsbtnXport2Xcel
        '
        Me.tsbtnXport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnXport2Xcel.Image = CType(resources.GetObject("tsbtnXport2Xcel.Image"), System.Drawing.Image)
        Me.tsbtnXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnXport2Xcel.Name = "tsbtnXport2Xcel"
        Me.tsbtnXport2Xcel.Size = New System.Drawing.Size(87, 22)
        Me.tsbtnXport2Xcel.Text = "Export to Excel"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'fYrInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 570)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gbYRPremiumUpdate)
        Me.Controls.Add(Me.dgvYrInvoice)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fYrInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Yearly Pending Renewal Invoice Listing"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvYrInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbYRPremiumUpdate.ResumeLayout(False)
        CType(Me.dgvYRPremiumUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvYRPremiumClosed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvYrInvoice As System.Windows.Forms.DataGridView
    Friend WithEvents tslblMonth As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbMonth As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tslblPlanType As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbPlanType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslblRecordCounter As System.Windows.Forms.ToolStripLabel
    Friend WithEvents gbYRPremiumUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvYRPremiumUpdate As System.Windows.Forms.DataGridView
    Friend WithEvents dgvYRPremiumClosed As System.Windows.Forms.DataGridView
    Friend WithEvents cView As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CHEQUENO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RECEIPTNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Browse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fileBrowse As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Submit As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents View As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents tslblYR As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbYR As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnXport2Xcel As System.Windows.Forms.ToolStripButton
End Class
