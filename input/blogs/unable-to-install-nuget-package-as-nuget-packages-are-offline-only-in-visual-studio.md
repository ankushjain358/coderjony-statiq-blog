Title: Unable to install NuGet package as NuGet packages are Offline Only in Visual Studio
Published: 14/01/2022
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
You may be facing this issue when working with recently installed Visual Studio. 

## Root Cause:

By default, Visual Studio comes with only one source of NuGet package, which is **Microsoft Visual Studio Offline Packages**. See below picture. ![Unable to install NuGet package as NuGet packages are Offline Only in Visual Studio](/img/blogs/unable-to-install-nuget-package-as-nuget-packages-are-offline-only-in-visual-studio/1-unable-to-install-nuget-package-as-nuget-packages-are-offline-only-in-visual-studio.png)

## Solution

To fix this issue, just add one more NuGet package source with below values.

*   Name: nuget.org

*   Source: [https://api.nuget.org/v3/index.json](https://api.nuget.org/v3/index.json)
![Unable to install NuGet package as NuGet packages are Offline Only in Visual Studio](/img/blogs/unable-to-install-nuget-package-as-nuget-packages-are-offline-only-in-visual-studio/2-unable-to-install-nuget-package-as-nuget-packages-are-offline-only-in-visual-studio.png)



That's all :)

                