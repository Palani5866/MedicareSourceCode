<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fNonPaymentnShortFall
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fNonPaymentnShortFall))
        Me.tsReport = New System.Windows.Forms.ToolStrip
        Me.tsbtnXport2Xcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tslblRecordCounter = New System.Windows.Forms.ToolStripLabel
        Me.dgvNPnSF = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FULLNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DOB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLANCODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLANTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SDATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STATUS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FILENO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PHOUSE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POFFICE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PMOBILE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TOTNONP = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTSHORTAMT = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTSHORTNOTREQUESTED = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTREQUESTED = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTRECOVERED = New System.Windows.Forms.DataGridViewLinkColumn
        Me.TOTBAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TOTALAMOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Action = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.AssignTo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.aAction = New System.Windows.Forms.DataGridViewLinkColumn
        Me.tsReport.SuspendLayout()
        CType(Me.dgvNPnSF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsReport
        '
        Me.tsReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnXport2Xcel, Me.ToolStripSeparator1, Me.tslblRecordCounter})
        Me.tsReport.Location = New System.Drawing.Point(0, 0)
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(1226, 25)
        Me.tsReport.TabIndex = 4
        Me.tsReport.Text = "ToolStrip"
        '
        'tsbtnXport2Xcel
        '
        Me.tsbtnXport2Xcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnXport2Xcel.Image = CType(resources.GetObject("tsbtnXport2Xcel.Image"), System.Drawing.Image)
        Me.tsbtnXport2Xcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnXport2Xcel.Name = "tsbtnXport2Xcel"
        Me.tsbtnXport2Xcel.Size = New System.Drawing.Size(87, 22)
        Me.tsbtnXport2Xcel.Text = "Export to Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tslblRecordCounter
        '
        Me.tslblRecordCounter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.tslblRecordCounter.Name = "tslblRecordCounter"
        Me.tslblRecordCounter.Size = New System.Drawing.Size(82, 22)
        Me.tslblRecordCounter.Text = "Total Records :"
        '
        'dgvNPnSF
        '
        Me.dgvNPnSF.AllowUserToAddRows = False
        Me.dgvNPnSF.AllowUserToDeleteRows = False
        Me.dgvNPnSF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNPnSF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.IC, Me.FULLNAME, Me.DOB, Me.PLANCODE, Me.PLANTYPE, Me.SDATE, Me.STATUS, Me.FILENO, Me.PHOUSE, Me.POFFICE, Me.PMOBILE, Me.EMAIL, Me.TOTNONP, Me.TOTSHORTAMT, Me.TOTSHORTNOTREQUESTED, Me.TOTREQUESTED, Me.TOTRECOVERED, Me.TOTBAL, Me.TOTALAMOUNT, Me.Action, Me.AssignTo, Me.aAction})
        Me.dgvNPnSF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNPnSF.Location = New System.Drawing.Point(0, 25)
        Me.dgvNPnSF.Name = "dgvNPnSF"
        Me.dgvNPnSF.Size = New System.Drawing.Size(1226, 478)
        Me.dgvNPnSF.TabIndex = 5
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'IC
        '
        Me.IC.DataPropertyName = "IC"
        Me.IC.HeaderText = "IC"
        Me.IC.Name = "IC"
        '
        'FULLNAME
        '
        Me.FULLNAME.DataPropertyName = "FULLNAME"
        Me.FULLNAME.HeaderText = "FULL NAME"
        Me.FULLNAME.Name = "FULLNAME"
        '
        'DOB
        '
        Me.DOB.DataPropertyName = "DOB"
        Me.DOB.HeaderText = "DOB"
        Me.DOB.Name = "DOB"
        '
        'PLANCODE
        '
        Me.PLANCODE.DataPropertyName = "PLANCODE"
        Me.PLANCODE.HeaderText = "PLANCODE"
        Me.PLANCODE.Name = "PLANCODE"
        '
        'PLANTYPE
        '
        Me.PLANTYPE.DataPropertyName = "PLANTYPE"
        Me.PLANTYPE.HeaderText = "PLANTYPE"
        Me.PLANTYPE.Name = "PLANTYPE"
        '
        'SDATE
        '
        Me.SDATE.DataPropertyName = "SDATE"
        Me.SDATE.HeaderText = "START DATE"
        Me.SDATE.Name = "SDATE"
        '
        'STATUS
        '
        Me.STATUS.DataPropertyName = "PSTATUS"
        Me.STATUS.HeaderText = "STATUS"
        Me.STATUS.Name = "STATUS"
        '
        'FILENO
        '
        Me.FILENO.DataPropertyName = "FILENO"
        Me.FILENO.HeaderText = "FILE NO"
        Me.FILENO.Name = "FILENO"
        '
        'PHOUSE
        '
        Me.PHOUSE.DataPropertyName = "PHOUSE"
        Me.PHOUSE.HeaderText = "PHONE HOUSE"
        Me.PHOUSE.Name = "PHOUSE"
        '
        'POFFICE
        '
        Me.POFFICE.DataPropertyName = "POFFICE"
        Me.POFFICE.HeaderText = "PHONE OFFICE"
        Me.POFFICE.Name = "POFFICE"
        '
        'PMOBILE
        '
        Me.PMOBILE.DataPropertyName = "PMOBILE"
        Me.PMOBILE.HeaderText = "PHONE MOBILE"
        Me.PMOBILE.Name = "PMOBILE"
        '
        'EMAIL
        '
        Me.EMAIL.DataPropertyName = "EMAIL"
        Me.EMAIL.HeaderText = "EMAIL"
        Me.EMAIL.Name = "EMAIL"
        '
        'TOTNONP
        '
        Me.TOTNONP.DataPropertyName = "TOTNONP"
        Me.TOTNONP.HeaderText = "TOTAL NON PAYMENT"
        Me.TOTNONP.Name = "TOTNONP"
        '
        'TOTSHORTAMT
        '
        Me.TOTSHORTAMT.DataPropertyName = "TOTSHORTAMT"
        Me.TOTSHORTAMT.HeaderText = "TOTAL SHORT"
        Me.TOTSHORTAMT.Name = "TOTSHORTAMT"
        '
        'TOTSHORTNOTREQUESTED
        '
        Me.TOTSHORTNOTREQUESTED.DataPropertyName = "TOTSHORTNOTREQUESTED"
        Me.TOTSHORTNOTREQUESTED.HeaderText = "TOTAL SHORT NOT REQUESTED"
        Me.TOTSHORTNOTREQUESTED.Name = "TOTSHORTNOTREQUESTED"
        '
        'TOTREQUESTED
        '
        Me.TOTREQUESTED.DataPropertyName = "TOTREQUESTED"
        Me.TOTREQUESTED.HeaderText = "TOTAL REQUESTED"
        Me.TOTREQUESTED.Name = "TOTREQUESTED"
        '
        'TOTRECOVERED
        '
        Me.TOTRECOVERED.DataPropertyName = "TOTRECOVERED"
        Me.TOTRECOVERED.HeaderText = "TOTAL RECOVERED"
        Me.TOTRECOVERED.Name = "TOTRECOVERED"
        '
        'TOTBAL
        '
        Me.TOTBAL.DataPropertyName = "TOTBAL"
        Me.TOTBAL.HeaderText = "TOTAL BALANCE"
        Me.TOTBAL.Name = "TOTBAL"
        '
        'TOTALAMOUNT
        '
        Me.TOTALAMOUNT.DataPropertyName = "TOTALAMOUNT"
        Me.TOTALAMOUNT.HeaderText = "TOTAL CREDIT AMOUNT"
        Me.TOTALAMOUNT.Name = "TOTALAMOUNT"
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.Items.AddRange(New Object() {"PREMIUM REQUEST", "CANCEL POLICY", "CONTACT POLICY HOLDER"})
        Me.Action.Name = "Action"
        '
        'AssignTo
        '
        Me.AssignTo.HeaderText = "Assign To"
        Me.AssignTo.Items.AddRange(New Object() {"ATIKAH", "FARAH", "FATIN", "HAZLINA", "JAIMEH", "MALAR", "MANJU", "MDNOOR", "MONICA", "NORFALAH", "SHILA", "VENI", "ZULIA"})
        Me.AssignTo.Name = "AssignTo"
        '
        'aAction
        '
        Me.aAction.HeaderText = "Action"
        Me.aAction.Name = "aAction"
        Me.aAction.Text = "Submit"
        Me.aAction.ToolTipText = "Submit"
        Me.aAction.UseColumnTextForLinkValue = True
        '
        'fNonPaymentnShortFall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1226, 503)
        Me.Controls.Add(Me.dgvNPnSF)
        Me.Controls.Add(Me.tsReport)
        Me.Name = "fNonPaymentnShortFall"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Non Payment and Shortfall"
        Me.tsReport.ResumeLayout(False)
        Me.tsReport.PerformLayout()
        CType(Me.dgvNPnSF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsReport As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslblRecordCounter As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dgvNPnSF As System.Windows.Forms.DataGridView
    Friend WithEvents tsbtnXport2Xcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FULLNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLANCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLANTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATUS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FILENO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PHOUSE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POFFICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PMOBILE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTNONP As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTSHORTAMT As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTSHORTNOTREQUESTED As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTREQUESTED As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTRECOVERED As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents TOTBAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTALAMOUNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Action As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents AssignTo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents aAction As System.Windows.Forms.DataGridViewLinkColumn
End Class
