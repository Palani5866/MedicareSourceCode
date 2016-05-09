Public Class femdb
#Region "Global Veriable"
    Dim _objBusi As New clsimdb
    Dim mConn As New SqlConnection("Data Source=MYSYSDB01\MSSQLSERVR;Initial Catalog=Medicare;user id=sa;password=Imgood!@#;Pooling=False")
    Dim cConn As New SqlConnection("Data Source=MYSYSDB01\MSSQLSERVR;Initial Catalog=TAS;user id=sa;password=Imgood!@#;Pooling=False")
#End Region
#Region "Page Load"
    Private Sub femdb_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    End Sub
    Private Sub femdb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Try
            If Me.txtNRIC.Text.ToString.Trim() = "" Then
                MsgBox("Required NRIC to Process")
                Me.txtNRIC.Focus()
                Exit Sub
            End If
            Try
                mConn.Open()
                cConn.Open()
            Catch ex As Exception
                Dim mConn As New SqlConnection("Data Source=MYSYSDB01\MSSQLSERVR;Initial Catalog=Medicare;user id=sa;password=Imgood!@#;Pooling=False")
                Dim cConn As New SqlConnection("Data Source=MYSYSDB01\MSSQLSERVR;Initial Catalog=TAS;user id=sa;password=Imgood!@#;Pooling=False")
                mConn.Open()
                cConn.Open()
            End Try
            Dim cmd As SqlCommand = CType(mConn.CreateCommand(), SqlCommand)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT * FROM DT_MEMBER where ic_new='" & Me.txtNRIC.Text.ToString.Trim() & "' "
            Dim sdp As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            sdp.Fill(dt)
            If dt.Rows.Count > 0 Then
                SharedData.ReadyToHideMarquee = False
                StartMarqueeThread()
                For Each dr As DataRow In dt.Rows
                    Dim chkCmd As SqlCommand = CType(cConn.CreateCommand, SqlCommand)
                    chkCmd.CommandType = CommandType.Text
                    chkCmd.CommandText = "SELECT * FROM DT_POLICYHOLDER WHERE IC='" & dr("IC_NEW").ToString.Trim() & "'"
                    Dim chkSdp As New SqlDataAdapter(chkCmd)
                    Dim chkdt As New DataTable
                    chkSdp.Fill(chkdt)
                    If chkdt.Rows.Count > 0 Then
                        Dim sRes, PB_DATE, SIC, ADD1, ADD2, TOWN, STATE, PSCODE, PHONE_H, PHONE_M, pSEX As String
                        If Not IsDBNull(dr("POSTAL_ADDRESS_L1")) Then
                            ADD1 = dr("POSTAL_ADDRESS_L1")
                        Else
                            ADD1 = ""
                        End If
                        If Not IsDBNull(dr("POSTAL_ADDRESS_L2")) Then
                            ADD2 = dr("POSTAL_ADDRESS_L2")
                        Else
                            ADD2 = ""
                        End If
                        If Not IsDBNull(dr("TOWN")) Then
                            TOWN = dr("TOWN")
                        Else
                            TOWN = ""
                        End If
                        If Not IsDBNull(dr("STATE")) Then
                            STATE = dr("STATE")
                        Else
                            STATE = ""
                        End If
                        If Not IsDBNull(dr("POSTCODE")) Then
                            PSCODE = dr("POSTCODE")
                        Else
                            PSCODE = ""
                        End If
                        If Not IsDBNull(dr("PHONE_HSE")) Then
                            PHONE_H = dr("PHONE_HSE")
                        Else
                            PHONE_H = ""
                        End If
                        If Not IsDBNull(dr("PHONE_MOBILE")) Then
                            PHONE_M = dr("PHONE_MOBILE")
                        Else
                            PHONE_M = ""
                        End If
                        If Not IsDBNull(dr("BIRTH_DATE")) Then
                            PB_DATE = dr("BIRTH_DATE")
                        Else
                            PB_DATE = ""
                        End If
                        If Not IsDBNull(dr("SEX")) Then
                            pSEX = dr("SEX")
                        Else
                            pSEX = True
                        End If
                        SIC = dr("IC_new")
                        sRes = _objBusi.InsPolicyHolderDetails("UPDATE", chkdt.Rows(0)("ID").ToString.Trim(), dr("CLIENTID").ToString.Trim(), dr("IC_NEW").ToString.Trim(), dr("FULL_NAME").ToString.Trim(), dr("NEW_NAME").ToString.Trim(), PB_DATE, ADD1, ADD2, TOWN, STATE, PSCODE, pSEX, PHONE_H, PHONE_M, "ADMIN", cConn)
                        Dim cmd1 As SqlCommand = CType(mConn.CreateCommand, SqlCommand)
                        cmd1.CommandType = CommandType.Text
                        cmd1.CommandText = "SELECT * FROM DT_MEMBER_POLICY WHERE MEMBER_ID='" & dr("ID").ToString.Trim() & "' and Deduction_Code not in ('6601', '0599', '0559')"
                        Dim sdp1 As New SqlDataAdapter(cmd1)
                        Dim dt1 As New DataTable
                        sdp1.Fill(dt1)
                        If dt1.Rows.Count > 0 Then
                            For Each dr1 As DataRow In dt1.Rows
                                Dim chkCmd1 As SqlCommand = CType(cConn.CreateCommand, SqlCommand)
                                chkCmd1.CommandType = CommandType.Text
                                chkCmd1.CommandText = "SELECT * FROM DT_POLICYHOLDER_POLICY WHERE POLICYHOLDER_ID='" & chkdt.Rows(0)("ID").ToString.Trim() & "' AND PLAN_CODE='" & dr1("PLAN_CODE").ToString.Trim() & "' AND POLICY_TYPE='" & dr1("LEVEL2_PLAN_CODE").ToString.Trim() & "'"
                                Dim chkSdp1 As New SqlDataAdapter(chkCmd1)
                                Dim chkdt1 As New DataTable
                                chkSdp1.Fill(chkdt1)
                                Dim sCancellation_Date As String
                                If Not IsDBNull(dr1("Cancellation_Date")) Then
                                    sCancellation_Date = dr1("Cancellation_Date")
                                Else
                                    sCancellation_Date = ""
                                End If
                                If chkdt1.Rows.Count > 0 Then
                                    If Not IsDBNull(dr1("PLAN_CODE")) Then
                                        If Not IsDBNull(dr1("STATUS")) Then
                                            If Not IsDBNull(dr1("EFFECTIVE_DATE")) Then
                                                sRes = _objBusi.InsPolicyDetails("UPDATE", chkdt1.Rows(0)("ID").ToString.Trim(), chkdt.Rows(0)("ID").ToString.Trim(), dr1("PLAN_CODE").ToString.Trim(), dr1("PLAN_CODE").ToString.Trim(), dr1("POLICY_NO").ToString.Trim(), dr1("NEW_POLICY_NO").ToString.Trim(), dr1("LEVEL2_PLAN_CODE").ToString().Trim(), dr1("AGENT_CODE").ToString.Trim(), dr1("EFFECTIVE_DATE"), dr1("EFFECTIVE_DATE"), sCancellation_Date, "0", "", "", "", dr1("STATUS"), dr1("ANGKASA_FILENO").ToString.Trim(), "ADMIN", cConn)
                                                POLICYNODETAILS(dr1("ID").ToString.Trim(), chkdt1.Rows(0)("ID").ToString.Trim())
                                                POLICYDOCS(dr1("ID").ToString.Trim(), chkdt1.Rows(0)("ID").ToString.Trim())
                                                Dim cmd2 As SqlCommand = CType(mConn.CreateCommand, SqlCommand)
                                                cmd2.CommandType = CommandType.Text
                                                cmd2.CommandText = "SELECT * FROM DT_MEMBER_POLICY_DEPENDENTS WHERE MEMBER_POLICY_ID='" & dr1("ID").ToString.Trim() & "'"
                                                Dim sdp2 As New SqlDataAdapter(cmd2)
                                                Dim dt2 As New DataTable
                                                sdp2.Fill(dt2)
                                                If dt2.Rows.Count > 0 Then
                                                    For Each DR2 As DataRow In dt2.Rows
                                                        Dim chkCmd2 As SqlCommand = CType(cConn.CreateCommand, SqlCommand)
                                                        chkCmd2.CommandType = CommandType.Text
                                                        chkCmd2.CommandText = "SELECT * FROM DT_POLICYHOLDER_DEPENDENTS WHERE POLICY_ID='" & chkdt1.Rows(0)("ID").ToString.Trim() & "' AND IC='" & DR2("IC_NEW").ToString.Trim() & "' AND FULL_NAME='" & DR2("FULL_NAME").ToString.Trim() & "'"
                                                        Dim chkSdp2 As New SqlDataAdapter(chkCmd2)
                                                        Dim chkdt2 As New DataTable
                                                        chkSdp2.Fill(chkdt2)
                                                        Dim E_Date, B_DATE, dSEX As String
                                                        If Not IsDBNull(DR2("BIRTH_DATE")) Then
                                                            B_DATE = DR2("BIRTH_DATE")
                                                        Else
                                                            B_DATE = ""
                                                        End If
                                                        If Not IsDBNull(DR2("EFFECTIVE_DATE")) Then
                                                            E_Date = DR2("EFFECTIVE_DATE")
                                                        Else
                                                            E_Date = ""
                                                        End If
                                                        If Not IsDBNull(DR2("SEX")) Then
                                                            dSEX = DR2("SEX")
                                                        Else
                                                            dSEX = True
                                                        End If
                                                        If chkdt2.Rows.Count > 0 Then
                                                            sRes = _objBusi.InsDepDetails("UPDATE", chkdt2.Rows(0)("ID").ToString.Trim(), chkdt1.Rows(0)("ID").ToString.Trim(), DR2("CLIENTID").ToString.Trim(), DR2("IC_NEW").ToString.Trim(), DR2("FULL_NAME").ToString.Trim(), DR2("NEW_NAME").ToString.Trim(), B_DATE, dSEX, DR2("RELATIONSHIP").ToString.Trim(), E_Date, "", "", "admin", cConn)
                                                        Else
                                                            sRes = _objBusi.InsDepDetails("INSERT", Guid.NewGuid.ToString.Trim(), chkdt1.Rows(0)("ID").ToString.Trim(), DR2("CLIENTID").ToString.Trim(), DR2("IC_NEW").ToString.Trim(), DR2("FULL_NAME").ToString.Trim(), DR2("NEW_NAME").ToString.Trim(), B_DATE, dSEX, DR2("RELATIONSHIP").ToString.Trim(), E_Date, "", "", "admin", cConn)
                                                        End If
                                                    Next
                                                End If
                                            End If
                                        End If
                                    End If
                                Else
                                    Dim POLICY_ID As String
                                    POLICY_ID = Guid.NewGuid.ToString.Trim()
                                    If Not IsDBNull(dr1("plan_code")) Then
                                        If Not IsDBNull(dr1("status")) Then
                                            If Not IsDBNull(dr1("EFFECTIVE_DATE")) Then
                                                sRes = _objBusi.InsPolicyDetails("INSERT", POLICY_ID, chkdt.Rows(0)("ID").ToString.Trim(), dr1("PLAN_CODE").ToString.Trim(), dr1("PLAN_CODE").ToString.Trim(), dr1("POLICY_NO").ToString.Trim(), dr1("NEW_POLICY_NO").ToString.Trim(), dr1("LEVEL2_PLAN_CODE").ToString().Trim(), dr1("AGENT_CODE").ToString.Trim(), dr1("EFFECTIVE_DATE"), dr1("EFFECTIVE_DATE"), sCancellation_Date, "0", "", "", "", dr1("STATUS"), dr1("ANGKASA_FILENO").ToString.Trim(), "ADMIN", cConn)
                                                POLICYNODETAILS(dr1("ID").ToString.Trim(), POLICY_ID)
                                                POLICYDOCS(dr1("ID").ToString.Trim(), POLICY_ID)
                                                Dim cmd2 As SqlCommand = CType(mConn.CreateCommand, SqlCommand)
                                                cmd2.CommandType = CommandType.Text
                                                cmd2.CommandText = "SELECT * FROM DT_MEMBER_POLICY_DEPENDENTS WHERE MEMBER_POLICY_ID='" & dr1("ID").ToString.Trim() & "'"
                                                Dim sdp2 As New SqlDataAdapter(cmd2)
                                                Dim dt2 As New DataTable
                                                sdp2.Fill(dt2)
                                                If dt2.Rows.Count > 0 Then
                                                    For Each DR2 As DataRow In dt2.Rows
                                                        Dim e_date, B_date, dSEX As String
                                                        If Not IsDBNull(DR2("BIRTH_DATE")) Then
                                                            B_date = DR2("BIRTH_DATE")
                                                        Else
                                                            B_date = ""
                                                        End If
                                                        If Not IsDBNull(DR2("EFFECTIVE_DATE")) Then
                                                            e_date = DR2("EFFECTIVE_DATE")
                                                        Else
                                                            e_date = ""
                                                        End If
                                                        If Not IsDBNull(DR2("SEX")) Then
                                                            dSEX = DR2("SEX")
                                                        Else
                                                            dSEX = True
                                                        End If
                                                        sRes = _objBusi.InsDepDetails("INSERT", Guid.NewGuid.ToString.Trim(), POLICY_ID, DR2("CLIENTID").ToString.Trim(), DR2("IC_NEW").ToString.Trim(), DR2("FULL_NAME").ToString.Trim(), DR2("NEW_NAME").ToString.Trim(), B_date, dSEX, DR2("RELATIONSHIP").ToString.Trim(), e_date, "", "", "admin", cConn)
                                                    Next
                                                End If
                                            End If

                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Else
                        Dim PH_ID As String
                        Dim sRes, PB_DATE, SIC, ADD1, ADD2, TOWN, STATE, PSCODE, PHONE_H, PHONE_M, pSEX As String
                        If Not IsDBNull(dr("POSTAL_ADDRESS_L1")) Then
                            ADD1 = dr("POSTAL_ADDRESS_L1")
                        Else
                            ADD1 = ""
                        End If
                        If Not IsDBNull(dr("POSTAL_ADDRESS_L2")) Then
                            ADD2 = dr("POSTAL_ADDRESS_L2")
                        Else
                            ADD2 = ""
                        End If
                        If Not IsDBNull(dr("TOWN")) Then
                            TOWN = dr("TOWN")
                        Else
                            TOWN = ""
                        End If
                        If Not IsDBNull(dr("STATE")) Then
                            STATE = dr("STATE")
                        Else
                            STATE = ""
                        End If
                        If Not IsDBNull(dr("POSTCODE")) Then
                            PSCODE = dr("POSTCODE")
                        Else
                            PSCODE = ""
                        End If
                        If Not IsDBNull(dr("PHONE_HSE")) Then
                            PHONE_H = dr("PHONE_HSE")
                        Else
                            PHONE_H = ""
                        End If
                        If Not IsDBNull(dr("PHONE_MOBILE")) Then
                            PHONE_M = dr("PHONE_MOBILE")
                        Else
                            PHONE_M = ""
                        End If
                        If Not IsDBNull(dr("BIRTH_DATE")) Then
                            PB_DATE = dr("BIRTH_DATE")
                        Else
                            PB_DATE = ""
                        End If
                        If Not IsDBNull(dr("SEX")) Then
                            pSEX = dr("SEX")
                        Else
                            pSEX = True
                        End If
                        PH_ID = Guid.NewGuid.ToString.Trim()
                        sRes = _objBusi.InsPolicyHolderDetails("INSERT", PH_ID, dr("CLIENTID").ToString.Trim(), dr("IC_NEW").ToString.Trim(), dr("FULL_NAME").ToString.Trim(), dr("NEW_NAME").ToString.Trim(), PB_DATE, ADD1, ADD2, TOWN, STATE, PSCODE, pSEX, PHONE_H, PHONE_M, "ADMIN", cConn)

                        Dim cmd1 As SqlCommand = CType(mConn.CreateCommand, SqlCommand)
                        cmd1.CommandType = CommandType.Text
                        cmd1.CommandText = "SELECT * FROM DT_MEMBER_POLICY WHERE MEMBER_ID='" & dr("ID").ToString.Trim() & "'"
                        Dim sdp1 As New SqlDataAdapter(cmd1)
                        Dim dt1 As New DataTable
                        sdp1.Fill(dt1)
                        If dt1.Rows.Count > 0 Then
                            For Each dr1 As DataRow In dt1.Rows
                                Dim POLICY_ID, sCancellation_Date As String
                                POLICY_ID = Guid.NewGuid.ToString.Trim()
                                If Not IsDBNull(dr1("Cancellation_Date")) Then
                                    sCancellation_Date = dr1("Cancellation_Date")
                                Else
                                    sCancellation_Date = ""
                                End If
                                If Not IsDBNull(dr1("STATUS")) Then
                                    If Not IsDBNull(dr1("effective_date")) Then
                                        sRes = _objBusi.InsPolicyDetails("INSERT", POLICY_ID, PH_ID, dr1("PLAN_CODE").ToString.Trim(), dr1("PLAN_CODE").ToString.Trim(), dr1("POLICY_NO").ToString.Trim(), dr1("NEW_POLICY_NO").ToString.Trim(), dr1("LEVEL2_PLAN_CODE").ToString().Trim(), dr1("AGENT_CODE").ToString.Trim(), dr1("EFFECTIVE_DATE"), dr1("EFFECTIVE_DATE"), sCancellation_Date, "0", "", "", "", dr1("STATUS"), dr1("ANGKASA_FILENO").ToString.Trim(), "ADMIN", cConn)
                                        POLICYNODETAILS(dr1("ID").ToString.Trim(), POLICY_ID)
                                        POLICYDOCS(dr1("ID").ToString.Trim(), POLICY_ID)
                                        Dim cmd2 As SqlCommand = CType(mConn.CreateCommand, SqlCommand)
                                        cmd2.CommandType = CommandType.Text
                                        cmd2.CommandText = "SELECT * FROM DT_MEMBER_POLICY_DEPENDENTS WHERE MEMBER_POLICY_ID='" & dr1("ID").ToString.Trim() & "'"
                                        Dim sdp2 As New SqlDataAdapter(cmd2)
                                        Dim dt2 As New DataTable
                                        sdp2.Fill(dt2)
                                        If dt2.Rows.Count > 0 Then
                                            For Each DR2 As DataRow In dt2.Rows
                                                Dim E_Date, B_Date, dSEX As String
                                                If Not IsDBNull(DR2("Effective_Date")) Then
                                                    E_Date = DR2("Effective_date")
                                                Else
                                                    E_Date = ""
                                                End If
                                                If Not IsDBNull(DR2("Birth_Date")) Then
                                                    B_Date = DR2("Birth_Date")
                                                Else
                                                    B_Date = ""
                                                End If
                                                If Not IsDBNull(DR2("SEX")) Then
                                                    dSEX = DR2("SEX")
                                                Else
                                                    dSEX = True
                                                End If
                                                sRes = _objBusi.InsDepDetails("INSERT", Guid.NewGuid.ToString.Trim(), POLICY_ID, DR2("CLIENTID").ToString.Trim(), DR2("IC_NEW").ToString.Trim(), DR2("FULL_NAME").ToString.Trim(), DR2("NEW_NAME").ToString.Trim(), B_Date, dSEX, DR2("RELATIONSHIP").ToString.Trim(), E_Date, "", "", "admin", cConn)
                                            Next
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                Dim Result As Integer
                Result = MsgBox("Process Completed Successfully! Do have to Process another Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Process")
                Select Case Result
                    Case 6
                        Me.txtNRIC.Text = ""
                    Case 7
                        Me.Close()
                End Select
            Else
                MsgBox("Invalid NRIC! Please try with valid NRIC")
            End If
        Catch ex As Exception
            MsgBox("Error while Instant Process, Please check your NRIC and try again!")
        End Try
    End Sub
