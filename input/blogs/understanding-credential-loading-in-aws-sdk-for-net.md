Title: Understanding Credential Loading in AWS SDK for .NET
Published: 18/02/2022
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
In this post, we will understand how does AWS SDK for .NET loads the AWS credentials.

Mainly, we will understand what are the places where does the SDK look for the credentials and what order it follows?

We will understand this process in 2 steps. 

*   First, we will understand a general AWS SDK setup for .NET applications

*   Secondly, we will understand how does AWS SDK load the credentials



So let's start.

## Part 1 - General AWS SDK setup for .NET applications

You can also refer to this link where I have explained [How to configure the AWS SDK for .NET with .NET Core](https://www.coderjony.com/blogs/configuring-the-aws-sdk-for-net-with-net-core/).

### 1. Install NuGet package

First, install the `Amazon.Extensions.NETCore.Setup` NuGet package.

### 2. Prepare AWSOptions obejct

Next, we need to create an object of the `AWSOptions` type. This type basically holds 2 properties that we can use to retrieve AWS credentials. Those properties are:

*   AWSOptions.Profile

*   AWSOptions.Credentials



There are multiple ways to create an object of the `AWSOptions` type. See a few of them below:

```
    // way 1: we can get AWS profile info directly from configuration
    AWSOptions awsOptions = builder.Configuration.GetAWSOptions();

    // way 2: we can set credentials manually
    AWSOptions awsOptions = new AWSOptions
    {
        Credentials = new BasicAWSCredentials("123", "456")
    };

    // way 3: we can set the profile manually
    AWSOptions awsOptions = new AWSOptions
    {
        Profile = "custom",
        ProfilesLocation = @"c:\temp\credentials"
    };
    ```

### 3. Pass AWSOptions object to ClientFactory via Extension Methods

Now, we have created an `AWSOptions` object that holds the credential information. All, we need to do is pass this information to the [`ClientFactory`](https://github.com/aws/aws-sdk-net/blob/master/extensions/src/AWSSDK.Extensions.NETCore.Setup/ClientFactory.cs) class which is responsible for creating instances of AWS Service Clients such as `AmazonS3Client` or `AmazonSQSClient`.

This `ClientFactory` is an internal class of `Amazon.Extensions.NETCore.Setup` NuGet package. In order to supply AWS credentials to this class, we use below extension methods provided by this package.

*   AddDefaultAWSOptions

*   AddAWSService



This is how we can use these extension methods:

1.  

We can add `AWSOptions` object in service collection using `AddDefaultAWSOptions` extension method.

`builder.Services.AddDefaultAWSOptions(awsOptions);`

2.  

We can pass it directly `AddAWSService` extension method.

`builder.Services.AddAWSService<iamazons3>(awsOptions);</iamazons3>`

This is how overall `Program.cs` will look like: ![Understanding Credential Loading in AWS SDK for .NET](/img/blogs/understanding-credential-loading-in-aws-sdk-for-net/understanding-credential-loading-in-aws-sdk-for-net.png)

### 4.  Deep dive in AddAWSService extension method - Very important

This [`AddAWSService`](https://github.com/aws/aws-sdk-net/blob/master/extensions/src/AWSSDK.Extensions.NETCore.Setup/ServiceCollectionExtensions.cs) extension method is part of **Amazon.Extensions.NETCore.Setup** NuGet package. This method uses reflection to dynamically load AWS Service Client assembly (i.e. AWSSDK.S3.dll) and register the service client in IoC container as per its interface. 

`AddAWSService` first calls [`ClientFactory.CreateServiceClient`](https://github.com/aws/aws-sdk-net/blob/master/extensions/src/AWSSDK.Extensions.NETCore.Setup/ClientFactory.cs) method, this method creates service client, but before that, it needs to load the AWS credentials, for that it calls [`ClientFactory.CreateCredentials`](https://github.com/aws/aws-sdk-net/blob/master/extensions/src/AWSSDK.Extensions.NETCore.Setup/ClientFactory.cs) method. Once the credentials are obtained, it calls [`ClientFactory.CreateClient`](https://github.com/aws/aws-sdk-net/blob/master/extensions/src/AWSSDK.Extensions.NETCore.Setup/ClientFactory.cs) that actually uses reflection to dynamically load the assembly.

I have copied the implementation of the `ClientFactory.CreateServiceClient` method below for your reference.

```
    /// <summary>
    /// Creates the AWS service client that implements the service client interface. The AWSOptions object
    /// will be searched for in the IServiceProvider.
    /// </summary>
    /// <param name="provider">The dependency injection provider.</param>
    /// <returns>The AWS service client</returns>
    internal static IAmazonService CreateServiceClient(ILogger logger, Type serviceInterfaceType, AWSOptions options)
    {
        var credentials = CreateCredentials(logger, options);
        var config = CreateConfig(serviceInterfaceType, options);
        var client = CreateClient(serviceInterfaceType, credentials, config);
        return client as IAmazonService;
    }
    ```

Mainly [`ClientFactory.CreateCredentials`](https://github.com/aws/aws-sdk-net/blob/master/extensions/src/AWSSDK.Extensions.NETCore.Setup/ClientFactory.cs) method is responsible for loading the AWS credentials.

## Part 2 - How AWS credentials are loaded

This is the most important part to understand, as credential loading happens differently in different environments such as applications running in:

*   Local development machine

*   EC2 instance

*   ECS task

*   Lambda function

*   etc.



So, let's understand the order in which AWS SDK loads the credentials.

### AWSOptions

`AddAWSService` extension method first tries to load the credentials from `AWSOptions` registered in service collection or from the parameters (if passed). If the `AWSOptions` object is not null, it follows the below order to load the credentials.

### 1. AWSOptions.Credential

First SDK will check if the `AWSOptions.Credential` property is present then it will use this property to get the credentials.

```
    AWSOptions awsOptions = new AWSOptions
    {
        Credentials = new BasicAWSCredentials("yourAccessKey", "yourAccessSecret")
    };
    builder.Services.AddDefaultAWSOptions(awsOptions);
    ```

### 2. AWSOptions.Profile

If the `AWSOptions.Credential` property is found null, then SDK will check the `AWSOptions.Profile` property. If it is there then it will load the credentials from the profile.

```
    AWSOptions awsOptions = new AWSOptions
    {
        Profile = "custom",
        ProfilesLocation = @"c:\temp\credentials"
    };
    builder.Services.AddDefaultAWSOptions(awsOptions);
    ```

There are 2 types of profiles:

*   Shared AWS Credential File

*   .NET SDK Credential File



#### 2.1 Shared AWS Credentials File

On Windows, by default, this is located at **C:\Users\<username>.aws\credentials</username>**. The SDK will load the profile with the given name from the specified profile location. If the profile location is not specified, it will look at the default location.

A Shared AWS Credential File looks like below:

```
    [default]
    aws_access_key_id = 1111
    aws_secret_access_key = 2222

    [custom]
    aws_access_key_id = 1234
    aws_secret_access_key = 9999
    ```

#### 2.2 .NET Encrypted Store / SDK Store / .NET SDK credentials file

On Windows, the SDK Store is another place to create profiles and store encrypted credentials for your AWS SDK for the .NET application. It's located in **%USERPROFILE%\AppData\Local\AWSToolkit\RegisteredAccounts.json**. You can use the SDK Store during development as an alternative to the shared AWS credentials file.

### Fallback Credentials Factory (When AWSOptions is null)

If both `AWSOptions.Credentials` and`AWSOptions.Profile` are not supplied or `AWSOptions` object itself is null, then [`ClientFactory`](https://github.com/aws/aws-sdk-net/blob/master/extensions/src/AWSSDK.Extensions.NETCore.Setup/ClientFactory.cs) (inside `AddAWSService` extension method) attempts to load the credentials from several fall back options.

### 1. Credential Profile Store Chain

`CredentialProfileStoreChain` is simply an object that loads multiple AWS profiles from a specific profile location.

To determine the profile location, it first checks for its `ProfilesLocations` property. If this property is null or empty, then it loads the profiles from the below locations:

*   SDK Store (if the platform supports it)

*   Shared AWS credentials file (from the default location)



The profile name will be loaded from the environment variable `AWS_PROFILE`. If there is no such environment variable, then `default` will be used as a profile name.

### 2. Environment Variables AWS Credentials

If SDK still hasn't got the credentials, then it checks for the following environment variables to load the AWS credentials.

```
    ENVIRONMENT_VARIABLE_ACCESSKEY = "AWS_ACCESS_KEY_ID";        
    ENVIRONMENT_VARIABLE_SECRETKEY = "AWS_SECRET_ACCESS_KEY";        
    ENVIRONMENT_VARIABLE_SESSION_TOKEN = "AWS_SESSION_TOKEN";
    ```

### 3.  EC2 Instance Profile or ECS Task Profile

Finally, this is the most important place where the SDK looks for the credentials. This would be the best place for the applications that are running in the AWS environment.

In this case, SDK loads the AWS credentials from the EC2 instance profile or ECS task role.

## Conclusion

In this post, we understood how AWS SDK for .NET loads the AWS credentials by searching them at various locations, and what sequence it follows to search them. I hope this post would help you in understanding how credential loading works under the hood.

Please let me know your feedback and suggestions in below comment section.

Thank You ❤️

                