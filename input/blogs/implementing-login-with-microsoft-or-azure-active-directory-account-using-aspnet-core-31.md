Title: Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1
Published: 24/10/2020
Author: Ankush Jain
IsActive: true
Tags:
  - OAuth
  - Authentication
---
In this post, we will understand how can we enable the user to log in with their work, school, or personal Microsoft account or Azure Active Directory account using ASP.NET Core.
*   We will be using **Visual Studio 2019** for this demo along with **ASP.NET Core 3.1**. 
*   Source Code for this demo - [ankushjain358/Login-with-Microsoft-ASP.NET-Core-3.1](https://github.com/ankushjain358/Login-with-Microsoft-ASP.NET-Core-3.1)

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

## Step by Step implementation

**Step 1:** Create a new ASP.NET Core web application project in Visual Studio 2019. 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/1-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 2:** Select ASP.NET Core 3.1 MVC application from the available templates as shown below. 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/2-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 3:** Install `Microsoft.AspNetCore.Authentication.MicrosoftAccount` NuGet package. 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/3-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 4:** Open `Startup.cs` file and copy below code in `ConfigureServices()` method.

>   Here, we have used 2 authentication schemes for implementing login with Microsoft functionality, you can go with either.
>   - **Scheme 1:** Generic Authentiction Scheme using `AddOAuth()` method.
>   - **Scheme 2:** Microsoft Authentiction Scheme using `AddMicrosoftAccount()` method.

**Cookie Authentication Scheme** is our default authentication scheme, that is configured to redirect the user to the `/Account/Login` page once the request is found as unauthenticated.

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/4-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

Copy the above image's code from here:
```cs
public void ConfigureServices(IServiceCollection services)
{
	services.AddControllersWithViews();

	services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
		.AddCookie(item => item.LoginPath = new PathString("/account/login"))

		// You must first create an app with Microsoft Account and add its ID and Secret to your user-secrets.
		// https://azure.microsoft.com/en-us/documentation/articles/active-directory-v2-app-registration/

		// Way 1
		.AddOAuth("Microsoft-AccessToken", "Microsoft AccessToken only", option =>
		{
			option.ClientId = Configuration["Authentication:Microsoft:clientid"];
			option.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
			option.CallbackPath = new PathString("/signin-microsoft-token");
			option.AuthorizationEndpoint = MicrosoftAccountDefaults.AuthorizationEndpoint;
			option.TokenEndpoint = MicrosoftAccountDefaults.TokenEndpoint;
			option.Scope.Add("https://graph.microsoft.com/user.read");
			option.SaveTokens = true;
			option.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
			option.ClaimActions.MapJsonKey(ClaimTypes.Name, "displayName");
			option.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "givenName");
			option.ClaimActions.MapJsonKey(ClaimTypes.Surname, "surname");
			option.ClaimActions.MapCustomJson(ClaimTypes.Email, 
				user => user.GetString("mail") ?? user.GetString("userPrincipalName"));
		})

		// Way 2
		.AddMicrosoftAccount(option =>
		{
			option.ClientId = Configuration["Authentication:Microsoft:clientid"];
			option.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
			option.SaveTokens = true;
		});
}   
```

 **Step 5:** Go to `Configure()` method in the same `Statup.cs` file, and add `app.UseAuthentication()` as shown below. This enables the authentication in the request pipeline. 
 
 ![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/5-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 6:** Now go to the Azure portal and register an application. Refer to this post to learn [how to create an app in Azure AD](https://docs.microsoft.com/en-us/azure/active-directory/develop/howto-create-service-principal-portal#register-an-application-with-azure-ad-and-create-a-service-principal). 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/6-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

### Important:
- **Generic Authentication Scheme** - If you are using the using `AddOAuth()` method, then for **Redirect URI**, use the `CallbackPath` value that you defined above. As we have used `/signin-microsoft-token` as `CallbackPath` so the URL should be like `https://localhost:44339/signin-microsoft-token`.
- **Microsoft Authentication Scheme** - If you are using the using `AddMicrosoftAccount()` method, then we must use`/signin-microsoft` in **Redirect URI**, so the URL should be like `https://localhost:44339/signin-microsoft`. The Microsoft auth flow is configured to handle the request to this URL `/signin-microsoft`. 

See, we have added both URLs here, so that code could work with both the schemes. 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/13-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)  


**Step 7:** Copy the **Application Id**, we will use it as **Client Id** in our code. 
 
![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/7-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 8:** Go to **Certificates & secrets** blade, generate a secret, and copy it as well. We will be using it as **Client Secret** in our code. 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/8-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 9:** Go to the `appsettings.json` file and add the **Authentication** block as shown below. 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/9-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

Copy the above image's code from here:

```json
"Authentication": {
    "Microsoft": {
        "ClientId": "04d7034f-ef3d-4216-8209-6259f8255948",
        "ClientSecret": "-o8Fi9.Or6qfqxzzo.6s4WPJ3gv3og2.A1"
    }
}
```

 **Step 10:** Add **Authorize** attribute on **Home Controller** to allow secure access only. 
 
 ![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/10-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 11:** Now, we create an **Account Controller** and create 3 actions over there.
*   **Login** - This method returns the Login view.
*   **LoginWithMicrosoft** - This method invokes the configured authentication scheme and redirects the user to the Microsft login page.
*   **Logout** - This method clears the authentication cookie and signs out the user.

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/11-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)


**Step 12** - Comment out the code for the scheme that you don't wish to continue. We have written code for both the schemes for this demo. In the real-world scenario, you won't be using 2 schemes for the same third-party login. 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/12-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 13:** Here is the Razor view for the login page. 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/14-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 14:** On Layout, we have used `User.Identity.IsAuthenticated` property to check if the user is logged in or not and accordingly showing buttons for Login and Logout. 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/15-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 15:** Run the application, this will redirect you to `/Account/Login` page. There you will see a button to log in. 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/16-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 16:** Clicking on the above button/link will take you to the **LoginWithMicrosoft** action of the **Account** Controller, and that further will redirect you to the Microsoft login page. There, you will be shown a consent page like below. 

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/17-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

**Step 17** After the consent is granted, you will be again taken to your application, where all the information will present in the `User.Identity` property. 

> #### Behind the scenes
> Behind the scenes, after successful authentication, Microsoft redirects the user to the Redirect URI that we mentioned in the app. NuGet package used above internally intercepts the request for that URI, retrieves the **code** from there, and gets an **access token** by calling MS Graph API. Once the access token is received, another graph API is invoked to get the user's basic profile information. All this user information is then deserialized and set into the `User.Identity` property.

You can get the user's email id from the `User.` `Identity` property and check if the user is present in the database or not, and create a new one if it is not there.

![Implementing Login with Microsoft or Azure Active Directory Account using ASP.NET Core 3.1](/img/blogs/implementing-login-with-microsoft-or-azure-active-directory-account-using-aspnet-core-31/18-implementing-login-with-microsoft-or-azure-active-directory-using-aspnet-core-31.png)

## That's all
This way, we can enable users to login with their **Microsoft** or **Azure Active Directory** account into our application. 

Code for the demo is available at GitHub - [ankushjain358/Login-with-Microsoft-ASP.NET-Core-3.1](https://github.com/ankushjain358/Login-with-Microsoft-ASP.NET-Core-3.1)

Happy Coding 😍

                