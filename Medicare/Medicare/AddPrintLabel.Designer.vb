<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPrintLabel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddPrintLabel))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsReport_lblDeductionCode_From = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsReport_txtDeductionCode_From = New System.Windows.Forms.ToolStripComboBox
        Me.tsReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReport_lblDeductionCode_From, Me.tsReport_txtDeductionCode_From, Me.tsReport_Go, Me.tsReport_Div1})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(573, 25)
        Me.tsReport.TabIndex = 2
        Me.tsReport.Text = "ToolStrip"
        '
        'tsReport_lblDeductionCode_From
        '
        Me.tsReport_lblDeductionCode_From.Name = "tsReport_lblDeductionCode_From"
        Me.tsReport_lblDeductionCode_From.Size = New System.Drawing.Size(81, 22)
        Me.tsReport_lblDeductionCode_From.Text = "Account Code :"
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
        'tsReport_txtDeductionCode_From
        '
        Me.tsReport_txtDeductionCode_From.Items.AddRange(New Object() {"GI2073", "GI2074", "GI2075", "GI2076", "GI2077", "GI2078", "GI2788"})
        Me.tsReport_txtDeductionCode_From.MaxLength = 10
        Me.tsReport_txtDeductionCode_From.Name = "tsReport_txtDeductionCode_From"
        Me.tsReport_txtDeductionCode_From.Size = New System.Drawing.Size(100, 25)
        '
        'AddPrintLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 26)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "AddPrintLabel"
        Me.Text = "Address Label Print"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_lblDeductionCode_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsReport_txtDeductionCode_From As System.Windows.Forms.ToolStripComboBox
End Class
