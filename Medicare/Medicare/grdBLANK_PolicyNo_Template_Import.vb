Public Class grdBLANK_PolicyNo_Template_Import
    Dim Conn As DbConnection = New SqlConnection
    Dim Remark As String = ""
    Dim _objBusi As New Business
    Private Sub grdBLANK_PolicyNo_Template_Import_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub grdBLANK_PolicyNo_Template_Import_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tstxtPPDate.Text = Format(Now(), "dd/MM/yyyy")
        Me.tstxtPEDate.Text = Format(Now(), "dd/MM/yyyy")

        Me.Text = "Import/Upload Template: BLANK Policy/Certificate No"
        
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
    Private Sub tsReport_File_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_File_Open.Click
        With Me.ofdCert2Upload
            .InitialDirectory = "C:\"
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Dim myfile As New System.IO.FileInfo(.FileName)
                Dim dt As New DataTable
                dt = BindData(myfile.FullName)
                If dt.Rows.Count > 0 Then
                    Me.dgvForm.DataSource = dt
                Else
                    MsgBox("No Record found on selected source! Please check it!")
                    Me.dgvForm.DataSource = dt
                End If
            End If
        End With
    End Sub
    Private Function CsvToTable(ByVal filePathName As String, Optional ByVal hasHeader As Boolean = False) As DataTable

        Try
            Dim result As New DataTable
            If System.IO.File.Exists(filePathName) Then
                Dim parser As New Microsoft.VisualBasic.FileIO.TextFieldParser(filePathName)
                parser.Delimiters = New String() {","}
                parser.HasFieldsEnclosedInQuotes = True
                parser.TextFieldType = FileIO.FieldType.Delimited
                parser.TrimWhiteSpace = True
                Dim HeaderFlag As Boolean
                If hasHeader Then HeaderFlag = True
                While Not parser.EndOfData
                    If AddValuesToTable(parser.ReadFields, result, HeaderFlag) Then
                        HeaderFlag = False
                    Else
                        parser.Close()
                        Return Nothing
                    End If
                End While
                parser.Close()
                Return result
            Else : Return Nothing
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
            Return Nothing
        End Try
    End Function
    Private Function AddValuesToTable(ByRef source() As String, ByVal destination As DataTable, Optional ByVal HeaderFlag As Boolean = False) As Boolean
        Try
            Dim existing As Integer = destination.Columns.Count
            If HeaderFlag Then
                Resolve_Duplicate_Names(source)
                For i As Integer = 0 To source.Length - existing - 1
                    destination.Columns.Add(source(i).ToString, GetType(String))
                Next i
                Return True
            End If
            For i As Integer = 0 To source.Length - existing - 1
                destination.Columns.Add("Column" & (existing + 1 + i).ToString, GetType(String))
            Next
            destination.Rows.Add(source)
            Return True
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
            Return False
        End Try
    End Function
    Private Sub Resolve_Duplicate_Names(ByRef source() As String)
        Dim i, n, dnum As Integer
        dnum = 1
        For n = 0 To source.Length - 1
            For i = n + 1 To source.Length - 1
                If source(i) = source(n) Then
                    source(i) = source(i) & "Duplicate Name " & dnum
                    dnum += 1
                End If
            Next
        Next
        Return
    End Sub
    Private Sub tsReport_Import_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Import.Click
        If Len(Me.tstxtPEDate.Text.Trim) = 0 Then
            MsgBox("Please do key in the Policy No's Effective Date (dd/mm/yyyy).")
            Me.tstxtPEDate.Focus()
            Exit Sub
        End If

        If IsDate(Me.tstxtPEDate.Text) = False Then
            MsgBox("Please do key in the Policy No's Effective Date in the right format (dd/mm/yyyy).")
            Me.tstxtPEDate.Focus()
            Exit Sub
        End If
        If Me.dgvForm.RowCount > 0 Then
            Dim response As MsgBoxResult = MsgBox("Do you want to proceed with the UPLOAD?", MsgBoxStyle.OkCancel, "Upload Certificate/Policy No")
            If response = MsgBoxResult.Cancel Then
                MsgBox("Cancel upload process.")
                Me.dgvForm.DataSource = Nothing
                Exit Sub
            Else
                Me.Upload_CertNo()
            End If
        Else
            MsgBox("No records to be uploaded.")
        End If
    End Sub
    Private Sub Upload_CertNo()
        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
        xls_workbook = xls_file.Workbooks.Add

        With xls_workbook.Worksheets(1)
            .Name = "Uploading Errors"

            .Columns(1).NumberFormat = "@"
            .Columns(2).NumberFormat = "@"
            .Columns(3).NumberFormat = "@"
            .Columns(4).NumberFormat = "@"
            .Columns(5).NumberFormat = "@"

            .Cells(1, 1) = "File No."
            .Cells(1, 2) = "Full Name"
            .Cells(1, 3) = "IC"
            .Cells(1, 4) = "Deduction Code"
            .Cells(1, 5) = "Remark"
        End With

        Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member.CommandType = CommandType.Text
        cmdSelect_Member.CommandText = "SELECT ID, Angkasa_FileNo, IC_New, Deduction_Code " & _
                                       "FROM vi_Member_Policy_v2"

        Dim da_Member As New SqlDataAdapter(cmdSelect_Member)


        Dim ds_SubmittedBatch As New DataSet
        da_Member.Fill(ds_SubmittedBatch, "vi_Member_Policy_v2")

        Dim dgvForm_count As Integer = 0
        Dim var_ReturnedRows As DataRow()
        Dim xls_row_index As Integer = 2

        With Me.dgvForm
            Do While dgvForm_count < .Rows.Count
                If Len(.Rows(dgvForm_count).Cells(2).Value.ToString.Trim) = 0 Then

                    With xls_workbook.Worksheets(1)
                        .Cells(xls_row_index, 1) = Me.dgvForm.Rows(dgvForm_count).Cells(0).Value.ToString
                        .Cells(xls_row_index, 2) = Me.dgvForm.Rows(dgvForm_count).Cells(1).Value.ToString
                        .Cells(xls_row_index, 3) = Me.dgvForm.Rows(dgvForm_count).Cells(2).Value.ToString
                        .Cells(xls_row_index, 4) = Me.dgvForm.Rows(dgvForm_count).Cells(3).Value.ToString
                        .Cells(xls_row_index, 5) = "IC Column is Blank."
                    End With
                    xls_row_index += 1
                Else
                    Dim var_FileNo As String = .Rows(dgvForm_count).Cells(0).Value.ToString.Replace("'", "''")

                    var_ReturnedRows = ds_SubmittedBatch.Tables("vi_Member_Policy_v2").Select("IC_New = '" & Me.Change_IC(.Rows(dgvForm_count).Cells(2).Value.ToString.Trim) & "' " & _
                                                                                              "AND Deduction_Code = '" & Me.Change_Deduction_Code(.Rows(dgvForm_count).Cells(3).Value.ToString.Trim) & "' " & _
                                                                                              "AND Angkasa_FileNo = '" & var_FileNo.Trim & "'")
                    Dim var_IC As String = Me.Change_IC(.Rows(dgvForm_count).Cells(2).Value.ToString.Trim)
                    Dim var_Deduction_Code As String = Me.Change_Deduction_Code(.Rows(dgvForm_count).Cells(3).Value.ToString.Trim)

                    Select Case var_ReturnedRows.Length
                        Case 0

                            With xls_workbook.Worksheets(1)
                                .Cells(xls_row_index, 1) = Me.dgvForm.Rows(dgvForm_count).Cells(0).Value.ToString
                                .Cells(xls_row_index, 2) = Me.dgvForm.Rows(dgvForm_count).Cells(1).Value.ToString
                                .Cells(xls_row_index, 3) = Me.dgvForm.Rows(dgvForm_count).Cells(2).Value.ToString
                                .Cells(xls_row_index, 4) = Me.dgvForm.Rows(dgvForm_count).Cells(3).Value.ToString
                                .Cells(xls_row_index, 5) = "Error: Record not found. (Table: vi_Member_Policy_v2)"
                            End With
                            xls_row_index += 1

                        Case 1

                            If UpdatePolicyNo_New(var_ReturnedRows(0).Item("ID").ToString.Trim, Me.dgvForm.Rows(dgvForm_count).Cells(5).Value.ToString) = False Then

                                With xls_workbook.Worksheets(1)
                                    .Cells(xls_row_index, 1) = Me.dgvForm.Rows(dgvForm_count).Cells(0).Value.ToString
                                    .Cells(xls_row_index, 2) = Me.dgvForm.Rows(dgvForm_count).Cells(1).Value.ToString
                                    .Cells(xls_row_index, 3) = Me.dgvForm.Rows(dgvForm_count).Cells(2).Value.ToString
                                    .Cells(xls_row_index, 4) = Me.dgvForm.Rows(dgvForm_count).Cells(3).Value.ToString
                                    .Cells(xls_row_index, 5) = Remark.Trim
                                End With
                                xls_row_index += 1
                            Else
                                With xls_workbook.Worksheets(1)
                                    .Cells(xls_row_index, 1) = Me.dgvForm.Rows(dgvForm_count).Cells(0).Value.ToString
                                    .Cells(xls_row_index, 2) = Me.dgvForm.Rows(dgvForm_count).Cells(1).Value.ToString
                                    .Cells(xls_row_index, 3) = Me.dgvForm.Rows(dgvForm_count).Cells(2).Value.ToString
                                    .Cells(xls_row_index, 4) = Me.dgvForm.Rows(dgvForm_count).Cells(3).Value.ToString
                                    .Cells(xls_row_index, 5) = Remark.Trim
                                End With
                                xls_row_index += 1
                            End If
                        Case Else

                With xls_workbook.Worksheets(1)
                    .Cells(xls_row_index, 1) = Me.dgvForm.Rows(dgvForm_count).Cells(0).Value.ToString
                    .Cells(xls_row_index, 2) = Me.dgvForm.Rows(dgvForm_count).Cells(1).Value.ToString
                    .Cells(xls_row_index, 3) = Me.dgvForm.Rows(dgvForm_count).Cells(2).Value.ToString
                    .Cells(xls_row_index, 4) = Me.dgvForm.Rows(dgvForm_count).Cells(3).Value.ToString
                    .Cells(xls_row_index, 5) = "Error: Record found but more 1 instance. (Table: vi_Member_Policy_v2)"
                End With
                xls_row_index += 1

                    End Select
                End If
                dgvForm_count += 1
            Loop
        End With
        MsgBox("Uploading Process complete.")
        xls_file.Visible = True
    End Sub
    Private Function Change_IC(ByVal var_IC_New As String) As String
        If IsNumeric(var_IC_New) = True Then
            Select Case Len(var_IC_New.Trim)
                Case 7
                    Change_IC = "0" & var_IC_New
                Case 6
                    Change_IC = "00" & var_IC_New
                Case 5
                    Change_IC = "000" & var_IC_New
                Case 4
                    Change_IC = "0000" & var_IC_New
                Case 3
                    Change_IC = "00000" & var_IC_New
                Case 2
                    Change_IC = "000000" & var_IC_New
                Case 1
                    Change_IC = "0000000" & var_IC_New
                Case Else
                    Change_IC = var_IC_New
            End Select
            Return Change_IC
        Else
            Change_IC = var_IC_New
            Return Change_IC
        End If
    End Function
    Private Function Change_Deduction_Code(ByVal var_Deduction_Code As String) As String
        If IsNumeric(var_Deduction_Code) = True Then
            If var_Deduction_Code > 999 Then
                Change_Deduction_Code = var_Deduction_Code
            Else
                Change_Deduction_Code = "0" & var_Deduction_Code.ToString.Trim
            End If
        Else
            Change_Deduction_Code = var_Deduction_Code
        End If
        Return Change_Deduction_Code
    End Function
    Private Function UpdatePolicyNo_New(ByVal PolicyID As String, ByVal PolicyNO As String) As Boolean
        Dim sRes As String
        sRes = _objBusi.fPolicyNoDetails(PolicyID, PolicyNO, My.Settings.Username.Trim(), Format(Convert.ToDateTime(Me.tstxtPEDate.Text.ToString()), "MM/dd/yyyy"), Format(Convert.ToDateTime(Me.tstxtPPDate.Text.ToString()), "MM/dd/yyyy"), "", "", Conn)
        If sRes = "1" Then
            Remark = "OK (Changes on Policy No)"
            Return True
        Else
            Remark = "No Changes on Policy/Certificate No."
            Return True
        End If
    End Function

    Private Function Update_Member_Policy(ByVal var_Member_Policy_ID As String, ByVal var_grid_row As Integer) As Boolean
       

        Try

            Dim cmdSelect_Member_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member_Policy.CommandType = CommandType.Text
            cmdSelect_Member_Policy.CommandText = "SELECT  ID, Member_ID, Deduction_Code, Angkasa_FileNo, Policy_No, NEW_Policy_No, " & _
                                                  "Last_Modified_By, Last_Modified_On, Policy_Posted_Date " & _
                                                  "FROM dt_Member_Policy " & _
                                                  "WHERE ID = '" & var_Member_Policy_ID.Trim & "'"
            Dim da_Member_Policy As New SqlDataAdapter(cmdSelect_Member_Policy)
            Dim cmdUpdate_Member_Policy As SqlCommandBuilder
            cmdUpdate_Member_Policy = New SqlCommandBuilder(da_Member_Policy)


            Dim cmdSelect_Log_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Log_Member.CommandType = CommandType.Text
            cmdSelect_Log_Member.CommandText = "SELECT * FROM log_Member " & _
                                               "WHERE Member_Policy_ID = '" & var_Member_Policy_ID.Trim & "'"
            Dim da_log_Member As New SqlDataAdapter(cmdSelect_Log_Member)
            Dim cmdInsert_log_Member As SqlCommandBuilder
            cmdInsert_log_Member = New SqlCommandBuilder(da_log_Member)



            Dim ds_UpdateBulk As New DataSet


            da_Member_Policy.Fill(ds_UpdateBulk, "dt_Member_Policy")
            da_log_Member.Fill(ds_UpdateBulk, "log_Member")

            With ds_UpdateBulk.Tables("dt_Member_Policy")
                If .Rows.Count = 1 Then
                    If Me.lblRQS1.Text.ToString.Trim() = "NEW" Then
                        If Len(.Rows(0).Item("NEW_Policy_No").ToString.Trim) = 0 Then
                            .Rows(0).Item("NEW_Policy_No") = Me.dgvForm.Rows(var_grid_row).Cells(5).Value.ToString.ToUpper.Trim
                            .Rows(0).Item("Last_Modified_By") = My.Settings.Username.Trim
                            .Rows(0).Item("Last_Modified_On") = Now()
                            .Rows(0).Item("Policy_Posted_Date") = Me.tstxtPPDate.Text
                            da_Member_Policy.Update(ds_UpdateBulk, "dt_Member_Policy")

                            Dim dr_log_Member_New As DataRow = ds_UpdateBulk.Tables("log_Member").NewRow


                            With dr_log_Member_New
                                .Item("Member_Policy_ID") = var_Member_Policy_ID.Trim
                                .Item("Log_Date") = Now()
                                .Item("Activity_Detail") = "Upload/Update Policy/Certificate No."
                                .Item("Username") = My.Settings.Username.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                            End With
                            ds_UpdateBulk.Tables("log_Member").Rows.Add(dr_log_Member_New)
                            da_log_Member.Update(ds_UpdateBulk, "log_Member")
                            Remark = "OK (New Policy No)"
                            Return True
                        Else
                            If .Rows(0).Item("NEW_Policy_No").ToString.ToUpper.Trim <> Me.dgvForm.Rows(var_grid_row).Cells(5).Value.ToString.ToUpper.Trim Then
                                .Rows(0).Item("NEW_Policy_No") = Me.dgvForm.Rows(var_grid_row).Cells(5).Value.ToString.ToUpper.Trim
                                .Rows(0).Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Rows(0).Item("Last_Modified_On") = Now()
                                .Rows(0).Item("Policy_Posted_Date") = Me.tstxtPPDate.Text
                                da_Member_Policy.Update(ds_UpdateBulk, "dt_Member_Policy")
                                Dim dr_log_Member_New As DataRow = ds_UpdateBulk.Tables("log_Member").NewRow

                                With dr_log_Member_New
                                    .Item("Member_Policy_ID") = var_Member_Policy_ID.Trim
                                    .Item("Log_Date") = Now()
                                    .Item("Activity_Detail") = "Upload/Update Policy/Certificate No."
                                    .Item("Username") = My.Settings.Username.Trim
                                    .Item("Created_By") = My.Settings.Username.Trim
                                    .Item("Created_On") = Now()
                                End With
                                ds_UpdateBulk.Tables("log_Member").Rows.Add(dr_log_Member_New)
                                da_log_Member.Update(ds_UpdateBulk, "log_Member")
                                Remark = "OK (New Policy No)"
                                Return True
                            Else
                                Remark = "No Changes on Policy/Certificate No."
                                Return True
                            End If
                        End If
                    Else

                        If Len(.Rows(0).Item("Policy_No").ToString.Trim) = 0 Then
                            .Rows(0).Item("Policy_No") = Me.dgvForm.Rows(var_grid_row).Cells(4).Value.ToString.ToUpper.Trim
                            .Rows(0).Item("Last_Modified_By") = My.Settings.Username.Trim
                            .Rows(0).Item("Last_Modified_On") = Now()
                            .Rows(0).Item("Policy_Posted_Date") = Me.tstxtPPDate.Text
                            da_Member_Policy.Update(ds_UpdateBulk, "dt_Member_Policy")

                            Dim dr_log_Member_New As DataRow = ds_UpdateBulk.Tables("log_Member").NewRow


                            With dr_log_Member_New
                                .Item("Member_Policy_ID") = var_Member_Policy_ID.Trim
                                .Item("Log_Date") = Now()
                                .Item("Activity_Detail") = "Upload/Update Policy/Certificate No."
                                .Item("Username") = My.Settings.Username.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                            End With
                            ds_UpdateBulk.Tables("log_Member").Rows.Add(dr_log_Member_New)
                            da_log_Member.Update(ds_UpdateBulk, "log_Member")
                            Remark = "OK (Old Policy No)"
                            Return True
                        Else
                            If .Rows(0).Item("Policy_No").ToString.ToUpper.Trim <> Me.dgvForm.Rows(var_grid_row).Cells(4).Value.ToString.ToUpper.Trim Then
                                .Rows(0).Item("Policy_No") = Me.dgvForm.Rows(var_grid_row).Cells(4).Value.ToString.ToUpper.Trim
                                .Rows(0).Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Rows(0).Item("Last_Modified_On") = Now()
                                .Rows(0).Item("Policy_Posted_Date") = Me.tstxtPPDate.Text
                                da_Member_Policy.Update(ds_UpdateBulk, "dt_Member_Policy")

                                Dim dr_log_Member_New As DataRow = ds_UpdateBulk.Tables("log_Member").NewRow


                                With dr_log_Member_New
                                    .Item("Member_Policy_ID") = var_Member_Policy_ID.Trim
                                    .Item("Log_Date") = Now()
                                    .Item("Activity_Detail") = "Upload/Update Policy/Certificate No."
                                    .Item("Username") = My.Settings.Username.Trim
                                    .Item("Created_By") = My.Settings.Username.Trim
                                    .Item("Created_On") = Now()
                                End With
                                ds_UpdateBulk.Tables("log_Member").Rows.Add(dr_log_Member_New)
                                da_log_Member.Update(ds_UpdateBulk, "log_Member")
                                Remark = "OK (OLD Policy No)"
                                Return True
                            Else
                                Remark = "No Changes on Policy/Certificate No."
                                Return True
                            End If
                        End If
                    End If
                Else
                    Remark = "Either 0 record or more than 1 records found. (Table: dt_Member_Policy / ID = " & var_Member_Policy_ID.ToString.Trim
                    Return False
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
            Remark = ex.ToString
            Return False
        End Try
    End Function
End Class