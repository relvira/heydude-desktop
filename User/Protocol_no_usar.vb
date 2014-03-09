Namespace User
    Public Class Protocol_no_usar
        Private ReadOnly _mValue As String

        Private Sub New()
        End Sub

        Private Sub New(ByVal pValue As String)
            _mValue = pValue
        End Sub

        Public ReadOnly Property Value() As String
            Get
                Return _mValue
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return _mValue
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is Protocol_no_usar Then
                Return ToString().Equals(obj.ToString())
            Else
                Throw New ArgumentException("The argument must be a protocol.")
            End If
        End Function

        Public Shared ReadOnly Connect As New Protocol_no_usar("connect")
        Public Shared ReadOnly Disconnect As New Protocol_no_usar("disconnect")
        Public Shared ReadOnly SendMessage As New Protocol_no_usar("send message")
    End Class
End Namespace