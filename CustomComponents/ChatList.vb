Namespace CustomComponents
    Public Class ChatList
        Private ReadOnly _mChatBoxList As List(Of ChatBox) = New List(Of ChatBox)()
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

        Public Sub Clean()
            ' Clean lists
            _mChatBoxList.Clear()

            ' Clear messages already displayed
            Controls.Clear()

            _mPosY = 0
        End Sub
    End Class
End Namespace