using DriveWorks.Extensibility;
using Titan.Rules.Execution;

namespace DriveWorks.Sdk.Examples.CSharp
{
    public class MyStandardArray : SharedProjectExtender
    {
        [Udf(true)]
        [FunctionInfo("Get DriveWorks Array", "SDK-Starter-Examples Plugin")]
        public object ExampleMyStandardArray()
        {
            // Call BuildStandardArray method for dummy data object
            return new StandardArrayValue(this.BuildStandardArray());
        }

        private object[,] BuildStandardArray()
        {
            // Declare Standard Array object
            var standardArrayObject = new object[2, 5];

            // Populate table headers
            standardArrayObject[0, 0] = "Days";
            standardArrayObject[0, 1] = "Hours";
            standardArrayObject[0, 2] = "Minutes";
            standardArrayObject[0, 3] = "Seconds";
            standardArrayObject[0, 4] = "Milliseconds";
            // Populate table data 
            standardArrayObject[1, 0] = "10";
            standardArrayObject[1, 1] = "20";
            standardArrayObject[1, 2] = "30";
            standardArrayObject[1, 3] = "40";
            standardArrayObject[1, 4] = "50";

            return standardArrayObject;
        }
    }
}