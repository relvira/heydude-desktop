Imports System.IO
Imports System.Net
Imports Entities

Public Class UserBox
    Private Shared ReadOnly MColor As Color = Color.FromArgb(106, 145, 177)
    Dim _userId As Integer
    Private _selected As Boolean = False

    Public Event UserBoxSelected(ByVal pUserBox As UserBox)

    Public Property UserName As String
        Get
            Return LblUserName.Text
        End Get
        Set(ByVal value As String)
            LblUserName.Text = value
        End Set
    End Property

    Public Property Id As Integer
        Get
            Return _userId
        End Get
        Set(ByVal value As Integer)
            _userId = value
        End Set
    End Property

    Public WriteOnly Property UserState As String
        Set(ByVal value As String)
            LblUserState.Text = value
        End Set
    End Property

    Public WriteOnly Property ImageUser As String
        Set(ByVal value As String)
            value = ProfileImagesPath & value
            ' Get the image from a web server
            Dim tClient As WebClient = New WebClient
            Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(value)))
            ImgUser.Image = tImage
        End Set
    End Property

    Public WriteOnly Property IsSelected() As Boolean
        Set(ByVal value As Boolean)
            _selected = value

            If value = True Then
                BackColor = MColor
                LblUserName.ForeColor = Color.White
                LblUserState.ForeColor = Color.White
                RaiseEvent UserBoxSelected(Me)
            Else
                BackColor = Color.White
                LblUserName.ForeColor = Color.Black
                LblUserState.ForeColor = Color.FromArgb(197, 189, 193)
            End If
        End Set
    End Property


    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        MyBase.OnClick(e)
        If _selected Then
            IsSelected = False
        Else
            IsSelected = True
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