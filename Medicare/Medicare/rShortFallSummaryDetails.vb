Public Class rShortFallSummaryDetails
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
#End Region
    Private Sub rShortFallSummaryDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub rShortFallSummaryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
#Region "Data Bind"
    Private Sub BINDDATA()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _ObjBusi.getDetails_II("SHORTFALL", Me.lblRTYPE.Text.ToString.Trim(), Me.lblRTYPE1.Text.ToString.Trim(), "", "", "", "", "", "", "", "D", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvShortfallDetails
                .DataSource = dt
                .Columns(0).Visible = False
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                Select Case Me.lblRTYPE.Text.ToString.Trim()
                    Case "TOTSHORT"
                        .Columns(7).DefaultCellStyle.Format = "#,##0.00"
                        .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    Case "TOTREQUESTED"
                        .Columns(7).DefaultCellStyle.Format = "#,##0.00"
                        .Columns(8).DefaultCellStyle.Format = "#,##0.00"
                        .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    Case "TOTRECOVERED"
                        .Columns(7).DefaultCellStyle.Format = "#,##0.00"
                        .Columns(8).DefaultCellStyle.Format = "#,##0.00"
                        .Columns(9).DefaultCellStyle.Format = "#,##0.00"
                        .Columns(10).DefaultCellStyle.Format = "#,##0.00"
                        .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                End Select
                Me.ssReport_RecordCount.Text = "Record #: " & dt.Rows.Count.ToString.Trim()
                Me.ssReport_RecordCount.Visible = True
            End With
        Else
            MsgBox("No record found")
            Me.dgvShortfallDetails.DataSource = dt
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

    Private Sub tsbExport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExport2Xcel.Click
        XPort2Xcel()
    End Sub
#Region "Export to Excel"
    Private Sub XPort2Xcel()
        If Me.dgvShortfallDetails.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "SHORTFALL SUMMARY DETAILS LISTING"
                .Cells(2, 1) = "Exported On : " & Now()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN"
                .Cells(4, 5) = "DEDUCTION MONTH"
                .Cells(4, 6) = "RECEIVING MONTH"
                .Cells(4, 7) = "LAST RECOVERING PERIOD"
                .Cells(4, 8) = "SHORT AMOUNT"
                Select Case Me.lblRTYPE.Text.ToString.Trim()
                    Case "TOTSHORT"

                    Case "TOTREQUESTED"
                        .Cells(4, 9) = "REQUESTED AMOUNT"
                    Case "TOTRECOVERED"
                        .Cells(4, 9) = "REQUESTED AMOUNT"
                        .Cells(4, 10) = "RECOVERED AMOUNT"
                        .Cells(4, 11) = "BALANCE AMOUNT"
                End Select
                
                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvShortfallDetails.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                    Select Case Me.lblRTYPE.Text.ToString.Trim()
                        Case "TOTSHORT"
                            .Cells(xRowCount, 8) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                        Case "TOTREQUESTED"
                            .Cells(xRowCount, 8) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                            .Cells(xRowCount, 9) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(8).Value.ToString.Trim
                        Case "TOTRECOVERED"
                            .Cells(xRowCount, 8) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                            .Cells(xRowCount, 9) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(8).Value.ToString.Trim
                            .Cells(xRowCount, 10) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                            .Cells(xRowCount, 11) = "'" & Me.dgvShortfallDetails.Rows(iCount).Cells(10).Value.ToString.Trim
                    End Select
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
End Class