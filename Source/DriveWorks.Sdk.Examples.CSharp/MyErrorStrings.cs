using DriveWorks.Extensibility;
using System.Collections.Generic;
using Titan.Rules.Execution;

namespace DriveWorks.Sdk.Examples.CSharp
{
    public class MyErrorStrings : ProjectExtender
    {
        [Udf(true)]
        [FunctionInfo("Multiplies two numbers.", "SDK-Starter-Examples Plugin")]
        public string ExampleErrorStrings()
        {
            var isErrorStringExample = "#PREFIX! Problem description.";
            var isErrorExample = "#NAME?";

            return string.Format("IsErrorString({0}) result: {1}. IsError({2}) result: {3}.",
                    isErrorStringExample,
                    this.IsErrorString(isErrorStringExample),
                    isErrorExample,
                    this.IsError(isErrorExample));
        }

        private bool IsErrorString(string isErrorStringExample)
        {
            //Check if isErrorStringExample isErrorString
            return Titan.Rules.Common.StringFunctions.IsErrorString(isErrorStringExample);
        }

        private bool IsError(string isErrorExample)
        {
            //Initialize list of isError patterns 
            List<string> isErrorPatern = new List<string>(new string[] { "#N/A", "#VALUE!", "#REF!", "#DIV/0!", "#NUM!", "#NAME?", "#NULL" });
            //Check isErrorPatern contains isErrorExample
            return isErrorPatern.Contains(isErrorExample);
        }
    }
}