Title: List all node modules installed globally & locally in Node.js
Published: 01/10/2018
Author: Ankush Jain
IsActive: true
ImageFolder: list-all-node-modules-installed-globally-locally-in-nodejs
Tags:
  - NodeJS
---
This post will show you – how can you get a list of all node modules installed globally & locally on your machine. 

## List all globally installed node modules 

You can use the below commands to get a list of all node modules installed globally on your machine.

```bash
npm list -g --depth 0
```
OR
```bash
npm list -g
```

There are also a few aliases for `list` and they are `ls`, `la` & `ll`. It means you can also write the above commands in the below ways.

1.  `npm ls -g --depth 0`
2.  `npm la -g --depth 0`
3.  `npm ll -g --depth 0`

When you run commands using `ll` or `la` – It will show some extra information by default.

> **Important Note:**
>  `npm list -g --depth 0` command is faster than `npm list -g`. Reason being, `npm list -g --depth 0` doesn’t care about further node-module dependencies & display result as a flat list. On the other hand, `npm list -g` command looks for further module dependencies & displays the result in a tree structure format.

## List all locally installed node modules (inside a project)
All the commands will remain the same in this case except the below two things:

1.  Just remove `-g` from the above commands, as `-g` refers to global.
2.  And run the above commands from your project’s root directory location.

That's all...Thanks...:)

                
