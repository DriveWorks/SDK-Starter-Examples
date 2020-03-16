using DriveWorks.Extensibility;
using System;
using Titan.Rules.Execution;

namespace DriveWorks.Sdk.Examples.CSharp
{
    public class MySharedProjectExtender : SharedProjectExtender
    {
        private DateTime? mStartTime;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            this.EnsureStartTimeSet();
        }

        /// <remarks>
        /// Note the allowRunDuringLoad parameter is set to true.
        /// This will cause DriveWorks to initialize the function and make it available to rules before the project opens.
        /// Because the function is initialized before the project has been fully loaded
        /// the function might not have access to any objects related to the project such
        /// as form controls, variables, etc when it is executed. This option is only recommended
        /// for functions that rely solely on the parameters passed to the function.
        /// Such as this one.
        /// </remarks>
        [Udf(true)]
        [FunctionInfo("Gets the time that the project was opened.", "SDK-Starter-Examples Plugin")]
        public DateTime EXAMPLEStartTime()
        {
            // Note: The function can be called before the project is fully loaded.
            this.EnsureStartTimeSet();
            return mStartTime.Value;
        }

        private void EnsureStartTimeSet()
        {
            // Ensure we only set this once (first call).
            if (mStartTime.HasValue)
            {
                return;
            }

            mStartTime = DateTime.Now;
        }
    }
}