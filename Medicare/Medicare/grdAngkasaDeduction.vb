
Public Class grdAngkasaDeduction
    Dim Conn As DbConnection = New SqlConnection
    Dim ds_MonthlyDeduction As New DataSet

    Dim grdChangeRequest As New grdBulkUpload
    Dim _objBusi As New Business
    Private Sub grdAngkasaDeduction_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
        ds_MonthlyDeduction = Nothing

    End Sub
    Private Sub grdAngkasaDeduction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Populate_Grid()
    End Sub
    Private Sub Populate_Grid()
        Dim dt As New DataTable
        dt = _objBusi.getDetails("PANGKASA", "", "", "", "", "BIND", Conn)
        With Me.dgvForm
            .DataSource = dt
            .Columns(0).Visible = True
            .Columns(1).Visible = False
            .Columns(2).Visible = True
            .Columns(3).Visible = True
            .Columns(4).Visible = True
            .Columns(5).Visible = True
            .Columns(6).Visible = True
            .Columns(7).Visible = True
            .Columns(8).Visible = True

            .Columns(2).HeaderText = "Batch No"
            .Columns(3).HeaderText = "Batch Record Count"
            .Columns(4).HeaderText = "Batch Record Consolidated"
            .Columns(5).HeaderText = "Batch Record Successfully Processed"
            .Columns(6).HeaderText = "Batch Uploaded On"
            .Columns(7).HeaderText = "Batch Uploaded By"
            .Columns(8).HeaderText = "Status"

            .Columns(3).Width = 150
            .Columns(4).Width = 150
            .Columns(5).Width = 180
            .Columns(6).Width = 150

            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(5).ReadOnly = True
            .Columns(6).ReadOnly = True
            .Columns(7).ReadOnly = True
            .Columns(8).ReadOnly = True
        End With
    End Sub
    Private Function Update_Angkasa_Transaction(ByVal Trans_GUID As String, ByVal Trans_Status As Char) As Boolean

        Dim cmdSelect_Angkasa_Child As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Angkasa_Child.CommandType = CommandType.Text
        cmdSelect_Angkasa_Child.CommandText = "SELECT * FROM dt_Angkasa_MonthlyDeduction_Consolidated WHERE ID = '" & Trans_GUID & "'"

        Dim da_Angkasa_Child As New SqlDataAdapter(cmdSelect_Angkasa_Child)

        Dim cmdUpdate_Angkasa_Child As SqlCommandBuilder
        cmdUpdate_Angkasa_Child = New SqlCommandBuilder(da_Angkasa_Child)


        Dim ds_Angkasa_Deduction As New DataSet

        Try
            da_Angkasa_Child.Fill(ds_Angkasa_Deduction, "dt_Angkasa_MonthlyDeduction_Consolidated")

            Dim dr_Angkasa_Child As DataRow = ds_Angkasa_Deduction.Tables("dt_Angkasa_MonthlyDeduction_Consolidated").Rows(0)

            If Trans_Status = "1" Then
                dr_Angkasa_Child.Item("Batch_Status") = 1

            Else

            End If

            da_Angkasa_Child.Update(ds_Angkasa_Deduction, "dt_Angkasa_MonthlyDeduction_Consolidated")
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
    Private Function Update_MonthlyDeduction(ByVal var_Batch_No As String, ByVal var_batch_trans_success As Integer)

        Dim cmdSelect_MonthlyDeduction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MonthlyDeduction.CommandType = CommandType.Text
        cmdSelect_MonthlyDeduction.CommandText = "SELECT * FROM dt_MonthlyDeduction WHERE Batch_No = '" & var_Batch_No.Trim & "'"

        Dim da_MonthlyDeduction As New SqlDataAdapter(cmdSelect_MonthlyDeduction)

        Dim cmdUpdate_MonthlyDeduction As SqlCommandBuilder
        cmdUpdate_MonthlyDeduction = New SqlCommandBuilder(da_MonthlyDeduction)


        Dim ds_MonthlyDeduction As New DataSet


        Try
            da_MonthlyDeduction.Fill(ds_MonthlyDeduction, "dt_MonthlyDeduction")

            Dim dr_MonthlyDeduction As DataRow = ds_MonthlyDeduction.Tables("dt_MonthlyDeduction").Rows(0)

            dr_MonthlyDeduction.Item("Batch_Record_Consolidated") = dr_MonthlyDeduction.Item("Batch_Record_Consolidated") + var_batch_trans_success
            da_MonthlyDeduction.Update(ds_MonthlyDeduction, "dt_MonthlyDeduction")
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
    Private Function Update_PostConso_MonthlyDeduction(ByVal var_Batch_No As String, ByVal var_batch_trans_success As Integer)

        Dim cmdSelect_MonthlyDeduction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MonthlyDeduction.CommandType = CommandType.Text
        cmdSelect_MonthlyDeduction.CommandText = "SELECT * FROM dt_MonthlyDeduction WHERE Batch_No = '" & var_Batch_No.Trim & "'"

        Dim da_MonthlyDeduction As New SqlDataAdapter(cmdSelect_MonthlyDeduction)

        Dim cmdUpdate_MonthlyDeduction As SqlCommandBuilder
        cmdUpdate_MonthlyDeduction = New SqlCommandBuilder(da_MonthlyDeduction)


        Dim ds_MonthlyDeduction As New DataSet


        Try
            da_MonthlyDeduction.Fill(ds_MonthlyDeduction, "dt_MonthlyDeduction")

            Dim dr_MonthlyDeduction As DataRow = ds_MonthlyDeduction.Tables("dt_MonthlyDeduction").Rows(0)

            dr_MonthlyDeduction.Item("Batch_Record_Processed") = dr_MonthlyDeduction.Item("Batch_Record_Processed") + var_batch_trans_success
            da_MonthlyDeduction.Update(ds_MonthlyDeduction, "dt_MonthlyDeduction")
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
    Private Function Update_MemberPolicy_Effective_Date(ByVal var_ID As String, ByVal var_Receiving_Month As String)

        Dim cmdSelect_Member_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Policy.CommandType = CommandType.Text
        cmdSelect_Member_Policy.CommandText = "SELECT * FROM dt_Member_Policy WHERE ID = '" & var_ID.Trim & "'"

        Dim da_Member_Policy As New SqlDataAdapter(cmdSelect_Member_Policy)

        Dim cmdUpdate_Effective_Date As SqlCommandBuilder
        cmdUpdate_Effective_Date = New SqlCommandBuilder(da_Member_Policy)


        Dim ds_MemberPolicy As New DataSet


        Try
            da_Member_Policy.Fill(ds_MemberPolicy, "dt_Member_Policy")

            If ds_MemberPolicy.Tables("dt_Member_Policy").Rows.Count = 1 Then
                Dim dr_MemberPolicy As DataRow = ds_MemberPolicy.Tables("dt_Member_Policy").Rows(0)

                Dim var_effective_month As Short
                Dim var_effective_year As Short
                Dim var_effective_date As Date

                var_effective_month = Val(var_Receiving_Month.Substring(4, 2)) + 1
                var_effective_year = Val(var_Receiving_Month.Substring(0, 4))

                If var_effective_month = 13 Then
                    var_effective_year += 1
                    var_effective_month = 1
                End If

                var_effective_date = Convert.ToDateTime(Str(var_effective_year) & "/" & Str(var_effective_month) & "/15")
                dr_MemberPolicy.Item("Effective_Date") = var_effective_date
                dr_MemberPolicy.Item("Status") = "INFORCE"
                da_Member_Policy.Update(ds_MemberPolicy, "dt_Member_Policy")

                _objBusi.InsUpsPremiumHistory("UP", Guid.NewGuid.ToString(), var_ID.ToString(), var_effective_date, "", "", "Active", "", "", Conn)


                _objBusi.InsUpsPolicyPremiumHistory("UPDATESTARTDATE", var_ID.ToString(), "0.00", var_effective_date, "", "", My.Settings.Username, Conn)

                Return True
            Else
                MsgBox("Error in loading the data")
                Return False
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    Private Function Insert_MemberPolicy_MonthlyDeduction(ByVal var_ID As String, ByVal var_Bulan_Potongan As String, ByVal var_Kod_Potongan As String, ByVal var_Jumlah_Potongan As Decimal, ByVal var_Batch_No As String, ByVal var_Receiving_Month As String)
        
        Dim cmdInsert_MonthlyDeduction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdInsert_MonthlyDeduction.CommandType = CommandType.Text
        cmdInsert_MonthlyDeduction.CommandText = "INSERT INTO dt_Member_Policy_MonthlyDeduction (ID, Member_Policy_ID, Angkasa_Bulan_Potongan, " & _
                                                 "Angkasa_Kod_Potongan, Angkasa_Jumlah_Pokok, Angkasa_Batch_No, Receiving_Month) " & _
                                                 "VALUES ('" & Guid.NewGuid.ToString().Trim() & "', '" & var_ID & "', '" & var_Bulan_Potongan & "', '" & var_Kod_Potongan & "', " & _
                                                 var_Jumlah_Potongan & ", '" & var_Batch_No & "', '" & var_Receiving_Month & "')"

        Try
            cmdInsert_MonthlyDeduction.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    Private Function Insert_Angkasa_Monthly_KIV(ByVal IC As String, ByVal var_Bulan_Potongan As String, ByVal var_Kod_Potongan As String, ByVal var_Jumlah_Potongan As Decimal, ByVal var_Batch_No As String, ByVal var_Receiving_Month As String)

        Dim cmdInsert_Monthly_SuspendAccount As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdInsert_Monthly_SuspendAccount.CommandType = CommandType.Text
        cmdInsert_Monthly_SuspendAccount.CommandText = "INSERT INTO dt_Angkasa_Monthly_SuspendAccount (No_Kad_Pengenalan, Angkasa_Bulan_Potongan, " & _
                                                       "Angkasa_Kod_Potongan, Angkasa_Jumlah_Pokok, Angkasa_Batch_No, Receiving_Month) " & _
                                                       "VALUES ('" & IC & "', '" & var_Bulan_Potongan & "', '" & var_Kod_Potongan & "', " & _
                                                       var_Jumlah_Potongan & ", '" & var_Batch_No & "', '" & var_Receiving_Month & "')"

        Try
            cmdInsert_Monthly_SuspendAccount.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

    End Function

    Private Sub InsertRow_Grid_ChangeRequest(ByVal var_cell0 As String, ByVal var_cell1 As String, ByVal var_cell2 As String, ByVal var_cell3 As String, _
                               ByVal var_cell4 As String, ByVal var_cell5 As String, ByVal var_cell6 As String, ByVal var_cell7 As Decimal, _
                               ByVal var_cell8 As Decimal, ByVal var_cell9 As String, ByVal var_cell10 As String, ByVal var_cell11 As String)

        With grdChangeRequest.dgvForm
            .Rows.Add()
            .Rows(.Rows.Count - 1).Cells(0).Value = var_cell0
            .Rows(.Rows.Count - 1).Cells(1).Value = var_cell1
            .Rows(.Rows.Count - 1).Cells(2).Value = var_cell2
            .Rows(.Rows.Count - 1).Cells(3).Value = var_cell3
            .Rows(.Rows.Count - 1).Cells(4).Value = var_cell4
            .Rows(.Rows.Count - 1).Cells(5).Value = var_cell5
            .Rows(.Rows.Count - 1).Cells(6).Value = var_cell6
            .Rows(.Rows.Count - 1).Cells(7).Value = var_cell7
            .Rows(.Rows.Count - 1).Cells(8).Value = var_cell8
            .Rows(.Rows.Count - 1).Cells(9).Value = var_cell9
            .Rows(.Rows.Count - 1).Cells(10).Value = var_cell10
            .Rows(.Rows.Count - 1).Cells(11).Value = var_cell11

            .Rows(.Rows.Count - 1).Cells(6).Style.BackColor = Color.Yellow
            .Rows(.Rows.Count - 1).Cells(7).Style.BackColor = Color.Yellow
        End With
    End Sub

    Private Sub tsb_Export2Excel_Angkasa_MonthlyDeduction_Child_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Export2Excel_Angkasa_MonthlyDeduction_Child.Click
        exportExcel()
    End Sub
    Private Sub exportExcel()
        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
        xls_workbook = xls_file.Workbooks.Add
        With xls_workbook.Worksheets(1)


            .Columns(1).NumberFormat = "@"
            .Columns(2).NumberFormat = "@"
            .Columns(3).NumberFormat = "@"
            .Columns(4).NumberFormat = "@"
            .Columns(5).NumberFormat = "##,##0.00"
            .Columns(6).NumberFormat = "@"
            .Columns(7).NumberFormat = "@"
            .Columns(8).NumberFormat = "@"

            .Cells(1, 1) = "No Kad Pengenalan"
            .Cells(1, 2) = "No Keahlian"
            .Cells(1, 3) = "Bulan Potongan"
            .Cells(1, 4) = "Kod Potongan"
            .Cells(1, 5) = "Jumlah Potongan"
            .Cells(1, 6) = "Nama Ahli"
            .Cells(1, 7) = "No Kad Pengenalan Lama"
            .Cells(1, 8) = "Batch No"
        End With

        Dim dgvForm_counter As Integer = 0
        Dim batch_trans_counter As Integer = 0
        Dim row_index As Integer = 2
        Try
            With Me.dgvForm
                Do While dgvForm_counter < .Rows.Count

                    batch_trans_counter = 0

                    If .Rows(dgvForm_counter).Cells(0).Value = "T" Then
                        Dim dt As New DataTable
                        dt = _objBusi.getDetails("PANGKASA", .Rows(dgvForm_counter).Cells(2).Value.ToString, "", "", "", "XPORT", Conn)

                        For Each dr As DataRow In dt.Rows
                            With xls_workbook.Worksheets(1)
                                .Cells(row_index, 1) = dr("No_Kad_Pengenalan").ToString
                                .Cells(row_index, 2) = dr("No_Keahlian").ToString
                                .Cells(row_index, 3) = dr("Bulan_Potongan").ToString
                                .Cells(row_index, 4) = dr("Kod_Potongan").ToString
                                .Cells(row_index, 5) = dr("Jumlah_Pokok")
                                .Cells(row_index, 6) = dr("Nama_Ahli").ToString
                                .Cells(row_index, 7) = dr("No_KP_Lama").ToString
                                .Cells(row_index, 8) = dr("Batch_No").ToString
                            End With
                            row_index += 1
                        Next
                    End If
                    dgvForm_counter += 1
                Loop
            End With
            MsgBox("Export Complete")
            xls_file.Visible = True

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub tsbConsolidate_MonthlyDeduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsolidate_MonthlyDeduction.Click
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        AConsolidate()
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        MsgBox("Consolidation Process Completed.")
        Application.DoEvents()
    End Sub
    Private Sub AConsolidate()
        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
        Dim row_index As Integer = 2
        xls_workbook = xls_file.Workbooks.Add
        With xls_workbook.Worksheets(1)
            .Columns(1).NumberFormat = "@"
            .Columns(2).NumberFormat = "@"
            .Columns(3).NumberFormat = "@"
            .Columns(4).NumberFormat = "@"
            .Columns(5).NumberFormat = "##,##0.00"
            .Columns(6).NumberFormat = "@"
            .Columns(7).NumberFormat = "@"
            .Columns(8).NumberFormat = "@"

            .Cells(1, 1) = "No Kad Pengenalan"
            .Cells(1, 2) = "No Keahlian"
            .Cells(1, 3) = "Bulan Potongan"
            .Cells(1, 4) = "Kod Potongan"
            .Cells(1, 5) = "Jumlah Potongan"
            .Cells(1, 6) = "Nama Ahli"
            .Cells(1, 7) = "No Kad Pengenalan Lama"
            .Cells(1, 8) = "Batch No"
        End With


        Dim cmdSelect_Angkasa_MonthlyDeduction_Child As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Angkasa_MonthlyDeduction_Child.CommandType = CommandType.Text
        cmdSelect_Angkasa_MonthlyDeduction_Child.CommandText = "SELECT * FROM dt_Angkasa_MonthlyDeduction_Child WHERE Batch_Status = '0'"

        Dim da_Angkasa_MonthlyDeduction_Child As New SqlDataAdapter(cmdSelect_Angkasa_MonthlyDeduction_Child)

        Dim cmdUpdate_Angkasa_Child As SqlCommandBuilder
        cmdUpdate_Angkasa_Child = New SqlCommandBuilder(da_Angkasa_MonthlyDeduction_Child)


        Dim ds_Angkasa2Consolidate As New DataSet


        da_Angkasa_MonthlyDeduction_Child.Fill(ds_Angkasa2Consolidate, "dt_Angkasa_MonthlyDeduction_Child")

        Dim dr_Batch_Trans As DataRow()
        Dim dgvForm_counter As Integer = 0
        Dim batch_trans_counter As Integer = 0
        Dim batch_trans_success_counter As Integer = 0

        With Me.dgvForm
            Do While dgvForm_counter < .Rows.Count
                batch_trans_counter = 0
                batch_trans_success_counter = 0

                If .Rows(dgvForm_counter).Cells(0).Value = "T" Then
                    If .Rows(dgvForm_counter).Cells(8).Value = 0 Then

                        Dim sRes As String
                        sRes = .Rows(dgvForm_counter).Cells(2).Value.ToString

                        dr_Batch_Trans = ds_Angkasa2Consolidate.Tables("dt_Angkasa_MonthlyDeduction_Child").Select("Batch_No = '" & sRes & "' and Batch_Status = '0'")
                        Dim iCount As String
                        iCount = dr_Batch_Trans.Length

                        Do While batch_trans_counter < dr_Batch_Trans.Length
                            With dr_Batch_Trans(batch_trans_counter)
                                Select Case .Item("Kod_Potongan").ToString
                                    Case "0550", "0551", "0552", "0553", "0554", "0555", "0556"
                                        If Insert_Consolidated_PA_Angkasa_MontlyDeduction(.Item("No_Kad_Pengenalan").ToString.Trim, _
                                                                                          .Item("Bulan_Potongan").ToString.Trim, _
                                                                                          .Item("Jumlah_Pokok"), _
                                                                                          .Item("Nama_Ahli").ToString.Trim, _
                                                                                          .Item("Batch_No").ToString.Trim) = True Then

                                            dr_Batch_Trans(batch_trans_counter).Item("Batch_Status") = "1"
                                            dr_Batch_Trans(batch_trans_counter).Item("Batch_ProcessCycle") = "1"

                                            da_Angkasa_MonthlyDeduction_Child.Update(ds_Angkasa2Consolidate, "dt_Angkasa_MonthlyDeduction_Child")

                                            batch_trans_success_counter = batch_trans_success_counter + 1
                                        Else
                                            With xls_workbook.Worksheets(1)
                                                .Cells(row_index, 1) = dr_Batch_Trans(batch_trans_counter).Item("No_Kad_Pengenalan").ToString
                                                .Cells(row_index, 2) = dr_Batch_Trans(batch_trans_counter).Item("No_Keahlian").ToString
                                                .Cells(row_index, 3) = dr_Batch_Trans(batch_trans_counter).Item("Bulan_Potongan").ToString
                                                .Cells(row_index, 4) = dr_Batch_Trans(batch_trans_counter).Item("Kod_Potongan").ToString
                                                .Cells(row_index, 5) = dr_Batch_Trans(batch_trans_counter).Item("Jumlah_Pokok")
                                                .Cells(row_index, 6) = dr_Batch_Trans(batch_trans_counter).Item("Nama_Ahli").ToString
                                                .Cells(row_index, 7) = dr_Batch_Trans(batch_trans_counter).Item("No_KP_Lama").ToString
                                                .Cells(row_index, 8) = dr_Batch_Trans(batch_trans_counter).Item("Batch_No").ToString
                                            End With
                                            row_index += 1
                                        End If
                                    Case Else
                                        If Insert_Consolidated_Angkasa_MonthlyDeduction(.Item("No_Kad_Pengenalan").ToString.Trim, _
                                                                                     .Item("Bulan_Potongan").ToString.Trim, _
                                                                                     .Item("Kod_Potongan").ToString.Trim, _
                                                                                     .Item("Jumlah_Pokok"), _
                                                                                     .Item("Nama_Ahli").ToString.Trim, _
                                                                                     .Item("Batch_No").ToString.Trim) = True Then

                                            dr_Batch_Trans(batch_trans_counter).Item("Batch_Status") = "1"
                                            dr_Batch_Trans(batch_trans_counter).Item("Batch_ProcessCycle") = "1"

                                            da_Angkasa_MonthlyDeduction_Child.Update(ds_Angkasa2Consolidate, "dt_Angkasa_MonthlyDeduction_Child")

                                            batch_trans_success_counter = batch_trans_success_counter + 1
                                        Else
                                            With xls_workbook.Worksheets(1)
                                                .Cells(row_index, 1) = dr_Batch_Trans(batch_trans_counter).Item("No_Kad_Pengenalan").ToString
                                                .Cells(row_index, 2) = dr_Batch_Trans(batch_trans_counter).Item("No_Keahlian").ToString
                                                .Cells(row_index, 3) = dr_Batch_Trans(batch_trans_counter).Item("Bulan_Potongan").ToString
                                                .Cells(row_index, 4) = dr_Batch_Trans(batch_trans_counter).Item("Kod_Potongan").ToString
                                                .Cells(row_index, 5) = dr_Batch_Trans(batch_trans_counter).Item("Jumlah_Pokok")
                                                .Cells(row_index, 6) = dr_Batch_Trans(batch_trans_counter).Item("Nama_Ahli").ToString
                                                .Cells(row_index, 7) = dr_Batch_Trans(batch_trans_counter).Item("No_KP_Lama").ToString
                                                .Cells(row_index, 8) = dr_Batch_Trans(batch_trans_counter).Item("Batch_No").ToString
                                            End With
                                            row_index += 1
                                        End If
                                End Select
                            End With
                            batch_trans_counter += 1
                        Loop


                        Update_MonthlyDeduction(.Rows(dgvForm_counter).Cells(2).Value.ToString, batch_trans_success_counter)
                        .Rows(dgvForm_counter).Cells(4).Value = .Rows(dgvForm_counter).Cells(4).Value + batch_trans_success_counter
                    End If
                End If

                dgvForm_counter += 1
            Loop
        End With

        xls_file.Visible = True
        Populate_Grid()
    End Sub

    Private Function Insert_Consolidated_PA_Angkasa_MontlyDeduction(ByVal var_IC As String, ByVal var_Bulan_Potongan As String, ByVal var_Jumlah_Pokok As Decimal, ByVal var_Nama_Ahli As String, ByVal var_Batch_No As String)
        Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy.CommandType = CommandType.Text
        cmdSelect_MemberPolicy.CommandText = "SELECT IC_New, Deduction_Code, Cancellation_Date " & _
                                             "FROM vi_Member_Policy_v3 " & _
                                             "WHERE Deduction_Code BETWEEN '0550' AND '0551'"

        Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)


        Dim ds_Consolidate_MonthlyDeduction As New DataSet

        da_MemberPolicy.Fill(ds_Consolidate_MonthlyDeduction, "vi_Member_Policy_v3")
        var_Nama_Ahli = var_Nama_Ahli.Replace("'", "''")

        Try
            Dim dr_Member_Policy As DataRow()
            dr_Member_Policy = ds_Consolidate_MonthlyDeduction.Tables("vi_Member_Policy_v3").Select("IC_New = '" & var_IC.Trim & "'")
            Dim sLen, ic As String
            sLen = dr_Member_Policy.Length

            Select Case dr_Member_Policy.Length
                Case 0
                    Return False

                Case 1
                    Dim var_Member_DeductionCode As String = dr_Member_Policy(0).Item("Deduction_Code").ToString.Trim

                    Dim cmdSelect_Consolidate_Monthly_Angkasa As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                    cmdSelect_Consolidate_Monthly_Angkasa.CommandType = CommandType.Text
                    cmdSelect_Consolidate_Monthly_Angkasa.CommandTimeout = 180
                    cmdSelect_Consolidate_Monthly_Angkasa.CommandText = "SELECT * FROM dt_Angkasa_MonthlyDeduction_Consolidated " & _
                                                                        "WHERE No_Kad_Pengenalan = '" & var_IC.Trim & "' " & _
                                                                        "AND Bulan_Potongan = '" & var_Bulan_Potongan & "' " & _
                                                                        "AND Kod_Potongan = '" & var_Member_DeductionCode & "' " & _
                                                                        "AND Batch_No = '" & var_Batch_No & "'"

                    Dim da_Consolidated_MonthlyDeduction As New SqlDataAdapter(cmdSelect_Consolidate_Monthly_Angkasa)
                    Dim cmdUpdate_Consolidate_Monthly_Angkasa As SqlCommandBuilder
                    cmdUpdate_Consolidate_Monthly_Angkasa = New SqlCommandBuilder(da_Consolidated_MonthlyDeduction)

                    da_Consolidated_MonthlyDeduction.Fill(ds_Consolidate_MonthlyDeduction, "dt_Angkasa_MonthlyDeduction_Consolidated")

                    With ds_Consolidate_MonthlyDeduction.Tables("dt_Angkasa_MonthlyDeduction_Consolidated")
                        If .Rows.Count = 0 Then
                            Dim cmdInsert_Consolidated_Monthly_Angkasa As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                            cmdInsert_Consolidated_Monthly_Angkasa.CommandType = CommandType.Text
                            cmdInsert_Consolidated_Monthly_Angkasa.CommandText = "INSERT INTO dt_Angkasa_MonthlyDeduction_Consolidated (ID, No_Kad_Pengenalan, " & _
                                                                                 "Bulan_Potongan, Kod_Potongan, Jumlah_Pokok, Nama_Ahli, Batch_No, Batch_Status) " & _
                                                                                 "VALUES ('" & Guid.NewGuid.ToString & "', '" & var_IC & "', '" & var_Bulan_Potongan & "', '" & _
                                                                                 var_Member_DeductionCode & "', " & var_Jumlah_Pokok & ", '" & var_Nama_Ahli & "', '" & _
                                                                                 var_Batch_No & "', " & 0 & ")"

                            cmdInsert_Consolidated_Monthly_Angkasa.ExecuteNonQuery()

                        ElseIf .Rows.Count = 1 Then
                            Dim var_Total_Deduction As Decimal = .Rows(0).Item("Jumlah_Pokok")

                            .Rows(0).Item("Jumlah_Pokok") = var_Total_Deduction + var_Jumlah_Pokok
                            da_Consolidated_MonthlyDeduction.Update(ds_Consolidate_MonthlyDeduction, "dt_Angkasa_MonthlyDeduction_Consolidated")
                        End If
                    End With
                    Return True

                Case Else

                    Dim dr_Member_PA_Policies As DataRow()
                    dr_Member_PA_Policies = ds_Consolidate_MonthlyDeduction.Tables("vi_Member_Policy_v3").Select("IC_New = '" & var_IC.Trim & "' " & _
                                                                                                                 "AND Cancellation_Date Is NULL")

                    Select Case dr_Member_PA_Policies.Length
                        Case 1
                            Dim var_Member_DeductionCode As String = dr_Member_PA_Policies(0).Item("Deduction_Code").ToString.Trim

                            Dim cmdSelect_Consolidate_Monthly_Angkasa As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                            cmdSelect_Consolidate_Monthly_Angkasa.CommandType = CommandType.Text
                            cmdSelect_Consolidate_Monthly_Angkasa.CommandText = "SELECT * FROM dt_Angkasa_MonthlyDeduction_Consolidated " & _
                                                                                "WHERE No_Kad_Pengenalan = '" & var_IC.Trim & "' " & _
                                                                                "AND Bulan_Potongan = '" & var_Bulan_Potongan & "' " & _
                                                                                "AND Kod_Potongan = '" & var_Member_DeductionCode & "' " & _
                                                                                "AND Batch_No = '" & var_Batch_No & "'"

                            Dim da_Consolidated_MonthlyDeduction As New SqlDataAdapter(cmdSelect_Consolidate_Monthly_Angkasa)
                            Dim cmdUpdate_Consolidate_Monthly_Angkasa As SqlCommandBuilder
                            cmdUpdate_Consolidate_Monthly_Angkasa = New SqlCommandBuilder(da_Consolidated_MonthlyDeduction)

                            da_Consolidated_MonthlyDeduction.Fill(ds_Consolidate_MonthlyDeduction, "dt_Angkasa_MonthlyDeduction_Consolidated")

                            With ds_Consolidate_MonthlyDeduction.Tables("dt_Angkasa_MonthlyDeduction_Consolidated")
                                If .Rows.Count = 0 Then
                                    Dim cmdInsert_Consolidated_Monthly_Angkasa As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                                    cmdInsert_Consolidated_Monthly_Angkasa.CommandType = CommandType.Text
                                    cmdInsert_Consolidated_Monthly_Angkasa.CommandText = "INSERT INTO dt_Angkasa_MonthlyDeduction_Consolidated (ID, No_Kad_Pengenalan, " & _
                                                                                         "Bulan_Potongan, Kod_Potongan, Jumlah_Pokok, Nama_Ahli, Batch_No, Batch_Status) " & _
                                                                                         "VALUES ('" & Guid.NewGuid.ToString & "', '" & var_IC & "', '" & var_Bulan_Potongan & "', '" & _
                                                                                         var_Member_DeductionCode & "', " & var_Jumlah_Pokok & ", '" & var_Nama_Ahli & "', '" & _
                                                                                         var_Batch_No & "', " & 0 & ")"

                                    cmdInsert_Consolidated_Monthly_Angkasa.ExecuteNonQuery()
                                ElseIf .Rows.Count = 1 Then
                                    Dim var_Total_Deduction As Decimal = .Rows(0).Item("Jumlah_Pokok")

                                    .Rows(0).Item("Jumlah_Pokok") = var_Total_Deduction + var_Jumlah_Pokok
                                    da_Consolidated_MonthlyDeduction.Update(ds_Consolidate_MonthlyDeduction, "dt_Angkasa_MonthlyDeduction_Consolidated")
                                End If
                            End With
                            Return True
                        Case Else
                            Return False
                    End Select
            End Select

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    Private Function Insert_Consolidated_Angkasa_MonthlyDeduction(ByVal var_IC As String, ByVal var_Bulan_Potongan As String, ByVal var_Kod_Potongan As String, ByVal var_Jumlah_Pokok As Decimal, ByVal var_Nama_Ahli As String, ByVal var_Batch_No As String)
        var_Nama_Ahli = var_Nama_Ahli.Replace("'", "''")
        Dim cmdInsert_Consolidated_Monthly_Angkasa As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdInsert_Consolidated_Monthly_Angkasa.CommandType = CommandType.Text
        cmdInsert_Consolidated_Monthly_Angkasa.CommandText = "INSERT INTO dt_Angkasa_MonthlyDeduction_Consolidated (ID, No_Kad_Pengenalan, " & _
                                                             "Bulan_Potongan, Kod_Potongan, Jumlah_Pokok, Nama_Ahli, Batch_No, Batch_Status) " & _
                                                             "VALUES ('" & Guid.NewGuid.ToString & "', '" & var_IC & "', '" & var_Bulan_Potongan & "', '" & _
                                                             var_Kod_Potongan & "', " & var_Jumlah_Pokok & ", '" & var_Nama_Ahli & "', '" & _
                                                             var_Batch_No & "', " & 0 & ")"
        Try
            cmdInsert_Consolidated_Monthly_Angkasa.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    Private Sub tsb_Export2Excel_Suspend_Account_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Export2Excel_Suspend_Account.Click
        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

        xls_workbook = xls_file.Workbooks.Add

        With xls_workbook.Worksheets(1)

            .Columns(1).NumberFormat = "@"
            .Columns(2).NumberFormat = "@"
            .Columns(3).NumberFormat = "@"
            .Columns(4).NumberFormat = "@"
            .Columns(5).NumberFormat = "##,##0.00"
            .Columns(6).NumberFormat = "@"
            .Columns(7).NumberFormat = "@"
            .Columns(8).NumberFormat = "@"

            .Cells(1, 1) = "No Kad Pengenalan"
            .Cells(1, 2) = "No Keahlian"
            .Cells(1, 3) = "Bulan Potongan"
            .Cells(1, 4) = "Kod Potongan"
            .Cells(1, 5) = "Jumlah Potongan"
            .Cells(1, 6) = "Nama Ahli"
            .Cells(1, 7) = "Batch No"
            .Cells(1, 8) = "Receiving Month"
        End With

        Dim cmdSelect_Monthly_SuspendAccount As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Monthly_SuspendAccount.CommandType = CommandType.Text
        cmdSelect_Monthly_SuspendAccount.CommandText = "SELECT * FROM vi_Monthly_SuspendAccount"

        Dim da_Monthly_SuspendAccount As New SqlDataAdapter(cmdSelect_Monthly_SuspendAccount)

        Dim ds_Monthly_SuspendAccount As New DataSet

        da_Monthly_SuspendAccount.Fill(ds_Monthly_SuspendAccount, "vi_Monthly_SuspendAccount")

        Dim dgvForm_counter As Integer = 0
        Dim batch_trans_counter As Integer = 0
        Dim row_index As Integer = 2
        Dim dr_Batch_Trans As DataRow()

        Try
            With Me.dgvForm
                Do While dgvForm_counter < .Rows.Count
                    batch_trans_counter = 0

                    If .Rows(dgvForm_counter).Cells(0).Value = "T" Then
                        dr_Batch_Trans = ds_Monthly_SuspendAccount.Tables("vi_Monthly_SuspendAccount").Select("Angkasa_Batch_No = '" & .Rows(dgvForm_counter).Cells(2).Value.ToString & "'")

                        Do While batch_trans_counter < dr_Batch_Trans.Length
                            With xls_workbook.Worksheets(1)
                                .Cells(row_index, 1) = dr_Batch_Trans(batch_trans_counter).Item("No_Kad_Pengenalan").ToString
                                .Cells(row_index, 2) = dr_Batch_Trans(batch_trans_counter).Item("Angkasa_FileNo").ToString
                                .Cells(row_index, 3) = dr_Batch_Trans(batch_trans_counter).Item("Angkasa_Bulan_Potongan").ToString
                                .Cells(row_index, 4) = dr_Batch_Trans(batch_trans_counter).Item("Angkasa_Kod_Potongan").ToString
                                .Cells(row_index, 5) = dr_Batch_Trans(batch_trans_counter).Item("Angkasa_Jumlah_Pokok")
                                .Cells(row_index, 6) = dr_Batch_Trans(batch_trans_counter).Item("Full_Name").ToString
                                .Cells(row_index, 7) = dr_Batch_Trans(batch_trans_counter).Item("Angkasa_Batch_No").ToString
                                .Cells(row_index, 8) = dr_Batch_Trans(batch_trans_counter).Item("Receiving_Month").ToString
                            End With
                            batch_trans_counter += 1
                            row_index += 1
                        Loop
                    End If
                    dgvForm_counter += 1
                Loop
            End With
            MsgBox("Export Complete")
            xls_file.Visible = True

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub tsb_ChangeRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_ChangeRequest.Click
        Dim grd_Borang2_79 As New grdBorang2_79
        grd_Borang2_79.MdiParent = Me.MdiParent
        grd_Borang2_79.Show()
    End Sub
    Private Sub tsb_Patch_Reprocess_KIV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Patch_Reprocess_KIV.Click
        Dim cmdSelect_Monthly_SuspendAccount As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Monthly_SuspendAccount.CommandType = CommandType.Text
        cmdSelect_Monthly_SuspendAccount.CommandText = "SELECT * FROM dt_Angkasa_Monthly_SuspendAccount"

        Dim da_Monthly_SuspendAccount As New SqlDataAdapter(cmdSelect_Monthly_SuspendAccount)

        Dim cmdSelect_Monthly_SuspendAccount_Update As SqlCommandBuilder
        cmdSelect_Monthly_SuspendAccount_Update = New SqlCommandBuilder(da_Monthly_SuspendAccount)
        Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy.CommandType = CommandType.Text
        cmdSelect_MemberPolicy.CommandText = "SELECT ID, IC_New, Deduction_Code, Deduction_Amount, Effective_Date, Cancellation_Date " & _
                                             "FROM vi_Member_Policy_v2"
        Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)
        Dim ds_MonthlyDeduction As New DataSet
        da_Monthly_SuspendAccount.Fill(ds_MonthlyDeduction, "dt_Angkasa_Monthly_SuspendAccount")
        da_MemberPolicy.Fill(ds_MonthlyDeduction, "vi_Member_Policy_v2")
        Dim Trans_counter As Integer = 0
        Dim Update_counter As Integer = 0
        Dim dr_MemberPolicy As DataRow()

        With ds_MonthlyDeduction.Tables("dt_Angkasa_Monthly_SuspendAccount")

            Do While Trans_counter < .Rows.Count
                dr_MemberPolicy = ds_MonthlyDeduction.Tables("vi_Member_Policy_v2").Select("IC_New = '" & .Rows(Trans_counter).Item("No_Kad_Pengenalan").ToString.Trim & "' " & _
                                                                                           "AND Deduction_Code = '" & .Rows(Trans_counter).Item("Angkasa_Kod_Potongan").ToString.Trim & "'")

                If dr_MemberPolicy.Length > 0 Then
                    If .Rows(Trans_counter).Item("Angkasa_Jumlah_Pokok") = dr_MemberPolicy(0).Item("Deduction_Amount") Then
                        If IsDBNull(dr_MemberPolicy(0).Item("Cancellation_Date")) = True Then
                            Insert_MemberPolicy_MonthlyDeduction(dr_MemberPolicy(0).Item("ID").ToString, _
                                                                 .Rows(Trans_counter).Item("Angkasa_Bulan_Potongan").ToString, _
                                                                 .Rows(Trans_counter).Item("Angkasa_Kod_Potongan").ToString, _
                                                                 .Rows(Trans_counter).Item("Angkasa_Jumlah_Pokok").ToString, _
                                                                 .Rows(Trans_counter).Item("Angkasa_Batch_No").ToString, _
                                                                 .Rows(Trans_counter).Item("Receiving_Month").ToString)

                            .Rows(Trans_counter).Delete()
                            da_Monthly_SuspendAccount.Update(ds_MonthlyDeduction, "dt_Angkasa_Monthly_SuspendAccount")

                            Update_counter += 1
                            If IsDBNull(dr_MemberPolicy(0).Item("Effective_Date")) = True Then
                                Update_MemberPolicy_Effective_Date(dr_MemberPolicy(0).Item("ID").ToString, .Rows(Trans_counter).Item("Receiving_Month").ToString)
                            End If
                        Else
                            If Len(dr_MemberPolicy(0).Item("Cancellation_Date").ToString.Trim) > 0 Then
                                Dim Cancel_Year As Integer = Year(dr_MemberPolicy(0).Item("Cancellation_Date"))
                                Dim Cancel_Month As Integer = Month(dr_MemberPolicy(0).Item("Cancellation_Date"))

                                If .Rows(Trans_counter).Item("Angkasa_Bulan_Potongan") > Val(Cancel_Year.ToString & Format(Cancel_Month, "00").ToString) Then
                                Else
                                    Insert_MemberPolicy_MonthlyDeduction(dr_MemberPolicy(0).Item("ID").ToString, _
                                                                         .Rows(Trans_counter).Item("Angkasa_Bulan_Potongan").ToString, _
                                                                         .Rows(Trans_counter).Item("Angkasa_Kod_Potongan").ToString, _
                                                                         .Rows(Trans_counter).Item("Angkasa_Jumlah_Pokok").ToString, _
                                                                         .Rows(Trans_counter).Item("Angkasa_Batch_No").ToString, _
                                                                         .Rows(Trans_counter).Item("Receiving_Month").ToString)

                                    .Rows(Trans_counter).Delete()
                                    da_Monthly_SuspendAccount.Update(ds_MonthlyDeduction, "dt_Angkasa_Monthly_SuspendAccount")

                                    Update_counter += 1
                                    If IsDBNull(dr_MemberPolicy(0).Item("Effective_Date")) = True Then
                                        Update_MemberPolicy_Effective_Date(dr_MemberPolicy(0).Item("ID").ToString, .Rows(Trans_counter).Item("Receiving_Month").ToString)
                                    End If
                                End If
                            Else
                                Insert_MemberPolicy_MonthlyDeduction(dr_MemberPolicy(0).Item("ID").ToString, _
                                                                    .Rows(Trans_counter).Item("Angkasa_Bulan_Potongan").ToString, _
                                                                    .Rows(Trans_counter).Item("Angkasa_Kod_Potongan").ToString, _
                                                                    .Rows(Trans_counter).Item("Angkasa_Jumlah_Pokok").ToString, _
                                                                    .Rows(Trans_counter).Item("Angkasa_Batch_No").ToString, _
                                                                    .Rows(Trans_counter).Item("Receiving_Month").ToString)

                                .Rows(Trans_counter).Delete()
                                da_Monthly_SuspendAccount.Update(ds_MonthlyDeduction, "dt_Angkasa_Monthly_SuspendAccount")

                                Update_counter += 1
                                If IsDBNull(dr_MemberPolicy(0).Item("Effective_Date")) = True Then
                                    Update_MemberPolicy_Effective_Date(dr_MemberPolicy(0).Item("ID").ToString, .Rows(Trans_counter).Item("Receiving_Month").ToString)
                                End If


                            End If

                        End If

                    End If
                End If
                Trans_counter += 1
            Loop
        End With
        MsgBox("Total records updated: " & Update_counter.ToString & "/" & ds_MonthlyDeduction.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows.Count.ToString)
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
    Private Sub tsb_ProcessMonthlyDeduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_ProcessMonthlyDeduction.Click
        Dim fPP As New fPremiumProcess
        fPP.Show()
    End Sub
End Class





