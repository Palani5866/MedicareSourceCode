Public Class fSFnNPCall
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Private Sub fSFnNPCall_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fSFnNPCall_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        ds = _ObjBusi.getDsDetails_VIII("SFnNPR", Me.lblP1.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvNPnSF
                .DataSource = ds.Tables(0)
                Me.tslblTot.Text = "Total Records : " & ds.Tables(0).Rows.Count

                .Columns(21).DefaultCellStyle.Format = "#,#00.00"
                .Columns(22).DefaultCellStyle.Format = "#,#00.00"
                .Columns(23).DefaultCellStyle.Format = "#,#00.00"
                .Columns(24).DefaultCellStyle.Format = "#,#00.00"
                .Columns(25).DefaultCellStyle.Format = "#,#00.00"
                .Columns(26).DefaultCellStyle.Format = "#,#00.00"

                .Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvNPnSF.DataSource = ds.Tables(0)
            Me.tslblTot.Text = "Total Records : 0"
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvShortFallsDetails
                .DataSource = ds.Tables(1)
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).Visible = False
                .Columns(3).Visible = False

                .Columns(15).DefaultCellStyle.Format = "#,##0.00"
                .Columns(16).DefaultCellStyle.Format = "#,##0.00"
                .Columns(17).DefaultCellStyle.Format = "#,##0.00"

                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
        Else
            Me.dgvShortFallsDetails.DataSource = ds.Tables(1)
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
    Private Sub tsbExport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExport2Xcel.Click
        xPort2Xcel()
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
                    .Cells(xRowCount, 2) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 10) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 11) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(10).Value.ToString.Trim
                    .Cells(xRowCount, 12) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(11).Value.ToString.Trim
                    .Cells(xRowCount, 13) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(12).Value.ToString.Trim
                    .Cells(xRowCount, 14) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 15) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(14).Value.ToString.Trim
                    .Cells(xRowCount, 16) = "'" & Me.dgvNPnSF.Rows(iCount).Cells(15).Value.ToString.Trim
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
            If e.ColumnIndex = 22 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(22).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "NONPAYMENT"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(8).Value.ToString()
                    VD.lblP3.Text = "NONPAYMENT"
                    VD.Show()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 23 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(23).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "TOTSHORT"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(8).Value.ToString()
                    VD.lblP3.Text = "SHORTFALL"
                    VD.ShowDialog()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 24 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(24).Value = "0" Then
                    MsgBox("There is no break down details on this request!")
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 25 Then
                If Not .Rows(e.RowIndex).Cells(25).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "TOTREQUESTED"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(8).Value.ToString()
                    VD.lblP3.Text = "REQUEST"
                    VD.ShowDialog()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 26 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not .Rows(e.RowIndex).Cells(26).Value = "0" Then
                    Dim VD As New fViewDetails
                    VD.lblP1.Text = "TOTRECOVERED"
                    VD.lblP2.Text = .Rows(e.RowIndex).Cells(8).Value.ToString()
                    VD.lblP3.Text = "RECOVER"
                    VD.ShowDialog()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 6 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(7).Value) Then
                    Dim CS As New vCS
                    CS.lblPID.Text = .Rows(e.RowIndex).Cells(7).Value.ToString()
                    CS.lblType.Text = "SHORTFALLFWUP"
                    CS.ShowDialog()
                Else
                    MsgBox("No Record Found")
                End If
            ElseIf e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(3).Value = "" Then
                    If .Rows(e.RowIndex).Cells(0).Value = "" Then
                        MsgBox("Please do key in the comments!")
                        Exit Sub
                    End If

                    If .Rows(e.RowIndex).Cells(1).Value = "" Then
                        MsgBox("Please do key in the reminder date!")
                        Exit Sub
                    End If
                    If Not IsDate(.Rows(e.RowIndex).Cells(1).Value) Then
                        MsgBox("Please do key in valid date!")
                        Exit Sub
                    End If
                    Dim sRDate As String
                    Dim rDate As Date
                    sRDate = .Rows(e.RowIndex).Cells(1).Value.ToString()
                    rDate = Convert.ToDateTime(sRDate)
                    If Not IsDBNull(.Rows(e.RowIndex).Cells(7).Value) Then
                        Dim sRes As String
                        sRes = _ObjBusi.spUpdate("NONSFOLLOWUP", .Rows(e.RowIndex).Cells(7).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(0).Value.ToString(), Format(rDate, "MM/dd/yyyy"), My.Settings.Username.ToUpper.ToString.Trim(), "", "", "", "", "", "", Conn)
                        If sRes = "1" Then
                            MsgBox("Successfully submitted your comments!")
                            BINDDATA()
                        Else
                            MsgBox("Error while submiting the comments, Please check with admin!")
                        End If
                    Else
                        MsgBox("No Record Found")
                    End If
                Else
                    If .Rows(e.RowIndex).Cells(4).Value = "" Then
                        MsgBox("Please select user to assign!")
                        Exit Sub
                    End If
                    If Not IsDBNull(.Rows(e.RowIndex).Cells(8).Value) Then
                        Dim sRes As String
                        sRes = _ObjBusi.fInUpSFNONPFUP("INSERT", Guid.NewGuid.ToString.Trim(), .Rows(e.RowIndex).Cells(8).Value.ToString(), .Rows(e.RowIndex).Cells(3).Value.ToString.Trim(), "", "", "", .Rows(e.RowIndex).Cells(22).Value, .Rows(e.RowIndex).Cells(23).Value, .Rows(e.RowIndex).Cells(24).Value, .Rows(e.RowIndex).Cells(25).Value, .Rows(e.RowIndex).Cells(26).Value, .Rows(e.RowIndex).Cells(27).Value, "OPEN", "", .Rows(e.RowIndex).Cells(4).Value.ToString.Trim(), My.Settings.Username.ToUpper.ToString.Trim(), Conn)
                        _ObjBusi.fInUpSFNONPFUP("UPDATE", .Rows(e.RowIndex).Cells(7).Value.ToString(), .Rows(e.RowIndex).Cells(8).Value.ToString(), "", "", "", "", .Rows(e.RowIndex).Cells(22).Value, .Rows(e.RowIndex).Cells(23).Value, .Rows(e.RowIndex).Cells(24).Value, .Rows(e.RowIndex).Cells(25).Value, .Rows(e.RowIndex).Cells(26).Value, .Rows(e.RowIndex).Cells(27).Value, "CLOSED", "", .Rows(e.RowIndex).Cells(4).Value.ToString.Trim(), My.Settings.Username.ToUpper.ToString.Trim(), Conn)
                        If sRes = "1" Then
                            MsgBox("Successfully submitted your request!")
                            BINDDATA()
                        Else
                            MsgBox("Error while submiting the request, Please check with admin!")
                        End If
                    Else
                        MsgBox("No Record Found")
                    End If
                End If
            End If
        End With
    End Sub
End Class