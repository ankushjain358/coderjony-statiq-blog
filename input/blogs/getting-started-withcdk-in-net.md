Title: Getting Started with AWS CDK using .NET
Published: 07/22/2022
Author: Ankush Jain
IsActive: true
Tags:
  - .NET
  - AWS
  - .NET on AWS
  - CDK
---
In this post, we will understand, how to easily get started with CDK in .NET.

## Step 1: Install CDK CLI
Run below command to install CDK CLI using NPM.
```bash
npm install -g aws-cdk
```

## Step 2: Create .NET Core application from CDK Template using CDK CLI
Run below commands to create new directory and then change your working directory to new one.
```bash
mkdir cdk-sample-app
cd cdk-sample-app
```
Now, run below command to quickly generate basic template to get started. This basic template includes .NET solution with one project.
```
cdk init app --language csharp
```
This is how the directory structure look like.

![image](https://user-images.githubusercontent.com/13661966/180404455-7ed3b188-0c2a-46ec-9d8e-96250f3225d1.png)

Inside, **src** folder.

![image](https://user-images.githubusercontent.com/13661966/180405098-9036e2a1-95df-40f8-9c16-6906f4a38f54.png)

Once you open the solution, you can see the `Program.cs` file with the following content.

![image](https://user-images.githubusercontent.com/13661966/180406259-9150a91c-b091-4a9f-9aff-f28513ed66d9.png)


## Step 3: Install NuGet packages
Install following NuGet packages to create an S3 bucket and DynamoDB table using CDK.
```
Amazon.CDK
Amazon.CDK.AWS.S3
Amazon.CDK.AWS.DynamoDB
```
`Amazon.CDK` is the base package, that must be installed whenever you are working with CDK.

## Step 4: Create S3 Bucket & DynamoDB table using CDK
Go to `Program.cs` and replace existing code with below:
```cs
public static void Main(string[] args)
{
    var app = new App();
    new CdkSampleAppStack(app, "CdkSampleAppStack");
    app.Synth();
}
```

Next, go to `CdkSampleAppStack.cs` file, and replace the code there as per below.

```cs
public class CdkSampleAppStack : Stack
{
    internal CdkSampleAppStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
    {
        // Create S3 bucket
        new Bucket(this, "MyFirstBucket", new BucketProps
        {
            Versioned = true
        });

        // Create DynamoDB Table
        new Table(this, "MyFirstDynamoDBTable", new TableProps
        {
            PartitionKey = new Attribute { Name = "PK", Type = AttributeType.STRING },
            SortKey = new Attribute { Name = "SK", Type = AttributeType.STRING },
            BillingMode = BillingMode.PAY_PER_REQUEST
        });
    }
}
```

## Step 5: Build the application
Run following command to build this application.
```
cd src
dotnet build
```

## Useful commands
- dotnet build src compile this app
- cdk deploy       deploy this stack to your default AWS account/region
- cdk synth        emits the synthesized CloudFormation template
cdk init
