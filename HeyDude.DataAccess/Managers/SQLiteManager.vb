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

        Public Function GetAll(ByVal fromUser As Integer, ByVal toUser As Integer) As List(Of Message)
            Dim queryResult = ExecuteQuery("SELECT * FROM messages WHERE (from_id=" & fromUser & " OR from_id=" & toUser & ") and ( to_id=" & fromUser & " or to_id=" & toUser & ") ORDER BY timestamp ASC;", "messages")

            If queryResult.Rows.Count = 0 Then Return New List(Of Message)

            Return (From msgRow As Object In queryResult.Rows Select New Message() With {
                                .FromUser = msgRow("from_id"),
                                .ToUser = msgRow("to_id"),
                                .Message = msgRow("message"),
                                .HourSent = msgRow("timestamp")
                                }) _
                        .ToList()
        End Function

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

        Private Function ExecuteQuery(ByVal sqlStatement As String, ByVal tableName As String) As DataTable
            Try
                Dim oDataAdapter As New SQLiteDataAdapter(sqlStatement, _sqliteInstance)
                Dim oDataSet As New DataSet
                oDataAdapter.Fill(oDataSet, tableName)

                If oDataSet.Tables(tableName).Rows.Count > 0 Then
                    Return oDataSet.Tables(tableName).Rows(0).Table
                End If
            Catch ex As SQLiteException
                Console.WriteLine(ex.Message)
            End Try
            Return New DataTable
        End Function

        Public Sub Close()
            _sqliteInstance.Cancel()
            _sqliteInstance.Close()
        End Sub
    End Class
End Namespace