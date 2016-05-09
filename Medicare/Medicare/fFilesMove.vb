Public Class fFilesMove
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
        fvClientID()
    End Sub
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
    Private Sub fvClientID()
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim dt As New DataTable
        dt = BindData(Me.txtFileName.Text)
        Dim iCount As Integer = 0
        Dim dm As String = ""
        Dim rCount As Integer = 0
        Dim _FNames As String()
        Dim _vNumber As Integer
        _FNames = System.IO.Directory.GetFiles("K:\BASF PETRONAS\BCP DOC'S SCANING\INDEX COMPLETED - Copy\VENDOR MASTER")
        Dim batch_no As String = ""
        If _FNames.Length > 0 Then
            Dim _FCounter As Integer = 0
            Do While _FCounter < _FNames.Length

                For Each dr As DataRow In dt.Rows
                    If iCount >= 0 Then
                        Dim sFileName, dFileName As String
                        sFileName = dr(0).ToString.Trim()
                        dFileName = System.IO.Path.GetFileName(_FNames(_FCounter).ToString)
                        If sFileName = dFileName Then
                            System.IO.File.Move(_FNames(_FCounter).ToString, "H:\TEMP\DIS\" & System.IO.Path.GetFileName(_FNames(_FCounter).ToString))
                        End If
                    End If
                    iCount += 1
                    rCount += 1
                Next

                _FCounter += 1
                _vNumber += 1
            Loop
        End If
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()

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