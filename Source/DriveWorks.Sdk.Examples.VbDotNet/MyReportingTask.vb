' Import the Specification namespace so we have access to Specification flow.
Imports DriveWorks.Specification

' Import EventFlow to access the Task EventFlow technology.
Imports DriveWorks.EventFlow

<Task("My Reporting Task", "embedded://DriveWorks.Sdk.Examples.VbDotNet.Puzzle-16x16.png", "SDK-Starter-Examples Plugin")>
Public Class MyReportingTask
    Inherits Task

    ' Register properties so DriveWorks can see them and build rules for them.
    Private ReadOnly myReportClass As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Report Class", "The Report Class is what type of report you are creating and what action you are performing.")
    Private ReadOnly myReportTarget As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Report Target", "The Report Target identifies what the report entry is referencing.")
    Private ReadOnly myReportDescription As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Report Description", "Enter a description about the object you are reporting on.")
    Private ReadOnly myReportEntryDetail As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Report Entry Detail", "Enter a entry detail about the object you are reporting on.")

    Protected Overrides Sub Execute(ByVal ctx As SpecificationContext)

        'Begin reporting process
        ctx.Report.BeginProcess(myReportClass.Value, myReportTarget.Value, myReportDescription.Value)

        'Write report 
        'Reporting.ReportingLevel.Minimal sets reporting level. Select from following: 
        'None
        'Minimal
        'Normal
        'Verbose
        ' Reporting.ReportEntryType.Information sets reporting entry type. Select one from the following: 
        'Information
        'Warning
        'Error
        ctx.Report.WriteEntry(Reporting.ReportingLevel.Minimal, Reporting.ReportEntryType.Information, myReportClass.Value, myReportTarget.Value, myReportDescription.Value, myReportEntryDetail.Value)

        'End reporting process
        ctx.Report.EndProcess()

    End Sub
End Class