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
        private NodeOutput MyNodeOutput { get; }
        public MySpecificationMacroTask()
        {
            // Register properties so DriveWorks can see them and build rules for them.
            MyName = this.Properties.RegisterStringProperty("Name", "Name of the constant to set.");
            MyValue = this.Properties.RegisterStringProperty("Value", "Value of the constant.");
            // Register node output so DriveWorks can output data.
            MyNodeOutput = this.Outputs.Register("Log", "My Task", typeof(string));
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
                this.SetState(NodeExecutionState.Successful, string.Format("The constant '{0}' value was successfully set.", MyName.Value));
                //Set node output value
                MyNodeOutput.Fulfill(string.Format("The constant '{0}' value was successfully set.", MyName.Value));
            }
            else
            {
                // Mark the Task as failed and report that we could not find the constant.
                this.SetState(NodeExecutionState.Failed, string.Format("The constant '{0}' does not exist.", MyName.Value));
                // Set node output value
                MyNodeOutput.Fulfill(string.Format("The constant '{0}' does not exist.", MyName.Value));
            }
        }
    }
}