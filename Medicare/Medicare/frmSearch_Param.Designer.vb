<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch_Param
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
        Me.lblProposer_ID = New System.Windows.Forms.Label
        Me.lblPayment_Frequency = New System.Windows.Forms.Label
        Me.lblPlan_Code = New System.Windows.Forms.Label
        Me.lblForm_Flag = New System.Windows.Forms.Label
        Me.btnFind = New System.Windows.Forms.Button
        Me.txtFind_String = New System.Windows.Forms.TextBox
        Me.cmbFind_Para = New System.Windows.Forms.ComboBox
        Me.lblFind = New System.Windows.Forms.Label
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.dgvFind_Result = New System.Windows.Forms.DataGridView
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblProposer_ID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblPayment_Frequency)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblPlan_Code)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(684, 464)
        Me.SplitContainer1.SplitterDistance = 94
        Me.SplitContainer1.TabIndex = 1
        '
        'lblProposer_ID
        '
        Me.lblProposer_ID.AutoSize = True
        Me.lblProposer_ID.Location = New System.Drawing.Point(500, 28)
        Me.lblProposer_ID.Name = "lblProposer_ID"
        Me.lblProposer_ID.Size = New System.Drawing.Size(66, 13)
        Me.lblProposer_ID.TabIndex = 7
        Me.lblProposer_ID.Text = "Proposer_ID"
        Me.lblProposer_ID.Visible = False
        '
        'lblPayment_Frequency
        '
        Me.lblPayment_Frequency.AutoSize = True
        Me.lblPayment_Frequency.Location = New System.Drawing.Point(390, 28)
        Me.lblPayment_Frequency.Name = "lblPayment_Frequency"
        Me.lblPayment_Frequency.Size = New System.Drawing.Size(104, 13)
        Me.lblPayment_Frequency.TabIndex = 6
        Me.lblPayment_Frequency.Text = "Payment_Frequency"
        Me.lblPayment_Frequency.Visible = False
        '
        'lblPlan_Code
        '
        Me.lblPlan_Code.AutoSize = True
        Me.lblPlan_Code.Location = New System.Drawing.Point(325, 29)
        Me.lblPlan_Code.Name = "lblPlan_Code"
        Me.lblPlan_Code.Size = New System.Drawing.Size(59, 13)
        Me.lblPlan_Code.TabIndex = 5
        Me.lblPlan_Code.Text = "Plan_Code"
        Me.lblPlan_Code.Visible = False
        '
        'lblForm_Flag
        '
        Me.lblForm_Flag.AutoSize = True
        Me.lblForm_Flag.Location = New System.Drawing.Point(12, 75)
        Me.lblForm_Flag.Name = "lblForm_Flag"
        Me.lblForm_Flag.Size = New System.Drawing.Size(629, 13)
        Me.lblForm_Flag.TabIndex = 4
        Me.lblForm_Flag.Text = "T-Title, S-State, P-Plan, P2 - Level 2 Plan, $ - Payment Method, A-Agent, D-Decli" & _
            "ne Reason, E-Exclusion Clause, SC-Spouse / Child"
        Me.lblForm_Flag.Visible = False
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(536, 51)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(35, 23)
        Me.btnFind.TabIndex = 3
        Me.btnFind.Text = "&Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtFind_String
        '
        Me.txtFind_String.Location = New System.Drawing.Point(98, 52)
        Me.txtFind_String.Name = "txtFind_String"
        Me.txtFind_String.Size = New System.Drawing.Size(432, 20)
        Me.txtFind_String.TabIndex = 2
        '
        'cmbFind_Para
        '
        Me.cmbFind_Para.FormattingEnabled = True
        Me.cmbFind_Para.Location = New System.Drawing.Point(98, 25)
        Me.cmbFind_Para.Name = "cmbFind_Para"
        Me.cmbFind_Para.Size = New System.Drawing.Size(212, 21)
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
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnCancel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnOK)
        Me.SplitContainer2.Size = New System.Drawing.Size(684, 366)
        Me.SplitContainer2.SplitterDistance = 320
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
        Me.dgvFind_Result.Size = New System.Drawing.Size(684, 320)
        Me.dgvFind_Result.TabIndex = 2
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
        'frmSearch_Param
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 464)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearch_Param"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Parameter"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvFind_Result, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtFind_String As System.Windows.Forms.TextBox
    Friend WithEvents cmbFind_Para As System.Windows.Forms.ComboBox
    Friend WithEvents lblFind As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvFind_Result As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblForm_Flag As System.Windows.Forms.Label
    Friend WithEvents lblPlan_Code As System.Windows.Forms.Label
    Friend WithEvents lblPayment_Frequency As System.Windows.Forms.Label
    Friend WithEvents lblProposer_ID As System.Windows.Forms.Label
End Class
