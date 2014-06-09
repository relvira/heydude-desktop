Imports Entities.UserComponents
Imports Entities.SocketUtil

Public Class User
    Public Property PersonalData As PersonalData
    Private Property ChatSocket As ChatSocket
    Public Property Friends As PersonalData()

    Private Function RetrieveFriends() As PersonalData()
        Throw New NotImplementedException()
    End Function

    Public Shared Event OnConnect()
    Public Shared Event OnMessageSent(ByVal chatRequest As ChatRequest)
    Public Shared Event OnMessageReceived(ByVal chatRequest As ChatRequest)
    Public Shared Event OnDisconnect()

    Public Sub New()
        Friends = RetrieveFriends()
        ChatSocket = New ChatSocket()
        AddHandler ChatSocket.OnRequestReceived, AddressOf OnChatRequestReceived
    End Sub

    Public Sub SendMessage(ByVal chatRequest As ChatRequest)
        ChatSocket.SendRequest(chatRequest)
    End Sub

    Private Sub OnChatRequestReceived(ByVal chatRequest As ChatRequest)
        Select Case chatRequest.ChatProtocol
            Case ChatProtocol.Connect
                RaiseEvent OnConnect()
            Case ChatProtocol.SendMessage
                RaiseEvent OnMessageSent(chatRequest)
            Case ChatProtocol.ReceiveMessage
                RaiseEvent OnMessageReceived(chatRequest)
            Case ChatProtocol.Disconnect
                RaiseEvent OnDisconnect()
        End Select
    End Sub
End Class
