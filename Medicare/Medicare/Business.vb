Imports System.Net.Mail
Public Class Business
    Public Function Log(ByVal ID As String, ByVal Activity_Details As String, ByVal Conn As SqlConnection) As Boolean
        Dim ds_endorsement As New DataSet
        Dim cmdSelect_MemberLog As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberLog.CommandType = CommandType.Text
        cmdSelect_MemberLog.CommandText = "SELECT * FROM log_Member " & _
                                          "WHERE Member_Policy_ID = '" & ID & "'"
        Dim da_MemberLog As New SqlDataAdapter(cmdSelect_MemberLog)

        Dim cmdInsert_MemberLog As SqlCommandBuilder
        cmdInsert_MemberLog = New SqlCommandBuilder(da_MemberLog)


        da_MemberLog.Fill(ds_endorsement, "log_Member")



        Dim dr_MemberLog As DataRow
        dr_MemberLog = ds_endorsement.Tables("log_Member").NewRow

        With dr_MemberLog
            .Item("Member_Policy_ID") = ID
            .Item("Log_Date") = Now()
            .Item("Activity_Detail") = Activity_Details
            .Item("Username") = My.Settings.Username.Trim
            .Item("Created_By") = My.Settings.Username.Trim
            .Item("Created_On") = Now()
        End With
        ds_endorsement.Tables("log_Member").Rows.Add(dr_MemberLog)
        da_MemberLog.Update(ds_endorsement, "log_Member")

    End Function
    Public Function aLog(ByVal ID As String, ByVal Activity_Details As String, ByVal Conn As SqlConnection) As Boolean
        Dim ds_endorsement As New DataSet

        Dim cmdSelect_MemberLog As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberLog.CommandType = CommandType.Text
        cmdSelect_MemberLog.CommandText = "SELECT * FROM log_Member " & _
                                          "WHERE Member_Policy_ID = '" & ID & "'"
        Dim da_MemberLog As New SqlDataAdapter(cmdSelect_MemberLog)

        Dim cmdInsert_MemberLog As SqlCommandBuilder
        cmdInsert_MemberLog = New SqlCommandBuilder(da_MemberLog)


        da_MemberLog.Fill(ds_endorsement, "log_Member")



        Dim dr_MemberLog As DataRow
        dr_MemberLog = ds_endorsement.Tables("log_Member").NewRow

        With dr_MemberLog
            .Item("Member_Policy_ID") = ID
            .Item("Log_Date") = Now()
            .Item("Activity_Detail") = Activity_Details
            .Item("Username") = My.Settings.Username.Trim
            .Item("Created_By") = My.Settings.Username.Trim
            .Item("Created_On") = Now()
            .Item("M_Log") = True
        End With

        ds_endorsement.Tables("log_Member").Rows.Add(dr_MemberLog)
        da_MemberLog.Update(ds_endorsement, "log_Member")



    End Function
    Public Function EndorsementLog(ByVal Member_ID As String, ByVal Member_Policy_Id As String, _
                                    ByVal E_Type As String, ByVal E_Details As String, ByVal Request_Dt As String, _
                                    ByVal Remarks As String, ByVal Effective_Date As String, ByVal IC As String, ByVal Trans_Type As String, ByVal Conn As SqlConnection) As Boolean

        
        Dim ds_endorsement As New DataSet

        Dim cmdSelect_Member_Endorsement As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Endorsement.CommandType = CommandType.Text
        cmdSelect_Member_Endorsement.CommandText = "SELECT * FROM dt_Member_Endorsement"
        Dim da_Member_Endorsement As New SqlDataAdapter(cmdSelect_Member_Endorsement)

        Dim cmdInsert_Member_Endorsement As SqlCommandBuilder
        cmdInsert_Member_Endorsement = New SqlCommandBuilder(da_Member_Endorsement)
        da_Member_Endorsement.Fill(ds_endorsement, "dt_Member_Endorsement")

        Dim dr_Member_Endorsement_New As DataRow
        dr_Member_Endorsement_New = ds_endorsement.Tables("dt_Member_Endorsement").NewRow

        With dr_Member_Endorsement_New
            .Item("ID") = Guid.NewGuid.ToString()
            .Item("Member_ID") = Member_ID
            .Item("Member_Policy_ID") = Member_Policy_Id
            .Item("Log_Date") = Now()
            .Item("Endorsement_Type") = E_Type
            .Item("Endorsement_Detail") = E_Details
            .Item("Request_Date") = Request_Dt
            .Item("Remark") = Remarks
            .Item("TRANS_TYPE") = Trans_Type
            .Item("IC") = IC
            .Item("Username") = My.Settings.Username.Trim
            .Item("Created_By") = My.Settings.Username.Trim
            .Item("Created_On") = Now()
            .Item("Effective_Date") = Effective_Date
        End With

        ds_endorsement.Tables("dt_Member_Endorsement").Rows.Add(dr_Member_Endorsement_New)
        da_Member_Endorsement.Update(ds_endorsement, "dt_Member_Endorsement")

    End Function
    Public Function InsUpsUsers(ByVal type As String, ByVal id As String, ByVal fullname As String, ByVal userid As String, ByVal pwd As String, _
                                ByVal expiry_date As String, ByVal M As String, ByVal SM As String, ByVal status As String, _
                                ByVal created_by As String, ByVal Conn As SqlConnection) As String

        Dim sRes As String
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_InsUpsUsers]"
            .Connection = Conn
            .Parameters.AddWithValue("@Type", type)
            .Parameters.AddWithValue("@ID", id)
            .Parameters.AddWithValue("@FullName", fullname)
            .Parameters.AddWithValue("@UserID", userid)
            .Parameters.AddWithValue("@Pwd", pwd)
            .Parameters.Add("@Expiry_Date", SqlDbType.SmallDateTime)
            .Parameters("@Expiry_Date").Value = expiry_date
            .Parameters.AddWithValue("@Module", M)
            .Parameters.AddWithValue("@SubModule", SM)
            .Parameters.AddWithValue("@Status", status)
            .Parameters.AddWithValue("@Created_By", created_by)
            sRes = .ExecuteNonQuery
            sRes = "Done"
        End With
        Return sRes
    End Function
    Public Function InsAuditLogs(ByVal UserName As String, ByVal Remarks As String, ByVal Conn As SqlConnection) As String
        Dim sRes As String
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_InsAuditLogs]"
            .Connection = Conn
            .CommandTimeout = 180
            .Parameters.AddWithValue("@UserName", UserName)
            .Parameters.AddWithValue("@Remarks", Remarks)
            sRes = .ExecuteNonQuery
            sRes = "Done"
        End With
        Return sRes
    End Function
    Public Function chkUser(ByVal type As String, ByVal UserID As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_chkUsers]"
            .Connection = sqlConn
            .Parameters.AddWithValue("@Type", type)
            .Parameters.AddWithValue("@UserID", UserID)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getUsers(ByVal type As String, ByVal UserID As String, ByVal Pwd As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getUsers]"
            .Connection = sqlConn
            .Parameters.AddWithValue("@Type", type)
            .Parameters.AddWithValue("@UserID", UserID)
            .Parameters.AddWithValue("@Pwd", Pwd)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function InsMothlyDedution(ByVal IC As String, ByVal D_Month As String, ByVal D_Code As String, ByVal D_Amount As String, ByVal R_Month As String, ByVal Conn As SqlConnection) As String
        Dim sRes As String
        Try
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsMonthlyDeduction]"
                .Connection = Conn
                .Parameters.AddWithValue("@Member_Policy_ID", IC)
                .Parameters.AddWithValue("@Bulan_Potongan", D_Month)
                .Parameters.AddWithValue("@Kod_Potongan", D_Code)
                .Parameters.AddWithValue("@Jumlah_Pokok", D_Amount)
                .Parameters.AddWithValue("@Receiving_Month", R_Month)
                sRes = .ExecuteScalar
                If sRes = "1" Then
                    sRes = "Done"
                End If
            End With
            Return sRes
        Catch ex As Exception
            sRes = ex.Message
            Return sRes
        End Try
    End Function
    Public Function UpdatePolicyStatus(ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_UpdatePolicyStatus]"
                .Connection = Conn
                sRes = .ExecuteNonQuery
                sRes = "Done"
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function getProposerDetails(ByVal ID As String) As DataTable
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Dim dt As New DataTable
        Dim sda As SqlDataAdapter
        Dim _sc As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _sc.CommandType = CommandType.Text
        _sc.CommandText = "SELECT * FROM dt_Proposer WHERE ID='" & ID & "'"
        sda = New SqlDataAdapter(_sc)
        sda.Fill(dt)
        Conn.Close()
        Return dt
    End Function
    Public Function CheckValidation(ByVal type As String, ByVal IC As String, ByVal BP As String, ByVal KP As String, ByVal JP As String, ByVal Conn As SqlConnection) As String
        Dim sRes As String = ""
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_CheckValidation]"
            .Connection = Conn
            .Parameters.AddWithValue("@Type", type)
            .Parameters.AddWithValue("@IC", IC)
            .Parameters.AddWithValue("@BP", BP)
            If Len(KP.Trim) > 3 Then
                .Parameters.AddWithValue("@KP", KP)
            Else
                .Parameters.AddWithValue("@KP", "0" + KP)
            End If
            .Parameters.AddWithValue("@JP", JP)
            sRes = .ExecuteScalar
        End With
        Return sRes
    End Function
    Public Function AgeValidation(ByVal type As String, ByVal IC As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_AgeValidation]"
            .Connection = sqlConn
            .Parameters.AddWithValue("@Type", type)
            .Parameters.AddWithValue("@IC", IC)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function SwapClipboardHtmlText( _
    ByVal replacementHtmlText As String) As String

        Dim returnHtmlText As String = Nothing

        If (Clipboard.ContainsText(TextDataFormat.Html)) Then
            returnHtmlText = Clipboard.GetText(TextDataFormat.Html)
            Clipboard.SetText(replacementHtmlText, TextDataFormat.Html)
        End If
        Return returnHtmlText
    End Function
    Public Function getUWProposerDetails(ByVal type As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getUWProposerDetails]"
            .Connection = sqlConn
            .Parameters.AddWithValue("@Type", type)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function UpdateUWCIMBSTATUS(ByVal ID As String, ByVal BNo As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_UpUWStatus]"
                .Connection = Conn
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@BatchNo", BNo)
                sRes = .ExecuteNonQuery
                sRes = "Done"
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function getSubProposerDetails(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getProposerDetails]"
            .Connection = sqlConn
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getDetails(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails]"
            .Connection = sqlConn
            .CommandTimeout = 800000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getSummaryReports(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, _
                               ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable

        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_reports]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getSubmissionDetails_MID(ByVal Type As String, ByVal DateFrm As String, ByVal DateTo As String, ByVal DCode As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getSubmission_MID]"
            .Connection = sqlConn
            .CommandTimeout = 600
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@DateFrm", DateFrm)
            .Parameters.AddWithValue("@DateTo", DateTo)
            .Parameters.AddWithValue("@DCODE", DCode)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getSubmissionDetails(ByVal Type As String, ByVal DateFrm As String, ByVal DateTo As String, ByVal DCode As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getSubmission]"
            .Connection = sqlConn
            .CommandTimeout = 600
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@DateFrm", DateFrm)
            .Parameters.AddWithValue("@DateTo", DateTo)
            .Parameters.AddWithValue("@DCODE", DCode)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getSubmissionYDetails(ByVal Type As String, ByVal DateFrm As String, ByVal DateTo As String, ByVal DCode As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getSubmissionY]"
            .Connection = sqlConn
            .CommandTimeout = 600
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@DateFrm", DateFrm)
            .Parameters.AddWithValue("@DateTo", DateTo)
            .Parameters.AddWithValue("@DCODE", DCode)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getSubmissionYNEWDetails(ByVal Type As String, ByVal DateFrm As String, ByVal DateTo As String, ByVal DCode As String, ByVal PID As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getSubmissionYNEW]"
            .Connection = sqlConn
            .CommandTimeout = 600
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@DateFrm", DateFrm)
            .Parameters.AddWithValue("@DateTo", DateTo)
            .Parameters.AddWithValue("@DCODE", DCode)
            .Parameters.AddWithValue("@PID", PID)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getSubmissionYRDetails(ByVal Type As String, ByVal DateFrm As String, ByVal DateTo As String, ByVal DCode As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getSubmissionYR]"
            .Connection = sqlConn
            .CommandTimeout = 600
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@DateFrm", DateFrm)
            .Parameters.AddWithValue("@DateTo", DateTo)
            .Parameters.AddWithValue("@DCODE", DCode)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function UpdateSuspenseAccount(ByVal ID As String, ByVal A2TAKE As String, ByVal REFNO As String, ByVal REFDATE As String, _
                                       ByVal AMOUNT As Double, ByVal ACTIONBY As String, ByVal REMARKS As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_upSuspenseAccount]"
                .Connection = Conn
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@Action2Take", A2TAKE)
                .Parameters.AddWithValue("@REFNo", REFNO)
                If REFDATE = "" Then
                    .Parameters.AddWithValue("@REFDATE", DBNull.Value)
                Else
                    .Parameters.AddWithValue("@REFDATE", REFDATE)
                End If
                .Parameters.AddWithValue("@Amount", AMOUNT)
                .Parameters.AddWithValue("@ActionBy", ACTIONBY)
                .Parameters.AddWithValue("@REMARKS", REMARKS)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function getOGdetails(ByVal id As String, ByVal conn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim asp As SqlDataAdapter
        Dim cmd As New SqlCommand
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getdetail]"
            .Connection = conn
            .Parameters.AddWithValue("@id", id)
            asp = New SqlDataAdapter(cmd)
            asp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function UpdateShortFalls(ByVal IC As String, ByVal A2TAKE As String, ByVal NoK As String, ByVal NOKPL As String, _
                                     ByVal DM As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_upShortfalls]"
                .Connection = Conn
                .Parameters.AddWithValue("@IC", IC)
                .Parameters.AddWithValue("@Action2Take", A2TAKE)
                .Parameters.AddWithValue("@NOK", NoK)
                .Parameters.AddWithValue("@NOKPL", NOKPL)
                .Parameters.AddWithValue("@DM", DM)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function spUpdate(ByVal TYPE As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, _
                             ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_update]"
                .Connection = Conn
                .CommandTimeout = 90000
                .Parameters.AddWithValue("@TYPE", TYPE)
                .Parameters.AddWithValue("@P1", P1)
                .Parameters.AddWithValue("@P2", P2)
                .Parameters.AddWithValue("@P3", P3)
                .Parameters.AddWithValue("@P4", P4)
                .Parameters.AddWithValue("@P5", P5)
                .Parameters.AddWithValue("@P6", P6)
                .Parameters.AddWithValue("@P7", P7)
                .Parameters.AddWithValue("@P8", P8)
                .Parameters.AddWithValue("@P9", P9)
                .Parameters.AddWithValue("@P10", P10)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function UpdateEDATE(ByVal ID As String, ByVal EDATE As String, ByVal FILENO As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_upEffectiveDate]"
                .Connection = Conn
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@EDATE", EDATE)
                .Parameters.AddWithValue("@FILENO", FILENO)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function UpdateBLANK(ByVal TYPE As String, ByVal UTYPE As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, _
                                ByVal P4 As String, ByVal P5 As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_UPBLANK]"
                .Connection = Conn
                .Parameters.AddWithValue("@TYPE", TYPE)
                .Parameters.AddWithValue("@UTYPE", UTYPE)
                .Parameters.AddWithValue("@P1", P1)
                .Parameters.AddWithValue("@P2", P2)
                .Parameters.AddWithValue("@P3", P3)
                .Parameters.AddWithValue("@P4", P4)
                .Parameters.AddWithValue("@P5", P5)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function upAddProposer(ByVal IC As String, ByVal ADD1 As String, ByVal ADD2 As String, ByVal TOWN As String, ByVal STATE As String, _
                               ByVal POS As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_upAddProposer]"
                .Connection = Conn
                .Parameters.AddWithValue("@IC", IC)
                .Parameters.AddWithValue("@ADD1", ADD1)
                .Parameters.AddWithValue("@ADD2", ADD2)
                .Parameters.AddWithValue("@TOWN", TOWN)
                .Parameters.AddWithValue("@STATE", STATE)
                .Parameters.AddWithValue("@POS", POS)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function InsEndorsement(ByVal MEMBER_ID As String, ByVal MEMBER_POLICY_ID As String, ByVal LOG_DATE As String, ByVal ENDORSEMENT_TYPE As String, _
                                    ByVal ENDORSEMENT_DETAILS As String, ByVal ADD1 As String, ByVal ADD2 As String, ByVal TOWN As String, _
                                    ByVal POSTCODE As String, ByVal STATE As String, ByVal REQUEST_DATE As String, ByVal REMARKS As String, _
                                    ByVal USERNAME As String, ByVal CREATED_BY As String, ByVal EFFECTIVE_DATE As String, ByVal Conn As SqlConnection) As String

        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsEndorsement]"
                .Connection = Conn
                .Parameters.AddWithValue("@MEMBER_ID", MEMBER_ID)
                .Parameters.AddWithValue("@POLICY_ID", MEMBER_POLICY_ID)
                .Parameters.AddWithValue("@LOG_DATE", LOG_DATE)
                .Parameters.AddWithValue("@ENDORSEMENT_TYPE", ENDORSEMENT_TYPE)
                .Parameters.AddWithValue("@ENDORSEMENT_DETAILS", ENDORSEMENT_DETAILS)
                .Parameters.AddWithValue("@ADD1", ADD1)
                .Parameters.AddWithValue("@ADD2", ADD2)
                .Parameters.AddWithValue("@TOWN", TOWN)
                .Parameters.AddWithValue("@POSTCODE", POSTCODE)
                .Parameters.AddWithValue("@STATE", STATE)
                .Parameters.AddWithValue("@REQUEST_DATE", REQUEST_DATE)
                .Parameters.AddWithValue("@REMARKS", REMARKS)
                .Parameters.AddWithValue("@USERNAME", USERNAME)
                .Parameters.AddWithValue("@CREATED_BY", CREATED_BY)
                .Parameters.AddWithValue("@EFFECTIVE_DATE", EFFECTIVE_DATE)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function UpdateDependentsDetails(ByVal TYPE As String, ByVal ID As String, ByVal CLIENTID As String, ByVal TITLE As String, ByVal IC_NEW As String, ByVal FULL_NAME As String, _
                                            ByVal DOB As String, ByVal IC_OLD As String, ByVal ARMFORCE_ID As String, ByVal RACE As String, _
                                            ByVal MARITAL_STATUS As String, ByVal SEX As String, ByVal RELATIONSHIP As String, ByVal HEIGHT As String, ByVal WEIGHT As String, _
                                            ByVal OCCUPATION As String, ByVal DEPARTMENT As String, ByVal EFFECTIVE_DATE As String, ByVal CREATED_BY As String, _
                                            ByVal Conn As SqlConnection) As String


        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_UpDependant]"
                .Connection = Conn
                .Parameters.AddWithValue("@TYPE", TYPE)
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@CLIENTID", CLIENTID)
                .Parameters.AddWithValue("@TITLE", TITLE)
                .Parameters.AddWithValue("@IC_NEW", IC_NEW)
                .Parameters.AddWithValue("@FULL_NAME", FULL_NAME)
                .Parameters.AddWithValue("@DOB", DOB)
                .Parameters.AddWithValue("@IC_OLD", IC_OLD)
                .Parameters.AddWithValue("@ARMFORCE_ID", ARMFORCE_ID)
                .Parameters.AddWithValue("@RACE", RACE)
                .Parameters.AddWithValue("@MARITAL_STATUS", MARITAL_STATUS)
                .Parameters.AddWithValue("@SEX", SEX)
                .Parameters.AddWithValue("@RELATIONSHIP", RELATIONSHIP)
                .Parameters.AddWithValue("@HEIGHT", HEIGHT)
                .Parameters.AddWithValue("@WEIGHT", WEIGHT)
                .Parameters.AddWithValue("@OCCUPATION", OCCUPATION)
                .Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT)
                .Parameters.AddWithValue("@EFFECTIVE_DATE", EFFECTIVE_DATE)
                .Parameters.AddWithValue("@CREATED_BY", CREATED_BY)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function INSUPSNOMINEEDETAILS(ByVal TYPE As String, ByVal ID As String, ByVal MEMBER_POLICY_ID As String, ByVal TITLE As String, _
                                            ByVal IC_NEW As String, ByVal FULL_NAME As String, ByVal DOB As String, ByVal RELATIONSHIP As String, _
                                            ByVal ADD1 As String, ByVal ADD2 As String, ByVal ADD3 As String, ByVal ADD4 As String, ByVal TOWN As String, ByVal STATE As String, ByVal POSCODE As String, ByVal SHARE As String, ByVal EFFECTIVE_DATE As String, ByVal CREATED_BY As String, _
                                            ByVal Conn As SqlConnection) As String


        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsUpsNominee]"
                .Connection = Conn
                .Parameters.AddWithValue("@TYPE", TYPE)
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@MEMBER_POLICY_ID", MEMBER_POLICY_ID)
                .Parameters.AddWithValue("@TITLE", TITLE)
                .Parameters.AddWithValue("@IC_NEW", IC_NEW)
                .Parameters.AddWithValue("@FULL_NAME", FULL_NAME)
                .Parameters.AddWithValue("@DOB", DOB)
                .Parameters.AddWithValue("@RELATIONSHIP", RELATIONSHIP)
                .Parameters.AddWithValue("@ADD1", ADD1)
                .Parameters.AddWithValue("@ADD2", ADD2)
                .Parameters.AddWithValue("@ADD3", ADD3)
                .Parameters.AddWithValue("@ADD4", ADD4)
                .Parameters.AddWithValue("@TOWN", TOWN)
                .Parameters.AddWithValue("@STATE", STATE)
                .Parameters.AddWithValue("@POSCODE", POSCODE)
                .Parameters.AddWithValue("@SHARE", SHARE)
                .Parameters.AddWithValue("@EFFECTIVE_DATE", EFFECTIVE_DATE)
                .Parameters.AddWithValue("@CREATED_BY", CREATED_BY)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function Delete(ByVal type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal Conn As SqlConnection) As String
        Dim sRes As String = ""
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_DELETE]"
            .Connection = Conn
            .Parameters.AddWithValue("@TYPE", type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sRes = .ExecuteScalar
        End With
        Return sRes
    End Function
    Public Function INSUPSEC(ByVal TYPE As String, ByVal ID As String, ByVal MEMBER_POLICY_ID As String, ByVal EC_CODE As String, _
                             ByVal EC_DESC As String, ByVal EC_EDATE As String, ByVal APPLYTO As String, ByVal CREATED_BY As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsUpEC]"
                .Connection = Conn
                .Parameters.AddWithValue("@TYPE", TYPE)
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@POLICY_ID", MEMBER_POLICY_ID)
                .Parameters.AddWithValue("@EC_CODE", EC_CODE)
                .Parameters.AddWithValue("@EC_DESC", EC_DESC)
                .Parameters.AddWithValue("@EC_EDATE", EC_EDATE)
                .Parameters.AddWithValue("@EC_APPLYTO", APPLYTO)
                .Parameters.AddWithValue("@CREATED_BY", CREATED_BY)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function fsDate() As String
        Dim sMonth, srMonth, sDay, sYear, sDate As String
        sDay = Now().Day().ToString()
        sMonth = Now().Month().ToString()
        sYear = Now().Year().ToString()
        Select Case sMonth
            Case "01", "1"
                srMonth = "Januari"
            Case "02", "2"
                srMonth = "Februari"
            Case "03", "3"
                srMonth = "Mac"
            Case "04", "4"
                srMonth = "April"
            Case "05", "5"
                srMonth = "Mei"
            Case "06", "6"
                srMonth = "Jun"
            Case "07", "7"
                srMonth = "Julai"
            Case "08", "8"
                srMonth = "Ogos"
            Case "09", "9"
                srMonth = "September"
            Case "10"
                srMonth = "Oktober"
            Case "11"
                srMonth = "November"
            Case "12"
                srMonth = "Disember"
        End Select
        sDate = sDay & " " & srMonth & " " & sYear
        Return sDate
    End Function
    Public Function UpdateMemberDetails(ByVal Type As String, ByVal id As String, ByVal CLIENTID As String, ByVal Title As String, ByVal fullname As String, ByVal dob As String, _
                                        ByVal ic As String, ByVal race As String, ByVal mstatus As String, ByVal sex As String, ByVal Add1 As String, _
                                        ByVal Add2 As String, ByVal Add3 As String, ByVal Add4 As String, ByVal Town As String, ByVal State As String, ByVal Poscode As String, _
                                        ByVal Bank_Name As String, ByVal Bank_Ac As String, ByVal phonehse As String, ByVal phonemobile As String, _
                                        ByVal phoneoff As String, ByVal email As String, ByVal height As String, ByVal weight As String, ByVal occupation As String, ByVal department As String, ByVal by As String, ByVal Conn As SqlConnection) As String

        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_upMemberDetails]"
                .Connection = Conn
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@ID", id)
                .Parameters.AddWithValue("@CLIENTID", CLIENTID)
                .Parameters.AddWithValue("@Title", Title)
                .Parameters.AddWithValue("@FullName", fullname)
                .Parameters.AddWithValue("@DOB", dob)
                .Parameters.AddWithValue("@ic", ic)
                .Parameters.AddWithValue("@race", race)
                .Parameters.AddWithValue("@mstatus", mstatus)
                .Parameters.AddWithValue("@sex", sex)
                .Parameters.AddWithValue("@add1", Add1)
                .Parameters.AddWithValue("@add2", Add2)
                .Parameters.AddWithValue("@add3", Add3)
                .Parameters.AddWithValue("@add4", Add4)
                .Parameters.AddWithValue("@town", Town)
                .Parameters.AddWithValue("@state", State)
                .Parameters.AddWithValue("@Bank_Name", Bank_Name)
                .Parameters.AddWithValue("@Bank_Ac", Bank_Ac)
                .Parameters.AddWithValue("@poscode", Poscode)
                .Parameters.AddWithValue("@phonehse", phonehse)
                .Parameters.AddWithValue("@phonemobile", phonemobile)
                .Parameters.AddWithValue("@phoneoff", phoneoff)
                .Parameters.AddWithValue("@email", email)
                .Parameters.AddWithValue("@height", height)
                .Parameters.AddWithValue("@weight", weight)
                .Parameters.AddWithValue("@occupation", occupation)
                .Parameters.AddWithValue("@department", department)
                .Parameters.AddWithValue("@by", by)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function InsUpsPremiumHistory(ByVal Type As String, ByVal id As String, ByVal mp_id As String, ByVal sdate As String, ByVal edate As String, _
                                        ByVal premium As String, ByVal status As String, ByVal remarks As String, ByVal created_by As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsUpPremiumHistory]"
                .Connection = Conn
                .CommandTimeout = 900000
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@ID", id)
                .Parameters.AddWithValue("@MP_ID", mp_id)
                If sdate = "" Then
                    .Parameters.AddWithValue("@sdate", DBNull.Value)
                Else
                    .Parameters.AddWithValue("@sdate", sdate)
                End If
                If edate = "" Then
                    .Parameters.AddWithValue("@edate", DBNull.Value)
                Else
                    .Parameters.AddWithValue("@edate", edate)
                End If

                .Parameters.AddWithValue("@premium", premium)
                .Parameters.AddWithValue("@status", status)
                .Parameters.AddWithValue("@remarks", remarks)
                .Parameters.AddWithValue("@created_by", created_by)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function getLetters(ByVal TYPE As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, _
                                 ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal Conn As SqlConnection) As DataSet
        Dim ds As New DataSet
        Dim sqlDa As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        Try
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_getLetters]"
                .Connection = Conn
                .Parameters.AddWithValue("@Type", TYPE)
                .Parameters.AddWithValue("@P1", P1)
                .Parameters.AddWithValue("@P2", P2)
                .Parameters.AddWithValue("@P3", P3)
                .Parameters.AddWithValue("@P4", P4)
                .Parameters.AddWithValue("@P5", P5)
                .Parameters.AddWithValue("@P6", P6)
                .Parameters.AddWithValue("@P7", P7)
                .Parameters.AddWithValue("@P8", P8)
                .Parameters.AddWithValue("@P9", P9)
                .Parameters.AddWithValue("@P10", P10)
                sqlDa = New SqlDataAdapter(sqlCmd)
                sqlDa.Fill(ds)
                Return ds
            End With
        Catch ex As Exception
            Return ds
        End Try
    End Function
    Public Function getPrint(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, _
                                ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_Print]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getMailDetails(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getMailDetails]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Sub SendEmail(ByVal sSubject As String, ByVal sHeader As String, ByVal sBody As String, ByVal sFooter As String, ByVal sTo As String, ByVal sCC As String, ByVal DisplayName As String)
        Try
            Dim SmtpServer As New SmtpClient()
            SmtpServer.Credentials = New Net.NetworkCredential("admin@medicare.org.my", "admin123+")
            SmtpServer.Port = 587
            SmtpServer.Host = "mail.medicare.org.my"
            SmtpServer.EnableSsl = False
            Dim omail As New MailMessage()
            omail.From = New MailAddress("admin@medicare.org.my", DisplayName, System.Text.Encoding.UTF8)
            omail.Subject = sSubject
            omail.Body = sHeader & vbCrLf & vbCrLf & vbCrLf & sBody & vbCrLf & vbCrLf & vbCrLf & sFooter
            omail.To.Add(sTo)
            omail.Bcc.Add("sridhar.jakke@gmail.com")
            SmtpServer.Send(omail)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Function getDetails_I(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_I]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function InsUpsFollowup(ByVal Type As String, ByVal id As String, ByVal pid As String, ByVal comments As String, ByVal RDATE As String, ByVal cby As String, ByVal can_contact As String, ByVal can_contact_remarks As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsUpFollowup]"
                .Connection = Conn
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@ID", id)
                .Parameters.AddWithValue("@PID", pid)
                .Parameters.AddWithValue("@Comments", comments)
                .Parameters.Add("@RDATE", SqlDbType.DateTime)
                If IsNothing(RDATE) Then
                    .Parameters("@RDATE").Value = DBNull.Value
                Else
                    .Parameters("@RDATE").Value = RDATE
                End If
                .Parameters.AddWithValue("@cby", cby)
                .Parameters.AddWithValue("@can_contact", can_contact)
                .Parameters.AddWithValue("@can_contact_remarks", can_contact_remarks)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function getFDB(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getFDB]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fPremium(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_Premium]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function InsUpsPremium(ByVal Type As String, ByVal id As String, ByVal refid As String, ByVal batchno As String, ByVal tran_type As String, _
                                  ByVal dob As String, ByVal age As String, ByVal cpremium As String, ByVal rpremium As String, ByVal status As String, _
                                  ByVal revised_status As String, ByVal remarks As String, ByVal verify_remarks As String, ByVal created_by As String, ByVal Conn As SqlConnection) As String

        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsUpsPremium]"
                .Connection = Conn
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@ID", id)
                .Parameters.AddWithValue("@REF_ID", refid)
                .Parameters.AddWithValue("@batchno", batchno)
                .Parameters.AddWithValue("@tran_type", tran_type)
                .Parameters.AddWithValue("@dob", dob)
                .Parameters.AddWithValue("@age", age)
                .Parameters.AddWithValue("@cpremium", cpremium)
                .Parameters.AddWithValue("@rpremium", rpremium)
                .Parameters.AddWithValue("@status", status)
                .Parameters.AddWithValue("@revised_status", revised_status)
                .Parameters.AddWithValue("@remarks", remarks)
                .Parameters.AddWithValue("@verify_remarks", verify_remarks)
                .Parameters.AddWithValue("@created_by", created_by)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function Check(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        Try
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_Check]"
                .Connection = sqlConn
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@P1", P1)
                .Parameters.AddWithValue("@P2", P2)
                .Parameters.AddWithValue("@P3", P3)
                .Parameters.AddWithValue("@P4", P4)
                .Parameters.AddWithValue("@P5", P5)
                .Parameters.AddWithValue("@P6", P6)
                .Parameters.AddWithValue("@P7", P7)
                .Parameters.AddWithValue("@P8", P8)
                .Parameters.AddWithValue("@P9", P9)
                .Parameters.AddWithValue("@P10", P10)
                sdp = New SqlDataAdapter(sqlCmd)
                sdp.Fill(dt)
                Return dt
            End With
        Catch ex As Exception
            Return dt
        End Try
    End Function
    Public Function fPI(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_PI]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fPD(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_PD]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fSMS(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_SMS]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fPremiumProcess(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_PremiumProcess]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fINPremiumProcess(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As String
        Dim sRes As String
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_PremiumProcess]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sRes = .ExecuteScalar
        End With
        Return sRes
    End Function
    Public Function fShortFalls(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_ShortFalls]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
   
    Public Function fINShortFall(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As String
        Dim sRes As String
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_ShortFalls]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sRes = .ExecuteScalar
        End With
        Return sRes
    End Function
    Public Function fNonPayment(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_NonPayment]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fINNonPayment(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As String
        Dim sRes As String
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_NonPayment]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sRes = .ExecuteScalar
        End With
        Return sRes
    End Function
    Public Function getDetails_IFUP(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataSet
        Dim ds As New DataSet
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_I]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(ds)
            Return ds
        End With
    End Function
    Public Function fYrSummary(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal P11 As String, ByVal P12 As String, ByVal P13 As String, ByVal P14 As String, ByVal P15 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getYrSummary]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            .Parameters.AddWithValue("@P11", P11)
            .Parameters.AddWithValue("@P12", P12)
            .Parameters.AddWithValue("@P13", P13)
            .Parameters.AddWithValue("@P14", P14)
            .Parameters.AddWithValue("@P15", P15)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fYRFS(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        Try
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_YRFS]"
                .Connection = sqlConn
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@P1", P1)
                .Parameters.AddWithValue("@P2", P2)
                .Parameters.AddWithValue("@P3", P3)
                .Parameters.AddWithValue("@P4", P4)
                .Parameters.AddWithValue("@P5", P5)
                .Parameters.AddWithValue("@P6", P6)
                .Parameters.AddWithValue("@P7", P7)
                .Parameters.AddWithValue("@P8", P8)
                .Parameters.AddWithValue("@P9", P9)
                .Parameters.AddWithValue("@P10", P10)
                sdp = New SqlDataAdapter(sqlCmd)
                sdp.Fill(dt)
                Return dt
            End With
        Catch ex As Exception
            Return dt
        End Try
    End Function
    Public Function fIUDocumentCheckList(ByVal Type As String, ByVal ID As String, ByVal PROPOSER_ID As String, ByVal MEMBER_POLICY_ID As String, ByVal REF_TYPE As String, ByVal REF_ID As String, ByVal DOC_TYPE As String, ByVal DOC_EXT As String, ByVal DOC_NAME As String, ByVal DOC_DATA As Byte(), ByVal REMARKS As String, ByVal CREATED_BY As String, ByVal sqlConn As SqlConnection) As String

        Dim sRes As String
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_IUDocumentChecklist]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@ID", ID)
            .Parameters.AddWithValue("@PROPOSER_ID", PROPOSER_ID)
            .Parameters.AddWithValue("@MEMBER_POLICY_ID", MEMBER_POLICY_ID)
            .Parameters.AddWithValue("@REF_TYPE", REF_TYPE)
            .Parameters.AddWithValue("@REF_ID", REF_ID)
            .Parameters.AddWithValue("@DOC_TYPE", DOC_TYPE)
            .Parameters.AddWithValue("@DOC_EXT", DOC_EXT)
            .Parameters.AddWithValue("@DOC_NAME", DOC_NAME)
            .Parameters.AddWithValue("@DOC_DATA", DOC_DATA)
            .Parameters.AddWithValue("@REMARKS", REMARKS)
            .Parameters.AddWithValue("@CREATED_BY", CREATED_BY)
            sRes = .ExecuteScalar
        End With
        Return sRes
    End Function
    Public Function rYRSFR(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        Try
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_getYRShortfallDetails]"
                .Connection = sqlConn
                .CommandTimeout = 600000
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@P1", P1)
                .Parameters.AddWithValue("@P2", P2)
                .Parameters.AddWithValue("@P3", P3)
                .Parameters.AddWithValue("@P4", P4)
                .Parameters.AddWithValue("@P5", P5)
                .Parameters.AddWithValue("@P6", P6)
                .Parameters.AddWithValue("@P7", P7)
                .Parameters.AddWithValue("@P8", P8)
                .Parameters.AddWithValue("@P9", P9)
                .Parameters.AddWithValue("@P10", P10)
                sdp = New SqlDataAdapter(sqlCmd)
                sdp.Fill(dt)
                Return dt
            End With
        Catch ex As Exception
            Return dt
        End Try
    End Function
    Public Function fPremiumSummaryReports(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        Try
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_getPremiumSummaryReports]"
                .Connection = sqlConn
                .CommandTimeout = 600000
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@P1", P1)
                .Parameters.AddWithValue("@P2", P2)
                .Parameters.AddWithValue("@P3", P3)
                .Parameters.AddWithValue("@P4", P4)
                .Parameters.AddWithValue("@P5", P5)
                .Parameters.AddWithValue("@P6", P6)
                .Parameters.AddWithValue("@P7", P7)
                .Parameters.AddWithValue("@P8", P8)
                .Parameters.AddWithValue("@P9", P9)
                .Parameters.AddWithValue("@P10", P10)
                sdp = New SqlDataAdapter(sqlCmd)
                sdp.Fill(dt)
                Return dt
            End With
        Catch ex As Exception
            Return dt
        End Try
    End Function
    Public Function fPremiumSummaryReportsDetails(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        Try
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_getPremiumSummaryReportsDetails]"
                .Connection = sqlConn
                .CommandTimeout = 600000
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@P1", P1)
                .Parameters.AddWithValue("@P2", P2)
                .Parameters.AddWithValue("@P3", P3)
                .Parameters.AddWithValue("@P4", P4)
                .Parameters.AddWithValue("@P5", P5)
                .Parameters.AddWithValue("@P6", P6)
                .Parameters.AddWithValue("@P7", P7)
                .Parameters.AddWithValue("@P8", P8)
                .Parameters.AddWithValue("@P9", P9)
                .Parameters.AddWithValue("@P10", P10)
                sdp = New SqlDataAdapter(sqlCmd)
                sdp.Fill(dt)
                Return dt
            End With
        Catch ex As Exception
            Return dt
        End Try
    End Function
    Public Function fPolicyNoDetails(ByVal policyid As String, ByVal policyno As String, ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, _
                                     ByVal p4 As String, ByVal p5 As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_IUPolicyNoDetails]"
                .Connection = Conn
                .Parameters.AddWithValue("@policyid", policyid)
                .Parameters.AddWithValue("@policyno", policyno)
                .Parameters.AddWithValue("@P1", p1)
                .Parameters.AddWithValue("@P2", p2)
                .Parameters.AddWithValue("@P3", p3)
                .Parameters.AddWithValue("@P4", p4)
                .Parameters.AddWithValue("@P5", p5)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function fR13M(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getR13M]"
            .Connection = sqlConn
            .CommandTimeout = 800000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fgetRevisePremiumDetails(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getRevisePremiumDetails]"
            .Connection = sqlConn
            .CommandTimeout = 800000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fRevisePremium(ByVal DCODE As String, ByVal PLANCODE As String, ByVal PLANTYPE As String, ByVal CPREMIUM As String, ByVal RPREMIUM As String, _
                                     ByVal EDATE As String, ByVal REMARKS As String, ByVal REVISEDBY As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_RevisePremium]"
                .Connection = Conn
                .CommandTimeout = 800000
                .Parameters.AddWithValue("@DCODE", DCODE)
                .Parameters.AddWithValue("@PLANCODE", PLANCODE)
                .Parameters.AddWithValue("@PLANTYPE", PLANTYPE)
                .Parameters.AddWithValue("@CPREMIUM", CPREMIUM)
                .Parameters.AddWithValue("@RPREMIUM", RPREMIUM)
                .Parameters.AddWithValue("@EDATE", EDATE)
                .Parameters.AddWithValue("@REMARKS", REMARKS)
                .Parameters.AddWithValue("@REVISEDBY", REVISEDBY)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function fgetDetailsII(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetailsII]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fValidateClientID(ByVal TYPE As String, ByVal CLIENTID As String, ByVal FUNIT As String, ByVal NAME As String, ByVal IC As String, ByVal CERT As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, _
                             ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_chkClientID]"
                .Connection = Conn
                .Parameters.AddWithValue("@TYPE", TYPE)
                .Parameters.AddWithValue("@CLIENTID", CLIENTID)
                .Parameters.AddWithValue("@FUNIT", FUNIT)
                .Parameters.AddWithValue("@NAME", NAME)
                .Parameters.AddWithValue("@IC", IC)
                .Parameters.AddWithValue("@CERT", CERT)
                .Parameters.AddWithValue("@P1", P1)
                .Parameters.AddWithValue("@P2", P2)
                .Parameters.AddWithValue("@P3", P3)
                .Parameters.AddWithValue("@P4", P4)
                .Parameters.AddWithValue("@P5", P5)
                .Parameters.AddWithValue("@P6", P6)
                .Parameters.AddWithValue("@P7", P7)
                .Parameters.AddWithValue("@P8", P8)
                .Parameters.AddWithValue("@P9", P9)
                .Parameters.AddWithValue("@P10", P10)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function fINUPPREMIUMREQUEST413M(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As String
        Dim sRes As String
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[SP_INSUPPREMIUM_REQUEST413M]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sRes = .ExecuteScalar
        End With
        Return sRes
    End Function
    Public Function f13MR(ByVal RefType As String, ByVal frmDCode As String, ByVal toDcode As String, ByVal syear As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_get13MR]"
            .Connection = sqlConn
            .CommandTimeout = 800000
            .Parameters.AddWithValue("@RefType", RefType)
            .Parameters.AddWithValue("@frmdCode", frmDCode)
            .Parameters.AddWithValue("@toDcode", toDcode)
            .Parameters.AddWithValue("@year", syear)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fgetIPPD(ByVal pYear As String, ByVal pMonth As String, ByVal frmDCode As String, ByVal toDcode As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getInsurerPremiumPaymentDetails]"
            .Connection = sqlConn
            .CommandTimeout = 800000
            .Parameters.AddWithValue("@pYear", pYear)
            .Parameters.AddWithValue("@pMonth", pMonth)
            .Parameters.AddWithValue("@frmdCode", frmDCode)
            .Parameters.AddWithValue("@toDcode", toDcode)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fgetPolicyPremium(ByVal PID As String, ByVal sDate As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getPolicyPremium]"
            .Connection = sqlConn
            .CommandTimeout = 800000
            .Parameters.AddWithValue("@PID", PID)
            .Parameters.AddWithValue("@sDate", sDate)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function InsUpsPolicyPremiumHistory(ByVal Type As String, ByVal pid As String, ByVal premium As String, ByVal sdate As String, ByVal edate As String, _
                                          ByVal remarks As String, ByVal by As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InUpPolicyPremiumHistory]"
                .Connection = Conn
                .CommandTimeout = 900000
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@PID", pid)
                .Parameters.AddWithValue("@premium", premium)
                If sdate = "" Then
                    .Parameters.AddWithValue("@sdate", DBNull.Value)
                Else
                    .Parameters.AddWithValue("@sdate", sdate)
                End If
                If edate = "" Then
                    .Parameters.AddWithValue("@edate", DBNull.Value)
                Else
                    .Parameters.AddWithValue("@edate", edate)
                End If
                .Parameters.AddWithValue("@remarks", remarks)
                .Parameters.AddWithValue("@by", by)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function getDetails_II(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_II]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getDetails_III(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_III]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getEndorsementSubmission(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getEndorsSubmission]"
            .Connection = sqlConn
            .CommandTimeout = 60000
            .Parameters.AddWithValue("@type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fPremiumIncrese(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_PremiumIncrese]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fMEMBERID(ByVal TYPE As String, ByVal CLIENTID As String, ByVal FUNIT As String, ByVal NAME As String, ByVal IC As String, ByVal CERT As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, _
                             ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_MEMBERID]"
                .Connection = Conn
                .Parameters.AddWithValue("@TYPE", TYPE)
                .Parameters.AddWithValue("@CLIENTID", CLIENTID)
                .Parameters.AddWithValue("@FUNIT", FUNIT)
                .Parameters.AddWithValue("@NAME", NAME)
                .Parameters.AddWithValue("@IC", IC)
                .Parameters.AddWithValue("@CERT", CERT)
                .Parameters.AddWithValue("@P1", P1)
                .Parameters.AddWithValue("@P2", P2)
                .Parameters.AddWithValue("@P3", P3)
                .Parameters.AddWithValue("@P4", P4)
                .Parameters.AddWithValue("@P5", P5)
                .Parameters.AddWithValue("@P6", P6)
                .Parameters.AddWithValue("@P7", P7)
                .Parameters.AddWithValue("@P8", P8)
                .Parameters.AddWithValue("@P9", P9)
                .Parameters.AddWithValue("@P10", P10)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function getDetails_IV(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_IV]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getDsDetails_V(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataSet
        Dim ds As New DataSet
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_V]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(ds)
            Return ds
        End With
    End Function
    Public Function getDetails_V(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_V]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getDetails_VI(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_VI]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getDsDetails_VI(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataSet
        Dim ds As New DataSet
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_VI]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(ds)
            Return ds
        End With
    End Function
    Public Function IUCLIENTREQUEST(ByVal TYPE As String, ByVal ID As String, ByVal REFID As String, ByVal POLICY_ID As String, ByVal IC As String, ByVal FULL_NAME As String, ByVal PARTICIPANT_TYPE As String, ByVal REQUEST_DATE As String, ByVal REQUEST_TYPE As String, ByVal SUBMISSION_BATCHNO As String, ByVal SUBMISSION_DATE As String, ByVal REMARKS As String, ByVal BY As String, ByVal Conn As SqlConnection) As String
        Dim sRes As String
        Try
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsUpsClientRequest]"
                .Connection = Conn
                .Parameters.AddWithValue("@TYPE", TYPE)
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@REFID", REFID)
                .Parameters.AddWithValue("@POLICY_ID", POLICY_ID)
                .Parameters.AddWithValue("@IC", IC)
                .Parameters.AddWithValue("@FULL_NAME", FULL_NAME)
                .Parameters.AddWithValue("@PARTICIPANT_TYPE", PARTICIPANT_TYPE)
                .Parameters.AddWithValue("@REQUEST_DATE", REQUEST_DATE)
                .Parameters.AddWithValue("@REQUEST_TYPE", REQUEST_TYPE)
                .Parameters.AddWithValue("@SUBMISSION_BATCHNO", SUBMISSION_BATCHNO)
                .Parameters.AddWithValue("@SUBMISSION_DATE", SUBMISSION_DATE)
                .Parameters.AddWithValue("@REMARKS", REMARKS)

                .Parameters.AddWithValue("@BY", BY)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            sRes = ex.Message
            Return sRes
        End Try
    End Function
    Public Function getDetails_VII(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_VII]"
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function IUAGENTREQUEST(ByVal TYPE As String, ByVal ID As String, ByVal AGENTCODE As String, ByVal GEFORM As Integer, ByVal GECONFIRM As Integer, _
    ByVal CCFORM As Integer, ByVal CPAFORM As Integer, ByVal BIRO As Integer, ByVal NOMINATION As Integer, ByVal FLYERSCC As Integer, ByVal FLYERSCPA As Integer, ByVal BOOKLETCC As Integer, ByVal BOOKLETCPA As Integer, ByVal POSTERCC As Integer, ByVal POSTERCPA As Integer, ByVal NAMECARD As Integer, ByVal BUNTINGCC As Integer, ByVal BUNTINGCPA As Integer, ByVal REQUESTDATE As String, ByVal REQUESTBY As String, ByVal VERIFIEDDATE As String, ByVal VERIFIEDBY As String, ByVal APPROVEDON As String, ByVal APPROVEDBY As String, ByVal POSTEDON As String, ByVal POSTEDBY As String, ByVal REMARKS As String, ByVal CREATEDBY As String, ByVal Conn As SqlConnection) As String
        Dim sRes As String
        Try
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsUpAGENTRequest]"
                .Connection = Conn
                .Parameters.AddWithValue("@TYPE", TYPE)
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@AGENTCODE", AGENTCODE)
                .Parameters.AddWithValue("@GEFORM", GEFORM)
                .Parameters.AddWithValue("@GECONFIRM", GECONFIRM)
                .Parameters.AddWithValue("@CCFORM", CCFORM)
                .Parameters.AddWithValue("@CPAFORM", CPAFORM)
                .Parameters.AddWithValue("@BIRO", BIRO)
                .Parameters.AddWithValue("@NOMINATION", NOMINATION)
                .Parameters.AddWithValue("@FLYERSCC", FLYERSCC)
                .Parameters.AddWithValue("@FLYERSCPA", FLYERSCPA)
                .Parameters.AddWithValue("@BOOKLETCC", BOOKLETCC)
                .Parameters.AddWithValue("@BOOKLETCPA", BOOKLETCPA)
                .Parameters.AddWithValue("@POSTERCC", POSTERCC)
                .Parameters.AddWithValue("@POSTERCPA", POSTERCPA)
                .Parameters.AddWithValue("@NAMECARD", NAMECARD)
                .Parameters.AddWithValue("@BUNTINGCC", BUNTINGCC)
                .Parameters.AddWithValue("@BUNTINGCPA", BUNTINGCPA)
                .Parameters.AddWithValue("@REQUESTDATE", REQUESTDATE)
                .Parameters.AddWithValue("@REQUESTBY", REQUESTBY)
                .Parameters.AddWithValue("@VERIFIEDDATE", VERIFIEDDATE)
                .Parameters.AddWithValue("@VERIFIEDBY", VERIFIEDBY)
                .Parameters.AddWithValue("@APPROVEDON", APPROVEDON)
                .Parameters.AddWithValue("@APPROVEDBY", APPROVEDBY)
                .Parameters.AddWithValue("@POSTEDON", POSTEDON)
                .Parameters.AddWithValue("@POSTEDBY", POSTEDBY)
                .Parameters.AddWithValue("@REMARKS", REMARKS)
                .Parameters.AddWithValue("@CREATEDBY", CREATEDBY)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            sRes = ex.Message
            Return sRes
        End Try
    End Function
    Public Function getDSDetails_VII(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataSet
        Dim ds As New DataSet
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_VII]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(ds)
            Return ds
        End With
    End Function
    Public Function getDsDetails_VIII(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataSet
        Dim ds As New DataSet
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_VIII]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(ds)
            Return ds
        End With
    End Function
    Public Function getDetails_VIII(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_VIII]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function fInUpSFNONPFUP(ByVal TYPE As String, ByVal ID As String, ByVal REFID As String, ByVal TRANSTYPE As String, ByVal PCODE As String, ByVal PTYPE As String, _
                                    ByVal FNO As String, ByVal NONPAYMENT As String, ByVal TOTSHORT As String, ByVal TOTSHORT_NR As String, ByVal TOTSHORT_R As String, _
                                    ByVal TOTSHORT_RECOVER As String, ByVal TOT_BAL As String, ByVal STATUS As String, ByVal LAST_COMMENTS As String, ByVal ASSIGN_TO As String, ByVal BY As String, ByVal Conn As SqlConnection) As String
        Try
            Dim sRes As String
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_inupSFNONPFUP]"
                .Connection = Conn
                .CommandTimeout = 90000

                .Parameters.AddWithValue("@TYPE", TYPE)
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@REFID", REFID)
                .Parameters.AddWithValue("@TRANSTYPE", TRANSTYPE)
                .Parameters.AddWithValue("@PCODE", PCODE)
                .Parameters.AddWithValue("@PTYPE", PTYPE)
                .Parameters.AddWithValue("@FNO", FNO)
                .Parameters.AddWithValue("@NON_PAYMENT", NONPAYMENT)
                .Parameters.AddWithValue("@TOT_SHORT", TOTSHORT)
                .Parameters.AddWithValue("@TOT_SHORT_NR", TOTSHORT_NR)
                .Parameters.AddWithValue("@TOT_SHORT_R", TOTSHORT_R)
                .Parameters.AddWithValue("@TOT_SHORT_RECOVER", TOTSHORT_RECOVER)
                .Parameters.AddWithValue("@TOT_BAL", TOT_BAL)
                .Parameters.AddWithValue("@STATUS", STATUS)
                .Parameters.AddWithValue("@LAST_COMMENTS", LAST_COMMENTS)
                .Parameters.AddWithValue("@ASSIGN_TO", ASSIGN_TO)
                .Parameters.AddWithValue("@BY", BY)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function getDetails_IX(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_IX]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(dt)
            Return dt
        End With
    End Function
    Public Function getDsDetails_IX(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataSet
        Dim ds As New DataSet
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_getDetails_IX]"
            .Connection = sqlConn
            .CommandTimeout = 600000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(ds)
            Return ds
        End With
    End Function
End Class



