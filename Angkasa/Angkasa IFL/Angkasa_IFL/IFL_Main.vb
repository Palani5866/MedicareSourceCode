Public Class IFL_Main
    Dim Conn As DbConnection = New SqlConnection
    Dim Trans_Child_counter As Integer = 0
    Dim cYr As String
    Private Sub Insert_Angkasa_MonthlyDeduction(ByVal var0 As String, ByVal var1 As String, ByVal var2 As String, _
                                                ByVal var3 As String, ByVal var4 As String, ByVal var5 As String, _
                                                ByVal var6 As String, ByVal var7 As Decimal, ByVal var8 As Decimal, _
                                                ByVal var9 As String, ByVal var10 As String, ByVal var11 As String)

        If var0.ToString.Trim = "0" Then

            Dim cmdInsert_dtMonthlyDeduction_M As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdInsert_dtMonthlyDeduction_M.CommandType = CommandType.Text
            cmdInsert_dtMonthlyDeduction_M.CommandText = "INSERT INTO dt_Angkasa_MonthlyDeduction_Master (Jenis_Rekod, " & _
                                                         "Kod_Kad_Pengenalan, No_Kad_Pengenalan, Kod_Koperasi, " & _
                                                         "No_Keahlian, Bulan_Potongan, Kod_Potongan, " & _
                                                         "Jumlah_Tuntutan, Jumlah_Bayaran, Lain_Lain, No_KP_Lama, " & _
                                                         "Batch_No) " & _
                                                         "VALUES ('" & var0.ToString.Trim & "', '" & _
                                                         var1.ToString.Trim & "', '" & var2.ToString.Trim & "', '" & _
                                                         var3.ToString.Trim & "', '" & var4.ToString.Trim & "', '" & _
                                                         var5.ToString.Trim & "', '" & var6.ToString.Trim & "', " & _
                                                         var7 & ", " & var8 & ", '" & var9.ToString.Trim & "', '" & _
                                                         var10.ToString.Trim & "', '" & var11.ToString.Trim & cYr & "')"
            Try
                cmdInsert_dtMonthlyDeduction_M.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.ToString)

            End Try
        Else
            var9 = var9.Replace("'", "''")


            Dim cmdInsert_dtMonthlyDeduction_C As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdInsert_dtMonthlyDeduction_C.CommandType = CommandType.Text
            cmdInsert_dtMonthlyDeduction_C.CommandText = "INSERT INTO dt_Angkasa_MonthlyDeduction_Child (Jenis_Rekod, " & _
                                                         "Kod_Kad_Pengenalan, No_Kad_Pengenalan, Kod_Koperasi, " & _
                                                         "No_Keahlian, Bulan_Potongan, Kod_Potongan, " & _
                                                         "Jumlah_Pokok, Jumlah_Faedah, Nama_Ahli, No_KP_Lama, " & _
                                                         "Batch_No, Batch_Status, Batch_ProcessCycle, Batch_GUID) " & _
                                                         "VALUES ('" & var0.ToString.Trim & "', '" & _
                                                         var1.ToString.Trim & "', '" & var2.ToString.Trim & "', '" & _
                                                         var3.ToString.Trim & "', '" & var4.ToString.Trim & "', '" & _
                                                         var5.ToString.Trim & "', '" & var6.ToString.Trim & "', " & _
                                                         var7 & ", " & var8 & ", '" & var9.ToString.Trim & "', '" & _
                                                         var10.ToString.Trim & "', '" & var11.ToString.Trim & cYr & "', " & _
                                                         0 & ", " & 0 & ", '" & Guid.NewGuid.ToString & "')"
            Try
                cmdInsert_dtMonthlyDeduction_C.ExecuteNonQuery()
                Trans_Child_counter += 1

            Catch ex As Exception
                MsgBox(ex.ToString)

            End Try
        End If
    End Sub
    Private Sub Insert_Angkasa_BatchControl(ByVal var0 As String, ByVal Angkasa_Incoming_File As String)

        Dim cmdSelect_MonthlyDeduction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MonthlyDeduction.CommandType = CommandType.Text
        cmdSelect_MonthlyDeduction.CommandText = "SELECT * FROM dt_MonthlyDeduction " & _
                                                 "WHERE Batch_No = '" & var0.ToString.Trim & "'"

        Dim da_MonthlyDeduction As New SqlDataAdapter(cmdSelect_MonthlyDeduction)

        Dim cmdInsert_MonthlyDeduction As SqlCommandBuilder
        cmdInsert_MonthlyDeduction = New SqlCommandBuilder(da_MonthlyDeduction)


        Dim ds_AutoUpload As New DataSet

        da_MonthlyDeduction.Fill(ds_AutoUpload, "dt_MonthlyDeduction")

        Dim dr_MonthlyDeduction_New As DataRow


        dr_MonthlyDeduction_New = ds_AutoUpload.Tables("dt_MonthlyDeduction").NewRow

        dr_MonthlyDeduction_New.Item("ID") = Guid.NewGuid.ToString
        dr_MonthlyDeduction_New.Item("Batch_No") = var0.ToString.Trim
        dr_MonthlyDeduction_New.Item("Batch_RecordCount") = Trans_Child_counter
        dr_MonthlyDeduction_New.Item("Batch_Record_Consolidated") = 0
        dr_MonthlyDeduction_New.Item("Batch_Record_Processed") = 0
        dr_MonthlyDeduction_New.Item("Batch_Upload_Date") = Now()
        dr_MonthlyDeduction_New.Item("Batch_Upload_By") = "System"
        dr_MonthlyDeduction_New.Item("Batch_Status") = 0

        ds_AutoUpload.Tables("dt_MonthlyDeduction").Rows.Add(dr_MonthlyDeduction_New)
        da_MonthlyDeduction.Update(ds_AutoUpload, "dt_MonthlyDeduction")


        System.IO.File.Move(Angkasa_Incoming_File, My.Settings.Outbox_Path & "\" & var0 & ".txt")

    End Sub

    Private Sub IFL_Main_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Function chkFile(ByVal fName As String) As Boolean
        Dim sc As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
        sc.CommandType = CommandType.Text
        sc.CommandText = "SELECT * FROM dt_MonthlyDeduction WHERE BATCH_NO='" & fName & "'"
        Dim sda As New SqlDataAdapter(sc)
        Dim dt As New DataTable
        sda.Fill(dt)
        If dt.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub IFL_Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cYr = Now.Year()
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim filenames As String()
        filenames = System.IO.Directory.GetFiles(My.Settings.Inbox_Path)

        Dim sr_line As String
        Dim batch_no As String = ""

        If filenames.Length > 0 Then
            Dim file_counter As Integer = 0

            Do While file_counter < filenames.Length
                Dim sr As IO.StreamReader = New IO.StreamReader(filenames(file_counter).ToString)
                sr_line = sr.ReadLine()
                If sr_line Is Nothing = False Then
                    Trans_Child_counter = 0
                    Dim chk As Boolean
                    If sr_line.Substring(0, 1).ToString.Trim = "0" Then
                        batch_no = sr_line.Substring(85, 5)
                    End If
                    chk = chkFile(batch_no & cYr)
                    If chk Then
                        Try
                            Do
                                If Len(Trim(sr_line)) <> 0 Then
                                    Me.Insert_Angkasa_MonthlyDeduction(sr_line.Substring(0, 1), _
                                                                       sr_line.Substring(1, 1), _
                                                                       sr_line.Substring(1, 13), _
                                                                       sr_line.Substring(14, 5), _
                                                                       sr_line.Substring(19, 12), _
                                                                       sr_line.Substring(31, 6), _
                                                                       sr_line.Substring(37, 4), _
                                                                       Val(sr_line.Substring(41, 7)) / 100, _
                                                                       Val(sr_line.Substring(48, 7)) / 100, _
                                                                       sr_line.Substring(55, 35), _
                                                                       sr_line.Substring(90, 10), _
                                                                       batch_no)
                                End If
                                sr_line = sr.ReadLine()
                            Loop Until sr_line Is Nothing

                            sr.Close()

                            If Trans_Child_counter > 0 Then
                                Me.Insert_Angkasa_BatchControl(batch_no & cYr, filenames(file_counter).ToString)
                            End If
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                            sr.Close()
                        End Try
                    End If
                End If
                file_counter += 1
            Loop
        End If
        Me.Close()
    End Sub
End Class
