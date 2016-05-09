Public Class fRetirees
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business
    Private Sub fRetirees_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fRetirees_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        If Me.lblRTYPE.Text = "OSA" Then
            Me.lblPremiumAmount.Visible = False
            Me.lblPremiumAmount1.Visible = False
            Me.txtPremiumAmount.Visible = False
            Me.lblGST.Visible = False
            Me.lblGST1.Visible = False
            Me.txtGST.Visible = False
        Else
            Me.lblPremiumAmount.Visible = True
            Me.lblPremiumAmount1.Visible = True
            Me.txtPremiumAmount.Visible = True
            Me.lblGST.Visible = True
            Me.lblGST1.Visible = True
            Me.txtGST.Visible = True
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
        dt = _ObjBusi.getDetails_VI("CLIENTREQUEST", sSearchBy, Me.tstxtSearchBy.Text.ToString.Trim(), "", "", "", "", "", "", "", "S", Conn)
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
            Me.dgvClientRequest.DataSource = dt
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
        End With
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.lblPHID.Text = ""
        Me.lblPHIC.Text = ""
        Me.lblPID.Text = ""
        Me.lblPHNAME.Text = ""
        Me.txtPremiumAmount.Text = ""
        Me.txtRemarks.Text = ""
        Me.txtTotalPremium.Text = ""
        Me.txtGST.Text = ""
        Me.Close()
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Me.txtPremiumAmount.Text = "" Then
            If Me.txtOSP.Text = "" Then
                MsgBox("Please do key the Premium Amount!")
                Exit Sub
            Else
                If Me.txtPremiumAmount.Text = "" Then
                    Me.txtPremiumAmount.Text = "0.00"
                End If
            End If
        Else
            If Me.txtOSP.Text = "" Then
                Me.txtOSP.Text = "0.00"
            End If
        End If
        PrintLetters.lblOSPremium.Text = FormatNumber(Me.txtOSP.Text.ToString.Trim(), 2)
        PrintLetters.lblOSGST.Text = FormatNumber(Me.txtOSPGST.Text.ToString.Trim(), 2)
        PrintLetters.lblPremium.Text = FormatNumber(Me.txtPremiumAmount.Text.ToString.Trim(), 2)
        PrintLetters.lblGST.Text = FormatNumber(Me.txtGST.Text.ToString.Trim(), 2)
        PrintLetters.lblTotPremium.Text = FormatNumber(Me.txtTotalPremium.Text.ToString.Trim(), 2)
        _ObjBusi.spUpdate("RETIREES", Me.lblPID.Text.ToString.Trim(), My.Settings.Username.ToUpper.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
        If Me.lblRTYPE.Text = "OSA" Then
            PrintLetters.Print_Letters("pRetireesOA.rpt", Me.lblPID.Text.ToString.Trim(), "RETIREES")
        Else
            PrintLetters.Print_Letters("pRetirees.rpt", Me.lblPID.Text.ToString.Trim(), "RETIREES")
        End If

    End Sub
    Private Sub txtOSP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOSP.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 127) Then
            e.KeyChar = ""
            e.Handled = False
        End If
    End Sub
    Private Sub txtPremiumAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPremiumAmount.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 127) Then
            e.KeyChar = ""
            e.Handled = False
        End If
    End Sub
    Private Sub txtPremiumAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPremiumAmount.TextChanged
        If Not Me.txtPremiumAmount.Text = "" Then
            Dim OSPremium, OSGST, Premium, GST, TotPremium As Decimal
            Premium = Me.txtPremiumAmount.Text
            GST = Premium * 6 / 100

            If Not Me.txtOSP.Text = "" Then
                OSPremium = Me.txtOSP.Text
                OSGST = OSPremium * 6 / 100
            Else
                OSPremium = 0
                OSGST = 0
            End If
            TotPremium = Premium + GST + OSPremium + OSGST
            Me.txtOSPGST.Text = FormatNumber(OSGST, 2)
            Me.txtGST.Text = FormatNumber(GST, 2)
            Me.txtTotalPremium.Text = FormatNumber(TotPremium, 2)
        End If
    End Sub
    Private Sub txtOSP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOSP.TextChanged
        If Not Me.txtOSP.Text = "" Then
            Dim OSPremium, OSGST, Premium, GST, TotPremium As Decimal
            OSPremium = Me.txtOSP.Text
            OSGST = OSPremium * 6 / 100
            If Not Me.txtPremiumAmount.Text = "" Then
                Premium = Me.txtPremiumAmount.Text
                GST = Premium * 6 / 100
            Else
                Premium = 0
                GST = 0
            End If
            TotPremium = Premium + GST + OSPremium + OSGST
            Me.txtOSPGST.Text = FormatNumber(OSGST, 2)
            Me.txtGST.Text = FormatNumber(GST, 2)
            Me.txtTotalPremium.Text = FormatNumber(TotPremium, 2)
        End If
    End Sub
End Class