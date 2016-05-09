Imports System.Windows.Forms
Public Class fBorang2_79
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub dlgBorang2_79_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub dlgBorang2_79_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindData()
        Me.txtRemarks.Enabled = False
    End Sub
#End Region
#Region "DataBind Events"
    Private Sub BindData()
        Dim dt As New DataTable
        dt = _objBusi.fgetDetailsII("PAYMENTEXCEPTION", "", "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvPaymentException
                .DataSource = dt
                .Columns(1).Visible = False
                .Columns(10).Visible = False
                .Columns(11).Visible = False
                .Columns(12).Visible = False
                .Columns(13).Visible = False
            End With
        Else
            Me.dgvPaymentException.DataSource = dt
            MsgBox("No record found")
        End If
    End Sub
    Private Sub ReProcesses()
        Dim sRemarks As String
        sRemarks = "Reprocessing after updating of Member's Policy"
        Dim dgvRowCount As Integer = 0
        With Me.dgvPaymentException
            Do While dgvRowCount < .Rows.Count
                If .Rows(dgvRowCount).Cells(0).Value = "T" Then
                    If Not IsDBNull(.Rows(dgvRowCount).Cells(1).Value) Then
                        If .Rows(dgvRowCount).Cells(7).Value.ToString() = .Rows(dgvRowCount).Cells(10).Value.ToString() Then
                            _objBusi.fINPremiumProcess("INSERT", Guid.NewGuid.ToString.Trim(), .Rows(dgvRowCount).Cells(1).Value.ToString(), .Rows(dgvRowCount).Cells(5).Value.ToString(), .Rows(dgvRowCount).Cells(6).Value.ToString(), .Rows(dgvRowCount).Cells(7).Value.ToString(), .Rows(dgvRowCount).Cells(8).Value.ToString(), .Rows(dgvRowCount).Cells(9).Value.ToString(), sRemarks, "", "MONTHLYDEDUCTION", Conn) 'Monthly Deduction                                                
                            _objBusi.Delete("SUSPENDAC", .Rows(dgvRowCount).Cells(3).Value.ToString(), .Rows(dgvRowCount).Cells(5).Value.ToString(), .Rows(dgvRowCount).Cells(6).Value.ToString(), .Rows(dgvRowCount).Cells(7).Value.ToString(), .Rows(dgvRowCount).Cells(8).Value.ToString(), .Rows(dgvRowCount).Cells(9).Value.ToString(), "", "", "", "", Conn) 'Monthly Deduction                                                
                            If IsDBNull(.Rows(dgvRowCount).Cells(11).Value.ToString()) = True Then
                                Update_MemberPolicy_Effective_Date(.Rows(dgvRowCount).Cells(1).Value.ToString(), .Rows(dgvRowCount).Cells(9).Value.ToString())
                            End If
                        End If
                    End If
                End If
                dgvRowCount += 1
            Loop
        End With
    End Sub
#End Region
#Region "General Functions/Subs"
    Private Function Add_MonthlyDeduction0599(ByVal id As String, ByVal PID As String, ByVal IC As String, ByVal DMonth As String, ByVal DCode As String, ByVal DAmount As String, ByVal BatchNo As String, ByVal RMonth As String, ByVal Remarks As String, ByVal sDate As String, ByVal eDate As String) As Boolean
        If id = "" Then
            Dim sqlCmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.CommandText = "select * from dt_member_policy where member_id=(select id from dt_member where ic_new='" & IC & "') and deduction_code='0599'"
            Dim adp As New SqlDataAdapter(sqlCmd)
            Dim ds As New DataSet
            adp.Fill(ds, "dt_member_policy")

            Dim sqlCmd0599 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            sqlCmd0599.CommandType = CommandType.Text
            sqlCmd0599.CommandText = "SELECT * FROM dt_Member_Policy_MonthlyDeduction where member_policy_id='" & ds.Tables(0).Rows(0)("ID").ToString & "'"
            Dim adp0599 As New SqlDataAdapter(sqlCmd0599)

            Dim cmdSelect_Monthly_Angkasa_KIV As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Monthly_Angkasa_KIV.CommandType = CommandType.Text
            cmdSelect_Monthly_Angkasa_KIV.CommandText = "SELECT * FROM dt_Angkasa_Monthly_SuspendAccount " & _
                                                        "WHERE No_Kad_Pengenalan = '" & IC & "' AND " & _
                                                        "Angkasa_Bulan_Potongan = '" & DMonth & "' AND " & _
                                                        "Angkasa_Kod_Potongan = '" & DCode & "' AND " & _
                                                        "Angkasa_Batch_No = '" & BatchNo & "' AND " & _
                                                        "Receiving_Month = '" & RMonth & "'"

            Dim da_Monthly_Angkasa_KIV As New SqlDataAdapter(cmdSelect_Monthly_Angkasa_KIV)

            Dim cmdDelete_Monthly_Angkasa_KIV As SqlCommandBuilder
            cmdDelete_Monthly_Angkasa_KIV = New SqlCommandBuilder(da_Monthly_Angkasa_KIV)

            Dim SqlcmdIns0599 As SqlCommandBuilder
            SqlcmdIns0599 = New SqlCommandBuilder(adp0599)
            Dim ds0599 As New DataSet
            adp0599.Fill(ds0599, "dt_Member_Policy_MonthlyDeduction")
            da_Monthly_Angkasa_KIV.Fill(ds0599, "dt_Angkasa_Monthly_SuspendAccount")
            Dim dr0599 As DataRow

            dr0599 = ds0599.Tables("dt_Member_Policy_MonthlyDeduction").NewRow

            With dr0599
                .Item("ID") = Guid.NewGuid.ToString.Trim()
                .Item("Member_Policy_ID") = ds.Tables(0).Rows(0)("ID").ToString.Trim()
                .Item("Angkasa_Bulan_Potongan") = DMonth
                .Item("Angkasa_Kod_Potongan") = DCode
                .Item("Angkasa_Jumlah_Pokok") = DAmount
                .Item("Angkasa_Batch_No") = BatchNo
                .Item("Receiving_Month") = RMonth
                .Item("Remark") = ""
            End With
            ds0599.Tables("dt_Member_Policy_MonthlyDeduction").Rows.Add(dr0599)
            adp0599.Update(ds0599, "dt_Member_Policy_MonthlyDeduction")

            If ds0599.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows.Count = 1 Then
                ds0599.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows(0).Delete()
                da_Monthly_Angkasa_KIV.Update(ds0599, "dt_Angkasa_Monthly_SuspendAccount")
                MsgBox("Successfully inserted.")
            Else
                MsgBox("Error in deleting record from Table: dt_Angkasa_Monthly_SuspendAccount")
            End If
        Else
            Dim sqlCmd0599 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            sqlCmd0599.CommandType = CommandType.Text
            sqlCmd0599.CommandText = "SELECT * FROM dt_Member_Policy_MonthlyDeduction"
            Dim adp0599 As New SqlDataAdapter(sqlCmd0599)
            Dim SqlcmdIns0599 As SqlCommandBuilder
            SqlcmdIns0599 = New SqlCommandBuilder(adp0599)

            Dim cmdSelect_Monthly_Angkasa_KIV As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Monthly_Angkasa_KIV.CommandType = CommandType.Text
            cmdSelect_Monthly_Angkasa_KIV.CommandText = "SELECT * FROM dt_Angkasa_Monthly_SuspendAccount " & _
                                                        "WHERE No_Kad_Pengenalan = '" & IC & "' AND " & _
                                                        "Angkasa_Bulan_Potongan = '" & DMonth & "' AND " & _
                                                        "Angkasa_Kod_Potongan = '" & DCode & "' AND " & _
                                                        "Angkasa_Batch_No = '" & BatchNo & "' AND " & _
                                                        "Receiving_Month = '" & RMonth & "'"

            Dim da_Monthly_Angkasa_KIV As New SqlDataAdapter(cmdSelect_Monthly_Angkasa_KIV)

            Dim cmdDelete_Monthly_Angkasa_KIV As SqlCommandBuilder
            cmdDelete_Monthly_Angkasa_KIV = New SqlCommandBuilder(da_Monthly_Angkasa_KIV)


            Dim ds0599 As New DataSet
            adp0599.Fill(ds0599, "dt_Member_Policy_MonthlyDeduction")
            da_Monthly_Angkasa_KIV.Fill(ds0599, "dt_Angkasa_Monthly_SuspendAccount")

            Dim dr0599 As DataRow

            dr0599 = ds0599.Tables("dt_Member_Policy_MonthlyDeduction").NewRow

            With dr0599
                .Item("ID") = Guid.NewGuid.ToString.Trim()
                .Item("Member_Policy_ID") = id
                .Item("Angkasa_Bulan_Potongan") = DMonth
                .Item("Angkasa_Kod_Potongan") = DCode
                .Item("Angkasa_Jumlah_Pokok") = DAmount
                .Item("Angkasa_Batch_No") = BatchNo
                .Item("Receiving_Month") = RMonth
                .Item("Remark") = ""
            End With
            ds0599.Tables("dt_Member_Policy_MonthlyDeduction").Rows.Add(dr0599)
            adp0599.Update(ds0599, "dt_Member_Policy_MonthlyDeduction")

            If ds0599.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows.Count = 1 Then
                ds0599.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows(0).Delete()
                da_Monthly_Angkasa_KIV.Update(ds0599, "dt_Angkasa_Monthly_SuspendAccount")
                MsgBox("Successfully inserted.")
            Else
                MsgBox("Error in deleting record from Table: dt_Angkasa_Monthly_SuspendAccount")
            End If
        End If
    End Function
    Private Function Transfer_FI_SuspendAccount(ByVal IC As String, ByVal DMonth As String, ByVal DCode As String, ByVal DAmount As String, ByVal BatchNo As String, ByVal RMonth As String, ByVal Remarks As String) As Boolean

        Dim cmdSelect_FI_SuspendAccount As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_FI_SuspendAccount.CommandType = CommandType.Text
        cmdSelect_FI_SuspendAccount.CommandText = "SELECT * FROM dt_FI_SuspendAccount"

        Dim da_FI_SuspendAccount As New SqlDataAdapter(cmdSelect_FI_SuspendAccount)

        Dim cmdInsert_FI_SuspendAccount As SqlCommandBuilder
        cmdInsert_FI_SuspendAccount = New SqlCommandBuilder(da_FI_SuspendAccount)


        Dim cmdSelect_Monthly_Angkasa_KIV As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Monthly_Angkasa_KIV.CommandType = CommandType.Text
        cmdSelect_Monthly_Angkasa_KIV.CommandText = "SELECT * FROM dt_Angkasa_Monthly_SuspendAccount " & _
                                                    "WHERE No_Kad_Pengenalan = '" & IC & "' AND " & _
                                                    "Angkasa_Bulan_Potongan = '" & DMonth & "' AND " & _
                                                    "Angkasa_Kod_Potongan = '" & DCode & "' AND " & _
                                                    "Angkasa_Batch_No = '" & BatchNo & "' AND " & _
                                                    "Receiving_Month = '" & RMonth & "'"

        Dim da_Monthly_Angkasa_KIV As New SqlDataAdapter(cmdSelect_Monthly_Angkasa_KIV)

        Dim cmdDelete_Monthly_Angkasa_KIV As SqlCommandBuilder
        cmdDelete_Monthly_Angkasa_KIV = New SqlCommandBuilder(da_Monthly_Angkasa_KIV)


        Dim ds_SuspendAccount As New DataSet


        Try
            da_FI_SuspendAccount.Fill(ds_SuspendAccount, "dt_FI_SuspendAccount")
            da_Monthly_Angkasa_KIV.Fill(ds_SuspendAccount, "dt_Angkasa_Monthly_SuspendAccount")

            Dim dr_FI_SuspendAccount_New As DataRow

            dr_FI_SuspendAccount_New = ds_SuspendAccount.Tables("dt_FI_SuspendAccount").NewRow

            With dr_FI_SuspendAccount_New
                .Item("ID") = Guid.NewGuid.ToString.Trim()
                .Item("No_Kad_Pengenalan") = IC
                .Item("Angkasa_Bulan_Potongan") = DMonth
                .Item("Angkasa_Kod_Potongan") = DCode
                .Item("Angkasa_Jumlah_Pokok") = DAmount
                .Item("Angkasa_Batch_No") = BatchNo
                .Item("Receiving_Month") = RMonth
                .Item("Remark") = Remarks
                .Item("Created_By") = My.Settings.Username.Trim
                .Item("Created_On") = Now()
            End With


            ds_SuspendAccount.Tables("dt_FI_SuspendAccount").Rows.Add(dr_FI_SuspendAccount_New)
            da_FI_SuspendAccount.Update(ds_SuspendAccount, "dt_FI_SuspendAccount")

            If ds_SuspendAccount.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows.Count = 1 Then
                ds_SuspendAccount.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows(0).Delete()
                da_Monthly_Angkasa_KIV.Update(ds_SuspendAccount, "dt_Angkasa_Monthly_SuspendAccount")
                Return True
            Else
                MsgBox("Error in deleting record from Table: dt_Angkasa_Monthly_SuspendAccount")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
    Private Sub Transfer_Member_Policy_MonthlyDeduction(ByVal ID As String, ByVal IC As String, ByVal DMonth As String, ByVal DCode As String, ByVal DAmount As String, ByVal BatchNo As String, ByVal RMonth As String, ByVal Remarks As String, ByVal sDate As String)
        Dim cmdSelect_MemberPolicy_MonthlyDeduction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy_MonthlyDeduction.CommandType = CommandType.Text
        cmdSelect_MemberPolicy_MonthlyDeduction.CommandText = "SELECT * FROM dt_Member_Policy_MonthlyDeduction"
        Dim da_MemberPolicy_MonthlyDeduction As New SqlDataAdapter(cmdSelect_MemberPolicy_MonthlyDeduction)
        Dim cmdInsert_MemberPolicy_MonthlyDeduction As SqlCommandBuilder
        cmdInsert_MemberPolicy_MonthlyDeduction = New SqlCommandBuilder(da_MemberPolicy_MonthlyDeduction)
        Dim cmdSelect_Monthly_Angkasa_KIV As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Monthly_Angkasa_KIV.CommandType = CommandType.Text
        cmdSelect_Monthly_Angkasa_KIV.CommandText = "SELECT * FROM dt_Angkasa_Monthly_SuspendAccount " & _
                                                    "WHERE No_Kad_Pengenalan = '" & IC & "' AND " & _
                                                    "Angkasa_Bulan_Potongan = '" & DMonth & "' AND " & _
                                                    "Angkasa_Kod_Potongan = '" & DCode & "' AND " & _
                                                    "Angkasa_Batch_No = '" & BatchNo & "' AND " & _
                                                    "Receiving_Month = '" & RMonth & "'"

        Dim da_Monthly_Angkasa_KIV As New SqlDataAdapter(cmdSelect_Monthly_Angkasa_KIV)

        Dim cmdDelete_Monthly_Angkasa_KIV As SqlCommandBuilder
        cmdDelete_Monthly_Angkasa_KIV = New SqlCommandBuilder(da_Monthly_Angkasa_KIV)
        Dim ds_MemberPolicy_MonthlyDeduction As New DataSet
        da_MemberPolicy_MonthlyDeduction.Fill(ds_MemberPolicy_MonthlyDeduction, "dt_Member_Policy_MonthlyDeduction")
        da_Monthly_Angkasa_KIV.Fill(ds_MemberPolicy_MonthlyDeduction, "dt_Angkasa_Monthly_SuspendAccount")

        Dim dr_MemberPolicy_MonthlyDeduction_New As DataRow
        dr_MemberPolicy_MonthlyDeduction_New = ds_MemberPolicy_MonthlyDeduction.Tables("dt_Member_Policy_MonthlyDeduction").NewRow
        With dr_MemberPolicy_MonthlyDeduction_New
            .Item("ID") = Guid.NewGuid.ToString()
            .Item("Member_Policy_ID") = ID
            .Item("Angkasa_Bulan_Potongan") = DMonth
            .Item("Angkasa_Kod_Potongan") = DCode
            .Item("Angkasa_Jumlah_Pokok") = DAmount
            .Item("Angkasa_Batch_No") = BatchNo
            .Item("Receiving_Month") = RMonth
            .Item("Remark") = Remarks
        End With

        ds_MemberPolicy_MonthlyDeduction.Tables("dt_Member_Policy_MonthlyDeduction").Rows.Add(dr_MemberPolicy_MonthlyDeduction_New)
        da_MemberPolicy_MonthlyDeduction.Update(ds_MemberPolicy_MonthlyDeduction, "dt_Member_Policy_MonthlyDeduction")

        If ds_MemberPolicy_MonthlyDeduction.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows.Count = 1 Then
            ds_MemberPolicy_MonthlyDeduction.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows(0).Delete()
            da_Monthly_Angkasa_KIV.Update(ds_MemberPolicy_MonthlyDeduction, "dt_Angkasa_Monthly_SuspendAccount")
        Else
            MsgBox("Error in deleting record from Table: dt_Angkasa_Monthly_SuspendAccount")
        End If
        If Len(sDate) = 0 Then
            Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_MemberPolicy.CommandType = CommandType.Text
            cmdSelect_MemberPolicy.CommandText = "SELECT ID, Member_ID, Deduction_Code, Effective_Date, Angkasa_FileNo, status " & _
                                                 "FROM dt_Member_Policy WHERE ID = '" & ID & "'"

            Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)

            Dim cmdUpdate_MemberPolicy As SqlCommandBuilder
            cmdUpdate_MemberPolicy = New SqlCommandBuilder(da_MemberPolicy)

            da_MemberPolicy.Fill(ds_MemberPolicy_MonthlyDeduction, "dt_Member_Policy")

            If ds_MemberPolicy_MonthlyDeduction.Tables("dt_Member_Policy").Rows.Count = 1 Then
                With ds_MemberPolicy_MonthlyDeduction.Tables("dt_Member_Policy").Rows(0)
                    Dim var_effective_month As Short
                    Dim var_effective_year As Short
                    Dim var_effective_date As Date

                    var_effective_month = Val(RMonth.Substring(4, 2)) + 1
                    var_effective_year = Val(RMonth.Substring(0, 4))

                    If var_effective_month = 13 Then
                        var_effective_year += 1
                        var_effective_month = 1
                    End If

                    var_effective_date = Convert.ToDateTime(Str(var_effective_year) & "/" & Str(var_effective_month) & "/15")
                    .Item("Effective_Date") = var_effective_date
                    .Item("STATUS") = "INFORCE"
                    _objBusi.InsUpsPremiumHistory("UP", Guid.NewGuid.ToString(), ID, Format(var_effective_date, "MM/dd/yyyy"), "", "", "Active", "", "", Conn)


                    _objBusi.spUpdate("GST", ID.ToString(), "", "", "", "", "", "", "", "", "", Conn)



                    _objBusi.InsUpsPolicyPremiumHistory("UPDATESTARTDATE", ID.ToString(), "0.00", Format(var_effective_date, "MM/dd/yyyy"), "", "", My.Settings.Username, Conn)


                End With
                da_MemberPolicy.Update(ds_MemberPolicy_MonthlyDeduction, "dt_Member_Policy")
            Else
                MsgBox("Error in updating record from Table: dt_Member_Policy")
            End If
        End If
    End Sub

    Private Sub Flag_rdiRTs()
        Me.rdReprocessing.Checked = False
        Me.rdiRT_CR.Checked = False
        Me.rd0599.Checked = False
        Me.rdIgnore.Checked = False
        Me.rdiRT_CR.Checked = False
        Me.txtRemarks.Enabled = False
    End Sub
    Public Shared Sub FlusMemory()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
        End If
    End Sub
    Private Sub Ignore()
        Dim dgvRowCount As Integer = 0
        Dim sRes As String
        With Me.dgvPaymentException
            Do While dgvRowCount < .Rows.Count
                If .Rows(dgvRowCount).Cells(0).Value = "T" Then
                    If Not IsDBNull(.Rows(dgvRowCount).Cells(1).Value) Then
                        sRes = _objBusi.spUpdate("SUSPENDIGNORE", "IGNORE", Me.txtRemarks.Text.Trim.Trim(), My.Settings.Username, "", "", .Rows(dgvRowCount).Cells(9).Value, .Rows(dgvRowCount).Cells(8).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(6).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(5).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(3).Value.ToString.Trim(), Conn)
                        MsgBox("Result " & sRes)
                    End If
                End If
                dgvRowCount += 1
            Loop
        End With
    End Sub
    Private Sub TransferFISuspendAc()
        Dim sRemarks As String
        sRemarks = "Cancelled / Retired policy but monthly deduction still goes on"
        Dim dgvRowCount As Integer = 0
        Dim sRes As String
        With Me.dgvPaymentException
            Do While dgvRowCount < .Rows.Count
                If .Rows(dgvRowCount).Cells(0).Value = "T" Then
                    If Not IsDBNull(.Rows(dgvRowCount).Cells(1).Value) Then
                        Transfer_FI_SuspendAccount(.Rows(dgvRowCount).Cells(3).Value, .Rows(dgvRowCount).Cells(5).Value, .Rows(dgvRowCount).Cells(6).Value, .Rows(dgvRowCount).Cells(7).Value, .Rows(dgvRowCount).Cells(8).Value, .Rows(dgvRowCount).Cells(9).Value, sRemarks)
                    End If
                End If
                dgvRowCount += 1
            Loop
        End With
    End Sub
    Private Function chk0599(ByVal ic As String) As Boolean
        Dim sqlCmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        sqlCmd.CommandType = CommandType.Text
        sqlCmd.CommandText = "select * from dt_member_policy where member_id=(select id from dt_member where ic_new='" & ic & "') and deduction_code='0599'"
        Dim adp As New SqlDataAdapter(sqlCmd)
        Dim ds As New DataSet
        adp.Fill(ds, "dt_member_policy")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region
