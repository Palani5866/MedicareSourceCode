Public Class fAgentRequest
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Private Sub fAgentRequest_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fAgentRequest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.gbAgentRequest.Enabled = False
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        Dim sSearchBy As String
        Select Case Me.tscbSearchBy.SelectedIndex
            Case 0
                sSearchBy = "AGENTID"
            Case 1
                sSearchBy = "FULLNAME"
        End Select
        dt = _ObjBusi.getDetails_VI("AGENTREQUEST", sSearchBy, Me.tstxtSearchBy.Text.ToString.Trim(), "", "", "", "", "", "", "", "S", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
        If dt.Rows.Count > 0 Then
            With Me.dgvAgentDetails
                .DataSource = dt
                .Columns(0).Visible = False
            End With
        Else
            MsgBox("No record found")
        End If
    End Sub
#Region "Progress Bar"
    'SharedData.ReadyToHideMarquee = False
    'StartMarqueeThread()
    'EVENTS PLACE
    'SyncLock SharedData
    'SharedData.ReadyToHideMarquee = True
    'End SyncLock
    'Application.DoEvents()
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
    Private Sub dgvAgentDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAgentDetails.CellDoubleClick
        With Me.dgvAgentDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Dim dt As New DataTable
            Me.lblAID.Text = Me.dgvAgentDetails.SelectedRows(0).Cells(1).Value.ToString.Trim
            Me.lblACODE.Text = Me.dgvAgentDetails.SelectedRows(0).Cells(0).Value.ToString.Trim
            Me.gbAgentRequest.Enabled = True
        End With
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.lblAID.Text = ""
        Me.lblACODE.Text = ""
        Me.Close()
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim sRes As String
        If fVERIFY() Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim dt As New DataTable
            dt = _ObjBusi.getDetails_VII("AGENTREQUEST", Me.lblAID.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "CHECK", Conn)
            If Not dt.Rows.Count > 0 Then
                Dim GEFORM, CCFORM, CPAFORM, BIRO, NOMINATION, FLYERSCC, FLYERSCPA, BOOKLETCC, BOOKLETCPA, POSTERCC, POSTERCPA, NAMECARD, BUNTINGCC, BUNTINGCPA As Integer
                If Me.txtGEForms.Text.Trim() = "" Then
                    GEFORM = 0
                Else
                    GEFORM = Me.txtGEForms.Text.Trim()
                End If
                If Me.txtCCForms.Text.Trim() = "" Then
                    CCFORM = 0
                Else
                    CCFORM = Me.txtCCForms.Text.Trim()
                End If
                If Me.txtCPAForms.Text.Trim() = "" Then
                    CPAFORM = 0
                Else
                    CPAFORM = Me.txtCPAForms.Text.Trim()
                End If

                If Me.txtBiro.Text.Trim() = "" Then
                    BIRO = 0
                Else
                    BIRO = Me.txtBiro.Text.Trim()
                End If
                If Me.txtNomination.Text.Trim() = "" Then
                    NOMINATION = 0
                Else
                    NOMINATION = Me.txtNomination.Text.Trim()
                End If
                If Me.txtFlyersCC.Text.Trim() = "" Then
                    FLYERSCC = 0
                Else
                    FLYERSCC = Me.txtFlyersCC.Text.Trim()
                End If

                If Me.txtFlyersCPA.Text.Trim() = "" Then
                    FLYERSCPA = 0
                Else
                    FLYERSCPA = Me.txtFlyersCPA.Text.Trim()
                End If
                If Me.txtBookLetCC.Text.Trim() = "" Then
                    BOOKLETCC = 0
                Else
                    BOOKLETCC = Me.txtBookLetCC.Text.Trim()
                End If
                If Me.txtBookLetCPA.Text.Trim() = "" Then
                    BOOKLETCPA = 0
                Else
                    BOOKLETCPA = Me.txtBookLetCPA.Text.Trim()
                End If
                If Me.txtPosterCC.Text.Trim() = "" Then
                    POSTERCC = 0
                Else
                    POSTERCC = Me.txtPosterCC.Text.Trim()
                End If
                If Me.txtPosterCPA.Text.Trim() = "" Then
                    POSTERCPA = 0
                Else
                    POSTERCPA = Me.txtPosterCPA.Text.Trim()
                End If
                If Me.txtNameCard.Text.Trim() = "" Then
                    NAMECARD = 0
                Else
                    NAMECARD = Me.txtNameCard.Text.Trim()
                End If
                If Me.txtBuntingCC.Text.Trim() = "" Then
                    BUNTINGCC = 0
                Else
                    BUNTINGCC = Me.txtBuntingCC.Text.Trim()
                End If
                If Me.txtBuntingCPA.Text.Trim() = "" Then
                    BUNTINGCPA = 0
                Else
                    BUNTINGCPA = Me.txtBuntingCPA.Text.Trim()
                End If
                sRes = _ObjBusi.IUAGENTREQUEST("INSERT", Guid.NewGuid.ToString(), Me.lblAID.Text.ToString.Trim(), GEFORM, "0", CCFORM, CPAFORM, BIRO, NOMINATION, FLYERSCC, FLYERSCPA, BOOKLETCC, BOOKLETCPA, POSTERCC, POSTERCPA, NAMECARD, BUNTINGCC, BUNTINGCPA, Format(Me.dtpRequestDate.Value, "MM/dd/yyyy"), My.Settings.Username.ToUpper.Trim(), "", "", "", "", "", "", Me.txtRemarks.Text.ToString.Trim(), My.Settings.Username.ToUpper.Trim(), Conn)
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                If sRes = "1" Then
                    MsgBox("Successfully Requested!")
                    fClear()
                    Me.Close()
                End If
            Else
                MsgBox("There is a Open request for this Agent! Please check it!")
                SyncLock SharedData
                    SharedData.ReadyToHideMarquee = True
                End SyncLock
                Application.DoEvents()
                Exit Sub
            End If
        End If
    End Sub
    Private Function fVERIFY() As Boolean
        If Me.txtBiro.Text.ToString.Trim() = "" Then
            If Me.txtBookLetCC.Text.ToString.Trim() = "" Then
                If Me.txtBookLetCPA.Text.ToString.Trim() = "" Then
                    If Me.txtBuntingCC.Text.ToString.Trim() = "" Then
                        If Me.txtBuntingCPA.Text.ToString.Trim() = "" Then
                            If Me.txtCCForms.Text.ToString.Trim() = "" Then
                                If Me.txtCPAForms.Text.ToString.Trim() = "" Then
                                    If Me.txtFlyersCC.Text.ToString.Trim() = "" Then
                                        If Me.txtFlyersCPA.Text.ToString.Trim() = "" Then
                                            If Me.txtGEForms.Text.ToString.Trim() = "" Then
                                                If Me.txtNameCard.Text.ToString.Trim() = "" Then
                                                    If Me.txtNomination.Text.ToString.Trim() = "" Then
                                                        If Me.txtPosterCC.Text.ToString.Trim() = "" Then
                                                            If Me.txtPosterCPA.Text.ToString.Trim() = "" Then
                                                                MsgBox("Please do key in request for!")
                                                                Me.txtCCForms.Focus()
                                                                Return False
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return True
    End Function
    Private Sub fClear()
        Me.txtBiro.Text = ""
        Me.txtBookLetCC.Text = ""
        Me.txtBookLetCPA.Text = ""
        Me.txtBuntingCC.Text = ""
        Me.txtBuntingCPA.Text = ""
        Me.txtCCForms.Text = ""
        Me.txtCPAForms.Text = ""
        Me.txtFlyersCC.Text = ""
        Me.txtFlyersCPA.Text = ""
        Me.txtGEForms.Text = ""
        Me.txtNameCard.Text = ""
        Me.txtNomination.Text = ""
        Me.txtPosterCC.Text = ""
        Me.txtPosterCPA.Text = ""
        Me.txtRemarks.Text = ""
    End Sub
End Class