Imports ChatClient.CustomComponents
Imports ChatClient.User
Imports ChatClient.Common

Namespace UI
    Public Class FrmHeyDude
        Private ReadOnly _mUser As ClientData
        Private ReadOnly _mUserBuffer As New ClientBuffer(Me)
        Private ReadOnly _mRequest As ClientRequest
        Private ReadOnly _mFriends As New ArrayList


        Public Sub New()
            ' Llamada necesaria para el diseñador.
            InitializeComponent()
        End Sub

        Public Sub New(ByVal pUser As ClientData)
            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Other calls
            _mUser = pUser
            _mFriends = pUser.GetUserAllFriends(pUser.Id)
            _mRequest = New ClientRequest(pUser.Id, Protocol.Connect)
            _mUserBuffer.SendRequest(_mRequest)
        End Sub

        Private Sub FrmHeyDude_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            ' Hide Login form
            FrmLogin.Hide()

            ' Load User friends
            For Each frnd As String In _mFriends
                Dim f As String() = frnd.ToString.Split(",")
                UserList.AddUserBox(New ClientData(f(0), f(2), f(4), f(3)))
            Next

            ' Before loading form, get all user local data
            getUserLocalData()
        End Sub

        Private Sub FrmHeyDude_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
            _mRequest.FromId = _mUser.Id
            _mRequest.Protocol = Protocol.Disconnect
            _mUserBuffer.SendRequest(_mRequest)

            UploadUserLocalData(_mUser.Id)

            FrmLogin.Close()
        End Sub

        Private Sub ToolBar_OnCloseButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBar.OnCloseButtonClick
            Close()
        End Sub

        Private Sub FrmHeyDude_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(213, 213, 213), ButtonBorderStyle.Solid)
        End Sub

        Private Sub SendMessage(ByVal e As KeyPressEventArgs) Handles TextBoxHD.OnIntroPressed
            If TextBoxHD.Message.Length > 1 And TitleChatList.Id <> 0 Then
                ChatList.AddChatBox(TextBoxHD.Message, AlignedTo.Right)
                SaveMessage(_mUser.Id, TitleChatList.Id, TextBoxHD.Message)
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
            _mRequest.FromId = _mUser.Id
            _mRequest.Protocol = Protocol.SendMessage
            '_mRequest.ToId = _mUser.Id
            _mRequest.ToId = TitleChatList.Id
            _mRequest.Message = TextBoxHD.Message

            _mUserBuffer.SendRequest(_mRequest)
        End Sub

        Private Sub RefreshMessageHistory()
            ' THERE ARE OLD MESSAGES? PRINT EM NIGGA!
            Dim i As Integer = 0
            Try
                Dim queryResult = _mSqliteManager.ExecuteQuery("SELECT from_id, to_id, message, timestamp FROM messages WHERE from_id=" & TitleChatList.Id & " OR to_id=" & TitleChatList.Id & " ORDER BY timestamp ASC;", "messages")
                If queryResult.Rows.Count > 0 Then
                    For Each oDataRow as DataRow In queryResult.Rows
                        If queryResult.Rows(i)("from_id") = TitleChatList.Id Then
                            ' From other messages
                            ChatList.AddChatBox(queryResult.Rows(i)("message"), AlignedTo.Left, queryResult.Rows(i)("timestamp"))
                        ElseIf queryResult.Rows(i)("from_id") = _mUser.Id Then
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

        Private Sub getUserLocalData()
            ' Download Local User data
            LocalDataInitCheck(_mUser.Id, _mUser.Passwd)
            ' After download create MySQL Instance
            _mSqliteManager = New SQLiteManager
        End Sub
    End Class
End Namespace