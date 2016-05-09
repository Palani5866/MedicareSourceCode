Public Class AgentComSum
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub AgentComSum_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub AgentComSum_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.rbSubmissionofDate.Checked = True
        Me.txtRMFROM.Visible = False
        Me.txtRMTO.Visible = False
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        If Not Me.cbProduct.SelectedIndex > -1 Then
            MsgBox("Please do key in the Product Type!")
            Me.cbProduct.Focus()
            Exit Sub
        End If
        If Me.rbSubmissionofDate.Checked Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            dt = _objBusi.getDetails_IV("ACS", "SDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), "", "", "", "", "", "", Conn)
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        ElseIf Me.rbReceivedMonth.Checked Then
            If Len(Me.txtRMFROM.Text.Trim) = 0 Then
                MsgBox("Please do key in the Receiving Month - From (yyyymm).")
                Me.txtRMFROM.Focus()
                Exit Sub
            End If

            If Len(Me.txtRMTO.Text.Trim) = 0 Then
                MsgBox("Please do key in the Receiving Month - To (yyyymm).")
                Me.txtRMTO.Focus()
                Exit Sub
            End If
            If IsNumeric(Me.txtRMFROM.Text) = False Then
                MsgBox("Please do key in the Receiving Month - From in the right format (yyyymm).")
                Me.txtRMFROM.Focus()
                Exit Sub
            Else
                If IsNumeric(Me.txtRMTO.Text) = False Then
                    MsgBox("Please do key in the Receiving Month - To date in the right format (yyyymm).")
                    Me.txtRMTO.Focus()
                    Exit Sub
                Else
                    Try
                        If Convert.ToUInt32(Me.txtRMTO.Text) >= Convert.ToUInt32(Me.txtRMFROM.Text) Then
                            SharedData.ReadyToHideMarquee = False
                            StartMarqueeThread()
                            dt = _objBusi.getDetails_IV("ACS", "RMONTH", Me.cbProduct.Text.ToString.Trim(), Me.txtRMFROM.Text.ToString.Trim(), Me.txtRMTO.Text.ToString.Trim(), "", "", "", "", "", "", Conn)
                            SyncLock SharedData
                                SharedData.ReadyToHideMarquee = True
                            End SyncLock
                            Application.DoEvents()
                        End If
                    Catch ex As Exception

                    End Try
                End If
            End If
        ElseIf Me.rbReceivedDate.Checked Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            dt = _objBusi.getDetails_IV("ACS", "PRDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), "", "", "", "", "", "", Conn)
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvACDetails
                .DataSource = dt
            End With
        Else
            MsgBox("No record found!")
            Me.dgvACDetails.DataSource = dt
        End If
    End Sub
    Private Sub rbSubmissionofDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSubmissionofDate.CheckedChanged
        rbChanged()
    End Sub
    Private Sub rbReceivedMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReceivedMonth.CheckedChanged
        rbChanged()
    End Sub
    Private Sub rbReceivedDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReceivedDate.CheckedChanged
        rbChanged()
    End Sub
    Private Sub rbChanged()
        If Me.rbSubmissionofDate.Checked Then
            Me.lblPeriod.Text = "Period of Submission Date"
            Me.dtpPeriodFrm.Visible = True
            Me.dtpPeriodTo.Visible = True
            Me.txtRMFROM.Visible = False
            Me.txtRMTO.Visible = False
        ElseIf Me.rbReceivedMonth.Checked Then
            Me.lblPeriod.Text = "Period of Received Month"
            Me.dtpPeriodFrm.Visible = False
            Me.dtpPeriodTo.Visible = False
            Me.txtRMFROM.Visible = True
            Me.txtRMTO.Visible = True
            Me.txtRMFROM.Text = Format(Now().Year, "0000").ToString & Format(Now.Month, "00").ToString
            Me.txtRMTO.Text = Format(Now().Year, "0000").ToString & Format(Now.Month, "00").ToString
        ElseIf Me.rbReceivedDate.Checked Then
            Me.lblPeriod.Text = "Period of Received Date"
            Me.dtpPeriodFrm.Visible = True
            Me.dtpPeriodTo.Visible = True
            Me.txtRMFROM.Visible = False
            Me.txtRMTO.Visible = False
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

    Private Sub XPort2Xcel()
        If Me.dgvACDetails.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "SUMMARY AGENT COMISSION LISTING FOR " & Me.cbProduct.Text.ToString.Trim()
                .Cells(2, 1) = "FOR THE MONTH OF " & Me.txtRMFROM.Text.Trim()
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "#"
                .Cells(5, 2) = "AGENT CODE"
                .Cells(5, 3) = "AGENT NAME"
                If Me.cbProduct.Text.ToString.Trim() = "CUEPACSCARE" Then
                    .Cells(5, 4) = "COMMISSION 4 % (RM)"
                Else
                    .Cells(5, 4) = "COMMISSION 7 % (RM)"
                End If
                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvACDetails.RowCount - 1
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvACDetails.Rows(iCount).Cells(0).Value
                    .Cells(xRowCount, 3) = "'" & Me.dgvACDetails.Rows(iCount).Cells(1).Value
                    .Cells(xRowCount, 4) = "'" & Me.dgvACDetails.Rows(iCount).Cells(2).Value
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
    Private Sub llXport2Xcel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llXport2Xcel.LinkClicked
        XPort2Xcel()
    End Sub

End Class