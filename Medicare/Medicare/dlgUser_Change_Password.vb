Imports System.Windows.Forms
Public Class dlgUser_Change_Password
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
#End Region
#Region "Page Events"
    Private Sub dlgUser_Change_Password_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub dlgUser_Change_Password_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Len(Me.txtUser_Password_Old.Text.Trim) = 0 Then
            MsgBox("Please do key in your old password.")
            Me.txtUser_Password_Old.Focus()
        Else
            If Len(Me.txtUser_Password_New.Text.Trim) = 0 Then
                MsgBox("Please do key in your new password.")
                Me.txtUser_Password_New.Focus()
            Else
                If Me.txtUser_Password_New.Text = Me.txtUser_Password_New_Final.Text Then

                    Dim cmdSelect_UserID As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                    cmdSelect_UserID.CommandType = CommandType.Text

                    cmdSelect_UserID.CommandText = "SELECT * FROM tb_Users WHERE UserID = '" & My.Settings.Username.Trim & "'"
                    Dim da_UserID As New SqlDataAdapter(cmdSelect_UserID)

                    Dim cmdUpdate_User_Password As SqlCommandBuilder
                    cmdUpdate_User_Password = New SqlCommandBuilder(da_UserID)


                    Dim cmdSelect_User_Log As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
                    cmdSelect_User_Log.CommandType = CommandType.Text
                    cmdSelect_User_Log.CommandText = "SELECT * FROM log_User WHERE Username = '" & My.Settings.Username.Trim & "'"
                    Dim da_User_Log As New SqlDataAdapter(cmdSelect_User_Log)

                    Dim cmdInsert_User_Log As SqlCommandBuilder
                    cmdInsert_User_Log = New SqlCommandBuilder(da_User_Log)


                    Dim ds_User As New DataSet


                    da_UserID.Fill(ds_User, "tb_Users")
                    da_User_Log.Fill(ds_User, "log_User")

                    If ds_User.Tables("tb_Users").Rows.Count = 1 Then
                        If Me.txtUser_Password_Old.Text.Trim = ds_User.Tables("tb_Users").Rows(0).Item("Password").ToString.Trim Then
                            ds_User.Tables("tb_Users").Rows(0)("Password") = Me.txtUser_Password_New_Final.Text.Trim
                            da_UserID.Update(ds_User, "tb_Users")


                            Dim dr_User_Log_New As DataRow
                            dr_User_Log_New = ds_User.Tables("log_User").NewRow

                            With dr_User_Log_New
                                .Item("Log_Date") = Now()
                                .Item("Username") = My.Settings.Username.Trim
                                .Item("Activity_Detail") = "User change password."
                            End With

                            ds_User.Tables("log_User").Rows.Add(dr_User_Log_New)
                            da_User_Log.Update(ds_User, "log_User")

                            MsgBox("Password changed.", MsgBoxStyle.Information, "Change a Password")
                            Me.Close()
                        Else
                            MsgBox("Old password not match, please try again.")
                            Me.txtUser_Password_Old.Focus()
                        End If
                    Else
                        MsgBox("System Error, please do contact your system vendor.")
                    End If
                Else
                    MsgBox("Confirm New Password is not the same as your New Password, please do rekey in.")
                    Me.txtUser_Password_New_Final.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region
End Class
