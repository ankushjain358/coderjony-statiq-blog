Title: Basic programming syntax in PowerShell for C# developers
Published: 02/08/2018
Author: Ankush Jain
IsActive: true
ImageFolder: basic-programming-syntax-in-powershell-for-c-developers
Tags:
  - PowerShell
---
Recently I started working on PowerShell as I was working on C# for a long time. Initially, it took me a while to get familiar with the PowerShell syntaxes. That’s why I thought to put all my google searches over here in this single post. I hope this will help you during your transition period from C# to PowerShell.

## How to use for loop in PowerShell?
```powershell
# declare & initialize an array
[string[]] $names = @("Ankush", "Virat", "Sachin", "MS Dhoni")

# call for loop
For ($i=0; $i -lt $names.count ; $i++) {

    [string]$playerName =  $names[$i]

    Write-Output $playerName
}
```

## How to use foreach in PowerShell?
```powershell
# declare & initialize an array
[string[]] $names = @("Ankush", "Virat", "Sachin", "MS Dhoni")

# call foreach
Foreach ($playerName in $names)
{   
    Write-Output $playerName
}
```

## How to use if block in PowerShell?
```powershell
[bool] $result = $true

if($result){
    Write-Output "Success"
}
```

## Declare an array in PowerShell?
```powershell
# declare & initialize an array
[string[]] $names = @("Ankush", "Virat", "Sachin", "MS Dhoni")
```

## How to check if array contains a value in PowerShell?
```powershell
# declare & initialize an array
[string[]] $names = @("Ankush", "Virat", "Sachin", "MS Dhoni")

if($names.Contains("Ankush")){
    Write-Output "Yes Ankush Exists"
}
```

## How to add an item in PowerShell?
```powershell
# declare & initialize an array
[string[]] $names = @("Ankush", "Virat", "Sachin", "MS Dhoni")

# add item in array
$names += "Ishant"
```

## How to use less than, equals to etc. operators in PowerShell?
```powershell
$i = 4
$j = 8

# use -eq for equal operator
Write-Output ($i -eq $j)

# use -le for less than or equal operator
Write-Output ($i -le $j)
```

## How to save a JSON object to a file in PowerShell?
```powershell
[string]$pathToSave =  "C:\Users\ankushjain01\Desktop\"

$apiResult =  Invoke-RestMethod -Uri "http://example.com/getusers" -Method Get -ContentType "application/json"

# code to save json
$apiResult | ConvertTo-Json -depth 100 | Set-Content "$pathToSave\users.json"
```

## How to call a REST API using PowerShell?
```powershell
# physical path to save json result
[string]$pathToSave =  "C:\Users\ankushjain01\Desktop\"

# Base64-encodes the Personal Access Token (PAT) appropriately
[string]$base64AuthInfo = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(("{0}:{1}" -f $user,$password)))

# this method invokes rest api & downloads it's result into json object
$apiResult =  Invoke-RestMethod -Uri "http://example.com/getusers" -Method Get -ContentType "application/json" -Headers @{Authorization=("Basic {0}" -f $base64AuthInfo)}

# code to save json
$apiResult | ConvertTo-Json -depth 100 | Set-Content "$pathToSave\users.json"
```

                
