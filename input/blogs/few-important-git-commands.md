Title: Few important GIT commands
Published: 14/05/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
As I am new to Git & in learning phase of it's concepts. During my learning, I found below commands quite useful. So, I thought to document my learning by writing a blog here.

## Useful GIT Commands

*   `git clone <url>` - To clone a git repository.

*   `git init`  - To initialize a Git repository. This command creates a  hidden folder with name `.git` on the folder on which you run this command. This `.git` folder contains all necessary files required to maintain version controlling.

*   `git add .` & `git add -A` - Both commands are used to stage files. To commit any file, we first have to stage it and then commit it. Staging means making a file ready to commit. Difference in both command is that `git add -A` also stages files in higher directories that still belong to the same git repository but `git add .`  will consider only current directory.

*   `git checkout -b <BranchName>` - To create a branch from exiting branch.

*   `git checkout <BranchName>` - To switch from current branch to new branch.

*   `git checkout -- <File>` - To discard changes of a file.

*   `git status` - To check status of the repository.

*   `git pull` - To get latest of your branch. **git pull = git fetch + git merge**

*   `git pull --all` To update local branches which track remote branches.

*   `git fetch` - To update your local copy of remote branch. This will not update your checked-out remote tracking branch.

*   `git fetch --all` - To update local copies of remote branches so this is always safe for your local branches.

*   `git clean -fd` - To remove untracked files. (Does not remove files which are ignored intentionally by **.gitignore**)

*   `git clean -fdx`- To remove untracked files. (Remove all file. Does not even consider **.gitignore** file)

*   `git commit -m "First commit"` - To commit staged files.

*   `git remote show origin` - To view remote repository URL.

*   `git remote add origin <RemoteRepositoryURL>` - To associate local repository with a remote repository.

*   `git push -u origin <BranchName>` - To push new branch to remote.

*   `git push -u origin --all` - To push all local branches to remote. This command is useful in case when you created project locally & want to push whole repository to remote.

*   `git branch` - To view local branches. The current branch will be highlighted with an asterisk.

*   `git branch --set-upstream` - To make a branch remote tracking.

*   `git stash save "<stash-name>"` - To stash your changes.

*   `git stash list` - To display the list of all stashes.

*   `git stash apply <stash-name>` - To un-stashed stashed changes. `<stash-name>` is optional.

*   `cat .git/HEAD` - Head is the tip of your current branch. Head always refers to the most recent commit on your current branch. When you change branches, `HEAD` is updated to refer to the new branch’s latest commit.

*   `git update-index --assume-unchanged [path_or_file]` - To prevent git from detecting changes from a tracked file.


                