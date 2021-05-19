Imports DriveWorks.Components.Tasks
Imports DriveWorks.Specification

''' <summary>
''' A Generation Task Specification Condition which determines whether the value entered is even.
''' </summary>
''' <remarks><see cref="ComponentTaskReleaseCondition"/> are evaluated at the time of releasing component-sets.</remarks>
<ComponentTaskCondition("Is Even",
                        "Passes if the specified value is even.",
                        "embedded://DriveWorks.Sdk.Examples.VbDotNet.Puzzle-16x16.png",
                        "SDK-Starter-Examples Plugin")>
Public Class MyGenerationTaskSpecificationCondition
    Inherits ComponentTaskReleaseCondition

    Private ReadOnly mValue As FlowProperty(Of Double) = Me.Properties.RegisterDoubleProperty("Value",
                                                                                              "The value to check for must be an even number for the condition to pass.")

    Protected Overrides Function Evaluate(specificationContext As SpecificationContext) As Boolean

        ' If a number is evenly divisible by 2 with no remainder, then it is even.
        Dim isEven = (mValue.Value Mod 2) = 0

        Return isEven

    End Function
End Class