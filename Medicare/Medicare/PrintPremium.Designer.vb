<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintPremium
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintPremium))
        Me.dgvLetters = New System.Windows.Forms.DataGridView
        Me.Print = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsLetters_lblLetter = New System.Windows.Forms.ToolStripLabel
        Me.tsLetter_cbLetterType = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tstbSearch = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsLetter_Go = New System.Windows.Forms.ToolStripButton
        Me.lblType = New System.Windows.Forms.Label
        Me.lblLetterID = New System.Windows.Forms.Label
        Me.lblRecordCount = New System.Windows.Forms.Label
        CType(Me.dgvLetters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvLetters
        '
        Me.dgvLetters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLetters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Print})
        Me.dgvLetters.Location = New System.Drawing.Point(1, 28)
        Me.dgvLetters.Name = "dgvLetters"
        Me.dgvLetters.Size = New System.Drawing.Size(921, 383)
        Me.dgvLetters.TabIndex = 15
        '
        'Print
        '
        Me.Print.HeaderText = "Print"
        Me.Print.Name = "Print"
        Me.Print.Text = "Print"
        Me.Print.ToolTipText = "Print"
        Me.Print.UseColumnTextForLinkValue = True
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLetters_lblLetter, Me.tsLetter_cbLetterType, Me.ToolStripSeparator1, Me.tstbSearch, Me.tsReport_Div1, Me.tsLetter_Go})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(927, 25)
        Me.tsReport.TabIndex = 14
        Me.tsReport.Text = "ToolStrip"
        '
        'tsLetters_lblLetter
        '
        Me.tsLetters_lblLetter.Name = "tsLetters_lblLetter"
        Me.tsLetters_lblLetter.Size = New System.Drawing.Size(77, 22)
        Me.tsLetters_lblLetter.Text = "Search Type  :"
        '
        'tsLetter_cbLetterType
        '
        Me.tsLetter_cbLetterType.Items.AddRange(New Object() {"IC ", "FULL NAME"})
        Me.tsLetter_cbLetterType.MaxLength = 10
        Me.tsLetter_cbLetterType.Name = "tsLetter_cbLetterType"
        Me.tsLetter_cbLetterType.Size = New System.Drawing.Size(175, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tstbSearch
        '
        Me.tstbSearch.Name = "tstbSearch"
        Me.tstbSearch.Size = New System.Drawing.Size(225, 25)
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsLetter_Go
        '
        Me.tsLetter_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsLetter_Go.Image = CType(resources.GetObject("tsLetter_Go.Image"), System.Drawing.Image)
        Me.tsLetter_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLetter_Go.Name = "tsLetter_Go"
        Me.tsLetter_Go.Size = New System.Drawing.Size(24, 22)
        Me.tsLetter_Go.Text = "Go"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(176, 424)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(35, 13)
        Me.lblType.TabIndex = 19
        Me.lblType.Text = "TYPE"
        Me.lblType.Visible = False
        '
        'lblLetterID
        '
        Me.lblLetterID.AutoSize = True
        Me.lblLetterID.Location = New System.Drawing.Point(110, 424)
        Me.lblLetterID.Name = "lblLetterID"
        Me.lblLetterID.Size = New System.Drawing.Size(18, 13)
        Me.lblLetterID.TabIndex = 18
        Me.lblLetterID.Text = "ID"
        Me.lblLetterID.Visible = False
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Location = New System.Drawing.Point(-2, 424)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(58, 13)
        Me.lblRecordCount.TabIndex = 17
        Me.lblRecordCount.Text = "Record # :"
        '
        'PrintPremium
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 441)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.lblLetterID)
        Me.Controls.Add(Me.lblRecordCount)
        Me.Controls.Add(Me.dgvLetters)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "PrintPremium"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Premium Letters"
        CType(Me.dgvLetters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvLetters As System.Windows.Forms.DataGridView
    Friend WithEvents Print As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsLetters_lblLetter As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsLetter_cbLetterType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstbSearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsLetter_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblLetterID As System.Windows.Forms.Label
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
End Class
