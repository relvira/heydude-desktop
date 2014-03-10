Namespace CustomComponents
    Public Class SimpleTextBox
        Public Property Message As String
            Get
                Return TxtMensaje.Text
            End Get
            Set(ByVal value As String)
                TxtMensaje.Text = value
            End Set
        End Property

        Public Property PasswdChar As Char
            Get
                Return TxtMensaje.PasswordChar
            End Get
            Set(ByVal value As Char)
                TxtMensaje.PasswordChar = value
            End Set
        End Property

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(213, 213, 213), ButtonBorderStyle.Solid)
        End Sub

        Private Sub TxtMensaje_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TxtMensaje.KeyPress
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                e.Handled = True
            End If
        End Sub

        Private Sub SimpleTextBox_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Me.GotFocus

        End Sub
    End Class
End Namespace