Imports System.Windows.Forms
Public Class dlgSelectMonth
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
#End Region
#Region "Page Events"
    Private Sub dlgSelectMonth_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub dlgSelectMonth_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindMonths()
    End Sub
#End Region
#Region "Click Events"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Clipboard.SetDataObject(Me.cmbMonth.SelectedValue.Trim())
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region
#Region "Data Bind"
    Private Sub BindMonths()
        Dim aMonth As New ArrayList
        Dim p1YR, p2Yr, cYr, f1Yr, f2Yr, p1M, p2M, cM, f1M, f2M As String
        For p1I As Integer = 0 To 11
            p1M = "0" & p1I + 1
            If p1M.Length = 3 Then
                p1M = p1M.Substring(1, 2)
            End If
            p1YR = Now.Year() - 2 & p1M
            aMonth.Add(p1YR)
        Next
        For p2I As Integer = 0 To 11
            p2M = "0" & p2I + 1
            If p2M.Length = 3 Then
                p2M = p2M.Substring(1, 2)
            End If
            p2Yr = Now.Year() - 1 & p2M
            aMonth.Add(p2Yr)
        Next
        For cI As Integer = 0 To 11
            cM = "0" & cI + 1
            If cM.Length = 3 Then
                cM = cM.Substring(1, 2)
            End If
            cYr = Now.Year() & cM
            aMonth.Add(cYr)
        Next
        For f1I As Integer = 0 To 11
            f1M = "0" & f1I + 1
            If f1M.Length = 3 Then
                f1M = f1M.Substring(1, 2)
            End If
            f1Yr = Now.Year() + 1 & f1M
            aMonth.Add(f1Yr)
        Next
        For f2I As Integer = 0 To 11
            f2M = "0" & f2I + 1
            If f2M.Length = 3 Then
                f2M = f2M.Substring(1, 2)
            End If
            f2Yr = Now.Year() + 2 & f2M
            aMonth.Add(f2Yr)
        Next
        Me.cmbMonth.DataSource = aMonth
    End Sub
#End Region
End Class
