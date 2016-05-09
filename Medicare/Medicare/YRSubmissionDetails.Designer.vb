<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YRSubmissionDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(YRSubmissionDetails))
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.tsbtnPrint = New System.Windows.Forms.ToolStripButton
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tslblTotalRecords = New System.Windows.Forms.ToolStripLabel
        Me.dgvYRS = New System.Windows.Forms.DataGridView
        Me.lblBATCHNO = New System.Windows.Forms.Label
        Me.lblSTATUS = New System.Windows.Forms.Label
        Me.tsSearch.SuspendLayout()
        CType(Me.dgvYRS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnPrint, Me.btnXPort, Me.ToolStripSeparator1, Me.tslblTotalRecords})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(1056, 25)
        Me.tsSearch.TabIndex = 9
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
        'dgvYRS
        '
        Me.dgvYRS.AllowUserToAddRows = False
        Me.dgvYRS.AllowUserToDeleteRows = False
        Me.dgvYRS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYRS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvYRS.Location = New System.Drawing.Point(0, 25)
        Me.dgvYRS.Name = "dgvYRS"
        Me.dgvYRS.ReadOnly = True
        Me.dgvYRS.Size = New System.Drawing.Size(1056, 384)
        Me.dgvYRS.TabIndex = 10
        '
        'lblBATCHNO
        '
        Me.lblBATCHNO.AutoSize = True
        Me.lblBATCHNO.Location = New System.Drawing.Point(348, 96)
        Me.lblBATCHNO.Name = "lblBATCHNO"
        Me.lblBATCHNO.Size = New System.Drawing.Size(59, 13)
        Me.lblBATCHNO.TabIndex = 11
        Me.lblBATCHNO.Text = "BATCHNO"
        Me.lblBATCHNO.Visible = False
        '
        'lblSTATUS
        '
        Me.lblSTATUS.AutoSize = True
        Me.lblSTATUS.Location = New System.Drawing.Point(499, 198)
        Me.lblSTATUS.Name = "lblSTATUS"
        Me.lblSTATUS.Size = New System.Drawing.Size(50, 13)
        Me.lblSTATUS.TabIndex = 12
        Me.lblSTATUS.Text = "STATUS"
        Me.lblSTATUS.Visible = False
        '
        'YRSubmissionDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 409)
        Me.Controls.Add(Me.lblSTATUS)
        Me.Controls.Add(Me.lblBATCHNO)
        Me.Controls.Add(Me.dgvYRS)
        Me.Controls.Add(Me.tsSearch)
        Me.Name = "YRSubmissionDetails"
        Me.Text = "Yearly Renewal Submission Details"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        CType(Me.dgvYRS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnXPort As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslblTotalRecords As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dgvYRS As System.Windows.Forms.DataGridView
    Friend WithEvents lblBATCHNO As System.Windows.Forms.Label
    Friend WithEvents lblSTATUS As System.Windows.Forms.Label
End Class
