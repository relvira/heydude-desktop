Imports Newtonsoft.Json.Converters
Imports Newtonsoft.Json

Namespace User
    <JsonConverter(GetType(StringEnumConverter))>
    Public Enum Protocol_is_bad
        Connect
        Disconnect
        SendMessage
        ReceiveMessage
    End Enum
End Namespace