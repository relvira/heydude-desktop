Module common
    Public Function UserLogin(ByVal User As String, ByVal Password As String)
        Dim sqlManager As New MySQLManager
        Dim queryResult = sqlManager.ExecuteQuery("SELECT id, uid, password, email, full_name, profile_img, user_status FROM user where uid='" & User & "'", "user")

        Dim i As Integer = 0

        For Each oDataRow In queryResult.Rows
            If queryResult.Rows(i)("uid") = User And queryResult.Rows(i)("password") = Password Then
                Dim UserItem As New ClientData
                UserItem.Id = queryResult.Rows(i)("id")
                UserItem.Name = queryResult.Rows(i)("uid")
                UserItem.Email = queryResult.Rows(i)("email")
                UserItem.FullName = queryResult.Rows(i)("full_name")
                UserItem.ImageSource = queryResult.Rows(i)("profile_img")
                UserItem.StateMessage = queryResult.Rows(i)("user_status")
                UserItem.isLoggedIn = True
                Return UserItem
            Else
                FrmLogin.LblLoginError.Enabled = True
            End If
            i = i + 1
        Next
        Return True
    End Function
End Module
