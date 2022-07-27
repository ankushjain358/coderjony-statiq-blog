Title: Getting Started with AWS CDK using .NET
Published: 07/22/2022
Author: Ankush Jain
IsActive: true
Tags:
  - .NET Core
  - AWS
  - .NET on AWS
  - CDK
UniqueIdentifier: d2038e01-b100-4ec2-bbf7-169acbf514dd
---
In this post, we will understand, how to easily get started with CDK in .NET.

CDK stands for **Cloud Development Kit**. CDK allows developers to provision the resources in the AWS cloud programmatically. CDK supports a variety of programming languages including C#, Java, Python, Go, JavaScript & TypeScript.

## Step 1: Install CDK CLI
Run the below command to install CDK CLI using NPM.
```bash
npm install -g aws-cdk
```

## Step 2: Create .NET Core CDK App using CDK CLI
In this step, you will create a CDK App. An `App` in the CDK represents the entry point for the entire CDK application. The CDK App is composed of one or more `Stacks` (same as a CloudFormation stack).

The unit of deployment in the AWS CDK is called a `stack`. All AWS resources defined in a stack, are provisioned as a single unit.

Run the below commands to create a new directory and then change your working directory to the new one.
```bash
mkdir cdk-sample-app
cd cdk-sample-app
```
Now, run the below command to quickly generate a basic template to get started. This basic template includes .NET solution with one project.
```bash
cdk init app --language csharp
```

This is what the directory structure looks like.

![image](https://user-images.githubusercontent.com/13661966/180404455-7ed3b188-0c2a-46ec-9d8e-96250f3225d1.png)

Inside, **src** folder.

![image](https://user-images.githubusercontent.com/13661966/180405098-9036e2a1-95df-40f8-9c16-6906f4a38f54.png)

Once you open the solution, you can see the `Program.cs` file. This contains a **CDK App** along with one **CDK Stack**.

![image](https://user-images.githubusercontent.com/13661966/180406259-9150a91c-b091-4a9f-9aff-f28513ed66d9.png)


## Step 3: Install NuGet packages
Install the following NuGet packages to create an S3 bucket and DynamoDB table using CDK.
```powershell
Install-Package Amazon.CDK
Install-Package Amazon.CDK.AWS.S3
Install-Package Amazon.CDK.AWS.DynamoDB
```
`Amazon.CDK` is the base package, that must be installed whenever you are working with CDK.

## Step 4: Modify CDK Stack - Create S3 Bucket & DynamoDB table using CDK
Go to `Program.cs` and replace the existing code with the below:
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
Run the following command to build this application.
```bash
cd src
dotnet build
```

## Step 6: Bootstrapping AWS environment for CDK deployment
You need to provision a few AWS resources in advance to deploy a CDK app in an environment. Those resources include:
- **Amazon S3 bucket** for storing CloudFormation files 
- **IAM roles** that grant permissions needed to perform deployments

The process of provisioning these initial resources is called _bootstrapping_.

Bootstrapping is required only once per environment, where the _environment_ is a combination of the target AWS account & region into which the stack is intended to be deployed.

To bootstrap, your AWS environment for CDK deployment, run the below command. 
```bash
cdk bootstrap
```
Running the above command will create necessary resources in AWS. See the below screenshot.

![image](https://user-images.githubusercontent.com/13661966/180462232-6d69576c-354f-4fb5-840a-4f0c0ccd51d4.png)

Here is another screenshot of the CDK Stack from AWS Console.

![image](https://user-images.githubusercontent.com/13661966/180472066-1a3d4e52-5f4c-461f-b796-27227b49a8d5.png)


## Step 5: Deploy the CDK stack
Run the below command to go to the root folder, as you should be on `src` folder due to the previous step. 
``bash
cd.. 
``

Next, run the following command to deploy the CDK stack.
```bash
cdk deploy
```
Running the above command will deploy the entire stack on AWS.

![image](https://user-images.githubusercontent.com/13661966/180473805-77621ca5-0ce7-480d-8795-65a087eecb66.png)

The same, we can verify from AWS Console. See the below screenshot.

![image](https://user-images.githubusercontent.com/13661966/180474103-35ae4081-7fcb-4acf-a468-9a479b3b475a.png)

To delete all the resources created by this Stack, just press **Delete** button shown in the above picture.

## Useful commands
- `dotnet build src` compile this app.
- `cdk deploy` deploy this stack to your default AWS account/region.
- `cdk diff` to compare the changes between your currently deployed stack, and the one generated by your code.
- `cdk init` creates a new CDK project in the current directory from a specified template.
- `cdk synth` command executes your app, which causes the resources defined in it to be translated into an AWS CloudFormation template.
  
   Running `cdk synth` command will generate JSON templates in **cdk.out** directory as shown below.
  
   ![image](https://user-images.githubusercontent.com/13661966/180475842-cbac7ad0-660a-4f4c-999c-16c47581fb66.png)


## Conclusion
In this post, you learned how easily can you deploy resources programmatically using AWS CDK. Please let me know your thoughts and feedback in the comment section below.

Thank You ❤️

# References
- [AWS CDK for .NET](https://aws.amazon.com/blogs/developer/aws-cdk-for-net/)
- [AWS Cloud Development Kit (CDK) v2](https://docs.aws.amazon.com/cdk/v2/guide/work-with-cdk-csharp.html)

