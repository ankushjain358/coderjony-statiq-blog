Title: Difference between SET and SETX in PowerShell
Published: 29/05/2018
Author: Ankush Jain
IsActive: true
Tags:
  - PowerShell
---
> Both commands are used to set environment variable value in windows through command-line.

## SET
SET is used to create new environment variable or change the value of existing environment variable. 

Its scope remains limited to the current shell (window). Once the window is closed, the environment variable gets deleted if it is new one else its value gets reverted to its original value.

```powershell
SET  MachineName = "Ankush Jain PC"
```

## SETX
SETX is used for the same purpose as SET is used. Like for creating new environment variable or updating the value of existing one. 

But, SETX updates the value permanently & Its scope doesn't remain limited to the current shell. It means that even if you close the current shell & reopen it, you will find your changes there. However, it will not affect already running shells & will not change enviorment variables value there. Once user open those shells again, they will get updated value.

Important thing, SETX further have scope to the currently logged-in user. If you want to set an environment variable for all users or on the machine level, you should use below syntax.

**For currently logged-in user**
```powershell
SETX MachineName "Ankush Jain PC"
```

**For All user** 
```powershell
SETX MachineName "Ankush Jain PC" /M 
```

You can use `SETX /?` for more options.