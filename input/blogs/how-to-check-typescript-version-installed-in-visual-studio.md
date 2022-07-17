Title: How to check TypeScript version installed in Visual Studio?
Published: 19/11/2017
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
To check which version of TypeScript is your Visual Studio using, there are 3 ways.

*   First, you can open Visual Studio and then go to Help menu. Under
   Help menu, click on **About Microsoft Visual Studio** - a popup will
   open that will list all installed products on Visual Studio, you can
   find TypeScript version there. Please see below screenshot:

![enter image description here](/img/blogs/how-to-check-typescript-version-installed-in-visual-studio/typescriptversion_1.png)

*   Second way, If you have multiple versions of TypeScript installed on your machine,
   then you can yo on this path **C:\Program Files (x86)\Microsoft
   SDKs\TypeScript** and here you will find the list of TypeScript
   version installed on your machine. Please see below screenshot:



![enter image description here](/img/blogs/how-to-check-typescript-version-installed-in-visual-studio/typescriptversion_2.png)

*   Third way of checking TypeScript version is to open Visual Studio and
   go to **Tools > Options** menu. A popup will open then - like below
   screen, there you can change below highlighted property to **Detailed**.
   Once you change it to **Detailed** and the build the project - you can
   check the output window to find which version of TypeScript is used
   by Visual Studio for compilation of .ts files.



![enter image description here](/img/blogs/how-to-check-typescript-version-installed-in-visual-studio/typescriptversion_3.png)

![enter image description here](/img/blogs/how-to-check-typescript-version-installed-in-visual-studio/typescriptversion_4.png)

                