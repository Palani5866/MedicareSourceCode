Imports System.IO
Public Class rPremiumD
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
    Private Sub rPremiumD_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub rPremiumD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindMonths()
    End Sub
    Private Sub BindMonths()
        Dim aMonth As New ArrayList
        Dim p1YR, p2Yr, cYr, f1Yr, f2Yr, p1M, p2M, cM, f1M, f2M As String
        For p1I As Integer = 0 To 11
            p1M = "0" & p1I + 1
            If p1M.Length = 3 Then
                p1M = p1M.Substring(1, 2)
            End If
            p1YR = Now.Year() - 2 & p1M
            aMonth.Add(p1YR)
        Next
        For p2I As Integer = 0 To 11
            p2M = "0" & p2I + 1
            If p2M.Length = 3 Then
                p2M = p2M.Substring(1, 2)
            End If
            p2Yr = Now.Year() - 1 & p2M
            aMonth.Add(p2Yr)
        Next
        For cI As Integer = 0 To 11
            cM = "0" & cI + 1
            If cM.Length = 3 Then
                cM = cM.Substring(1, 2)
            End If
            cYr = Now.Year() & cM
            aMonth.Add(cYr)
        Next
        For f1I As Integer = 0 To 11
            f1M = "0" & f1I + 1
            If f1M.Length = 3 Then
                f1M = f1M.Substring(1, 2)
            End If
            f1Yr = Now.Year() + 1 & f1M
            aMonth.Add(f1Yr)
        Next
        For f2I As Integer = 0 To 11
            f2M = "0" & f2I + 1
            If f2M.Length = 3 Then
                f2M = f2M.Substring(1, 2)
            End If
            f2Yr = Now.Year() + 2 & f2M
            aMonth.Add(f2Yr)
        Next
        Me.tsReport_ddlMonth.ComboBox.DataSource = aMonth
    End Sub
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If fValid() Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            BINDDATA()
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        End If
    End Sub
    Private Function fValid() As Boolean
        If Len(Me.tsReport_ddlMonth.Text.Trim()) = 0 Then
            MsgBox("Please select premium DECREASE month!")
            Return False
        End If
        Return True
    End Function
    Private Sub BINDDATA()
        Dim dt As New DataTable
        Select Case Me.lblRF1.Text.Trim()
            Case "CCNEW"
                dt = _objBusi.fPD("CC", Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "", "", "", "", "", "CCNEW", "DECREASE", Conn)
            Case "CCOLD"
                dt = _objBusi.fPD("CC", Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "", "", "", "", "", "CCOLD", "DECREASE", Conn)
            Case "CPANEW"
                dt = _objBusi.fPD("CPA", Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "", "", "", "", "", "CPANEW", "DECREASE", Conn)
            Case "CPAOLD"
                dt = _objBusi.fPD("CPA", Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "", "", "", "", "", "CPAOLD", "DECREASE", Conn)
        End Select
        If dt.Rows.Count > 0 Then
            With Me.dgvForm
                .DataSource = dt
                .Columns(1).Visible = False ' refid
            End With
        Else
            MsgBox("No record found")
            Me.dgvForm.DataSource = dt
        End If
        BINDDATAD()
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            Dim dgvRowCount As Integer = 0
            Dim sRes, batchno As String
            batchno = "PD" & Format(Now.Date, "yyMMdd") & "-" & Format(Now, "HHmmss")
            With Me.dgvForm
                Do While dgvRowCount < .Rows.Count
                    If .Rows(dgvRowCount).Cells(0).Value = "T" Then
                        sRes = _objBusi.InsUpsPremium("INSERT", Guid.NewGuid.ToString.Trim(), .Rows(dgvRowCount).Cells(1).Value.ToString, batchno, "DECREASE", "", "", .Rows(dgvRowCount).Cells(7).Value.ToString, .Rows(dgvRowCount).Cells(8).Value.ToString, "In Progress", "Requested", "", "", My.Settings.Username, Conn)
                    End If
                    dgvRowCount += 1
                Loop
            End With
            If sRes = "1" Then
                MsgBox("Sucessfully requested!")
                BINDDATA()
            End If
        Catch ex As Exception
            MsgBox("Currently Our server busy! Please try again later")
        End Try
    End Sub
    Private Sub dgvPIRequested_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPIRequested.CellContentClick
        With Me.dgvPIRequested
            If e.ColumnIndex = 0 Then

                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(3).Value) Then

                    Dim PD As New PremiumDetails
                    PD.lblREFID.Text = .Rows(e.RowIndex).Cells(3).Value.ToString().Trim()
                    PD.Show()
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
                            BINDDATAD()
                        End If
                    Else 'Cancel
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
    Private Sub BINDDATAD()
        Dim dtPI As New DataTable
        dtPI = _objBusi.fPI("CC", Me.lblRF1.Text.Trim(), "", "", "", "", "", "", "", "REQUESTED", "DECREASE", Conn)
        If dtPI.Rows.Count > 0 Then
            With Me.dgvPIRequested
                .DataSource = dtPI
                .Columns(0).DisplayIndex = 3
                .Columns(1).DisplayIndex = 3
                .Columns(2).DisplayIndex = 3
            End With
        End If
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
            SqlCom.Parameters.Add(New SqlParameter("@RefType", "PREMIUMDECREASE"))
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
    Private Function chkUpFName(ByVal fname As String, ByVal refID As String) As Boolean
        Dim dt As New DataTable
        dt = _objBusi.Check("DOCUMENTS", fname, refID, "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Private Sub downLoadFile(ByVal iFileId As String, ByVal sFileName As String, ByVal sFileExtension As String)
        Try
            Dim dt As New DataTable
            dt = _objBusi.fPremium("CC", iFileId, "", "", "", "", "", "", "", "DL", "DECREASE", Conn)
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
    Private Sub tsbtnXporttoXcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnXporttoXcel.Click
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        XPort2Xcel()
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvForm.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PREMIUM INCREASE DETAILS"
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "DOB"
                .Cells(4, 5) = "AGE"
                .Cells(4, 6) = "DEDUCTION CODE"
                .Cells(4, 7) = "CURRENT PREMIUM"
                .Cells(4, 8) = "PREMIUM TO REVISE"
                .Cells(4, 9) = "EFFECTIVE DATE"
                .Cells(4, 10) = "PLAN"
                .Cells(4, 11) = "PLAN TYPE"
                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvForm.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvForm.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvForm.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvForm.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvForm.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvForm.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvForm.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvForm.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvForm.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvForm.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvForm.Rows(iCount).Cells(11).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exported records to REPORT: PREMIUM INCREASE DETAILS")
            xApp.Visible = True
        End If
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
End Class