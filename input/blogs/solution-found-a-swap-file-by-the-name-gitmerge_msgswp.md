Title: Solution- Found a swap file by the name ".git/.MERGE_MSG.swp"
Published: 19/12/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Normally, you get this error message when you are performing GIT operations from two different places. Like I got this issue while I was using Git Bash (Command Line) & Visual Studio together to perform Git operations.

## Reason:

*   This issue occurs when a `commit` or `merge` session is going on in
   one of the two instances of GIT. *i.e. Git Bash & Visual Studio Git.*

*   Both instances try to edit the same file & we get this error message.



## Solution:

Complete the `commit` or `merge` session in one of the two opened instances. 

> **Note**: When I got this error message, I found that a window with commit message text-box was opened in Visual Studio. I just entered the commit message & committed the code. Later I also closed Git Bash window as well.

Reference: [https://stackoverflow.com/a/13361874/1273882](https://stackoverflow.com/a/13361874/1273882)

                