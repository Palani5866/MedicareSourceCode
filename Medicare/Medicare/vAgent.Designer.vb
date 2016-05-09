<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vAgent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(vAgent))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tslblSearchBy = New System.Windows.Forms.ToolStripLabel
        Me.tstxtSearchBy = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.dgvAgentDetails = New System.Windows.Forms.DataGridView
        Me.tslblStatus = New System.Windows.Forms.ToolStripLabel
        Me.tscbStatus = New System.Windows.Forms.ToolStripComboBox
        Me.tolForm.SuspendLayout()
        CType(Me.dgvAgentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblStatus, Me.tscbStatus, Me.tslblSearchBy, Me.tstxtSearchBy, Me.tsbtnGo, Me.ToolStripSeparator1, Me.tsbtnXport2Xcel})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(969, 25)
        Me.tolForm.TabIndex = 1
        Me.tolForm.Text = "ToolStrip1"
        '
        'tslblSearchBy
        '
        Me.tslblSearchBy.Name = "tslblSearchBy"
        Me.tslblSearchBy.Size = New System.Drawing.Size(92, 22)
        Me.tslblSearchBy.Text = "Search by Name :"
        '
        'tstxtSearchBy
        '
        Me.tstxtSearchBy.MaxLength = 50
        Me.tstxtSearchBy.Name = "tstxtSearchBy"
        Me.tstxtSearchBy.Size = New System.Drawing.Size(250, 25)
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(34, 22)
        Me.tsbtnGo.Text = "GO.."
        Me.tsbtnGo.ToolTipText = "Go"
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
        'dgvAgentDetails
        '
        Me.dgvAgentDetails.AllowUserToAddRows = False
        Me.dgvAgentDetails.AllowUserToDeleteRows = False
        Me.dgvAgentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAgentDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAgentDetails.Location = New System.Drawing.Point(0, 25)
        Me.dgvAgentDetails.Name = "dgvAgentDetails"
        Me.dgvAgentDetails.ReadOnly = True
        Me.dgvAgentDetails.Size = New System.Drawing.Size(969, 297)
        Me.dgvAgentDetails.TabIndex = 2
        '
        'tslblStatus
        '
        Me.tslblStatus.Name = "tslblStatus"
        Me.tslblStatus.Size = New System.Drawing.Size(45, 22)
        Me.tslblStatus.Text = "Status :"
        '
        'tscbStatus
        '
        Me.tscbStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.tscbStatus.Name = "tscbStatus"
        Me.tscbStatus.Size = New System.Drawing.Size(121, 25)
        '
        'vAgent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 322)
        Me.Controls.Add(Me.dgvAgentDetails)
        Me.Controls.Add(Me.tolForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "vAgent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "vAgent"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        CType(Me.dgvAgentDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tstxtSearchBy As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tslblSearchBy As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnXport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvAgentDetails As System.Windows.Forms.DataGridView
    Friend WithEvents tslblStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbStatus As System.Windows.Forms.ToolStripComboBox
End Class