#Region "Insert"
    Private Sub insert0599()
        Dim sRemarks As String
        sRemarks = "Cancelled / Retired policy but monthly deduction still goes on"
        Dim dgvRowCount As Integer = 0
        Dim sRes As String
        With Me.dgvPaymentException
            Do While dgvRowCount < .Rows.Count
                If .Rows(dgvRowCount).Cells(0).Value = "T" Then
                    If Not IsDBNull(.Rows(dgvRowCount).Cells(1).Value) Then
                        Insert_0599(.Rows(dgvRowCount).Cells(1).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(3).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(5).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(6).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(7).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(8).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(9).Value.ToString.Trim(), sRemarks, .Rows(dgvRowCount).Cells(11).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(12).Value.ToString.Trim())
                    End If
                End If
                dgvRowCount += 1
            Loop
        End With
    End Sub
    Private Function Insert_0599(ByVal ID As String, ByVal IC As String, ByVal DMonth As String, ByVal DCode As String, ByVal DAmount As String, ByVal BatchNo As String, ByVal RMonth As String, ByVal Remarks As String, ByVal sDate As String, ByVal eDate As String) As Boolean
        If chk0599(IC) Then
            Add_MonthlyDeduction0599("", ID, IC, DMonth, DCode, DAmount, BatchNo, RMonth, Remarks, sDate, eDate)
        Else
            Try
                Dim sRes As String
                Dim ds As New DataSet
                Dim sqlCmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                sqlCmd.CommandType = CommandType.Text
                sqlCmd.CommandText = "select * from dt_member_policy where member_id=(select id from dt_member where ic_new='" & IC & "')"

                Dim adp As New SqlDataAdapter(sqlCmd)
                Dim cmdInsert_MemberPolicy As SqlCommandBuilder
                cmdInsert_MemberPolicy = New SqlCommandBuilder(adp)
                adp.Fill(ds, "dt_member_policy")

                Dim dr_MemberPolicy_Old As DataRow = ds.Tables("dt_Member_Policy").Rows(0)

                With dr_MemberPolicy_Old
                    Dim srRes As String
                    srRes = ds.Tables("dt_Member_Policy").Rows(0).Item("Cancellation_Date").ToString
                    srRes = ds.Tables("dt_Member_Policy").Rows(0).Item("Effective_Date").ToString
                    .Item("Member_ID") = ds.Tables("dt_Member_Policy").Rows(0).Item("Member_ID").ToString
                    .Item("Effective_Date") = ds.Tables("dt_Member_Policy").Rows(0).Item("Effective_Date").ToString
                    If Not IsDBNull(ds.Tables("dt_Member_Policy").Rows(0).Item("Cancellation_Date")) Then
                        .Item("Cancellation_Date") = ds.Tables("dt_Member_Policy").Rows(0).Item("Cancellation_Date").ToString
                    End If
                    .Item("Agent_Code") = ds.Tables("dt_Member_Policy").Rows(0).Item("Agent_Code").ToString
                    .Item("Submission_Date") = ds.Tables("dt_Member_Policy").Rows(0).Item("Submission_Date")
                    .Item("Angkasa_FileNo") = ds.Tables("dt_Member_Policy").Rows(0).Item("Angkasa_FileNo")
                    .Item("Plan_Code") = ds.Tables("dt_Member_Policy").Rows(0).Item("Plan_Code")
                    .Item("Level2_Plan_Code") = ds.Tables("dt_Member_Policy").Rows(0).Item("Level2_Plan_Code")
                    .Item("Special_Promo") = ds.Tables("dt_Member_Policy").Rows(0).Item("Special_Promo")
                    .Item("Underwriting_Required") = ds.Tables("dt_Member_Policy").Rows(0).Item("Underwriting_Required")
                    .Item("Payment_Frequency") = ds.Tables("dt_Member_Policy").Rows(0).Item("Payment_Frequency")
                    .Item("Payment_Method") = ds.Tables("dt_Member_Policy").Rows(0).Item("Payment_Method")
                    .Item("DataEntry_Checklist_Proposer_Details") = ds.Tables("dt_Member_Policy").Rows(0).Item("DataEntry_Checklist_Proposer_Details")
                    .Item("DataEntry_Checklist_Enrolled_Dependents") = ds.Tables("dt_Member_Policy").Rows(0).Item("DataEntry_Checklist_Enrolled_Dependents")
                    .Item("DataEntry_Checklist_Insurance_Proposed") = ds.Tables("dt_Member_Policy").Rows(0).Item("DataEntry_Checklist_Insurance_Proposed")
                    .Item("DataEntry_Checklist_BiroAngkasa_Deduction") = ds.Tables("dt_Member_Policy").Rows(0).Item("DataEntry_Checklist_BiroAngkasa_Deduction")
                    .Item("DataEntry_Checklist_Nomination") = ds.Tables("dt_Member_Policy").Rows(0).Item("DataEntry_Checklist_Nomination")
                    .Item("Document_Checklist_Application_Form") = ds.Tables("dt_Member_Policy").Rows(0).Item("Document_Checklist_Application_Form")
                    .Item("Document_Checklist_IC") = ds.Tables("dt_Member_Policy").Rows(0).Item("Document_Checklist_IC")
                    .Item("Document_Checklist_Payslip") = ds.Tables("dt_Member_Policy").Rows(0).Item("Document_Checklist_Payslip")
                    .Item("Document_Checklist_Borang1_79") = ds.Tables("dt_Member_Policy").Rows(0).Item("Document_Checklist_Borang1_79")
                    .Item("Policy_No") = ds.Tables("dt_Member_Policy").Rows(0).Item("Policy_No")
                End With

                Dim dr_MemberPolicy_New As DataRow
                Dim var_MemberPolicy_ID_New As String = ""
                dr_MemberPolicy_New = ds.Tables("dt_Member_Policy").NewRow

                With dr_MemberPolicy_New
                    var_MemberPolicy_ID_New = Guid.NewGuid.ToString

                    .Item("ID") = var_MemberPolicy_ID_New
                    .Item("Deduction_Code") = DCode
                    .Item("Deduction_Amount") = DAmount
                    If sDate = "" Then
                        .Item("Effective_Date") = dr_MemberPolicy_Old.Item("Effective_Date")
                    Else
                        .Item("Effective_Date") = sDate
                    End If
                    If eDate = "" Then
                        .Item("Cancellation_Date") = dr_MemberPolicy_Old.Item("Cancellation_Date")
                    Else
                        .Item("Cancellation_Date") = eDate
                    End If
                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                    .Item("Last_Modified_On") = Now()

                    .Item("Member_ID") = dr_MemberPolicy_Old.Item("Member_ID")
                    .Item("Agent_Code") = dr_MemberPolicy_Old.Item("Agent_Code")
                    .Item("Submission_Date") = dr_MemberPolicy_Old.Item("Submission_Date")
                    .Item("Angkasa_FileNo") = dr_MemberPolicy_Old.Item("Angkasa_FileNo")
                    .Item("Plan_Code") = dr_MemberPolicy_Old.Item("Plan_Code")
                    .Item("Level2_Plan_Code") = dr_MemberPolicy_Old.Item("Level2_Plan_Code")
                    .Item("Special_Promo") = dr_MemberPolicy_Old.Item("Special_Promo")
                    .Item("Underwriting_Required") = dr_MemberPolicy_Old.Item("Underwriting_Required")
                    .Item("Payment_Frequency") = dr_MemberPolicy_Old.Item("Payment_Frequency")
                    .Item("Payment_Method") = dr_MemberPolicy_Old.Item("Payment_Method")
                    .Item("DataEntry_Checklist_Proposer_Details") = dr_MemberPolicy_Old.Item("DataEntry_Checklist_Proposer_Details")
                    .Item("DataEntry_Checklist_Enrolled_Dependents") = dr_MemberPolicy_Old.Item("DataEntry_Checklist_Enrolled_Dependents")
                    .Item("DataEntry_Checklist_Insurance_Proposed") = dr_MemberPolicy_Old.Item("DataEntry_Checklist_Insurance_Proposed")
                    .Item("DataEntry_Checklist_BiroAngkasa_Deduction") = dr_MemberPolicy_Old.Item("DataEntry_Checklist_BiroAngkasa_Deduction")
                    .Item("DataEntry_Checklist_Nomination") = dr_MemberPolicy_Old.Item("DataEntry_Checklist_Nomination")
                    .Item("Document_Checklist_Application_Form") = dr_MemberPolicy_Old.Item("Document_Checklist_Application_Form")

                    .Item("Document_Checklist_IC") = dr_MemberPolicy_Old.Item("Document_Checklist_IC")
                    .Item("Document_Checklist_Payslip") = dr_MemberPolicy_Old.Item("Document_Checklist_Payslip")
                    .Item("Document_Checklist_Borang1_79") = dr_MemberPolicy_Old.Item("Document_Checklist_Borang1_79")
                    .Item("Policy_No") = dr_MemberPolicy_Old.Item("Policy_No")
                End With

                ds.Tables("dt_Member_Policy").Rows.Add(dr_MemberPolicy_New)
                adp.Update(ds, "dt_Member_Policy")
                Add_MonthlyDeduction0599(var_MemberPolicy_ID_New, ID, IC, DMonth, DCode, DAmount, BatchNo, RMonth, Remarks, sDate, eDate)
                MsgBox("Successfully inserted.")
            Catch ex As Exception
                MsgBox("Record already existed or Error while inserting the record!")
            End Try
        End If

    End Function
