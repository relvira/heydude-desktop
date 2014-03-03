Imports MySql.Data.MySqlClient
Public Class MySQLManager
    Private connection As New MySqlConnection
    Dim Server As String = "localhost"
    Dim Port As String = "3306"
    Dim DBUser As String = "root"
    Dim DBPasswd As String = "joyfe"
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

    ''' <summary>
    ''' Database connect method
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Connect()
        Try
            connection.ConnectionString =
                "server=" & Server & ";" &
                "user id=" & DBUser & ";" &
                "password=" & DBPasswd & ";" &
                "port=" & Port & ";" &
                "database=" & Database & ";"

            connection.Open()
            'MessageBox.Show("Connected to database!")

        Catch ex As Exception
            MessageBox.Show("Error al conectar al servidor MySQL: " & ex.Message)
            Return False
        End Try
        Return True
    End Function


    ''' <summary>
    ''' Function to query the database, returns an ArrayList if we 
    ''' </summary>
    ''' <param name="SqlStatement"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecuteQuery(ByVal SqlStatement As String, ByVal tableName As String) As DataTable
        Dim oDataAdapter As New MySqlDataAdapter(SqlStatement, connection)
        Dim oDataSet As New DataSet
        oDataAdapter.Fill(oDataSet, tableName)

        Dim oDataRow As DataRow = oDataSet.Tables(tableName).Rows(0)
        Dim myTable As DataTable
        myTable = oDataRow.Table

        Return myTable
    End Function

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


    Public Sub Close()
        connection.Close()
    End Sub
End Class
