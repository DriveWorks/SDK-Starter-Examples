using DriveWorks.Components.Tasks;
using DriveWorks.Specification;

namespace DriveWorks.Sdk.Examples.CSharp
{
    /// <summary>
    /// A Generation Task Specification Condition which determines whether the value entered is even.
    /// </summary>
    /// <remarks><see cref="ComponentTaskReleaseCondition"/> are evaluated at the time of releasing component-sets.</remarks>
    [ComponentTaskCondition("Is Even",
                            "Passes if the specified value is even.",
                            "embedded://DriveWorks.Sdk.Examples.CSharp.Puzzle-16x16.png",
                            "SDK-Starter-Examples Plugin")]
    public class MyGenerationTaskSpecificationCondition : ComponentTaskReleaseCondition
    {
        private readonly FlowProperty<double> mValue;

        public MyGenerationTaskSpecificationCondition()
        {
            mValue = this.Properties.RegisterDoubleProperty("Value",
                                                            "The value to check for must be an even number for the condition to pass.");
        }

        protected override bool Evaluate(SpecificationContext specificationContext)
        {
            // If a number is evenly divisible by 2 with no remainder, then it is even.
            var isEven = (mValue.Value % 2) == 0;

            return isEven;
        }
    }
}