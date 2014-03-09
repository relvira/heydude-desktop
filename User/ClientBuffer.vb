Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports ChatClient.UI
Imports ChatClient.CustomComponents
Imports Newtonsoft.Json

Namespace User
    Public Class ClientBuffer
        Private Const Port As Integer = 8000
        Private Const IpAddress As String = "localhost"

        Private ReadOnly _mClientSocket As TcpClient
        Private ReadOnly _mNetworkStream As NetworkStream

        Private _mInput As StreamReader
        Private _mOutput As StreamWriter
        Private _mThReciveRequest As Thread

        Delegate Sub GetRequestCallback(txt As String)

        Public Event OnMessageRecived(ByVal pRequest As ClientRequest)

        Public Sub New()
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

            _mThReciveRequest = New Thread(AddressOf RecieveRequest)
            _mThReciveRequest.Start()
        End Sub

        Private Sub RecieveRequest()
            Dim request As ClientRequest
            While True
                Try
                    request = ReadRequest()
                    RaiseEvent OnMessageRecived(request)
                    SetMessage(request.Message)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Finalize()
                End Try
            End While
        End Sub

        Private Sub SetMessage(ByVal pMsg As String)
            If FrmHeyDude.ChatList.InvokeRequired Then
                Dim d As New GetRequestCallback(AddressOf SetMessage)
                FrmHeyDude.Invoke(d, New Object() {pMsg})
            Else
                FrmHeyDude.ChatList.AddChatBox(pMsg, AlignedTo.Left)
            End If
        End Sub

        Private Function ReadRequest() As ClientRequest
            Return CType(JsonConvert.DeserializeObject(_mInput.ReadLine()), ClientRequest)
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