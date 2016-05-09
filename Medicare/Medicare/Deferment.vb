Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Deferment
    Inherits System.Windows.Forms.Form
#Region "Global Veriables"
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub Rejection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        Dim cryRpt As New ReportDocument
        Dim PlanCode As String()
        PlanCode = Me.lblPlanCode.Text.Split("-")
        Select Case PlanCode(1).Substring(0, 1)
            Case "0"
                cryRpt.Load(Application.StartupPath & "\Report\defermentLetter.rpt")
            Case Else
                Select Case PlanCode(1).Substring(0, 2)
                    Case "Y0"
                        cryRpt.Load(Application.StartupPath & "\Report\defermentLetter.rpt")
                    Case Else
                        cryRpt.Load(Application.StartupPath & "\Report\defermentLetterO.rpt")
                End Select
        End Select
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

        'sDate
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

        crParameterDiscreteValue.Value = Me.Label1.Text.Trim
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("Form")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Me.Label2.Text.Trim
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("Slip")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Me.Label3.Text.Trim
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("IC")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Me.Label4.Text.Trim
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("Angkasa")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        'P1
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Me.Label5.Text.Trim
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("P1")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        'P2
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Me.Label6.Text.Trim
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("P2")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        'P3
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Me.Label7.Text.Trim
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("P3")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        'P4
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Me.Label8.Text.Trim
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("P4")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        'P5
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Me.Label9.Text.Trim
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("P5")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        Dim dt As New DataTable
        dt = _objBusi.getProposerDetails(Me.lblProposer_ID.Text.ToString.Trim)
        Dim pCode As String()
        pCode = dt.Rows(0)("Plan_Code").ToString.Split("-")
        If pCode(1).Substring(0, 1) = "Y" Then
            Select Case PlanCode(1).Substring(0, 2)
                Case "Y0"
                    crParameterDiscreteValue.Value = "(Tahunan)"
                Case Else
                    If pCode(0).Substring(0, 12).Trim() = "CUEPACSCARE" Then
                        crParameterDiscreteValue.Value = pCode(0).ToString.Replace("CUEPACSCARE", "")
                    Else
                        crParameterDiscreteValue.Value = pCode(0).ToString.Replace("CUEPACS PA", "")
                    End If
            End Select
        Else
            Select Case PlanCode(1).Substring(0, 1)
                Case "0"
                    crParameterDiscreteValue.Value = ""
                Case Else
                    If pCode(0).Substring(0, 12).Trim() = "CUEPACSCARE" Then
                        crParameterDiscreteValue.Value = pCode(0).ToString.Replace("CUEPACSCARE", "")
                    Else
                        crParameterDiscreteValue.Value = pCode(0).ToString.Replace("CUEPACS PA", "")
                    End If
            End Select
        End If
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("Town")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
    End Sub
#End Region
    
End Class