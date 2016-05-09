<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fReUpPI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fReUpPI))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tslblSearch = New System.Windows.Forms.ToolStripLabel
        Me.tscbSearchBy = New System.Windows.Forms.ToolStripComboBox
        Me.tstxtSearchBy = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnGo = New System.Windows.Forms.ToolStripButton
        Me.dgvReUpPIPR = New System.Windows.Forms.DataGridView
        Me.Upload = New System.Windows.Forms.DataGridViewLinkColumn
        Me.ViewDoc = New System.Windows.Forms.DataGridViewLinkColumn
        Me.Request = New System.Windows.Forms.DataGridViewLinkColumn
        Me.fViewDoc = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsReport.SuspendLayout()
        CType(Me.dgvReUpPIPR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.tslblSearch, Me.tscbSearchBy, Me.tstxtSearchBy, Me.ToolStripSeparator2, Me.tsbtnGo})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1162, 25)
        Me.tsReport.TabIndex = 4
        Me.tsReport.Text = "ToolStrip"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tslblSearch
        '
        Me.tslblSearch.Name = "tslblSearch"
        Me.tslblSearch.Size = New System.Drawing.Size(64, 22)
        Me.tslblSearch.Text = "Search By :"
        '
        'tscbSearchBy
        '
        Me.tscbSearchBy.Items.AddRange(New Object() {"NRIC", "FULL NAME"})
        Me.tscbSearchBy.Name = "tscbSearchBy"
        Me.tscbSearchBy.Size = New System.Drawing.Size(121, 25)
        '
        'tstxtSearchBy
        '
        Me.tstxtSearchBy.Name = "tstxtSearchBy"
        Me.tstxtSearchBy.Size = New System.Drawing.Size(155, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnGo
        '
        Me.tsbtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnGo.Image = CType(resources.GetObject("tsbtnGo.Image"), System.Drawing.Image)
        Me.tsbtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnGo.Name = "tsbtnGo"
        Me.tsbtnGo.Size = New System.Drawing.Size(32, 22)
        Me.tsbtnGo.Text = "Go.."
        '
        'dgvReUpPIPR
        '
        Me.dgvReUpPIPR.AllowUserToAddRows = False
        Me.dgvReUpPIPR.AllowUserToDeleteRows = False
        Me.dgvReUpPIPR.AllowUserToOrderColumns = True
        Me.dgvReUpPIPR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReUpPIPR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Upload, Me.ViewDoc, Me.Request, Me.fViewDoc})
        Me.dgvReUpPIPR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReUpPIPR.Location = New System.Drawing.Point(0, 25)
        Me.dgvReUpPIPR.Name = "dgvReUpPIPR"
        Me.dgvReUpPIPR.Size = New System.Drawing.Size(1162, 470)
        Me.dgvReUpPIPR.TabIndex = 5
        '
        'Upload
        '
        Me.Upload.HeaderText = "Upload"
        Me.Upload.Name = "Upload"
        Me.Upload.Text = "Upload"
        Me.Upload.ToolTipText = "Upload"
        Me.Upload.UseColumnTextForLinkValue = True
        '
        'ViewDoc
        '
        Me.ViewDoc.HeaderText = "View Doc"
        Me.ViewDoc.Name = "ViewDoc"
        Me.ViewDoc.Text = "View Doc"
        Me.ViewDoc.ToolTipText = "View Doc"
        Me.ViewDoc.UseColumnTextForLinkValue = True
        '
        'Request
        '
        Me.Request.HeaderText = "Upload (Requested Fully)"
        Me.Request.Name = "Request"
        Me.Request.Text = "Upload"
        Me.Request.ToolTipText = "Upload"
        Me.Request.UseColumnTextForLinkValue = True
        '
        'fViewDoc
        '
        Me.fViewDoc.HeaderText = "View Doc (Requested Fully)"
        Me.fViewDoc.Name = "fViewDoc"
        Me.fViewDoc.Text = "View Doc"
        Me.fViewDoc.ToolTipText = "View Doc"
        Me.fViewDoc.UseColumnTextForLinkValue = True
        '
        'fReUpPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1162, 495)
        Me.Controls.Add(Me.dgvReUpPIPR)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "fReUpPI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Re-Upload Premium Increase Requested Documents"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvReUpPIPR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvReUpPIPR As System.Windows.Forms.DataGridView
    Friend WithEvents Upload As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ViewDoc As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Request As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents fViewDoc As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents tslblSearch As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstxtSearchBy As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tscbSearchBy As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnGo As System.Windows.Forms.ToolStripButton
End Class
