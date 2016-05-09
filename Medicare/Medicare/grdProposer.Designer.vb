<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdProposer
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblSubmission_Batch_No = New System.Windows.Forms.Label
        Me.lblForm_Flag = New System.Windows.Forms.Label
        Me.btnFind = New System.Windows.Forms.Button
        Me.txtFind_String = New System.Windows.Forms.TextBox
        Me.cmbFind_Para = New System.Windows.Forms.ComboBox
        Me.lblFind = New System.Windows.Forms.Label
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.dgvFind_Result = New System.Windows.Forms.DataGridView
        Me.lblVerficationCheck = New System.Windows.Forms.Label
        Me.btnConversion = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvFind_Result, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSubmission_Batch_No)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblForm_Flag)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnFind)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFind_String)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbFind_Para)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFind)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1020, 491)
        Me.SplitContainer1.SplitterDistance = 70
        Me.SplitContainer1.TabIndex = 2
        '
        'lblSubmission_Batch_No
        '
        Me.lblSubmission_Batch_No.AutoSize = True
        Me.lblSubmission_Batch_No.Location = New System.Drawing.Point(655, 50)
        Me.lblSubmission_Batch_No.Name = "lblSubmission_Batch_No"
        Me.lblSubmission_Batch_No.Size = New System.Drawing.Size(108, 13)
        Me.lblSubmission_Batch_No.TabIndex = 5
        Me.lblSubmission_Batch_No.Text = "Submission Batch No"
        Me.lblSubmission_Batch_No.Visible = False
        '
        'lblForm_Flag
        '
        Me.lblForm_Flag.AutoSize = True
        Me.lblForm_Flag.Location = New System.Drawing.Point(534, 48)
        Me.lblForm_Flag.Name = "lblForm_Flag"
        Me.lblForm_Flag.Size = New System.Drawing.Size(115, 13)
        Me.lblForm_Flag.TabIndex = 4
        Me.lblForm_Flag.Text = "0-Non-Verify, 1-Verified"
        Me.lblForm_Flag.Visible = False
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(682, 24)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(35, 23)
        Me.btnFind.TabIndex = 3
        Me.btnFind.Text = "&Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtFind_String
        '
        Me.txtFind_String.Location = New System.Drawing.Point(244, 25)
        Me.txtFind_String.Name = "txtFind_String"
        Me.txtFind_String.Size = New System.Drawing.Size(432, 20)
        Me.txtFind_String.TabIndex = 2
        '
        'cmbFind_Para
        '
        Me.cmbFind_Para.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFind_Para.FormattingEnabled = True
        Me.cmbFind_Para.Items.AddRange(New Object() {"IC (New)", "Full Name", "- Show ALL -"})
        Me.cmbFind_Para.Location = New System.Drawing.Point(98, 25)
        Me.cmbFind_Para.Name = "cmbFind_Para"
        Me.cmbFind_Para.Size = New System.Drawing.Size(140, 21)
        Me.cmbFind_Para.TabIndex = 1
        '
        'lblFind
        '
        Me.lblFind.AutoSize = True
        Me.lblFind.Location = New System.Drawing.Point(12, 29)
        Me.lblFind.Name = "lblFind"
        Me.lblFind.Size = New System.Drawing.Size(80, 13)
        Me.lblFind.TabIndex = 0
        Me.lblFind.Text = "Find Based On:"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvFind_Result)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblVerficationCheck)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnConversion)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnCancel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnOK)
        Me.SplitContainer2.Size = New System.Drawing.Size(1020, 417)
        Me.SplitContainer2.SplitterDistance = 371
        Me.SplitContainer2.TabIndex = 0
        '
        'dgvFind_Result
        '
        Me.dgvFind_Result.AllowUserToAddRows = False
        Me.dgvFind_Result.AllowUserToDeleteRows = False
        Me.dgvFind_Result.AllowUserToOrderColumns = True
        Me.dgvFind_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFind_Result.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFind_Result.Location = New System.Drawing.Point(0, 0)
        Me.dgvFind_Result.MultiSelect = False
        Me.dgvFind_Result.Name = "dgvFind_Result"
        Me.dgvFind_Result.ReadOnly = True
        Me.dgvFind_Result.Size = New System.Drawing.Size(1020, 371)
        Me.dgvFind_Result.TabIndex = 2
        '
        'lblVerficationCheck
        '
        Me.lblVerficationCheck.AutoSize = True
        Me.lblVerficationCheck.Location = New System.Drawing.Point(503, 15)
        Me.lblVerficationCheck.Name = "lblVerficationCheck"
        Me.lblVerficationCheck.Size = New System.Drawing.Size(14, 13)
        Me.lblVerficationCheck.TabIndex = 33
        Me.lblVerficationCheck.Text = "V"
        Me.lblVerficationCheck.Visible = False
        '
        'btnConversion
        '
        Me.btnConversion.Location = New System.Drawing.Point(933, 9)
        Me.btnConversion.Name = "btnConversion"
        Me.btnConversion.Size = New System.Drawing.Size(75, 23)
        Me.btnConversion.TabIndex = 4
        Me.btnConversion.Text = "Conversion"
        Me.btnConversion.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(98, 9)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(15, 9)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'grdProposer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1020, 491)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdProposer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List of Proposer"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvFind_Result, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblForm_Flag As System.Windows.Forms.Label
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtFind_String As System.Windows.Forms.TextBox
    Friend WithEvents cmbFind_Para As System.Windows.Forms.ComboBox
    Friend WithEvents lblFind As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvFind_Result As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblSubmission_Batch_No As System.Windows.Forms.Label
    Friend WithEvents btnConversion As System.Windows.Forms.Button
    Friend WithEvents lblVerficationCheck As System.Windows.Forms.Label
End Class
