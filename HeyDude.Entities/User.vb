Imports Entities.UserComponents

Public Class User
    Private ReadOnly _chatSocket As ChatSocket
    Public Property PersonalData As PersonalData

    Public Event OnConnect()
    Public Event OnMessageSent(ByVal request As Request)
    Public Event OnMessageReceived(ByVal request As Request)
    Public Event OnDisconnect()

    Public Sub New()
        _chatSocket = New ChatSocket()
        AddHandler _chatSocket.OnRequestReceived, AddressOf OnChatRequestReceived
    End Sub

    Public Sub SendMessage(ByVal request As Request)
        _chatSocket.SendRequest(request)
    End Sub

    Private Sub OnChatRequestReceived(ByVal request As Request)
        Select Case request.Protocol
            Case Protocol.Connect
                RaiseEvent OnConnect()
            Case Protocol.SendMessage
                RaiseEvent OnMessageSent(request)
            Case Protocol.ReceiveMessage
                RaiseEvent OnMessageReceived(request)
            Case Protocol.Disconnect
                RaiseEvent OnDisconnect()
        End Select
    End Sub
End Class
