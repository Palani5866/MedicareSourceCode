Imports System.IO
Public Class frmShortfallRequest
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Private Sub frmShortfallRequest_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub frmShortfallRequest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        ds = _ObjBusi.getDsDetails_VI("SFR", "", "", "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvSFR
                .DataSource = ds.Tables(0)
                .Columns(0).DisplayIndex = 16
                .Columns(1).DisplayIndex = 16
                .Columns(2).DisplayIndex = 16
                .Columns(3).DisplayIndex = 16
                .Columns(4).DisplayIndex = 16

                .Columns(5).Visible = False
                .Columns(6).Visible = False


                .Columns(14).DefaultCellStyle.Format = "#,##0.00"
                .Columns(15).DefaultCellStyle.Format = "#,##0.00"
                .Columns(16).DefaultCellStyle.Format = "#,##0.00"

                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                Me.tslblTot.Text = "Total Records : " & ds.Tables(0).Rows.Count
            End With
        Else
            Me.dgvSFR.DataSource = ds.Tables(0)
            Me.tslblTot.Text = "Total Records : 0"
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvPendingConfirmation
                .DataSource = ds.Tables(1)
                .Columns(0).DisplayIndex = 13
                .Columns(1).DisplayIndex = 13
                .Columns(2).Visible = False
                .Columns(3).Visible = False

                .Columns(11).DefaultCellStyle.Format = "#,##0.00"
                .Columns(12).DefaultCellStyle.Format = "#,##0.00"
                .Columns(13).DefaultCellStyle.Format = "#,##0.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
        Else
            Me.dgvPendingConfirmation.DataSource = ds.Tables(1)
        End If

        If ds.Tables(2).Rows.Count > 0 Then
            With Me.dgvPendingDecision
                .DataSource = ds.Tables(2)
                .Columns(0).Visible = False
                .Columns(1).Visible = False

                .Columns(9).DefaultCellStyle.Format = "#,##0.00"
                .Columns(10).DefaultCellStyle.Format = "#,##0.00"
                .Columns(11).DefaultCellStyle.Format = "#,##0.00"

                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
        Else
            Me.dgvPendingDecision.DataSource = ds.Tables(2)
        End If
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
            qry = "UPDATE dt_Shortfall_Account SET DOC_NAME=@DOC_NAME,DOC_DATA=@DOC_DATA, DOC_TYPE=@DOC_TYPE,DOC_EXT=@DOC_EXT, UPLOADED_BY=@BY, UPLOADED_ON=GETDATE()WHERE ID=@ID"

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
            SqlCom.Parameters.Add(New SqlParameter("@DOC_NAME", sFileName))
            SqlCom.Parameters.Add(New SqlParameter("@DOC_DATA", DirectCast(FileData, Object)))
            SqlCom.Parameters.Add(New SqlParameter("@DOC_TYPE", contenttype))
            SqlCom.Parameters.Add(New SqlParameter("@DOC_EXT", sFileType))
            SqlCom.Parameters.Add(New SqlParameter("@ID", REFID))
            SqlCom.Parameters.Add(New SqlParameter("@BY", My.Settings.Username))
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
        openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|doc files (*.doc)|*.doc|text files (*.text)|*.txt|jpg files (*.jpg)|*.jpg"
        openFileDialog.Multiselect = False
        openFileDialog.AddExtension = True
        openFileDialog.ValidateNames = True
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Return openFileDialog
    End Function
    Private Function chkUpFName(ByVal fname As String, ByVal refID As String) As Boolean
        Dim dt As New DataTable
        dt = _ObjBusi.Check("CHKSFRDOC", fname, refID, "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Private Sub downLoadFile(ByVal iFileId As String, ByVal sFileName As String, ByVal sFileExtension As String)
        Try
            Dim dt As New DataTable
            dt = _ObjBusi.getDetails_VI("VSFR", iFileId, "", "", "", "", "", "", "", "", "", Conn)
            Dim strSql As String
            strSql = "Select DOC_DATA from dt_Shortfall_Account WHERE Id='" & iFileId & "'"
            Dim sqlCmd As New SqlCommand(strSql, Conn)
            Dim dbbyte As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())
            Dim filepath As String = Application.StartupPath & "\Report\Letters\" & dt.Rows(0)("DOC_NAME").ToString()
            Dim FS As FileStream
            FS = New FileStream(filepath, System.IO.FileMode.Create)
            FS.Write(dbbyte, 0, dbbyte.Length)
            FS.Close()
            Dim Proc As Process
            Proc = New Process()
            Proc.StartInfo.FileName = filepath
            Proc.Start()
        Catch ex As Exception
            MsgBox("No record found!")
        End Try
    End Sub
    Private Sub dgvSFR_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSFR.CellContentClick
        With Me.dgvSFR
            If e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(3).Value = "" Then
                    MsgBox("Please select the request type!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(2).Value = "" Then
                    MsgBox("Please do key in Remarks!")
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(6).Value) Then
                    Dim sRes As String
                    Dim dt As DataTable
                    If .Rows(e.RowIndex).Cells(2).Value.ToString.Trim() = "REQUEST" Then
                        dt = _ObjBusi.getDetails_VI("VSFR", .Rows(e.RowIndex).Cells(6).Value.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
                        If Not dt.Rows.Count > 0 Then
                            MsgBox("There is no request form uploaded for this shortfall! Please upload the request form and Try again!")
                            Exit Sub
                        End If
                    End If
                    sRes = _ObjBusi.spUpdate("UPDATESFR", .Rows(e.RowIndex).Cells(6).Value.ToString.Trim(), "SFR", .Rows(e.RowIndex).Cells(2).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(3).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(16).Value.ToString.Trim(), "0599", My.Settings.Username.ToUpper.ToString.Trim(), "", "", "", Conn)
                    If sRes = "1" Then
                        MsgBox("Successfully Submitted!")
                        BINDDATA()
                    Else
                        MsgBox("Error while submitted the shortfall details or there is open document for this case!")
                    End If
                End If
            ElseIf e.ColumnIndex = 0 Then
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
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(6).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                            'BINDDATA()
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(6).Value.ToString().Trim(), "filename", "extenstion")
            End If
        End With
    End Sub
    Private Sub dgvPendingConfirmation_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendingConfirmation.CellContentClick
        With Me.dgvPendingConfirmation
            If e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(3).Value) Then
                    Dim sRes As String
                    sRes = _ObjBusi.spUpdate("UPDATESFC", .Rows(e.RowIndex).Cells(3).Value.ToString.Trim(), "SFR", "", "", "", "0599", My.Settings.Username.ToUpper.ToString.Trim(), "", "", "", Conn)
                    If sRes = "1" Then
                        MsgBox("Successfully Submitted!")
                        BINDDATA()
                    Else
                        MsgBox("Error while submitted the shortfall details or there is open document for this case!")
                    End If
                End If
            ElseIf e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            End If
        End With
    End Sub
