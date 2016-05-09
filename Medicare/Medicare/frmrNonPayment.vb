Public Class frmrNonPayment
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub frmrNonPayment_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If

    End Sub

    Private Sub frmrNonPayment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tstxtDateFrom.Text = Format(Now, "dd/MM/yyyy")
        Me.tstxtDateTo.Text = Format(Now, "dd/MM/yyyy")
    End Sub
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim sDate, eDate As DateTime
        Dim strsDate, streDate As String
        sDate = Me.tstxtDateFrom.Text.ToString.Trim()
        eDate = Me.tstxtDateTo.Text.ToString.Trim()
        strsDate = Format(sDate, "MM/dd/yyyy")
        streDate = Format(eDate, "MM/dd/yyyy")
        ds = _objBusi.getDsDetails_V("RNONPAYMENT", strsDate, streDate, "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvNP
                .DataSource = ds.Tables(0)
                Me.tslblTOT.Text = "Total Record : " & ds.Tables(0).Rows.Count
            End With
        Else
            Me.dgvNP.DataSource = ds.Tables(0)
            Me.tslblTOT.Text = "Total Record : 0 "
        End If
    End Sub
    Private Sub tsbtnExporttoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExporttoExcel.Click
        Xport2Xcel()
    End Sub
    Private Sub Xport2Xcel()
        If Me.dgvNP.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "NON PAYMENT POLICY DETAILS"
                .Cells(2, 1) = "FOR DATE FROM " & Me.tstxtDateFrom.Text.ToString.Trim() & " To : " & Me.tstxtDateTo.Text.ToString.Trim()
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "DOB"
                .Cells(5, 5) = "START DATE"
                .Cells(5, 6) = "PLAN"
                .Cells(5, 7) = "PLAN TYPE"
                .Cells(5, 8) = "HOUSE CONTACT"
                .Cells(5, 9) = "MOBILE"
                .Cells(5, 10) = "OFFICE #"
                .Cells(5, 11) = "EMAIL"
                .Cells(5, 12) = "FILE #"
                .Cells(5, 13) = "STATUS"
                .Cells(5, 14) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvNP.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvNP.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvNP.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvNP.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvNP.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvNP.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvNP.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvNP.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvNP.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvNP.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvNP.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvNP.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvNP.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 14) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
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