Public Class ModernToolBar
    Public Event OnCloseButtonClick(sender As Object, e As EventArgs)

    Private _mParentPosition As Point
    Private _mMouseAction As Boolean

    Private Sub BtnClose_MouseClick(sender As Object, e As MouseEventArgs) Handles BtnClose.MouseClick
        RaiseEvent OnCloseButtonClick(sender, e)
    End Sub

    Private Sub BtnClose_MouseDown(sender As Object, e As EventArgs) Handles BtnClose.MouseDown
        BtnClose.BackgroundImage = New Bitmap("assets\closebutton_pressed.png")
    End Sub

    Private Sub BtnClose_MouseEnter(sender As Object, e As EventArgs) Handles BtnClose.MouseEnter
        BtnClose.BackgroundImage = New Bitmap("assets\closebutton_over.png")
    End Sub

    Private Sub BtnClose_MouseLeave(sender As Object, e As EventArgs) Handles BtnClose.MouseLeave
        BtnClose.BackgroundImage = New Bitmap("assets\closebutton_unpressed.png")
    End Sub

    Private Sub ToolBar_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        _mParentPosition = New Point(Cursor.Position.X - Parent.Location.X, Cursor.Position.Y - Parent.Location.Y)
        _mMouseAction = True
    End Sub

    Private Sub ToolBar_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
        If _mMouseAction = True Then
            Parent.Location = New Point(Cursor.Position.X - _mParentPosition.X, Cursor.Position.Y - _mParentPosition.Y)
        End If
    End Sub

    Private Sub ToolBar_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp
        _mMouseAction = False
    End Sub
End Class