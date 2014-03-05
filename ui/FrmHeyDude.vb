Public Class FrmHeyDude
    Private _mCurrentUser As ClientData
    Private _mUserSelected As ClientData
    Private Friends As New ArrayList

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal UserItem As ClientData)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _mCurrentUser = UserItem

        Friends = _mCurrentUser.GetUserAllFriends(_mCurrentUser.Id)

    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)

        ' Hide Login form
        FrmLogin.Hide()

        'UserList.AddUserBox(_mCurrentUser)
        For Each frnd In Friends
            Dim f = frnd.ToString.Split(",")
            _mUserSelected = New ClientData(f(2), f(4), State.Connected, f(3))
            UserList.AddUserBox(_mUserSelected)
        Next

        ' No borrar, es para hacer pruebas de interfaz
        UserList.AddUserBox("Manuel Mangas Zurita", ":)")
        UserList.AddUserBox("Rafael De Elvira Tellez", ":)")

    End Sub

    Private Sub SendMessage(ByVal e As KeyPressEventArgs) Handles TextBoxHD.OnIntroPressed
        If TextBoxHD.Message <> "" Then
            ChatList.AddChatBox(_mCurrentUser.FullName, TextBoxHD.Message, _mCurrentUser.ImageSource)
            TextBoxHD.Message = ""
        End If
    End Sub

    Private Sub UserSelectedChanged(ByVal pUserBox As UserBox) Handles UserList.UserSelectedChanged
        TitleChatList.UserName = pUserBox.UserName
        TitleChatList.UserState = pUserBox.UserState
    End Sub

    Private Sub ToolBar_OnCloseButtonClick(sender As Object, e As System.EventArgs) Handles ToolBar.OnCloseButtonClick
        Close()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(213, 213, 213), ButtonBorderStyle.Solid)
    End Sub
End Class
