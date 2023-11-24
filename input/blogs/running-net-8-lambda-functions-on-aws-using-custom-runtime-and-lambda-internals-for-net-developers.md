Title: Running .NET 8 Lambda Functions on AWS using Custom Runtime & Lambda Internals for .NET Developers
Published: 21/11/2023
Author: Ankush Jain
IsActive: true
ImageFolder: running-net-8-lambda-functions-on-aws-using-custom-runtime
Tags:
  - .NET
  - AWS
  - .NET on AWS
  - Lambda
---
In this post, you will learn how you can create, debug, and deploy a .NET 8 Lambda function on AWS using Visual Studio.

Since .NET 8 has just released a few days back, a managed runtime for this is not yet available (at the time of writing this blog). Therefore, we will use Custom Runtime to run a .NET 8 Lambda function.

Since we will use [Custom Runtime](https://docs.aws.amazon.com/lambda/latest/dg/runtimes-custom.html) in this post to deploy the Lambda function, it is important to understand some of the **Lambda Internals** such as what is **Lambda Runtime**, the difference between **Managed** and **Custom Runtimes**, and a few other lambda-related terminologies.

## Lambda Internals for .NET Developers
> 💡 This section is OPTIONAL; you can skip it and continue directly to Step 1 below.

Knowing the internals helps you to become a better developer. As a result, I strongly advise you to read through this section and have a thorough understanding of .NET Lambda functions. By the end of this section you will have learnt the following:

1. Types of .NET Lambda functions
    1. Class library handler
    2. Executing assembly handler
2. How these 2 different types of .NET Lambda functions are executed by Lambda Runtime?
3. What is Lambda Runtime?
4. Types of Lambda Runtime
    1. Managed runtime
    2. Custom runtime
5. What is Lambda Runtime API?

### 1. Lambda terminologies

First of all, let’s quickly go through different lambda-related terminologies that we will use in this post to understand Lambda concepts.


> 💡 It is important to know that **Lambda Runtime  ≠ Language Runtime (.NET, Java, etc.)**

- **Lambda Service -** AWS managed service used to manage and orchestrate Lambda functions at scale.
- **Language Runtime -** Language specific runtimes *i.e. Node.js, .NET, Java, etc.* 
   This includes all the framework assemblies, and just-in-time (JIT) compiler, that converts MSIL code into machine code. In this post, we refer to this type of runtime as Language Runtime.
- **Lambda Runtime -**  A program that executes lambda function handler.
    - Managed Runtime *(lambda runtime provided by AWS in execution environment)*
    - Custom Runtime *(lambda runtime provided by Developer in deployment package)*
- **Lambda Runtime API -** An API hosted on the same execution environment compute, acts as a bridge between Lambda Runtime and Lambda Service.

### 2. What is Lambda Runtime?
> 💡 A **Lambda Runtime** is a program that runs in an Execution Environment, reads invocation events from the Lambda service, and executes the Function handler. Once an execution is finished, it requests another invocation event, and this process keeps going on until the execution environment is shut down. For .NET, this runtime **.NET Lambda Runtime Interface Client (RIC)** has been packaged into **[Amazon.Lambda.RuntimeSupport](https://aws.amazon.com/blogs/developer/announcing-amazon-lambda-runtimesupport/)** NuGet package. This Runtime needs to be started as soon as the execution environment is created so that it can start requesting invocation events. How this Runtime is started has been covered later in this post.

![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/0.png)

The story starts with the `bootstrap` file. When an execution environment is created the `bootstrap` file is executed. **This bootstrap file can be the runtime, or it can invoke another file that creates the runtime.** In the .NET lambda function, this is the second case where the `bootstrap` executable invokes the **.NET Lambda Runtime Interface Client (RIC),** which is the actual .NET Lambda Runtime that is packaged into **[Amazon.Lambda.RuntimeSupport](https://aws.amazon.com/blogs/developer/announcing-amazon-lambda-runtimesupport/) NuGet package.**

Once the **Lambda Runtime Interface Client (RIC)** is initialized or started, it keeps on processing the invocation events until the execution environment is shut down. To get an invocation event, **Lambda Runtime or RIC** program calls the [next invocation](https://docs.aws.amazon.com/lambda/latest/dg/runtimes-api.html#runtimes-api-next) API of **Lambda Runtime API** *(an API hosted on the same execution environment compute, acts as a bridge between Lambda Runtime and Lambda Service)* which further calls **Lambda Service** to get an invocation event. If Lambda Service has an event waiting for the execution, it is returned to the Lambda Runtime. Lambda Runtime then executes the Function Handler for the event and returns the response back to the Lambda Service via Lambda Runtime API.

There are 2 types of Lambda Runtime:

1. Managed runtime 
2. Custom runtime

### 3. Managed Runtime vs Custom Runtime

#### Managed Runtime
A **Managed Runtime** has everything that it needs to run a Lambda function, you just need to provide it with the deployment package (zip archive). By everything, I mean, it has the following things:

- Language Runtime - Language specific runtime *i.e. Node.js, .NET, etc.*
- Lambda Runtime *(a program that reads invocation events, executes the lambda handler, and sends the response back to the Lambda service)*

Now once the deployment package is provided, it has the code that needs to be executed, as well as all other dependencies. So this works like a charm!

#### Custom Runtime
On the other hand, a Custom Runtime doesn't have either a **Language Runtime** or **Lambda Runtime**. Both of these has to be provided by the deployment package. Custom Runtime is just like an empty Linux machine with Lambda Runtime API. 

Also, it is important to know that the entry point of a Custom Runtime is a bootstrap file. That means, when an Execution Environment is created for a Custom Runtime, the **bootstrap** file is executed first.

In order to provide that **bootstrap** file within the deployment package, you must rename your projects's assembly to **bootstrap**.

To run a .NET Lambda function with Custom Runtime, you need to understand the following things:

> 💡 You don't need to make the following changes manually because the AWS Lambda Template in Visual Studio takes care of them.

1. **Keep the assembly name `bootstrap`** - *The executable name of the .NET Lambda function that you create must be **bootstrap**, so that when the execution environment is created, it will invoke your .NET Lambda executable because it has been named **bootstrap**.* 

2. **Use `self-contained` deployment to provide missing Langauge Runtime** - *The Lambda code in the deployment package should either be [OS native](https://docs.aws.amazon.com/lambda/latest/dg/dotnet-native-aot.html) or [self-contained](https://learn.microsoft.com/en-us/dotnet/core/deploying/single-file/overview?tabs=cli), since there is no language runtime installed in the execution environment when you use custom runtime.* 

3. **Providing missing Lambda Runtime** - *In order to provide missing Lambda Runtime, you use **[Amazon.Lambda.RuntimeSupport](https://aws.amazon.com/blogs/developer/announcing-amazon-lambda-runtimesupport/)** NuGet package in your project as it contains the required **.NET Lambda Runtime Interface Client (RIC)**.* 

   *Next, you write below code inside the **main()** method of your Lambda function, which starts the Lambda Runtime, and begins requesting invocation events.*

    ```csharp
    LambdaBootstrapBuilder.Create(handler, new DefaultLambdaJsonSerializer())
        .Build()
        .RunAsync();
    ```
    
    *In the above code, the **handler** has been passed as a **delegate**.*


### 4. Lambda runtime API

AWS Lambda provides an HTTP API for [custom runtimes](https://docs.aws.amazon.com/lambda/latest/dg/runtimes-custom.html) to receive invocation events from the Lambda service and send response data back to the Lambda service. This API is hosted within the Lambda [execution environment](https://docs.aws.amazon.com/lambda/latest/dg/lambda-runtimes.html).

```bash
curl "http://${AWS_LAMBDA_RUNTIME_API}/2018-06-01/runtime/invocation/next"
```

Here are the **4 API Methods** that have been exposed by **Lambda runtime API.**

- **Next invocation**
    - Method - GET
    - Path - */runtime/invocation/next*
    - Description - Used to request an invocation event from Lambda service.
- **Invocation response**
    - Method - POST
    - Path - */runtime/invocation/`AwsRequestId`/response*
    - Description - Used to send an invocation response to Lambda service.
- **Initialization error**
    - Method - POST
    - Path - */runtime/init/error*
    - Description - Used to report error to Lambda service if runtime encounters an error during initialization.
- **Invocation error**
    - Method - POST
    - Path - */runtime/invocation/`AwsRequestId`/error*
    - Description - Used to report an error to Lambda service if the function returns an error.

### 5. How the .NET Lambda function works under the hood (Managed Runtime)

> Lambda Runtime for .NET has been open-sourced at [Lambda runtime client](https://github.com/aws/aws-lambda-dotnet/tree/master/Libraries/src/Amazon.Lambda.RuntimeSupport) from the [aws/aws-lambda-dotnet](https://github.com/aws/aws-lambda-dotnet) repository, and has been packaged into **[Amazon.Lambda.RuntimeSupport](https://aws.amazon.com/blogs/developer/announcing-amazon-lambda-runtimesupport/) NuGet.**
> 

Now let's understand what happens when a .NET lambda function is invoked when you are using the managed runtime.

- When the Lambda service receives a request to run a function via the Lambda API, the service first prepares an execution environment.
- During this step, the service downloads the code for the function, which is stored in an internal S3 bucket. It then creates an environment with the memory, runtime, and configuration specified.
- Next, the *[bootstrap.sh](https://github.com/aws/aws-lambda-dotnet/blob/master/Libraries/src/Amazon.Lambda.RuntimeSupport/bootstrap.sh)* file is invoked in the execution environment as part of the **Init** phase.
- This bootstrap file determines the type of .NET Lambda function:
    - [Class library handler](https://docs.aws.amazon.com/lambda/latest/dg/csharp-handler.html#csharp-handler-class-library)
    - [Executing assembly handler](https://docs.aws.amazon.com/lambda/latest/dg/csharp-handler.html#csharp-handler-executable)
- **Class library handler** is straight forward, where a Lambda project is a class library and the Lambda function handler is set to the assembly, type, and method name that the Lambda runtime client invokes. Using reflection, the .NET Lambda runtime client uses the function handler string to identify the method to call in the .NET assembly.
- **Executing assembly handler** is not as straightforward as a Class library handler. This lambda function is basically a console application that has a **main()** method as an entry point. With **top-level statements**, the main() method has been generated by the compiler. Such application is compiled into an executable (.exe).
    
    There are two things that you must know when working with executing assembly handler: 
    
    - First, in the case of executing assembly, you tell the Lambda *(or the bootstrap file)* to run the assembly, which runs the **top-level statements** or **the main() method**. To indicate that you want Lambda to run the assembly, **set the Lambda function handler to the assembly name only**.
    - Second thing, in the case of **class library handler**, the **Lambda Runtime client** is started by the Lambda *(or the bootstrap file)*, while when using **executing assembly**, the lambda executes the assembly, but does not start the runtime. So it is your responsibility to start the Lambda Runtime client, which is done by adding the following code in the main() method.
        
        ```csharp
        private static async Task Main(string[] args)
        {
            Func<string, ILambdaContext, string> handler = FunctionHandler;
            
        		// Build the Lambda runtime client and passing in the handler as delegate
            await LambdaBootstrapBuilder.Create(handler, new DefaultLambdaJsonSerializer())
                .Build()
                .RunAsync();
        }
        ```
        
- Here is a snapshot of the bootstrap file, that shows how it runs different executables for different types of Lambda functions. This files is part of .NET Lambda Managed Runtime, and can be accessed from here - [bootstrap.sh](https://github.com/aws/aws-lambda-dotnet/blob/master/Libraries/src/Amazon.Lambda.RuntimeSupport/bootstrap.sh).
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/1.png)
    
- Once the Lambda Runtime client is started, it starts getting invocation events and executing the specified handler.

## Pre-requisites

1. Visual Studio (≥ v17.8.0 for .NET 8 support)
2. [AWS Toolkit for Visual Studio](https://marketplace.visualstudio.com/items?itemName=AmazonWebServices.AWSToolkitforVisualStudio2022) (≥ 1.44.0.0)
3. [AWS .NET Mock Lambda Test Tool](https://github.com/aws/aws-lambda-dotnet/tree/master/Tools/LambdaTestTool)  (Use the latest one that supports .NET 8)

## Step 1. Create a new Lambda function

1. Create a new Lambda function from Visual Studio.
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/2.png)
    
2. Select **Custom Runtime Function** from the available blueprints.
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/3.png)
    
3. Press the **Finish** button.

## Step 2. Understand `Function` class

1. The function class looks like the code sample shown below, where you have a **main()** method.
2. This **main()** method is executed when the **Lambda executing assembly** is invoked.
3. **LambdaBootstrapBuilder.Create()** method creates and starts the Lambda Runtime with a handler. 
4. The **LambdaBootstrapBuilder** class is part of **Amazon.Lambda.RuntimeSupport** NuGet package.
5. Once the lambda runtime is initialized, it starts requesting invocation events and executes a lambda handler for each invocation.
    
    ```csharp
    public class Function
    {
        private static async Task Main(string[] args)
        {
            Func<string, ILambdaContext, string> handler = FunctionHandler;
            
    				await LambdaBootstrapBuilder.Create(handler, new DefaultLambdaJsonSerializer())
                .Build()
                .RunAsync();
        }
    
        public static string FunctionHandler(string input, ILambdaContext context)
        {
            return input.ToUpper();
        }
    }
    ```
    

## Step 3. Understanding the .CSPROJ properties

Here are a few properties in your .csproj file that you need to pay attention.

- `AssemblyName`
- `PublishReadyToRun`
- `Microsoft.ICU.ICU4C.Runtime` NuGet package

### AssemblyName

Note that the assembly name has been put `bootstrap` intentionally as you are using custom runtime, not a managed runtime.

```xml
<AssemblyName>bootstrap</AssemblyName>
```

When using Lambda with a custom runtime, the Lambda service looks for an executable file named bootstrap within the packaged ZIP file. To enable this, the `OutputType` is set to exe and the `AssemblyName` to `bootstrap`

### PublishReadyToRun (****ReadyToRun Compilation)****
> 💡 R2R binaries include both codes, MSIL + Native of the same. This reduces the work that needs to be done by JIT.

R2R binaries improve startup performance **by reducing the amount of work the just-in-time (JIT) compiler needs to do** as your application loads. The binaries contain similar native code compared to what the JIT would produce. However, **R2R binaries are larger** because **they contain both intermediate language (IL) code**, which is still needed for some scenarios, **and the native version of the same code**.

To learn more, refer [ReadyToRun Compilation](https://learn.microsoft.com/en-us/dotnet/core/deploying/ready-to-run) on Microsoft documentation.

### Microsoft.ICU.ICU4C.Runtime NuGet package

Amazon Linux 2023 does not have `libicu` a system library for internationalization preinstalled. When publishing to the **provided.al2023** runtime **Microsoft.ICU.ICU4C.Runtime** package need to be included to support internationalization.

## Step 4. Create a Lambda function in the AWS Console
> 💡 Skip this step, if you want to create a Lambda Function with Visual Studio.

1. Navigate to [Lambda Console](https://console.aws.amazon.com/lambda/home).
2. Click the **Create Function** button.
3. To create a new Lambda function, provide the following details.
    1. Enter function name.
    2. For **Runtime** select **Provide your own bootstrap on Amazon Linux 2023**
    3. For Architecture, select **x86_64**
    4. For the **Execution role,** select **Create a new role with basic Lambda permissions**
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/4.png)
    
4. Lastly, click on the **Create function** button.

## Step 5. Create and deploy the Lambda function using Visual Studio

1. Right-click on the Lambda project, and select **Publish to AWS Lambda...** option.
2. You should see a wizard like the below screenshot. Make sure you select the following things.
    1. **Package Type** - Zip
    2. **Lambda Runtime** - Custom .NET Core Runtime (AL2023)
    3. **Architecture** - x86
    4. **Function Name -** Either create a new function or select the one that you created in the previous step.
    5. **Handler** - bootstrap
    6. **Configuration -** Release
    7. **Framework** - .net8.0
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/5.png)
    
3. In the next screen, select the IAM Role **AWSLambdaBasicExecutionRole** as shown in the below screenshot, and press the **Upload** button.
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/6.png)
    
4. This publishes the .NET Lambda app in self-contained mode so that the app does not require runtime to be installed on the server. You can have a look at the **aws-lambda-tools-defaults.json** file to see from where this `-self-contained true` is coming.
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/7.png)
    

## Step 6. Test Lambda Function in AWS Console

1. Navigate to [Lambda Console](https://console.aws.amazon.com/lambda/home).
2. Select the Lambda function that you recently created.
3. On the detail page, select the **Test** tab.
4. Enter text in the **Event JSON** textbox, and press the **Test** button.
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/8.png)
    
5. You should see a successful response like below.
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/9.png)
    

## Step 7. Debug and test Lambda Functions in Visual Studio

Debugging executable assembly functions is a little different. This requires you to run **Amazon.Lambda.TestTool** first.

1. Run the below command to install the Mock Lambda Test Tool.
    
    ```bash
    dotnet tool update -g Amazon.Lambda.TestTool-8.0
    ```
    
2. After that, navigate to `C:\Users\<username>\.dotnet\tools` location, you will see all the installed tools.
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/10.png)
    
3. Run this tool via the command line, which starts the Test Tool in the browser at [http://localhost:5050/](http://localhost:5050/) URL.
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/11.png)
    
4. Now, switch back to Visual Studio, and set the **AWS_LAMBDA_RUNTIME_API** environment variable to **localhost:5050.**
    1. Right-click, and select **Properties.**
    2. Navigate to **Debug** > **General** tab, and select **Open debug launch profiles UI**
    3. Set the required environment variable, and close the window.
        
        ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/12.png)
        
    4. This creates a **launchSettings.json** file like this.
        
        ```json
        {
          "profiles": {
            "AWSLambda.NET8.Demo": {
              "commandName": "Project",
              "environmentVariables": {
                "AWS_LAMBDA_RUNTIME_API": "localhost:5050"
              }
            }
          }
        }
        ```
        
5. Now, run the application by pressing **F5.** This starts the app and executes the **main()** method. 
6. Code in the **main()** method to start the Lambda Runtime looks for the **AWS_LAMBDA_RUNTIME_API** environment variable. That’s why the Mock Lambda Test tool needs to be started first.
7. Now, go back to the lambda test tool, enter the event in the text box, and press the **Queue Event** button.
8. The moment you press the **Queue Event** button, the debugger is hit in Visual Studio.
    
    ![Running .NET 8 Lambda Functions on AWS using Custom Runtime](/img/blogs/running-net-8-lambda-functions-on-aws-using-custom-runtime/13.png)
    
9. So this is how you can easily debug and test your Lambda function.

## Summary

Though we have covered this throughout the post, again re-iterating that, we have:

- 2 types of Runtimes
    - Managed runtime
    - Custom runtime
- 2 types of .NET Lambda functions
    - Class library handler
    - Executing assembly handler

## References

- [Building serverless .NET applications on AWS Lambda using .NET 7](https://aws.amazon.com/blogs/compute/building-serverless-net-applications-on-aws-lambda-using-net-7/)
- [Custom Lambda runtimes](https://docs.aws.amazon.com/lambda/latest/dg/runtimes-custom.html)
- [The AWS .NET Mock Lambda Test Tool](https://github.com/aws/aws-lambda-dotnet/tree/master/Tools/LambdaTestTool)