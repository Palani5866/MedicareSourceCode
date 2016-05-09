<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rYShortfallReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rYShortfallReport))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripcmbYear = New System.Windows.Forms.ToolStripComboBox
        Me.lblMonthFrom = New System.Windows.Forms.ToolStripLabel
        Me.cbMonthFrm = New System.Windows.Forms.ToolStripComboBox
        Me.lblMonthTo = New System.Windows.Forms.ToolStripLabel
        Me.cbMonthTo = New System.Windows.Forms.ToolStripComboBox
        Me.tsReport_Go = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsReport_Export = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.lblTotalRecords = New System.Windows.Forms.ToolStripLabel
        Me.dgvShortFallReport = New System.Windows.Forms.DataGridView
        Me.lblREF1 = New System.Windows.Forms.Label
        Me.tsReport.SuspendLayout()
        CType(Me.dgvShortFallReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripcmbYear, Me.lblMonthFrom, Me.cbMonthFrm, Me.lblMonthTo, Me.cbMonthTo, Me.tsReport_Go, Me.tsReport_Div1, Me.tsReport_Export, Me.ToolStripSeparator1, Me.lblTotalRecords})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(999, 25)
        Me.tsReport.TabIndex = 4
        Me.tsReport.Text = "c"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(33, 22)
        Me.ToolStripLabel1.Text = "Year:"
        '
        'ToolStripcmbYear
        '
        Me.ToolStripcmbYear.Name = "ToolStripcmbYear"
        Me.ToolStripcmbYear.Size = New System.Drawing.Size(121, 25)
        '
        'lblMonthFrom
        '
        Me.lblMonthFrom.Name = "lblMonthFrom"
        Me.lblMonthFrom.Size = New System.Drawing.Size(80, 22)
        Me.lblMonthFrom.Text = "Month From :"
        Me.lblMonthFrom.Visible = False
        '
        'cbMonthFrm
        '
        Me.cbMonthFrm.Name = "cbMonthFrm"
        Me.cbMonthFrm.Size = New System.Drawing.Size(121, 25)
        Me.cbMonthFrm.Visible = False
        '
        'lblMonthTo
        '
        Me.lblMonthTo.Name = "lblMonthTo"
        Me.lblMonthTo.Size = New System.Drawing.Size(66, 22)
        Me.lblMonthTo.Text = "Month To :"
        Me.lblMonthTo.Visible = False
        '
        'cbMonthTo
        '
        Me.cbMonthTo.Name = "cbMonthTo"
        Me.cbMonthTo.Size = New System.Drawing.Size(121, 25)
        Me.cbMonthTo.Visible = False
        '
        'tsReport_Go
        '
        Me.tsReport_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsReport_Go.Image = CType(resources.GetObject("tsReport_Go.Image"), System.Drawing.Image)
        Me.tsReport_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Go.Name = "tsReport_Go"
        Me.tsReport_Go.Size = New System.Drawing.Size(26, 22)
        Me.tsReport_Go.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsReport_Export
        '
        Me.tsReport_Export.Image = CType(resources.GetObject("tsReport_Export.Image"), System.Drawing.Image)
        Me.tsReport_Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport_Export.Name = "tsReport_Export"
        Me.tsReport_Export.Size = New System.Drawing.Size(60, 22)
        Me.tsReport_Export.Text = "Export"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblTotalRecords
        '
        Me.lblTotalRecords.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblTotalRecords.ForeColor = System.Drawing.Color.Green
        Me.lblTotalRecords.Name = "lblTotalRecords"
        Me.lblTotalRecords.Size = New System.Drawing.Size(91, 22)
        Me.lblTotalRecords.Text = "Total Records :"
        '
        'dgvShortFallReport
        '
        Me.dgvShortFallReport.AllowUserToAddRows = False
        Me.dgvShortFallReport.AllowUserToDeleteRows = False
        Me.dgvShortFallReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortFallReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShortFallReport.Location = New System.Drawing.Point(0, 25)
        Me.dgvShortFallReport.Name = "dgvShortFallReport"
        Me.dgvShortFallReport.ReadOnly = True
        Me.dgvShortFallReport.Size = New System.Drawing.Size(999, 439)
        Me.dgvShortFallReport.TabIndex = 5
        '
        'lblREF1
        '
        Me.lblREF1.AutoSize = True
        Me.lblREF1.Location = New System.Drawing.Point(398, 225)
        Me.lblREF1.Name = "lblREF1"
        Me.lblREF1.Size = New System.Drawing.Size(56, 13)
        Me.lblREF1.TabIndex = 6
        Me.lblREF1.Text = "REFTYPE"
        Me.lblREF1.Visible = False
        '
        'rYShortfallReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 464)
        Me.Controls.Add(Me.lblREF1)
        Me.Controls.Add(Me.dgvShortFallReport)
        Me.Controls.Add(Me.tsReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "rYShortfallReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Short Fall Report "
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvShortFallReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripcmbYear As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsReport_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsReport_Export As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvShortFallReport As System.Windows.Forms.DataGridView
    Friend WithEvents lblREF1 As System.Windows.Forms.Label
    Friend WithEvents lblMonthFrom As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cbMonthFrm As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents lblMonthTo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cbMonthTo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblTotalRecords As System.Windows.Forms.ToolStripLabel
End Class
