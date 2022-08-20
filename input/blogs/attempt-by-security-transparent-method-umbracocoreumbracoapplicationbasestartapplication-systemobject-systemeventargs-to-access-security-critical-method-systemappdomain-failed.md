Title: Attempt by security transparent method 'Umbraco.Core.UmbracoApplicationBase.StartApplication(System.Object, System.EventArgs)' to access security critical method 'System.AppDomain....' failed.
Published: 25/04/2018
Author: Ankush Jain
IsActive: true
ImageFolder: attempt-by-security-transparent-method-umbracocoreumbracoapplicationbasestartapplication-systemobject-systemeventargs-to-access-security-critical-method-systemappdomain-failed
Tags:
  - Umbraco
---
I got this issue after hosting my umbraco website on GoDaddy server. 

## Solution

```xml
<configuration>
    <system.web>
       <trust level="Full" />
    </system.web>
</configuration>
```

This will fix your issue. Happy Coding 😊

                
