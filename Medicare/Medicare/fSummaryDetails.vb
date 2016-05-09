Public Class fSummaryDetails
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub fSummaryDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fSummaryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim FromDay As String = Convert.ToDateTime(Me.lblDateFrom.Text).Day
        Dim FromMonth As String = Convert.ToDateTime(Me.lblDateFrom.Text).Month
        Dim FromYear As String = Convert.ToDateTime(Me.lblDateFrom.Text).Year
        Dim DateFrom As String = FromMonth & "/" & FromDay & "/" & FromYear

        Dim ToDay As String = Convert.ToDateTime(Me.lblDateTo.Text).Day
        Dim ToMonth As String = Convert.ToDateTime(Me.lblDateTo.Text).Month
        Dim ToYear As String = Convert.ToDateTime(Me.lblDateTo.Text).Year
        Dim DateTo As String = ToMonth & "/" & ToDay & "/" & ToYear
        Dim dt As New DataTable
        If Me.lblP1.Text.Trim() = "MEMBER" Then
            dt = _objBusi.getDetails_I("FSUMMARY", DateFrom, DateTo, Me.lblP1.Text.Trim(), Me.lblP2.Text.Trim(), Me.lblP3.Text.Trim(), Me.lblP4.Text.Trim(), Me.lblP5.Text.Trim(), "", "MEMBER", "DETAILS", Conn)
        Else
            dt = _objBusi.getDetails_I("FSUMMARY", DateFrom, DateTo, Me.lblP1.Text.Trim(), Me.lblP2.Text.Trim(), Me.lblP3.Text.Trim(), Me.lblP4.Text.Trim(), Me.lblP5.Text.Trim(), "", "PROPOSER", "DETAILS", Conn)
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvFSD
                .DataSource = dt
            End With
            Me.tslblTotalRecords.Text = "Total Records : " & dt.Rows.Count
        Else
            MsgBox("No Record found")
            Me.dgvFSD.DataSource = dt
            Me.tslblTotalRecords.Text = "Total Records : 0"
        End If
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvFSD.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "FOLLOW UP SUMMARY DETAIL REPORT"


                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "PLAN TYPE"
                .Cells(4, 6) = "STATUS"
                .Cells(4, 7) = "FOLLOW UP REMARKS"
                .Cells(4, 8) = "FILE NO"
                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvFSD.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvFSD.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvFSD.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvFSD.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvFSD.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvFSD.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvFSD.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvFSD.Rows(iCount).Cells(6).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: FOLLOW UP SUMMARY DETAIL REPORT")
            xApp.Visible = True
        Else
            MsgBox("No Record found!")
        End If
    End Sub
    Private Sub btnXPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXPort.Click
        XPort2Xcel()
    End Sub
End Class