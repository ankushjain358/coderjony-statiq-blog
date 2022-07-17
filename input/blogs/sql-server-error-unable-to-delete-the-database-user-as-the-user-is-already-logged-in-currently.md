Title: SQL Server Error- Unable to delete the database user as the user is already logged in currently.
Published: 18/04/2017
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Yesterday, when I was trying to delete my database from the web panel of GoDaddy hosting. I got this issue. I was not able to delete my database and I was being shown this message.

I just googled it and got the solution. I thought, it would be nice to share this with you all.

## Root cause

As the message indicates very clearly that there is some user which is still connected with database. That's why it is not allowing you to delete database. User might be connected to server either though any application or through SQL Server Management Studio.

## Solution

First, find out the sessionId for your SQL user

`SELECT session_id
FROM sys.dm_exec_sessions
WHERE login_name = 'ankushjain'
`

then kill that session using KILL command

`KILL 85 -- 85 is just for demo, you may get some different.
`

                