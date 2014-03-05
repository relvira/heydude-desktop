<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserList))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCancelSearch = New System.Windows.Forms.Button()
        Me.LblBuscar = New System.Windows.Forms.Label()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnCancelSearch)
        Me.Panel1.Controls.Add(Me.LblBuscar)
        Me.Panel1.Controls.Add(Me.TxtSearch)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(10, 10)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(180, 31)
        Me.Panel1.TabIndex = 0
        '
        'BtnCancelSearch
        '
        Me.BtnCancelSearch.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BtnCancelSearch.BackgroundImage = CType(resources.GetObject("BtnCancelSearch.BackgroundImage"), System.Drawing.Image)
        Me.BtnCancelSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnCancelSearch.FlatAppearance.BorderSize = 0
        Me.BtnCancelSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelSearch.Location = New System.Drawing.Point(156, 5)
        Me.BtnCancelSearch.Name = "BtnCancelSearch"
        Me.BtnCancelSearch.Size = New System.Drawing.Size(18, 20)
        Me.BtnCancelSearch.TabIndex = 5
        Me.BtnCancelSearch.UseVisualStyleBackColor = True
        Me.BtnCancelSearch.Visible = False
        '
        'LblBuscar
        '
        Me.LblBuscar.AutoSize = True
        Me.LblBuscar.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuscar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.LblBuscar.Location = New System.Drawing.Point(34, 8)
        Me.LblBuscar.Name = "LblBuscar"
        Me.LblBuscar.Size = New System.Drawing.Size(36, 15)
        Me.LblBuscar.TabIndex = 3
        Me.LblBuscar.Text = "Buscar"
        '
        'TxtSearch
        '
        Me.TxtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(34, 8)
        Me.TxtSearch.Multiline = True
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(143, 16)
        Me.TxtSearch.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'UserList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UserList"
        Me.Size = New System.Drawing.Size(200, 374)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblBuscar As System.Windows.Forms.Label
    Friend WithEvents BtnCancelSearch As System.Windows.Forms.Button

End Class