#Region "Progress Bar"

    Private Shared SharedData As New SharedObject()
    Protected Overridable Sub StartMarqueeThread()
        Dim t As New Threading.Thread(AddressOf ShowMarqueeForm)
        t.Start()
    End Sub
    Protected Overridable Sub ShowMarqueeForm()
        Dim L As New Loading()
        L.Show()
        L.Update()
        Do
            SyncLock SharedData
                If SharedData.ReadyToHideMarquee Then
                    Exit Do
                End If
            End SyncLock
            Application.DoEvents()
        Loop

    End Sub

    Private Class SharedObject
        Public ReadyToHideMarquee As Boolean
    End Class
#End Region
    Private Sub tsbExport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExport2Xcel.Click
        xPort2Xcel()
    End Sub
    Private Sub xPort2Xcel()
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWSName As String = ""
        Dim xRCount As Integer = 0
        Dim dgvrCount As Integer = 0
        xWB.Worksheets.Add()
        xWSName = "Sheet" & xWB.Worksheets.Count.ToString.Trim()

        With xWB.Worksheets(xWSName)
            .Cells(1, 1) = "SHORT FALL DETAILS"
            .Cells(2, 1) = "EXPORTED ON : " & Now()

            .Cells(4, 1) = "NO"
            .Cells(4, 2) = "IC"
            .Cells(4, 3) = "FULL NAME"
            .Cells(4, 4) = "PLAN"
            .Cells(4, 5) = "PHONE HOUSE"
            .Cells(4, 6) = "PHONE MOBILE"
            .Cells(4, 7) = "PHONE OFFICE"
            .Cells(4, 8) = "EMAIL"
            .Cells(4, 9) = "REQUESTED AMOUNT"
            .Cells(4, 10) = "RECEIVED AMOUNT"
            .Cells(4, 11) = "SHORT AMOUNT"
            .Cells(4, 12) = "REMAKRS"

            xRCount = 5
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Do While dgvrCount < Me.dgvSFR.Rows.Count

                .Cells(xRCount, 1) = "'" & (xRCount - 4).ToString.Trim
                .Cells(xRCount, 2) = "'" & Me.dgvSFR.Rows(dgvrCount).Cells(7).Value
                .Cells(xRCount, 3) = "'" & Me.dgvSFR.Rows(dgvrCount).Cells(8).Value
                .Cells(xRCount, 4) = "'" & Me.dgvSFR.Rows(dgvrCount).Cells(9).Value
                .Cells(xRCount, 5) = "'" & Me.dgvSFR.Rows(dgvrCount).Cells(10).Value
                .Cells(xRCount, 6) = "'" & Me.dgvSFR.Rows(dgvrCount).Cells(11).Value
                .Cells(xRCount, 7) = "'" & Me.dgvSFR.Rows(dgvrCount).Cells(12).Value
                .Cells(xRCount, 8) = "'" & Me.dgvSFR.Rows(dgvrCount).Cells(13).Value
                .Cells(xRCount, 9) = "'" & Me.dgvSFR.Rows(dgvrCount).Cells(14).Value
                .Cells(xRCount, 10) = "'" & Me.dgvSFR.Rows(dgvrCount).Cells(15).Value
                .Cells(xRCount, 11) = "'" & Me.dgvSFR.Rows(dgvrCount).Cells(16).Value
                .Cells(xRCount, 12) = " "

                dgvrCount += 1
                xRCount += 1
            Loop
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        End With
        xApp.Visible = True
    End Sub
End Class