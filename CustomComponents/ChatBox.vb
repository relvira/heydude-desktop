Public Class ChatBox
    Private _mAlignTo As AlignedTo = AlignedTo.Right
    Private _mBottomColor As Color
    Private _mBottomBorderAnchor As Byte

    Public Property Mensaje As String
        Get
            Return LblMensaje.Text
        End Get
        Set(ByVal value As String)
            LblMensaje.Text = value
            LblHora.Text = Now.ToString("HH:mm")

            ResizeControl()
            ChangeAlign()
        End Set
    End Property

    Public Property AlignTo As AlignedTo
        Get
            Return _mAlignTo
        End Get
        Set(ByVal value As AlignedTo)
            _mAlignTo = value
        End Set
    End Property

    Private Sub ResizeControl()
        For i As Integer = 47 To LblMensaje.Text.Count() Step 50
            LblMensaje.Text = LblMensaje.Text.Insert(i, vbCrLf)
        Next

        Height = Height + (15 * (Math.Floor(LblMensaje.Text.Length / 50)))
    End Sub

    Private Sub ChangeAlign()
        If _mAlignTo = AlignedTo.Right Then
            _mBottomColor = Color.FromArgb(188, 221, 198)
            _mBottomBorderAnchor = 2
            Width = LblMensaje.Width + LblHora.Width + ImgTick.Width + 20
            Location = New Point(Parent.Width - Width - 5, 0)
        Else
            _mBottomColor = Color.FromArgb(149, 151, 155)
            _mBottomBorderAnchor = 1
            Width = LblMensaje.Width + LblHora.Width + 10
            BackColor = Color.White
            ImgTick.Width = 0
            Location = New Point(5, 0)
            LblHora.Location = New Point(Width - LblHora.Width - 3, 6)
            LblHora.ForeColor = Color.FromArgb(188, 193, 199)
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Transparent, 0, ButtonBorderStyle.Solid, _
                                Color.Transparent, 0, ButtonBorderStyle.Solid, _
                                Color.Transparent, 0, ButtonBorderStyle.Solid, _
                                _mBottomColor, _mBottomBorderAnchor, ButtonBorderStyle.Solid)
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