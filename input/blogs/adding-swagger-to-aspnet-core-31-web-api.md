Title: Adding Swagger to ASP.NET Core 3.1 Web API
Published: 16/04/2020
Author: Ankush Jain
IsActive: true
ImageFolder: adding-swagger-to-aspnet-core-31-web-api
Tags:
  - .NET Core
  - Web API
  - Swagger
---
In this post, we will understand how can we add **Swagger UI** in an **ASP.NET Core 3.1 Web API** project.

> **Swagger UI:** Swagger UI allows API users to visualize and interact with the API resources without writing any custom logic. Swagger UI also helps in maintaining well up-to-date documentation of the APIs.

For this post, I have used **Visual Studio 2019** and **ASP.NET Core 3.1 Web API** project templates.

**Step 1:** Create an ASP.NET Core Web API project in Visual Studio 2019. 

![Adding Swagger to ASP.NET Core 3.1 Web API](/img/blogs/adding-swagger-to-aspnet-core-31-web-api/1-adding-swagger-to-aspnet-core-31-web-api.png)

**Step 2:** Select the API as the project template. 

![Adding Swagger to ASP.NET Core 3.1 Web API](/img/blogs/adding-swagger-to-aspnet-core-31-web-api/2-adding-swagger-to-aspnet-core-31-web-api.png)

**Step 3:** Install the NuGet Package -`Swashbuckle.AspNetCore`. We may also run the below command to install this NuGet package from the Package Manager Console.
```powershell
Install-Package Swashbuckle.AspNetCore
```

 ![Adding Swagger to ASP.NET Core 3.1 Web API](/img/blogs/adding-swagger-to-aspnet-core-31-web-api/3-adding-swagger-to-aspnet-core-31-web-api.png)

**Step 4:** Make sure that the above package has been installed in the Web API project. 

![Adding Swagger to ASP.NET Core 3.1 Web API](/img/blogs/adding-swagger-to-aspnet-core-31-web-api/4-adding-swagger-to-aspnet-core-31-web-api.png)

**Step 5:** Open `Startup.cs` file and import the following namespace to use the `OpenApiInfo` class.

```cs
using Microsoft.OpenApi.Models;
```
Now, go to `Startup.ConfigureServices` method and add the Swagger in `ServiceCollection` for the current application.

> **Note:** Add this **AddSwaggerGen()** method after **AddMvc()** or **AddMvcCore()**.

![Adding Swagger to ASP.NET Core 3.1 Web API](/img/blogs/adding-swagger-to-aspnet-core-31-web-api/5-adding-swagger-to-aspnet-core-31-web-api.png)

Copy the source code from here:

```cs
// Register the Swagger Generator service. This service is responsible for genrating Swagger Documents.
// Note: Add this service at the end after AddMvc() or AddMvcCore().
services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { 
		Title = "Zomato API", 
		Version = "v1",
		Description ="Description for the API goes here.",
		Contact = new OpenApiContact
		{
			Name = "Ankush Jain",
			Email = string.Empty,
			Url = new Uri("https://coderjony.com/"),
		},
	});
});
```

**Step 6:** Now go to the `Startup.Configure` method and add two middlewares in the ASP.NET Core request pipeline.

1.  **UseSwagger** - To serve the JSON end-points that hold the API metadata.
2.  **UseSwaggerUI** - To serve the UI for the API.

![Adding Swagger to ASP.NET Core 3.1 Web API](/img/blogs/adding-swagger-to-aspnet-core-31-web-api/6-adding-swagger-to-aspnet-core-31-web-api.png)


Copy the source code from here:

```cs
// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zomato API V1");

	// To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
	c.RoutePrefix = string.Empty;
});
```

**Step 7:** Press **F5** in **Visual Studio** and see the result. You will see a page like this. 

![Adding Swagger to ASP.NET Core 3.1 Web API](/img/blogs/adding-swagger-to-aspnet-core-31-web-api/7-adding-swagger-to-aspnet-core-31-web-api.png)

**Step 8:** To provide different responses for different status codes, we can also decorate our action methods with some attributes. These attributes help in generating more precise documentation for the APIs. 

![Adding Swagger to ASP.NET Core 3.1 Web API](/img/blogs/adding-swagger-to-aspnet-core-31-web-api/8-adding-swagger-to-aspnet-core-31-web-api.png) 

Copy the source code from here:

```cs
[HttpGet]
[ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
```

**Step 9:** Again press **F5** in **Visual Studio** and see the difference. This time, we have received multiple responses one for each specified status code. 

![Adding Swagger to ASP.NET Core 3.1 Web API](/img/blogs/adding-swagger-to-aspnet-core-31-web-api/9-adding-swagger-to-aspnet-core-31-web-api.png)

That's how we can implement the **Swagger UI** in our **ASP.NET Core Web API** application. 

**Reference** - [Get started with Swashbuckle and ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio)

                
