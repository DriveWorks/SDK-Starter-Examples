﻿Imports DriveWorks.Components
Imports DriveWorks.SolidWorks
Imports DriveWorks.SolidWorks.Generation
Imports DriveWorks.SolidWorks.Generation.Proxies

''' <summary>
''' A Generation Task Generation Condition which determines whether the model has multiple configurations.
''' </summary>
''' <remarks><see cref="GenerationTaskCondition"/> are evaluated at the time of generating component-sets.</remarks>
<GenerationTaskCondition("Has Multiple Configurations",
                         "Checks whether the model has multiple configurations.",
                         "embedded://DriveWorks.Sdk.Examples.VbDotNet.Puzzle-16x16.png",
                         "SDK-Starter-Examples Plugin",
                         GenerationTaskScope.Parts Or GenerationTaskScope.Assemblies)>
Public Class MyGenerationTaskGenerationCondition
    Inherits GenerationTaskCondition

    Protected Overrides Function Evaluate(model As SldWorksModelProxy, component As ReleasedComponent, generationSettings As GenerationSettings) As Boolean

        ' Using the provided SldWorksModelProxy object to query information from the current model.
        Dim nbrOfConfigurations = model.Model.GetConfigurationCount()
        Dim hasMultipleConfigurations = nbrOfConfigurations > 1

        ' EvaluationResultDetails will be used by DriveWorks for reporting in the Model Generation Reports or Model Insight.
        If hasMultipleConfigurations Then

            Me.EvaluationResultDetails = $"The component has multiple configurations. ({nbrOfConfigurations} found)."
        Else

            Me.EvaluationResultDetails = "The component has 1 configuration only."
        End If

        Return hasMultipleConfigurations

    End Function
End Class