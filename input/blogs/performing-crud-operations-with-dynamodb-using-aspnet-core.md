Title: Performing CRUD operations with DynamoDB using ASP.NET Core
Published: 27/02/2022
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
In this post, we will understand how can we create a DynamoDB table in the AWS cloud and connect it with an ASP.NET Core application to perform CRUD operations.

## Tools & Frameworks

We will be using below tools and frameworks in this post going forward.

*   Visual Studio 2022

*   .NET 6

*   AWS account



## Step 1: Create a DynamoDB table in the AWS account

Login to your AWS account, search for DynamoDB. On the DynamoDB page, select **Tables > Create Table** as shown in the below picture. ![Performing CRUD operations with DynamoDB using ASP.NET Core](/img/blogs/performing-crud-operations-with-dynamodb-using-aspnet-core/1-performing-crud-operations-with-dynamodb-using-aspnet-core.png) In this demo, we are creating a `products` table with the following information.

*   Table name: **products**

*   Partition Key: **category**

*   

Sort Key: **name** ![Performing CRUD operations with DynamoDB using ASP.NET Core](/img/blogs/performing-crud-operations-with-dynamodb-using-aspnet-core/2-performing-crud-operations-with-dynamodb-using-aspnet-core.png) In DynamoDB, we can have 2 types of primary keys.

    1.  **Partition Key**  -  In this case, the partition key is our primary key. It should be unique across the table. No two items can have the same partition key. In this case, there is no sort key.

    2.  **Partition Key + Sort Key**  -  In this case, a combination of partition key and sort key is considered as the primary key. Two items could have the same partition key, but the combination of partition key and sort key should be unique across the table.

## Step 2: Create an ASP.NET Core project

Go to visual studio, create an ASP.NET Core project of your choice. Here, I will be creating an ASP.NET Core MVC application. ![Performing CRUD operations with DynamoDB using ASP.NET Core](/img/blogs/performing-crud-operations-with-dynamodb-using-aspnet-core/3-performing-crud-operations-with-dynamodb-using-aspnet-core.png) Provide some additional information such as your project name, project location, etc. ![Performing CRUD operations with DynamoDB using ASP.NET Core](/img/blogs/performing-crud-operations-with-dynamodb-using-aspnet-core/4-performing-crud-operations-with-dynamodb-using-aspnet-core.png) Here, I am using .NET 6 LTS version. Once you have provided all the information, just press the create button. ![Performing CRUD operations with DynamoDB using ASP.NET Core](/img/blogs/performing-crud-operations-with-dynamodb-using-aspnet-core/5-performing-crud-operations-with-dynamodb-using-aspnet-core.png)

## Step 3: Install NuGet packages for DynamoDB

Now you have to install the following NuGet packages to use DynamoDB services in .NET.

1.  Install `AWSSDK.Extensions.NETCore.Setup` to setup dependency injection for AWS Service Clients. 

2.  Install `AWSSDK.DynamoDBv2` to perform DynamoDB related operations.



```
    PM> Install-Package Amazon.Extensions.NETCore.Setup
    PM> Install-Package AWSSDK.DynamoDBv2
    ```

In this picture, you can see we have installed above mentioned NuGet packages. ![Performing CRUD operations with DynamoDB using ASP.NET Core](/img/blogs/performing-crud-operations-with-dynamodb-using-aspnet-core/6-performing-crud-operations-with-dynamodb-using-aspnet-core.png)

## Step 4: Load AWS credentials in SDK

Go to your `appsettings.Development.json` file, and provide your local AWS credential profile information there in the below format.

```
    {
      "AWS": {
        "Profile": "<aws-credential-profile-name>",
        "Region": "ap-south-1"
      }
    }
    ```

Your `appsettings.Development.json` file should look like below: ![Performing CRUD operations with DynamoDB using ASP.NET Core](/img/blogs/performing-crud-operations-with-dynamodb-using-aspnet-core/7-performing-crud-operations-with-dynamodb-using-aspnet-core.png) Now, go to the `Program.cs` file and add below code. This will read AWS credential profile information from configuration file and load it into AWS SDK.

```
    // Get the AWS profile information from configuration providers
    AWSOptions awsOptions = builder.Configuration.GetAWSOptions();

    // Configure AWS service clients to use these credentials
    builder.Services.AddDefaultAWSOptions(awsOptions);
    ```

`Program.cs` file will look like this after adding above code. ![Performing CRUD operations with DynamoDB using ASP.NET Core](/img/blogs/performing-crud-operations-with-dynamodb-using-aspnet-core/12-performing-crud-operations-with-dynamodb-using-aspnet-core.png)

