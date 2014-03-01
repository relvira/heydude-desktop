Public Class ChatList
    Private ReadOnly _mChatBoxList As List(Of ChatBox) = New List(Of ChatBox)()
    Private _mPosY As Integer = 0

    Public Sub AddChatBox(ByVal pName As String, ByVal pMessage As String, ByVal pImgSrc As String)
        Dim chatBox As New ChatBox
        chatBox.UserName = pName
        chatBox.Mensaje = pMessage
        chatBox.ImageUser = pImgSrc
        chatBox.Location = New Point(20, _mPosY)

        Controls.Add(chatBox)

        _mPosY += chatBox.Height + 10

        _mChatBoxList.Add(chatBox)
    End Sub
End Class
