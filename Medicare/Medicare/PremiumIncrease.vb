Public Class PremiumIncrease
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
    Private Sub PremiumIncrease_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub PremiumIncrease_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindMonths()
    End Sub
    Private Sub BindMonths()
        Dim aMonth As New ArrayList
        Dim p1YR, p2Yr, cYr, f1Yr, f2Yr, p1M, p2M, cM, f1M, f2M As String
        
        For cI As Integer = 0 To 11
            cM = "0" & cI + 1
            If cM.Length = 3 Then
                cM = cM.Substring(1, 2)
            End If
            cYr = Now.Year() & cM
            aMonth.Add(cYr)
        Next
        For f1I As Integer = 0 To 11
            f1M = "0" & f1I + 1
            If f1M.Length = 3 Then
                f1M = f1M.Substring(1, 2)
            End If
            f1Yr = Now.Year() + 1 & f1M
            aMonth.Add(f1Yr)
        Next
        For f2I As Integer = 0 To 11
            f2M = "0" & f2I + 1
            If f2M.Length = 3 Then
                f2M = f2M.Substring(1, 2)
            End If
            f2Yr = Now.Year() + 2 & f2M
            aMonth.Add(f2Yr)
        Next
        Me.tsReport_ddlMonth.ComboBox.DataSource = aMonth
    End Sub
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If fValid() Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            BINDDATA()
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        End If
    End Sub
    Private Function fValid() As Boolean
        If Len(Me.tsReport_ddlMonth.Text.Trim()) = 0 Then
            MsgBox("Please select premium increase month!")
            Return False
        End If
        Return True
    End Function
    Private Sub BINDDATA()
        Dim dt As New DataTable
        Select Case Me.lblRF1.Text.Trim()
            Case "CCNEW"
                dt = _objBusi.fPremiumIncrese("CC", Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "", "", "", "", "", "CCNEW", "INCREASE", Conn)
            Case "CPANEW"
                dt = _objBusi.fPremiumIncrese("CPA", Me.tsReport_ddlMonth.Text.ToString.Trim(), "", "", "", "", "", "", "", "CPANEW", "INCREASE", Conn)
        End Select
        If dt.Rows.Count > 0 Then
            With Me.dgvForm
                .DataSource = dt
                .Columns(0).Visible = False 'refid
                Me.ssReport_RecordCount.Text = "Record #: " & dt.Rows.Count.ToString.Trim()
                Me.ssReport_RecordCount.Visible = True
            End With
        Else
            MsgBox("No record found")
            Me.ssReport_RecordCount.Text = "Record #: 0 "
            Me.ssReport_RecordCount.Visible = True
            Me.dgvForm.DataSource = dt
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

    Private Sub btnXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXport2Xcel.Click
        XPort2Xcel()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvForm.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PREMIUM INCREASE/DECREASE DETAILS"
                .Cells(2, 1) = "Exported On : " & Now().ToString.Trim()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "DOB"
                .Cells(4, 5) = "AGE"
                .Cells(4, 6) = "DEDUCTION CODE"
                .Cells(4, 7) = "CURRENT PREMIUM"
                .Cells(4, 8) = "PREMIUM TO REVISE"
                .Cells(4, 9) = "EFFECTIVE DATE"
                .Cells(4, 10) = "PLAN"
                .Cells(4, 11) = "PLAN TYPE"
                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvForm.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvForm.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvForm.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvForm.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvForm.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvForm.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvForm.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvForm.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvForm.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvForm.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvForm.Rows(iCount).Cells(10).Value.ToString.Trim
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
End Class