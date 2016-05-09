<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vShortfallsDetails
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
        Me.dgvSD = New System.Windows.Forms.DataGridView
        Me.IC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FULLNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TOTALSHORT = New System.Windows.Forms.DataGridViewLinkColumn
        Me.RECOVEREDAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BALANCEAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvSD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSD
        '
        Me.dgvSD.AllowUserToAddRows = False
        Me.dgvSD.AllowUserToDeleteRows = False
        Me.dgvSD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IC, Me.FULLNAME, Me.TOTALSHORT, Me.RECOVEREDAMT, Me.BALANCEAMT})
        Me.dgvSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSD.Location = New System.Drawing.Point(0, 0)
        Me.dgvSD.Name = "dgvSD"
        Me.dgvSD.ReadOnly = True
        Me.dgvSD.Size = New System.Drawing.Size(782, 386)
        Me.dgvSD.TabIndex = 0
        '
        'IC
        '
        Me.IC.HeaderText = "IC"
        Me.IC.Name = "IC"
        Me.IC.ReadOnly = True
        '
        'FULLNAME
        '
        Me.FULLNAME.HeaderText = "FULL NAME"
        Me.FULLNAME.Name = "FULLNAME"
        Me.FULLNAME.ReadOnly = True
        '
        'TOTALSHORT
        '
        Me.TOTALSHORT.DataPropertyName = "TOTALSHORT"
        Me.TOTALSHORT.HeaderText = "TOTAL SHORT"
        Me.TOTALSHORT.Name = "TOTALSHORT"
        Me.TOTALSHORT.ReadOnly = True
        Me.TOTALSHORT.UseColumnTextForLinkValue = True
        '
        'RECOVEREDAMT
        '
        Me.RECOVEREDAMT.HeaderText = "RECOVERED AMOUNT"
        Me.RECOVEREDAMT.Name = "RECOVEREDAMT"
        Me.RECOVEREDAMT.ReadOnly = True
        '
        'BALANCEAMT
        '
        Me.BALANCEAMT.HeaderText = "BALANCE AMOUNT"
        Me.BALANCEAMT.Name = "BALANCEAMT"
        Me.BALANCEAMT.ReadOnly = True
        '
        'vShortfallsDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 386)
        Me.Controls.Add(Me.dgvSD)
        Me.Name = "vShortfallsDetails"
        Me.Text = "Short Falls Details"
        CType(Me.dgvSD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvSD As System.Windows.Forms.DataGridView
    Friend WithEvents IC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FULLNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTALSHORT As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents RECOVEREDAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BALANCEAMT As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
