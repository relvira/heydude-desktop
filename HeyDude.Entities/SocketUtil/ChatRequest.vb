Imports Newtonsoft.Json

Namespace SocketUtil
    Public Class ChatRequest
        Public Property FromId() As Integer
        Public Property ChatProtocol() As ChatProtocol
        Public Property ToId() As Integer
        Public Property Message() As String
        
        Public Sub New(pFrom As Integer, pChatProtocol As ChatProtocol, Optional pTo As Integer = 0, Optional pMsg As String = "")
            FromId = pFrom
            ChatProtocol = pChatProtocol
            ToId = pTo
            Message = pMsg
        End Sub
    End Class
End Namespace