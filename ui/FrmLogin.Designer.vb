Imports ChatClient.CustomComponents

Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrmLogin
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
            Me.LblLoginError = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.BtnClose = New System.Windows.Forms.Button()
            Me.TxtPasswd = New ChatClient.CustomComponents.SimpleTextBox()
            Me.BtnRegister = New ChatClient.CustomComponents.SimpleButton()
            Me.BtnLogin = New ChatClient.CustomComponents.SimpleButton()
            Me.TxtUser = New ChatClient.CustomComponents.SimpleTextBox()
            Me.SuspendLayout()
            '
            'LblLoginError
            '
            Me.LblLoginError.AutoSize = True
            Me.LblLoginError.ForeColor = System.Drawing.Color.Red
            Me.LblLoginError.Location = New System.Drawing.Point(107, 195)
            Me.LblLoginError.Name = "LblLoginError"
            Me.LblLoginError.Size = New System.Drawing.Size(152, 13)
            Me.LblLoginError.TabIndex = 6
            Me.LblLoginError.Text = "Usuario/Contraseña incorrecto"
            Me.LblLoginError.Visible = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(122, 78)
            Me.Label1.MaximumSize = New System.Drawing.Size(300, 50)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(107, 13)
            Me.Label1.TabIndex = 8
            Me.Label1.Text = "HeyDude Messenger"
            '
            'BtnClose
            '
            Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BtnClose.BackColor = System.Drawing.Color.Transparent
            Me.BtnClose.BackgroundImage = CType(resources.GetObject("BtnClose.BackgroundImage"), System.Drawing.Image)
            Me.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.BtnClose.FlatAppearance.BorderSize = 0
            Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.BtnClose.Location = New System.Drawing.Point(332, 0)
            Me.BtnClose.Name = "BtnClose"
            Me.BtnClose.Size = New System.Drawing.Size(29, 26)
            Me.BtnClose.TabIndex = 10
            Me.BtnClose.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            Me.BtnClose.UseVisualStyleBackColor = False
            '
            'TxtPasswd
            '
            Me.TxtPasswd.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.TxtPasswd.Location = New System.Drawing.Point(12, 152)
            Me.TxtPasswd.Message = "rafa"
            Me.TxtPasswd.Name = "TxtPasswd"
            Me.TxtPasswd.PasswdChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.TxtPasswd.Size = New System.Drawing.Size(331, 40)
            Me.TxtPasswd.TabIndex = 9
            '
            'BtnRegister
            '
            Me.BtnRegister.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.BtnRegister.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(156, Byte), Integer))
            Me.BtnRegister.ButtonText = "Registrate"
            Me.BtnRegister.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BtnRegister.ForeColor = System.Drawing.Color.White
            Me.BtnRegister.Location = New System.Drawing.Point(181, 220)
            Me.BtnRegister.Name = "BtnRegister"
            Me.BtnRegister.Size = New System.Drawing.Size(162, 40)
            Me.BtnRegister.TabIndex = 4
            '
            'BtnLogin
            '
            Me.BtnLogin.BackColor = System.Drawing.Color.Red
            Me.BtnLogin.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(232, Byte), Integer))
            Me.BtnLogin.ButtonText = "Iniciar Sesión"
            Me.BtnLogin.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.BtnLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.BtnLogin.Location = New System.Drawing.Point(13, 220)
            Me.BtnLogin.Name = "BtnLogin"
            Me.BtnLogin.Size = New System.Drawing.Size(162, 40)
            Me.BtnLogin.TabIndex = 3
            '
            'TxtUser
            '
            Me.TxtUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.TxtUser.Location = New System.Drawing.Point(13, 106)
            Me.TxtUser.Message = "manu"
            Me.TxtUser.Name = "TxtUser"
            Me.TxtUser.PasswdChar = Global.Microsoft.VisualBasic.ChrW(0)
            Me.TxtUser.Size = New System.Drawing.Size(331, 40)
            Me.TxtUser.TabIndex = 1
            '
            'FrmLogin
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(362, 305)
            Me.Controls.Add(Me.BtnClose)
            Me.Controls.Add(Me.TxtPasswd)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.LblLoginError)
            Me.Controls.Add(Me.BtnRegister)
            Me.Controls.Add(Me.BtnLogin)
            Me.Controls.Add(Me.TxtUser)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmLogin"
            Me.Text = "FrmLogin"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtUser As SimpleTextBox
        Friend WithEvents BtnLogin As SimpleButton
        Friend WithEvents BtnRegister As SimpleButton
        Friend WithEvents LblLoginError As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TxtPasswd As SimpleTextBox
        Friend WithEvents BtnClose As System.Windows.Forms.Button
    End Class
End Namespace