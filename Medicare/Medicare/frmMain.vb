

Imports System.Windows.Forms
Public Class frmMain
#Region "Global Veriables"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim cmdSelect_User_Log As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_User_Log.CommandType = CommandType.Text
        cmdSelect_User_Log.CommandText = "SELECT * FROM log_User WHERE Username = '" & My.Settings.Username.Trim & "'"
        Dim da_User_Log As New SqlDataAdapter(cmdSelect_User_Log)

        Dim cmdInsert_User_Log As SqlCommandBuilder
        cmdInsert_User_Log = New SqlCommandBuilder(da_User_Log)
        Dim ds_User As New DataSet
        da_User_Log.Fill(ds_User, "log_User")
        Dim dr_User_Log_New As DataRow
        dr_User_Log_New = ds_User.Tables("log_User").NewRow

        With dr_User_Log_New
            .Item("Log_Date") = Now()
            .Item("Username") = My.Settings.Username.Trim

            Select Case e.CloseReason
                Case CloseReason.TaskManagerClosing
                    .Item("Activity_Detail") = "Application terminate via Task Manager."
                Case CloseReason.UserClosing
                    .Item("Activity_Detail") = "User Log off."
                Case CloseReason.WindowsShutDown
                    .Item("Activity_Detail") = "Application terminate via WIndows Shutdown."
                Case Else
                    .Item("Activity_Detail") = e.CloseReason.ToString.Trim & "."
            End Select
        End With

        ds_User.Tables("log_User").Rows.Add(dr_User_Log_New)
        da_User_Log.Update(ds_User, "log_User")
        Application.Exit()
    End Sub
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
    Private Sub frmMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
        Application.Exit()
    End Sub
    Private m_ChildFormNumber As Integer
