Title: Implementing Configuration, Logging & Dependency Injection in AWS Lambda using .NET Core
Published: 18/05/2022
Author: Ankush Jain
IsActive: true
ImageFolder: implementing-configuration-logging-dependency-injection-in-aws-lambda-using-net-core
Tags:
  - .NET Core
  - AWS
  - .NET on AWS
  - Lambda
UniqueIdentifier: aa20117e-f30a-4223-8093-7b654135fe4c
---
In this post, we will understand how can we implement the following things when using AWS Lambda with .NET Core.
*   Configuration
*   Logging
*   Dependency Injection

## Overview
When we create an AWS Lambda project in Visual Studio, we just get the basic `FunctionHandler` method inside `Function` class. 

.NET Core features such as *Configuration*, *Logging* & *Dependency Injection* are not enabled by default. We need to write some additional code to enable these features. 

Although, Logging is enabled by default, that uses the lambda logger, not the .NET Core's default logger.

## Implementation - Configuration, Logging & Dependency Injection
We will be implementing the following things in this post further.
*   **Configuration** - Configuration support with `appsettings.json` file & `Environment Variables`.
*   **Logging** - Logging support with default `Console` logging.
*   **Dependency Injection** - DI support by adding services in `ServiceCollection`.

## Step 1: Install NuGet packages
We would need the below packages to implement *Configuration*, *Logging* & *Dependency Injection* in our Lambda project. Just update `csproj` file to have `ItemGroup` section like below, or install these packages manually. 

```xml
<ItemGroup>
    <!-- Default Lambda packages specific to Lambda  -->
    <PackageReference Include="Amazon.Lambda.Core" Version="2.1.0" />
    <PackageReference Include="Amazon.Lambda.Serialization.SystemTextJson" Version="2.3.0" />

    <!-- Packages required for Dependency Injection -->
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="6.0.0" />
    <PackageReference Include="AWSSDK.Extensions.NETCore.Setup" Version="3.7.2" />
    <PackageReference Include="AWSSDK.S3" Version="3.7.9.2" />

    <!-- Packages required for Configuration -->
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="6.0.1" />
    <PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="6.0.1" />
    <PackageReference Include="Microsoft.Extensions.Configuration.FileExtensions" Version="6.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="6.0.0" />
    <!---->

    <!-- Packages required for Logging -->
    <PackageReference Include="Microsoft.Extensions.Logging" Version="6.0.0" />
    <PackageReference Include="Microsoft.Extensions.Logging.Console" Version="6.0.0" />
</ItemGroup>
```

## Step 2: Create a `Startup` class file
Create a `Startup.cs` class file with the below content. Code is self-explanatory.

```cs
public class Startup
{
    private readonly IConfigurationRoot Configuration;

    public Startup()
    {
        Configuration = new ConfigurationBuilder() // ConfigurationBuilder() method requires Microsoft.Extensions.Configuration NuGet package
            .SetBasePath(Directory.GetCurrentDirectory())  // SetBasePath() method requires Microsoft.Extensions.Configuration.FileExtensions NuGet package
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // AddJsonFile() method requires Microsoft.Extensions.Configuration.Json NuGet package
            .AddEnvironmentVariables() // AddEnvironmentVariables() method requires Microsoft.Extensions.Configuration.EnvironmentVariables NuGet package
            .Build();
    }

    public IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection(); // ServiceCollection require Microsoft.Extensions.DependencyInjection NuGet package

        ConfigureLoggingAndConfigurations(services);

        ConfigureApplicationServices(services);

        IServiceProvider provider = services.BuildServiceProvider();

        return provider;
    }


    private void ConfigureLoggingAndConfigurations(ServiceCollection services)
    {

        // Add configuration service
        services.AddSingleton<IConfiguration>(Configuration);

        // Add logging service
        services.AddLogging(loggingBuilder =>  // AddLogging() requires Microsoft.Extensions.Logging NuGet package
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddConsole(); // AddConsole() requires Microsoft.Extensions.Logging.Console NuGet package
        });
    }

    private void ConfigureApplicationServices(ServiceCollection services)
    {
        #region AWS SDK setup
        // Get the AWS profile information from configuration providers
        AWSOptions awsOptions = Configuration.GetAWSOptions();

        // Configure AWS service clients to use these credentials
        services.AddDefaultAWSOptions(awsOptions);

        // These AWS service clients will be singleton by default
        services.AddAWSService<IAmazonS3>();
        #endregion

        services.AddSingleton<ILambdaEntryPoint, LambdaEntryPoint>();
    }
}
```

You may also need to add the below namespaces.
```cs
using Amazon.Extensions.NETCore.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
```

## Step 3: Create `LambdaEntryPoint` class
Create `LambdaEntryPoint` class with `Handler` method. Inject all the dependencies inside the constructor of this class. We will invoke `Handler` method of this class from the original `FunctionHandler`.

### 3.1. `ILambdaEntryPoint` interface
```cs
public interface ILambdaEntryPoint
{
    Task<string> Handler(string input);
}
```

### 3.2. `LambdaEntryPoint` class
```cs
public class LambdaEntryPoint : ILambdaEntryPoint
{
    private readonly ILogger<LambdaEntryPoint> _logger;

    public LambdaEntryPoint(ILogger<LambdaEntryPoint> logger)
    {
        _logger = logger;
    }

    public async Task<string> Handler(string input)
    {
        _logger.LogInformation("Handler invoked");

        return $"Hello {input}";
    }
}
```

## 4. Modify `Function.cs` class
Now replace `Function` class content with the below content. 

Here, we are mainly doing 2 things:

1.  Inside the constructor, we are calling `ConfigureServices()` method of `Startup` class. This method will register all the services in `ServiceCollection` and return an instance of `IServiceProvider`. 
2.  Inside `FunctionHandler`, we are calling `_lambdaEntryPoint.Handler(input)` method to do the actual processing.

Also, it is important to understand, `Function` class is Singleton in AWS Lambda. Multiple invocations of AWS Lambda will not execute Constructor logic multiple times, which will be executed only once in the beginning, and the class will remain singleton until the Lambda compute is alive.

```cs
public class Function
{
    private readonly ILambdaEntryPoint _lambdaEntryPoint;

    public Function()
    {
        var startup = new Startup();
        IServiceProvider provider = startup.ConfigureServices();

        _lambdaEntryPoint = provider.GetRequiredService<ILambdaEntryPoint>();
    }

    public async Task<string> FunctionHandler(string input, ILambdaContext context)
    {
        return await _lambdaEntryPoint.Handler(input);
    }

}
```

That's all.

## Conclusion

In this post, we learned how easily we can set up _configuration_, *logging* and *dependency injection* in AWS Lambda when using with .NET Core. Please let me know your thoughts and feedback in the comment section below.

Thank You ❤️

                
