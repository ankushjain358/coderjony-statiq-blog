Title: Structured Logging in .NET Core Worker Service with Serilog - Write logs to Amazon CloudWatch
Published: 01/03/2023
Author: Ankush Jain
IsActive: true
ImageFolder: structured-logging-in-net-core-worker-service
SeoTags: dotnet, aws, .net on aws, .net worker service, c-sharp, background-service
Tags:
  - .NET Core
  - AWS
  - .NET on AWS
---
In this post, I'll show how to use Serilog in a .NET Worker Service to perform Structured Logging and persist log data to AWS CloudWatch.

You will also learn how to use AWS CloudWatch Log Insights to query log data to determine how structured logging can benefit you.

## Pre-requisites
1. Visual Studio
2. .NET 6
3. AWS Account

## Step 1: Create a .NET Worker Service
Open **Visual Studio**, create **New Project**, and select **Worker Service** template.

![image](/img/blogs/structured-logging-in-net-core-worker-service/logging-to-amazon-cloudwatch-with-serilog-1.png)

On the next dialog, enter **Project Name** and select **Next**. Select the latest framework, I am selecting **.NET6**  for now.

## Step 2: Add Serilog to the .NET Worker Service
To add Serilog to your .NET Worker Service (Non-Web) application, install the following NuGet packages.
 ```ps
 Install-Package Serilog.Extensions.Hosting
 Install-Package Serilog.Settings.Configuration
 Install-Package Serilog.Sinks.Console
 Install-Package AWS.Logger.SeriLog
 ```

- `Serilog.Extensions.Hosting` - This package provides an extension method `UseSerilog()` to add Serilog provider to **Non-web .NET Core** applications. Since this package depends on `Serilog`, it automatically installs that as well.

- `Serilog.Settings.Configuration` - This package allows you to read Serilog configurations from [Microsoft.Extensions.Configuration](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0) sources, including .NET Core's `appsettings.json` file.

### Install Serilog sink packages
Serilog provides sinks for writing logs at various destinations. Here is a complete list of [supported sinks](https://github.com/serilog/serilog/wiki/Provided-Sinks). To follow this blog post, you can just install the following sinks.

- `Serilog.Sinks.Console` - This package writes logs to Console.
- `AWS.Logger.SeriLog` - This package writes logs to AWS CloudWatch. This is an official NuGet package managed by AWS. 

## Step 3: Configure Serilog in Worker Service
Open `Program.cs` file, and update the code as shown below.

```cs
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)  
    .Enrich.FromLogContext()) // <-- This line adds support for structured logging
    .Build();
```
The preceding code uses `UseSerilog()` extension method to add the Serilog logging provider to your application. Next, it reads configuration from `IConfiguration` sources, which is `appsettings.json` for this demo. Finally, it adds support for structured logging from the `Enrich.FromLogContext()` line. 

Now let's modify `appsettings.json` file to add Serilog configuration.

```json
{
  "Logging": { // <-- You can remove this Logging section, as this is no longer used
    "LogLevel": {
      "Default": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "AWS.Logger.SeriLog" ],
    "LogGroup": "WorkerService.LoggingDemo.LogGroup",
    "LogStreamNamePrefix": "dev",
    "Region": "ap-south-1",
    "MinimumLevel": "Debug",
    "WriteTo": [
      { "Name": "Console" },
      {
        "Name": "AWSSeriLog",
        "Args": {
          "textFormatter": "Serilog.Formatting.Json.JsonFormatter, Serilog"
        }
      }
    ],
    "Properties": {
      "Application": "WorkerService.LoggingDemo"
    }
  }
}
```

Finally, edit `worker.cs` file and update the code to include a logging statement as shown in the following code snippet.

```cs
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Example of structured logging (logging properties along with log event)
            _logger.LogInformation("Order {OrderId} by {Email} has been processed successfully.", 1, "user@domain.com");

            await Task.Delay(1000, stoppingToken);
        }
    }
}
```

## Step 4: Run the application to generate logs
Build and run the application by pressing **F5**, you should see the logs in Console as shown shown below.

![image](/img/blogs/structured-logging-in-net-core-worker-service/logging-to-amazon-cloudwatch-with-serilog-2.png)

## Step 5: Viewing the output in AWS CloudWatch Logs & Logs Insights
Logs generated in the previous step have also been written to AWS CloudWatch automatically through the configured CloudWatch sink. 

Follow the instructions below to view the logs in AWS CloudWatch.

1. Go to **AWS CloudWatch** and see the output for structured logging. As you can see, the logs are in JSON format rather than plain text.

   ![image](/img/blogs/structured-logging-in-net-core-worker-service/logging-to-amazon-cloudwatch-with-serilog-3.png)

2. Next, go to **AWS CloudWatch**, and select **Logs Insights**.
3. Select the **Log Groups** from the dropdown and write a query to filter logs.
4. See the below screenshot of the filtered logs in **AWS CloudWatch Logs Insights**.
   
   ![image](/img/blogs/structured-logging-in-net-core-worker-service/logging-to-amazon-cloudwatch-with-serilog-4.png)

## Conclusion
In this post, you learned how to use Serilog to perform structure logging in AWS CloudWatch from your .NET Worker Service. Please share your views and feedback in the section below.

Thank You ❤️
