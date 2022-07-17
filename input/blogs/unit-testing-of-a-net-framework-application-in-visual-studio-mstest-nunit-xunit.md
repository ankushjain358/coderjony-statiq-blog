Title: Unit Testing of a .NET Framework application in Visual Studio - MSTest, NUnit & xUnit
Published: 28/06/2020
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
I am just documenting all my research and learning that I did to build my concepts regarding the Unit Testing of a **.NET Framework** application in **Visual Studio** using various Test Frameworks. I would be glad if this learning will be useful for you as well.

## 1. Test Frameworks

Below are 3 main Unit Test framework for writing unit tests for any .NET Framework application.

*   MS Test

*   NUnit

*   xUnit



## 2. Creating a Test Project in Visual Studio

By default, for `.NET Framework` - Visual Studio provides a template for `MS Test` only. If you want to use `NUnit` or `xUnit` Test Frameworks, then you have two options.

*   Create a Class Library project and install the respective NuGet packages.

*   Install the NUnit/xUnit project template from Visual Studio Marketplace.



## 3. Running NUnit & xUnit Unit Tests in Visual Studio Test Explorer (Test Runner)

To run the tests written with MS Test requires no additional setup, you can run them from Visual Studio Test Explorer. But to run the unit tests written with NUnit and xUnit, you have to work a little extra, you just need to install their adapter.

> Visual Studio Test Explorer runner can run tests from any unit test framework that has developed an adapter interface for it.

#### NUnit Adapter Installation (2 Options)

*   Visual Studio > Go to Tools > Extensions and Updates > Search NUnit Adapter **online** > Download

*   Install NuGet package (Search for NUnit Adapter )



Refer this link - [How to choose between Extension and NuGet package?](http://nunit.org/nunitv2/docs/2.6.4/vsTestAdapter.html)

#### xUnit Adapter Installation (1 Option)

*   Install NuGet package (Search for `xunit.runner.visualstudio`)



> Visual Studio Extensions are no longer supported for xUnit.

## 4. Running Unit Tests from Command Line

*   

**MSTest.exe** - You can use the MSTest.exe program to run automated tests in a test assembly from a command line. This is a legacy tool. 

*   

**VSTest.Console.exe** - This is the latest offering from Microsoft to run automated unit and coded UI tests from a command line. VSTest.Console.exe is optimized in performance and can be used in place of MSTest.exe.

## 5. References:

#### NUnit:

*   [Getting started with .NET unit testing using NUnit](https://www.infragistics.com/community/blogs/b/dhananjay_kumar/posts/getting-started-with-net-unit-testing-using-nunit)

*   [NUnit Version 2 Documentation Archive](http://nunit.org/nunitv2/docs/2.6.4/vsTestAdapter.html)



#### xUnit:

*   [Getting Started with xUnit.net](https://xunit.net/docs/getting-started/netfx/visual-studio) 


                