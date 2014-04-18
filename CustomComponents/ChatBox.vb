Namespace CustomComponents
    Public Class ChatBox
        ''' <summary>
        ''' Máximo número de caracteres posibles en el mensaje.
        ''' </summary>
        Private Const MaxChar As Byte = 50
        ''' <summary>
        ''' Mínima distancia entre el componente y su entorno.
        ''' </summary>
        Private Const MinMargin As Byte = 5
        ''' <summary>
        ''' Mínima distancia entre el componente y los elementos interiores.
        ''' </summary>
        Private Const MinPadding As Byte = 10
        ''' <summary>
        ''' Distancia de separación entre cada ChatBox.
        ''' </summary>
        Private Const PlusHeight As Byte = 15

        Private _mAlignTo As AlignedTo = AlignedTo.Right
        Private _mBottomColor As Color = Color.FromArgb(188, 221, 198)
        Private _mBottomBorderAnchor As Byte = 2

        ''' <summary>
        ''' Establece el valor que va a tener la Label que va a mostrar el mensaje.
        ''' En función del tamaño que tenga el texto este control cambiará su tamaño.
        ''' Dependiendo de hacia donde esté alieado modificará su aspecto y los elementos a mostrar.
        ''' </summary>
        ''' <value>Mensaje que va a mostrar el componente.</value>
        Public Property Mensaje As String
            Set(ByVal value As String)
                LblMensaje.Text = value
                ChangeHeight()
                ChangeWidth()
            End Set
            Get
                Return LblMensaje.Text
            End Get
        End Property

        ''' <summary>
        ''' Establece el valor que va a tener la label que muestra la hora a la cual se recibió el mensaje.
        ''' El formato que tiene es "HH:mm".
        ''' </summary>
        ''' <value>Hora a mostrar.</value>
        Public WriteOnly Property Hora As Date
            Set(ByVal value As Date)
                LblHora.Text = value.ToString("HH:mm")
            End Set
        End Property

        ''' <summary>
        ''' Establece u obtiene en qué posición va a ser o está mostrado el control contenedor.
        ''' Si el valor es Right significa que será alineado a la derecha de su contenedor y viceversa en
        ''' el caso Left.
        ''' </summary>
        ''' <value>Donde será mostrado el control en el contenedor.</value>
        ''' <returns>En que posición está alineada actualmente el control.</returns>
        Public Property AlignTo As AlignedTo
            Get
                Return _mAlignTo
            End Get
            Set(ByVal value As AlignedTo)
                _mAlignTo = value
            End Set
        End Property

        ''' <summary>
        ''' Modifica la altura del control en función de la cantidad de caracteres máximos que puede
        ''' contener por línea.
        ''' El número de caracteres necesarios para el salto de linea está parametrizado por la 
        ''' constante MaxChar.
        ''' </summary>
        Private Sub ChangeHeight()
            For i As Integer = MaxChar - 1 To LblMensaje.Text.Length() Step MaxChar
                LblMensaje.Text = LblMensaje.Text.Insert(i, vbCrLf)
            Next

            Height += (PlusHeight * (Math.Floor(LblMensaje.Text.Length / MaxChar)))
        End Sub

        ''' <summary>
        ''' Modifica la anchura del control en función de los elementos que va a mostrar.
        ''' Right: Mostrará la imagen del Tick y su padding será el doble del parametrizado por defecto.
        ''' Left: La anchura tan solo abarca el Mensaje y la Hora, con un padding mínimo. También cambia el color del componente.
        ''' </summary>
        Private Sub ChangeWidth()
            If _mAlignTo = AlignedTo.Right Then
                Width = LblMensaje.Width + LblHora.Width + ImgTick.Width + (MinPadding * 2)
                Location = New Point(Parent.Width - Width - MinMargin, 0)
            Else
                Width = LblMensaje.Width + LblHora.Width + MinPadding
                Location = New Point(MinMargin, 0)

                ChangeColor()
            End If
        End Sub

        ''' <summary>
        ''' Cambia el color del fondo, del borde inferior y de la fuente de la Hora.
        ''' Modifica el tamaño del borde y oculta la imagen del Tick.
        ''' </summary>
        Private Sub ChangeColor()
            BackColor = Color.White
            _mBottomColor = Color.FromArgb(149, 151, 155)
            _mBottomBorderAnchor = 1

            ImgTick.Width = 0
            LblHora.Location = New Point(Width - LblHora.Width - 3, 6)
            LblHora.ForeColor = Color.FromArgb(188, 193, 199)
        End Sub

        ''' <summary>
        ''' Pinta una línea inferior sobre el control.
        ''' </summary>
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Nothing, 0, Nothing, Nothing, 0, Nothing, Nothing, 0, Nothing, _
                                    _mBottomColor, _mBottomBorderAnchor, ButtonBorderStyle.Solid)
        End Sub
    End Class
End Namespace