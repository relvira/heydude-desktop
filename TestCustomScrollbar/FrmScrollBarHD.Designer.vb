<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmScrollBarHD
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
        Me.HdScrollBar1 = New ChatClient.HdScrollBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.HdScrollBar1)
        Me.Panel1.Location = New System.Drawing.Point(40, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 209)
        Me.Panel1.TabIndex = 1
        '
        'HdScrollBar1
        '
        Me.HdScrollBar1.LargeChangeProperty = HdScrollBar1.MaximumProperty / HdScrollBar1.Height + Panel1.Height
        Me.HdScrollBar1.Location = New System.Drawing.Point(173, 3)
        Me.HdScrollBar1.MaximumProperty = 10
        Me.HdScrollBar1.MinimumProperty = 0
        Me.HdScrollBar1.Name = "HdScrollBar1"
        Me.HdScrollBar1.Size = New System.Drawing.Size(24, 203)
        Me.HdScrollBar1.SmallChangeProperty = 15
        Me.HdScrollBar1.TabIndex = 0
        Me.HdScrollBar1.ValueProperty = 10
        '
        'FrmScrollBarHD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmScrollBarHD"
        Me.Text = "FrmScrollBarHD"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HdScrollBar1 As ChatClient.HdScrollBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
