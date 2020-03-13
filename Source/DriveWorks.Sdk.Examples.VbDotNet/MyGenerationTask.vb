Imports DriveWorks.Components
Imports DriveWorks.Components.Tasks
Imports DriveWorks.Reporting
Imports DriveWorks.SolidWorks
Imports DriveWorks.SolidWorks.Generation
Imports DriveWorks.SolidWorks.Generation.Proxies

<GenerationTask("Rebuild Component",
                "Rebuilds the current SOLIDWORKS component.",
                "embedded://DriveWorks.Sdk.Examples.VbDotNet.Puzzle-16x16.png",
                "SDK-Starter-Examples Plugin",
                GenerationTaskScope.All)>
Public Class MyGenerationTask
    Inherits GenerationTask

    Private Const REBUILD_TOP_LEVEL_RULE_INVARIANT_NAME As String = "OnlyTopLevel"

    Public Overrides ReadOnly Property Parameters As ComponentTaskParameterInfo()
        Get
            Return New ComponentTaskParameterInfo() {
                        New ComponentTaskParameterInfo(REBUILD_TOP_LEVEL_RULE_INVARIANT_NAME, "Top Level Only", "True to only rebuild the top level model (Default is False).")
                   }
        End Get
    End Property

    Public Overrides Sub Execute(model As SldWorksModelProxy, component As ReleasedComponent, generationSettings As GenerationSettings)

        ' This method gets called during generation, we now have full access to
        ' 1). The release data for the component
        ' 2). The evaluated result of our rules defined in the Parameters property
        ' 3). The entire SOLIDWORKS API

        Dim topLevelOnly As Boolean = False

        If Me.Data.TryGetParameterValueAsBoolean(REBUILD_TOP_LEVEL_RULE_INVARIANT_NAME, topLevelOnly) Then

            ' The user didn't build a rule for the "Top Level Only" rule, or the rule evaluated
            ' to something that couldn't be converted to a Boolean.
            ' Report on it, and just use the default value of False
            Me.Report.WriteEntry(ReportingLevel.Minimal,
                                 ReportEntryType.Information,
                                 "Rebuild Component Task",
                                 "Model Generation",
                                 "No / Invalid value provided for the 'Top Level Only'-rule. Assuming false.",
                                 Nothing)
        End If

        Dim forceRebuildSuccess = model.Model.ForceRebuild3(topLevelOnly)

        If forceRebuildSuccess Then
            Me.SetExecutionResult(TaskExecutionResult.Success, "Successfully force rebuilt model.")
        Else
            Me.SetExecutionResult(TaskExecutionResult.Failed, "Failed to force rebuild model.")
        End If

    End Sub
End Class