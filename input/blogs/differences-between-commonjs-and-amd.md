Title: Differences between CommonJS and AMD?
Published: 23/06/2017
Author: Ankush Jain
IsActive: true
Tags:
  - JavaScript
---
In this article, I am going to talk about these two terms - CommonJS and AMD. 

> Before two days, I was not even aware about these two technologies. When I heard about these, I googled and studied. In this article, I am going to share my understandings and hope that this will be quite beneficial for beginners.

Whenever we are planning to build a large scale application then we must be concerned about modular approach. Modular approach means, each part of software should be a module, and each module should be an independent piece of code. By doing this, we make a robust, scalable and maintainable code base, that is very much required in large scale applications.

## What is modular JavaScript?
In JavaScript, a module is an independent unit of code. If we want to use a module in different module, then we just need to import that module. Syntax of importing a module is usually different in different Module Definition Specifications (CommonJS, AMD etc).

## What is CommonJS and AMD?
CommonJS and AMD - Both are Module Definition Specifications or in easy words - these are the ways of writing a Module in JavaScript.

## Defining a module in CommonJS
```js
// hotelsModule.js
exports.getHotelsbyCityId = function(cityId){
  return []; // return a list of hotels
}

// mainModule.js
var hotelsModule = require("hotelsModule");
exports.getHotelsInMumbai = function(){
  var mumbaiCityId = 56;
  return hotelsModule.getHotelsbyCityId(mumbaiCityId);
}
```
In CommonJS, we use **exports** object to create exportable/public properties or methods.

## Defining a module in AMD
```
define('moduleOne',['otherDepenedentModule'], function(otherDependentModule){
    return {
        func1: function(){ return "Ankush Jain in func1"; },
        func2: function(){ return "Ankush Jain in func2"; };
    };
})

require('module2',['moduleOne','jQuery'],function(m1,$){  
    $("body").html(m1.func1());
});
```

In AMD, we return any object which we want to make publicly available.

## Differences
1.  CommonJS loads modules synchronously while AMD loads modules asynchronously.
2.  CommonJS is mostly used at server level while AMD is mostly used at browser level.
3.  NodeJS is the best implementation of CommonJS pattern, all node-modules follow CommonJS pattern while [RequireJS](http://requirejs.org/docs/whyamd.html#purposes) is the best implementation of AMD pattern.


                