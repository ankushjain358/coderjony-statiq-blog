Title: Solution- Can't bind to 'ngModel' since it isn't a known property of 'input'.
Published: 25/04/2019
Author: Ankush Jain
IsActive: true
ImageFolder: solution-cant-bind-to-ngmodel-since-it-isnt-a-known-property-of-input
Tags:
  - Angular
---
Just add `FormsModule` in `app.module.ts` file of your Angular application.

```ts
import { FormsModule } from '@angular/forms';

[...]

@NgModule({
  imports: [
    [...]
    FormsModule
  ],
  [...]
})
```
                
