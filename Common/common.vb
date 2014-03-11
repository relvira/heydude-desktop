﻿Imports System.Text.RegularExpressions
Imports ChatClient.User
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Imports System.IO

Namespace Common

    Module Common
        Public Function UserLogin(ByVal user As String, ByVal password As String)
            Dim sqlManager As New MySQLManager
            Dim queryResult = sqlManager.ExecuteQuery("SELECT id, uid, password, email, full_name, profile_img, user_status FROM user where uid='" & User & "'", "user")

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
            Dim SQLitePath = "sqlite/heydude.db"
            Try

                'Upload image!
                ServicePointManager.Expect100Continue = False
                Dim uploadServer = DynamicServer & "sqliteUpload.php?uid=" & uid

                Dim webp As New WebProxy("192.168.255.1", 3128)
                webp.UseDefaultCredentials = True

                Dim webcl As New WebClient()
                webcl.Proxy = webp
                webcl.UploadFile(uploadServer, SQLitePath)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ' This is not very secure.... :S
        Function DownloadUserLocalFromServer(ByVal id As Integer, Optional ByVal passwd As String = "")
            Dim SQLitePath = "sqlite/heydude.db"
            Try
                ServicePointManager.Expect100Continue = False
                System.Net.ServicePointManager.Expect100Continue = False
                MessageBox.Show(ServicePointManager.Expect100Continue)
                Dim downloadServer = DynamicServer & "downloadSqlite.php"

                Dim webp As New WebProxy("192.168.255.1", 3128)
                webp.UseDefaultCredentials = True

                Dim webcl As New WebClient()
                webcl.Proxy = webp

                'params
                Dim reqparm As New Specialized.NameValueCollection
                reqparm.Add("id", id)
                reqparm.Add("passwd", passwd)

                Dim responsebytes = webcl.UploadValues(downloadServer, "POST", reqparm)

                Try
                    Dim oBin As New BinaryWriter(New FileStream(SQLitePath, FileMode.CreateNew))
                    oBin.Write(responsebytes)
                    oBin.Close()
                    oBin = Nothing
                Catch ex As Exception

                End Try

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Module
End Namespace