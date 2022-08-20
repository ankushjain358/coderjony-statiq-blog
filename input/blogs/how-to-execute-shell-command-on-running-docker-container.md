Title: How to execute shell command on running docker container?
Published: 03/05/2020
Author: Ankush Jain
IsActive: true
ImageFolder: how-to-execute-shell-command-on-running-docker-container
Tags:
  - Docker
---
Use the below syntax:

```bash
docker exec -ti <container_id> <command>
```

To check the container id, run `docker container ls` command in the console.

Examples:
*   To print date in the console -  `docker exec -ti date`
*   To echo **Hello World** in console - `docker exec -ti 011f0b0f68ce echo "hello world"`
*   To create a directory inside container - `docker exec -ti 011f0b0f68ce mkdir -p "/home/databox"`

Reference - [https://docs.docker.com/engine/reference/commandline/exec/](https://docs.docker.com/engine/reference/commandline/exec/)

                
