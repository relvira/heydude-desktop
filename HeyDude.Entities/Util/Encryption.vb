Imports System.Security.Cryptography
Imports System.Text

Namespace Util
    Public Module Encryption
        Public Function GetSha1Hash(ByVal strToHash As String) As String
            Dim bytesToHash() As Byte = Encoding.ASCII.GetBytes(strToHash)
            bytesToHash = New SHA1CryptoServiceProvider().ComputeHash(bytesToHash)
            Return bytesToHash.Aggregate("", Function(current, b) current + b.ToString("x2"))
        End Function
    End Module
End Namespace