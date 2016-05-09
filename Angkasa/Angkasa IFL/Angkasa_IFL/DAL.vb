Imports System.Xml
Imports System.Configuration
Imports System.Reflection
Public Class DAL
    Private Sub New()
    End Sub
    Public Shared Function SqlConn(ByVal key As String) As String

        Dim doc As XmlDocument = loadConfigDoc()

        Dim node As XmlNode = doc.SelectSingleNode("//ConnectionStrings")
        Dim sRes As String
        If node Is Nothing Then
            Throw New InvalidOperationException("ConnectionStrings section not found in config file.")
        End If
        Try

            Dim elem As XmlElement = DirectCast(node.SelectSingleNode(String.Format("//add[@key='{0}']", key)), XmlElement)
            sRes = elem.GetAttribute("value")
        Catch
            Throw
        End Try
        Return sRes
    End Function
    Public Shared Function InboxPath(ByVal key As String) As String

        Dim doc As XmlDocument = loadConfigDoc()

        Dim node As XmlNode = doc.SelectSingleNode("//appSettings")
        Dim sRes As String
        If node Is Nothing Then
            Throw New InvalidOperationException("ConnectionStrings section not found in config file.")
        End If
        Try

            Dim elem As XmlElement = DirectCast(node.SelectSingleNode(String.Format("//add[@key='{0}']", key)), XmlElement)
            sRes = elem.GetAttribute("value")
        Catch
            Throw
        End Try
        Return sRes
    End Function
    Public Shared Function OutboxPath(ByVal key As String) As String

        Dim doc As XmlDocument = loadConfigDoc()

        Dim node As XmlNode = doc.SelectSingleNode("//appSettings")
        Dim sRes As String
        If node Is Nothing Then
            Throw New InvalidOperationException("ConnectionStrings section not found in config file.")
        End If
        Try

            Dim elem As XmlElement = DirectCast(node.SelectSingleNode(String.Format("//add[@key='{0}']", key)), XmlElement)
            sRes = elem.GetAttribute("value")
        Catch
            Throw
        End Try
        Return sRes
    End Function
    Private Shared Function loadConfigDoc() As XmlDocument
        Dim doc As XmlDocument = Nothing
        Try
            doc = New XmlDocument()
            doc.Load(getConfigfPath())
            Return doc
        Catch e As System.IO.FileNotFoundException
            Throw New Exception("No configuration file found.", e)
        End Try
    End Function
    Private Shared Function getConfigfPath() As String
        Return "D:\App Config\appSettings.config"
    End Function
End Class