Check out my other blog [Understanding Credential Loading in AWS SDK for .NET](https://coderjony.com/blogs/understanding-credential-loading-in-aws-sdk-for-net/) to understand how does AWS SDK loads credentials in different environments.

## Step 5: Configure Dependency Injection in Program.cs

Copy and paste below lines in your `Program.cs` to configure dependency injection.

```
    builder.Services.AddAWSService<IAmazonDynamoDB>();
    builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();
    ```

`Program.cs` file will look like this after adding above code. ![Performing CRUD operations with DynamoDB using ASP.NET Core](/img/blogs/performing-crud-operations-with-dynamodb-using-aspnet-core/11-performing-crud-operations-with-dynamodb-using-aspnet-core.png)

## Step 6: Create a domain class that maps to the DynamoDB table

Create an entity class to represent your DynamoDB table. Also, decorate this class with proper attributes. 

*   **DynamoDBTable**  -  DynamoDB table name

*   **DynamoDBHashKey** - Partition key

*   **DynamoDBRangeKey**  -  Sort key



```
    using Amazon.DynamoDBv2.DataModel;

    namespace AWS.Demo.DynamoDB.Models
    {
        [DynamoDBTable("products")]
        public class Product
        {
            [DynamoDBHashKey("category")]
            public string Category { get; set; }

            [DynamoDBRangeKey("name")]
            public string Name { get; set; }

            [DynamoDBProperty("description")]
            public string Description { get; set; }

            [DynamoDBProperty("price")]
            public decimal Price { get; set; }
        }
    }
    ```

## Step 7: Write code in Controller to access data

Now, create an API Controller in your ASP.NET Core application and write the code to perform CRUD operations with the DynamoDB table.

Here is the code that I wrote for **ProductController.cs** file.

```
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.DocumentModel;
    using AWS.Demo.DynamoDB.Models;
    using Microsoft.AspNetCore.Mvc;

    namespace AWS.Demo.DynamoDB.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
            private readonly IDynamoDBContext _dynamoDBContext;

            public ProductController(IDynamoDBContext dynamoDBContext)
            {
                _dynamoDBContext = dynamoDBContext;
            }

            [Route("get/{category}/{productName}")]
            [HttpGet]
            public async Task<IActionResult> Get(string category, string productName)
            {
                var product = await _dynamoDBContext.LoadAsync<Product>(category, productName);
                return Ok(product);
            }

            [Route("save")]
            [HttpPost]
            public async Task<IActionResult> Save(Product product)
            {
                await _dynamoDBContext.SaveAsync(product);
                return Ok();
            }

            [Route("delete/{category}/{productName}")]
            [HttpDelete]
            public async Task<IActionResult> Delete(string category, string productName)
            {
                await _dynamoDBContext.DeleteAsync<Product>(category, productName);
                return Ok();
            }

            [Route("search/{category}")]
            [HttpGet]
            public async Task<IActionResult> Search(string category, string? productName = null, decimal? price = null)
            {
                // Note: You can only query the tables that have a composite primary key (partition key and sort key).

                // 1. Construct QueryFilter
                var queryFilter = new QueryFilter("category", QueryOperator.Equal, category);

                if (!string.IsNullOrEmpty(productName))
                {
                    queryFilter.AddCondition("name", ScanOperator.Equal, productName);
                }

                if (price.HasValue)
                {
                    queryFilter.AddCondition("price", ScanOperator.LessThanOrEqual, price);
                }

                // 2. Construct QueryOperationConfig
                var queryOperationConfig = new QueryOperationConfig
                {
                    Filter = queryFilter
                };

                // 3. Create async search object
                var search = _dynamoDBContext.FromQueryAsync<Product>(queryOperationConfig);

                // 4. Finally get all the data in a singleshot
                var searchResponse = await search.GetRemainingAsync();

                // Return it
                return Ok(searchResponse);
            }
        }
    }
    ```

## Step 8: Test APIs using Postman or some Rest API testing tool

I tested these APIs using [Visual Studio Code Rest Client extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client). I have also copied the content of my `api-testing.http` file below. You can use the same to test at your end.

```
    ### Get products by category
    GET https://localhost:7029/api/product/search/Laptops

    ### Search products 
    GET https://localhost:7029/api/product/search/Laptops?price=68999 HTTP/1.1

    ### Get a single product
    GET https://localhost:7029/api/product/get/Laptops/Dell Inspiron 14 Laptop HTTP/1.1

    ### Add or update a new product
    POST https://localhost:7029/api/product/save HTTP/1.1
    content-type: application/json

    {
        "category": "Laptops",
        "name": "Dell Inspiron 14 Laptop",
        "description":"AMD Ryzen™ 7 5700U 8-core/16-thread Mobile Processor with Radeon™ Graphics",
        "price": 68990
    }

    ### Delete single product
    DELETE  https://localhost:7029/api/product/delete/Laptops/Dell Inspiron 14 Laptop HTTP/1.1
    ```

Here is a screenshot that I took during the testing. ![Performing CRUD operations with DynamoDB using ASP.NET Core](/img/blogs/performing-crud-operations-with-dynamodb-using-aspnet-core/9-performing-crud-operations-with-dynamodb-using-aspnet-core.png)

## Step  9: Verify the data in the AWS console

Now go to the AWS console, select table, hit the scan button to view all the data. ![Performing CRUD operations with DynamoDB using ASP.NET Core](/img/blogs/performing-crud-operations-with-dynamodb-using-aspnet-core/10-performing-crud-operations-with-dynamodb-using-aspnet-core.png) That's all.

## Conclusion

In this post, we learned how can we easily get started with DynamoDB using ASP.NET Core applications. Please let me know your thoughts and feedback in the comment section below.

Thank You ❤️

## References

*   [DynamoDBContext Class - Amazon DynamoDB](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/DotNetDynamoDBContext.html)

*   [Querying Tables and Indexes: .NET - Amazon DynamoDB](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/LowLevelDotNetQuerying.html)

*   [AWS DynamoDB For The .NET Developer: How To Easily Get Started](https://www.rahulpnath.com/blog/aws-dynamodb-net-core/)


                