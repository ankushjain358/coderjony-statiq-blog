Title: Solution- System.BadImageFormatException- Could not load file or assembly
Published: 20/12/2018
Author: Ankush Jain
IsActive: true
ImageFolder: solution-systembadimageformatexception-could-not-load-file-or-assembly
Tags:
  - .NET
---
Make sure that you are using the correct tool path (i.e. `installutil.exe`) for installing the application. 

This issue normally occurs when we attempt to use 32 bit `(/platform:x86)` version of the tool to install a 64-bit application or a 64-bit `(/platform:x64)` version of the tool to install a 32-bit application.

Just confirm the path you are using is correct. There is a slight difference in both paths.

- C:\Windows\Microsoft.NET\Framework\v2.0.50727
- C:\Windows\Microsoft.NET\Framework**64**\v2.0.50727\

                
