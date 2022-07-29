Title: Multiple ways to access Key Vault from .NET Core Web Application
Published: 13/12/2020
Author: Ankush Jain
IsActive: true
Tags:
  - Azure
  - Security
  - Key Vault
---
There could be multiple ways to access the keys from Key Vault in a .NET Core application, but you could choose from the 2 explained below.

## 1. Accessing Key Vault Secret using C# SDK
To access key vault secrets using C# SDK, you will have to install the below NuGet packages:
*   Azure.Identity
*   Azure.Security.KeyVault.Secrets

Now, there is some code that you have to write to initialize the Key Vault SDK object. But the main thing here is how your app will be considered as an authenticated app that could use or access Azure Key Vault.

Here comes, **DefaultAzureCredential** object. This is the main object, that helps your .NET Core application to get an Azure Identity (could be either Service Principal, Managed Identity, or a User Identity). And this identity is further used to check whether it has permission to access Key Vault or not.

So, now there are again 3 ways you can go ahead with:
*   Managed Identity 
*   Service Principal (Azure AD App Registration) 
*   Visual Studio (SharedTokenCacheCredential)

### Managed Identity
For azure hosted apps, I would recommend going with Managed Identity as you don't have to manage any client id and secrets in your application. DefaultAzureCredential will automatically pick the Managed Identity from Azure App Service or Function App.

### Service Principal
For azure hosted & local development, we can create a Service Principal, and keep the following variables in the environment variable. One way to put keys in Environment Variable is to put them in localsettings.json.
*   AZURE_TENANT_ID
*   AZURE_CLIENT_ID
*   AZURE_CLIENT_SECRET

### Visual Studio (SharedTokenCacheCredential)
For local development only, as Managed Identity does not work locally. So, another way to access Key Vault from the development environment is to go to **Visual Studio > Tools > Options > Azure Service Authentication**. Log in with a user from your Azure AD account. **DefaultAzureCredential** will pick this value if it fails to get identity from Environment Variable and Managed Identity.

**DefaultAzureCredential** looks in the below order to get the Azure Credentials.
*   EnvironmentCredential
*   ManagedIdentityCredential
*   SharedTokenCacheCredential
*   VisualStudioCredential


## 2. Accessing Key Vault Secret using App Configuration

## References:
*   [Tutorial: Use a managed identity to connect Key Vault to an Azure web app in .NET](https://docs.microsoft.com/en-us/azure/key-vault/general/tutorial-net-create-vault-azure-web-app)
*   [App Authentication client library for .NET - Version 1.6.0 (To get Access Token using AzureServiceTokenProvider)](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/service-to-service-authentication)
*   [DefaultAzureCredential](https://docs.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet)
*   [Local Setup](https://www.rahulpnath.com/blog/azure-managed-service-identity-and-local-development/)