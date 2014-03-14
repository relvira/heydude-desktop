Imports MySql.Data.MySqlClient

Namespace Common
    Public Class MySQLManager
        Private connection As New MySqlConnection
        Dim Server As String = MySQLServer
        Dim Port As String = "3306"
        Dim DBUser As String = "project_user"
        Dim DBPasswd As String = "$$JoYf3FTWNiGGa$$"
        Dim Database As String = "chat_project"

        Public Sub New(ByVal Server As String, ByVal Port As String, ByVal DBUser As String, ByVal DBPasswd As String, ByVal Database As String)
            Me.Server = Server
            Me.Port = Port
            Me.DBUser = DBUser
            Me.DBPasswd = DBPasswd
            Me.Database = Database

            Me.Connect()
        End Sub

        Public Sub New(ByVal Database As String)
            Me.Database = Database
            Me.Connect()
        End Sub

        Public Sub New()
            Me.Connect()
        End Sub

        ' Database connect method
        Public Function Connect()
            Try
                connection.ConnectionString =
                    "server=" & Server & ";" &
                    "user id=" & DBUser & ";" &
                    "password=" & DBPasswd & ";" &
                    "port=" & Port & ";" &
                    "database=" & Database & ";"

                connection.Open()
            Catch ex As Exception
                MessageBox.Show("Error al conectar al servidor MySQL: " & ex.Message)
                Return False
            End Try
            Return True
        End Function


        ' Function to query the database, returns an ArrayList if we 
        Public Function ExecuteQuery(ByVal SqlStatement As String, ByVal tableName As String) As DataTable
            Try
                Dim oDataAdapter As New MySqlDataAdapter(SqlStatement, connection)
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
        Public Function ExecuteNoQuery(ByVal SqlStatement As String) As Boolean
            Dim sqlCommand As New MySqlCommand()
            sqlCommand.CommandText = SqlStatement
            sqlCommand.Connection = connection

            Try
                sqlCommand.ExecuteNonQuery()
            Catch ex As MySqlException
                MsgBox(ex.Message.ToString)
                Return False
            Finally
                connection.Close()
            End Try
            Return True
        End Function

        ' Database connection close method
        Public Sub Close()
            connection.Close()
        End Sub
    End Class
End Namespace