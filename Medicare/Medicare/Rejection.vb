Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Rejection
    Inherits System.Windows.Forms.Form
    Dim _objBusi As New Business
    Private Sub Rejection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        Dim cryRpt As New ReportDocument
        If UCase(Me.lblReject_Reason.Text) = "POTONGAN ANGKASA MELEBIHI 60%" Then
            Dim PlanCode As String()
            PlanCode = Me.lblPlanCode.Text.Split("-")
            Select Case PlanCode(1)
                Case "0531", "0532", "0511", "0512"
                    cryRpt.Load(Application.StartupPath & "\Report\RejectDue60Per.rpt")
                Case "0550", "0551", "0513", "0514"
                    cryRpt.Load(Application.StartupPath & "\Report\RejectLetter60DuePA.rpt")
                Case Else
                    cryRpt.Load(Application.StartupPath & "\Report\rejectLetter.rpt")
            End Select
        Else
            Select Case Me.lblRejectReason.Text.Trim()
                Case "PROPOSEREXISTS"
                    cryRpt.Load(Application.StartupPath & "\Report\RejectMemExists.rpt")
                Case "PROPOSERSPOUSEEXISTS"
                    cryRpt.Load(Application.StartupPath & "\Report\RejectPSExists.rpt")
                Case "PROPOSEROVERAGED"
                    cryRpt.Load(Application.StartupPath & "\Report\OverAged.rpt")
                Case Else
                    cryRpt.Load(Application.StartupPath & "\Report\rejectLetter.rpt")
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


        crParameterDiscreteValue.Value = Me.lblsDate.Text.Trim()
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("sDRV")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


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


        crParameterDiscreteValue.Value = Me.lblReject_Reason.Text.Trim & "."
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("rejectReason")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
    End Sub

End Class