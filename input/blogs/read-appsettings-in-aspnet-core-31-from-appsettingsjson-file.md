Title: Read AppSettings in ASP.NET Core 3.1 from appsettings.json file
Published: 14/03/2020
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
In this article, we will understand, how can we read the `AppSettings` from `appsettings.json` file in ASP.NET Core 3.1.

![Read AppSettings in ASP.NET Core 3.1 from appsettings.json file](/img/blogs/read-appsettings-in-aspnet-core-31-from-appsettingsjson-file/aspnet-core.png)

**Step 1:** Create a new ASP.NET Core project in Visual Studio 2019. ![Read AppSettings in ASP.NET Core 3.1 from appsettings.json file](/img/blogs/read-appsettings-in-aspnet-core-31-from-appsettingsjson-file/1-read-appsettings-in-aspnet-core-31-from-appsettingsjson-file.png)

**Step 2:** On this screen, you can provide your project name, solution name and it's location. ![Read AppSettings in ASP.NET Core 3.1 from appsettings.json file](/img/blogs/read-appsettings-in-aspnet-core-31-from-appsettingsjson-file/2-read-appsettings-in-aspnet-core-31-from-appsettingsjson-file.png)

**Step 3:** Here you can select any type of ASP.NET Core Web Application that you want to create. I have selected the API project. This will create an ASP.NET Core Web API application. ![Read AppSettings in ASP.NET Core 3.1 from appsettings.json file](/img/blogs/read-appsettings-in-aspnet-core-31-from-appsettingsjson-file/3-read-appsettings-in-aspnet-core-31-from-appsettingsjson-file.png)

**Step 4:** Open `appsettings.json` file. Create an `AppSettings` key and provide some key values inside it as I have highlighted in the below picture. ![Read AppSettings in ASP.NET Core 3.1 from appsettings.json file](/img/blogs/read-appsettings-in-aspnet-core-31-from-appsettingsjson-file/4-read-appsettings-in-aspnet-core-31-from-appsettingsjson-file.png)

You can also copy the above settings from here.

```
      "AppSettings": {
        "ApplicationName": "Coder Jony",
        "ApplicationUrl": "http://coderjony.com"
      }
    ```

**Step 5:** Create a new `AppSettings.cs` class file. ![Read AppSettings in ASP.NET Core 3.1 from appsettings.json file](/img/blogs/read-appsettings-in-aspnet-core-31-from-appsettingsjson-file/5-read-appsettings-in-aspnet-core-31-from-appsettingsjson-file.png)

**Step 6:** Add the properties here in this class with the same key names that you have defined in the `AppSettings` section of `appsettings.json` file. ![Read AppSettings in ASP.NET Core 3.1 from appsettings.json file](/img/blogs/read-appsettings-in-aspnet-core-31-from-appsettingsjson-file/6-read-appsettings-in-aspnet-core-31-from-appsettingsjson-file.png)

You can copy the code from here as well for `AppSettings.cs` file.

```
    public class AppSettings
    {
          public string ApplicationName { get; set; }
          public string ApplicationUrl { get; set; }
    }
    ```

**Step 7:** Open `StartUp.cs` file, and add the highlighted lines in the `ConfigureServices` method like below. ![Read AppSettings in ASP.NET Core 3.1 from appsettings.json file](/img/blogs/read-appsettings-in-aspnet-core-31-from-appsettingsjson-file/7-read-appsettings-in-aspnet-core-31-from-appsettingsjson-file.png)

Copy the above-highlighted code from here.

```
    // 1. Read app settings from AppSettings key from appsettings.json file
    var appSettingsSection = Configuration.GetSection("AppSettings");

    // 2. Register it with a strongly typed object to access it using dependency injection 
    services.Configure<AppSettings>(appSettingsSection);
    ```

The above code does two things. **First**, it reads the `AppSettings` section from the file. **Second**, it creates a mapping of that with the `AppSettings` class and also registers it to be used as `IOptions<AppSettings>` using dependency injection.

**Step 8:** Finally, create a new controller and verify that we are able to access the `AppSettings` values in code. For this purpose, I have created a new `DemoController`, as you can see in the below picture. And I am successfully able to read app settings values in code from `appsettings.json` file.

![Read AppSettings in ASP.NET Core 3.1 from appsettings.json file](/img/blogs/read-appsettings-in-aspnet-core-31-from-appsettingsjson-file/8-read-appsettings-in-aspnet-core-31-from-appsettingsjson-file.png)

You can copy the above code from here as well.

```
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    namespace AppSettingsDemo.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class DemoController : ControllerBase
        {
            private readonly AppSettings _appSettings;

            public DemoController(IOptions<AppSettings> appSettings)
            {
                _appSettings = appSettings.Value;
            }

            [HttpGet]
            public bool Get()
            {
                string applicationName = _appSettings.ApplicationName;
                string applicationUrl = _appSettings.ApplicationUrl;

                return true;
            }
        }
    }
    ```

Thant's all :)

This is how we have successfully read the `AppSettings` section from the `appsettings.json` file in the ASP.NET Core application.

                