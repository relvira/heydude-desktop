Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Specialized
Imports System.Security.Cryptography
Imports DataAccess.Managers
Imports System.Windows.Forms
Imports Entities.UserComponents

Public Module Common
    Public SqliteManager As SQLiteManager

    Public Function UserLogin(ByVal user As String, ByVal password As String)
        Dim sqlManager As New MySQLManager
        Dim queryResult = sqlManager.ExecuteQuery("SELECT id, uid, password, email, full_name, profile_img, user_status FROM user where uid='" & user & "'", "user")

        Dim i As Integer = 0
        Dim userItem As New PersonalData

        If queryResult.Rows.Count > 0 Then
            For Each oDataRow In queryResult.Rows

                If queryResult.Rows(i)("uid") = user And queryResult.Rows(i)("password") = GetSha1Hash(password) Then
                    userItem.Id = queryResult.Rows(i)("id")
                    userItem.Passwd = queryResult.Rows(i)("password")
                    userItem.Name = queryResult.Rows(i)("uid")
                    userItem.Email = queryResult.Rows(i)("email")
                    userItem.FullName = queryResult.Rows(i)("full_name")
                    userItem.ImageSource = queryResult.Rows(i)("profile_img")
                    userItem.StateMessage = queryResult.Rows(i)("user_status")
                    userItem.IsLoggedIn = True
                    Exit For
                Else
                    userItem.IsLoggedIn = False
                End If
                i = i + 1
            Next
        Else
            userItem.IsLoggedIn = False
        End If
        Return userItem
    End Function

    Function IsEmail(ByVal email As String) As Boolean
        Static emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")

        Return emailExpression.IsMatch(email)
    End Function

    Function GetSha1Hash(ByVal strToHash As String) As String

        Dim sha1Obj As New SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        ' TODO: Convertir a LinQ
        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult
    End Function

    ' TODO: Descomentar!!!
    'Function UploadUserLocalData(ByVal uid As String)
    '    SqliteManager.Close()
    '    Const sqLitePath As String = "sqlite/heydude.db"
    '    Try
    '        'Upload image!
    '        ServicePointManager.Expect100Continue = False
    '        Dim uploadServer = DynamicServer & "sqliteUpload.php?uid=" & uid

    '        Dim webp As New WebProxy("192.168.255.1", 3128)
    '        webp.UseDefaultCredentials = True

    '        Dim webcl As New WebClient()
    '        'webcl.Proxy = webp
    '        webcl.UploadFile(uploadServer, sqLitePath)

    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    Private Function DownloadUserLocalFromServer(ByVal id As Integer, Optional ByVal passwd As String = "")
        Const sqLitePath As String = "sqlite/heydude.db"
        Try
            ServicePointManager.Expect100Continue = False
            ServicePointManager.Expect100Continue = False
            Const downloadServer As String = DynamicServer & "downloadSqlite.php"

            Dim webcl As New WebClient()

            'params
            Dim reqparm As New NameValueCollection
            reqparm.Add("id", id)
            reqparm.Add("passwd", passwd)

            Dim responsebytes = webcl.UploadValues(downloadServer, "POST", reqparm)

            Try
                Dim oBin As New BinaryWriter(New FileStream(sqLitePath, FileMode.OpenOrCreate))
                oBin.Write(responsebytes)
                oBin.Close()
            Catch ex As Exception

            End Try

            Dim mFileInfo As New FileInfo(sqLitePath)
            ' If file recieved is 1kb
            If mFileInfo.Length < 62 Then
                File.Delete(sqLitePath)
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub SaveMessage(ByVal fromUser As Integer, ByVal toUser As Integer, ByVal message As String)
        ' Save this shit in SQLite
        Try
            Dim messageStatement = "INSERT INTO messages(from_id, to_id, message) VALUES(" & fromUser & ", " & toUser & " ,'" & message & "');"
            SqliteManager.ExecuteNoQuery(messageStatement)
        Catch ex As Exception
            MessageBox.Show("DB error: " & ex.Message)
        End Try
    End Sub

    Public Sub LocalDataInitCheck(ByVal id As Integer, Optional ByVal passwd As String = "")
        If File.Exists("sqlite/heydude.db") Then
            ' Este cliente ya tiene sqlite local, descargamos la ultima version del servidor
            DownloadUserLocalFromServer(id, passwd)
        Else
            Dim mHasVersion As Boolean = DownloadUserLocalFromServer(id, passwd)
            ' El usuario no tiene sqlite local, tiene alguno en el servidor?
            If mHasVersion Then
                ' No tiene version en local de sqlite per si en el servidor, la descargamos
                DownloadUserLocalFromServer(id, passwd)
            Else
                ' Si no tiene en el servidor tampoco descargamos el de por defecto
                DownloadDefaultUserLocalSqlite()
            End If
        End If
    End Sub

    Private Function DownloadDefaultUserLocalSqlite()
        Const sqLiteSavePath As String = "sqlite/heydude.db"
        Try
            ' Descargar base de datos por defecto (vacia)
            ServicePointManager.Expect100Continue = False
            Const downloadServer As String = StaticServer & "default.db"

            Dim webcl As New WebClient()
            webcl.DownloadFile(downloadServer, sqLiteSavePath)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UserExists(ByVal user As String)
        Dim sqlManager As New MySQLManager
        Dim queryResult = sqlManager.ExecuteQuery("SELECT id, uid, password, email, full_name, profile_img, user_status FROM user where uid='" & user & "'", "user")

        If queryResult.Rows.Count > 0 Then
            Return queryResult.Rows(0)("id")
        Else
            Return 0
        End If
        Return 0
    End Function

    Public Function AddUserToFriendList(ByVal userToAdd As String, ByVal RequesterUser As String)
        Dim isUserInDB As Integer = UserExists(userToAdd)
        Dim RequesterUserId As Integer = UserExists(RequesterUser)
        If isUserInDB <> 0 Then
            Try
                ' Insert userdata in database 
                Dim registerUser As New MySQLManager
                Dim statementGenerated = "INSERT INTO user_friends(friend_of, friend_to) VALUES('" & RequesterUser & "','" & isUserInDB & "');"
                Dim result = registerUser.ExecuteNoQuery(statementGenerated)

                statementGenerated = "INSERT INTO user_friends(friend_of, friend_to) VALUES('" & isUserInDB & "','" & RequesterUser & "');"
                result = registerUser.ExecuteNoQuery(statementGenerated)
                Return True
            Catch ex As Exception

            End Try
        Else
            Return False
        End If
        Return False
    End Function
End Module
