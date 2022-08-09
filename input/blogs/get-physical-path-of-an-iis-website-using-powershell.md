Title: Get physical path of an IIS website using PowerShell
Published: 28/08/2018
Author: Ankush Jain
IsActive: true
Tags:
  - IIS
  - .NET
---
Below piece of code will give you physical path of an IIS website.

```
Import-Module WebAdministration

[string] $iisWebsiteName = 'Default Web Site'

$iisWebsite = Get-WebFilePath "IIS:\Sites\$iisWebsiteName"

if($iisWebsite -ne $null)
{ 
    Write-Output "Website's physical path:"
    Write-Output $iisWebsite.FullName
}
else
{
    Write-Output "Website not found"
} 
```

## See below image:
![enter image description here](/img/blogs/get-physical-path-of-an-iis-website-using-powershell/get-physical-path-of-an-iis-website-using-powershell.png)

                