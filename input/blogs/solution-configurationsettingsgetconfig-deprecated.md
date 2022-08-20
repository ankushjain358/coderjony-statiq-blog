Title: Solution- ConfigurationSettings.GetConfig deprecated
Published: 14/11/2018
Author: Ankush Jain
IsActive: true
ImageFolder: solution-configurationsettingsgetconfig-deprecated
Tags:
  - .NET
---
## Solution:

Just replace 
```cs
ConfigurationSettings.GetConfig
```
with 
```cs
ConfigurationManager.GetSection
```
