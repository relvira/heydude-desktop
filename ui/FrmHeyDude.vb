Public Class FrmHeyDude
    Private _mCurrentUser As ClientData
    Private _mUserSelected As ClientData
    Private Friends As New ArrayList

    Dim formPosition As Point
    Dim mouseAction As Boolean

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

        UserList.AddUserBox(_mCurrentUser)
        For Each frnd In Friends
            Dim f = frnd.ToString.Split(",")
            _mUserSelected = New ClientData(f(2), f(4), State.Connected, f(3))
            UserList.AddUserBox(_mUserSelected)
        Next

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
        TitleChatList.Connected = State.Connected
    End Sub

    '---------------- MOVER FORMULARIO ----------------
    Private Sub FrmLogin_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        formPosition = New Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y)
        mouseAction = True
    End Sub

    Private Sub FrmLogin_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If mouseAction = True Then

            Location = New Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y)

        End If
    End Sub

    Private Sub FrmLogin_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        mouseAction = False
    End Sub
End Class
