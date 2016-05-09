Imports System.IO
Public Class fSFnNPR
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Dim UPPID As String
    Private Sub fSFnNPR_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fSFnNPR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        ds = _ObjBusi.getDsDetails_VIII("SFnNPR", Me.lblP1.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvNPnSF
                .DataSource = ds.Tables(0)
                Me.tslblTot.Text = "Total Records : " & ds.Tables(0).Rows.Count

                .Columns(21).DefaultCellStyle.Format = "#,#00.00"
                .Columns(22).DefaultCellStyle.Format = "#,#00.00"
                .Columns(23).DefaultCellStyle.Format = "#,#00.00"
                .Columns(24).DefaultCellStyle.Format = "#,#00.00"
                .Columns(25).DefaultCellStyle.Format = "#,#00.00"
                .Columns(26).DefaultCellStyle.Format = "#,#00.00"


                .Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvNPnSF.DataSource = ds.Tables(0)
            Me.tslblTot.Text = "Total Records : 0"
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvPendingConfirmation
                .DataSource = ds.Tables(1)
                .Columns(0).DisplayIndex = 22
                .Columns(1).DisplayIndex = 22
                .Columns(2).Visible = False
                .Columns(3).Visible = False

                .Columns(18).DefaultCellStyle.Format = "#,##0.00"
                .Columns(19).DefaultCellStyle.Format = "#,##0.00"
                .Columns(20).DefaultCellStyle.Format = "#,##0.00"
                .Columns(21).DefaultCellStyle.Format = "#,##0.00"
                .Columns(22).DefaultCellStyle.Format = "#,##0.00"

                .Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
        Else
            Me.dgvPendingConfirmation.DataSource = ds.Tables(1)
        End If

        If ds.Tables(2).Rows.Count > 0 Then
            With Me.dgvPendingDecision
                .DataSource = ds.Tables(2)
                .Columns(0).Visible = False
                .Columns(1).Visible = False

                .Columns(15).DefaultCellStyle.Format = "#,##0.00"
                .Columns(16).DefaultCellStyle.Format = "#,##0.00"
                .Columns(17).DefaultCellStyle.Format = "#,##0.00"
                .Columns(18).DefaultCellStyle.Format = "#,##0.00"
                .Columns(19).DefaultCellStyle.Format = "#,##0.00"
                .Columns(20).DefaultCellStyle.Format = "#,##0.00"

                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
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
            qry = "insert into dt_documents (RefType, RefID, FileName,FileData," & _
            "FileType,Fileext, DocumentName,CREATED_ON, CREATED_BY) values(@RefType, @ID, @FileName, @FileData," & _
            "@FileType,@FileExt, @DName, getdate(), @BY)"

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
            SqlCom.Parameters.Add(New SqlParameter("@RefType", "SHORTFALL"))
            SqlCom.Parameters.Add(New SqlParameter("@DName", sFileName.ToString.Trim().ToUpper()))
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
            strSql = "select filedata from dt_documents WHERE Id='" & dt.Rows(0)("ID").ToString() & "'"
            Dim sqlCmd As New SqlCommand(strSql, Conn)
            Dim dbbyte As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())
            Dim filepath As String = Application.StartupPath & "\Report\Letters\" & dt.Rows(0)("filename").ToString()
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
    Private Sub dgvSFR_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        With Me.dgvNPnSF
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
                If Not IsDBNull(.Rows(e.RowIndex).Cells(2).Value) Then
                    Dim sRes As String
                    sRes = _ObjBusi.spUpdate("SHORTFALLCONFIRM", .Rows(e.RowIndex).Cells(2).Value.ToString.Trim(), My.Settings.Username.ToUpper.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
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
                downLoadFile(.Rows(e.RowIndex).Cells(2).Value.ToString().Trim(), "filename", "extenstion")
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
    Private Sub Xport2Xcel()
        If Me.dgvNPnSF.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "NON PAYMENT AND SHORT FALL POLICY DETAILS"
                .Cells(2, 1) = "EXPORTED ON : " & Now()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "ASSIGN TO"
                .Cells(4, 3) = "ASSIGN ON"
                .Cells(4, 4) = "ASSIGN BY"
                .Cells(4, 5) = "IC"
                .Cells(4, 6) = "FULL NAME"
                .Cells(4, 7) = "DOB"
                .Cells(4, 8) = "PLAN I"
                .Cells(4, 9) = "PLAN II"
                .Cells(4, 10) = "FILE NO"
                .Cells(4, 11) = "PHONE HOUSE"
                .Cells(4, 12) = "PHONE OFFICE"
                .Cells(4, 13) = "PHONE MOBILE"
                .Cells(4, 14) = "EMAIL"
                .Cells(4, 15) = "TOTAL NON PAYMENT"
                .Cells(4, 16) = "TOTAL SHORT"
                .Cells(4, 17) = "TOTAL SHORT NOT REQUESTED"
                .Cells(4, 18) = "TOTAL SHORT REQUESTED"
                .Cells(4, 19) = "TOTAL SHORT RECEOVED"
                .Cells(4, 20) = "TOTAL SHORT BALANCE"


                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvNPnSF.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(17).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(18).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(19).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(20).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(21).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(22).Value.ToString.Trim
                    .Cells(xRowCount, 17) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(23).Value.ToString.Trim
                    .Cells(xRowCount, 18) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(24).Value.ToString.Trim
                    .Cells(xRowCount, 19) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(25).Value.ToString.Trim
                    .Cells(xRowCount, 20) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(26).Value.ToString.Trim

                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub dgvNPnSF_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNPnSF.CellContentClick
        With Me.dgvNPnSF
            If e.ColumnIndex = 21 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(21).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "NONPAYMENT"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(7).Value.ToString()
                    VD.lblP3.Text = "NONPAYMENT"
                    VD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 22 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(22).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "TOTSHORT"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(7).Value.ToString()
                    VD.lblP3.Text = "SHORTFALL"
                    VD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 23 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(23).Value = "0" Then
                    MsgBox("There is no break down details on this request!")
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 24 Then
                If Not .Rows(e.RowIndex).Cells(24).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "TOTREQUESTED"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(7).Value.ToString()
                    VD.lblP3.Text = "REQUEST"
                    VD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 25 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(25).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "TOTRECOVERED"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(7).Value.ToString()
                    VD.lblP3.Text = "RECOVER"
                    VD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 3 Then
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

                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(6).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(0).Value = "" Then
                    MsgBox("Please do key in Deduction Month from!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(1).Value = "" Then
                    MsgBox("Please do key in Deduction Month To!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(2).Value = "" Then
                    MsgBox("Please do key in Requested Amount!")
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(7).Value) Then
                    Dim sRes, ssDate, seDate As String
                    Dim dAmt As Double
                    ssDate = "01/" & Microsoft.VisualBasic.Right(.Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), 2) & "/" & Microsoft.VisualBasic.Left(.Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), 4)
                    seDate = "28/" & Microsoft.VisualBasic.Right(.Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), 2) & "/" & Microsoft.VisualBasic.Left(.Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), 4)
                    Dim sDate, eDate As Date
                    Dim NoOfMonths As Integer
                    sDate = Convert.ToDateTime(ssDate)
                    eDate = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(seDate))
                    NoOfMonths = DateDiff(DateInterval.Month, sDate, eDate)
                    dAmt = .Rows(e.RowIndex).Cells(2).Value * NoOfMonths
                    sRes = _ObjBusi.spUpdate("SHORTFALLREQUEST", .Rows(e.RowIndex).Cells(6).Value.ToString(), .Rows(e.RowIndex).Cells(7).Value.ToString(), .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), dAmt, My.Settings.Username.ToUpper.ToString.Trim(), "", "", "", "", Conn)
                    If sRes = "1" Then
                        MsgBox("Successfully submitted your request!")
                        BINDDATA()
                    Else
                        MsgBox("Error while submiting the request, Please check with admin!")
                    End If
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
    End Sub
End Class