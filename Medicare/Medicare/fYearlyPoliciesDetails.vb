Public Class fYearlyPoliciesDetails
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub fYearlyPoliciesDetails_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fYearlyPoliciesDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindMonths()
    End Sub
    Private Sub BindMonths()
        Dim aYear As New ArrayList
        aYear.Add(Now.Year() - 1)
        aYear.Add(Now.Year())
        aYear.Add(Now.Year() + 1)
        Me.tscbYear.ComboBox.DataSource = aYear
        Me.tscbYear.ComboBox.Text = Now.Year()
    End Sub
    Private Sub BINDDATA()
        Dim iMonth As Integer
        Select Case Me.tscbMonth.SelectedIndex
            Case "0"
                iMonth = "01"
            Case "1"
                iMonth = "02"
            Case "2"
                iMonth = "03"
            Case "3"
                iMonth = "04"
            Case "4"
                iMonth = "05"
            Case "5"
                iMonth = "06"
            Case "6"
                iMonth = "07"
            Case "7"
                iMonth = "08"
            Case "8"
                iMonth = "09"
            Case "9"
                iMonth = "10"
            Case "10"
                iMonth = "11"
            Case "11"
                iMonth = "12"
        End Select
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _objBusi.getDetails_III("YPM", iMonth, Me.tscbYear.Text.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvYrPolicies
                .DataSource = dt
                Me.ssReport_RecordCount.Text = "Record #: " & Me.dgvYrPolicies.RowCount.ToString
                Me.ssReport_RecordCount.Visible = True
            End With
        Else
            Me.dgvYrPolicies.DataSource = dt
            Me.ssReport_RecordCount.Text = "Record #:0 "
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        If Not Me.tscbMonth.SelectedIndex > -1 Then
            MsgBox("Please select the Month!")
            Me.tscbMonth.Focus()
            Exit Sub
        End If
        BINDDATA()
    End Sub
    Private Sub btnXPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXPort.Click
        Xport2Xcel()
    End Sub
    Private Sub Xport2Xcel()
        If Me.dgvYrPolicies.RowCount > 0 Then
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            Dim dgvrCount As Integer = 0
            Dim xRCount As Integer = 0
            xWB.Worksheets.Add()
            Dim xRange As Microsoft.Office.Interop.Excel.Range
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "YEARLY POLICIES DETAILS "
                .Cells(2, 1) = "Exported On  : " & Now().ToString()
                .Cells(3, 1) = "SELECTED MONTH " & Me.tscbMonth.Text.ToString.Trim() & " YEAR : " & Me.tscbYear.Text.ToString.Trim()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "FILE #"
                .Cells(5, 3) = "IC"
                .Cells(5, 4) = "FULL NAME"
                .Cells(5, 5) = "PLAN"
                .Cells(5, 6) = "PLAN TYPE"
                .Cells(5, 7) = "START DATE"
                .Cells(5, 8) = "END DATE"
                .Cells(5, 9) = "PREMIUM"
                .Cells(5, 10) = "POLICY NO"
                .Cells(5, 11) = "STATUS"
                xRCount = 6

                SharedData.ReadyToHideMarquee = False
                StartMarqueeThread()
                Do While dgvrCount < Me.dgvYrPolicies.Rows.Count
                    .Cells(xRCount, 1) = "'" & (xRCount - 6).ToString.Trim
                    .Cells(xRCount, 2) = "'" & Me.dgvYrPolicies.Rows(dgvrCount).Cells(0).Value
                    .Cells(xRCount, 3) = "'" & Me.dgvYrPolicies.Rows(dgvrCount).Cells(1).Value
                    .Cells(xRCount, 4) = "'" & Me.dgvYrPolicies.Rows(dgvrCount).Cells(2).Value
                    .Cells(xRCount, 5) = "'" & Me.dgvYrPolicies.Rows(dgvrCount).Cells(3).Value
                    .Cells(xRCount, 6) = "'" & Me.dgvYrPolicies.Rows(dgvrCount).Cells(4).Value
                    .Cells(xRCount, 7) = "'" & Me.dgvYrPolicies.Rows(dgvrCount).Cells(5).Value
                    .Cells(xRCount, 8) = "'" & Me.dgvYrPolicies.Rows(dgvrCount).Cells(6).Value
                    .Cells(xRCount, 9) = "'" & FormatNumber(Me.dgvYrPolicies.Rows(dgvrCount).Cells(7).Value, 2)
                    .Cells(xRCount, 10) = "'" & Me.dgvYrPolicies.Rows(dgvrCount).Cells(8).Value
                    .Cells(xRCount, 11) = "'" & Me.dgvYrPolicies.Rows(dgvrCount).Cells(9).Value
                    dgvrCount += 1
                    xRCount += 1
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