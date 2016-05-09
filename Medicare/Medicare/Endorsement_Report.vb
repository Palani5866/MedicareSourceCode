Public Class Endorsement_Report
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
#End Region
#Region "Page Events"
    Private Sub Endorsement_Report_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Endorsement_Report_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tsReport_txtDate_From.Text = Format(Now(), "dd/MM/yyyy")
        Me.tsReport_txtDate_To.Text = Format(Now(), "dd/MM/yyyy")
        Me.tsReport_cbType.SelectedIndex = 1
    End Sub
#End Region
#Region "Click Events"
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tsReport_cbType.SelectionLength) = 0 Then
            MsgBox("Please Select the creteria.")
            Me.tsReport_cbType.Focus()
            Exit Sub
        End If
        If Me.tsReport_cbType.SelectedIndex = 1 Then
            If Len(Me.tsReport_txtDate_From.Text.Trim) = 0 Then
                MsgBox("Please do key in the Effective Date (From) (dd/mm/yyyy).")
                Me.tsReport_txtDate_From.Focus()
                Exit Sub
            End If
            If Len(Me.tsReport_txtDate_To.Text.Trim) = 0 Then
                MsgBox("Please do key in the Effective Date (To) (dd/mm/yyyy).")
                Me.tsReport_txtDate_To.Focus()
                Exit Sub
            End If
            If IsDate(Me.tsReport_txtDate_From.Text) = False Then
                MsgBox("Please do key in the Effective Date (From) in the right format (dd/mm/yyyy).")
                Me.tsReport_txtDate_From.Focus()
                Exit Sub
            Else
                If IsDate(Me.tsReport_txtDate_To.Text) = False Then
                    MsgBox("Please do key in the Effective Date (To) in the right format (dd/mm/yyyy).")
                    Me.tsReport_txtDate_To.Focus()
                    Exit Sub
                Else
                    If Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Date >= Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Date Then
                        Me.Populate_Grid()
                    Else
                        MsgBox("Effective Date (To) is < Effective Date (From).")
                        Me.tsReport_txtDate_To.Focus()
                        Exit Sub
                    End If

                End If
            End If
        Else
            If Len(Me.tsReport_txtDate_From.Text.Trim) = 0 Then
                MsgBox("Please do key in the Received Date (From) (dd/mm/yyyy).")
                Me.tsReport_txtDate_From.Focus()
                Exit Sub
            End If
            If Len(Me.tsReport_txtDate_To.Text.Trim) = 0 Then
                MsgBox("Please do key in the Received Date (To) (dd/mm/yyyy).")
                Me.tsReport_txtDate_To.Focus()
                Exit Sub
            End If
            If IsDate(Me.tsReport_txtDate_From.Text) = False Then
                MsgBox("Please do key in the Received Date (From) in the right format (dd/mm/yyyy).")
                Me.tsReport_txtDate_From.Focus()
                Exit Sub
            Else
                If IsDate(Me.tsReport_txtDate_To.Text) = False Then
                    MsgBox("Please do key in the Received Date (To) in the right format (dd/mm/yyyy).")
                    Me.tsReport_txtDate_To.Focus()
                    Exit Sub
                Else
                    If Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Date >= Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Date Then
                        Me.Pop_Grid()
                    Else
                        MsgBox("Received Date (To) is < Received Date (From).")
                        Me.tsReport_txtDate_To.Focus()
                        Exit Sub
                    End If

                End If
            End If
        End If

    End Sub
    Private Sub tsReport_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Export.Click
        If Me.dgvForm.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)

            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

            xls_workbook = xls_file.Workbooks.Add

            Dim xls_wks_name As String = ""

            xls_workbook.Worksheets.Add()
            xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim

            With xls_workbook.Worksheets(xls_wks_name)
                If Me.ssReport_Parameter.Text = "E" Then
                    .Cells(1, 1) = "ENDORSEMENT LISTING"
                    .Cells(3, 9) = "ENDORSEMENT DETAIL"
                Else
                    .Cells(1, 1) = "CANCELLED POLICY LISTING"
                    .Cells(3, 9) = "CANCELLATION DETAIL"
                End If

                .Cells(3, 1) = "NO. "
                .Cells(3, 2) = "EFFECTIVE DATE"
                .Cells(3, 3) = "FILE NO."
                .Cells(3, 4) = "FULL NAME"
                .Cells(3, 5) = "IC"
                .Cells(3, 6) = "DEDUCTION CODE"
                .Cells(3, 7) = "POLICY NO."
                .Cells(3, 8) = "NEW POLICY NO."
                .Cells(3, 9) = "DATE RECEIVED DOCUMENT FROM CLIENT"
                .Cells(3, 11) = "DATA ENTERED STAFF NAME"
                .Cells(3, 12) = "REMARK"


                Dim xls_row_counter As Integer = 4
                Dim var_name_count As Integer = 0
                Do While var_name_count < Me.dgvForm.RowCount
                    .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 3).ToString.Trim
                    .Cells(xls_row_counter, 2) = "'" & Format(Me.dgvForm.Rows(var_name_count).Cells("Effective_Date").Value, "dd/MM/yyyy")
                    .Cells(xls_row_counter, 3) = "'" & Me.dgvForm.Rows(var_name_count).Cells("Angkasa_FileNo").Value.ToString.Trim
                    .Cells(xls_row_counter, 4) = "'" & Me.dgvForm.Rows(var_name_count).Cells("Full_Name").Value.ToString.Trim
                    .Cells(xls_row_counter, 5) = "'" & Me.dgvForm.Rows(var_name_count).Cells("IC_New").Value.ToString.Trim
                    .Cells(xls_row_counter, 6) = "'" & Me.dgvForm.Rows(var_name_count).Cells("Deduction_Code").Value.ToString.Trim
                    .Cells(xls_row_counter, 7) = "'" & Me.dgvForm.Rows(var_name_count).Cells("Policy_No").Value.ToString.Trim
                    .Cells(xls_row_counter, 8) = "'" & Me.dgvForm.Rows(var_name_count).Cells("NEW_Policy_No").Value.ToString.Trim
                    .Cells(xls_row_counter, 9) = "'" & Format(Me.dgvForm.Rows(var_name_count).Cells("Request_Date").Value, "dd/MM/yyyy")
                    If Not IsDBNull(Me.dgvForm.Rows(var_name_count).Cells("Cancellation_Date").Value) Then
                        .Cells(xls_row_counter, 10) = "'" & Format(Me.dgvForm.Rows(var_name_count).Cells("Cancellation_Date").Value, "dd/MM/yyyy")

                    End If
                    .Cells(xls_row_counter, 10) = "'" & Me.dgvForm.Rows(var_name_count).Cells("Endorsement_Detail").Value.ToString.Trim
                    .Cells(xls_row_counter, 11) = "'" & Me.dgvForm.Rows(var_name_count).Cells("Created_By").Value.ToString.Trim
                    .Cells(xls_row_counter, 12) = "'" & Me.dgvForm.Rows(var_name_count).Cells("Remark").Value.ToString.Trim
                    If Me.dgvForm.Rows(var_name_count).Cells("Endorsement_Type").Value.ToString.Trim = "EA" Then
                        .Cells(xls_row_counter, 10) = "' Change of Postal Address From : " & Me.dgvForm.Rows(var_name_count).Cells("Old Address").Value.ToString.Trim & "   TO :" & Me.dgvForm.Rows(var_name_count).Cells("New Address").Value.ToString.Trim
                    End If
                    xls_row_counter += 1
                    var_name_count += 1
                Loop
            End With

            If Me.ssReport_Parameter.Text = "E" Then
                MsgBox("Exporting records to REPORT: ENDORSEMENT LISTING completed.")
            Else
                MsgBox("Exporting records to REPORT: CANCELLED POLICY LISTING completed.")
            End If

            xls_file.Visible = True
        End If
    End Sub
