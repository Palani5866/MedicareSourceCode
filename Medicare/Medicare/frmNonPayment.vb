Imports System.IO
Public Class frmNonPayment
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub frmNonPayment_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frmNonPayment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tstxtDateFrom.Text = DateSerial(Today.Year, Today.Month + 0, 15)
        Me.tstxtDateTo.Text = DateSerial(Today.Year, Today.Month + 1, 14)
    End Sub
    Private Sub BINDDATA()
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim sDate, eDate As DateTime
        Dim strsDate, streDate As String
        sDate = Me.tstxtDateFrom.Text.ToString.Trim()
        eDate = Me.tstxtDateTo.Text.ToString.Trim()
        strsDate = Format(sDate, "MM/dd/yyyy")
        streDate = Format(eDate, "MM/dd/yyyy")
        ds = _objBusi.getDsDetails_V("NONPAYMENT", strsDate, streDate, "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvPNONPayment
                .DataSource = ds.Tables(0)
                .Columns(0).DisplayIndex = 16
                .Columns(1).DisplayIndex = 16
                .Columns(2).DisplayIndex = 16
                .Columns(3).DisplayIndex = 16
                .Columns(4).Visible = False
                Me.tslblTOT.Text = "Total Record : " & ds.Tables(0).Rows.Count
            End With
        Else
            Me.dgvPNONPayment.DataSource = ds.Tables(0)
            Me.tslblTOT.Text = "Total Record : 0 "
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvRNONPD
                .DataSource = ds.Tables(1)
                .Columns(0).DisplayIndex = 16
                .Columns(1).DisplayIndex = 16
                .Columns(2).DisplayIndex = 16
                .Columns(3).DisplayIndex = 16
                .Columns(4).Visible = False
            End With
        Else
            Me.dgvRNONPD.DataSource = ds.Tables(1)
        End If

        If ds.Tables(2).Rows.Count > 0 Then
            With Me.dgvPendingConfirmation
                .DataSource = ds.Tables(2)
                .Columns(0).Visible = False
                .Columns(1).Visible = False
            End With
        Else
            Me.dgvPendingConfirmation.DataSource = ds.Tables(2)
        End If

        If ds.Tables(3).Rows.Count > 0 Then
            With Me.dgvPendingDecision
                .DataSource = ds.Tables(3)
                .Columns(0).DisplayIndex = 16
                .Columns(1).DisplayIndex = 16
                .Columns(2).DisplayIndex = 16
                .Columns(3).DisplayIndex = 16
                .Columns(2).Visible = False
            End With
        Else
            Me.dgvPendingDecision.DataSource = ds.Tables(3)
        End If
        
    End Sub
    Private Sub BINDDATAI()
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim sDate, eDate As DateTime
        Dim strsDate, streDate As String
        sDate = Me.tstxtDateFrom.Text.ToString.Trim()
        eDate = Me.tstxtDateFrom.Text.ToString.Trim()
        strsDate = Format(sDate, "MM/dd/yyyy")
        streDate = Format(eDate, "MM/dd/yyyy")
        ds = _objBusi.getDsDetails_V("NONPAYMENT", strsDate, streDate, "", "", "", "", "", "", "", Me.lblREFTYPE.Text.Trim(), Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvPNONPayment
                .DataSource = ds.Tables(0)
                .Columns(0).DisplayIndex = 16
                .Columns(1).DisplayIndex = 16
                .Columns(2).DisplayIndex = 16
                .Columns(3).DisplayIndex = 16
                .Columns(4).Visible = False
                Me.tslblTOT.Text = "Total Record : " & ds.Tables(0).Rows.Count
            End With
        Else
            Me.dgvPNONPayment.DataSource = ds.Tables(0)
            Me.tslblTOT.Text = "Total Record : 0 "
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvRNONPD
                .DataSource = ds.Tables(1)
                .Columns(0).DisplayIndex = 25
                .Columns(1).DisplayIndex = 25
                .Columns(2).DisplayIndex = 25
                .Columns(3).DisplayIndex = 25
                .Columns(4).DisplayIndex = 25
                .Columns(5).DisplayIndex = 25
                .Columns(6).DisplayIndex = 25
                .Columns(7).Visible = False
                .Columns(8).Visible = False
            End With
        Else
            Me.dgvRNONPD.DataSource = ds.Tables(1)
        End If

        If ds.Tables(2).Rows.Count > 0 Then
            With Me.dgvPendingConfirmation
                .DataSource = ds.Tables(2)
                .Columns(0).DisplayIndex = 20
                .Columns(1).DisplayIndex = 20
                .Columns(2).Visible = False
                .Columns(3).Visible = False
            End With
        Else
            Me.dgvPendingConfirmation.DataSource = ds.Tables(2)
        End If

        If ds.Tables(3).Rows.Count > 0 Then
            With Me.dgvPendingDecision
                .DataSource = ds.Tables(3)
                .Columns(0).Visible = False
                .Columns(1).Visible = False
            End With
        Else
            Me.dgvPendingDecision.DataSource = ds.Tables(3)
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
    Private Sub tstxtDateFrom_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstxtDateFrom.Leave
        Dim sDate As DateTime
        sDate = Convert.ToDateTime(tstxtDateFrom.Text.ToString.Trim())
        Me.tstxtDateFrom.Text = DateSerial(sDate.Year, sDate.Month + 0, 15)
        Me.tstxtDateTo.Text = DateSerial(sDate.Year, sDate.Month + 1, 14)
    End Sub
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        If Me.lblREFTYPE.Text.ToString.Trim() = "" Then
            BINDDATA()
        Else
            BINDDATAI()
        End If
    End Sub
    Private Sub dgvPNONPayment_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPNONPayment.CellContentClick
        With Me.dgvPNONPayment
            If e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(0).Value = "" Then
                    MsgBox("Please select the declaration!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(1).Value = "" Then
                    MsgBox("Please select the action!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(2).Value = "" Then
                    MsgBox("Please do key in Remarks!")
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(4).Value) Then
                    Dim sDate As DateTime
                    Dim strsDate As String
                    sDate = Convert.ToDateTime(tstxtDateFrom.Text.ToString.Trim())
                    strsDate = Format(sDate, "MM/dd/yyyy")
                    Dim sRes As String
                    sRes = _objBusi.spUpdate("INSERTPP", .Rows(e.RowIndex).Cells(4).Value.ToString.Trim(), "NONPAYMENT", .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(2).Value.ToString.Trim(), strsDate, My.Settings.Username.ToUpper.ToString.Trim(), "", "", "NONPAYMENT", Conn)
                    If sRes = "1" Then
                        MsgBox("Successfully Submitted!")
                        BINDDATA()
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub dgvRNONPD_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRNONPD.CellContentClick
        With Me.dgvRNONPD
            If e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(0).Value = "" Then
                    MsgBox("Please select the declaration!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(1).Value = "" Then
                    MsgBox("Please select the action!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(2).Value = "" Then
                    MsgBox("Please do key in Remarks!")
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(4).Value) Then
                    Dim sDate As DateTime
                    Dim strsDate As String
                    sDate = Convert.ToDateTime(tstxtDateFrom.Text.ToString.Trim())
                    strsDate = Format(sDate, "MM/dd/yyyy")
                    Dim sRes As String
                    sRes = _objBusi.spUpdate("INSERTPP", .Rows(e.RowIndex).Cells(7).Value.ToString.Trim(), "NONPAYMENT", .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(2).Value.ToString.Trim(), strsDate, My.Settings.Username.ToUpper.ToString.Trim(), "", "", "NONPAYMENT", Conn)
                    _objBusi.spUpdate("UPDATEPP", .Rows(e.RowIndex).Cells(8).Value.ToString.Trim(), "NONPAYMENT", .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), strsDate, My.Settings.Username.ToUpper.ToString.Trim(), "", "", "NONPAYMENT", Conn)
                    If sRes = "1" Then
                        MsgBox("Successfully Submitted!")
                        BINDDATAI()
                    Else
                        MsgBox("Error while submitted the payment details or there is open document for this case!")
                    End If
                End If
            ElseIf e.ColumnIndex = 4 Then
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
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(8).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(8).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 6 Then
                Dim sRes As String
                sRes = _objBusi.spUpdate("NONPUP", .Rows(e.RowIndex).Cells(8).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "", Conn)
                BINDDATAI()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Non Payment")
                Else
                    MsgBox("Error while requesting Non Payment")
                End If
            End If

        End With
    End Sub
    Private Sub dgvPendingConfirmation_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendingConfirmation.CellContentClick
        With Me.dgvPendingConfirmation
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("NONPUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                BINDDATAI()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
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
            qry = "UPDATE dt_pending_premium SET DOC_NAME=@DOC_NAME,DOC_DATA=@DOC_DATA, DOC_TYPE=@DOC_TYPE,DOC_EXT=@DOC_EXT, UPLOADED_BY=@BY, UPLOADED_ON=GETDATE()WHERE ID=@ID"

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
        openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|xls files (*.xls)|*.xls|jpg files (*.jpg)|*.jpg|doc files (*.doc)|*.doc|text files (*.text)|*.txt"
        openFileDialog.Multiselect = False
        openFileDialog.AddExtension = True
        openFileDialog.ValidateNames = True
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Return openFileDialog
    End Function
    Private Function chkUpFName(ByVal fname As String, ByVal refID As String) As Boolean
        Dim dt As New DataTable
        dt = _objBusi.Check("CHKPIDOC", fname, refID, "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Private Sub downLoadFile(ByVal iFileId As String, ByVal sFileName As String, ByVal sFileExtension As String)
        Try
            Dim dt As New DataTable
            dt = _objBusi.getDetails_V("NONPDOC", iFileId, "", "", "", "", "", "", "", "", "", Conn)
            Dim strSql As String
            strSql = "Select DOC_DATA from dt_pending_premium WHERE Id='" & iFileId & "'"
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
    Private Sub tsbtnExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExporttoExcel.Click
        Xport2Xcel()
    End Sub
    Private Sub Xport2Xcel()
        If Me.dgvPNONPayment.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "NON PAYMENT POLICY DETAILS"
                .Cells(2, 1) = "FOR DATE FROM " & Me.tstxtDateFrom.Text.ToString.Trim() & " To : " & Me.tstxtDateTo.Text.ToString.Trim()
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "DOB"
                .Cells(5, 5) = "START DATE"
                .Cells(5, 6) = "PLAN"
                .Cells(5, 7) = "PLAN TYPE"
                .Cells(5, 8) = "HOUSE CONTACT"
                .Cells(5, 9) = "MOBILE"
                .Cells(5, 10) = "OFFICE #"
                .Cells(5, 11) = "EMAIL"
                .Cells(5, 12) = "FILE #"
                .Cells(5, 13) = "STATUS"
                .Cells(5, 14) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvPNONPayment.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 14) = ""
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

End Class