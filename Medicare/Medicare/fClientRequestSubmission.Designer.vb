<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fClientRequestSubmission
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fClientRequestSubmission))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tslblDate_From = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDate_From = New System.Windows.Forms.ToolStripTextBox
        Me.tsReport_lblDate_To = New System.Windows.Forms.ToolStripLabel
        Me.tstxtDate_To = New System.Windows.Forms.ToolStripTextBox
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.tsReport_Div1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnExport = New System.Windows.Forms.ToolStripButton
        Me.gbPendingSubmission = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.dgvPendingSubmission = New System.Windows.Forms.DataGridView
        Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.gbPendingPost = New System.Windows.Forms.GroupBox
        Me.dgvPendingPost = New System.Windows.Forms.DataGridView
        Me.gbPostedClaims = New System.Windows.Forms.GroupBox
        Me.dgvPostedDetails = New System.Windows.Forms.DataGridView
        Me.PostedDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Action = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Print = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsReport.SuspendLayout()
        Me.gbPendingSubmission.SuspendLayout()
        CType(Me.dgvPendingSubmission, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPendingPost.SuspendLayout()
        CType(Me.dgvPendingPost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPostedClaims.SuspendLayout()
        CType(Me.dgvPostedDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblDate_From, Me.tstxtDate_From, Me.tsReport_lblDate_To, Me.tstxtDate_To, Me.tsbtnGo, Me.tsReport_Div1, Me.tsbtnExport})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1070, 25)
        Me.tsReport.TabIndex = 10
        Me.tsReport.Text = "ToolStrip"
        '
        'tslblDate_From
        '
        Me.tslblDate_From.Name = "tslblDate_From"
        Me.tslblDate_From.Size = New System.Drawing.Size(199, 22)
        Me.tslblDate_From.Text = "Request Date - From (dd/mm/yyyy):"
        '
        'tstxtDate_From
        '
        Me.tstxtDate_From.MaxLength = 10
        Me.tstxtDate_From.Name = "tstxtDate_From"
        Me.tstxtDate_From.Size = New System.Drawing.Size(100, 25)
        '
        'tsReport_lblDate_To
        '
        Me.tsReport_lblDate_To.Name = "tsReport_lblDate_To"
        Me.tsReport_lblDate_To.Size = New System.Drawing.Size(185, 22)
        Me.tsReport_lblDate_To.Text = "Request Date - To (dd/mm/yyyy):"
        '
        'tstxtDate_To
        '
        Me.tstxtDate_To.MaxLength = 10
        Me.tstxtDate_To.Name = "tstxtDate_To"
        Me.tstxtDate_To.Size = New System.Drawing.Size(100, 25)
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(26, 22)
        Me.tsbtnGo.Text = "Go"
        '
        'tsReport_Div1
        '
        Me.tsReport_Div1.Name = "tsReport_Div1"
        Me.tsReport_Div1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnExport
        '
        Me.tsbtnExport.Image = CType(resources.GetObject("tsbtnExport.Image"), System.Drawing.Image)
        Me.tsbtnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExport.Name = "tsbtnExport"
        Me.tsbtnExport.Size = New System.Drawing.Size(60, 22)
        Me.tsbtnExport.Text = "Export"
        '
        'gbPendingSubmission
        '
        Me.gbPendingSubmission.Controls.Add(Me.btnCancel)
        Me.gbPendingSubmission.Controls.Add(Me.btnSubmit)
        Me.gbPendingSubmission.Controls.Add(Me.dgvPendingSubmission)
        Me.gbPendingSubmission.Location = New System.Drawing.Point(12, 29)
        Me.gbPendingSubmission.Name = "gbPendingSubmission"
        Me.gbPendingSubmission.Size = New System.Drawing.Size(1047, 255)
        Me.gbPendingSubmission.TabIndex = 11
        Me.gbPendingSubmission.TabStop = False
        Me.gbPendingSubmission.Text = "Pending Submission"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(523, 215)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 50
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(431, 215)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 49
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'dgvPendingSubmission
        '
        Me.dgvPendingSubmission.AllowUserToAddRows = False
        Me.dgvPendingSubmission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendingSubmission.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check})
        Me.dgvPendingSubmission.Location = New System.Drawing.Point(6, 19)
        Me.dgvPendingSubmission.Name = "dgvPendingSubmission"
        Me.dgvPendingSubmission.Size = New System.Drawing.Size(1029, 185)
        Me.dgvPendingSubmission.TabIndex = 48
        '
        'Check
        '
        Me.Check.HeaderText = "Tick"
        Me.Check.Name = "Check"
        '
        'gbPendingPost
        '
        Me.gbPendingPost.Controls.Add(Me.dgvPendingPost)
        Me.gbPendingPost.Location = New System.Drawing.Point(12, 291)
        Me.gbPendingPost.Name = "gbPendingPost"
        Me.gbPendingPost.Size = New System.Drawing.Size(1047, 176)
        Me.gbPendingPost.TabIndex = 12
        Me.gbPendingPost.TabStop = False
        Me.gbPendingPost.Text = "Submitted - Pending Post"
        '
        'dgvPendingPost
        '
        Me.dgvPendingPost.AllowUserToAddRows = False
        Me.dgvPendingPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendingPost.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PostedDate, Me.Remarks, Me.Action, Me.Print})
        Me.dgvPendingPost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingPost.Location = New System.Drawing.Point(3, 16)
        Me.dgvPendingPost.Name = "dgvPendingPost"
        Me.dgvPendingPost.Size = New System.Drawing.Size(1041, 157)
        Me.dgvPendingPost.TabIndex = 0
        '
        'gbPostedClaims
        '
        Me.gbPostedClaims.Controls.Add(Me.dgvPostedDetails)
        Me.gbPostedClaims.Location = New System.Drawing.Point(18, 482)
        Me.gbPostedClaims.Name = "gbPostedClaims"
        Me.gbPostedClaims.Size = New System.Drawing.Size(1041, 197)
        Me.gbPostedClaims.TabIndex = 13
        Me.gbPostedClaims.TabStop = False
        Me.gbPostedClaims.Text = "Posted Details"
        '
        'dgvPostedDetails
        '
        Me.dgvPostedDetails.AllowUserToAddRows = False
        Me.dgvPostedDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPostedDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPostedDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvPostedDetails.Name = "dgvPostedDetails"
        Me.dgvPostedDetails.Size = New System.Drawing.Size(1035, 178)
        Me.dgvPostedDetails.TabIndex = 0
        '
        'PostedDate
        '
        Me.PostedDate.HeaderText = "Posted Date"
        Me.PostedDate.Name = "PostedDate"
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.Name = "Action"
        Me.Action.Text = "Submit"
        Me.Action.ToolTipText = "Submit"
        Me.Action.UseColumnTextForLinkValue = True
        '
        'Print
        '
        Me.Print.HeaderText = "Print"
        Me.Print.Name = "Print"
        Me.Print.Text = "Print"
        Me.Print.ToolTipText = "Print"
        Me.Print.UseColumnTextForLinkValue = True
        '
        'fClientRequestSubmission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 691)
        Me.Controls.Add(Me.gbPostedClaims)
        Me.Controls.Add(Me.gbPendingPost)
        Me.Controls.Add(Me.gbPendingSubmission)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "fClientRequestSubmission"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client Request Submission"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        Me.gbPendingSubmission.ResumeLayout(False)
        CType(Me.dgvPendingSubmission, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPendingPost.ResumeLayout(False)
        CType(Me.dgvPendingPost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPostedClaims.ResumeLayout(False)
        CType(Me.dgvPostedDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents tslblDate_From As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDate_From As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsReport_lblDate_To As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtDate_To As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReport_Div1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbPendingSubmission As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents dgvPendingSubmission As System.Windows.Forms.DataGridView
    Friend WithEvents Check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents gbPendingPost As System.Windows.Forms.GroupBox
    Friend WithEvents gbPostedClaims As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPendingPost As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPostedDetails As System.Windows.Forms.DataGridView
    Friend WithEvents PostedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Action As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Print As System.Windows.Forms.DataGridViewLinkColumn
End Class
