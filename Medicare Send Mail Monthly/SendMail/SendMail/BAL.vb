Imports System.Data.SqlClient
Public Class BAL
    Public Function fGetPI(ByVal Type As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal P4 As String, ByVal P5 As String, _
                                   ByVal P6 As String, ByVal P7 As String, ByVal P8 As String, ByVal P9 As String, ByVal P10 As String, ByVal sqlConn As SqlConnection) As DataSet

        Dim ds As New DataSet
        Dim sdp As SqlDataAdapter
        Dim sqlCmd As New SqlCommand
        With sqlCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "[dbo].[sp_SendMailPI]"
            If sqlConn.State = ConnectionState.Closed Then
                sqlConn.Open()
            End If
            .Connection = sqlConn
            .CommandTimeout = 6000
            .Parameters.AddWithValue("@Type", Type)
            .Parameters.AddWithValue("@P1", P1)
            .Parameters.AddWithValue("@P2", P2)
            .Parameters.AddWithValue("@P3", P3)
            .Parameters.AddWithValue("@P4", P4)
            .Parameters.AddWithValue("@P5", P5)
            .Parameters.AddWithValue("@P6", P6)
            .Parameters.AddWithValue("@P7", P7)
            .Parameters.AddWithValue("@P8", P8)
            .Parameters.AddWithValue("@P9", P9)
            .Parameters.AddWithValue("@P10", P10)
            sdp = New SqlDataAdapter(sqlCmd)
            sdp.Fill(ds)
            sqlConn.Close()
            Return ds
        End With
    End Function

End Class
