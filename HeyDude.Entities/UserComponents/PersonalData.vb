Imports System.Collections.Specialized
Imports System.Net
Imports System.Windows.Forms
Imports System.Configuration

Namespace UserComponents
    Public Class PersonalData
        Public Property Id As Integer
        Public Property Name As String
        Public Property Passwd As String
        Public Property StateMessage As String
        Public Property ImageSource As String
        Public Property FullName As String
        Public Property Email As String
        Public Property IsLoggedIn As Boolean

        Public Sub New()
        End Sub

        Public Sub New(ByVal pId As Integer, ByVal pName As String, ByVal pStateMsg As String, ByVal pImgSrc As String)
            Id = pId
            Name = pName
            StateMessage = pStateMsg
            ImageSource = pImgSrc
        End Sub


        Public Function GetUserAllFriends() As ArrayList
            'Dim sqlManager As New MySQLManager
            'Dim queryResult = sqlManager.ExecuteQuery("SELECT friend_to FROM user_friends where friend_of='" & Id & "'", "user_friends")

            'Dim J = 0
            'Dim Result As New ArrayList
            'For Each oDataRow In queryResult.Rows
            '    Dim Idfriend = queryResult.Rows(J)("friend_to")
            '    Dim frnd = sqlManager.ExecuteQuery("SELECT id, uid, full_name, profile_img, user_status FROM user where id='" & Idfriend & "'", "user")
            '    For Each f In frnd.Rows
            '        Result.Add(frnd.Rows(0)("id") & "," & frnd.Rows(0)("uid") & "," & frnd.Rows(0)("full_name") & "," & frnd.Rows(0)("profile_img") & "," & frnd.Rows(0)("user_status"))
            '    Next
            '    J = J + 1
            'Next
            'Return Result

            ServicePointManager.Expect100Continue = False
            Dim downloaddServer As String = ConfigurationManager.AppSettings("DynamicServer") & "getUserFriends.php"

            Dim webcl As New WebClient()

            Dim reqParam As New NameValueCollection
            reqParam.Add("id", Id)
            reqParam.Add("passwd", Passwd)

            Dim responseBytes As Byte()

            Try
                responseBytes = webcl.UploadValues(downloaddServer, "POST", reqParam)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        End Function
    End Class
End Namespace