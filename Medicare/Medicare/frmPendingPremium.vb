Public Class frmPendingPremium
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub frmPendingPremium_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frmPendingPremium_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tstxtDateFrom.Text = DateSerial(Today.Year, Today.Month + 0, 15)
        Me.tstxtDateTo.Text = DateSerial(Today.Year, Today.Month + 1, 14)
        Me.gbDecision.Enabled = False
        BINDDATAI()
    End Sub
    Private Sub BINDDATA()
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim sDate, eDate As DateTime
        Dim strsDate, streDate As String
        sDate = Me.tstxtDateFrom.Text.ToString.Trim()
        eDate = Me.tstxtDateFrom.Text.ToString.Trim()
        strsDate = Format(sDate, "MM/dd/yyyy")
        streDate = Format(eDate, "MM/dd/yyyy")
        ds = _objBusi.getDsDetails_V("NONPAYMENT", strsDate, streDate, "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvPNONPayment
                .DataSource = ds.Tables(0)
                .Columns(0).DisplayIndex = 16
                .Columns(1).DisplayIndex = 16
                .Columns(2).DisplayIndex = 16
                .Columns(3).DisplayIndex = 16
                .Columns(4).Visible = False
            End With
        Else
            Me.dgvPNONPayment.DataSource = ds.Tables(1)
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvPaymentDetails
                .DataSource = ds.Tables(1)
                .Columns(0).Visible = False
                .Columns(1).Visible = False
            End With
        Else
            Me.dgvPaymentDetails.DataSource = ds.Tables(1)
        End If
    End Sub
    Private Sub BINDDATAI()
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim sDate, eDate As DateTime
        Dim strsDate, streDate As String
        sDate = Me.tstxtDateFrom.Text.ToString.Trim()
        eDate = Me.tstxtDateFrom.Text.ToString.Trim()
        strsDate = Format(sDate, "MM/dd/yyyy")
        streDate = Format(eDate, "MM/dd/yyyy")
        ds = _objBusi.getDsDetails_V("NONPAYMENT", strsDate, streDate, "", "", "", "", "", "", "", Me.lblREFTYPE.Text.Trim(), Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvPNONPayment
                .DataSource = ds.Tables(0)
                .Columns(0).DisplayIndex = 22
                .Columns(1).DisplayIndex = 22
                .Columns(2).DisplayIndex = 22
                .Columns(3).DisplayIndex = 22
                .Columns(4).Visible = False
                .Columns(5).Visible = False
            End With
        Else
            Me.dgvPNONPayment.DataSource = ds.Tables(1)
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvPaymentDetails
                .DataSource = ds.Tables(1)
                .Columns(0).Visible = False
                .Columns(1).Visible = False
            End With
        Else
            Me.dgvPaymentDetails.DataSource = ds.Tables(1)
        End If
    End Sub
    Private Sub tstxtDateFrom_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstxtDateFrom.Leave
        Dim sDate As DateTime
        sDate = Convert.ToDateTime(tstxtDateFrom.Text.ToString.Trim())
        Me.tstxtDateFrom.Text = DateSerial(sDate.Year, sDate.Month + 0, 15)
        Me.tstxtDateTo.Text = DateSerial(sDate.Year, sDate.Month + 1, 14)
    End Sub
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        If Me.lblREFTYPE.Text.ToString.Trim() = "" Then
            BINDDATA()
        Else
            BINDDATAI()
        End If
    End Sub
    Private Sub dgvPNONPayment_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPNONPayment.CellContentClick
        With Me.dgvPNONPayment
            If e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(0).Value = "" Then
                    MsgBox("Please select the declaration!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(1).Value = "" Then
                    MsgBox("Please select the action!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(2).Value = "" Then
                    MsgBox("Please do key in Remarks!")
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(4).Value) Then
                    Dim sDate As DateTime
                    Dim strsDate As String
                    sDate = Convert.ToDateTime(tstxtDateFrom.Text.ToString.Trim())
                    strsDate = Format(sDate, "MM/dd/yyyy")
                    Dim sRes As String
                    sRes = _objBusi.spUpdate("INSERTPP", .Rows(e.RowIndex).Cells(4).Value.ToString.Trim(), "NONPAYMENT", .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(2).Value.ToString.Trim(), strsDate, My.Settings.Username.ToUpper.ToString.Trim(), "", "", "NONPAYMENT", Conn)
                    _objBusi.spUpdate("UPDATEPP", .Rows(e.RowIndex).Cells(5).Value.ToString.Trim(), "NONPAYMENT", .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), strsDate, My.Settings.Username.ToUpper.ToString.Trim(), "", "", "NONPAYMENT", Conn)
                    If sRes = "1" Then
                        MsgBox("Successfully Submitted!")
                        If Me.lblREFTYPE.Text.ToString.Trim() = "" Then
                            BINDDATA()
                        Else
                            BINDDATAI()
                        End If
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub dgvPNONPayment_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPNONPayment.CellDoubleClick
        If Me.dgvPNONPayment.SelectedRows.Count > 0 Then
            With Me.dgvPNONPayment
                Dim dt As New DataTable
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Me.gbDecision.Enabled = True
                Me.btnPrint.Enabled = False
                Me.btnSubmit.Enabled = True
                Me.btnCancel.Enabled = True
                Me.lblREFID.Text = .SelectedRows(0).Cells(4).Value.ToString()
                Me.lblPREMIUM.Text = .SelectedRows(0).Cells(7).Value.ToString()
                Me.lblRID.Text = .SelectedRows(0).Cells(5).Value.ToString()
            End With
        End If
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
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.lblREFID.Text = "REFID"
        Me.gbDecision.Enabled = False
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.Verify_Endorsement_Details = True Then
            Dim Result As Integer
            Result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Proceed with the Changes?")
            Select Case Result
                Case 6
                    If Me.Endorse_Changes = True Then
                        _objBusi.spUpdate("UPDATEPP", Me.lblRID.Text.ToString.Trim(), "NONPAYMENT", "", "", "", "", My.Settings.Username.ToUpper.ToString.Trim(), "", "", "NONPAYMENT", Conn)
                        MsgBox("Endorsement successfully.")
                        Me.btnPrint.Enabled = True
                        Me.btnSubmit.Enabled = False
                    Else
                        MsgBox("Error in endorsing this record.")
                    End If
                Case 7
                    Exit Sub
            End Select
        End If
    End Sub
    Private Function Endorse_Changes() As Boolean
        Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy.CommandType = CommandType.Text
        cmdSelect_MemberPolicy.CommandText = "SELECT * FROM dt_Member_Policy " & _
                                             "WHERE ID = '" & Me.lblREFID.Text.Trim & "'"
        Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)

        Dim cmdInsert_MemberPolicy As SqlCommandBuilder
        cmdInsert_MemberPolicy = New SqlCommandBuilder(da_MemberPolicy)

        Dim cmdSelect_MemberLog As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberLog.CommandType = CommandType.Text
        cmdSelect_MemberLog.CommandText = "SELECT * FROM log_Member " & _
                                          "WHERE Member_Policy_ID = '" & Me.lblREFID.Text.Trim & "'"
        Dim da_MemberLog As New SqlDataAdapter(cmdSelect_MemberLog)

        Dim cmdInsert_MemberLog As SqlCommandBuilder
        cmdInsert_MemberLog = New SqlCommandBuilder(da_MemberLog)

        Dim cmdSelect_Member_Endorsement As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Member_Endorsement.CommandType = CommandType.Text
        cmdSelect_Member_Endorsement.CommandText = "SELECT * FROM dt_Member_Endorsement"
        Dim da_Member_Endorsement As New SqlDataAdapter(cmdSelect_Member_Endorsement)

        Dim cmdInsert_Member_Endorsement As SqlCommandBuilder
        cmdInsert_Member_Endorsement = New SqlCommandBuilder(da_Member_Endorsement)

        Dim ds_Endorsement As New DataSet

        Try
            da_MemberPolicy.Fill(ds_Endorsement, "dt_Member_Policy")
            da_MemberLog.Fill(ds_Endorsement, "log_Member")
            da_Member_Endorsement.Fill(ds_Endorsement, "dt_Member_Endorsement")


            With ds_Endorsement.Tables("dt_Member_Policy").Rows(0)
                .Item("Cancellation_Date") = Me.dtpPolicy_CancellationDate.Value
                .Item("Status") = Me.cmbCancellation_Reason.SelectedItem.ToString.Trim
                .Item("Remarks") = "Policy Cancelled"
                .Item("Last_Modified_By") = My.Settings.Username.Trim
                .Item("Last_Modified_On") = Now()
            End With

            da_MemberPolicy.Update(ds_Endorsement, "dt_Member_Policy")

            _objBusi.InsUpsPremiumHistory("CANCELLATION", Guid.NewGuid.ToString.Trim(), Me.lblREFID.Text.Trim, "", Format(Me.dtpPolicy_CancellationDate.Value, "MM/dd/yyyy"), Me.lblPREMIUM.Text.Trim(), "InActive", Me.txtRemark.Text.ToString.Trim(), My.Settings.Username, Conn)



            _objBusi.InsUpsPolicyPremiumHistory("CANCELLATION", Me.lblREFID.Text.ToString.Trim(), "0.00", "", Format(Me.dtpPolicy_CancellationDate.Value, "MM/dd/yyyy"), Me.txtRemark.Text.ToString.Trim(), My.Settings.Username, Conn)



            Dim dr_MemberLog As DataRow
            dr_MemberLog = ds_Endorsement.Tables("log_Member").NewRow

            With dr_MemberLog
                .Item("Member_Policy_ID") = Me.lblREFID.Text.Trim
                .Item("Log_Date") = Now()
                .Item("Activity_Detail") = "Policy cancelled/lapsed."
                .Item("Username") = My.Settings.Username.Trim
                .Item("Created_By") = My.Settings.Username.Trim
                .Item("Created_On") = Now()
            End With

            ds_Endorsement.Tables("log_Member").Rows.Add(dr_MemberLog)
            da_MemberLog.Update(ds_Endorsement, "log_Member")

            Dim dr_Member_Endorsement_New As DataRow
            dr_Member_Endorsement_New = ds_Endorsement.Tables("dt_Member_Endorsement").NewRow

            With dr_Member_Endorsement_New
                .Item("Member_ID") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Member_ID").ToString
                .Item("Member_Policy_ID") = Me.lblREFID.Text.Trim
                .Item("Log_Date") = Now()
                .Item("Endorsement_Type") = "C"
                .Item("Endorsement_Detail") = "Policy cancelled. Reason for cancellation: " & Me.cmbCancellation_Reason.SelectedItem.ToString.Trim & _
                                              ", effective from " & Format(Me.dtpPolicy_CancellationDate.Value, "dd/MM/yyyy") & "."
                .Item("Request_Date") = Me.dtpRequestedDate.Value
                .Item("TRANS_TYPE") = "POLICY CANCELLED"
                .Item("Remark") = Me.txtRemark.Text.ToString.Trim
                .Item("Username") = My.Settings.Username.Trim
                .Item("Created_By") = My.Settings.Username.Trim
                .Item("Created_On") = Now()
                .Item("Effective_Date") = dtpEffective_Date.Value
            End With

            ds_Endorsement.Tables("dt_Member_Endorsement").Rows.Add(dr_Member_Endorsement_New)
            da_Member_Endorsement.Update(ds_Endorsement, "dt_Member_Endorsement")


            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim type As String
        type = Me.cmbCancellation_Reason.SelectedIndex
        Select Case type
            Case "0", "6"
                PrintLetters.Print_Letters("AngkasaCancellation.rpt", Me.lblREFID.Text.Trim, type)
            Case "1"
                PrintLetters.Print_Letters("NPL.rpt", Me.lblREFID.Text.Trim, type)
            Case "2"
                PrintLetters.Print_Letters("Change2Yearly.rpt", Me.lblREFID.Text.Trim, type)
            Case "3"
                PrintLetters.Print_Letters("Due_to_60_Percent.rpt", Me.lblREFID.Text.Trim, type)
            Case "4"
                PrintLetters.Print_Letters("No_Deduction_Frm_Angkasa.rpt", Me.lblREFID.Text.Trim, type)
            Case "5"
                PrintLetters.Print_Letters("NPCC.rpt", Me.lblREFID.Text.Trim, type)
            Case "7"
                PrintLetters.Print_Letters("IncompleteBorang.rpt", Me.lblREFID.Text.Trim, type)
        End Select
    End Sub
    Private Function Verify_Endorsement_Details() As Boolean
        If Me.lblREFID.Text = "REFID" Then
            MsgBox("Please do select the Member Policy.")
            Return False
        Else
            If Me.cmbCancellation_Reason.SelectedIndex = -1 Then
                MsgBox("Please do select the Cancellation Reason.")
                Me.cmbCancellation_Reason.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub dtpPolicy_CancellationDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPolicy_CancellationDate.ValueChanged
        If Not (My.Settings.Username.Trim.ToUpper() = "ADMIN" Or My.Settings.Username.Trim.ToUpper() = "SRI") Then
            If Not dtpPolicy_CancellationDate.Value >= Now() Then
                MsgBox("Invalid date!")
                dtpPolicy_CancellationDate.Value = Now()
            End If
        End If
    End Sub
    Private Sub tsbtnExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExporttoExcel.Click
        Xport2Xcel()
    End Sub
    Private Sub Xport2Xcel()
        If Me.dgvPNONPayment.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "NON PAYMENT POLICY DETAILS"
                .Cells(2, 1) = "FOR DATE FROM " & Me.tstxtDateFrom.Text.ToString.Trim() & " To : " & Me.tstxtDateTo.Text.ToString.Trim()
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "DOB"
                .Cells(5, 5) = "START DATE"
                .Cells(5, 6) = "PLAN"
                .Cells(5, 7) = "PLAN TYPE"
                .Cells(5, 8) = "HOUSE CONTACT"
                .Cells(5, 9) = "MOBILE"
                .Cells(5, 10) = "OFFICE #"
                .Cells(5, 11) = "EMAIL"
                .Cells(5, 12) = "FILE #"
                .Cells(5, 13) = "STATUS"
                .Cells(5, 14) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvPNONPayment.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 14) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
End Class