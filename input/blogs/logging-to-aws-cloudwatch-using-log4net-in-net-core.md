Title: Logging to AWS CloudWatch using Log4Net in .NET Core
Published: 24/04/2022
Author: Ankush Jain
IsActive: true
Tags:
  - .NET
  - AWS
  - .NET on AWS
  - CloudWatch
---
In this post, we will understand how to use Log4Net in .NET Core application to store logs in AWS CloudWatch.

## Overview
By default, .NET Core provides its own logging framework. Additionally, it provides Logging APIs that enables other developers to implement their own Logging Provider. A Logging Provider is just an implementation of `Microsoft.Extensions.Logging.ILogger` interface. 

`Log4Net` officially does not provide any Logging Provider. But, there are community developed Logging Providers that we can use in our application. In this demo, we will be  using  [Microsoft.Extensions.Logging.Log4Net.AspNetCore](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Log4Net.AspNetCore/)  NuGet package.

## Step 1: Install NuGet package
Install below NuGet package:

```powershell
PM> Install-Package Microsoft.Extensions.Logging.Log4Net.AspNetCore
```

This package additionally includes the following things:

- **Logging Provider:** Implementation of `Microsoft.Extensions.Logging.ILogger` for Log4Net.
-  **Extension method:** To add the Logging Provider to .NET Core Logger Factory in startup class or similar.

By default, **Log4Net** comes along with default appenders such as `Debug`, `Console`, `File`, etc.

## Step 2: Update `Program.cs` file
Add `Log4Net` provider to `LoggerFactory` using its extension method `AddLog4Net()`.
```cs
builder.Host.ConfigureLogging((context, logging) =>
{
    // clear default providers
    logging.ClearProviders();

    // add Log4Net provider
    logging.AddLog4Net(); 
});
```

### For Non-Host Console Apps 
Applications not having Generic Host implementation may use below code to configure Log4Net.
```cs
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddLog4Net();
});

ILogger logger = loggerFactory.CreateLogger();
logger.LogInformation("Example log message");
```

## Step 3: Add `log4net.config` file
Add `log4net.config` file with below content.

```xml
<log4net>
	<root>
		<level value="ALL" />
		<appender-ref ref="console" />
		<appender-ref ref="file" />
	</root>
	<appender name="console" type="log4net.Appender.ConsoleAppender">
		<layout type="log4net.Layout.PatternLayout">
			<conversionPattern value="%date %level %logger - %message%newline" />
		</layout>
	</appender>
	<appender name="file" type="log4net.Appender.RollingFileAppender">
		<file value="myapp.log" />
		<appendToFile value="true" />
		<rollingStyle value="Size" />
		<maxSizeRollBackups value="5" />
		<maximumFileSize value="10MB" />
		<staticLogFileName value="true" />
		<layout type="log4net.Layout.PatternLayout">
			<conversionPattern value="%date [%thread] %level %logger - %message%newline" />
		</layout>
	</appender>
</log4net>
```

Above file is configured with 2 appenders - `Console` & `File`.

Also, don't forget to set **Copy to Output Directory** to **Copy always** for this file.

### Log4Net Appender
Log4net configures appenders to receive log messages. For log4net to know where to store your log messages, you add one or more appenders to your configuration. 

An appender is a C# class that can transform a log message, including its properties, and persist it somewhere. Examples of appenders are the console, a file, a database, an API call, elmah.io, etc.

[Click here to see the list of available appenders](https://logging.apache.org/log4net/release/framework-support.html#appenders)

## Step 4: Install AWS CloudWatch appender
Install following NuGet package for AWS CloudWatch appender.
```powershell
PM> Install-Package AWS.Logger.Log4net
```


## Step 5: Modify `log4net.config` file
Now, modify existing `log4net.config` file with AWS CloudWatch appender settings.
```xml
<?xml version="1.0" encoding="utf-8" ?>
<log4net>
	<root>
		<level value="ALL" />
		<appender-ref ref="console" />
		<appender-ref ref="file" />
		<appender-ref ref="AWS" />
	</root>
	<appender name="console" type="log4net.Appender.ConsoleAppender">
		<layout type="log4net.Layout.PatternLayout">
			<conversionPattern value="%date %level %logger - %message%newline" />
		</layout>
	</appender>
	<appender name="file" type="log4net.Appender.RollingFileAppender">
		<file value="myapp.log" />
		<appendToFile value="true" />
		<rollingStyle value="Size" />
		<maxSizeRollBackups value="5" />
		<maximumFileSize value="10MB" />
		<staticLogFileName value="true" />
		<layout type="log4net.Layout.PatternLayout">
			<conversionPattern value="%date [%thread] %level %logger - %message%newline" />
		</layout>
	</appender>
	<appender name="AWS" type="AWS.Logger.Log4net.AWSAppender,AWS.Logger.Log4net">
		<LogGroup>ASPNETCore.Logging.Log4Net</LogGroup>
		<Region>ap-south-1</Region>
		<layout type="log4net.Layout.PatternLayout">
			<conversionPattern value="%-4timestamp [%thread] %-5level %logger %ndc - %message%newline" />
		</layout>
	</appender>
</log4net>
```

## Step 6: Configuring AWS credentials
**AmazonCloudWatchLogsClient** from the AWS SDK requires AWS credentials. To correctly associate credentials with the library, there are following options.

- **Instance profile:** Use IAM Profile set on your EC2 instance machine or ECS Task.
- **Credential profile:** Create a credentials profile with your AWS credentials.
- **Environment Variables:** Use Environment Variables.

For now, just add `AWS_PROFILE` environment variable in application's `launchSettings.json` file.
```json
"environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development",
    "AWS_PROFILE": "default"
    }
```    

Also make sure, AWS credentials profile have enough IAM permissions to access and write logs in CloudWatch.

That's all.

## Conclusion
In this post, we learned how easily we can use Log4Net to log into AWS CloudWatch in less than 10 minutes. Please let me know your thoughts and feedback in the comment section below.

Thank You ❤️

## References
1. [AWS Logging .NET: Apache log4net](https://github.com/aws/aws-logging-dotnet#apache-log4net)
2. [GitHub: Microsoft.Extensions.Logging.Log4Net.AspNetCore](https://github.com/huorswords/Microsoft.Extensions.Logging.Log4Net.AspNetCore)