#End Region
#Region "Update"
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

                _objBusi.InsUpsPremiumHistory("UP", Guid.NewGuid().ToString(), var_ID.ToString(), Format(var_effective_date, "MM/dd/yyyy"), "", "", "Active", "", "", Conn)


                _objBusi.spUpdate("GST", var_ID.ToString(), "", "", "", "", "", "", "", "", "", Conn)



                _objBusi.InsUpsPolicyPremiumHistory("UPDATESTARTDATE", var_ID.ToString(), "0.00", Format(var_effective_date, "MM/dd/yyyy"), "", "", My.Settings.Username, Conn)


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
#End Region
#Region "Click Events"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Not Me.rdReprocessing.Checked Then
            If Not Me.rdIgnore.Checked Then
                If Not Me.rd0599.Checked Then
                    If Not Me.rdiRT_CR.Checked Then
                        MsgBox("Please do select at least one action!")
                    End If
                End If
            End If
        End If
        If Me.rdiRT_CR.Checked Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            TransferFISuspendAc()
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        ElseIf Me.rdIgnore.Checked Then
            If Not Len(Me.txtRemarks.Text.Trim()) > 0 Then
                Me.txtRemarks.Focus()
                MsgBox("Please do key in the remark!")
                Exit Sub
            End If
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Ignore()
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        ElseIf Me.rdReprocessing.Checked Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            ReProcesses()
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        ElseIf Me.rd0599.Checked Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            insert0599()
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        End If
        BindData()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region
#Region "Change Events"
    Private Sub rdiRT_CR_Prior01012009_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdReprocessing.CheckedChanged
        If Me.rdReprocessing.Checked = True Then
            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
            Me.txtRemarks.Enabled = False
        End If
    End Sub
    Private Sub rdiRT_GE_DeductionCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rd0599.CheckedChanged
        If Me.rd0599.Checked = True Then
            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
            Me.txtRemarks.Enabled = False
        End If
    End Sub
    Private Sub rdiRT_StampDuty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdIgnore.CheckedChanged
        If Me.rdIgnore.Checked = True Then
            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
            Me.txtRemarks.Enabled = True
        End If
    End Sub
    Private Sub rdiRT_CR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiRT_CR.CheckedChanged
        If Me.rdiRT_CR.Checked = True Then
            Me.txtRemarks.Enabled = False
        End If
    End Sub
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
