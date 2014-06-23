Imports System.Configuration
Imports System.Net
Imports System.Collections.Specialized
Imports System.IO

Namespace Util
    Public Module ServerDataCommunication
        Private ReadOnly SqLitePath As String = ConfigurationManager.AppSettings("SqliteDbPath")
        Private ReadOnly ServerUrl As String = ConfigurationManager.AppSettings("DynamicServer")
        Private ReadOnly WebClient As New WebClient

        Public Sub UploadFile(ByVal url As String)
            WebClient.UploadFile(ServerUrl & url, SqLitePath)
        End Sub

        Public Function DownloadFile(ByVal url As String, Optional ByVal params As NameValueCollection = Nothing)
            If params Is Nothing Then
                WebClient.DownloadFile(ServerUrl & "?" & url, SqLitePath)
                Return True
            Else
                Return WebClient.UploadValues(ServerUrl & "?" & url, "POST", params)
            End If
        End Function

        Public Sub UpdateMsgDb(ByVal url As String, ByVal id As Integer, ByVal passwd As String)
            Dim params As New NameValueCollection()
            params.Add("id", id)
            params.Add("passwd", passwd)
            Dim bytes = WebClient.UploadValues(ServerUrl & "?" & url, "POST", params)
            AppendToDb(bytes)
        End Sub

        Private Sub AppendToDb(ByVal content As Byte())
            Try
                Dim writer = New BinaryWriter(New FileStream(SqLitePath, FileMode.OpenOrCreate))
                writer.Write(content)
                writer.Close()
            Catch ex As IOException
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Function VerifyFileCorruption()
            If New FileInfo(SqLitePath).Length < 62 Then
                File.Delete(SqLitePath)
                Return False
            End If
            Return True
        End Function
    End Module
End Namespace