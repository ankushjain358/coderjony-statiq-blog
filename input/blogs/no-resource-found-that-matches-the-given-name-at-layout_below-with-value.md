Title: no resource found that matches the given name (at 'layout_below' with value
Published: 28/11/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
## Solution:

Just change `@id` to `@+id` while defining or referencing an id. This will fix your issue.

For me, I just changed 

`android:layout_below="@id/toolbar_layout"`

to

`android:layout_below="@+id/toolbar_layout"`

                