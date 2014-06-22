Imports CustomControls
Imports Entities
Imports Entities.UserComponents
Imports Entities.SocketUtil
Imports Entities.Util
Imports ChatClient.My.Resources

Public Class FrmHeyDude
    Private Property User As User

    Private Delegate Sub RequestReceivedCallback(ByVal chatRequest As ChatRequest)

    Public Sub New(ByVal personalData As PersonalData)
        Me.New()

        User = New User(personalData)
        User.SendMessage(ChatProtocol.Connect)
        AddHandler User.OnMessageReceived, AddressOf OnMessageReceived

        Dim friends = From frnd In User.Friends Select frnd.ToString.Split(",")
        ' Load User friends. LinQ expression.
        For Each f In friends
            UserList.AddUserBox(New PersonalData(f(0), f(2), f(4), f(3)))
        Next
        ' Before loading form, get all user local data
        GetUserLocalData()
    End Sub

    Private Sub FrmHeyDude_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        FrmLogin.Hide()
    End Sub

    Private Sub FrmHeyDude_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        User.SendMessage(ChatProtocol.Disconnect)
        UploadFile("sqliteUpload.php?uid=" & _User.PersonalData.Id)
        FrmLogin.Close()
    End Sub

    Private Sub ToolBar_OnCloseButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles ModernToolBar.OnCloseButtonClick
        Close()
    End Sub

    Private Sub FrmHeyDude_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(213, 213, 213), ButtonBorderStyle.Solid)
    End Sub

    Private Sub SendMessage(ByVal e As KeyPressEventArgs) Handles TextBoxHD.OnIntroPressed
        If TextBoxHD.Message.Length > 1 And TitleChatList.Id <> 0 Then
            ChatList.AddChatBox(TextBoxHD.Message, AlignedTo.Right)
            SaveMessage(User.PersonalData.Id, TitleChatList.Id, TextBoxHD.Message)
            User.SendMessage(TextBoxHD.Message, TitleChatList.Id)
            TextBoxHD.Message = ""
        End If
    End Sub

    Private Sub UserSelectedChanged(ByVal pUserBox As UserBox) Handles UserList.UserSelectedChanged
        ChatList.Clean()
        TitleChatList.UserName = pUserBox.UserName
        TitleChatList.Id = pUserBox.Id
        RefreshMessageHistory()
    End Sub

    Private Sub RefreshMessageHistory()
        ' THERE ARE OLD MESSAGES? PRINT EM NIGGA!
        Dim i As Integer = 0
        Try
            Dim queryResult = Common.SqliteManager.ExecuteQuery("SELECT from_id, to_id, message, timestamp FROM messages WHERE from_id=" & TitleChatList.Id & " OR to_id=" & TitleChatList.Id & " ORDER BY timestamp ASC;", "messages")
            If queryResult.Rows.Count > 0 Then
                For Each oDataRow In queryResult.Rows
                    If queryResult.Rows(i)("from_id") = TitleChatList.Id Then
                        ' From other messages
                        ChatList.AddChatBox(queryResult.Rows(i)("message"), AlignedTo.Left, queryResult.Rows(i)("timestamp"))
                    ElseIf queryResult.Rows(i)("from_id") = User.PersonalData.Id Then
                        ' Messages from me to others
                        ChatList.AddChatBox(queryResult.Rows(i)("message"), AlignedTo.Right, queryResult.Rows(i)("timestamp"))
                    End If
                    i = i + 1
                Next
            Else
                ' NO ROWS RETURNED
            End If
        Catch ex As Exception
            MessageBox.Show(ReadException & ex.Message)
        End Try
    End Sub

    Private Sub GetUserLocalData()
        ' Download Local User data
        LocalDataInitCheck(User.PersonalData.Id, User.PersonalData.Passwd)
        ' After download create MySQL Instance
        Common.SqliteManager = New SQLiteManager
    End Sub

    Private Sub OnMessageReceived(ByVal request As ChatRequest)
        If ChatList.InvokeRequired Then
            Dim callback As New RequestReceivedCallback(AddressOf OnMessageReceived)
            ChatList.Invoke(callback, New Object() {request})
        Else
            SaveMessage(request.FromId, request.ToId, request.Message)
            ChatList.AddChatBox(request.Message, AlignedTo.Left)
        End If
    End Sub

    Private Sub LocalDataInitCheck(ByVal id As Integer, Optional ByVal passwd As String = "")
        Const url As String = "downloadSqlite.php"
        If Not DownloadFile(url, id, passwd) Then ' Si no existe el fichero o no hay versión en el servidor...
            DownloadFile("default.db")  ' Default db file.
        End If
    End Sub
End Class