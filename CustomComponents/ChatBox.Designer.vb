<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChatBox
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
        Me.LblUserName = New System.Windows.Forms.Label()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.ImgUser = New System.Windows.Forms.PictureBox()
        CType(Me.ImgUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblUserName
        '
        Me.LblUserName.AutoSize = True
        Me.LblUserName.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUserName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.LblUserName.Location = New System.Drawing.Point(54, 8)
        Me.LblUserName.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.LblUserName.Name = "LblUserName"
        Me.LblUserName.Size = New System.Drawing.Size(97, 13)
        Me.LblUserName.TabIndex = 1
        Me.LblUserName.Text = "Nombre de usuario"
        '
        'LblMensaje
        '
        Me.LblMensaje.AutoSize = True
        Me.LblMensaje.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.Location = New System.Drawing.Point(54, 21)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(48, 13)
        Me.LblMensaje.TabIndex = 2
        Me.LblMensaje.Text = "Mensaje"
        '
        'ImgUser
        '
        Me.ImgUser.Location = New System.Drawing.Point(0, 0)
        Me.ImgUser.Name = "ImgUser"
        Me.ImgUser.Size = New System.Drawing.Size(48, 48)
        Me.ImgUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgUser.TabIndex = 0
        Me.ImgUser.TabStop = False
        '
        'ChatBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.LblMensaje)
        Me.Controls.Add(Me.LblUserName)
        Me.Controls.Add(Me.ImgUser)
        Me.Name = "ChatBox"
        Me.Size = New System.Drawing.Size(388, 48)
        CType(Me.ImgUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImgUser As System.Windows.Forms.PictureBox
    Friend WithEvents LblUserName As System.Windows.Forms.Label
    Friend WithEvents LblMensaje As System.Windows.Forms.Label

End Class
