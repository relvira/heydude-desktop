Imports DataAccess
Imports Entities.UserComponents
Imports Entities.Util

Public Class FrmLogin
    Dim _formPosition As Point
    Dim _mouseAction As Boolean
    Private Sub BtnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnLogin.MyClick
        Dim result = CheckUserLogin(TxtUser.Message, TxtPasswd.Message)
        If result.IsLoggedIn Then
            Call New FrmHeyDude().Show(result)
        End If
    End Sub

    Private Function CheckUserLogin()
        Try
            Dim userData = GetUserData()
            If Not userData.Passwd = GetSha1Hash(TxtPasswd.Message) Then Throw New InvalidOperationException
        Catch ex As InvalidOperationException
            LblLoginError.Visible = True
            Return New PersonalData() With {.IsLoggedIn = False}
        End Try
    End Function

    Private Function GetUserData()
        Return New ChatProjectEntities().users _
                .Where(Function(personalData) personalData.uid = TxtUser.Message) _
                .Select(Function(personalData) New PersonalData With {
                        .Id = personalData.id,
                        .Passwd = personalData.password,
                        .Name = personalData.uid,
                        .Email = personalData.email,
                        .FullName = personalData.full_name,
                        .ImageSource = personalData.profile_img,
                        .StateMessage = personalData.user_status,
                        .IsLoggedIn = True}) _
                .Single()
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