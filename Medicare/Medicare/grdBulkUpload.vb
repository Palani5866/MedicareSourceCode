Public Class grdBulkUpload
    Dim Conn As DbConnection = New SqlConnection

    Private Sub grdMember_BulkUpload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub

    Private Sub grdMember_BulkUpload_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub tsb_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Save.Click
        Select Case Me.tss_Parent.Text.Trim
            Case "Member"
                Me.Insert_Member()
            Case "Monthly Deduction"
                Me.Insert_Angkasa_MonthlyDeduction()
            Case "Report - Wrong Code Requested"
                Export_Excel("Report - Wrong Code Requested")
            Case "Report - Wrong Amount Requested"
                Export_Excel_WrongAmount_Requested()
            Case "Report - Members MIA"
                Export_Excel("Report - Members MIA")
            Case "Report - List Outstanding Payment (RENEWAL CASES)"
                Export_Excel_Outstanding_Payment("RENEW")
            Case "Report - List Outstanding Payment (NEW CASES)"
                Export_Excel_Outstanding_Payment("NEW")
            Case "Report - List Members (0500)"
                Export_Excel_ProductCode_500()
            Case "Report - Members without Deduction Code"
                Export_Excel("Report-Members wo Kod Potongan")
            Case Else
                Export_Excel_New_Members()
        End Select
    End Sub

    Private Sub Export_Excel(ByVal Report_Title As String)
        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

        xls_workbook = xls_file.Workbooks.Add

        With xls_workbook.Worksheets(1)
            .Name = Report_Title

            .Columns(1).NumberFormat = "@"
            .Columns(2).NumberFormat = "@"
            .Columns(3).NumberFormat = "@"
            .Columns(4).NumberFormat = "@"
            .Columns(5).NumberFormat = "##,##0.00"
            .Columns(6).NumberFormat = "@"
            .Columns(7).NumberFormat = "@"

            .Cells(1, 1) = "No Keahlian"
            .Cells(1, 2) = "Nama Ahli"
            .Cells(1, 3) = "No Kad Pengenalan"
            .Cells(1, 4) = "Kod Potongan(Angkasa)"
            .Cells(1, 5) = "Jumlah Potongan(Angkasa)"
            .Cells(1, 6) = "Bulan Potongan"
            .Cells(1, 7) = "Batch No"

            Dim dgvForm_counter As Integer = 0
            Dim row_index As Integer = 2

            Do While dgvForm_counter < Me.dgvForm.Rows.Count
                .Cells(row_index, 1) = Me.dgvForm.Rows(dgvForm_counter).Cells(0).Value.ToString
                .Cells(row_index, 2) = Me.dgvForm.Rows(dgvForm_counter).Cells(1).Value.ToString
                .Cells(row_index, 3) = Me.dgvForm.Rows(dgvForm_counter).Cells(2).Value.ToString
                .Cells(row_index, 4) = Me.dgvForm.Rows(dgvForm_counter).Cells(3).Value.ToString
                .Cells(row_index, 5) = Me.dgvForm.Rows(dgvForm_counter).Cells(4).Value.ToString
                .Cells(row_index, 6) = Me.dgvForm.Rows(dgvForm_counter).Cells(5).Value.ToString
                .Cells(row_index, 7) = Me.dgvForm.Rows(dgvForm_counter).Cells(6).Value.ToString
                row_index += 1
                dgvForm_counter += 1
            Loop
            xls_file.Visible = True
        End With
    End Sub

    Private Sub Export_Excel_WrongAmount_Requested()
        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

        xls_workbook = xls_file.Workbooks.Add

        With xls_workbook.Worksheets(1)
            .Name = "Report - Wrong Amount Requested"

            .Columns(1).NumberFormat = "@"
            .Columns(2).NumberFormat = "@"
            .Columns(3).NumberFormat = "@"
            .Columns(4).NumberFormat = "@"
            .Columns(5).NumberFormat = "##,##0.00"
            .Columns(6).NumberFormat = "##,##0.00"
            .Columns(7).NumberFormat = "@"
            .Columns(8).NumberFormat = "@"

            .Cells(1, 1) = "No Keahlian"
            .Cells(1, 2) = "Nama Ahli"
            .Cells(1, 3) = "No Kad Pengenalan"
            .cells(1, 4) = "Kod Potongan(Angkasa)"
            .Cells(1, 5) = "Jumlah Requested(Medicare)"
            .Cells(1, 6) = "Jumlah Potongan(Angkasa)"
            .Cells(1, 7) = "Bulan Potongan"
            .Cells(1, 8) = "Batch No"

            Dim dgvForm_counter As Integer = 0
            Dim row_index As Integer = 2

            Do While dgvForm_counter < Me.dgvForm.Rows.Count
                .Cells(row_index, 1) = Me.dgvForm.Rows(dgvForm_counter).Cells(0).Value.ToString
                .Cells(row_index, 2) = Me.dgvForm.Rows(dgvForm_counter).Cells(1).Value.ToString
                .Cells(row_index, 3) = Me.dgvForm.Rows(dgvForm_counter).Cells(2).Value.ToString
                .Cells(row_index, 4) = Me.dgvForm.Rows(dgvForm_counter).Cells(3).Value.ToString
                .Cells(row_index, 5) = Me.dgvForm.Rows(dgvForm_counter).Cells(4).Value.ToString
                .Cells(row_index, 6) = Me.dgvForm.Rows(dgvForm_counter).Cells(5).Value.ToString
                .Cells(row_index, 7) = Me.dgvForm.Rows(dgvForm_counter).Cells(6).Value.ToString
                .Cells(row_index, 8) = Me.dgvForm.Rows(dgvForm_counter).Cells(7).Value.ToString
                row_index += 1
                dgvForm_counter += 1
            Loop
            xls_file.Visible = True
        End With
    End Sub

    Private Sub Export_Excel_New_Members()
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
            .Columns(7).NumberFormat = "dd/MM/yyyy"
            .Columns(8).NumberFormat = "dd/MM/yyyy"

            .Cells(1, 1) = "No Keahlian"
            .Cells(1, 2) = "Nama Ahli"
            .Cells(1, 3) = "No Kad Pengenalan"
            .Cells(1, 4) = "Kod Potongan"
            .Cells(1, 5) = "Jumlah Potongan"
            .Cells(1, 6) = "Agent Code"
            .Cells(1, 7) = "Submission Date"
            .Cells(1, 8) = "1st Payment Date"

            Dim dgvForm_counter As Integer = 0
            Dim row_index As Integer = 2

            Do While dgvForm_counter < Me.dgvForm.Rows.Count
                .Cells(row_index, 1) = Me.dgvForm.Rows(dgvForm_counter).Cells(0).Value.ToString
                .Cells(row_index, 2) = Me.dgvForm.Rows(dgvForm_counter).Cells(1).Value.ToString
                .Cells(row_index, 3) = Me.dgvForm.Rows(dgvForm_counter).Cells(2).Value.ToString
                .Cells(row_index, 4) = Me.dgvForm.Rows(dgvForm_counter).Cells(3).Value.ToString
                .Cells(row_index, 5) = Me.dgvForm.Rows(dgvForm_counter).Cells(4).Value.ToString
                .Cells(row_index, 6) = Me.dgvForm.Rows(dgvForm_counter).Cells(5).Value.ToString
                .Cells(row_index, 7) = Me.dgvForm.Rows(dgvForm_counter).Cells(6).Value
                .Cells(row_index, 8) = Me.dgvForm.Rows(dgvForm_counter).Cells(7).Value
                row_index += 1
                dgvForm_counter += 1
            Loop
            xls_file.Visible = True
        End With
    End Sub

    Private Sub Export_Excel_Outstanding_Payment(ByVal Report_Title As String)
        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

        xls_workbook = xls_file.Workbooks.Add

        With xls_workbook.Worksheets(1)
            .Name = Report_Title

            .Columns(1).NumberFormat = "@"
            .Columns(2).NumberFormat = "@"
            .Columns(3).NumberFormat = "@"
            .Columns(4).NumberFormat = "@"
            .Columns(5).NumberFormat = "##,##0.00"
            .Columns(6).NumberFormat = "@"
            .Columns(7).NumberFormat = "dd/MM/yyyy"
            If Report_Title = "RENEW" Then
                .Columns(8).NumberFormat = "dd/MM/yyyy"
                .columns(9).NUmberFormat = "@"
            End If

            .Cells(1, 1) = "No Keahlian"
            .Cells(1, 2) = "Nama Ahli"
            .Cells(1, 3) = "No Kad Pengenalan"
            .Cells(1, 4) = "Kod Potongan"
            .Cells(1, 5) = "Jumlah Potongan"
            .Cells(1, 6) = "Agent Code"
            .Cells(1, 7) = "Submission Date"
            If Report_Title = "RENEW" Then
                .Cells(1, 8) = "1st Payment Date"
                .Cells(1, 9) = "Last Deduction Month"
            End If

            Dim dgvForm_counter As Integer = 0
            Dim row_index As Integer = 2

            Do While dgvForm_counter < Me.dgvForm.Rows.Count
                .Cells(row_index, 1) = Me.dgvForm.Rows(dgvForm_counter).Cells(0).Value.ToString
                .Cells(row_index, 2) = Me.dgvForm.Rows(dgvForm_counter).Cells(1).Value.ToString
                .Cells(row_index, 3) = Me.dgvForm.Rows(dgvForm_counter).Cells(2).Value.ToString
                .Cells(row_index, 4) = Me.dgvForm.Rows(dgvForm_counter).Cells(3).Value.ToString
                .Cells(row_index, 5) = Me.dgvForm.Rows(dgvForm_counter).Cells(4).Value.ToString
                .Cells(row_index, 6) = Me.dgvForm.Rows(dgvForm_counter).Cells(5).Value.ToString
                .Cells(row_index, 7) = Me.dgvForm.Rows(dgvForm_counter).Cells(6).Value
                If Report_Title = "RENEW" Then
                    .Cells(row_index, 8) = Me.dgvForm.Rows(dgvForm_counter).Cells(7).Value
                    .Cells(row_index, 9) = Me.dgvForm.Rows(dgvForm_counter).Cells(8).Value.ToString
                End If
                row_index += 1
                dgvForm_counter += 1
            Loop
            xls_file.Visible = True
        End With
    End Sub

    Private Sub Export_Excel_ProductCode_500()
        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

        xls_workbook = xls_file.Workbooks.Add

        With xls_workbook.Worksheets(1)


            .Columns(1).NumberFormat = "@"
            .Columns(2).NumberFormat = "@"
            .Columns(3).NumberFormat = "@"
            .Columns(4).NumberFormat = "@"
            .columns(5).NumberFormat = "@"
            .Columns(6).NumberFormat = "##,##0.00"

            .Cells(1, 1) = "SYSTEM ID"
            .Cells(1, 2) = "No Keahlian"
            .Cells(1, 3) = "Nama Ahli"
            .Cells(1, 4) = "No Kad Pengenalan"
            .Cells(1, 5) = "Kod Potongan(Angkasa)"
            .Cells(1, 6) = "Jumlah Potongan(Angkasa)"

            Dim dgvForm_counter As Integer = 0
            Dim row_index As Integer = 2

            Do While dgvForm_counter < Me.dgvForm.Rows.Count
                .Cells(row_index, 1) = Me.dgvForm.Rows(dgvForm_counter).Cells(0).Value.ToString
                .Cells(row_index, 2) = Me.dgvForm.Rows(dgvForm_counter).Cells(1).Value.ToString
                .Cells(row_index, 3) = Me.dgvForm.Rows(dgvForm_counter).Cells(2).Value.ToString
                .Cells(row_index, 4) = Me.dgvForm.Rows(dgvForm_counter).Cells(3).Value.ToString
                .Cells(row_index, 5) = Me.dgvForm.Rows(dgvForm_counter).Cells(4).Value.ToString
                .Cells(row_index, 6) = Me.dgvForm.Rows(dgvForm_counter).Cells(5).Value.ToString
                row_index += 1
                dgvForm_counter += 1
            Loop
            xls_file.Visible = True
        End With
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
            Change_Deduction_Code = "0" & var_Deduction_Code.ToString.Trim
            Return Change_Deduction_Code
        Else
            Change_Deduction_Code = var_Deduction_Code
            Return Change_Deduction_Code
        End If
    End Function

    Private Sub Insert_Member()

        Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member.CommandType = CommandType.Text
        cmdSelect_Member.CommandText = "SELECT * FROM dt_Member"

        Dim da_Member As New SqlDataAdapter(cmdSelect_Member)

        Dim cmdInsert_Member As SqlCommandBuilder
        cmdInsert_Member = New SqlCommandBuilder(da_Member)


        Dim cmdSelect_Member_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Policy.CommandType = CommandType.Text
        cmdSelect_Member_Policy.CommandText = "SELECT * FROM dt_Member_Policy"

        Dim da_Member_Policy As New SqlDataAdapter(cmdSelect_Member_Policy)

        Dim cmdInsert_Member_Policy As SqlCommandBuilder
        cmdInsert_Member_Policy = New SqlCommandBuilder(da_Member_Policy)


        Dim ds_UploadBulk As New DataSet


        da_Member.Fill(ds_UploadBulk, "dt_Member")
        da_Member_Policy.Fill(ds_UploadBulk, "dt_Member_Policy")

        Dim dgvForm_counter As Integer = 0

        Dim dr_Member_New As DataRow
        Dim dr_Member_Policy_New As DataRow
        Dim dr_Member_Select As DataRow()
        Dim dr_Member_Policy_Select As DataRow()
        Dim Member_ID As String

        Try
            With Me.dgvForm
                Do While dgvForm_counter < .Rows.Count
                    dr_Member_Select = ds_UploadBulk.Tables("dt_Member").Select("IC_New = '" & Me.Change_IC(.Rows(dgvForm_counter).Cells(2).Value.ToString) & "'")

                    If dr_Member_Select.Length = 0 Then

                        dr_Member_New = ds_UploadBulk.Tables("dt_Member").NewRow

                        Member_ID = Guid.NewGuid.ToString

                        dr_Member_New.Item("ID") = Member_ID
                        dr_Member_New.Item("Angkasa_FileNo") = .Rows(dgvForm_counter).Cells(0).Value.ToString.Trim
                        dr_Member_New.Item("Full_Name") = .Rows(dgvForm_counter).Cells(1).Value.ToString.Trim
                        dr_Member_New.Item("IC_New") = Me.Change_IC(.Rows(dgvForm_counter).Cells(2).Value.ToString)

                        ds_UploadBulk.Tables("dt_Member").Rows.Add(dr_Member_New)
                        da_Member.Update(ds_UploadBulk, "dt_Member")


                        dr_Member_Policy_New = ds_UploadBulk.Tables("dt_Member_Policy").NewRow

                        dr_Member_Policy_New.Item("ID") = Guid.NewGuid.ToString
                        dr_Member_Policy_New.Item("Member_ID") = Member_ID
                        dr_Member_Policy_New.Item("Deduction_Code") = Me.Change_Deduction_Code(.Rows(dgvForm_counter).Cells(3).Value.ToString)
                        dr_Member_Policy_New.Item("Deduction_Amount") = .Rows(dgvForm_counter).Cells(4).Value
                        dr_Member_Policy_New.Item("Agent_Code") = .Rows(dgvForm_counter).Cells(5).Value.ToString.Trim
                        dr_Member_Policy_New.Item("Submission_Date") = .Rows(dgvForm_counter).Cells(6).Value
                        dr_Member_Policy_New.Item("Effective_Date") = .Rows(dgvForm_counter).Cells(7).Value

                        Console.WriteLine("dt_Master_Policy-A")
                        Console.WriteLine(.Rows(dgvForm_counter).Cells(0).Value.ToString.Trim)
                        Console.WriteLine(.Rows(dgvForm_counter).Cells(1).Value.ToString.Trim)
                        Console.WriteLine(.Rows(dgvForm_counter).Cells(3).Value.ToString.Trim)

                        ds_UploadBulk.Tables("dt_Member_Policy").Rows.Add(dr_Member_Policy_New)
                        da_Member_Policy.Update(ds_UploadBulk, "dt_Member_Policy")
                    Else
                        Member_ID = dr_Member_Select(0).Item("ID").ToString

                        dr_Member_Policy_Select = ds_UploadBulk.Tables("dt_Member_Policy").Select("Member_ID = '" & Member_ID & "' AND Deduction_Code = '" & _
                                                                                                  Me.Change_Deduction_Code(.Rows(dgvForm_counter).Cells(3).Value.ToString) & "'")

                        If dr_Member_Policy_Select.Length = 0 Then

                            dr_Member_Policy_New = ds_UploadBulk.Tables("dt_Member_Policy").NewRow

                            dr_Member_Policy_New.Item("ID") = Guid.NewGuid.ToString
                            dr_Member_Policy_New.Item("Member_ID") = Member_ID
                            dr_Member_Policy_New.Item("Deduction_Code") = Me.Change_Deduction_Code(.Rows(dgvForm_counter).Cells(3).Value.ToString)
                            dr_Member_Policy_New.Item("Deduction_Amount") = .Rows(dgvForm_counter).Cells(4).Value
                            dr_Member_Policy_New.Item("Agent_Code") = .Rows(dgvForm_counter).Cells(5).Value.ToString.Trim
                            dr_Member_Policy_New.Item("Submission_Date") = .Rows(dgvForm_counter).Cells(6).Value
                            dr_Member_Policy_New.Item("Effective_Date") = .Rows(dgvForm_counter).Cells(7).Value

                            Console.WriteLine("dt_Master_Policy-B")
                            Console.WriteLine(.Rows(dgvForm_counter).Cells(0).Value.ToString.Trim)
                            Console.WriteLine(.Rows(dgvForm_counter).Cells(1).Value.ToString.Trim)
                            Console.WriteLine(.Rows(dgvForm_counter).Cells(3).Value.ToString.Trim)

                            ds_UploadBulk.Tables("dt_Member_Policy").Rows.Add(dr_Member_Policy_New)
                            da_Member_Policy.Update(ds_UploadBulk, "dt_Member_Policy")
                        Else
                            Console.WriteLine(Member_ID & " found in dt_Member_Policy")
                        End If
                    End If
                    dgvForm_counter += 1
                Loop
            End With
            MsgBox("Total Record Uploaded:" & dgvForm_counter)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Insert_Angkasa_MonthlyDeduction()

        Dim cmdSelect_Angkasa_MonthlyDeduction_Master As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Angkasa_MonthlyDeduction_Master.CommandType = CommandType.Text
        cmdSelect_Angkasa_MonthlyDeduction_Master.CommandText = "SELECT * FROM dt_Angkasa_MonthlyDeduction_Master"

        Dim da_Angkasa_MonthlyDeduction_Master As New SqlDataAdapter(cmdSelect_Angkasa_MonthlyDeduction_Master)

        Dim cmdInsert_Angkasa_MonthlyDeduction_Master As SqlCommandBuilder
        cmdInsert_Angkasa_MonthlyDeduction_Master = New SqlCommandBuilder(da_Angkasa_MonthlyDeduction_Master)


        Dim cmdSelect_Angkasa_MonthlyDeduction_Child As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Angkasa_MonthlyDeduction_Child.CommandType = CommandType.Text
        cmdSelect_Angkasa_MonthlyDeduction_Child.CommandText = "SELECT * FROM dt_Angkasa_MonthlyDeduction_Child"

        Dim da_Angkasa_MonthlyDeduction_Child As New SqlDataAdapter(cmdSelect_Angkasa_MonthlyDeduction_Child)

        Dim cmdInsert_Angkasa_MonthlyDeduction_Child As SqlCommandBuilder
        cmdInsert_Angkasa_MonthlyDeduction_Child = New SqlCommandBuilder(da_Angkasa_MonthlyDeduction_Child)


        Dim cmdSelect_MonthlyDeduction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MonthlyDeduction.CommandType = CommandType.Text
        cmdSelect_MonthlyDeduction.CommandText = "SELECT * FROM dt_MonthlyDeduction"

        Dim da_MonthlyDeduction As New SqlDataAdapter(cmdSelect_MonthlyDeduction)

        Dim cmdInsert_MonthlyDeduction As SqlCommandBuilder
        cmdInsert_MonthlyDeduction = New SqlCommandBuilder(da_MonthlyDeduction)



        Dim ds_UploadBulk As New DataSet


        da_Angkasa_MonthlyDeduction_Master.Fill(ds_UploadBulk, "dt_Angkasa_MonthlyDeduction_Master")
        da_Angkasa_MonthlyDeduction_Child.Fill(ds_UploadBulk, "dt_Angkasa_MonthlyDeduction_Child")
        da_MonthlyDeduction.Fill(ds_UploadBulk, "dt_MonthlyDeduction")

        Dim dgvForm_counter As Integer = 0
        Dim Trans_Master_counter As Integer = 0
        Dim Trans_Child_counter As Integer = 0

        Dim dr_Angkasa_Trans_Master_New As DataRow
        Dim dr_Angkasa_Trans_Child_New As DataRow
        Dim dr_MonthlyDeduction_New As DataRow

        Try
            With Me.dgvForm
                Do While dgvForm_counter < .Rows.Count
                    If .Rows(dgvForm_counter).Cells(0).Value.ToString.Trim = "0" Then

                        dr_Angkasa_Trans_Master_New = ds_UploadBulk.Tables("dt_Angkasa_MonthlyDeduction_Master").NewRow

                        dr_Angkasa_Trans_Master_New.Item("Jenis_Rekod") = .Rows(dgvForm_counter).Cells(0).Value.ToString.Trim
                        dr_Angkasa_Trans_Master_New.Item("Kod_Kad_Pengenalan") = .Rows(dgvForm_counter).Cells(1).Value.ToString.Trim
                        dr_Angkasa_Trans_Master_New.Item("No_Kad_Pengenalan") = .Rows(dgvForm_counter).Cells(2).Value.ToString.Trim
                        dr_Angkasa_Trans_Master_New.Item("Kod_Koperasi") = .Rows(dgvForm_counter).Cells(3).Value.ToString.Trim
                        dr_Angkasa_Trans_Master_New.Item("No_Keahlian") = .Rows(dgvForm_counter).Cells(4).Value.ToString.Trim
                        dr_Angkasa_Trans_Master_New.Item("Bulan_Potongan") = .Rows(dgvForm_counter).Cells(5).Value.ToString.Trim
                        dr_Angkasa_Trans_Master_New.Item("Kod_Potongan") = .Rows(dgvForm_counter).Cells(6).Value.ToString.Trim
                        dr_Angkasa_Trans_Master_New.Item("Jumlah_Tuntutan") = .Rows(dgvForm_counter).Cells(7).Value
                        dr_Angkasa_Trans_Master_New.Item("Jumlah_Bayaran") = .Rows(dgvForm_counter).Cells(8).Value
                        dr_Angkasa_Trans_Master_New.Item("Lain_Lain") = .Rows(dgvForm_counter).Cells(9).Value.ToString.Trim
                        dr_Angkasa_Trans_Master_New.Item("No_KP_Lama") = .Rows(dgvForm_counter).Cells(10).Value.ToString.Trim
                        dr_Angkasa_Trans_Master_New.Item("Batch_No") = .Rows(dgvForm_counter).Cells(11).Value.ToString.Trim

                        ds_UploadBulk.Tables("dt_Angkasa_MonthlyDeduction_Master").Rows.Add(dr_Angkasa_Trans_Master_New)
                        da_Angkasa_MonthlyDeduction_Master.Update(ds_UploadBulk, "dt_Angkasa_MonthlyDeduction_Master")
                        Trans_Master_counter += 1
                    Else

                        dr_Angkasa_Trans_Child_New = ds_UploadBulk.Tables("dt_Angkasa_MonthlyDeduction_Child").NewRow

                        dr_Angkasa_Trans_Child_New.Item("Jenis_Rekod") = .Rows(dgvForm_counter).Cells(0).Value.ToString.Trim
                        dr_Angkasa_Trans_Child_New.Item("Kod_Kad_Pengenalan") = .Rows(dgvForm_counter).Cells(1).Value.ToString.Trim
                        dr_Angkasa_Trans_Child_New.Item("No_Kad_Pengenalan") = .Rows(dgvForm_counter).Cells(2).Value.ToString.Trim
                        dr_Angkasa_Trans_Child_New.Item("Kod_Koperasi") = .Rows(dgvForm_counter).Cells(3).Value.ToString.Trim
                        dr_Angkasa_Trans_Child_New.Item("No_Keahlian") = .Rows(dgvForm_counter).Cells(4).Value.ToString.Trim
                        dr_Angkasa_Trans_Child_New.Item("Bulan_Potongan") = .Rows(dgvForm_counter).Cells(5).Value.ToString.Trim
                        dr_Angkasa_Trans_Child_New.Item("Kod_Potongan") = .Rows(dgvForm_counter).Cells(6).Value.ToString.Trim
                        dr_Angkasa_Trans_Child_New.Item("Jumlah_Pokok") = .Rows(dgvForm_counter).Cells(7).Value
                        dr_Angkasa_Trans_Child_New.Item("Jumlah_Faedah") = .Rows(dgvForm_counter).Cells(8).Value
                        dr_Angkasa_Trans_Child_New.Item("Nama_Ahli") = .Rows(dgvForm_counter).Cells(9).Value.ToString.Trim
                        dr_Angkasa_Trans_Child_New.Item("No_KP_Lama") = .Rows(dgvForm_counter).Cells(10).Value.ToString.Trim
                        dr_Angkasa_Trans_Child_New.Item("Batch_No") = .Rows(dgvForm_counter).Cells(11).Value.ToString.Trim
                        dr_Angkasa_Trans_Child_New.Item("Batch_Status") = 0         '##0 = New
                        dr_Angkasa_Trans_Child_New.Item("Batch_ProcessCycle") = 0   '##Set as counter to detect how many times we process this record
                        dr_Angkasa_Trans_Child_New.Item("Batch_GUID") = Guid.NewGuid

                        ds_UploadBulk.Tables("dt_Angkasa_MonthlyDeduction_Child").Rows.Add(dr_Angkasa_Trans_Child_New)
                        da_Angkasa_MonthlyDeduction_Child.Update(ds_UploadBulk, "dt_Angkasa_MonthlyDeduction_Child")
                        Trans_Child_counter += 1
                    End If
                    dgvForm_counter += 1
                Loop

                If .Rows.Count > 0 Then

                    dr_MonthlyDeduction_New = ds_UploadBulk.Tables("dt_MonthlyDeduction").NewRow

                    dr_MonthlyDeduction_New.Item("ID") = Guid.NewGuid.ToString
                    dr_MonthlyDeduction_New.Item("Batch_No") = .Rows(.Rows.Count - 1).Cells(11).Value.ToString.Trim
                    dr_MonthlyDeduction_New.Item("Batch_RecordCount") = Trans_Child_counter
                    dr_MonthlyDeduction_New.Item("Batch_Record_Processed") = 0
                    dr_MonthlyDeduction_New.Item("Batch_Upload_Date") = Now()
                    dr_MonthlyDeduction_New.Item("Batch_Upload_By") = "Test"
                    dr_MonthlyDeduction_New.Item("Batch_Status") = 0 '##0 = New

                    ds_UploadBulk.Tables("dt_MonthlyDeduction").Rows.Add(dr_MonthlyDeduction_New)
                    da_MonthlyDeduction.Update(ds_UploadBulk, "dt_MonthlyDeduction")
                End If

            End With

            MsgBox("Total Record Uploaded:" & dgvForm_counter)
            MsgBox("Total Record (Master) Uploaded:" & Trans_Master_counter)
            MsgBox("Total Record (Child) Uploaded:" & Trans_Child_counter)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Insert_Angkasa_Trans_Error()

        Dim cmdSelect_Angkasa_MonthlyDeduction_Child As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Angkasa_MonthlyDeduction_Child.CommandType = CommandType.Text
        cmdSelect_Angkasa_MonthlyDeduction_Child.CommandText = "SELECT * FROM dt_Angkasa_MonthlyDeduction_Child"

        Dim da_Angkasa_MonthlyDeduction_Child As New SqlDataAdapter(cmdSelect_Angkasa_MonthlyDeduction_Child)

        Dim cmdInsert_Angkasa_MonthlyDeduction_Child As SqlCommandBuilder
        cmdInsert_Angkasa_MonthlyDeduction_Child = New SqlCommandBuilder(da_Angkasa_MonthlyDeduction_Child)


        Dim ds_UploadBulk As New DataSet


        da_Angkasa_MonthlyDeduction_Child.Fill(ds_UploadBulk, "dt_Angkasa_MonthlyDeduction_Child")

        Dim dgvForm_counter As Integer = 0
        Dim dr_Angkasa_Trans_Child_New As DataRow

        Try
            With Me.dgvForm
                Do While dgvForm_counter < .Rows.Count

                    dr_Angkasa_Trans_Child_New = ds_UploadBulk.Tables("dt_Angkasa_MonthlyDeduction_Child").NewRow

                    dr_Angkasa_Trans_Child_New.Item("Jenis_Rekod") = .Rows(dgvForm_counter).Cells(0).Value.ToString.Trim
                    dr_Angkasa_Trans_Child_New.Item("Kod_Kad_Pengenalan") = .Rows(dgvForm_counter).Cells(1).Value.ToString.Trim
                    dr_Angkasa_Trans_Child_New.Item("No_Kad_Pengenalan") = .Rows(dgvForm_counter).Cells(2).Value.ToString.Trim
                    dr_Angkasa_Trans_Child_New.Item("Kod_Koperasi") = .Rows(dgvForm_counter).Cells(3).Value.ToString.Trim
                    dr_Angkasa_Trans_Child_New.Item("No_Keahlian") = .Rows(dgvForm_counter).Cells(4).Value.ToString.Trim
                    dr_Angkasa_Trans_Child_New.Item("Bulan_Potongan") = .Rows(dgvForm_counter).Cells(5).Value.ToString.Trim
                    dr_Angkasa_Trans_Child_New.Item("Kod_Potongan") = .Rows(dgvForm_counter).Cells(6).Value.ToString.Trim
                    dr_Angkasa_Trans_Child_New.Item("Jumlah_Pokok") = .Rows(dgvForm_counter).Cells(7).Value
                    dr_Angkasa_Trans_Child_New.Item("Jumlah_Faedah") = .Rows(dgvForm_counter).Cells(8).Value
                    dr_Angkasa_Trans_Child_New.Item("Nama_Ahli") = .Rows(dgvForm_counter).Cells(9).Value.ToString.Trim
                    dr_Angkasa_Trans_Child_New.Item("No_KP_Lama") = .Rows(dgvForm_counter).Cells(10).Value.ToString.Trim
                    dr_Angkasa_Trans_Child_New.Item("Batch_No") = .Rows(dgvForm_counter).Cells(11).Value.ToString.Trim
                    dr_Angkasa_Trans_Child_New.Item("Batch_Status") = 0         '##0 = New
                    dr_Angkasa_Trans_Child_New.Item("Batch_ProcessCycle") = 0   '##Set as counter to detect how many times we process this record
                    dr_Angkasa_Trans_Child_New.Item("Batch_GUID") = Guid.NewGuid

                    ds_UploadBulk.Tables("dt_Angkasa_MonthlyDeduction_Child").Rows.Add(dr_Angkasa_Trans_Child_New)
                    da_Angkasa_MonthlyDeduction_Child.Update(ds_UploadBulk, "dt_Angkasa_MonthlyDeduction_Child")
                    dgvForm_counter += 1
                Loop
            End With

            MsgBox("Total Record Uploaded:" & dgvForm_counter)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub tsb_Filter_Errors_Only_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Filter_Errors_Only.Click
        Apply_Filter("Success")
    End Sub

    Private Sub tsb_Filter_Success_Only_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Filter_Success_Only.Click
        Apply_Filter("Error")
    End Sub

    Private Sub Apply_Filter(ByVal var_filter As String)
        Dim dgvForm_counter As Integer = 0

        With Me.dgvForm
            Do While dgvForm_counter < .Rows.Count
                If .Rows(dgvForm_counter).Cells(0).Value = var_filter Then
                    .Rows(dgvForm_counter).Visible = False
                Else
                    .Rows(dgvForm_counter).Visible = True
                End If
                dgvForm_counter += 1
            Loop
        End With
    End Sub

    Private Sub dgvForm_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvForm.CellValidating
        If Me.tss_Parent.Text.Trim = "Change Request" Then
            If e.ColumnIndex = 6 Then
                With Me.dgvForm
                    If .CurrentCell.IsInEditMode = True Then
                        MsgBox("Validate Cell's Value in Column 6")
                    End If
                End With

            End If

            If e.ColumnIndex = 7 Then
                With Me.dgvForm
                    If .CurrentCell.IsInEditMode = True Then
                        MsgBox("Validate Cell's Value in Column 7")
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub tsb_Filter_Errors_Wrong_KodPotongan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Filter_Errors_Wrong_KodPotongan.Click

        Dim cmdSelect_Deduction_Master As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Deduction_Master.CommandType = CommandType.Text
        cmdSelect_Deduction_Master.CommandText = "SELECT * FROM dt_Deduction_Master"

        Dim da_Deduction_Master As New SqlDataAdapter(cmdSelect_Deduction_Master)


        Dim ds_Deduction_Master As New DataSet


        da_Deduction_Master.Fill(ds_Deduction_Master, "dt_Deduction_Master")



        Dim grdError_Report As New grdBulkUpload
        grdError_Report.Text = "Exceptional Report - Wrong Code (Kod Potongan) Requested"
        grdError_Report.tss_Parent.Text = "Report - Wrong Code Requested"
        grdError_Report.tsb_Save.Enabled = True
        grdError_Report.tsb_Filter.Visible = False

        With grdError_Report.dgvForm
            .Columns.Add("Angkasa_Member_ID", "No Keahlian")
            .Columns.Add("Full_Name", "Nama Ahli")
            .Columns.Add("IC", "No Kad Pengenalan")
            .Columns.Add("Deduction_Code", "Kod Potongan(Angkasa)")
            .Columns.Add("Amount_Received", "Jumlah Potongan(Angkasa)")
            .Columns.Add("Deduction_Month", "Bulan Potongan")
            .Columns.Add("Batch_No", "Batch No")
        End With

        Dim dgvForm_counter As Integer = 0
        Dim dr_Deduction_Master As DataRow()

        With Me.dgvForm
            Do While dgvForm_counter < .Rows.Count
                dr_Deduction_Master = ds_Deduction_Master.Tables("dt_Deduction_Master").Select("Deduction_Code = '" & .Rows(dgvForm_counter).Cells(7).Value.ToString & "'")

                If dr_Deduction_Master.Length = 0 Then
                    With grdError_Report.dgvForm
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells(0).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(5).Value.ToString
                        .Rows(.Rows.Count - 1).Cells(1).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(10).Value.ToString
                        .Rows(.Rows.Count - 1).Cells(2).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(3).Value.ToString
                        .Rows(.Rows.Count - 1).Cells(3).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(7).Value.ToString
                        .Rows(.Rows.Count - 1).Cells(4).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(8).Value
                        .Rows(.Rows.Count - 1).Cells(5).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(6).Value.ToString
                        .Rows(.Rows.Count - 1).Cells(6).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(12).Value.ToString

                        .Rows(.Rows.Count - 1).Cells(3).Style.BackColor = Color.Yellow
                    End With
                End If
                dgvForm_counter += 1
            Loop
        End With

        grdError_Report.ShowDialog()
    End Sub

    Private Sub tsb_Filter_Errors_Wrong_DeductionAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Filter_Errors_Wrong_DeductionAmount.Click

        Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy.CommandType = CommandType.Text
        cmdSelect_MemberPolicy.CommandText = "SELECT * FROM vi_Member_Policy"

        Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)


        Dim ds_MemberPolicy As New DataSet


        da_MemberPolicy.Fill(ds_MemberPolicy, "vi_Member_Policy")



        Dim grdError_Report As New grdBulkUpload
        grdError_Report.Text = "Exceptional Report - Wrong Amount (Jumlah Potongan) Requested"
        grdError_Report.tss_Parent.Text = "Report - Wrong Amount Requested"
        grdError_Report.tsb_Save.Enabled = True
        grdError_Report.tsb_Filter.Visible = False

        With grdError_Report.dgvForm
            .Columns.Add("Angkasa_Member_ID", "No Keahlian")
            .Columns.Add("Full_Name", "Nama Ahli")
            .Columns.Add("IC", "No Kad Pengenalan")
            .Columns.Add("Deduction_Code", "Kod Potongan(Angkasa)")
            .Columns.Add("Amount_Requested", "Jumlah Requested(Medicare)")
            .Columns.Add("Amount_Received", "Jumlah Potongan(Angkasa)")
            .Columns.Add("Deduction_Month", "Bulan Potongan")
            .Columns.Add("Batch_No", "Batch No")
        End With

        Dim dgvForm_counter As Integer = 0
        Dim dr_MemberPolicy As DataRow()

        With Me.dgvForm
            Do While dgvForm_counter < .Rows.Count
                dr_MemberPolicy = ds_MemberPolicy.Tables("vi_Member_Policy").Select("IC_New = '" & .Rows(dgvForm_counter).Cells(3).Value.ToString & "' " & _
                                                                                    "AND Deduction_Code = '" & .Rows(dgvForm_counter).Cells(7).Value.ToString & "'")

                If dr_MemberPolicy.Length > 0 Then
                    If dr_MemberPolicy(0).Item("Deduction_Amount") <> Me.dgvForm.Rows(dgvForm_counter).Cells(8).Value Then
                        With grdError_Report.dgvForm
                            .Rows.Add()
                            .Rows(.Rows.Count - 1).Cells(0).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(5).Value.ToString
                            .Rows(.Rows.Count - 1).Cells(1).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(10).Value.ToString
                            .Rows(.Rows.Count - 1).Cells(2).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(3).Value.ToString
                            .Rows(.Rows.Count - 1).Cells(3).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(7).Value.ToString
                            .Rows(.Rows.Count - 1).Cells(4).Value = dr_MemberPolicy(0).Item("Deduction_Amount")
                            .Rows(.Rows.Count - 1).Cells(5).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(8).Value
                            .Rows(.Rows.Count - 1).Cells(6).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(6).Value.ToString
                            .Rows(.Rows.Count - 1).Cells(7).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(12).Value.ToString

                            .Rows(.Rows.Count - 1).Cells(4).Style.BackColor = Color.LightBlue
                            .Rows(.Rows.Count - 1).Cells(5).Style.BackColor = Color.Yellow
                        End With
                    End If
                End If
                dgvForm_counter += 1
            Loop
        End With

        grdError_Report.ShowDialog()
    End Sub

    Private Sub tsb_Filter_Errors_Member_IC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Filter_Errors_Member_IC.Click

        Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member.CommandType = CommandType.Text
        cmdSelect_Member.CommandText = "SELECT IC_New FROM dt_Member"

        Dim da_Member As New SqlDataAdapter(cmdSelect_Member)


        Dim ds_Member As New DataSet


        da_Member.Fill(ds_Member, "dt_Member")



        Dim grdError_Report As New grdBulkUpload
        grdError_Report.Text = "Exceptional Report - Members Don't Exist in Master List"
        grdError_Report.tss_Parent.Text = "Report - Members MIA"
        grdError_Report.tsb_Save.Enabled = True
        grdError_Report.tsb_Filter.Visible = False

        With grdError_Report.dgvForm
            .Columns.Add("Angkasa_Member_ID", "No Keahlian")
            .Columns.Add("Full_Name", "Nama Ahli")
            .Columns.Add("IC", "No Kad Pengenalan")
            .Columns.Add("Deduction_Code", "Kod Potongan(Angkasa)")
            .Columns.Add("Amount_Received", "Jumlah Potongan(Angkasa)")
            .Columns.Add("Deduction_Month", "Bulan Potongan")
            .Columns.Add("Batch_No", "Batch No")
        End With

        Dim dgvForm_counter As Integer = 0
        Dim dr_Member As DataRow()

        With Me.dgvForm
            Do While dgvForm_counter < .Rows.Count
                dr_Member = ds_Member.Tables("dt_Member").Select("IC_New = '" & .Rows(dgvForm_counter).Cells(3).Value.ToString & "'")

                If dr_Member.Length = 0 Then
                    With grdError_Report.dgvForm
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells(0).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(5).Value.ToString
                        .Rows(.Rows.Count - 1).Cells(1).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(10).Value.ToString
                        .Rows(.Rows.Count - 1).Cells(2).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(3).Value.ToString
                        .Rows(.Rows.Count - 1).Cells(3).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(7).Value.ToString
                        .Rows(.Rows.Count - 1).Cells(4).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(8).Value
                        .Rows(.Rows.Count - 1).Cells(5).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(6).Value.ToString
                        .Rows(.Rows.Count - 1).Cells(6).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(12).Value.ToString

                        .Rows(.Rows.Count - 1).Cells(2).Style.BackColor = Color.Yellow
                    End With
                End If
                dgvForm_counter += 1
            Loop
        End With

        grdError_Report.ShowDialog()
    End Sub

    Private Sub tsb_Filter_Errors_Member_without_DeductionCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Filter_Errors_Member_without_DeductionCode.Click

        Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member.CommandType = CommandType.Text
        cmdSelect_Member.CommandText = "SELECT ID, IC_New FROM dt_Member"
        Dim da_Member As New SqlDataAdapter(cmdSelect_Member)


        Dim cmdSelect_Member_Policy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Policy.CommandType = CommandType.Text
        cmdSelect_Member_Policy.CommandText = "SELECT Member_ID, Deduction_Code FROM dt_Member_Policy"
        Dim da_Member_Policy As New SqlDataAdapter(cmdSelect_Member_Policy)


        Dim ds_Member As New DataSet


        da_Member.Fill(ds_Member, "dt_Member")
        da_Member_Policy.Fill(ds_Member, "dt_Member_Policy")



        Dim grdError_Report As New grdBulkUpload
        grdError_Report.Text = "Exceptional Report - Members Exist in Master List but without Deduction Code"
        grdError_Report.tss_Parent.Text = "Report - Members without Deduction Code"
        grdError_Report.tsb_Save.Enabled = True
        grdError_Report.tsb_Filter.Visible = False

        With grdError_Report.dgvForm
            .Columns.Add("Angkasa_Member_ID", "No Keahlian")
            .Columns.Add("Full_Name", "Nama Ahli")
            .Columns.Add("IC", "No Kad Pengenalan")
            .Columns.Add("Deduction_Code", "Kod Potongan(Angkasa)")
            .Columns.Add("Amount_Received", "Jumlah Potongan(Angkasa)")
            .Columns.Add("Deduction_Month", "Bulan Potongan")
            .Columns.Add("Batch_No", "Batch No")
        End With

        Dim dgvForm_counter As Integer = 0
        Dim dr_Member As DataRow()
        Dim dr_Member_Policy As DataRow()

        With Me.dgvForm
            Do While dgvForm_counter < .Rows.Count
                dr_Member = ds_Member.Tables("dt_Member").Select("IC_New = '" & .Rows(dgvForm_counter).Cells(3).Value.ToString & "'")

                If dr_Member.Length > 0 Then
                    Dim Member_GUID As String = dr_Member(0).Item("ID").ToString.Trim
                    dr_Member_Policy = ds_Member.Tables("dt_Member_Policy").Select("Member_ID = '" & Member_GUID & _
                                       "' AND Deduction_Code = '" & .Rows(dgvForm_counter).Cells(7).Value.ToString & "'")

                    If dr_Member_Policy.Length = 0 Then
                        With grdError_Report.dgvForm
                            .Rows.Add()
                            .Rows(.Rows.Count - 1).Cells(0).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(5).Value.ToString
                            .Rows(.Rows.Count - 1).Cells(1).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(10).Value.ToString
                            .Rows(.Rows.Count - 1).Cells(2).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(3).Value.ToString
                            .Rows(.Rows.Count - 1).Cells(3).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(7).Value.ToString
                            .Rows(.Rows.Count - 1).Cells(4).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(8).Value
                            .Rows(.Rows.Count - 1).Cells(5).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(6).Value.ToString
                            .Rows(.Rows.Count - 1).Cells(6).Value = Me.dgvForm.Rows(dgvForm_counter).Cells(12).Value.ToString


                        End With
                    End If
                End If

                dgvForm_counter += 1
            Loop
        End With

        grdError_Report.ShowDialog()
    End Sub
End Class