Public Class grdBLANK_Address_Template_Import
    Dim Conn As DbConnection = New SqlConnection
    Dim Remark As String = ""

    Private Sub grdBLANK_Address_Template_Import_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub grdBLANK_Address_Template_Import_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
    Private Sub tsReport_File_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_File_Open.Click
        Dim Excel As New Microsoft.Office.Interop.Excel.ApplicationClass

        With Me.ofdAddresses2Upload
            .InitialDirectory = "C:\"
            .Filter = "CSV files (*.csv)|*.csv"

            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Dim myfile As New System.IO.FileInfo(.FileName)
                Dim sConnStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & myfile.DirectoryName & _
                                         ";Extended Properties=""Text;HDR=YES;FMT=Delimited;IMEX=1"""
                Dim objConn As New System.Data.OleDb.OleDbConnection(sConnStr)
                Dim objDA As New System.Data.OleDb.OleDbDataAdapter

                If objConn.State = ConnectionState.Closed Then
                    objConn.Open()
                End If

                Dim objCmdSelect As New System.Data.OleDb.OleDbCommand("SELECT * FROM " & myfile.Name, objConn)

                objDA.SelectCommand = objCmdSelect

                Dim objDS As New DataSet
                objDA.Fill(objDS)

                Me.dgvForm.DataSource = objDS.Tables(0).DefaultView

                If objConn.State = ConnectionState.Open Then
                    objConn.Close()
                End If
            End If
        End With
    End Sub

    Private Sub tsReport_Import_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Import.Click
        If Me.dgvForm.RowCount > 0 Then
            Dim response As MsgBoxResult = MsgBox("Do you want to proceed with the UPLOAD?", MsgBoxStyle.OkCancel, "Upload Addresses")

            If response = MsgBoxResult.Cancel Then
                MsgBox("Cancel upload process.")
                Me.dgvForm.DataSource = Nothing
                Exit Sub
            Else
                Me.Upload_Addresses()
            End If
        Else
            MsgBox("No records to be uploaded.")
        End If
    End Sub

    Private Sub Upload_Addresses()
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
                If Len(.Rows(dgvForm_count).Cells(4).Value.ToString.Trim) = 0 Then
                    With xls_workbook.Worksheets(1)
                        .Cells(xls_row_index, 1) = Me.dgvForm.Rows(dgvForm_count).Cells(0).Value.ToString
                        .Cells(xls_row_index, 2) = Me.dgvForm.Rows(dgvForm_count).Cells(2).Value.ToString
                        .Cells(xls_row_index, 3) = Me.dgvForm.Rows(dgvForm_count).Cells(4).Value.ToString
                        .Cells(xls_row_index, 4) = Me.dgvForm.Rows(dgvForm_count).Cells(9).Value.ToString
                        .Cells(xls_row_index, 5) = "IC Column is Blank."
                    End With
                    xls_row_index += 1
                Else
                    Dim var_FileNo As String = .Rows(dgvForm_count).Cells(0).Value.ToString.Replace("'", "''")

                    var_ReturnedRows = ds_SubmittedBatch.Tables("vi_Member_Policy_v2").Select("IC_New = '" & Me.Change_IC(.Rows(dgvForm_count).Cells(4).Value.ToString.Trim) & "' " & _
                                                                                              "AND Deduction_Code = '" & Me.Change_Deduction_Code(.Rows(dgvForm_count).Cells(9).Value.ToString.Trim) & "' " & _
                                                                                              "AND Angkasa_FileNo = '" & var_FileNo.Trim & "'")
                    Dim var_IC As String = Me.Change_IC(.Rows(dgvForm_count).Cells(4).Value.ToString.Trim)
                    Dim var_Deduction_Code As String = Me.Change_Deduction_Code(.Rows(dgvForm_count).Cells(9).Value.ToString.Trim)

                    Select Case var_ReturnedRows.Length
                        Case 0
                            With xls_workbook.Worksheets(1)
                                .Cells(xls_row_index, 1) = Me.dgvForm.Rows(dgvForm_count).Cells(0).Value.ToString
                                .Cells(xls_row_index, 2) = Me.dgvForm.Rows(dgvForm_count).Cells(2).Value.ToString
                                .Cells(xls_row_index, 3) = Me.dgvForm.Rows(dgvForm_count).Cells(4).Value.ToString
                                .Cells(xls_row_index, 4) = Me.dgvForm.Rows(dgvForm_count).Cells(9).Value.ToString
                                .Cells(xls_row_index, 5) = "Error: Record not found. (Table: vi_Member_Policy_v2)"
                            End With
                            xls_row_index += 1
                        Case 1
                            If Me.Update_Member_Policy(var_ReturnedRows(0).Item("ID").ToString.Trim, dgvForm_count) = False Then
                                With xls_workbook.Worksheets(1)
                                    .Cells(xls_row_index, 1) = Me.dgvForm.Rows(dgvForm_count).Cells(0).Value.ToString
                                    .Cells(xls_row_index, 2) = Me.dgvForm.Rows(dgvForm_count).Cells(2).Value.ToString
                                    .Cells(xls_row_index, 3) = Me.dgvForm.Rows(dgvForm_count).Cells(4).Value.ToString
                                    .Cells(xls_row_index, 4) = Me.dgvForm.Rows(dgvForm_count).Cells(9).Value.ToString
                                    .Cells(xls_row_index, 5) = Remark.Trim
                                End With
                                xls_row_index += 1
                            Else
                                With xls_workbook.Worksheets(1)
                                    .Cells(xls_row_index, 1) = Me.dgvForm.Rows(dgvForm_count).Cells(0).Value.ToString
                                    .Cells(xls_row_index, 2) = Me.dgvForm.Rows(dgvForm_count).Cells(2).Value.ToString
                                    .Cells(xls_row_index, 3) = Me.dgvForm.Rows(dgvForm_count).Cells(4).Value.ToString
                                    .Cells(xls_row_index, 4) = Me.dgvForm.Rows(dgvForm_count).Cells(9).Value.ToString
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

    Private Function Update_Member_Policy(ByVal var_Member_Policy_ID As String, ByVal var_grid_row As Integer) As Boolean
        Dim var_Full_Name As String = Me.dgvForm.Rows(var_grid_row).Cells(2).Value.ToString.Replace("'", "''")

        Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member.CommandType = CommandType.Text
        cmdSelect_Member.CommandText = "SELECT IC_New, Full_Name, Postal_Address_L1, Postal_Address_L2 " & _
                                       "FROM dt_Member " & _
                                       "WHERE IC_New = '" & Me.Change_IC(Me.dgvForm.Rows(var_grid_row).Cells(4).Value.ToString.Trim) & "' " & _
                                       "AND Full_Name = '" & var_Full_Name.Trim & "'"
        Dim da_Member As New SqlDataAdapter(cmdSelect_Member)
        Dim cmdUpdate_Member As SqlCommandBuilder
        cmdUpdate_Member = New SqlCommandBuilder(da_Member)

        Dim cmdSelect_Member_Dependents As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Dependents.CommandType = CommandType.Text
        cmdSelect_Member_Dependents.CommandText = "SELECT * FROM dt_Member_Policy_Dependents " & _
                                                  "WHERE Member_Policy_ID = '" & var_Member_Policy_ID & "'"
        Dim da_Member_Dependents As New SqlDataAdapter(cmdSelect_Member_Dependents)
        Dim cmdInsert_Member_Dependents As SqlCommandBuilder
        cmdInsert_Member_Dependents = New SqlCommandBuilder(da_Member_Dependents)

        Dim cmdSelect_Member_Policy_Exclusion As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Policy_Exclusion.CommandType = CommandType.Text
        cmdSelect_Member_Policy_Exclusion.CommandText = "SELECT * FROM dt_Member_Policy_Exclusion_Clause " & _
                                                        "WHERE Member_Policy_ID = '" & var_Member_Policy_ID & "'"
        Dim da_Member_Policy_Exclusion As New SqlDataAdapter(cmdSelect_Member_Policy_Exclusion)
        Dim cmdInsert_Member_Policy_Exclusion As SqlCommandBuilder
        cmdInsert_Member_Policy_Exclusion = New SqlCommandBuilder(da_Member_Policy_Exclusion)

        Dim cmdSelect_Log_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Log_Member.CommandType = CommandType.Text
        cmdSelect_Log_Member.CommandText = "SELECT * FROM log_Member " & _
                                           "WHERE Member_Policy_ID = '" & var_Member_Policy_ID & "'"
        Dim da_log_Member As New SqlDataAdapter(cmdSelect_Log_Member)
        Dim cmdInsert_log_Member As SqlCommandBuilder
        cmdInsert_log_Member = New SqlCommandBuilder(da_log_Member)

        Dim ds_UpdateBulk As New DataSet

        da_Member.Fill(ds_UpdateBulk, "dt_Member")
        da_Member_Dependents.Fill(ds_UpdateBulk, "dt_Member_Policy_Dependents")
        da_Member_Policy_Exclusion.Fill(ds_UpdateBulk, "dt_Member_Policy_Exclusion_Clause")
        da_log_Member.Fill(ds_UpdateBulk, "log_Member")

        Try
            With ds_UpdateBulk.Tables("dt_Member")
                Dim var_dt_Member_Upd_Count As Int16 = 0

                If .Rows.Count = 1 Then
                    If Len(.Rows(0).Item("Postal_Address_L1").ToString.Trim) = 0 Then
                        .Rows(0).Item("Postal_Address_L1") = Me.dgvForm.Rows(var_grid_row).Cells(5).Value.ToString.ToUpper.Trim
                        var_dt_Member_Upd_Count += 1
                    Else
                        var_dt_Member_Upd_Count -= 1
                    End If
                    If Len(.Rows(0).Item("Postal_Address_L2").ToString.Trim) = 0 Then
                        .Rows(0).Item("Postal_Address_L2") = Me.dgvForm.Rows(var_grid_row).Cells(6).Value.ToString.ToUpper.Trim
                        var_dt_Member_Upd_Count += 1
                    Else
                        var_dt_Member_Upd_Count -= 1
                    End If
                    If Len(.Rows(0).Item("Add3").ToString.Trim) = 0 Then
                        .Rows(0).Item("Add3") = Me.dgvForm.Rows(var_grid_row).Cells(7).Value.ToString.ToUpper.Trim
                        var_dt_Member_Upd_Count += 1
                    Else
                        var_dt_Member_Upd_Count -= 1
                    End If
                    If Len(.Rows(0).Item("Add4").ToString.Trim) = 0 Then
                        .Rows(0).Item("Add4") = Me.dgvForm.Rows(var_grid_row).Cells(8).Value.ToString.ToUpper.Trim
                        var_dt_Member_Upd_Count += 1
                    Else
                        var_dt_Member_Upd_Count -= 1
                    End If

                    If var_dt_Member_Upd_Count > 0 Then
                        da_Member.Update(ds_UpdateBulk, "dt_Member")
                        Remark = "Addresses Added. "
                    Else
                        Remark = "No Changes to Address. "
                    End If
                    Dim dr_log_Member_New As DataRow = ds_UpdateBulk.Tables("log_Member").NewRow

                    With dr_log_Member_New
                        .Item("Member_Policy_ID") = var_Member_Policy_ID
                        .Item("Log_Date") = Now()
                        .Item("Activity_Detail") = "Bulk Upload/Update on Addresses."
                        .Item("Username") = My.Settings.Username.Trim
                        .Item("Created_By") = My.Settings.Username.Trim
                        .Item("Created_On") = Now()
                    End With
                    ds_UpdateBulk.Tables("log_Member").Rows.Add(dr_log_Member_New)
                    da_log_Member.Update(ds_UpdateBulk, "log_Member")

                    Return True
                Else
                    Remark = "Either 0 record or more than 1 records found. (Table: dt_Member)"
                    Return False
                End If
            End With
        Catch ex As Exception
            Remark = ex.ToString
            Return False
        End Try
    End Function
End Class