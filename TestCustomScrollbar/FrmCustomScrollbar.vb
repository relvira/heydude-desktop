Imports ChatClient.ui

Public Class FrmCustomScrollbar
    Inherits Form
    Friend WithEvents HdScrollBar1 As ChatClient.HdScrollBar

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

    Private Sub InitializeComponent()
        Me.HdScrollBar1 = New ChatClient.HdScrollBar()
        Me.SuspendLayout()
        '
        'HdScrollBar1
        '
        Me.HdScrollBar1.ChannelColorProperty = System.Drawing.Color.Empty
        Me.HdScrollBar1.LargeChangeProperty = 10
        Me.HdScrollBar1.Location = New System.Drawing.Point(58, 12)
        Me.HdScrollBar1.MaximumProperty = 10
        Me.HdScrollBar1.MinimumProperty = 10
        Me.HdScrollBar1.Name = "HdScrollBar1"
        Me.HdScrollBar1.Size = New System.Drawing.Size(19, 315)
        Me.HdScrollBar1.SmallChangeProperty = 10
        Me.HdScrollBar1.TabIndex = 0
        Me.HdScrollBar1.ValueProperty = 10
        '
        'FrmCustomScrollbar
        '
        Me.ClientSize = New System.Drawing.Size(179, 339)
        Me.Controls.Add(Me.HdScrollBar1)
        Me.Name = "FrmCustomScrollbar"
        Me.ResumeLayout(False)

    End Sub
End Class
