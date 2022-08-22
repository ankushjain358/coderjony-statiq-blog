Title: Insight on some .NET terms for better clarity
Published: 24/12/2021
Author: Ankush Jain
IsActive: true
ImageFolder: insight-on-some-net-terms-for-better-clarity
Tags:
  - .NET 
  - .NET Core
---
The primary goal of this post is to clarify the meanings of selected terms and acronyms that appear frequently in the .NET documentation.

## BCL
A set of libraries that comprise the `System.*` (and to a limited extent `Microsoft.*` ) namespaces. The BCL is a general purpose, a lower-level framework that higher-level **application frameworks**, such as ASP.NET Core, build on.

The following terms often refer to the same collection of APIs that BCL refers to:
*   core .NET libraries
*   framework libraries
*   runtime libraries
*   shared framework

Both **.NET Framework** and **.NET 5 (and .NET Core) and later versions** have a different set of base class libraries that works as a **lower-level framework**. Other higher-level **application frameworks** such ASP.NET Core, WCF, LINQ, Entity Framework, etc. consider this BCL as their base, and they build on top of it.

## .NET Framework
An implementation of .NET that runs only on Windows. This includes the following:
*   Common Language Runtime (CLR)
*   Base Class Library (BCL)
*   Application framework libraries such as ASP.NET, Windows Forms, and WPF


## .NET 5 (and .NET Core) and later versions
A cross-platform, high-performance, open-source implementation of .NET. Also referred to as .NET 5+. This includes the following: 
*   Common Language Runtime (Core CLR)
*   AOT runtime (CoreRT, in development) 
*   Base Class Library (BCL)
*   .NET SDK  (It contains everything you need to build and run .NET apps. It includes .NET CLI, compiler, .NET libraries and runtime.)

## .NET runtime - In context of  .NET 5 (and .NET Core) and later versions
You can download the .NET runtime or other runtimes, such as the ASP.NET Core runtime. A runtime in this usage is the set of components that must be installed on a machine to run a framework-dependent app on the machine.

The .NET runtime includes the CLR and the .NET shared framework, which provides the BCL.

Some examples:
*   .NET runtime = Core CLR + BCL (CoreFX or Shared framework)
*   .NET Desktop Runtime = Core CLR + BCL (shared framework) + .NET Desktop framework libraries (application framework)
*   ASP.NET Core Runtime =  Core CLR + BCL (shared framework) + ASP.NET Core framework libraries (application framework)

The .NET Runtime contains just the components needed to run a console app. Typically, you'd also install either the ASP.NET Core Runtime or .NET Desktop Runtime.

## Framework-dependent vs Self-contained apps
Applications you create with .NET can be published in two different modes, and the mode affects how a user runs your app.

Publishing your app as ***self-contained*** produces an application that includes the .NET runtime (CoreCLR and shared framework assemblies), your application and its dependencies. Users of the application can run it on a machine that doesn't have the .NET runtime installed.

Publishing your app as ***framework-dependent*** produces an application that includes only your application itself and its dependencies. Users of the application have to separately install the .NET runtime.

## Reference
*   [.NET Glossary](https://docs.microsoft.com/en-us/dotnet/standard/glossary)


                
