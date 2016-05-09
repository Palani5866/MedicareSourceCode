Public Class fPaymentSummary
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub fPaymentSummary_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub fPaymentSummary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.tstxtDate.Text = Format(Now(), "dd/MM/yyyy")
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
    Private Sub xPort2Xcel4CARD()
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWSName As String = ""
        Dim xRCount As Integer = 0
        Dim dgvrCount As Integer = 0
        xWB.Worksheets.Add()
        xWSName = "Sheet" & xWB.Worksheets.Count.ToString.Trim()

        With xWB.Worksheets(xWSName)
            .Cells(1, 1) = "SUN LIFE MALAYSIA TAKAFUL BERHAD"
            .Cells(2, 1) = "Procedure Title : Payment of Insurance Premium Listing Summary"
            .Cells(3, 1) = "PAYMENT SUMMARY LISTING FOR CREDIT CARD"
            .Cells(4, 1) = "FOR THE DAY : " & Me.tstxtDate.Text.ToString.Trim()
            .Cells(5, 1) = "EXPORTED ON : " & Now()
            .Cells(5, 6) = "Branch : Intania, Klang"

            .Cells(7, 1) = "Date : " & Me.tstxtDate.Text.ToString.Trim()
            .Cells(7, 3) = "Merchant No : 080100944"
            .Cells(7, 5) = "BATCH NO : " & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(6).Value

            .Cells(8, 1) = "NO"
            .Cells(8, 2) = "INSURED NAME"
            .Cells(8, 3) = "IC No."
            .Cells(8, 4) = "CARD TYPE"
            .Cells(8, 5) = "APPROVAL CODE"
            .Cells(8, 6) = "INVOICE NO"
            .Cells(8, 7) = "AMOUNT"
            .Cells(8, 8) = "REMARKS"
            xRCount = 9

            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()

            Dim TotalPremium As Double
            Do While dgvrCount < Me.dgvPaymentSummary.Rows.Count
                .Cells(xRCount, 1) = "'" & (xRCount - 8).ToString.Trim
                .Cells(xRCount, 2) = "'" & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(0).Value
                .Cells(xRCount, 3) = "'" & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(1).Value
                .Cells(xRCount, 4) = "'" & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(2).Value
                .Cells(xRCount, 5) = "'" & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(3).Value
                .Cells(xRCount, 6) = "'" & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(4).Value
                .Cells(xRCount, 7) = "'" & FormatNumber(Me.dgvPaymentSummary.Rows(dgvrCount).Cells(5).Value, 2)
                .Cells(xRCount, 8) = ""

                TotalPremium += Me.dgvPaymentSummary.Rows(dgvrCount).Cells(5).Value
                dgvrCount += 1
                xRCount += 1
            Loop


            .Cells(xRCount + 2, 2) = "TOTAL AS PER THE TERMINAL"
            .Cells(xRCount + 2, 7) = FormatNumber(TotalPremium, 2)


            .Cells(xRCount + 6, 1) = "Signature :"
            .Cells(xRCount + 7, 1) = "Name : "
            .Cells(xRCount + 8, 1) = "Date :"

            .Cells(xRCount + 6, 6) = "Signature :"
            .Cells(xRCount + 7, 6) = "Name : "
            .Cells(xRCount + 8, 6) = "Date :"

            .Cells(xRCount + 10, 1) = "Received at Sun Life"

            .Cells(xRCount + 12, 1) = "Signature :"
            .Cells(xRCount + 13, 1) = "Name : "
            .Cells(xRCount + 14, 1) = "Date :"

            .Cells(xRCount + 17, 1) = "Signature :"
            .Cells(xRCount + 18, 1) = "Name : "
            .Cells(xRCount + 19, 1) = "Date :"

            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        End With
        xApp.Visible = True
    End Sub
    Private Sub xPort2Xcel()
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWSName As String = ""
        Dim xRCount As Integer = 0
        Dim dgvrCount As Integer = 0
        xWB.Worksheets.Add()
        xWSName = "Sheet" & xWB.Worksheets.Count.ToString.Trim()

        With xWB.Worksheets(xWSName)
            .Cells(1, 1) = "SUN LIFE MALAYSIA TAKAFUL BERHAD"
            .Cells(2, 1) = "Procedure Title : Payment of Insurance Premium Listing Summary"
            .Cells(3, 1) = "PAYMENT SUMMARY LISTING FOR CASH AND CHEQUE"
            .Cells(4, 1) = "FOR THE DAY : " & Me.tstxtDate.Text.ToString.Trim()
            .Cells(5, 1) = "EXPORTED ON : " & Now()

            .Cells(7, 1) = "NO"
            .Cells(7, 2) = "INSURED NAME"
            .Cells(7, 3) = "IC No."
            .Cells(7, 4) = "PAYMENT TYPE"
            .Cells(7, 5) = "RECEIPT NO"
            .Cells(7, 6) = "DATE"
            .Cells(7, 7) = "AMOUNT"
            .Cells(7, 8) = "CHEUQE NO"
            .Cells(7, 9) = "REMARKS"
            xRCount = 8
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim TotalPremium As Double
            Do While dgvrCount < Me.dgvPaymentSummary.Rows.Count
                .Cells(xRCount, 1) = "'" & (xRCount - 7).ToString.Trim
                .Cells(xRCount, 2) = "'" & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(0).Value
                .Cells(xRCount, 3) = "'" & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(1).Value
                .Cells(xRCount, 4) = "'" & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(2).Value
                .Cells(xRCount, 5) = "'" & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(3).Value
                .Cells(xRCount, 6) = "'" & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(4).Value
                .Cells(xRCount, 7) = "'" & FormatNumber(Me.dgvPaymentSummary.Rows(dgvrCount).Cells(5).Value, 2)
                .Cells(xRCount, 8) = "'" & Me.dgvPaymentSummary.Rows(dgvrCount).Cells(6).Value
                .Cells(xRCount, 9) = ""
                TotalPremium += Me.dgvPaymentSummary.Rows(dgvrCount).Cells(5).Value
                dgvrCount += 1
                xRCount += 1
            Loop

            .Cells(xRCount + 2, 2) = "TOTAL "
            .Cells(xRCount + 2, 7) = FormatNumber(TotalPremium, 2)


            
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        End With
        xApp.Visible = True
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        'To Date
        Dim varDay As String = Convert.ToDateTime(Me.tstxtDate.Text).Day
        Dim varMonth As String = Convert.ToDateTime(Me.tstxtDate.Text).Month
        Dim varYear As String = Convert.ToDateTime(Me.tstxtDate.Text).Year
        Dim varDate As String = varMonth & "/" & varDay & "/" & varYear
        
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim sBy As String
        Select Case Me.tscbSearchBy.SelectedIndex
            Case 0
                sBy = "CREDITCARD"
            Case 1
                sBy = "CASH"
        End Select
        dt = _objBusi.getDetails_VI("PAYMENTSUMMARY", sBy, varDate, "", "", "", "", "", "", "", "", Conn)

        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvPaymentSummary
                .DataSource = dt
                .Columns(5).DefaultCellStyle.Format = "#,##0.00"
                
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
        Else
            Me.dgvPaymentSummary.DataSource = dt
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        If Me.tscbSearchBy.SelectedIndex = -1 Then
            MsgBox("Required Search By")
            Me.tscbSearchBy.Focus()
            Exit Sub
        End If
        If Len(Me.tstxtDate.Text.Trim) = 0 Then
            MsgBox("Required date (dd/mm/yyyy).")
            Me.tstxtDate.Focus()
            Exit Sub
        End If
        If IsDate(Me.tstxtDate.Text) = False Then
            MsgBox("Invalid From date (dd/mm/yyyy).")
            Me.tstxtDate.Focus()
            Exit Sub
        Else
            BINDDATA()
        End If
    End Sub
    Private Sub tsReport_Xport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Xport.Click
        If Me.tscbSearchBy.SelectedIndex = 0 Then
            xPort2Xcel4CARD()
        Else
            xPort2Xcel()
        End If
    End Sub
End Class