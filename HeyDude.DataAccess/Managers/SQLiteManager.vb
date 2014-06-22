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

        Private Sub ExecuteQuery(ByVal sqlStatement As String)
            Try
                Call New SQLiteCommand() With {
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