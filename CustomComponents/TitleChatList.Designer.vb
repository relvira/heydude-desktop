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
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ImgConnected = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgConnected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblUserState
        '
        Me.LblUserState.AutoSize = True
        Me.LblUserState.BackColor = System.Drawing.Color.White
        Me.LblUserState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUserState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.LblUserState.Location = New System.Drawing.Point(34, 37)
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
        Me.LblUserName.Location = New System.Drawing.Point(34, 15)
        Me.LblUserName.Margin = New System.Windows.Forms.Padding(3, 15, 3, 0)
        Me.LblUserName.Name = "LblUserName"
        Me.LblUserName.Size = New System.Drawing.Size(83, 19)
        Me.LblUserName.TabIndex = 4
        Me.LblUserName.Text = "User Name"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.PictureBox2.Location = New System.Drawing.Point(15, 71)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(380, 2)
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'ImgConnected
        '
        Me.ImgConnected.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ImgConnected.Location = New System.Drawing.Point(15, 10)
        Me.ImgConnected.Margin = New System.Windows.Forms.Padding(15, 10, 10, 10)
        Me.ImgConnected.Name = "ImgConnected"
        Me.ImgConnected.Size = New System.Drawing.Size(6, 48)
        Me.ImgConnected.TabIndex = 5
        Me.ImgConnected.TabStop = False
        '
        'TitleChatList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LblUserState)
        Me.Controls.Add(Me.ImgConnected)
        Me.Controls.Add(Me.LblUserName)
        Me.Name = "TitleChatList"
        Me.Size = New System.Drawing.Size(416, 85)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgConnected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblUserState As System.Windows.Forms.Label
    Friend WithEvents ImgConnected As System.Windows.Forms.PictureBox
    Friend WithEvents LblUserName As System.Windows.Forms.Label

End Class
