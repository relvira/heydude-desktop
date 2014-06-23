Imports DataAccess
Imports Entities.UserComponents
Imports Entities.SocketUtil

Public Class User
    Public Property PersonalData As PersonalData
    Public Property Friends As List(Of PersonalData)
    Private Property ChatSocket As ChatSocket

    Public Event OnConnect()
    Public Event OnMessageSent(ByVal chatRequest As ChatRequest)
    Public Event OnMessageReceived(ByVal chatRequest As ChatRequest)
    Public Event OnDisconnect()

    Public Sub New(ByVal id As String)
        PersonalData = RetrievePersonalData(id)
    End Sub

    Public Sub SendMessage(ByVal msg As String, ByVal toId As Integer)
        ChatSocket.SendRequest(New ChatRequest(PersonalData.Id, ChatProtocol.SendMessage, toId, msg))
    End Sub

    Public Sub SendMessage(ByVal protocol As ChatProtocol)
        If Not protocol = ChatProtocol.SendMessage Then
            ChatSocket.SendRequest(New ChatRequest(PersonalData.Id, protocol, 0, ""))
        Else
            Throw New ArgumentException("Can't use this overload for send a request with SendMessage protocol.")
        End If
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

    Private Shared Function RetrievePersonalData(ByVal id As String) As PersonalData
        Return New ChatProjectEntities().users _
                .Where(Function(data) data.uid = id) _
                .Select(Function(data) New PersonalData With {
                        .Id = data.id,
                        .Passwd = data.password,
                        .Name = data.uid,
                        .Email = data.email,
                        .FullName = data.full_name,
                        .ImageSource = data.profile_img,
                        .StateMessage = data.user_status,
                        .IsLoggedIn = True}) _
                .Single()
    End Function

    Public Sub StartChatSocket()
        ChatSocket = New ChatSocket()
        AddHandler ChatSocket.OnRequestReceived, AddressOf OnChatRequestReceived
    End Sub

    Public Sub LoadFriends()
        Dim context As New ChatProjectEntities()
        Friends = (context.user_friends _
            .Where(Function(id) id.friend_of = PersonalData.Id) _
            .Select(Function(id) context.users _
                        .Where(Function(frnd) frnd.id = id.friend_to) _
                        .Select(Function(frnd) New PersonalData() With {
                                    .Id = frnd.id,
                                    .Name = frnd.uid,
                                    .FullName = frnd.full_name,
                                    .ImageSource = frnd.profile_img,
                                    .StateMessage = frnd.user_status})) _
            .ToList().Cast(Of PersonalData)())
    End Sub
End Class
