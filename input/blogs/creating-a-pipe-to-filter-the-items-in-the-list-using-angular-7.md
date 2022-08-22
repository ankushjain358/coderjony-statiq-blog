Title: Creating a Pipe to filter the items in the list using Angular 7
Published: 27/07/2019
Author: Ankush Jain
IsActive: true
ImageFolder: creating-a-pipe-to-filter-the-items-in-the-list-using-angular-7
Tags:
  - Angular
---
Having a search box & filtering out the list based on the text of that search box is a common development task in almost every software application.

In this post, we will understand how can we achieve the same functionality in Angular 7 using Pipe.

## What is Pipe?
Pipes are a useful feature in Angular. They are a way to transform one value into another inside an Angular template. There are some built-in pipes, but we can also create our own custom pipes. You can more read about pipes on Angular's website - [https://angular.io/guide/pipes](https://angular.io/guide/pipes).

## Creating a Pipe to filter the items in the list using Angular 7
In this post, I am using a list of complex objects for filtering purposes, instead of having a simple list of strings. In our case, the component will somehow look like the below.

```ts
// search text property
searchText: string;

// list of categories
categories: any[] = [
{id: 1, categoryName:"Schools"},
{id: 2, categoryName:"Colleges"},
{id: 3, categoryName:"Doctors"},
{id: 4, categoryName:"Hospitals"},
{id: 5, categoryName:"Advocates"}
]
```

Now we want to filter this list based on the category name. To do this, we did two things.
- First, we created a textbox & bound it with `searchText` which is a string property of the component.
- Secondly, we created another property of type array that holds the above categories. We call that property as `categories`. Now, our template markup will look like this.

```html
<!-- Search box -->
<input type="text" [(ngModel)]="searchText" placeholder="Search Category" />

<!-- List of categories -->
<ul>
  <li *ngFor="let item of categories | filter : searchText : 'categoryName'">
	{{item.categoryName}}
  </li>
</li>
```

## filter.pipe.ts (Definition for Filter pipe)

```ts
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(items: any[], searchText: string, fieldName: string): any[] {

    // return empty array if array is falsy
    if (!items) { return []; }

    // return the original array if search text is empty
    if (!searchText) { return items; }

    // convert the searchText to lower case
    searchText = searchText.toLowerCase();

    // retrun the filtered array
    return items.filter(item => {
      if (item && item[fieldName]) {
        return item[fieldName].toLowerCase().includes(searchText);
      }
      return false;
    });
   }
}
```  

Also, don't forget to register this filter pipe in `app.module.ts` file inside `declarations` array.

                
