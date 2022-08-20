Title: WCF Service Error - "This collection already contains an address with scheme http"
Published: 26/03/2019
Author: Ankush Jain
IsActive: true
ImageFolder: wcf-service-error-this-collection-already-contains-an-address-with-scheme-http
Tags:
  - WCF
---
Just add the below section in your `web.config` file.

```xml
<system.serviceModel>
     <serviceHostingEnvironment multipleSiteBindingsEnabled="true"/>
</system.serviceModel>
```

                
