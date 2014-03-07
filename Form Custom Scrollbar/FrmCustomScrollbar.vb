Imports ChatClient.ui

Public Class FrmCustomScrollbar
    Inherits Form

    Public Sub New()
        Me.Size = New Size(500, 500)

        Dim Bar1 As New CustomScrollBar()
        Bar1.Location = New Point(50, 100)
        Bar1.Size = New Size(200, 20)

        Controls.Add(Bar1)
    End Sub

    <STAThread()> _
    Shared Sub Main()
        ' The call to EnableVisualStyles below does not affect whether  
        ' ScrollBarRenderer.IsSupported is true; as long as visual styles  
        ' are enabled by the operating system, IsSupported is true.
        Application.EnableVisualStyles()
        Application.Run(New FrmHeyDude())
    End Sub
End Class
