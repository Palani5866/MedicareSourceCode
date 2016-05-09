Public Class fMemberIDUP
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub fMemberIDUP_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fMemberIDUP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
#Region "Data Bind"
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
#End Region
#Region "Click Events"
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
        uploadMemberID()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region
#Region "General Functions/Subs"
    Private Sub Up()
        Dim fNames As String()
        fNames = System.IO.Directory.GetFiles("C:\SRI\CLIENTIDUP\SRI TEST\")
        If fNames.Length > 0 Then
            Dim fCount As Integer = 0
            Do While fCount < fNames.Length
                DynamicInsXportData(fNames(fCount))
                fCount += 1
            Loop
        End If
    End Sub
    Private Function DynamicInsXportData(ByVal fName As String) As String
        If fName = "" Then
            MsgBox("Can not find the file")
            Exit Function
        End If
        Dim dt As New DataTable
        dt = BindData(fName)
        Dim sRes As String

        Dim iCount As Integer = 0
        Dim dm As String = ""

        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWName As String = ""
        xWB.Worksheets.Add()
        xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

        With xWB.Worksheets(xWName)
            .Cells(1, 1) = "UPLOADING CLIENT ID's"

            .Cells(4, 1) = "NO"
            .Cells(4, 2) = "CLIENT ID "
            .Cells(4, 3) = "IC #"
            .Cells(4, 4) = "FULL NAME"
            .Cells(4, 5) = "FAMILY UNIT"
            .Cells(4, 6) = "CERTIFICATE NO"
            .Cells(4, 7) = "Remarks"
        End With
        Dim rCount As Integer = 0
        Dim xRowCount As Integer = 5
        Dim certM, MemIC As String

        For Each dr As DataRow In dt.Rows
            If iCount >= 0 Then
                If dr(7).ToString.Trim() = "M" Then
                    certM = dr(37).ToString.Trim()
                    MemIC = dr(9).ToString.Trim()
                Else
                    certM = certM
                    MemIC = MemIC
                End If
                MsgBox("Test" & certM)
                If certM.Trim = "" Then
                    certM = "temp"
                    MsgBox("Test" & certM)
                End If
                If IsNothing(MemIC.Trim()) Then
                    MemIC = "temp"
                End If
                xWB.Worksheets(xWName).Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                xWB.Worksheets(xWName).Cells(xRowCount, 2) = "'" & dr(3)
                xWB.Worksheets(xWName).Cells(xRowCount, 3) = "'" & dr(9)
                xWB.Worksheets(xWName).Cells(xRowCount, 4) = "'" & dr(8)
                xWB.Worksheets(xWName).Cells(xRowCount, 5) = "'" & dr(7)
                xWB.Worksheets(xWName).Cells(xRowCount, 6) = "'" & certM
                sRes = _objBusi.spUpdate("CLIENTNO", dr(3).ToString.Trim(), dr(7).ToString.Trim(), dr(8).ToString.Trim(), dr(9).ToString.Trim(), certM, MemIC, "", "", "", "", Conn)
                xWB.Worksheets(xWName).Cells(xRowCount, 7) = "'" & sRes
            End If
            xRowCount += 1
            iCount += 1
            rCount += 1
        Next
        MsgBox("No of Record : " & rCount & " Sucessfuly Uploaded")
        xApp.Visible = True
    End Function
#End Region
#Region "Upload"
    Private Function uploadMemberID() As String
        If Me.txtFileName.Text.Trim() = "" Then
            MsgBox("Required file")
            Exit Function
        End If
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim dt As New DataTable
        dt = BindData(Me.txtFileName.Text)
        Dim sRes As String
        Dim iCount As Integer = 0
        Dim dm As String = ""
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWName As String = ""
        xWB.Worksheets.Add()
        xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

        With xWB.Worksheets(xWName)
            .Cells(1, 1) = "UPLOADING CLIENT ID's"

            .Cells(4, 1) = "NO"
            .Cells(4, 2) = "CLIENT ID"
            .Cells(4, 3) = "IC #"
            .Cells(4, 4) = "FULL NAME"
            .Cells(4, 5) = "FAMILY UNIT"
            .Cells(4, 6) = "CERTIFICATE NO"
            .Cells(4, 7) = "Remarks"
        End With
        Dim rCount As Integer = 0
        Dim xRowCount As Integer = 5
        Dim certM, MemIC, MemName, PIC As String
        For Each dr As DataRow In dt.Rows
            If iCount >= 0 Then
                If dr(7).ToString.Trim() = "M" Then
                    certM = dr(37).ToString.Trim()
                    If dr(9).ToString.Trim().Length() > 11 Then
                        MemIC = "C" + dr(9).ToString.Trim().Replace("'", "")
                        PIC = "C" + dr(9).ToString.Trim().Replace("'", "")
                    Else
                        MemIC = dr(9).ToString.Trim().Replace("'", "")
                        PIC = dr(9).ToString.Trim().Replace("'", "")
                    End If
                    MemName = dr(8).ToString.Trim()
                Else
                    certM = certM
                    MemIC = MemIC
                    MemName = MemName
                    PIC = dr(9).ToString.Trim().Replace("'", "")
                End If
                xWB.Worksheets(xWName).Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                xWB.Worksheets(xWName).Cells(xRowCount, 2) = "'" & dr(3)
                xWB.Worksheets(xWName).Cells(xRowCount, 3) = "'" & dr(9)
                xWB.Worksheets(xWName).Cells(xRowCount, 4) = "'" & dr(8)
                xWB.Worksheets(xWName).Cells(xRowCount, 5) = "'" & dr(7)
                xWB.Worksheets(xWName).Cells(xRowCount, 6) = "'" & certM
                sRes = _objBusi.fMEMBERID("MEMBERID", dr(3).ToString.Trim().Replace("'", ""), dr(7).ToString.Trim(), dr(8).ToString.Trim(), PIC, dr(37).ToString.Trim(), MemIC, MemName, certM, "", "", "", "", "", "", My.Settings.Username.Trim, Conn)
                xWB.Worksheets(xWName).Cells(xRowCount, 7) = "'" & sRes
            End If
            xRowCount += 1
            iCount += 1
            rCount += 1
        Next
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        Me.txtFileName.Text = ""
        xApp.Visible = True
    End Function
    Private Function InsXportData() As String
        If Me.txtFileName.Text.Trim() = "" Then
            MsgBox("Required file")
            Exit Function
        End If
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim dt As New DataTable
        dt = BindData(Me.txtFileName.Text)
        Dim sRes As String
        Dim iCount As Integer = 0
        Dim dm As String = ""
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWName As String = ""
        xWB.Worksheets.Add()
        xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
        With xWB.Worksheets(xWName)
            .Cells(1, 1) = "UPLOADING CLIENT ID's"

            .Cells(4, 1) = "NO"
            .Cells(4, 2) = "CLIENT ID "
            .Cells(4, 3) = "IC #"
            .Cells(4, 4) = "FULL NAME"
            .Cells(4, 5) = "FAMILY UNIT"
            .Cells(4, 6) = "CERTIFICATE NO"
            .Cells(4, 7) = "Remarks"
        End With
        Dim rCount As Integer = 0
        Dim xRowCount As Integer = 5
        Dim certM, MemIC As String
        For Each dr As DataRow In dt.Rows
            If iCount >= 0 Then
                certM = ""
                MemIC = ""
                If dr(7).ToString.Trim() = "M" Then
                    certM = dr(37).ToString.Trim()
                    MemIC = dr(9).ToString.Trim()
                Else
                    certM = certM
                    MemIC = MemIC
                End If
                If certM.ToString.Trim() = "" Then
                    If dr(7).ToString.Trim() = "D" Then
                        certM = dr(37).ToString.Trim()
                    End If
                End If
                xWB.Worksheets(xWName).Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                xWB.Worksheets(xWName).Cells(xRowCount, 2) = "'" & dr(3)
                xWB.Worksheets(xWName).Cells(xRowCount, 3) = "'" & dr(9)
                xWB.Worksheets(xWName).Cells(xRowCount, 4) = "'" & dr(8)
                xWB.Worksheets(xWName).Cells(xRowCount, 5) = "'" & dr(7)
                xWB.Worksheets(xWName).Cells(xRowCount, 6) = "'" & certM
                sRes = _objBusi.spUpdate("CLIENTNO", dr(3).ToString.Trim(), dr(7).ToString.Trim(), dr(8).ToString.Trim(), dr(9).ToString.Trim(), certM, MemIC, "", "", "", "", Conn)
                xWB.Worksheets(xWName).Cells(xRowCount, 7) = "'" & sRes
            End If
            xRowCount += 1
            iCount += 1
            rCount += 1
        Next
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        MsgBox("No of Record : " & rCount & " Sucessfuly Uploaded")
        Me.txtFileName.Text = ""
        Me.Close()
        xApp.Visible = True
    End Function
#End Region
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