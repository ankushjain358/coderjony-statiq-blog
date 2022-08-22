Title: Get Previous and Next page URLs in Umbraco
Published: 28/11/2018
Author: Ankush Jain
IsActive: true
ImageFolder: get-previous-and-next-page-urls-in-umbraco
Tags:
  - Umbraco
---
To get previous & next page URLs in Umbraco, you can use the below piece of code in your razor view.

```cs
@if(CurrentPage.Previous() != null){
       <a href="@CurrentPage.Previous().Url">Previous</a>
}
	
@if(CurrentPage.Next() != null){
       <a href="@CurrentPage.Next().Url">Next</a>
}
```

                
