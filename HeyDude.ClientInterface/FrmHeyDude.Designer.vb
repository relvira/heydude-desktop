Imports CustomControls
Imports Entities.Util

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHeyDude
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ModernToolBar = New CustomControls.ModernToolBar()
        Me.TitleChatList = New CustomControls.TitleChatList()
        Me.ChatList = New CustomControls.ChatList()
        Me.TextBoxHD = New CustomControls.TextBoxHd()
        Me.UserList = New CustomControls.UserList()
        Me.SuspendLayout()
        '
        'ModernToolBar
        '
        Me.ModernToolBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.ModernToolBar.Location = New System.Drawing.Point(0, -5)
        Me.ModernToolBar.Margin = New System.Windows.Forms.Padding(0)
        Me.ModernToolBar.Name = "ModernToolBar"
        Me.ModernToolBar.Size = New System.Drawing.Size(616, 39)
        Me.ModernToolBar.TabIndex = 14
        '
        'TitleChatList
        '
        Me.TitleChatList.BackColor = System.Drawing.Color.White
        Me.TitleChatList.Id = 0
        Me.TitleChatList.Location = New System.Drawing.Point(200, 34)
        Me.TitleChatList.Margin = New System.Windows.Forms.Padding(0)
        Me.TitleChatList.Name = "TitleChatList"
        Me.TitleChatList.Size = New System.Drawing.Size(416, 52)
        Me.TitleChatList.TabIndex = 13
        Me.TitleChatList.UserName = "User Name"
        Me.TitleChatList.UserState = "Estado"
        '
        'ChatList
        '
        Me.ChatList.AutoScroll = True
        Me.ChatList.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ChatList.Location = New System.Drawing.Point(200, 86)
        Me.ChatList.Margin = New System.Windows.Forms.Padding(0)
        Me.ChatList.Name = "ChatList"
        Me.ChatList.Size = New System.Drawing.Size(416, 367)
        Me.ChatList.TabIndex = 12
        '
        'TextBoxHD
        '
        Me.TextBoxHD.BackColor = System.Drawing.Color.White
        Me.TextBoxHD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TextBoxHD.Location = New System.Drawing.Point(200, 453)
        Me.TextBoxHD.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxHD.Message = ""
        Me.TextBoxHD.Name = "TextBoxHD"
        Me.TextBoxHD.Size = New System.Drawing.Size(416, 41)
        Me.TextBoxHD.TabIndex = 11
        '
        'UserList
        '
        Me.UserList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UserList.AutoScroll = True
        Me.UserList.BackColor = System.Drawing.Color.White
        Me.UserList.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserList.Location = New System.Drawing.Point(0, 34)
        Me.UserList.Margin = New System.Windows.Forms.Padding(0)
        Me.UserList.Name = "UserList"
        Me.UserList.Size = New System.Drawing.Size(200, 460)
        Me.UserList.TabIndex = 9
        '
        'FrmHeyDude
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(616, 494)
        Me.Controls.Add(Me.ModernToolBar)
        Me.Controls.Add(Me.TitleChatList)
        Me.Controls.Add(Me.ChatList)
        Me.Controls.Add(Me.TextBoxHD)
        Me.Controls.Add(Me.UserList)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "FrmHeyDude"
        Me.Text = "HeyDude!"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UserList As UserList
    Friend WithEvents TextBoxHD As TextBoxHd
    Friend WithEvents ChatList As ChatList
    Friend WithEvents TitleChatList As TitleChatList
    Friend WithEvents ModernToolBar As ModernToolBar
End Class