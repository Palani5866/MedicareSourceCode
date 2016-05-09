Public Class fNonPayment
    
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub fNonPayment_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fNonPayment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
        Me.gbDecisionMake.Enabled = False
        Me.btnPrint.Enabled = False
    End Sub
#End Region
#Region "Click Events"
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        BINDDATA()
    End Sub
    Private Sub dgvProposer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProposer.CellContentClick
        With Me.dgvProposer
            If e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(5).Value) Then
                    If IsNothing(.Rows(e.RowIndex).Cells(0).Value) Then
                        MsgBox("Please do key in remarks")
                        Exit Sub
                    End If
                    If Not IsNothing(.Rows(e.RowIndex).Cells(1).Value) Then
                        If IsDate(.Rows(e.RowIndex).Cells(1).Value) = False Then
                            MsgBox("Invalid Date Format!")
                            Exit Sub
                        End If
                    End If
                    If MsgBox("Are you sure? You want update this comments", vbYesNo, "Followup") = vbYes Then
                        Dim sRes As String
                        sRes = _objBusi.InsUpsFollowup("INSERT", Guid.NewGuid.ToString().Trim(), .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value, My.Settings.Username, "", "", Conn)

                        MsgBox("Successfully updated your comments!")
                        BINDDATA()

                    End If
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.MdiParent = frmMain
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(5).Value.ToString()
                CS.Show()
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.MdiParent = frmMain
                CS.lblStatus.Text = Me.lblREFTYPE.Text.ToString.Trim()
                CS.lblType.Text = "LIST"
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(5).Value.ToString()
                CS.Show()
            End If
        End With
    End Sub
    Private Sub dgvProposer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProposer.CellDoubleClick
        With Me.dgvProposer
            Dim dt As New DataTable
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            dt = _objBusi.fNonPayment("NONPAYMENT", .SelectedRows(0).Cells(5).Value.ToString(), "", "", "", "", "", "", "", "", "ACTION", Conn)
            If dt.Rows.Count > 0 Then
                Me.gbDecisionMake.Enabled = True
                Me.txtFullName.Text = dt.Rows(0)("FULL_NAME")
                Me.txtNRIC.Text = dt.Rows(0)("IC_NEW")
                Me.lblAMT.Text = dt.Rows(0)("Deduction_Amount")
                Me.lblREF1.Text = dt.Rows(0)("PID").ToString().Trim()
                Me.lblREF2.Text = dt.Rows(0)("MID").ToString().Trim()
                Me.lblREF3.Text = dt.Rows(0)("Deduction_Code").ToString().Trim()
            Else
                Me.gbDecisionMake.Enabled = False
            End If
        End With
    End Sub
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
            sRes = _objBusi.fINNonPayment("UPDATE", "CLIENT PAY DIRECT", "DP", Me.lblREF1.Text.ToString.Trim(), "", Me.lblREF3.Text.ToString.Trim(), Me.txtRecoveredAmt.Text.Trim(), Me.txtPaymentRefNo.Text.Trim(), Me.txtsfRemarks.Text.Trim(), My.Settings.Username.Trim(), "", Conn)
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
    Private Sub tsbtnXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnXport2Xcel.Click
        XPort2Xcel()
    End Sub
