Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Underwriting
    Inherits System.Windows.Forms.Form
    Dim _objBusi As New Business
    Private Sub Rejection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim cryRpt As New ReportDocument

        If Me.lblUnderWriting_ID.Text.ToString.Trim = "P1" Then
            cryRpt.Load(Application.StartupPath & "\Report\underwritingLetter.rpt")
        Else
            cryRpt.Load(Application.StartupPath & "\Report\underwritingLetterP2.rpt")
        End If

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

        crParameterDiscreteValue.Value = "{" & Me.lblProposer_ID.Text.Trim & "}"
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("ID")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        Dim dt As New DataTable
        dt = _objBusi.getProposerDetails(Me.lblProposer_ID.Text.Trim())
        Dim pCode As String()
        pCode = dt.Rows(0)("Plan_Code").ToString.Split("-")
        Dim pName As String()
        Dim sPN As String
        pName = pCode(0).Split("(")
        sPN = pName(1).ToString().Replace(")", "")
        If pCode(1).Substring(0, 1) = "Y" Then
            If sPN = "YEARLY" Then
                crParameterDiscreteValue.Value = "(Tahunan)"
            Else
                crParameterDiscreteValue.Value = "(Tahunan)" & "-" & sPN
            End If
        Else
            If sPN = "MONTHLY" Then
                crParameterDiscreteValue.Value = ""
            Else
                crParameterDiscreteValue.Value = "-" & sPN
            End If
        End If
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("sYear")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


        If Me.lblUnderWriting_ID.Text.ToString.Trim = "P1" Then
            crParameterDiscreteValue.Value = Me.LabelL1.Text.Trim
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("L1")
            crParameterValues = crParameterFieldDefinition.CurrentValues

            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Me.LabelL2.Text.Trim
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("L2")
            crParameterValues = crParameterFieldDefinition.CurrentValues

            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Me.LabelL3.Text.Trim
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("Poscode")
            crParameterValues = crParameterFieldDefinition.CurrentValues

            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Me.LabelL4.Text.Trim
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("State")
            crParameterValues = crParameterFieldDefinition.CurrentValues

            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        End If

        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
    End Sub

End Class