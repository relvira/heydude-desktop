Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles

Public Class HdScrollBar
    Protected ChannelColor As Color = Color.Empty


    Protected LargeChange As Integer = 10
    Protected SmallChange As Integer = 10
    Protected Minimum As Integer = 10
    Protected Maximum As Integer = 10
    Protected MValue As Integer = 10

    Private _mClickPoint As Integer
    Private _mThumbTop As Integer = 0
    Private _mThumbDown As Boolean = False
    Private _mThumbDragging As Boolean = False

    Public Shadows Event Scroll(sender As Object, e As EventArgs)
    Public Event ValueChanged(sender As Object, e As EventArgs)

    <EditorBrowsable(EditorBrowsableState.Always), Browsable(True), DefaultValue(False), Category("Behaviour"), Description("LargeChange")>
    Public Property SmallChangeProperty() As Integer
        Get
            Return SmallChange
        End Get
        Set(ByVal value As Integer)
            SmallChange = value
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Always), Browsable(True), DefaultValue(False), Category("Behaviour"), Description("SmallChange")>
    Public Property LargeChangeProperty() As Integer
        Get
            Return LargeChange
        End Get
        Set(ByVal value As Integer)
            LargeChange = value
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Always), Browsable(True), DefaultValue(False), Category("Behaviour"), Description("Minimum")>
    Public Property MinimumProperty() As Integer
        Get
            Return Minimum
        End Get
        Set(ByVal value As Integer)
            Minimum = value
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Always), Browsable(True), DefaultValue(False), Category("Behaviour"), Description("Maximum")>
    Public Property MaximumProperty() As Integer
        Get
            Return Maximum
        End Get
        Set(ByVal value As Integer)
            Maximum = value
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Always), Browsable(True), DefaultValue(False), Category("Behaviour"), Description("Value")>
    Public Property ValueProperty() As Integer
        Get
            Return MValue
        End Get
        Set(ByVal value As Integer)
            MValue = value
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Always), Browsable(True), DefaultValue(False), Category("Behaviour"), Description("ChannelColor")>
    Public Property ChannelColorProperty() As Color
        Get
            Return ChannelColor
        End Get
        Set(ByVal value As Color)
            ChannelColor = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor

        Dim oChannelBrush As New SolidBrush(ChannelColor)
        Dim oWhiteBrush As New SolidBrush(Color.Chartreuse)

        ' Draw channel left and right border color.
        e.Graphics.FillRectangle(oWhiteBrush, New Rectangle(0, 30, 1, Height - (30 * 2)))
        e.Graphics.FillRectangle(oWhiteBrush, New Rectangle(Width - 1, 30, 1, Height - (30 * 2)))

        ' Draw channel.
        e.Graphics.FillRectangle(oChannelBrush, New Rectangle(1, 30, Width - 2, Height - (30 * 2)))

        ' Draw thumb control.
        Dim nTrackHeight As Integer = Height - (30 + 30)
        Dim fThumbHeight As Single = LargeChange / Maximum * nTrackHeight
        Dim nThumbHeight As Integer = fThumbHeight

        If nThumbHeight > nTrackHeight Then
            nThumbHeight = nTrackHeight
            fThumbHeight = nTrackHeight
        End If

        If nThumbHeight < 56 Then
            nThumbHeight = 56
            fThumbHeight = 56
        End If

        Dim fSpanHeight As Single = (fThumbHeight - (60 + 2 + 2)) / 2.0F
        Dim nSpanHeight As Integer = fSpanHeight
        Dim nTop As Integer = _mThumbTop

        nTop += 30

        Dim brushTopImage As New SolidBrush(Color.DeepSkyBlue)
        'draw top part of thumb now
        e.Graphics.FillRectangle(brushTopImage, New Rectangle(1, nTop, Width - 2, 2))
        nTop += 2

        Dim brushTopSpanImage As New SolidBrush(Color.DeepPink)
        'draw top span thumb
        e.Graphics.FillRectangle(brushTopSpanImage, 1.0F, nTop, Width - 2.0F, fSpanHeight * 2)

        nTop += nSpanHeight

        Dim brushMidImage As New SolidBrush(Color.ForestGreen)
        'draw middle part of thumb
        e.Graphics.FillRectangle(brushMidImage, New Rectangle(1, nTop,
                           Width - 2, 60))

        nTop += 60

        Dim brushBottomSpanImage As New SolidBrush(Color.DarkOrange)
        'draw botom span thumb
        Dim rect As New Rectangle(1, nTop, Width - 2, nSpanHeight * 2)
        e.Graphics.FillRectangle(brushBottomSpanImage, rect)
        nTop += nSpanHeight

        'draw bottom part of thumb
        Dim brushBottomImage As New SolidBrush(Color.BlueViolet)
        e.Graphics.FillRectangle(brushBottomImage, New Rectangle(1, nTop, Width - 2, nSpanHeight))

        'draw down arrow

        e.Graphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(New Point(0, (Height - 30)), New Size(Width, 30)))
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)

        _mThumbDown = False
        _mThumbDragging = False
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)

        Dim ptPoint As Point = PointToClient(Cursor.Position)
        Dim nTrackHeight As Integer = (Height - (30 + 30))
        Dim nThumbHeight As Integer = 60
        Dim nTop As Integer = _mThumbTop
        nTop += 30

        Dim thumbrect As New Rectangle(New Point(1, nTop), New Size(Width - 2, nThumbHeight))

        If (thumbrect.Contains(ptPoint)) Then

            'hit the thumb
            _mClickPoint = (ptPoint.Y - nTop)
            _mThumbDown = True
        End If

        Dim uparrowrect As New Rectangle(New Point(1, 0), New Size(30, 30))

        If (uparrowrect.Contains(ptPoint)) Then
            Dim nRealRange As Integer = (Maximum - Minimum) - LargeChange
            Dim nPixelRange As Integer = nTrackHeight - nThumbHeight
            If (nRealRange > 0) Then

                If (nPixelRange > 0) Then

                    If ((_mThumbTop - SmallChange) < 0) Then
                        _mThumbTop = 0
                    Else
                        _mThumbTop -= SmallChange
                        'figure out value
                        Dim fPerc As Single = _mThumbTop / nPixelRange
                        Dim fValue As Single = fPerc * (Maximum - LargeChange)

                        MValue = fValue
                        Debug.WriteLine(MValue.ToString())
                        RaiseEvent ValueChanged(Me, New EventArgs())
                        RaiseEvent Scroll(Me, New EventArgs())
                        Invalidate()
                    End If
                End If
            End If
        End If

        Dim downarrowrect As New Rectangle(New Point(1, 30 + nTrackHeight), New Size(Width, 30))
        If (downarrowrect.Contains(ptPoint)) Then
            Dim nRealRange As Integer = (Maximum - Minimum) - LargeChange
            Dim nPixelRange As Integer = (nTrackHeight - nThumbHeight)
            If (nRealRange > 0) Then

                If (nPixelRange > 0) Then

                    If ((_mThumbTop + SmallChange) > nPixelRange) Then
                        _mThumbTop = nPixelRange
                    Else
                        _mThumbTop += SmallChange
                        'figure out value
                        Dim fPerc As Single = _mThumbTop / nPixelRange
                        Dim fValue = fPerc * (Maximum - LargeChange)

                        MValue = fValue
                        RaiseEvent ValueChanged(Me, New EventArgs())
                        RaiseEvent Scroll(Me, New EventArgs())
                        Invalidate()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub MoveThumb(y As Integer)
        Dim nRealRange As Integer = Maximum - Minimum
        Dim nTrackHeight As Integer = (Height - (30 + 30))
        Dim nThumbHeight = 60
        Dim nSpot As Integer = _mClickPoint
        Dim nPixelRange = (nTrackHeight - nThumbHeight)
        If (_mThumbDown And nRealRange > 0) Then
            If nPixelRange > 0 Then
                Dim nNewThumbTop = y - (30 + nSpot)

                If (nNewThumbTop < 0) Then
                    _mThumbTop = nNewThumbTop = 0

                ElseIf (nNewThumbTop > nPixelRange) Then

                    _mThumbTop = nNewThumbTop = nPixelRange

                Else
                    _mThumbTop = y - (30 + nSpot)

                    'figure out value
                    Dim fPerc As Single = _mThumbTop / nPixelRange
                    Dim fValue As Single = fPerc * (Maximum - LargeChange)
                    MValue = fValue
                    Debug.WriteLine(MValue.ToString())
                    Application.DoEvents()
                    Invalidate()
                End If
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        If _mThumbDown = True Then
            _mThumbDragging = True
        End If

        If _mThumbDragging Then
            MoveThumb(e.Y)
        End If

        RaiseEvent ValueChanged(Me, New EventArgs())
        RaiseEvent Scroll(Me, New EventArgs())
    End Sub
End Class
