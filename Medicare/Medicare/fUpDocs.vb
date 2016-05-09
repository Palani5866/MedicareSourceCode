Imports System.IO
Public Class fUpDocs
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim rCount As Integer

    Private Sub fUpDocs_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fUpDocs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.gbUploadDoc.Enabled = False
    End Sub
    Private Sub BINDDATA(ByVal P1 As String, ByVal P2 As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails_IX("UPLOADDOCS", P1, P2, "", "", "", "", "", "", "", "PHD", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvPHDetails
                .DataSource = dt
                .Columns(0).Visible = False
            End With
        Else
            MsgBox("No record found!")
            Me.dgvPHDetails.DataSource = dt
        End If
    End Sub

#Region "DOCUMENTS UPLOAD"
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
            If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                Me.txtBrowse.Text = OpenFileDialog.FileName
            Else
                MsgBox("File Requied")
                Exit Sub
            End If
        End Using
    End Sub
    Private Function GetOpenFileDialog() As OpenFileDialog
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.CheckPathExists = True
        openFileDialog.CheckFileExists = True
        openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|xls files (*.xls)|*.xls|jpg files (*.jpg)|*.jpg|doc files (*.doc)|*.doc|text files (*.text)|*.txt"
        openFileDialog.Multiselect = False
        openFileDialog.AddExtension = True
        openFileDialog.ValidateNames = True
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Return openFileDialog
    End Function
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim sFileToUpload As String = ""
        sFileToUpload = LTrim(RTrim(Me.txtBrowse.Text.Trim()))
        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
        If upLoadImageOrFile(sFileToUpload, Extension) Then
            Me.txtBrowse.Text = ""
            Me.txtDocName.Text = ""
        End If
    End Sub
    Private Function upLoadImageOrFile(ByVal sFilePath As String, ByVal sFileType As String) As Boolean
        Dim FileData As Byte()
        Dim sFileName As String
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            FileData = ReadFile(sFilePath)
            sFileName = System.IO.Path.GetFileName(sFilePath)
            
            If chkUpFName(sFileName, Me.lblPHPID.Text.ToString.Trim()) = False Then
                MsgBox("This Document already exists!Please check it")
                Return False
            End If
            Dim ext As String = sFileType
            Dim contenttype As String = String.Empty
            Select Case ext
                Case ".doc"
                    contenttype = "application/vnd.ms-word"
                    Exit Select
                Case ".docx"
                    contenttype = "application/vnd.ms-word"
                    Exit Select
                Case ".xls"
                    contenttype = "application/vnd.ms-excel"
                    Exit Select
                Case ".xlsx"
                    contenttype = "application/vnd.ms-excel"
                    Exit Select
                Case ".jpg"
                    contenttype = "image/jpg"
                    Exit Select
                Case ".png"
                    contenttype = "image/png"
                    Exit Select
                Case ".gif"
                    contenttype = "image/gif"
                    Exit Select
                Case ".pdf"
                    contenttype = "application/pdf"
                    Exit Select
            End Select
            _objBusi.fIUDocumentCheckList("INS", Guid.NewGuid.ToString(), Guid.NewGuid.ToString(), Me.lblPHPID.Text.ToString.Trim(), "MEMBER", "", contenttype, sFileType, sFileName, DirectCast(FileData, Object), Me.txtDocName.Text.ToString.Trim(), My.Settings.Username.ToString.Trim(), Conn)
            GetDocuments()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function ReadFile(ByVal sPath As String) As Byte()
        Dim data As Byte() = Nothing
        Dim fInfo As New FileInfo(sPath)
        Dim numBytes As Long = fInfo.Length
        Dim fStream As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fStream)
        data = br.ReadBytes(CInt(numBytes))
        Return data
    End Function
    Private Function chkUpFName(ByVal fname As String, ByVal PID As String) As Boolean
        Dim dt As New DataTable
        dt = _objBusi.Check("DOCCHKLIST", fname, PID, "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Private Sub GetDocuments()
        Try

            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Dim strSql As String = "Select Id, Doc_Name, Doc_Type, Doc_ext, created_on, DOCUMENT_NAME from dt_documents_checklist where MEMBER_POLICY_ID='" & Me.lblPHPID.Text.ToString.Trim() & "'"

            Dim ADAP As New SqlDataAdapter(strSql, Conn)

            Dim DS As New DataSet()

            ADAP.Fill(DS, "dt_documents_checklist")

            If DS.Tables(0).Rows.Count > 0 Then
                Me.dgvDocList.DataSource = DS.Tables("dt_documents_checklist")
                Dim dgButtonColumn As New DataGridViewButtonColumn
                dgButtonColumn.HeaderText = "View / Download"
                dgButtonColumn.UseColumnTextForButtonValue = True
                dgButtonColumn.Text = "View File"
                dgButtonColumn.Name = "ViewFile"
                dgButtonColumn.ToolTipText = "View File"
                dgButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                dgButtonColumn.FlatStyle = FlatStyle.System
                dgButtonColumn.DefaultCellStyle.BackColor = Color.Gray
                dgButtonColumn.DefaultCellStyle.ForeColor = Color.White

                Dim dgBtnDelete As New DataGridViewButtonColumn
                dgBtnDelete.HeaderText = "Delete"
                dgBtnDelete.UseColumnTextForButtonValue = True
                dgBtnDelete.Text = "Delete"
                dgBtnDelete.Name = "Delete"
                dgBtnDelete.ToolTipText = "Delete"
                dgBtnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                dgBtnDelete.FlatStyle = FlatStyle.System
                dgBtnDelete.DefaultCellStyle.BackColor = Color.Gray
                dgBtnDelete.DefaultCellStyle.ForeColor = Color.Red

                Dim RowCount As Integer
                For RowCount = 0 To Me.dgvDocList.Rows.Count - 1
                    If rCount = 0 Then
                        Me.dgvDocList.Columns(0).Visible = False
                        Me.dgvDocList.Columns(3).Visible = False
                        Me.dgvDocList.Columns(4).Visible = False
                        Me.dgvDocList.Columns.Add(dgButtonColumn)
                        Me.dgvDocList.Columns.Add(dgBtnDelete)
                    End If
                    rCount += 1
                Next
            Else
                Me.dgvDocList.DataSource = DS.Tables("dt_documents_checklist")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            MessageBox.Show("Could not load the Image")
        End Try

    End Sub
    Private Sub dgvDetails_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocList.CellContentClick
        Try
            Select Case e.ColumnIndex
                Case Is > -1
                    If sender.Columns(e.ColumnIndex).Name = "ViewFile" Then
                        Select Case dgvDocList.Rows(e.RowIndex).Cells("Doc_Ext").Value
                            Case ".txt", ".pdf", ".doc"
                                downLoadFile(dgvDocList.Rows(e.RowIndex).Cells("Id").Value.ToString(), dgvDocList.Rows(e.RowIndex).Cells("Doc_Name").Value, dgvDocList.Rows(e.RowIndex).Cells("Doc_Type").Value)
                        End Select
                    ElseIf sender.Columns(e.ColumnIndex).Name = "Delete" Then
                        If MsgBox("Do you want Delete? ", vbYesNo, "Document") = vbYes Then
                            Dim sRes As String
                            sRes = _objBusi.Delete("DOCCHKLIST", dgvDocList.Rows(e.RowIndex).Cells("Id").Value.ToString(), "", "", "", "", "", "", "", "", "", Conn)
                            GetDocuments()
                            MsgBox("Document deleted sucessfully")
                        End If
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub downLoadFile(ByVal iFileId As String, ByVal sFileName As String, ByVal sFileExtension As String)
        Try
            Dim strSql As String
            strSql = "Select Doc_Data from dt_documents_checklist WHERE Id='" & iFileId & "'"
            Dim sqlCmd As New SqlCommand(strSql, Conn)
            Dim dbbyte As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())
            Dim filepath As String = Application.StartupPath & "\Report\Letters\" & sFileName
            Dim FS As FileStream
            FS = New FileStream(filepath, System.IO.FileMode.Create)
            FS.Write(dbbyte, 0, dbbyte.Length)
            FS.Close()
            Dim Proc As Process
            Proc = New Process()
            Proc.StartInfo.FileName = filepath
            Proc.Start()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtBrowse.Text = ""
        Me.txtDocName.Text = ""
    End Sub
#End Region

    Private Sub tsb_Filter_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Filter_Go.Click
        Me.lblPHPID.Text = "PHPID"
        Select Case Me.tsb_Filter.SelectedItem
            Case "IC"
                If Len(Me.tsb_Filter_Param.Text.Trim) > 0 Then
                    Me.BINDDATA("IC", Me.tsb_Filter_Param.Text.Trim)
                End If
            Case "Full Name"
                If Len(Me.tsb_Filter_Param.Text.Trim) > 0 Then
                    Me.BINDDATA("FULLNAME", Me.tsb_Filter_Param.Text.Trim)
                End If
            Case Else
                Me.BINDDATA("Null", "")
        End Select
    End Sub
    Private Sub dgvPHDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPHDetails.CellDoubleClick
        With Me.dgvPHDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Dim dt As New DataTable
            dt = _objBusi.getDetails_IX("UPLOADDOCS", .CurrentRow.Cells(0).Value.ToString, "", "", "", "", "", "", "", "", "PHPD", Conn)
            If dt.Rows.Count > 0 Then
                With Me.dgvPolicyDetails
                    .DataSource = dt
                    .Columns(0).Visible = False
                End With
            Else
                MsgBox("No record found")
                Me.dgvPolicyDetails.DataSource = dt
            End If
        End With
    End Sub
    Private Sub dgvPolicyDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPolicyDetails.CellDoubleClick
        With Me.dgvPolicyDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            If Not IsDBNull(.CurrentRow.Cells(0).Value) Then
                Me.lblPHPID.Text = .CurrentRow.Cells(0).Value.ToString.Trim()
                GetDocuments()
                Me.gbUploadDoc.Enabled = True
            Else
                Me.gbUploadDoc.Enabled = False
            End If
        End With
    End Sub

End Class