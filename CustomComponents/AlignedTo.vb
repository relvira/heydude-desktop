Public Class AlignedTo
    Private ReadOnly _mValue As String
    Public Shared Right As New AlignedTo("right")
    Public Shared Left As New AlignedTo("left")

    Sub New(ByVal mValue As String)
        _mValue = mValue
    End Sub

    Public Shared Operator =(ByVal pState1 As AlignedTo, ByVal pState2 As AlignedTo) As Boolean
        Return pState1._mValue = pState2._mValue
    End Operator

    Public Shared Operator <>(ByVal pState1 As AlignedTo, ByVal pState2 As AlignedTo) As Boolean
        Return pState1._mValue = pState2._mValue
    End Operator
End Class
