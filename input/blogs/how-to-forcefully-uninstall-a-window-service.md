Title: How to forcefully uninstall a window service?
Published: 13/07/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Sometimes, You may find that window service's executable has been deleted but the service is still present in service viewer.

**To forcefully uninstall a window service, you just need to do two small things.**

*   **Step 1:** Close the service viewer window. Because the command which you will run in the second step will not work if the service
   viewer window is opened.

*   **Step 2:** once you have closed the service viewer window. Just run below command in command prompt.  

`sc delete cleanUpService `
 Here `cleanUpService` is a
   dummy name. You need to replace it with your service name.



Now, if you re-open service viewer then you can find that service has been removed.

                