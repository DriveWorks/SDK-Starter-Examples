// Import the Specification namespace so we have access to Specification flow.
using DriveWorks.Specification;

namespace DriveWorks.Sdk.Examples.CSharp
{
    [Condition("My Condition", "embedded://DriveWorks.Sdk.Examples.CSharp.Puzzle-16x16.png")]
    public class MySpecificationMacroCondition : Condition
    {
        private FlowProperty<bool> MyProperty { get; }

        public MySpecificationMacroCondition()
        {
            // Register properties so DriveWorks can see them and build rules for them.
            MyProperty = this.Properties.RegisterBooleanProperty("Condition Result", "Specifies the result of the condition.");
        }

        protected override bool Evaluate(SpecificationContext specificationContext)
        {
            // Do something here to determine if the condition is met.
            return MyProperty.Value;
        }
    }
}