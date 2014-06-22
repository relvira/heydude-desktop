Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Namespace Util
    Public Module Encryption
        Public Function GetSha1Hash(ByVal strToHash As String) As String
            Dim sha1Obj As New SHA1CryptoServiceProvider
            Dim bytesToHash() As Byte = Encoding.ASCII.GetBytes(strToHash)
            bytesToHash = sha1Obj.ComputeHash(bytesToHash)
            Return bytesToHash.Aggregate("", Function(current, b) current + b.ToString("x2"))
        End Function

        Function IsEmail(ByVal email As String) As Boolean
            Static emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")
            Return emailExpression.IsMatch(email)
        End Function
    End Module
End Namespace