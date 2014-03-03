Imports System.Net

Public Class FrmRegister
    Dim formPosition As Point
    Dim mouseAction As Boolean
    Dim ProfileImagePath As String = ""






    '---------------- MOVER FORMULARIO ----------------
    Private Sub FrmRegister_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        formPosition = New Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y)
        mouseAction = True
    End Sub

    Private Sub FrmRegister_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If mouseAction = True Then

            Location = New Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y)

        End If
    End Sub

    Private Sub FrmRegister_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        mouseAction = False
    End Sub

    Private Sub BtnUploadImage_myClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUploadImage.myClick
        Dim fileDialog As New OpenFileDialog
        fileDialog.ShowDialog()
        ProfileImagePath = fileDialog.FileName
    End Sub



    Private Sub BtnRegister_myClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRegister.myClick
        Dim UserFullName As String = TxtFullName.Message
        Dim UserEmail As String = TxtEmail.Message
        Dim UserPasswd1 As String = TxtPasswd1.Message
        Dim UserPasswd2 As String = TxtPasswd2.Message
        Dim UserPasswdFinal As String = ""
        Dim UserUid As String = TxtUsername.Message
        Dim valid As Boolean = True

        If UserUid.Length < 3 Then
            MessageBox.Show("Nombre de usuario no valido")
            valid = False
        End If

        If Not common.IsEmail(UserEmail) Then
            MessageBox.Show("Correo electronico invalido")
            valid = False
        End If

        If UserFullName.Length < 5 Then
            MessageBox.Show("Nombre y apellidos no validos")
            valid = False
        End If

        If UserPasswd1 = UserPasswd2 Then
            UserPasswdFinal = common.getSHA1Hash(UserPasswd1)
            MessageBox.Show("Hash: " & UserPasswdFinal)
        Else
            MessageBox.Show("Nombre y apellidos no validos")
            valid = False
        End If

        If valid Then
            '' register user!!!
            'Upload image!
            ServicePointManager.Expect100Continue = False
            Dim UploadServer = Config.DynamicServer & "profileImageUpload.php?uid=" & TxtUsername.Message

            Dim webp As New System.Net.WebProxy("192.168.255.1", 3128)
            webp.UseDefaultCredentials = True

            Dim webcl As New System.Net.WebClient()
            webcl.Proxy = webp
            webcl.UploadFile(UploadServer, ProfileImagePath)

            Dim RegisterUser As New MySQLManager
            Dim ProfileImgGenerated As String = TxtUsername.Message & ".png"
            Dim StatementGenerated = "INSERT INTO user(uid, email, full_name, password, profile_img) VALUES('" & UserUid & "','" & UserEmail & "','" & UserFullName & "','" & UserPasswdFinal & "','" & ProfileImgGenerated & "');"
            Console.WriteLine(StatementGenerated)
            MessageBox.Show(StatementGenerated)
            Dim Result = RegisterUser.ExecuteNoQuery(StatementGenerated)
            Me.Close()
        End If
    End Sub
End Class