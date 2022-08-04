Title: ASP.NET Core - Notes for Beginners
Published: 02/12/2018
Author: Ankush Jain
IsActive: true
Tags:
  - .NET Core
---
ASP.NET Core is a free and open-source web framework, and the next generation of ASP.NET, developed by Microsoft and the community. It is a modular framework that runs on both the full .NET Framework, on Windows, and the cross-platform .NET Core.

## ASP.NET Core (Key Points)
* ASP.NET Core is a new framework to build and run applications on cross platforms. We can develop and host ASP.NET Core apps in all major OS i.e. Windows, Linux or Mac.
* ASP.NET Core is basically a Console Application. Its `main` method creates a server or web host and runs this application on that server.
* There are 3 types of projects in ASP.NET Core.  WEB API, ASP.NET Core Razor Pages, ASP.NET Core MVC Style
* It has `StartUp.cs` class that is being called by the Main method of console application.
* `StartUp.cs` class is a start-up class that is being invoked when the application runs the first time.
* It has mainly two methods `ConfigureServices` & `Configure` & one constructor.
* `ConfigureService` – You can use this method to configure services. i.e. ASP.NET Core’s default Dependency Injection.
* `Configure` – You can use this method to register Middleware components in your application request pipeline. i.e. Cookie Based Authentication,
Token Based Authentication, Logging, ExceptionHandling, RouteHandling etc.
* ASP.NET Core removes the concept of using `System.Web` and `HTTP Modules` to be a part of its request pipeline & it becomes possible due to the concept of Middleware.
* `Request Delegates` or `Middleware Components` should be registered in Configure Method.
* `Request Delegates` or `Middleware Component` will use extension methods. i.e. `Run`, `Use` & `Map`. These may be anonymous methods also. (Extension Method of `IApplicationBuilder` class)
* In ASP.NET Core, Middleware is the replacement of HTTP Modules in ASP.NET 4.x or below.
* `OWIN` is a Middleware for ASP.NET.  A replacement of HTTP Modules.
* KATANTA is a project that contains many OWIN Middleware Components that have been developed by the Microsoft team.
* The goal of OWIN is decoupling asp.net web applications from IIS. With the help of OWIN Middleware Components, the app will not rely on `System.Web` DLL and `HTTP Modules`.

## Few Important Links
* [Understanding ASP.NET Core Initialization](https://developer.telerik.com/featured/understanding-asp-net-core-initialization/)
* [Create a web app with ASP.NET Core MVC using Visual Studio](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/)
* [Application startup in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup)
* [ASP.NET Core Middleware](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?tabs=aspnetcore2x)
* [Token Based Authentication with OWIN Middleware](https://www.youtube.com/watch?v=rMA69bVv0U8)
* [Cookie Based Authentication with OWIN Middleware](https://brockallen.com/2013/10/24/a-primer-on-owin-cookie-authentication-middleware-for-the-asp-net-developer/)
* [Using Cookie Authentication without ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?tabs=aspnetcore2x)
* [Building Web APIs with ASP.NET Core 2.0](https://www.youtube.com/watch?v=aIkpVzqLuhA)
* [ASP.NET Core Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/)
* [JWT Token Based Authentication in ASP.NET Core](https://www.c-sharpcorner.com/article/jwt-json-web-token-authentication-in-asp-net-core/)


                