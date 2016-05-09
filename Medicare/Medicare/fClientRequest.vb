Public Class fClientRequest
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Dim sRTYPE As String
    Private Sub fClientRequest_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fClientRequest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.gbClientRequest.Enabled = False
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim sSearchBy As String
        Select Case Me.tscbSearchBy.SelectedIndex
            Case 0
                sSearchBy = "IC"
            Case 1
                sSearchBy = "FULLNAME"
        End Select
        dt = _ObjBusi.getDetails_VI("CLIENTREQUEST", sSearchBy, Me.tstxtSearchBy.Text.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvClientRequest
                .DataSource = dt
                .Columns(0).Visible = False
                .Columns(1).Visible = False
            End With
        Else
            MsgBox("No record found")
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
    Private Sub tsbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGo.Click
        If Me.tscbSearchBy.SelectedIndex = -1 Then
            MsgBox("Please select search by")
            Exit Sub
        End If
        If Me.tstxtSearchBy.Text.ToString.Trim() = "" Then
            MsgBox("Required IC/FULL NAME!")
            Exit Sub
        End If
        BINDDATA()
    End Sub
    Private Sub dgvClientRequest_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClientRequest.CellDoubleClick
        With Me.dgvClientRequest
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Dim dt As New DataTable
            Me.lblPHID.Text = Me.dgvClientRequest.SelectedRows(0).Cells(1).Value.ToString.Trim
            Me.lblPID.Text = Me.dgvClientRequest.SelectedRows(0).Cells(0).Value.ToString.Trim
            Me.lblPHIC.Text = Me.dgvClientRequest.SelectedRows(0).Cells(2).Value.ToString.Trim
            Me.lblPHNAME.Text = Me.dgvClientRequest.SelectedRows(0).Cells(3).Value.ToString.Trim
            Me.gbClientRequest.Enabled = True
            dt = _ObjBusi.getDetails_VI("DEPENDENTS", Me.dgvClientRequest.SelectedRows(0).Cells(0).Value.ToString.Trim, "", "", "", "", "", "", "", "", "", Conn)
            If dt.Rows.Count > 0 Then
                With Me.dgvDependents
                    .DataSource = dt
                    .Columns(1).Visible = False
                    .Columns(2).Visible = False
                End With
            End If
        End With
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.cbCard.Checked Then
            If Me.cbPolicy.Checked Then
                sRTYPE = "BOTH"
            Else
                sRTYPE = "CARD"
            End If
        Else
            sRTYPE = "POLICY"
        End If
        If fVerify() Then
            Dim sRes As String
            Try
                If Me.cbPolicyHolder.Checked Then
                    sRes = _ObjBusi.IUCLIENTREQUEST("INSERT", Guid.NewGuid.ToString(), Me.lblPHID.Text.ToString.Trim(), Me.lblPID.Text.ToString.Trim(), Me.lblPHIC.Text.ToString.Trim(), Me.lblPHNAME.Text.ToString.Trim(), "M", Format(Me.dtpRequestDate.Value, "MM/dd/yyyy"), sRTYPE, "", Format(Me.dtpRequestDate.Value, "MM/dd/yyyy"), Me.txtRemarks.Text.Trim(), My.Settings.Username.ToUpper.ToString.Trim(), Conn)
                End If
                Dim dgvRowCount As Integer
                With Me.dgvDependents
                    Do While dgvRowCount < .Rows.Count
                        If .Rows(dgvRowCount).Cells(0).Value Then
                            sRes = _ObjBusi.IUCLIENTREQUEST("INSERT", Guid.NewGuid.ToString(), .Rows(dgvRowCount).Cells(1).Value.ToString, Me.lblPID.Text.ToString.Trim(), .Rows(dgvRowCount).Cells(2).Value.ToString, .Rows(dgvRowCount).Cells(3).Value.ToString, "D", Format(Me.dtpRequestDate.Value, "MM/dd/yyyy"), sRTYPE, "", Format(Me.dtpRequestDate.Value, "MM/dd/yyyy"), Me.txtRemarks.Text.Trim(), My.Settings.Username.ToUpper.ToString.Trim(), Conn)
                        End If
                        dgvRowCount += 1
                    Loop
                End With
                If sRes = "1" Then
                    MsgBox("Successfully requested!")
                    Me.Close()
                End If
            Catch ex As Exception
                MsgBox("Errow on request/ currently our server busy Please try again later!")
            End Try
        End If
    End Sub
    Private Function fVerify() As Boolean
        If Not Me.cbCard.Checked Then
            If Not Me.cbPolicy.Checked Then
                MsgBox("Please select the request type!")
                Return False
            End If
        End If
        Dim dtM, dtD As New DataTable

        If Me.cbPolicyHolder.Checked Then
            dtM = _ObjBusi.getDetails_VI("CR", Me.lblPHID.Text.ToString.Trim(), Me.lblPID.Text.ToString.Trim(), sRTYPE, "", "", "", "", "", "", "M", Conn)
            If dtM.Rows.Count > 0 Then
                MsgBox("Please check there is an open request for Policy Holder : " & Me.lblPHNAME.Text.ToString.Trim())
                Return False
            End If
        End If
        If Not Me.cbPolicyHolder.Checked Then
            If Me.dgvDependents.Rows.Count > 0 Then
                Dim dgvRowCount As Integer
                With Me.dgvDependents
                    Do While dgvRowCount < .Rows.Count
                        If .Rows(dgvRowCount).Cells(0).Value Then
                            dtD = _ObjBusi.getDetails_VI("CR", .Rows(dgvRowCount).Cells(1).Value.ToString, Me.lblPID.Text.ToString.Trim(), sRTYPE, "", "", "", "", "", "", "D", Conn)
                            If dtD.Rows.Count > 0 Then
                                MsgBox("Please check there is an open request for this Dependent : " & .Rows(dgvRowCount).Cells(3).Value.ToString)
                                Return False
                            End If
                            Return True
                        End If
                        dgvRowCount += 1
                    Loop
                End With
                MsgBox("Please select the Request for!")
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        fClear()
        Me.Close()
    End Sub
    Private Sub fClear()
        Me.cbPolicyHolder.Checked = False
        Me.cbCard.Checked = False
        Me.cbPolicy.Checked = False
        Me.txtRemarks.Text = ""
    End Sub
End Class