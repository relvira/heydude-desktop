Imports System.Data.SQLite

Public Class SQLiteManager
    Dim connection As SQLiteConnection
    Public Sub New()
        Try
            Me.Connect()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Connect()
        Try
            connection = New SQLiteConnection("Data Source=sqlite/heydude.db")
            ' Set sqlite password sha-1 generated + our own salt (more secure) :)
            'connection.SetPassword(GetSha1Hash("H3yDud3R0ckZzZDud3") & "sT1llRoCksNiGGa")
            connection.Open()
        Catch ex As SQLiteException
            MessageBox.Show("Fallo al conectar a sqlite: " & ex.Message)
        End Try
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

    Public Sub Close()
        connection.Close()
    End Sub

End Class