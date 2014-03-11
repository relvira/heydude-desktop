Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports ChatClient.UI
Imports ChatClient.CustomComponents
Imports ChatClient.Common
Imports Newtonsoft.Json

Namespace User
    Public Class ClientBuffer
        Private Const Port As Integer = 8000
        Private Const IpAddress As String = Config.ChatServer

        Private ReadOnly _mClientSocket As TcpClient
        Private ReadOnly _mNetworkStream As NetworkStream

        Private _mInput As StreamReader
        Private _mOutput As StreamWriter
        Private _mThReciveRequest As Thread
        Private ReadOnly _mContext As FrmHeyDude

        Delegate Sub GetRequestCallback(ByVal pRequest As ClientRequest)

        Public Sub New(ByVal pContext As FrmHeyDude)
            _mContext = pContext
            Try
                _mClientSocket = New TcpClient(IpAddress, Port)
                _mNetworkStream = _mClientSocket.GetStream()
                InitBuffers()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub InitBuffers()
            _mInput = New StreamReader(_mNetworkStream)
            _mOutput = New StreamWriter(_mNetworkStream)

            _mThReciveRequest = New Thread(New ThreadStart(AddressOf RecieveRequest))
            _mThReciveRequest.Name = "Recieve request thread"
            _mThReciveRequest.Start()
        End Sub

        Public Sub RecieveRequest()
            Dim request As ClientRequest
            While True
                request = ReadRequest()
                Try
                    Select Case request.Protocol
                        Case Protocol.Connect
                        Case Protocol.SendMessage
                        Case Protocol.ReceiveMessage
                            RaiseRequest(request)
                        Case Protocol.Disconnect
                    End Select
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Finalize()
                End Try
            End While
        End Sub

        Private Sub RaiseRequest(ByVal pRequest As ClientRequest)
            If _mContext.ChatList.InvokeRequired Then
                Dim d As New GetRequestCallback(AddressOf RaiseRequest)
                _mContext.ChatList.Invoke(d, New Object() {pRequest})
            Else
                _mContext.ChatList.AddChatBox(pRequest.Message, AlignedTo.Left)
            End If
        End Sub

        Private Function ReadRequest() As ClientRequest
            Dim js As String = _mInput.ReadLine()
            Console.WriteLine(js)
            Return JsonConvert.DeserializeObject(Of ClientRequest)(js)
        End Function

        Public Sub SendRequest(ByVal pRequest As ClientRequest)
            Try
                Console.WriteLine(JsonConvert.SerializeObject(pRequest))
                _mOutput.WriteLine(JsonConvert.SerializeObject(pRequest))
                _mOutput.Flush()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()

            If Not _mClientSocket Is Nothing Then
                _mClientSocket.Close()
                _mNetworkStream.Close()
                _mInput.Close()
                _mOutput.Close()
                _mThReciveRequest.Abort()
            End If
        End Sub
    End Class
End Namespace