Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports DataAccess.Common
Imports Newtonsoft.Json

Namespace User
    Public Class ClientBuffer
        Private Const Port As Integer = 8000
        Private ReadOnly _ipAddress As String = Config.ChatServer

        Private ReadOnly _mClientSocket As TcpClient
        Private ReadOnly _mNetworkStream As NetworkStream

        Private _mInput As StreamReader
        Private _mOutput As StreamWriter
        Private _mThReciveRequest As Thread
        Private ReadOnly _mContext As IAccesibleMultiThread

        Delegate Sub GetRequestCallback(ByVal pRequest As ClientRequest)

        Public Sub New(ByVal pContext As IAccesibleMultiThread)
            _mContext = pContext
            Try
                _mClientSocket = New TcpClient(_ipAddress, Port)
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
                    Return
                End Try
            End While
        End Sub

        Private Sub RaiseRequest(ByVal pRequest As ClientRequest)
            If _mContext.NeedExecute Then
                Dim d As New GetRequestCallback(AddressOf RaiseRequest)
                _mContext.ExecuteMethod(d, New Object() {pRequest})
            Else
                SaveMessage(pRequest.FromId, pRequest.ToId, pRequest.Message)
                _mContext.AddComponent(pRequest)
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