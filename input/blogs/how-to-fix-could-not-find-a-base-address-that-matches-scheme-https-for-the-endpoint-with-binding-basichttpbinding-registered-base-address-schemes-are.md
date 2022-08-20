Title: How to fix - "Could not find a base address that matches scheme https for the endpoint with binding BasicHttpBinding. Registered base address schemes are..."
Published: 26/03/2019
Author: Ankush Jain
IsActive: true
ImageFolder: how-to-fix-could-not-find-a-base-address-that-matches-scheme-https-for-the-endpoint-with-binding-basichttpbinding-registered-base-address-schemes-are
Tags:
  - WCF
---
Just follow below two steps:

1.  Add missing HTTPS binding in IIS. **Go to IIS > Website > Bindings > Add Binding**.   
    See the below screenshot. 
    
    ![enter image description here](/img/blogs/how-to-fix-could-not-find-a-base-address/could-not-find-a-base-address-that-matches-scheme-https.png)

2.  Now, Add `serviceBehaviours` in `web.config` file like below:

    ```xml
    <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true"/>
    ```

                
