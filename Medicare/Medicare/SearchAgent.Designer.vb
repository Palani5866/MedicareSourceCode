<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchAgent
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
        Me.dgvAgentDetails = New System.Windows.Forms.DataGridView
        Me.gbAgentDetails = New System.Windows.Forms.GroupBox
        Me.gbAgentLevelDetails = New System.Windows.Forms.GroupBox
        Me.dgvAgentLevelDetails = New System.Windows.Forms.DataGridView
        CType(Me.dgvAgentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgentDetails.SuspendLayout()
        Me.gbAgentLevelDetails.SuspendLayout()
        CType(Me.dgvAgentLevelDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAgentDetails
        '
        Me.dgvAgentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAgentDetails.Location = New System.Drawing.Point(16, 19)
        Me.dgvAgentDetails.Name = "dgvAgentDetails"
        Me.dgvAgentDetails.Size = New System.Drawing.Size(618, 283)
        Me.dgvAgentDetails.TabIndex = 0
        '
        'gbAgentDetails
        '
        Me.gbAgentDetails.Controls.Add(Me.dgvAgentDetails)
        Me.gbAgentDetails.Location = New System.Drawing.Point(21, 12)
        Me.gbAgentDetails.Name = "gbAgentDetails"
        Me.gbAgentDetails.Size = New System.Drawing.Size(653, 317)
        Me.gbAgentDetails.TabIndex = 1
        Me.gbAgentDetails.TabStop = False
        Me.gbAgentDetails.Text = "Agent Details"
        '
        'gbAgentLevelDetails
        '
        Me.gbAgentLevelDetails.Controls.Add(Me.dgvAgentLevelDetails)
        Me.gbAgentLevelDetails.Location = New System.Drawing.Point(21, 345)
        Me.gbAgentLevelDetails.Name = "gbAgentLevelDetails"
        Me.gbAgentLevelDetails.Size = New System.Drawing.Size(653, 159)
        Me.gbAgentLevelDetails.TabIndex = 2
        Me.gbAgentLevelDetails.TabStop = False
        Me.gbAgentLevelDetails.Text = "Agent Level Details"
        '
        'dgvAgentLevelDetails
        '
        Me.dgvAgentLevelDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAgentLevelDetails.Location = New System.Drawing.Point(16, 19)
        Me.dgvAgentLevelDetails.Name = "dgvAgentLevelDetails"
        Me.dgvAgentLevelDetails.Size = New System.Drawing.Size(618, 125)
        Me.dgvAgentLevelDetails.TabIndex = 1
        '
        'SearchAgent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 516)
        Me.Controls.Add(Me.gbAgentLevelDetails)
        Me.Controls.Add(Me.gbAgentDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "SearchAgent"
        Me.Text = "SearchAgent"
        CType(Me.dgvAgentDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgentDetails.ResumeLayout(False)
        Me.gbAgentLevelDetails.ResumeLayout(False)
        CType(Me.dgvAgentLevelDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAgentDetails As System.Windows.Forms.DataGridView
    Friend WithEvents gbAgentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents gbAgentLevelDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvAgentLevelDetails As System.Windows.Forms.DataGridView
End Class
