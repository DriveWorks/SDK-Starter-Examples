// Import the Specification namespace so we have access to Specification flow.
using DriveWorks.Specification;

namespace DriveWorks.Sdk.Examples.CSharp
{
    [Task("My Reporting Task", "embedded://DriveWorks.Sdk.Examples.CSharp.Puzzle-16x16.png", "SDK-Starter-Examples Plugin")]
    public class MyReportingTask : Task
    {
        private FlowProperty<string> myReportClass { get; }
        private FlowProperty<string> myReportTarget { get; }
        private FlowProperty<string> myReportDescription { get; }
        private FlowProperty<string> myReportEntryDetail { get; }

        public MyReportingTask()
        {
            // Register properties so DriveWorks can see them and build rules for them.
            myReportClass = this.Properties.RegisterStringProperty("Report Class", "The Report Class is what type of report you are creating and what action you are performing.");
            myReportTarget = this.Properties.RegisterStringProperty("Report Target", "The Report Target identifies what the report entry is referencing.");
            myReportDescription = this.Properties.RegisterStringProperty("Report Description", "Enter a description about the object you are reporting on.");
            myReportEntryDetail = this.Properties.RegisterStringProperty("Report Entry Detail", "Enter a entry detail about the object you are reporting on.");
        }

        protected override void Execute(SpecificationContext ctx)
        {
            // Begin reporting process
            ctx.Report.BeginProcess(myReportClass.Value, myReportTarget.Value, myReportDescription.Value);

            ///Write report 
            ///Reporting.ReportingLevel.Minimal sets reporting level. Select from following: 
            ///None
            ///Minimal
            ///Normal
            ///Verbose
            /// Reporting.ReportEntryType.Information sets reporting entry type. Select one from the following: 
            ///Information
            ///Warning
            ///Error
            ctx.Report.WriteEntry(Reporting.ReportingLevel.Minimal, Reporting.ReportEntryType.Information, myReportClass.Value, myReportTarget.Value, myReportDescription.Value, myReportEntryDetail.Value);

            ///End reporting process
            ctx.Report.EndProcess();
        }
    }
}