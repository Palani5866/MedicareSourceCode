Imports System.Windows.Forms
Public Class dlgBorang2_79
#Region "Global Veriables"
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
        Me.Check_Status()
        Me.OK_Button.Enabled = False
        Me.txtRemarks.Enabled = False
    End Sub
#End Region
#Region "Data Bind"

#End Region
#Region "General Functions/Subs"
    Private Sub Flag_rdiRTs()
        Me.rdiRT_CR_Prior01012009.Checked = False
        Me.rdiRT_CR.Checked = False
        Me.rdiRT_GE_DeductionCode.Checked = False
        Me.rdiRT_StampDuty.Checked = False
        Me.rdiRT_SuspendAccount.Checked = False
        Me.rdiRT_CR.Checked = False
        Me.txtRemarks.Enabled = False
    End Sub
    Private Sub Check_Status()
        Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy.CommandType = CommandType.Text
        cmdSelect_MemberPolicy.CommandText = "SELECT ID, IC_New, Deduction_Code, Deduction_Amount, Effective_Date, Cancellation_Date " & _
                                             "FROM vi_Member_Policy_v3 " & _
                                             "WHERE IC_New = '" & Me.txtNRIC.Text.Trim & "' AND " & _
                                             "Deduction_Code = '" & Me.txtDeduction_Code.Text.Trim & "'"

        Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)


        Dim ds_MemberPolicy As New DataSet

        da_MemberPolicy.Fill(ds_MemberPolicy, "vi_Member_Policy_v3")

        Select Case ds_MemberPolicy.Tables("vi_Member_Policy_v3").Rows.Count
            Case 0
                Me.lblRecord_Status.Text = "Record Not Found in DB!"
                Me.lblMemberPolicy_ID.Text = "GUID"
            Case 1
                Me.lblRecord_Status.Text = ds_MemberPolicy.Tables("vi_Member_Policy_v3").Rows.Count.ToString.Trim & " record found in DB."

                With ds_MemberPolicy.Tables("vi_Member_Policy_v3").Rows(0)
                    Me.lblMemberPolicy_ID.Text = .Item("ID").ToString.Trim
                    Me.lblRequested_Amount_OldValue.Text = .Item("Deduction_Amount").ToString
                    If Me.chkGT_Wrong_RequestedAmount.CheckState = CheckState.Unchecked Then
                        Me.txtRequested_Amount.Text = .Item("Deduction_Amount").ToString
                    End If

                    If (IsDBNull(.Item("Effective_Date").ToString) = False) And (Len(.Item("Effective_Date").ToString.Trim) > 0) Then
                        Me.txtPolicy_EffectiveDate.Text = Convert.ToDateTime(.Item("Effective_Date").ToString)
                    End If
                    If (IsDBNull(.Item("Cancellation_Date").ToString) = False) And (Len(.Item("Cancellation_Date").ToString.Trim) > 0) Then
                        Me.txtPolicy_CancellationDate.Text = Convert.ToDateTime(.Item("Cancellation_Date").ToString)
                    Else
                        Me.txtPolicy_CancellationDate.Text = ""
                    End If
                End With
            Case Else
                Dim dr_Multi_MemberPolicies As DataRow()
                dr_Multi_MemberPolicies = ds_MemberPolicy.Tables("vi_Member_Policy_v3").Select("IC_New = '" & Me.txtNRIC.Text.Trim & "' " & _
                                                                                               "AND Deduction_Code = '" & Me.txtDeduction_Code.Text.Trim & "' " & _
                                                                                               "AND Cancellation_Date IS NULL")

                Select Case dr_Multi_MemberPolicies.Length
                    Case 0
                        Me.lblRecord_Status.Text = dr_Multi_MemberPolicies.Length.ToString.Trim & " record found in DB."
                        Me.lblMemberPolicy_ID.Text = "GUID"
                        MsgBox("Pls do contact your system vendor as there 0 record found for this IC and Deduction Code which the Cancellation Date is NULL.")
                    Case 1
                        Me.lblRecord_Status.Text = dr_Multi_MemberPolicies.Length.ToString.Trim & " record found in DB."

                        With dr_Multi_MemberPolicies(0)
                            Me.lblMemberPolicy_ID.Text = .Item("ID").ToString.Trim
                            Me.lblRequested_Amount_OldValue.Text = .Item("Deduction_Amount").ToString
                            If Me.chkGT_Wrong_RequestedAmount.CheckState = CheckState.Unchecked Then
                                Me.txtRequested_Amount.Text = .Item("Deduction_Amount").ToString
                            End If

                            If (IsDBNull(.Item("Effective_Date").ToString) = False) And (Len(.Item("Effective_Date").ToString.Trim) > 0) Then
                                Me.txtPolicy_EffectiveDate.Text = Convert.ToDateTime(.Item("Effective_Date").ToString)
                            End If

                            If (IsDBNull(.Item("Cancellation_Date").ToString) = False) And (Len(.Item("Cancellation_Date").ToString.Trim) > 0) Then
                                Me.txtPolicy_CancellationDate.Text = Convert.ToDateTime(.Item("Cancellation_Date").ToString)
                            End If
                        End With
                    Case Else
                        Me.lblRecord_Status.Text = dr_Multi_MemberPolicies.Length.ToString.Trim & " record found in DB."
                        Me.lblMemberPolicy_ID.Text = "GUID"
                        MsgBox("Pls do contact your system vendor as there is more than 1 record found for this IC and Deduction Code.")
                End Select
        End Select
    End Sub
    Private Sub Flag_chkGTs()
        Me.chkGT_Wrong_DeductionCode.CheckState = CheckState.Unchecked
        Me.chkGT_Wrong_DeductionAmount.CheckState = CheckState.Unchecked
        Me.chkGT_Old_DeductionCode_Old_Premium.CheckState = CheckState.Unchecked
        Me.chkGT_Reprocess.CheckState = CheckState.Unchecked
        Me.chkGT_Wrong_RequestedAmount.CheckState = CheckState.Unchecked
    End Sub
