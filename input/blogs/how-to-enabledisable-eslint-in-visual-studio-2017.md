Title: How to enable/disable ESLint in Visual Studio 2017 ?
Published: 15/03/2018
Author: Ankush Jain
IsActive: true
ImageFolder: how-to-enabledisable-eslint-in-visual-studio-2017
Tags:
  - Visual Studio
---
## What is ESLint?
ESLint is a tool which allows us to write clean, optimized, organized & valid JavaScript code by following a set of rules or coding guidelines.

**ESLint** has already been integrated in **Visual Studio 2017** by **Microsoft**. You can enable or disable it as per your project requirement.

## Enable or disable ESLint in Visual Studio 2017
To enable it, you can go to **Tools > Options > Text Editor > JavaScript/TypeScript > ESLint**

![How to enable or disable it in Visual Studio 2017](/img/blogs/how-to-enabledisable-eslint-in-visual-studio-2017/eslint-in-visualstudio-2017.png)

 **ESLint** follows rules from a file named `.eslintrc` which you can find on below location. You can also modify this file and change rules as per your project requirement.

```bash
C:\Users\ankushjain
```

![.eslintrc file path](/img/blogs/how-to-enabledisable-eslint-in-visual-studio-2017/eslintrc.png)

 **ESLint** in **Visual Studio** works whenever you open or save any javascript file. It will also show your errors, warnings & information in **ErrorList pane**. See below image.

![ESLint error list pane](/img/blogs/how-to-enabledisable-eslint-in-visual-studio-2017/eslint-errorlist-pane.png)
                
