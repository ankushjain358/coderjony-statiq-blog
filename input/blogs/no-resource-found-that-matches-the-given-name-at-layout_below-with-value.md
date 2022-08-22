Title: no resource found that matches the given name (at 'layout_below' with value
Published: 28/11/2018
Author: Ankush Jain
IsActive: true
ImageFolder: no-resource-found-that-matches-the-given-name-at-layout_below-with-value
Tags:
  - Android
---
## Solution:

Just change `@id` to `@+id` while defining or referencing an id. This will fix your issue.

For me, I just changed 

```markup
android:layout_below="@id/toolbar_layout"
```
to
```markup
`android:layout_below="@+id/toolbar_layout"
```

                
