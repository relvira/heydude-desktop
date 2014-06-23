Imports DataAccess

Namespace Util

    Public Module UsersRepository
        Public Sub Alta(ByVal usrName As String, ByVal email As String, ByVal fullName As String, ByVal pass As String, ByVal img As String)
            Dim context = New ChatProjectEntities()
            context.users.Add(New DataAccess.user With {
                                 .id = usrName,
                                 .email = email,
                                 .full_name = fullName,
                                 .password = pass,
                                 .profile_img = img})
            context.SaveChanges()
        End Sub
    End Module
End Namespace