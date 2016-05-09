Imports System.IO
Public Class frNonPayment
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Private Sub frNonPayment_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frNonPayment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        eDate = Me.tstxtDateFrom.Text.ToString.Trim()
        strsDate = Format(sDate, "MM/dd/yyyy")
        streDate = Format(eDate, "MM/dd/yyyy")
        ds = _objBusi.getDsDetails_V("NONPAYMENT", strsDate, streDate, "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvPNONPayment
                .DataSource = ds.Tables(0)
                .Columns(0).DisplayIndex = 16
                .Columns(1).DisplayIndex = 16
                .Columns(2).DisplayIndex = 16
                .Columns(3).DisplayIndex = 16
                .Columns(4).Visible = False
                Me.tslblTOT.Text = "Total Record : " & ds.Tables(0).Rows.Count
            End With
        Else
            Me.dgvPNONPayment.DataSource = ds.Tables(0)
            Me.tslblTOT.Text = "Total Record : 0 "
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvRNONPD
                .DataSource = ds.Tables(1)
                .Columns(0).DisplayIndex = 16
                .Columns(1).DisplayIndex = 16
                .Columns(2).DisplayIndex = 16
                .Columns(3).DisplayIndex = 16
                .Columns(4).Visible = False
            End With
        Else
            Me.dgvRNONPD.DataSource = ds.Tables(1)
        End If

        If ds.Tables(2).Rows.Count > 0 Then
            With Me.dgvPendingConfirmation
                .DataSource = ds.Tables(2)
                .Columns(0).Visible = False
                .Columns(1).Visible = False
            End With
        Else
            Me.dgvPendingConfirmation.DataSource = ds.Tables(2)
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