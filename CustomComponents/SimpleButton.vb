Namespace CustomComponents
    Public Class SimpleButton

        Public Event myClick(ByVal sender As Object, ByVal e As EventArgs)

        Property ButtonColor As Color
            Get
                Return Button1.BackColor
            End Get
            Set(ByVal value As Color)
                Button1.BackColor = value
            End Set
        End Property

        Property ButtonText() As String
            Get
                Return Button1.Text
            End Get
            Set(ByVal value As String)
                Button1.Text = value
            End Set
        End Property

        'Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        '    MyBase.OnPaint(e)

        '    ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(213, 213, 213), ButtonBorderStyle.Solid)
        'End Sub

        Private Sub SimpleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
            RaiseEvent myClick(sender, e)
        End Sub
    End Class
End Namespace