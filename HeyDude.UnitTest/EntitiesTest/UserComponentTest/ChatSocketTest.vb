Imports NUnit.Framework
Imports Entities.UserComponents
Imports Entities.SocketUtil

Namespace EntitiesTest.UserComponentTest
    <TestFixture()>
    Public Class ChatSocketTest
        Private Property ChatSocket() As ChatSocket
        <SetUp()>
        Public Sub InstantiateChatSocket()
            ChatSocket = New ChatSocket()
        End Sub

        <Test()>
        Public Sub SocketShouldNotThrowExceptionWithHostFromAppConfig()
            Assert.DoesNotThrow(ChatSocket.StartListening())
        End Sub

        <Test()>
        Public Sub SocketShouldThrowChatExceptionWithNonExistentHost()
            ChatSocket.IpAddress = "fooIp"
            Assert.Throws(Of ChatException)(ChatSocket.StartListening())
        End Sub
    End Class
End Namespace