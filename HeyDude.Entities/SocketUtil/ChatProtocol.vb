Namespace SocketUtil
    Public Class ChatProtocol
        Public Property Value As String

        Private Sub New(ByVal pValue As String)
            Value = pValue
        End Sub

        Public Overrides Function ToString() As String
            Return Value
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is ChatProtocol Then
                Return ToString().Equals(obj.ToString())
            Else
                Throw New ArgumentException("The argument must be a ChatProtocol.")
            End If
        End Function

        Public Shared Operator =(ByVal pParam1 As ChatProtocol, ByVal pParam2 As ChatProtocol)
            Return pParam1.Equals(pParam2)
        End Operator

        Public Shared Operator <>(ByVal pParam1 As ChatProtocol, ByVal pParam2 As ChatProtocol)
            Return pParam1.Equals(pParam2)
        End Operator

        Public Shared ReadOnly Connect As New ChatProtocol("CONNECT")
        Public Shared ReadOnly Disconnect As New ChatProtocol("DISCONNECT")
        Public Shared ReadOnly SendMessage As New ChatProtocol("SEND_MESSAGE")
        Public Shared ReadOnly ReceiveMessage As New ChatProtocol("RECEIVE_MESSAGE")
    End Class
End Namespace