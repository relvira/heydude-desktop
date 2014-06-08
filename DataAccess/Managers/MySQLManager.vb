Imports MySql.Data.MySqlClient

Namespace Managers
    Public Class MySQLManager
        Private ReadOnly _connection As New MySqlConnection
        Private Const Server As String = MySQLServer
        Private Const Port As String = "3306"
        Private Const DbUser As String = "project_user"
        Private Const DbPasswd As String = "$$JoYf3FTWNiGGa$$"
        Private Const Database As String = "chat_project"

        'Public Sub New(ByVal server As String, ByVal port As String, ByVal dbUser As String, ByVal dbPasswd As String, ByVal database As String)
        '    _server = server
        '    _port = port
        '    _dbUser = dbUser
        '    _dbPasswd = dbPasswd
        '    _database = database

        '    Connect()
        'End Sub

        'Public Sub New(ByVal database As String)
        '    _database = Database
        '    Connect()
        'End Sub

        Public Sub New()
            Connect()
        End Sub

        ' Database connect method
        Private Function Connect()
            Try
                _connection.ConnectionString =
                    "server=" & Server & ";" &
                    "user id=" & DbUser & ";" &
                    "password=" & DbPasswd & ";" &
                    "port=" & Port & ";" &
                    "database=" & Database & ";"

                _connection.Open()
            Catch ex As Exception
                MessageBox.Show("Error al conectar al servidor MySQL: " & ex.Message)
                Return False
            End Try
            Return True
        End Function


        ' Function to query the database, returns an ArrayList if we 
        Public Function ExecuteQuery(ByVal sqlStatement As String, ByVal tableName As String) As DataTable
            Try
                Dim oDataAdapter As New MySqlDataAdapter(sqlStatement, _connection)
                Dim oDataSet As New DataSet
                Dim myTable As DataTable
                oDataAdapter.Fill(oDataSet, tableName)

                If oDataSet.Tables(tableName).Rows.Count > 0 Then
                    Dim oDataRow As DataRow = oDataSet.Tables(tableName).Rows(0)
                    myTable = oDataRow.Table
                    Return myTable
                Else
                    Return New DataTable
                End If
            Catch ex As MySqlException
                Return New DataTable
            End Try
        End Function

        ' Method to execute commands that aren't a query (insert, update, delete,...)
        Public Function ExecuteNoQuery(ByVal sqlStatement As String) As Boolean
            Dim sqlCommand As New MySqlCommand()
            sqlCommand.CommandText = sqlStatement
            sqlCommand.Connection = _connection

            Try
                sqlCommand.ExecuteNonQuery()
            Catch ex As MySqlException
                MsgBox(ex.Message.ToString)
                Return False
            Finally
                _connection.Close()
            End Try
            Return True
        End Function

        ' Database connection close method
        Public Sub Close()
            _connection.Close()
        End Sub
    End Class
End Namespace