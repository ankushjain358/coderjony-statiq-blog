Title: Attempt by security transparent method 'Umbraco.Core.UmbracoApplicationBase.StartApplication(System.Object, System.EventArgs)' to access security critical method 'System.AppDomain....' failed.
Published: 25/04/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
I got this issue after hosting my umbraco website on GoDaddy server. 

## Solution

`<configuration>
    <system.web>
       <trust level="Full" />
    </system.web>
</configuration>
`

This will fix your issue. Happy Coding :)

                