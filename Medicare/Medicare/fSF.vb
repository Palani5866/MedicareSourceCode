Public Class fSF
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Private Sub fSF_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fSF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
        Me.gbDecisionMake.Enabled = False
    End Sub
#Region "Data Bind"
    Private Sub BINDDATA()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _ObjBusi.getDetails_II("SHORTFALL", "", "", "", "", "", "", "", "", "", "S", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvShortfall
                .DataSource = dt

                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                .Columns(4).DefaultCellStyle.Format = "#,##0.00"
                .Columns(5).DefaultCellStyle.Format = "#,##0.00"
                .Columns(6).DefaultCellStyle.Format = "#,##0.00"
                .Columns(7).DefaultCellStyle.Format = "#,##0.00"

                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                Me.ssReport_RecordCount.Text = "Record #: " & dt.Rows.Count.ToString.Trim()
                Me.ssReport_RecordCount.Visible = True
            End With
        Else
            MsgBox("No record found")
            Me.dgvShortfall.DataSource = dt
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub tsbExport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExport2Xcel.Click
        XPort2Xcel()
    End Sub
    Private Sub dgvShortfall_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShortfall.CellContentClick
        With Me.dgvShortfall
            If e.ColumnIndex = 8 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(8).Value = "0" Then
                    Dim vSFD As New rShortFallSummaryDetails
                    vSFD.lblRTYPE.Text = "TOTSHORT"
                    vSFD.lblRTYPE1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 9 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(9).Value = "0" Then
                    Dim vSFD As New rShortFallSummaryDetails
                    vSFD.lblRTYPE.Text = "TOTREQUESTED"
                    vSFD.lblRTYPE1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 10 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(10).Value = "0" Then
                    Dim vSFD As New rShortFallSummaryDetails
                    vSFD.lblRTYPE.Text = "TOTRECOVERED"
                    vSFD.lblRTYPE1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
    End Sub
    Private Sub dgvShortFalls_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShortfall.CellDoubleClick
        With Me.dgvShortfall
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Dim dt, dtPolicy As New DataTable
            dt = _ObjBusi.fShortFalls("SHORTFALL", .SelectedRows(0).Cells(0).Value.ToString.Trim, "", "", "", "", "", "", "", "", "CHECK", Conn)
            dtPolicy = _ObjBusi.fNonPayment("NONPAYMENT", .SelectedRows(0).Cells(0).Value.ToString(), "", "", "", "", "", "", "", "", "ACTION", Conn)
            If dt.Rows.Count > 0 Then
                MsgBox("This record already requested Please do select another record")
                Me.gbDecisionMake.Enabled = False
            Else
                Me.gbDecisionMake.Enabled = True
                Me.txtFullName.Text = dtPolicy.Rows(0)("FULL_NAME")
                Me.txtNRIC.Text = dtPolicy.Rows(0)("IC_NEW")
                Me.lblAMT.Text = dtPolicy.Rows(0)("Deduction_Amount")
                Me.lblREF1.Text = dtPolicy.Rows(0)("PID").ToString().Trim()
                Me.lblREF2.Text = dtPolicy.Rows(0)("MID").ToString().Trim()
                Me.lblREF3.Text = dtPolicy.Rows(0)("Deduction_Code").ToString().Trim()
            End If
        End With
    End Sub
#End Region
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Not Len(Me.txtsfRemarks.Text.Trim()) > 0 Then
            MsgBox("Please do key the remarks!")
            Me.txtsfRemarks.Focus()
            Exit Sub
        End If
        Dim sDecision, sRes As String
        If Me.rbC2Y.Checked Then
            If Not Len(Me.txtPaymentRefNo.Text.Trim()) > 0 Then
                MsgBox("Please do key the Payment Reference Number.!")
                Me.txtPaymentRefNo.Focus()
                Exit Sub
            End If
            If Not Len(Me.txtRecoveredAmt.Text.Trim()) > 0 Then
                MsgBox("Please do key the Amount Received!")
                Me.txtRecoveredAmt.Focus()
                Exit Sub
            End If
            sDecision = "CLIENT PAY DIRECT"
            sRes = _ObjBusi.fINNonPayment("UPDATE", "CLIENT PAY DIRECT", "DP", Me.lblREF1.Text.ToString.Trim(), "", Me.lblREF3.Text.ToString.Trim(), Me.txtRecoveredAmt.Text.Trim(), Me.txtPaymentRefNo.Text.Trim(), Me.txtsfRemarks.Text.Trim(), My.Settings.Username.Trim(), "", Conn)
            If sRes = "1" Then
                MsgBox("Thank you..Your Short fall payment has been received!")
                BINDDATA()
                Me.gbDecisionMake.Enabled = False
                Clearup()
            End If
        ElseIf Me.rbCP.Checked Then
            If Me.cmbCancellation_Reason.SelectedIndex = -1 Then
                MsgBox("Please do select the Cancellation Reason.")
                Me.cmbCancellation_Reason.Focus()
                Exit Sub
            End If
            Dim Result As Integer
            Result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Proceed with the Changes?")
            Select Case Result
                Case 6
                    sRes = _objBusi.fINNonPayment("UPDATE", Me.lblREF2.Text.ToString.Trim(), "UR2C", Me.lblREF1.Text.ToString.Trim(), Format(Me.dtpRequestedDate.Value, "MM/dd/yyyy"), Format(Me.dtpEffective_Date.Value, "MM/dd/yyyy"), Format(Me.dtpPolicy_CancellationDate.Value, "MM/dd/yyyy"), Me.cmbCancellation_Reason.Text.Trim(), Me.txtsfRemarks.Text.Trim(), My.Settings.Username.Trim(), "DECISION", Conn)
                    If sRes = "1" Then
                        MsgBox("Successfully Cancelled the policy.")
                        Me.btnPrint.Enabled = True
                        Me.btnSubmit.Enabled = False
                        Clearup()
                    Else
                        MsgBox("Error while cancelling the policy")
                    End If
                Case 7
                    Exit Sub
            End Select
        ElseIf Me.rbIgnor.Checked Then
            If Not Len(Me.txtRPFrm.Text.Trim()) > 0 Then
                MsgBox("Please do key the Recover Period From!")
                Me.txtRPFrm.Focus()
                Exit Sub
            End If
            If Not Len(Me.txtRPTo.Text.Trim()) > 0 Then
                MsgBox("Please do key the Recover Period To!")
                Me.txtRPTo.Focus()
                Exit Sub
            End If
            If Not Len(Me.txtRequestedAmt.Text.Trim()) > 0 Then
                MsgBox("Please do key the Requesting Amount!")
                Me.txtRequestedAmt.Focus()
                Exit Sub
            End If
            If Not Me.lblAMT.Text.Trim() = Me.txtRequestedAmt.Text.Trim() Then
                MsgBox("You can't request Less/More then deduction amount!")
                Me.txtRequestedAmt.Text = Me.lblAMT.Text.Trim()
            End If
            sDecision = "REQUEST_DA"
            sRes = _objBusi.fINNonPayment("UPDATE", Me.lblREF2.Text.ToString.Trim(), "REQUEST_DA", Me.lblREF1.Text.ToString.Trim(), Me.txtRPFrm.Text.Trim(), Me.txtRPTo.Text.Trim(), Me.txtDCode.Text.Trim(), Me.txtRequestedAmt.Text.Trim(), Me.txtsfRemarks.Text.Trim(), My.Settings.Username.Trim(), "DECISION", Conn)
            If sRes = "1" Then
                MsgBox("Successfully Requested Non Payment")
                BINDDATA()
                Me.gbDecisionMake.Enabled = False
            End If
        End If
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim type As String
        type = Me.cmbCancellation_Reason.SelectedIndex
        Select Case type
            Case "0", "6"
                PrintLetters.Print_Letters("AngkasaCancellation.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "1"
                PrintLetters.Print_Letters("NPL.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "2"
                PrintLetters.Print_Letters("Change2Yearly.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "3"
                PrintLetters.Print_Letters("Due_to_60_Percent.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "4"
                PrintLetters.Print_Letters("No_Deduction_Frm_Angkasa.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "5"
                PrintLetters.Print_Letters("NPCC.rpt", Me.lblREF2.Text.ToString.Trim(), type)
            Case "7"
                PrintLetters.Print_Letters("IncompleteBorang.rpt", Me.lblREF2.Text.ToString.Trim(), type)
        End Select
    End Sub
#Region "Export to Excel"
    Private Sub XPort2Xcel()
        If Me.dgvShortfall.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "SHORTFALL SUMMARY LISTING"
                .Cells(2, 1) = "Exported On : " & Now()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN"
                .Cells(4, 5) = "PHONE HOUSE"
                .Cells(4, 6) = "PHONE MOBILE"
                .Cells(4, 7) = "PHONE OFFICE"
                .Cells(4, 8) = "EMAIL"
                .Cells(4, 9) = "TOTAL SHORT"
                .Cells(4, 10) = "TOTAL REQUESTED"
                .Cells(4, 11) = "TOTAL RECOVERED"
                .Cells(4, 12) = "TOTAL BALANCE"
                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvShortfall.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvShortfall.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvShortfall.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvShortfall.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvShortfall.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvShortfall.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvShortfall.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvShortfall.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvShortfall.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvShortfall.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvShortfall.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvShortfall.Rows(iCount).Cells(11).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
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
#Region "General Functions/Subs"
    Private Sub Clearup()
        Me.txtFullName.Text = ""
        Me.txtNRIC.Text = ""
        Me.txtsfRemarks.Text = ""
        Me.txtRecoveredAmt.Text = ""
        Me.txtPaymentRefNo.Text = ""
        Me.txtRPFrm.Text = ""
        Me.txtRPTo.Text = ""
        Me.txtDCode.Text = ""
    End Sub
#End Region
End Class