﻿Imports System.Text.RegularExpressions

Namespace Util
    Public Module Verification
        Function IsEmail(ByVal email As String) As Boolean
            Static emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")
            Return emailExpression.IsMatch(email)
        End Function
    End Module
End Namespace