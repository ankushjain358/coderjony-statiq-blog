Title: Structured Logging with NLog in AWS Lambda using .NET Core
Published: 24/09/2022
Author: Ankush Jain
IsActive: true
ImageFolder: structured-logging-with-nlog-in-aws-lambda-using-net-core
Tags:
  - .NET Core
  - AWS
  - .NET on AWS
  - Lambda
---
In this post, you will learn how you can use Structured Logging with NLog in your AWS Lambda using .NET Core. 

You will also learn, how you can use **AWS CloudWatch Log Insights** to query the log data to see how structured logging is beneficial to you.

## Pre-requisites
1. Visual Studio
2. AWS Toolkit for Visual Studio
3. AWS Account
4. .NET 6

## Step 1: Create Lambda Project
Open Visual Studio, create **New Project**, and select **AWS Lambda Project (.NET Core - C#)**. 

![Structured Logging with NLog in AWS Lambda using .NET Core](/img/blogs/structured-logging-with-nlog-in-aws-lambda-using-net-core/1.png)

Next, from the available blueprints, select the **Empty Function**.

![Structured Logging with NLog in AWS Lambda using .NET Core](/img/blogs/structured-logging-with-nlog-in-aws-lambda-using-net-core/2.png)

## Step 2: Traditional Logging vs Structred Logging
In **Traditional Logging**, you simply combine both the **event-information** and **event-properties** together in a single text message.

But when using **Structured Logging**, both **event-information** and **event-properties** are stored in a particular format such as _JSON, XML or CSV_, so that these logs could be queried easily at a later point in time.

Let's examine the output for the below example:
```cs
logger.Info("Order {orderid} created for {user}", 42, "Kenny");
```

### Tranditional Logging
The output will be formatted as:
```html
Order 42 created for Kenny
```
Here you can see, both `event-properties` and `event-information` are bound together in a single text message. We are considering `orderId` & `user` as event-properties in this example.

### Structured Logging
The output will be formatted as:
```json
{
    "message": "Order 42 created for Kenny",
    "orderid": 42,
    "user": "Kenny"
}
```
Here you can see, the entire event has been logged as a JSON document, where both `event-properties` and `event-information` are separate from each other. This separation helps you in query event logs at a later point in time.

# Step 2: Install and Configure NLog in Lambda Project
1. Install `NLog.Extensions.Logging` NuGet package. 
2. Create a `nlog.config` file, and set **Copy to Output Directory** to **Copy always**.
3. Copy below content in `nlog.config` file.
    ```xml
    <?xml version="1.0" encoding="utf-8" ?>
    <nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

      <!-- the targets to write to -->
      <targets>
        <target xsi:type="Console" name="ConsoleTarget">
          <layout xsi:type="JsonLayout" includeAllProperties="true">
            <attribute name="time" layout="${longdate}" />
            <attribute name="level" layout="${level:upperCase=true}"/>
            <attribute name="message" layout="${message}" />
          </layout>
        </target>
      </targets>

      <!-- rules to map from logger name to target -->
      <rules>
        <!--Output hosting lifetime messages to console target for faster startup detection -->
        <logger name="Microsoft.Hosting.Lifetime" minlevel="Info" writeTo="ConsoleTarget" final="true" />

        <!--Skip non-critical Microsoft logs and so log only own logs (BlackHole) -->
        <logger name="Microsoft.*" maxlevel="Info" final="true" />
        <logger name="System.Net.Http.*" maxlevel="Info" final="true" />

        <logger name="*" minlevel="Trace" writeTo="ConsoleTarget" />
      </rules>
    </nlog>
    ```
    Above `nlog.config` file includes mainly 2 things - Target & Rules.
    - **Targets** - Targets configure where to log, or we can say what are the target destinations where NLog should write the log events.
    - **Rules** - Rules configure what to log, you can use them as filters for your log events.
    
    For Lambda, writing to the console is sufficient as Lambda will automatically move console logs to **AWS CloudWatch Log Group**.
4. In `nlog.config`, we used `JsonLayout` for structured logging, otherwise, we could have used a normal layout as shown below.
    ```xml
    <target xsi:type="Console" name="ConsoleTarget">
      <layout>${longdate}|${level}|${logger}|${message}|${all-event-properties}</layout>
    </target>
    ```

## Step 3: Configure Lambda to use NLog
1. Go to `csproj` file and add below NuGet packages.    
    ```xml
    <ItemGroup>
        <PackageReference Include="Amazon.Lambda.Core" Version="2.1.0" />
        <PackageReference Include="Amazon.Lambda.Serialization.SystemTextJson" Version="2.2.0" />
        <PackageReference Include="Microsoft.Extensions.Configuration" Version="6.0.1" />
        <PackageReference Include="Microsoft.Extensions.Configuration.FileExtensions" Version="6.0.0" />
        <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="6.0.0" />
        <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="6.0.0" />
        <PackageReference Include="Microsoft.Extensions.Logging" Version="6.0.0" />
        <PackageReference Include="NLog.Extensions.Logging" Version="5.0.4" />
    </ItemGroup>
    ```
    Build the project to restore all the NuGet packages.
2. Go to `Function.cs` file, and add the following namespaces.
    ```cs
    using Amazon.Lambda.Core;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using NLog.Extensions.Logging;
    using System;
    using System.IO;
    ```
3. Update the content of `Function.cs` file as per below.
     ```cs
    public class Function
    {
        private readonly IConfiguration Configuration;
        private readonly IServiceProvider ServiceProvider;

        public Function()
        {
            // Build IConfiguration
            Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true)
                    .Build();

            // Configure services for Dependency Injection
            ServiceProvider = ConfigureServices();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // 1. Add configuration
            services.AddSingleton<IConfiguration>(Configuration);

            // 2. Add logging providers
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();

                // add NLog provider
                loggingBuilder.AddNLog(Path.Join(Directory.GetCurrentDirectory(), "nlog.config"));
            });

            // 3. return service provider
            return services.BuildServiceProvider();
        }

        public string FunctionHandler(string input, ILambdaContext context)
        {
            ILogger logger = ServiceProvider.GetRequiredService<ILogger<Function>>();

            logger.LogInformation("Processing order with OrderId: {OrderId}", "SomeOrderId");

            logger.LogInformation("Order processing completed for order: {OrderId}", "SomeOrderId");

            return "Success";
        }

    }
    ```
    Here, you can see in `ConfigureServices` method, we have first removed all the existing logging providers and then added the NLog provider to `LoggingBuilder` object.
4. Now, build and run the function locally using Visual Studio.
5. See the output on local.
    
    ![Structured Logging with NLog in AWS Lambda using .NET Core](/img/blogs/structured-logging-with-nlog-in-aws-lambda-using-net-core/3.png)


## Viewing the output in AWS CloudWatch Logs & Logs Insights
1. See the output for **structured logging** in AWS CloudWatch Logs.
   
   ![Structured Logging with NLog in AWS Lambda using .NET Core](/img/blogs/structured-logging-with-nlog-in-aws-lambda-using-net-core/4.png)

3. Next, go to **AWS CloudWatch**, and select **Logs Insights**.
4. Select the **Log Groups** from the dropdown and write a query to filter logs.
5. See the below screenshot of the filtered logs in **AWS CloudWatch Logs Insights**.
   
   ![Structured Logging with NLog in AWS Lambda using .NET Core](/img/blogs/structured-logging-with-nlog-in-aws-lambda-using-net-core/5.png)
    
## Conclusion
In this post, we explained how you can use NLog to write structured logs in AWS Lambda using .NET Core. Please let me know your thoughts and feedback in the comment section below.

Thank You ❤️

## References  
- [How to use structured logging](https://github.com/NLog/NLog/wiki/How-to-use-structured-logging)
- [NLog - Advanced .NET Logging](https://nlog-project.org/)
