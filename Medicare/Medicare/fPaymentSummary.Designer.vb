<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPaymentSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fPaymentSummary))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslblDateTo = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDate = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvPaymentSummary = New System.Windows.Forms.DataGridView
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Xport = New System.Windows.Forms.ToolStripButton
        Me.tscbSearchBy = New System.Windows.Forms.ToolStripComboBox
        Me.tslblSearch = New System.Windows.Forms.ToolStripLabel
        Me.tsReport.SuspendLayout()
        CType(Me.dgvPaymentSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblSearch, Me.tscbSearchBy, Me.tslblDateTo, Me.tstxtDate, Me.tsReport_Div1, Me.tsbtnGo, Me.ToolStripSeparator1, Me.tsReport_Xport})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(984, 25)
        Me.tsReport.TabIndex = 19
        Me.tsReport.Text = "ToolStrip"
        '
        'tslblDateTo
        '
        Me.tslblDateTo.Name = "tslblDateTo"
        Me.tslblDateTo.Size = New System.Drawing.Size(140, 22)
        Me.tslblDateTo.Text = "Date - To (dd/mm/yyyy):"
        '
        'tstxtDate
        '
        Me.tstxtDate.MaxLength = 10
        Me.tstxtDate.Name = "tstxtDate"
        Me.tstxtDate.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'dgvPaymentSummary
        '
        Me.dgvPaymentSummary.AllowUserToAddRows = False
        Me.dgvPaymentSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPaymentSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPaymentSummary.Location = New System.Drawing.Point(0, 25)
        Me.dgvPaymentSummary.Name = "dgvPaymentSummary"
        Me.dgvPaymentSummary.Size = New System.Drawing.Size(984, 418)
        Me.dgvPaymentSummary.TabIndex = 20
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(35, 22)
        Me.tsbtnGo.Text = "Go..."
        '
        'tsReport_Xport
        '
        Me.tsReport_Xport.Image = CType(resources.GetObject("tsReport_Xport.Image"), System.Drawing.Image)
        Me.tsReport_Xport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Xport.Name = "tsReport_Xport"
        Me.tsReport_Xport.Size = New System.Drawing.Size(103, 22)
        Me.tsReport_Xport.Text = "Export to Excel"
        '
        'tscbSearchBy
        '
        Me.tscbSearchBy.Items.AddRange(New Object() {"CREDIT CARD", "CASH AND CHEQUE"})
        Me.tscbSearchBy.Name = "tscbSearchBy"
        Me.tscbSearchBy.Size = New System.Drawing.Size(121, 25)
        '
        'tslblSearch
        '
        Me.tslblSearch.Name = "tslblSearch"
        Me.tslblSearch.Size = New System.Drawing.Size(64, 22)
        Me.tslblSearch.Text = "Search By :"
        '
        'fPaymentSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 443)
        Me.Controls.Add(Me.dgvPaymentSummary)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "fPaymentSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment Summary"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvPaymentSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblDateTo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDate As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsReport_Xport As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvPaymentSummary As System.Windows.Forms.DataGridView
    Friend WithEvents tslblSearch As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbSearchBy As System.Windows.Forms.ToolStripComboBox
End Class