#End Region
#Region "Data Bind"
    Private Sub BINDDATA()
        Dim dt As New DataTable
        Try
            If Me.tscbSearch.Text = "IC" Then
                If Me.tstxtSearch.Text.ToString.Trim() = "" Then
                    MsgBox("Please do key in IC / Full Name!")
                    Me.tstxtSearch.Focus()
                    Exit Sub
                End If
                dt = _objBusi.getDetails_I(Me.lblTYPE.Text.Trim(), "IC", Me.tstxtSearch.Text.ToString.Trim(), "", "", "", "", "", "", Me.lblREF1.Text.Trim(), Me.lblREFTYPE.Text.Trim(), Conn)
            ElseIf Me.tscbSearch.Text = "FULL NAME" Then
                If Me.tstxtSearch.Text.ToString.Trim() = "" Then
                    MsgBox("Please do key in IC / Full Name!")
                    Me.tstxtSearch.Focus()
                    Exit Sub
                End If
                dt = _objBusi.getDetails_I(Me.lblTYPE.Text.Trim(), "FULLNAME", Me.tstxtSearch.Text.ToString.Trim(), "", "", "", "", "", "", Me.lblREF1.Text.Trim(), Me.lblREFTYPE.Text.Trim(), Conn)
            Else
                dt = _objBusi.getDetails_I(Me.lblTYPE.Text.Trim(), "", "", "", "", "", "", "", "", Me.lblREF1.Text.Trim(), Me.lblREFTYPE.Text.Trim(), Conn)
            End If
            If dt.Rows.Count > 0 Then
                With Me.dgvProposer
                    .DataSource = dt
                    .Columns(5).Visible = False
                    .Columns(0).DisplayIndex = 19
                    .Columns(1).DisplayIndex = 19
                    .Columns(2).DisplayIndex = 19
                    .Columns(3).DisplayIndex = 19
                    .Columns(4).DisplayIndex = 19

                    .Columns(6).ReadOnly = True
                    .Columns(7).ReadOnly = True
                    .Columns(8).ReadOnly = True
                    .Columns(9).ReadOnly = True
                    .Columns(10).ReadOnly = True
                    .Columns(11).ReadOnly = True
                    .Columns(16).ReadOnly = True
                    .Columns(17).ReadOnly = True
                    .Columns(18).ReadOnly = True
                    .Columns(19).ReadOnly = True
                    Me.lblRecordCount.Text = "Total Records : " & dt.Rows.Count
                End With
            Else
                MsgBox("No record found")
                Me.dgvProposer.DataSource = dt
                Me.lblRecordCount.Text = "Total Records : " & dt.Rows.Count
            End If
        Catch ex As Exception
            MsgBox("Currently our server busy! Please try again later!")
            Me.dgvProposer.DataSource = dt
            Me.lblRecordCount.Text = "Total Records : " & dt.Rows.Count
        End Try
    End Sub
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
#Region "Change Events"
    Private Sub rbC2Y_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbC2Y.CheckedChanged
        If Me.rbC2Y.Checked Then
            Me.txtPaymentRefNo.Enabled = True
            Me.txtRecoveredAmt.Enabled = True
            Me.txtDCode.Enabled = False
            Me.txtRequestedAmt.Enabled = False
            Me.txtRPFrm.Enabled = False
            Me.txtRPTo.Enabled = False
            Me.dtpEffective_Date.Enabled = False
            Me.dtpPolicy_CancellationDate.Enabled = False
            Me.dtpRequestedDate.Enabled = False
            Me.cmbCancellation_Reason.Enabled = False
            Me.txtRequestedAmt.Text = "0.00"
            Me.txtRecoveredAmt.Text = Me.lblAMT.Text.Trim()
        End If
    End Sub
    Private Sub rbIgnor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIgnor.CheckedChanged
        Me.txtPaymentRefNo.Enabled = False
        Me.txtRecoveredAmt.Enabled = False
        Me.txtDCode.Enabled = True
        Me.txtRequestedAmt.Enabled = True
        Me.txtRPFrm.Enabled = True
        Me.txtRPTo.Enabled = True
        Me.dtpEffective_Date.Enabled = False
        Me.dtpPolicy_CancellationDate.Enabled = False
        Me.dtpRequestedDate.Enabled = False
        Me.cmbCancellation_Reason.Enabled = False
        Me.txtRequestedAmt.Text = Me.lblAMT.Text.Trim()
        Me.txtRecoveredAmt.Text = "0.00"
    End Sub
    Private Sub rbCP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCP.CheckedChanged
        Me.txtPaymentRefNo.Enabled = False
        Me.txtRecoveredAmt.Enabled = False
        Me.txtDCode.Enabled = False
        Me.txtRequestedAmt.Enabled = False
        Me.txtRPFrm.Enabled = False
        Me.txtRPTo.Enabled = False
        Me.dtpEffective_Date.Enabled = True
        Me.dtpPolicy_CancellationDate.Enabled = True
        Me.dtpRequestedDate.Enabled = True
        Me.cmbCancellation_Reason.Enabled = True
        Me.txtRequestedAmt.Text = "0.00"
        Me.txtRecoveredAmt.Text = "0.00"
    End Sub
    Private Sub dtpPolicy_CancellationDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPolicy_CancellationDate.ValueChanged
        If Not My.Settings.Username.Trim.ToUpper() = "ADMIN" Then
            If Not dtpPolicy_CancellationDate.Value >= Now() Then
                MsgBox("Invalid date!")
                dtpPolicy_CancellationDate.Value = Now()
            End If
        End If
    End Sub
#End Region
#Region "Export to Excel"
    Private Sub XPort2Xcel()
        If Me.dgvProposer.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "NON PAYMENT DETAILS"

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE NO"
                .Cells(4, 3) = "IC"
                .Cells(4, 4) = "FULL NAME"
                .Cells(4, 5) = "DOB"
                .Cells(4, 6) = "POLICY START DATE"
                .Cells(4, 7) = "NO PAYMENT FROM & PLAN"
                .Cells(4, 8) = "HOUSE CONTACT NO"
                .Cells(4, 9) = "MOBILE NO"
                .Cells(4, 10) = "OFFICE CONTACT NO"
                .Cells(4, 11) = "EMAIL"
                .Cells(4, 12) = "STATUS"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvProposer.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvProposer.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvProposer.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvProposer.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvProposer.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvProposer.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvProposer.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvProposer.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvProposer.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvProposer.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvProposer.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvProposer.Rows(iCount).Cells(16).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: Non Payment DETAILS")
            xApp.Visible = True
        End If
    End Sub
#End Region
End Class