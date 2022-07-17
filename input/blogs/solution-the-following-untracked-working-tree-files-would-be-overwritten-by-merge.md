Title: Solution- The following untracked working tree files would be overwritten by merge
Published: 16/01/2019
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Below, I have mentioned both root-cause & solution of above error.

## Root Cause:

It seems that the files you want to ignore are already committed into the repository. And `.gitignore` doesn't actually ignore the files which are already committed into the repository.

Note that here **untracked working tree files** means that git is considering these files as untracked because `.gitignore` file have their entries. 

## Solution:

You can fix this issue by following below easy steps:

1.  Create a new feature branch or separate branch.

2.  Delete the files which you actually want to ignore.  (i.e. files mentioned in `.gitignore`)

3.  Commit these deleted files & push the code.

4.  Now, raise the pull-request to merge this feature branch in your actual main branch.

5.  Now, this issue has been fixed in main branch. You won't get this issue again. 


                