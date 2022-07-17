Title: WCF Service Error - "This collection already contains an address with scheme http"
Published: 26/03/2019
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Just add below section in your `web.config` file.

    ```
    <system.serviceModel>
         &LT;serviceHostingEnvironment multipleSiteBindingsEnabled="true"/>
    </system.serviceModel>
    ```

                