Title: Choosing the perfect memory for your AWS Lambda functions
Published: 09/07/2022
Author: Ankush Jain
IsActive: true
ImageFolder: determine-the-right-memory-for-your-lambda-using-aws-cloudwatch-logs-insights
SeoTags: dotnet, aws, .net on aws, aws lambda, optimize aws lambda memory, serverless
Tags:
  - .NET Core
  - AWS
  - .NET on AWS
  - Lambda
UniqueIdentifier: ddfd90fd-cd47-4efd-82c0-ebad95c15c2e
---
In the world of serverless computing, choosing the right memory configuration for your AWS Lambda functions is crucial for optimal performance and cost-efficiency. Determining the ideal memory allocation requires careful consideration and understanding of your application's requirements. By properly sizing the memory, you can ensure that your Lambda functions have the necessary resources to handle their workload effectively.

Optimizing memory for your Lambda functions is one of the important things you should know. This helps you in both - performance as well as cost optimization. You can save a good amount of money by reducing the allocated memory to over-provisioned Lambda functions.

In this post, I will show you one of the ways to determine the right memory for your Lambda Function.

## Pre-requisite
This approach makes use of **Amazon CloudWatch** logs. So, make sure the Lambda execution role has enough permission to send logs to Amazon CloudWatch.

## Step 1: Invoke Lambda Function N Times
In the first step, you just need to invoke your Lambda Function multiple times, say 10 times, 50 times, 100 times or more. These executions will generate logs in **Amazon CloudWatch**, which will be used in further steps.

To invoke your Lambda Function multiple times, you can use any approach from the following:
* Use some Load Testing tools such as JMeter, k6, NBomber, etc.
* Use the EventBridge rule to run on a schedule and invoke Lambda
* Invoke Lambda Function using code
* Invoke Lambda Function manually from the console

or any other way that you are comfortable with.

## Step 2: Query Logs using Amazon CloudWatch Logs Insights
>  **Amazon CloudWatch Logs Insights** allows you to search and analyze your log data stored in Amazon CloudWatch Logs. You can perform queries to efficiently and effectively analyze log data for specific use cases.
>
>  Example of most common use cases:
>  * Lambda: View latency statistics for 5-minute intervals
>  * Lambda: Determine the amount of overprovisioned memory
>  * Lambda: Find the most expensive requests
>  * VPC Flow Logs: Top 20 source IP addresses with highest number of rejected requests
>  * Common queries: Number of exceptions logged every 5 minutes
>  * Common queries: 25 most recently added log events


Follow the below easy steps to run a query in **Amazon CloudWatch Logs Insights**.
1.  Go to **Amazon CloudWatch**, select **Logs Insights** from the left menu
2.  Select the **Log Group** of your Lambda Function from the dropdown (select only 1 at a time)
3.  Select the time duration, when you ran your Lambda Function multiple times
4.  Copy the below query and press the Run query button.
    ```markup
    filter @type = "REPORT"
          | stats max(@memorySize / 1000 / 1000) as provisonedMemoryMB,
              min(@maxMemoryUsed / 1000 / 1000) as smallestMemoryRequestMB,
              avg(@maxMemoryUsed / 1000 / 1000) as avgMemoryUsedMB,
              max(@maxMemoryUsed / 1000 / 1000) as maxMemoryUsedMB,
              provisonedMemoryMB - maxMemoryUsedMB as overProvisionedMB
    ```

Here is a screenshot with the above query:

![Choosing the perfect memory for your AWS Lambda functions](/img/blogs/determine-the-right-memory-for-your-lambda-using-aws-cloudwatch-logs-insights/1.png)

## Step 3: Observing Results

After running the above query in **Amazon CloudWatch Logs Insights**, you will get the result below. This result will provide you with numbers for the below parameters:
*   avgMemoryUsedMB	
*   maxMemoryUsedMB	
*   overProvisionedMB	
*   provisonedMemoryMB	
*   smallestMemoryRequestMB	

With the help of the above parameters, you can easily decide how much memory would be required for your Lambda Function to run efficiently. To be on the safe side, you should always provision some extra memory. 

![Choosing the perfect memory for your AWS Lambda functions](/img/blogs/determine-the-right-memory-for-your-lambda-using-aws-cloudwatch-logs-insights/2.png)

## Conclusion
In this post, you learned how can you determine the right memory for your Lambda function using Amazon CloudWatch Logs Insights. Please let me know your thoughts and feedback in the comment section below.

Thank You ❤️

## References
*   [How do I monitor my Lambda function's memory usage?](https://aws.amazon.com/premiumsupport/knowledge-center/lambda-function-memory-usage-monitoring/)
*   [Sample queries](https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CWL_QuerySyntax-examples.html)


                
