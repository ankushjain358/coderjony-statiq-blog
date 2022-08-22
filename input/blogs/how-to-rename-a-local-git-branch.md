Title: How to rename a local GIT Branch?
Published: 28/06/2018
Author: Ankush Jain
IsActive: true
ImageFolder: how-to-rename-a-local-git-branch
Tags:
  - Git
---
If you want to rename the branch you are currently working on, hit below command:

```bash
git branch -m <newBranchName>
```

If the branch you want to rename is different from your current branch, then hit below command

```bash
git branch -m <oldBranchName> <newBranchName>
```

To check your **current branch**, hit below command. You can see the current branch highlighted followed by an asterisk.

```bash
git branch
```

The same question has also been asked here as well @ [StackOverflow](https://stackoverflow.com/questions/6591213/how-do-i-rename-a-local-git-branch).

                
