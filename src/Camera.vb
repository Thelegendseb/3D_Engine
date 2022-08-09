Imports System.Numerics
Imports XApps
Public Class Camera
    Private Position As Vector3
    Private Rotation As RotationComponent
    ' // Private ImagePlaneAngleX, ImagePlaneAngleY As Double
    ' // Private ImagePlaneWidth, ImagePlaneHeight As Double
    Sub New()
        Me.Rotation = New RotationComponent
    End Sub
    Public Function GetPosition() As Vector3
        Return Me.Position
    End Function
    Public Function GetRotation() As RotationComponent
        Return Me.Rotation
    End Function
End Class
