Title: Building a Serverless ASP.NET Core Web API with AWS Lambda using Function URLs
Published: 02/10/2022
Author: Ankush Jain
IsActive: true
ImageFolder: building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls
Tags:
  - .NET Core
  - AWS
  - .NET on AWS
  - CDK
  - Lambda
---
In this post, you will learn how to build a Serverless API using ASP.NET Core and AWS Lambda.

To make the API available on a public HTTP(S) endpoint, you will use Lambda **[Lambda function URLs](https://docs.aws.amazon.com/lambda/latest/dg/lambda-urls.html)** instead of **Amazon API Gateway**.

# Pre-requisites
1. Visual Studio 2022
2. AWS Toolkit for Visual Studio
3. AWS Account
4. .NET 6

## Step 1: Create ASP.NET Core Web API project
Open Visual Studio, create **New Project** and select **ASP.NET Core Web API** template to create a new Web API project.

![image](/img/blogs/building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls/1.png)

In the **Additional information** window, keep the following settings.

![image](/img/blogs/building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls/2.png)

## Step 2: Install `Amazon.Lambda.AspNetCoreServer.Hosting` NuGet package
.NET 6 introduces a new style of writing ASP.NET Core applications called Minimal APIs. Minimal API makes use of C# 9's new feature top-level statements. Minimal API allows you to define an entire ASP.NET Core application in a single file.

To deploy ASP.NET Core application using Minimal API to Lambda, install `Amazon.Lambda.AspNetCoreServer.Hosting` NuGet package to your existing application.

![image](/img/blogs/building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls/3.png)

Next, add a call to `AddAWSLambdaHosting`` method when services are defined in your application.

```cs
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AWS Lambda support.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();
```

### 💡 Important
When the ASP.NET Core project is run locally, `AddAWSLambdaHosting` does nothing, allowing the normal .NET Kestrel web server to handle the local experience. When running in Lambda, `AddAWSLambdaHosting` swaps out Kestrel with `Amazon.Lambda.AspNetCoreServer` allowing Lambda and API Gateway to act as the web server instead of Kestrel. Since Minimal APIs take advantage of top-level statements, `AddAWSLambdaHosting` also starts the Lambda runtime client.

## Step 3: Update .csproj file
Open `.csproj` file and add `<AWSProjectType>Lambda</AWSProjectType>` in **PropertyGroup** section.

![image](/img/blogs/building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls/4.png)

This will let **AWS Toolkit for Visual Studio** know that your project is an AWS project. Now, when you right-click on your project, you will start getting **Publish to AWS ...** options as shown in the below image.

![image](/img/blogs/building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls/5.png)

## Step 4: Deploy Web API on AWS Lambda
Follow the instructions below to deploy Web API on AWS Lambda.
1. Right-click on the project, and select **Publish to AWS Lambda...**. 
2. In **Upload Lambda Function** dialog, ensure the following values are correct.
   - Lambda Runtime should be .NET 6
   - Configuration should be Release
   - Handler must be the Assembly name of your application
   
   ![image](/img/blogs/building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls/6.png)
3. In the Advanced Function Details, you can configure the following things.
   - IAM Role for the Lambda Function, when in doubt, select **AWSLambdaBasicExecutionRole** from the dropdown.
   - Memory & Timeout values
   - Environment Variables
   - DLQ & VPC details (if needed)
   
   ![image](/img/blogs/building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls/7.png)
4. Now, click on **Upload** button.
    
## Step 5: Enable Function Url for the Lambda
Follow the instructions below to enable Function Url for the Lambda.
1. Go to **AWS Console** & navigate to **Lambda** service.
2. You can see the deployed Lambda Function in AWS Console.
   
   ![image](/img/blogs/building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls/8.png)
3. Select your Lambda function to go to its detail page.
4. Select **Configuration** tab and then select **Function URL** from the left menu.
5. Click on **Create function URL** button.
6. On **Configure Function URL** screen, select **NONE** as Auth type.
   
   ![image](/img/blogs/building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls/9.png)
7. Click on the **Save** button.
8. You can see, **Function URL** has been created, and you can use the below URL to access your Web API.
   
   ![image](/img/blogs/building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls/10.png)

## Step 6: Verify that API is working
Follow the instructions below to verify that API is working.
1. Copy the **Function URL**. It should look like **https://6fm7vxp77g7vrgl5apdyw2jce40vrcbi.lambda-url.ap-south-1.on.aws/**
2. Just append **WeatherForecast** in this URL, as this is the only controller we have in the default API.
3. Copy the new URL in the browser and see the result.
4. If everything is fine, you will get the JSON response from the API like below.
   
   ![image](/img/blogs/building-a-serverless-aspnet-core-web-api-with-aws-lambda-using-function-urls/11.png)
5. That's all.   

## Conclusion
In this post, you learned how easily and quickly, you can deploy an ASP.NET Core Web API on AWS Lambda. Running Web APIs on AWS Lambda helps you to make your system scalable as well as cost-effective. Please let me know your thoughts and feedback in the comment section below.

Thank You ❤️

## References
- [Introducing the .NET 6 runtime for AWS Lambda](https://aws.amazon.com/blogs/compute/introducing-the-net-6-runtime-for-aws-lambda/)