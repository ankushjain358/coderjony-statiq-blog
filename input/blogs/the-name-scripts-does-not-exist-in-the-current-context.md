Title: The name 'Scripts' does not exist in the current context
Published: 30/09/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
This post will show you, how you can fix **"The name 'Scripts' does not exist in the current context"** error.

## Issue:

![The name 'Scripts' does not exist in the current context - ASP.NET MVC Error](/img/blogs/the-name-scripts-does-not-exist-in-the-current-context/the-name-scripts-does-not-exist-in-the-current-context_issue.png)

## Solution:

Just go to your `Views` folder, open `web.config` & add this missing key. You're done...!!! ` <add namespace="System.Web.Optimization"/>` ## Things to remember here: 1. You must have the reference of `System.Web.Optimization.dll` in your project. 2. If not, just install this package from [Nuget](https://www.nuget.org/packages/microsoft.aspnet.web.optimization) with this command - `Install-Package Microsoft.AspNet.Web.Optimization`. 3. Ensure that your Views `Web.Config` file have the reference of `System.Web.Optimization`. ## Example Screenshot: 

![The name 'Scripts' does not exist in the current context - Solution](/img/blogs/the-name-scripts-does-not-exist-in-the-current-context/the-name-scripts-does-not-exist-in-the-current-context.png)

                