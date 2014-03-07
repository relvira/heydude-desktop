Public Class FrmHeyDude
    Private _mCurrentUser As ClientData
    'Private _mUserSelected As ClientData
    Private Friends As New ArrayList

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal UserItem As ClientData)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Other calls
        _mCurrentUser = UserItem
        Friends = _mCurrentUser.GetUserAllFriends(_mCurrentUser.Id)

    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)

        ' Hide Login form
        FrmLogin.Hide()

        For Each frnd In Friends
            Dim f = frnd.ToString.Split(",")
            UserList.AddUserBox(New ClientData(f(0), f(2), f(4), State.Connected, f(3)))
        Next

        ' No borrar, es para hacer pruebas de interfaz
        'UserList.AddUserBox("Manuel Mangas Zurita", ":)")
        'UserList.AddUserBox("Rafael De Elvira Tellez", ":)")

    End Sub

    Private Sub RecieveMessage(ByVal MessageArgs As Object)

    End Sub

    Private Sub SendMessage(ByVal e As KeyPressEventArgs) Handles TextBoxHD.OnIntroPressed
        If TextBoxHD.Message <> "" And TitleChatList.Id <> 0 Then
            ChatList.AddChatBox(TextBoxHD.Message, AlignedTo.Right)

            ' Save this shit in SQLite
            Try
                Dim SaveMessage As New SQLiteManager
                Dim MessageStatement = "INSERT INTO messages(from_id, to_id, message) VALUES(" & _mCurrentUser.Id & ", " & TitleChatList.Id & " ,'" & TextBoxHD.Message & "');"
                Dim Result = SaveMessage.ExecuteNoQuery(MessageStatement)
            Catch ex As Exception
                MessageBox.Show("DB error: " & ex.Message)
            End Try

            ' WORK REAL SEND MESSAGE TO SERVER HERE

            TextBoxHD.Message = ""
        End If
    End Sub

    Private Sub UserSelectedChanged(ByVal pUserBox As UserBox) Handles UserList.UserSelectedChanged
        ' @TODO: Clean messages zone!!!!!
        ChatList.Clean()
        TitleChatList.UserName = pUserBox.UserName
        TitleChatList.Id = pUserBox.Id

        ' THERE ARE OLD MESSAGES? PRINT EM NIGGA!
        Dim i As Integer = 0
        Try
            Dim OldMessages As New SQLiteManager
            Dim queryResult = OldMessages.ExecuteQuery("SELECT from_id, to_id, message, timestamp FROM messages WHERE from_id=" & TitleChatList.Id & " OR to_id=" & TitleChatList.Id & " ORDER BY timestamp ASC;", "messages")
            If queryResult.Rows.Count > 0 Then
                For Each oDataRow In queryResult.Rows
                    If queryResult.Rows(i)("from_id") = TitleChatList.Id Then
                        ' From other messages
                        ChatList.AddChatBox(queryResult.Rows(i)("message"), AlignedTo.Left)
                    ElseIf queryResult.Rows(i)("from_id") = _mCurrentUser.Id Then
                        ' Messages from me to others
                        ChatList.AddChatBox(queryResult.Rows(i)("message"), AlignedTo.Right)
                    End If
                    i = i + 1
                Next
            Else
                ' NO ROWS RETURNED
            End If
        Catch ex As Exception
            MessageBox.Show("Read exception" & ex.Message)
        End Try
    End Sub

    Private Sub ToolBar_OnCloseButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar.OnCloseButtonClick
        Close()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(213, 213, 213), ButtonBorderStyle.Solid)
    End Sub

    Private Sub ChatList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChatList.Load

    End Sub
End Class
