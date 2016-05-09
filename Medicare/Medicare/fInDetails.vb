Public Class fInDetails
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub fInDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fInDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Me.Text = "Yearly Submission Details"
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _objBusi.fgetDetailsII("YRRENEWAL", Me.lblREF1.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvD
                .DataSource = dt
                Me.tslblTotalRecords.Text = "Total Records : " & dt.Rows.Count
            End With
        Else
            MsgBox("No record found")
            Me.dgvD.DataSource = dt
            Me.tslblTotalRecords.Text = "Total Records : " & dt.Rows.Count
        End If
    End Sub
    Private Sub btnXPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXPort.Click
        XPort2Xcel()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvD.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "YEARLY SUBMISSION DETAILS"
                .Cells(2, 1) = "EXPORTED ON : " & Now()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "DOC RECEIVED DATE"
                .Cells(4, 3) = "FILE #"
                .Cells(4, 4) = "POLICY #"
                .Cells(4, 5) = "FULL NAME"
                .Cells(4, 6) = "NRIC"
                .Cells(4, 7) = "GROSS PREMIUM"
                .Cells(4, 8) = "PLAN"
                .Cells(4, 9) = "PAYMENT METHOD"
                .Cells(4, 10) = "EFFECTIVE DATE"
                .Cells(4, 11) = "CREDIT CARD - BATCH #"
                .Cells(4, 12) = "CREDIT CARD - APPROVAL CODE"
                .Cells(4, 13) = "CREDIT CARD - INVOICE #"
                .Cells(4, 14) = "CHEQUE #"
                .Cells(4, 15) = "CHEQUE - RECEIPT #"
                .Cells(4, 16) = "CASH - RECEIPT #"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvD.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvD.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvD.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvD.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvD.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvD.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvD.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvD.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvD.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvD.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvD.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvD.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvD.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvD.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvD.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvD.Rows(iCount).Cells(14).Value.ToString.Trim
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