<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserBox
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
        Me.ImgUser = New System.Windows.Forms.PictureBox()
        Me.LblUserName = New System.Windows.Forms.Label()
        Me.LblUserState = New System.Windows.Forms.Label()
        CType(Me.ImgUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImgUser
        '
        Me.ImgUser.Location = New System.Drawing.Point(3, 3)
        Me.ImgUser.Name = "ImgUser"
        Me.ImgUser.Size = New System.Drawing.Size(48, 48)
        Me.ImgUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgUser.TabIndex = 0
        Me.ImgUser.TabStop = False
        '
        'LblUserName
        '
        Me.LblUserName.AutoSize = True
        Me.LblUserName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUserName.Location = New System.Drawing.Point(57, 9)
        Me.LblUserName.Name = "LblUserName"
        Me.LblUserName.Size = New System.Drawing.Size(129, 16)
        Me.LblUserName.TabIndex = 1
        Me.LblUserName.Text = "Nombre de usuario"
        '
        'LblUserState
        '
        Me.LblUserState.AutoSize = True
        Me.LblUserState.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUserState.ForeColor = System.Drawing.SystemColors.GrayText
        Me.LblUserState.Location = New System.Drawing.Point(57, 26)
        Me.LblUserState.Margin = New System.Windows.Forms.Padding(0)
        Me.LblUserState.Name = "LblUserState"
        Me.LblUserState.Size = New System.Drawing.Size(39, 13)
        Me.LblUserState.TabIndex = 2
        Me.LblUserState.Text = "Estado"
        '
        'UserBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.LblUserState)
        Me.Controls.Add(Me.LblUserName)
        Me.Controls.Add(Me.ImgUser)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UserBox"
        Me.Size = New System.Drawing.Size(198, 55)
        CType(Me.ImgUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImgUser As System.Windows.Forms.PictureBox
    Friend WithEvents LblUserName As System.Windows.Forms.Label
    Friend WithEvents LblUserState As System.Windows.Forms.Label

End Class
