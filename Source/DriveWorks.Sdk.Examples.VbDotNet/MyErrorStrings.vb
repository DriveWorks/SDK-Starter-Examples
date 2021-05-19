Imports DriveWorks.Extensibility
Imports Titan.Rules.Execution

Public Class MyErrorStrings
    Inherits ProjectExtender

    <Udf(True)>
    <FunctionInfo("Multiplies two numbers.", "SDK-Starter-Examples Plugin")>
    Function ExampleErrorStrings() As Object

        Dim isErrorStringExample As String = "#PREFIX! Problem description."
        Dim isErrorExample As String = "#NAME?"

        Return String.Format("IsErrorString({0}) result: {1}. IsError({2}) result: {3}.",
                             isErrorStringExample,
                             Me.IsErrorString(isErrorStringExample),
                             isErrorExample,
                             Me.IsError(isErrorExample))

    End Function

    Private Function IsErrorString(isErrorStringExample As String) As Boolean

        'Check if isErrorStringExample isErrorString
        Return Titan.Rules.Common.StringFunctions.IsErrorString(isErrorStringExample)

    End Function

    Private Function IsError(isErrorExample As String) As Boolean

        'Initialize list of isError patterns 
        Dim isErrorPatern() As String = {"#N/A", "#VALUE!", "#REF!", "#DIV/0!", "#NUM!", "#NAME?", "#NULL"}
        'Check isErrorPatern contains isErrorExample
        Return isErrorPatern.Contains(isErrorExample)

    End Function
End Class