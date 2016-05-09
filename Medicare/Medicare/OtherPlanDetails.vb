Public Class OtherPlanDetails
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub OtherPlanDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub OtherPlanDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.Text = "POLICY DETAILS" & Me.lblREF1.Text.Trim()
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        Try
            dt = _objBusi.getDetails_I("POLICYDETAILS", Me.lblREF1.Text.Trim(), "", "", "", "", "", "", "", "", "", Conn)
            If dt.Rows.Count > 0 Then
                With Me.dgvPAYMENTDETAILS
                    .DataSource = dt
                    Me.lblRecordCount.Text = "Total Records : " & dt.Rows.Count
                End With
            Else
                MsgBox("No record found")
                Me.dgvPAYMENTDETAILS.DataSource = dt
                Me.lblRecordCount.Text = "Total Records : " & dt.Rows.Count
            End If
        Catch ex As Exception
            MsgBox("Currenly server busy, Please try again later!")
            Me.dgvPAYMENTDETAILS.DataSource = dt
            Me.lblRecordCount.Text = "Total Records : " & dt.Rows.Count
        End Try
    End Sub
    Private Sub tsbtnXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnXport2Xcel.Click
        XPort2Xcel()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvPAYMENTDETAILS.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY DETAILS FOR " & Me.lblREF1.Text.Trim()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "FILE NO"
                .Cells(4, 3) = "IC"
                .Cells(4, 4) = "FULL NAME"
                .Cells(4, 5) = "PLAN CODE"
                .Cells(4, 6) = "EFFECTIVE DATE "
                .Cells(4, 7) = "PREMIUM"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvPAYMENTDETAILS.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvPAYMENTDETAILS.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvPAYMENTDETAILS.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvPAYMENTDETAILS.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvPAYMENTDETAILS.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvPAYMENTDETAILS.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvPAYMENTDETAILS.Rows(iCount).Cells(5).Value.ToString.Trim
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: POLICY DETAILS")
            xApp.Visible = True
        End If
    End Sub
End Class