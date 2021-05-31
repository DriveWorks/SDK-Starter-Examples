using DriveWorks.Components;
using DriveWorks.SolidWorks;
using DriveWorks.SolidWorks.Generation;
using DriveWorks.SolidWorks.Generation.Proxies;

namespace DriveWorks.Sdk.Examples.CSharp
{
    /// <summary>
    /// A Generation Task Generation Condition which determines whether the model has multiple configurations.
    /// </summary>
    /// <remarks><see cref="GenerationTaskCondition"/> are evaluated at the time of generating component-sets.</remarks>
    [GenerationTaskCondition("Has Multiple Configurations",
                             "Checks whether the model has multiple configurations.",
                             "embedded://DriveWorks.Sdk.Examples.CSharp.Puzzle-16x16.png",
                             "SDK-Starter-Examples Plugin",
                             GenerationTaskScope.Parts | GenerationTaskScope.Assemblies)]
    public class MyGenerationTaskGenerationCondition : GenerationTaskCondition
    {
        protected override bool Evaluate(SldWorksModelProxy model, ReleasedComponent component, GenerationSettings generationSettings)
        {
            // Using the provided SldWorksModelProxy object to query information from the current model.
            var nbrOfConfigurations = model.Model.GetConfigurationCount();
            var hasMultipleConfigurations = nbrOfConfigurations > 1;

            // EvaluationResultDetails will be used by DriveWorks for reporting in the Model Generation Reports or Model Insight.
            if (hasMultipleConfigurations)
            {
                this.EvaluationResultDetails = $"The component has multiple configurations. ({nbrOfConfigurations} found).";
            }
            else
            {
                this.EvaluationResultDetails = "The component has 1 configuration only.";
            }

            return hasMultipleConfigurations;
        }
    }
}