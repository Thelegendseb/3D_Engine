Imports XApps
Imports System.Numerics
Imports XApps.Math3D
Public Class WorldRenderer
    Inherits XBase
    Private Shapes As List(Of Shape)
    Private Camera As Camera
    Sub New(SPtr As List(Of Shape), CPtr As Camera)
        Me.Shapes = SPtr
        Me.Camera = CPtr
        Me.SetDrawStatus(True)
    End Sub
    Public Overrides Sub Update(Session As XSession)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)

        For Each S As Shape In Me.Shapes

            ' // All Vertexes visible by the camera will be contained in this list

            Dim ValidVertexes As New List(Of Vector3)

            ' // Get the world Coordinates of the shapes' vertexes

            Dim Vertexes As List(Of Vector3) = S.CallState ' // --> Gets the shapes vertexes relative to world space

            For Each Vertex As Vector3 In Vertexes

                ' // Displace each vertex by the cameras position (Negative displacement)

                Vertex.X -= Me.Camera.GetPosition.X
                Vertex.Y -= Me.Camera.GetPosition.Y
                Vertex.Z -= Me.Camera.GetPosition.Z

                ' // Rotate each vertex by the cameras rotation (Negative rotation)

                Matrix.Multiply(Matrix.Type("X", -Me.Camera.GetRotation.Pitch), Vertex)
                Matrix.Multiply(Matrix.Type("Y", -Me.Camera.GetRotation.Yaw), Vertex)
                Matrix.Multiply(Matrix.Type("Z", -Me.Camera.GetRotation.Roll), Vertex)

                ' // Check if the Vertex will be visible by the camera

                If (Vertex.X > 0 And Vertex.X < g.VisibleClipBounds.Width) And
                   (Vertex.Y > 0 And Vertex.Y < g.VisibleClipBounds.Height) Then
                    ValidVertexes.Add(Vertex)
                End If

            Next

            ' // Draw valid vertexes

        Next

    End Sub
End Class
