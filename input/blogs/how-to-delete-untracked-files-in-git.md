Title: How to Delete Untracked Files in Git?
Published: 07/12/2019
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
In this post, we will understand how can we delete untracked files present in the git repository. To understand what are Untracked Files? Refer to this - [What are Untracked Files in Git?](http://www.coderjony.com/blogs/what-are-untracked-files-in-git/)

## Deleting Untracked Files

To delete Untracked Files from the repository, you can use `git clean -f -d -x` command. This will remove all untracked files and folders from the repository. This command also deletes the files which are ignored by `.gitignore` file, which eventually results in the fresh and initial state of your repository.

> **Important**: Below commands will work only for the directories or sub-directories from where they have been executed. To apply this command to the whole repository, run it from the root folder.

Understand the below parameters:

*   `-n` Don't remove anything, just show what would be deleted.

*   `-f`  Delete files forcefully.

*   `-d` Consider untracked directories as well along with untracked files.

*   `-x` Consider untracked files also that are ignored by `.gitignore`.



To view what files will be deleted before actually deleting them, you can use the below commands.

*   `git clean -n`- List only untracked files except those ignored by `.gitignore`.

*   `git clean -n -d`- List untracked files & folders except those ignored by `.gitignore`.

*   `git clean -n -x`- List all untracked files including those ignored by `.gitignore` as well.

*   `git clean -n -d -x`- List all untracked files & folders including those ignored by `.gitignore` as well.



To delete the files from the repository, use the below commands.

*   `git clean -f`- Delete only untracked files except those ignored by `.gitignore`.

*   `git clean -f -d`- Delete untracked files & folders except those ignored by `.gitignore`.

*   `git clean -f -x`- Delete all untracked files including those ignored by `.gitignore` as well.

*   `git clean -f -d -x`- Delete all untracked files & folders including those ignored by `.gitignore` as well.



You can also refer to this StackOverflow link to know more about - [How to delete untracked files in Git?](https://stackoverflow.com/a/64966/1273882)

                