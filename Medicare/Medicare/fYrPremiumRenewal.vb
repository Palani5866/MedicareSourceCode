Imports System.IO
Public Class fYrPremiumRenewal
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Private Sub fYrPremiumRenewal_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fYrPremiumRenewal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
            If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                Dim sFileToUpload As String = ""
                sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                Me.txtBrowse.Text = sFileToUpload
            Else
                MsgBox("File Requied")
                Exit Sub
            End If
        End Using
    End Sub
    Private Function GetOpenFileDialog() As OpenFileDialog
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.CheckPathExists = True
        openFileDialog.CheckFileExists = True
        openFileDialog.Filter = "xls files (*.xls)|*.xls"
        openFileDialog.Multiselect = False
        openFileDialog.AddExtension = True
        openFileDialog.ValidateNames = True
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Return openFileDialog
    End Function
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.txtNoofPolicies.Text.ToString.Trim() = "" Then
            MsgBox("Please key in No Policies would like to Renew!")
            Exit Sub
        End If
        If Me.txtReceivedPremium.Text.ToString.Trim() = "" Then
            MsgBox("Please key in Received Premium would like to Renew!")
            Exit Sub
        End If
        fYRPremiumRenewal()
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
    Public Shared Function BindData(ByVal SourceFilePath As String) As DataTable
        Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & SourceFilePath & ";Extended Properties=Excel 8.0;"
        Using cn As New OleDb.OleDbConnection(ConnectionString)
            cn.Open()
            Dim dbSchema As DataTable = cn.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)
            If dbSchema Is Nothing OrElse dbSchema.Rows.Count < 1 Then
                Throw New Exception("Error: Could not determine the name of the first worksheet.")
            End If
            Dim WorkSheetName As String = dbSchema.Rows(0)("TABLE_NAME").ToString()
            Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [" & WorkSheetName & "] ", cn)
            Dim dt As New DataTable(WorkSheetName)
            da.Fill(dt)
            Return dt
        End Using
    End Function
    Private Function fYRPremiumRenewal() As String
        If Me.txtBrowse.Text.Trim() = "" Then
            MsgBox("Required file")
            Exit Function
        End If
        If Me.txtChequeNo.Text.Trim() = "" Then
            MsgBox("Please key in the cheque number!")
            Exit Function
        End If
        If Me.txtChequeReceiptNo.Text.Trim() = "" Then
            MsgBox("Please key in the receipt no")
            Exit Function
        End If
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim dt As New DataTable
        dt = BindData(Me.txtBrowse.Text)
        Dim iRowCount As Integer = 0
        Dim iuRowCount As Integer = 0
        iRowCount = dt.Rows.Count
        iuRowCount = Me.txtNoofPolicies.Text
        If Not iuRowCount = iRowCount Then
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            MsgBox("No of Policies doesnot matching! Please check it!")
            Me.txtNoofPolicies.Focus()
            Exit Function
        End If
        Dim sRes As String
        Dim iTotalPremium As Double
        
        Dim iCount As Integer = 0
        Dim dm As String = ""
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWName As String = ""
        xWB.Worksheets.Add()
        xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

        With xWB.Worksheets(xWName)
            .Cells(1, 1) = "UPLOADING YEARLY PREMIUM RENEWAL"
            .Cells(2, 1) = "TOTAL NO OF POLICIES : " & Me.txtNoofPolicies.Text.ToString.Trim()
            .Cells(3, 1) = "TOTAL RECEIVED PREMIUM : " & FormatNumber(Me.txtReceivedPremium.Text.ToString.Trim(), 2)
            .Cells(4, 1) = "UPLOADED ON : " & Now()

            .Cells(6, 1) = "NO"
            .Cells(6, 2) = "FILE NO"
            .Cells(6, 3) = "FULL NAME"
            .Cells(6, 4) = "IC"
            .Cells(6, 5) = "PLAN CODE"
            .Cells(6, 6) = "PREMIUM"
            .Cells(6, 7) = "RENEWAL STATUS"
            .Cells(6, 8) = "Remarks"
        End With
        Dim rCount As Integer = 0
        Dim xRowCount As Integer = 7
        Dim certM, MemIC, MemName As String
        For Each dr As DataRow In dt.Rows
            If iCount >= 0 Then
                xWB.Worksheets(xWName).Cells(xRowCount, 1) = "'" & (xRowCount - 6).ToString.Trim
                xWB.Worksheets(xWName).Cells(xRowCount, 2) = "'" & dr(0)
                xWB.Worksheets(xWName).Cells(xRowCount, 3) = "'" & dr(1)
                xWB.Worksheets(xWName).Cells(xRowCount, 4) = "'" & dr(2)
                xWB.Worksheets(xWName).Cells(xRowCount, 5) = "'" & dr(3)
                xWB.Worksheets(xWName).Cells(xRowCount, 6) = "'" & dr(4)
                If YearlyRenewal(dr(1), dr(0)) Then
                    sRes = "DONE"
                Else
                    sRes = "Reason One of Below : <br> 1). Sorry can't process. This Policy has been lapse or Your not authorized to do this. Please check with your admin. <br> 2). Sorry can't process. This Policy has been renewed <br> 3: Sorry can't process. This policy has been lapse!. Please check with administrator <br> 4.Sorry can't process. This policy renewal period closed. Please contact administrator <br> 5.Error in renewal this policy"
                End If
                xWB.Worksheets(xWName).Cells(xRowCount, 7) = "'" & sRes
                xWB.Worksheets(xWName).Cells(xRowCount, 8) = ""
            End If
            xRowCount += 1
            iCount += 1
            rCount += 1
        Next
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        MsgBox("No of Record : " & rCount & " Sucessfuly Uploaded")
        Me.txtBrowse.Text = ""
        Me.Close()
        xApp.Visible = True
    End Function
    Private Function YearlyRenewal(ByVal IC As String, ByVal FILENO As String) As Boolean
        Dim PID, Premium As String
        Dim dt As New DataTable
        dt = _ObjBusi.getDetails_VI("YEARLY", IC, FILENO, "", "", "", "", "", "", "", "", Conn)

        PID = dt.Rows(0)("PID").ToString.Trim()
        Premium = FormatNumber(dt.Rows(0)("PREMIUM").ToString.Trim(), 2)

        Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy.CommandType = CommandType.Text
        cmdSelect_MemberPolicy.CommandText = "SELECT * FROM dt_Member_Policy " & _
                                             "WHERE ID = '" & PID & "'"
        Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)

        Dim cmdInsert_MemberPolicy As SqlCommandBuilder
        cmdInsert_MemberPolicy = New SqlCommandBuilder(da_MemberPolicy)



        Dim cmdSelect_MemberPolicy_YearlyRenewal As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy_YearlyRenewal.CommandType = CommandType.Text
        cmdSelect_MemberPolicy_YearlyRenewal.CommandText = "SELECT * FROM dt_Member_Policy_YearlyRenewal " & _
                                                        "WHERE Member_Policy_ID = '" & PID & "'"
        Dim da_MemberPolicy_YearlyRenewal As New SqlDataAdapter(cmdSelect_MemberPolicy_YearlyRenewal)

        Dim cmdInsert_MemberPolicy_YearlyRenewal As SqlCommandBuilder
        cmdInsert_MemberPolicy_YearlyRenewal = New SqlCommandBuilder(da_MemberPolicy_YearlyRenewal)



        Dim cmdSelect_MemberLog As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberLog.CommandType = CommandType.Text
        cmdSelect_MemberLog.CommandText = "SELECT * FROM log_Member " & _
                                          "WHERE Member_Policy_ID = '" & PID & "'"
        Dim da_MemberLog As New SqlDataAdapter(cmdSelect_MemberLog)

        Dim cmdInsert_MemberLog As SqlCommandBuilder
        cmdInsert_MemberLog = New SqlCommandBuilder(da_MemberLog)

        Dim ds_Renewal As New DataSet


        Try
            da_MemberPolicy.Fill(ds_Renewal, "dt_Member_Policy")
            da_MemberPolicy_YearlyRenewal.Fill(ds_Renewal, "dt_Member_Policy_YearlyRenewal")
            da_MemberLog.Fill(ds_Renewal, "log_Member")
            If ds_Renewal.Tables("dt_member_policy").Rows(0)("status").ToString.Trim() = "Lapse" Then
                Select Case My.Settings.Username.Trim()
                    Case "admin"
                    Case Else

                        Exit Function
                End Select
            End If
            Dim eDate, pNextRenewal As String
            Dim cYear, nextYear, pYear, pMonth, cMonth1 As Integer
            cMonth1 = Now.Month()
            If cMonth1 = 12 Then
                nextYear = Now.Year() + 2
                cYear = Now.Year() + 1
            ElseIf cMonth1 = 11 Then
                nextYear = Now.Year() + 2
                cYear = Now.Year()
            Else
                nextYear = Now.Year() + 1
                cYear = Now.Year()
            End If
            Dim cY, nY, pY As String
            cY = cYear
            nY = nextYear
            pY = pYear
            If Not IsDBNull(ds_Renewal.Tables("dt_member_policy").Rows(0)("Cancellation_Date")) Then
                eDate = ds_Renewal.Tables("dt_member_policy").Rows(0)("Cancellation_Date")
                pYear = Year(eDate)
                pMonth = Month(eDate)
                pNextRenewal = DateAdd(DateInterval.Month, -3, Convert.ToDateTime(eDate))
                If pYear = nextYear Then

                    Exit Function
                Else
                    Dim exDate, exYear1, exMonth1 As String
                    Dim exYear, exMonth, cMonth, RSM As Integer
                    If pMonth <= cMonth1 Then
                        exDate = DateAdd(DateInterval.Day, +60, Convert.ToDateTime(eDate))
                    Else
                        exDate = eDate
                    End If
                    exYear = Year(exDate)
                    If Now.Month() = 12 Then
                        exMonth = 13
                    Else
                        exMonth = Month(exDate)
                    End If
                    cMonth = Now.Month()
                    exYear1 = exYear
                    exMonth1 = exMonth

                    Dim SRI, RenewalStartMonth, RSM1, RSY As String
                    If Not (My.Settings.Username = "admin") Then
                        RSY = Year(DateAdd(DateInterval.Month, -6, Convert.ToDateTime(eDate)))
                        RenewalStartMonth = DateAdd(DateInterval.Month, -6, Convert.ToDateTime(eDate))
                        RSM = Month(DateAdd(DateInterval.Month, -6, Convert.ToDateTime(eDate)))
                        RSM1 = cMonth
                        If exYear = nextYear And cMonth <> 11 Then

                            Exit Function
                        ElseIf exYear < cYear And exMonth <> 12 Then
                            
                            Exit Function
                        ElseIf exMonth < cMonth And cMonth <> 11 Then
                            If ds_Renewal.Tables("dt_Member_Policy").Rows(0)("Status") = "Lapse" Then

                                Exit Function
                            End If
                        ElseIf exYear = RSY And cMonth < RSM And RSY >= cYear Then

                            Exit Function
                        Else

                            With ds_Renewal.Tables("dt_Member_Policy").Rows(0)
                                If IsDBNull(.Item("Cancellation_Date")) Then
                                    .Item("Cancellation_Date") = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(.Item("Effective_Date")).AddYears(1))
                                Else
                                    .Item("Cancellation_Date") = Convert.ToDateTime(.Item("Cancellation_Date")).AddYears(1)
                                End If
                                .Item("Deduction_Amount") = Convert.ToDouble(Premium)
                                .Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Item("Last_Modified_On") = Now()
                                .Item("Status") = "INFORCE"
                                .Item("Policy_Status") = "Renewed"
                                .Item("GST") = 1
                            End With

                            da_MemberPolicy.Update(ds_Renewal, "dt_Member_Policy")


                            Dim dr_MemberPolicy_YearlyRenewal As DataRow
                            dr_MemberPolicy_YearlyRenewal = ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").NewRow

                            With dr_MemberPolicy_YearlyRenewal
                                .Item("ID") = Guid.NewGuid.ToString()
                                .Item("Member_Policy_ID") = PID
                                .Item("Log_Date") = Now()
                                .Item("Payment_Method") = "Cheque"
                                .Item("Request_Date") = Now()
                                .Item("Premium") = Convert.ToDouble(Premium)
                                .Item("Cheque_No") = Me.txtChequeNo.Text.Trim
                                .Item("Cheque_Receipt_No") = Me.txtChequeReceiptNo.Text.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                            End With

                            ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").Rows.Add(dr_MemberPolicy_YearlyRenewal)
                            da_MemberPolicy_YearlyRenewal.Update(ds_Renewal, "dt_Member_Policy_YearlyRenewal")



                            Dim dr_MemberLog As DataRow
                            dr_MemberLog = ds_Renewal.Tables("log_Member").NewRow

                            With dr_MemberLog
                                .Item("Member_Policy_ID") = PID
                                .Item("Log_Date") = Now()
                                .Item("Activity_Detail") = "Policy renewed."
                                .Item("Username") = My.Settings.Username.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                            End With

                            ds_Renewal.Tables("log_Member").Rows.Add(dr_MemberLog)
                            da_MemberLog.Update(ds_Renewal, "log_Member")
                        End If
                    Else
                        If exYear = nextYear Then
                            Exit Function
                        Else
                            With ds_Renewal.Tables("dt_Member_Policy").Rows(0)
                                If IsDBNull(.Item("Cancellation_Date")) Then
                                    .Item("Cancellation_Date") = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(.Item("Effective_Date")).AddYears(1))
                                Else
                                    .Item("Cancellation_Date") = Convert.ToDateTime(.Item("Cancellation_Date")).AddYears(1)
                                End If
                                .Item("Deduction_Amount") = Convert.ToDouble(Premium)
                                .Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Item("Last_Modified_On") = Now()
                                .Item("Status") = "INFORCE"
                                .Item("Policy_Status") = "Renewed"
                                .Item("GST") = 1

                            End With
                            da_MemberPolicy.Update(ds_Renewal, "dt_Member_Policy")

                            Dim dr_MemberPolicy_YearlyRenewal As DataRow
                            dr_MemberPolicy_YearlyRenewal = ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").NewRow

                            With dr_MemberPolicy_YearlyRenewal
                                .Item("ID") = Guid.NewGuid.ToString()
                                .Item("Member_Policy_ID") = PID
                                .Item("Log_Date") = Now()
                                .Item("Payment_Method") = "Cheque"
                                .Item("Request_Date") = Now()
                                .Item("Premium") = Convert.ToDouble(Premium)
                                .Item("Cheque_No") = Me.txtChequeNo.Text.Trim
                                .Item("Cheque_Receipt_No") = Me.txtChequeReceiptNo.Text.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                            End With

                            ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").Rows.Add(dr_MemberPolicy_YearlyRenewal)
                            da_MemberPolicy_YearlyRenewal.Update(ds_Renewal, "dt_Member_Policy_YearlyRenewal")



                            Dim dr_MemberLog As DataRow
                            dr_MemberLog = ds_Renewal.Tables("log_Member").NewRow

                            With dr_MemberLog
                                .Item("Member_Policy_ID") = PID
                                .Item("Log_Date") = Now()
                                .Item("Activity_Detail") = "Special Approval by Administrator... Policy renewed."
                                .Item("Username") = My.Settings.Username.Trim
                                .Item("Created_By") = My.Settings.Username.Trim
                                .Item("Created_On") = Now()
                            End With

                            ds_Renewal.Tables("log_Member").Rows.Add(dr_MemberLog)
                            da_MemberLog.Update(ds_Renewal, "log_Member")
                        End If
                    End If

                End If
            Else
                With ds_Renewal.Tables("dt_Member_Policy").Rows(0)
                    If IsDBNull(.Item("Cancellation_Date")) Then
                        .Item("Cancellation_Date") = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(.Item("Effective_Date")).AddYears(1))
                    Else
                        .Item("Cancellation_Date") = Convert.ToDateTime(.Item("Cancellation_Date")).AddYears(1)
                    End If
                    .Item("Deduction_Amount") = Convert.ToDouble(Premium)
                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                    .Item("Last_Modified_On") = Now()
                    .Item("Status") = "INFORCE"
                    .Item("Policy_Status") = "Renewed"
                    .Item("GST") = 1
                End With

                da_MemberPolicy.Update(ds_Renewal, "dt_Member_Policy")


                Dim dr_MemberPolicy_YearlyRenewal As DataRow
                dr_MemberPolicy_YearlyRenewal = ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").NewRow

                With dr_MemberPolicy_YearlyRenewal
                    .Item("ID") = Guid.NewGuid.ToString()
                    .Item("Member_Policy_ID") = PID
                    .Item("Log_Date") = Now()
                    .Item("Payment_Method") = "Cheque"
                    .Item("Request_Date") = Now()
                    .Item("Premium") = Convert.ToDouble(Premium)
                    .Item("Cheque_No") = Me.txtChequeNo.Text.Trim
                    .Item("Cheque_Receipt_No") = Me.txtChequeReceiptNo.Text.Trim

                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                End With

                ds_Renewal.Tables("dt_Member_Policy_YearlyRenewal").Rows.Add(dr_MemberPolicy_YearlyRenewal)
                da_MemberPolicy_YearlyRenewal.Update(ds_Renewal, "dt_Member_Policy_YearlyRenewal")



                Dim dr_MemberLog As DataRow
                dr_MemberLog = ds_Renewal.Tables("log_Member").NewRow

                With dr_MemberLog
                    .Item("Member_Policy_ID") = PID
                    .Item("Log_Date") = Now()
                    .Item("Activity_Detail") = "Policy renewed."
                    .Item("Username") = My.Settings.Username.Trim
                    .Item("Created_By") = My.Settings.Username.Trim
                    .Item("Created_On") = Now()
                End With

                ds_Renewal.Tables("log_Member").Rows.Add(dr_MemberLog)
                da_MemberLog.Update(ds_Renewal, "log_Member")
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.txtNoofPolicies.Text = ""
        Me.txtReceivedPremium.Text = ""
        Me.txtBrowse.Text = ""
        Me.Close()
    End Sub
    Private Sub txtNoofPolicies_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoofPolicies.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 127) Then
            e.KeyChar = ""
            e.Handled = False
        End If
    End Sub
    Private Sub txtReceivedPremium_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceivedPremium.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 127) Then
            e.KeyChar = ""
            e.Handled = False
        End If
    End Sub
End Class