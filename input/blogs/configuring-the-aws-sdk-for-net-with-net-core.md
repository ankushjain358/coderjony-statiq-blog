Title: Configuring the AWS SDK for .NET with .NET Core
Published: 12/02/2022
Author: Ankush Jain
IsActive: true
Tags:
  - .NET Core
  - AWS
  - .NET on AWS
---
In this post, we will step by step understand how to configure and set up a .NET application to use AWS SDK.

In this post, we will only set up SDKs for S3 and SQS services, but the procedure will be the same for any other AWS service you want to use in a .NET application.

So, let's get started.

## Tools & Frameworks

We will be using the below tools and frameworks in this post going forward.
*   Visual Studio 2022
*   .NET 6



## Step 1: Create a new ASP.NET Core Web API project
Create a new ASP.NET Core Web API project from the available templates. 

![Configuring the AWS SDK for .NET with .NET Core](/img/blogs/configuring-the-aws-sdk-for-net-with-net-core/1-configuring-the-aws-sdk-for-net-with-net-core.png) 

Provide some additional information such as your project name, project location, etc. 

![Configuring the AWS SDK for .NET with .NET Core](/img/blogs/configuring-the-aws-sdk-for-net-with-net-core/2-configuring-the-aws-sdk-for-net-with-net-core.png) 

Here, I am using .NET 6 LTS version with controllers option, I have not opted for minimal API. Once you have provided all the information, just press the create button. 

![Configuring the AWS SDK for .NET with .NET Core](/img/blogs/configuring-the-aws-sdk-for-net-with-net-core/3-configuring-the-aws-sdk-for-net-with-net-core.png)

## Step 2: Install NuGet package
Now, go and install **Amazon.Extensions.NETCore.Setup** NuGet package. 

![Configuring the AWS SDK for .NET with .NET Core](/img/blogs/configuring-the-aws-sdk-for-net-with-net-core/4-configuring-the-aws-sdk-for-net-with-net-core.png)

## Step 3: Install AWS Clients for S3 and SQS
In this post, we will configure SDKs for only these 2 services, but this will give you an idea of how to configure them for the rest of the services.

For S3 & SQS, install the below NuGet packages respectively:

```powershell
> Install-Package AWSSDK.S3
> Install-Package AWSSDK.SQS
```

 So, by now we have installed below NuGet packages. 
 
 ![Configuring the AWS SDK for .NET with .NET Core](/img/blogs/configuring-the-aws-sdk-for-net-with-net-core/5-configuring-the-aws-sdk-for-net-with-net-core.png)

## Step 4: ASP.NET Core dependency injection
Now, go to `Program.cs` file and copy the below code there:

```cs
// Get the AWS profile information from configuration providers
AWSOptions awsOptions = builder.Configuration.GetAWSOptions();

// Configure AWS service clients to use these credentials
builder.Services.AddDefaultAWSOptions(awsOptions);

// These AWS service clients will be singleton by default
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddAWSService<IAmazonSQS>();
```

 This is how the overall `Program.cs` will look like: 
 
 ![Configuring the AWS SDK for .NET with .NET Core](/img/blogs/configuring-the-aws-sdk-for-net-with-net-core/6-configuring-the-aws-sdk-for-net-with-net-core.png)

## Step 5: Load AWS credentials in SDK
Go to your `appsettings.Development.json` file, and provide your local AWS profile information there in the below format.
```json
{
    "AWS": {
        "Profile": "local-test-profile",
        "Region": "us-west-2"
    }
}
```

 It will look like the below: 
 
 ![Configuring the AWS SDK for .NET with .NET Core](/img/blogs/configuring-the-aws-sdk-for-net-with-net-core/7-configuring-the-aws-sdk-for-net-with-net-core.png) 
 
 This is because, in the below code snippet, `builder.Configuration.GetAWSOptions()` populates the `AWSOptions.Profile` property from the above configuration file.

```cs
AWSOptions awsOptions = builder.Configuration.GetAWSOptions();
builder.Services.AddDefaultAWSOptions(awsOptions);
```

 Alternatively, if you don't want to load the credentials from the profile (as that will work only on your local machine), you can also update `AWSOptions.Credentials` property like below to have the AWS credentials.

```cs
AWSOptions awsOptions = new AWSOptions 
{
    Credentials = new BasicAWSCredentials("yourAccessKey", "yourAccessSecret")
};
builder.Services.AddDefaultAWSOptions(awsOptions);
```

 However, even if you don't use both - `AWSOptions.Profile` and `AWSOptions.Credentials`, then also SDK is smart enough to search at certain locations to find the AWS credentials. [You can check out this blog to understand how AWS SDK credential loading works](https://coderjony.com/blogs/understanding-credential-loading-in-aws-sdk-for-net/).

## Step 6: Use S3 & SQS clients in the Controller
To use AWS S3 and SQS clients in the controller, you can write code like the below:
```cs
using Amazon.S3;
using Amazon.SQS;
using Microsoft.AspNetCore.Mvc;

namespace AWSSDK.Setup.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IAmazonSQS _sqsClient;

        public UserController(IAmazonS3 s3Client, IAmazonSQS sqsClient)
        {
            _s3Client = s3Client;
            _sqsClient = sqsClient;
        }

        [Route("[action]")]
        public async Task<IActionResult> TestMethod()
        {
            var s3Response = await _s3Client.ListObjectsAsync("yourBucketName");

            var sqsResponse = await _sqsClient.CreateQueueAsync("yourQuueName");

            return Ok();
        }
    }
}
```

 This is what the above code will look like: 
 
 ![Configuring the AWS SDK for .NET with .NET Core](/img/blogs/configuring-the-aws-sdk-for-net-with-net-core/8-configuring-the-aws-sdk-for-net-with-net-core.png) That's all.

## Conclusion
In this post, we learned how quickly we can set up AWS SDK in a .NET application for any AWS service that we want to use. Please let me know your thoughts and feedback in the comment section below.

Thank You ❤️

## References
*   [Credential Loading and the AWS SDK for .NET (Deep Dive)](https://www.stevejgordon.co.uk/credential-loading-and-the-aws-sdk-for-dotnet-deep-dive)
*   [Getting Started with the AWS SDK in .NET Core](https://www.stevejgordon.co.uk/getting-started-with-the-aws-sdk-in-net-core-part-1)
*   [Using AWSSDK.Extensions.NETCore.Setup and the IConfiguration interface - AWS SDK for .NET](https://docs.aws.amazon.com/sdk-for-net/v3/developer-guide/net-dg-config-netcore.html)


                