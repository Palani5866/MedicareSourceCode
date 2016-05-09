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
        CCPI()
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
            omail.To.Add("malar@medicare.org.my, puvanes@medicare.org.my")
            omail.CC.Add("palani@medicare.org.my")

            Dim attachment As System.Net.Mail.Attachment
            attachment = New System.Net.Mail.Attachment(sPath)
            omail.Attachments.Add(attachment)
            SmtpServer.Send(omail)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CCPI()
        Dim ds As New DataSet
        ds = _objBusi.fGetPI("MAIL", "", "", "", "", "", "", "", "", "", "SENDMAIL", sqlConn)
        Dim sMsg, sSub, sHeader, sFooter As String
        Dim i As Integer = 1
        sSub = "POLICIES DETAIL FOR PREMIUM INCREASE"
        sHeader = "Dear Sir/Madam, <br><br><br> "
        sHeader = sHeader & " Enclosed POLICIES DETAILS FOR PREMIUM INCREASE.<br><br><br>"
        sFooter = "Thanks & Regards,<br>"
        sFooter = sFooter & " System Admin,<br> "
        sFooter = sFooter & " Medicare Assistance Sdn Bha,<br><br><br><br> "
        sFooter = sFooter & " Note : This is a system generated email please do not reply.<br><br><br><br>"
        sMsg = ""
        Dim xApp As New Microsoft.Office.Interop.Excel.Application
        Dim xWB As Microsoft.Office.Interop.Excel.Workbook
        xWB = xApp.Workbooks.Add
        Dim xWName As String = ""
        Dim _FileName As String = "PI" & DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() & ".xls"

        If ds.Tables(0).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "CUEPACS CARE POLICIES DETAILS FOR PREMIUM INCREASE."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "DOB"
                .Cells(4, 5) = "AGE"
                .Cells(4, 6) = "DEDUCTION CODE"
                .Cells(4, 7) = "CURRENT AMOUNT"
                .Cells(4, 8) = "ACTUAL PREMIUM"
                .Cells(4, 9) = "POLICY START DATE"
                .Cells(4, 10) = "PRODUCT"
                .Cells(4, 11) = "PLAN TYPE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(0).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("DOB").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("AGE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("DEDUCTION CODE").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("DEDUCTION AMOUNT").ToString.Trim()
                    .Cells(xRowCount, 8) = "'" & dr("ACTUAL PREMIUM").ToString.Trim()
                    .Cells(xRowCount, 9) = "'" & dr("POLICY START DATE").ToString.Trim()
                    .Cells(xRowCount, 10) = "'" & dr("PRODUCT").ToString.Trim()
                    .Cells(xRowCount, 11) = "'" & dr("PLAN TYPE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        If ds.Tables(1).Rows.Count > 0 Then
            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "CUEPACS PA POLICIES DETAILS FOR PREMIUM INCREASE."
                .Cells(4, 1) = "NO"
                .Cells(4, 2) = "IC"
                .Cells(4, 3) = "FULL NAME"
                .Cells(4, 4) = "DOB"
                .Cells(4, 5) = "AGE"
                .Cells(4, 6) = "DEDUCTION CODE"
                .Cells(4, 7) = "CURRENT AMOUNT"
                .Cells(4, 8) = "ACTUAL PREMIUM"
                .Cells(4, 9) = "POLICY START DATE"
                .Cells(4, 10) = "PRODUCT"
                .Cells(4, 11) = "PLAN TYPE"

                Dim xRowCount As Integer = 5
                For Each dr As DataRow In ds.Tables(1).Rows
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 4).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & dr("IC").ToString.Trim()
                    .Cells(xRowCount, 3) = "'" & dr("FULL NAME").ToString.Trim()
                    .Cells(xRowCount, 4) = "'" & dr("DOB").ToString.Trim()
                    .Cells(xRowCount, 5) = "'" & dr("AGE").ToString.Trim()
                    .Cells(xRowCount, 6) = "'" & dr("DEDUCTION CODE").ToString.Trim()
                    .Cells(xRowCount, 7) = "'" & dr("DEDUCTION AMOUNT").ToString.Trim()
                    .Cells(xRowCount, 8) = "'" & dr("ACTUAL PREMIUM").ToString.Trim()
                    .Cells(xRowCount, 9) = "'" & dr("POLICY START DATE").ToString.Trim()
                    .Cells(xRowCount, 10) = "'" & dr("PRODUCT").ToString.Trim()
                    .Cells(xRowCount, 11) = "'" & dr("PLAN TYPE").ToString.Trim()
                    xRowCount += 1
                Next
            End With
        End If
        xWB.SaveAs(AppDomain.CurrentDomain.BaseDirectory & "Files\" & _FileName)
        xWB.Close()
        SendEmail(sSub, sHeader, sMsg, sFooter, AppDomain.CurrentDomain.BaseDirectory & "Files\" & _FileName)
    End Sub
End Module
