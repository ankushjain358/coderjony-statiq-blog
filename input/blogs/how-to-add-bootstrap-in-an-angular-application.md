Title: How to add bootstrap in an Angular application?
Published: 20/04/2019
Author: Ankush Jain
IsActive: true
Tags:
  - Angular
  - Bootstrap
---
Adding the Bootstrap library to an Angular application is quite easy. Bootstrap Library consists of both CSS & JS files. 

*   **Bootstrap CSS** files are used for design/UI purposes.
*   **Bootstrap JavaScript** files are used in some of its components such as Accordion, Tooltip, Modal Popup, Tabs, etc.

Now, let's understand - How can we add the bootstrap library to the Angular application?

## Step 1: Install Bootstrap
First, open angular CLI & hit the below command. 
```bash
npm install bootstrap --save
```
This will install bootstrap node module in your application inside `node_modules` folder. 

## Step 2: Adding Bootstrap Styles 
There are two ways to add bootstrap CSS to the application.

### Method 1 
Open `angular.json` file & add bootstrap CSS file reference in styles array.
```json
"styles": [
              "./node_modules/bootstrap/dist/css/bootstrap.min.css"
            ]
```

### Method 2
Open `styles.css` file which is present in the `src` folder & add an `import` statement like the below.

```bash
@import "~bootstrap/dist/css/bootstrap.min.css";
```

## Step 3: Adding Bootstrap JavaScript
Bootstrap JavaScript components depend upon two other JavaScript libraries - `jQuery` & `popper.js`. So first, we have to install these two dependencies from `npm`.

```bash
npm install jquery --save
npm install popper.js --save
```

After this, open `angular.json` file & update the scripts section like below:

```js
"scripts": [
                "./node_modules/jquery/dist/jquery.min.js",
                "./node_modules/popper.js/dist/umd/popper.min.js",
                "./node_modules/bootstrap/dist/js/bootstrap.min.js"
            ]
```

## Step 4: Accessing Bootstrap JavaScript Library in Angular
So far, we have added the bootstrap JavaScript library to the application. But we might need to call some methods of this library such as `modal('show')` to show the modal popup, `tab('show')` to activate a tab. 

To access these methods of bootstrap library & get proper IntelliSense support in Visual Studio Code IDE, we should install `types` for `jQuery` & `Bootstrap` libraries.

```bash
npm install @types/jquery --save
npm install @types/bootstrap --save
```

**tsconfig.json** - Look into this file for **types** array and add **jquery** and **bootstrap** entries.

```js
"types": [
        "jquery",
        "bootstrap",  
        "node"
]
```

That's all :)

                