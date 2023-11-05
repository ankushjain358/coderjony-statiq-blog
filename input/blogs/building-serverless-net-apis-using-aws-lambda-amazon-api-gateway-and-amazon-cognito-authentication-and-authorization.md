Title: Building Serverless .NET APIs using AWS Lambda, Amazon API Gateway, and Amazon Cognito | Authentication and Authorization
Published: 04/11/2023
Author: Ankush Jain
IsActive: true
ImageFolder: building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito
SeoTags: Serverless .NET, AWS Lambda, Amazon API Gateway, Amazon Cognito, Serverless APIs, API Development, Security, Authentication, AWS Services, .NET Development, Cloud Computing, AWS Integration, Web Services, AWS Security, Amazon Web Services, .NET Core, Identity and Access Management, Scalable APIs, Cloud Development, AWS Best Practices.
Tags:
  - .NET Core
  - AWS
  - .NET on AWS
---
# Building Serverless .NET APIs using AWS Lambda, Amazon API Gateway, and Amazon Cognito

In this blog post, you'll learn how you can build Serverless .NET APIs with AWS Lambda, Amazon API Gateway, and secure them using Amazon Cognito.

I have created this [YouTube playlist](https://www.youtube.com/playlist?list=PL7OOStOfKPFfekur5LJFyI0e6wQB7KiJO) to explain you everything that you need to know to build cost-effective serverless .NET APIs or .NET microservices, and secure them using Amazon Cognito.

The following AWS services are used while building serverless .NET APIs on AWS:

- Amazon API Gateway
- AWS Lambda Function
- Amazon Cognito
- AWS CDK (used for the deployment)

## Table of Contents
- [Benefits of building serverless .NET APIs](#benefits-of-building-serverless.net-apis)
- [GitHub Repository](#github-repository)
- [Architecture](#architecture)
- [Chatpters](#chatpters)
- [Directory Structure](#directory-structure)
- [How to Deploy](#how-to-deploy)
- [How to Test](#how-to-test)

## Benefits of building serverless .NET APIs
The most important benefit when building serverless APIs on AWS is that you will not be charged if your APIs are idle and have no traffic, and once they do, you will not have to worry about scaling because AWS will take care of it.

The second advantage is that high availability is built in. Because AWS Lambda, Amazon API Gateway, and Amazon Cognito are regional services, you don't even need to worry about deploying your resources into various availability zones for HA, as these regional services provide high availability by default.

## GitHub Repository
This repository provides you code samples along with the guidance how you can build serverless .NET APIs on AWS and secure them with Amazon Cognito.

This repository contains sample .NET applications that can be deployed as Lambda functions and exposed as APIs using the Amazon API Gateway REST API.

GitHub Repository - [ankushjain358/serverless-dotnet-apis-with-amazon-cognito](https://github.com/ankushjain358/serverless-dotnet-apis-with-amazon-cognito)

## Architecture
The following diagram captures the architecture of the Serverless .NET APIs that we will build in this series. 

![Choosing the perfect memory for your AWS Lambda functions](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/architecture.png)


## Chatpters
Here are the chapters or videos that you will find in this video series.

1. [Introduction to Architecture and GitHub Project](https://www.youtube.com/watch?v=-yDLQ1pDTuE)
2. [Building and Deploying Your First Serverless .NET API Using AWS Lambda & Amazon API Gateway](https://www.youtube.com/watch?v=cd8LSNACzxE)
3. [Introduction to Amazon Cognito User Pools](https://www.youtube.com/watch?v=7O9O44AetgQ)
4. [Creating Amazon Cognito User Pool & App Client](https://www.youtube.com/watch?v=PCIbfJ9pj8I)
5. [Securing .NET API with Amazon Cognito | Implementing Authentication](https://www.youtube.com/watch?v=XkCOnRP0bYs)
6. [Securing .NET API With Amazon Cognito | Implementing Authorization (role-based)](https://www.youtube.com/watch?v=9XQRvq4iIGM)
7. [Fine-Grained Authorization With Custom Scopes Using Amazon Cognito](https://www.youtube.com/watch?v=64Al6FGRed4)
8. [Proxy Integration | Separate Lambda functions for each endpoint | Class library handler](https://www.youtube.com/watch?v=ugn6lNscRQc)
9. [Proxy Integration | Authentication & Authorization in .NET Lambda function using Amazon Cognito | Class library handler](https://www.youtube.com/watch?v=SQ3NV226U8o)
10. [How to Deploy & Test](https://www.youtube.com/watch?v=p_6avllx5Ew)


### 1. Introduction to Architecture and GitHub Project
In this video, you'll learn the following:
- Understanding the solution architecture of the serverless .NET APIs built in this series.
- Exploring the GitHub repository specially created for this series and getting acquainted with the code structure.
- Discovering how you can run two different types of .NET applications inside a Lambda function:
  - ASP.NET Core Web API
  - Class Library (Class library handlers)

[![Image](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/dotnet-apis-amazon-cognito-1.jpg){width=40%}](https://www.youtube.com/watch?v=-yDLQ1pDTuE){target="_blank" style="margin-left:20%"}
  
### 2. Building and Deploying Your First Serverless .NET API Using AWS Lambda & Amazon API Gateway
In this video, you'll learn the following:
- Creating your first serverless ASP.NET Core API
- Configuring an ASP.NET Core API to run as a Lambda Function
- Understanding the differences between Class library handlers and ASP.NET Core Lambda Functions
- Exploring the inner workings of .NET Lambda Functions
- Deploying your application to AWS Lambda via Visual Studio
- Creating an API Gateway
- Linking an API Gateway route to a Lambda function using Proxy Resource and Proxy Integration
- Conducting tests on the REST API Endpoint using ThunderClient
  
[![Image](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/dotnet-apis-amazon-cognito-2.jpg){width=40%}](https://www.youtube.com/watch?v=cd8LSNACzxE){target="_blank" style="margin-left:20%"}
  
### 3. Introduction to Amazon Cognito User Pools
In this video, you will learn the following:
- What is Amazon Cognito
- The differences between Cognito User Pool and Identity Pool
- Key features of Amazon Cognito User Pool
- How to Secure API Gateway using Cognito Authorizer

[![Image](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/dotnet-apis-amazon-cognito-3.jpg){width=40%}](https://www.youtube.com/watch?v=7O9O44AetgQ){target="_blank"}{style="margin-left:20%"}

### 4. Creating Amazon Cognito User Pool & App Client
In this video, you'll learn the following:
- Creating an Amazon Cognito User Pool with an App Client.
- The process of creating a user in Amazon Cognito.
- Setting up an Admin Group within Amazon Cognito.

[![Image](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/dotnet-apis-amazon-cognito-4.jpg){width=40%}](https://www.youtube.com/watch?v=PCIbfJ9pj8I){target="_blank"}{style="margin-left:20%"}
  
### 5. Securing .NET API with Amazon Cognito | Implementing Authentication
In this video, you'll learn the following:
- Creating an ASP.NET Core API and configuring it to run as a Lambda Function.
- Understanding the importance of application-level security.
- Creating a Lambda Function in the AWS Console and deploying the ASP.NET Core API to Lambda using Visual Studio.
- Creating a Cognito Authorizer to enable security.
- Creating an API Gateway route and linking it to the Lambda function using Proxy Resource and Proxy Integration.
- Associating the Cognito Authorizer with the API Gateway route.
- Obtaining a Cognito token from ThunderClient and inspecting it at jwt.io.
- Conducting API testing from ThunderClient.

[![Image](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/dotnet-apis-amazon-cognito-5.jpg){width=40%}](https://www.youtube.com/watch?v=XkCOnRP0bYs){target="_blank"}{style="margin-left:20%"}
  
### 6. Securing .NET API With Amazon Cognito | Implementing Authorization (role-based)
In this video, you'll gain knowledge about the following:
- Creating an ASP.NET Core API and configuring it to run as a Lambda Function.
- Understanding the importance of application-level security.
- Implementing Role-Based Authorization in ASP.NET Core API.
- Creating a Lambda Function in the AWS Console and deploying the ASP.NET Core API to Lambda using Visual Studio.
- Creating a Cognito Authorizer to enable security.
- Creating an API Gateway route and linking it to the Lambda function using Proxy Resource and Proxy Integration.
- Associating the Cognito Authorizer with the API Gateway route.
- Obtaining a Cognito token from ThunderClient and inspecting it at jwt.io.
- Thoroughly testing the API from ThunderClient.

[![Image](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/dotnet-apis-amazon-cognito-6.jpg){width=40%}](https://www.youtube.com/watch?v=9XQRvq4iIGM){target="_blank"}{style="margin-left:20%"}
  
### 7. Fine-Grained Authorization With Custom Scopes Using Amazon Cognito
In this video, you will explore the following:
- Why do we need Custom Scopes in the API?
- Understanding the concept of a Resource Server.
- An in-depth look at OAuth Custom Scopes.
- The process of creating a Resource Server within Amazon Cognito.
- How to add Custom Scopes to a Resource Server.
- Creating an ASP.NET Core API for implementing fine-grained access control using Cognito Custom Scopes.
- Setting up an API Gateway route and connecting it to a Lambda function through Proxy Resource and Proxy Integration.
- Configuring Cognito Security at the API Gateway route.
- Obtaining a Cognito token from ThunderClient and examining it at jwt.io.
- Thoroughly testing the API from ThunderClient.
  
[![Image](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/dotnet-apis-amazon-cognito-7.jpg){width=40%}](https://www.youtube.com/watch?v=64Al6FGRed4){target="_blank"}{style="margin-left:20%"}
  
### 8. Proxy Integration | Separate Lambda functions for each endpoint | Class library handlers
In this video, you'll learn the following:

- Differentiating between a Class Library Lambda Function (Class library handlers) and an ASP.NET Core API Lambda Function.
- Creating a Class Library handler Lambda Function from scratch.
- Deploying the Class library handler Lambda Function using Visual Studio.
- Creating an API Gateway route and linking it to the Lambda function through Proxy Integration.
- Testing the API using ThunderClient.
  
[![Image](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/dotnet-apis-amazon-cognito-8.jpg){width=40%}](https://www.youtube.com/watch?v=ugn6lNscRQc){target="_blank"}{style="margin-left:20%"}

### 9. Proxy Integration | Authentication & Authorization in .NET Lambda function using Amazon Cognito | Class library handler
In this video, you'll learn the following:
- Understanding the differences between a Class Library handlers and an ASP.NET Core API Lambda Function.
- Creating a Class Library handler Lambda Function from scratch.
- Deploying the Class library handler Lambda Function using Visual Studio.
- Understanding the importance of application-level security.
- Creating or utilizing an existing Cognito Authorizer.
- Creating an API Gateway route and linking it to the Lambda function through Proxy Integration.
- Obtaining a Cognito token from ThunderClient and inspecting it at jwt.io.
- Testing the API using ThunderClient.
  
[![Image](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/dotnet-apis-amazon-cognito-9.jpg){width=40%}](https://www.youtube.com/watch?v=SQ3NV226U8o){target="_blank"}{style="margin-left:20%"}

### 10. How to Deploy & Test
In this video, you'll learn the following:
- Deploying the GitHub solution on AWS using AWS CDK.
- Testing the deployed APIs effectively using ThunderClient.

[![Image](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/dotnet-apis-amazon-cognito-10.jpg){width=40%}](https://www.youtube.com/watch?v=p_6avllx5Ew){target="_blank"}{style="margin-left:20%"}

## Directory Structure
![serverless-dotnet-apis-with-amazon-cognito-directory-structure](/img/blogs/building-serverless-net-apis-using-aws-lambda-amazon-api-gateway-and-amazon-cognito/directory-structure.png)

## How to Deploy
### Prerequisites

Here's what you need to install to use the AWS CDK.

- [Node.js](https://nodejs.org/en/download/) 14.15.0 or later
- [AWS CLI](https://docs.aws.amazon.com/cli/latest/userguide/getting-started-install.html)
- [AWS CDK Toolkit](https://docs.aws.amazon.com/cdk/v2/guide/getting_started.html#getting_started_install)
- .NET 6.0 or later, [available here](https://dotnet.microsoft.com/en-us/download)

After having all the above prerequisites, you must establish how the AWS CDK authenticates with AWS. To learn how to do this, refer [authentication with AWS](https://docs.aws.amazon.com/cdk/v2/guide/getting_started.html#getting_started_auth).

### Deployment steps
1. Run `git clone https://github.com/ankushjain358/serverless-dotnet-apis-with-amazon-cognito.git` to clone the repository.
2. Run `cd ./cdk/src` to navigate to the CDK application project.
3. Run `dotnet restore` to install all the necessary dependencies.
4. If this is your first time deploying the CDK stack in the AWS account, run `cdk bootstrap`.
5. Run `dotnet build` to compile the application and ensure there are no build errors.
6. Run `cd..` to return one level back where `cdk.json` file is present.
7. Run `cdk deploy` to deploy your CDK stack to AWS.
8. Confirm the changes when prompted. Type "y" to proceed with the deployment.
9. Once the deployment is complete, monitor the AWS CloudFormation events to ensure that the stack creation/update was successful.

## How to Test
1. Use ThunderClient extension in VS Code to test the APIs.
2. Import the `collections` and `environment variables` in ThunderClient from `thunder-client` folder from the [GitHub repository](https://github.com/ankushjain358/serverless-dotnet-apis-with-amazon-cognito/)
3. Update the environment variable values with their actual values.
4. Save everything.
5. You're good to go!