#End Region
#Region "Click Events"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim Result As Integer
        Result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Proceed with the transfer?")
        Select Case Result
            Case 6
                If Me.cbIgnore.Checked Then
                    If Len(Me.txtRemarks.Text.Trim()) > 0 Then
                        Dim sRes As String
                        SharedData.ReadyToHideMarquee = False
                        StartMarqueeThread()
                        sRes = _objBusi.spUpdate("SUSPENDIGNORE", "IGNORE", Me.txtRemarks.Text.Trim.Trim(), My.Settings.Username, "", "", Me.txtReceiving_Month.Text.Trim, Me.txtBatch_No.Text.Trim, Me.txtDeduction_Code.Text.Trim, Me.txtDeduction_Month.Text.Trim, Me.txtNRIC.Text.Trim, Conn)
                        SyncLock SharedData
                            SharedData.ReadyToHideMarquee = True
                        End SyncLock
                        Application.DoEvents()
                        If sRes = "1" Then
                            MsgBox("Record Ignored successfully.")
                            Me.Close()
                        Else
                            MsgBox("Error in Ignoring this record.")
                        End If
                    Else
                        MsgBox("Please do key in the remark!")
                    End If
                    Exit Sub
                End If
                If Me.rdiRT_CR_Prior01012009.Checked = True Then
                    If Me.Transfer_FI_SuspendAccount("Cancelled / Retired policy prior 01/01/2009") = True Then
                        MsgBox("Record transferred successfully.")
                    Else
                        MsgBox("Error in transfering this record.")
                    End If
                End If

                If Me.rdiRT_GE_DeductionCode.Checked = True Then
                    If Me.Transfer_FI_SuspendAccount("GE Deduction Code") = True Then
                        MsgBox("Record transferred successfully.")
                    Else
                        MsgBox("Error in transfering this record.")
                    End If
                End If

                If Me.rdiRT_StampDuty.Checked = True Then
                    If Me.Transfer_FI_SuspendAccount("Stamp Duty prior 01/01/2008") = True Then
                        MsgBox("Record transferred successfully.")
                    Else
                        MsgBox("Error in transfering this record.")
                    End If
                End If

                If Me.rdiRT_SuspendAccount.Checked = True Then
                    If Me.Transfer_FI_SuspendAccount("Angkasa's Suspend Account") = True Then
                        MsgBox("Record transferred successfully.")
                    Else
                        MsgBox("Error in transfering this record.")
                    End If
                End If

                If Me.rdiRT_CR.Checked = True Then
                    If Me.Transfer_FI_SuspendAccount("Cancelled / Retired policy but monthly deduction still goes on") = True Then
                        MsgBox("Record transferred successfully.")
                    Else
                        MsgBox("Error in transfering this record.")
                    End If
                End If

                If Me.chkGT_Wrong_DeductionCode.CheckState = CheckState.Checked Then
                    If Me.chkGT_Wrong_DeductionAmount.CheckState = CheckState.Checked Then
                        If Me.Transfer_Member_Policy_MonthlyDeduction("Wrong Code: " & Me.lblDeduction_Code_OldValue.Text.Trim & " -> " & Me.txtDeduction_Code.Text.Trim & ", Wrong Deduction Amount") = True Then
                            MsgBox("Record transferred successfully.")
                        Else
                            MsgBox("Error in transfering this record.")
                        End If
                    Else
                        If Me.Transfer_Member_Policy_MonthlyDeduction("Wrong Code: " & Me.lblDeduction_Code_OldValue.Text.Trim & " -> " & Me.txtDeduction_Code.Text.Trim) = True Then
                            MsgBox("Record transferred successfully.")
                        Else
                            MsgBox("Error in transfering this record.")
                        End If
                    End If
                Else
                    If Me.chkGT_Wrong_RequestedAmount.CheckState = CheckState.Checked Then
                        If Me.chkGT_Wrong_DeductionAmount.CheckState = CheckState.Checked Then
                            If Me.Transfer_Member_Policy_MonthlyDeduction("Wrong Requested Amount: " & Me.lblRequested_Amount_OldValue.Text.Trim & " -> " & Me.txtRequested_Amount.Text.Trim & ", Wrong Deduction Amount") = True Then
                                MsgBox("Record transferred successfully.")
                            Else
                                MsgBox("Error in transfering this record.")
                            End If
                        Else
                            If Me.Transfer_Member_Policy_MonthlyDeduction("Wrong Requested Amount: " & Me.lblRequested_Amount_OldValue.Text.Trim & " -> " & Me.txtRequested_Amount.Text.Trim) = True Then
                                MsgBox("Record transferred successfully.")
                            Else
                                MsgBox("Error in transfering this record.")
                            End If
                        End If
                    Else
                        If Me.chkGT_Wrong_DeductionAmount.CheckState = CheckState.Checked Then
                            If Me.Transfer_Member_Policy_MonthlyDeduction("Wrong Deduction Amount") = True Then
                                MsgBox("Record transferred successfully.")
                            Else
                                MsgBox("Error in transfering this record.")
                            End If
                        End If
                    End If
                End If

                If Me.chkGT_Old_DeductionCode_Old_Premium.CheckState = CheckState.Checked Then
                    If Me.Transfer_Member_Policy_MonthlyDeduction("Old Deduction Code: " & Me.lblDeduction_Code_OldValue.Text.Trim & " -> " & Me.txtDeduction_Code.Text.Trim & ", Old Deduction Amount") = True Then
                        MsgBox("Record transferred successfully.")
                    Else
                        MsgBox("Error in transfering this record.")
                    End If
                End If

                If Me.chkGT_Reprocess.CheckState = CheckState.Checked Then
                    If Me.Transfer_Member_Policy_MonthlyDeduction("Reprocessing after updating of Member's Policy") = True Then
                        MsgBox("Record transferred successfully.")
                    Else
                        MsgBox("Error in transfering this record.")
                    End If
                End If
                If Me.cb0599.CheckState = CheckState.Checked Then
                    Insert_0599()
                End If
            Case 7
                Exit Sub
        End Select
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region
#Region "Process"
    Private Function chk0599() As Boolean
        Dim sqlCmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        sqlCmd.CommandType = CommandType.Text
        sqlCmd.CommandText = "select * from dt_member_policy where member_id=(select id from dt_member where ic_new='" & Me.txtNRIC.Text.Trim & "') and deduction_code='0599'"
        Dim adp As New SqlDataAdapter(sqlCmd)
        Dim ds As New DataSet
        adp.Fill(ds, "dt_member_policy")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function Add_MonthlyDeduction0599(ByVal id As String) As Boolean
        If id = "" Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim sqlCmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.CommandText = "select * from dt_member_policy where member_id=(select id from dt_member where ic_new='" & Me.txtNRIC.Text.Trim & "') and deduction_code='0599'"
            Dim adp As New SqlDataAdapter(sqlCmd)
            Dim ds As New DataSet
            adp.Fill(ds, "dt_member_policy")

            Dim sqlCmd0599 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            sqlCmd0599.CommandType = CommandType.Text
            sqlCmd0599.CommandText = "SELECT * FROM dt_Member_Policy_MonthlyDeduction where member_policy_id='" & ds.Tables(0).Rows(0)("ID").ToString & "'"
            Dim adp0599 As New SqlDataAdapter(sqlCmd0599)

            Dim cmdSelect_Monthly_Angkasa_KIV As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Monthly_Angkasa_KIV.CommandType = CommandType.Text
            cmdSelect_Monthly_Angkasa_KIV.CommandTimeout = 900000
            cmdSelect_Monthly_Angkasa_KIV.CommandText = "SELECT * FROM dt_Angkasa_Monthly_SuspendAccount " & _
                                                        "WHERE No_Kad_Pengenalan = '" & Me.txtNRIC.Text.Trim & "' AND " & _
                                                        "Angkasa_Bulan_Potongan = '" & Me.txtDeduction_Month.Text.Trim & "' AND " & _
                                                        "Angkasa_Kod_Potongan = '" & Me.lblDeduction_Code_OldValue.Text.Trim & "' AND " & _
                                                        "Angkasa_Batch_No = '" & Me.txtBatch_No.Text.Trim & "' AND " & _
                                                        "Receiving_Month = '" & Me.txtReceiving_Month.Text.Trim & "'"

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
                .Item("Angkasa_Bulan_Potongan") = Me.txtDeduction_Month.Text.Trim
                .Item("Angkasa_Kod_Potongan") = Me.txtDeduction_Code.Text.Trim
                .Item("Angkasa_Jumlah_Pokok") = Me.txtDeduction_Amount.Text.Trim
                .Item("Angkasa_Batch_No") = Me.txtBatch_No.Text.Trim
                .Item("Receiving_Month") = Me.txtReceiving_Month.Text.Trim
                .Item("Remark") = ""
            End With
            ds0599.Tables("dt_Member_Policy_MonthlyDeduction").Rows.Add(dr0599)
            adp0599.Update(ds0599, "dt_Member_Policy_MonthlyDeduction")

            If ds0599.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows.Count = 1 Then
                ds0599.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows(0).Delete()
                da_Monthly_Angkasa_KIV.Update(ds0599, "dt_Angkasa_Monthly_SuspendAccount")
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                MsgBox("Successfully inserted.")
            Else
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                MsgBox("Error in deleting record from Table: dt_Angkasa_Monthly_SuspendAccount")
            End If
        Else
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim sqlCmd0599 As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            sqlCmd0599.CommandType = CommandType.Text
            sqlCmd0599.CommandTimeout = 900000
            sqlCmd0599.CommandText = "SELECT * FROM dt_Member_Policy_MonthlyDeduction"
            Dim adp0599 As New SqlDataAdapter(sqlCmd0599)
            Dim SqlcmdIns0599 As SqlCommandBuilder
            SqlcmdIns0599 = New SqlCommandBuilder(adp0599)

            Dim cmdSelect_Monthly_Angkasa_KIV As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Monthly_Angkasa_KIV.CommandType = CommandType.Text
            cmdSelect_Monthly_Angkasa_KIV.CommandText = "SELECT * FROM dt_Angkasa_Monthly_SuspendAccount " & _
                                                        "WHERE No_Kad_Pengenalan = '" & Me.txtNRIC.Text.Trim & "' AND " & _
                                                        "Angkasa_Bulan_Potongan = '" & Me.txtDeduction_Month.Text.Trim & "' AND " & _
                                                        "Angkasa_Kod_Potongan = '" & Me.lblDeduction_Code_OldValue.Text.Trim & "' AND " & _
                                                        "Angkasa_Batch_No = '" & Me.txtBatch_No.Text.Trim & "' AND " & _
                                                        "Receiving_Month = '" & Me.txtReceiving_Month.Text.Trim & "'"

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
                .Item("Angkasa_Bulan_Potongan") = Me.txtDeduction_Month.Text.Trim
                .Item("Angkasa_Kod_Potongan") = Me.txtDeduction_Code.Text.Trim
                .Item("Angkasa_Jumlah_Pokok") = Me.txtDeduction_Amount.Text.Trim
                .Item("Angkasa_Batch_No") = Me.txtBatch_No.Text.Trim
                .Item("Receiving_Month") = Me.txtReceiving_Month.Text.Trim
                .Item("Remark") = ""
            End With
            ds0599.Tables("dt_Member_Policy_MonthlyDeduction").Rows.Add(dr0599)
            adp0599.Update(ds0599, "dt_Member_Policy_MonthlyDeduction")

            If ds0599.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows.Count = 1 Then
                ds0599.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows(0).Delete()
                da_Monthly_Angkasa_KIV.Update(ds0599, "dt_Angkasa_Monthly_SuspendAccount")
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                MsgBox("Successfully inserted.")
            Else
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                MsgBox("Error in deleting record from Table: dt_Angkasa_Monthly_SuspendAccount")
            End If
        End If
    End Function
    Private Function Insert_0599() As Boolean

        If chk0599() Then
            Add_MonthlyDeduction0599("")
        Else
            Try
                Dim sRes As String
                Dim ds As New DataSet
                SharedData.ReadyToHideMarquee = False
                StartMarqueeThread()
                Dim sqlCmd As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                sqlCmd.CommandType = CommandType.Text
                sqlCmd.CommandTimeout = 900000
                sqlCmd.CommandText = "select * from dt_member_policy where member_id=(select id from dt_member where ic_new='" & Me.txtNRIC.Text.Trim & "')"

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
                    .Item("Deduction_Code") = Me.txtDeduction_Code.Text.ToString.Trim
                    .Item("Deduction_Amount") = Me.txtDeduction_Amount.Text.ToString.Trim
                    If Me.txtPolicy_EffectiveDate.Text.ToString.Trim = "" Then
                        .Item("Effective_Date") = dr_MemberPolicy_Old.Item("Effective_Date")
                    Else
                        .Item("Effective_Date") = Me.txtPolicy_EffectiveDate.Text.ToString.Trim
                    End If
                    If Me.txtPolicy_CancellationDate.Text.ToString.Trim = "" Then
                        .Item("Cancellation_Date") = dr_MemberPolicy_Old.Item("Cancellation_Date")
                    Else
                        .Item("Cancellation_Date") = Me.txtPolicy_CancellationDate.Text.ToString.Trim
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
                Add_MonthlyDeduction0599(var_MemberPolicy_ID_New)
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                MsgBox("Successfully inserted.")
            Catch ex As Exception
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                MsgBox("Record already existed or Error while inserting the record!")
            End Try
        End If
    End Function
    Private Function Transfer_FI_SuspendAccount(ByVal var_Transfer_Remark As String) As Boolean

        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim cmdSelect_FI_SuspendAccount As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_FI_SuspendAccount.CommandType = CommandType.Text
        cmdSelect_FI_SuspendAccount.CommandText = "SELECT * FROM dt_FI_SuspendAccount"

        Dim da_FI_SuspendAccount As New SqlDataAdapter(cmdSelect_FI_SuspendAccount)

        Dim cmdInsert_FI_SuspendAccount As SqlCommandBuilder
        cmdInsert_FI_SuspendAccount = New SqlCommandBuilder(da_FI_SuspendAccount)


        Dim cmdSelect_Monthly_Angkasa_KIV As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Monthly_Angkasa_KIV.CommandType = CommandType.Text
        cmdSelect_Monthly_Angkasa_KIV.CommandText = "SELECT * FROM dt_Angkasa_Monthly_SuspendAccount " & _
                                                    "WHERE No_Kad_Pengenalan = '" & Me.txtNRIC.Text.Trim & "' AND " & _
                                                    "Angkasa_Bulan_Potongan = '" & Me.txtDeduction_Month.Text.Trim & "' AND " & _
                                                    "Angkasa_Kod_Potongan = '" & Me.txtDeduction_Code.Text.Trim & "' AND " & _
                                                    "Angkasa_Batch_No = '" & Me.txtBatch_No.Text.Trim & "' AND " & _
                                                    "Receiving_Month = '" & Me.txtReceiving_Month.Text.Trim & "'"

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
                .Item("No_Kad_Pengenalan") = Me.txtNRIC.Text.Trim
                .Item("Angkasa_Bulan_Potongan") = Me.txtDeduction_Month.Text.Trim
                .Item("Angkasa_Kod_Potongan") = Me.txtDeduction_Code.Text.Trim
                .Item("Angkasa_Jumlah_Pokok") = Me.txtDeduction_Amount.Text.Trim
                .Item("Angkasa_Batch_No") = Me.txtBatch_No.Text.Trim
                .Item("Receiving_Month") = Me.txtReceiving_Month.Text.Trim
                .Item("Remark") = var_Transfer_Remark.Trim
                .Item("Created_By") = My.Settings.Username.Trim
                .Item("Created_On") = Now()
            End With


            ds_SuspendAccount.Tables("dt_FI_SuspendAccount").Rows.Add(dr_FI_SuspendAccount_New)
            da_FI_SuspendAccount.Update(ds_SuspendAccount, "dt_FI_SuspendAccount")

            If ds_SuspendAccount.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows.Count = 1 Then
                ds_SuspendAccount.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows(0).Delete()
                da_Monthly_Angkasa_KIV.Update(ds_SuspendAccount, "dt_Angkasa_Monthly_SuspendAccount")
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                Return True
            Else
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                MsgBox("Error in deleting record from Table: dt_Angkasa_Monthly_SuspendAccount")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
    Private Function Transfer_Member_Policy_MonthlyDeduction(ByVal var_Transfer_Remark As String) As Boolean
        
        Dim cmdSelect_MemberPolicy_MonthlyDeduction As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy_MonthlyDeduction.CommandType = CommandType.Text
        cmdSelect_MemberPolicy_MonthlyDeduction.CommandTimeout = 9000000

        cmdSelect_MemberPolicy_MonthlyDeduction.CommandText = "SELECT * FROM dt_Member_Policy_MonthlyDeduction WHERE MEMBER_POLICY_ID ='" & Me.lblMemberPolicy_ID.Text.ToString.Trim() & "'"

        Dim da_MemberPolicy_MonthlyDeduction As New SqlDataAdapter(cmdSelect_MemberPolicy_MonthlyDeduction)

        Dim cmdInsert_MemberPolicy_MonthlyDeduction As SqlCommandBuilder
        cmdInsert_MemberPolicy_MonthlyDeduction = New SqlCommandBuilder(da_MemberPolicy_MonthlyDeduction)




        Dim cmdSelect_Monthly_Angkasa_KIV As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Monthly_Angkasa_KIV.CommandType = CommandType.Text
        cmdSelect_Monthly_Angkasa_KIV.CommandTimeout = 9000000
        cmdSelect_Monthly_Angkasa_KIV.CommandText = "SELECT * FROM dt_Angkasa_Monthly_SuspendAccount " & _
                                                    "WHERE No_Kad_Pengenalan = '" & Me.txtNRIC.Text.Trim & "' AND " & _
                                                    "Angkasa_Bulan_Potongan = '" & Me.txtDeduction_Month.Text.Trim & "' AND " & _
                                                    "Angkasa_Kod_Potongan = '" & Me.lblDeduction_Code_OldValue.Text.Trim & "' AND " & _
                                                    "Angkasa_Batch_No = '" & Me.txtBatch_No.Text.Trim & "' AND " & _
                                                    "Receiving_Month = '" & Me.txtReceiving_Month.Text.Trim & "'"

        Dim da_Monthly_Angkasa_KIV As New SqlDataAdapter(cmdSelect_Monthly_Angkasa_KIV)

        Dim cmdDelete_Monthly_Angkasa_KIV As SqlCommandBuilder
        cmdDelete_Monthly_Angkasa_KIV = New SqlCommandBuilder(da_Monthly_Angkasa_KIV)


        Dim ds_MemberPolicy_MonthlyDeduction As New DataSet


        Try
            da_MemberPolicy_MonthlyDeduction.Fill(ds_MemberPolicy_MonthlyDeduction, "dt_Member_Policy_MonthlyDeduction")
            da_Monthly_Angkasa_KIV.Fill(ds_MemberPolicy_MonthlyDeduction, "dt_Angkasa_Monthly_SuspendAccount")

            Dim dr_MemberPolicy_MonthlyDeduction_New As DataRow


            dr_MemberPolicy_MonthlyDeduction_New = ds_MemberPolicy_MonthlyDeduction.Tables("dt_Member_Policy_MonthlyDeduction").NewRow

            With dr_MemberPolicy_MonthlyDeduction_New
                .Item("ID") = Guid.NewGuid.ToString()
                .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.ToString.Trim()
                .Item("Angkasa_Bulan_Potongan") = Me.txtDeduction_Month.Text.Trim
                .Item("Angkasa_Kod_Potongan") = Me.txtDeduction_Code.Text.Trim
                .Item("Angkasa_Jumlah_Pokok") = Me.txtDeduction_Amount.Text.Trim
                .Item("Angkasa_Batch_No") = Me.txtBatch_No.Text.Trim
                .Item("Receiving_Month") = Me.txtReceiving_Month.Text.Trim
                .Item("Remark") = var_Transfer_Remark.Trim
            End With

            ds_MemberPolicy_MonthlyDeduction.Tables("dt_Member_Policy_MonthlyDeduction").Rows.Add(dr_MemberPolicy_MonthlyDeduction_New)
            da_MemberPolicy_MonthlyDeduction.Update(ds_MemberPolicy_MonthlyDeduction, "dt_Member_Policy_MonthlyDeduction")

            If ds_MemberPolicy_MonthlyDeduction.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows.Count = 1 Then
                ds_MemberPolicy_MonthlyDeduction.Tables("dt_Angkasa_Monthly_SuspendAccount").Rows(0).Delete()
                da_Monthly_Angkasa_KIV.Update(ds_MemberPolicy_MonthlyDeduction, "dt_Angkasa_Monthly_SuspendAccount")
                
                Transfer_Member_Policy_MonthlyDeduction = True
            Else
                
                MsgBox("Error in deleting record from Table: dt_Angkasa_Monthly_SuspendAccount")
                Transfer_Member_Policy_MonthlyDeduction = False
            End If

            If Me.txtRequested_Amount.Text.Trim <> Me.lblRequested_Amount_OldValue.Text.Trim Then

                Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect_MemberPolicy.CommandType = CommandType.Text
                cmdSelect_MemberPolicy.CommandTimeout = 9000000

                cmdSelect_MemberPolicy.CommandText = "SELECT ID, Member_ID, Deduction_Code, Effective_Date, status " & _
                                                     "FROM dt_Member_Policy WHERE ID = '" & Me.lblMemberPolicy_ID.Text.ToString.Trim() & "'"

                Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)

                Dim cmdUpdate_MemberPolicy As SqlCommandBuilder
                cmdUpdate_MemberPolicy = New SqlCommandBuilder(da_MemberPolicy)

                da_MemberPolicy.Fill(ds_MemberPolicy_MonthlyDeduction, "dt_Member_Policy")

                If ds_MemberPolicy_MonthlyDeduction.Tables("dt_Member_Policy").Rows.Count = 1 Then
                    With ds_MemberPolicy_MonthlyDeduction.Tables("dt_Member_Policy").Rows(0)
                        .Item("Deduction_Amount") = Me.txtDeduction_Amount.Text.Trim
                    End With
                    da_MemberPolicy.Update(ds_MemberPolicy_MonthlyDeduction, "dt_Member_Policy")
                
                    Transfer_Member_Policy_MonthlyDeduction = True
                Else
                    MsgBox("Error in updating record from Table: dt_Member_Policy")
                    Transfer_Member_Policy_MonthlyDeduction = False
                End If
            End If

            If Len(Me.txtPolicy_EffectiveDate.Text.Trim) = 0 Then

                Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect_MemberPolicy.CommandType = CommandType.Text
                cmdSelect_MemberPolicy.CommandTimeout = 9000000
                cmdSelect_MemberPolicy.CommandText = "SELECT ID, Member_ID, Deduction_Code, Effective_Date, Angkasa_FileNo, status " & _
                                                     "FROM dt_Member_Policy WHERE ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"

                Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)

                Dim cmdUpdate_MemberPolicy As SqlCommandBuilder
                cmdUpdate_MemberPolicy = New SqlCommandBuilder(da_MemberPolicy)

                da_MemberPolicy.Fill(ds_MemberPolicy_MonthlyDeduction, "dt_Member_Policy")

                If ds_MemberPolicy_MonthlyDeduction.Tables("dt_Member_Policy").Rows.Count = 1 Then
                    With ds_MemberPolicy_MonthlyDeduction.Tables("dt_Member_Policy").Rows(0)
                        Dim var_effective_month As Short
                        Dim var_effective_year As Short
                        Dim var_effective_date As Date

                        var_effective_month = Val(Me.txtReceiving_Month.Text.Trim.Substring(4, 2)) + 1
                        var_effective_year = Val(Me.txtReceiving_Month.Text.Trim.Substring(0, 4))

                        If var_effective_month = 13 Then
                            var_effective_year += 1
                            var_effective_month = 1
                        End If

                        var_effective_date = Convert.ToDateTime(Str(var_effective_year) & "/" & Str(var_effective_month) & "/15")
                        .Item("Effective_Date") = var_effective_date
                        .Item("STATUS") = "INFORCE"
                        _objBusi.InsUpsPremiumHistory("UP", Guid.NewGuid.ToString(), Me.lblMemberPolicy_ID.Text.ToString.Trim(), Format(var_effective_date, "MM/dd/yyyy"), "", "", "Active", "", "", Conn)

                        _objBusi.spUpdate("GST", Me.lblMemberPolicy_ID.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)

                        _objBusi.InsUpsPolicyPremiumHistory("UPDATESTARTDATE", Me.lblMemberPolicy_ID.Text.ToString.Trim(), "0.00", Format(var_effective_date, "MM/dd/yyyy"), "", "", My.Settings.Username, Conn)
                    End With
                    da_MemberPolicy.Update(ds_MemberPolicy_MonthlyDeduction, "dt_Member_Policy")
                    Transfer_Member_Policy_MonthlyDeduction = True
                Else
                    MsgBox("Error in updating record from Table: dt_Member_Policy")
                    Transfer_Member_Policy_MonthlyDeduction = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
