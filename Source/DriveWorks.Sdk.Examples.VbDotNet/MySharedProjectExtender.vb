Imports DriveWorks.Extensibility
Imports Titan.Rules.Execution

Public Class MySharedProjectExtender
    Inherits SharedProjectExtender

    Private mStartTime As DateTime?

    Protected Overrides Sub OnInitialize()
        MyBase.OnInitialize()

        Me.EnsureStartTimeSet()
    End Sub

    <Udf()>
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