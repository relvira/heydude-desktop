Imports CustomControls
Imports DataAccess
Imports Entities.UserComponents
Imports Entities.SocketUtil
Imports Entities.Util
Imports ChatClient.My.Resources
Imports DataAccess.Managers

Public Class FrmHeyDude
    Private Property MessageDb() As New SqLiteManager
    Private Property User As Entities.User

    Private Delegate Sub RequestReceivedCallback(ByVal chatRequest As ChatRequest)

    Public Sub New(ByVal personalData As PersonalData)
        Me.New()

        User = New Entities.User(personalData)
        User.SendMessage(ChatProtocol.Connect)
        AddHandler User.OnMessageReceived, AddressOf OnMessageReceived

        For Each frnd In User.Friends
            UserList.AddUserBox(New UserBox With {
                                .Id = frnd.Id,
                                .UserName = frnd.Name,
                                .UserState = frnd.StateMessage,
                                .ImageUser = frnd.ImageSource _
                            })
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
            TextBoxHD.Message = ""
            ChatList.AddChatBox(TextBoxHD.Message, AlignedTo.Right)
            User.SendMessage(TextBoxHD.Message, TitleChatList.Id)
            MessageDb.SaveMessage(New Message With {
                                  .FromUser = User.PersonalData.Id,
                                  .ToUser = TitleChatList.Id,
                                  .Message = TextBoxHD.Message _
                              })
        End If
    End Sub

    Private Sub UserSelectedChanged(ByVal pUserBox As UserBox) Handles UserList.UserSelectedChanged
        ChatList.Clean()
        TitleChatList.UserName = pUserBox.UserName
        TitleChatList.Id = pUserBox.Id
        RefreshMessageHistory()
    End Sub

    Private Sub RefreshMessageHistory()
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