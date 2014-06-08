Public Class TitleChatList
    Private _mId As Integer

    Property UserName() As String
        Get
            Return LblUserName.Text
        End Get
        Set(ByVal value As String)
            LblUserName.Text = value
        End Set
    End Property

    Property Id() As Integer
        Get
            Return _mId
        End Get
        Set(ByVal value As Integer)
            _mId = value
        End Set
    End Property

    Property UserState() As String
        Get
            Return LblUserState.Text
        End Get
        Set(ByVal value As String)
            LblUserState.Text = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(0, 213, 213, 213), 0, ButtonBorderStyle.Solid, _
                                Color.FromArgb(213, 213, 213), 1, ButtonBorderStyle.Solid, _
                                Color.FromArgb(213, 213, 213), 1, ButtonBorderStyle.Solid, _
                                Color.FromArgb(213, 213, 213), 1, ButtonBorderStyle.Solid)
    End Sub
End Class