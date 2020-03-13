' Import the Specification namespace so we have access to Specification flow.
Imports DriveWorks.Specification

<Condition("My Condition", "embedded://DriveWorks.Sdk.Examples.VbDotNet.Puzzle-16x16.png")>
Public Class MySpecificationMacroCondition
    Inherits Condition

    ' Register properties so DriveWorks can see them and build rules for them.
    Private ReadOnly mMyProperty As FlowProperty(Of Boolean) = Me.Properties.RegisterBooleanProperty("Condition Result", "Specifies the result of the condition.")

    Protected Overrides Function Evaluate(ByVal specificationContext As SpecificationContext) As Boolean

        ' Do something here to determine if the condition is met.
        Return mMyProperty.Value

    End Function
End Class