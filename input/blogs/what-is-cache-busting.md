Title: What is Cache Busting?
Published: 25/10/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Whenever you access any website from the browser, all the static resources such as JS, CSS & images are cached by the browser. So, whenever you open the next page on that website, the browser will fetch those resources from the cache. This cache could be either **disc cache** or **memory cache**.

It is also important to know that the browser will only cache the static resources whenever it is told to do so. So, in order to explicitly tell the browser that it needs to cache a particular resource, the server sends `Cache-Control` header in the response. Whenever this header is received, browser cache the response except when it's value is `no-cache`. 

## Understand the requirement of Cache Busting

Now let's understand why we need Cache Busting. Suppose, you have deployed your web-application on a web-server. Your app is up & running. Now, your development team has done some new development & it is obvious that they have made some changes in existing JS & CSS files. So, if you deploy your web-application again & one of your users access your website again. As the user had already accessed your website, so the JS & CSS files are already cached by his or her browser. So, now even if you updated or deployed the latest code, but the user accessing your website won't be able to see the latest changes. And this is the moment when you require Cache Busting.

## What is Cache Busting?

**Cache Busting** is the process of appending some query parameter in the URLs of static resources such as JS, CSS or image file. Once we add a query parameter with newer value, the URL will get different from its previous version, hence browser won't find it's response in its cache & user will get the latest updated file from the server. 

**Example:** You initially deployed the application with version 1001. Your scripts & styles will look like below:

```
    <link href="http://coderjony.com/styles/external-styles?v=1001" rel="stylesheet"/>
    <script src="http://coderjony.com/scripts/shared-scripts?v=1001"></script>
    ```

Now, you want to deploy the second version, then your script & styles should look like below:

```
    <link href="http://coderjony.com/styles/external-styles?v=1002" rel="stylesheet"/>
    <script src="http://coderjony.com/scripts/shared-scripts?v=1002"></script>
    ```

 Below picture will show you how Cache Busting actually works.

![Cache Busting](/img/blogs/what-is-cache-busting/what-is-cache-busting.png)

                