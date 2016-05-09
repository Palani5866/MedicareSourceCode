<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewLetters
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewLetters))
        Me.lblLetterID = New System.Windows.Forms.Label
        Me.lblRecordCount = New System.Windows.Forms.Label
        Me.dgvLetters = New System.Windows.Forms.DataGridView
        Me.Print = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsLetters_lblLetter = New System.Windows.Forms.ToolStripLabel
        Me.tsLetter_cbLetterType = New System.Windows.Forms.ToolStripComboBox
        Me.lblIC = New System.Windows.Forms.ToolStripLabel
        Me.txtIC = New System.Windows.Forms.ToolStripTextBox
        Me.tsLetter_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.lblATYPE = New System.Windows.Forms.Label
        CType(Me.dgvLetters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblLetterID
        '
        Me.lblLetterID.AutoSize = True
        Me.lblLetterID.Location = New System.Drawing.Point(124, 348)
        Me.lblLetterID.Name = "lblLetterID"
        Me.lblLetterID.Size = New System.Drawing.Size(18, 13)
        Me.lblLetterID.TabIndex = 11
        Me.lblLetterID.Text = "ID"
        Me.lblLetterID.Visible = False
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Location = New System.Drawing.Point(12, 348)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(58, 13)
        Me.lblRecordCount.TabIndex = 10
        Me.lblRecordCount.Text = "Record # :"
        '
        'dgvLetters
        '
        Me.dgvLetters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLetters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Print})
        Me.dgvLetters.Location = New System.Drawing.Point(0, 28)
        Me.dgvLetters.Name = "dgvLetters"
        Me.dgvLetters.Size = New System.Drawing.Size(921, 317)
        Me.dgvLetters.TabIndex = 9
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
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLetters_lblLetter, Me.tsLetter_cbLetterType, Me.lblIC, Me.txtIC, Me.tsLetter_Go, Me.tsReport_Div1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(933, 25)
        Me.tsReport.TabIndex = 8
        Me.tsReport.Text = "ToolStrip"
        '
        'tsLetters_lblLetter
        '
        Me.tsLetters_lblLetter.Name = "tsLetters_lblLetter"
        Me.tsLetters_lblLetter.Size = New System.Drawing.Size(63, 22)
        Me.tsLetters_lblLetter.Text = "Letter Type"
        '
        'tsLetter_cbLetterType
        '
        Me.tsLetter_cbLetterType.DropDownHeight = 125
        Me.tsLetter_cbLetterType.IntegralHeight = False
        Me.tsLetter_cbLetterType.MaxLength = 10
        Me.tsLetter_cbLetterType.Name = "tsLetter_cbLetterType"
        Me.tsLetter_cbLetterType.Size = New System.Drawing.Size(175, 25)
        '
        'lblIC
        '
        Me.lblIC.Name = "lblIC"
        Me.lblIC.Size = New System.Drawing.Size(29, 22)
        Me.lblIC.Text = "IC #"
        '
        'txtIC
        '
        Me.txtIC.MaxLength = 13
        Me.txtIC.Name = "txtIC"
        Me.txtIC.Size = New System.Drawing.Size(125, 25)
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
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'lblATYPE
        '
        Me.lblATYPE.AutoSize = True
        Me.lblATYPE.Location = New System.Drawing.Point(708, 352)
        Me.lblATYPE.Name = "lblATYPE"
        Me.lblATYPE.Size = New System.Drawing.Size(42, 13)
        Me.lblATYPE.TabIndex = 12
        Me.lblATYPE.Text = "ATYPE"
        Me.lblATYPE.Visible = False
        '
        'viewLetters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 370)
        Me.Controls.Add(Me.lblATYPE)
        Me.Controls.Add(Me.lblLetterID)
        Me.Controls.Add(Me.lblRecordCount)
        Me.Controls.Add(Me.dgvLetters)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "viewLetters"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Letters"
        CType(Me.dgvLetters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLetterID As System.Windows.Forms.Label
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents dgvLetters As System.Windows.Forms.DataGridView
    Friend WithEvents Print As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsLetters_lblLetter As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsLetter_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsLetter_cbLetterType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents lblIC As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtIC As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents lblATYPE As System.Windows.Forms.Label
End Class
