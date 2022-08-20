Title: Creating NuGet package using Visual Studio 2019 and publishing it to Nuget.org
Published: 06/03/2020
Author: Ankush Jain
IsActive: true
ImageFolder: creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg
Tags:
  - Visual Studio
---
In this post, we will understand how can we create a NuGet package using Visual Studio 2019. Also, we will understand, how to deploy this package to Nuget.org to make it available to the rest of the world.

![Creating NuGet package using Visual Studio 2019 and publishing it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/nuget.png)

**Step 1**: Open Visual Studio 2019 and create a **Class Library (.NET Standard)** project. 

> **Note:** We should choose **.NET Standard** for creating Class Library projects. The reason being, libraries created using .NET Standard can be used by all major platforms such as .NET Framework, .NET Core, Mono, Xamarin or Unity.

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/1-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step 2:** Provide a name for your project. My project name is `CoderJony.Utilities.Logger`. Try to keep this project name the same as your NuGet package name just for consistency. 

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/2-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step 3:** Now I create a public `Logger` class and define some public methods inside that class. 

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/3-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step 4:** Go to the properties of the project and select the package tab. 

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/4-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step 5:** This is the most useful step. In this step, I will tell you about the properties that you need to take care of the most.
1.  **Package id** - This should be the unique name for your NuGet package. This should not conflict with any other package available on the NuGet server.
2.  **Package version** - This is the version displayed on NuGet.org for your NuGet package.
3.  **Authors** - This could be your company name or your name if you are an individual.
4.  **Company** -  This should be your company name.
5.  **Product** - This is the product name. You can keep it the same as the package id.
6.  **Description** - This should be the description of your package.
7.  **Licensing** - This field is required. Either you have to provide some expression here OR you can also upload a local licensing file here. I am using MIT as a license expression. [Click here for more information about License Expressions](https://docs.microsoft.com/en-us/nuget/nuget-org/licenses.nuget.org#request).
8.  **Repository Url** - This is optional, but you can provide your public repository URL here such as GitHub.
9.  **Tags** - You should provide comma-separated values here. This helps in indexing your package on NuGet. So that NuGet can show your package as a search result when someone searches for it.
10.  **Assembly Version & Assembly File Version** - This should be the Assembly Version of the project. But it is advised to keep it the same as Package Version to avoid confusion at a later stage.

The more information you provide here, the more informative your package will look in the search results.

**Step 6** - Below, you can see, that I have provided all the information that is required for the NuGet package. 

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/6-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step 7** - Just mark these two checkboxes that are highlighted below.
*   **Generate NuGet package on build** - This will generate a NuGet package every time you build the project.
*   **Require license acceptance** - This will ensure that users have to accept the license while installing the package.

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/7-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step 8** - Now select `Release` mode and build the application. You can see a `.nupkg` file has been generated inside `~\bin\release\` folder. 

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/8-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step 9** - Here you can see the generated `.nupkg` file. 

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/9-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step 10** - Now login to [nuget.org](https://www.nuget.org/) with your Microsoft account and click on **Upload Package** link. 

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/10-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step11** - Drag and drop the generated `.nupkg` file here. As you can see I have dropped my `.nupkg` file here. 

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/11-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step 12** - Verify the provided information and press the submit button at the end of the page. After submitting the information, you will be redirected to your package's page. 

> **Note**: NuGet takes some time to validate your package after upload. After around 5 minutes, you will find that this warning is removed automatically.

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/12-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step 13** - After a few minutes, you can see - your package is available for use. 

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/13-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

**Step 14** - Now we can install this NuGet package in any of our .NET projects. 

![Creating NuGet package using Visual Studio 2019 and deploying it to Nuget.org](/img/blogs/creating-nuget-package-using-visual-studio-2019-and-publishing-it-to-nugetorg/14-httpcreating-nuget-package-using-visual-studio-2019-and-deployin-it-to-nugetorg.png)

Congratulations !!! We have created a NuGet package in less than 30 minutes. Please let me know your feedback and suggestions in below comment box.

Happy Coding :)

                
