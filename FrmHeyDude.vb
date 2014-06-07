Imports CustomControls
Imports DataAccess
Imports DataAccess.User
Imports DataAccess.DbManagers

Public Class FrmHeyDude
    Implements IAccesibleMultiThread

    Private ReadOnly _user As ClientData
    Private ReadOnly _userBuffer As New ClientBuffer(Me)
    Private ReadOnly _request As ClientRequest
    Private ReadOnly _friends As New ArrayList

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal pUser As ClientData)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Other calls
        _user = pUser
        _friends = pUser.GetUserAllFriends()
        _request = New ClientRequest(pUser.Id, Protocol.Connect)
        _userBuffer.SendRequest(_request)
    End Sub

    Private Sub FrmHeyDude_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Hide Login form
        FrmLogin.Hide()

        ' Load User friends. LinQ expression.
        For Each f In From frnd As String In _friends Select frnd.ToString.Split(",")
            UserList.AddUserBox(New ClientData(f(0), f(2), f(4), f(3)))
        Next

        ' Antiguo for
        'For Each frnd As String In _friends
        '    Dim f As String() = frnd.ToString.Split(",")
        '    UserList.AddUserBox(New ClientData(f(0), f(2), f(4), f(3)))
        'Next

        ' Before loading form, get all user local data
        GetUserLocalData()
    End Sub

    Private Sub FrmHeyDude_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        _request.FromId = _user.Id
        _request.Protocol = Protocol.Disconnect
        _userBuffer.SendRequest(_request)

        UploadUserLocalData(_user.Id)

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
            SaveMessage(_user.Id, TitleChatList.Id, TextBoxHD.Message)
            SendMessage()
        End If

        TextBoxHD.Message = ""
    End Sub

    Private Sub UserSelectedChanged(ByVal pUserBox As UserBox) Handles UserList.UserSelectedChanged
        ChatList.Clean()
        TitleChatList.UserName = pUserBox.UserName
        TitleChatList.Id = pUserBox.Id

        RefreshMessageHistory()
    End Sub

    Private Sub SendMessage()
        _request.FromId = _user.Id
        _request.Protocol = Protocol.SendMessage
        '_request.ToId = _user.Id
        _request.ToId = TitleChatList.Id
        _request.Message = TextBoxHD.Message

        _userBuffer.SendRequest(_request)
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
                    ElseIf queryResult.Rows(i)("from_id") = _user.Id Then
                        ' Messages from me to others
                        ChatList.AddChatBox(queryResult.Rows(i)("message"), AlignedTo.Right, queryResult.Rows(i)("timestamp"))
                    End If
                    i = i + 1
                Next
            Else
                ' NO ROWS RETURNED
            End If
        Catch ex As Exception
            MessageBox.Show("Read exception: " & ex.Message)
        End Try
    End Sub

    Private Sub GetUserLocalData()
        ' Download Local User data
        LocalDataInitCheck(_user.Id, _user.Passwd)
        ' After download create MySQL Instance
        Common.SqliteManager = New SQLiteManager
    End Sub

    Public Property IAccesibleMultiThread_NeedExecute() As Boolean Implements IAccesibleMultiThread.NeedExecute

    Public Sub ExecuteMethod(ByVal method As [Delegate], ParamArray args As Object()) Implements IAccesibleMultiThread.ExecuteMethod
        ChatList.Invoke(method, args)
    End Sub

    Public Sub AddComponent(ByVal request As ClientRequest) Implements IAccesibleMultiThread.AddComponent
        ChatList.AddChatBox(request.Message, AlignedTo.Left)
    End Sub
End Class