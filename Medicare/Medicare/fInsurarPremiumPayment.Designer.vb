<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fInsurarPremiumPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fInsurarPremiumPayment))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblDeductionCode_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_From = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblDeductionCode_To = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_txtDeductionCode_To = New System.Windows.Forms.ToolStripTextBox
        Me.tslblYear1 = New System.Windows.Forms.ToolStripLabel
        Me.tscbYear = New System.Windows.Forms.ToolStripComboBox
        Me.tslblMonth1 = New System.Windows.Forms.ToolStripLabel
        Me.tscbMonth = New System.Windows.Forms.ToolStripComboBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.dgvIPRD = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        CType(Me.dgvIPRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblDeductionCode_From, Me.tsReport_txtDeductionCode_From, Me.tsReport_lblDeductionCode_To, Me.tsReport_txtDeductionCode_To, Me.tslblYear1, Me.tscbYear, Me.tslblMonth1, Me.tscbMonth, Me.tsbtnGo, Me.tsReport_Div1, Me.tsXport2Xcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(975, 25)
        Me.tsReport.TabIndex = 5
        Me.tsReport.Text = "c"
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
        'tsReport_lblDeductionCode_To
        '
        Me.tsReport_lblDeductionCode_To.Name = "tsReport_lblDeductionCode_To"
        Me.tsReport_lblDeductionCode_To.Size = New System.Drawing.Size(109, 22)
        Me.tsReport_lblDeductionCode_To.Text = "Deduction Code - To:"
        '
        'tsReport_txtDeductionCode_To
        '
        Me.tsReport_txtDeductionCode_To.MaxLength = 10
        Me.tsReport_txtDeductionCode_To.Name = "tsReport_txtDeductionCode_To"
        Me.tsReport_txtDeductionCode_To.Size = New System.Drawing.Size(100, 25)
        '
        'tslblYear1
        '
        Me.tslblYear1.Name = "tslblYear1"
        Me.tslblYear1.Size = New System.Drawing.Size(33, 22)
        Me.tslblYear1.Text = "Year:"
        '
        'tscbYear
        '
        Me.tscbYear.Name = "tscbYear"
        Me.tscbYear.Size = New System.Drawing.Size(121, 25)
        '
        'tslblMonth1
        '
        Me.tslblMonth1.Name = "tslblMonth1"
        Me.tslblMonth1.Size = New System.Drawing.Size(44, 22)
        Me.tslblMonth1.Text = "Month :"
        '
        'tscbMonth
        '
        Me.tscbMonth.Items.AddRange(New Object() {"", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.tscbMonth.Name = "tscbMonth"
        Me.tscbMonth.Size = New System.Drawing.Size(121, 25)
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
        'tsXport2Xcel
        '
        Me.tsXport2Xcel.Image = CType(resources.GetObject("tsXport2Xcel.Image"), System.Drawing.Image)
        Me.tsXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsXport2Xcel.Name = "tsXport2Xcel"
        Me.tsXport2Xcel.Size = New System.Drawing.Size(100, 22)
        Me.tsXport2Xcel.Text = "Export to Excel"
        '
        'dgvIPRD
        '
        Me.dgvIPRD.AllowUserToAddRows = False
        Me.dgvIPRD.AllowUserToDeleteRows = False
        Me.dgvIPRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIPRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPRD.Location = New System.Drawing.Point(0, 25)
        Me.dgvIPRD.Name = "dgvIPRD"
        Me.dgvIPRD.ReadOnly = True
        Me.dgvIPRD.Size = New System.Drawing.Size(975, 514)
        Me.dgvIPRD.TabIndex = 6
        '
        'fInsurarPremiumPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 539)
        Me.Controls.Add(Me.dgvIPRD)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "fInsurarPremiumPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monthly Premium Payment Listing"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvIPRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblDeductionCode_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_From As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_lblDeductionCode_To As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_txtDeductionCode_To As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tslblYear1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbYear As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tslblMonth1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbMonth As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsXport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvIPRD As System.Windows.Forms.DataGridView
End Class
