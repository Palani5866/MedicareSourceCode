<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UWCIMB
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
        Me.dgvUW = New System.Windows.Forms.DataGridView
        Me.colDeduction_BatchSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.gbUBCIMBSPL = New System.Windows.Forms.GroupBox
        Me.gbUBCIMBSL = New System.Windows.Forms.GroupBox
        Me.dgvUWCIMBSL = New System.Windows.Forms.DataGridView
        Me.UWSLFROMCIMB = New System.Windows.Forms.GroupBox
        Me.dgvUWRLCIMB = New System.Windows.Forms.DataGridView
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btnUWRLCIMB = New System.Windows.Forms.Button
        CType(Me.dgvUW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbUBCIMBSPL.SuspendLayout()
        Me.gbUBCIMBSL.SuspendLayout()
        CType(Me.dgvUWCIMBSL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UWSLFROMCIMB.SuspendLayout()
        CType(Me.dgvUWRLCIMB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvUW
        '
        Me.dgvUW.AllowUserToAddRows = False
        Me.dgvUW.AllowUserToDeleteRows = False
        Me.dgvUW.AllowUserToOrderColumns = True
        Me.dgvUW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUW.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDeduction_BatchSelected})
        Me.dgvUW.Location = New System.Drawing.Point(13, 28)
        Me.dgvUW.MultiSelect = False
        Me.dgvUW.Name = "dgvUW"
        Me.dgvUW.Size = New System.Drawing.Size(936, 179)
        Me.dgvUW.TabIndex = 6
        '
        'colDeduction_BatchSelected
        '
        Me.colDeduction_BatchSelected.FalseValue = "F"
        Me.colDeduction_BatchSelected.HeaderText = "(Tick)"
        Me.colDeduction_BatchSelected.IndeterminateValue = ""
        Me.colDeduction_BatchSelected.Name = "colDeduction_BatchSelected"
        Me.colDeduction_BatchSelected.TrueValue = "T"
        Me.colDeduction_BatchSelected.Width = 50
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(18, 245)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(127, 23)
        Me.btnSubmit.TabIndex = 7
        Me.btnSubmit.Text = "Submit to Sun Life"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'gbUBCIMBSPL
        '
        Me.gbUBCIMBSPL.Controls.Add(Me.dgvUW)
        Me.gbUBCIMBSPL.Location = New System.Drawing.Point(5, 13)
        Me.gbUBCIMBSPL.Name = "gbUBCIMBSPL"
        Me.gbUBCIMBSPL.Size = New System.Drawing.Size(973, 224)
        Me.gbUBCIMBSPL.TabIndex = 8
        Me.gbUBCIMBSPL.TabStop = False
        Me.gbUBCIMBSPL.Text = "Under Writing Submission Pending List"
        '
        'gbUBCIMBSL
        '
        Me.gbUBCIMBSL.Controls.Add(Me.dgvUWCIMBSL)
        Me.gbUBCIMBSL.Location = New System.Drawing.Point(5, 492)
        Me.gbUBCIMBSL.Name = "gbUBCIMBSL"
        Me.gbUBCIMBSL.Size = New System.Drawing.Size(973, 195)
        Me.gbUBCIMBSL.TabIndex = 9
        Me.gbUBCIMBSL.TabStop = False
        Me.gbUBCIMBSL.Text = "Under Writing Submitted List"
        '
        'dgvUWCIMBSL
        '
        Me.dgvUWCIMBSL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUWCIMBSL.Location = New System.Drawing.Point(13, 29)
        Me.dgvUWCIMBSL.Name = "dgvUWCIMBSL"
        Me.dgvUWCIMBSL.Size = New System.Drawing.Size(936, 150)
        Me.dgvUWCIMBSL.TabIndex = 0
        '
        'UWSLFROMCIMB
        '
        Me.UWSLFROMCIMB.Controls.Add(Me.dgvUWRLCIMB)
        Me.UWSLFROMCIMB.Location = New System.Drawing.Point(8, 280)
        Me.UWSLFROMCIMB.Name = "UWSLFROMCIMB"
        Me.UWSLFROMCIMB.Size = New System.Drawing.Size(973, 176)
        Me.UWSLFROMCIMB.TabIndex = 10
        Me.UWSLFROMCIMB.TabStop = False
        Me.UWSLFROMCIMB.Text = "Under Writing Received List from Sun Life "
        '
        'dgvUWRLCIMB
        '
        Me.dgvUWRLCIMB.AllowUserToAddRows = False
        Me.dgvUWRLCIMB.AllowUserToDeleteRows = False
        Me.dgvUWRLCIMB.AllowUserToOrderColumns = True
        Me.dgvUWRLCIMB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUWRLCIMB.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1})
        Me.dgvUWRLCIMB.Location = New System.Drawing.Point(13, 26)
        Me.dgvUWRLCIMB.MultiSelect = False
        Me.dgvUWRLCIMB.Name = "dgvUWRLCIMB"
        Me.dgvUWRLCIMB.Size = New System.Drawing.Size(936, 131)
        Me.dgvUWRLCIMB.TabIndex = 6
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.FalseValue = "F"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "(Tick)"
        Me.DataGridViewCheckBoxColumn1.IndeterminateValue = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.TrueValue = "T"
        Me.DataGridViewCheckBoxColumn1.Width = 50
        '
        'btnUWRLCIMB
        '
        Me.btnUWRLCIMB.Location = New System.Drawing.Point(18, 463)
        Me.btnUWRLCIMB.Name = "btnUWRLCIMB"
        Me.btnUWRLCIMB.Size = New System.Drawing.Size(166, 23)
        Me.btnUWRLCIMB.TabIndex = 11
        Me.btnUWRLCIMB.Text = "Submit (Status 1PU to 1U)"
        Me.btnUWRLCIMB.UseVisualStyleBackColor = True
        '
        'UWCIMB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 698)
        Me.Controls.Add(Me.btnUWRLCIMB)
        Me.Controls.Add(Me.UWSLFROMCIMB)
        Me.Controls.Add(Me.gbUBCIMBSL)
        Me.Controls.Add(Me.gbUBCIMBSPL)
        Me.Controls.Add(Me.btnSubmit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "UWCIMB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Submission Under Writing to Sun Life"
        CType(Me.dgvUW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbUBCIMBSPL.ResumeLayout(False)
        Me.gbUBCIMBSL.ResumeLayout(False)
        CType(Me.dgvUWCIMBSL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UWSLFROMCIMB.ResumeLayout(False)
        CType(Me.dgvUWRLCIMB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvUW As System.Windows.Forms.DataGridView
    Friend WithEvents colDeduction_BatchSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents gbUBCIMBSPL As System.Windows.Forms.GroupBox
    Friend WithEvents gbUBCIMBSL As System.Windows.Forms.GroupBox
    Friend WithEvents dgvUWCIMBSL As System.Windows.Forms.DataGridView
    Friend WithEvents UWSLFROMCIMB As System.Windows.Forms.GroupBox
    Friend WithEvents dgvUWRLCIMB As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnUWRLCIMB As System.Windows.Forms.Button
End Class
