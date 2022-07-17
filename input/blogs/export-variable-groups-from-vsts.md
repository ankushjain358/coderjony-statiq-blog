Title: Export Variable Groups from VSTS
Published: 02/08/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Recently I stuck in a situation where I wanted to export variable groups from my VSTS account but there was no such option to export variable group. That time I came to know that VSTS has also exposed its API. After that, I just wrote a PowerShell to download all variable groups into a JSON file by calling its API.

## PowerShell code to export variable group into JSON file

    ```
    Param(
       [string]$vstsAccount = 'yourAccountName', # https://yourAccountName.visualstudio.com/
       [string]$projectName = 'yourProjectName',
       [string]$user = 'yourEmail@gmail.com',
       [string]$token = 'werkwfj080dcmoirjfmwj98eh9fenc',
       [string]$pathToSave =  "C:\Users\ankushjain\Desktop\VariableGroupFolder"

    )

    # Base64-encodes the Personal Access Token (PAT) appropriately
    [string]$base64AuthInfo = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(("{0}:{1}" -f $user,$token)))

    [string]$vstsApiBaseUrl = "https://$vstsAccount.visualstudio.com/$projectName"

    [string]$apiUrlGetVariableGroups = "$vstsApiBaseUrl/_apis/distributedtask/variablegroups?api-version=4.1-preview.1"

    # this method delete all files & folder of destination folder
    Function CleanOuputFolder{
        Get-ChildItem -Path $pathToSave -Recurse| Foreach-object {Remove-item -Recurse -path $_.FullName }
    }

    # this method downloads variable groups
    Function DownloadVariableGroups{

        Write-Output "Downloading variable groups"

        $variableGroupResult =  Invoke-RestMethod -Uri $apiUrlGetVariableGroups -Method Get -ContentType "application/json" -Headers @{Authorization=("Basic {0}" -f $base64AuthInfo)}

        $variableGroupResult | ConvertTo-Json -depth 100 | Set-Content "$pathToSave\VariableGroups.json"

        Write-Output "Variable groups downloaded successfully"

    }

    # clear output folder
    CleanOuputFolder

    # call api to download variable groups
    DownloadVariableGroups
    ```

                