<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fYearlyPoliciesDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fYearlyPoliciesDetails))
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.tslblMonth = New System.Windows.Forms.ToolStripLabel
        Me.tscbMonth = New System.Windows.Forms.ToolStripComboBox
        Me.tslblYear = New System.Windows.Forms.ToolStripLabel
        Me.tscbYear = New System.Windows.Forms.ToolStripComboBox
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.ssReport = New System.Windows.Forms.StatusStrip
        Me.ssReport_RecordCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ssReport_Parameter = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvYrPolicies = New System.Windows.Forms.DataGridView
        Me.btnGo = New System.Windows.Forms.ToolStripButton
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.tsSearch.SuspendLayout()
        Me.ssReport.SuspendLayout()
        CType(Me.dgvYrPolicies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblMonth, Me.tscbMonth, Me.tslblYear, Me.tscbYear, Me.btnGo, Me.tsReport_Div1, Me.btnXPort})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(1060, 25)
        Me.tsSearch.TabIndex = 7
        Me.tsSearch.Text = "ToolStrip"
        '
        'tslblMonth
        '
        Me.tslblMonth.Name = "tslblMonth"
        Me.tslblMonth.Size = New System.Drawing.Size(44, 22)
        Me.tslblMonth.Text = "Month :"
        '
        'tscbMonth
        '
        Me.tscbMonth.Items.AddRange(New Object() {"January ", "February ", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.tscbMonth.MaxLength = 10
        Me.tscbMonth.Name = "tscbMonth"
        Me.tscbMonth.Size = New System.Drawing.Size(100, 25)
        '
        'tslblYear
        '
        Me.tslblYear.Name = "tslblYear"
        Me.tslblYear.Size = New System.Drawing.Size(36, 22)
        Me.tslblYear.Text = "Year :"
        '
        'tscbYear
        '
        Me.tscbYear.MaxLength = 10
        Me.tscbYear.Name = "tscbYear"
        Me.tscbYear.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'ssReport
        '
        Me.ssReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssReport_RecordCount, Me.ssReport_Parameter})
        Me.ssReport.Location = New System.Drawing.Point(0, 453)
        Me.ssReport.Name = "ssReport"
        Me.ssReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ssReport.Size = New System.Drawing.Size(1060, 22)
        Me.ssReport.TabIndex = 18
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
        'dgvYrPolicies
        '
        Me.dgvYrPolicies.AllowUserToAddRows = False
        Me.dgvYrPolicies.AllowUserToDeleteRows = False
        Me.dgvYrPolicies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYrPolicies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvYrPolicies.Location = New System.Drawing.Point(0, 25)
        Me.dgvYrPolicies.Name = "dgvYrPolicies"
        Me.dgvYrPolicies.ReadOnly = True
        Me.dgvYrPolicies.Size = New System.Drawing.Size(1060, 428)
        Me.dgvYrPolicies.TabIndex = 19
        '
        'btnGo
        '
        Me.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(24, 22)
        Me.btnGo.Text = "Go"
        '
        'btnXPort
        '
        Me.btnXPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnXPort.Image = CType(resources.GetObject("btnXPort.Image"), System.Drawing.Image)
        Me.btnXPort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnXPort.Name = "btnXPort"
        Me.btnXPort.Size = New System.Drawing.Size(84, 22)
        Me.btnXPort.Text = "Export to Excel"
        '
        'fYearlyPoliciesDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 475)
        Me.Controls.Add(Me.dgvYrPolicies)
        Me.Controls.Add(Me.ssReport)
        Me.Controls.Add(Me.tsSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fYearlyPoliciesDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Yearly Policies Details"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        Me.ssReport.ResumeLayout(False)
        Me.ssReport.PerformLayout()
        CType(Me.dgvYrPolicies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblMonth As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbMonth As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tslblYear As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbYear As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnXPort As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssReport As System.Windows.Forms.StatusStrip
    Friend WithEvents ssReport_RecordCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssReport_Parameter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvYrPolicies As System.Windows.Forms.DataGridView
End Class
