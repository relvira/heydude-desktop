Public Class TextBoxHd
    Public Event OnIntroPressed(ByVal e As KeyPressEventArgs)

    Public Property Message As String
        Get
            Return TxtMensaje.Text
        End Get
        Set(value As String)
            TxtMensaje.Text = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(0, 213, 213, 213), 0, ButtonBorderStyle.Solid, _
                                Color.FromArgb(213, 213, 213), 1, ButtonBorderStyle.Solid, _
                                Color.FromArgb(213, 213, 213), 1, ButtonBorderStyle.Solid, _
                                Color.FromArgb(213, 213, 213), 1, ButtonBorderStyle.Solid)
    End Sub

    Private Sub TxtMensaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMensaje.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            RaiseEvent OnIntroPressed(e)
            e.Handled = True
        End If
    End Sub
End Class
