# kawakudari-opentk-vb

This project implements part of the [std15.h](https://github.com/IchigoJam/c4ij/blob/master/src/std15.h) API (from [c4ij](https://github.com/IchigoJam/c4ij)) with [OpenTK](https://opentk.net), and [Kawakudari Game](https://ichigojam.github.io/print/en/KAWAKUDARI.html) on top of it.

It will allow programming for [IchigoJam](https://ichigojam.net/index-en.html)-like targets that display [IchigoJam FONT](https://mitsuji.github.io/ichigojam-font.json/) on screen using a Visual Basic programming language.
```
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

```

## Prerequisite

* [Download](https://www.mono-project.com/download/stable/) and install mono suitable for your environment.
* [Download](https://www.mono-project.com/docs/about-mono/languages/visualbasic/) and install Visual Basic suitable for your environment.(In most cases, the distribution provides the package.)
* Download and install packages related OpenGL, OpenGL ES and OpenAL suitable for your environment.

## How to use

To build it
```
$ mcs -r:OpenTK.dll Kawakudari.vb IchigoJam.vb
```

To run it
```
$ mono Kawakudari.exe
```
(In windows environment, you can run it by just double click 'Kawakudari.exe' in Explorer)



## License
[![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/)
[CC BY](https://creativecommons.org/licenses/by/4.0/) [mitsuji.org](https://mitsuji.org)

This work is licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/).
