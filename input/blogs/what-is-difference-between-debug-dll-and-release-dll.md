Title: What is difference between Debug DLL and Release DLL ?
Published: 16/05/2017
Author: Ankush Jain
IsActive: true
ImageFolder: what-is-difference-between-debug-dll-and-release-dll
Tags:
  - .NET
---
If you are a .NET Developer then you must know that there are mainly two build configurations. 
- Debug 
- Release

**Debug** is used in Development Environment while **Release** is used in Production Environment.

## Now, what is difference between the dll files generated in both mode?
DLL files generated in Debug mode contains additional Debug Symbolic Information to provide debug information while debugging. Also, compiled code in debug dll is not optimized. Therefore size of dll file in Debug mode is comparaively larger then release mode.

On other hand, DLL files generated in Release mode are far optimized, also debugging symbol information is also omitted from the DLLs in this mode. Therefore, size of dll files generated in Release mode is comparaively smaller then files generated in Debug mode.

- Note: It is advised to publish your code in release mode.


                
