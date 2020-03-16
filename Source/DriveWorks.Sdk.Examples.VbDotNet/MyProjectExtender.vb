Imports DriveWorks.Extensibility
Imports Titan.Rules.Execution

Public Class MyProjectExtender
    Inherits ProjectExtender

    ''' <remarks>
    ''' Note the allowRunDuringLoad parameter Is set to true.
    ''' This will cause DriveWorks to initialize the function And make it available to rules before the project opens.
    ''' Because the function Is initialized before the project has been fully loaded
    ''' the function might Not have access to any objects related to the project such
    ''' as form controls, variables, etc when it Is executed. This option Is only recommended
    ''' for functions that rely solely on the parameters passed to the function.
    ''' Such as this one.
    ''' </remarks>
    <Udf(True)>
    <FunctionInfo("Multiplies two numbers.", "SDK-Starter-Examples Plugin")>
    Function MultiplyTheseNumbers(<ParamInfo("Value 1", "The first value to multiply.")> ByVal val1 As Double, <ParamInfo("Value 2", "The second value to multiply.")> ByVal val2 As Double) As Double
        Return val1 * val2
    End Function

End Class