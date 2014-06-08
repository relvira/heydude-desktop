Public Interface IChatActions
    Sub OnConnect()
    Sub OnMessageSent(ByVal request As Request)
    Sub OnMessageReceived(ByVal request As Request)
    Sub OnDisconnect()
End Interface
