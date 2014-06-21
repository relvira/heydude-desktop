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
    End Class
End Namespace