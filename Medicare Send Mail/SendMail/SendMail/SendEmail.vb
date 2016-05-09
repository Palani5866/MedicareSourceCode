Imports System.Net.Mail
Imports System.IO
Imports System.Web
Imports System.Data.SqlClient
Module SendEmail
#Region "Global Veriable"
    Dim sqlConn As New SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("SQL_Conn"))
    Dim _objBusi As New BAL
#End Region
    Sub Main()
        Try
            If sqlConn.State = ConnectionState.Closed Then
                sqlConn.Open()
            End If
        Catch ex As Exception
            Dim sqlConn As New SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("SQL_ConnDB2"))
            If sqlConn.State = ConnectionState.Closed Then
                sqlConn.Open()
            End If
        End Try
        SMSIncomplete()
        SMSUW()
        SMSCOMPLETED()
        SMSYPR()
    End Sub
#Region "INCOMPLETE"
    Private Sub SMSIncomplete()
        Dim ds As New DataSet
        ds = _objBusi.getSMS("SMS", "", "", "", "", "", "", "", "", "INCOMPLETE", "SENDMAIL", sqlConn)
        Dim sMsg, sSub, sHeader, sFooter As String
        Dim i As Integer = 1
        sSub = "PROPOSER DETAILS TO SEND SMS FOR INCOMPLETE DOCUMENTS "
        sHeader = "Dear Sir/Madam, <br><br><br> "
        sHeader = sHeader & " Below enclosed proposer details of incomplete documents.<br><br><br>"
        sFooter = "Thanks & Regards,<br>"
        sFooter = sFooter & " System Admin,<br> "
        sFooter = sFooter & " Medicare Assistance Sdn Bhd,<br><br><br><br> "
        sFooter = sFooter & " Note : This is a system generated email please do not reply.<br><br><br><br>"
        sMsg = ""

        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWName As String = ""
        Dim _FileName As String = "PIN" & DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() & ".xls"

        If ds.Tables(0).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER INCOMPLETE DOCUMENT 60 DAYS FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "PROPOSAL RECIEVED DATE"
                .Cells(4, 6) = "PROPOSAL SIGNED DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(0).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("PROPOSAL_RECEIVED_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("proposal_signed_date").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        If ds.Tables(1).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER INCOMPLETE DOCUMENT 45 DAYS FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "PROPOSAL RECIEVED DATE"
                .Cells(4, 6) = "PROPOSAL SIGNED DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(1).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("PROPOSAL_RECEIVED_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("proposal_signed_date").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        If ds.Tables(2).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER INCOMPLETE DOCUMENT 30 DAYS FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "PROPOSAL RECIEVED DATE"
                .Cells(4, 6) = "PROPOSAL SIGNED DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(2).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("PROPOSAL_RECEIVED_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("proposal_signed_date").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        If ds.Tables(3).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER INCOMPLETE DOCUMENT 15 DAYS FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "PROPOSAL RECIEVED DATE"
                .Cells(4, 6) = "PROPOSAL SIGNED DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(3).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("PROPOSAL_RECEIVED_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("proposal_signed_date").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        xWB.SaveAs(AppDomain.CurrentDomain.BaseDirectory & "Files\" & _FileName)
        xWB.Close()

        Dim sRes As String
        sRes = sMsg
        _objBusi.getINUPSMS("SMS", _FileName.Replace(".xls", ""), "", "", "", "", "", "", "", "INCOMPLETE", "UPDATE", sqlConn)
        SendEmail(sSub, sHeader, sMsg, sFooter, AppDomain.CurrentDomain.BaseDirectory & "Files\" & _FileName)
    End Sub
#End Region
  
    Private Sub SMSUW()
        Dim ds As New DataSet
        ds = _objBusi.getSMS("SMS", "", "", "", "", "", "", "", "", "UW", "SENDMAIL", sqlConn)
        Dim sMsg, sSub, sHeader, sFooter As String
        Dim i As Integer = 1
        sSub = "PROPOSER DETAILS TO SEND SMS FOR UNDER WRITING"
        sHeader = "Dear Sir/Madam, <br><br><br> "
        sHeader = sHeader & " Below enclosed proposer details of UNDER WRITING.<br><br><br>"
        sFooter = "Thanks & Regards,<br>"
        sFooter = sFooter & " System Admin,<br> "
        sFooter = sFooter & " Medicare Assistance Sdn Bha,<br><br><br><br> "
        sFooter = sFooter & " Note : This is a system generated email please do not reply.<br><br><br><br>"
        sMsg = ""
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWName As String = ""
        Dim _FileName As String = "PUW" & DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() & ".xls"

        If ds.Tables(0).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER UNDERWRITING DOCUMENT 60 DAYS FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "PROPOSAL RECIEVED DATE"
                .Cells(4, 6) = "PROPOSAL SIGNED DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(0).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("PROPOSAL_RECEIVED_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("proposal_signed_date").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        If ds.Tables(1).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER UNDERWRITING DOCUMENT 45 DAYS FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "PROPOSAL RECIEVED DATE"
                .Cells(4, 6) = "PROPOSAL SIGNED DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(1).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("PROPOSAL_RECEIVED_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("proposal_signed_date").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        If ds.Tables(2).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER UNDERWRITING DOCUMENT 30 DAYS FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "PROPOSAL RECIEVED DATE"
                .Cells(4, 6) = "PROPOSAL SIGNED DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(2).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("PROPOSAL_RECEIVED_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("proposal_signed_date").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        If ds.Tables(3).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER UNDERWRITING 15 DAYS FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "PROPOSAL RECIEVED DATE"
                .Cells(4, 6) = "PROPOSAL SIGNED DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(3).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("PROPOSAL_RECEIVED_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("proposal_signed_date").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        xWB.SaveAs(AppDomain.CurrentDomain.BaseDirectory & "Files\" & _FileName)
        xWB.Close()

        Dim sRes As String
        sRes = sMsg
        _objBusi.getINUPSMS("SMS", _FileName.Replace(".xls", ""), "", "", "", "", "", "", "", "UW", "UPDATE", sqlConn)
        SendEmail(sSub, sHeader, sMsg, sFooter, AppDomain.CurrentDomain.BaseDirectory & "Files\" & _FileName)
    End Sub
    Private Sub SMSCOMPLETED()
        Dim ds As New DataSet
        ds = _objBusi.getSMS("SMS", "", "", "", "", "", "", "", "", "COMPLETED", "SENDMAIL", sqlConn)
        Dim sMsg, sSub, sHeader, sFooter As String
        Dim i As Integer = 1
        sSub = "PROPOSER DETAILS TO SEND SMS FOR AKNOWLEDGEMENT"
        sHeader = "Dear Sir/Madam, <br><br><br> "
        sHeader = sHeader & " Below enclosed proposer details of approval.<br><br><br>"
        sFooter = "Thanks & Regards,<br>"
        sFooter = sFooter & " System Admin,<br> "
        sFooter = sFooter & " Medicare Assistance Sdn Bhd,<br><br><br><br> "
        sFooter = sFooter & " Note : This is a system generated email please do not reply.<br><br><br><br>"
        sMsg = ""
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWName As String = ""
        Dim _FileName As String = "PAK" & DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() & ".xls"

        If ds.Tables(0).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER COMPLETED DETAILS LAST DAY."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "PROPOSAL RECIEVED DATE"
                .Cells(4, 6) = "PROPOSAL SIGNED DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(0).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("PROPOSAL_RECEIVED_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("proposal_signed_date").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        xWB.SaveAs(AppDomain.CurrentDomain.BaseDirectory & "Files\" & _FileName)
        xWB.Close()

        Dim sRes As String
        sRes = sMsg
        _objBusi.getINUPSMS("SMS", _FileName.Replace(".xls", ""), "", "", "", "", "", "", "", "COMPLETED", "UPDATE", sqlConn)
        SendEmail(sSub, sHeader, sMsg, sFooter, AppDomain.CurrentDomain.BaseDirectory & "Files\" & _FileName)
    End Sub
    Private Sub SendEmail(ByVal sSubject As String, ByVal sHeader As String, ByVal sBody As String, ByVal sFooter As String, ByVal sPath As String)
        Try
            Dim SmtpServer As New SmtpClient()
            SmtpServer.Credentials = New Net.NetworkCredential("sri@medicare.org.my", "SRI@MEDICARE")
            SmtpServer.Port = 587
            SmtpServer.Host = "mail.medicare.org.my"
            SmtpServer.EnableSsl = False
            Dim omail As New MailMessage()
            omail.From = New MailAddress("sri@medicare.org.my", "MEDICARE", System.Text.Encoding.UTF8)
            omail.Subject = sSubject
            omail.IsBodyHtml = True
            omail.Body = sHeader & vbCrLf & vbCrLf & vbCrLf & sBody & vbCrLf & vbCrLf & vbCrLf & sFooter
            omail.To.Add("zulia@medicare.org.my, farah@medicare.org.my, puvanes@medicare.org.my")
            omail.CC.Add("palani@medicare.org.my")
            Dim attachment As System.Net.Mail.Attachment
            attachment = New System.Net.Mail.Attachment(sPath)
            omail.Attachments.Add(attachment)
            SmtpServer.Send(omail)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SMSYPR()
        Dim ds As New DataSet
        ds = _objBusi.getSMS("SMS", "", "", "", "", "", "", "", "", "YPR", "SENDMAIL", sqlConn)
        Dim sMsg, sSub, sHeader, sFooter As String
        Dim i As Integer = 1
        sSub = "MEMBER DETAILS TO SEND SMS FOR PENDING RENEWAL"
        sHeader = "Dear Sir/Madam, <br><br><br> "
        sHeader = sHeader & " Below enclosed member details of PENDING RENEWAL.<br><br><br>"
        sFooter = "Thanks & Regards,<br>"
        sFooter = sFooter & " System Admin,<br> "
        sFooter = sFooter & " Medicare Assistance Sdn Bha,<br><br><br><br> "
        sFooter = sFooter & " Note : This is a system generated email please do not reply.<br><br><br><br>"
        sMsg = ""
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWName As String = ""
        Dim _FileName As String = "YPR" & DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() & ".xls"

        If ds.Tables(0).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER PENDING RENEWAL 45 DAYS FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "EFFECTIVE DATE"
                .Cells(4, 6) = "EXPIRY DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(0).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("EFFECTIVE_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("CANCELLATION_DATE").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        If ds.Tables(1).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER PENDING RENEWAL 30 DAYS FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "EFFECTIVE DATE"
                .Cells(4, 6) = "EXPIRY DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(1).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("EFFECTIVE_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("CANCELLATION_DATE").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        If ds.Tables(2).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER PENDING RENEWAL TO DAY'S FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "EFFECTIVE DATE"
                .Cells(4, 6) = "EXPIRY DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(2).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("EFFECTIVE_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("CANCELLATION_DATE").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        If ds.Tables(3).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "PROPOSER PENDING RENEWAL > 30 DAYS FOLLOW UP."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "PLAN CODE"
                .Cells(4, 5) = "EFFECTIVE DATE"
                .Cells(4, 6) = "EXPIRY DATE"
                .Cells(4, 7) = "PHONE MOBILE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(3).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC_NEW").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL_NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("PLAN_CODE").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("EFFECTIVE_DATE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("CANCELLATION_DATE").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("PHONE_MOBILE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        xWB.SaveAs(AppDomain.CurrentDomain.BaseDirectory & "Files\" & _FileName)
        xWB.Close()

        Dim sRes As String
        sRes = sMsg
        _objBusi.getINUPSMS("SMS", _FileName.Replace(".xls", ""), "", "", "", "", "", "", "", "YPR", "UPDATE", sqlConn)
        SendEmail(sSub, sHeader, sMsg, sFooter, AppDomain.CurrentDomain.BaseDirectory & "Files\" & _FileName)
    End Sub
End Module
