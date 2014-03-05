Imports System.Data.SQLite
Public Class SQLiteManager
    Dim connection As SQLiteConnection
    Public Sub New()
        Me.Connect()
    End Sub

    Private Sub Connect()
        connection = New SQLiteConnection("Data Source=sqlite/heydude.db")
    End Sub

    Public Function ExecuteNoQuery(ByVal SqlStatement As String)
        Dim sqlCommand As New SQLiteCommand
        sqlCommand.CommandText = SqlStatement
        sqlCommand.Connection = connection

        Try
            sqlCommand.ExecuteNonQuery()
        Catch ex As SQLiteException
            MsgBox(ex.Message.ToString)
            Return False
        Finally
            connection.Close()
        End Try
        Return True
    End Function

    Public Function ExecuteQuery(ByVal SqlStatement As String, ByVal tableName As String) As DataTable
        Try
            Dim oDataAdapter As New SQLiteDataAdapter(SqlStatement, connection)
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
        Catch ex As SQLiteException
            Return New DataTable
        End Try
    End Function


End Class