#End Region
#Region "Change Events"
    Private Sub chkGT_Wrong_DeductionCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGT_Wrong_DeductionCode.CheckedChanged
        If Me.chkGT_Wrong_DeductionCode.CheckState = CheckState.Checked Then
            Me.Flag_rdiRTs()

            Me.chkGT_Old_DeductionCode_Old_Premium.Checked = False
            Me.chkGT_Reprocess.Checked = False
            Me.chkGT_Wrong_RequestedAmount.CheckState = False
            Me.txtDeduction_Code.ReadOnly = False
            Me.cb0599.Checked = False
            Me.txtDeduction_Code.Focus()
        Else
            Me.txtDeduction_Code.Text = Me.lblDeduction_Code_OldValue.Text.Trim
            Me.txtDeduction_Code.ReadOnly = True
        End If
        Me.Check_Status()
    End Sub
    Private Sub chkGT_Wrong_DeductionAmount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGT_Wrong_DeductionAmount.CheckedChanged
        If Me.chkGT_Wrong_DeductionAmount.CheckState = CheckState.Checked Then
            Me.Flag_rdiRTs()

            Me.chkGT_Old_DeductionCode_Old_Premium.Checked = False
            Me.chkGT_Reprocess.Checked = False
            Me.cb0599.Checked = False
            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
        Else
            Me.OK_Button.Enabled = False
        End If
        Me.Check_Status()
    End Sub
    Private Sub chkGT_Old_DeductionCode_Old_Premium_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGT_Old_DeductionCode_Old_Premium.CheckedChanged
        If Me.chkGT_Old_DeductionCode_Old_Premium.CheckState = CheckState.Checked Then
            Me.Flag_rdiRTs()

            Me.chkGT_Wrong_DeductionCode.Checked = False
            Me.chkGT_Wrong_DeductionAmount.Checked = False
            Me.chkGT_Reprocess.Checked = False
            Me.chkGT_Wrong_RequestedAmount.Checked = False

            Me.txtDeduction_Code.ReadOnly = False
            Me.cb0599.Checked = False
            Me.txtDeduction_Code.Focus()
        Else
            Me.txtDeduction_Code.Text = Me.lblDeduction_Code_OldValue.Text.Trim
            Me.txtDeduction_Code.ReadOnly = True
        End If
        Me.Check_Status()
    End Sub
    Private Sub chkGT_Reprocess_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGT_Reprocess.CheckedChanged
        If Me.chkGT_Reprocess.CheckState = CheckState.Checked Then

            Me.Flag_rdiRTs()

            Me.chkGT_Wrong_DeductionCode.Checked = False
            Me.chkGT_Wrong_DeductionAmount.Checked = False
            Me.chkGT_Old_DeductionCode_Old_Premium.Checked = False
            Me.chkGT_Wrong_RequestedAmount.Checked = False
            Me.cb0599.Checked = False
            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
        Else
            Me.OK_Button.Enabled = False
        End If
        Me.Check_Status()
    End Sub
    Private Sub chkGT_Wrong_RequestedAmount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGT_Wrong_RequestedAmount.CheckedChanged
        If Me.chkGT_Wrong_RequestedAmount.CheckState = CheckState.Checked Then
            Me.Flag_rdiRTs()

            Me.chkGT_Wrong_DeductionCode.Checked = False
            Me.chkGT_Old_DeductionCode_Old_Premium.Checked = False
            Me.chkGT_Reprocess.Checked = False

            Me.txtRequested_Amount.ReadOnly = False
            Me.cb0599.Checked = False
            Me.txtRequested_Amount.Focus()
            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
        Else
            Me.txtRequested_Amount.Text = Me.lblRequested_Amount_OldValue.Text.Trim
            Me.txtRequested_Amount.ReadOnly = True
            Me.OK_Button.Enabled = False
        End If
        Me.Check_Status()
    End Sub
    Private Sub rdiRT_CR_Prior01012009_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiRT_CR_Prior01012009.CheckedChanged
        If Me.rdiRT_CR_Prior01012009.Checked = True Then
            Me.Flag_chkGTs()

            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
        End If
    End Sub
    Private Sub rdiRT_GE_DeductionCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiRT_GE_DeductionCode.CheckedChanged
        If Me.rdiRT_GE_DeductionCode.Checked = True Then
            Me.Flag_chkGTs()

            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
        End If
    End Sub
    Private Sub rdiRT_StampDuty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiRT_StampDuty.CheckedChanged
        If Me.rdiRT_StampDuty.Checked = True Then
            Me.Flag_chkGTs()

            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
        End If
    End Sub
    Private Sub rdiRT_SuspendAccount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiRT_SuspendAccount.CheckedChanged
        If Me.rdiRT_SuspendAccount.Checked = True Then
            Me.Flag_chkGTs()

            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
        End If
    End Sub
    Private Sub rdiRT_CR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiRT_CR.CheckedChanged
        If Me.rdiRT_CR.Checked = True Then
            Me.Flag_chkGTs()

            If Me.lblMemberPolicy_ID.Text.Trim = "GUID" Then
                Me.OK_Button.Enabled = False
                Me.Cancel_Button.Focus()
            Else
                If Len(Me.txtPolicy_CancellationDate.Text.Trim) = 0 Then
                    Me.OK_Button.Enabled = False
                    Me.Cancel_Button.Focus()
                Else
                    Me.OK_Button.Enabled = True
                    Me.OK_Button.Focus()
                End If

            End If
        End If
    End Sub
    Private Sub lblMemberPolicy_ID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMemberPolicy_ID.TextChanged
        If Me.lblMemberPolicy_ID.Text.Trim = "GUID" Then
            If Me.rdiRT_CR_Prior01012009.Checked = True Then
                Me.OK_Button.Enabled = True
                Me.OK_Button.Focus()
            Else
                Me.OK_Button.Enabled = False
                Me.Cancel_Button.Focus()
            End If
        Else
            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
        End If
    End Sub
    Private Sub cb0599_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb0599.CheckedChanged
        If Me.cb0599.Checked Then
            Me.Flag_rdiRTs()
            Me.chkGT_Wrong_DeductionCode.Checked = False
            Me.chkGT_Wrong_DeductionAmount.Checked = False
            Me.chkGT_Old_DeductionCode_Old_Premium.Checked = False
            Me.chkGT_Wrong_RequestedAmount.Checked = False
            Me.txtRemarks.Enabled = False
            Me.chkGT_Reprocess.Checked = False
            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
        Else
            Me.OK_Button.Enabled = False
            Me.OK_Button.Focus()
        End If
    End Sub
    Private Sub cbIgnore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIgnore.CheckedChanged
        If Me.cbIgnore.Checked Then
            Me.Flag_rdiRTs()
            Me.Flag_chkGTs()
            Me.cb0599.CheckState = CheckState.Unchecked
            Me.txtRemarks.Enabled = True
            Me.OK_Button.Enabled = True
            Me.OK_Button.Focus()
        Else
            Me.OK_Button.Enabled = False
            Me.OK_Button.Focus()
        End If
    End Sub
#End Region
#Region "Validate"
    Private Sub txtDeduction_Code_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDeduction_Code.Validating
        Me.Check_Status()
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
