Title: Connecting with Azure SQL Database using Azure Active Directory and Managed Identity in .NET Core
Published: 13/12/2020
Author: Ankush Jain
IsActive: true
ImageFolder: connecting-with-azure-sql-database-using-azure-active-directory-and-managed-identity-in-net-core
Tags:
  - Azure
  - Azure SQL Database
  - SQL Server
---
Steps to connect Azure SQL with Azure Active Directory

1.  Create an Azure SQL Database
2.  Configure it to use Azure AD by setting up an admin
3.  Connect with SSMS to your database using **Azure Active Directory - Universal with MFA** authentication

4.  **For Local Development**

    - Go to **Visual Studio > Tools > Options > Azure Service Authentication** (Login with your AD Account)
    - Run the below script to add your email id which is an Azure AD Identity as a user in SQL Server

    ```sql
    CREATE USER [your.name@domain.com] FROM EXTERNAL PROVIDER; 
    ALTER ROLE db_datareader ADD MEMBER [your.name@domain.com]; 
    ALTER ROLE db_datawriter ADD MEMBER [your.name@domain.com]; 
    ALTER ROLE db_ddladmin ADD MEMBER [your.name@domain.com]; 
    GO
    ```

5.  **When App runs in Azure cloud**

    - Create an **App Service** and enable **System Assigned Managed Identity**
    - Run the below script to add your email id which is an Azure AD Identity as a user in SQL Server

    ```sql
    CREATE USER [<identity-name>] FROM EXTERNAL PROVIDER;
    ALTER ROLE db_datareader ADD MEMBER [<identity-name>];
    ALTER ROLE db_datawriter ADD MEMBER [<identity-name>];
    ALTER ROLE db_ddladmin ADD MEMBER [<identity-name>];
    GO
    ```

6.  To get the Access Token for Azure AD Identity, install NuGet package - `Microsoft.Azure.Services.AppAuthentication`

7.  Create a class like the below:
    ```cs
    public class AzureSqlAuthTokenService
    {
        public string GetToken(string connectionString)
        {
            AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
            var token = provider.GetAccessTokenAsync("https://database.windows.net/").Result;
            return token;
        }
    }
    ```

8.  Finally write the ADO.NET Code and set the AccessToken property.

    ```cs
    using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("SQLConnectionString")))
    {
        string connectionStringForToken_Local = "RunAs=Developer; DeveloperTool=VisualStudio";
        string connectionStringForToken_Azure = "RunAs=App";

        con.AccessToken = new AzureSqlAuthTokenService().GetToken(connectionStringForToken_Local);

        SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", con);
        cmd.CommandType = CommandType.Text;
        con.Open();
        SqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            customer.Add(rdr["CustomerName"].ToString());
        }
        con.Close();
    }
    ```

## References
*   [EF Core Connection to Azure SQL with Managed Identity](https://stackoverflow.com/questions/54187241/ef-core-connection-to-azure-sql-with-managed-identity)
*   [Connection String Support](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/service-to-service-authentication)


                
