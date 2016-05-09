Imports System.Data.SqlClient
Public Class clsimdb
    Public Function InsPolicyHolderDetails(ByVal type As String, ByVal ID As String, ByVal CLIENTID As String, ByVal IC As String, ByVal Full_Name As String, _
                                              ByVal NEW_NAME As String, ByVal DOB As String, ByVal Add1 As String, ByVal Add2 As String, ByVal Town As String, _
                                              ByVal State As String, ByVal postcode As String, ByVal sex As String, ByVal ContactNo As String, _
                                              ByVal MobileNo As String, ByVal Created_By As String, ByVal Conn As SqlConnection) As String

        Dim sRes As String
        Try
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsUpsPolicyHolderDetails]"

                .Connection = Conn
                .Parameters.AddWithValue("@Type", type)
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@CLIENTID", CLIENTID)
                .Parameters.AddWithValue("@IC", IC)
                .Parameters.AddWithValue("@FULLNAME", Full_Name)
                .Parameters.AddWithValue("@NEWNAME", NEW_NAME)
                If DOB = "" Then
                    .Parameters.Add("@DOB", SqlDbType.SmallDateTime)
                    .Parameters("@DOB").Value = DBNull.Value
                Else
                    .Parameters.Add("@DOB", SqlDbType.SmallDateTime)
                    .Parameters("@DOB").Value = DOB
                End If
                .Parameters.AddWithValue("@Add1", Add1)
                .Parameters.AddWithValue("@Add2", Add2)
                .Parameters.AddWithValue("@Town", Town)
                .Parameters.AddWithValue("@State", State)
                .Parameters.AddWithValue("@Postcode", postcode)
                .Parameters.AddWithValue("@Sex", sex)
                .Parameters.AddWithValue("@ContactNo", ContactNo)
                .Parameters.AddWithValue("@MobileNo", MobileNo)
                .Parameters.AddWithValue("@Created_By", Created_By)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            sRes = ex.Message
            Return sRes
        End Try
    End Function
    Public Function InsPolicyDetails(ByVal Type As String, ByVal ID As String, ByVal P_ID As String, ByVal Com As String, ByVal P_CODE As String, _
                                     ByVal P_NO As String, ByVal NEW_P_NO As String, ByVal P_Type As String, ByVal A_Code As String, ByVal J_Dt As String, ByVal E_Dt As String, _
                                     ByVal Ex_Dt As String, ByVal TOP As String, ByVal Claim_Handle As String, ByVal E_Clause As String, _
                                     ByVal D_Clause As String, ByVal Status As String, ByVal File_No As String, ByVal Created_by As String, ByVal Conn As SqlConnection) As String

        Dim sRes As String
        Try
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsUpsPolicyDetails]"
                .Connection = Conn
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@POLICYHOLDER_ID", P_ID)
                .Parameters.AddWithValue("@COMPANY", Com)
                .Parameters.AddWithValue("@PLAN_CODE", P_CODE)
                .Parameters.AddWithValue("@POLICY_NO", P_NO)
                .Parameters.AddWithValue("@New_POLICY_NO", NEW_P_NO)
                .Parameters.AddWithValue("@POLICY_TYPE", P_Type)
                .Parameters.AddWithValue("@AGENT_CODE", A_Code)
                .Parameters.Add("@JOIN_DATE", SqlDbType.SmallDateTime)
                .Parameters("@JOIN_DATE").Value = J_Dt
                .Parameters.Add("@Effective_Date", SqlDbType.SmallDateTime)
                .Parameters("@Effective_Date").Value = E_Dt
                If Ex_Dt = "" Then
                    .Parameters.Add("@Expiry_Date", SqlDbType.SmallDateTime)
                    .Parameters("@Expiry_Date").Value = DBNull.Value
                Else
                    .Parameters.Add("@Expiry_Date", SqlDbType.SmallDateTime)
                    .Parameters("@Expiry_Date").Value = Ex_Dt
                End If
                .Parameters.AddWithValue("@Take_Over_policy", TOP)
                .Parameters.AddWithValue("@Claim_Handle_By", Claim_Handle)
                .Parameters.AddWithValue("@E_Clause", E_Clause)
                .Parameters.AddWithValue("@D_Clause", D_Clause)
                .Parameters.AddWithValue("@Status", Status)
                .Parameters.AddWithValue("@File_No", File_No)
                .Parameters.AddWithValue("@Created_By", Created_by)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            sRes = ex.Message
            Return sRes
        End Try
    End Function
    Public Function InsDepDetails(ByVal Type As String, ByVal ID As String, ByVal P_ID As String, ByVal CLIENTID As String, ByVal IC As String, ByVal FullName As String, _
                                  ByVal NEWNAME As String, ByVal DOB As String, ByVal sex As String, ByVal Relationship As String, ByVal E_Date As String, _
                                 ByVal E_Clause As String, ByVal Remarks As String, ByVal Created_By As String, ByVal Conn As SqlConnection) As String
        Dim sRes As String
        Try
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsUpsDependentDetails]"
                .Connection = Conn
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@POLICY_ID", P_ID)
                .Parameters.AddWithValue("@CLIENTID", CLIENTID)
                .Parameters.AddWithValue("@IC", IC)
                .Parameters.AddWithValue("@FULLNAME", FullName)
                .Parameters.AddWithValue("@NEWNAME", NEWNAME)
                If DOB = "" Then
                    .Parameters.Add("@DOB", SqlDbType.SmallDateTime)
                    .Parameters("@DOB").Value = DBNull.Value
                Else
                    .Parameters.Add("@DOB", SqlDbType.SmallDateTime)
                    .Parameters("@DOB").Value = DOB
                End If
                .Parameters.AddWithValue("@Sex", sex)
                .Parameters.AddWithValue("@Relationship", Relationship)
                If E_Date = "" Then
                    .Parameters.Add("@Effective_Date", SqlDbType.SmallDateTime)
                    .Parameters("@Effective_Date").Value = DBNull.Value
                Else
                    .Parameters.Add("@Effective_Date", SqlDbType.SmallDateTime)
                    .Parameters("@Effective_Date").Value = E_Date
                End If
                .Parameters.AddWithValue("@E_Clause", E_Clause)
                .Parameters.AddWithValue("@Remarks", Remarks)
                .Parameters.AddWithValue("@Created_By", Created_By)
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            sRes = ex.Message
            Return sRes
        End Try
    End Function
    Public Function fmgetDetails(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_iemdbGetDetails]"
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
    Public Function fcgetDetails(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataTable
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_iemdbGetDetails]"
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
    Public Function fIUPOLICYNODetails(ByVal Type As String, ByVal POLICYID As String, ByVal POLICYNO As String, ByVal SDATE As String, ByVal EDATE As String, ByVal Conn As SqlConnection) As String
        Dim sRes As String
        Try
            Dim sqlCmd As New SqlCommand
            With sqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[dbo].[sp_InsUpsPOLICYNODETAILS]"
                .Connection = Conn
                .Parameters.AddWithValue("@Type", Type)
                .Parameters.AddWithValue("@POLICYID", POLICYID)
                .Parameters.AddWithValue("@POLICYNO", POLICYNO)
                If SDATE = "" Then
                    .Parameters.Add("@SDATE", SqlDbType.SmallDateTime)
                    .Parameters("@SDATE").Value = DBNull.Value
                Else
                    .Parameters.Add("@SDATE", SqlDbType.SmallDateTime)
                    .Parameters("@SDATE").Value = SDATE
                End If
                If EDATE = "" Then
                    .Parameters.Add("@EDATE", SqlDbType.SmallDateTime)
                    .Parameters("@EDATE").Value = DBNull.Value
                Else
                    .Parameters.Add("@EDATE", SqlDbType.SmallDateTime)
                    .Parameters("@EDATE").Value = EDATE
                End If
                sRes = .ExecuteScalar
            End With
            Return sRes
        Catch ex As Exception
            sRes = ex.Message
            Return sRes
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

End Class
