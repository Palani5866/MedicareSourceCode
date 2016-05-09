Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class PrintLetters

#Region "GLOBAL VARIABLES"
    Dim Deduction_Code As String
    Dim _objBusi As New Business
#End Region
    Private Function getCancellationLetter(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.CommandText = "SELECT top 1 a.ID, b.Full_Name, substring(b.IC_New,2,14) AS IC_NEW, " & _
                                "b.Postal_Address_L1 As Add1, b.Postal_Address_L2 As Add2, b.Postcode + ', ' + b.Town As Town, b.State , " & _
                                "case when (new_policy_no is null or new_policy_no='') then A.Policy_No else new_policy_no end as Policy_NO, " & _
                                "A.Level2_Plan_Code As Policy_Type,  c.Request_Date As Request_Date, a.Cancellation_Date As Receive_Date, " & _
                                "a.Angkasa_FileNo As File_No, a.Deduction_code, b.Title, b.Add3, b.Add4 " & _
                                "FROM dt_Member_policy a INNER JOIN dt_member b ON a.member_id=b.id  " & _
                                "INNER JOIN dt_Member_Endorsement C on C.Member_policy_ID=a.id " & _
                                "WHERE a.ID='" & ID & "' ORDER BY c.Request_date Desc "
        Dim sdp As New SqlDataAdapter(cmdSelect)
        sdp.Fill(ds, "dt_member_policy")
        If ds.Tables(0).Rows.Count > 0 Then
            Deduction_Code = ds.Tables("dt_Member_Policy").Rows(0)("Deduction_Code").ToString().Trim()
            Dim dsReturn As New DataSet("dsLetters")
            dt = tb_Member_Policy()
            Try
                For Each row As DataRow In ds.Tables(0).Rows
                    dt.ImportRow(row)
                Next
            Catch ex As Exception
            End Try
            dsReturn.Tables.Add(dt)
            Return dsReturn
        End If
    End Function
    Private Function getIncompleteBiroLetter(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        ds = _objBusi.getLetters("URC", ID, "", "", "", "", "", "", "", "", "INCOMPLETEBIRO", Conn)
        If ds.Tables(0).Rows.Count > 0 Then
            Deduction_Code = ds.Tables(0).Rows(0)("Deduction_Code").ToString().Trim()
            Dim dsReturn As New DataSet("dsLetters")
            dt = tb_Member_Policy()
            Try
                For Each row As DataRow In ds.Tables(0).Rows
                    dt.ImportRow(row)
                Next
            Catch ex As Exception
            End Try
            dsReturn.Tables.Add(dt)
            Return dsReturn
        End If
    End Function
    Private Function getDue2_60_PercentLetter(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.CommandText = "SELECT a.ID, b.Full_Name, substring(b.IC_New,2,14) AS IC_NEW, " & _
                                "b.Postal_Address_L1 As Add1, b.Postal_Address_L2 As Add2, b.Postcode + ', ' + b.Town As Town, b.State , " & _
                                "case when (new_policy_no is null or new_policy_no='') then A.Policy_No else new_policy_no end as Policy_NO, " & _
                                "A.Level2_Plan_Code As Policy_Type, a.Cancellation_Date As Expiry_Date, a.Deduction_Amount, a.Deduction_code, b.Title, b.Add3, b.Add4 " & _
                                "FROM dt_Member_policy a INNER JOIN dt_member b ON a.member_id=b.id " & _
                                "WHERE a.ID='" & ID & "' "
        Dim sdp As New SqlDataAdapter(cmdSelect)
        sdp.Fill(ds, "dt_member_policy")
        Deduction_Code = ds.Tables("dt_Member_Policy").Rows(0)("Deduction_Code").ToString().Trim()
        Dim dsReturn As New DataSet("dsLetters")
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
    Private Function getNo_Deduction_frm_AngkasaLetter(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.CommandText = "SELECT a.ID, b.Full_Name, substring(b.IC_New,2,14) AS IC_NEW, " & _
                                "b.Postal_Address_L1 As Add1, b.Postal_Address_L2 As Add2, b.Postcode + ', ' + b.Town As Town, b.State , " & _
                                "case when (new_policy_no is null or new_policy_no='') then A.Policy_No else new_policy_no end as Policy_NO, " & _
                                "A.Level2_Plan_Code As Policy_Type, a.Cancellation_Date As Expiry_Date, a.Deduction_Amount, a.Deduction_code, b.Title, b.Add3, b.Add4 " & _
                                "FROM dt_Member_policy a INNER JOIN dt_member b ON a.member_id=b.id " & _
                                "WHERE a.ID='" & ID & "' "
        Dim sdp As New SqlDataAdapter(cmdSelect)
        sdp.Fill(ds, "dt_member_policy")
        Deduction_Code = ds.Tables("dt_Member_Policy").Rows(0)("Deduction_Code").ToString().Trim()
        Dim dsReturn As New DataSet("dsLetters")
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
    Private Function getAngkasaPaymentLetter(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.CommandText = "SELECT a.ID, b.Full_Name, substring(b.IC_New,2,14) AS IC_NEW, " & _
                                "b.Postal_Address_L1 As Add1, b.Postal_Address_L2 As Add2, b.Postcode + ', ' + b.Town As Town, b.State ,  " & _
                                "case when (new_policy_no is null or new_policy_no='') then A.Policy_No else new_policy_no end as Policy_NO, " & _
                                "A.Level2_Plan_Code As Policy_Type, a.Cancellation_Date As Expiry_Date, a.Deduction_Amount, a.Deduction_code, b.Title, b.Add3, b.Add4 " & _
                                "FROM dt_Member_policy a INNER JOIN dt_member b ON a.member_id=b.id " & _
                                "WHERE a.ID='" & ID & "' "
        Dim sdp As New SqlDataAdapter(cmdSelect)
        sdp.Fill(ds, "dt_member_policy")
        Deduction_Code = ds.Tables("dt_Member_Policy").Rows(0)("Deduction_Code").ToString().Trim()
        Dim dsReturn As New DataSet("dsLetters")
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
    Private Function getAngkasaCancellationLetter(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.CommandText = "SELECT a.ID, b.Full_Name, substring(b.IC_New,2,14) AS IC_NEW, " & _
                                "b.Postal_Address_L1 As Add1, b.Postal_Address_L2 As Add2,b.Postcode + ', ' + b.Town As Town, b.State , " & _
                                "case when (new_policy_no is null or new_policy_no='') then A.Policy_No else new_policy_no end as Policy_NO, " & _
                                "A.Level2_Plan_Code As Policy_Type, a.Cancellation_Date As Expiry_Date, a.Deduction_Amount, a.Deduction_code, b.Title, b.Add3, b.Add4 " & _
                                "FROM dt_Member_policy a INNER JOIN dt_member b ON a.member_id=b.id " & _
                                "WHERE a.ID='" & ID & "' "
        Dim sdp As New SqlDataAdapter(cmdSelect)
        sdp.Fill(ds, "dt_member_policy")
        Deduction_Code = ds.Tables("dt_Member_Policy").Rows(0)("Deduction_Code").ToString().Trim()
        Dim dsReturn As New DataSet("dsLetters")
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
    Private Function getNonPaymentLetter(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.CommandText = "SELECT a.ID, b.Full_Name, substring(b.IC_New,2,14) AS IC_NEW, " & _
                                "b.Postal_Address_L1 As Add1, b.Postal_Address_L2 As Add2, b.Postcode + ', ' + b.Town As Town, b.State , " & _
                                "case when (new_policy_no is null or new_policy_no='') then A.Policy_No else new_policy_no end as Policy_NO, " & _
                                "A.Level2_Plan_Code As Policy_Type, a.Cancellation_Date As Request_Date, a.Deduction_Amount, a.Deduction_code, " & _
                                "(select Top 1 CAST(Angkasa_Bulan_potongan + '15' As DateTime) from dt_Member_Policy_MonthlyDeduction " & _
                                "WHERE member_policy_id='" & ID & "' " & _
                                "Order by Angkasa_Bulan_potongan desc) As Receive_Date, b.Title, b.Add3, b.Add4 " & _
                                "FROM dt_Member_policy a INNER JOIN dt_member b ON a.member_id=b.id " & _
                                "WHERE a.ID='" & ID & "' "
        Dim sdp As New SqlDataAdapter(cmdSelect)
        sdp.Fill(ds, "dt_member_policy")
        Deduction_Code = ds.Tables("dt_Member_Policy").Rows(0)("Deduction_Code").ToString().Trim()
        Dim dsReturn As New DataSet("dsLetters")
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
    Private Function getChange2Yearly(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.CommandText = "SELECT a.ID, b.Full_Name, substring(b.IC_New,2,14) AS IC_NEW, " & _
                                "b.Postal_Address_L1 As Add1, b.Postal_Address_L2 As Add2, b.Town, b.State, b.Postcode, " & _
                                "case when (new_policy_no is null or new_policy_no='') then A.Policy_No else new_policy_no end as Policy_NO, " & _
                                "A.Level2_Plan_Code As Policy_Type, " & _
                                "a.Angkasa_FileNo As File_No, (Select Deduction_Amount From dt_member_policy where Member_ID=(Select distinct Member_ID from dt_member_policy where id='" & ID & "') AND Deduction_Code like 'Y%' and status='INFORCE') As Individual_Amount, " & _
                                "(select Top 1 Request_Date from dt_Member_Endorsement " & _
                                "WHERE member_policy_id='" & ID & "' " & _
                                "Order by Request_Date desc) As Request_Date, " & _
                                "(select Top 1 CAST(Angkasa_Bulan_potongan + '15' As DateTime) from dt_Member_Policy_MonthlyDeduction " & _
                                "WHERE member_policy_id='" & ID & "' " & _
                                "Order by Angkasa_Bulan_potongan desc) As Receive_Date, " & _
                                "a.Deduction_code, b.Title, b.Add3, b.Add4 " & _
                                "FROM dt_Member_policy a INNER JOIN dt_member b ON a.member_id=b.id " & _
                                "WHERE a.ID='" & ID & "' "
        Dim sdp As New SqlDataAdapter(cmdSelect)
        sdp.Fill(ds, "dt_member_policy")
        Deduction_Code = ds.Tables("dt_Member_Policy").Rows(0)("Deduction_Code").ToString().Trim()
        Dim dsReturn As New DataSet("dsLetters")
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
        dt.Columns.Add("Request_Date", GetType(Date))
        dt.Columns.Add("Receive_Date", GetType(Date))
        dt.Columns.Add("Individual_Amount", GetType(Double))
        dt.Columns.Add("Family_Amount", GetType(Double))
        dt.Columns.Add("File_No", GetType(String))
        dt.Columns.Add("Title", GetType(String))
        dt.Columns.Add("Add3", GetType(String))
        dt.Columns.Add("Add4", GetType(String))
        dt.Columns.Add("GST", GetType(Boolean))
        Return dt
    End Function
    Friend Sub Print_Letters(ByVal ReportName As String, ByVal ID As String, ByVal Type As String)
        ExportPDF(ReportName, ID, Type)
    End Sub
    Private Sub ExportPDF(ByVal ReportName As String, ByVal ID As String, ByVal Type As String)
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        CrystalReportViewer.ActiveViewIndex = 0
        CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        CrystalReportViewer.DisplayGroupTree = False
        CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        CrystalReportViewer.Name = "CrystalReportViewer"
        Dim pType As String
        Dim ds As New DataSet
        Select Case Type
            Case "0", "6"
                ds = Me.getCancellationLetter(ID)
            Case "1"
                ds = Me.getNonPaymentLetter(ID)
                Select Case Deduction_Code
                    Case "Y0531", "Y0532", "Y3531", "Y3532", "Y4531", "Y4532", "Y0550", "Y0551", "Y9550", "Y9551"
                        ReportName = "NPL.rpt"
                    Case Else
                        ReportName = "NP.rpt"
                End Select
            Case "2"
                ds = Me.getChange2Yearly(ID)
            Case "3"
                ds = getDue2_60_PercentLetter(ID)
                Select Case Deduction_Code
                    Case "0550", "0551", "0513", "0514"
                        ReportName = "Due_to_60_PercentPA.rpt"
                    Case Else
                        ReportName = "Due_to_60_Percent.rpt"
                End Select
            Case "4"
                ds = getNo_Deduction_frm_AngkasaLetter(ID)
                Select Case Deduction_Code
                    Case "0550", "0551", "0513", "0514"
                        ReportName = "No_Deduction_Frm_AngkasaPA.rpt"
                    Case Else
                        ReportName = "No_Deduction_Frm_Angkasa.rpt"
                End Select
            Case "5"
                ds = Me.getNonPaymentLetter(ID)
            Case "7"
                ds = Me.getIncompleteBiroLetter(ID)
            Case "YEARLYRENEWAL"
                ds = Me.getYearlyRenewalLetter(ID)
            Case "PRINTADDLABEL"
                ds = getAddLabelPrint(ID)
            Case "PRINTPREMIUM"
                ds = getPRINTPREMIUM(ID)
            Case "RETIREES"
                ds = Me.getRetirees(ID)
        End Select
        If ds Is Nothing Then
            Return
        End If
        Dim sRes As String
        Dim sSri As String
        sSri = Application.StartupPath

        Report.Load(Application.StartupPath & "\Report\" & ReportName & "")
        Report.Database.Tables("dt_member_policy").SetDataSource(ds.Tables(0))
        CrystalReportViewer.ReportSource = Report
        Dim _FileName As String = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf"
        Try
            Dim sMonth, srMonth, sDay, sYear, sDate As String
            sDay = Now().Day().ToString()
            sMonth = Now().Month().ToString()
            sYear = Now().Year().ToString()
            Select Case sMonth
                Case "01", "1"
                    srMonth = "Januari"
                Case "02", "2"
                    srMonth = "Februari"
                Case "03", "3"
                    srMonth = "Mac"
                Case "04", "4"
                    srMonth = "April"
                Case "05", "5"
                    srMonth = "Mei"
                Case "06", "6"
                    srMonth = "Jun"
                Case "07", "7"
                    srMonth = "Julai"
                Case "08", "8"
                    srMonth = "Ogos"
                Case "09", "9"
                    srMonth = "September"
                Case "10"
                    srMonth = "Oktober"
                Case "11"
                    srMonth = "November"
                Case "12"
                    srMonth = "Disember"
            End Select
            sDate = sDay & " " & srMonth & " " & sYear
            Dim cryRpt As New ReportDocument()
            Dim pfdsMonth As ParameterFieldDefinitions
            Dim pdfMonth As ParameterFieldDefinition
            Dim pvMonth As New ParameterValues
            Dim pdvMonth As New ParameterDiscreteValue

            pdvMonth.Value = sDate
            pfdsMonth = Report.DataDefinition.ParameterFields()
            pdfMonth = pfdsMonth.Item("sDate")
            pvMonth = pdfMonth.CurrentValues

            pvMonth.Clear()
            pvMonth.Add(pdvMonth)
            pdfMonth.ApplyCurrentValues(pvMonth)
            Select Case Type
                Case "RETIREES"
                    Dim pfdsPremium As ParameterFieldDefinitions
                    Dim pdfPRemium As ParameterFieldDefinition
                    Dim pvPremium As New ParameterValues
                    Dim pdvPremium As New ParameterDiscreteValue

                    pdvPremium.Value = Me.lblOSPremium.Text.ToString.Trim()
                    pfdsPremium = Report.DataDefinition.ParameterFields()
                    pdfPRemium = pfdsPremium.Item("sOSPremium")
                    pvPremium = pdfPRemium.CurrentValues

                    pvPremium.Clear()
                    pvPremium.Add(pdvPremium)
                    pdfPRemium.ApplyCurrentValues(pvPremium)

                    pdvPremium.Value = Me.lblOSGST.Text.ToString.Trim()
                    pfdsPremium = Report.DataDefinition.ParameterFields()
                    pdfPRemium = pfdsPremium.Item("sOSGST")
                    pvPremium = pdfPRemium.CurrentValues

                    pvPremium.Clear()
                    pvPremium.Add(pdvPremium)
                    pdfPRemium.ApplyCurrentValues(pvPremium)

                    pdvPremium.Value = Me.lblPremium.Text.ToString.Trim()
                    pfdsPremium = Report.DataDefinition.ParameterFields()
                    pdfPRemium = pfdsPremium.Item("sPremium")
                    pvPremium = pdfPRemium.CurrentValues

                    pvPremium.Clear()
                    pvPremium.Add(pdvPremium)
                    pdfPRemium.ApplyCurrentValues(pvPremium)


                    pdvPremium.Value = Me.lblGST.Text.ToString.Trim()
                    pfdsPremium = Report.DataDefinition.ParameterFields()
                    pdfPRemium = pfdsPremium.Item("sGST")
                    pvPremium = pdfPRemium.CurrentValues

                    pvPremium.Clear()
                    pvPremium.Add(pdvPremium)
                    pdfPRemium.ApplyCurrentValues(pvPremium)

                    pdvPremium.Value = Me.lblTotPremium.Text.ToString.Trim()
                    pfdsPremium = Report.DataDefinition.ParameterFields()
                    pdfPRemium = pfdsPremium.Item("sTotalPremium")
                    pvPremium = pdfPRemium.CurrentValues

                    pvPremium.Clear()
                    pvPremium.Add(pdvPremium)
                    pdfPRemium.ApplyCurrentValues(pvPremium)
                Case "PRINTPREMIUM"
                    Dim s As String()
                    Dim s1, s2, s3 As String
                    s = ds.Tables(0).Rows(0)("Policy_Type").ToString.Trim().Split("-")
                    s1 = s(0).Trim()
                    s2 = s(0).Trim()
                    s3 = ds.Tables(0).Rows(0)("Policy_Type").ToString.Trim().Substring(0, 12)
                    If Not s3.Trim() = "CUEPACSCARE" Then
                        s3 = s3.Substring(0, 11)
                        pdvMonth.Value = "PELAN PERLINDUNGAN KEMALANGAN " & s1
                    Else
                        pdvMonth.Value = "SKIM TAKAFUL KEMALANGAN" & s1
                    End If
                    pfdsMonth = Report.DataDefinition.ParameterFields()
                    pdfMonth = pfdsMonth.Item("PType")
                    pvMonth = pdfMonth.CurrentValues

                    pvMonth.Clear()
                    pvMonth.Add(pdvMonth)
                    pdfMonth.ApplyCurrentValues(pvMonth)

                    pdvMonth.Value = s3
                    pfdsMonth = Report.DataDefinition.ParameterFields()
                    pdfMonth = pfdsMonth.Item("PPlan")
                    pvMonth = pdfMonth.CurrentValues

                    pvMonth.Clear()
                    pvMonth.Add(pdvMonth)
                    pdfMonth.ApplyCurrentValues(pvMonth)
                Case "0", "6", "7"
                    Dim pfdsPType, pfdsDesc1, pfdsDesc2 As ParameterFieldDefinitions
                    Dim pdfPType, pdfDesc1, pdfDesc2 As ParameterFieldDefinition
                    Dim pvPType, pvDesc1, pvDesc2 As New ParameterValues
                    Dim pdvPType, pdvDesc1, pdvDesc2 As New ParameterDiscreteValue

                    pType = sPType(ID, Deduction_Code)
                    pdvPType.Value = pType
                    pfdsPType = Report.DataDefinition.ParameterFields()
                    pdfPType = pfdsPType.Item("spType")
                    pvPType = pdfPType.CurrentValues

                    pvPType.Clear()
                    pvPType.Add(pdvPType)
                    pdfPType.ApplyCurrentValues(pvPType)
                    Dim desc1, desc2 As String
                    Select Case Deduction_Code
                        Case "0531", "0532", "0550", "0551", "0511", "0512", "0513", "0514"
                            desc1 = "Potongan gaji anda melalui Biro Angkasa anda "
                        Case "Y0531", "Y0532", "Y0532", "Y3531", "Y3532", "Y4531", "Y4532", "Y9550", "Y9551"
                            desc1 = "Sijil Takaful CuepacsCare anda akan"
                        Case Else
                            desc1 = "Potongan gaji anda melalui majikan anda akan "
                    End Select
                    pdvDesc1.Value = desc1
                    pfdsDesc1 = Report.DataDefinition.ParameterFields()
                    pdfDesc1 = pfdsDesc1.Item("sDesc1")
                    pvDesc1 = pdfDesc1.CurrentValues

                    pvDesc1.Clear()
                    pvDesc1.Add(pdvDesc1)
                    pdfDesc1.ApplyCurrentValues(pvDesc1)
                    desc2 = Chr(13) & "Untuk mempercepatkan urusan pemberhentian di Biro Angkasa, sila berhubung terus dengan Jabatan Penggajian anda. " & Chr(13)
                    pdvDesc2.Value = desc2
                    pfdsDesc2 = Report.DataDefinition.ParameterFields()
                    pdfDesc2 = pfdsDesc2.Item("sDesc2")
                    pvDesc2 = pdfDesc2.CurrentValues

                    pvDesc2.Clear()
                    pvDesc2.Add(pdvDesc2)
                    pdfDesc2.ApplyCurrentValues(pvDesc2)
                Case "1", "2", "4", "5"
                    Dim pfdsPType, pfdsDesc1, pfdsDesc2 As ParameterFieldDefinitions
                    Dim pdfPType, pdfDesc1, pdfDesc2 As ParameterFieldDefinition
                    Dim pvPType, pvDesc1, pvDesc2 As New ParameterValues
                    Dim pdvPType, pdvDesc1, pdvDesc2 As New ParameterDiscreteValue

                    pType = sPType(ID, Deduction_Code)
                    pdvPType.Value = pType
                    pfdsPType = Report.DataDefinition.ParameterFields()
                    pdfPType = pfdsPType.Item("sPType")
                    pvPType = pdfPType.CurrentValues

                    pvPType.Clear()
                    pvPType.Add(pdvPType)
                    pdfPType.ApplyCurrentValues(pvPType)
                    Dim desc1, desc2 As String
                    Select Case Deduction_Code
                        Case "0531", "0532", "0550", "0551", "0511", "0512", "0513", "0514"
                            desc1 = " Biro Angkasa"
                        Case Else
                            desc1 = " majikan "
                    End Select
                    pdvDesc1.Value = desc1
                    pfdsDesc1 = Report.DataDefinition.ParameterFields()
                    pdfDesc1 = pfdsDesc1.Item("sDesc1")
                    pvDesc1 = pdfDesc1.CurrentValues

                    pvDesc1.Clear()
                    pvDesc1.Add(pdvDesc1)
                    pdfDesc1.ApplyCurrentValues(pvDesc1)
                    Select Case Type
                        Case "1"
                            Select Case Deduction_Code
                                Case "0531", "0532", "0511", "0512"
                                    desc2 = " BAYARAN MELALUI BIRO ANGKASA TIDAK BERJAYA"
                                Case Else
                                    desc2 = ""
                            End Select
                        Case Else
                            desc2 = ""
                    End Select
                    pdvDesc2.Value = desc2
                    pfdsDesc2 = Report.DataDefinition.ParameterFields()
                    pdfDesc2 = pfdsDesc1.Item("sDesc2")
                    pvDesc2 = pdfDesc1.CurrentValues

                    pvDesc2.Clear()
                    pvDesc2.Add(pdvDesc2)
                    pdfDesc2.ApplyCurrentValues(pvDesc2)
            End Select
            cryRpt = DirectCast(CrystalReportViewer.ReportSource, ReportDocument)
            Dim exportOpts As New ExportOptions()
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile

            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = Application.StartupPath & "\Report\Letters\" & _FileName
            CrExportOptions = cryRpt.ExportOptions
            If True Then
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions
                CrExportOptions.FormatOptions = CrFormatTypeOptions
            End If
            cryRpt.Export()
            System.Diagnostics.Process.Start(Application.StartupPath & "\Report\Letters\" & _FileName)
        Catch Ex As Exception
            Dim msg As String = Ex.Message
            MessageBox.Show("You Must Have a report viewable in the Report panel To print")
        End Try
    End Sub
    Private Function sPType(ByVal ID As String, ByVal Deduction_Code As String) As String
        Dim PType As String = ""
        Select Case Deduction_Code
            Case "0531", "0532", "0511", "0512"
                PType = "CUEPACSCARE"
            Case "Y0531", "Y0532"
                PType = "CUEPACSCARE (Tahunan)"
            Case "0550", "0551", "0513", "0514"
                PType = "CUEPACSPA"
            Case Else
                Dim Conn As DbConnection = New SqlConnection
                Conn.ConnectionString = My.Settings.SQL_Conn
                Conn.Open()
                Dim dt As New DataTable
                Dim ds As New DataSet
                Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                cmdSelect.CommandType = CommandType.Text
                cmdSelect.CommandText = "select * from dt_member_policy WHERE ID='" & ID & "' "
                Dim sdp As New SqlDataAdapter(cmdSelect)
                sdp.Fill(ds, "dt_member_policy")
                Dim stPType As String()
                stPType = ds.Tables(0).Rows(0)("Plan_Code").ToString.Split("-")
                PType = stPType(0)
               
        End Select
        Return PType
    End Function
    Private Function getYearlyRenewalLetter(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.CommandText = "SELECT TOP 1 a.ID, b.Full_Name, substring(b.IC_New,2,14) AS IC_NEW, " & _
                                "b.Postal_Address_L1 As Add1, b.Postal_Address_L2 As Add2,  b.Postcode + ', ' + b.Town As Town, b.State ,  " & _
                                "case when (new_policy_no is null or new_policy_no='') then A.Policy_No else new_policy_no end as Policy_NO, " & _
                                " PLAN_CODE As Policy_Type, c.Request_Date As Request_Date, a.Deduction_Amount As Individual_Amount, a.Deduction_code, b.Title, b.Add3, b.Add4, GST " & _
                                "FROM dt_Member_policy a INNER JOIN dt_member b ON a.member_id=b.id left join dt_member_policy_yearlyRenewal c ON c.Member_policy_ID=a.ID" & _
                                " WHERE a.ID='" & ID & "' ORDER BY REquest_Date desc "
        Dim sdp As New SqlDataAdapter(cmdSelect)
        sdp.Fill(ds, "dt_member_policy")
        Deduction_Code = ds.Tables("dt_Member_Policy").Rows(0)("Deduction_Code").ToString().Trim()
        Dim dsReturn As New DataSet("dsLetters")
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
    Private Function getRetirees(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        ds = _objBusi.getDsDetails_VI("RETIREES", ID, "", "", "", "", "", "", "", "", "", Conn)
        Deduction_Code = ds.Tables(0).Rows(0)("Deduction_Code").ToString().Trim()
        Dim dsReturn As New DataSet("dsLetters")
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
    Private Function getAddLabelPrint(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim dtMain As New DataTable
        dtMain = _objBusi.getDetails_I("PRINTADDLABEL", ID, "", "", "", "", "", "", "", "", "", Conn)
        Dim dsReturn As New DataSet("dsLetters")
        dt = tb_Member_Policy()
        Try
            For Each row As DataRow In dtMain.Rows
                dt.ImportRow(row)
            Next
        Catch ex As Exception
        End Try
        dsReturn.Tables.Add(dt)
        Return dsReturn
    End Function
    Private Function getPRINTPREMIUM(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim dtMain As New DataTable
        dtMain = _objBusi.getDetails_I("PRINTPREMIUM", ID, "", "", "", "", "", "", "", "", "PRINT", Conn)
        Dim dsReturn As New DataSet("dsLetters")
        dt = tb_Member_Policy()
        Try
            For Each row As DataRow In dtMain.Rows
                dt.ImportRow(row)
            Next
        Catch ex As Exception
        End Try
        dsReturn.Tables.Add(dt)
        Return dsReturn
    End Function
    Friend Sub PrintProposer(ByVal RName As String, ByVal ID As String, ByVal Type As String)
        XPort2PDF(RName, ID, Type)
    End Sub
    Friend Sub PrintACS(ByVal RName As String, ByVal AC As String, ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String)
        xPort2PDFforACS(RName, AC, Type, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10)
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
        Dim _FileName As String = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf"
        Try

            Dim cryRpt As New ReportDocument()
            Dim pfdsP1 As ParameterFieldDefinitions
            Dim pdfP1 As ParameterFieldDefinition
            Dim pvP1 As New ParameterValues
            Dim pdvP1 As New ParameterDiscreteValue
            pdvP1.Value = P6
            pfdsP1 = Report.DataDefinition.ParameterFields()
            pdfP1 = pfdsP1.Item("P1")
            pvP1 = pdfP1.CurrentValues

            pvP1.Clear()
            pvP1.Add(pdvP1)
            pdfP1.ApplyCurrentValues(pvP1)

            pdvP1.Value = P6
            pfdsP1 = Report.DataDefinition.ParameterFields()
            pdfP1 = pfdsP1.Item("P2")
            pvP1 = pdfP1.CurrentValues

            pvP1.Clear()
            pvP1.Add(pdvP1)
            pdfP1.ApplyCurrentValues(pvP1)

            pdvP1.Value = P7
            pfdsP1 = Report.DataDefinition.ParameterFields()
            pdfP1 = pfdsP1.Item("P3")
            pvP1 = pdfP1.CurrentValues

            pvP1.Clear()
            pvP1.Add(pdvP1)
            pdfP1.ApplyCurrentValues(pvP1)

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

            CrDiskFileDestinationOptions.DiskFileName = Application.StartupPath & "\Report\Letters\" & _FileName
            CrExportOptions = cryRpt.ExportOptions
            If True Then
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions
                CrExportOptions.FormatOptions = CrFormatTypeOptions
            End If
            cryRpt.Export()
            System.Diagnostics.Process.Start(Application.StartupPath & "\Report\Letters\" & _FileName)
        Catch Ex As Exception
            Dim msg As String = Ex.Message
            MessageBox.Show("You Must Have a report viewable in the Report panel To print")
        End Try
    End Sub
    Private Sub XPort2PDF(ByVal ReportName As String, ByVal ID As String, ByVal Type As String)
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        CrystalReportViewer.ActiveViewIndex = 0
        CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        CrystalReportViewer.DisplayGroupTree = False
        CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        CrystalReportViewer.Name = "CrystalReportViewer"
        Dim ds As New DataSet
        If Type = "AGENT" Then
            ds = getAgent(ID)
        ElseIf Type = "CLIENTREQUEST" Then
            ds = getClientRequest(ID)
        ElseIf Type = "AGENTCOMISSION" Then
            ds = getAgentComission(ID)
        Else
            ds = getProposer(ID)
        End If

        If ds Is Nothing Then
            Return
        End If

        Report.Load(Application.StartupPath & "\Report\" & ReportName & "")
        If Type = "AGENT" Then
            Report.Database.Tables("dtAgent").SetDataSource(ds.Tables(0))
        ElseIf Type = "CLIENTREQUEST" Then
            Report.Database.Tables("dt_proposer").SetDataSource(ds.Tables(0))
        Else
            Report.Database.Tables("dt_proposer").SetDataSource(ds.Tables(0))
            Report.Database.Tables("dt_proposer_dependents").SetDataSource(ds.Tables(1))
            Report.Database.Tables("dt_proposer_nomination").SetDataSource(ds.Tables(2))
            Report.Database.Tables("dt_proposer_ec").SetDataSource(ds.Tables(3))
        End If
        
        CrystalReportViewer.ReportSource = Report
        Dim _FileName As String = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf"
        Try

            Dim cryRpt As New ReportDocument()

            Dim pfdsPrintedBy As ParameterFieldDefinitions
            Dim pdfPrintedBy As ParameterFieldDefinition
            Dim pvPrintedBy As New ParameterValues
            Dim pdvPrintedBy As New ParameterDiscreteValue

            pdvPrintedBy.Value = My.Settings.Username.ToString.ToUpper.Trim()
            pfdsPrintedBy = Report.DataDefinition.ParameterFields()
            pdfPrintedBy = pfdsPrintedBy.Item("pPrintedBy")
            pvPrintedBy = pdfPrintedBy.CurrentValues

            pvPrintedBy.Clear()
            pvPrintedBy.Add(pdvPrintedBy)
            pdfPrintedBy.ApplyCurrentValues(pvPrintedBy)

            If Type = "UW" Then
                Dim pfdssYear As ParameterFieldDefinitions
                Dim pdfsYear As ParameterFieldDefinition
                Dim pvsYear As New ParameterValues
                Dim pdvsYear As New ParameterDiscreteValue

                Dim dt As New DataTable
                dt = _objBusi.getProposerDetails(ID)
                Dim pCode As String()
                pCode = dt.Rows(0)("Plan_Code").ToString.Split("-")
                Dim pName As String()
                Dim sPN As String
                pName = pCode(0).Split("(")
                sPN = pName(1).ToString().Replace(")", "")
                If pCode(1).Substring(0, 1) = "Y" Then
                    If sPN = "YEARLY" Then
                        pdvsYear.Value = "(Tahunan)"
                    Else
                        pdvsYear.Value = "(Tahunan)" & "-" & sPN
                    End If
                Else
                    If sPN = "MONTHLY" Then
                        pdvsYear.Value = ""
                    Else
                        pdvsYear.Value = "-" & sPN
                    End If
                End If
                pfdssYear = Report.DataDefinition.ParameterFields()
                pdfsYear = pfdssYear.Item("sYear")
                pvsYear = pdfsYear.CurrentValues

                pvsYear.Clear()
                pvsYear.Add(pdvsYear)
                pdfsYear.ApplyCurrentValues(pvsYear)
            End If
            cryRpt = DirectCast(CrystalReportViewer.ReportSource, ReportDocument)
            Dim exportOpts As New ExportOptions()
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile

            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = Application.StartupPath & "\Report\Letters\" & _FileName
            CrExportOptions = cryRpt.ExportOptions
            If True Then
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions
                CrExportOptions.FormatOptions = CrFormatTypeOptions
            End If
            cryRpt.Export()
            System.Diagnostics.Process.Start(Application.StartupPath & "\Report\Letters\" & _FileName)
        Catch Ex As Exception
            Dim msg As String = Ex.Message
            MessageBox.Show("You Must Have a report viewable in the Report panel To print")
        End Try
    End Sub
    Private Sub XPort2PDF4SendMail(ByVal ReportName As String, ByVal ID As String, ByVal Type As String)
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        CrystalReportViewer.ActiveViewIndex = 0
        CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        CrystalReportViewer.DisplayGroupTree = False
        CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        CrystalReportViewer.Name = "CrystalReportViewer"
        Dim ds As New DataSet
        If Type = "AGENT" Then
            ds = getAgent(ID)
        ElseIf Type = "AGENTCOMISSION" Then
            ds = getClientRequest(ID)
        Else
            ds = getProposer(ID)
        End If

        If ds Is Nothing Then
            Return
        End If

        Report.Load(Application.StartupPath & "\Report\" & ReportName & "")
        If Type = "AGENT" Then
            Report.Database.Tables("dtAgent").SetDataSource(ds.Tables(0))
        Else
            Report.Database.Tables("dt_proposer").SetDataSource(ds.Tables(0))
            Report.Database.Tables("dt_proposer_dependents").SetDataSource(ds.Tables(1))
            Report.Database.Tables("dt_proposer_nomination").SetDataSource(ds.Tables(2))
            Report.Database.Tables("dt_proposer_ec").SetDataSource(ds.Tables(3))
        End If

        CrystalReportViewer.ReportSource = Report
        Dim _FileName As String = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf"
        Try

            Dim cryRpt As New ReportDocument()
            Dim pfdsPrintedBy As ParameterFieldDefinitions
            Dim pdfPrintedBy As ParameterFieldDefinition
            Dim pvPrintedBy As New ParameterValues
            Dim pdvPrintedBy As New ParameterDiscreteValue

            pdvPrintedBy.Value = My.Settings.Username.ToString.ToUpper.Trim()
            pfdsPrintedBy = Report.DataDefinition.ParameterFields()
            pdfPrintedBy = pfdsPrintedBy.Item("pPrintedBy")
            pvPrintedBy = pdfPrintedBy.CurrentValues

            pvPrintedBy.Clear()
            pvPrintedBy.Add(pdvPrintedBy)
            pdfPrintedBy.ApplyCurrentValues(pvPrintedBy)

            If Type = "UW" Then
                Dim pfdssYear As ParameterFieldDefinitions
                Dim pdfsYear As ParameterFieldDefinition
                Dim pvsYear As New ParameterValues
                Dim pdvsYear As New ParameterDiscreteValue
                Dim dt As New DataTable
                dt = _objBusi.getProposerDetails(ID)
                Dim pCode As String()
                pCode = dt.Rows(0)("Plan_Code").ToString.Split("-")
                Dim pName As String()
                Dim sPN As String
                pName = pCode(0).Split("(")
                sPN = pName(1).ToString().Replace(")", "")
                If pCode(1).Substring(0, 1) = "Y" Then
                    If sPN = "YEARLY" Then
                        pdvsYear.Value = "(Tahunan)"
                    Else
                        pdvsYear.Value = "(Tahunan)" & "-" & sPN
                    End If
                Else
                    If sPN = "MONTHLY" Then
                        pdvsYear.Value = ""
                    Else
                        pdvsYear.Value = "-" & sPN
                    End If
                End If
                pfdssYear = Report.DataDefinition.ParameterFields()
                pdfsYear = pfdssYear.Item("sYear")
                pvsYear = pdfsYear.CurrentValues

                pvsYear.Clear()
                pvsYear.Add(pdvsYear)
                pdfsYear.ApplyCurrentValues(pvsYear)
            End If
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
            System.Diagnostics.Process.Start(Application.StartupPath & "\Report\Emails\" & _FileName)
        Catch Ex As Exception
            Dim msg As String = Ex.Message
            MessageBox.Show("You Must Have a report viewable in the Report panel To print")
        End Try
    End Sub

    Private Function getAgent(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim cmdSelect As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.CommandText = "select tb_agent_id, nric, agent_code as AGENTCODE, agent_name as full_name, dob, age, race, gender, marital_status as MSTATUS, add1, add2, town, state, postcode as POSCODE," & _
                                "tel as [CONTACTNO], contact_office as [CONTACTOFFICE], MOBILE, EMAIL, PERCENTAGE AS [COMISSION], APPLICATION_DATE AS APPLICATIONDT, APPOINTMENT_DATE AS [APPOINTMENTDT] " & _
                                "from tb_agent " & _
                                "WHERE Agent_id='" & ID & "' "
        Dim sdp As New SqlDataAdapter(cmdSelect)
        sdp.Fill(ds, "tb_agent")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dsReturn As New DataSet("dsLetters")
            dt = dt_Agent()
            Try
                For Each dr As DataRow In ds.Tables(0).Rows
                    dt.ImportRow(dr)
                Next
            Catch ex As Exception
            End Try
            dsReturn.Tables.Add(dt)
            Return dsReturn
        End If
    End Function
    Private Function getClientRequest(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt, dt1, dt2, dt3, dtP, dtPD, dtPN, dtPEC As New DataTable
        Dim ds As New DataSet
        dtP = _objBusi.getPrint("CLIENTREQUEST", ID, "", "", "", "", "", "", "", "", "", Conn)
        Dim dsReturn As New DataSet("dsLetters")
        dt = dt_proposer()
        Try
            For Each dr As DataRow In dtP.Rows
                dt.ImportRow(dr)
            Next
        Catch ex As Exception
        End Try
        dsReturn.Tables.Add(dt)
        Return dsReturn
    End Function
    Private Function getAGENTCOMISSION(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt, dt1, dt2, dt3, dtP, dtPD, dtPN, dtPEC As New DataTable
        Dim ds As New DataSet
        dtP = _objBusi.getPrint("AGENTCOMISSION", ID, "", "", "", "", "", "", "", "", "", Conn)
        Dim dsReturn As New DataSet("dsLetters")
        dt = dt_proposer()
        Try
            For Each dr As DataRow In dtP.Rows
                dt.ImportRow(dr)
            Next
        Catch ex As Exception
        End Try
        dsReturn.Tables.Add(dt)
        Return dsReturn
    End Function
    Private Function getProposer(ByVal ID As String) As DataSet
        Dim Conn As DbConnection = New SqlConnection
        Conn.ConnectionString = My.Settings.SQL_Conn
        Conn.Open()
        Dim dt, dt1, dt2, dt3, dtP, dtPD, dtPN, dtPEC As New DataTable
        Dim ds As New DataSet
        dtP = _objBusi.getPrint("PROPOSER", ID, "", "", "", "", "", "", "", "", "PROPOSER", Conn)
        dtPD = _objBusi.getPrint("PROPOSER", ID, "", "", "", "", "", "", "", "", "DEPENDENTS", Conn)
        dtPN = _objBusi.getPrint("PROPOSER", ID, "", "", "", "", "", "", "", "", "NOMINATION", Conn)
        dtPEC = _objBusi.getPrint("PROPOSER", ID, "", "", "", "", "", "", "", "", "EC", Conn)
        Dim dsReturn As New DataSet("dsLetters")
        dt = dt_proposer()
        Try
            For Each dr As DataRow In dtP.Rows
                dt.ImportRow(dr)
            Next
        Catch ex As Exception
        End Try
        dt1 = dt_proposer_dependents()
        Try
            For Each dr1 As DataRow In dtPD.Rows
                dt1.ImportRow(dr1)
            Next
        Catch ex As Exception
        End Try
        dt2 = dt_proposer_nomination()
        Try
            For Each dr2 As DataRow In dtPN.Rows
                dt2.ImportRow(dr2)
            Next
        Catch ex As Exception
        End Try
        dt3 = dt_proposer_ec()
        Try
            For Each dr3 As DataRow In dtPEC.Rows
                dt3.ImportRow(dr3)
            Next
        Catch ex As Exception
        End Try
        dsReturn.Tables.Add(dt)
        dsReturn.Tables.Add(dt1)
        dsReturn.Tables.Add(dt2)
        dsReturn.Tables.Add(dt3)
        Return dsReturn
    End Function
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
        Try
            For Each dr As DataRow In dt.Rows
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
    Private Function dt_proposer() As DataTable
        Dim dt As New DataTable("dt_proposer")
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("title", GetType(String))
        dt.Columns.Add("full_name", GetType(String))
        dt.Columns.Add("ic_new", GetType(String))
        dt.Columns.Add("ic_old", GetType(String))
        dt.Columns.Add("dob", GetType(String))
        dt.Columns.Add("race", GetType(String))
        dt.Columns.Add("marital_status", GetType(String))
        dt.Columns.Add("sex", GetType(String))
        dt.Columns.Add("proposal_received_date", GetType(String))
        dt.Columns.Add("proposal_signed_date", GetType(String))
        dt.Columns.Add("add1", GetType(String))
        dt.Columns.Add("add2", GetType(String))
        dt.Columns.Add("add3", GetType(String))
        dt.Columns.Add("add4", GetType(String))
        dt.Columns.Add("town", GetType(String))
        dt.Columns.Add("state", GetType(String))
        dt.Columns.Add("poscode", GetType(String))
        dt.Columns.Add("phone_house", GetType(String))
        dt.Columns.Add("phone_mobile", GetType(String))
        dt.Columns.Add("phone_off", GetType(String))
        dt.Columns.Add("email", GetType(String))
        dt.Columns.Add("height", GetType(String))
        dt.Columns.Add("weight", GetType(String))
        dt.Columns.Add("occupation", GetType(String))
        dt.Columns.Add("department", GetType(String))
        dt.Columns.Add("plan_code", GetType(String))
        dt.Columns.Add("plan_type", GetType(String))
        dt.Columns.Add("premium", GetType(String))
        dt.Columns.Add("special_promo", GetType(String))
        dt.Columns.Add("underwriting_required", GetType(String))
        dt.Columns.Add("payment_type", GetType(String))
        dt.Columns.Add("payment_method", GetType(String))
        dt.Columns.Add("cc_batch_no", GetType(String))
        dt.Columns.Add("cc_aproval_code", GetType(String))
        dt.Columns.Add("cc_invoice_no", GetType(String))
        dt.Columns.Add("chq_no", GetType(String))
        dt.Columns.Add("chq_receipt_no", GetType(String))
        dt.Columns.Add("cash_receipt_no", GetType(String))
        dt.Columns.Add("cash_receipt_issued", GetType(String))
        dt.Columns.Add("biro_angkasa_no", GetType(String))
        dt.Columns.Add("de_chk_lst", GetType(String))
        dt.Columns.Add("de_chk_lst_enrld_dependent", GetType(String))
        dt.Columns.Add("de_chk_lst_insurace_proposed", GetType(String))
        dt.Columns.Add("de_chk_lst_nomination", GetType(String))
        dt.Columns.Add("doc_chk_lst_app_frm", GetType(String))
        dt.Columns.Add("doc_chk_lst_app_frm_status", GetType(String))
        dt.Columns.Add("doc_chk_lst_ic", GetType(String))
        dt.Columns.Add("doc_chk_lst_pentaya", GetType(String))
        dt.Columns.Add("doc_chk_lst_payslip", GetType(String))
        dt.Columns.Add("doc_chk_lst_payslip_status", GetType(String))
        dt.Columns.Add("doc_chk_lst_borang1_79", GetType(String))
        dt.Columns.Add("doc_chk_lst_borang1_79_status", GetType(String))
        dt.Columns.Add("status", GetType(String))
        dt.Columns.Add("created_by", GetType(String))
        dt.Columns.Add("created_on", GetType(String))
        dt.Columns.Add("verify_by", GetType(String))
        dt.Columns.Add("verify_on", GetType(String))
        dt.Columns.Add("printed_by", GetType(String))
        dt.Columns.Add("printed_on", GetType(String))
        dt.Columns.Add("decline_reason", GetType(String))
        dt.Columns.Add("file_no", GetType(String))
        dt.Columns.Add("submission_batch_no", GetType(String))
        dt.Columns.Add("submitted_by", GetType(String))
        dt.Columns.Add("submitted_on", GetType(String))
        dt.Columns.Add("agent_code", GetType(String))
        Return dt
    End Function
    Private Function dt_Agent() As DataTable
        Dim dt As New DataTable("dtAgent")
        dt.Columns.Add("ID", GetType(String))
        dt.Columns.Add("NRIC", GetType(String))
        dt.Columns.Add("FULL_NAME", GetType(String))
        dt.Columns.Add("AGENTCODE", GetType(String))
        dt.Columns.Add("DOB", GetType(String))
        dt.Columns.Add("AGE", GetType(String))
        dt.Columns.Add("RACE", GetType(String))
        dt.Columns.Add("GENDER", GetType(String))
        dt.Columns.Add("MSTATUS", GetType(String))
        dt.Columns.Add("ADD1", GetType(String))
        dt.Columns.Add("ADD2", GetType(String))
        dt.Columns.Add("ADD3", GetType(String))
        dt.Columns.Add("ADD4", GetType(String))
        dt.Columns.Add("TOWN", GetType(String))
        dt.Columns.Add("STATE", GetType(String))
        dt.Columns.Add("POSCODE", GetType(String))
        dt.Columns.Add("CONTACTNO", GetType(String))
        dt.Columns.Add("CONTACTOFFICE", GetType(String))
        dt.Columns.Add("MOBILE", GetType(String))
        dt.Columns.Add("EMAIL", GetType(String))
        dt.Columns.Add("COMISSION", GetType(String))
        dt.Columns.Add("APPLICATIONDT", GetType(String))
        dt.Columns.Add("APPOINTMENTDT", GetType(String))
        dt.Columns.Add("BANKAC", GetType(String))
        dt.Columns.Add("DESIGNATION", GetType(String))
        dt.Columns.Add("PLAN", GetType(String))
        dt.Columns.Add("COMPANY", GetType(String))
        dt.Columns.Add("AGENTTYPE", GetType(String))
        dt.Columns.Add("MNGR", GetType(String))
        dt.Columns.Add("SUPERVISOR", GetType(String))
        dt.Columns.Add("SPOUSENAME", GetType(String))
        dt.Columns.Add("payment_type", GetType(String))
        Return dt
    End Function
    Private Function dt_proposer_dependents() As DataTable
        Dim dt As New DataTable("dt_proposer_dependents")
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("proposer_id", GetType(String))
        dt.Columns.Add("title", GetType(String))
        dt.Columns.Add("full_name", GetType(String))
        dt.Columns.Add("ic_new", GetType(String))
        dt.Columns.Add("ic_old", GetType(String))
        dt.Columns.Add("dob", GetType(String))
        dt.Columns.Add("race", GetType(String))
        dt.Columns.Add("marital_status", GetType(String))
        dt.Columns.Add("sex", GetType(String))
        dt.Columns.Add("relationship", GetType(String))
        dt.Columns.Add("height", GetType(String))
        dt.Columns.Add("weight", GetType(String))
        dt.Columns.Add("occupation", GetType(String))
        dt.Columns.Add("department", GetType(String))
        Return dt
    End Function
    Private Function dt_proposer_nomination() As DataTable
        Dim dt As New DataTable("dt_proposer_nomination")
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("proposer_id", GetType(String))
        dt.Columns.Add("title", GetType(String))
        dt.Columns.Add("full_name", GetType(String))
        dt.Columns.Add("dob", GetType(String))
        dt.Columns.Add("relationship", GetType(String))
        dt.Columns.Add("add1", GetType(String))
        dt.Columns.Add("add2", GetType(String))
        dt.Columns.Add("add3", GetType(String))
        dt.Columns.Add("add4", GetType(String))
        dt.Columns.Add("town", GetType(String))
        dt.Columns.Add("state", GetType(String))
        dt.Columns.Add("poscode", GetType(String))
        dt.Columns.Add("share", GetType(String))
        Return dt
    End Function
    Private Function dt_proposer_ec() As DataTable
        Dim dt As New DataTable("dt_proposer_ec")
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("proposer_id", GetType(String))
        dt.Columns.Add("ec_code", GetType(String))
        dt.Columns.Add("ec_description", GetType(String))
        Return dt
    End Function
End Class