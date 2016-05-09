<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YrFollowupDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(YrFollowupDetails))
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.dgvYRFSD = New System.Windows.Forms.DataGridView
        Me.lblREF1 = New System.Windows.Forms.Label
        Me.tslblTotalRecords = New System.Windows.Forms.ToolStripLabel
        Me.tsSearch.SuspendLayout()
        CType(Me.dgvYRFSD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblTotalRecords, Me.tsReport_Div1, Me.btnXPort})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsSearch.Size = New System.Drawing.Size(1054, 25)
        Me.tsSearch.TabIndex = 8
        Me.tsSearch.Text = "ToolStrip"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'btnXPort
        '
        Me.btnXPort.Image = CType(resources.GetObject("btnXPort.Image"), System.Drawing.Image)
        Me.btnXPort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnXPort.Name = "btnXPort"
        Me.btnXPort.Size = New System.Drawing.Size(59, 22)
        Me.btnXPort.Text = "Export"
        '
        'dgvYRFSD
        '
        Me.dgvYRFSD.AllowUserToAddRows = False
        Me.dgvYRFSD.AllowUserToDeleteRows = False
        Me.dgvYRFSD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYRFSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvYRFSD.Location = New System.Drawing.Point(0, 25)
        Me.dgvYRFSD.Name = "dgvYRFSD"
        Me.dgvYRFSD.ReadOnly = True
        Me.dgvYRFSD.Size = New System.Drawing.Size(1054, 502)
        Me.dgvYRFSD.TabIndex = 9
        '
        'lblREF1
        '
        Me.lblREF1.AutoSize = True
        Me.lblREF1.Location = New System.Drawing.Point(444, 308)
        Me.lblREF1.Name = "lblREF1"
        Me.lblREF1.Size = New System.Drawing.Size(34, 13)
        Me.lblREF1.TabIndex = 10
        Me.lblREF1.Text = "REF1"
        Me.lblREF1.Visible = False
        '
        'tslblTotalRecords
        '
        Me.tslblTotalRecords.Name = "tslblTotalRecords"
        Me.tslblTotalRecords.Size = New System.Drawing.Size(80, 22)
        Me.tslblTotalRecords.Text = "Total Records :"
        '
        'YrFollowupDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 527)
        Me.Controls.Add(Me.lblREF1)
        Me.Controls.Add(Me.dgvYRFSD)
        Me.Controls.Add(Me.tsSearch)
        Me.Name = "YrFollowupDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Yearly Follow up Summary Details"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        CType(Me.dgvYRFSD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStrip
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnXPort As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvYRFSD As System.Windows.Forms.DataGridView
    Friend WithEvents lblREF1 As System.Windows.Forms.Label
    Friend WithEvents tslblTotalRecords As System.Windows.Forms.ToolStripLabel
End Class
