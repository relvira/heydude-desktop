Imports System.Configuration
Imports System.IO
Imports System.Net.Sockets
Imports System.Threading
Imports Newtonsoft.Json
Imports Entities.My.Resources

Namespace UserComponents
    Public Class ChatSocket
        Private ReadOnly _tcpSocket As TcpClient
        Private ReadOnly _networkStream As NetworkStream
        Private ReadOnly _input As StreamReader
        Private ReadOnly _output As StreamWriter
        Private ReadOnly _requestThread As Thread

        Public Event OnRequestReceived(ByVal request As Request)

        Public Sub New()
            _tcpSocket = InstantiateNewTcpClient()
            _networkStream = GetTcpStream()

            _input = New StreamReader(_networkStream)
            _output = New StreamWriter(_networkStream)

            _requestThread = New Thread(New ThreadStart(AddressOf RecieveRequest))
            _requestThread.Name = "Recieve request thread"
            _requestThread.Start()
        End Sub

        Public Sub SendRequest(ByVal pRequest As Request)
            WriteSocketLine(JsonConvert.SerializeObject(pRequest))
        End Sub

        Private Sub RecieveRequest()
            While True
                RaiseEvent OnRequestReceived(DeserializeRequest())
            End While
            ' ReSharper disable once FunctionNeverReturns
        End Sub

        Private Function DeserializeRequest() As Request
            Return JsonConvert.DeserializeObject(Of Request)(ReadSocketLine())
        End Function

        Private Shared Function InstantiateNewTcpClient() As TcpClient
            Dim ip = ConfigurationManager.AppSettings("IP-ADDRESS")
            Dim port = ConfigurationManager.AppSettings("PORT")

            Try
                Return New TcpClient(ip, port)
            Catch ex As ArgumentNullException
                Throw New ChatException(PortIsNothing, ex)
            Catch ex As SocketException
                Throw New ChatException(UnableToConnectToServer, ex)
            End Try
        End Function

        Private Function GetTcpStream() As NetworkStream
            Try
                Return _tcpSocket.GetStream()
            Catch ex As InvalidExpressionException
                Throw New ChatException(TCPNotConnected, ex)
            Catch ex As ObjectDisposedException
                Throw New ChatException(TCPClosed, ex)
            End Try
        End Function

        Private Function ReadSocketLine() As String
            Try
                Return _input.ReadLine()
            Catch ex As OutOfMemoryException
                Throw New ChatException(BufferSizeOverflow, ex)
            Catch ex As IOException
                Throw New ChatException(ServerConnectionClosed, ex)
            End Try
        End Function

        Private Sub WriteSocketLine(ByVal msg As String)
            Console.WriteLine(msg)
            Try
                _output.WriteLine(msg)
                _output.Flush()
            Catch ex As IOException
                Throw New ChatException(ServerConnectionClosed, ex)
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            If Not _tcpSocket Is Nothing Then
                _tcpSocket.Close()
                _networkStream.Close()
                _input.Close()
                _output.Close()
                _requestThread.Abort()
            End If
        End Sub
    End Class
End Namespace