<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fInDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fInDetails))
        Me.tsSearch = New System.Windows.Forms.ToolStrip
        Me.tslblTotalRecords = New System.Windows.Forms.ToolStripLabel
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnXPort = New System.Windows.Forms.ToolStripButton
        Me.dgvD = New System.Windows.Forms.DataGridView
        Me.lblREF1 = New System.Windows.Forms.Label
        Me.lblREF2 = New System.Windows.Forms.Label
        Me.lblREF3 = New System.Windows.Forms.Label
        Me.lblREF4 = New System.Windows.Forms.Label
        Me.lblREF5 = New System.Windows.Forms.Label
        Me.tsSearch.SuspendLayout()
        CType(Me.dgvD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSearch
        '
        Me.tsSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblTotalRecords, Me.tsReport_Div1, Me.btnXPort})
        Me.tsSearch.Location = New System.Drawing.Point(0, 0)
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsSearch.Size = New System.Drawing.Size(1059, 25)
        Me.tsSearch.TabIndex = 9
        Me.tsSearch.Text = "ToolStrip"
        '
        'tslblTotalRecords
        '
        Me.tslblTotalRecords.Name = "tslblTotalRecords"
        Me.tslblTotalRecords.Size = New System.Drawing.Size(80, 22)
        Me.tslblTotalRecords.Text = "Total Records :"
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
        'dgvD
        '
        Me.dgvD.AllowUserToAddRows = False
        Me.dgvD.AllowUserToDeleteRows = False
        Me.dgvD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvD.Location = New System.Drawing.Point(0, 25)
        Me.dgvD.Name = "dgvD"
        Me.dgvD.ReadOnly = True
        Me.dgvD.Size = New System.Drawing.Size(1059, 483)
        Me.dgvD.TabIndex = 10
        '
        'lblREF1
        '
        Me.lblREF1.AutoSize = True
        Me.lblREF1.Location = New System.Drawing.Point(490, 239)
        Me.lblREF1.Name = "lblREF1"
        Me.lblREF1.Size = New System.Drawing.Size(34, 13)
        Me.lblREF1.TabIndex = 11
        Me.lblREF1.Text = "REF1"
        Me.lblREF1.Visible = False
        '
        'lblREF2
        '
        Me.lblREF2.AutoSize = True
        Me.lblREF2.Location = New System.Drawing.Point(547, 239)
        Me.lblREF2.Name = "lblREF2"
        Me.lblREF2.Size = New System.Drawing.Size(34, 13)
        Me.lblREF2.TabIndex = 12
        Me.lblREF2.Text = "REF2"
        Me.lblREF2.Visible = False
        '
        'lblREF3
        '
        Me.lblREF3.AutoSize = True
        Me.lblREF3.Location = New System.Drawing.Point(587, 239)
        Me.lblREF3.Name = "lblREF3"
        Me.lblREF3.Size = New System.Drawing.Size(34, 13)
        Me.lblREF3.TabIndex = 13
        Me.lblREF3.Text = "REF3"
        Me.lblREF3.Visible = False
        '
        'lblREF4
        '
        Me.lblREF4.AutoSize = True
        Me.lblREF4.Location = New System.Drawing.Point(641, 239)
        Me.lblREF4.Name = "lblREF4"
        Me.lblREF4.Size = New System.Drawing.Size(34, 13)
        Me.lblREF4.TabIndex = 14
        Me.lblREF4.Text = "REF4"
        Me.lblREF4.Visible = False
        '
        'lblREF5
        '
        Me.lblREF5.AutoSize = True
        Me.lblREF5.Location = New System.Drawing.Point(690, 239)
        Me.lblREF5.Name = "lblREF5"
        Me.lblREF5.Size = New System.Drawing.Size(34, 13)
        Me.lblREF5.TabIndex = 15
        Me.lblREF5.Text = "REF5"
        Me.lblREF5.Visible = False
        '
        'fInDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 508)
        Me.Controls.Add(Me.lblREF5)
        Me.Controls.Add(Me.lblREF4)
        Me.Controls.Add(Me.lblREF3)
        Me.Controls.Add(Me.lblREF2)
        Me.Controls.Add(Me.lblREF1)
        Me.Controls.Add(Me.dgvD)
        Me.Controls.Add(Me.tsSearch)
        Me.Name = "fInDetails"
        Me.Text = "Details"
        Me.tsSearch.ResumeLayout(False)
        Me.tsSearch.PerformLayout()
        CType(Me.dgvD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblTotalRecords As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnXPort As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvD As System.Windows.Forms.DataGridView
    Friend WithEvents lblREF1 As System.Windows.Forms.Label
    Friend WithEvents lblREF2 As System.Windows.Forms.Label
    Friend WithEvents lblREF3 As System.Windows.Forms.Label
    Friend WithEvents lblREF4 As System.Windows.Forms.Label
    Friend WithEvents lblREF5 As System.Windows.Forms.Label
End Class
