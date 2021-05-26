Imports DriveWorks.Extensibility
Imports Titan.Rules.Execution

Public Class MyErrorStrings
    Inherits ProjectExtender

    Private Const EXAMPLE_ERROR_STRING = "#FINDUSERID! User ID invalid."
    '<remarks>
    'UDF validates User ID input.
    ' If User ID Is 3 characters In length Function will output successful message otherwise an error string. 
    '</remarks>   
    <Udf(True)>
    <FunctionInfo("This function returns an error string if the user ID supplied is not 3 characters in length. Error strings can be caught in rules using IfErrorString() or IsErrorString().", "SDK-Starter-Examples Plugin")>
    Function ExampleErrorString(<ParamInfo("User ID", "Enter User ID integer.")> ByVal userID As String) As Object

        If (userID.Length = 3) Then

            Return String.Format("User ID: {0} has been validated successfully.", userID)

        Else

            Return EXAMPLE_ERROR_STRING

        End If
    End Function
End Class