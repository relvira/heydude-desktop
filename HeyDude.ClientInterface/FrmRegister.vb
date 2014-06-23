Imports System.Net
Imports System.Configuration
Imports Entities.Util
Imports ChatClient.My.Resources

Public Class FrmRegister
    Dim _formPosition As Point
    Dim _mouseAction As Boolean
    Dim _profileImagePath As String = "profile-default.jpg"
    Dim _uploadClicked As Boolean = False

    Private Sub FrmRegister_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        FrmLogin.Hide()
    End Sub

    '---------------- MOVER FORMULARIO ----------------
    Private Sub FrmRegister_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        _formPosition = New Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y)
        _mouseAction = True
    End Sub

    Private Sub FrmRegister_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
        If _mouseAction = True Then

            Location = New Point(Cursor.Position.X - _formPosition.X, Cursor.Position.Y - _formPosition.Y)

        End If
    End Sub

    Private Sub FrmRegister_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp
        _mouseAction = False
    End Sub

    Private Sub BtnUploadImage_myClick(ByVal sender As Object, ByVal e As EventArgs) Handles BtnUploadImage.MyClick
        Dim fileDialog As New OpenFileDialog
        fileDialog.ShowDialog()
        _profileImagePath = fileDialog.FileName
        _uploadClicked = True
    End Sub

    Private Sub BtnRegister_myClick(ByVal sender As Object, ByVal e As EventArgs) Handles BtnRegister.MyClick
        Dim userFullName As String = TxtFullName.Message
        Dim userEmail As String = TxtEmail.Message
        Dim userPasswd1 As String = TxtPasswd1.Message
        Dim userPasswd2 As String = TxtPasswd2.Message
        Dim userPasswdFinal As String = ""
        Dim userUid As String = TxtUsername.Message
        Dim valid As Boolean = True

        If userUid.Length < 3 Then
            MessageBox.Show(InvalidUser)
            valid = False
        End If

        If Not IsEmail(userEmail) Then
            MessageBox.Show(InvalidEmail)
            valid = False
        End If

        If userFullName.Length < 5 Then
            MessageBox.Show(InvalidNameAndSurname)
            valid = False
        End If

        If userPasswd1 = userPasswd2 Then
            userPasswdFinal = GetSha1Hash(userPasswd1)
        Else
            MessageBox.Show(PasswordsDontMatch)
            valid = False
        End If

        If valid Then ' Valid form, let's register the user :)
            Dim profileImgGenerated As String = _profileImagePath
            If _uploadClicked Then
                'Upload image!
                ServicePointManager.Expect100Continue = False
                Dim uploadServer = ConfigurationManager.AppSettings("DynamicServer") & "profileImageUpload.php?uid=" & TxtUsername.Message

                Dim webp As New WebProxy("192.168.255.1", 3128)
                webp.UseDefaultCredentials = True

                Dim webcl As New WebClient()
                'webcl.Proxy = webp
                webcl.UploadFile(uploadServer, _profileImagePath)
                profileImgGenerated = TxtUsername.Message & ".png"
            End If

            Alta(userUid, userEmail, userFullName, userPasswdFinal, profileImgGenerated)

            FrmLogin.Show()
            Close()
        End If
    End Sub
End Class