#End Region
#Region "Data Bind"
    Private Sub Populate_Grid()
        Me.dgvForm.DataSource = Nothing
        Me.dgvForm.DataMember = Nothing

        Dim var_Log_From_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
        Dim var_Log_From_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
        Dim var_Log_From_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
        Dim var_Log_Date_From As String = var_Log_From_Month & "/" & var_Log_From_Day & "/" & var_Log_From_Year

        Dim var_Log_To_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
        Dim var_Log_To_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
        Dim var_Log_To_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
        Dim var_Log_Date_To As String = var_Log_To_Month & "/" & var_Log_To_Day & "/" & var_Log_To_Year

        Dim cmdSelect_EndorsedPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_EndorsedPolicy.CommandType = CommandType.Text

        cmdSelect_EndorsedPolicy.CommandText = "Select a.Effective_Date, b.Angkasa_FileNo, c.Full_Name, c.IC_New, b.Deduction_Code, b.Policy_No, b.new_policy_no, a.Request_Date, a.Endorsement_Detail, " & _
                                                "b.Cancellation_Date, a.Created_By, a.Remark, " & _
                                                "a.Postal_Address_L1 + ', ' + a.Postal_Address_L2 + ', ' + a.Town + ', ' + a.Postcode + ', ' + a.State as [Old Address], " & _
                                                "c.Postal_Address_L1 + ', ' + c.Postal_Address_L2 + ', ' + c.Town + ', ' + c.Postcode + ', ' + c.State as [New Address], a.Endorsement_Type " & _
                                                "from dt_Member_Endorsement a inner join dt_member_policy b on a.member_policy_id=b.id  inner join dt_member c on a.member_id=c.id " & _
                                                "WHERE a.Effective_Date BETWEEN '" & var_Log_Date_From & "' " & _
                                                "AND '" & var_Log_Date_To & "' " & _
                                                "AND a.Endorsement_Type in ('" & Me.ssReport_Parameter.Text.Trim & "', 'EA')" & _
                                                "ORDER BY b.Deduction_Code, b.Angkasa_FileNo"
        Dim da_EndorsedPolicy As New SqlDataAdapter(cmdSelect_EndorsedPolicy)


        Dim ds_EndorsementReport As New DataSet
        da_EndorsedPolicy.Fill(ds_EndorsementReport, "vi_Member_Endorsement")

        With Me.dgvForm
            .DataSource = ds_EndorsementReport
            .DataMember = "vi_Member_Endorsement"

            .Columns(0).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(6).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(0).HeaderText = "Effective Date"
            .Columns(1).HeaderText = "File No."
            .Columns(2).HeaderText = "Full Name"
            .Columns(3).HeaderText = "IC"
            .Columns(4).HeaderText = "Deduction Code"
            .Columns(5).HeaderText = "Policy No."
            .Columns(6).HeaderText = "New Policy No."
            .Columns(7).HeaderText = "Date Received Document From Client"
            .Columns(9).HeaderText = "Cancellation Date"
            If Me.ssReport_Parameter.Text = "E" Then
                .Columns(8).HeaderText = "Endorsement Detail"
            Else
                .Columns(8).HeaderText = "Cancellation Detail"
            End If

            .Columns(10).HeaderText = "Data Entered Staff Name"
            .Columns(11).HeaderText = "Remark"
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False

            Me.ssReport_RecordCount.Text = "Record #: " & Me.dgvForm.RowCount.ToString
            Me.ssReport_RecordCount.Visible = True
        End With
    End Sub
    Private Sub Pop_Grid()
        Me.dgvForm.DataSource = Nothing
        Me.dgvForm.DataMember = Nothing

        Dim var_Log_From_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
        Dim var_Log_From_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
        Dim var_Log_From_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
        Dim var_Log_Date_From As String = var_Log_From_Month & "/" & var_Log_From_Day & "/" & var_Log_From_Year

        Dim var_Log_To_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
        Dim var_Log_To_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
        Dim var_Log_To_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
        Dim var_Log_Date_To As String = var_Log_To_Month & "/" & var_Log_To_Day & "/" & var_Log_To_Year

        Dim cmdSelect_EndorsedPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_EndorsedPolicy.CommandType = CommandType.Text

        cmdSelect_EndorsedPolicy.CommandText = "Select a.Effective_Date, b.Angkasa_FileNo, c.Full_Name, c.IC_New, b.Deduction_Code, b.Policy_No,b.new_policy_no, a.Request_Date, a.Endorsement_Detail, " & _
                                                "b.Cancellation_Date, a.Created_By, a.Remark, " & _
                                                "a.Postal_Address_L1 + ', ' + a.Postal_Address_L2 + ', ' + a.Town + ', ' + a.Postcode + ', ' + a.State as [Old Address], " & _
                                                "c.Postal_Address_L1 + ', ' + c.Postal_Address_L2 + ', ' + c.Town + ', ' + c.Postcode + ', ' + c.State as [New Address], a.Endorsement_Type " & _
                                                "from dt_Member_Endorsement a inner join dt_member_policy b on a.member_policy_id=b.id  inner join dt_member c on a.member_id=c.id " & _
                                                "WHERE a.Request_Date BETWEEN '" & var_Log_Date_From & "' " & _
                                                "AND '" & var_Log_Date_To & "' " & _
                                                "AND a.Endorsement_Type in ('" & Me.ssReport_Parameter.Text.Trim & "', 'EA')" & _
                                                "ORDER BY b.Deduction_Code, b.Angkasa_FileNo"

        Dim da_EndorsedPolicy As New SqlDataAdapter(cmdSelect_EndorsedPolicy)


        Dim ds_EndorsementReport As New DataSet
        da_EndorsedPolicy.Fill(ds_EndorsementReport, "vi_Member_Endorsement")

        With Me.dgvForm
            .DataSource = ds_EndorsementReport
            .DataMember = "vi_Member_Endorsement"

            .Columns(0).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(6).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(0).HeaderText = "Effective Date"
            .Columns(1).HeaderText = "File No."
            .Columns(2).HeaderText = "Full Name"
            .Columns(3).HeaderText = "IC"
            .Columns(4).HeaderText = "Deduction Code"
            .Columns(5).HeaderText = "Policy No."
            .Columns(6).HeaderText = "New Policy No."
            .Columns(7).HeaderText = "Date Received Document From Client"
            .Columns(9).HeaderText = "Cancellation Date"
            If Me.ssReport_Parameter.Text = "E" Then
                .Columns(8).HeaderText = "Endorsement Detail"
            Else
                .Columns(8).HeaderText = "Cancellation Detail"
            End If

            .Columns(10).HeaderText = "Data Entered Staff Name"
            .Columns(11).HeaderText = "Remark"
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False

            Me.ssReport_RecordCount.Text = "Record #: " & Me.dgvForm.RowCount.ToString
            Me.ssReport_RecordCount.Visible = True
        End With
    End Sub
#End Region
#Region "Change Events"
    Private Sub tsReport_cbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsReport_cbType.SelectedIndexChanged
        If Me.tsReport_cbType.SelectedIndex = 1 Then
            Me.tsReport_lblDate_From.Text = "Effective Date - From (dd/mm/yyyy):"
            Me.tsReport_lblDate_To.Text = "Effective Date - To (dd/mm/yyyy):"
        Else
            Me.tsReport_lblDate_From.Text = "Received Date - From (dd/mm/yyyy):"
            Me.tsReport_lblDate_To.Text = "Received Date - To (dd/mm/yyyy):"
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