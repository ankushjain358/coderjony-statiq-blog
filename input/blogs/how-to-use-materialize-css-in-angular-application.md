Title: How to use Materialize CSS in Angular application
Published: 01/02/2019
Author: Ankush Jain
IsActive: true
ImageFolder: how-to-use-materialize-css-in-angular-application
Tags:
  - Angular
---
To install [Materialize](https://materializecss.com/) in your angular app. You just need to follow 2 steps.

![Materialize CSS in Angular](/img/blogs/how-to-use-materialize-css-in-angular-application/materialize.png)

1.  Install the `materialize-css` node package in your application. 
    ```bash
    npm install materialize-css --save
    ```
    This will install [Materialize CSS](https://materializecss.com/). 

2. Open `angular.json` file & add below styles & scripts.
    ```js
    "styles": [
              "./node_modules/materialize-css/dist/css/materialize.css",
            ],
    "scripts": [
              "./node_modules/materialize-css/dist/js/materialize.js"
            ]
    ```  

3.  You are done. Now re-run your application.


                
