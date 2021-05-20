Imports DriveWorks.Extensibility
Imports Titan.Rules.Execution

Public Class MyStandardArray
    Inherits SharedProjectExtender

    <Udf(True)>
    <FunctionInfo("Get DriveWorks Array.", "SDK-Starter-Examples Plugin")>
    Public Function ExampleMyStandardArray() As Object

        'Call BuildStandardArray method for dummy data object
        Return New StandardArrayValue(Me.BuildStandardArray())

    End Function

    Private Function BuildStandardArray() As Object

        ' Declare Standard Array object
        Dim standardArrayObject = New Object(1, 4) {}
        'Populate table headers
        standardArrayObject(0, 0) = "Days"
        standardArrayObject(0, 1) = "Hours"
        standardArrayObject(0, 2) = "Minutes"
        standardArrayObject(0, 3) = "Seconds"
        standardArrayObject(0, 4) = "Milliseconds"
        'Populate table data 
        standardArrayObject(1, 0) = "10"
        standardArrayObject(1, 1) = "20"
        standardArrayObject(1, 2) = "30"
        standardArrayObject(1, 3) = "40"
        standardArrayObject(1, 4) = "50"

        Return standardArrayObject

    End Function
End Class