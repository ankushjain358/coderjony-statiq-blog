Title: Upgrading existing Ionic 4.x app to Ionic 5.x
Published: 16/02/2020
Author: Ankush Jain
IsActive: true
ImageFolder: upgrading-existing-ionic-4x-app-to-ionic-5x
Tags:
  - Ionic Framework
---
Ionic community recently released its latest version **Ionic 5** in the market. Today, in this article we will understand how can we upgrade an existing **Ionic 4** application to **Ionic 5**.

![Upgrading existing Ionic 4.x app to Ionic 5.x](/img/blogs/upgrading-existing-ionic-4x-app-to-ionic-5x/migrate-ionic-4-to-ionic-5.png)

We will run this migration in 5 easy steps.
1.  Install Ionic 5 CLI globally
2.  Updating the app to Ionic 4 last release (Version 4.11.10)
3.  Upgrade to Ionic 5
4.  Upgrade Angular Version (Upgrade to Angular 9)
5.  Run and Test the upgraded Ionic app


## Step 1: Install Ionic 5 CLI globally
First of all, install Ionic 5 CLI globally. Run below command.
```bash
npm install -g ionic@latest
```

Once you update the CLI to the latest version, you can verify it by running the below command.
```bash
ionic --version
```

## Step 2 - Updating the app to Ionic 4 last release (Version 4.11.10)
> As Ionic recommends that before you jump to directly upgrade your app to Ionic 5, you should first bring your app to the latest Ionic 4 release (4.11.10). And then you should run the application to see any deprecation warnings in the developer console. You should fix those warnings and then move forward to update the app to Ionic 5.

Run the below command to update the Ionic 4 app to version 4.11.10.

```bash
npm install @ionic/angular@4.11.10 --save
```

Run the below command to verify that the app has been upgraded to 4.11.10 version.
```bash
ionic info
```

Before you move forward, please run and test the application by running it via `ionic serve` and ensure that the app has been successfully upgraded to `4.11.10` version and there is no deprecation warning in the developer console.

## Step 3: Upgrade to Ionic 5
Update `@ionic/angular` and `@ionic/angular-toolkit` packages to the latest releases by running below command.
```bash
npm install @ionic/angular@latest @ionic/angular-toolkit@latest --save
```

Again verify the versions by running the below command.
```bash
ionic info
```

## Step 4: Upgrade Angular Version (Upgrade to Angular 9)
So far, we have updated `@ionic/angular` and `@ionic/angular-toolkit` packages only, but still, we have not updated the angular and its dependencies that are used by the Ionic app.

As **Ionic 5** supports **Angular 9**, so we should update the angular libraries used in the Ionic App to the latest version of Angular (That is Angular 9 as of now).

For this, I would recommend going through Angular's website, where they clearly explain how to migrate from one version to another. Here is the link to their website - [https://update.angular.io](https://update.angular.io/).

> **Note**: Use `ionic info` command to check the current Angular version of the Ionic app.

## Step 5: Run and Test the upgraded Ionic app
Run the below command to launch the upgraded Ionic 5 app in the browsers.

```bash
ionic serve
```

Go through all the screens and test the upgraded application.

## Conclusion
This is how we can migrate an Ionic 4 application to the latest Ionic 5 application in 5 easy steps. Please let me know your feedback, and suggestions in below comment box. 

Reference - [https://ionicframework.com/docs/building/migration](https://ionicframework.com/docs/building/migration)

                
