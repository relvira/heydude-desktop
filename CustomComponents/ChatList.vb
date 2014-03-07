Public Class ChatList
    Private ReadOnly _mChatBoxList As List(Of ChatBox) = New List(Of ChatBox)()
    Private ReadOnly _mChatBoxLeftList As List(Of ChatBoxLeft) = New List(Of ChatBoxLeft)()
    Private _mPosY As Integer = 0

    Public Sub AddChatBox(ByVal pMessage As String, ByVal pAlignTo As AlignedTo, Optional ByVal pHourSent As Date = Nothing)
        Dim chatBox As New ChatBox


        If pHourSent = Nothing Then
            pHourSent = Now()
        End If

        Controls.Add(chatBox)

        chatBox.AlignTo = pAlignTo
        chatBox.Mensaje = pMessage
        chatBox.Location = New Point(chatBox.Location.X, _mPosY)
        chatBox.Hora = pHourSent

        _mPosY += chatBox.Height + 5

        _mChatBoxList.Add(chatBox)

    End Sub

    Public Sub AddChatBoxLeft(ByVal pMessage As String)
        Dim chatBoxLeft As New ChatBoxLeft

        Controls.Add(chatBoxLeft)

        chatBoxLeft.Mensaje = pMessage
        chatBoxLeft.Location = New Point(Width - (Width / 3) - chatBoxLeft.Width - 5, _mPosY)

        _mPosY += chatBoxLeft.Height + 5

        _mChatBoxLeftList.Add(chatBoxLeft)
    End Sub

    Public Sub Clean()
        ' Clean lists
        _mChatBoxList.Clear()
        _mChatBoxLeftList.Clear()

        ' Clear messages already displayed
        Controls.Clear()

        _mPosY = 0
    End Sub
End Class
