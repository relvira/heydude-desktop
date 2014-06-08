Imports System.Runtime.Serialization

Public Class ChatException
    Inherits Exception
    Implements ISerializable

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As Exception)
        MyBase.New()
    End Sub

    ' This constructor is needed for serialization.
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New()
    End Sub
End Class
