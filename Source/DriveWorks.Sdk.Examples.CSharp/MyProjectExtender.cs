using DriveWorks.Extensibility;
using Titan.Rules.Execution;

namespace DriveWorks.Sdk.Examples.CSharp
{
    public class MyProjectExtender : ProjectExtender
    {
        /// <remarks>
        /// Note the allowRunDuringLoad parameter is set to true.
        /// This will cause DriveWorks to initialize the function and make it available to rules before the project opens.
        /// Because the function is initialized before the project has been fully loaded
        /// the function might not have access to any objects related to the project such
        /// as form controls, variables, etc when it is executed. This option is only recommended
        /// for functions that rely solely on the parameters or object data which does not interact with DriveWorks.
        /// Such as this one.
        /// </remarks>
        [Udf(true)]
        [FunctionInfo("Multiplies two numbers.", "SDK-Starter-Examples Plugin")]
        public double MultiplyTheseNumbers([ParamInfo("Value 1", "The first value to multiply.")] double val1, [ParamInfo("Value 2", "The second value to multiply.")] double val2)
        {
            return val1 * val2;
        }
    }
}