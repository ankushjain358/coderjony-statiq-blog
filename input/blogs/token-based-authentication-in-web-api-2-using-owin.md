Title: Token Based Authentication in Web API 2 using OWIN
Published: 25/12/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
In this post, we will learn how to secure Web APIs by implementing Token Based Authentication & Authorization in them. You can refer [this post](http://coderjony.com/blogs/understand-authentication-and-authorization-in-brief/) to understand what is Authentication & Authorization in web applications.

## Authentication Methods in Web API

Basically, there are two most common methods for Authentication in Rest Based services.

1.  Basic Authentication

2.  Token Based Authentication (OAuth 2)



You can refer [this link](https://www.c-sharpcorner.com/blogs/basic-authentication-in-webapi) to understand the Basic Authentication. In this post, we will only concentrate on implementing Token Based Authentication in Web API.

Note that there are several ways to implement token-based authentication. Currently, I am aware of two types of tokens.

*   JWT Token

*   OWIN Based Token



In this post, we will learn about the implementation of OWIN Based tokens. So let's begin the game.

## Implementing Token Based Authentication in Web API 2 using OWIN

**Step 1:** Create a new web application project in Visual Studio. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/1-token-based-authentication-in-web-api-2-using-owin.png)

**Step 2:** Select Web API project template. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/2-token-based-authentication-in-web-api-2-using-owin.png)

**Step 3:** Install this Nuget package - `Microsoft.Owin.Security.OAuth`. This package is a Middleware that enables the application to support OAuth 2.0 authentication workflow. This package is responsible for generating auth token, validating the token in ASP.NET pipeline & setting up User's identity. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/3-token-based-authentication-in-web-api-2-using-owin.png)

**Step 4:** Now, create an OWIN Startup class. In this class, we will write the code to register the OWIN middleware. Name it `StartUp.cs`. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/4-token-based-authentication-in-web-api-2-using-owin.png)

**Step 5:** `Startup` class will look like this initially. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/5-token-based-authentication-in-web-api-2-using-owin.png)

**Step 6:** Now copy below code in `StartUp.cs` file to configure OAuth (Token Based Authentication) using OWIN Middleware. Here we registering OWIN OAuth Middleware in the application so that it can be the part of the request pipeline.

    ```
    public void Configuration(IAppBuilder app)
            {
                ConfigureOAuth(app);
            }

            public void ConfigureOAuth(IAppBuilder app)
            {
                OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    Provider = new CustomAuthorizationServerProvider()
                };

                // Token Generation
                app.UseOAuthAuthorizationServer(OAuthServerOptions);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            }
    ```

After, copying above code, your file will look like this.

![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/6-token-based-authentication-in-web-api-2-using-owin.png)

**Step 7:** Now implement `CustomAuthorizationServerProvider` class. This is the class in which, we will be validating user's username & password. This is purely a custom class. We can write a custom logic here to validate a user's credentials. We are not using ASP.NET Identity here.

    ```
    public class CustomAuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
            }

            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {

                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                AuthRepository authRepository = new AuthRepository();
                bool isValid = authRepository.ValidateUser(context.UserName, context.Password);

                if (!isValid)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

                context.Validated(identity);
            }
        }
    ```

The file will look like this. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/7-token-based-authentication-in-web-api-2-using-owin.png)

**Step 8:** This is a demo class I have used in this example. Here, you will be validating the user's credentials from your application's database. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/8-token-based-authentication-in-web-api-2-using-owin.png)

**Step 9:** Now add this Nuget package. If you don't add this, then your `StartUp.cs` file won't be executed. So just install the Nuget package - `Microsoft.Owin.Host.SystemWeb`. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/9-token-based-authentication-in-web-api-2-using-owin-startup-class-not-called.png)

**Step 10:** Build the application to ensure there is no compilation error. Once build is successful, press F5 to launch the application. You will see the application like below in your web browser. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/10-token-based-authentication-in-web-api-2-using-owin.png)

**Step 11:** Now, it's time to generate the Access Token. Open postman & fill the information like below image. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/11-token-based-authentication-in-web-api-2-using-owin.png)

**Step 12:** Also, make sure to set `Content-Type` to `application/json`. This is because, we explicitly tell the browser to send the response in JSON format. 

**Note**: This may not be the necessary step, but I just did it. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/12-token-based-authentication-in-web-api-2-using-owin.png)

**Step 13:** Once you hit execute button in postman, you will see that your breakpoint in `GrantResourceOwnerCredentials` will get hit. In this method, you will verify the user, set his claims. OWIN will take care of the information which you have shared with him. And it will then generate the token from all this information when `context.Validated(identity);` will be called. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/13-token-based-authentication-in-web-api-2-using-owin.png)

**Step 14:** Now just look at the response in postman. You will see that we have received the access token in the response. ![enter image description here](/img/blogs/token-based-authentication-in-web-api-2-using-owin/14-token-based-authentication-in-web-api-2-using-owin.png)

> You can access the whole source code from GitHub -[https://github.com/ankushjain358/TokenBasedAuthenticationUsingOWIN](https://github.com/ankushjain358/TokenBasedAuthenticationUsingOWIN).

**Related Important Links:**

*   [Difference between Basic Authentication & OAuth (Token Based
   Authentication)](https://stackoverflow.com/a/34930402/1273882)


                