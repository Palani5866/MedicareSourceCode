Public Class UWCIMB
    Dim Conn As DbConnection = New SqlConnection()
    Dim _objBusi As New Business
    Private Sub UWCIMB_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub UWCIMB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BindData()
    End Sub
    Private Sub BindData()
        Dim dt As New DataTable
        dt = _objBusi.getUWProposerDetails("", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvUW
                .DataSource = dt
                .Columns(0).Visible = True
                .Columns(1).Visible = False

                .Columns(2).HeaderText = "FULL NAME"
                .Columns(3).HeaderText = "IC NO"
                .Columns(4).HeaderText = "STATE"
                .Columns(5).HeaderText = "PLAN CODE"
                .Columns(6).HeaderText = "PLAN TYPE"
                .Columns(7).HeaderText = "STATUS"
                .Columns(8).HeaderText = "REMARKS"
                .Columns(9).HeaderText = "FILE NO"
            End With
        Else
            MsgBox("No Under writing records")
        End If
        Dim dtUWSL, dtU As New DataTable
        dtUWSL = _objBusi.getUWProposerDetails("UW", Conn)
        dtU = _objBusi.getUWProposerDetails("U", Conn)
        If dtU.Rows.Count > 0 Then
            With Me.dgvUWCIMBSL
                .DataSource = dtU
                .Columns(0).Visible = False

                .Columns(1).HeaderText = "FULL NAME"
                .Columns(2).HeaderText = "IC NO"
                .Columns(3).HeaderText = "STATE"
                .Columns(4).HeaderText = "PLAN CODE"
                .Columns(5).HeaderText = "PLAN TYPE"
                .Columns(6).HeaderText = "STATUS"
                .Columns(7).HeaderText = "REMARKS"
                .Columns(8).HeaderText = "FILE NO"
                .Columns(9).HeaderText = "SUN LIFE SUBMISSION BATCH NO"
                .Columns(10).HeaderText = "SUN LIFE SUBMISSION DATE"
            End With
        End If

        If dtUWSL.Rows.Count > 0 Then
            With Me.dgvUWRLCIMB
                .DataSource = dtUWSL
                .Columns(0).Visible = True
                .Columns(1).Visible = False

                .Columns(2).HeaderText = "FULL NAME"
                .Columns(3).HeaderText = "IC NO"
                .Columns(4).HeaderText = "STATE"
                .Columns(5).HeaderText = "PLAN CODE"
                .Columns(6).HeaderText = "PLAN TYPE"
                .Columns(7).HeaderText = "STATUS"
                .Columns(8).HeaderText = "REMARKS"
                .Columns(9).HeaderText = "FILE NO"
                .Columns(10).HeaderText = "SUN LIFE SUBMISSION BATCH NO"
                .Columns(11).HeaderText = "SUN LIFE SUBMISSION DATE"
            End With
        End If
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Xport2Xcel()
    End Sub
    Private Sub Xport2Xcel()
        If Me.dgvUW.RowCount > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xls_file As New Microsoft.Office.Interop.Excel.Application
            Dim xls_workbook As Microsoft.Office.Interop.Excel.Workbook
            xls_workbook = xls_file.Workbooks.Add
            Dim cxls_wks_name As String = ""
            Dim i As Integer = 0
            Dim rCount As Integer = 7
            Dim BatchNo As String
            BatchNo = Now.Day & "/" & Now.Month & "/" & "UW" & "/" & Now.Year()
            xls_workbook.Worksheets.Add()
            cxls_wks_name = "Sheet" & xls_workbook.Worksheets.Count.ToString.Trim
            With xls_workbook.Worksheets(cxls_wks_name)
                .Cells(1, 1) = "SUBMISSION OF UNDERWRITING PROPOSALS TO SUN LIFE MALAYSIA TAKAFUL BERHAD"
                .Cells(2, 1) = "CUEPACSCARE A/C CODE : "
                .Cells(3, 1) = "BATCH NO : " & BatchNo

                .Cells(6, 1) = "NO"
                .Cells(6, 2) = "FILE NO"
                .Cells(6, 3) = "FULL NAME"
                .Cells(6, 4) = "IC NO"
                .Cells(6, 5) = "PLAN TYPE"
                .Cells(6, 6) = "REMARKS FROM SUN LIFE"
                Do While i < Me.dgvUW.Rows.Count
                    If Me.dgvUW.Rows(i).Cells(0).Value = "T" Then
                        _objBusi.UpdateUWCIMBSTATUS(dgvUW.Rows(i).Cells(1).Value.ToString.Trim(), BatchNo, Conn)
                        .Cells(rCount, 1) = "'" & (rCount - 6).ToString.Trim
                        .Cells(rCount, 2) = "'" & dgvUW.Rows(i).Cells(9).Value
                        .Cells(rCount, 3) = "'" & dgvUW.Rows(i).Cells(2).Value
                        .Cells(rCount, 4) = "'" & dgvUW.Rows(i).Cells(3).Value
                        .Cells(rCount, 5) = "'" & dgvUW.Rows(i).Cells(6).Value
                        .Cells(rCount, 6) = "'" & dgvUW.Rows(i).Cells(8).Value
                        rCount += 1
                    End If
                    i += 1
                Loop
                .Cells(rCount + 2, 2) = "PREPARED BY"
                .Cells(rCount + 5, 2) = "------------------------"
                .Cells(rCount + 6, 2) = "Name : " & My.Settings.Username
                .Cells(rCount + 7, 2) = "Date : " & Format(Now(), "dd/MM/yyyy")
                .Cells(rCount + 2, 5) = "RECEIVED BY"
                .Cells(rCount + 5, 5) = "------------------------"
                .Cells(rCount + 6, 5) = "Name : "
                .Cells(rCount + 7, 5) = "Date : "
            End With
            MsgBox("Completed Exporting UNDER WRITING records TO SUN LIFE.")
            xls_file.Visible = True
        End If
    End Sub
    Private Sub rBINDDATA()
        Dim dtUWSL, dtU As New DataTable
        dtUWSL = _objBusi.getUWProposerDetails("UW", Conn)
        dtU = _objBusi.getUWProposerDetails("U", Conn)
        If dtUWSL.Rows.Count > 0 Then
            With Me.dgvUWCIMBSL
                .DataSource = dtU
                .Columns(0).Visible = False

                .Columns(1).HeaderText = "FULL NAME"
                .Columns(2).HeaderText = "IC NO"
                .Columns(3).HeaderText = "STATE"
                .Columns(4).HeaderText = "PLAN CODE"
                .Columns(5).HeaderText = "PLAN TYPE"
                .Columns(6).HeaderText = "STATUS"
                .Columns(7).HeaderText = "REMARKS"
                .Columns(8).HeaderText = "FILE NO"
                .Columns(9).HeaderText = "SUN LIFE SUBMISSION BATCH NO"
                .Columns(10).HeaderText = "SUN LIFE SUBMISSION DATE"
            End With
        End If

        If dtUWSL.Rows.Count > 0 Then
            With Me.dgvUWRLCIMB
                .DataSource = dtUWSL
                .Columns(0).Visible = True
                .Columns(1).Visible = False

                .Columns(2).HeaderText = "FULL NAME"
                .Columns(3).HeaderText = "IC NO"
                .Columns(4).HeaderText = "STATE"
                .Columns(5).HeaderText = "PLAN CODE"
                .Columns(6).HeaderText = "PLAN TYPE"
                .Columns(7).HeaderText = "STATUS"
                .Columns(8).HeaderText = "REMARKS"
                .Columns(9).HeaderText = "FILE NO"
                .Columns(10).HeaderText = "SUN LIFE SUBMISSION BATCH NO"
                .Columns(11).HeaderText = "SUN LIFE SUBMISSION DATE"
            End With
        End If
    End Sub
    Private Sub btnUWRLCIMB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUWRLCIMB.Click
        Dim i As Integer = 0
        Dim sRes As String
        Do While i < Me.dgvUWRLCIMB.Rows.Count
            If Me.dgvUWRLCIMB.Rows(i).Cells(0).Value = "T" Then
                sRes = _objBusi.spUpdate("UWRLCIMB", dgvUWRLCIMB.Rows(i).Cells(1).Value.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
            End If
            i += 1
        Loop
        If sRes = "1" Then
            MsgBox("Successfully changed status 1PU to 1U")
            rBINDDATA()
        End If
    End Sub
End Class