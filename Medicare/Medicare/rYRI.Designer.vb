<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rYRI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rYRI))
        Me.gbYRR = New System.Windows.Forms.GroupBox
        Me.gbYRC = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.gbYRR.SuspendLayout()
        Me.gbYRC.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbYRR
        '
        Me.gbYRR.Controls.Add(Me.DataGridView1)
        Me.gbYRR.Location = New System.Drawing.Point(-2, 28)
        Me.gbYRR.Name = "gbYRR"
        Me.gbYRR.Size = New System.Drawing.Size(1156, 186)
        Me.gbYRR.TabIndex = 0
        Me.gbYRR.TabStop = False
        Me.gbYRR.Text = "Yearly Requested Details"
        '
        'gbYRC
        '
        Me.gbYRC.Controls.Add(Me.DataGridView2)
        Me.gbYRC.Location = New System.Drawing.Point(-2, 235)
        Me.gbYRC.Name = "gbYRC"
        Me.gbYRC.Size = New System.Drawing.Size(1156, 241)
        Me.gbYRC.TabIndex = 1
        Me.gbYRC.TabStop = False
        Me.gbYRC.Text = "Yearly Closed Details"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1150, 167)
        Me.DataGridView1.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(1150, 222)
        Me.DataGridView2.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.tsXport2Xcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1156, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsXport2Xcel
        '
        Me.tsXport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsXport2Xcel.Image = CType(resources.GetObject("tsXport2Xcel.Image"), System.Drawing.Image)
        Me.tsXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsXport2Xcel.Name = "tsXport2Xcel"
        Me.tsXport2Xcel.Size = New System.Drawing.Size(87, 22)
        Me.tsXport2Xcel.Text = "Export to Excel"
        '
        'rYRI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 488)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbYRC)
        Me.Controls.Add(Me.gbYRR)
        Me.Name = "rYRI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Yearly Invoice Listing Details for Others"
        Me.gbYRR.ResumeLayout(False)
        Me.gbYRC.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbYRR As System.Windows.Forms.GroupBox
    Friend WithEvents gbYRC As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsXport2Xcel As System.Windows.Forms.ToolStripButton
End Class
