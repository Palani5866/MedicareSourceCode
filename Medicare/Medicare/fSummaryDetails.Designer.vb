<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fSummaryDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fSummaryDetails))
        Me.lblP1 = New System.Windows.Forms.Label
        Me.lblP2 = New System.Windows.Forms.Label
        Me.lblP3 = New System.Windows.Forms.Label
        Me.lblP4 = New System.Windows.Forms.Label
        Me.lblP5 = New System.Windows.Forms.Label
        Me.lblDateTo = New System.Windows.Forms.Label
        Me.lblDateFrom = New System.Windows.Forms.Label
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.tsbtnPrint = New System.Windows.Forms.ToolStripButton
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tslblTotalRecords = New System.Windows.Forms.ToolStripLabel
        Me.dgvFSD = New System.Windows.Forms.DataGridView
        Me.tsSearch.SuspendLayout()
        CType(Me.dgvFSD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblP1
        '
        Me.lblP1.AutoSize = True
        Me.lblP1.Location = New System.Drawing.Point(685, 483)
        Me.lblP1.Name = "lblP1"
        Me.lblP1.Size = New System.Drawing.Size(20, 13)
        Me.lblP1.TabIndex = 1
        Me.lblP1.Text = "P1"
        Me.lblP1.Visible = False
        '
        'lblP2
        '
        Me.lblP2.AutoSize = True
        Me.lblP2.Location = New System.Drawing.Point(711, 483)
        Me.lblP2.Name = "lblP2"
        Me.lblP2.Size = New System.Drawing.Size(20, 13)
        Me.lblP2.TabIndex = 2
        Me.lblP2.Text = "P2"
        Me.lblP2.Visible = False
        '
        'lblP3
        '
        Me.lblP3.AutoSize = True
        Me.lblP3.Location = New System.Drawing.Point(737, 483)
        Me.lblP3.Name = "lblP3"
        Me.lblP3.Size = New System.Drawing.Size(20, 13)
        Me.lblP3.TabIndex = 3
        Me.lblP3.Text = "P3"
        Me.lblP3.Visible = False
        '
        'lblP4
        '
        Me.lblP4.AutoSize = True
        Me.lblP4.Location = New System.Drawing.Point(763, 483)
        Me.lblP4.Name = "lblP4"
        Me.lblP4.Size = New System.Drawing.Size(20, 13)
        Me.lblP4.TabIndex = 4
        Me.lblP4.Text = "P4"
        Me.lblP4.Visible = False
        '
        'lblP5
        '
        Me.lblP5.AutoSize = True
        Me.lblP5.Location = New System.Drawing.Point(789, 483)
        Me.lblP5.Name = "lblP5"
        Me.lblP5.Size = New System.Drawing.Size(20, 13)
        Me.lblP5.TabIndex = 5
        Me.lblP5.Text = "P5"
        Me.lblP5.Visible = False
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(623, 483)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(43, 13)
        Me.lblDateTo.TabIndex = 7
        Me.lblDateTo.Text = "DateTo"
        Me.lblDateTo.Visible = False
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(547, 484)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(53, 13)
        Me.lblDateFrom.TabIndex = 6
        Me.lblDateFrom.Text = "DateFrom"
        Me.lblDateFrom.Visible = False
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnPrint, Me.btnXPort, Me.ToolStripSeparator1, Me.tslblTotalRecords})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(887, 25)
        Me.tsSearch.TabIndex = 8
        Me.tsSearch.Text = "ToolStrip"
        '
        'tsbtnPrint
        '
        Me.tsbtnPrint.Image = Global.Medicare.My.Resources.Resources._100
        Me.tsbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnPrint.Name = "tsbtnPrint"
        Me.tsbtnPrint.Size = New System.Drawing.Size(52, 22)
        Me.tsbtnPrint.Text = "Print"
        Me.tsbtnPrint.Visible = False
        '
        'btnXPort
        '
        Me.btnXPort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnXPort.Image = CType(resources.GetObject("btnXPort.Image"), System.Drawing.Image)
        Me.btnXPort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnXPort.Name = "btnXPort"
        Me.btnXPort.Size = New System.Drawing.Size(60, 22)
        Me.btnXPort.Text = "Export"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tslblTotalRecords
        '
        Me.tslblTotalRecords.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tslblTotalRecords.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.tslblTotalRecords.Name = "tslblTotalRecords"
        Me.tslblTotalRecords.Size = New System.Drawing.Size(85, 22)
        Me.tslblTotalRecords.Text = "Total Records : "
        '
        'dgvFSD
        '
        Me.dgvFSD.AllowUserToAddRows = False
        Me.dgvFSD.AllowUserToDeleteRows = False
        Me.dgvFSD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFSD.Location = New System.Drawing.Point(0, 25)
        Me.dgvFSD.Name = "dgvFSD"
        Me.dgvFSD.ReadOnly = True
        Me.dgvFSD.Size = New System.Drawing.Size(887, 472)
        Me.dgvFSD.TabIndex = 9
        '
        'fSummaryDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 497)
        Me.Controls.Add(Me.dgvFSD)
        Me.Controls.Add(Me.tsSearch)
        Me.Controls.Add(Me.lblDateTo)
        Me.Controls.Add(Me.lblDateFrom)
        Me.Controls.Add(Me.lblP5)
        Me.Controls.Add(Me.lblP4)
        Me.Controls.Add(Me.lblP3)
        Me.Controls.Add(Me.lblP2)
        Me.Controls.Add(Me.lblP1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fSummaryDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Followup Summary Details"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        CType(Me.dgvFSD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblP1 As System.Windows.Forms.Label
    Friend WithEvents lblP2 As System.Windows.Forms.Label
    Friend WithEvents lblP3 As System.Windows.Forms.Label
    Friend WithEvents lblP4 As System.Windows.Forms.Label
    Friend WithEvents lblP5 As System.Windows.Forms.Label
    Friend WithEvents lblDateTo As System.Windows.Forms.Label
    Friend WithEvents lblDateFrom As System.Windows.Forms.Label
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnXPort As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvFSD As System.Windows.Forms.DataGridView
    Friend WithEvents tslblTotalRecords As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
