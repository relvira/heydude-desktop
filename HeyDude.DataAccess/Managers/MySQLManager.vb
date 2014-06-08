Imports System.Configuration
Imports MySql.Data.MySqlClient

Namespace Managers
    Public Class MySQLManager
        Private ReadOnly _connection As New MySqlConnection

        Public Sub New()
            Connect()
        End Sub

        Private Function Connect()
            Try
                _connection.ConnectionString = ConfigurationManager.ConnectionStrings("MySQL").ConnectionString
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
                Close()
            End Try
            Return True
        End Function

        ' Database connection close method
        Private Sub Close()
            _connection.Close()
        End Sub
    End Class
End Namespace