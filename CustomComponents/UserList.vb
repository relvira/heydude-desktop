Public Class UserList
    Private ReadOnly _mUserBoxlist As List(Of UserBox) = New List(Of UserBox)()
    Private _mPosY As Integer = 0

    Public Event UserSelectedChanged(ByVal pUserBox As UserBox)

    Sub AddUserBox(clientData As ClientData)
        Dim userBox As New UserBox()
        userBox.UserName = clientData.Name
        userBox.UserState = clientData.StateMessage
        userBox.ImageUser = clientData.ImageSource
        userBox.Location = New Point(0, _mPosY)
        AddHandler userBox.UserBoxSelected, AddressOf UserBoxSelected

        Controls.Add(userBox)

        _mPosY += userBox.Height

        _mUserBoxlist.Add(userBox)
    End Sub

    Private Sub UserBoxSelected(ByVal pUserBox As UserBox)
        RaiseEvent UserSelectedChanged(pUserBox)
    End Sub
End Class
