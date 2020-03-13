Imports DriveWorks.Extensibility
Imports Titan.Rules.Execution

Public Class MyProjectExtender
    Inherits ProjectExtender

    <Udf()>
    <FunctionInfo("Multiplies two numbers.", "SDK-Starter-Examples Plugin")>
    Function MultiplyTheseNumbers(<ParamInfo("Value 1", "The first value to multiply.")> ByVal val1 As Double, <ParamInfo("Value 2", "The second value to multiply.")> ByVal val2 As Double) As Double
        Return val1 * val2
    End Function

End Class