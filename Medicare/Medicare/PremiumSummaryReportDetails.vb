Public Class PremiumSummaryReportDetails
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub PremiumSummaryReportDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub PremiumSummaryReportDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        If Me.lblP4.Text = "CC" Then
            dt = _objBusi.fPremiumSummaryReportsDetails("CCD", Me.lblP1.Text.ToString.Trim(), Me.lblP2.Text.ToString.Trim(), "", "", "", "", "", "", "", Me.lblP3.Text.ToString.Trim(), Conn)
        Else
            dt = _objBusi.fPremiumSummaryReportsDetails("CPAD", Me.lblP1.Text.ToString.Trim(), Me.lblP2.Text.ToString.Trim(), "", "", "", "", "", "", "", Me.lblP3.Text.ToString.Trim(), Conn)
        End If

        If dt.Rows.Count > 0 Then
            With Me.dgvPSRDetails
                .DataSource = dt
                Me.tslblTotalRecords.Text = "Total Records : " & dt.Rows.Count
            End With
        Else
            MsgBox("No Record found")
            Me.dgvPSRDetails.DataSource = dt
            Me.tslblTotalRecords.Text = "Total Records : " & dt.Rows.Count
        End If
    End Sub
    Private Sub tsbtnExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExporttoExcel.Click
        If Me.lblP3.Text.Trim() = "MEMBER" Then
            XPort2XcelM()
        Else
            XPort2Xcel()
        End If

    End Sub
    Private Sub XPort2XcelM()
        If Me.dgvPSRDetails.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook

            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PREMIUM SUMMARY REPORT (CUEPACS PA) DETAILS"
                .Cells(2, 1) = "For : " & Me.lblP1.Text.Trim()
                .Cells(3, 1) = "For : " & Me.lblP2.Text.Trim()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE NO"
                .Cells(4, 3) = "TITLE"
                .Cells(4, 4) = "IC"
                .Cells(4, 5) = "NAME"
                .Cells(4, 6) = "DOB"
                .Cells(4, 7) = "PLAN CODE"
                .Cells(4, 8) = "PLAN TYPE"
                .Cells(4, 9) = "START DATE"
                .Cells(4, 10) = "STATUS"
                .Cells(4, 11) = "ADD1"
                .Cells(4, 12) = "ADD2"
                .Cells(4, 13) = "ADD3"
                .Cells(4, 14) = "ADD4"
                .Cells(4, 15) = "TOWN"
                .Cells(4, 16) = "POST CODE"
                .Cells(4, 17) = "STATE"
                .Cells(4, 18) = "PHONE HOUSE"
                .Cells(4, 19) = "PHONE MOBILE"
                .Cells(4, 20) = "PHONE OFFICE"
                .Cells(4, 21) = "EMAIL"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvPSRDetails.RowCount

                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 17) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 18) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 19) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(17).Value.ToString.Trim
                    .Cells(xRowCount, 20) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(18).Value.ToString.Trim
                    .Cells(xRowCount, 21) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(19).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: PRODUCTION SUMMARY REPORT")
            xApp.Visible = True
        End If
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvPSRDetails.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook

            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PREMIUM SUMMARY REPORT (CUEPACS PA) DETAILS"
                .Cells(2, 1) = "For : " & Me.lblP1.Text.Trim()
                .Cells(3, 1) = "For : " & Me.lblP2.Text.Trim()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE NO"
                .Cells(4, 3) = "PH IC"
                .Cells(4, 4) = "PH NAME"
                .Cells(4, 5) = "TITLE"
                .Cells(4, 6) = "IC"
                .Cells(4, 7) = "NAME"
                .Cells(4, 8) = "DOB"
                .Cells(4, 9) = "PLAN CODE"
                .Cells(4, 10) = "PLAN TYPE"
                .Cells(4, 11) = "START DATE"
                .Cells(4, 12) = "STATUS"
                .Cells(4, 13) = "ADD1"
                .Cells(4, 14) = "ADD2"
                .Cells(4, 15) = "ADD3"
                .Cells(4, 16) = "ADD4"
                .Cells(4, 17) = "TOWN"
                .Cells(4, 18) = "POST CODE"
                .Cells(4, 19) = "STATE"
                .Cells(4, 20) = "PHONE HOUSE"
                .Cells(4, 21) = "PHONE MOBILE"
                .Cells(4, 22) = "PHONE OFFICE"
                .Cells(4, 23) = "EMAIL"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvPSRDetails.RowCount

                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 17) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 18) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 19) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(17).Value.ToString.Trim
                    .Cells(xRowCount, 20) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(18).Value.ToString.Trim
                    .Cells(xRowCount, 21) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(19).Value.ToString.Trim
                    .Cells(xRowCount, 22) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(20).Value.ToString.Trim
                    .Cells(xRowCount, 23) = "'" & Me.dgvPSRDetails.Rows(iCount).Cells(21).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: PRODUCTION SUMMARY REPORT")
            xApp.Visible = True
        End If
    End Sub
End Class