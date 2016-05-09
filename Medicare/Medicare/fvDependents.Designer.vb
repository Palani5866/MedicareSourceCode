<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fvDependents
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
        Me.lblREFTYPE = New System.Windows.Forms.Label
        Me.lblREFID = New System.Windows.Forms.Label
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.lblTYPE = New System.Windows.Forms.Label
        Me.dgvDepDetails = New System.Windows.Forms.DataGridView
        Me.cbTick = New System.Windows.Forms.DataGridViewCheckBoxColumn
        CType(Me.dgvDepDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblREFTYPE
        '
        Me.lblREFTYPE.AutoSize = True
        Me.lblREFTYPE.Location = New System.Drawing.Point(777, 383)
        Me.lblREFTYPE.Name = "lblREFTYPE"
        Me.lblREFTYPE.Size = New System.Drawing.Size(56, 13)
        Me.lblREFTYPE.TabIndex = 0
        Me.lblREFTYPE.Text = "REFTYPE"
        Me.lblREFTYPE.Visible = False
        '
        'lblREFID
        '
        Me.lblREFID.AutoSize = True
        Me.lblREFID.Location = New System.Drawing.Point(732, 383)
        Me.lblREFID.Name = "lblREFID"
        Me.lblREFID.Size = New System.Drawing.Size(39, 13)
        Me.lblREFID.TabIndex = 1
        Me.lblREFID.Text = "REFID"
        Me.lblREFID.Visible = False
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(402, 370)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 3
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblTYPE
        '
        Me.lblTYPE.AutoSize = True
        Me.lblTYPE.Location = New System.Drawing.Point(839, 383)
        Me.lblTYPE.Name = "lblTYPE"
        Me.lblTYPE.Size = New System.Drawing.Size(35, 13)
        Me.lblTYPE.TabIndex = 6
        Me.lblTYPE.Text = "TYPE"
        Me.lblTYPE.Visible = False
        '
        'dgvDepDetails
        '
        Me.dgvDepDetails.AllowUserToAddRows = False
        Me.dgvDepDetails.AllowUserToDeleteRows = False
        Me.dgvDepDetails.AllowUserToOrderColumns = True
        Me.dgvDepDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDepDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cbTick})
        Me.dgvDepDetails.Location = New System.Drawing.Point(8, 8)
        Me.dgvDepDetails.Name = "dgvDepDetails"
        Me.dgvDepDetails.Size = New System.Drawing.Size(930, 342)
        Me.dgvDepDetails.TabIndex = 7
        '
        'cbTick
        '
        Me.cbTick.FalseValue = "F"
        Me.cbTick.HeaderText = "Tick"
        Me.cbTick.Name = "cbTick"
        Me.cbTick.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cbTick.TrueValue = "T"
        '
        'fvDependents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 405)
        Me.Controls.Add(Me.dgvDepDetails)
        Me.Controls.Add(Me.lblTYPE)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.lblREFID)
        Me.Controls.Add(Me.lblREFTYPE)
        Me.Name = "fvDependents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List of Dependents"
        CType(Me.dgvDepDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblREFTYPE As System.Windows.Forms.Label
    Friend WithEvents lblREFID As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblTYPE As System.Windows.Forms.Label
    Friend WithEvents dgvDepDetails As System.Windows.Forms.DataGridView
    Friend WithEvents cbTick As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
