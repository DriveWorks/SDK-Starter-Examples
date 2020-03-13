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

        [Udf()]
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