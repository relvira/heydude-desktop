Public Class State
    Private _mValue As String

    Private Sub New(ByVal pValue As String)
        _mValue = pValue
    End Sub

    Public Shared Operator =(ByVal pState1 As State, ByVal pState2 As State) As Boolean
        Return pState1._mValue = pState2._mValue
    End Operator

    Public Shared Operator <>(ByVal pState1 As State, ByVal pState2 As State) As Boolean
        Return pState1._mValue = pState2._mValue
    End Operator

    Public Shared Connected As New State("connected")
    Public Shared Disconnected As New State("disconnected")
    Public Shared NotAvailable As New State("not_available")
End Class
