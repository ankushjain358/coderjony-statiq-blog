Title: Solution- "PDB does not match image" issue in Post Build event in Visual Studio
Published: 24/03/2018
Author: Ankush Jain
IsActive: true
Tags:
  - .NET
  - IIS
---
## Root Cause
This error normally occurs when you are using **Post Build** event to move your **.PDB & .DLL files** from you current project's bin directory to some other project's bin directory. And when you run the project (in which you have copied the DLLs & PDBs), you find that you are no longer able to debug the project (whose DLLs & PDBs) you have copied from post build event.

## Solution
Simply, stop the IIS before building the project. Because, it is the IIS, which stops a Web Project from copying it's DLL & PDB files after build completion. Once you stop IIS and build the project, IIS will stop using those DLL & PDB files and these files will get copied on destination location & hence this issue will get fixed.

Cheers & Happy Coding...!!! 

                