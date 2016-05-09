Public Class UMD
  
#Region "Global Variables"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
    Dim L As New Loading()
    Dim rowCount As Integer
    Private Sub UMD_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then

            Conn.Close()
        End If
        L.Close()
    End Sub
    Private Sub UMD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then

            Conn.Open()
        End If
    End Sub
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim folder As New OpenFileDialog
        Dim result = folder.ShowDialog
        If result = 1 Then
            Me.txtFileName.Text = folder.FileName
        Else
            MsgBox("File Requied")
        End If
    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        InsXportData()
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        MsgBox("No of Record : " & rowCount & " Sucessfuly Uploaded")
    End Sub
    Private Function InsXportData() As String
        If Me.txtFileName.Text.Trim() = "" Then
            MsgBox("Required file")
            Exit Function
        End If
        Dim dt As New DataTable
        dt = BindData(Me.txtFileName.Text)
        Dim sRes As String
        Dim iCount As Integer = 0
        Dim dm As String = ""
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xls_wks_name As String = ""
        xWB.Worksheets.Add()
        xls_wks_name = "Sheet" & xWB.Worksheets.Count.ToString.Trim

        With xWB.Worksheets(xls_wks_name)
            .Cells(1, 1) = "PROCESSING MONTHLY SALARY DEDUCTION (SIRIM/FAMA/OTHERS)"
            .Cells(2, 1) = "SALARY DEDUCTION MONTH : " & dm

            .Cells(4, 1) = "NO"
            .Cells(4, 2) = "IC #"
            .Cells(4, 3) = "DEDUCTION MONTH"
            .Cells(4, 4) = "DEDUCTION CODE"
            .Cells(4, 5) = "DEDUCTION AMOUNT"
            .Cells(4, 6) = "Status"
        End With
        Dim rCount As Integer = 0
        Dim xls_row_counter As Integer = 5
        Dim Reason As String
        For Each dr As DataRow In dt.Rows
            If iCount > 0 Then
                Dim dtChk As DataTable
                Dim sDcode As String
                If Len(dr(2).ToString.Trim()) > 3 Then
                    sDcode = dr(2)
                Else
                    sDcode = "0" + dr(2).ToString.Trim()
                End If
                dtChk = _objBusi.getDetails_I("OTHERCHKUP", dr(0).ToString.Trim(), sDcode, "", "", "", "", "", "", "", "", Conn)

                If validateDate(dr(1).ToString.Trim()) Then

                    If validateDate(dr(4).ToString.Trim()) Then

                        Reason = _objBusi.CheckValidation("IC", dr(0).ToString.Trim(), dr(1).ToString.Trim(), sDcode, dr(3).ToString.Trim(), Conn)
                        If Reason = "VALID" Then

                            Reason = _objBusi.CheckValidation("DC", dr(0).ToString.Trim(), dr(1).ToString.Trim(), sDcode, dr(3).ToString.Trim(), Conn)
                            If Reason = "VALID DC" Then

                                Reason = _objBusi.CheckValidation("DA", dr(0).ToString.Trim(), dr(1).ToString.Trim(), sDcode, dr(3).ToString.Trim(), Conn)
                                If Reason = "VALID DA" Then

                                    Reason = _objBusi.CheckValidation("", dr(0).ToString.Trim(), dr(1).ToString.Trim(), sDcode, dr(3).ToString.Trim(), Conn)
                                    If Reason = "VALID" Then
                                        sRes = _objBusi.InsMothlyDedution(dr(0).ToString.Trim(), dr(1).ToString.Trim(), sDcode, dr(3).ToString.Trim(), dr(4).ToString.Trim(), Conn)
                                        rCount += 1
                                    Else
                                        sRes = "RECORD EXISTS"
                                    End If
                                Else
                                    If Reason = "EXISTS" Then
                                        sRes = "RECORD EXISTS"
                                    Else
                                        Dim rAmt, rvAmt, sAmt As Double
                                        rAmt = dtChk.Rows(0)("deduction_amount").ToString.Trim()
                                        rvAmt = dr(3)
                                        If rvAmt > rAmt Then
                                            _objBusi.fINPremiumProcess("INSERT", Guid.NewGuid.ToString.Trim(), "SHORTFALL", dtChk.Rows(0)("ID").ToString.Trim(), dr(1), dr(4), rAmt, rvAmt, sAmt, "OTHERS", "SHORTFALL", Conn) 'Suspend Account
                                        Else
                                            sAmt = rAmt - rvAmt
                                            sRes = _objBusi.InsMothlyDedution(dr(0).ToString.Trim(), dr(1).ToString.Trim(), sDcode, dr(3).ToString.Trim(), dr(4).ToString.Trim(), Conn)
                                            _objBusi.fINPremiumProcess("INSERT", Guid.NewGuid.ToString.Trim(), "SHORTFALL", dtChk.Rows(0)("ID").ToString.Trim(), dr(1), dr(4), rAmt, rvAmt, sAmt, "OTHERS", "SHORTFALL", Conn) 'Suspend Account
                                        End If
                                        sRes = "WRONG DEDUCTION AMOUNT"
                                    End If
                                    
                                End If
                            Else
                                _objBusi.fINPremiumProcess("INSERT", dr(0), dr(1), sDcode, dr(3), "OTHERS", dr(4), "", "", "", "KIV", Conn) 'Suspend Account
                                sRes = "WRONG DEDUCTION CODE"
                            End If
                        Else
                            sRes = "WRONG IC"
                        End If
                    Else
                        sRes = "Unpresented receiving month"
                    End If
                Else

                    sRes = "Unpresented deduction month"
                End If
                If dm = "" Then
                    dm = dr(1)
                End If

                xWB.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 4).ToString.Trim
                xWB.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = "'" & dr(0)
                xWB.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = "'" & dr(1)
                xWB.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = "'" & dr(2)
                xWB.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & dr(3)
                If sRes = "Done" Then
                    xWB.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & sRes
                Else
                    xWB.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & sRes
                End If
            End If
            xls_row_counter += 1
            iCount += 1
        Next
        rowCount = rCount
        Me.txtFileName.Text = ""
        xApp.Visible = True
        Me.Close()
    End Function
    Private Function validateDate(ByVal strDate As String) As Boolean
        Dim yr As String = strDate.Substring(0, 4)
        If CInt(yr) < 1900 Then Return False
        Dim mon As String = strDate.Substring(4, 2)
        Dim day As String = "14"
        Try
            Dim d As Date = New Date(CInt(yr), CInt(mon), CInt(day))
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Shared Function BindData(ByVal SourceFilePath As String) As DataTable
        Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & SourceFilePath & ";Extended Properties=Excel 8.0;"
        Using cn As New OleDb.OleDbConnection(ConnectionString)
            cn.Open()
            Dim dbSchema As DataTable = cn.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)
            If dbSchema Is Nothing OrElse dbSchema.Rows.Count < 1 Then
                Throw New Exception("Error: Could not determine the name of the first worksheet.")
            End If
            Dim WorkSheetName As String = dbSchema.Rows(0)("TABLE_NAME").ToString()
            Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [" & WorkSheetName & "] ", cn)
            Dim dt As New DataTable(WorkSheetName)
            da.Fill(dt)
            Return dt
        End Using
    End Function
    Private Sub Xport2Xcel(ByVal dt As DataTable, ByVal D_Month As String)
        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_wb As Microsoft.Office.Interop.Excel.Workbook
        xls_wb = xls_file.Workbooks.Add
        Dim xls_wks_name As String = ""
        xls_wb.Worksheets.Add()
        xls_wks_name = "Sheet" & xls_wb.Worksheets.Count.ToString.Trim

        With xls_wb.Worksheets(xls_wks_name)
            .Cells(1, 1) = "PROCESSING MONTHLY SALARY DEDUCTION (SIRIM/FAMA/OTHERS)"
            .Cells(2, 1) = "SALARY DEDUCTION MONTH : " & D_Month

            .Cells(4, 1) = "NO"
            .Cells(4, 2) = "IC #"
            .Cells(4, 3) = "DEDUCTION MONTH"
            .Cells(4, 4) = "DEDUCTION CODE"
            .Cells(4, 5) = "DEDUCTION AMOUNT"
        End With
        Dim xls_row_counter As Integer = 5
        Dim iCount As Integer = 0
        For Each dr As DataRow In dt.Rows
            If iCount > 0 Then
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 4).ToString.Trim
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = "'" & dr(0)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = "'" & dr(1)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = "'" & dr(2)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & dr(3)
            End If
            xls_row_counter += 1
            iCount += 1
        Next
        xls_file.Visible = True
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.txtFileName.Text = ""
        Me.Close()
    End Sub
#Region "Progress Bar"
    Private Shared SharedData As New SharedObject()
    Protected Overridable Sub StartMarqueeThread()
        Dim t As New Threading.Thread(AddressOf ShowMarqueeForm)
        t.Start()
    End Sub
    Protected Overridable Sub ShowMarqueeForm()
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