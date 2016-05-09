Public Class UploadCID
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub UploadCID_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub UploadCID_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Up()
    End Sub
    Private Sub Up()
        Dim fNames As String()
        fNames = System.IO.Directory.GetFiles("C:\SRI\CLIENTIDUP\SRI TEST\Final\")

        If fNames.Length > 0 Then
            Dim fCount As Integer = 0
            Do While fCount < fNames.Length

                DynamicInsXportDataTemp(fNames(fCount))
                fCount += 1
            Loop
        End If
    End Sub
    Private Function DynamicInsXportDataTemp(ByVal fName As String) As String

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
        
                certM = dr(5).ToString.Trim()
                MemIC = dr(2).ToString.Trim()
               
                xWB.Worksheets(xWName).Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                xWB.Worksheets(xWName).Cells(xRowCount, 2) = "'" & dr(1)
                xWB.Worksheets(xWName).Cells(xRowCount, 3) = "'" & dr(2)
                xWB.Worksheets(xWName).Cells(xRowCount, 4) = "'" & dr(3)
                xWB.Worksheets(xWName).Cells(xRowCount, 5) = "'" & dr(4)
                xWB.Worksheets(xWName).Cells(xRowCount, 6) = "'" & certM
                sRes = _objBusi.spUpdate("CLIENTNO", dr(1).ToString.Trim(), dr(4).ToString.Trim(), dr(3).ToString.Trim(), dr(2).ToString.Trim(), certM, MemIC, "", "", "", "", Conn)
                xWB.Worksheets(xWName).Cells(xRowCount, 7) = "'" & sRes
            End If
            xRowCount += 1
            iCount += 1
            rCount += 1
        Next
       
        xApp.Visible = True
    End Function
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
       
        xApp.Visible = True
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
End Class