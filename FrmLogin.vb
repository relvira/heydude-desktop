Imports DataAccess

Public Class FrmLogin
    Dim formPosition As Point
    Dim mouseAction As Boolean
    Private Sub BtnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnLogin.MyClick
        Dim result = Common.UserLogin(TxtUser.Message, TxtPasswd.Message)
        If result.isLoggedIn Then
            Dim HeyDudeFrm As New FrmHeyDude(result)
            HeyDudeFrm.Show()
        Else
            LblLoginError.Visible = True
        End If
    End Sub

    '---------------- MOVER FORMULARIO ----------------
    Private Sub FrmLogin_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        formPosition = New Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y)
        mouseAction = True
    End Sub

    Private Sub FrmLogin_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If mouseAction = True Then

            Location = New Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y)

        End If
    End Sub

    Private Sub FrmLogin_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        mouseAction = False
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub BtnRegister_myClick(ByVal sender As Object, ByVal e As EventArgs) Handles BtnRegister.MyClick
        Dim FrmRegister As New FrmRegister()
        FrmRegister.Show()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class