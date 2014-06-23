Imports CustomControls
Imports Entities.SocketUtil
Imports Entities.Util
Imports DataAccess.Managers
Imports System.IO
Imports ChatClient.My.Resources

Public Class FrmHeyDude
    Private Property MessageDb() As SqLiteManager
    Private Property User As Entities.User

    Private Delegate Sub RequestReceivedCallback(ByVal chatRequest As ChatRequest)

    Public Sub New(ByVal usr As Entities.User)
        Me.New()

        User = usr
        Try
            User.LoadFriends()
            User.StartChatSocket()
            For Each frnd In User.Friends
                UserList.AddUserBox(New UserBox With {
                                    .Id = frnd.Id,
                                    .UserName = frnd.Name,
                                    .UserState = frnd.StateMessage,
                                    .ImageUser = frnd.ImageSource
                                })
            Next
        Catch ex As ChatException
            MessageBox.Show(ex.Message)
            Application.Exit()
            Return
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        User.SendMessage(ChatProtocol.Connect)
        AddHandler User.OnMessageReceived, AddressOf OnMessageReceived

        ' Before loading form, get all user local data
        GetUserLocalData()
        MessageDb = New SqLiteManager()
    End Sub

    Private Sub FrmHeyDude_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        FrmLogin.Hide()
    End Sub

    Private Sub FrmHeyDude_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        User.SendMessage(ChatProtocol.Disconnect)
        MessageDb.Close()
        UploadFile("sqliteUpload.php?uid=" & _User.PersonalData.Id)
        Application.Exit()
        User.CloseConnection()
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
            User.SendMessage(TextBoxHD.Message, TitleChatList.Id)
            MessageDb.SaveMessage(New Message With {
                                  .FromUser = User.PersonalData.Id,
                                  .ToUser = TitleChatList.Id,
                                  .Message = TextBoxHD.Message _
                              })
        End If
        TextBoxHD.Message = ""
    End Sub

    Private Sub UserSelectedChanged(ByVal pUserBox As UserBox) Handles UserList.UserSelectedChanged
        ChatList.Clean()
        TitleChatList.UserName = pUserBox.UserName
        TitleChatList.Id = pUserBox.Id
        RefreshMessageHistory()
    End Sub

    Private Sub RefreshMessageHistory()
        For Each msg In MessageDb.GetAll(User.PersonalData.Id, TitleChatList.Id)
            If msg.FromUser = User.PersonalData.Id Then
                ChatList.AddChatBox(msg.Message, AlignedTo.Right, msg.HourSent)
            ElseIf msg.FromUser = TitleChatList.Id Then
                ChatList.AddChatBox(msg.Message, AlignedTo.Left, msg.HourSent)
            End If
        Next
    End Sub

    Private Sub GetUserLocalData()
        ' Download Local User data
        LocalDataInitCheck(User.PersonalData.Id, User.PersonalData.Passwd)
    End Sub

    Private Sub OnMessageReceived(ByVal request As ChatRequest)
        If ChatList.InvokeRequired Then
            Dim callback As New RequestReceivedCallback(AddressOf OnMessageReceived)
            ChatList.Invoke(callback, New Object() {request})
        Else
            ChatList.AddChatBox(request.Message, AlignedTo.Left)
            MessageDb.SaveMessage(New Message With {
                                  .FromUser = request.FromId,
                                  .ToUser = request.ToId,
                                  .Message = request.Message})
        End If
    End Sub

    Private Shared Sub LocalDataInitCheck(ByVal id As Integer, Optional ByVal passwd As String = "")
        If File.Exists("heydude.db") Then
            UpdateMsgDb("downloadSqlite.php", id, passwd)
        Else
            DownloadFile("client-db/default.db")
        End If
    End Sub

    Private Sub ModernToolBar_OnFilterIntroClick(userName As String) Handles ModernToolBar.OnFilterIntroClick
        If (IsAdded(userName)) Then
            ModernToolBar.VisibleFilter = False
            ModernToolBar.EnableFail = False
            User.LoadFriends()
        Else
            ModernToolBar.EnableFail = True
        End If
    End Sub

    Private Function IsAdded(ByVal userName As String) As Boolean
        Try
            Return AddFriend(User.PersonalData.Id, userName)
        Catch ex As Exception
            MessageBox.Show(UserIsAlreadyFriend)
            Return False
        End Try
    End Function
End Class