Public Class fYrInvoice
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim dtExcel As New DataTable
    Private Sub fYrInvoice_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fYrInvoice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        popPlanType()
    End Sub
    Private Sub popPlanType()
        Dim dt As New DataTable
        dt = _objBusi.getDetails("VP", "", "", "", "", "Y", Conn)
        Me.tscbPlanType.ComboBox.DataSource = dt
        Me.tscbPlanType.ComboBox.DisplayMember = "PLAN_CODE"
        Me.tscbPlanType.ComboBox.ValueMember = "PLAN_CODE"

        Me.tscbYR.ComboBox.Items.Add(Now.Year())
        Me.tscbYR.ComboBox.Items.Add(Now.Year() + 1)
    End Sub
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        If Me.tscbPlanType.SelectedIndex = -1 Then
            MsgBox("Please do select the Plan Type!")
            Me.tscbPlanType.Focus()
            Exit Sub
        End If
        If Me.tscbMonth.SelectedIndex = -1 Then
            MsgBox("Please do select the Policy Renewal Month!")
            Me.tscbMonth.Focus()
            Exit Sub
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _objBusi.getDetails_VI("YRI", Me.tscbPlanType.Text.ToString.Trim(), Me.tscbMonth.Text.ToString.Trim(), Me.tscbYR.Text.ToString.Trim(), "", "", "", "", "", "", "", Conn)
        ds = _objBusi.getDsDetails_VI("YRP", Me.tscbPlanType.Text.ToString.Trim(), Me.tscbMonth.Text.ToString.Trim(), Me.tscbYR.Text.ToString.Trim(), "", "", "", "", "", "", "", Conn)

        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvYrInvoice
                .DataSource = dt
                .Columns(0).Visible = False

                .Columns(5).DefaultCellStyle.Format = "#,##0.00"
                .Columns(6).DefaultCellStyle.Format = "#,##0.00"
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                Me.tslblRecordCounter.Text = "Record #: " & Me.dgvYrInvoice.RowCount.ToString
            End With
        Else
            Me.dgvYrInvoice.DataSource = dt
            Me.tslblRecordCounter.Text = "Record #: 0 "
        End If

        With Me.dgvYRPremiumUpdate
            .DataSource = ds.Tables(0)
            .Columns(0).DisplayIndex = 6
            .Columns(1).DisplayIndex = 6
            .Columns(2).DisplayIndex = 6
            .Columns(3).DisplayIndex = 6
            .Columns(4).DisplayIndex = 6
            .Columns(5).DisplayIndex = 6
        End With

        With Me.dgvYRPremiumClosed
            .DataSource = ds.Tables(1)
            .Columns(0).DisplayIndex = 1
        End With
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
    Private Sub tsbtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExport.Click
        xPort2Xcel()
    End Sub
    Private Sub xPort2Xcel()
        If Me.dgvYrInvoice.RowCount > 0 Then
            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
            xls_workbook = xls_file.Workbooks.Add

            Dim var_name_count As Integer = 0
            Dim xls_wks_name As String = ""
            Dim xls_row_counter As Integer = 6
            Dim Batch_No As String = "YR/" & Format(Now.Date, "yyMMdd") & "-" & Format(Now, "HHmmss")
            Dim var_Deduction_Code As String = ""
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()

            xls_workbook.Worksheets.Add()
            xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

            With xls_workbook.Worksheets(xls_wks_name)
              

                .Cells(1, 1) = "FILE NO."
                .Cells(1, 2) = "FULL NAME"
                .Cells(1, 3) = "IC"
                .Cells(1, 4) = "DEDUCTION CODE"
                .Cells(1, 5) = "PREMIUM"
                .Cells(1, 6) = "GST 6%"
                .Cells(1, 7) = "PREMIUM + GST 6%"
                .Cells(1, 8) = "EFFECTIVE DATE"
                .Cells(1, 9) = "CANCELLATION DATE"

                .Columns(1).NumberFormat = "@"
                .Columns(2).NumberFormat = "@"
                .Columns(3).NumberFormat = "@"
                .Columns(4).NumberFormat = "@"
                .Columns(5).NumberFormat = "@"
                .Columns(6).NumberFormat = "@"
                .Columns(7).NumberFormat = "@"
                .Columns(8).NumberFormat = "dd/MM/yyyy"
                .Columns(9).NumberFormat = "dd/MM/yyyy"
            End With
            xls_row_counter = 2

            Do While var_name_count < Me.dgvYrInvoice.RowCount
                With Me.dgvYrInvoice.Rows(var_name_count)
                    _objBusi.spUpdate("YRI", .Cells(0).Value.ToString.Trim, Batch_No, Me.tscbMonth.Text.Trim(), Me.tscbYR.Text.ToString.Trim(), "", "", "", "", "", "", Conn)
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = "'" & .Cells(1).Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = .Cells(2).Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = "'" & .Cells(3).Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = "'" & .Cells(4).Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & Format(.Cells(5).Value, "#,#00.00")
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & Format(.Cells(6).Value, "#,#0.00")
                    Dim Premium, GST As Double
                    Premium = .Cells(5).Value
                    GST = .Cells(6).Value
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "'" & Format(Premium + GST, "#,#0.00")
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 8) = "'" & .Cells(8).Value
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 9) = "'" & .Cells(9).Value
                End With
                xls_row_counter += 1
                var_name_count += 1
            Loop
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xls_file.Visible = True
        Else
            MsgBox("No Record Found!")
        End If
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
    Public Shared Function EXBINDDATA(ByVal SourceFilePath As String) As DataTable

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
    Private Sub dgvYRPremiumUpdate_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvYRPremiumUpdate.CellContentClick
        With Me.dgvYRPremiumUpdate
            If e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(6).Value = "0" Then
                    Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                        If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                            Dim sFileToUpload As String = ""
                            sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))

                            dtExcel = EXBINDDATA(sFileToUpload)
                            .Rows(e.RowIndex).Cells(2).Value = sFileToUpload
                        Else
                            MsgBox("File Requied")
                            Exit Sub
                        End If
                    End Using
                End If
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsNothing(.Rows(e.RowIndex).Cells(6).Value) Then
                    If IsNothing(.Rows(e.RowIndex).Cells(0).Value) Then
                        MsgBox("Please do key in Cheque No !")
                        Exit Sub
                    End If

                    If IsNothing(.Rows(e.RowIndex).Cells(1).Value) Then
                        MsgBox("Please do key in Receipt No!")
                        Exit Sub
                    End If

                    If IsNothing(.Rows(e.RowIndex).Cells(2).Value) Then
                        MsgBox("File Required!")
                        Exit Sub
                    End If
                    SharedData.ReadyToHideMarquee = False
                    StartMarqueeThread()
                    If dtExcel.Rows.Count > 0 Then
                        For Each exDr As DataRow In dtExcel.Rows
                            Dim dt As New DataTable
                            dt = _objBusi.getDetails_VI("YRD", .Rows(e.RowIndex).Cells(6).Value.ToString.Trim(), exDr("IC").ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
                            If dt.Rows.Count > 0 Then
                                YearlyRenewal(dt.Rows(0)("ID").ToString.Trim(), FormatNumber(dt.Rows(0)("DEDUCTION_AMOUNT"), 2), .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value.ToString.Trim())
                            End If
                        Next
                    End If
                   
                    SyncLock SharedData
                        SharedData.ReadyToHideMarquee = True
                    End SyncLock
                    Application.DoEvents()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsNothing(.Rows(e.RowIndex).Cells(6).Value) Then
                    Dim vFSD As New YRSubmissionDetails
                    vFSD.lblBATCHNO.Text = .Rows(e.RowIndex).Cells(6).Value.ToString.Trim()
                    vFSD.lblSTATUS.Text = "SUBMITTED"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
    End Sub
    Private Sub dgvYRPremiumClosed_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvYRPremiumClosed.CellContentClick
        With Me.dgvYRPremiumClosed
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsNothing(.Rows(e.RowIndex).Cells(1).Value) Then
                    Dim vFSD As New YRSubmissionDetails
                    vFSD.lblBATCHNO.Text = .Rows(e.RowIndex).Cells(1).Value.ToString.Trim()
                    vFSD.lblSTATUS.Text = "CLOSED"
                    vFSD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
    End Sub
    Private Function YearlyRenewal(ByVal PID As String, ByVal PREMIUM As String, ByVal CHEQUENO As String, ByVal RECEIPTNO As String) As Boolean
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
                    cMonth = 8

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
                            
                        ElseIf exYear = RSY And cMonth < RSM And RSY >= cYear Then

                            Exit Function
                        Else

                            With ds_Renewal.Tables("dt_Member_Policy").Rows(0)
                                If IsDBNull(.Item("Cancellation_Date")) Then
                                    .Item("Cancellation_Date") = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(.Item("Effective_Date")).AddYears(1))
                                Else
                                    .Item("Cancellation_Date") = Convert.ToDateTime(.Item("Cancellation_Date")).AddYears(1)
                                End If
                                .Item("Deduction_Amount") = Convert.ToDouble(PREMIUM)
                                .Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Item("Last_Modified_On") = Now()
                                .Item("Status") = "INFORCE"
                                .Item("YRINVOICE") = "CLOSED"
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
                                .Item("Premium") = Convert.ToDouble(PREMIUM)
                                .Item("Cheque_No") = CHEQUENO
                                .Item("Cheque_Receipt_No") = RECEIPTNO
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
                                .Item("Deduction_Amount") = Convert.ToDouble(PREMIUM)
                                .Item("Last_Modified_By") = My.Settings.Username.Trim
                                .Item("Last_Modified_On") = Now()
                                .Item("Status") = "INFORCE"
                                .Item("YRINVOICE") = "CLOSED"
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
                                .Item("Premium") = Convert.ToDouble(PREMIUM)
                                .Item("Cheque_No") = CHEQUENO
                                .Item("Cheque_Receipt_No") = RECEIPTNO
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
                    .Item("Deduction_Amount") = Convert.ToDouble(PREMIUM)
                    .Item("Last_Modified_By") = My.Settings.Username.Trim
                    .Item("Last_Modified_On") = Now()
                    .Item("Status") = "INFORCE"
                    .Item("YRINVOICE") = "CLOSED"
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
                    .Item("Premium") = Convert.ToDouble(PREMIUM)
                    .Item("Cheque_No") = CHEQUENO
                    .Item("Cheque_Receipt_No") = RECEIPTNO

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

    Private Sub tsbtnXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnXport2Xcel.Click
        GxPort2Xcel()
    End Sub
    Private Sub GxPort2Xcel()
        If Me.dgvYrInvoice.RowCount > 0 Then
            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
            xls_workbook = xls_file.Workbooks.Add

            Dim var_name_count As Integer = 0
            Dim xls_wks_name As String = ""
            Dim xls_row_counter As Integer = 6
            Dim Batch_No As String = "YR/" & Format(Now.Date, "yyMMdd") & "-" & Format(Now, "HHmmss")
            Dim var_Deduction_Code As String = ""
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()

            xls_workbook.Worksheets.Add()
            xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

            With xls_workbook.Worksheets(xls_wks_name)
                .Cells(1, 1) = "FILE NO."
                .Cells(1, 2) = "FULL NAME"
                .Cells(1, 3) = "IC"
                .Cells(1, 4) = "DEDUCTION CODE"
                .Cells(1, 5) = "PREMIUM"
                .Cells(1, 6) = "GST 6%"
                .Cells(1, 7) = "PREMIUM + GST 6%"
                .Cells(1, 8) = "EFFECTIVE DATE"
                .Cells(1, 9) = "CANCELLATION DATE"

                .Columns(1).NumberFormat = "@"
                .Columns(2).NumberFormat = "@"
                .Columns(3).NumberFormat = "@"
                .Columns(4).NumberFormat = "@"
                .Columns(5).NumberFormat = "@"
                .Columns(6).NumberFormat = "@"
                .Columns(7).NumberFormat = "@"
                .Columns(8).NumberFormat = "dd/MM/yyyy"
                .Columns(9).NumberFormat = "dd/MM/yyyy"
            End With
            xls_row_counter = 2

            Do While var_name_count < Me.dgvYrInvoice.RowCount
                With Me.dgvYrInvoice.Rows(var_name_count)
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 1) = "'" & .Cells(1).Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 2) = .Cells(2).Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 3) = "'" & .Cells(3).Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 4) = "'" & .Cells(4).Value.ToString.Trim
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 5) = "'" & Format(.Cells(5).Value, "#,#00.00")
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 6) = "'" & Format(.Cells(6).Value, "#,#0.00")
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 7) = "'" & (Format(.Cells(5).Value, "#,#00.00") + Format(.Cells(6).Value, "#,#0.00"))
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 8) = "'" & .Cells(8).Value
                    xls_workbook.Worksheets(xls_wks_name).Cells(xls_row_counter, 9) = "'" & .Cells(9).Value
                End With
                xls_row_counter += 1
                var_name_count += 1
            Loop
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xls_file.Visible = True
        Else
            MsgBox("No Record Found!")
        End If
    End Sub
End Class