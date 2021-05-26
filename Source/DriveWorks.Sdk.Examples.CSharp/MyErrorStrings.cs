using DriveWorks.Extensibility;
using Titan.Rules.Execution;

namespace DriveWorks.Sdk.Examples.CSharp
{
    public class ExampleErrorStrings : SharedProjectExtender
    {
        private const string EXAMPLE_ERROR_STRING = "#FINDUSERID! User ID invalid.";

        /// <remarks>
        /// UDF validates User ID input.
        /// If User ID is 3 characters in length function will output successful message otherwise an error string. 
        /// </remarks>   
        [Udf(true)]
        [FunctionInfo("This function returns an error string if the user ID supplied is not 3 characters in length. Error strings can be caught in rules using IfErrorString() or IsErrorString().", "SDK-Starter-Examples Plugin")]
        public object ExampleErrorString([ParamInfo("User ID", "Enter User ID.")] string userID)
        {
            if (userID.Length == 3)
            {
                return string.Format("User ID: {0} has been validated successfully.", userID);
            }
            else
            {
                return EXAMPLE_ERROR_STRING;
            }
        }
    }
}