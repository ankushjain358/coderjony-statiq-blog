Title: How to split a string into array by another string in C#
Published: 09/07/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
To split a string by another string separator, we can use `Split` function of C#.

## Example code

In below example, we are converting a comma-separated string into a list of string.

    ```
    string nodeUrls = "127.0.0.1:2222,127.0.0.1:2223,127.0.0.1:2224";

    List<string> nodeList = nodeUrls.Split(new string[] { "," }, StringSplitOptions.None).ToList();
    ```

                