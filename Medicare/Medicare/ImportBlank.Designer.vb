<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportBlank
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
        Me.gbUpload = New System.Windows.Forms.GroupBox
        Me.lblNote = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnUpload = New System.Windows.Forms.Button
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.lblSelectFile1 = New System.Windows.Forms.Label
        Me.lblSelectFile = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.lblType = New System.Windows.Forms.Label
        Me.lblUType = New System.Windows.Forms.Label
        Me.gbUpload.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbUpload
        '
        Me.gbUpload.Controls.Add(Me.lblNote)
        Me.gbUpload.Controls.Add(Me.btnCancel)
        Me.gbUpload.Controls.Add(Me.btnUpload)
        Me.gbUpload.Controls.Add(Me.btnBrowse)
        Me.gbUpload.Controls.Add(Me.txtFileName)
        Me.gbUpload.Controls.Add(Me.lblSelectFile1)
        Me.gbUpload.Controls.Add(Me.lblSelectFile)
        Me.gbUpload.Location = New System.Drawing.Point(12, 12)
        Me.gbUpload.Name = "gbUpload"
        Me.gbUpload.Size = New System.Drawing.Size(480, 131)
        Me.gbUpload.TabIndex = 3
        Me.gbUpload.TabStop = False
        Me.gbUpload.Text = "Upload File"
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.ForeColor = System.Drawing.Color.Red
        Me.lblNote.Location = New System.Drawing.Point(258, 13)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(216, 13)
        Me.lblNote.TabIndex = 20
        Me.lblNote.Text = "Note : Sheet name should be Sheet1"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(230, 89)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(126, 23)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(109, 89)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(115, 23)
        Me.btnUpload.TabIndex = 16
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(344, 40)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(53, 20)
        Me.btnBrowse.TabIndex = 13
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtFileName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFileName.Location = New System.Drawing.Point(109, 40)
        Me.txtFileName.MaxLength = 10
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(229, 20)
        Me.txtFileName.TabIndex = 10
        Me.txtFileName.TabStop = False
        '
        'lblSelectFile1
        '
        Me.lblSelectFile1.AutoSize = True
        Me.lblSelectFile1.Location = New System.Drawing.Point(93, 43)
        Me.lblSelectFile1.Name = "lblSelectFile1"
        Me.lblSelectFile1.Size = New System.Drawing.Size(10, 13)
        Me.lblSelectFile1.TabIndex = 2
        Me.lblSelectFile1.Text = ":"
        '
        'lblSelectFile
        '
        Me.lblSelectFile.AutoSize = True
        Me.lblSelectFile.Location = New System.Drawing.Point(15, 43)
        Me.lblSelectFile.Name = "lblSelectFile"
        Me.lblSelectFile.Size = New System.Drawing.Size(56, 13)
        Me.lblSelectFile.TabIndex = 1
        Me.lblSelectFile.Text = "Select File"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(413, 146)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(31, 13)
        Me.lblType.TabIndex = 18
        Me.lblType.Text = "Type"
        Me.lblType.Visible = False
        '
        'lblUType
        '
        Me.lblUType.AutoSize = True
        Me.lblUType.Location = New System.Drawing.Point(363, 146)
        Me.lblUType.Name = "lblUType"
        Me.lblUType.Size = New System.Drawing.Size(39, 13)
        Me.lblUType.TabIndex = 19
        Me.lblUType.Text = "UType"
        Me.lblUType.Visible = False
        '
        'ImportBlank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 159)
        Me.Controls.Add(Me.lblUType)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.gbUpload)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ImportBlank"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ImportBlank"
        Me.gbUpload.ResumeLayout(False)
        Me.gbUpload.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbUpload As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblSelectFile1 As System.Windows.Forms.Label
    Friend WithEvents lblSelectFile As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblUType As System.Windows.Forms.Label
    Friend WithEvents lblNote As System.Windows.Forms.Label
End Class
