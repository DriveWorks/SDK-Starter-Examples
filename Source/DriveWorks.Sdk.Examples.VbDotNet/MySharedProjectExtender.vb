Imports DriveWorks.Extensibility
Imports Titan.Rules.Execution

Public Class MySharedProjectExtender
    Inherits SharedProjectExtender

    Private mStartTime As DateTime?

    Protected Overrides Sub OnInitialize()
        MyBase.OnInitialize()
        Me.EnsureStartTimeSet()
    End Sub

    ''' <remarks>
    ''' Note the allowRunDuringLoad parameter Is set to true.
    ''' This will cause DriveWorks to initialize the function And make it available to rules before the project opens.
    ''' Because the function Is initialized before the project has been fully loaded
    ''' the function might Not have access to any objects related to the project such
    ''' as form controls, variables, etc when it Is executed. This option Is only recommended
    ''' for functions that rely solely on the parameters or object data which does not interact with DriveWorks.
    ''' Such as this one.
    ''' </remarks>
    <Udf(True)>
    <FunctionInfo("Gets the time that the project was opened.", "SDK-Starter-Examples Plugin")>
    Public Function EXAMPLEStartTime() As DateTime

        ' Note: The function can be called before the project is fully loaded.
        Me.EnsureStartTimeSet()

        Return mStartTime.Value
    End Function

    Private Sub EnsureStartTimeSet()

        ' Ensure we only set this once (first call).
        If mStartTime.HasValue Then
            Return
        End If

        mStartTime = DateTime.Now
    End Sub

End Class