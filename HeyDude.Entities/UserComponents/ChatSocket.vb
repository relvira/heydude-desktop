Imports System.Configuration
Imports System.IO
Imports System.Net.Sockets
Imports System.Threading
Imports NUnit.Framework
Imports Newtonsoft.Json
Imports Entities.My.Resources
Imports Entities.SocketUtil

Namespace UserComponents
    Public Class ChatSocket
        Public Property IpAddress As String
        Private Property Port As Integer
        Private Property TcpSocket As TcpClient
        Private Property NetworkStream As NetworkStream
        Private Property Input As StreamReader
        Private Property Output As StreamWriter
        Private Property RequestThread As Thread
        Private Property ChatException As ChatException

        Public Event OnRequestReceived(ByVal chatRequest As ChatRequest)

        Public Sub New()
            IpAddress = ConfigurationManager.AppSettings("IP-ADDRESS")
            Port = ConfigurationManager.AppSettings("PORT")
        End Sub

        Public Function StartListening() As TestDelegate
            TcpSocket = InstantiateNewTcpClient()
            NetworkStream = GetTcpStream()

            Input = New StreamReader(NetworkStream)
            Output = New StreamWriter(NetworkStream)

            RequestThread = New Thread(New ThreadStart(AddressOf RecieveRequest))
            RequestThread.Name = "Recieve ChatRequest thread"
            RequestThread.Start()
        End Function

        Public Sub SendRequest(ByVal pChatRequest As ChatRequest)
            WriteSocketLine(JsonConvert.SerializeObject(pChatRequest))
        End Sub

        Private Sub RecieveRequest()
            While True
                RaiseEvent OnRequestReceived(DeserializeRequest())
            End While
            ' ReSharper disable once FunctionNeverReturns
        End Sub

        Private Function DeserializeRequest() As ChatRequest
            Return JsonConvert.DeserializeObject(Of ChatRequest)(ReadSocketLine())
        End Function

        Private Function InstantiateNewTcpClient() As TcpClient
            Try
                Return New TcpClient(IpAddress, Port)
            Catch ex As ArgumentNullException
                Throw NewChatException(PortIsNothing, ex)
            Catch ex As SocketException
                Throw NewChatException(UnableToConnectToServer, ex)
            End Try
        End Function

        Private Function GetTcpStream() As NetworkStream
            Try
                Return TcpSocket.GetStream()
            Catch ex As InvalidExpressionException
                Throw NewChatException(TCPNotConnected, ex)
            Catch ex As ObjectDisposedException
                Throw NewChatException(TCPClosed, ex)
            End Try
        End Function

        Private Function ReadSocketLine() As String
            Try
                Return Input.ReadLine()
            Catch ex As OutOfMemoryException
                Throw NewChatException(BufferSizeOverflow, ex)
            Catch ex As IOException
                Throw NewChatException(ServerConnectionClosed, ex)
            End Try
        End Function

        Private Sub WriteSocketLine(ByVal msg As String)
            Console.WriteLine(msg)
            Try
                Output.WriteLine(msg)
                Output.Flush()
            Catch ex As IOException
                Throw NewChatException(ServerConnectionClosed, ex)
            End Try
        End Sub

        Private Function NewChatException(ByVal msg As String, ByVal ex As Exception) As ChatException
            ChatException = New ChatException(msg, ex)
            Return ChatException
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            If Not TcpSocket Is Nothing Then
                TcpSocket.Close()
                NetworkStream.Close()
                Input.Close()
                Output.Close()
                RequestThread.Abort()
            End If
        End Sub
    End Class
End Namespace