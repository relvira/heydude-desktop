Imports Entities

Public Class FrmLogin
    Dim _formPosition As Point
    Dim _mouseAction As Boolean
    Private Sub BtnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnLogin.MyClick
        Dim result = UserLogin(TxtUser.Message, TxtPasswd.Message)
        If result.IsLoggedIn Then
            Dim heyDudeFrm As New FrmHeyDude(result)
            heyDudeFrm.Show()
        Else
            LblLoginError.Visible = True
        End If
    End Sub

    '---------------- MOVER FORMULARIO ----------------
    Private Sub FrmLogin_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        _formPosition = New Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y)
        _mouseAction = True
    End Sub

    Private Sub FrmLogin_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        Dim newPositionX = Cursor.Position.X - _formPosition.X
        Dim newPositionY = Cursor.Position.Y - _formPosition.Y
        If _mouseAction = True Then
            Location = New Point(newPositionX, newPositionY)
        End If
    End Sub

    Private Sub FrmLogin_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        _mouseAction = False
    End Sub
    
    Private Shared Sub BtnRegister_myClick(ByVal sender As Object, ByVal e As EventArgs) Handles BtnRegister.MyClick
        Dim frmRegister As New FrmRegister()
        frmRegister.Show()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
End Class