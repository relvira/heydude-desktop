Imports ChatClient.CustomComponents

Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrmRegister
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
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.BtnUploadImage = New SimpleButton()
            Me.TxtPasswd2 = New SimpleTextBox()
            Me.TxtPasswd1 = New SimpleTextBox()
            Me.BtnRegister = New SimpleButton()
            Me.TxtEmail = New SimpleTextBox()
            Me.TxtFullName = New SimpleTextBox()
            Me.TxtUsername = New SimpleTextBox()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(48, 26)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(99, 13)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Nombre de usuario:"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(48, 98)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(93, 13)
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "Nombre completo:"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(48, 167)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(35, 13)
            Me.Label3.TabIndex = 7
            Me.Label3.Text = "Email:"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(48, 237)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(64, 13)
            Me.Label4.TabIndex = 8
            Me.Label4.Text = "Contraseña:"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(48, 311)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(100, 13)
            Me.Label5.TabIndex = 9
            Me.Label5.Text = "Repetir contraseña:"
            '
            'BtnUploadImage
            '
            Me.BtnUploadImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.BtnUploadImage.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(156, Byte), Integer))
            Me.BtnUploadImage.ButtonText = "Subir Imagen de Perfil"
            Me.BtnUploadImage.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BtnUploadImage.ForeColor = System.Drawing.Color.White
            Me.BtnUploadImage.ImeMode = System.Windows.Forms.ImeMode.[On]
            Me.BtnUploadImage.Location = New System.Drawing.Point(51, 373)
            Me.BtnUploadImage.Name = "BtnUploadImage"
            Me.BtnUploadImage.Size = New System.Drawing.Size(331, 40)
            Me.BtnUploadImage.TabIndex = 13
            '
            'TxtPasswd2
            '
            Me.TxtPasswd2.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.TxtPasswd2.Location = New System.Drawing.Point(51, 327)
            Me.TxtPasswd2.Message = ""
            Me.TxtPasswd2.Name = "TxtPasswd2"
            Me.TxtPasswd2.Size = New System.Drawing.Size(331, 40)
            Me.TxtPasswd2.TabIndex = 12
            '
            'TxtPasswd1
            '
            Me.TxtPasswd1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.TxtPasswd1.Location = New System.Drawing.Point(51, 253)
            Me.TxtPasswd1.Message = ""
            Me.TxtPasswd1.Name = "TxtPasswd1"
            Me.TxtPasswd1.Size = New System.Drawing.Size(331, 40)
            Me.TxtPasswd1.TabIndex = 11
            '
            'BtnRegister
            '
            Me.BtnRegister.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.BtnRegister.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(232, Byte), Integer))
            Me.BtnRegister.ButtonText = "Registrate!"
            Me.BtnRegister.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BtnRegister.ForeColor = System.Drawing.Color.White
            Me.BtnRegister.Location = New System.Drawing.Point(51, 421)
            Me.BtnRegister.Name = "BtnRegister"
            Me.BtnRegister.Size = New System.Drawing.Size(331, 40)
            Me.BtnRegister.TabIndex = 10
            '
            'TxtEmail
            '
            Me.TxtEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.TxtEmail.Location = New System.Drawing.Point(51, 183)
            Me.TxtEmail.Message = ""
            Me.TxtEmail.Name = "TxtEmail"
            Me.TxtEmail.Size = New System.Drawing.Size(331, 40)
            Me.TxtEmail.TabIndex = 4
            '
            'TxtFullName
            '
            Me.TxtFullName.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.TxtFullName.Location = New System.Drawing.Point(51, 114)
            Me.TxtFullName.Message = ""
            Me.TxtFullName.Name = "TxtFullName"
            Me.TxtFullName.Size = New System.Drawing.Size(331, 40)
            Me.TxtFullName.TabIndex = 1
            '
            'TxtUsername
            '
            Me.TxtUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.TxtUsername.Location = New System.Drawing.Point(51, 42)
            Me.TxtUsername.Message = ""
            Me.TxtUsername.Name = "TxtUsername"
            Me.TxtUsername.Size = New System.Drawing.Size(331, 40)
            Me.TxtUsername.TabIndex = 0
            '
            'FrmRegister
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(243, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(444, 504)
            Me.Controls.Add(Me.BtnUploadImage)
            Me.Controls.Add(Me.TxtPasswd2)
            Me.Controls.Add(Me.TxtPasswd1)
            Me.Controls.Add(Me.BtnRegister)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.TxtEmail)
            Me.Controls.Add(Me.TxtFullName)
            Me.Controls.Add(Me.TxtUsername)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmRegister"
            Me.Text = "FrmRegister"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtUsername As SimpleTextBox
        Friend WithEvents TxtFullName As SimpleTextBox
        Friend WithEvents TxtEmail As SimpleTextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents BtnRegister As SimpleButton
        Friend WithEvents TxtPasswd1 As SimpleTextBox
        Friend WithEvents TxtPasswd2 As SimpleTextBox
        Friend WithEvents BtnUploadImage As SimpleButton
    End Class
End Namespace