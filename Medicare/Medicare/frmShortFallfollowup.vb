Imports System.IO
Public Class frmShortFallfollowup
    Dim Conn As DbConnection = New SqlConnection()
    Dim _objBusi As New Business
    Dim sType, BatchNo As String
    Private Sub frmShortFallfollowup_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frmShortFallfollowup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDCB()
        BINDDATA()
    End Sub
    Private Sub BINDCB()
        Dim dt As New DataTable
        dt = _objBusi.fShortFalls("SHORTFALL", "", "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), "BINDCODES", Conn)
        If dt.Rows.Count > 0 Then
            Me.ddlDCode.ComboBox.DataSource = dt
            Me.ddlDCode.ComboBox.DisplayMember = "Deduction_CODE"
            Me.ddlDCode.ComboBox.ValueMember = "Deduction_CODE"
        Else
            Me.ddlDCode.ComboBox.DataSource = dt
        End If

        Dim dtBatchNo As New DataTable
        If sType = "SEARCH" Then
            dtBatchNo = _objBusi.fShortFalls("SHORTFALL", Me.ddlDCode.Text.Trim(), "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), "SBATCHNO", Conn)
        Else
            dtBatchNo = _objBusi.fShortFalls("SHORTFALL", "", "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), "BATCHNO", Conn)
        End If
    End Sub
    Private Sub BINDDATA()
        Dim dt As DataTable
        If sType = "SEARCH" Then
            dt = _objBusi.fShortFalls("SHORTFALL", Me.ddlDCode.Text.Trim(), "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), "SEARCH", Conn)
        Else
            dt = _objBusi.fShortFalls("SHORTFALL", "", "", "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), Conn)
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvShortFalls
                .DataSource = dt
                .Columns(0).Visible = False 'id
                Me.tslblTotalRecords.Text = "Total Records :" & dt.Rows.Count.ToString()
            End With
        Else
            MsgBox("No Record Found")
            Me.dgvShortFalls.DataSource = dt
        End If
        Dim dtR As New DataTable
        If sType = "SEARCH" Then
            dtR = _objBusi.fShortFalls("SHORTFALL", Me.ddlDCode.Text.Trim(), "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), "SREQUESTED", Conn)
        Else
            dtR = _objBusi.fShortFalls("SHORTFALL", "", "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), "REQUESTED", Conn)
        End If

        If dtR.Rows.Count > 0 Then
            With Me.dgvRSFR
                .DataSource = dtR
                .Columns(0).DisplayIndex = 3
                .Columns(1).DisplayIndex = 3
                .Columns(2).DisplayIndex = 3
            End With
        Else
            Me.dgvRSFR.DataSource = dtR
        End If

        Dim dtC As New DataTable
        If sType = "SEARCH" Then
            dtC = _objBusi.fShortFalls("SHORTFALL", Me.ddlDCode.Text.Trim(), "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), "SCLOSED", Conn)
        Else
            dtC = _objBusi.fShortFalls("SHORTFALL", "", "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), "CLOSED", Conn)
        End If

        If dtC.Rows.Count > 0 Then
            With Me.dgvShortfallsClosed
                .DataSource = dtC
            End With
        Else
            Me.dgvShortfallsClosed.DataSource = dtC
        End If
    End Sub
    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        sType = "SEARCH"
        BINDDATA()
        BINDCB()
    End Sub
    Private Sub dgvShortFalls_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShortFalls.CellDoubleClick
        With Me.dgvShortFalls
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            If BatchNo = "" Then
                BatchNo = Now.Day & "/" & Now.Month & "/" & "S" & "/" & Now.Year()
            End If
            Dim dt As New DataTable
            dt = _objBusi.fShortFalls("SHORTFALL", .SelectedRows(0).Cells(0).Value.ToString.Trim, "", "", "", "", "", "", "", "", "CHECK", Conn)
            If dt.Rows.Count > 0 Then
                MsgBox("This record already requested Please do select another record")
            Else
                Dim rSF As New RecoverShortFall
                rSF.MdiParent = frmMain
                rSF.lblREFID.Text = .SelectedRows(0).Cells(0).Value.ToString.Trim
                rSF.txtNRIC.Text = .SelectedRows(0).Cells(1).Value.ToString.Trim
                rSF.txtFullName.Text = .SelectedRows(0).Cells(2).Value.ToString.Trim
                rSF.txtDeductionCode.Text = .SelectedRows(0).Cells(5).Value.ToString.Trim
                rSF.txtShortAmt.Text = FormatNumber(.SelectedRows(0).Cells(11).Value.ToString.Trim.Replace("-", ""), 2)
                rSF.txtRequestedAmt.Text = FormatNumber(.SelectedRows(0).Cells(11).Value.ToString.Trim.Replace("-", ""), 2)
                rSF.lblBATCHNO.Text = BatchNo
                rSF.lblREF1.Text = Me.lblREF1.Text.Trim
                rSF.Show()
            End If
        End With
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvShortfallsClosed.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "SHORT FALLS CLOSED DETAILS"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "DEDUCTION CODE"
                .Cells(4, 5) = "DEDUCTION MONTH"
                .Cells(4, 6) = "RECEIVING MONTH"
                .Cells(4, 7) = "REQUESTED AMOUNT"
                .Cells(4, 8) = "RECEIVING AMOUNT"
                .Cells(4, 9) = "SHORT AMOUNT"
                .Cells(4, 10) = "STATUS"
                .Cells(4, 11) = "REMARKS"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvShortfallsClosed.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvShortfallsClosed.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvShortfallsClosed.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvShortfallsClosed.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvShortfallsClosed.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvShortfallsClosed.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvShortfallsClosed.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvShortfallsClosed.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvShortfallsClosed.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvShortfallsClosed.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvShortfallsClosed.Rows(iCount).Cells(9).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: SHORT FALLS CLOSED DETAILS")
            xApp.Visible = True
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
    Private Sub dgvRSFR_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRSFR.CellContentClick
        With Me.dgvRSFR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(3).Value) Then
                    Dim vSF As New vShortFalls
                    vSF.lblREFID.Text = .Rows(e.RowIndex).Cells(3).Value.ToString().Trim()
                    vSF.lblREF2.Text = Me.lblREF1.Text.Trim()
                    vSF.Show()
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
            SqlCom.Parameters.Add(New SqlParameter("@RefType", "SHORTFALLS"))
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
        openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|xls files (*.xls)|*.xls|jpg files (*.jpg)|*.jpg|doc files (*.doc)|*.doc|text files (*.text)|*.txt"
        openFileDialog.Multiselect = False
        openFileDialog.AddExtension = True
        openFileDialog.ValidateNames = True
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Return openFileDialog
    End Function
    Private Sub downLoadFile(ByVal iFileId As String, ByVal sFileName As String, ByVal sFileExtension As String)
        Try
            Dim dt As New DataTable
            dt = _objBusi.fShortFalls("SHORTFALL", iFileId, "", "", "", "", "", "", "", "", "DL", Conn)
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

    Private Sub tsbtnRequestbatchNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnRequestbatchNo.Click
        Dim dt As New DataTable
        dt = _objBusi.fShortFalls("SHORTFALL", Me.tscbRequestBatchNo.Text.Trim(), "", "", "", "", "", "", "SEARCH", Me.lblREF1.Text.Trim(), "REQUESTED", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvRSFR
                .DataSource = dt
                .Columns(0).DisplayIndex = 3
                .Columns(1).DisplayIndex = 3
                .Columns(2).DisplayIndex = 3
            End With
        Else
            MsgBox("No record found")
            Me.dgvRSFR.DataSource = dt
        End If
    End Sub
    Private Sub tsbtnXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnXport2Xcel.Click
        ShortFallXPort2Xcel()
    End Sub
    Private Sub ShortFallXPort2Xcel()
        If Me.dgvShortFalls.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "SHORT FALLS DETAILS"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "POLICY START DATE"
                .Cells(4, 5) = "POLICY END DATE"
                .Cells(4, 6) = "DEDUCTION CODE"
                .Cells(4, 7) = "DEDUCTION MONTH"
                .Cells(4, 8) = "RECEIVING MONTH"
                .Cells(4, 9) = "REQUESTED AMOUNT"
                .Cells(4, 10) = "RECEIVING AMOUNT"
                .Cells(4, 11) = "SHORT AMOUNT"
                .Cells(4, 12) = "RECOVERED AMOUNT"
                .Cells(4, 13) = "BALANCE AMOUNT"
                .Cells(4, 14) = "RECOVER STATUS"
                .Cells(4, 15) = "STATUS"
                .Cells(4, 16) = "REMARKS"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvShortFalls.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvShortFalls.Rows(iCount).Cells(15).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: SHORT FALLS DETAILS")
            xApp.Visible = True
        End If
    End Sub
End Class