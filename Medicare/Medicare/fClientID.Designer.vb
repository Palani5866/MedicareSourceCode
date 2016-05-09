<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fClientID
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvClientIDDetails = New System.Windows.Forms.DataGridView
        Me.colDeduction_BatchSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvSubmittedList = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgvClosedList = New System.Windows.Forms.DataGridView
        Me.lnkXport2Xcel = New System.Windows.Forms.LinkLabel
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvClientIDDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvSubmittedList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvClosedList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Controls.Add(Me.btnSubmit)
        Me.GroupBox1.Controls.Add(Me.dgvClientIDDetails)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(929, 234)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Exceptional Client ID Details"
        Me.GroupBox1.UseWaitCursor = True
        '
        'dgvClientIDDetails
        '
        Me.dgvClientIDDetails.AllowUserToAddRows = False
        Me.dgvClientIDDetails.AllowUserToDeleteRows = False
        Me.dgvClientIDDetails.AllowUserToOrderColumns = True
        Me.dgvClientIDDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClientIDDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDeduction_BatchSelected})
        Me.dgvClientIDDetails.Location = New System.Drawing.Point(3, 17)
        Me.dgvClientIDDetails.MultiSelect = False
        Me.dgvClientIDDetails.Name = "dgvClientIDDetails"
        Me.dgvClientIDDetails.Size = New System.Drawing.Size(920, 180)
        Me.dgvClientIDDetails.TabIndex = 9
        Me.dgvClientIDDetails.UseWaitCursor = True
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
        Me.btnSubmit.Location = New System.Drawing.Point(357, 204)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 10
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        Me.btnSubmit.UseWaitCursor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(438, 203)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 11
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        Me.btnClear.UseWaitCursor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvSubmittedList)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 247)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(929, 191)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Exceptional Client id Submitted List"
        '
        'dgvSubmittedList
        '
        Me.dgvSubmittedList.AllowUserToAddRows = False
        Me.dgvSubmittedList.AllowUserToDeleteRows = False
        Me.dgvSubmittedList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubmittedList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSubmittedList.Location = New System.Drawing.Point(3, 16)
        Me.dgvSubmittedList.Name = "dgvSubmittedList"
        Me.dgvSubmittedList.ReadOnly = True
        Me.dgvSubmittedList.Size = New System.Drawing.Size(923, 172)
        Me.dgvSubmittedList.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvClosedList)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 444)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(929, 191)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Exceptional Client id Closed List"
        '
        'dgvClosedList
        '
        Me.dgvClosedList.AllowUserToAddRows = False
        Me.dgvClosedList.AllowUserToDeleteRows = False
        Me.dgvClosedList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClosedList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClosedList.Location = New System.Drawing.Point(3, 16)
        Me.dgvClosedList.Name = "dgvClosedList"
        Me.dgvClosedList.ReadOnly = True
        Me.dgvClosedList.Size = New System.Drawing.Size(923, 172)
        Me.dgvClosedList.TabIndex = 0
        '
        'lnkXport2Xcel
        '
        Me.lnkXport2Xcel.AutoSize = True
        Me.lnkXport2Xcel.Location = New System.Drawing.Point(807, -1)
        Me.lnkXport2Xcel.Name = "lnkXport2Xcel"
        Me.lnkXport2Xcel.Size = New System.Drawing.Size(78, 13)
        Me.lnkXport2Xcel.TabIndex = 3
        Me.lnkXport2Xcel.TabStop = True
        Me.lnkXport2Xcel.Text = "Export to Excel"
        '
        'fClientID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 638)
        Me.Controls.Add(Me.lnkXport2Xcel)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fClientID"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EXCEPTIONAL CLIENT ID DETAILS"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvClientIDDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvSubmittedList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvClosedList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvClientIDDetails As System.Windows.Forms.DataGridView
    Friend WithEvents colDeduction_BatchSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSubmittedList As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvClosedList As System.Windows.Forms.DataGridView
    Friend WithEvents lnkXport2Xcel As System.Windows.Forms.LinkLabel
End Class
