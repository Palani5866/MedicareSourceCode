<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grdSubmitted_Proposers
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
        Me.btnFind = New System.Windows.Forms.Button
        Me.txtFind_String = New System.Windows.Forms.TextBox
        Me.cmbFind_Para = New System.Windows.Forms.ComboBox
        Me.lblFind = New System.Windows.Forms.Label
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.gbPMember = New System.Windows.Forms.GroupBox
        Me.dgvFind_Result = New System.Windows.Forms.DataGridView
        Me.gbMember = New System.Windows.Forms.GroupBox
        Me.dgvC2Mem = New System.Windows.Forms.DataGridView
        Me.btnSubmission2CIMB = New System.Windows.Forms.Button
        Me.btnPrint_SubmissionList_Yearly = New System.Windows.Forms.Button
        Me.btnConvert_Proposer2Member = New System.Windows.Forms.Button
        Me.btnGoto_AngkasaSubmissionDetails = New System.Windows.Forms.Button
        Me.btnPrint_AngkasaSubmissionList = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.gbPMember.SuspendLayout()
        CType(Me.dgvFind_Result, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMember.SuspendLayout()
        CType(Me.dgvC2Mem, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnFind)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFind_String)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbFind_Para)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFind)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1067, 664)
        Me.SplitContainer1.SplitterDistance = 70
        Me.SplitContainer1.TabIndex = 3
        '
        'btnFind
        '
        Me.btnFind.Enabled = False
        Me.btnFind.Location = New System.Drawing.Point(682, 24)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(35, 23)
        Me.btnFind.TabIndex = 3
        Me.btnFind.Text = "&Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtFind_String
        '
        Me.txtFind_String.Enabled = False
        Me.txtFind_String.Location = New System.Drawing.Point(244, 25)
        Me.txtFind_String.Name = "txtFind_String"
        Me.txtFind_String.Size = New System.Drawing.Size(432, 20)
        Me.txtFind_String.TabIndex = 2
        '
        'cmbFind_Para
        '
        Me.cmbFind_Para.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFind_Para.Enabled = False
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.gbPMember)
        Me.SplitContainer2.Panel1.Controls.Add(Me.gbMember)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnSubmission2CIMB)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnPrint_SubmissionList_Yearly)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnConvert_Proposer2Member)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnGoto_AngkasaSubmissionDetails)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnPrint_AngkasaSubmissionList)
        Me.SplitContainer2.Size = New System.Drawing.Size(1067, 590)
        Me.SplitContainer2.SplitterDistance = 520
        Me.SplitContainer2.TabIndex = 0
        '
        'gbPMember
        '
        Me.gbPMember.Controls.Add(Me.dgvFind_Result)
        Me.gbPMember.Location = New System.Drawing.Point(15, 18)
        Me.gbPMember.Name = "gbPMember"
        Me.gbPMember.Size = New System.Drawing.Size(1040, 235)
        Me.gbPMember.TabIndex = 4
        Me.gbPMember.TabStop = False
        Me.gbPMember.Text = "Pending Member List"
        '
        'dgvFind_Result
        '
        Me.dgvFind_Result.AllowUserToAddRows = False
        Me.dgvFind_Result.AllowUserToDeleteRows = False
        Me.dgvFind_Result.AllowUserToOrderColumns = True
        Me.dgvFind_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFind_Result.Location = New System.Drawing.Point(6, 19)
        Me.dgvFind_Result.MultiSelect = False
        Me.dgvFind_Result.Name = "dgvFind_Result"
        Me.dgvFind_Result.ReadOnly = True
        Me.dgvFind_Result.Size = New System.Drawing.Size(1018, 200)
        Me.dgvFind_Result.TabIndex = 2
        '
        'gbMember
        '
        Me.gbMember.Controls.Add(Me.dgvC2Mem)
        Me.gbMember.Location = New System.Drawing.Point(15, 278)
        Me.gbMember.Name = "gbMember"
        Me.gbMember.Size = New System.Drawing.Size(1040, 226)
        Me.gbMember.TabIndex = 3
        Me.gbMember.TabStop = False
        Me.gbMember.Text = "Converted to Member"
        '
        'dgvC2Mem
        '
        Me.dgvC2Mem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvC2Mem.Location = New System.Drawing.Point(6, 19)
        Me.dgvC2Mem.Name = "dgvC2Mem"
        Me.dgvC2Mem.Size = New System.Drawing.Size(1018, 189)
        Me.dgvC2Mem.TabIndex = 0
        '
        'btnSubmission2CIMB
        '
        Me.btnSubmission2CIMB.Location = New System.Drawing.Point(596, 9)
        Me.btnSubmission2CIMB.Name = "btnSubmission2CIMB"
        Me.btnSubmission2CIMB.Size = New System.Drawing.Size(156, 23)
        Me.btnSubmission2CIMB.TabIndex = 4
        Me.btnSubmission2CIMB.Text = "Submission to Sun Life"
        Me.btnSubmission2CIMB.UseVisualStyleBackColor = True
        '
        'btnPrint_SubmissionList_Yearly
        '
        Me.btnPrint_SubmissionList_Yearly.Location = New System.Drawing.Point(173, 9)
        Me.btnPrint_SubmissionList_Yearly.Name = "btnPrint_SubmissionList_Yearly"
        Me.btnPrint_SubmissionList_Yearly.Size = New System.Drawing.Size(166, 23)
        Me.btnPrint_SubmissionList_Yearly.TabIndex = 1
        Me.btnPrint_SubmissionList_Yearly.Text = "Print Submission (Yearly Cases)"
        Me.btnPrint_SubmissionList_Yearly.UseVisualStyleBackColor = True
        '
        'btnConvert_Proposer2Member
        '
        Me.btnConvert_Proposer2Member.Location = New System.Drawing.Point(434, 9)
        Me.btnConvert_Proposer2Member.Name = "btnConvert_Proposer2Member"
        Me.btnConvert_Proposer2Member.Size = New System.Drawing.Size(156, 23)
        Me.btnConvert_Proposer2Member.TabIndex = 3
        Me.btnConvert_Proposer2Member.Text = "Convert Proposer to Member"
        Me.btnConvert_Proposer2Member.UseVisualStyleBackColor = True
        '
        'btnGoto_AngkasaSubmissionDetails
        '
        Me.btnGoto_AngkasaSubmissionDetails.Location = New System.Drawing.Point(345, 9)
        Me.btnGoto_AngkasaSubmissionDetails.Name = "btnGoto_AngkasaSubmissionDetails"
        Me.btnGoto_AngkasaSubmissionDetails.Size = New System.Drawing.Size(83, 23)
        Me.btnGoto_AngkasaSubmissionDetails.TabIndex = 2
        Me.btnGoto_AngkasaSubmissionDetails.Text = "Go To Details"
        Me.btnGoto_AngkasaSubmissionDetails.UseVisualStyleBackColor = True
        '
        'btnPrint_AngkasaSubmissionList
        '
        Me.btnPrint_AngkasaSubmissionList.Location = New System.Drawing.Point(15, 9)
        Me.btnPrint_AngkasaSubmissionList.Name = "btnPrint_AngkasaSubmissionList"
        Me.btnPrint_AngkasaSubmissionList.Size = New System.Drawing.Size(152, 23)
        Me.btnPrint_AngkasaSubmissionList.TabIndex = 0
        Me.btnPrint_AngkasaSubmissionList.Text = "Print Submission to Angkasa"
        Me.btnPrint_AngkasaSubmissionList.UseVisualStyleBackColor = True
        '
        'grdSubmitted_Proposers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1067, 664)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "grdSubmitted_Proposers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List of Proposers Submitted to Angkasa"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.gbPMember.ResumeLayout(False)
        CType(Me.dgvFind_Result, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMember.ResumeLayout(False)
        CType(Me.dgvC2Mem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtFind_String As System.Windows.Forms.TextBox
    Friend WithEvents cmbFind_Para As System.Windows.Forms.ComboBox
    Friend WithEvents lblFind As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvFind_Result As System.Windows.Forms.DataGridView
    Friend WithEvents btnGoto_AngkasaSubmissionDetails As System.Windows.Forms.Button
    Friend WithEvents btnPrint_AngkasaSubmissionList As System.Windows.Forms.Button
    Friend WithEvents btnConvert_Proposer2Member As System.Windows.Forms.Button
    Friend WithEvents btnPrint_SubmissionList_Yearly As System.Windows.Forms.Button
    Friend WithEvents gbMember As System.Windows.Forms.GroupBox
    Friend WithEvents dgvC2Mem As System.Windows.Forms.DataGridView
    Friend WithEvents gbPMember As System.Windows.Forms.GroupBox
    Friend WithEvents btnSubmission2CIMB As System.Windows.Forms.Button
End Class
