Imports System.IO
Imports System.Net

Public Class UserBox
    Private Shared ReadOnly MColor As Color = Color.FromArgb(106, 145, 177)

    Public Selected As Boolean = False

    Public Event UserBoxSelected(pUserBox As UserBox)

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

    Public Property IsSelected() As Boolean
        Get
            Return Selected
        End Get
        Set(ByVal value As Boolean)
            Selected = value
        End Set
    End Property

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        MyBase.OnClick(e)
        If BackColor = MColor Then
            Selected = False
            BackColor = Color.White
            LblUserName.ForeColor = Color.Black
            LblUserState.ForeColor = Color.FromArgb(197, 189, 193)
        Else
            Selected = True
            BackColor = MColor
            LblUserName.ForeColor = Color.White
            LblUserState.ForeColor = Color.White
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
