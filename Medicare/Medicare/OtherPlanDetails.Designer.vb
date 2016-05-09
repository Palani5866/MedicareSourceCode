<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OtherPlanDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OtherPlanDetails))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.lblRecordCount = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.dgvPAYMENTDETAILS = New System.Windows.Forms.DataGridView
        Me.lblREF1 = New System.Windows.Forms.Label
        Me.lblREF2 = New System.Windows.Forms.Label
        Me.tsReport.SuspendLayout()
        CType(Me.dgvPAYMENTDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblRecordCount, Me.ToolStripSeparator1, Me.tsbtnXport2Xcel})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsReport.Size = New System.Drawing.Size(748, 25)
        Me.tsReport.TabIndex = 11
        Me.tsReport.Text = "ToolStrip"
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblRecordCount.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(91, 22)
        Me.lblRecordCount.Text = "Total Records :"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnXport2Xcel
        '
        Me.tsbtnXport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnXport2Xcel.Image = CType(resources.GetObject("tsbtnXport2Xcel.Image"), System.Drawing.Image)
        Me.tsbtnXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnXport2Xcel.Name = "tsbtnXport2Xcel"
        Me.tsbtnXport2Xcel.Size = New System.Drawing.Size(84, 22)
        Me.tsbtnXport2Xcel.Text = "Export to Excel"
        '
        'dgvPAYMENTDETAILS
        '
        Me.dgvPAYMENTDETAILS.AllowUserToAddRows = False
        Me.dgvPAYMENTDETAILS.AllowUserToDeleteRows = False
        Me.dgvPAYMENTDETAILS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPAYMENTDETAILS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPAYMENTDETAILS.Location = New System.Drawing.Point(0, 25)
        Me.dgvPAYMENTDETAILS.Name = "dgvPAYMENTDETAILS"
        Me.dgvPAYMENTDETAILS.ReadOnly = True
        Me.dgvPAYMENTDETAILS.Size = New System.Drawing.Size(748, 400)
        Me.dgvPAYMENTDETAILS.TabIndex = 12
        '
        'lblREF1
        '
        Me.lblREF1.AutoSize = True
        Me.lblREF1.Location = New System.Drawing.Point(262, 162)
        Me.lblREF1.Name = "lblREF1"
        Me.lblREF1.Size = New System.Drawing.Size(34, 13)
        Me.lblREF1.TabIndex = 13
        Me.lblREF1.Text = "REF1"
        Me.lblREF1.Visible = False
        '
        'lblREF2
        '
        Me.lblREF2.AutoSize = True
        Me.lblREF2.Location = New System.Drawing.Point(329, 162)
        Me.lblREF2.Name = "lblREF2"
        Me.lblREF2.Size = New System.Drawing.Size(34, 13)
        Me.lblREF2.TabIndex = 14
        Me.lblREF2.Text = "REF2"
        Me.lblREF2.Visible = False
        '
        'OtherPlanDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 425)
        Me.Controls.Add(Me.lblREF2)
        Me.Controls.Add(Me.lblREF1)
        Me.Controls.Add(Me.dgvPAYMENTDETAILS)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "OtherPlanDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POLICY DETAILS "
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvPAYMENTDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents lblRecordCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnXport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvPAYMENTDETAILS As System.Windows.Forms.DataGridView
    Friend WithEvents lblREF1 As System.Windows.Forms.Label
    Friend WithEvents lblREF2 As System.Windows.Forms.Label
End Class
