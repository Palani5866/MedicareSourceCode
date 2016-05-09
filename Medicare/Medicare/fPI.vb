Imports System.IO
Public Class fPI
#Region "Global Veriable"
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
    Dim PSTATUS As String
    Dim RAMOUNT As Double
#End Region
    Private Sub fPI_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fPI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        If Me.lblRTYPE.Text = "PD" Then
            Me.Text = "Premium Decrease"
        Else
            Me.Text = "Premium Increase"
        End If
        BindYRs()
        BINDDATA()
    End Sub
    Private Sub BindYRs()
        Dim aYrs As New ArrayList
        Dim p1YR As String
        p1YR = Now.Year()
        aYrs.Add(Now.Year())
        aYrs.Add(Now.Year() + 1)
        Me.tscbYR.ComboBox.DataSource = aYrs
    End Sub
    Private Sub BINDDATA()
        Dim ds As New DataSet
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        ds = _objBusi.getDsDetails_V(Me.lblRTYPE.Text.ToString.Trim(), Me.lblRTYPE1.Text.ToString.Trim(), Me.tscbYR.Text.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()

        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvJanPIPR
                .DataSource = ds.Tables(0)

                Me.lblTOTJAN.Text = "Total Records : " & ds.Tables(0).Rows.Count
                .Columns(4).Visible = False

                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End With
        Else
            Me.dgvJanPIPR.DataSource = ds.Tables(0)
            Me.lblTOTJAN.Text = "Total Records : 0 "
        End If


        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvFebPIPR
                .DataSource = ds.Tables(1)
                Me.lblTOTFEB.Text = "Total Records : " & ds.Tables(1).Rows.Count

                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                
            End With
        Else
            Me.dgvFebPIPR.DataSource = ds.Tables(1)
            Me.lblTOTFEB.Text = "Total Records : 0 "
        End If


        If ds.Tables(2).Rows.Count > 0 Then
            With Me.dgvMarPIPR
                .DataSource = ds.Tables(2)
                Me.lblTOTMARCH.Text = "Total Records : " & ds.Tables(2).Rows.Count

                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                
            End With
        Else
            Me.dgvMarPIPR.DataSource = ds.Tables(2)
            Me.lblTOTMARCH.Text = "Total Records : 0 "
        End If


        If ds.Tables(3).Rows.Count > 0 Then
            With Me.dgvAprilPIPR
                .DataSource = ds.Tables(3)
                Me.lblTOTAPRIL.Text = "Total Records : " & ds.Tables(3).Rows.Count

                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvAprilPIPR.DataSource = ds.Tables(3)
            Me.lblTOTAPRIL.Text = "Total Records : 0 "
        End If


        If ds.Tables(4).Rows.Count > 0 Then
            With Me.dgvMayPIPR
                .DataSource = ds.Tables(4)
                Me.lblTOTMAY.Text = "Total Records : " & ds.Tables(4).Rows.Count

                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvMayPIPR.DataSource = ds.Tables(4)
            Me.lblTOTMAY.Text = "Total Records : 0 "
        End If


        If ds.Tables(5).Rows.Count > 0 Then
            With Me.dgvJunePIPR
                .DataSource = ds.Tables(5)
                Me.lblTOTJUNE.Text = "Total Records : " & ds.Tables(5).Rows.Count

                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvJunePIPR.DataSource = ds.Tables(5)
            Me.lblTOTJUNE.Text = "Total Records : 0 "
        End If


        If ds.Tables(6).Rows.Count > 0 Then
            With Me.dgvJulyPIPR
                .DataSource = ds.Tables(6)
                Me.lblTOTJULY.Text = "Total Records : " & ds.Tables(6).Rows.Count

                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvJulyPIPR.DataSource = ds.Tables(6)
            Me.lblTOTJULY.Text = "Total Records : 0 "
        End If


        If ds.Tables(7).Rows.Count > 0 Then
            With Me.dgvAugustPIPR
                .DataSource = ds.Tables(7)
                Me.lblTOTAUGUST.Text = "Total Records : " & ds.Tables(7).Rows.Count

                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvAugustPIPR.DataSource = ds.Tables(7)
            Me.lblTOTAUGUST.Text = "Total Records : 0 "
        End If


        If ds.Tables(8).Rows.Count > 0 Then
            With Me.dgvSepPIPR
                .DataSource = ds.Tables(8)
                Me.lblTOTSEP.Text = "Total Records : " & ds.Tables(8).Rows.Count

                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvSepPIPR.DataSource = ds.Tables(8)
            Me.lblTOTSEP.Text = "Total Records : 0 "
        End If


        If ds.Tables(9).Rows.Count > 0 Then
            With Me.dgvOctPIPR
                .DataSource = ds.Tables(9)
                Me.lblTOTOCT.Text = "Total Records : " & ds.Tables(9).Rows.Count

                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvOctPIPR.DataSource = ds.Tables(9)
            Me.lblTOTOCT.Text = "Total Records : 0 "
        End If


        If ds.Tables(10).Rows.Count > 0 Then
            With Me.dgvNovPIPR
                .DataSource = ds.Tables(10)
                Me.lblTOTNOV.Text = "Total Records : " & ds.Tables(10).Rows.Count

                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvNovPIPR.DataSource = ds.Tables(10)
            Me.lblTOTNOV.Text = "Total Records : 0 "
        End If


        If ds.Tables(11).Rows.Count > 0 Then
            With Me.dgvDecPIPR
                .DataSource = ds.Tables(11)
                Me.lblTOTDEC.Text = "Total Records : " & ds.Tables(11).Rows.Count

                .Columns(4).Visible = False
                .Columns(0).DisplayIndex = 14
                .Columns(1).DisplayIndex = 14
                .Columns(2).DisplayIndex = 14
                .Columns(3).DisplayIndex = 14

                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"

                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvDecPIPR.DataSource = ds.Tables(11)
            Me.lblTOTDEC.Text = "Total Records : 0 "
        End If


        Dim dsR As New DataSet
        dsR = _objBusi.getDsDetails_V(Me.lblRTYPE.Text.ToString.Trim() & "R", Me.lblRTYPE1.Text.ToString.Trim(), Me.tscbYR.Text.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)


        If dsR.Tables(0).Rows.Count > 0 Then
            With Me.dgvJanPIR
                .DataSource = dsR.Tables(0)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvJanPIR.DataSource = dsR.Tables(0)
        End If


        If dsR.Tables(1).Rows.Count > 0 Then
            With Me.dgvFebPIR
                .DataSource = dsR.Tables(1)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvFebPIR.DataSource = dsR.Tables(1)
        End If


        If dsR.Tables(2).Rows.Count > 0 Then
            With Me.dgvMarPIR
                .DataSource = dsR.Tables(2)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvMarPIR.DataSource = dsR.Tables(2)
        End If


        If dsR.Tables(3).Rows.Count > 0 Then
            With Me.dgvAprilPIR
                .DataSource = dsR.Tables(3)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvAprilPIR.DataSource = dsR.Tables(3)
        End If


        If dsR.Tables(4).Rows.Count > 0 Then
            With Me.dgvMayPIR
                .DataSource = dsR.Tables(4)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvMayPIR.DataSource = dsR.Tables(4)
        End If


        If dsR.Tables(5).Rows.Count > 0 Then
            With Me.dgvJunePIR
                .DataSource = dsR.Tables(5)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvJunePIR.DataSource = dsR.Tables(5)
        End If


        If dsR.Tables(6).Rows.Count > 0 Then
            With Me.dgvJulyPIR
                .DataSource = dsR.Tables(6)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvJulyPIR.DataSource = dsR.Tables(6)
        End If


        If dsR.Tables(7).Rows.Count > 0 Then
            With Me.dgvAugustPIR
                .DataSource = dsR.Tables(7)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvAugustPIR.DataSource = dsR.Tables(7)
        End If


        If dsR.Tables(8).Rows.Count > 0 Then
            With Me.dgvSepPIR
                .DataSource = dsR.Tables(8)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvSepPIR.DataSource = dsR.Tables(8)
        End If


        If dsR.Tables(9).Rows.Count > 0 Then
            With Me.dgvOctPIR
                .DataSource = dsR.Tables(9)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvOctPIR.DataSource = dsR.Tables(9)
        End If


        If dsR.Tables(10).Rows.Count > 0 Then
            With Me.dgvNovPIR
                .DataSource = dsR.Tables(10)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvNovPIR.DataSource = dsR.Tables(10)
        End If


        If dsR.Tables(11).Rows.Count > 0 Then
            With Me.dgvDecPIR
                .DataSource = dsR.Tables(11)
                .Columns(5).Visible = False
                .Columns(0).DisplayIndex = 17
                .Columns(1).DisplayIndex = 17
                .Columns(2).DisplayIndex = 17
                .Columns(3).DisplayIndex = 17
                .Columns(4).DisplayIndex = 17

                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"
                .Columns(15).DefaultCellStyle.Format = "#,#00.00"
                .Columns(16).DefaultCellStyle.Format = "#,#00.00"

                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvDecPIR.DataSource = dsR.Tables(11)
        End If

        
        If dsR.Tables(12).Rows.Count > 0 Then
            With Me.dgvfPRJan
                .DataSource = dsR.Tables(12)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvfPRJan.DataSource = dsR.Tables(12)
        End If


        If dsR.Tables(13).Rows.Count > 0 Then
            With Me.dgvfPRFeb
                .DataSource = dsR.Tables(13)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvfPRFeb.DataSource = dsR.Tables(13)
        End If


        If dsR.Tables(14).Rows.Count > 0 Then
            With Me.dgvfPRMar
                .DataSource = dsR.Tables(14)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvfPRMar.DataSource = dsR.Tables(14)
        End If


        If dsR.Tables(15).Rows.Count > 0 Then
            With Me.dgvfPRApr
                .DataSource = dsR.Tables(15)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvfPRApr.DataSource = dsR.Tables(15)
        End If


        If dsR.Tables(16).Rows.Count > 0 Then
            With Me.dgvfPRMay
                .DataSource = dsR.Tables(16)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvfPRMay.DataSource = dsR.Tables(16)
        End If


        If dsR.Tables(17).Rows.Count > 0 Then
            With Me.dgvfPRJun
                .DataSource = dsR.Tables(17)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvfPRJun.DataSource = dsR.Tables(17)
        End If


        If dsR.Tables(18).Rows.Count > 0 Then
            With Me.dgvfPRJul
                .DataSource = dsR.Tables(18)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvfPRJul.DataSource = dsR.Tables(18)
        End If


        If dsR.Tables(19).Rows.Count > 0 Then
            With Me.dgvfPRAug
                .DataSource = dsR.Tables(19)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvfPRAug.DataSource = dsR.Tables(19)
        End If


        If dsR.Tables(20).Rows.Count > 0 Then
            With Me.dgvfPRSep
                .DataSource = dsR.Tables(20)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvSepPIR.DataSource = dsR.Tables(20)
        End If


        If dsR.Tables(21).Rows.Count > 0 Then
            With Me.dgvfPROct
                .DataSource = dsR.Tables(21)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvfPROct.DataSource = dsR.Tables(21)
        End If


        If dsR.Tables(22).Rows.Count > 0 Then
            With Me.dgvfPRNov
                .DataSource = dsR.Tables(22)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvfPRNov.DataSource = dsR.Tables(22)
        End If


        If dsR.Tables(23).Rows.Count > 0 Then
            With Me.dgvfPRDec
                .DataSource = dsR.Tables(23)
                .Columns(3).Visible = False
                .Columns(0).DisplayIndex = 15
                .Columns(1).DisplayIndex = 15
                .Columns(2).DisplayIndex = 15

                .Columns(10).DefaultCellStyle.Format = "#,#00.00"
                .Columns(11).DefaultCellStyle.Format = "#,#00.00"
                .Columns(12).DefaultCellStyle.Format = "#,#00.00"
                .Columns(13).DefaultCellStyle.Format = "#,#00.00"
                .Columns(14).DefaultCellStyle.Format = "#,#00.00"

                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Else
            Me.dgvfPRDec.DataSource = dsR.Tables(23)
        End If
    End Sub
    Private Sub dgvJanPIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJanPIPR.CellContentClick
        With Me.dgvJanPIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")

                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)

                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvFebPIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFebPIPR.CellContentClick
        With Me.dgvFebPIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvMarPIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMarPIPR.CellContentClick
        With Me.dgvMarPIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If

                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvAprilPIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAprilPIPR.CellContentClick
        With Me.dgvAprilPIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvMayPIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMayPIPR.CellContentClick
        With Me.dgvMayPIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String

                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvJunePIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJunePIPR.CellContentClick
        With Me.dgvJunePIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If

                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvJulyPIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJulyPIPR.CellContentClick
        With Me.dgvJulyPIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvAugustPIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAugustPIPR.CellContentClick
        With Me.dgvAugustPIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvSepPIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSepPIPR.CellContentClick
        With Me.dgvSepPIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvOctPIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOctPIPR.CellContentClick
        With Me.dgvOctPIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")

                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If

                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvNovPIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNovPIPR.CellContentClick
        With Me.dgvNovPIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")

                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvDecPIPR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDecPIPR.CellContentClick
        With Me.dgvDecPIPR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If upLoadFile(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(4).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")

                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(4).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                If IsNothing(.Rows(e.RowIndex).Cells(3).Value) Then
                    MsgBox("Please key in requested Premium!")
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(13).Value = .Rows(e.RowIndex).Cells(3).Value Then
                    PSTATUS = "FULL REQUESTED"
                Else
                    PSTATUS = "PARTIAL REQUESTED"
                End If
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(4).Value.ToString(), My.Settings.Username().ToUpper.ToString(), PSTATUS, .Rows(e.RowIndex).Cells(3).Value, "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Requested the Increase Premium")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvJanPIR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJanPIR.CellContentClick
        With Me.dgvJanPIR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(11).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If MsgBox("Are you requesting full premium? ", vbYesNo, "Document") = vbYes Then
                            PSTATUS = "FULL REQUESTED"
                        Else
                            PSTATUS = "PARTIAL REQUESTED"
                        End If
                        If upLoadFileFull(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(5).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")

                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "FULL REQUESTED", "", .Rows(e.RowIndex).Cells(16).Value, "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("You have requested increase Premium full successfully ")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvFebPIR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFebPIR.CellContentClick
        With Me.dgvFebPIR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(11).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If MsgBox("Are you requesting full premium? ", vbYesNo, "Document") = vbYes Then
                            PSTATUS = "FULL REQUESTED"
                        Else
                            PSTATUS = "PARTIAL REQUESTED"
                        End If
                        If upLoadFileFull(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(5).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")

                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "FULL REQUESTED", "", .Rows(e.RowIndex).Cells(16).Value, "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("You have requested increase Premium full successfully ")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvMarPIR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMarPIR.CellContentClick
        With Me.dgvMarPIR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(11).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If MsgBox("Are you requesting full premium? ", vbYesNo, "Document") = vbYes Then
                            PSTATUS = "FULL REQUESTED"
                        Else
                            PSTATUS = "PARTIAL REQUESTED"
                        End If
                        If upLoadFileFull(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(5).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "FULL REQUESTED", "", .Rows(e.RowIndex).Cells(16).Value, "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("You have requested increase Premium full successfully ")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvAprilPIR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAprilPIR.CellContentClick
        With Me.dgvAprilPIR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(11).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If MsgBox("Are you requesting full premium? ", vbYesNo, "Document") = vbYes Then
                            PSTATUS = "FULL REQUESTED"
                        Else
                            PSTATUS = "PARTIAL REQUESTED"
                        End If
                        If upLoadFileFull(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(5).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "FULL REQUESTED", "", .Rows(e.RowIndex).Cells(16).Value, "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("You have requested increase Premium full successfully ")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvMayPIR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMayPIR.CellContentClick
        With Me.dgvMayPIR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(11).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If MsgBox("Are you requesting full premium? ", vbYesNo, "Document") = vbYes Then
                            PSTATUS = "FULL REQUESTED"
                        Else
                            PSTATUS = "PARTIAL REQUESTED"
                        End If
                        If upLoadFileFull(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(5).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "FULL REQUESTED", "", .Rows(e.RowIndex).Cells(16).Value, "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("You have requested increase Premium full successfully ")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvJunePIR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJunePIR.CellContentClick
        With Me.dgvJunePIR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(11).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If MsgBox("Are you requesting full premium? ", vbYesNo, "Document") = vbYes Then
                            PSTATUS = "FULL REQUESTED"
                        Else
                            PSTATUS = "PARTIAL REQUESTED"
                        End If
                        If upLoadFileFull(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(5).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "FULL REQUESTED", "", .Rows(e.RowIndex).Cells(16).Value, "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("You have requested increase Premium full successfully ")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvJulyPIR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJulyPIR.CellContentClick
        With Me.dgvJulyPIR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(11).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If MsgBox("Are you requesting full premium? ", vbYesNo, "Document") = vbYes Then
                            PSTATUS = "FULL REQUESTED"
                        Else
                            PSTATUS = "PARTIAL REQUESTED"
                        End If
                        If upLoadFileFull(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(5).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "FULL REQUESTED", "", .Rows(e.RowIndex).Cells(16).Value, "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("You have requested increase Premium full successfully ")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvAugustPIR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAugustPIR.CellContentClick
        With Me.dgvAugustPIR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(11).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If MsgBox("Are you requesting full premium? ", vbYesNo, "Document") = vbYes Then
                            PSTATUS = "FULL REQUESTED"
                        Else
                            PSTATUS = "PARTIAL REQUESTED"
                        End If
                        If upLoadFileFull(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(5).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "FULL REQUESTED", "", .Rows(e.RowIndex).Cells(16).Value, "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("You have requested increase Premium full successfully ")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvSepPIR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSepPIR.CellContentClick
        With Me.dgvSepPIR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(11).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If MsgBox("Are you requesting full premium? ", vbYesNo, "Document") = vbYes Then
                            PSTATUS = "FULL REQUESTED"
                        Else
                            PSTATUS = "PARTIAL REQUESTED"
                        End If
                        If upLoadFileFull(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(5).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "FULL REQUESTED", "", .Rows(e.RowIndex).Cells(16).Value, "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("You have requested increase Premium full successfully ")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvNovPIR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNovPIR.CellContentClick
        With Me.dgvNovPIR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(11).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If MsgBox("Are you requesting full premium? ", vbYesNo, "Document") = vbYes Then
                            PSTATUS = "FULL REQUESTED"
                        Else
                            PSTATUS = "PARTIAL REQUESTED"
                        End If
                        If upLoadFileFull(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(5).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")

                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "FULL REQUESTED", "", .Rows(e.RowIndex).Cells(16).Value, "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("You have requested increase Premium full successfully ")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvDecPIR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDecPIR.CellContentClick
        With Me.dgvDecPIR
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "C", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(11).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Using OpenFileDialog As OpenFileDialog = Me.GetOpenFileDialog()
                    If (OpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                        Dim fdateTime As String
                        Dim fDt As DateTime
                        fdateTime = IO.File.GetLastWriteTime(OpenFileDialog.FileName)
                        fDt = Convert.ToDateTime(fdateTime)
                        Dim sFileToUpload As String = ""
                        sFileToUpload = LTrim(RTrim(OpenFileDialog.FileName))
                        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
                        If MsgBox("Are you requesting full premium? ", vbYesNo, "Document") = vbYes Then
                            PSTATUS = "FULL REQUESTED"
                        Else
                            PSTATUS = "PARTIAL REQUESTED"
                        End If
                        If upLoadFileFull(sFileToUpload, Extension, .Rows(e.RowIndex).Cells(5).Value.ToString()) Then
                            MsgBox("Successfully uploading file!")
                        End If
                    Else
                        MsgBox("File Requied")
                        Exit Sub
                    End If
                End Using
            ElseIf e.ColumnIndex = 3 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(5).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(5).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "FULL REQUESTED", "", .Rows(e.RowIndex).Cells(16).Value, "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("You have requested increase Premium full successfully ")
                Else
                    MsgBox("Error while requesting Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Function upLoadFile(ByVal sFilePath As String, ByVal sFileType As String, ByVal REFID As String) As Boolean
        Dim SqlCom As SqlCommand
        Dim FileData As Byte()
        Dim sFileName As String
        Dim qry As String
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            FileData = ReadFile(sFilePath)
            sFileName = System.IO.Path.GetFileName(sFilePath)
            If chkUpFName(sFileName, REFID) = False Then
                MsgBox("This Document already exists!Please check it")
                Return False
            End If
            qry = "UPDATE dt_premium_increase_request SET DOC_NAME=@DOC_NAME,DOC_DATA=@DOC_DATA, DOC_TYPE=@DOC_TYPE,DOC_EXT=@DOC_EXT, UPLOADED_BY=@BY, UPLOADED_ON=GETDATE()WHERE ID=@ID"

            SqlCom = New SqlCommand(qry, Conn)
            Dim ext As String = sFileType
            Dim contenttype As String = String.Empty
            Select Case ext
                Case ".doc"
                    contenttype = "application/vnd.ms-word"
                    Exit Select
                Case ".docx"
                    contenttype = "application/vnd.ms-word"
                    Exit Select
                Case ".xls"
                    contenttype = "application/vnd.ms-excel"
                    Exit Select
                Case ".xlsx"
                    contenttype = "application/vnd.ms-excel"
                    Exit Select
                Case ".jpg"
                    contenttype = "image/jpg"
                    Exit Select
                Case ".png"
                    contenttype = "image/png"
                    Exit Select
                Case ".gif"
                    contenttype = "image/gif"
                    Exit Select
                Case ".pdf"
                    contenttype = "application/pdf"
                    Exit Select
            End Select
            SqlCom.Parameters.Add(New SqlParameter("@DOC_NAME", sFileName))
            SqlCom.Parameters.Add(New SqlParameter("@DOC_DATA", DirectCast(FileData, Object)))
            SqlCom.Parameters.Add(New SqlParameter("@DOC_TYPE", contenttype))
            SqlCom.Parameters.Add(New SqlParameter("@DOC_EXT", sFileType))
            SqlCom.Parameters.Add(New SqlParameter("@ID", REFID))
            SqlCom.Parameters.Add(New SqlParameter("@BY", My.Settings.Username))
            SqlCom.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function upLoadFileFull(ByVal sFilePath As String, ByVal sFileType As String, ByVal REFID As String) As Boolean
        Dim SqlCom As SqlCommand
        Dim FileData As Byte()
        Dim sFileName As String
        Dim qry As String
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            FileData = ReadFile(sFilePath)
            sFileName = System.IO.Path.GetFileName(sFilePath)
            If chkUpFName(sFileName, REFID) = False Then
                MsgBox("This Document already exists!Please check it")
                Return False
            End If
            qry = "UPDATE dt_premium_increase_request SET DOC_NAME1=@DOC_NAME,DOC_DATA1=@DOC_DATA, DOC_TYPE1=@DOC_TYPE,DOC_EXT1=@DOC_EXT, UPLOADED_BY1=@BY, UPLOADED_ON1=GETDATE(), PREMIUM_REQUEST_STATUS=@PSTATUS WHERE ID=@ID"

            SqlCom = New SqlCommand(qry, Conn)
            Dim ext As String = sFileType
            Dim contenttype As String = String.Empty
            Select Case ext
                Case ".doc"
                    contenttype = "application/vnd.ms-word"
                    Exit Select
                Case ".docx"
                    contenttype = "application/vnd.ms-word"
                    Exit Select
                Case ".xls"
                    contenttype = "application/vnd.ms-excel"
                    Exit Select
                Case ".xlsx"
                    contenttype = "application/vnd.ms-excel"
                    Exit Select
                Case ".jpg"
                    contenttype = "image/jpg"
                    Exit Select
                Case ".png"
                    contenttype = "image/png"
                    Exit Select
                Case ".gif"
                    contenttype = "image/gif"
                    Exit Select
                Case ".pdf"
                    contenttype = "application/pdf"
                    Exit Select
            End Select
            SqlCom.Parameters.Add(New SqlParameter("@DOC_NAME", sFileName))
            SqlCom.Parameters.Add(New SqlParameter("@DOC_DATA", DirectCast(FileData, Object)))
            SqlCom.Parameters.Add(New SqlParameter("@DOC_TYPE", contenttype))
            SqlCom.Parameters.Add(New SqlParameter("@DOC_EXT", sFileType))
            SqlCom.Parameters.Add(New SqlParameter("@ID", REFID))
            SqlCom.Parameters.Add(New SqlParameter("@PSTATUS", PSTATUS))
            SqlCom.Parameters.Add(New SqlParameter("@BY", My.Settings.Username))
            SqlCom.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function ReadFile(ByVal sPath As String) As Byte()
        Dim data As Byte() = Nothing
        Dim fInfo As New FileInfo(sPath)
        Dim numBytes As Long = fInfo.Length
        Dim fStream As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fStream)
        data = br.ReadBytes(CInt(numBytes))
        Return data
    End Function
    Private Function GetOpenFileDialog() As OpenFileDialog
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.CheckPathExists = True
        openFileDialog.CheckFileExists = True
        openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|xls files (*.xls)|*.xls|jpg files (*.jpg)|*.jpg|doc files (*.doc)|*.doc|text files (*.text)|*.txt"
        openFileDialog.Multiselect = False
        openFileDialog.AddExtension = True
        openFileDialog.ValidateNames = True
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Return openFileDialog
    End Function
    Private Function chkUpFName(ByVal fname As String, ByVal refID As String) As Boolean
        Dim dt As New DataTable
        dt = _objBusi.Check("CHKPIDOC", fname, refID, "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Private Sub downLoadFile(ByVal iFileId As String, ByVal sFileName As String, ByVal sFileExtension As String)
        Try
            Dim dt As New DataTable
            dt = _objBusi.getDetails_V("PIDOC", iFileId, "", "", "", "", "", "", "", "", "", Conn)
            Dim strSql As String
            strSql = "Select DOC_DATA from dt_premium_increase_request WHERE Id='" & iFileId & "'"
            Dim sqlCmd As New SqlCommand(strSql, Conn)
            Dim dbbyte As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())
            Dim filepath As String = Application.StartupPath & "\Report\Letters\" & dt.Rows(0)("DOC_NAME").ToString()
            Dim FS As FileStream
            FS = New FileStream(filepath, System.IO.FileMode.Create)
            FS.Write(dbbyte, 0, dbbyte.Length)
            FS.Close()
            Dim Proc As Process
            Proc = New Process()
            Proc.StartInfo.FileName = filepath
            Proc.Start()
        Catch ex As Exception
            MsgBox("No record found!")
        End Try
    End Sub
    Private Sub downLoadFile4full(ByVal iFileId As String, ByVal sFileName As String, ByVal sFileExtension As String)
        Try
            Dim dt As New DataTable
            dt = _objBusi.getDetails_V("PIDOC", iFileId, "", "", "", "", "", "", "", "", "", Conn)
            Dim strSql As String
            strSql = "Select DOC_DATA1 from dt_premium_increase_request WHERE Id='" & iFileId & "'"
            Dim sqlCmd As New SqlCommand(strSql, Conn)
            Dim dbbyte As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())
            Dim filepath As String = Application.StartupPath & "\Report\Letters\" & dt.Rows(0)("DOC_NAME1").ToString()
            Dim FS As FileStream
            FS = New FileStream(filepath, System.IO.FileMode.Create)
            FS.Write(dbbyte, 0, dbbyte.Length)
            FS.Close()
            Dim Proc As Process
            Proc = New Process()
            Proc.StartInfo.FileName = filepath
            Proc.Start()
        Catch ex As Exception
            MsgBox("No record found!" & ex.StackTrace.ToString.Trim())
        End Try
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
    Private Sub lnklblJanXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblJanXport.LinkClicked
        If Me.dgvJanPIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF JANUARY"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvJanPIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvJanPIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvJanPIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvJanPIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvJanPIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvJanPIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvJanPIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvJanPIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvJanPIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvJanPIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvJanPIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub lnklblFEBXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblFEBXport.LinkClicked
        If Me.dgvFebPIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF FEBRUARY"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvFebPIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvFebPIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvFebPIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvFebPIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvFebPIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvFebPIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvFebPIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvFebPIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvFebPIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvFebPIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvFebPIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub lnklblMARCHXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblMARCHXport.LinkClicked
        If Me.dgvMarPIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF MARCH"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvMarPIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvMarPIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvMarPIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvMarPIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvMarPIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvMarPIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvMarPIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvMarPIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvMarPIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvMarPIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvMarPIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub lnklblAPRILXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblAPRILXport.LinkClicked
        If Me.dgvAprilPIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF APRIL"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvAprilPIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvAprilPIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvAprilPIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvAprilPIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvAprilPIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvAprilPIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvAprilPIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvAprilPIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvAprilPIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvAprilPIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvAprilPIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub lnklblMAYXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblMAYXport.LinkClicked
        If Me.dgvMayPIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF MAY"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvMayPIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvMayPIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvMayPIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvMayPIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvMayPIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvMayPIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvMayPIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvMayPIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvMayPIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvMayPIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvMayPIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub lnklblJUNEXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblJUNEXport.LinkClicked
        If Me.dgvJunePIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF JUNE"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvJunePIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvJunePIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvJunePIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvJunePIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvJunePIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvJunePIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvJunePIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvJunePIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvJunePIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvJunePIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvJunePIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub lnklblJULYXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblJULYXport.LinkClicked
        If Me.dgvJulyPIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF JULY"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvJulyPIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvJulyPIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvJulyPIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvJulyPIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvJulyPIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvJulyPIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvJulyPIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvJulyPIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvJulyPIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvJulyPIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvJulyPIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub lnklblAUGUSTXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblAUGUSTXport.LinkClicked
        If Me.dgvAugustPIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF AUGUST"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvAugustPIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvAugustPIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvAugustPIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvAugustPIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvAugustPIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvAugustPIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvAugustPIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvAugustPIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvAugustPIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvAugustPIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvAugustPIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub lnklblSEPXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblSEPXport.LinkClicked
        If Me.dgvSepPIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF SEPTEMBER"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvSepPIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvSepPIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvSepPIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvSepPIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvSepPIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvSepPIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvSepPIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvSepPIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvSepPIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvSepPIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvSepPIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub lnklblOCTXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblOCTXport.LinkClicked
        If Me.dgvOctPIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF OCTOBER"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvOctPIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvOctPIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvOctPIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvOctPIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvOctPIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvOctPIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvOctPIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvOctPIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvOctPIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvOctPIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvOctPIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub lnklblNOVXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblNOVXport.LinkClicked
        If Me.dgvNovPIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF NOVEMBER"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvNovPIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvNovPIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvNovPIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvNovPIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvNovPIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvNovPIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvNovPIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvNovPIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvNovPIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvNovPIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvNovPIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub lnklblDECXport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblDECXport.LinkClicked
        If Me.dgvDecPIPR.Rows.Count > 0 Then
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim

            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "POLICY PREMIUM INCREASE DETAILS"
                .Cells(2, 1) = "FOR THE MONTH OF DECEMBER"
                .Cells(3, 1) = "EXPORTED ON : " & Now()

                .Cells(5, 1) = "NO"
                .Cells(5, 2) = "IC"
                .Cells(5, 3) = "FULL NAME"
                .Cells(5, 4) = "PLAN"
                .Cells(5, 5) = "PLAN TYPE"
                .Cells(5, 6) = "START DATE"
                .Cells(5, 7) = "FOR MONTH YEAR"
                .Cells(5, 8) = "CURRENT PREMIUM"
                .Cells(5, 9) = "ACTUAL PREMIUM"
                .Cells(5, 10) = "PREMIUM DIFFERS"
                .Cells(5, 11) = "STATUS"
                .Cells(5, 12) = "REMARKS"

                Dim xRowCount As Integer = 6
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvDecPIPR.RowCount
                    .Cells(xRowCount, 1) = "'" & (xRowCount - 5).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvDecPIPR.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvDecPIPR.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvDecPIPR.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvDecPIPR.Rows(iCount).Cells(7).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvDecPIPR.Rows(iCount).Cells(8).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvDecPIPR.Rows(iCount).Cells(9).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & FormatNumber(Me.dgvDecPIPR.Rows(iCount).Cells(10).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 9) = "'" & FormatNumber(Me.dgvDecPIPR.Rows(iCount).Cells(11).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 10) = "'" & FormatNumber(Me.dgvDecPIPR.Rows(iCount).Cells(12).Value.ToString.Trim, 2)
                    .Cells(xRowCount, 11) = "'" & Me.dgvDecPIPR.Rows(iCount).Cells(13).Value.ToString.Trim
                    .Cells(xRowCount, 12) = ""
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            xApp.Visible = True
        Else
            MsgBox("No record found!")
        End If
    End Sub
    Private Sub dgvfPRJan_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPRJan.CellContentClick
        With Me.dgvfPRJan
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvfPRFeb_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPRFeb.CellContentClick
        With Me.dgvfPRFeb
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvfPRMar_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPRMar.CellContentClick
        With Me.dgvfPRMar
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvfPRApr_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPRApr.CellContentClick
        With Me.dgvfPRApr
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvfPRMay_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPRMay.CellContentClick
        With Me.dgvfPRMay
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvfPRJun_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPRJun.CellContentClick
        With Me.dgvfPRJun
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvfPRJul_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPRJul.CellContentClick
        With Me.dgvfPRJul
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvfPRAug_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPRAug.CellContentClick
        With Me.dgvfPRAug
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String

                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvfPRSep_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPRSep.CellContentClick
        With Me.dgvfPRSep
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvfPROct_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPROct.CellContentClick
        With Me.dgvfPROct
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvfPRNov_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPRNov.CellContentClick
        With Me.dgvfPRNov
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            End If
        End With
    End Sub
    Private Sub dgvfPRDec_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfPRDec.CellContentClick
        With Me.dgvfPRDec
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 1 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile4full(.Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "filename", "extenstion")
            ElseIf e.ColumnIndex = 2 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim sRes As String
                sRes = _objBusi.spUpdate("PIUP", .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", "CFULL", Conn)
                _objBusi.spUpdate("PPVERIFY", .Rows(e.RowIndex).Cells(3).Value.ToString().Trim(), "Premium Increase Request for " & .Rows(e.RowIndex).Cells(9).Value.ToString().Trim() & " has been confirmed!", My.Settings.Username().ToUpper.ToString(), "", "", "", "", "", "", "", Conn)
                BINDDATA()
                If sRes = "1" Then
                    MsgBox("Successfully Confirmed the Increase Premium")
                Else
                    MsgBox("Error while confirming Increase Premium")
                End If
            
            End If
        End With
    End Sub
    Private Sub tstbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstbtnGo.Click
        SharedData.ReadyToHideMarquee = False
        StartMarqueeThread()
        BINDDATA()
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()
    End Sub
End Class