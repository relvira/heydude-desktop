Imports System.IO
Imports System.Net

Public Class UserBox
    Public Shared ReadOnly MColor As Color = Color.FromArgb(234, 239, 243)

    Public Event UserBoxSelected(ByVal pUserBox As UserBox)

    Public Property UserName As String
        Get
            Return LblUserName.Text
        End Get
        Set(ByVal value As String)
            LblUserName.Text = value
        End Set
    End Property

    Public Property UserState As String
        Get
            Return LblUserState.Text
        End Get
        Set(ByVal value As String)
            LblUserState.Text = value
        End Set
    End Property

    Public WriteOnly Property ImageUser As String
        Set(ByVal value As String)
            value = Config.ProfileImagesPath & value
            ' Get the image from a web server
            Dim tClient As WebClient = New WebClient
            Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(value)))
            ImgUser.Image = tImage
        End Set
    End Property

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        MyBase.OnClick(e)
        If BackColor = Color.White Then
            BackColor = MColor
        Else
            BackColor = Color.White
            RaiseEvent UserBoxSelected(Me)
        End If
    End Sub

    Private Sub LblUserName_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LblUserName.Click
        OnClick(e)
    End Sub

    Private Sub LblEstado_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LblUserState.Click
        OnClick(e)
    End Sub

    Private Sub ImgUser_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ImgUser.Click
        OnClick(e)
    End Sub
End Class
