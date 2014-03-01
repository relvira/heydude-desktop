Imports System.Net
Imports System.IO

Public Class ChatBox
    Public Property UserName As String
        Get
            Return LblUserName.Text
        End Get
        Set(ByVal value As String)
            LblUserName.Text = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return LblMensaje.Text
        End Get
        Set(ByVal value As String)
            LblMensaje.Text = value
        End Set
    End Property

    Public WriteOnly Property ImageUser As String
        Set(ByVal value As String)
            ' Get the image from a web server
            Dim tClient As WebClient = New WebClient
            Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(value)))
            ImgUser.Image = tImage
        End Set
    End Property
End Class
