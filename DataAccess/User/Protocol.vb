Namespace User
    Public Class Protocol
        Private ReadOnly _mValue As String

        Private Sub New(ByVal pValue As String)
            _mValue = pValue
        End Sub

        Public Overrides Function ToString() As String
            Return _mValue
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is Protocol Then
                Return ToString().Equals(obj.ToString())
            Else
                Throw New ArgumentException("The argument must be a protocol.")
            End If
        End Function

        Public Shared Operator =(ByVal pParam1 As Protocol, ByVal pParam2 As Protocol)
            Return pParam1.Equals(pParam2)
        End Operator

        Public Shared Operator <>(ByVal pParam1 As Protocol, ByVal pParam2 As Protocol)
            Return pParam1.Equals(pParam2)
        End Operator

        Public Shared ReadOnly Connect As New Protocol("CONNECT")
        Public Shared ReadOnly Disconnect As New Protocol("DISCONNECT")
        Public Shared ReadOnly SendMessage As New Protocol("SEND_MESSAGE")
        Public Shared ReadOnly ReceiveMessage As New Protocol("RECEIVE_MESSAGE")
    End Class
End Namespace