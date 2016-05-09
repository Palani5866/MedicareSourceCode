Imports System.Net
Imports System.Web
Imports System
Imports System.IO
Imports System.Text

Public Class fSentSMS
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub fSentSMS_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
    End Sub
    Private Sub fSentSMS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
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
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If Me.txtMsg.Text.Trim = "" Then
            MsgBox("Required the Message!")
            Me.txtMsg.Focus()
            Exit Sub
        End If
        Try
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            'SentSMS()
            ESMS()
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        Catch ex As Exception
            MsgBox("Error while sending message! Please check with administrator!")
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        End Try
    End Sub

    Private Sub SentSMS()
        Dim Msg As String
        Dim wc As New WebClient
        Msg = Me.txtMsg.Text.Trim()
        Dim url As String = "http://210.48.155.79/cmp/MEDI.asp?SMS_OA:63660&SMS_DA:60146619282&SMS_ID:MEDICARE&SMS_MsgData:RM0.00+SRI+You+hv+successfully"
        wc.OpenRead(url)
    End Sub

    Private Sub ESMS()
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim url As String
        Dim username As String = "SRI"
        Dim password As String = "SREE"
        Dim host As String = "http://127.0.0.1:9501"
        Dim originator As String = "60146619282"

        
        Dim sMobile As String
        Dim sSMS As String
        sMobile = "60146619282"
        sSMS = Me.txtMsg.Text.ToString.Trim()
        url = "http://210.48.155.79/cmp/MEDI.asp?SMS_OA:63660&SMS_DA:" & sMobile & "&SMS_ID:MEDICARE&SMS_MsgData:" & sSMS & ""
        request = DirectCast(WebRequest.Create(url), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        MessageBox.Show("Response: " & response.StatusDescription)
    End Sub
End Class