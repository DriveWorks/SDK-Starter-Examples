' Import the Specification namespace so we have access to Specification flow.
Imports DriveWorks.Specification

' Import EventFlow to access the Task EventFlow technology.
Imports DriveWorks.EventFlow

<Task("My Task", "embedded://DriveWorks.Sdk.Examples.VbDotNet.Puzzle-16x16.png", "SDK-Starter-Examples Plugin")>
Public Class MySpecificationMacroTask
    Inherits Task

    ' Register properties so DriveWorks can see them and build rules for them.
    Private ReadOnly mMyName As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Name", "Name of the constant to set.")
    Private ReadOnly mMyValue As FlowProperty(Of String) = Me.Properties.RegisterStringProperty("Value", "Value of the constant.")
    ' Register node output so DriveWorks can output data.
    Private ReadOnly myNodeOutput As NodeOutput = Me.Outputs.Register("Log", "My Task", GetType(String))

    Protected Overrides Sub Execute(ByVal ctx As SpecificationContext)
        Dim theConstant As ProjectConstant = Nothing

        ' Perform the main work of the task here.
        If ctx.Project.Constants.TryGetConstant(mMyName.Value, theConstant) Then

            ' Set the constant value. 
            theConstant.Value = mMyValue.Value
            ' Mark the Task as successful. 
            Me.SetState(NodeExecutionState.Successful, String.Format("The constant '{0}' value was successfully set.", mMyName.Value))
            'Set node output value
            myNodeOutput.Fulfill(String.Format("The constant '{0}' value was successfully set.", mMyName.Value))

        Else

            ' Mark the Task as failed and report that we could not find the constant.
            Me.SetState(NodeExecutionState.Failed, String.Format("The constant '{0}' does not exist.", mMyName.Value))
            'Set node output value
            myNodeOutput.Fulfill(String.Format("The constant '{0}' does not exist.", mMyName.Value))

        End If
    End Sub
End Class