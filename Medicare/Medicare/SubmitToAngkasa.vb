Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class SubmitToAngkasa
    Inherits System.Windows.Forms.Form


    Private Sub SubmitToAngkasa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        Dim cryRpt As New ReportDocument
        cryRpt.Load(Application.StartupPath & "\Report\SubmitToAngkasa.rpt")
        With crConnectionInfo
            .ServerName = My.Settings.Report_DBServerName.ToString.Trim
            .DatabaseName = My.Settings.Report_DBName.ToString.Trim
            .UserID = "sa"
            .Password = My.Settings.Report_DBPassword.ToString.Trim
        End With

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        crParameterDiscreteValue.Value = lblBatch_No.Text.Trim
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("Batch No")
        crParameterValues = crParameterFieldDefinition.CurrentValues


        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = My.Settings.Username.ToUpper.Trim()
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("sPreparedBy")
        crParameterValues = crParameterFieldDefinition.CurrentValues


        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()

    End Sub
End Class