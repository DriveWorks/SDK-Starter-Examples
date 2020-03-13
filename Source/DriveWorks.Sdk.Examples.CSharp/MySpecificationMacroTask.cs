// Import the Specification namespace so we have access to Specification flow.
using DriveWorks.Specification;

// Import EventFlow to access the Task EventFlow technology. 
using DriveWorks.EventFlow;

namespace DriveWorks.Sdk.Examples.CSharp
{
    [Task("My Task", "embedded://DriveWorks.Sdk.Examples.CSharp.Puzzle-16x16.png", "SDK-Starter-Examples Plugin")]
    public class MySpecificationMacroTask : Task
    {
        private FlowProperty<string> MyName { get; }
        private FlowProperty<string> MyValue { get; }

        public MySpecificationMacroTask()
        {
            // Register properties so DriveWorks can see them and build rules for them.
            MyName = this.Properties.RegisterStringProperty("Name", "Name of the constant to set.");
            MyValue = this.Properties.RegisterStringProperty("Value", "Value of the constant.");
        }

        protected override void Execute(SpecificationContext ctx)
        {
            ProjectConstant theConstant = null;

            // Perform the main work of the task here.
            if (ctx.Project.Constants.TryGetConstant(MyName.Value, ref theConstant))
            {
                // Set the constant value.
                theConstant.Value = MyValue.Value;

                // Mark the Task as successful. 
                this.SetState(NodeExecutionState.Successful, "The constant value was successfully set.");
            }
            else
            {
                // Mark the Task as failed and report that we could not find the constant.
                this.SetState(NodeExecutionState.Failed, "The constant '" + MyName.Value + "' does not exist.");
            }
        }
    }
}