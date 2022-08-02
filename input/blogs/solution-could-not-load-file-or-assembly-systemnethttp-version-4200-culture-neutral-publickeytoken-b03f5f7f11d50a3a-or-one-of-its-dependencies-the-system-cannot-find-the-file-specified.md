Title: Solution- Could not load file or assembly 'System.Net.Http, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified.
Published: 27/07/2019
Author: Ankush Jain
IsActive: true
Tags:
  - .NET
---
In this post, I have tried to explain both the root cause & solution for the above error.

## Root Cause:

You normally get this issue when you take the reference of a certain third-party library in your application.

*For example, you took the reference of **RestSharp** (A third-party library) from NuGet. That RestSharp internally may have used the reference of `System.Net.Http` `4.2.0.0` version. And your project is also using the reference to `System.Net.Http` `4.0.0.0` (From GAC). Now when you run the application & try to call any method which is using **RestSharp**, at the same time Runtime (CLR) tries to locate the `System.Net.Http` assembly with version `4.2.0.0` & when it fails to locate the desired version, it throws `System.IO.FileNotFoundException` exception with below error message.*

> Could not load file or assembly 'System.Net.Http, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of > its dependencies. The system cannot find the file specified.

Here you can see [How the Runtime Locates Assemblies](https://docs.microsoft.com/en-us/dotnet/framework/deployment/how-the-runtime-locates-assemblies)?

## Solution:

Just add the below configuration in the `web.config` or `app.config` of your startup project.

```xml
<dependentAssembly>
	<assemblyIdentity name="System.Net.Http" publicKeyToken="b03f5f7f11d50a3a" culture="neutral" />
	<bindingRedirect oldVersion="0.0.0.0-4.2.0.0" newVersion="4.0.0.0" />
</dependentAssembly>
```

This configuration instructs the runtime to resolve `System.Net.Http` assembly with `4.0.0.0` version only, whenever it looks for this assembly for any version between `0.0.0.0` to `4.2.0.0`.

Here is the complete schema:

```xml
<configuration>  
   <runtime>  
	  <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
		<dependentAssembly>
			<assemblyIdentity name="System.Net.Http" publicKeyToken="b03f5f7f11d50a3a" culture="neutral" />
			<bindingRedirect oldVersion="0.0.0.0-4.2.0.0" newVersion="4.0.0.0" />
		</dependentAssembly>
	  </assemblyBinding>  
   </runtime>  
</configuration>
```  

Hopefully, this should fix the issue. If not, just let me know your comments in below comment box.

                