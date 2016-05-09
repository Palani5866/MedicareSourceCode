Public Class frmEndorSum
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Dim DateTo, DateFrom As String
#End Region
    Private Sub frmEndorSum_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frmEndorSum_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tstxtDateFrom.Text = Format(Now(), "dd/MM/yyyy")
        Me.tstxtDateTo.Text = Format(Now(), "dd/MM/yyyy")
    End Sub
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        If fVerify() Then
            BINDDATA()
        End If
    End Sub
    Private Sub BINDDATA()
        Dim FromDay As String = Convert.ToDateTime(Me.tstxtDateFrom.Text).Day
        Dim FromMonth As String = Convert.ToDateTime(Me.tstxtDateFrom.Text).Month
        Dim FromYear As String = Convert.ToDateTime(Me.tstxtDateFrom.Text).Year
        DateFrom = FromMonth & "/" & FromDay & "/" & FromYear

        Dim ToDay As String = Convert.ToDateTime(Me.tstxtDateTo.Text).Day
        Dim ToMonth As String = Convert.ToDateTime(Me.tstxtDateTo.Text).Month
        Dim ToYear As String = Convert.ToDateTime(Me.tstxtDateTo.Text).Year
        DateTo = ToMonth & "/" & ToDay & "/" & ToYear

        Dim dt As DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        dt = _ObjBusi.getDetails_IX(Me.lblP1.Text.ToString.Trim(), DateFrom, DateTo, "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvEndorSum
                .DataSource = dt
            End With
        End If
    End Sub
    Private Function fVerify() As Boolean
        If Len(Me.tstxtDateFrom.Text.Trim) = 0 Then
            MsgBox("Please do key in the Date (From) (dd/mm/yyyy).")
            Me.tstxtDateFrom.Focus()
            Return False
        End If
        If Len(Me.tstxtDateTo.Text.Trim) = 0 Then
            MsgBox("Please do key in the Date (To) (dd/mm/yyyy).")
            Me.tstxtDateTo.Focus()
            Return False
        End If
        If IsDate(Me.tstxtDateFrom.Text) = False Then
            MsgBox("Please do key in the Date (From) in the right format (dd/mm/yyyy).")
            Me.tstxtDateFrom.Focus()
            Exit Function
        Else
            If IsDate(Me.tstxtDateTo.Text) = False Then
                MsgBox("Please do key in the  Date (To) in the right format (dd/mm/yyyy).")
                Me.tstxtDateTo.Focus()
                Exit Function
            Else
                If Not Convert.ToDateTime(Me.tstxtDateTo.Text).Date >= Convert.ToDateTime(Me.tstxtDateFrom.Text).Date Then
                    MsgBox("Date (To) is < Date (From).")
                    Me.tstxtDateTo.Focus()
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Private Sub dgvEndorSum_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEndorSum.CellContentClick
        With Me.dgvEndorSum
            If e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(1).Value = "0" Then
                    Dim vSFD As New frmSummaryDetails
                    vSFD.lblP1.Text = "ESD"
                    vSFD.lblP2.Text = DateFrom
                    vSFD.lblP3.Text = DateTo
                    vSFD.lblP4.Text = .Rows(e.RowIndex).Cells(0).Value.ToString.Trim()
                    vSFD.lblP5.Text = "TOTNOOFCASES"
                    vSFD.lblRTYPE.Text = Me.lblP1.Text.ToString.Trim()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(2).Value = "0" Then
                    Dim vSFD As New frmSummaryDetails
                    vSFD.lblP1.Text = "ESD"
                    vSFD.lblP2.Text = DateFrom
                    vSFD.lblP3.Text = DateTo
                    vSFD.lblP4.Text = .Rows(e.RowIndex).Cells(0).Value.ToString.Trim()
                    vSFD.lblP5.Text = "RFI"
                    vSFD.lblRTYPE.Text = Me.lblP1.Text.ToString.Trim()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(3).Value = "0" Then
                    Dim vSFD As New frmSummaryDetails
                    vSFD.lblP1.Text = "ESD"
                    vSFD.lblP2.Text = DateFrom
                    vSFD.lblP3.Text = DateTo
                    vSFD.lblP4.Text = .Rows(e.RowIndex).Cells(0).Value.ToString.Trim()
                    vSFD.lblP5.Text = "PWI"
                    vSFD.lblRTYPE.Text = Me.lblP1.Text.ToString.Trim()
                    vSFD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
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

    Private Sub tsbExport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExport2Xcel.Click
        XPort2Xcel()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvEndorSum.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "ENDORSEMENT SUMMARY DETAILS"
                .Cells(2, 1) = "Exported On : " & Now()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "BATCH NO"
                .Cells(4, 3) = "TOTAL NO OF CASES"
                .Cells(4, 4) = "TOTAL RECEIVED FROM INSURER"
                .Cells(4, 5) = "TOTAL PENDING WITH INSURER"
                
                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvEndorSum.RowCount

                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvEndorSum.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvEndorSum.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvEndorSum.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvEndorSum.Rows(iCount).Cells(3).Value.ToString.Trim
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