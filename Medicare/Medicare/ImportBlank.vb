Public Class ImportBlank
   
#Region "Global Variables"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
    Private Sub ImportBlank_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub ImportBlank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
        InsXportData()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.txtFileName.Text = ""
        Me.Close()
    End Sub
    Private Function InsXportData() As String
        Try

            If Me.txtFileName.Text.Trim() = "" Then
                MsgBox("Required file")
                Exit Function
            End If
            Dim dt As New DataTable

            dt = BindData(Me.txtFileName.Text)
            Dim sRes As String

            Dim iCount As Integer = 0
            Dim dm As String = ""

            For Each dr As DataRow In dt.Rows
                If iCount > 2 Then
                    Dim P1, P2, P3 As String
                    Select Case Me.lblType.Text.Trim.Trim
                        Case "MEMBER"
                            Select Case Me.lblUType.Text.Trim
                                Case "DOB"
                                    If Not IsDBNull(dr(3)) Then
                                        P1 = dr(3)
                                    Else
                                        P1 = ""
                                    End If
                                    If Not IsDBNull(dr(1)) Then
                                        sRes = _objBusi.UpdateBLANK("MEMBER", "DOB", dr(1), P1, "", "", "", Conn)
                                    End If
                                Case "PHONE"
                                    If Not IsDBNull(dr(4)) Then
                                        P1 = dr(4)
                                    Else
                                        P1 = ""
                                    End If
                                    If Not IsDBNull(dr(5)) Then
                                        P2 = dr(5)
                                    Else
                                        P2 = ""
                                    End If
                                    If Not IsDBNull(dr(6)) Then
                                        P3 = dr(6)
                                    Else
                                        P3 = ""
                                    End If
                                    If Not IsDBNull(dr(1)) Then
                                        sRes = _objBusi.UpdateBLANK("MEMBER", "PHONE", dr(1), P1, P2, P3, "", Conn)
                                    End If
                            End Select
                        Case "SPOUSE"
                            Select Case Me.lblUType.Text.Trim
                                Case "IC"
                                    If Not IsDBNull(dr(3)) Then
                                        P1 = dr(3).ToString.Replace("'", "")
                                    Else
                                        P1 = ""
                                    End If
                                    If Not IsDBNull(dr(7)) Then
                                        P2 = dr(7)
                                    Else
                                        P2 = ""
                                    End If
                                    If Not IsDBNull(dr(1)) Then
                                        sRes = _objBusi.UpdateBLANK("SPOUSE", "IC", dr(1), P1, P2, dr(4).ToString.Trim(), "", Conn)
                                    End If
                                Case "DOB"
                                    If Not IsDBNull(dr(6)) Then
                                        P1 = dr(6)
                                    Else
                                        P1 = ""
                                    End If
                                    If Not IsDBNull(dr(1)) Then
                                        sRes = _objBusi.UpdateBLANK("SPOUSE", "DOB", dr(3), P1, dr(4).ToString.Trim(), "", "", Conn)
                                    End If
                            End Select
                        Case "DEP"
                            Select Case Me.lblUType.Text.Trim
                                Case "IC"
                                    If Not IsDBNull(dr(3)) Then
                                        P1 = dr(3).ToString.Replace("'", "")
                                    Else
                                        P1 = ""
                                    End If
                                    If Not IsDBNull(dr(7)) Then
                                        P2 = dr(7).ToString.Replace("'", "").Trim()
                                    Else
                                        P2 = ""
                                    End If
                                    If Not IsDBNull(dr(1)) Then
                                        sRes = _objBusi.UpdateBLANK("DEP", "IC", dr(1), P1, P2, dr(4).ToString.Trim(), "", Conn)
                                    End If

                                Case "DOB"
                                    If Not IsDBNull(dr(6)) Then
                                        P2 = dr(6)
                                    Else
                                        P2 = ""
                                    End If
                                    If Not IsDBNull(dr(1)) Then
                                        sRes = _objBusi.UpdateBLANK("DEP", "DOB", dr(3), P2, dr(4).ToString.Trim(), "", "", Conn)
                                    End If
                            End Select
                    End Select
                End If
                iCount += 1
            Next
            If sRes = "1" Then
                MsgBox("Sucessfuly Uploaded")
                Me.txtFileName.Text = ""
                Me.Close()
            Else
                MsgBox("Error while uploading! Please check the excel sheet name and try again!")
                Me.txtFileName.Text = ""
                Me.btnBrowse.Focus()
            End If
        Catch ex As Exception
            MsgBox("Invalid rows,Please check the excel sheet and try again!")
            Me.txtFileName.Text = ""
            Me.btnBrowse.Focus()
        End Try
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