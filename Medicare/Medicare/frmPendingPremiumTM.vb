Public Class frmPendingPremiumTM
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub frmPendingPremiumTM_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frmPendingPremiumTM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tstxtDateFrom.Text = DateSerial(Today.Year, Today.Month + 0, 15)
        Me.tstxtDateTo.Text = DateSerial(Today.Year, Today.Month + 1, 14)
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
                .Columns(0).DisplayIndex = 25
                .Columns(1).DisplayIndex = 25
                .Columns(2).DisplayIndex = 25
                .Columns(3).DisplayIndex = 25
                .Columns(4).DisplayIndex = 25
                .Columns(5).DisplayIndex = 25
                .Columns(6).DisplayIndex = 25
                .Columns(7).DisplayIndex = 25
                .Columns(8).Visible = False
                .Columns(9).Visible = False
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
                .DataSource = ds.Tables(0)
                .Columns(0).DisplayIndex = 27
                .Columns(1).DisplayIndex = 27
                .Columns(2).DisplayIndex = 27
                .Columns(3).DisplayIndex = 27
                .Columns(4).DisplayIndex = 27
                .Columns(5).DisplayIndex = 27
                .Columns(6).DisplayIndex = 27
                .Columns(7).DisplayIndex = 27
                .Columns(8).Visible = False
                .Columns(9).Visible = False
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
            If e.ColumnIndex = 7 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(4).Value = "" Then
                    MsgBox("Please select the declaration!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(5).Value = "" Then
                    MsgBox("Please select the action!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(6).Value = "" Then
                    MsgBox("Please do key in Remarks!")
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(4).Value) Then
                    Dim sDate As DateTime
                    Dim strsDate As String
                    sDate = Convert.ToDateTime(tstxtDateFrom.Text.ToString.Trim())
                    strsDate = Format(sDate, "MM/dd/yyyy")
                    Dim sRes As String
                    sRes = _objBusi.spUpdate("INSERTPP", .Rows(e.RowIndex).Cells(8).Value.ToString.Trim(), "NONPAYMENT", .Rows(e.RowIndex).Cells(4).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(5).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(6).Value.ToString.Trim(), strsDate, My.Settings.Username.ToUpper.ToString.Trim(), "", "", "NONPAYMENT", Conn)
                    _objBusi.spUpdate("UPDATEPP", .Rows(e.RowIndex).Cells(9).Value.ToString.Trim(), "NONPAYMENT", .Rows(e.RowIndex).Cells(4).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(5).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(6).Value.ToString.Trim(), strsDate, My.Settings.Username.ToUpper.ToString.Trim(), "", "", "NONPAYMENT", Conn)
                    If sRes = "1" Then
                        MsgBox("Successfully Submitted!")
                        BINDDATAI()
                    End If
                End If
            ElseIf e.ColumnIndex = 2 Then
                Dim CS As New vCS
                CS.MdiParent = frmMain
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(9).Value.ToString()
                CS.Show()
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(9).Value) Then
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
                        sRes = _objBusi.InsUpsFollowup("INSERT", Guid.NewGuid.ToString().Trim(), .Rows(e.RowIndex).Cells(9).Value.ToString().Trim(), .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(1).Value, My.Settings.Username, "", "", Conn)
                        'If sRes = "1" Then
                        MsgBox("Successfully updated your comments!")
                        BINDDATAI()
                        'End If
                    End If
                Else
                    MsgBox("No Record Found")
                End If
            End If
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
                    .Cells(xRowCount, 2) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(17).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(18).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(19).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(20).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvPNONPayment.Rows(iCount).Cells(21).Value.ToString.Trim
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