Imports XApps
Public Class Program
    Inherits XApp
    Private Shapes As List(Of Shape)
    Private Camera As Camera
    Sub New(FormIn As Form)
        MyBase.New(FormIn)

        GUIInit(FormIn)
        ObjInit()
        SessionInit()
    End Sub
    Private Sub GUIInit(FormIn As Form)
        FormIn.Text = "3D Engine | Sebastian Clarke"
        FormIn.WindowState = FormWindowState.Maximized
        Me.Session.Window.SetClearColor(Color.FromArgb(10, 20, 30))
    End Sub
    Private Sub ObjInit()
        Me.Shapes = New List(Of Shape)
        Me.Camera = New Camera
    End Sub
    Private Sub SessionInit()
        Me.Session.AddObj(New WorldRenderer(Me.Shapes, Me.Camera))
    End Sub
End Class
