Title: Capitalize the first letter of input textbox using Directive in Angular 6
Published: 27/06/2019
Author: Ankush Jain
IsActive: true
Tags:
  - Angular
---
To capitalize the first letter of the input textbox, we can create a custom directive in the Angular application. 

## **Attribute Directive vs Structural Directive** :
The directive which we are going to create is an **Attribute Directive** because we are manipulating only the behavior of the DOM element. There is one more type of directive which manipulates the DOM (add or remove DOM elements) known as a **Structural Directive**.

In this example, I have created a custom directive `TitleCaseDirective`.

## TitleCaseDirective.ts (Attribute Directive)

```ts
import { Directive, ElementRef, HostListener  } from '@angular/core';

@Directive({
  selector: '[appTitleCase]'
})
export class TitleCaseDirective {

  constructor(private el: ElementRef) {
  }

  @HostListener('blur') onBlur() {
    if (this.el.nativeElement.value) {
      const arr: string[] = this.el.nativeElement.value.split('');
      arr[0] = arr[0].toUpperCase();
      this.el.nativeElement.value = arr.join('');
   }
  }
}
```

## Use of Directive in Component Template

```html
<input appTitleCase type="text" class="form-control" />
```

This custom directive will now turn the first letter to uppercase once the user loses focus from the input.

                