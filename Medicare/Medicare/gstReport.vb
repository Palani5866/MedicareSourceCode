Public Class gstReport
#Region "Global Veriable"
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
#End Region
    Private Sub gstReport_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub gstReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindMonths()
    End Sub
    Private Sub BindMonths()
        Dim aMonth As New ArrayList
        Dim p2Yr, cYr, p2M, cM As String
        For p2I As Integer = 0 To 11
            p2M = "0" & p2I + 1
            If p2M.Length = 3 Then
                p2M = p2M.Substring(1, 2)
            End If
            p2Yr = Now.Year() - 1 & p2M
            aMonth.Add(p2Yr)
        Next
        For cI As Integer = 0 To 11
            cM = "0" & cI + 1
            If cM.Length = 3 Then
                cM = cM.Substring(1, 2)
            End If
            cYr = Now.Year() & cM
            aMonth.Add(cYr)
        Next
        Dim s As String
        s = "0" + Now.Month.ToString()
        If s.Length = 3 Then
            s = s.Substring(1, 2)
        End If
        Me.tsReport_ddlMonth.ComboBox.DataSource = aMonth
        Me.tsReport_ddlMonth.ComboBox.Text = Now.Year() & s
    End Sub
    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _objBusi.getDetails_IV("GST", Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            Me.dgvGST.DataSource = dt
        Else
            Me.dgvGST.DataSource = dt
            MsgBox("No Record found!")
        End If
    End Sub
    Private Sub btnExport2Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport2Excel.Click
        xPort2Xcel()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvGST.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PREMIUM GST BY RECEIVING MONTH : " & Me.tsReport_ddlMonth.Text.ToString.Trim()
                .Cells(2, 1) = "EXPORTED ON : " & Now()

                .Cells(4, 1) = "#"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "DEDUCTION AMOUNT"
                .Cells(4, 5) = "RECEIVED AMOUNT"
                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvGST.RowCount - 1
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvGST.Rows(iCount).Cells(0).Value
                    .Cells(xRowCount, 3) = "'" & Me.dgvGST.Rows(iCount).Cells(1).Value
                    .Cells(xRowCount, 4) = "'" & Me.dgvGST.Rows(iCount).Cells(2).Value
                    .Cells(xRowCount, 5) = "'" & Me.dgvGST.Rows(iCount).Cells(3).Value
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