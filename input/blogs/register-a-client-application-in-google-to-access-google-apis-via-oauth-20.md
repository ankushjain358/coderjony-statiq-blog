Title: Register a Client application in Google to access Google APIs via OAuth 2.0
Published: 26/01/2021
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Any application that wants to use Google API, must have to register a Client application in Google to get a **Client Id** and **Client Secret**. That application will further use this **Client Id** and **Client Secret** to get an Access Token from Google to access its APIs.

In this post, we will understand how to register an application in Google and generate ClientId and Client Secret.

**Step1:** Go to [Google Developer Console - Credential Page](https://console.developers.google.com/apis/credentials), select an existing project, or create a new one. 

**Step 2:** Follow the below steps:

*   Select project (i.e. *Login with Google Demo*)

*   Create credentials 

*   OAuth client ID
![Register a Client application in Google to access Google APIs via OAuth 2.0](/img/blogs/register-a-client-application-in-google-to-access-google-apis-via-oauth-20/1-registering-an-oauth-client-application-with-authorization-credentials-in-google.png)



**Step 3:** Note: Before you create a client ID, you have to configure a consent screen. Click **Configure Consent Screen** button. ![Register a Client application in Google to access Google APIs via OAuth 2.0](/img/blogs/register-a-client-application-in-google-to-access-google-apis-via-oauth-20/2-registering-an-oauth-client-application-with-authorization-credentials-in-google.png)

**Step 4:** Fill basic information in wizard step 1 - **OAuth consent screen**. ![Register a Client application in Google to access Google APIs via OAuth 2.0](/img/blogs/register-a-client-application-in-google-to-access-google-apis-via-oauth-20/3-registering-an-oauth-client-application-with-authorization-credentials-in-google.png)

**Step 5:** Select all basic scopes - `openid`, `email` & `profile`. ![Register a Client application in Google to access Google APIs via OAuth 2.0](/img/blogs/register-a-client-application-in-google-to-access-google-apis-via-oauth-20/4-registering-an-oauth-client-application-with-authorization-credentials-in-google.png)

**Step 6:** For testing, put your email id here. You can add multiple test users here. ![Register a Client application in Google to access Google APIs via OAuth 2.0](/img/blogs/register-a-client-application-in-google-to-access-google-apis-via-oauth-20/6-registering-an-oauth-client-application-with-authorization-credentials-in-google.png)

**Step 7:** Finally, go to the **Credentials** tab again. Select **Application Type > Web application** and enter a name for the application. ![Register a Client application in Google to access Google APIs via OAuth 2.0](/img/blogs/register-a-client-application-in-google-to-access-google-apis-via-oauth-20/7-registering-an-oauth-client-application-with-authorization-credentials-in-google.png)

**Step 8:** Enter the URL of your application where you want Google to redirect post authentication. ![Register a Client application in Google to access Google APIs via OAuth 2.0](/img/blogs/register-a-client-application-in-google-to-access-google-apis-via-oauth-20/8-registering-an-oauth-client-application-with-authorization-credentials-in-google.png)

**Step 9:** Hit **Create** button. Once the application is created, you will get a popup like below. Copy **Client Id** and **Client Secret**, and store them somewhere. ![Register a Client application in Google to access Google APIs via OAuth 2.0](/img/blogs/register-a-client-application-in-google-to-access-google-apis-via-oauth-20/9-registering-an-oauth-client-application-with-authorization-credentials-in-google.png)

That's all, this is how we successfully registered a client application in Google to access its APIs via OAuth 2.0.

                