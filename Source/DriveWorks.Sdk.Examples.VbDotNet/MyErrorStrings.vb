Imports DriveWorks.Extensibility
Imports Titan.Rules.Execution

Public Class MyErrorStrings
    Inherits ProjectExtender

    Private Const CONTENT_LENGTH_ERROR_PREFIX = "#FINDUSERID! User ID invalid."
    '<remarks>
    'UDF validates User ID input.
    ' If User ID Is 3 characters In length Function will output successful message otherwise an Error. 
    '</remarks>   
    <Udf(True)>
    <FunctionInfo("ExampleErrorString.", "SDK-Starter-Examples Plugin")>
    Function ExampleErrorString(<ParamInfo("User ID", "Enter User ID integer.")> ByVal userID As String) As Object

        If (userID.Length = 3) Then

            Return String.Format("User ID: {0} has been validated successfully.", userID)

        Else

            Return CONTENT_LENGTH_ERROR_PREFIX

        End If
    End Function
End Class