#End Region
    
    Private Sub mnuProposers_Verify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProposers_Verify.Click
        Dim grd_Proposer As New grdProposer

        grd_Proposer.MdiParent = Me
        m_ChildFormNumber += 1
        grd_Proposer.lblVerficationCheck.Text = "VPRINT"
        grd_Proposer.lblForm_Flag.Text = "0"
        grd_Proposer.Show()
    End Sub
    Private Sub mnuProposers_View_AllProposers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProposers_View_AllProposers.Click
        Dim grd_Proposer As New grdProposer

        grd_Proposer.MdiParent = Me
        m_ChildFormNumber += 1
        grd_Proposer.lblForm_Flag.Text = "3"
        grd_Proposer.Show()
    End Sub
    Private Sub mnuProposers_View_VerifiedProposer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProposers_View_VerifiedProposer.Click
        Dim grd_Proposer As New grdProposer

        grd_Proposer.MdiParent = Me
        m_ChildFormNumber += 1
        grd_Proposer.lblForm_Flag.Text = "1"
        grd_Proposer.Show()
    End Sub
    Private Sub mnuProposers_Submission_List_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProposers_Submission_List.Click
        Dim grd_SubmittedProposers As New grdSubmitted_Proposers
        grd_SubmittedProposers.MdiParent = Me
        m_ChildFormNumber += 1
        grd_SubmittedProposers.Show()
    End Sub
    Private Sub xPortData()
        My.Computer.Clipboard.Clear()
        Dim RMonth As String = ""
        Dim SMonth As New dlgSelectMonth
        SMonth.Text = "PLS SELECT THE RECEIVING MONTH"
        If SMonth.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            RMonth = My.Computer.Clipboard.GetText
            If Len(RMonth.ToString.Trim) = 0 Then
                MsgBox("Receiving Month is blank, Please do rerun the report.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                My.Computer.Clipboard.Clear()
            End If
        End If
        Dim dt As New DataTable
        dt = _objBusi.getDetails("ANGKASA", RMonth.ToString.Trim, "", "", "", "MD", Conn)
        If dt.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            Dim G_TOT, AMT, TOT_AMT As Double
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PREMIUM COLLECTIONS - ANGKASA FOR CUEPACSCARE & CUEPACS PA MEMBERS"
                .Cells(2, 1) = "Receiving Month: " & RMonth.ToString.Trim

                .Cells(4, 1) = "Batch #"
                .Cells(4, 2) = "DEDUCTION MONTH"
                .Cells(4, 3) = "'0000"
                .Cells(4, 4) = "'0511"
                .Cells(4, 5) = "'0512"
                .Cells(4, 6) = "'0513"
                .Cells(4, 7) = "'0514"
                .Cells(4, 8) = "'0531"
                .Cells(4, 9) = "'0532"
                .Cells(4, 10) = "'0550"
                .Cells(4, 11) = "'0551"
                .Cells(4, 12) = "'0552"
                .Cells(4, 13) = "'0553"
                .Cells(4, 14) = "'0554"
                .Cells(4, 15) = "'0555"
                .Cells(4, 16) = "'0556"
                .Cells(4, 17) = "'0599"
                .Cells(4, 18) = "'9091"
                .Cells(4, 18) = "'6601"
                .Cells(4, 19) = "'TOTAL"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In dt.Rows
                    Dim BNO, OLDBNO, BP, BPOLD As String
                    BNO = dr("Angkasa_Batch_No").ToString.Trim()
                    If BNO <> OLDBNO Then
                        Dim dt1 As New DataTable
                        dt1 = _objBusi.getDetails("ANGKASA", dr("Angkasa_Batch_No").ToString.Trim(), "", "", "", "MD1", Conn)
                        BPOLD = ""
                        For Each dr1 As DataRow In dt1.Rows
                            BP = dr1("BULAN_POTONGAN").ToString.Trim()
                            If BP <> BPOLD Then
                                Dim dt2 As New DataTable
                                dt2 = _objBusi.getDetails("ANGKASA", dr1("BATCH_NO").ToString.Trim(), dr1("BULAN_POTONGAN").ToString.Trim(), "", "", "MD2", Conn)
                                For Each dr2 As DataRow In dt2.Rows
                                    .Cells(xRowCount, 1) = dr2("BATCH_NO").ToString.Trim()
                                    .Cells(xRowCount, 2) = dr2("BULAN_POTONGAN").ToString.Trim()
                                    Select Case dr2("KOD_POTONGAN").ToString.Trim()
                                        Case "0000"
                                            .Cells(xRowCount, 3) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0511"
                                            .Cells(xRowCount, 4) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0512"
                                            .Cells(xRowCount, 5) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0513"
                                            .Cells(xRowCount, 6) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0514"
                                            .Cells(xRowCount, 7) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0531"
                                            .Cells(xRowCount, 8) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0532"
                                            .Cells(xRowCount, 9) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0550"
                                            .Cells(xRowCount, 10) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0551"
                                            .Cells(xRowCount, 11) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0552"
                                            .Cells(xRowCount, 12) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0553"
                                            .Cells(xRowCount, 13) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0554"
                                            .Cells(xRowCount, 14) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0555"
                                            .Cells(xRowCount, 15) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0556"
                                            .Cells(xRowCount, 16) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "0599"
                                            .Cells(xRowCount, 17) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "9091"
                                            .Cells(xRowCount, 18) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                        Case "6601"
                                            .Cells(xRowCount, 18) = Format(dr2("JUMLAH_POKOK"), "Standard")
                                    End Select
                                    AMT = Format(dr2("JUMLAH_POKOK"), "Standard")
                                    TOT_AMT += AMT
                                    .Cells(xRowCount, 19) = Format(TOT_AMT, "Standard")
                                    AMT = 0
                                Next
                                BPOLD = BP
                                G_TOT += TOT_AMT
                                TOT_AMT = 0
                                xRowCount += 1
                            End If
                        Next
                        OLDBNO = BNO
                    End If
                Next
                .Cells(xRowCount + 1, 17) = "TOTAL"
                .Cells(xRowCount + 1, 19) = Format(G_TOT, "Standard")
            End With
            MsgBox("Exporting records to REIMBURSEMENT CLAIMS DECLINED CASES LISTING completed.")
            xApp.Visible = True
        Else
            MsgBox("No Record found")
        End If
    End Sub
    Private Sub mnuLogoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogoff.Click
        Dim Result As Integer
        Result = MsgBox("Do you want to logoff?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Logoff")
        Select Case Result
            Case 6
                Me.Close()
                Application.Exit()
            Case 7
                Exit Sub
        End Select
    End Sub
    Private Sub mnuMySettings_Change_Password_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMySettings_Change_Password.Click
        Dim dlg_Change_Password As New dlgUser_Change_Password
        dlg_Change_Password.ShowDialog()
    End Sub
    Private Sub mnuMySettings_Log_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMySettings_Log.Click
        Dim grd_Log As New grdLog_Login_Logoff

        grd_Log.MdiParent = Me
        m_ChildFormNumber += 1
        grd_Log.Show()
    End Sub
    Private Sub mnuMySettings_Log_Daily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMySettings_Log_Daily.Click
        Dim grd_DA As New grdLog_Daily_Activities

        grd_DA.MdiParent = Me
        m_ChildFormNumber += 1
        grd_DA.Show()
    End Sub
    Private Sub mSS_tsmiNewUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mSS_tsmiNewUsers.Click
        Dim fUsers As New fUserAccess
        fUsers.MdiParent = Me
        fUsers.Show()
    End Sub

    Private Sub mnuProposer_UWSubmission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProposer_UWSubmission.Click
        Dim UW As New UWCIMB
        UW.MdiParent = Me
        UW.Show()
    End Sub
    


    Private Sub mAdmin_Report_PolicyDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAdmin_Report_PolicyDetails.Click
        Dim xPD As New xPolicyDetails
        xPD.MdiParent = Me
        m_ChildFormNumber += 1
        xPD.Show()
    End Sub
    Private Sub XportOverAged()
        Dim _objBusi As New Business
        Dim dt As DataTable
        dt = _objBusi.getDetails("XPORTOVERAGED", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "OVER AGED MEMBER/SPOUSE DETAILS"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC #"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "DOB"
                .Cells(4, 5) = "AGE"
                .Cells(4, 6) = "DEDUCTION CODE"
                .Cells(4, 7) = "DEDUCTION AMOUNT"
                .Cells(4, 8) = "PLAN CODE"
                .Cells(4, 9) = "SPOUSE IC"
                .Cells(4, 10) = "SPOUSE FULL NAME"
                .Cells(4, 11) = "DOB"
                .Cells(4, 12) = "AGE"
                Dim xRowCount As Integer = 5
                For Each dr As DataRow In dt.Rows
                    Dim Age, Age1 As Integer
                    If Not IsDBNull(dr("BIRTH_DATE")) Then
                        Age = Math.Floor(DateDiff(DateInterval.Day, dr("BIRTH_DATE"), Now()) / 365.25)
                    End If
                    Dim dt1 As DataTable
                    dt1 = _objBusi.getDetails("XPORTOVERAGED", dr("ID").ToString.Trim(), "", "", "", "DEP", Conn)
                    If dt1.Rows.Count > 0 Then
                        If Not IsDBNull(dt1.Rows(0)("BIRTH_DATE")) Then
                            Age1 = Math.Floor(DateDiff(DateInterval.Day, dt1.Rows(0)("BIRTH_DATE"), Now()) / 365.25)
                        Else
                            Age1 = 0
                        End If
                        If (Age > 70) Or (Age1 > 70) Then
                            .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                            .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString()
                            .Cells(xRowCount, 3) = dr("FULL_NAME").ToString()
                            .Cells(xRowCount, 4) = "'" & dr("BIRTH_DATE").ToString()
                            .Cells(xRowCount, 5) = Age
                            .Cells(xRowCount, 6) = "'" & dr("DEDUCTION_CODE").ToString()
                            .Cells(xRowCount, 7) = FormatNumber(dr("DEDUCTION_AMOUNT").ToString())
                            .Cells(xRowCount, 8) = dr("PLAN_CODE").ToString()
                            .Cells(xRowCount, 9) = "'" & dt1.Rows(0)("IC_NEW").ToString().Trim()
                            .Cells(xRowCount, 10) = dt1.Rows(0)("FULL_NAME").ToString().Trim()
                            .Cells(xRowCount, 11) = "'" & dt1.Rows(0)("BIRTH_DATE").ToString().Trim()
                            .Cells(xRowCount, 12) = Age1
                            xRowCount += 1
                        End If
                    Else
                        If Age > 70 Then
                            .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                            .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString()
                            .Cells(xRowCount, 3) = dr("FULL_NAME").ToString()
                            .Cells(xRowCount, 4) = "'" & dr("BIRTH_DATE").ToString()
                            .Cells(xRowCount, 5) = Age
                            .Cells(xRowCount, 6) = "'" & dr("DEDUCTION_CODE").ToString()
                            .Cells(xRowCount, 7) = dr("DEDUCTION_AMOUNT").ToString()
                            .Cells(xRowCount, 8) = dr("PLAN_CODE").ToString()
                            If dt1.Rows.Count > 0 Then
                                .Cells(xRowCount, 9) = "'" & dt1.Rows(0)("IC_NEW").ToString().Trim()
                                .Cells(xRowCount, 10) = dt1.Rows(0)("FULL_NAME").ToString().Trim()
                                .Cells(xRowCount, 11) = "'" & dt1.Rows(0)("BIRTH_DATE").ToString().Trim()
                                .Cells(xRowCount, 12) = Age1
                            End If
                            xRowCount += 1
                        End If
                    End If
                Next
            End With
            MsgBox("Exporting records to SPOUSE DETAILS BLANK IC/DOB LISTING completed.")
            xApp.Visible = True
        End If
    End Sub
    Private Sub XportOverAgedChildrens()
        Dim _objBusi As New Business
        Dim dt As DataTable
        dt = _objBusi.getDetails("XPORTOVERAGED", "", "", "", "CHILD", "", Conn)
        If dt.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "OVER AGED Childrens DETAILS"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC #"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "DOB"
                .Cells(4, 5) = "AGE"
                .Cells(4, 6) = "DEDUCTION CODE"
                .Cells(4, 7) = "DEDUCTION AMOUNT"
                .Cells(4, 8) = "PLAN CODE"
                .Cells(4, 9) = "CHILDRENS IC"
                .Cells(4, 10) = "CHILDRENS FULL NAME"
                .Cells(4, 11) = "DOB"
                .Cells(4, 12) = "AGE"
                Dim xRowCount As Integer = 5
                For Each dr As DataRow In dt.Rows
                    Dim Age, Age1 As Integer
                    If Not IsDBNull(dr("BIRTH_DATE")) Then
                        Age = Math.Floor(DateDiff(DateInterval.Day, dr("BIRTH_DATE"), Now()) / 365.25)
                    End If
                    Dim dt1 As DataTable
                    dt1 = _objBusi.getDetails("XPORTOVERAGED", dr("ID").ToString.Trim(), "", "", "CHILD", "DEP", Conn)
                    If dt1.Rows.Count > 0 Then
                        If Not IsDBNull(dt1.Rows(0)("BIRTH_DATE")) Then
                            Age1 = Math.Floor(DateDiff(DateInterval.Day, dt1.Rows(0)("BIRTH_DATE"), Now()) / 365.25)
                        Else
                            Age1 = 0
                        End If
                        If Age1 > 23 Then
                            .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                            .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString()
                            .Cells(xRowCount, 3) = dr("FULL_NAME").ToString()
                            .Cells(xRowCount, 4) = "'" & dr("BIRTH_DATE").ToString()
                            .Cells(xRowCount, 5) = Age
                            .Cells(xRowCount, 6) = "'" & dr("DEDUCTION_CODE").ToString()
                            .Cells(xRowCount, 7) = FormatNumber(dr("DEDUCTION_AMOUNT").ToString())
                            .Cells(xRowCount, 8) = dr("PLAN_CODE").ToString()
                            .Cells(xRowCount, 9) = "'" & dt1.Rows(0)("IC_NEW").ToString().Trim()
                            .Cells(xRowCount, 10) = dt1.Rows(0)("FULL_NAME").ToString().Trim()
                            .Cells(xRowCount, 11) = "'" & dt1.Rows(0)("BIRTH_DATE").ToString().Trim()
                            .Cells(xRowCount, 12) = Age1
                            xRowCount += 1
                        End If
                    End If
                Next
            End With
            MsgBox("Exporting records to SPOUSE DETAILS BLANK IC/DOB LISTING completed.")
            xApp.Visible = True
        End If
    End Sub
    Private Sub getFollowUP()
        MsgBox("Starting the export process...", MsgBoxStyle.Information)
        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
        xls_workbook = xls_file.Workbooks.Add
        Dim cmdSelect_Proposers_1U1D As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Proposers_1U1D.CommandType = CommandType.Text
        cmdSelect_Proposers_1U1D.CommandText = "SELECT Full_Name, IC_New, Plan_Code, Level2_Plan_Code, Phone_Hse, Phone_Mobile, Phone_Off, " & _
                                               "Department, Proposal_Received_Date, Verified_On, A.Status,a.DECLINE_REASON, B.AGENT_CODE, C.AGENT_NAME " & _
                                               "FROM dt_Proposer A INNER JOIN DT_PROPOSER_AGENT_COMMISSION B ON A.ID=B.PROPOSER_ID  " & _
                                               "INNER JOIN TB_AGENT C ON B.AGENT_CODE=C.AGENT_CODE " & _
                                               "WHERE (A.Status='1R') " & _
                                               "ORDER BY A.Status, Verified_On"
        Dim da_AllProposers_1U1D As New SqlDataAdapter(cmdSelect_Proposers_1U1D)
        Dim ds_Proposers As New DataSet
        da_AllProposers_1U1D.Fill(ds_Proposers, "dt_Proposer")

        Dim var_name_count As Integer = 0
        Dim xls_wks_name As String = ""
        Dim xls_row_counter As Integer = 4

        Dim var_Status As String = ""

        Do While var_name_count < ds_Proposers.Tables("dt_Proposer").Rows.Count
            With ds_Proposers.Tables("dt_Proposer").Rows(var_name_count)
                If var_Status <> .Item("Status").ToString.Trim Then
                    xls_workbook.Worksheets.Add()

                    xls_wks_name = "Sheet" & (xls_workbook.Worksheets.Count).ToString.Trim
                    With xls_workbook.Worksheets(xls_wks_name)
                        .Cells(1, 1) = "Followup Listing on Proposers (Status: Reject[1R])"

                        .Columns(1).NumberFormat = "@"
                        .Columns(2).NumberFormat = "@"
                        .Columns(3).NumberFormat = "@"
                        .Columns(4).NumberFormat = "@"
                        .columns(5).NumberFormat = "@"
                        .columns(6).NumberFormat = "@"
                        .Columns(7).NumberFormat = "@"
                        .Columns(8).NumberFormat = "@"
                        .Columns(9).NumberFormat = "@"
                        .Columns(10).NumberFormat = "dd/MM/yyyy"
                        .Columns(11).NumberFormat = "dd/MM/yyyy"
                        .Columns(12).NumberFormat = "@"

                        .Cells(3, 1) = "No."
                        .Cells(3, 2) = "Full Name"
                        .Cells(3, 3) = "IC"
                        .Cells(3, 4) = "PLAN CODE"
                        .Cells(3, 5) = "PLAN "
                        .Cells(3, 6) = "PHONE (House)"
                        .Cells(3, 7) = "PHONE (Mobile)"
                        .Cells(3, 8) = "PHONE (Office)"
                        .Cells(3, 9) = "DEPARTMENT"
                        .Cells(3, 10) = "PROPOSAL RECEIVED DATE"
                        .Cells(3, 11) = "PROPOSAL VERIFIED DATE"
                        .Cells(3, 12) = "CURRENT PROPOSAL STATUS"
                        .Cells(3, 13) = "DECLINE REASON"
                        .Cells(3, 14) = "AGENT CODE"
                        .Cells(3, 15) = "AGENT NAME"

                    End With

                    var_Status = .Item("Status").ToString.Trim
                    xls_row_counter = 4
                End If

                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = (xls_row_counter - 3).ToString & "."
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = .Item("Full_Name").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = .Item("IC_New").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = .Item("Plan_Code").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = .Item("Level2_Plan_Code").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = .Item("Phone_Hse").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = .Item("Phone_Mobile").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 8) = .Item("Phone_Off").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 9) = .Item("Department").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 10) = .Item("Proposal_Received_Date")
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 11) = .Item("Verified_On")
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 12) = .Item("Status").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 13) = .Item("Decline_Reason").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 14) = .Item("AGENT_CODE").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 15) = .Item("AGENT_NAME").ToString.Trim
            End With

            xls_row_counter += 1
            var_name_count += 1
        Loop
        MsgBox("Exporting records to Followup Listing (Reject) completed.")
        xls_file.Visible = True
    End Sub
    Private Sub mProposer_Letters_Acknowledgement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_Letters_Acknowledgement.Click
        Dim PL As New pLetter
        PL.lblType.Text = "1A"
        PL.MdiParent = Me
        PL.Show()
    End Sub
    Private Sub mProposer_Letters_Deferment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_Letters_Deferment.Click
        Dim PL As New pLetter
        PL.lblType.Text = "1D"
        PL.MdiParent = Me
        PL.Show()
    End Sub
    Private Sub mProposer_Letters_Reject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_Letters_Reject.Click
        Dim PL As New pLetter
        PL.lblType.Text = "1R"
        PL.MdiParent = Me
        PL.Show()
    End Sub
    Private Sub mProposer_Letters_Underwriting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_Letters_Underwriting.Click
        Dim PL As New pLetter
        PL.lblType.Text = "1U"
        PL.MdiParent = Me
        PL.Show()
    End Sub
    Private Sub mnuProposers_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProposers_New.Click
        'Dim frm_Proposer_New As New Proposer
        Dim frm_Proposer_New As New New_Proposer
        frm_Proposer_New.MdiParent = Me
        m_ChildFormNumber += 1
        frm_Proposer_New.lblForm_Flag.Text = "N"
        frm_Proposer_New.Show()
    End Sub
    Private Sub mProposer_SendMail_Acknowledgement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_SendMail_Acknowledgement.Click
        Dim fsMail As New fsMail
        fsMail.MdiParent = Me
        m_ChildFormNumber += 1
        fsMail.lblType.Text = "ACKNOWLEDGEMENT"
        fsMail.Show()
    End Sub
    Private Sub mProposer_SendMail_Incomplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_SendMail_Incomplete.Click
        Dim fsMail As New fsMail
        fsMail.MdiParent = Me
        m_ChildFormNumber += 1
        fsMail.lblType.Text = "INCOMPLETE"
        fsMail.Show()
    End Sub
    
    Private Sub mCS_ViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_ViewAll.Click
        Dim CS As New fvCS
        CS.MdiParent = Me
        m_ChildFormNumber += 1
        CS.Show()
    End Sub
    Private Sub mMember_Download_BlankAddresses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Download_BlankAddresses.Click
        Dim grd_BLANK_Address_Template_Export As New grdBLANK_Address_Template_Export
        grd_BLANK_Address_Template_Export.MdiParent = Me
        grd_BLANK_Address_Template_Export.Show()
    End Sub
    Private Sub mMember_UploadToolStripMenuItem_BlankAddresses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Upload_Addresses.Click
        Dim grd_BLANK_Address_Template_Import As New grdBLANK_Address_Template_Import

        grd_BLANK_Address_Template_Import.MdiParent = Me
        grd_BLANK_Address_Template_Import.Show()
    End Sub
    Private Sub mMember_Download_ExportBlankICDOBPHONE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Download_ExportBlankICDOBPHONE.Click
        Dim fXB As New XportBlank
        fXB.MdiParent = Me
        m_ChildFormNumber += 1
        fXB.Show()
    End Sub
    Private Sub mMember_Upload_ClientNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Upload_ClientNo.Click
        Dim UCID As New fUploadCID
        UCID.MdiParent = Me
        UCID.Show()
    End Sub
    Private Sub mMember_Upload_ICDOBPHONE_Member_DOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Upload_ICDOBPHONE_Member_DOB.Click
        Dim fIB As New ImportBlank
        fIB.MdiParent = Me
        m_ChildFormNumber += 1
        fIB.lblType.Text = "MEMBER"
        fIB.lblUType.Text = "DOB"
        fIB.Show()
    End Sub
    Private Sub mMember_Upload_ICDOBPHONE_Member_PHONE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Upload_ICDOBPHONE_Member_PHONE.Click
        Dim fIB As New ImportBlank
        fIB.MdiParent = Me
        m_ChildFormNumber += 1
        fIB.lblType.Text = "MEMBER"
        fIB.lblUType.Text = "PHONE"
        fIB.Show()
    End Sub
    Private Sub mMember_Upload_ICDOBPHONE_Spouse_IC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Upload_ICDOBPHONE_Spouse_IC.Click
        Dim fIB As New ImportBlank
        fIB.MdiParent = Me
        m_ChildFormNumber += 1
        fIB.lblType.Text = "SPOUSE"
        fIB.lblUType.Text = "IC"
        fIB.Show()
    End Sub
    Private Sub mMember_Upload_ICDOBPHONE_Spouse_DOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Upload_ICDOBPHONE_Spouse_DOB.Click
        Dim fIB As New ImportBlank
        fIB.MdiParent = Me
        m_ChildFormNumber += 1
        fIB.lblType.Text = "SPOUSE"
        fIB.lblUType.Text = "DOB"
        fIB.Show()
    End Sub
    Private Sub mMember_Upload_ICDOBPHONE_Child_DOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Upload_ICDOBPHONE_Child_DOB.Click
        Dim fIB As New ImportBlank
        fIB.MdiParent = Me
        m_ChildFormNumber += 1
        fIB.lblType.Text = "DEP"
        fIB.lblUType.Text = "DOB"
        fIB.Show()
    End Sub
    Private Sub mMember_Upload_ICDOBPHONE_Child_IC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Upload_ICDOBPHONE_Child_IC.Click
        Dim fIB As New ImportBlank
        fIB.MdiParent = Me
        m_ChildFormNumber += 1
        fIB.lblType.Text = "DEP"
        fIB.lblUType.Text = "IC"
        fIB.Show()
    End Sub
    Private Sub mProposer_Reports_Production_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_Reports_Production.Click
        Dim PS As New rPSummary
        PS.MdiParent = Me
        PS.Show()
    End Sub
    
    Private Sub mPremium_ViewMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_ViewMember.Click
        Dim CS As New fvCS
        CS.MdiParent = Me
        m_ChildFormNumber += 1
        CS.Show()
    End Sub
    Private Sub mCS_YearlyRenewal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_YearlyRenewal.Click
        Dim dlg_Premium_Renewal_Yearly As New dlgPremium_Renewal
        dlg_Premium_Renewal_Yearly.MdiParent = Me
        m_ChildFormNumber += 1
        dlg_Premium_Renewal_Yearly.Show()
    End Sub
    Private Sub mCS_Endorsement_ChangePostalAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_Endorsement_ChangePostalAddress.Click
        Dim dlg_Endosement As New dlgEndosement_PostalAddress
        dlg_Endosement.MdiParent = Me
        m_ChildFormNumber += 1
        dlg_Endosement.Show()
    End Sub
    Private Sub mCS_Endorsement_ChangePersonalDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_Endorsement_ChangePersonalDetails.Click
        Dim dlg_Endosement As New dlgEndosement_PersonalDetails
        dlg_Endosement.MdiParent = Me
        m_ChildFormNumber += 1
        dlg_Endosement.Show()
    End Sub
    Private Sub mCS_Endorsement_Dependents_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_Endorsement_Dependents_Add.Click
        Dim Add_Dependant As New Add_Dependant_New
        Add_Dependant.MdiParent = Me
        Add_Dependant.Show()
    End Sub
    Private Sub mCS_Endorsement_Dependents_ViewEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_Endorsement_Dependents_ViewEdit.Click
        Dim Dependant As New Dependant
        Dependant.MdiParent = Me
        Dependant.Show()
    End Sub
    Private Sub mCS_Endorsement_Nominee_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_Endorsement_Nominee_Add.Click
        Dim Search_Member As New Search_Member
        Search_Member.MdiParent = Me
        Search_Member.Show()
    End Sub

    Private Sub mCS_Endorsement_Nominee_ViewEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_Endorsement_Nominee_ViewEdit.Click
        Dim searchNominee As New searchNominee
        searchNominee.MdiParent = Me
        searchNominee.Show()
    End Sub
    Private Sub mCS_Endorsement_EC_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_Endorsement_EC_Add.Click
        Dim dgvMemberDetails As New dgvMemberDetails
        dgvMemberDetails.MdiParent = Me
        dgvMemberDetails.Show()
    End Sub

    Private Sub mCS_Endorsement_EC_ViewEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_Endorsement_EC_ViewEdit.Click
        Dim viewExclusion_Clause As New viewExclusion_Clause
        viewExclusion_Clause.MdiParent = Me
        viewExclusion_Clause.Show()
    End Sub
    Private Sub mAdmin_ReinstatePolicy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAdmin_ReinstatePolicy.Click
        Dim dlg_Endosement As New dlgEndosement_Reinstate
        dlg_Endosement.MdiParent = Me
        m_ChildFormNumber += 1
        dlg_Endosement.Show()
    End Sub
    Private Sub mSS_Insurer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mSS_Insurer.Click
        Dim insurer As New Insurer
        insurer.MdiParent = Me
        insurer.Show()
    End Sub
    Private Sub mSS_Product_PName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mSS_Product_PName.Click
        Dim Product_Plan_Type As New Product_Plan_Type
        Product_Plan_Type.MdiParent = Me
        Product_Plan_Type.Show()
    End Sub
    Private Sub mSS_Product_PType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mSS_Product_PType.Click
        Dim Product_type As New Product_type
        Product_type.MdiParent = Me
        Product_type.Show()
    End Sub
    Private Sub mSS_Product_PlanType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mSS_Product_PlanType.Click
        Dim Plan_Type As New Plan_Type
        Plan_Type.MdiParent = Me
        Plan_Type.Show()
    End Sub
    Private Sub mSS_Product_PremiumTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mSS_Product_PremiumTable.Click
        Dim tbPremium As New PremiumTable
        tbPremium.MdiParent = Me
        tbPremium.Show()
    End Sub
    Private Sub mSS_Product_PaymentMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mSS_Product_PaymentMode.Click
        Dim Premium_Type As New Premium_Type
        Premium_Type.MdiParent = Me
        Premium_Type.Show()
    End Sub
    Private Sub mSS_Product_PSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mSS_Product_PSetup.Click
        Dim Product As New Product_Setup
        Product.MdiParent = Me
        Product.Show()
    End Sub
    Private Sub mSS_Agent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mSS_Agent.Click
        Dim Agent As New Agent
        Agent.MdiParent = Me
        Agent.Show()
    End Sub
    
    Private Sub mCS_Reports_SubmissiontoInsurer_YearlyRenewCases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim grd_Report_Submission2Insurer_Renewal As New grdReport_Submission2Insurer_Yearly_Renewal
        grd_Report_Submission2Insurer_Renewal.MdiParent = Me
        grd_Report_Submission2Insurer_Renewal.Show()

    End Sub
    

    Private Sub mPremium_Reports_SubmissionToInurer_Monthly_NewListing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_Reports_SubmissionToInurer_Monthly_NewListing.Click
        My.Computer.Clipboard.Clear()
        Dim receiving_month As String = ""
        Dim var_effective_month As Short
        Dim var_effective_year As Short
        Dim var_effective_date As String

        Dim rcvMonthd As New dlgSelectMonth
        rcvMonthd.Text = "PLS SELECT THE RECEIVING MONTH"

        If rcvMonthd.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            Dim iData As IDataObject = Clipboard.GetDataObject()
            If iData.GetDataPresent(DataFormats.Text) Then
                receiving_month = CType(iData.GetData(DataFormats.Text), String)
            Else
                MsgBox("Could not retrieve data off the clipboard.")
            End If
            If Len(receiving_month.ToString.Trim) = 0 Then
                MsgBox("Receiving Month is blank, please do rerun the report.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                var_effective_month = Val(receiving_month.Substring(4, 2)) + 1
                var_effective_year = Val(receiving_month.Substring(0, 4))

                If var_effective_month = 13 Then
                    var_effective_year += 1
                    var_effective_month = 1
                End If

                var_effective_date = Str(var_effective_year) & "/" & Str(var_effective_month) & "/15"

                My.Computer.Clipboard.Clear()
            End If
        End If

        MsgBox("Starting the export process...", MsgBoxStyle.Information)

        Dim xls_file As New Microsoft.Office.Interop.Excel.Application
        Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

        xls_workbook = xls_file.Workbooks.Add


        Dim cmdSelect_Angkasa_Monthly_NewCases As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Angkasa_Monthly_NewCases.CommandType = CommandType.Text
        cmdSelect_Angkasa_Monthly_NewCases.CommandText = "SELECT Angkasa_FileNo, Full_Name, IC_New, Deduction_Code, Deduction_Amount, Effective_Date " & _
                                                         "FROM  vi_Member_Policy_v2 " & _
                                                         "WHERE (Effective_Date = '" & var_effective_date & " ') and deduction_code not like 'Y%' " & _
                                                         "ORDER BY Deduction_Code, Full_Name, IC_New"


        Dim da_Selected_Monthly_NewCases As New SqlDataAdapter(cmdSelect_Angkasa_Monthly_NewCases)


        Dim ds_InsurerReport As New DataSet

        da_Selected_Monthly_NewCases.Fill(ds_InsurerReport, "vi_Member_Policy_v2")

        Dim var_count As Integer = 0
        Dim xls_wks_name As String = ""
        Dim xls_row_counter As Integer = 6

        Dim var_Deduction_Code As String = ""

        Do While var_count < ds_InsurerReport.Tables("vi_Member_Policy_v2").Rows.Count
            With ds_InsurerReport.Tables("vi_Member_Policy_v2").Rows(var_count)
                If var_Deduction_Code <> .Item("Deduction_Code").ToString.Trim Then
                    xls_workbook.Worksheets.Add()
                    Dim Ac_Desc, strDeduction_code As String
                    strDeduction_code = .Item("Deduction_Code").ToString.Trim
                    Select Case strDeduction_code
                        Case "0531", "0532", "0511", "0512"
                            Ac_Desc = "CUEPACSCARE A/C CODE: GI2074 (ANGKASA A/C)"
                        Case "0550", "0551", "0513", "0514"
                            Ac_Desc = "CUEPACS PA A/C CODE: GI2078 (ANGKASA A/C)"
                        Case "1531", "1532"
                            Ac_Desc = "CUEPACSCARE A/C CODE: GI2075 (FAMA A/C)"
                        Case "2531", "2532"
                            Ac_Desc = "CUEPACSCARE A/C CODE: GI2076 (SIRIM A/C)"
                        Case "9531", "9532"
                            Ac_Desc = "CUEPACSCARE A/C CODE: GI2077 (OTHERS A/C)"
                        Case "9550", "9551"
                            Ac_Desc = "CUEPACS PA A/C CODE: GI2788 (OTHERS A/C)"
                    End Select

                    xls_wks_name = "Sheet" & (xls_workbook.Worksheets.Count).ToString.Trim
                    With xls_workbook.Worksheets(xls_wks_name)
                        .Cells(1, 1) = "SUBMISSION OF NEW PROPOSALS TO SUN LIFE MALAYSIA TAKAFUL BERHAD"
                        .Cells(2, 1) = Ac_Desc
                        .Cells(3, 1) = "FOR THE MONTH RECEIVED DEDUCTION: " & receiving_month.Trim
                        .Cells(5, 1) = "No."
                        .Cells(5, 2) = "Proposer's Name"
                        .Cells(5, 3) = "Proposer's IC"
                        .Cells(5, 4) = "File No."
                        .Cells(5, 5) = "Deduction Code"
                        .Cells(5, 6) = "Deduction Amount"
                        .Cells(5, 7) = "Plan"
                        .Cells(5, 8) = "Effective Date"

                        .Columns(1).NumberFormat = "@"
                        .Columns(2).NumberFormat = "@"
                        .Columns(3).NumberFormat = "@"
                        .Columns(4).NumberFormat = "@"
                        .Columns(5).NumberFormat = "@"
                        .Columns(6).NumberFormat = "###,##0.00"
                        .Columns(7).NumberFormat = "@"
                        .Columns(8).NumberFormat = "dd/MM/yyyy"
                    End With

                    var_Deduction_Code = .Item("Deduction_Code").ToString.Trim
                    xls_row_counter = 6
                End If

                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = (xls_row_counter - 5).ToString.Trim & "."
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = .Item("Full_Name").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = .Item("IC_New").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = .Item("Angkasa_FileNo").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & .Item("Deduction_Code").ToString.Trim
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = .Item("Deduction_Amount").ToString.Trim
                Select Case .Item("Deduction_Code").ToString.Trim
                    Case "0531", "0511", "1531", "2531", "9531"
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "EMPLOYEE AND FAMILY ONLY"
                    Case "0532", "0512", "1532", "2532", "9532"
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "EMPLOYEE ONLY"
                    Case "0550", "0513", "9550"
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "CUEPACS PA PLAN A"
                    Case "0551", "0514", "9551"
                        xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "CUEPACS PA PLAN B"
                End Select
                xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 8) = .Item("Effective_Date")
            End With

            xls_row_counter += 1
            var_count += 1
        Loop

        MsgBox("Exporting records to Submission of New Proposals to Sun Life Malaysia Takaful Berhad completed.")
        xls_file.Visible = True
    End Sub
    Private Sub mPremium_Reports_SubmissionToInurer_Monthly_PolicyPrinting_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_Reports_SubmissionToInurer_Monthly_PolicyPrinting_New.Click
        Dim grd_Report_Insurer_PolicyPrinting_Monthly As New grdReport_Insurer_PolicyPrinting_Monthly
        grd_Report_Insurer_PolicyPrinting_Monthly.MdiParent = Me
        grd_Report_Insurer_PolicyPrinting_Monthly.Show()
    End Sub
    Private Sub mPremium_Reports_SubmissionToInurer_Yearly_PolicyPrinting_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_Reports_SubmissionToInurer_Yearly_PolicyPrinting_New.Click
        Dim grd_Report_Insurer_PolicyPrinting_Yearly As New grdReport_Insurer_PolicyPrinting_Yearly
        grd_Report_Insurer_PolicyPrinting_Yearly.MdiParent = Me
        grd_Report_Insurer_PolicyPrinting_Yearly.Show()
    End Sub
    Private Sub mPremium_Reports_SubmissionToInurer_Yearly_PolicyPrinting_Renewal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_Reports_SubmissionToInurer_Yearly_PolicyPrinting_Renewal.Click
        Dim grd_Report_Insurer_PolicyPrinting_Yearly_Renewal As New grdReport_Insurer_PolicyPrinting_Yearly_Renewal
        grd_Report_Insurer_PolicyPrinting_Yearly_Renewal.MdiParent = Me
        grd_Report_Insurer_PolicyPrinting_Yearly_Renewal.Show()
    End Sub
    
    
    Private Sub mCS_Endorsement_ViewEditMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_Endorsement_ViewEditMember.Click
        Dim searchMember As New searchMember
        searchMember.MdiParent = Me
        searchMember.Show()
    End Sub
    Private Sub mProposer_View_Members_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_View_Members.Click
        Dim CS As New fvCS
        CS.MdiParent = Me
        m_ChildFormNumber += 1
        CS.Show()
    End Sub
    Private Sub mMember_Download_ClientNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Download_ClientNo.Click
        XPort2XcelCID()
    End Sub
    Private Sub XPort2XcelCID()
        Dim dt As New DataTable
        Dim _objBusi As New Business
        dt = _objBusi.getDetails_I("CLIENTNO", "", "", "", "", "", "", "", "", "", "BLANKCID", Conn)
        If dt.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "CIMB Data for Client ID"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "REF ID"
                .Cells(4, 3) = "CLIENT NO"
                .Cells(4, 4) = "MEMBER IC"
                .Cells(4, 5) = "MEMBER NAME"
                .Cells(4, 6) = "MEM / DEP IC"
                .Cells(4, 7) = "MEM / DEP NAME"
                .Cells(4, 8) = "DOB"
                .Cells(4, 9) = "FAMILY UNIT"
                .Cells(4, 10) = "CERTIFICATE NO"
                .Cells(4, 11) = "EFFECTIVE DATE"
                .Cells(4, 12) = "EXPIRY DATE"
                .Cells(4, 13) = "AC CODE"
                .Cells(4, 14) = "FILE NO"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                For Each dr As DataRow In dt.Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("REFID")
                    .Cells(xRowCount, 3) = "'" & dr("CLIENTNO")
                    .Cells(xRowCount, 4) = "'" & dr("IC")
                    .Cells(xRowCount, 5) = "'" & dr("FULLNAME")
                    .Cells(xRowCount, 6) = "'" & dr("MEMDEPIC")
                    .Cells(xRowCount, 7) = "'" & dr("MEMDEPNAME")
                    .Cells(xRowCount, 8) = "'" & dr("DOB")
                    .Cells(xRowCount, 9) = "'" & dr("FAMILYUNIT")
                    .Cells(xRowCount, 10) = "'" & dr("CERTIFICATENO")
                    .Cells(xRowCount, 11) = "'" & dr("EFFECTIVEDATE")
                    .Cells(xRowCount, 12) = "'" & dr("EXPIRYDATE")
                    .Cells(xRowCount, 13) = "'" & dr("ACCODE")
                    .Cells(xRowCount, 14) = "'" & dr("FILENO")
                    xRowCount += 1
                Next
            End With
            MsgBox("Exporting records to REPORT: CIMB DATA for Client Number")
            xApp.Visible = True
        End If
    End Sub
    Private Sub mProposer_Report_ProductionByStaff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_Report_ProductionByStaff.Click
        Dim SA As New rSA
        SA.MdiParent = Me
        m_ChildFormNumber += 1
        SA.Show()
    End Sub
    Private Sub mPremium_PrintLetters_PI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_PrintLetters_PI.Click
        Dim PP As New PrintPremium
        PP.MdiParent = Me
        m_ChildFormNumber += 1
        PP.lblType.Text = "PI"
        PP.Show()
    End Sub
    Private Sub mPremium_PrintLetters_PD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_PrintLetters_PD.Click
        Dim PP As New PrintPremium
        PP.MdiParent = Me
        m_ChildFormNumber += 1
        PP.lblType.Text = "PD"
        PP.Show()
    End Sub
    Private Sub mPremium_PL_PrintLetters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_PL_PrintLetters.Click
        Dim viewLetters As New viewLetters
        viewLetters.MdiParent = Me
        viewLetters.lblLetterID.Text = ""
        viewLetters.lblATYPE.Text = "PREMIUM"
        viewLetters.Show()
    End Sub
    Private Sub StaffActivityReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StaffActivityReportToolStripMenuItem.Click
        Dim fStaffDetails As New fReports
        fStaffDetails.MdiParent = Me
        fStaffDetails.Show()
    End Sub
    Private Sub SIRIMToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fUMD As New UMD
        fUMD.MdiParent = Me
        fUMD.lblUMDType.Text = "SIRIM"
        fUMD.Show()
    End Sub
    Private Sub FAMAToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fUMD As New UMD
        fUMD.MdiParent = Me
        fUMD.lblUMDType.Text = "FAMA"
        fUMD.Show()
    End Sub
    Private Sub OthersToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fUMD As New UMD
        fUMD.MdiParent = Me
        fUMD.lblUMDType.Text = "OTHERS"
        fUMD.Show()
    End Sub
    Private Sub mPremium_UnRSFFollowUp_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rRSF As New rRecoverShortFall
        rRSF.MdiParent = Me
        m_ChildFormNumber += 1S
        rRSF.lblREF1.Text = "NEW"
        rRSF.Show()
    End Sub
    Private Sub mPremium_UnRSFFollowUp_Old_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rRSF As New rRecoverShortFall
        rRSF.MdiParent = Me
        m_ChildFormNumber += 1S
        rRSF.lblREF1.Text = "OLD"
        rRSF.Show()
    End Sub
    Private Sub mPremium_UnRecoverSFFU_Others_FAMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rRSF As New rRecoverShortFall
        rRSF.MdiParent = Me
        m_ChildFormNumber += 1S
        rRSF.lblREF1.Text = "FAMA"
        rRSF.Show()
    End Sub
    Private Sub mPremium_UnRecoverSFFU_Others_SIRIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rRSF As New rRecoverShortFall
        rRSF.MdiParent = Me
        m_ChildFormNumber += 1S
        rRSF.lblREF1.Text = "SIRIM"
        rRSF.Show()
    End Sub
    Private Sub ShortPaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim YSFR As New rYShortfallReport
        YSFR.MdiParent = Me
        YSFR.lblREF1.Text = "NONP"
        YSFR.Show()
    End Sub
    Private Sub ShortPaymentToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim YSFR As New rYShortfallReport
        YSFR.MdiParent = Me
        YSFR.lblREF1.Text = "SHORTFALL"
        YSFR.Show()
    End Sub
    Private Sub NewPremiumNotReceivedFromDeductionAgencyMonthlyCasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim grd_Report_Premium_Not_ReceivedFrAgency_Monthly As New grdReport_Premium_Not_ReceivedFrAgency_Monthly
        grd_Report_Premium_Not_ReceivedFrAgency_Monthly.MdiParent = Me
        grd_Report_Premium_Not_ReceivedFrAgency_Monthly.Show()
    End Sub
    Private Sub RecoveredShortfallsDeductionCode0599ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim grd_Report_Recovered_ShortFalls_0599 As New grdReport_Recovered_ShortFalls_0599
        grd_Report_Recovered_ShortFalls_0599.MdiParent = Me
        grd_Report_Recovered_ShortFalls_0599.Show()
    End Sub
    
    Private Sub mProposer_Submission_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_Submission_New.Click
        Dim fVP As New fVerifiedProposers
        fVP.MdiParent = Me
        m_ChildFormNumber += 1
        fVP.Show()
    End Sub
    Private Sub mCS_PrintLetter_PrintLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_PrintLetter_PrintLetter.Click
        Dim viewLetters As New viewLetters
        viewLetters.MdiParent = Me
        viewLetters.lblLetterID.Text = ""
        viewLetters.lblATYPE.Text = "PREMIUM"
        viewLetters.Show()
    End Sub
    Private Sub mSystemSettings_RevisePremium_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mSystemSettings_RevisePremium.Click
        Dim fRP As New fRevisePremium
        fRP.MdiParent = Me
        m_ChildFormNumber += 1
        fRP.Show()
    End Sub
    Private Sub mCS_ActiveAgentList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_ActiveAgentList.Click
        Dim vA As New vAgent
        vA.MdiParent = Me
        m_ChildFormNumber += 1
        vA.Show()
    End Sub
   
    Private Sub MRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MRToolStripMenuItem.Click
        Dim fIPP As New fInsurarPremiumPayment
        fIPP.MdiParent = Me
        m_ChildFormNumber += 1S
        fIPP.Show()
    End Sub
    
    Private Sub mMember_Upload_PolicyCertificateNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMember_Upload_PolicyCertificateNo.Click
        Dim grd_BLANK_PolicyNo_Template_Import As New grdBLANK_PolicyNo_Template_Import
        grd_BLANK_PolicyNo_Template_Import.MdiParent = Me
        grd_BLANK_PolicyNo_Template_Import.lblRQS1.Text = "NEW"
        grd_BLANK_PolicyNo_Template_Import.Show()
    End Sub
    Private Sub mMember_Download_BlankPolicyNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim grd_BLANK_PolicyNo_Template_Export As New grdBLANK_PolicyNo_Template_Export
        grd_BLANK_PolicyNo_Template_Export.MdiParent = Me
        grd_BLANK_PolicyNo_Template_Export.lblRQS1.Text = "NEW"
        grd_BLANK_PolicyNo_Template_Export.Show()
    End Sub
    
    Private Sub mAdmin_ChangeRequestDeductionAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dlg_Endosement As New dlgEndosement_RequestedAmount
        dlg_Endosement.MdiParent = Me
        m_ChildFormNumber += 1
        dlg_Endosement.Show()
    End Sub
    Private Sub mCS_PrintLetters_RePrintyearlyRenewal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_PrintLetters_RePrintyearlyRenewal.Click
        Dim viewLetters As New viewLetters
        viewLetters.MdiParent = Me
        viewLetters.lblLetterID.Text = ""
        viewLetters.lblATYPE.Text = "CS"
        viewLetters.Show()
    End Sub
    Private Sub mProposer_Report_Pending_Incomplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_Report_Pending_Incomplete.Click
        Dim rP As New rPending
        rP.MdiParent = Me
        rP.lblRTYPE.Text = "INCOMPLETE"
        rP.Show()
    End Sub
    Private Sub mProposer_Report_Pending_UW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_Report_Pending_UW.Click
        Dim rP As New rPending
        rP.MdiParent = Me
        rP.lblRTYPE.Text = "UW"
        rP.Show()
    End Sub
    Private Sub mProposer_Report_Pending_Deduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_Report_Pending_Deduction.Click
        Dim rP As New rPending
        rP.MdiParent = Me
        rP.lblRTYPE.Text = "DEDUCTION"
        rP.Show()
    End Sub
    Private Sub mProposer_Report_Pending_Rejected60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mProposer_Report_Pending_Rejected60.Click
        Dim rP As New rPending
        rP.MdiParent = Me
        rP.lblRTYPE.Text = "REJECTED60"
        rP.Show()
    End Sub
    Private Sub EXPORTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SIXport2Xcel()
    End Sub
    Private Sub SIXport2Xcel()
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        'EVENT PLACE
        
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWNAME As String = ""
        Dim i As Integer = 0
        Dim rCount As Integer = 0
        Dim xlRCount As Integer = 6
        Dim dtPolicy As New DataTable
        xWB.Worksheets.Add()
        xWNAME = "Sheet" & xWB.Worksheets.Count.ToString.Trim

        With xWB.Worksheets(xWNAME)
            .Cells(1, 1) = "SUBMISSION"
            .Cells(2, 1) = "Attn : "
            .Cells(3, 1) = "Exported On : " & Now()

            .Cells(5, 1) = "NO"
            .Cells(5, 2) = "FULL NAME"
            .Cells(5, 3) = "POLICY NO"
            .Cells(5, 4) = "IC"
            .Cells(5, 5) = "ADD1"
            .Cells(5, 6) = "ADD2"
            .Cells(5, 7) = "ADD3"
            .Cells(5, 8) = "ADD4"
            .Cells(5, 9) = "ADD5"
            .Cells(5, 10) = "START DATE"
            .Cells(5, 11) = "END DATE"
            .Cells(5, 12) = "PLAN TYPE"
            .Cells(5, 13) = "DEDUCTION CODE"
            .Cells(5, 14) = "JAN"
            .Cells(5, 15) = "FEB"
            .Cells(5, 16) = "MAR"
            .Cells(5, 17) = "APR"
            .Cells(5, 18) = "MAY"
            .Cells(5, 19) = "JUN"
            .Cells(5, 20) = "JUL"
            .Cells(5, 21) = "AUG"
            .Cells(5, 22) = "SEP"
            .Cells(5, 23) = "OCT"
            .Cells(5, 24) = "NOV"
            .Cells(5, 25) = "DEC"

            Dim dt As New DataTable
            dt = _objBusi.getDetails_II("CUEPACSCARE", "", "", "", "", "", "", "", "", "", "", Conn)
            For Each dr As DataRow In dt.Rows

                .Cells(xlRCount, 1) = (xlRCount - 5).ToString.Trim
                .Cells(xlRCount, 2) = dr("full_name").ToString.Trim()
                .Cells(xlRCount, 3) = dr("new_policy_no").ToString.Trim()
                .Cells(xlRCount, 4) = dr("ic_new").ToString.Trim()
                .Cells(xlRCount, 5) = dr("add1").ToString.Trim()
                .Cells(xlRCount, 6) = dr("add2").ToString.Trim()
                .Cells(xlRCount, 7) = dr("ADD3").ToString.Trim()
                .Cells(xlRCount, 8) = dr("add4").ToString.Trim()
                .Cells(xlRCount, 9) = dr("add5").ToString.Trim()
                .Cells(xlRCount, 10) = dr("effective_date").ToString.Trim()
                .Cells(xlRCount, 11) = dr("cancellation_date").ToString.Trim()
                .Cells(xlRCount, 12) = dr("LEVEL2_PLAN_CODE").ToString.Trim()
                .Cells(xlRCount, 13) = dr("deduction_code").ToString.Trim()
                .Cells(xlRCount, 14) = dr("M1").ToString.Trim()
                .Cells(xlRCount, 15) = dr("M2").ToString.Trim()
                .Cells(xlRCount, 16) = dr("M3").ToString.Trim()
                .Cells(xlRCount, 17) = dr("M4").ToString.Trim()
                .Cells(xlRCount, 18) = dr("M5").ToString.Trim()
                .Cells(xlRCount, 19) = dr("M6").ToString.Trim()
                .Cells(xlRCount, 20) = dr("M7").ToString.Trim()
                .Cells(xlRCount, 21) = dr("M8").ToString.Trim()
                .Cells(xlRCount, 22) = dr("M9").ToString.Trim()
                .Cells(xlRCount, 23) = dr("M10").ToString.Trim()
                .Cells(xlRCount, 24) = dr("M11").ToString.Trim()
                .Cells(xlRCount, 25) = dr("M12").ToString.Trim()
                xlRCount += 1
            Next
        End With
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        xApp.Visible = True
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
    Private Sub ByMonthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub ByDurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub UploadToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fMID As New fMemberIDUP
        fMID.MdiParent = Me
        m_ChildFormNumber += 1
        fMID.Show()
    End Sub
    

    Private Sub GSTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fSF As New frmShortFallfollowup
        fSF.MdiParent = Me
        fSF.lblREF1.Text = "GST"
        m_ChildFormNumber += 1S
        fSF.Show()
    End Sub
    Private Sub CuepacsCareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fPPI As New fPolicyPremiumIncrease
        fPPI.MdiParent = Me
        fPPI.lblRTYPE.Text = "CC"
        m_ChildFormNumber += 1S
        fPPI.Show()
    End Sub
    Private Sub CuepacsPAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fPPI As New fPolicyPremiumIncrease
        fPPI.MdiParent = Me
        fPPI.lblRTYPE.Text = "CPA"
        m_ChildFormNumber += 1S
        fPPI.Show()
    End Sub
    Private Sub mTeleMarketing_FollowUp_Telephone_Incomplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTeleMarketing_FollowUp_Telephone_Incomplete.Click
        Dim CS As New fCS_New
        CS.MdiParent = Me
        CS.lblREFTYPE.Text = "1D"
        CS.lblTYPE.Text = "PROPOSER"
        CS.Text = "Follow up Incomplete"
        m_ChildFormNumber += 1
        CS.Show()
    End Sub
    Private Sub mTeleMarketing_FollowUp_Telephone_UW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTeleMarketing_FollowUp_Telephone_UW.Click
        Dim CS As New fCS_New
        CS.MdiParent = Me
        CS.lblREFTYPE.Text = "1U"
        CS.lblTYPE.Text = "PROPOSER"
        CS.Text = "Follow up Underwriting"
        m_ChildFormNumber += 1
        CS.Show()
    End Sub
    Private Sub mTeleMarketing_FollowUp_Telephone_PendingRenewal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTeleMarketing_FollowUp_Telephone_PendingRenewal.Click
        Dim CS As New fCS_New
        CS.MdiParent = Me
        CS.lblREFTYPE.Text = "PENDING RENEWAL"
        CS.lblTYPE.Text = "MEMBER"
        CS.Text = "Follow up Pending Renewal"
        m_ChildFormNumber += 1
        CS.Show()
    End Sub

    Private Sub mTeleMarketing_FollowUp_SMS_Incomplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTeleMarketing_FollowUp_SMS_Incomplete.Click
        Dim SMS As New fSMS
        SMS.MdiParent = Me
        SMS.lblRF1.Text = "1D"
        m_ChildFormNumber += 1S
        SMS.Show()
    End Sub

    Private Sub mTeleMarketing_FollowUp_SMS_UW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTeleMarketing_FollowUp_SMS_UW.Click
        Dim SMS As New fSMS
        SMS.MdiParent = Me
        SMS.lblRF1.Text = "1U"
        m_ChildFormNumber += 1S
        SMS.Show()
    End Sub
    Private Sub mTeleMarketing_FollowUp_SMS_CompletedProposal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTeleMarketing_FollowUp_SMS_CompletedProposal.Click
        Dim SMS As New fSMS
        SMS.MdiParent = Me
        SMS.lblRF1.Text = "1A"
        m_ChildFormNumber += 1S
        SMS.Show()
    End Sub
    Private Sub mTeleMarketing_FollowUp_SMS_YearlyPendingRenewal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTeleMarketing_FollowUp_SMS_YearlyPendingRenewal.Click
        Dim SMS As New fSMS
        SMS.MdiParent = Me
        SMS.lblRF1.Text = "YPR"
        m_ChildFormNumber += 1S
        SMS.Show()
    End Sub
    Private Sub mTeleMarketing_Reports_Renewal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTeleMarketing_Reports_Renewal.Click
        Dim YRFS As New YrFollowupSummary
        YRFS.MdiParent = Me
        m_ChildFormNumber += 1
        YRFS.Show()
    End Sub
    Private Sub mCS_SubmissionToInsurer_Endorsement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_SubmissionToInsurer_Endorsement.Click
        Dim ES As New fEndorsSubmission
        ES.MdiParent = Me
        ES.lblREFNO.Text = "E"
        ES.Show()
    End Sub
    Private Sub mCS_SubmissionToInsurer_YearlyRenewalPending_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_SubmissionToInsurer_YearlyRenewalPending.Click
        Dim Renewal_Yr_Submission As New Renewal_Yr_Submission
        Renewal_Yr_Submission.MdiParent = Me
        Renewal_Yr_Submission.Show()
    End Sub

    Private Sub mAgencyServices_AgentCommission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAgencyServices_AgentCommission.Click
        Dim AC As New vAgent_Commission
        AC.MdiParent = Me
        m_ChildFormNumber += 1
        AC.Show()
    End Sub

    Private Sub mAgencyServices_AgentProductionSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAgencyServices_AgentProductionSummary.Click
        Dim CS As New vProReportbyAgent
        CS.MdiParent = Me
        m_ChildFormNumber += 1
        CS.Show()
    End Sub
    Private Sub mFinance_AgentCommissionSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mFinance_AgentCommissionSummary.Click
        Dim fAC As New AgentComSum
        fAC.MdiParent = Me
        m_ChildFormNumber += 1S
        fAC.Show()
    End Sub

    Private Sub RenewalListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCS_Reports_RenewalListing.Click
        Dim xRL As New xRenewalListing
        xRL.MdiParent = Me
        m_ChildFormNumber += 1
        xRL.Show()
    End Sub
    Private Sub OthersToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OthersToolStripMenuItem3.Click
        Dim grd_Template_Export As New grdTemplate_Export
        grd_Template_Export.lblType.Text = ""
        grd_Template_Export.MdiParent = Me
        grd_Template_Export.Show()
    End Sub

    Private Sub AngkasaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AngkasaToolStripMenuItem.Click
        Dim grd_AngkasaDeduction As New grdAngkasaDeduction
        grd_AngkasaDeduction.MdiParent = Me
        m_ChildFormNumber += 1
        grd_AngkasaDeduction.Show()
    End Sub
    Private Sub OthersToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OthersToolStripMenuItem4.Click
        Dim fUMD As New UMD
        fUMD.MdiParent = Me
        fUMD.lblUMDType.Text = "OTHERS"
        fUMD.Show()
    End Sub
    Private Sub NonPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fNP As New frmNonPayment
        fNP.MdiParent = Me
        m_ChildFormNumber += 1
        fNP.Show()
    End Sub

    Private Sub ShortfallToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fSF As New fShortFall
        fSF.MdiParent = Me
        fSF.lblREFTYPE.Text = "P"
        m_ChildFormNumber += 1S
        fSF.Show()
    End Sub

    Private Sub PaymentExceptionsProcessesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentExceptionsProcessesToolStripMenuItem1.Click
        Dim f279 As New fBorang2_79
        f279.MdiParent = Me
        m_ChildFormNumber += 1S
        f279.Show()
    End Sub
    Private Sub CancellationToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancellationToolStripMenuItem2.Click
        Dim dlg_Endosement As New dlgEndosement_Cancellation
        dlg_Endosement.MdiParent = Me
        m_ChildFormNumber += 1
        dlg_Endosement.Show()
    End Sub

    Private Sub MemberSpouse70ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemberSpouse70ToolStripMenuItem.Click
        XportOverAged()
    End Sub

    Private Sub Childrens23ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Childrens23ToolStripMenuItem1.Click
        XportOverAgedChildrens()
    End Sub

    Private Sub ReportPremiumCollectionsAngkasaByReceivingMonthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PolicyCancellationListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PolicyCancellationListingToolStripMenuItem.Click
        Dim rCP As New rCancelledPolicy
        rCP.MdiParent = Me
        m_ChildFormNumber += 1
        rCP.Show()
    End Sub

    Private Sub PolicyDetailsOthersToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fNP As New NonPaymentPlanCodes
        fNP.lblREF1.Text = "POLICYDETAILS"
        fNP.MdiParent = Me
        m_ChildFormNumber += 1
        fNP.Show()
    End Sub

    Private Sub CPAToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CPAToolStripMenuItem2.Click
        Dim frmPSR As New PremiumSummaryReport
        frmPSR.MdiParent = Me
        frmPSR.Show()
    End Sub
    Private Sub CCToolStripMenuItem3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CCToolStripMenuItem3.Click
        Dim frmPSR As New ccPremiumSummaryReport
        frmPSR.MdiParent = Me
        frmPSR.Show()
    End Sub

    

    Private Sub DependentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DependentToolStripMenuItem.Click
        Dim Add_Dependant As New Add_Dependant_New
        Add_Dependant.MdiParent = Me
        Add_Dependant.lblAdmin.Text = "Admin"
        Add_Dependant.Show()
    End Sub

    Private Sub NomineeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NomineeToolStripMenuItem.Click
        Dim Search_Member As New Search_Member
        Search_Member.MdiParent = Me
        Search_Member.lblAdmin.Text = "Admin"
        Search_Member.Show()
    End Sub

    Private Sub ExclusionClauseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExclusionClauseToolStripMenuItem.Click
        Dim dgvMemberDetails As New dgvMemberDetails
        dgvMemberDetails.MdiParent = Me
        dgvMemberDetails.lblAdmin.Text = "Admin"
        dgvMemberDetails.Show()
    End Sub
    Private Sub MemberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAdmin_DEE_VE_Member.Click
        Dim searchMember As New searchMember
        searchMember.MdiParent = Me
        searchMember.Show()
    End Sub

    Private Sub DependentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DependentsToolStripMenuItem.Click
        Dim aDep As New Dependant
        aDep.MdiParent = Me
        aDep.lblAdmin.Text = "Admin"
        aDep.Show()
    End Sub

    Private Sub NomineeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NomineeToolStripMenuItem1.Click
        Dim sNominee As New searchNominee
        sNominee.MdiParent = Me
        sNominee.lblAdmin.Text = "Admin"
        sNominee.Show()
    End Sub

    Private Sub ExclusionClauseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExclusionClauseToolStripMenuItem1.Click
        Dim EClause As New viewExclusion_Clause
        EClause.MdiParent = Me
        EClause.lblAdmin.Text = "Admin"
        EClause.Show()
    End Sub

    Private Sub MemberPolicyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemberPolicyToolStripMenuItem1.Click
        Dim Mem As New searchMember
        Mem.MdiParent = Me
        Mem.lblParam.Text = "MP"
        Mem.Show()
    End Sub

    Private Sub PolicyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PolicyToolStripMenuItem.Click
        Dim Policy As New fPolicy
        Policy.MdiParent = Me
        Policy.lblAdmin.Text = "Admin"
        Policy.Show()
    End Sub
    Private Sub mAgencyServices_AgentCommissionSentEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAgencyServices_AgentCommissionSentEmail.Click
        Dim fAC As New fAgentComission
        fAC.MdiParent = Me
        m_ChildFormNumber += 1S
        fAC.Show()
    End Sub
    Private Sub mPremium_ChangeOfPlanCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_ChangeOfPlanCode.Click
        Dim dlg_Endosement As New dlgEndosement_L2_Plan_Code
        dlg_Endosement.MdiParent = Me
        m_ChildFormNumber += 1
        dlg_Endosement.Show()
    End Sub
    Private Sub mTeleMarketing_Followup_ShortFalls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fSF As New ftShortfall
        fSF.MdiParent = Me
        m_ChildFormNumber += 1S
        fSF.Show()
    End Sub
    Private Sub mTeleMarketing_Followup_NonPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fNP As New frmPendingPremiumTM
        fNP.MdiParent = Me
        fNP.lblREFTYPE.Text = "TM"
        m_ChildFormNumber += 1
        fNP.Show()
    End Sub
    Private Sub mF_Reports_Yearly_ByMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mF_Reports_Yearly_ByMonth.Click
        Dim fYPD As New fYearlyPoliciesDetails
        fYPD.MdiParent = Me
        fYPD.Show()
    End Sub
    Private Sub mF_Reports_Yearly_ByDuration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mF_Reports_Yearly_ByDuration.Click
        Dim fYPD As New rYP
        fYPD.MdiParent = Me
        fYPD.Show()
    End Sub
    Private Sub mF_PremiumRequestYearlyOthers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mF_PremiumRequestYearlyOthers.Click
        Dim YRP As New fYrInvoice
        YRP.MdiParent = Me
        m_ChildFormNumber += 1
        YRP.Show()
       
    End Sub
    Private Sub mF_PremiumUpdateYearlyOthers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mF_PremiumUpdateYearlyOthers.Click
        Dim YRP As New fYrPremiumRenewal
        YRP.MdiParent = Me
        m_ChildFormNumber += 1
        YRP.Show()
       
    End Sub
    Private Sub mF_PremiumCollectionsAngkasa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mF_PremiumCollectionsAngkasa.Click
        xPortData()
    End Sub
    Private Sub mPremium_InvoiceListingOthers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_InvoiceListingOthers.Click
        Dim fNP As New NonPaymentPlanCodes
        fNP.lblREF1.Text = "POLICYDETAILS"
        fNP.MdiParent = Me
        m_ChildFormNumber += 1
        fNP.Show()
    End Sub
    Private Sub mTM_ViewAllPolicyHolders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTM_ViewAllPolicyHolders.Click
        Dim CS As New fvCS
        CS.MdiParent = Me
        m_ChildFormNumber += 1
        CS.Show()
    End Sub
    Private Sub mTM_ViewAllAgents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTM_ViewAllAgents.Click
        Dim vA As New vAgent
        vA.MdiParent = Me
        m_ChildFormNumber += 1
        vA.Show()
    End Sub
    Private Sub mTM_Reports_FollowupListingReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        getFollowUP()
    End Sub
    Private Sub mPremium_Increase_CC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_Increase_CC.Click
        Dim fPPI As New fPI
        fPPI.MdiParent = Me
        fPPI.lblRTYPE.Text = "PI"
        fPPI.lblRTYPE1.Text = "CC"
        m_ChildFormNumber += 1
        fPPI.Show()
    End Sub
    Private Sub mPremium_Increase_CPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_Increase_CPA.Click
        Dim fPPI As New fPI
        fPPI.MdiParent = Me
        fPPI.lblRTYPE.Text = "PI"
        fPPI.lblRTYPE1.Text = "CPA"
        m_ChildFormNumber += 1
        fPPI.Show()
    End Sub
    Private Sub mPremium_Decrease_CPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_Decrease_CPA.Click
        Dim fPPI As New fPI
        fPPI.MdiParent = Me
        fPPI.lblRTYPE.Text = "PD"
        fPPI.lblRTYPE1.Text = "CPA"
        m_ChildFormNumber += 1
        fPPI.Show()
    End Sub
    Private Sub mFinance_NonPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fNP As New frmPendingPremium
        fNP.MdiParent = Me
        fNP.lblREFTYPE.Text = "FINANCE"
        m_ChildFormNumber += 1
        fNP.Show()
    End Sub

    Private Sub ShortFallsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShortFallsToolStripMenuItem.Click
        Dim SMS As New fSMS
        SMS.MdiParent = Me
        SMS.lblRF1.Text = "SHORTFALLS"
        m_ChildFormNumber += 1S
        SMS.Show()
       
    End Sub
    Private Sub ShortFalls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fSF As New ffShortFall
        fSF.MdiParent = Me
        m_ChildFormNumber += 1S
        fSF.Show()
    End Sub
    Private Sub PendingCancellationListingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendingCancellationListingToolStripMenuItem1.Click
        Dim fSF As New fPendingCancellationListing
        fSF.MdiParent = Me
        m_ChildFormNumber += 1S
        fSF.Show()
    End Sub

    Private Sub SentSMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SentSMSToolStripMenuItem.Click
        Dim fSF As New fSentSMS
        fSF.MdiParent = Me
        m_ChildFormNumber += 1S
        fSF.Show()
    End Sub
    Private Sub ShortfallRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fSFR As New frmShortfallRequest
        fSFR.MdiParent = Me
        m_ChildFormNumber += 1S
        fSFR.Show()
    End Sub
    Private Sub RequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RequestToolStripMenuItem.Click
        Dim fCR As New fClientRequest
        fCR.MdiParent = Me
        m_ChildFormNumber += 1S
        fCR.Show()
    End Sub
    Private Sub SubmitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitToolStripMenuItem.Click
        Dim fCR As New fClientRequestSubmission
        fCR.MdiParent = Me
        m_ChildFormNumber += 1S
        fCR.Show()
    End Sub
    Private Sub mPremium_PL_Retirees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_PL_Retirees.Click
        Dim fR As New fRetirees
        fR.MdiParent = Me
        m_ChildFormNumber += 1S
        fR.Show()
    End Sub
    Private Sub PaymentSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentSummaryToolStripMenuItem.Click
        Dim fPS As New fPaymentSummary
        fPS.MdiParent = Me
        m_ChildFormNumber += 1S
        fPS.Show()
    End Sub
    Private Sub AgentRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgentRequestToolStripMenuItem.Click
        Dim fAR As New fAgentRequest
        fAR.MdiParent = Me
        m_ChildFormNumber += 1S
        fAR.Show()
    End Sub
    Private Sub IncomplToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncomplToolStripMenuItem.Click
        Dim fSR As New rSummaryReports
        fSR.MdiParent = Me
        m_ChildFormNumber += 1S
        fSR.lblSTYPE.Text = "SIN"
        fSR.Show()
    End Sub
    Private Sub UnderwritingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderwritingToolStripMenuItem1.Click
        Dim fSR As New rSummaryReports
        fSR.MdiParent = Me
        m_ChildFormNumber += 1S
        fSR.lblSTYPE.Text = "SUW"
        fSR.Show()
    End Sub
    Private Sub NonPaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NonPaymentToolStripMenuItem1.Click
        Dim SMS As New fSMS
        SMS.MdiParent = Me
        SMS.lblRF1.Text = "NONPAYMENT"
        m_ChildFormNumber += 1S
        SMS.Show()
    End Sub

    Private Sub AgentRequestDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgentRequestDetailsToolStripMenuItem.Click
        Dim fSR As New rAgentRequestDetails
        fSR.MdiParent = Me
        m_ChildFormNumber += 1S
        fSR.Show()
    End Sub
    
    Private Sub NonPaymentToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fSR As New rSummaryReports
        fSR.MdiParent = Me
        m_ChildFormNumber += 1S
        fSR.lblSTYPE.Text = "SNP"
        fSR.Show()
    End Sub
    Private Sub ShortFallsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fSR As New rSummaryReports
        fSR.MdiParent = Me
        m_ChildFormNumber += 1S
        fSR.lblSTYPE.Text = "SSF"
        fSR.Show()
    End Sub
    Private Sub RetireesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetireesToolStripMenuItem.Click
        Dim fSR As New rSummaryReports
        fSR.MdiParent = Me
        m_ChildFormNumber += 1S
        fSR.lblSTYPE.Text = "SRETIREES"
        fSR.Show()
    End Sub
    Private Sub OutStandingPremiumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutStandingPremiumToolStripMenuItem.Click
        Dim fR As New fRetirees
        fR.MdiParent = Me
        m_ChildFormNumber += 1S
        fR.lblRTYPE.Text = "OSA"
        fR.Show()
    End Sub
    Private Sub MemberIDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim PMID As New xPortMemberID
        PMID.MdiParent = Me
        m_ChildFormNumber += 1S
        PMID.Show()
    End Sub
    Private Sub SFNNPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SFNNPToolStripMenuItem.Click
        Dim fNPNSF As New fNonPaymentnShortFall
        fNPNSF.MdiParent = Me
        m_ChildFormNumber += 1S
        fNPNSF.Show()
    End Sub
    Private Sub ReUploadDocToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReUploadDocToolStripMenuItem.Click
        Dim fRUPI As New fReUpPI
        fRUPI.MdiParent = Me
        m_ChildFormNumber += 1S
        fRUPI.Show()
    End Sub
    Private Sub mPremium_Reports_NonPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPremium_Reports_NonPayment.Click
        Dim fNP As New frmrNonPayment
        fNP.MdiParent = Me
        m_ChildFormNumber += 1S
        fNP.Show()
    End Sub

    Private Sub SFNNPRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SFNNPRequestToolStripMenuItem.Click
        Dim fNP As New fSFnNPR
        fNP.MdiParent = Me
        fNP.lblP1.Text = "PREMIUM"
        m_ChildFormNumber += 1S
        fNP.Show()
    End Sub
    Private Sub SFNNPToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SFNNPToolStripMenuItem1.Click
        Dim fNP As New fSFnNPCall
        fNP.MdiParent = Me
        fNP.lblP1.Text = "CALL"
        m_ChildFormNumber += 1S
        fNP.Show()
    End Sub

    Private Sub FileMoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileMoveToolStripMenuItem.Click
        Dim fNP As New fFilesMove
        fNP.MdiParent = Me
        m_ChildFormNumber += 1S
        fNP.Show()
    End Sub
    Private Sub SFNNPToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SFNNPToolStripMenuItem2.Click
        Dim fSF As New ffShortFall
        fSF.MdiParent = Me
        fSF.lblP1.Text = "FINANCE"
        m_ChildFormNumber += 1S
        fSF.Show()
    End Sub
    Private Sub tsPDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPDS.Click
        Dim fSR As New fPendingDedSum
        fSR.MdiParent = Me
        fSR.lblP1.Text = "PDS"
        m_ChildFormNumber += 1S
        fSR.Show()
    End Sub
    Private Sub tsSS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSS.Click
        Dim fSR As New fPendingDedSum
        fSR.MdiParent = Me
        fSR.lblP1.Text = "SS"
        m_ChildFormNumber += 1S
        fSR.Show()
    End Sub
    Private Sub NewCasesSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewCasesSummaryToolStripMenuItem.Click
        Dim fSR As New fPendingDedSum
        fSR.MdiParent = Me
        fSR.lblP1.Text = "NCS"
        m_ChildFormNumber += 1S
        fSR.Show()

    End Sub
    Private Sub ExistinToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExistinToolStripMenuItem.Click
        Dim fSR As New fPendingDedSum
        fSR.MdiParent = Me
        fSR.lblP1.Text = "EPS"
        m_ChildFormNumber += 1S
        fSR.Show()
    End Sub
    Private Sub CancellationSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancellationSummaryToolStripMenuItem.Click
        Dim fSR As New frmCancelSum
        fSR.MdiParent = Me
        fSR.lblP1.Text = "CS"
        m_ChildFormNumber += 1S
        fSR.Show()
    End Sub
    Private Sub EndorsementSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndorsementSummaryToolStripMenuItem.Click
        Dim fSR As New frmEndorSum
        fSR.MdiParent = Me
        fSR.lblP1.Text = "ES"
        m_ChildFormNumber += 1S
        fSR.Show()
    End Sub
    Private Sub Below60YearsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Below60YearsToolStripMenuItem.Click
        Dim CS As New fCS_New
        CS.MdiParent = Me
        CS.lblREFTYPE.Text = "RETIREES"
        CS.lblTYPE.Text = "MEMBER"
        CS.Text = "Follow up Retirees"
        m_ChildFormNumber += 1
        CS.Show()
    End Sub
    Private Sub Above60YearsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Above60YearsToolStripMenuItem.Click
        Dim fR As New frmRetirees
        fR.MdiParent = Me
        m_ChildFormNumber += 1S
        fR.Show()
    End Sub
    Private Sub RetireesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetireesToolStripMenuItem1.Click
        Dim fRC As New frmRCancel
        fRC.MdiParent = Me
        m_ChildFormNumber += 1S
        fRC.Show()
    End Sub
    Private Sub InstantProcessToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstantProcessToolStripMenuItem.Click
        Dim fDB As New femdb
        fDB.MdiParent = Me
        m_ChildFormNumber += 1S
        fDB.Show()
    End Sub
    Private Sub DocumentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentsToolStripMenuItem.Click
        Dim fUD As New fUpDocs
        fUD.MdiParent = Me
        m_ChildFormNumber += 1S
        fUD.Show()
    End Sub

    Private Sub DocumentsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentsToolStripMenuItem1.Click
        Dim fUD As New fUpDocs
        fUD.MdiParent = Me
        m_ChildFormNumber += 1S
        fUD.Show()
    End Sub
End Class