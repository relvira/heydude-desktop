Public Class ChatBoxLeft
    Private _mGrowing As Boolean = False

    Public Property Mensaje As String
        Get
            Return LblMensaje.Text
        End Get
        Set(ByVal value As String)
            LblMensaje.Text = value
            LblHora.Text = Now.ToString("HH:mm")
            ResizeControl()
        End Set
    End Property

    Private Sub ResizeControl()
        For i As Integer = 47 To LblMensaje.Text.Count() Step 50
            LblMensaje.Text = LblMensaje.Text.Insert(i, vbCrLf)
        Next

        Height = Height + (15 * (Math.Floor(LblMensaje.Text.Length / 50)))
        Width = LblMensaje.Width + LblHora.Width + ImgTick.Width + 20
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(0, 213, 213, 213), 0, ButtonBorderStyle.Solid, _
                                Color.FromArgb(0, 213, 213, 213), 0, ButtonBorderStyle.Solid, _
                                Color.FromArgb(0, 213, 213, 213), 0, ButtonBorderStyle.Solid, _
                                Color.FromArgb(188, 221, 198), 2, ButtonBorderStyle.Solid)
    End Sub

    'Public WriteOnly Property ImageUser As String
    '    Set(ByVal value As String)
    '        ' Get the image from a web server
    '        Dim tClient As WebClient = New WebClient
    '        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(value)))
    '        ImgUser.Image = tImage
    '    End Set
    'End Property
End Class
