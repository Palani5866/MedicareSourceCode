Public Class UPLOAD
    
    Dim Conn As DbConnection = New SqlConnection()
    Dim _objBusi As New Business
    Private Sub UPLOAD_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then

            Conn.Close()
        End If
    End Sub
    Private Sub UPLOAD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

        InsPremiumData()
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


        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_wb As Microsoft.Office.Interop.Excel.Workbook
        xls_wb = xls_file.Workbooks.Add
        Dim xls_wks_name As String = ""
        xls_wb.Worksheets.Add()
        xls_wks_name = "Sheet" & xls_wb.Worksheets.Count.ToString.Trim

        With xls_wb.Worksheets(xls_wks_name)
            .Cells(1, 1) = "UPLOADING MEMBER DEPENDENTS DETAILS"
            .Cells(2, 1) = "MEMBERE DEPENDENTS : 201202"

            .Cells(4, 1) = "NO"
            .Cells(4, 2) = "#"
            .Cells(4, 3) = "NAME"
            .Cells(4, 4) = "POLICY # "
            .Cells(4, 5) = "IC #"
            .Cells(4, 6) = "Status"
        End With
        Dim rCount As Integer = 0
        Dim xls_row_counter As Integer = 5
        Dim Reason As String

        For Each dr As DataRow In dt.Rows
            If iCount > 0 Then
                Dim dtM As DataTable
                Dim ic As String
                ic = iCount
                dtM = _objBusi.getProposerDetails(dr(2).ToString.Trim())
                If dtM.Rows.Count > 0 Then

                    If Not IsDBNull(dr(4)) Then
                        Dim sRes1, sRes2, sRes3, sRes4 As String
                        Dim DOB As String
                        If Not IsDBNull(dr(6)) Then
                            DOB = Format(Convert.ToDateTime(dr(6)), "MM/dd/yyyy")
                        Else
                            DOB = Format(Now, "MM/dd/yyyy")
                        End If
                        
                        Dim sqlCmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                        sqlCmd.CommandText = "INSERT INTO DT_MEMBER_POLICY_DEPENDENTS (ID, MEMBER_POLICY_ID, FULL_NAME, IC_NEW, BIRTH_DATE, Relationship, Created_by, Created_on) VALUES ('" & _
                                            Guid.NewGuid.ToString & "', '" & dtM.Rows(0)("ID").ToString.Trim() & "', '" & dr(4) & "', '" & dr(5).ToString.Replace("-", "") & "', '" & DOB & "', '" & dr(7) & "', 'SRI', '" & Format(Now, "MM/dd/yyyy") & "')"
                        sqlCmd.CommandType = CommandType.Text
                        sRes = sqlCmd.ExecuteNonQuery
                    End If


                    If Not IsDBNull(dr(8)) Then
                        Dim DOB As String
                        If Not IsDBNull(dr(10)) Then
                            DOB = Format(Convert.ToDateTime(dr(10)), "MM/dd/yyyy")
                        Else
                            DOB = Format(Now, "MM/dd/yyyy")
                        End If
                        Dim sqlCmd1 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                        sqlCmd1.CommandText = "INSERT INTO DT_MEMBER_POLICY_DEPENDENTS (ID, MEMBER_POLICY_ID, FULL_NAME, IC_NEW, BIRTH_DATE, Relationship, Created_by, Created_on) VALUES ('" & _
                                            Guid.NewGuid.ToString & "', '" & dtM.Rows(0)("ID").ToString.Trim() & "', '" & dr(8) & "', '" & dr(9).ToString.Replace("-", "") & "', '" & DOB & "', '" & dr(11) & "', 'SRI', '" & Now & "')"
                        sqlCmd1.CommandType = CommandType.Text
                        sRes = sqlCmd1.ExecuteNonQuery
                    End If
                    

                    If Not IsDBNull(dr(12)) Then
                        Dim DOB As String
                        If Not IsDBNull(dr(14)) Then
                            DOB = Format(Convert.ToDateTime(dr(14)), "MM/dd/yyyy")
                        Else
                            DOB = Format(Now, "MM/dd/yyyy")
                        End If
                        
                        Dim sqlCmd2 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                        sqlCmd2.CommandText = "INSERT INTO DT_MEMBER_POLICY_DEPENDENTS (ID, MEMBER_POLICY_ID, FULL_NAME, IC_NEW, BIRTH_DATE, Relationship, Created_by, Created_on) VALUES ('" & _
                                            Guid.NewGuid.ToString & "', '" & dtM.Rows(0)("ID").ToString.Trim() & "', '" & dr(12) & "', '" & dr(13).ToString.Replace("-", "") & "', '" & DOB & "', '" & dr(15) & "', 'SRI', '" & Now & "')"
                        sqlCmd2.CommandType = CommandType.Text
                        sRes = sqlCmd2.ExecuteNonQuery
                    End If


                    If Not IsDBNull(dr(16)) Then
                        Dim DOB As String
                        If Not IsDBNull(dr(18)) Then
                            DOB = Format(Convert.ToDateTime(dr(18)), "MM/dd/yyyy")
                        Else
                            DOB = Format(Now, "MM/dd/yyyy")
                        End If
                        Dim sqlCmd4 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                        sqlCmd4.CommandText = "INSERT INTO DT_MEMBER_POLICY_DEPENDENTS (ID, MEMBER_POLICY_ID, FULL_NAME, IC_NEW, BIRTH_DATE, Relationship, Created_by, Created_on) VALUES ('" & _
                                            Guid.NewGuid.ToString & "', '" & dtM.Rows(0)("ID").ToString.Trim() & "', '" & dr(16) & "', '" & dr(17).ToString.Replace("-", "") & "', '" & DOB & "', '" & dr(19) & "', 'SRI', '" & Now & "')"
                        sqlCmd4.CommandType = CommandType.Text
                        sRes = sqlCmd4.ExecuteNonQuery
                    End If
                    

                    If Not IsDBNull(dr(20)) Then
                        Dim DOB As String
                        If Not IsDBNull(dr(22)) Then
                            DOB = Format(Convert.ToDateTime(dr(22)), "MM/dd/yyyy")
                        Else
                            DOB = Format(Now, "MM/dd/yyyy")
                        End If
                        Dim sqlCmd5 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                        sqlCmd5.CommandText = "INSERT INTO DT_MEMBER_POLICY_DEPENDENTS (ID, MEMBER_POLICY_ID, FULL_NAME, IC_NEW, BIRTH_DATE, Relationship, Created_by, Created_on) VALUES ('" & _
                                            Guid.NewGuid.ToString & "', '" & dtM.Rows(0)("ID").ToString.Trim() & "', '" & dr(20) & "', '" & dr(21).ToString.Replace("-", "") & "', '" & DOB & "', '" & dr(23) & "', 'SRI', '" & Now & "')"
                        sqlCmd5.CommandType = CommandType.Text
                        sRes = sqlCmd5.ExecuteNonQuery
                    End If
                    

                    If Not IsDBNull(dr(24)) Then
                        Dim DOB As String
                        If Not IsDBNull(dr(26)) Then
                            DOB = Format(Convert.ToDateTime(dr(26)), "MM/dd/yyyy")
                        Else
                            DOB = Format(Now, "MM/dd/yyyy")
                        End If
                        Dim sqlCmd6 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                        sqlCmd6.CommandText = "INSERT INTO DT_MEMBER_POLICY_DEPENDENTS (ID, MEMBER_POLICY_ID, FULL_NAME, IC_NEW, BIRTH_DATE, Relationship, Created_by, Created_on) VALUES ('" & _
                                            Guid.NewGuid.ToString & "', '" & dtM.Rows(0)("ID").ToString.Trim() & "', '" & dr(24) & "', '" & dr(25).ToString.Replace("-", "") & "', '" & DOB & "', '" & dr(27) & "', 'SRI', '" & Now & "')"
                        sqlCmd6.CommandType = CommandType.Text
                        sRes = sqlCmd6.ExecuteNonQuery
                    End If


                    If Not IsDBNull(dr(28)) Then
                        Dim DOB As String
                        If Not IsDBNull(dr(30)) Then
                            DOB = Format(Convert.ToDateTime(dr(30)), "MM/dd/yyyy")
                        Else
                            DOB = Format(Now, "MM/dd/yyyy")
                        End If
                        Dim sqlCmd7 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                        sqlCmd7.CommandText = "INSERT INTO DT_MEMBER_POLICY_DEPENDENTS (ID, MEMBER_POLICY_ID, FULL_NAME, IC_NEW, BIRTH_DATE, Relationship, Created_by, Created_on) VALUES ('" & _
                                            Guid.NewGuid.ToString & "', '" & dtM.Rows(0)("ID").ToString.Trim() & "', '" & dr(28) & "', '" & dr(29).ToString.Replace("-", "") & "', '" & DOB & "', '" & dr(31) & "', 'SRI', '" & Now & "')"
                        sqlCmd7.CommandType = CommandType.Text
                        sRes = sqlCmd7.ExecuteNonQuery
                    End If
                    rCount += 1
                Else
                    sRes = "POLICY EXPIRY"
                End If

                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 4).ToString.Trim
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = "'" & dr(0)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = "'" & dr(1)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = "'" & dr(2)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & dr(3)
                If sRes = "Done" Then
                    xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & sRes
                Else
                    xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & sRes
                End If
            End If
            xls_row_counter += 1
            iCount += 1
        Next
        MsgBox("No of Record : " & rCount & " Sucessfuly Uploaded")
        Me.txtFileName.Text = ""
        Me.Close()
        xls_file.Visible = True
    End Function
    Private Function InsPremiumData() As String

        If Me.txtFileName.Text.Trim() = "" Then
            MsgBox("Required file")
            Exit Function
        End If
        Dim dt As New DataTable

        dt = BindData(Me.txtFileName.Text)
        Dim sRes As String

        Dim iCount As Integer = 0
        Dim dm As String = ""


        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_wb As Microsoft.Office.Interop.Excel.Workbook
        xls_wb = xls_file.Workbooks.Add
        Dim xls_wks_name As String = ""
        xls_wb.Worksheets.Add()
        xls_wks_name = "Sheet" & xls_wb.Worksheets.Count.ToString.Trim

        With xls_wb.Worksheets(xls_wks_name)
            .Cells(1, 1) = "PREMIUM REQUEST TABLE INSERT AND UPDATE"
            .Cells(2, 1) = "PREMIUM"

            .Cells(4, 1) = "NO"
            .Cells(4, 2) = "FILE #"
            .Cells(4, 3) = "IC #"
            .Cells(4, 4) = "NAME"
            .Cells(4, 5) = "PLAN TYPE"
            .Cells(4, 6) = "START DATE"
            .Cells(4, 7) = "PREMIUM"
            .Cells(4, 8) = "RESULT"
        End With
        Dim rCount As Integer = 0
        Dim xls_row_counter As Integer = 5

        For Each dr As DataRow In dt.Rows
            If iCount > 0 Then
                Try
                    sRes = _objBusi.fINUPPREMIUMREQUEST413M("", dr(0), dr(1), dr(4), Format(Convert.ToDateTime(dr(5)), "MM/dd/yyyy"), dr(10), dr(9), dr(8), dr(7), dr(6), "OLD", Conn)
                Catch ex As Exception
                    MsgBox("Error while uploading " + dr(0).ToString() + " " + dr(1).ToString() + " " + dr(4).ToString() + " " + ex.StackTrace)
                End Try

                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 4).ToString.Trim
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = "'" & dr(0)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = "'" & dr(1)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = "'" & dr(2)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & dr(4)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & dr(5)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "'" & dr(10)
                xls_wb.Worksheets(xls_wks_name).Cells(xls_row_counter, 8) = "'" & sRes
            End If
            xls_row_counter += 1
            iCount += 1
        Next
        MsgBox("No of Record : " & rCount & " Sucessfuly Uploaded")
        Me.txtFileName.Text = ""
        Me.Close()
        xls_file.Visible = True
    End Function
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.txtFileName.Text = ""
        Me.Close()
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


End Class