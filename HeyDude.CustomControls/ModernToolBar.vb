Public Class ModernToolBar
    Public WriteOnly Property VisibleFilter() As Boolean
        Set(value As Boolean)
            TxtFriendFinder.Visible = value
            TxtFriendFinder.Enabled = value
        End Set
    End Property

    Public WriteOnly Property EnableFail() As Boolean
        Set(value As Boolean)
            ImgFinderStatus.Visible = value
            ImgFinderStatus.Enabled = value
        End Set
    End Property

    Public Event OnCloseButtonClick(sender As Object, e As EventArgs)
    Public Event OnFilterIntroClick(userName As String)

    Private _mParentPosition As Point
    Private _mMouseAction As Boolean

    Private Sub BtnClose_MouseClick(sender As Object, e As MouseEventArgs) Handles BtnClose.MouseClick
        RaiseEvent OnCloseButtonClick(sender, e)
    End Sub

    Private Sub BtnClose_MouseDown(sender As Object, e As EventArgs) Handles BtnClose.MouseDown
        BtnClose.BackgroundImage = New Bitmap(My.Resources.closebutton_pressed)
    End Sub

    Private Sub BtnClose_MouseEnter(sender As Object, e As EventArgs) Handles BtnClose.MouseEnter
        BtnClose.BackgroundImage = New Bitmap(My.Resources.closebutton_over)
    End Sub

    Private Sub BtnClose_MouseLeave(sender As Object, e As EventArgs) Handles BtnClose.MouseLeave
        BtnClose.BackgroundImage = New Bitmap(My.Resources.closebutton_unpressed)
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

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        TxtFriendFinder.Visible = True
        TxtFriendFinder.Enabled = True
    End Sub

    Private Sub TxtFriendFinder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFriendFinder.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True
            RaiseEvent OnFilterIntroClick(TxtFriendFinder.Text)
        End If
    End Sub

    Private Sub ImgFinderStatus_Click(sender As Object, e As EventArgs) Handles ImgFinderStatus.Click
        TxtFriendFinder.Visible = False
        TxtFriendFinder.Enabled = False
        ImgFinderStatus.Visible = False
        ImgFinderStatus.Enabled = False
    End Sub
End Class