<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fUpDocs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fUpDocs))
        Me.tolForm = New System.Windows.Forms.ToolStrip
        Me.tsb_Filter = New System.Windows.Forms.ToolStripComboBox
        Me.tsb_Filter_Param = New System.Windows.Forms.ToolStripTextBox
        Me.tsb_Filter_Go = New System.Windows.Forms.ToolStripButton
        Me.gbPHDetails = New System.Windows.Forms.GroupBox
        Me.dgvPHDetails = New System.Windows.Forms.DataGridView
        Me.gbPolicyDetails = New System.Windows.Forms.GroupBox
        Me.dgvPolicyDetails = New System.Windows.Forms.DataGridView
        Me.gbUploadDoc = New System.Windows.Forms.GroupBox
        Me.gbUploadDocList = New System.Windows.Forms.GroupBox
        Me.dgvDocList = New System.Windows.Forms.DataGridView
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnUpload = New System.Windows.Forms.Button
        Me.txtBrowse = New System.Windows.Forms.TextBox
        Me.txtDocName = New System.Windows.Forms.TextBox
        Me.lblDoc = New System.Windows.Forms.Label
        Me.lblDocName1 = New System.Windows.Forms.Label
        Me.lblDoc1 = New System.Windows.Forms.Label
        Me.lblDocName = New System.Windows.Forms.Label
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.lblPHPID = New System.Windows.Forms.Label
        Me.tolForm.SuspendLayout()
        Me.gbPHDetails.SuspendLayout()
        CType(Me.dgvPHDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPolicyDetails.SuspendLayout()
        CType(Me.dgvPolicyDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbUploadDoc.SuspendLayout()
        Me.gbUploadDocList.SuspendLayout()
        CType(Me.dgvDocList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tolForm
        '
        Me.tolForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Filter, Me.tsb_Filter_Param, Me.tsb_Filter_Go})
        Me.tolForm.Location = New System.Drawing.Point(0, 0)
        Me.tolForm.Name = "tolForm"
        Me.tolForm.Size = New System.Drawing.Size(871, 25)
        Me.tolForm.TabIndex = 1
        Me.tolForm.Text = "ToolStrip1"
        '
        'tsb_Filter
        '
        Me.tsb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tsb_Filter.Items.AddRange(New Object() {"", "IC", "Full Name"})
        Me.tsb_Filter.Name = "tsb_Filter"
        Me.tsb_Filter.Size = New System.Drawing.Size(100, 25)
        '
        'tsb_Filter_Param
        '
        Me.tsb_Filter_Param.MaxLength = 50
        Me.tsb_Filter_Param.Name = "tsb_Filter_Param"
        Me.tsb_Filter_Param.Size = New System.Drawing.Size(250, 25)
        '
        'tsb_Filter_Go
        '
        Me.tsb_Filter_Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Filter_Go.Image = CType(resources.GetObject("tsb_Filter_Go.Image"), System.Drawing.Image)
        Me.tsb_Filter_Go.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Filter_Go.Name = "tsb_Filter_Go"
        Me.tsb_Filter_Go.Size = New System.Drawing.Size(34, 22)
        Me.tsb_Filter_Go.Text = "GO.."
        Me.tsb_Filter_Go.ToolTipText = "Go"
        '
        'gbPHDetails
        '
        Me.gbPHDetails.Controls.Add(Me.dgvPHDetails)
        Me.gbPHDetails.Location = New System.Drawing.Point(0, 37)
        Me.gbPHDetails.Name = "gbPHDetails"
        Me.gbPHDetails.Size = New System.Drawing.Size(871, 121)
        Me.gbPHDetails.TabIndex = 2
        Me.gbPHDetails.TabStop = False
        Me.gbPHDetails.Text = "Policy Holder Details"
        '
        'dgvPHDetails
        '
        Me.dgvPHDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPHDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPHDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvPHDetails.Name = "dgvPHDetails"
        Me.dgvPHDetails.Size = New System.Drawing.Size(865, 102)
        Me.dgvPHDetails.TabIndex = 0
        '
        'gbPolicyDetails
        '
        Me.gbPolicyDetails.Controls.Add(Me.dgvPolicyDetails)
        Me.gbPolicyDetails.Location = New System.Drawing.Point(0, 159)
        Me.gbPolicyDetails.Name = "gbPolicyDetails"
        Me.gbPolicyDetails.Size = New System.Drawing.Size(871, 121)
        Me.gbPolicyDetails.TabIndex = 3
        Me.gbPolicyDetails.TabStop = False
        Me.gbPolicyDetails.Text = "Policy Details"
        '
        'dgvPolicyDetails
        '
        Me.dgvPolicyDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPolicyDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPolicyDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvPolicyDetails.Name = "dgvPolicyDetails"
        Me.dgvPolicyDetails.Size = New System.Drawing.Size(865, 102)
        Me.dgvPolicyDetails.TabIndex = 1
        '
        'gbUploadDoc
        '
        Me.gbUploadDoc.Controls.Add(Me.lblPHPID)
        Me.gbUploadDoc.Controls.Add(Me.gbUploadDocList)
        Me.gbUploadDoc.Controls.Add(Me.btnClear)
        Me.gbUploadDoc.Controls.Add(Me.btnUpload)
        Me.gbUploadDoc.Controls.Add(Me.txtBrowse)
        Me.gbUploadDoc.Controls.Add(Me.txtDocName)
        Me.gbUploadDoc.Controls.Add(Me.lblDoc)
        Me.gbUploadDoc.Controls.Add(Me.lblDocName1)
        Me.gbUploadDoc.Controls.Add(Me.lblDoc1)
        Me.gbUploadDoc.Controls.Add(Me.lblDocName)
        Me.gbUploadDoc.Controls.Add(Me.btnBrowse)
        Me.gbUploadDoc.Location = New System.Drawing.Point(8, 286)
        Me.gbUploadDoc.Name = "gbUploadDoc"
        Me.gbUploadDoc.Size = New System.Drawing.Size(863, 230)
        Me.gbUploadDoc.TabIndex = 4
        Me.gbUploadDoc.TabStop = False
        Me.gbUploadDoc.Text = "Upload Documents"
        '
        'gbUploadDocList
        '
        Me.gbUploadDocList.Controls.Add(Me.dgvDocList)
        Me.gbUploadDocList.Location = New System.Drawing.Point(6, 105)
        Me.gbUploadDocList.Name = "gbUploadDocList"
        Me.gbUploadDocList.Size = New System.Drawing.Size(854, 119)
        Me.gbUploadDocList.TabIndex = 18
        Me.gbUploadDocList.TabStop = False
        Me.gbUploadDocList.Text = "Uploaded Document List"
        '
        'dgvDocList
        '
        Me.dgvDocList.AllowUserToAddRows = False
        Me.dgvDocList.AllowUserToDeleteRows = False
        Me.dgvDocList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDocList.Location = New System.Drawing.Point(3, 16)
        Me.dgvDocList.Name = "dgvDocList"
        Me.dgvDocList.ReadOnly = True
        Me.dgvDocList.Size = New System.Drawing.Size(848, 100)
        Me.dgvDocList.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(441, 76)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(66, 23)
        Me.btnClear.TabIndex = 17
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(349, 76)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(66, 23)
        Me.btnUpload.TabIndex = 16
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'txtBrowse
        '
        Me.txtBrowse.Location = New System.Drawing.Point(305, 20)
        Me.txtBrowse.Name = "txtBrowse"
        Me.txtBrowse.ReadOnly = True
        Me.txtBrowse.Size = New System.Drawing.Size(319, 20)
        Me.txtBrowse.TabIndex = 11
        '
        'txtDocName
        '
        Me.txtDocName.Location = New System.Drawing.Point(305, 46)
        Me.txtDocName.Name = "txtDocName"
        Me.txtDocName.Size = New System.Drawing.Size(319, 20)
        Me.txtDocName.TabIndex = 15
        '
        'lblDoc
        '
        Me.lblDoc.AutoSize = True
        Me.lblDoc.Location = New System.Drawing.Point(167, 23)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(56, 13)
        Me.lblDoc.TabIndex = 9
        Me.lblDoc.Text = "Document"
        '
        'lblDocName1
        '
        Me.lblDocName1.AutoSize = True
        Me.lblDocName1.Location = New System.Drawing.Point(272, 49)
        Me.lblDocName1.Name = "lblDocName1"
        Me.lblDocName1.Size = New System.Drawing.Size(10, 13)
        Me.lblDocName1.TabIndex = 14
        Me.lblDocName1.Text = ":"
        '
        'lblDoc1
        '
        Me.lblDoc1.AutoSize = True
        Me.lblDoc1.Location = New System.Drawing.Point(272, 23)
        Me.lblDoc1.Name = "lblDoc1"
        Me.lblDoc1.Size = New System.Drawing.Size(10, 13)
        Me.lblDoc1.TabIndex = 10
        Me.lblDoc1.Text = ":"
        '
        'lblDocName
        '
        Me.lblDocName.AutoSize = True
        Me.lblDocName.Location = New System.Drawing.Point(167, 49)
        Me.lblDocName.Name = "lblDocName"
        Me.lblDocName.Size = New System.Drawing.Size(87, 13)
        Me.lblDocName.TabIndex = 13
        Me.lblDocName.Text = "Document Name"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(630, 18)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(66, 23)
        Me.btnBrowse.TabIndex = 12
        Me.btnBrowse.Text = "Browse.."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblPHPID
        '
        Me.lblPHPID.AutoSize = True
        Me.lblPHPID.Location = New System.Drawing.Point(773, 52)
        Me.lblPHPID.Name = "lblPHPID"
        Me.lblPHPID.Size = New System.Drawing.Size(40, 13)
        Me.lblPHPID.TabIndex = 19
        Me.lblPHPID.Text = "PHPID"
        Me.lblPHPID.Visible = False
        '
        'fUpDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 515)
        Me.Controls.Add(Me.gbUploadDoc)
        Me.Controls.Add(Me.gbPolicyDetails)
        Me.Controls.Add(Me.gbPHDetails)
        Me.Controls.Add(Me.tolForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fUpDocs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload Documents"
        Me.tolForm.ResumeLayout(False)
        Me.tolForm.PerformLayout()
        Me.gbPHDetails.ResumeLayout(False)
        CType(Me.dgvPHDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPolicyDetails.ResumeLayout(False)
        CType(Me.dgvPolicyDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbUploadDoc.ResumeLayout(False)
        Me.gbUploadDoc.PerformLayout()
        Me.gbUploadDocList.ResumeLayout(False)
        CType(Me.dgvDocList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tolForm As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Filter As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsb_Filter_Param As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsb_Filter_Go As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbPHDetails As System.Windows.Forms.GroupBox
    Friend WithEvents gbPolicyDetails As System.Windows.Forms.GroupBox
    Friend WithEvents gbUploadDoc As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPHDetails As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPolicyDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents txtBrowse As System.Windows.Forms.TextBox
    Friend WithEvents txtDocName As System.Windows.Forms.TextBox
    Friend WithEvents lblDoc As System.Windows.Forms.Label
    Friend WithEvents lblDocName1 As System.Windows.Forms.Label
    Friend WithEvents lblDoc1 As System.Windows.Forms.Label
    Friend WithEvents lblDocName As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents gbUploadDocList As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDocList As System.Windows.Forms.DataGridView
    Friend WithEvents lblPHPID As System.Windows.Forms.Label
End Class
