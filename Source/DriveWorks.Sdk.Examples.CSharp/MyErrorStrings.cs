using DriveWorks.Extensibility;
using Titan.Rules.Execution;

namespace DriveWorks.Sdk.Examples.CSharp
{
    public class ExampleErrorStrings : SharedProjectExtender
    {
        private const string EXAMPLE_ERROR_STRINGS = "#FINDUSERID! User ID invalid.";
        /// <remarks>
        /// UDF validates User ID input.
        /// If User ID is 3 characters in length function will output successful message otherwise an error. 
        /// </remarks>   
        [Udf(true)]
        [FunctionInfo("ExampleErrorString.", "SDK-Starter-Examples Plugin")]
        public object ExampleErrorString([ParamInfo("User ID", "Enter User ID.")] string userID)
        {
            if (userID.Length == 3)
            {
                return string.Format("User ID: {0} has been validated successfully.", userID);
            }
            else
            {
                return EXAMPLE_ERROR_STRINGS;
            }
        }
    }
}