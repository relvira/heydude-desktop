Imports System.Text.RegularExpressions
Imports System.Net
Imports System.IO

Module common
    Public Function UserLogin(ByVal User As String, ByVal Password As String)
        Dim sqlManager As New MySQLManager
        Dim queryResult = sqlManager.ExecuteQuery("SELECT id, uid, password, email, full_name, profile_img, user_status FROM user where uid='" & User & "'", "user")

        Dim i As Integer = 0
        Dim UserItem As New ClientData
        'If queryResult = False Then
        '    UserItem.isLoggedIn = False
        'End If

        For Each oDataRow In queryResult.Rows

            If queryResult.Rows(i)("uid") = User And queryResult.Rows(i)("password") = getSHA1Hash(Password) Then
                UserItem.Id = queryResult.Rows(i)("id")
                UserItem.Name = queryResult.Rows(i)("uid")
                UserItem.Email = queryResult.Rows(i)("email")
                UserItem.FullName = queryResult.Rows(i)("full_name")
                UserItem.ImageSource = queryResult.Rows(i)("profile_img")
                UserItem.StateMessage = queryResult.Rows(i)("user_status")
                UserItem.isLoggedIn = True
                Exit For
            Else

            End If
            i = i + 1
        Next
        Return UserItem
    End Function

    Function IsEmail(ByVal email As String) As Boolean
        Static emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")

        Return emailExpression.IsMatch(email)
    End Function

    Function getSHA1Hash(ByVal strToHash As String) As String

        Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult

    End Function
End Module
