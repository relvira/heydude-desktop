Public Class FrmScrollBarHD



    Private Sub HdScrollBar1_Scroll(sender As Object, e As System.EventArgs) Handles HdScrollBar1.Scroll
        Panel1.AutoScrollPosition = New Point(0, HdScrollBar1.ValueProperty)
        HdScrollBar1.Invalidate()
        Application.DoEvents()
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)

        Me.HdScrollBar1.MaximumProperty = Panel1.DisplayRectangle.Height
        Me.HdScrollBar1.ValueProperty = Math.Abs(Panel1.AutoScrollPosition.Y)
    End Sub
End Class