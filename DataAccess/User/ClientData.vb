Imports System.Net
Imports System.Collections.Specialized

Namespace User
    Public Class ClientData
        Private _mId As Integer
        Private _mName As String
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

        Public WriteOnly Property FullName As String
            Set(ByVal value As String)
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

        Public WriteOnly Property Email As String
            Set(ByVal value As String)
            End Set
        End Property

        Public WriteOnly Property IsLoggedIn As Boolean
            Set(ByVal value As Boolean)
            End Set
        End Property


        Public Function GetUserAllFriends() As ArrayList
            ServicePointManager.Expect100Continue = False
            Const downloaddServer As String = DynamicServer & "getUserFriends.php"

            Dim webcl As New WebClient()

            Dim reqParam As New NameValueCollection
            reqParam.Add("id", _mId)
            reqParam.Add("passwd", _mPasswd)

            Try
                webcl.UploadValues(downloaddServer, "POST", reqParam)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            ' TODO: ¿Return?
        End Function
    End Class
End Namespace