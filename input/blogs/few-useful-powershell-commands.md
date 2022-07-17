Title: Few useful PowerShell commands
Published: 08/06/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Here I am sharing few useful PowerShell commands which I found quite useful in my day to day coding. I hope these will help you as well.

## To print something in the console

`Write-Output "Database published from DACPAC"
`

## To delete all files & sub-folders from a folder

`<# Variable declaration #>
$targetFolderPath = "E:\Published\Admin"

<# Clean output folder #>
Get-ChildItem -Path $targetFolderPath -Recurse| Foreach-object {Remove-item -Recurse -path $_.FullName }
`

## To change the working location

`Set-Location -Path E:\Published\Admin
`

                