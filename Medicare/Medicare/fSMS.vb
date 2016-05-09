Imports System.IO
Public Class fSMS
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim sType As String
    Private Sub fSMS_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fSMS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDCB()
        BINDDATA()
    End Sub
    Private Sub BINDCB()
        Dim dt As New DataTable
        dt = _objBusi.fSMS("SMS", "", "", "", "", "", "", "", Me.lblRF1.Text.Trim(), "BATCHNO", "DETAILS", Conn)
        If dt.Rows.Count > 0 Then
            Me.tsddlBatchNo.ComboBox.DataSource = dt
            Me.tsddlBatchNo.ComboBox.DisplayMember = "sms_batch_no"
            Me.tsddlBatchNo.ComboBox.ValueMember = "sms_batch_no"
        End If
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        If sType = "SEARCH" Then
            If Not Len(Me.tsddlBatchNo.Text.Trim()) > 0 Then
                MsgBox("Please do select the batch no!")
                Me.tsddlBatchNo.Focus()
                Exit Sub
            End If
            dt = _objBusi.fSMS("SMS", Me.tsddlBatchNo.Text.Trim(), "", "", "", "", "", "", Me.lblRF1.Text.Trim(), "BATCHNO", "DETAILS", Conn)
        Else
            dt = _objBusi.fSMS("SMS", "", "", "", "", "", "", "", Me.lblRF1.Text.Trim(), "BATCHNO", "DETAILS", Conn)
        End If

        If dt.Rows.Count > 0 Then
            With Me.dgvSMS
                .DataSource = dt
                .Columns(0).DisplayIndex = 3
                .Columns(1).DisplayIndex = 3
                .Columns(2).DisplayIndex = 3
            End With
        End If
    End Sub
    Private Function chkUpFName(ByVal fname As String, ByVal refID As String) As Boolean
        Dim dt As New DataTable
        dt = _objBusi.Check("DOCUMENTS", fname, refID, "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Private Sub dgvSMS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSMS.CellContentClick
        With Me.dgvSMS
            If e.ColumnIndex = 0 Then

                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(3).Value) Then
                    Dim vSMS As New vCS
                    vSMS.lblPID.Text = .Rows(e.RowIndex).Cells(3).Value.ToString().Trim()
                    vSMS.lblType.Text = "SMS"
                    vSMS.Show()
                End If
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(3).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                            BINDDATA()
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            End If
        End With
    End Sub
    Private Function upLoadFile(ByVal sFilePath As String, ByVal sFileType As String, ByVal REFID As String) As Boolean
        Dim SqlCom As SqlCommand
        Dim FileData As Byte()
        Dim sFileName As String
        Dim qry As String
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            FileData = ReadFile(sFilePath)
            sFileName = System.IO.Path.GetFileName(sFilePath)
            If chkUpFName(sFileName, REFID) = False Then
                MsgBox("This Document already exists!Please check it")
                Return False
            End If
            qry = "insert into dt_documents (FileName,FileData," & _
            "FileType,Fileext,RefType, RefID, DocumentName,created_on, created_by) values(@FileName, @FileData," & _
            "@FileType,@FileExt,@RefType, @refID, @DName, @created_on,@created_by )"
            SqlCom = New SqlCommand(qry, Conn)
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
            SqlCom.Parameters.Add(New SqlParameter("@FileName", sFileName))
            SqlCom.Parameters.Add(New SqlParameter("@FileData", DirectCast(FileData, Object)))
            SqlCom.Parameters.Add(New SqlParameter("@FileType", contenttype))
            SqlCom.Parameters.Add(New SqlParameter("@FileExt", sFileType))
            SqlCom.Parameters.Add(New SqlParameter("@RefType", "SMSFILES"))
            SqlCom.Parameters.Add(New SqlParameter("@REFID", REFID))
            SqlCom.Parameters.Add(New SqlParameter("@DName", sFileName.ToUpper()))
            SqlCom.Parameters.Add(New SqlParameter("@created_on", Now()))
            SqlCom.Parameters.Add(New SqlParameter("@created_by", My.Settings.Username))
            SqlCom.ExecuteNonQuery()
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
    Private Function GetOpenFileDialog() As OpenFileDialog
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.CheckPathExists = True
        openFileDialog.CheckFileExists = True
        openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|doc files (*.doc)|*.doc|text files (*.text)|*.txt|xls files (*.xls)|*.xls"
        openFileDialog.Multiselect = False
        openFileDialog.AddExtension = True
        openFileDialog.ValidateNames = True
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Return openFileDialog
    End Function
    Private Sub downLoadFile(ByVal iFileId As String, ByVal sFileName As String, ByVal sFileExtension As String)
        Try
            Dim dt As New DataTable
            dt = _objBusi.fSMS("SMS", iFileId, "", "", "", "", "", "", "", "", "DL", Conn)
            Dim strSql As String
            strSql = "Select FileData from dt_documents WHERE Id=" & dt.Rows(0)("ID").ToString().Trim()
            Dim sqlCmd As New SqlCommand(strSql, Conn)
            Dim dbbyte As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())
            Dim filepath As String = Application.StartupPath & "\Report\Letters\" & dt.Rows(0)("Filename").ToString().Trim()
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
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        sType = "SEARCH"
        BINDDATA()
    End Sub
End Class