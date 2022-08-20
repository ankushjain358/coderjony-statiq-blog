Title: Authentication with Google Account using OpenID Connect
Published: 26/01/2021
Author: Ankush Jain
IsActive: true
ImageFolder: authentication-with-google-account-using-openid-connect
Tags:
  - OAuth
---
In this post, we will understand, how can we implement **Login with Google Account** functionality in our web application. We will be doing this authentication using the **Open Id Connect** protocol.

### Step 1
First, you have to register an application on Google to get a **Client Id** and **Client Secret**. Check out this blog post [Register a Client application in Google](https://coderjony.com/blogs/register-a-client-application-in-google-to-access-google-apis-via-oauth-20/) where I have explained this process step by step. 

### Step 2
Open the Google discovery document in a new tab from the below link.

**Google Discovery Endpoint** - [https://accounts.google.com/.well-known/openid-configuration](https://accounts.google.com/.well-known/openid-configuration)

> A Discovery Document has all the necessary values defined in the OpenID Connect protocol. This also helps clients to configure OpenID implementation on their side.
> 
>  If you are not familiar with Discovery Document, refer to this - [OpenID Connect Discovery Document](https://janrain-education-center.knowledgeowl.com/home/the-hosted-login-discovery-document),

### Step 3
Copy the **authorization_endpoint** from the discovery document, and consider it as a base URI.

Base Address - **https://accounts.google.com/o/oauth2/v2/auth**

Add below required query parameters in this base URI:

*   **client_id**- You obtain this from the app you registered in step 1.
*   **response_type** - Keep its value `code`, as we are using **Authorization Code Flow**. [Click here to see all grant types or authorization flow](https://auth0.com/docs/applications/application-grant-types#spec-conforming-grants).
*   **scope** - The scope parameter must begin with `openid`, then add `email` or `profile` or both. i.e. `openid email profile`.
*   **redirect_uri** - The value for this must be the same as you mentioned while registering it in step 1.


For all available parameters, refer to this [Authentication URI parameters](https://developers.google.com/identity/protocols/oauth2/openid-connect#authenticationuriparameters)

So, finally, the constructed URL becomes like this:

```http
https://accounts.google.com/o/oauth2/v2/auth?
client_id=153956101972-pnukt83olcgcm1alq96mjfsvhto2vpiv.apps.googleusercontent.com
&response_type=code
&scope=openid email profile
&redirect_uri=http://localhost
```

### Step 4
Copy the above URL and paste it into the browser. You will see a **Google Login** screen like this. Select an account and do the login. 

![Authentication with Google Account using OpenID Connect](/img/blogs/authentication-with-google-account-using-openid-connect/1-authentication-with-google-account-using-openid-connect.png)

### Step 5
After login, you will be redirected to the **redirect_uri** that you mentioned in the above URL. Notice, that here we have received a **code** in the query parameter. 

New URL - **http://localhost/?code=4%2F0AY0e-g57VagfLYSg54NGBQbMKzSr-mknlsiMA7G1VqYm0Ns3eTvdxKfaYXY-UPJEkzSCgQ**

This is because we have used `response_type` as `code`. 

![Authentication with Google Account using OpenID Connect](/img/blogs/authentication-with-google-account-using-openid-connect/2-authentication-with-google-account-using-openid-connect.png)

### Step 6
Now the time is to get the **ID Token** and **Access Token** from this `code`. So, we construct one more URL to exchange this `code` with `id_token` and `access_token`.

Copy the **token_endpoint** from the above [discovery document](https://accounts.google.com/.well-known/openid-configuration) and consider it as the base URI. 

Base Address - **https://oauth2.googleapis.com/token**

Add below required query parameters in this base URI:

*   **code**: The authorization code that we received in the previous step.
*   **client_id**: Copy Client Id from the app you registered in step 1.
*   **client_secret**: Copy Client Secret also from the app you registered in step 1.
*   **redirect_uri**: This should be the same as we mentioned in the client app that we registered in step 1.
*   **grant_type**: Use `authorization_code` here, as we are using authorization code flow.

So finally, the constructed URL becomes like this

```http
https://oauth2.googleapis.com/token?
code=4%2F0AY0e-g57VagfLYSg54NGBQbMKzSr-mknlsiMA7G1VqYm0Ns3eTvdxKfaYXY-UPJEkzSCgQ
&client_id=153956101972-pnukt83olcgcm1alq96mjfsvhto2vpiv.apps.googleusercontent.com
&client_secret=p0gKOTz39HoiCA1Rj72zHnrk
&redirect_uri=http://localhost
&grant_type=authorization_code
```

Now, we use Postman to make a POST request on this URL. So, as you can see, we have received both **Access Token** and **ID Token** in the response. 

![Authentication with Google Account using OpenID Connect](/img/blogs/authentication-with-google-account-using-openid-connect/3-authentication-with-google-account-using-openid-connect.png)

### Step 7
Copy `id_token` and paste it on [jwt.io](https://jwt.io/) to decode it. You can see that we have got the following claims in ID Token. 
*   email
*   name
*   picture
*   given_name
*   family_name

JWT is made of 3 things - `{Header}.{Payload}.{Signature}`. You can simply decode the base64 encoded payload in any language. For example, in JavaScript, you can use `window.atob('encoded-payload')`.

![Authentication with Google Account using OpenID Connect](/img/blogs/authentication-with-google-account-using-openid-connect/4-authentication-with-google-account-using-openid-connect.png)

### Step 8
The final step is **validating an ID token**. Though we have received it directly from Google, still it is a good practice to validate the ID Token before we consider it genuine. Below are certain things that we must verify while validating an ID Token.

*   Signature verification - Verify that ID Token (JWT) is properly signed by the issuer. Google uses its private key to generate the signature in the JWT token. But we can verify it as Public Keys/Certificates can be found in the URL specified in the `jwks_uri` key of the [Discovery document](https://accounts.google.com/.well-known/openid-configuration).
*   Verify that `iss` (issuer) claim in ID token is either **https://accounts.google.com** or **accounts.google.com**
*   Verify that `aud`(audience) claim value is the same as the **Client Id** of your app.
*   Verify that the `exp` claim has the value of expiry time that has not passed, and the token is still active.

## Conclusion
In this post, we understood how we could get the user's identity in form of an ID Token. We have not used any third-party library or wrapper in this implementation to better understand how Open ID authentication actually works. After successful authentication, we obtain the user's email id in the claims and can use it to create a new user or login into the user automatically if exist already. 

## References
*   [OpenID Connect | Google Identity | Google Developers](https://developers.google.com/identity/protocols/oauth2/openid-connect)


                
