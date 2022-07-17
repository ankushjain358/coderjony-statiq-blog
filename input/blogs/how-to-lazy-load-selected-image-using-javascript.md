Title: How to Lazy load selected image using JavaScript
Published: 16/10/2021
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
You can use the below code to display the preview of a large-sized image when the user clicks on its thumbnail. 

The code is self-explanatory.

```
    // function to show loading spinner
    var showloading = function() { ... };

    // function to hide loading spinner
    var hideloading = function() { ... };

    // function to show error notification
    var showError = function(message) { ... };

    // invoke this method when user clicks on a thumbnail
    var lazyLoadSelectedImage = function (imageUrl) {

        // show loading
        showloading();

        // create a JS object with Image type
        var img = new Image();

        // write an handler for load event
        img.onload = function () {

            // set the src of original image to this image url
            $("img#someId").attr('src', imageUrl);

            // hide loading
            hideloading();    
        };

        // write an handler for error event
        img.onerror = function () {

            // show error notification
            showError("Some error occured");

            // hide loading
            hideloading();
        };

        // finally set the selected image url
        img.src = imageUrl;
    };
    ```

Also, while writing this blog, I got to know about this [HTML <img> loading Attribute tag](https://www.w3schools.com/tags/att_img_loading.asp) as well. It looks interesting, just read about this.

Thank You 🙂 !!

                