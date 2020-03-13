using DriveWorks.Components;
using DriveWorks.Components.Tasks;
using DriveWorks.SolidWorks;
using DriveWorks.SolidWorks.Generation;
using DriveWorks.SolidWorks.Generation.Proxies;

namespace DriveWorks.Sdk.Examples.CSharp
{
    [GenerationTask("Rebuild Component", "Rebuilds the current SOLIDWORKS component.", "embedded://DriveWorks.Sdk.Examples.CSharp.Puzzle-16x16.png", "SDK-Starter-Examples Plugin", GenerationTaskScope.All)]
    public class MyGenerationTask : GenerationTask
    {
        private const string REBUILD_TOP_LEVEL_RULE_INVARIANT_NAME = "OnlyTopLevel";

        public override ComponentTaskParameterInfo[] Parameters
        {
            get
            {
                return new ComponentTaskParameterInfo[] { new ComponentTaskParameterInfo(REBUILD_TOP_LEVEL_RULE_INVARIANT_NAME, "Top Level Only", "True to only rebuild the top level model (Default is False).") };
            }
        }

        public override void Execute(SldWorksModelProxy model, ReleasedComponent component, GenerationSettings generationSettings)
        {
            // This method gets called during generation, we now have full access to
            // 1). The release data for the component
            // 2). The evaluated result of our rules defined in the Parameters property
            // 3). The entire SOLIDWORKS API

            bool topLevelOnly = false;

            if (this.Data.TryGetParameterValueAsBoolean(REBUILD_TOP_LEVEL_RULE_INVARIANT_NAME, ref topLevelOnly))
            {
                // The user didn't build a rule for the "Top Level Only" rule, or the rule evaluated
                // to something that couldn't be converted to a Boolean.
                // Report on it, and just use the default value of False
                this.Report.WriteEntry(Reporting.ReportingLevel.Minimal, Reporting.ReportEntryType.Information, "Rebuild Component Task", "Model Generation", "No / Invalid value provided for the 'Top Level Only'-rule. Assuming false.", null);
            }

            var forceRebuildSuccess = model.Model.ForceRebuild3(topLevelOnly);

            if(forceRebuildSuccess)
            {
                this.SetExecutionResult(TaskExecutionResult.Success, "Successfully force rebuilt model.");
            }
            else
            {
                this.SetExecutionResult(TaskExecutionResult.Failed, "Failed to force rebuild model.");
            }

        }

    }
}
