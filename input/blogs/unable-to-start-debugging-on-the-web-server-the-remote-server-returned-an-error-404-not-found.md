Title: Unable to start debugging on the web server. The remote server returned an error (404) not found.
Published: 20/09/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
I recently faced this issue while I was trying to launch my ASP.NET MVC application from **Visual Studio 2017** but I was unable to do that because Visual Studio was always showing me a popup with below error message.

> Unable to start debugging on the web server. The remote server returned an error (404) not found.

![enter image description here](/img/blogs/unable-to-start-debugging-on-the-web-server-the-remote-server-returned-an-error-404-not-found/unable-to-start-debugging-on-the-web-server-the-remote-server-returned-an-error-404-not-found.png)

## Issue Root Cause

After some struggling, I found the root cause of the issue & it was some configuration settings in `web.config` file that was preventing Visual Studio from launching the application. And below was that setting - a `requestFiltering` tag.

```
    <security>
          <requestFiltering>
            <requestLimits maxAllowedContentLength="2147483648" />
            <verbs allowUnlisted="false">
              <!--Allowed Verbs-->
              <add verb="GET" allowed="true" />
              <add verb="POST" allowed="true" />
            </verbs>
          </requestFiltering>
     </security>
    ```

## Solution

Just add below tag inside `verbs` node. This will fix the issue & will allow Visual Studio to launch your application.

`<add verb="DEBUG" allowed="true"/>`

                