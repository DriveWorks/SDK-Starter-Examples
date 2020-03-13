using DriveWorks.Extensibility;
using Titan.Rules.Execution;

namespace DriveWorks.Sdk.Examples.CSharp
{
    public class MyProjectExtender : ProjectExtender
    {
        // Note - UDF allowRunDuringLoad parameter is to set to true.
        [Udf(true)]
        [FunctionInfo("Multiplies two numbers.", "SDK-Starter-Examples Plugin")]
        public double MultiplyTheseNumbers([ParamInfo("Value 1", "The first value to multiply.")] double val1, [ParamInfo("Value 2", "The second value to multiply.")] double val2)
        {
            return val1 * val2;
        }
    }
}