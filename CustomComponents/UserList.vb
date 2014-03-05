Imports Microsoft.VisualBasic.ApplicationServices

Public Class UserList
    Private ReadOnly _mUserBoxlist As List(Of UserBox) = New List(Of UserBox)()
    Private _mPosY As Integer = 47

    Public Event UserSelectedChanged(ByVal pUserBox As UserBox)

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(213, 213, 213), ButtonBorderStyle.Solid)
    End Sub

    Sub AddUserBox(clientData As ClientData)
        Dim userBox As New UserBox()
        userBox.UserName = clientData.Name
        userBox.UserState = clientData.StateMessage
        userBox.ImageUser = clientData.ImageSource
        userBox.Location = New Point(1, _mPosY)
        AddHandler userBox.UserBoxSelected, AddressOf UserBoxSelected

        Controls.Add(userBox)

        _mPosY += userBox.Height

        _mUserBoxlist.Add(userBox)
    End Sub


    ''' <summary>
    ''' Método para hacer pruebas sin necesitas conectarme a la base de datos.
    ''' </summary>
    Sub AddUserBox(pName As String, pState As String)
        Dim userBox As New UserBox
        With userBox
            .UserName = pName
            .UserState = pState
            .Location = New Point(1, _mPosY)
        End With

        AddHandler userBox.UserBoxSelected, AddressOf UserBoxSelected

        Controls.Add(userBox)

        _mPosY += userBox.Height

        _mUserBoxlist.Add(userBox)
    End Sub

    Private Sub UserBoxSelected(pUserBox As UserBox)
        RaiseEvent UserSelectedChanged(pUserBox)

    End Sub
End Class
