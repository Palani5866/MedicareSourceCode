Public Class rShortfallSummary
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
#End Region
#Region "Page Events"
    Private Sub rShortfallSummary_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub rShortfallSummary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
#End Region
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
#Region "Click Events"
    Private Sub tsbExport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExport2Xcel.Click
        XPort2Xcel()
    End Sub
#End Region
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
                .Cells(4, 5) = "TOTAL SHORT"
                .Cells(4, 6) = "TOTAL REQUESTED"
                .Cells(4, 7) = "TOTAL RECOVERED"
                .Cells(4, 8) = "TOTAL BALANCE"
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
    Private Sub dgvShortfall_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShortfall.CellContentClick
        With Me.dgvShortfall
            If e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(4).Value = "0" Then
                    Dim vSFD As New rShortFallSummaryDetails
                    vSFD.lblRTYPE.Text = "TOTSHORT"
                    vSFD.lblRTYPE1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(5).Value = "0" Then
                    Dim vSFD As New rShortFallSummaryDetails
                    vSFD.lblRTYPE.Text = "TOTREQUESTED"
                    vSFD.lblRTYPE1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 6 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(6).Value = "0" Then
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
            dtPolicy = _ObjBusi.fShortFalls("POLICY", .SelectedRows(0).Cells(0).Value.ToString.Trim, "", "", "", "", "", "", "", "", "CHECK", Conn)
            If dt.Rows.Count > 0 Then
                MsgBox("This record already requested Please do select another record")
            Else
                Dim rSF As New RecoverShortFall
                rSF.MdiParent = frmMain
                rSF.lblREFID.Text = .SelectedRows(0).Cells(0).Value.ToString.Trim
                rSF.txtNRIC.Text = .SelectedRows(0).Cells(1).Value.ToString.Trim
                rSF.txtFullName.Text = .SelectedRows(0).Cells(2).Value.ToString.Trim
                rSF.txtDeductionCode.Text = dtPolicy.Rows(0)("DEDUCTION_CODE").ToString.Trim()
                rSF.txtShortAmt.Text = FormatNumber(.SelectedRows(0).Cells(4).Value.ToString.Trim.Replace("-", ""), 2)
                rSF.txtRequestedAmt.Text = FormatNumber(.SelectedRows(0).Cells(5).Value.ToString.Trim.Replace("-", ""), 2)
                
                rSF.Show()
            End If
        End With
    End Sub
End Class