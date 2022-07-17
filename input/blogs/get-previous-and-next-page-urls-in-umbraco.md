Title: Get Previous and Next page URLs in Umbraco
Published: 28/11/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
To get previous & next page URLs in Umbraco, you can use below piece of code in your razor view.

```
    @if(CurrentPage.Previous() != null){
           <a href="@CurrentPage.Previous().Url">Previous</a>
    }

    @if(CurrentPage.Next() != null){
           <a href="@CurrentPage.Next().Url">Next</a>
    }
    ```

                