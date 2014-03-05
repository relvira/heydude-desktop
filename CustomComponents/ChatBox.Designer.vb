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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChatBox))
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.ImgTick = New System.Windows.Forms.PictureBox()
        Me.LblHora = New System.Windows.Forms.Label()
        CType(Me.ImgTick, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblMensaje
        '
        Me.LblMensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblMensaje.AutoSize = True
        Me.LblMensaje.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.Location = New System.Drawing.Point(5, 5)
        Me.LblMensaje.Margin = New System.Windows.Forms.Padding(5)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(47, 14)
        Me.LblMensaje.TabIndex = 2
        Me.LblMensaje.Text = "Mensaje"
        '
        'ImgTick
        '
        Me.ImgTick.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImgTick.BackgroundImage = CType(resources.GetObject("ImgTick.BackgroundImage"), System.Drawing.Image)
        Me.ImgTick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ImgTick.Location = New System.Drawing.Point(124, 7)
        Me.ImgTick.Name = "ImgTick"
        Me.ImgTick.Size = New System.Drawing.Size(15, 12)
        Me.ImgTick.TabIndex = 3
        Me.ImgTick.TabStop = False
        '
        'LblHora
        '
        Me.LblHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(159, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(108, Byte), Integer))
        Me.LblHora.Location = New System.Drawing.Point(79, 6)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(39, 13)
        Me.LblHora.TabIndex = 4
        Me.LblHora.Text = "00:00"
        '
        'ChatBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Controls.Add(Me.LblHora)
        Me.Controls.Add(Me.ImgTick)
        Me.Controls.Add(Me.LblMensaje)
        Me.Name = "ChatBox"
        Me.Size = New System.Drawing.Size(142, 28)
        CType(Me.ImgTick, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblMensaje As System.Windows.Forms.Label
    Friend WithEvents ImgTick As System.Windows.Forms.PictureBox
    Friend WithEvents LblHora As System.Windows.Forms.Label

End Class
