Imports ChatClient.CustomComponents
Imports ChatClient.User
Imports ChatClient.Common

Namespace UI
    Public Class FrmHeyDude
        Private ReadOnly _mCurrentUser As ClientData
        Private ReadOnly _mCurrentUserBuffer As New ClientBuffer(Me)
        Private ReadOnly _mFriends As New ArrayList
        Private sqliteManager As SQLiteManager

        Public ReadOnly Property Instance() As FrmHeyDude
            Get
                Return Me
            End Get
        End Property
        
        Public Sub New()
            ' Llamada necesaria para el diseñador.
            InitializeComponent()
        End Sub

        Public Sub New(ByVal userItem As ClientData)
            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Other calls
            _mCurrentUser = userItem
            _mFriends = _mCurrentUser.GetUserAllFriends(_mCurrentUser.Id)

        End Sub

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)

            ' Hide Login form
            FrmLogin.Hide()

            For Each frnd In _mFriends
                Dim f = frnd.ToString.Split(",")
                UserList.AddUserBox(New ClientData(f(0), f(2), f(4), f(3)))
            Next

            _mCurrentUserBuffer.SendRequest(New ClientRequest(_mCurrentUser.Id, Protocol.Connect))
            AddHandler _mCurrentUserBuffer.OnMessageRecived, AddressOf OnMessageReceived
            AsyncTask.RunWorkerAsync()

            ' Download Local User data
            'Common.downloadUserLocalFromServer(_mCurrentUser.Id, _mCurrentUser.Passwd)
            'sqliteManager = New SQLiteManager
        End Sub

        Private Sub OnMessageReceived(ByVal pRequest As String)
            CheckForIllegalCrossThreadCalls = False
            SyncLock Me
                MessageBox.Show(pRequest)
                Console.WriteLine("evento on msgrecieved")
                ChatList.AddChatBox(pRequest, AlignedTo.Left)
            End SyncLock
        End Sub

        Private Sub SendMessage(ByVal e As KeyPressEventArgs) Handles TextBoxHD.OnIntroPressed
            'If TextBoxHD.Message.Length > 1 And TitleChatList.Id <> 0 Then
            ChatList.AddChatBox(TextBoxHD.Message, AlignedTo.Right)

            ' Save this shit in SQLite
            'Try
            '    Dim messageStatement = "INSERT INTO messages(from_id, to_id, message) VALUES(" & _mCurrentUser.Id & ", " & TitleChatList.Id & " ,'" & TextBoxHD.Message & "');"
            '    Dim result = sqliteManager.ExecuteNoQuery(messageStatement)
            'Catch ex As Exception
            '    MessageBox.Show("DB error: " & ex.Message)
            'End Try

            ' WORK REAL SEND MESSAGE TO SERVER HERE
            _mCurrentUserBuffer.SendRequest(New ClientRequest(_mCurrentUser.Id, Protocol.SendMessage, _mCurrentUser.Id, TextBoxHD.Message))

            'AsyncTask.ReportProgress(100, TextBoxHD.Message)

            TextBoxHD.Message = ""
            'End If
        End Sub

        Private Sub UserSelectedChanged(ByVal pUserBox As UserBox) Handles UserList.UserSelectedChanged
            ' @TODO: Clean messages zone!!!!!
            ChatList.Clean()
            TitleChatList.UserName = pUserBox.UserName
            TitleChatList.Id = pUserBox.Id

            ' THERE ARE OLD MESSAGES? PRINT EM NIGGA!
            Dim i As Integer = 0
            'Try
            '    Dim queryResult = sqliteManager.ExecuteQuery("SELECT from_id, to_id, message, timestamp FROM messages WHERE from_id=" & TitleChatList.Id & " OR to_id=" & TitleChatList.Id & " ORDER BY timestamp ASC;", "messages")
            '    If queryResult.Rows.Count > 0 Then
            '        For Each oDataRow In queryResult.Rows
            '            If queryResult.Rows(i)("from_id") = TitleChatList.Id Then
            '                ' From other messages
            '                ChatList.AddChatBox(queryResult.Rows(i)("message"), AlignedTo.Left, queryResult.Rows(i)("timestamp"))
            '            ElseIf queryResult.Rows(i)("from_id") = _mCurrentUser.Id Then
            '                ' Messages from me to others
            '                ChatList.AddChatBox(queryResult.Rows(i)("message"), AlignedTo.Right, queryResult.Rows(i)("timestamp"))
            '            End If
            '            i = i + 1
            '        Next
            '    Else
            '        ' NO ROWS RETURNED
            '    End If
            'Catch ex As Exception
            '    MessageBox.Show("Read exception" & ex.Message)
            'End Try
        End Sub

        Private Sub ToolBar_OnCloseButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBar.OnCloseButtonClick
            Close()
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(213, 213, 213), ButtonBorderStyle.Solid)
        End Sub

        Private Sub ChatList_Load(ByVal sender As Object, ByVal e As EventArgs) Handles ChatList.Load

        End Sub


        Private Sub FrmHeyDude_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            'sqliteManager.Close()
            Common.uploadUserLocalData(_mCurrentUser.Id)
            FrmLogin.Close()
        End Sub

        Public Sub MessageRecievedRequest(ByVal clientRequest As ClientRequest)
            OnMessageReceived(clientRequest.Message)
            ' ChatList.AddChatBox(clientRequest.Message, AlignedTo.Left)
        End Sub

        Private Sub AsyncTask_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles AsyncTask.ProgressChanged
            ChatList.AddChatBox(e.UserState.ToString(), AlignedTo.Left)
        End Sub

        Private Sub AsyncTask_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles AsyncTask.DoWork
            _mCurrentUserBuffer.RecieveRequest()
            'Dim request As ClientRequest
            'While True
            '    request = _mCurrentUserBuffer.ReadRequest()
            '    Try
            '        Select Case request.Protocol
            '            Case Protocol.Connect
            '            Case Protocol.SendMessage
            '            Case Protocol.ReceiveMessage
            '                AsyncTask.ReportProgress(100, request.Message)
            '                'RaiseRequest(request)
            '            Case Protocol.Disconnect
            '        End Select
            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message)
            '        Finalize()
            '    End Try
            'End While
        End Sub
    End Class
End Namespace