Imports System.Text.RegularExpressions
Imports ChatClient.User
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Imports System.IO

Namespace Common
    Module Common
        Public _mSqliteManager As SQLiteManager

        Public Function UserLogin(ByVal user As String, ByVal password As String)
            Dim sqlManager As New MySQLManager
            Dim queryResult = sqlManager.ExecuteQuery("SELECT id, uid, password, email, full_name, profile_img, user_status FROM user where uid='" & user & "'", "user")

            Dim i As Integer = 0
            Dim userItem As New ClientData

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
                        userItem.isLoggedIn = True
                        Exit For
                    Else
                        userItem.isLoggedIn = False
                    End If
                    i = i + 1
                Next
            Else
                userItem.isLoggedIn = False
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

            For Each b As Byte In bytesToHash
                strResult += b.ToString("x2")
            Next

            Return strResult

        End Function

        Function UploadUserLocalData(ByVal uid As String)
            _mSqliteManager.Close()
            Dim SQLitePath = "sqlite/heydude.db"
            Try

                'Upload image!
                ServicePointManager.Expect100Continue = False
                Dim uploadServer = DynamicServer & "sqliteUpload.php?uid=" & uid

                Dim webp As New WebProxy("192.168.255.1", 3128)
                webp.UseDefaultCredentials = True

                Dim webcl As New WebClient()
                'webcl.Proxy = webp
                webcl.UploadFile(uploadServer, SQLitePath)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Function DownloadUserLocalFromServer(ByVal id As Integer, Optional ByVal passwd As String = "")
            Dim SQLitePath = "sqlite/heydude.db"
            Try
                ServicePointManager.Expect100Continue = False
                System.Net.ServicePointManager.Expect100Continue = False
                Dim downloadServer = DynamicServer & "downloadSqlite.php"

                Dim webcl As New WebClient()

                'params
                Dim reqparm As New Specialized.NameValueCollection
                reqparm.Add("id", id)
                reqparm.Add("passwd", passwd)

                Dim responsebytes = webcl.UploadValues(downloadServer, "POST", reqparm)

                Try
                    Dim oBin As New BinaryWriter(New FileStream(SQLitePath, FileMode.OpenOrCreate))
                    oBin.Write(responsebytes)
                    oBin.Close()
                    oBin = Nothing
                Catch ex As Exception

                End Try

                Dim _mFileInfo As New FileInfo(SQLitePath)
                ' If file recieved is 1kb
                If _mFileInfo.Length < 62 Then
                    File.Delete(SQLitePath)
                    Return False
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Sub SaveMessage(ByVal _pFrom As Integer, ByVal _pTo As Integer, ByVal _pMessage As String)
            ' Save this shit in SQLite
            Try
                Dim messageStatement = "INSERT INTO messages(from_id, to_id, message) VALUES(" & _pFrom & ", " & _pTo & " ,'" & _pMessage & "');"
                Dim result = _mSqliteManager.ExecuteNoQuery(messageStatement)
            Catch ex As Exception
                MessageBox.Show("DB error: " & ex.Message)
            End Try
        End Sub

        Public Sub LocalDataInitCheck(ByVal id As Integer, Optional ByVal passwd As String = "")
            If File.Exists("sqlite/heydude.db") Then
                ' Este cliente ya tiene sqlite local, descargamos la ultima version del servidor
                DownloadUserLocalFromServer(id, passwd)
            Else
                Dim _mHasVersion As Boolean = DownloadUserLocalFromServer(id, passwd)
                ' El usuario no tiene sqlite local, tiene alguno en el servidor?
                If _mHasVersion Then
                    ' No tiene version en local de sqlite per si en el servidor, la descargamos
                    DownloadUserLocalFromServer(id, passwd)
                Else
                    ' Si no tiene en el servidor tampoco descargamos el de por defecto
                    DownloadDefaultUserLocalSqlite(id, passwd)
                End If
            End If
        End Sub

        Function DownloadDefaultUserLocalSqlite(ByVal id As Integer, Optional ByVal passwd As String = "")
            Dim SQLiteSavePath = "sqlite/heydude.db"
            Try

                ' Descargar base de datos por defecto (vacia)
                ServicePointManager.Expect100Continue = False
                Dim _mDownloadServer = StaticServer & "default.db"

                Dim webcl As New WebClient()
                webcl.DownloadFile(_mDownloadServer, SQLiteSavePath)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Module
End Namespace