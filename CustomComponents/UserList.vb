Imports Microsoft.VisualBasic.ApplicationServices

Public Class UserList
    Private ReadOnly _mUserBoxlist As List(Of UserBox) = New List(Of UserBox)()
    Private _mPosY As Integer = 51

    Public Event UserSelectedChanged(ByVal pUserBox As UserBox)

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

        Controls.Add(userBox)

        With userBox
            .UserName = pName
            .UserState = pState
            .Location = New Point(1, _mPosY)
        End With

        AddHandler userBox.UserBoxSelected, AddressOf UserBoxSelected

        _mPosY += userBox.Height

        _mUserBoxlist.Add(userBox)
    End Sub

    Private Sub UserBoxSelected(pUserBox As UserBox)
        RaiseEvent UserSelectedChanged(pUserBox)
    End Sub

    Private Sub TxtSearch_KeyPress(sender As System.Object, e As KeyPressEventArgs) Handles TxtSearch.KeyPress
        Dim positionY As Integer = 51

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            TxtSearch.Text = ""
        End If

        For Each userBox As UserBox In _mUserBoxlist
            userBox.Visible = True
            userBox.Location = New Point(1, positionY)
            positionY += userBox.Height
        Next
    End Sub


    Private Sub TxtSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtSearch.TextChanged
        Dim positionY As Integer = 51

        For Each userBox As UserBox In _mUserBoxlist
            If Not userBox.UserName.ToLower().Contains(TxtSearch.Text.ToLower()) Then
                userBox.Visible = False
            Else
                userBox.Visible = True
                userBox.Location = New Point(1, positionY)
                positionY += userBox.Height
            End If
        Next
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(213, 213, 213), ButtonBorderStyle.Solid)
    End Sub
End Class
