Imports System.Net.Mail
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class fAgentComission
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
    Dim sFrm, sTo As String
    Dim _FileName As String
    Dim Ac_Tot As Decimal
    Dim Ac_TotRecords As Integer
    Private Sub fAgentComission_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fAgentComission_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.rbSubmissionofDate.Checked = True
        Me.txtRMFROM.Visible = False
        Me.txtRMTO.Visible = False
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        If Not Me.cbProduct.SelectedIndex > -1 Then
            MsgBox("Please do key in the Product Type!")
            Me.cbProduct.Focus()
            Exit Sub
        End If
        If Me.rbSubmissionofDate.Checked Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            sFrm = Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy")
            sTo = Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy")
            dt = _objBusi.getDetails_IV("AC", "SDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), "", "", "", "", "", "", Conn)
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        ElseIf Me.rbReceivedMonth.Checked Then
            If Len(Me.txtRMFROM.Text.Trim) = 0 Then
                MsgBox("Please do key in the Receiving Month - From (yyyymm).")
                Me.txtRMFROM.Focus()
                Exit Sub
            End If

            If Len(Me.txtRMTO.Text.Trim) = 0 Then
                MsgBox("Please do key in the Receiving Month - To (yyyymm).")
                Me.txtRMTO.Focus()
                Exit Sub
            End If
            If IsNumeric(Me.txtRMFROM.Text) = False Then
                MsgBox("Please do key in the Receiving Month - From in the right format (yyyymm).")
                Me.txtRMFROM.Focus()
                Exit Sub
            Else
                If IsNumeric(Me.txtRMTO.Text) = False Then
                    MsgBox("Please do key in the Receiving Month - To date in the right format (yyyymm).")
                    Me.txtRMTO.Focus()
                    Exit Sub
                Else
                    Try
                        If Convert.ToUInt32(Me.txtRMTO.Text) >= Convert.ToUInt32(Me.txtRMFROM.Text) Then
                            SharedData.ReadyToHideMarquee = False
                            StartMarqueeThread()
                            sFrm = Me.txtRMFROM.Text.ToString.Trim()
                            sTo = Me.txtRMTO.Text.ToString.Trim()
                            dt = _objBusi.getDetails_IV("AC", "RMONTH", Me.cbProduct.Text.ToString.Trim(), Me.txtRMFROM.Text.ToString.Trim(), Me.txtRMTO.Text.ToString.Trim(), "", "", "", "", "", "", Conn)

                            SyncLock SharedData
                                SharedData.ReadyToHideMarquee = True
                            End SyncLock
                            Application.DoEvents()
                        End If
                    Catch ex As Exception

                    End Try
                End If
            End If
        ElseIf Me.rbReceivedDate.Checked Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            sFrm = Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy")
            sTo = Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy")
            dt = _objBusi.getDetails_IV("AC", "PRDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), "", "", "", "", "", "", Conn)
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvACDetails
                .DataSource = dt
                .Columns(1).DisplayIndex = 5
            End With
        Else
            MsgBox("No record found!")
            Me.dgvACDetails.DataSource = dt
        End If
    End Sub
    Private Sub rbSubmissionofDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSubmissionofDate.CheckedChanged
        rbChanged()
    End Sub
    Private Sub rbReceivedMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReceivedMonth.CheckedChanged
        rbChanged()
    End Sub
    Private Sub rbReceivedDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReceivedDate.CheckedChanged
        rbChanged()
    End Sub
    Private Sub rbChanged()
        If Me.rbSubmissionofDate.Checked Then
            Me.lblPeriod.Text = "Period of Submission Date"
            Me.dtpPeriodFrm.Visible = True
            Me.dtpPeriodTo.Visible = True
            Me.txtRMFROM.Visible = False
            Me.txtRMTO.Visible = False
        ElseIf Me.rbReceivedMonth.Checked Then
            Me.lblPeriod.Text = "Period of Received Month"
            Me.dtpPeriodFrm.Visible = False
            Me.dtpPeriodTo.Visible = False
            Me.txtRMFROM.Visible = True
            Me.txtRMTO.Visible = True
            Me.txtRMFROM.Text = Format(Now().Year, "0000").ToString & Format(Now.Month, "00").ToString
            Me.txtRMTO.Text = Format(Now().Year, "0000").ToString & Format(Now.Month, "00").ToString
        ElseIf Me.rbReceivedDate.Checked Then
            Me.lblPeriod.Text = "Period of Received Date"
            Me.dtpPeriodFrm.Visible = True
            Me.dtpPeriodTo.Visible = True
            Me.txtRMFROM.Visible = False
            Me.txtRMTO.Visible = False
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
    Private Sub cbSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelectAll.CheckedChanged
        If cbSelectAll.Checked Then
            Dim i As Integer = 0
            With Me.dgvACDetails
                Do While i < .Rows.Count
                    Dim status As Integer = ValidateEmailId(.Rows(i).Cells(4).Value.ToString.Trim())
                    If status = 0 Then
                        .Rows(i).Cells(0).Value = 0
                    ElseIf status = 1 Then
                        .Rows(i).Cells(0).Value = 1
                    ElseIf status = 2 Then
                        .Rows(i).Cells(0).Value = 0
                    End If
                    i += 1
                Loop
            End With
        Else
            Dim i As Integer = 0
            With Me.dgvACDetails
                Do While i < .Rows.Count
                    .Rows(i).Cells(0).Value = 0
                    i += 1
                Loop
            End With
        End If
    End Sub

    Public Function ValidateEmailId(ByVal emailId As String) As Integer
        Dim rEMail As New System.Text.RegularExpressions.Regex("^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
        If emailId.Length > 0 Then
            If Not rEMail.IsMatch(emailId) Then
                Return 0
            Else
                Return 1
            End If
        End If
        Return 2
    End Function
    Private Sub dgvACDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvACDetails.CellContentClick
        With Me.dgvACDetails
            If e.ColumnIndex = 0 Then
                Dim status As Integer = ValidateEmailId(.Rows(e.RowIndex).Cells(4).Value.ToString.Trim())
                If status = 0 Then
                    .Rows(e.RowIndex).Cells(0).Value = 0
                ElseIf status = 1 Then
                    .Rows(e.RowIndex).Cells(0).Value = 1
                ElseIf status = 2 Then
                    .Rows(e.RowIndex).Cells(0).Value = 0
                End If
            ElseIf e.ColumnIndex = 1 Then
                If Me.rbSubmissionofDate.Checked Then
                    PrintLetters.PrintACS("rAgentComission.rpt", .Rows(e.RowIndex).Cells(2).Value.ToString.Trim, "AGENTCOMISSION", "SDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), "", Me.txtRMFROM.Text.Trim(), Me.txtRMTO.Text.Trim(), "", "", "")
                ElseIf Me.rbReceivedMonth.Checked Then
                    PrintLetters.PrintACS("rAgentComission.rpt", .Rows(e.RowIndex).Cells(2).Value.ToString.Trim, "AGENTCOMISSION", "RMONTH", Me.cbProduct.Text.ToString.Trim(), Me.txtRMFROM.Text.ToString.Trim(), Me.txtRMTO.Text.ToString.Trim(), "", Me.txtRMFROM.Text.Trim(), Me.txtRMTO.Text.Trim(), "", "", "")
                ElseIf Me.rbReceivedDate.Checked Then
                    PrintLetters.PrintACS("rAgentComission.rpt", .Rows(e.RowIndex).Cells(2).Value.ToString.Trim, "AGENTCOMISSION", "PRDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), "", Me.txtRMFROM.Text.Trim(), Me.txtRMTO.Text.Trim(), "", "", "")
                End If
            End If
        End With
    End Sub
    Sub dgvACDetails_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvACDetails.CurrentCellDirtyStateChanged
        If dgvACDetails.IsCurrentCellDirty Then
            dgvACDetails.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Public Sub dgvACDetails_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvACDetails.CellValueChanged
        If dgvACDetails.Columns(e.ColumnIndex).Name = "Tick" Then
            Dim buttonCell As DataGridViewCheckBoxCell = CType(dgvACDetails.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell)

            Dim checkCell As DataGridViewCheckBoxCell = CType(dgvACDetails.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell)
            buttonCell.TrueValue = Not CType(checkCell.Value, [Boolean])
            dgvACDetails.Invalidate()
        End If
    End Sub
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim rCount As Integer = 0
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Do While rCount < Me.dgvACDetails.Rows.Count
            If Me.dgvACDetails.Rows(rCount).Cells(0).Value = 1 Then
                _FileName = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf"
                SENDMAILAGENTCOMISSIONDATA(Me.dgvACDetails.Rows(rCount).Cells(2).Value.ToString.Trim, Me.dgvACDetails.Rows(rCount).Cells(3).Value.ToString.Trim, Me.dgvACDetails.Rows(rCount).Cells(4).Value.ToString.Trim)
            End If
            rCount += 1
        Loop
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
    End Sub
    Private Sub xPort2PDFforACS(ByVal ReportName As String, ByVal AC As String, ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String)
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        CrystalReportViewer.ActiveViewIndex = 0
        CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        CrystalReportViewer.DisplayGroupTree = False
        CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        CrystalReportViewer.Name = "CrystalReportViewer"
        Dim ds As New DataSet
        ds = getACSDetails(AC, P1, P2, P3, P4, P5)
        If ds Is Nothing Then
            Return
        End If

        Report.Load(Application.StartupPath & "\Report\" & ReportName & "")
        Report.Database.Tables("DT_AGENTCOMISSION").SetDataSource(ds.Tables(0))

        CrystalReportViewer.ReportSource = Report
        Try

            Dim cryRpt As New ReportDocument()
            Dim pfdsP1 As ParameterFieldDefinitions
            Dim pdfP1 As ParameterFieldDefinition
            Dim pvP1 As New ParameterValues
            Dim pdvP1 As New ParameterDiscreteValue

            'P1
            pdvP1.Value = P6
            pfdsP1 = Report.DataDefinition.ParameterFields()
            pdfP1 = pfdsP1.Item("P1")
            pvP1 = pdfP1.CurrentValues

            pvP1.Clear()
            pvP1.Add(pdvP1)
            pdfP1.ApplyCurrentValues(pvP1)

            'P2
            pdvP1.Value = P6
            pfdsP1 = Report.DataDefinition.ParameterFields()
            pdfP1 = pfdsP1.Item("P2")
            pvP1 = pdfP1.CurrentValues

            pvP1.Clear()
            pvP1.Add(pdvP1)
            pdfP1.ApplyCurrentValues(pvP1)

            'P3
            pdvP1.Value = P7
            pfdsP1 = Report.DataDefinition.ParameterFields()
            pdfP1 = pfdsP1.Item("P3")
            pvP1 = pdfP1.CurrentValues

            pvP1.Clear()
            pvP1.Add(pdvP1)
            pdfP1.ApplyCurrentValues(pvP1)

            'P4
            pdvP1.Value = P8
            pfdsP1 = Report.DataDefinition.ParameterFields()
            pdfP1 = pfdsP1.Item("P4")
            pvP1 = pdfP1.CurrentValues

            pvP1.Clear()
            pvP1.Add(pdvP1)
            pdfP1.ApplyCurrentValues(pvP1)

            cryRpt = DirectCast(CrystalReportViewer.ReportSource, ReportDocument)
            Dim exportOpts As New ExportOptions()
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile

            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = Application.StartupPath & "\Report\Emails\" & _FileName
            CrExportOptions = cryRpt.ExportOptions
            If True Then
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions
                CrExportOptions.FormatOptions = CrFormatTypeOptions
            End If
            cryRpt.Export()
        Catch Ex As Exception
            Dim msg As String = Ex.Message
            MessageBox.Show("You Must Have a report viewable in the Report panel To print")
        End Try
    End Sub
    Private Function getACSDetails(ByVal AC As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt, dtR As New DataTable
        Dim ds As New DataSet
        If P1 = "SDATE" Then
            dt = _objBusi.getDetails_IV("ACDETAILS", "SDATE", P2, P3, P4, AC, "", "", "", "", "", Conn)
        ElseIf P1 = "RMONTH" Then
            dt = _objBusi.getDetails_IV("ACDETAILS", "RMONTH", P2, P3, P4, AC, "", "", "", "", "", Conn)
        ElseIf P1 = "PRDATE" Then
            dt = _objBusi.getDetails_IV("ACDETAILS", "PRDATE", P2, P3, P4, AC, "", "", "", "", "", Conn)
        End If
        Dim dsReturn As New DataSet("dsLetters")
        dtR = DT_AGENTCOMISSION()
        Ac_TotRecords = dt.Rows.Count
        Try
            For Each dr As DataRow In dt.Rows
                Ac_Tot += dr("COMISSION")
                dtR.ImportRow(dr)
            Next
        Catch ex As Exception
        End Try
        dsReturn.Tables.Add(dtR)
        Return dsReturn
    End Function
    Private Function DT_AGENTCOMISSION() As DataTable
        Dim dt As New DataTable("DT_AGENTCOMISSION")
        dt.Columns.Add("FILENO", GetType(String))
        dt.Columns.Add("AGENTCODE", GetType(String))
        dt.Columns.Add("AGENTNAME", GetType(String))
        dt.Columns.Add("PHIC", GetType(String))
        dt.Columns.Add("PHNAME", GetType(String))
        dt.Columns.Add("PLANCODE", GetType(String))
        dt.Columns.Add("PLANTYPE", GetType(String))
        dt.Columns.Add("SDATE", GetType(Date))
        dt.Columns.Add("EDATE", GetType(Date))
        dt.Columns.Add("PREMIUM", GetType(Double))
        dt.Columns.Add("COMISSION", GetType(Double))
        Return dt
    End Function
    Private Sub SENDMAILAGENTCOMISSIONDATA(ByVal AC As String, ByVal ANAME As String, ByVal aEmail As String)
        If Me.rbSubmissionofDate.Checked Then
            xPort2PDFforACS("rAgentComission.rpt", AC, "AGENTCOMISSION", "SDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), "", Me.txtRMFROM.Text.Trim(), Me.txtRMTO.Text.Trim(), Ac_Tot, Ac_TotRecords, "")
        ElseIf Me.rbReceivedMonth.Checked Then
            xPort2PDFforACS("rAgentComission.rpt", AC, "AGENTCOMISSION", "RMONTH", Me.cbProduct.Text.ToString.Trim(), Me.txtRMFROM.Text.ToString.Trim(), Me.txtRMTO.Text.ToString.Trim(), "", Me.txtRMFROM.Text.Trim(), Me.txtRMTO.Text.Trim(), Ac_Tot, Ac_TotRecords, "")
        ElseIf Me.rbReceivedDate.Checked Then
            xPort2PDFforACS("rAgentComission.rpt", AC, "AGENTCOMISSION", "PRDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), "", Me.txtRMFROM.Text.Trim(), Me.txtRMTO.Text.Trim(), Ac_Tot, Ac_TotRecords, "")
        End If
        Dim sMsg, sSub, sHeader, sFooter As String
        sSub = "COMMISION STATEMENT FOR " & Me.cbProduct.Text.ToString.Trim()
        sHeader = "Dear Sir/Madam, <br><br><br> "
        sHeader = sHeader & " We have enclosed here your Comission Statement Details for the Period of : " & sFrm & " - " & sTo & " .<br><br><br>"
        sFooter = "Thanks & Regards,<br>"
        sFooter = sFooter & " System Admin,<br> "
        sFooter = sFooter & " Medicare Assistance Sdn Bhd,<br> "
        sFooter = sFooter & "  <br><br><br><br>"
        sFooter = sFooter & " Note : This is a system generated email please do not reply.<br><br><br><br>"
        sMsg = ""
        sMsg = sMsg & "<table width='200' border='1'>"
        sMsg = sMsg & " <tr>"
        sMsg = sMsg & " <td><div align='center'><strong>NO OF POLICIES</strong></div></td>"
        sMsg = sMsg & " <td><div align='center'><strong>TOTAL COMMISSION</strong></div></td>"
        sMsg = sMsg & " </tr>"
        sMsg = sMsg & " <tr>"
        sMsg = sMsg & " <td><div align='center'>" & Ac_TotRecords & "</div></td>"
        sMsg = sMsg & " <td><div align='center'>" & Ac_Tot & "</div></td>"
        sMsg = sMsg & " </tr>"
        sMsg = sMsg & "</table>"
        sMsg = sMsg & "<br><br><br>"

        Ac_TotRecords = 0
        Ac_Tot = 0
        Dim sRes As String
        sRes = sMsg
        SendEmailA(aEmail, sSub, sHeader, sMsg, sFooter, Application.StartupPath & "\Report\Emails\" & _FileName)
    End Sub
    Private Sub btnDiscard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiscard.Click
        Dim i As Integer = 0
        With Me.dgvACDetails
            Do While i < .Rows.Count
                .Rows(i).Cells(0).Value = 0
                i += 1
            Loop
        End With
    End Sub
    Private Sub BINDDATAAC(ByVal AC As String, ByVal ANAME As String, ByVal aEmail As String)
        Dim sType As String
        Dim dt As New DataTable
        If Me.rbSubmissionofDate.Checked Then
            dt = _objBusi.getDetails_IV("ACDETAILS", "SDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), AC, "", "", "", "", "", Conn)
            sType = "Submission Date " & Me.cbProduct.Text.ToString.Trim()
        ElseIf Me.rbReceivedMonth.Checked Then
            dt = _objBusi.getDetails_IV("ACDETAILS", "RMONTH", Me.cbProduct.Text.ToString.Trim(), Me.txtRMFROM.Text.ToString.Trim(), Me.txtRMTO.Text.ToString.Trim(), AC, "", "", "", "", "", Conn)
            sType = "Receiving Month " & Me.cbProduct.Text.ToString.Trim()
        ElseIf Me.rbReceivedDate.Checked Then
            dt = _objBusi.getDetails_IV("ACDETAILS", "PRDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), AC, "", "", "", "", "", Conn)
            sType = "Proposal Received Date " & Me.cbProduct.Text.ToString.Trim()
        End If
        If dt.Rows.Count > 0 Then


            Dim sMsg, sSub, sHeader, sFooter As String
            Dim i As Integer = 1
            sSub = "COMISSION DETAILS FOR " & sType
            sHeader = "Dear Sir/Madam, <br><br><br> "
            sHeader = sHeader & " We have enclosed here your Comission Details for Period : .<br><br><br>"
            sFooter = "Thanks & Regards,<br>"
            sFooter = sFooter & " System Admin,<br> "
            sFooter = sFooter & " Medicare Assistance Sdn Bhd,<br> "
            sFooter = sFooter & "  <br><br><br><br>"
            sFooter = sFooter & " Note : This is a system generated email please do not reply.<br><br><br><br>"
            sMsg = ""
            sMsg = sMsg & "<table width='985' border='1'>"
            sMsg = sMsg & " <tr>"
            sMsg = sMsg & " <td><div align='center'><strong>NO</strong></div></td>"
            sMsg = sMsg & " <td><div align='center'><strong>FILE #</strong></div></td>"
            sMsg = sMsg & " <td><div align='center'><strong>EFFECTIVE DATE</strong></div></td>"
            sMsg = sMsg & " <td><div align='center'><strong>CANCELLATION DATE</strong></div></td>"
            sMsg = sMsg & " <td><div align='center'><strong>PH NAME</strong></div></td>"
            sMsg = sMsg & " <td><div align='center'><strong>PH IC</strong></div></td>"
            sMsg = sMsg & " <td><div align='center'><strong>PLAN CODE</strong></div></td>"
            sMsg = sMsg & " <td><div align='center'><strong>PLAN TYPE</strong></div></td>"
            sMsg = sMsg & " <td><div align='center'><strong>PREMIUM</strong></div></td>"
            sMsg = sMsg & " <td><div align='center'><strong>TOT COMISSION</strong></div></td>"
            sMsg = sMsg & " </tr>"
            For Each dr As DataRow In dt.Rows
                sMsg = sMsg & " <tr>"
                sMsg = sMsg & " <td><div align='center'>" & i & "</div></td>"
                sMsg = sMsg & " <td><div align='center'>" & dr("FILENO").ToString().Trim() & "</div></td>"
                sMsg = sMsg & " <td><div align='center'>" & dr("SDATE").ToString().Trim() & "</div></td>"
                sMsg = sMsg & " <td><div align='center'>" & dr("EDATE").ToString().Trim() & "</div></td>"
                sMsg = sMsg & " <td><div align='center'>" & dr("PHNAME").ToString().Trim() & "</div></td>"
                sMsg = sMsg & " <td><div align='center'>" & dr("PHIC").ToString().Trim() & "</div></td>"
                sMsg = sMsg & " <td><div align='center'>" & dr("PLANCODE").ToString().Trim() & "</div></td>"
                sMsg = sMsg & " <td><div align='center'>" & dr("PLANTYPE").ToString().Trim() & "</div></td>"
                sMsg = sMsg & " <td><div align='center'>" & dr("PREMIUM").ToString().Trim() & "</div></td>"
                sMsg = sMsg & " <td><div align='center'>" & dr("TOTCOMISSION").ToString().Trim() & "</div></td>"
                sMsg = sMsg & " </tr>"
                i += 1
            Next
            sMsg = sMsg & "</table>"
            sMsg = sMsg & "<br><br><br>"
            Dim sRes As String
            sRes = sMsg
            SendEmail(aEmail, sSub, sHeader, sMsg, sFooter)
        End If

    End Sub
    Private Sub BINDDATAACA(ByVal AC As String, ByVal ANAME As String, ByVal aEmail As String)
        Dim sType As String
        Dim dt As New DataTable
        If Me.rbSubmissionofDate.Checked Then
            dt = _objBusi.getDetails_IV("ACDETAILS", "SDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), AC, "", "", "", "", "", Conn)
            sType = "Submission Date " & Me.cbProduct.Text.ToString.Trim()
        ElseIf Me.rbReceivedMonth.Checked Then
            dt = _objBusi.getDetails_IV("ACDETAILS", "RMONTH", Me.cbProduct.Text.ToString.Trim(), Me.txtRMFROM.Text.ToString.Trim(), Me.txtRMTO.Text.ToString.Trim(), AC, "", "", "", "", "", Conn)
            sType = "Receiving Month " & Me.cbProduct.Text.ToString.Trim()
        ElseIf Me.rbReceivedDate.Checked Then
            dt = _objBusi.getDetails_IV("ACDETAILS", "PRDATE", Me.cbProduct.Text.ToString.Trim(), Format(Me.dtpPeriodFrm.Value, "MM/dd/yyyy"), Format(Me.dtpPeriodTo.Value, "MM/dd/yyyy"), AC, "", "", "", "", "", Conn)
            sType = "Proposal Received Date " & Me.cbProduct.Text.ToString.Trim()
        End If

        Dim sMsg, sSub, sHeader, sFooter As String
        Dim i As Integer = 1

        Dim total As Decimal
        For Each dr As DataRow In dt.Rows
            total += dr(6)
        Next

        sSub = "COMMISION STATEMENT FOR " & Me.cbProduct.Text.ToString.Trim()
        sHeader = "Dear Sir/Madam, <br><br><br> "
        sHeader = sHeader & " We have enclosed here your Comission Statement Details for the Period of : " & sFrm & " - " & sTo & " .<br><br><br>"
        sFooter = "Thanks & Regards,<br>"
        sFooter = sFooter & " System Admin,<br> "
        sFooter = sFooter & " Medicare Assistance Sdn Bhd,<br> "
        sFooter = sFooter & "  <br><br><br><br>"
        sFooter = sFooter & " Note : This is a system generated email please do not reply.<br><br><br><br>"
        sMsg = ""
        sMsg = sMsg & "<table width='200' border='1'>"
        sMsg = sMsg & " <tr>"
        sMsg = sMsg & " <td><div align='center'><strong>NO OF POLICIES</strong></div></td>"
        sMsg = sMsg & " <td><div align='center'><strong>TOTAL COMMISSION</strong></div></td>"
        sMsg = sMsg & " </tr>"
        sMsg = sMsg & " <tr>"
        sMsg = sMsg & " <td><div align='center'>" & dt.Rows.Count.ToString() & "</div></td>"
        sMsg = sMsg & " <td><div align='center'>" & total & "</div></td>"
        sMsg = sMsg & " </tr>"
        sMsg = sMsg & "</table>"
        sMsg = sMsg & "<br><br><br>"

        Dim _FileName As String = "PC" & DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() & ".pdf"

        With Me.dgvSentMail
            .DataSource = dt
            .Columns(5).DefaultCellStyle.Format = "#,##0.00"
            .Columns(6).DefaultCellStyle.Format = "#,##0.00"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With
        Dim doc As Document

        Dim pdfTable As New PdfPTable(dgvSentMail.ColumnCount)
        pdfTable.DefaultCell.Padding = 3
        pdfTable.WidthPercentage = 100
        pdfTable.SpacingAfter = 10
        pdfTable.PaddingTop = 500
        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.DefaultCell.BorderWidth = 1

        Dim Para1 As Paragraph
        Para1 = New Paragraph(" COMMISION STATEMENT FOR " & Me.cbProduct.Text.ToString.Trim())
        Dim Para2 As Paragraph
        Para2 = New Paragraph(" FOR THE PERIOD OF : " & sFrm & " - " & sTo)
        Dim Para3 As Paragraph
        Para3 = New Paragraph(" AGENT CODE : " & AC)
        Dim Para4 As Paragraph
        Para4 = New Paragraph(" AGENT NAME : " & ANAME)

        Dim Para7 As Paragraph
        Para7 = New Paragraph(" ")

        Dim Para5 As Paragraph
        Para5 = New Paragraph(" TOTAL NO. OF POLICIES : " & dt.Rows.Count.ToString())

        Dim Para6 As Paragraph
        Para6 = New Paragraph(" TOTAL COMMISION : " & total)


        For Each column As DataGridViewColumn In dgvSentMail.Columns
            Dim cell As New PdfPCell(New Phrase(column.HeaderText))
            cell.BackgroundColor = New iTextSharp.text.BaseColor(240, 240, 240)
            pdfTable.AddCell(cell)
        Next


        For Each row As DataGridViewRow In dgvSentMail.Rows
            For Each cell As DataGridViewCell In row.Cells
                pdfTable.AddCell(cell.Value.ToString())
            Next
        Next




        Dim folderPath As String = Application.StartupPath & "\Report\Emails\"
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If
        Using stream As New FileStream(folderPath & _FileName, FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 15.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()
            pdfDoc.Add(Para1)
            pdfDoc.Add(Para2)
            pdfDoc.Add(Para3)
            pdfDoc.Add(Para4)
            pdfDoc.Add(Para7)
            pdfDoc.Add(pdfTable)
            pdfDoc.Add(Para5)
            pdfDoc.Add(Para6)

            pdfDoc.Close()

            stream.Close()
        End Using

        Dim sRes As String
        sRes = sMsg
        SendEmailA(aEmail, sSub, sHeader, sMsg, sFooter, Application.StartupPath & "\Report\Emails\" & _FileName)
    End Sub
    Private Sub Xport2PDF()

        Dim pdfTable As New PdfPTable(dgvSentMail.ColumnCount)
        pdfTable.DefaultCell.Padding = 3
        pdfTable.WidthPercentage = 30
        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.DefaultCell.BorderWidth = 1


        For Each column As DataGridViewColumn In dgvSentMail.Columns
            Dim cell As New PdfPCell(New Phrase(column.HeaderText))
            cell.BackgroundColor = New iTextSharp.text.BaseColor(240, 240, 240)
            pdfTable.AddCell(cell)
        Next


        For Each row As DataGridViewRow In dgvSentMail.Rows
            For Each cell As DataGridViewCell In row.Cells
                pdfTable.AddCell(cell.Value.ToString())
            Next
        Next




        Dim folderPath As String = Application.StartupPath & "\Report\Emails\"
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If
        Using stream As New FileStream(folderPath & "AgentCom.pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()
            pdfDoc.Add(pdfTable)
            pdfDoc.Close()
            stream.Close()
        End Using

    End Sub
#Region "Send"
    Private Sub SendEmailA(ByVal sEmail As String, ByVal sSubject As String, ByVal sHeader As String, ByVal sBody As String, ByVal sFooter As String, ByVal sPath As String)
        Try
            Dim SmtpServer As New SmtpClient()
            SmtpServer.Credentials = New Net.NetworkCredential("sri@medicare.org.my", "SRI@MEDICARE")
            SmtpServer.Port = 587
            SmtpServer.Host = "mail.medicare.org.my"
            SmtpServer.EnableSsl = False
            Dim omail As New MailMessage()
            omail.From = New MailAddress("sri@medicare.org.my", "MEDICARE AGENT COMMISSION", System.Text.Encoding.UTF8)
            omail.Subject = sSubject
            omail.IsBodyHtml = True
            omail.Body = sHeader & vbCrLf & vbCrLf & vbCrLf & sBody & vbCrLf & vbCrLf & vbCrLf & sFooter
            omail.To.Add(sEmail)
            omail.CC.Add("puvanes@medicare.org.my, ranjini@medicare.org.my")
            Dim attachment As System.Net.Mail.Attachment
            attachment = New System.Net.Mail.Attachment(sPath)
            omail.Attachments.Add(attachment)
            SmtpServer.Send(omail)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SendEmail(ByVal sEmail As String, ByVal sSubject As String, ByVal sHeader As String, ByVal sBody As String, ByVal sFooter As String)
        Try
            Dim SmtpServer As New SmtpClient()
            SmtpServer.Credentials = New Net.NetworkCredential("admin@medicare.org.my", "admin123+")
            SmtpServer.Port = 587
            SmtpServer.Host = "mail.medicare.org.my"
            SmtpServer.EnableSsl = False
            Dim omail As New MailMessage()
            omail.From = New MailAddress("admin@medicare.org.my", "AGENT COMISSION", System.Text.Encoding.UTF8)
            omail.Subject = sSubject
            omail.IsBodyHtml = True
            omail.Body = sHeader & vbCrLf & vbCrLf & vbCrLf & sBody & vbCrLf & vbCrLf & vbCrLf & sFooter
            omail.To.Add(sEmail)
            SmtpServer.Send(omail)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region
End Class