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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ToolBar = New FormComponent.ToolBar()
        Me.TitleChatList = New FormComponent.TitleChatList()
        Me.ChatList = New FormComponent.ChatList()
        Me.TextBoxHD = New FormComponent.TextBoxHd()
        Me.UserList = New FormComponent.UserList()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        Me.ToolBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.Size = New System.Drawing.Size(616, 26)
        Me.ToolBar.TabIndex = 14
        '
        'TitleChatList
        '
        Me.TitleChatList.BackColor = System.Drawing.Color.White
        Me.TitleChatList.Location = New System.Drawing.Point(200, 26)
        Me.TitleChatList.Name = "TitleChatList"
        Me.TitleChatList.Size = New System.Drawing.Size(416, 84)
        Me.TitleChatList.TabIndex = 13
        Me.TitleChatList.UserName = "User Name"
        Me.TitleChatList.UserState = "Estado"
        '
        'ChatList
        '
        Me.ChatList.AutoScroll = True
        Me.ChatList.BackColor = System.Drawing.Color.White
        Me.ChatList.Location = New System.Drawing.Point(200, 134)
        Me.ChatList.Margin = New System.Windows.Forms.Padding(0)
        Me.ChatList.Name = "ChatList"
        Me.ChatList.Size = New System.Drawing.Size(407, 295)
        Me.ChatList.TabIndex = 12
        '
        'TextBoxHD
        '
        Me.TextBoxHD.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.TextBoxHD.Location = New System.Drawing.Point(214, 442)
        Me.TextBoxHD.Message = ""
        Me.TextBoxHD.Name = "TextBoxHD"
        Me.TextBoxHD.Size = New System.Drawing.Size(381, 40)
        Me.TextBoxHD.TabIndex = 11
        '
        'UserList
        '
        Me.UserList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UserList.AutoScroll = True
        Me.UserList.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.UserList.Location = New System.Drawing.Point(0, 26)
        Me.UserList.Margin = New System.Windows.Forms.Padding(0)
        Me.UserList.Name = "UserList"
        Me.UserList.Size = New System.Drawing.Size(200, 468)
        Me.UserList.TabIndex = 9
        '
        'FrmHeyDude
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(616, 494)
        Me.Controls.Add(Me.ToolBar)
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
    Friend WithEvents UserList As FormComponent.UserList
    Friend WithEvents TextBoxHD As FormComponent.TextBoxHd
    Friend WithEvents ChatList As FormComponent.ChatList
    Friend WithEvents TitleChatList As FormComponent.TitleChatList
    Friend WithEvents ToolBar As FormComponent.ToolBar

End Class
