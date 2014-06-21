Imports Entities.UserComponents
Imports Entities.SocketUtil
Imports DataAccess.Managers

Public Class User
    Public Property PersonalData As PersonalData
    Private Property ChatSocket As ChatSocket
    Public Property Friends As ArrayList
    
    Public Event OnConnect()
    Public Event OnMessageSent(ByVal chatRequest As ChatRequest)
    Public Event OnMessageReceived(ByVal chatRequest As ChatRequest)
    Public Event OnDisconnect()

    Public Sub New()
        ChatSocket = New ChatSocket()
        ChatSocket.StartListening()
        AddHandler ChatSocket.OnRequestReceived, AddressOf OnChatRequestReceived
    End Sub
    
    Public Sub SendMessage(ByVal msg As String, ByVal toId As Integer)
        ChatSocket.SendRequest(New ChatRequest(PersonalData.Id, ChatProtocol.SendMessage, toId, msg))
    End Sub

    Public Sub SendMessage(ByVal protocol As ChatProtocol)
        If protocol = ChatProtocol.SendMessage Then
            Throw New ArgumentException("Can't use this overload for send a request with SendMessage protocol.")
        Else
            ChatSocket.SendRequest(New ChatRequest(PersonalData.Id, protocol, 0, ""))
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

    Public Sub InitFriends()
        Friends = RetrieveFriends()
    End Sub
    Private Function RetrieveFriends() As ArrayList
        Dim sqlManager As New MySQLManager
        Dim queryResult = sqlManager.ExecuteQuery("SELECT friend_to FROM user_friends where friend_of='" & PersonalData.Id & "'", "user_friends")

        Dim J = 0
        Dim Result As New ArrayList
        For Each oDataRow In queryResult.Rows
            Dim Idfriend = queryResult.Rows(J)("friend_to")
            Dim frnd = sqlManager.ExecuteQuery("SELECT id, uid, full_name, profile_img, user_status FROM user where id='" & Idfriend & "'", "user")
            For Each f In frnd.Rows
                Result.Add(frnd.Rows(0)("id") & "," & frnd.Rows(0)("uid") & "," & frnd.Rows(0)("full_name") & "," & frnd.Rows(0)("profile_img") & "," & frnd.Rows(0)("user_status"))
            Next
            J = J + 1
        Next
        Return Result
    End Function
End Class
