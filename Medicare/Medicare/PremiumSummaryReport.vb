Public Class PremiumSummaryReport
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub PremiumSummaryReport_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub PremiumSummaryReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
        Me.Text = "Premium Summary Report (CUEPACS PA)"
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.fPremiumSummaryReports("CPA", "", "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvPSR

                .DataSource = dt
                
            End With
        Else
            MsgBox("No Record found")
            Me.dgvPSR.DataSource = dt
        End If
    End Sub
    Private Sub tsbtnExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExporttoExcel.Click
        XPort2Xcel()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvPSR.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook

            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            Dim xlRG As Microsoft.Office.Interop.Excel.Range
            Dim dt As New DataTable
            dt = _objBusi.fPremiumSummaryReports("PREMIUM", "", "", "", "", "", "", "", "", "", "", Conn)
            Dim paM, paS, paC12, paC18, paC23, paCA23, pbM, pbS, pbC12, pbC18, pbC23, pbCA23 As Double
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If dr("Premium_Code").ToString.Trim() = "CUEPACS-PA-PLAN A-MONTHLY" Then
                        If dr("Participant_Type").ToString.Trim() = "MEMBER" Then
                            paM = dr("Premium_Amt")
                        End If
                        If dr("Participant_Type").ToString.Trim() = "SPOUSE" Then
                            paS = dr("Premium_Amt")
                        End If
                        If dr("Participant_Type").ToString.Trim() = "CHILD" And dr("Age_Limit").ToString.Trim() = "0-12" Then
                            paC12 = dr("Premium_Amt")
                        End If
                        If dr("Participant_Type").ToString.Trim() = "CHILD" And dr("Age_Limit").ToString.Trim() = "13-17" Then
                            paC18 = dr("Premium_Amt")
                        End If
                        If dr("Participant_Type").ToString.Trim() = "CHILD" And dr("Age_Limit").ToString.Trim() = "18-23" Then
                            paC23 = dr("Premium_Amt")
                        End If
                    ElseIf dr("Premium_Code").ToString.Trim() = "CUEPACS-PA-PLAN B-MONTHLY" Then
                        If dr("Participant_Type").ToString.Trim() = "MEMBER" Then
                            pbM = dr("Premium_Amt")
                        End If
                        If dr("Participant_Type").ToString.Trim() = "SPOUSE" Then
                            pbS = dr("Premium_Amt")
                        End If
                        If dr("Participant_Type").ToString.Trim() = "CHILD" And dr("Age_Limit").ToString.Trim() = "0-12" Then
                            pbC12 = dr("Premium_Amt")
                        End If
                        If dr("Participant_Type").ToString.Trim() = "CHILD" And dr("Age_Limit").ToString.Trim() = "13-17" Then
                            pbC18 = dr("Premium_Amt")
                        End If
                        If dr("Participant_Type").ToString.Trim() = "CHILD" And dr("Age_Limit").ToString.Trim() = "18-23" Then
                            pbC23 = dr("Premium_Amt")
                        End If
                    End If
                Next
            Else
                Exit Sub
            End If
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PREMIUM SUMMARY REPORT (CUEPACS PA)"

                .Cells(3, 1) = "NO"
                .Cells(3, 2) = "PLAN CODE"
                .Cells(3, 3) = "CUEPACS PA PLAN A"
                .Cells(3, 15) = "CUEPACS PA PLAN B"
                '

                xlRG = .Cells(1, 1)
                xlRG.Font.Bold = True
                xlRG.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                xlRG = .Cells(3, 1)
                xlRG.Font.Bold = True
                xlRG.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                xlRG = .Cells(3, 2)
                xlRG.Font.Bold = True
                xlRG.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                xlRG = .Cells(3, 3)
                xlRG.Font.Bold = True
                xlRG.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                xlRG = .Cells(3, 15)
                xlRG.Font.Bold = True
                xlRG.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter


                .Range("A1:Z1").Merge()
                .Range("A3:A4").Merge()
                .Range("B3:B4").Merge()
                .Range("C3:N3").Merge()
                .Range("O3:Z3").Merge()


                .Cells(4, 3) = "MEMBER"
                .Cells(4, 4) = "RM"
                .Cells(4, 5) = "SPOUSE"
                .Cells(4, 6) = "RM"
                .Cells(4, 7) = "CHILD UNDER 12"
                .Cells(4, 8) = "RM"
                .Cells(4, 9) = "CHILD UNDER 18"
                .Cells(4, 10) = "RM"
                .Cells(4, 11) = "CHILD UNDER 23"
                .Cells(4, 12) = "RM"
                .Cells(4, 13) = "CHILD ABOVE 23"
                .Cells(4, 14) = "RM"
                .Cells(4, 15) = "MEMBER"
                .Cells(4, 16) = "RM"
                .Cells(4, 17) = "SPOUSE"
                .Cells(4, 18) = "RM"
                .Cells(4, 19) = "CHILD UNDER 12"
                .Cells(4, 20) = "RM"
                .Cells(4, 21) = "CHILD UNDER 18"
                .Cells(4, 22) = "RM"
                .Cells(4, 23) = "CHILD UNDER 23"
                .Cells(4, 24) = "RM"
                .Cells(4, 25) = "CHILD ABOVE 23"
                .Cells(4, 26) = "RM"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvPSR.RowCount
                    Dim paMA, paSA, paC12A, paC18A, paC23A, paCA23A, pbMA, pbSA, pbC12A, pbC18A, pbC23A, pbCA23A As Double
                    paMA = Me.dgvPSR.Rows(iCount).Cells(1).Value
                    paSA = Me.dgvPSR.Rows(iCount).Cells(2).Value
                    paC12A = Me.dgvPSR.Rows(iCount).Cells(3).Value
                    paC18A = Me.dgvPSR.Rows(iCount).Cells(4).Value
                    paC23A = Me.dgvPSR.Rows(iCount).Cells(5).Value
                    paCA23A = Me.dgvPSR.Rows(iCount).Cells(6).Value
                    pbMA = Me.dgvPSR.Rows(iCount).Cells(7).Value
                    pbSA = Me.dgvPSR.Rows(iCount).Cells(8).Value
                    pbC12A = Me.dgvPSR.Rows(iCount).Cells(9).Value
                    pbC18A = Me.dgvPSR.Rows(iCount).Cells(10).Value
                    pbC23A = Me.dgvPSR.Rows(iCount).Cells(11).Value
                    pbCA23A = Me.dgvPSR.Rows(iCount).Cells(12).Value

                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvPSR.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvPSR.Rows(iCount).Cells(1).Value
                    .Cells(xRowCount, 4) = "'" & paMA * paM
                    .Cells(xRowCount, 5) = "'" & Me.dgvPSR.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & paSA * paS
                    .Cells(xRowCount, 7) = "'" & Me.dgvPSR.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & paC12A * paC12
                    .Cells(xRowCount, 9) = "'" & Me.dgvPSR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & paC18A * paC18
                    .Cells(xRowCount, 11) = "'" & Me.dgvPSR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & paC23A * paC23
                    .Cells(xRowCount, 13) = "'" & Me.dgvPSR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & paCA23A * paCA23
                    .Cells(xRowCount, 15) = "'" & Me.dgvPSR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & pbMA * pbM
                    .Cells(xRowCount, 17) = "'" & Me.dgvPSR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 18) = "'" & pbSA * pbS
                    .Cells(xRowCount, 19) = "'" & Me.dgvPSR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 20) = "'" & pbC12A * pbC12
                    .Cells(xRowCount, 21) = "'" & Me.dgvPSR.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 22) = "'" & pbC18A * pbC18
                    .Cells(xRowCount, 23) = "'" & Me.dgvPSR.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 24) = "'" & pbC23A * pbC23
                    .Cells(xRowCount, 25) = "'" & Me.dgvPSR.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 26) = "'" & pbCA23A * pbCA23
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: PREMIUM SUMMARY REPORT CUEPACS PA")
            xApp.Visible = True
        End If
    End Sub
    Private Sub dgvPSR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPSR.CellContentClick
        With Me.dgvPSR
            If e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim vPSRD As New PremiumSummaryReportDetails
                vPSRD.lblP2.Text = "CUEPACS PA PLAN A"
                vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                vPSRD.lblP3.Text = "MEMBER"
                vPSRD.Show()
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(2).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "CUEPACS PA PLAN A"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "SPOUSE"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(3).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "CUEPACS PA PLAN A"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "CHILD12"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(4).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "CUEPACS PA PLAN A"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "CHILD18"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(5).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "CUEPACS PA PLAN A"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "CHILD23"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 6 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(6).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "CUEPACS PA PLAN A"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "CHILDABOVE23"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 7 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(7).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "CUEPACS PA PLAN B"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "MEMBER"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 8 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(8).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "CUEPACS PA PLAN B"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "SPOUSE"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 9 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(9).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "CUEPACS PA PLAN B"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "CHILD12"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 10 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(10).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "CUEPACS PA PLAN B"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "CHILD18"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 11 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(11).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "CUEPACS PA PLAN B"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "CHILD23"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 12 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(12).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "CUEPACS PA PLAN B"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "CHILDABOVE23"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            End If

        End With
    End Sub
End Class