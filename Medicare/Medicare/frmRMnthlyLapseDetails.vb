Public Class frmRMnthlyLapseDetails
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub frmRMnthlyLapseDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frmRMnthlyLapseDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.getDetails_I("LAPSEPOLICYDETAILS", "", "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvLapseDetails
                .DataSource = dt
            End With
            Me.lblRecordCount.Text = "Total Records : " & dt.Rows.Count
        Else
            Me.dgvLapseDetails.DataSource = dt
            Me.lblRecordCount.Text = "Total Records : " & dt.Rows.Count
        End If
    End Sub
    Private Sub xPort2xCel()
        If Me.dgvLapseDetails.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "LAPSE POLICY DETAILS"

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
                Do While iCount < Me.dgvLapseDetails.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvLapseDetails.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvLapseDetails.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvLapseDetails.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvLapseDetails.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvLapseDetails.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvLapseDetails.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvLapseDetails.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvLapseDetails.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvLapseDetails.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvLapseDetails.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvLapseDetails.Rows(iCount).Cells(10).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: LAPSE POLICY DETAILS")
            xApp.Visible = True
        End If

    End Sub
    Private Sub tsbtnXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnXport2Xcel.Click
        xPort2xCel()
    End Sub
End Class