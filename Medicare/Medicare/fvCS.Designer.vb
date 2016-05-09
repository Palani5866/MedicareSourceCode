<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fvCS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fvCS))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslblSearch = New System.Windows.Forms.ToolStripLabel
        Me.tscbSearch = New System.Windows.Forms.ToolStripComboBox
        Me.tstxtSearch = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvCS = New System.Windows.Forms.DataGridView
        Me.PID = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsReport.SuspendLayout()
        CType(Me.dgvCS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblSearch, Me.tscbSearch, Me.tstxtSearch, Me.tsbtnGo, Me.tsReport_Div1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1179, 25)
        Me.tsReport.TabIndex = 11
        Me.tsReport.Text = "ToolStrip"
        '
        'tslblSearch
        '
        Me.tslblSearch.Name = "tslblSearch"
        Me.tslblSearch.Size = New System.Drawing.Size(62, 22)
        Me.tslblSearch.Text = "Search By :"
        '
        'tscbSearch
        '
        Me.tscbSearch.Items.AddRange(New Object() {"IC", "FULL NAME", "DEPENDENT IC", "DEPENDENT NAME", "FILE NO", "POLICY NO"})
        Me.tscbSearch.Name = "tscbSearch"
        Me.tscbSearch.Size = New System.Drawing.Size(121, 25)
        '
        'tstxtSearch
        '
        Me.tstxtSearch.MaxLength = 100
        Me.tstxtSearch.Name = "tstxtSearch"
        Me.tstxtSearch.Size = New System.Drawing.Size(250, 25)
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(24, 22)
        Me.tsbtnGo.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'dgvCS
        '
        Me.dgvCS.AllowUserToAddRows = False
        Me.dgvCS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PID})
        Me.dgvCS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCS.Location = New System.Drawing.Point(0, 25)
        Me.dgvCS.Name = "dgvCS"
        Me.dgvCS.Size = New System.Drawing.Size(1179, 445)
        Me.dgvCS.TabIndex = 12
        '
        'PID
        '
        Me.PID.HeaderText = "View"
        Me.PID.Name = "PID"
        Me.PID.Text = "View"
        Me.PID.ToolTipText = "View"
        Me.PID.UseColumnTextForLinkValue = True
        '
        'fvCS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 470)
        Me.Controls.Add(Me.dgvCS)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fvCS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Service"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvCS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblSearch As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbSearch As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tstxtSearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvCS As System.Windows.Forms.DataGridView
    Friend WithEvents PID As System.Windows.Forms.DataGridViewLinkColumn
End Class
