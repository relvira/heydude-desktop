Imports System.Data.SQLite

Namespace Managers
    Public Class SqLiteManager
        Private _sqliteInstance As SQLiteConnection
        Public Sub New()
            Try
                Connect()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Sub Connect()
            Try
                _sqliteInstance = New SQLiteConnection("Data Source=heydude.db")
                _sqliteInstance.Open()
            Catch ex As SQLiteException
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Public Sub SaveMessage(ByVal msg As Message)
            ExecuteQuery("INSERT INTO messages(from_id, to_id, message) " & _
                           "VALUES(" & msg.FromUser & ", " & msg.ToUser & ", '" & msg.Message & "');")
        End Sub

        Public Function GetAll(ByVal fromUser As Integer, ByVal toUser As Integer)
            Dim queryResult = "SELECT from_id, to_id, message, timestamp FROM messages " & _
                "WHERE from_id=" & fromUser & " OR to_id=" & toUser & " " & _
                "ORDER BY timestamp ASC;"
            Dim i As Integer = 0
            Try
                Dim queryResult = ExecuteQuery("SELECT from_id, to_id, message, timestamp FROM messages WHERE from_id=" & TitleChatList.Id & " OR to_id=" & TitleChatList.Id & " ORDER BY timestamp ASC;", "messages")
                If queryResult.Rows.Count > 0 Then
                    For Each oDataRow In queryResult.Rows
                        If queryResult.Rows(i)("from_id") = TitleChatList.Id Then
                            ' From other messages
                            ChatList.AddChatBox(queryResult.Rows(i)("message"), AlignedTo.Left, queryResult.Rows(i)("timestamp"))
                        ElseIf queryResult.Rows(i)("from_id") = user.PersonalData.Id Then
                            ' Messages from me to others
                            ChatList.AddChatBox(queryResult.Rows(i)("message"), AlignedTo.Right, queryResult.Rows(i)("timestamp"))
                        End If
                        i = i + 1
                    Next
                Else
                    ' NO ROWS RETURNED
                End If
            Catch ex As Exception
                MessageBox.Show(ReadException & ex.Message)
            End Try
        End Function

        Private Sub ExecuteQuery(ByVal sqlStatement As String)
            Try
                Return New SQLiteCommand() With {
                    .CommandText = sqlStatement,
                    .Connection = _sqliteInstance} _
                .ExecuteNonQuery()
            Catch ex As SQLiteException
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Public Sub Close()
            _sqliteInstance.Close()
        End Sub
    End Class
End Namespace