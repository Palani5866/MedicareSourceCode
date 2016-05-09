Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Renewal_Notice

    Private Function getRenewalNotice(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.CommandText = "SELECT a.ID, b.Full_Name, substring(b.IC_New,2,14) AS IC_NEW, " & _
                                "b.Postal_Address_L1 As Add1, b.Postal_Address_L2 As Add2, b.Town, b.State, b.Postcode, A.Policy_No,  " & _
                                "A.Level2_Plan_Code As Policy_Type, a.Cancellation_Date As Expiry_Date, a.Deduction_Amount, " & _
                                "(SELECT ExclusionClause_Description + ',' FROM dt_Member_Policy_Exclusion_Clause " & _
                                "where member_policy_id='" & ID & "' FOR XML PATH('')) As ExlusionClause, b.Title " & _
                                "FROM dt_Member_policy a INNER JOIN dt_member b ON a.member_id=b.id " & _
                                "WHERE a.ID='" & ID & "' "
        Dim sdp As New SqlDataAdapter(cmdSelect)
        sdp.Fill(ds, "dt_member_policy")

        Dim dsReturn As New DataSet("dsRenewalNotice")
        dt = tb_Member_Policy()
        Try
            For Each row As DataRow In ds.Tables(0).Rows
                dt.ImportRow(row)
            Next
        Catch ex As Exception
        End Try
        dsReturn.Tables.Add(dt)
        Return dsReturn
    End Function
    Private Function tb_Member_Policy() As DataTable
        Dim dt As New DataTable("dt_Member_Policy")
        dt.Columns.Add("ID", GetType(String))
        dt.Columns.Add("Full_Name", GetType(String))
        dt.Columns.Add("IC_New", GetType(String))
        dt.Columns.Add("Add1", GetType(String))
        dt.Columns.Add("Add2", GetType(String))
        dt.Columns.Add("Town", GetType(String))
        dt.Columns.Add("State", GetType(String))
        dt.Columns.Add("Postcode", GetType(String))
        dt.Columns.Add("Policy_No", GetType(String))
        dt.Columns.Add("Policy_Type", GetType(String))
        dt.Columns.Add("Expiry_Date", GetType(String))
        dt.Columns.Add("Deduction_Amount", GetType(Double))
        dt.Columns.Add("ExlusionClause", GetType(String))
        dt.Columns.Add("Title", GetType(String))
        Return dt
    End Function
    Friend Sub Print(ByVal ReportName As String, ByVal ID As String)
        ExportPDF(ReportName, ID)
    End Sub
    Private Sub ExportPDF(ByVal ReportName As String, ByVal ID As String)
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        CrystalReportViewer.ActiveViewIndex = 0
        CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        CrystalReportViewer.DisplayGroupTree = False
        CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        CrystalReportViewer.Name = "CrystalReportViewer"
        Dim ds As New DataSet
        ds = Me.getRenewalNotice(ID)
        If ds Is Nothing Then
            Return
        End If
        Dim sRes As String
        Report.Load(Application.StartupPath & "\Report\" & ReportName & "")
        sRes = ds.Tables("dt_member_policy").Rows(0)("Full_Name")
        Report.Database.Tables("dt_member_policy").SetDataSource(ds.Tables(0))

        CrystalReportViewer.ReportSource = Report

        Dim _FileName As String = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf"

        Try
            Dim cryRpt As New ReportDocument()
            cryRpt = DirectCast(CrystalReportViewer.ReportSource, ReportDocument)
            Dim exportOpts As New ExportOptions()
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile

            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = Application.StartupPath & "\Report\" & _FileName
            CrExportOptions = cryRpt.ExportOptions
            If True Then
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions
                CrExportOptions.FormatOptions = CrFormatTypeOptions
            End If
            cryRpt.Export()
            System.Diagnostics.Process.Start(Application.StartupPath & "\Report\" & _FileName)
        Catch Ex As Exception
            Dim msg As String = Ex.Message
            MessageBox.Show("You Must Have a report viewable in the Report panel To print")
        End Try
    End Sub
End Class