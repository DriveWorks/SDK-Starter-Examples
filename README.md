## DriveWorks SDK Starter Examples
This code shows examples of how to add functionality to DriveWorks using the SDK.
Examples include:
* Function using a Shared Project Extender and Project Extender
* Generation Task
* Generation Task Specification Condition
* Specification Macro Condition
* Specification Macro Task

This code shows how to get started implementing these features. Examples show the required references, imports statements, attributes and objects.

We have included examples for C# and VB.net 

The examples include implementing a SharedProjectExtender and ProjectExtender.

For DriveWorks to load the Project Extender, you need to have a single class in the Project Extender class library which inherits from ProjectExtender Class.
A ProjectExtender can be loaded into DriveWorks by placing the DLL alongside the DriveWorks Project file (.driveprojx).
The DLL file name must be the same as the DriveWorks Project name.

A SharedProjectExtender must be installed. See the [help file](https://docs.driveworkspro.com/Topic/HowToManuallyInstallAPlugin) for how to do this.

If you need any further clarity on the functionality of this code please contact apisupport@driveworks.co.uk

It is not recommended to download and modify this code. Please implement the code examples into your own solution.

We have a full [integration plugin example](https://github.com/DriveWorks/Labs-Integration-Example) which can be downloaded and modified. 

The SDK is made freely available to all customers with a valid subscription contract.
To obtain the SDK please send an email request to apisupport@driveworks.co.uk.