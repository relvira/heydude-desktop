Imports System.Runtime.Serialization

Namespace SocketUtil
    Public Class ChatException
        Inherits Exception
        Implements ISerializable

        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New(message, inner)
        End Sub
    End Class
End Namespace