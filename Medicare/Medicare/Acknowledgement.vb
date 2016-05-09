Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Acknowledgement
    Inherits System.Windows.Forms.Form
#Region "Global Veriables"
    Dim _objBusi As New Business
#End Region
#Region "Page Evnets"
    Private Sub Rejection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        Dim cryRpt As New ReportDocument
        Dim PlanCode As String()
        PlanCode = Me.lblPlancode.Text.Split("-")
        If Me.lblPType.Text.Trim() = "INFO" Then
            cryRpt.Load(Application.StartupPath & "\Report\InfoletterN.rpt")
            Me.Text = "Premium Notification Letter"
        Else
            Select Case PlanCode(1).Substring(0, 1)
                Case "0"
                    cryRpt.Load(Application.StartupPath & "\Report\acknowledgementLetter.rpt")
                Case Else
                    cryRpt.Load(Application.StartupPath & "\Report\acknowledgementLetterO.rpt")
            End Select
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
        'Date
        crParameterDiscreteValue.Value = _objBusi.fsDate()
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("sDate")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = "{" & Me.lblProposer_ID.Text.Trim & "}"
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("ID")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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

        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
    End Sub
#End Region
End Class