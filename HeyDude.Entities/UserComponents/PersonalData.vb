Imports System.Collections.Specialized
Imports System.Net
Imports System.Windows.Forms

Namespace UserComponents
    Public Class PersonalData
        Private _mId As Integer
        Private _mName As String
        Private _mEmail As String
        Private _mFullName As String
        Private _mLoggedIn As Boolean
        Private _mPasswd As String
        Private _mStateMessage As String
        Private _mImgStringSrc As String

        Public Sub New()
        End Sub

        Public Sub New(ByVal pId As Integer, ByVal pName As String, ByVal pStateMsg As String, ByVal pImgSrc As String)
            _mId = pId
            _mName = pName
            _mStateMessage = pStateMsg
            _mImgStringSrc = pImgSrc
        End Sub

        Public Property Name() As String
            Get
                Return _mName
            End Get
            Set(ByVal value As String)
                _mName = value
            End Set
        End Property

        Public Property Passwd() As String
            Get
                Return _mPasswd
            End Get
            Set(ByVal value As String)
                _mPasswd = value
            End Set
        End Property

        Public Property StateMessage() As String
            Get
                Return _mStateMessage
            End Get
            Set(ByVal value As String)
                _mStateMessage = value
            End Set
        End Property

        Public Property ImageSource As String
            Get
                Return _mImgStringSrc
            End Get
            Set(ByVal value As String)
                _mImgStringSrc = ProfileImagesPath & value
            End Set
        End Property

        Public Property FullName As String
            Get
                Return _mFullName
            End Get
            Set(ByVal value As String)
                _mFullName = value
            End Set
        End Property

        Public Property Id As Integer
            Get
                Return _mId
            End Get
            Set(ByVal value As Integer)
                _mId = value
            End Set
        End Property

        Public Property Email As String
            Get
                Return _mEmail
            End Get
            Set(ByVal value As String)
                _mEmail = value
            End Set
        End Property

        Public Property IsLoggedIn As Boolean
            Get
                Return _mLoggedIn
            End Get
            Set(ByVal value As Boolean)
                _mLoggedIn = value
            End Set
        End Property


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
            Const downloaddServer As String = DynamicServer & "getUserFriends.php"

            Dim webcl As New WebClient()

            Dim reqParam As New NameValueCollection
            reqParam.Add("id", _mId)
            reqParam.Add("passwd", _mPasswd)

            Dim responseBytes As Byte()

            Try
                responseBytes = webcl.UploadValues(downloaddServer, "POST", reqParam)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        End Function
    End Class
End Namespace