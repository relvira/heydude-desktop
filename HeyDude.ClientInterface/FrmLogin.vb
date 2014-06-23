Imports Entities.Util
Imports Entities

Public Class FrmLogin
    Dim _formPosition As Point
    Dim _mouseAction As Boolean
    Dim _user As User

    Private Sub BtnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnLogin.MyClick
        If UserVerified() Then
            Call New FrmHeyDude(_user).Show()
        End If
    End Sub

    Private Function UserVerified() As Boolean
        'Try
        _user = New User(TxtUser.Message)
        If _user.PersonalData.Passwd <> GetSha1Hash(TxtPasswd.Message) Then Return False
        If Not _user.PersonalData.IsLoggedIn Then Return False
        Return True
        'Catch ex As InvalidOperationException
        '    LblLoginError.Visible = True
        '    Return False
        'End Try
    End Function

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