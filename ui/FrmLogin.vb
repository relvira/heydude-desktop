Public Class FrmLogin
    Dim formPosition As Point
    Dim mouseAction As Boolean
    Private Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.myClick
        Dim result = common.UserLogin(TxtUser.Message, TxtPasswd.Message)
        If result.isLoggedIn Then
            Dim HeyDudeFrm As New FrmHeyDude(result)
            HeyDudeFrm.Show()
        Else
            LblLoginError.Visible = True
        End If
    End Sub

    Private Sub FrmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    '---------------- MOVER FORMULARIO ----------------
    Private Sub FrmLogin_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        formPosition = New Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y)
        mouseAction = True
    End Sub

    Private Sub FrmLogin_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If mouseAction = True Then

            Location = New Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y)

        End If
    End Sub

    Private Sub FrmLogin_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        mouseAction = False
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub BtnRegister_myClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRegister.myClick
        Dim FrmRegister As New FrmRegister()
        FrmRegister.Show()
    End Sub
End Class