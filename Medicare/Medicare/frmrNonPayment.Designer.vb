<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrNonPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrNonPayment))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslbldtFrom = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateFrom = New System.Windows.Forms.ToolStripTextBox
        Me.tslbldtTo = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDateTo = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnExporttoExcel = New System.Windows.Forms.ToolStripButton
        Me.tslblTOT = New System.Windows.Forms.ToolStripLabel
        Me.dgvNP = New System.Windows.Forms.DataGridView
        Me.tsReport.SuspendLayout()
        CType(Me.dgvNP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslbldtFrom, Me.tstxtDateFrom, Me.tslbldtTo, Me.tstxtDateTo, Me.tsbtnGo, Me.tsReport_Div1, Me.tsbtnExporttoExcel, Me.tslblTOT})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(969, 25)
        Me.tsReport.TabIndex = 8
        Me.tsReport.Text = "ToolStrip"
        '
        'tslbldtFrom
        '
        Me.tslbldtFrom.Name = "tslbldtFrom"
        Me.tslbldtFrom.Size = New System.Drawing.Size(146, 22)
        Me.tslbldtFrom.Text = "Date From (dd/mm/yyyy):"
        '
        'tstxtDateFrom
        '
        Me.tstxtDateFrom.MaxLength = 10
        Me.tstxtDateFrom.Name = "tstxtDateFrom"
        Me.tstxtDateFrom.Size = New System.Drawing.Size(100, 25)
        '
        'tslbldtTo
        '
        Me.tslbldtTo.Name = "tslbldtTo"
        Me.tslbldtTo.Size = New System.Drawing.Size(132, 22)
        Me.tslbldtTo.Text = "Date To (dd/mm/yyyy):"
        '
        'tstxtDateTo
        '
        Me.tstxtDateTo.MaxLength = 10
        Me.tstxtDateTo.Name = "tstxtDateTo"
        Me.tstxtDateTo.Size = New System.Drawing.Size(100, 25)
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
        'tsbtnExporttoExcel
        '
        Me.tsbtnExporttoExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnExporttoExcel.Image = CType(resources.GetObject("tsbtnExporttoExcel.Image"), System.Drawing.Image)
        Me.tsbtnExporttoExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExporttoExcel.Name = "tsbtnExporttoExcel"
        Me.tsbtnExporttoExcel.Size = New System.Drawing.Size(87, 22)
        Me.tsbtnExporttoExcel.Text = "Export to Excel"
        '
        'tslblTOT
        '
        Me.tslblTOT.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.tslblTOT.ForeColor = System.Drawing.Color.Blue
        Me.tslblTOT.Name = "tslblTOT"
        Me.tslblTOT.Size = New System.Drawing.Size(90, 22)
        Me.tslblTOT.Text = "Total Records :"
        '
        'dgvNP
        '
        Me.dgvNP.AllowUserToAddRows = False
        Me.dgvNP.AllowUserToDeleteRows = False
        Me.dgvNP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNP.Location = New System.Drawing.Point(0, 25)
        Me.dgvNP.Name = "dgvNP"
        Me.dgvNP.ReadOnly = True
        Me.dgvNP.Size = New System.Drawing.Size(969, 399)
        Me.dgvNP.TabIndex = 9
        '
        'frmrNonPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 424)
        Me.Controls.Add(Me.dgvNP)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "frmrNonPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Non Payment Details"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvNP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tslbldtFrom As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDateFrom As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tslbldtTo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDateTo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnExporttoExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tslblTOT As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dgvNP As System.Windows.Forms.DataGridView
End Class
