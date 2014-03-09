Imports Newtonsoft.Json.Converters
Imports Newtonsoft.Json

Namespace User
    Public Class ClientRequest
        Private ReadOnly _mProtocol As Protocol
        Private ReadOnly _mFromId As Integer
        Private _mToId As Integer
        Private _mMessage As String

        Public Sub New(pFrom As Integer, pProtocol As Protocol, Optional pTo As Integer = 0, Optional pMsg As String = "")
            _mFromId = pFrom
            _mProtocol = pProtocol
            _mToId = pTo
            _mMessage = pMsg
        End Sub

        Public ReadOnly Property FromId() As Integer
            Get
                Return _mFromId
            End Get
        End Property

        Public ReadOnly Property Protocol() As Protocol
            Get
                Return _mProtocol
            End Get
        End Property

        Public Property ToId() As Integer
            Get
                Return _mToId
            End Get
            Set(value As Integer)
                _mToId = value
            End Set
        End Property

        Public Property Message() As String
            Get
                Return _mMessage
            End Get
            Set(value As String)
                _mMessage = value
            End Set
        End Property
    End Class
End Namespace