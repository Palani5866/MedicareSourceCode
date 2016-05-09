Public Class frmRetirees
#Region "Global Veriable"
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection()
    Dim PSTATUS As String
    Dim RAMOUNT As Double
#End Region
    Private Sub frmRetirees_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frmRetirees_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
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
        ds = _objBusi.getDsDetails_IX("RETIREES", Me.tscbYR.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
        SyncLock SharedData
            SharedData.ReadyToHideMarquee = True
        End SyncLock
        Application.DoEvents()


        If ds.Tables(0).Rows.Count > 0 Then
            With Me.dgvJanR
                .DataSource = ds.Tables(0)

                Me.lblTOTJAN.Text = "Total Records : " & ds.Tables(0).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            End With
        Else
            Me.dgvJanR.DataSource = ds.Tables(0)
            Me.lblTOTJAN.Text = "Total Records : 0 "
        End If


        If ds.Tables(1).Rows.Count > 0 Then
            With Me.dgvFebR
                .DataSource = ds.Tables(1)
                Me.lblTOTFEB.Text = "Total Records : " & ds.Tables(1).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End With
        Else
            Me.dgvFebR.DataSource = ds.Tables(1)
            Me.lblTOTFEB.Text = "Total Records : 0 "
        End If


        If ds.Tables(2).Rows.Count > 0 Then
            With Me.dgvMarR
                .DataSource = ds.Tables(2)
                Me.lblTOTMARCH.Text = "Total Records : " & ds.Tables(2).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            End With
        Else
            Me.dgvMarR.DataSource = ds.Tables(2)
            Me.lblTOTMARCH.Text = "Total Records : 0 "
        End If


        If ds.Tables(3).Rows.Count > 0 Then
            With Me.dgvAprR
                .DataSource = ds.Tables(3)
                Me.lblTOTAPRIL.Text = "Total Records : " & ds.Tables(3).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End With
        Else
            Me.dgvAprR.DataSource = ds.Tables(3)
            Me.lblTOTAPRIL.Text = "Total Records : 0 "
        End If


        If ds.Tables(4).Rows.Count > 0 Then
            With Me.dgvMayR
                .DataSource = ds.Tables(4)
                Me.lblTOTMAY.Text = "Total Records : " & ds.Tables(4).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End With
        Else
            Me.dgvMayR.DataSource = ds.Tables(4)
            Me.lblTOTMAY.Text = "Total Records : 0 "
        End If


        If ds.Tables(5).Rows.Count > 0 Then
            With Me.dgvJuneR
                .DataSource = ds.Tables(5)
                Me.lblTOTJUNE.Text = "Total Records : " & ds.Tables(5).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End With
        Else
            Me.dgvJuneR.DataSource = ds.Tables(5)
            Me.lblTOTJUNE.Text = "Total Records : 0 "
        End If


        If ds.Tables(6).Rows.Count > 0 Then
            With Me.dgvJulyR
                .DataSource = ds.Tables(6)
                Me.lblTOTJULY.Text = "Total Records : " & ds.Tables(6).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End With
        Else
            Me.dgvJulyR.DataSource = ds.Tables(6)
            Me.lblTOTJULY.Text = "Total Records : 0 "
        End If


        If ds.Tables(7).Rows.Count > 0 Then
            With Me.dgvAugR
                .DataSource = ds.Tables(7)
                Me.lblTOTAUGUST.Text = "Total Records : " & ds.Tables(7).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End With
        Else
            Me.dgvAugR.DataSource = ds.Tables(7)
            Me.lblTOTAUGUST.Text = "Total Records : 0 "
        End If


        If ds.Tables(8).Rows.Count > 0 Then
            With Me.dgvSepR
                .DataSource = ds.Tables(8)
                Me.lblTOTSEP.Text = "Total Records : " & ds.Tables(8).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End With
        Else
            Me.dgvSepR.DataSource = ds.Tables(8)
            Me.lblTOTSEP.Text = "Total Records : 0 "
        End If


        If ds.Tables(9).Rows.Count > 0 Then
            With Me.dgvOctR
                .DataSource = ds.Tables(9)
                Me.lblTOTOCT.Text = "Total Records : " & ds.Tables(9).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End With
        Else
            Me.dgvOctR.DataSource = ds.Tables(9)
            Me.lblTOTOCT.Text = "Total Records : 0 "
        End If


        If ds.Tables(10).Rows.Count > 0 Then
            With Me.dgvNovR
                .DataSource = ds.Tables(10)
                Me.lblTOTNOV.Text = "Total Records : " & ds.Tables(10).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End With
        Else
            Me.dgvNovR.DataSource = ds.Tables(10)
            Me.lblTOTNOV.Text = "Total Records : 0 "
        End If


        If ds.Tables(11).Rows.Count > 0 Then
            With Me.dgvDecR
                .DataSource = ds.Tables(11)
                Me.lblTOTDEC.Text = "Total Records : " & ds.Tables(11).Rows.Count
                .Columns(7).Visible = False

                .Columns(0).DisplayIndex = 21
                .Columns(1).DisplayIndex = 21
                .Columns(2).DisplayIndex = 21
                .Columns(3).DisplayIndex = 21
                .Columns(4).DisplayIndex = 21
                .Columns(5).DisplayIndex = 21
                .Columns(6).DisplayIndex = 21


                .Columns(12).DefaultCellStyle.Format = "#,#00.00"



                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            End With
        Else
            Me.dgvDecR.DataSource = ds.Tables(11)
            Me.lblTOTDEC.Text = "Total Records : 0 "
        End If
        
    End Sub
    Private Sub dgvJanR_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJanR.CellContentClick
        With Me.dgvJanR
            If e.ColumnIndex = 4 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If .Rows(e.RowIndex).Cells(3).Value = "" Then
                    If .Rows(e.RowIndex).Cells(0).Value = "" Then
                        MsgBox("Please do key in the comments!")
                        Exit Sub
                    End If

                    If .Rows(e.RowIndex).Cells(1).Value = "" Then
                        MsgBox("Please do key in the reminder date!")
                        Exit Sub
                    End If
                    If Not IsDate(.Rows(e.RowIndex).Cells(1).Value) Then
                        MsgBox("Please do key in valid date!")
                        Exit Sub
                    End If
                    
                    Dim sRDate As String
                    Dim rDate As Date
                    sRDate = .Rows(e.RowIndex).Cells(1).Value.ToString()
                    rDate = Convert.ToDateTime(sRDate)
                    If Not IsDBNull(.Rows(e.RowIndex).Cells(7).Value) Then
                        Dim sRes As String
                        sRes = _objBusi.spUpdate("RETIREESFOLLOWUP", .Rows(e.RowIndex).Cells(7).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(0).Value.ToString(), Format(rDate, "MM/dd/yyyy"), My.Settings.Username.ToUpper.ToString.Trim(), "", "", "", "", "", "", Conn)
                        If sRes = "1" Then
                            MsgBox("Successfully submitted your comments!")
                            BINDDATA()
                        Else
                            MsgBox("Error while submiting the comments, Please check with admin!")
                        End If
                    Else
                        MsgBox("No Record Found")
                    End If
                Else
                    If .Rows(e.RowIndex).Cells(4).Value = "" Then
                        MsgBox("Please select user to assign!")
                        Exit Sub
                    End If
                    If Not IsDBNull(.Rows(e.RowIndex).Cells(7).Value) Then
                        Dim sRes As String
                        sRes = _objBusi.spUpdate("RF_FOLLOWUP", .Rows(e.RowIndex).Cells(7).Value.ToString.Trim(), .Rows(e.RowIndex).Cells(2).Value.ToString(), .Rows(e.RowIndex).Cells(3).Value.ToString(), My.Settings.Username.ToUpper.ToString.Trim(), "", "", "", "", "", "", Conn)
                        If sRes = "1" Then
                            MsgBox("Successfully submitted your request!")
                            BINDDATA()
                        Else

                        End If
                    Else
                        MsgBox("No Record Found")
                    End If
                End If
            ElseIf e.ColumnIndex = 5 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim CS As New vCS
                CS.lblPID.Text = .Rows(e.RowIndex).Cells(7).Value.ToString()
                CS.lblType.Text = "RETIREES"
                CS.ShowDialog()
            ElseIf e.ColumnIndex = 6 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                If Not IsDBNull(.Rows(e.RowIndex).Cells(7).Value) Then
                    Dim Premium, GST, TOTALAMT As Double
                    Premium = .Rows(e.RowIndex).Cells(12).Value
                    GST = Premium * 6 / 100
                    TOTALAMT = Premium + GST
                    PrintLetters.lblOSPremium.Text = "0.00"
                    PrintLetters.lblOSGST.Text = "0.00"
                    PrintLetters.lblPremium.Text = FormatNumber(Premium, 2)
                    PrintLetters.lblGST.Text = FormatNumber(GST, 2)
                    PrintLetters.lblTotPremium.Text = FormatNumber(TOTALAMT, 2)

                    PrintLetters.Print_Letters("rfRetirees.rpt", .Rows(e.RowIndex).Cells(7).Value.ToString.Trim(), "RETIREES")
                End If
            End If
        End With
    End Sub
    Private Sub tstbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstbtnGo.Click
        BINDDATA()
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
End Class