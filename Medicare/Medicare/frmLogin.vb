Imports System.Security.Cryptography
Public Class frmLogin
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim Listener As System.Net.Sockets.TcpListener
    Dim Client As New System.Net.Sockets.TcpClient
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
        Catch ex As Exception
            My.Settings.SQL_Conn = My.Settings.SQL_ConnDB2
            Conn.ConnectionString = My.Settings.SQL_Conn
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
        End Try
        chkUA()
    End Sub
    Private Sub frmLogin_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
#End Region
    Private Sub chkUA()
        _objBusi.UpdatePolicyStatus(Conn)
    End Sub
    Private Function VCheck() As Boolean
        Dim dt As New DataTable
        dt = _objBusi.getDetails("V", "MSV1.0.5", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            MsgBox("We are sorry! Your trying login Older Version or Invalid Version, Please check with your admin for New Version or Valid Version!")
            Return False
        End If
    End Function
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If VCheck() Then
            LoginUsersNew()
        End If
    End Sub
    Private Sub LoginUsersNew()
        Dim dt As New DataTable
        dt = _objBusi.getUsers("LOGIN", Me.txtUsername.Text.Trim, Me.txtPassword.Text.Trim, Conn)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Status") = "Active" Then
                My.Settings.Username = Me.txtUsername.Text.Trim
                With frmMain
                    If Not (dt.Rows(0)("UserID") = "SRI" Or dt.Rows(0)("UserID") = "Admin" Or dt.Rows(0)("UserID") = "hafeza") Then
                        MenuDisable()
                        .mnuSystemSettings.Enabled = False
                        .mAdmin.Enabled = False
                        Dim oM, oSM As String
                        oM = dt.Rows(0)("Module")
                        oSM = dt.Rows(0)("Sub_Module")
                        For Each M As String In oM.Split(",")
                            Select Case M
                                Case "P0", "P1"
                                    PDisable("Proposer")
                                    If M = "P1" Then
                                        .MenuStrip.Items("mnuProposers").Enabled = True
                                        .mnuProposers.DropDownItems("mnuProposers_New").Enabled = True
                                        .mnuProposers.DropDownItems("mnuProposers_Verify").Enabled = True
                                        .mnuProposers.DropDownItems("mnuProposers_Submission").Enabled = True
                                        .mnuProposers_Submission.DropDownItems("mnuProposers_Submission_List").Enabled = True
                                        .mnuProposers_Submission.DropDownItems("mnuProposer_UWSubmission").Enabled = True
                                        .mnuProposers.DropDownItems("mnuProposers_View").Enabled = True
                                        .mnuProposers_View.DropDownItems("mnuProposers_View_VerifiedProposer").Enabled = True
                                        .mnuProposers_View.DropDownItems("mnuProposers_View_AllProposers").Enabled = True
                                        .mnuProposers.DropDownItems("mProposer_Letters").Enabled = True
                                        .mProposer_Letters.DropDownItems("mProposer_Letters_Acknowledgement").Enabled = True
                                        .mProposer_Letters.DropDownItems("mProposer_Letters_Deferment").Enabled = True
                                        .mProposer_Letters.DropDownItems("mProposer_Letters_Reject").Enabled = True
                                        .mProposer_Letters.DropDownItems("mProposer_Letters_Underwriting").Enabled = True
                                        .mnuProposers.DropDownItems("mPropsoer_SendMail").Enabled = True
                                        .mPropsoer_SendMail.DropDownItems("mProposer_SendMail_Incomplete").Enabled = True
                                        .mPropsoer_SendMail.DropDownItems("mProposer_SendMail_Acknowledgement").Enabled = True
                                        .mnuProposers.DropDownItems("mProposer_Reports").Enabled = True
                                        .mProposer_Reports.DropDownItems("mProposer_Reports_Production").Enabled = True
                                    Else
                                        For Each SM As String In oSM.Split(",")
                                            .MenuStrip.Items("mnuProposers").Enabled = True
                                            Select Case SM
                                                Case "P0"
                                                    .mnuProposers.DropDownItems("mnuProposers_New").Enabled = True
                                                Case "P1"
                                                    .mnuProposers.DropDownItems("mnuProposers_Verify").Enabled = True
                                                Case "P2"
                                                    .mnuProposers.DropDownItems("mnuProposers_Submission").Enabled = True
                                                    .mnuProposers_Submission.DropDownItems("mnuProposers_Submission_List").Enabled = True
                                                    .mnuProposers_Submission.DropDownItems("mnuProposer_UWSubmission").Enabled = True
                                                Case "P3"
                                                    .mnuProposers.DropDownItems("mnuProposers_View").Enabled = True
                                                    .mnuProposers_View.DropDownItems("mnuProposers_View_VerifiedProposer").Enabled = True
                                                Case "P4"
                                                    .mnuProposers.DropDownItems("mnuProposers_View").Enabled = True
                                                    .mnuProposers_View.DropDownItems("mnuProposers_View_AllProposers").Enabled = True
                                                Case "P5"
                                                    .mnuProposers.DropDownItems("mProposer_Letters").Enabled = True
                                                    .mProposer_Letters.DropDownItems("mProposer_Letters_Acknowledgement").Enabled = True
                                                Case "P6"
                                                    .mnuProposers.DropDownItems("mProposer_Letters").Enabled = True
                                                    .mProposer_Letters.DropDownItems("mProposer_Letters_Deferment").Enabled = True
                                                Case "P7"
                                                    .mnuProposers.DropDownItems("mProposer_Letters").Enabled = True
                                                    .mProposer_Letters.DropDownItems("mProposer_Letters_Reject").Enabled = True
                                                Case "P8"
                                                    .mnuProposers.DropDownItems("mProposer_Letters").Enabled = True
                                                    .mProposer_Letters.DropDownItems("mProposer_Letters_Underwriting").Enabled = True
                                                Case "P9"
                                                    .mnuProposers.DropDownItems("mPropsoer_SendMail").Enabled = True
                                                    .mPropsoer_SendMail.DropDownItems("mProposer_SendMail_Incomplete").Enabled = True
                                                Case "P10"
                                                    .mnuProposers.DropDownItems("mPropsoer_SendMail").Enabled = True
                                                    .mPropsoer_SendMail.DropDownItems("mProposer_SendMail_Acknowledgement").Enabled = True
                                                Case "P11"
                                                    .mnuProposers.DropDownItems("mProposer_Reports").Enabled = True
                                                    .mProposer_Reports.DropDownItems("mProposer_Reports_Production").Enabled = True
                                            End Select
                                        Next
                                    End If
                                Case "M0", "M1"
                                    If M = "M1" Then
                                        .MenuStrip.Items("mnuMembers").Enabled = True
                                        .mnuMembers.DropDownItems("mMember_Upload").Enabled = True
                                        .mMember_Upload.DropDownItems("mMember_Upload_PolicyCertificateNo").Enabled = True
                                        .mMember_Upload.DropDownItems("mMember_Upload_Addresses").Enabled = True
                                        .mMember_Upload.DropDownItems("mMember_Upload_ClientNo").Enabled = True
                                        .mMember_Upload.DropDownItems("mMember_Upload_ICDOBPHONE").Enabled = True
                                        .mnuMembers.DropDownItems("mMember_Download").Enabled = True
                                    Else
                                        For Each SM As String In oSM.Split(",")
                                            .MenuStrip.Items("mnuMembers").Enabled = True
                                            Select Case SM
                                                Case "M0"

                                                Case "M1"

                                                Case "M2"
                                                    
                                                Case "M3"
                                                    .mnuMembers.DropDownItems("mMember_Upload").Enabled = True
                                                    .mMember_Upload.DropDownItems("mMember_Upload_PolicyCertificateNo").Enabled = True
                                                Case "M4"
                                                    .mnuMembers.DropDownItems("mMember_Upload").Enabled = True
                                                    .mMember_Upload.DropDownItems("mMember_Upload_Addresses").Enabled = True
                                                Case "M5"
                                                    .mnuMembers.DropDownItems("mMember_Upload").Enabled = True
                                                    .mMember_Upload.DropDownItems("mMember_Upload_ClientNo").Enabled = True
                                                Case "M6"
                                                    .mnuMembers.DropDownItems("mMember_Upload").Enabled = True
                                                    .mMember_Upload.DropDownItems("mMember_Upload_ICDOBPHONE").Enabled = True
                                                Case "M7"
                                                    .mnuMembers.DropDownItems("mMember_Download").Enabled = True
                                                Case "M8"
                                                    .mnuMembers.DropDownItems("mMember_Download").Enabled = True
                                                    .mMember_Download.DropDownItems("mMember_Download_BlankAddresses").Enabled = True
                                                Case "M9"
                                                    .mnuMembers.DropDownItems("mMember_Download").Enabled = True
                                                    .mMember_Download.DropDownItems("mMember_Download_ExportBlankICDOBPHONE").Enabled = True
                                                Case "M10"
                                                    .mnuMembers.DropDownItems("mMember_Download").Enabled = True
                                                    .mMember_Download.DropDownItems("mMember_Download_ClientNo").Enabled = True
                                                Case "M11"
                                                Case "M12"
                                                Case "M13"
                                                Case "M14"
                                            End Select
                                        Next
                                    End If
                                Case "PRE0", "PRE1"
                                    If M = "PRE1" Then

                                        .MenuStrip.Items("mnuPremium").Enabled = True
                                        .mnuPremium.DropDownItems("mPremium_ViewMember").Enabled = True
                                        .mnuPremium.DropDownItems("mPremium_PrintLetters").Enabled = True
                                        .mnuPremium.DropDownItems("mPremium_Reports").Enabled = True
                                        .mPremium_Reports.DropDownItems("mPremium_Reports_SubmissionToInurer").Enabled = True
                                    Else
                                        For Each SM As String In oSM.Split(",")
                                            .MenuStrip.Items("mnuPremium").Enabled = True
                                            Select Case SM
                                                Case "PRE0"
                                                    .mnuPremium.DropDownItems("mPremium_ViewMember").Enabled = True
                                                Case "PRE1"

                                                Case "PRE2"

                                                Case "PRE3"
                                                    .mnuPremium.DropDownItems("mPremium_Yearly").Enabled = True
                                                Case "PRE4"
                                                    .mnuPremium.DropDownItems("mPremium_Yearly").Enabled = True
                                                Case "PRE5"
                                                Case "PRE6"
                                                Case "PRE7"
                                                    .mnuPremium.DropDownItems("mPremium_CancellationOfPolicy").Enabled = True
                                                Case "PRE8"

                                                Case "PRE9"

                                                Case "PRE10"

                                                Case "PRE11"

                                                Case "PRE12"

                                                Case "PRE13"

                                                Case "PRE14"

                                                Case "PRE15"
                                                    .mnuPremium.DropDownItems("mPremium_PrintLetters").Enabled = True
                                                Case "PRE16"
                                                    .mnuPremium.DropDownItems("mPremium_Reports").Enabled = True
                                                    .mPremium_Reports.DropDownItems("mPremium_Reports_13Months").Enabled = True
                                                Case "PRE17"
                                                    .mnuPremium.DropDownItems("mPremium_Reports").Enabled = True
                                                    .mPremium_Reports.DropDownItems("mPremium_Reports_SuspensionAccount").Enabled = True
                                                Case "PRE18"
                                                    .mnuPremium.DropDownItems("mPremium_Reports").Enabled = True
                                                    .mPremium_Reports.DropDownItems("mPremium_Reports_ShortFalls").Enabled = True
                                                Case "PRE19"
                                                    .mnuPremium.DropDownItems("mPremium_Reports").Enabled = True
                                                Case "PRE20"
                                                    .mnuPremium.DropDownItems("mPremium_Reports").Enabled = True
                                                Case "PRE21"
                                                    .mnuPremium.DropDownItems("mPremium_Reports").Enabled = True
                                                Case "PRE22"
                                                    .mnuPremium.DropDownItems("mPremium_Reports").Enabled = True
                                                Case "PRE23"
                                                    .mnuPremium.DropDownItems("mPremium_Reports").Enabled = True
                                            End Select
                                        Next
                                    End If
                                Case "CS0", "CS1"
                                    If M = "CS1" Then

                                        .MenuStrip.Items("mCS").Enabled = True
                                        .mCS.DropDownItems("mCS_ViewAll").Enabled = True
                                        .mCS.DropDownItems("mCS_Endorsement").Enabled = True
                                        .mCS_Endorsement.DropDownItems("mCS_Endorsement_ChangePostalAddress").Enabled = True
                                        .mCS_Endorsement.DropDownItems("mCS_Endorsement_ChangePersonalDetails").Enabled = True
                                        .mCS_Endorsement.DropDownItems("mCS_Endorsement_Dependents").Enabled = True
                                        .mCS_Endorsement.DropDownItems("mCS_Endorsement_Nominee").Enabled = True
                                        .mCS_Endorsement.DropDownItems("mCS_Endorsement_EC").Enabled = True
                                    Else
                                        For Each SM As String In oSM.Split(",")
                                            .MenuStrip.Items("mCS").Enabled = True
                                            Select Case SM
                                                Case "CS0"
                                                    .mCS.DropDownItems("mCS_ViewAll").Enabled = True
                                                Case "CS1"
                                                    .mCS.DropDownItems("mCS_Endorsement").Enabled = True
                                                    .mCS_Endorsement.DropDownItems("mCS_Endorsement_ChangePostalAddress").Enabled = True
                                                Case "CS2"
                                                    .mCS.DropDownItems("mCS_Endorsement").Enabled = True
                                                    .mCS_Endorsement.DropDownItems("mCS_Endorsement_ChangePersonalDetails").Enabled = True
                                                Case "CS3"
                                                    .mCS.DropDownItems("mCS_Endorsement").Enabled = True
                                                    .mCS_Endorsement.DropDownItems("mCS_Endorsement_Dependents").Enabled = True
                                                Case "CS4"
                                                    .mCS.DropDownItems("mCS_Endorsement").Enabled = True
                                                    .mCS_Endorsement.DropDownItems("mCS_Endorsement_Nominee").Enabled = True
                                                Case "CS5"
                                                    .mCS.DropDownItems("mCS_Endorsement").Enabled = True
                                                    .mCS_Endorsement.DropDownItems("mCS_Endorsement_EC").Enabled = True
                                                Case "CS6"
                                                    .mCS.DropDownItems("mCS_Endorsement").Enabled = True
                                                    .mCS_Endorsement.DropDownItems("mCS_Endorsement_ViewEditMember").Enabled = True
                                                Case "CS7"
                                                Case "CS8"
                                                Case "CS9"
                                                Case "CS10"
                                                Case "CS11"
                                                Case "CS12"
                                                Case "CS13"
                                                Case "CS14"
                                                Case "CS15"
                                            End Select
                                        Next
                                    End If
                                Case "A0", "A1"
                                    If M = "A1" Then
                                        .MenuStrip.Items("mAdmin").Visible = True
                                        .mAdmin.DropDownItems("mAdmin_tsmiViewEdit").Enabled = True
                                        .mAdmin.DropDownItems("mAdmin_ReinstatePolicy").Enabled = True
                                    Else
                                        For Each SM As String In oSM.Split(",")
                                            .MenuStrip.Items("mAdmin").Visible = True
                                            Select Case SM
                                                Case "A0"
                                                    .mAdmin.DropDownItems("mAdmin_tsmiViewEdit").Enabled = True
                                                    .mAdmin_tsmiViewEdit.DropDownItems("mAdmin_ViewEdit_tsmiMember").Enabled = True
                                                Case "A1"
                                                    .mAdmin.DropDownItems("mAdmin_tsmiViewEdit").Enabled = True
                                                    .mAdmin_tsmiViewEdit.DropDownItems("mAdmin_ViewEdit_tsmiDependents").Enabled = True
                                                Case "A2"
                                                    .mAdmin.DropDownItems("mAdmin_tsmiViewEdit").Enabled = True
                                                    .mAdmin_tsmiViewEdit.DropDownItems("mAdmin_ViewEdit_tsmiNominees").Enabled = True
                                                Case "A3"
                                                    .mAdmin.DropDownItems("mAdmin_tsmiViewEdit").Enabled = True
                                                    .mAdmin_tsmiViewEdit.DropDownItems("mAdmin_ViewEdit_tsmiExclosueClause").Enabled = True
                                                Case "A4"
                                                    .mAdmin.DropDownItems("mAdmin_tsmiViewEdit").Enabled = True
                                                    .mAdmin_tsmiViewEdit.DropDownItems("mAdmin_ViewEdit_tsmiPolicy").Enabled = True
                                                Case "A5"
                                                    .mAdmin.DropDownItems("mAdmin_tsmiReprots").Enabled = True
                                                    .mAdmin_tsmiReprots.DropDownItems("mAdmin_Reprots_tsmiStaffActivityDetails").Enabled = True
                                                Case "A6"
                                                    .mAdmin.DropDownItems("mAdmin_tsmiReprots").Enabled = True
                                                    .mAdmin_tsmiReprots.DropDownItems("mAdmin_StaffAR").Enabled = True
                                                Case "A7"
                                                    .mAdmin.DropDownItems("mAdmin_tsmiReprots").Enabled = True
                                                    .mAdmin_tsmiReprots.DropDownItems("mAdmin_Report_PolicyDetails").Enabled = True
                                                Case "A8"
                                                    .mAdmin.DropDownItems("mAdmin_tsmiAdd").Enabled = True
                                                Case "A9"
                                                    .mAdmin.DropDownItems("mAdmin_tsmiAdd").Enabled = True
                                                Case "A10"
                                                    .mAdmin.DropDownItems("mAdmin_tsmiAdd").Enabled = True
                                                Case "A11"
                                                    .mAdmin.DropDownItems("mAdminRenewalListing").Enabled = True
                                                Case "A12"
                                                    .mAdmin.DropDownItems("mAdmin_SuspenseAccountSettlement").Enabled = True
                                                Case "A13"
                                                    .mAdmin.DropDownItems("mAdmin_ShortfallsSettlement").Enabled = True
                                                Case "A14"
                                                    .mAdmin.DropDownItems("mAdmin_ReinstatePolicy").Enabled = True
                                                Case "A17"
                                                    .mAdmin.DropDownItems("mAdmin_ViewEditMember").Enabled = True
                                                Case "A18"
                                                    .mAdmin.DropDownItems("mAdmin_ViewAllMember").Enabled = True = True
                                            End Select
                                        Next
                                    End If
                            End Select
                        Next
                    End If
                    _objBusi.InsAuditLogs(My.Settings.Username, "User Login.", Conn)
                    .Show()
                End With
                Me.Close()
            Else
                MsgBox("Your account has been deactivated or Expiried, Please contact your incharge!")
            End If
        Else
            MsgBox("Invalid User Name or Password")
        End If
    End Sub
    Private Sub MenuDisable()
        With frmMain
            .MenuStrip.Items("mnuProposers").Enabled = False
            .mnuProposers.DropDownItems("mnuProposers_New").Enabled = False
            .mnuProposers.DropDownItems("mnuProposers_Verify").Enabled = False
            .mnuProposers.DropDownItems("mnuProposers_Submission").Enabled = False
            .mnuProposers_Submission.DropDownItems("mnuProposers_Submission_List").Enabled = False
            .mnuProposers_Submission.DropDownItems("mnuProposer_UWSubmission").Enabled = False
            .mnuProposers.DropDownItems("mnuProposers_View").Enabled = False
            .mnuProposers_View.DropDownItems("mnuProposers_View_VerifiedProposer").Enabled = False
            .mnuProposers_View.DropDownItems("mnuProposers_View_AllProposers").Enabled = False
            .mnuProposers.DropDownItems("mProposer_Letters").Enabled = False
            .mProposer_Letters.DropDownItems("mProposer_Letters_Acknowledgement").Enabled = False
            .mProposer_Letters.DropDownItems("mProposer_Letters_Deferment").Enabled = False
            .mProposer_Letters.DropDownItems("mProposer_Letters_Reject").Enabled = False
            .mProposer_Letters.DropDownItems("mProposer_Letters_Underwriting").Enabled = False
            .mnuProposers.DropDownItems("mPropsoer_SendMail").Enabled = False
            .mPropsoer_SendMail.DropDownItems("mProposer_SendMail_Incomplete").Enabled = False
            .mPropsoer_SendMail.DropDownItems("mProposer_SendMail_Acknowledgement").Enabled = False
            .mnuProposers.DropDownItems("mProposer_Reports").Enabled = False
            .mProposer_Reports.DropDownItems("mProposer_Reports_Production").Enabled = False

            .MenuStrip.Items("mnuMembers").Enabled = False
            .mnuMembers.DropDownItems("mMember_Upload").Enabled = False
            .mMember_Upload.DropDownItems("mMember_Upload_PolicyCertificateNo").Enabled = False
            .mMember_Upload.DropDownItems("mMember_Upload_Addresses").Enabled = False
            .mMember_Upload.DropDownItems("mMember_Upload_ClientNo").Enabled = False
            .mMember_Upload.DropDownItems("mMember_Upload_ICDOBPHONE").Enabled = False
            .mnuMembers.DropDownItems("mMember_Download").Enabled = False
            .mMember_Download.DropDownItems("mMember_Download_BlankAddresses").Enabled = False
            .mMember_Download.DropDownItems("mMember_Download_ExportBlankICDOBPHONE").Enabled = False
            .mMember_Download.DropDownItems("mMember_Download_ClientNo").Enabled = False


            .MenuStrip.Items("mnuPremium").Enabled = False
            .mnuPremium.DropDownItems("mPremium_PrintLetters").Enabled = False
            .mnuPremium.DropDownItems("mPremium_Reports").Enabled = False
            


            .MenuStrip.Items("mCS").Enabled = False
            .mCS.DropDownItems("mCS_ViewAll").Enabled = False
            .mCS.DropDownItems("mCS_Endorsement").Enabled = False
            .mCS_Endorsement.DropDownItems("mCS_Endorsement_ChangePostalAddress").Enabled = False
            .mCS_Endorsement.DropDownItems("mCS_Endorsement_ChangePersonalDetails").Enabled = False
            .mCS_Endorsement.DropDownItems("mCS_Endorsement_Dependents").Enabled = False
            .mCS_Endorsement.DropDownItems("mCS_Endorsement_Nominee").Enabled = False
            .mCS_Endorsement.DropDownItems("mCS_Endorsement_EC").Enabled = False
            
            .mAdmin.DropDownItems("mAdmin_ReinstatePolicy").Enabled = False
            .MenuStrip.Items("mnuSystemSettings").Enabled = False
            .MenuStrip.Items("mAdmin").Visible = False
        End With
    End Sub
    Private Sub PDisable(ByVal type As String)
        With frmMain
            Select Case type
                Case "Proposer"

                    .MenuStrip.Items("mnuProposers").Enabled = False
                    .mnuProposers.DropDownItems("mnuProposers_New").Enabled = False
                    .mnuProposers.DropDownItems("mnuProposers_Verify").Enabled = False
                    .mnuProposers.DropDownItems("mnuProposers_Submission").Enabled = False
                    .mnuProposers_Submission.DropDownItems("mnuProposers_Submission_List").Enabled = False
                    .mnuProposers.DropDownItems("mnuProposers_View").Enabled = False
                    .mnuProposers_View.DropDownItems("mnuProposers_View_VerifiedProposer").Enabled = False
                    .mnuProposers_View.DropDownItems("mnuProposers_View_AllProposers").Enabled = False

                Case "Member"

                    .MenuStrip.Items("mnuMembers").Enabled = False
                    .mnuMembers.DropDownItems("mnuMembers_View").Enabled = False
                    .mnuMembers.DropDownItems("mnuMembers_Endosement").Enabled = False
                    .mnuMembers.DropDownItems("tsmnuMembers_Template").Enabled = False
                Case "Premium"

                    .MenuStrip.Items("mnuPremium").Enabled = False
                    .mnuPremium.DropDownItems("mnuPremium_Renewal_Yearly").Enabled = False
                    .mnuPremium.DropDownItems("mnuPremium_Renewal_Monthly_SalaryDeduction").Enabled = False
                    .mnuPremium.DropDownItems("tsmnuPremium_Template").Enabled = False
            End Select
            .MenuStrip.Items("mnuSystemSettings").Enabled = False
        End With
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
End Class
