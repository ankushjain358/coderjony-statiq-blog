Title: How to refresh git branches in visual studio?
Published: 13/07/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
## Problem

Deleted remote branches are still visible in Visual Studio Team Explorer (Branches Section).

## Solution

You just need to run `git fetch --prune` command in your solution directory using **GIT Bash** or **Command Prompt**. 

After running this command, you will find that deleted remote branches are no longer showing up in `remotes/origin` section in Visual Studio.

![enter image description here](/img/blogs/how-to-refresh-git-branches-in-visual-studio/update-git-branches-in-visual-studio.png)

                