
Public Class UserList
    Private ReadOnly _mUserBoxlist As List(Of UserBox) = New List(Of UserBox)()

    Private _posY As Integer = 51

    Private _mLastUserBoxSelected As UserBox

    Public Event UserSelectedChanged(ByVal pUserBox As UserBox)

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)

        BtnCancelSearch.FlatAppearance.MouseOverBackColor = Color.Transparent
        BtnCancelSearch.FlatAppearance.MouseDownBackColor = Color.Transparent
    End Sub

    Sub AddUserBox(userBox As UserBox)
        AddHandler userBox.UserBoxSelected, AddressOf UserBoxSelected
        userBox.Location = New Point(1, _posY)
        Controls.Add(userBox)
        _posY += userBox.Height
        _mUserBoxlist.Add(userBox)
    End Sub
    Public Sub RemoveAllUserBox()
        _posY = 51
        For Each usrBox In _mUserBoxlist
            Controls.Remove(usrBox)
        Next
    End Sub

    Private Sub UserBoxSelected(pUserBox As UserBox)
        RaiseEvent UserSelectedChanged(pUserBox)

        If Not _mLastUserBoxSelected Is Nothing Then
            _mLastUserBoxSelected.IsSelected = False
        End If

        _mLastUserBoxSelected = pUserBox
    End Sub

    Private Sub TxtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSearch.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Escape) Then
            TxtSearch.Text = ""
            LblBuscar.Visible = True
            e.Handled = True
        End If
    End Sub

    Private Sub TxtSearch_MouseDown(sender As Object, e As MouseEventArgs) Handles TxtSearch.MouseDown
        LblBuscar.Visible = False
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged
        Dim positionY As Integer = 51
        LblBuscar.Visible = False

        If TxtSearch.Text = "" Then
            BtnCancelSearch.Visible = False

            For Each userBox As UserBox In _mUserBoxlist
                userBox.Visible = True
                userBox.Location = New Point(1, positionY)
                positionY += userBox.Height
            Next
        Else
            BtnCancelSearch.Visible = True
            For Each userBox As UserBox In _mUserBoxlist
                If Not userBox.UserName.ToLower().Contains(TxtSearch.Text.ToLower()) Then
                    userBox.Visible = False
                Else
                    userBox.Visible = True
                    userBox.Location = New Point(1, positionY)
                    positionY += userBox.Height
                End If
            Next
        End If
    End Sub

    Private Sub TxtSearch_Leave(sender As Object, e As EventArgs) Handles TxtSearch.Leave
        If TxtSearch.Text = "" Then
            LblBuscar.Visible = True
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(213, 213, 213), ButtonBorderStyle.Solid)
    End Sub

    Private Sub BtnCancelSearch_MouseDown(sender As Object, e As MouseEventArgs) Handles BtnCancelSearch.MouseDown
        BtnCancelSearch.BackgroundImage = New Bitmap(My.Resources.cancelsearchbutton_pressed)
    End Sub


    Private Sub BtnCancelSearch_MouseUp(sender As Object, e As EventArgs) Handles BtnCancelSearch.MouseUp
        BtnCancelSearch.BackgroundImage = New Bitmap(My.Resources.cancelsearchbutton_unpressed)
    End Sub

    Private Sub BtnCancelSearch_Click(sender As Object, e As EventArgs) Handles BtnCancelSearch.Click
        BtnCancelSearch.Visible = False
        TxtSearch.Text = ""
    End Sub
End Class