#End Region
#Region "General Sub's"
    Private Sub POLICYNODETAILS(ByVal POLICYID As String, ByVal CPOLICYID As String)
        Dim dt As New DataTable
        dt = _objBusi.fmgetDetails("POLICYNODETAILS", POLICYID, "", "", "", "", "", "", "", "", "", mConn)
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim cdt As New DataTable
                Dim ssDate, seDate As String
                Dim sDate, eDate As Date
                sDate = Convert.ToDateTime(dr("start_date").ToString())
                If Not IsDBNull(dr("end_date")) Then
                    eDate = Convert.ToDateTime(dr("end_date").ToString())
                    seDate = Format(eDate, "MM/dd/yyyy")
                Else
                    seDate = ""
                End If
                ssDate = Format(sDate, "MM/dd/yyyy")
                cdt = _objBusi.fcgetDetails("POLICYNODETAILS", CPOLICYID, dr("POLICY_NO").ToString.Trim(), ssDate, seDate, "", "", "", "", "", "", cConn)
                Dim sRes As String
                If cdt.Rows.Count > 0 Then
                    sRes = _objBusi.fIUPOLICYNODetails("UPDATE", cdt.Rows(0)("ID").ToString.Trim(), dr("POLICY_NO").ToString.Trim(), dr("start_date").ToString.Trim(), dr("end_date").ToString.Trim(), cConn)
                Else
                    sRes = _objBusi.fIUPOLICYNODetails("INSERT", CPOLICYID, dr("POLICY_NO").ToString.Trim(), dr("start_date").ToString.Trim(), dr("end_date").ToString.Trim(), cConn)
                End If
            Next
        End If

    End Sub
    Private Sub POLICYDOCS(ByVal POLICYID As String, ByVal CPOLICYID As String)
        _objBusi.spUpdate("UPDC", POLICYID, CPOLICYID, "", "", "", "", "", "", "", "", mConn)
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