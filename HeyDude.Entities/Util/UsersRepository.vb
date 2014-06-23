Imports DataAccess

Namespace Util

    Public Module UsersRepository
        Public Sub Alta(ByVal usrName As String, ByVal email As String, ByVal fullName As String, ByVal pass As String, ByVal img As String)
            Dim context = New ChatProjectEntities()
            context.users.Add(New DataAccess.user With {
                                 .uid = usrName,
                                 .email = email,
                                 .full_name = fullName,
                                 .password = pass,
                                 .profile_img = img})
            context.SaveChanges()
        End Sub

        Public Function AddFriend(ByVal userId As Integer, ByVal friendGuid As String)
            Dim usr = GetUser(friendGuid)

            If usr Is Nothing Then Return False

            Using context = New ChatProjectEntities()
                context.user_friends.Add(New user_friends With {
                                         .friend_of = userId,
                                         .friend_to = usr.id})

                context.user_friends.Add(New user_friends With {
                                         .friend_of = usr.id,
                                         .friend_to = userId})
                context.SaveChanges()
            End Using
            Return True
        End Function

        Private Function GetUser(ByVal userGuid As String) As DataAccess.user
            Using context = New ChatProjectEntities
                Try
                    Return context.users.Single(Function(usr) usr.uid = userGuid)
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        End Function
    End Module
End Namespace