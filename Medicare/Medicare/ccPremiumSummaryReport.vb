Public Class ccPremiumSummaryReport
#Region "Global Veriables"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub ccPremiumSummaryReport_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub ccPremiumSummaryReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        dt = _objBusi.fPremiumSummaryReports("CC", "", "", "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvPSR
                .DataSource = dt
            End With
        Else
            MsgBox("No Record found")
            Me.dgvPSR.DataSource = dt
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub tsbtnExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExporttoExcel.Click
        XPort2Xcel()
    End Sub
    Private Sub dgvPSR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPSR.CellContentClick
        With Me.dgvPSR
            If e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim vPSRD As New PremiumSummaryReportDetails
                vPSRD.lblP2.Text = "EMPLOYEE AND FAMILY ONLY"
                vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                vPSRD.lblP3.Text = "F18TO55"
                vPSRD.lblP4.Text = "CC"
                vPSRD.Show()
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(2).Value = "0" Then
                    Dim vPSRD As New PremiumSummaryReportDetails
                    vPSRD.lblP2.Text = "EMPLOYEE AND FAMILY ONLY"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "F56TO60"
                    vPSRD.lblP4.Text = "CC"
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
                    vPSRD.lblP2.Text = "EMPLOYEE ONLY"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "F18TO55"
                    vPSRD.lblP4.Text = "CC"
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
                    vPSRD.lblP2.Text = "EMPLOYEE ONLY"
                    vPSRD.lblP1.Text = .Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
                    vPSRD.lblP3.Text = "I56TO60"
                    vPSRD.lblP4.Text = "CC"
                    vPSRD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
    End Sub
#End Region
#Region "Export"
    Private Sub XPort2Xcel()
        If Me.dgvPSR.Rows.Count > 0 Then

            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook

            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            Dim xlRG As Microsoft.Office.Interop.Excel.Range
            Dim dt As New DataTable
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            dt = _objBusi.fPremiumSummaryReports("CCPREMIUM", "", "", "", "", "", "", "", "", "", "", Conn)
            Dim aF18TO55, aF56TO60, aI18TO55, aI56TO60 As Double
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If dr("Premium_Code").ToString.Trim() = "CCARE FAMILY MONTHLY" Then
                        If dr("Participant_Type").ToString.Trim() = "MEMBER" And dr("Age_Limit").ToString.Trim() = "18-55" Then
                            aF18TO55 = dr("Premium_Amt")
                        End If
                        If dr("Participant_Type").ToString.Trim() = "MEMBER" And dr("Age_Limit").ToString.Trim() = "56-60" Then
                            aF56TO60 = dr("Premium_Amt")
                        End If
                    ElseIf dr("Premium_Code").ToString.Trim() = "CCARE INDI MONTHLY" Then
                        If dr("Participant_Type").ToString.Trim() = "MEMBER" And dr("Age_Limit").ToString.Trim() = "18-55" Then
                            aI18TO55 = dr("Premium_Amt")
                        End If
                        If dr("Participant_Type").ToString.Trim() = "MEMBER" And dr("Age_Limit").ToString.Trim() = "56-60" Then
                            aI56TO60 = dr("Premium_Amt")
                        End If
                    End If
                Next
            Else
                Exit Sub
            End If
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PREMIUM SUMMARY REPORT (CUEPACS CARE)"

                .Cells(3, 1) = "NO"
                .Cells(3, 2) = "PLAN CODE"
                .Cells(3, 3) = "EMPLOYEE AND FAMILY ONLY"
                .Cells(3, 7) = "EMPLOYEE ONLY"
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
                xlRG = .Cells(3, 7)
                xlRG.Font.Bold = True
                xlRG.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter


                .Range("A1:Z1").Merge()
                .Range("A3:A4").Merge()
                .Range("B3:B4").Merge()
                .Range("C3:F3").Merge()
                .Range("G3:J3").Merge()


                .Cells(4, 3) = "18 TO 55"
                .Cells(4, 4) = "RM"
                .Cells(4, 5) = "56 TO 60"
                .Cells(4, 6) = "RM"
                .Cells(4, 7) = "18 TO 55"
                .Cells(4, 8) = "RM"
                .Cells(4, 9) = "56 TO 60"
                .Cells(4, 10) = "RM"


                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvPSR.RowCount
                    Dim F18TO55, F56TO60, I18TO55, I56TO60 As Double
                    F18TO55 = Me.dgvPSR.Rows(iCount).Cells(1).Value
                    F56TO60 = Me.dgvPSR.Rows(iCount).Cells(2).Value
                    I18TO55 = Me.dgvPSR.Rows(iCount).Cells(3).Value
                    I56TO60 = Me.dgvPSR.Rows(iCount).Cells(4).Value


                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvPSR.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvPSR.Rows(iCount).Cells(1).Value
                    .Cells(xRowCount, 4) = "'" & aF18TO55 * F18TO55
                    .Cells(xRowCount, 5) = "'" & Me.dgvPSR.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & aF56TO60 * F56TO60
                    .Cells(xRowCount, 7) = "'" & Me.dgvPSR.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & aI18TO55 * I18TO55
                    .Cells(xRowCount, 9) = "'" & Me.dgvPSR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & aI56TO60 * I56TO60
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
End Class