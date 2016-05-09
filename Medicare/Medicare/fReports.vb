Public Class fReports
  
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
#End Region
#Region "Page Events"
    Private Sub fReports_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindCB()
        Me.tsReport_txtDate_From.Text = Now().Date
        Me.tsReport_txtDate_To.Text = Now().Date
    End Sub
#End Region
#Region "Data Bind"
    Private Sub BindCB()
        Dim dt As New DataTable
        Dim sdp As SqlDataAdapter
        Dim sc As SqlCommand = CType(Conn.CreateCommand, SqlCommand)
        sc.CommandType = CommandType.Text
        sc.CommandText = "SELECT * FROM tb_USERS WHERE STATUS='Active'"
        sdp = New SqlDataAdapter(sc)
        sdp.Fill(dt)
        Me.tscbStaffName.ComboBox.DataSource = dt
        Me.tscbStaffName.ComboBox.DisplayMember = "Full_Name"
        Me.tscbStaffName.ComboBox.ValueMember = "UserID"
    End Sub
    Private Sub BindData()
        Dim var_From_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
        Dim var_From_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
        Dim var_From_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
        Dim var_Date_From As String = var_From_Month & "/" & var_From_Day & "/" & var_From_Year

        Dim var_To_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
        Dim var_To_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
        Dim var_To_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
        Dim var_Date_To As String = var_To_Month & "/" & var_To_Day & "/" & var_To_Year

        '
        Dim _ds As New DataSet
        Dim _scGetYr As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        _scGetYr.CommandType = CommandType.Text
        _scGetYr.CommandText = "select c.Full_Name As Staff_Name, a.Log_date, b.Angkasa_FileNo, d.Full_Name, Activity_Detail from log_member a " & _
                                "inner join dt_member_policy b ON a.Member_policy_id=b.ID " & _
                                "inner join tb_users c ON a.UserName=c.UserID inner join dt_member d ON b.Member_ID=d.ID " & _
                                "WHERE UserName='" & Me.tscbStaffName.ComboBox.SelectedValue & "' " & _
                                "AND LOG_Date BETWEEN '" & var_Date_From & "' " & _
                                "AND '" & var_Date_To & "' ORDER BY LOG_Date Desc"

        Dim _sdaGetYr As New SqlDataAdapter(_scGetYr)
        _sdaGetYr.Fill(_ds, "log_member")
        If _ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvStaffActivityDetails
                .DataSource = _ds
                .DataMember = "log_member"

                .Columns(0).HeaderText = "Full Name"
                .Columns(1).HeaderText = "Date"
                .Columns(2).HeaderText = "File #"
                .Columns(3).HeaderText = "Proposer Name"
                .Columns(4).HeaderText = "Activity Details"
            End With
        End If

    End Sub
