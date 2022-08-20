Title: Solution- Pendrive not showing data files
Published: 08/10/2017
Author: Ankush Jain
IsActive: true
ImageFolder: solution-pendrive-not-showing-data-files
Tags:
---
If your pen-drive is not showing data and you know that there is some data in it then below steps can help you in displaying data in pen-drive.

1.  Open command prompt - Start > Run > type "cmd" and enter
2.  Hit below command. Here I am assuming that your pen-drive is H drive
    ```bash
    attrib -h -r -s /s /d h:\*.*
    ```

This will solve your problem. :)

                
