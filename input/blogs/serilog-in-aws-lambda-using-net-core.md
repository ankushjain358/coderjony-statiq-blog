Title: Serilog in AWS Lambda using .NET Core
Published: 14/03/2022
Author: Ankush Jain
IsActive: true
Tags:
  - .NET
  - AWS
  - .NET on AWS
  - Lambda
UniqueIdentifier: 94b0372a-b960-4376-89bb-215024679c60
---
In this post, we will understand how to use Serilog in AWS Lambda to store logs in AWS CloudWatch.

## Tools & Frameworks

We will be using the below tools and frameworks in this post going forward.
*   Visual Studio 2022
*   AWS Toolkit for Visual Studio
*   .NET Core 3.1
*   AWS account

## Step 1: Create a new Lambda project in Visual Studio
Open Visual Studio, and create a new project with **AWS Lambda Project** template as shown in the below picture. To get AWS project templates, you have to install [AWS Toolkit for Visual Studio](https://aws.amazon.com/visualstudio/) first. 

![Serilog in AWS Lambda using .NET Core](/img/blogs/serilog-in-aws-lambda-using-net-core/1-serilog-in-aws-lambda-using-net-core.png)

In the next step, provide some necessary information as per the below picture, and then click on create button. 

![Serilog in AWS Lambda using .NET Core](/img/blogs/serilog-in-aws-lambda-using-net-core/2-serilog-in-aws-lambda-using-net-core.png)

Now, select a **Blue Print** as per your application's need. Here, I am selecting **Empty Function** to keep things simple. 

![Serilog in AWS Lambda using .NET Core](/img/blogs/serilog-in-aws-lambda-using-net-core/3-serilog-in-aws-lambda-using-net-core.png)

## Step 2: Install NuGet packages for Serilog
Install the following NuGet packages to install Serilog in your Lambda Function.
```powershell
Install-Package Serilog
Install-Package Serilog.Settings.Configuration
Install-Package Serilog.Sinks.Console
```

*   **Serilog** - This package contains the core components of Serilog.
*   **Serilog.Settings.Configuration** - This package allows Serilog to read the settings from the configuration file such as `appsettings.json`.
*   **Serilog.Sinks.Console** -  This package is used to sink the logs in the console.

In this picture, you can see we have installed above mentioned NuGet packages. 

![Serilog in AWS Lambda using .NET Core](/img/blogs/serilog-in-aws-lambda-using-net-core/4-serilog-in-aws-lambda-using-net-core.png)

> **Important:** By default, everything that we write to the Console from within an AWS Lambda function, ends up in AWS CloudWatch, so if we are writing to the Console via `Serilog.Sinks.Console`, then all the logs by default will get stored in the AWS CloudWatch log group. We don't have to do anything extra for this.

## Step 3: Add Serilog configuration
Create an `appsettings.json` file and copy the below configuration there. You can modify this configuration as per your need, but for this demo, this configuration is sufficient.

Also, don't forget to set **Copy to Output Directory** property to **Copy always** for `appsettings.json` file.

```json
{
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console" ],
    "MinimumLevel": "Debug",
    "WriteTo": [
      { "Name": "Console" }
    ],
    "Properties": {
      "Application": "AWSLambda.SerilogDemo"
    }
  }
}
```

Your `appsettings.json` file should look like the below: 

![Serilog in AWS Lambda using .NET Core](/img/blogs/serilog-in-aws-lambda-using-net-core/5-serilog-in-aws-lambda-using-net-core.png)

## Step 4: Read Serilog configuration in Lambda Function
Install `Microsoft.Extensions.Configuration.Json` NuGet package to read configurations from `appsettings.json` file. 

![Serilog in AWS Lambda using .NET Core](/img/blogs/serilog-in-aws-lambda-using-net-core/6-serilog-in-aws-lambda-using-net-core.png)

After installing the above NuGet package, you can initialize the Serilog logger by reading the configurations from `appsettings.json` file inside the constructor. 

Once Serilog is initialized, you can use the below logging methods.
*   Log.Logger.Debug()
*   Log.Logger.Information()
*   Log.Logger.Warning()
*   Log.Logger.Error()

![Serilog in AWS Lambda using .NET Core](/img/blogs/serilog-in-aws-lambda-using-net-core/7-serilog-in-aws-lambda-using-net-core.png)

You can copy the above code from here.
```cs
using Amazon.Lambda.Core;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Formatting.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambda.SerilogDemo
{
    public class Function
    {
        private readonly IConfiguration _configuration;
        public Function()
        {
            // construct configuration object from appsettings.json file
            _configuration = new ConfigurationBuilder() 
                                .AddJsonFile("appsettings.json", true)
                                .Build();

            // initialize serilog's logger property with valid configuration
            Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(_configuration)
                            .WriteTo.Console(new JsonFormatter())
                            .CreateLogger();
        }

        public string FunctionHandler(string input, ILambdaContext context)
        {
            Log.Logger.Information("Executing lambda function");
            return input?.ToUpper();
        }
    }
}
```

## Step 5: Deploy the Lambda Function
Right-click on the Lambda project and select **Publish to AWS Lambda...** This will open up below the window. Verify all the information and click on Next. 

![Serilog in AWS Lambda using .NET Core](/img/blogs/serilog-in-aws-lambda-using-net-core/8-serilog-in-aws-lambda-using-net-core.png) 

In this window, make sure you select the `lambda_exec_BasicLambda` role. This basic lambda role has enough permissions required to store the logs into AWS CloudWatch. 

![Serilog in AWS Lambda using .NET Core](/img/blogs/serilog-in-aws-lambda-using-net-core/9-serilog-in-aws-lambda-using-net-core.png)

## Step 6: Test & Verify
Once Lambda Function is deployed successfully, we can test it by invoking it from the Visual Studio itself. You can see the below picture, log information is getting printed, which means Serilog is doing its job. 

![Serilog in AWS Lambda using .NET Core](/img/blogs/serilog-in-aws-lambda-using-net-core/10-serilog-in-aws-lambda-using-net-core.png) 

We can also verify it from the AWS CloudWatch console. 

![Serilog in AWS Lambda using .NET Core](/img/blogs/serilog-in-aws-lambda-using-net-core/11-serilog-in-aws-lambda-using-net-core.png)

That's all.

## Conclusion
In this post, we learned how easily we can start using Serilog in AWS Lambda in less than 10 minutes. Please let me know your thoughts and feedback in the comment section below.

Thank You ❤️

## References
*   [Serilog in ASP.NET Core 3.1](https://codewithmukesh.com/blog/serilog-in-aspnet-core-3-1/)
*   [Serilog - Getting Started](https://github.com/serilog/serilog/wiki/Getting-Started)    