#End Region
#Region "Click Events"
    Private Sub tsbXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbXport2Xcel.Click
        Xport2Xcel()
    End Sub
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tscbStaffName.Text.Trim) = 0 Then
            MsgBox("Required Staff Name.")
            Me.tscbStaffName.Focus()
            Exit Sub
        End If

        If Len(Me.tsReport_txtDate_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the From date (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        End If

        If Len(Me.tsReport_txtDate_To.Text.Trim) = 0 Then
            MsgBox("Please do key in the To date (dd/mm/yyyy).")
            Me.tsReport_txtDate_To.Focus()
            Exit Sub
        End If

        If IsDate(Me.tsReport_txtDate_From.Text) = False Then
            MsgBox("Please do key in the From date in the right format (dd/mm/yyyy).")
            Me.tsReport_txtDate_From.Focus()
            Exit Sub
        Else
            If IsDate(Me.tsReport_txtDate_To.Text) = False Then
                MsgBox("Please do key in the To date in the right format (dd/mm/yyyy).")
                Me.tsReport_txtDate_To.Focus()
                Exit Sub
            Else
                If Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Date >= Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Date Then
                    Me.BindData()
                Else
                    MsgBox("To date is < From date.")
                    Me.tsReport_txtDate_To.Focus()
                    Exit Sub
                End If
            End If
        End If
    End Sub
#End Region
    
#Region "Export to Excel"
    Private Sub Xport2Xcel()
        If Me.dgvStaffActivityDetails.RowCount > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook

            xls_workbook = xls_file.Workbooks.Add

            Dim var_From_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Day
            Dim var_From_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Month
            Dim var_From_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_From.Text).Year
            Dim var_Date_From As String = var_From_Month & "/" & var_From_Day & "/" & var_From_Year

            Dim var_To_Day As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Day
            Dim var_To_Month As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Month
            Dim var_To_Year As String = Convert.ToDateTime(Me.tsReport_txtDate_To.Text).Year
            Dim var_Date_To As String = var_To_Month & "/" & var_To_Day & "/" & var_To_Year


            Dim _scGetPYr As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            _scGetPYr.CommandType = CommandType.Text
            _scGetPYr.CommandText = "select c.Full_Name As Staff_Name, a.Log_date, b.Angkasa_FileNo, d.Full_Name, Activity_Detail from log_member a " & _
                                        "inner join dt_member_policy b ON a.Member_policy_id=b.ID " & _
                                        "inner join tb_users c ON a.UserName=c.UserID inner join dt_member d ON b.Member_ID=d.ID " & _
                                        "WHERE UserName='" & Me.tscbStaffName.ComboBox.SelectedValue & "' " & _
                                        "AND LOG_Date BETWEEN '" & var_Date_From & "' " & _
                                        "AND '" & var_Date_To & "' ORDER BY LOG_Date Desc"

            Dim sda As New SqlDataAdapter(_scGetPYr)
            Dim ds As New DataSet
            sda.Fill(ds, "log_member")

            Dim xls_wks_name As String = ""

            Dim drWP As DataRow() = ds.Tables("log_member").Select
            If drWP.Length > 0 Then
                xls_workbook.Worksheets.Add()
                xls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim
                With xls_workbook.Worksheets(xls_wks_name)
                    .Cells(1, 1) = "Staff Activity Details "
                    .Cells(2, 1) = "Staff Name : " & ds.Tables(0).Rows(0)("Staff_Name")
                    .Cells(3, 1) = "Date From :" & var_Date_From & " To : " & var_Date_To

                    .Cells(5, 1) = "NO"
                    .Cells(5, 2) = "FULL NAME"
                    .Cells(5, 3) = "DATE"
                    .Cells(5, 4) = "Time"
                    .Cells(5, 5) = "FILE NO."
                    .Cells(5, 6) = "PROPOSER NAME"
                    .Cells(5, 7) = "ACTIVITY DETAILS"

                    Dim xls_row_counter As Integer = 6
                    Dim var_name_count As Integer = 0

                    Do While var_name_count < drWP.Length
                        .Cells(xls_row_counter, 1) = "'" & (xls_row_counter - 5).ToString.Trim
                        .Cells(xls_row_counter, 2) = "'" & drWP(var_name_count).Item("STAFF_NAME").ToString.Trim
                        .Cells(xls_row_counter, 3) = "'" & Format(drWP(var_name_count).Item("LOG_DATE"), "dd/MM/yyyy")
                        .Cells(xls_row_counter, 4) = "'" & Format(drWP(var_name_count).Item("LOG_DATE"), "HH:mm:ss")
                        .Cells(xls_row_counter, 5) = drWP(var_name_count).Item("Angkasa_FileNo").ToString.Trim
                        .Cells(xls_row_counter, 6) = "'" & drWP(var_name_count).Item("Full_NAME").ToString.Trim
                        .Cells(xls_row_counter, 7) = "'" & drWP(var_name_count).Item("Activity_Detail").ToString.Trim
                        xls_row_counter += 1
                        var_name_count += 1
                    Loop
                End With
            End If
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xls_file.Visible = True
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