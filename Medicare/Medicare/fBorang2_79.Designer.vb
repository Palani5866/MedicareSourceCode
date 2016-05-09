<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fBorang2_79
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.rdIgnore = New System.Windows.Forms.RadioButton
        Me.rd0599 = New System.Windows.Forms.RadioButton
        Me.rdiRT_CR = New System.Windows.Forms.RadioButton
        Me.rdReprocessing = New System.Windows.Forms.RadioButton
        Me.lblMemberPolicy_ID = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgvPaymentException = New System.Windows.Forms.DataGridView
        Me.colDeduction_BatchSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvPaymentException, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(625, 381)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 24
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.lblRemarks)
        Me.GroupBox1.Controls.Add(Me.rdIgnore)
        Me.GroupBox1.Controls.Add(Me.rd0599)
        Me.GroupBox1.Controls.Add(Me.rdiRT_CR)
        Me.GroupBox1.Controls.Add(Me.rdReprocessing)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Green
        Me.GroupBox1.Location = New System.Drawing.Point(2, 226)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(777, 146)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Action: Transfer to Policy Holder's Account/Permanent Suspend Account"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(76, 77)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(681, 51)
        Me.txtRemarks.TabIndex = 8
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(20, 77)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(55, 13)
        Me.lblRemarks.TabIndex = 7
        Me.lblRemarks.Text = "Remarks :"
        '
        'rdIgnore
        '
        Me.rdIgnore.AutoSize = True
        Me.rdIgnore.Location = New System.Drawing.Point(391, 42)
        Me.rdIgnore.Name = "rdIgnore"
        Me.rdIgnore.Size = New System.Drawing.Size(55, 17)
        Me.rdIgnore.TabIndex = 2
        Me.rdIgnore.Text = "Ignore"
        Me.rdIgnore.UseVisualStyleBackColor = True
        '
        'rd0599
        '
        Me.rd0599.AutoSize = True
        Me.rd0599.Location = New System.Drawing.Point(391, 19)
        Me.rd0599.Name = "rd0599"
        Me.rd0599.Size = New System.Drawing.Size(49, 17)
        Me.rd0599.TabIndex = 1
        Me.rd0599.Text = "0599"
        Me.rd0599.UseVisualStyleBackColor = True
        '
        'rdiRT_CR
        '
        Me.rdiRT_CR.AutoSize = True
        Me.rdiRT_CR.Location = New System.Drawing.Point(13, 42)
        Me.rdiRT_CR.Name = "rdiRT_CR"
        Me.rdiRT_CR.Size = New System.Drawing.Size(312, 17)
        Me.rdiRT_CR.TabIndex = 4
        Me.rdiRT_CR.Text = "Cancelled / Retired policy but monthly deduction still goes on"
        Me.rdiRT_CR.UseVisualStyleBackColor = True
        '
        'rdReprocessing
        '
        Me.rdReprocessing.AutoSize = True
        Me.rdReprocessing.Location = New System.Drawing.Point(13, 19)
        Me.rdReprocessing.Name = "rdReprocessing"
        Me.rdReprocessing.Size = New System.Drawing.Size(249, 17)
        Me.rdReprocessing.TabIndex = 0
        Me.rdReprocessing.Text = "Reprocessing after updating of Member's Policy"
        Me.rdReprocessing.UseVisualStyleBackColor = True
        '
        'lblMemberPolicy_ID
        '
        Me.lblMemberPolicy_ID.AutoSize = True
        Me.lblMemberPolicy_ID.Location = New System.Drawing.Point(504, 549)
        Me.lblMemberPolicy_ID.Name = "lblMemberPolicy_ID"
        Me.lblMemberPolicy_ID.Size = New System.Drawing.Size(34, 13)
        Me.lblMemberPolicy_ID.TabIndex = 26
        Me.lblMemberPolicy_ID.Text = "GUID"
        Me.lblMemberPolicy_ID.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvPaymentException)
        Me.GroupBox3.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(777, 218)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Payment Exceptions Details"
        '
        'dgvPaymentException
        '
        Me.dgvPaymentException.AllowUserToAddRows = False
        Me.dgvPaymentException.AllowUserToDeleteRows = False
        Me.dgvPaymentException.AllowUserToOrderColumns = True
        Me.dgvPaymentException.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPaymentException.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDeduction_BatchSelected})
        Me.dgvPaymentException.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPaymentException.Location = New System.Drawing.Point(3, 16)
        Me.dgvPaymentException.MultiSelect = False
        Me.dgvPaymentException.Name = "dgvPaymentException"
        Me.dgvPaymentException.Size = New System.Drawing.Size(771, 199)
        Me.dgvPaymentException.TabIndex = 6
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
        'fBorang2_79
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(783, 422)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblMemberPolicy_ID)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fBorang2_79"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Borang 2/79"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvPaymentException, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdiRT_CR As System.Windows.Forms.RadioButton
    Friend WithEvents rd0599 As System.Windows.Forms.RadioButton
    Friend WithEvents lblMemberPolicy_ID As System.Windows.Forms.Label
    Friend WithEvents rdIgnore As System.Windows.Forms.RadioButton
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPaymentException As System.Windows.Forms.DataGridView
    Friend WithEvents colDeduction_BatchSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents rdReprocessing As System.Windows.Forms.RadioButton

End Class
