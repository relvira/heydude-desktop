<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TitleChatList
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.LblUserState = New System.Windows.Forms.Label()
        Me.LblUserName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblUserState
        '
        Me.LblUserState.AutoSize = True
        Me.LblUserState.BackColor = System.Drawing.Color.White
        Me.LblUserState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUserState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.LblUserState.Location = New System.Drawing.Point(6, 32)
        Me.LblUserState.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.LblUserState.Name = "LblUserState"
        Me.LblUserState.Size = New System.Drawing.Size(40, 13)
        Me.LblUserState.TabIndex = 6
        Me.LblUserState.Text = "Estado"
        '
        'LblUserName
        '
        Me.LblUserName.AutoSize = True
        Me.LblUserName.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUserName.Location = New System.Drawing.Point(5, 5)
        Me.LblUserName.Margin = New System.Windows.Forms.Padding(5)
        Me.LblUserName.Name = "LblUserName"
        Me.LblUserName.Size = New System.Drawing.Size(83, 19)
        Me.LblUserName.TabIndex = 4
        Me.LblUserName.Text = "User Name"
        '
        'TitleChatList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.LblUserState)
        Me.Controls.Add(Me.LblUserName)
        Me.Name = "TitleChatList"
        Me.Size = New System.Drawing.Size(416, 56)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblUserState As System.Windows.Forms.Label
    Friend WithEvents LblUserName As System.Windows.Forms.Label

End Class
