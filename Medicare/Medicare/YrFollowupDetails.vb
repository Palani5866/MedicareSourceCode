Public Class YrFollowupDetails
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub YrFollowupDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub YrFollowupDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.fYRFS("SUMMARYDETAILS", "", "", "", "", "", "", "", "", "", Me.lblREF1.Text.ToString.Trim(), Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvYRFSD
                .DataSource = dt
                Me.tslblTotalRecords.Text = "Total Records : " & dt.Rows.Count
            End With
        Else
            MsgBox("No record found")
            Me.dgvYRFSD.DataSource = dt
            Me.tslblTotalRecords.Text = "Total Records : " & dt.Rows.Count
        End If
    End Sub
    Private Sub btnXPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXPort.Click
        XPort2Xcel()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvYRFSD.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "FOLLOW UP SUMMARY REPORT DETAILS "
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE NO"
                .Cells(4, 3) = "IC"
                .Cells(4, 4) = "FULL NAME"
                .Cells(4, 5) = "PLAN TYPE"
                .Cells(4, 6) = "START DATE"
                .Cells(4, 7) = "END DATE"
                .Cells(4, 8) = "PREMIUM"
                .Cells(4, 9) = "LAST COMMENT"
                .Cells(4, 10) = "LAST COMMENT ON"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvYRFSD.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvYRFSD.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvYRFSD.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvYRFSD.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvYRFSD.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvYRFSD.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvYRFSD.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvYRFSD.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvYRFSD.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvYRFSD.Rows(iCount).Cells(8).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: FOLLOW UP SUMMARY REPORT DETAILS")
            xApp.Visible = True
        End If
    End Sub
End Class