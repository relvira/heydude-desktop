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

        Public Function DownloadFile(ByVal url As String, ByVal id As String, ByVal pass As String)
            Try
                Dim params As New NameValueCollection()
                params.Add("id", id)
                params.Add("passwd", pass)
                UpdateMsgDb(DownloadFile(url, params))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return False
            End Try

            Return VerifyFileCorruption()
        End Function

        Private Sub UpdateMsgDb(ByVal contentToAdd As Byte())
            With New BinaryWriter(New FileStream(SqLitePath, FileMode.OpenOrCreate))
                .Write(contentToAdd)
                .Close()
            End With
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