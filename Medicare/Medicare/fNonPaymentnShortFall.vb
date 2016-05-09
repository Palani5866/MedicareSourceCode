Public Class fNonPaymentnShortFall
#Region "Global Veriable"
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
    Dim PSTATUS As String
    Dim RAMOUNT As Double
#End Region
    Private Sub fNonPaymentnShortFall_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fNonPaymentnShortFall_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        ds = _objBusi.getDsDetails_VIII("SFnNONP", "", "", "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvNPnSF
                .DataSource = ds.Tables(0)
                Me.tslblRecordCounter.Text = "Total Records :  " & ds.Tables(0).Rows.Count.ToString()
                
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"
                .Columns(17).DefaultCellStyle.Format = "#,#00.00"
                .Columns(18).DefaultCellStyle.Format = "#,#00.00"
                .Columns(19).DefaultCellStyle.Format = "#,#00.00"
                .Columns(20).DefaultCellStyle.Format = "#,#00.00"
                .Columns(21).DefaultCellStyle.Format = "#,#00.00"
                .Columns(22).DefaultCellStyle.Format = "#,#00.00"

                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvNPnSF.DataSource = ds.Tables(0)
            Me.tslblRecordCounter.Text = "Total Records : 0 "
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
    Private Sub tsbtnXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnXport2Xcel.Click
        Xport2Xcel()
    End Sub
    Private Sub Xport2Xcel()
        If Me.dgvNPnSF.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "NON PAYMENT AND SHORT FALL POLICY DETAILS"
                .Cells(2, 1) = "EXPORTED ON : " & Now()

                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "DOB"
                .Cells(4, 6) = "PLAN"
                .Cells(4, 7) = "PLAN TYPE"
                .Cells(4, 7) = "POLICY START DATE"
                .Cells(4, 8) = "STATUS"
                .Cells(4, 9) = "FILE NO"
                .Cells(4, 10) = "TOTAL NON PAYMENT"
                .Cells(4, 11) = "TOTAL SHORT"
                .Cells(4, 12) = "TOTAL SHORT NOT REQUESTED"
                .Cells(4, 13) = "TOTAL SHORT REQUESTED"
                .Cells(4, 14) = "TOTAL SHORT RECEOVED"
                .Cells(4, 15) = "TOTAL SHORT BALANCE"
                .Cells(4, 16) = "TOTAL AMOUNT"

                Dim xRowCount As Integer = 5
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvNPnSF.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(15).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(16).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(17).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(18).Value.ToString.Trim
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
    Private Sub dgvNPnSF_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNPnSF.CellContentClick
        With Me.dgvNPnSF
            If e.ColumnIndex = 16 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(16).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "NONPAYMENT"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(3).Value.ToString()
                    VD.lblP3.Text = "NONPAYMENT"
                    VD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 17 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(17).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "TOTSHORT"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(3).Value.ToString()
                    VD.lblP3.Text = "SHORTFALL"
                    VD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 18 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(14).Value = "0" Then
                    MsgBox("There is no break down details on this request!")
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 19 Then
                If Not .Rows(e.RowIndex).Cells(19).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "TOTREQUESTED"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(3).Value.ToString()
                    VD.lblP3.Text = "REQUEST"
                    VD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 20 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(20).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "TOTRECOVERED"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(3).Value.ToString()
                    VD.lblP3.Text = "RECOVER"
                    VD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(0).Value = "" Then
                    MsgBox("Please select the action!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(1).Value = "" Then
                    MsgBox("Please select user to assign!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(0).Value = "PREMIUM REQUEST" Then
                    If .Rows(e.RowIndex).Cells(18).Value = "0" Then
                        If .Rows(e.RowIndex).Cells(16).Value = "0" Then
                            MsgBox("There no pending premium to request!")
                            Exit Sub
                        End If
                    End If
                End If

                If Not IsDBNull(.Rows(e.RowIndex).Cells(3).Value) Then
                    Dim sRes As String
                    sRes = _objBusi.fInUpSFNONPFUP("INSERT", Guid.NewGuid.ToString.Trim(), .Rows(e.RowIndex).Cells(3).Value.ToString(), .Rows(e.RowIndex).Cells(0).Value.ToString.Trim(), "", "", "", .Rows(e.RowIndex).Cells(16).Value, .Rows(e.RowIndex).Cells(17).Value, .Rows(e.RowIndex).Cells(18).Value, .Rows(e.RowIndex).Cells(19).Value, .Rows(e.RowIndex).Cells(20).Value, .Rows(e.RowIndex).Cells(21).Value, "OPEN", "", .Rows(e.RowIndex).Cells(1).Value.ToString.Trim(), My.Settings.Username.ToUpper.ToString.Trim(), Conn)
                    If sRes = "1" Then
                        MsgBox("Successfully submitted your request!")
                        BINDDATA1()
                    Else
                        MsgBox("Error while submiting the request, Please check with admin!")
                    End If
                Else
                    MsgBox("No Record Found")
                End If
            End If
        End With
    End Sub
    Private Sub BINDDATA1()
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        ds = _objBusi.getDsDetails_VIII("SFnNONP1", "", "", "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvNPnSF
                .DataSource = ds.Tables(0)
                Me.tslblRecordCounter.Text = "Total Records :  " & ds.Tables(0).Rows.Count.ToString()
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"
                .Columns(17).DefaultCellStyle.Format = "#,#00.00"
                .Columns(18).DefaultCellStyle.Format = "#,#00.00"
                .Columns(19).DefaultCellStyle.Format = "#,#00.00"
                .Columns(20).DefaultCellStyle.Format = "#,#00.00"
                .Columns(21).DefaultCellStyle.Format = "#,#00.00"
                .Columns(22).DefaultCellStyle.Format = "#,#00.00"

                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvNPnSF.DataSource = ds.Tables(0)
            Me.tslblRecordCounter.Text = "Total Records : 0 "
        End If
    End Sub
End Class