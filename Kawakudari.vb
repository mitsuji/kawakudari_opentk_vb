Imports System
Imports OpenTK
Imports OpenTK.Input
Imports OpenTK.Graphics
Imports OpenTK.Graphics.OpenGL
Imports IchigoJam

Class Kawakudari

  Shared Sub Main
    Dim k = New Kawakudari
  End Sub

  Private std15 As Std15
  Private frame As UInteger
  Private rnd As Random
  Private x As Integer
  Private running As Boolean

  Sub New
    std15 = New Std15(512, 384, 32, 24)
    rnd = New Random
    Dim win As GameWindow = New GameWindow (512, 384, GraphicsMode.Default, "kawakudari")
    AddHandler win.Load,        AddressOf OnLoad
    AddHandler win.UpdateFrame, AddressOf OnUpdateFrame
    AddHandler win.KeyDown,     AddressOf OnKeyDown
    AddHandler win.RenderFrame, AddressOf OnRenderFrame
    AddHandler win.Resize,      AddressOf OnResize
    win.Run(60.0)
  End Sub

  Private Sub OnLoad (sender As Object, e As EventArgs)
    frame = 0
    x = 15
    running = True
  End Sub

  Private Sub OnUpdateFrame (sender As Object, e As FrameEventArgs)
    If Not running Then Return
    If frame Mod 5 = 0 Then
      std15.Locate(x,5)
      std15.Putc("0")
      std15.Locate(rnd.Next(0,32),23)
      std15.Putc("*")
      std15.Scroll(Std15.Direction.Up)
      If std15.Scr(x,5) <> ChrW(0) Then
        std15.Locate(0,23)
        std15.Putstr("Game Over...")
        std15.Putnum(CType(frame,Integer))
        running = False
      End If
    End If
    frame +=1
  End Sub

  Private Sub OnKeyDown (sender As Object, e As KeyboardKeyEventArgs)
    If e.Key = Key.Left  Then  x-=1
    If e.Key = Key.Right Then  x+=1
  End Sub

  Private Sub OnRenderFrame (sender As Object, e As FrameEventArgs)
    std15.DrawScreen
    sender.Context.SwapBuffers
  End Sub

  Private Sub OnResize (sender As Object, e As EventArgs)
    Dim win As GameWindow = sender
    GL.Viewport(0,0,win.Width,win.Height)
  End Sub

End Class
