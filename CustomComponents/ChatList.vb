Public Class ChatList
    Private ReadOnly _mChatBoxList As List(Of ChatBox) = New List(Of ChatBox)()
    Private _mPosY As Integer = 0

    Public Sub AddChatBox(ByVal pMessage As String)
        Dim chatBox As New ChatBox

        Controls.Add(chatBox)

        chatBox.Mensaje = pMessage
        chatBox.Location = New Point(Width - chatBox.Width - 5, _mPosY)

        _mPosY += chatBox.Height + 5

        _mChatBoxList.Add(chatBox)
    End Sub
End Class
