Title: Mount a Windows Share on Linux container using C#.NET
Published: 06/08/2020
Author: Ankush Jain
IsActive: true
ImageFolder: mount-a-windows-share-on-linux-container-using-cnet
Tags:
  - .NET Core
  - Linux
  - Docker
---
If you are running a .NET Core application in a Linux container and want to access Windows Share (Network Share) that is secured with credentials, then you can use the below C# based solution.

![Mount a Windows Share on Linux container using C#.NET](/img/blogs/mount-a-windows-share-on-linux-container-using-cnet/aspnet-core.png)

## Step by Step: Mounting Network Share using C#.NET

**Step 1:** Install the CIFS utility in the container through the docker file.

```cs
# install cifs-utils package in this linux container 
RUN apt-get update && apt-get install -y cifs-utils
```

Write this command just before we call entry point `ENTRYPOINT ["dotnet", "NETCoreApp.dll"]`

**Step 2:** Add below class `NetworkDriveUtility` in your project and replace the below 4 variables with their actual values:
- mountPath
- sharePath 
- username
- password 

```cs
using System;
using System.Diagnostics;
using System.IO;

namespace MountDrive
{
    public class NetworkDriveUtility
    {
        /// <summary>
        /// Mounts network drive on linux container
        /// </summary>
        /// <returns>Result</returns>
        public bool MountNetworkDrive()
        {

            bool result = false;

            try
            {
                //Replace these values with actual one
                string mountPath = "<localpath>"; // i.e. /LocalFolderName
                string sharePath = "//<host>/<path>";
                string username = "<username>";
                string password = "<password>";

                string mkdirArgs = $"-p \"{mountPath}\"";
                string mountArgs = $"-t cifs -o username={username},password={password} {sharePath} {mountPath}";

                string message = string.Empty;

                if (RunCommand("mkdir", mkdirArgs, out message))
                {
                    //Logger.LogInformation($"Output 1: {message}");

                    if (RunCommand("mount", mountArgs, out message))
                    {
                        //Logger.LogInformation($"Output 2: {message}");

                        string connectingTestingFile = $"{Guid.NewGuid()}.txt";
                        string filePath = Path.Combine(mountPath, connectingTestingFile);

                        //Logger.LogInformation("Testing file path: " + filePath);

                        File.Create(filePath);
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                            result = true;
                        }
                        if (result)
                        {
                            //Logger.LogInformation("Network drive mounted successfully");
                        }
                        else
                        {
                            //Logger.LogError("Network drive mounting failed");
                        }
                    }
                    else
                    {
                        //Logger.LogError($"Error Output 2: {message}");
                    }
                }
                else
                {
                    //Logger.LogError($"Error Output 2: {message}");
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, $"Error message - {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// This method runs command on shell/bash
        /// </summary>
        /// <param name="command">Command name</param>
        /// <param name="args">Command argument</param>
        /// <param name="message">Output message</param>
        /// <returns>Boolean
        public static bool RunCommand(string command, string args, out string message)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (string.IsNullOrEmpty(error))
            {
                message = output;
                return true;
            }
            else
            {
                message = error;
                return true;
            }
        }
    }
}
```

**Step 3:** Call the `MountNetworkDrive` method in the `Main` method.
```cs
static void Main(string[] args)
{
    bool success = new MountDrive.NetworkDriveUtility().MountNetworkDrive();
}
```

That's it. If the `success` variable's value is true then you are done.

## NetworkDriveUtility Class
*   **RunCommand** - Runs the command on shell/bash
*   **MountNetworkDrive** - Mounts network drive

> **Mount Verification** - I am verifying by creating a text file on the share path and checking if file gets created or not. If created, then we consider that drive mounted successfully and delete the file in the next step.

Hope this should solve your purpose. 😊

## References:
*   [Mount SMB/CIFS share within a Docker container](https://stackoverflow.com/questions/27989751/mount-smb-cifs-share-within-a-docker-container)
*   [Docker - Mount Windows Network Share Inside Container](https://stackoverflow.com/questions/30493300/docker-mount-windows-network-share-inside-container)
*   [Accessing network path using C# from Ubuntu](https://stackoverflow.com/questions/52081068/accessing-network-path-using-c-sharp-from-ubuntu/52081235#52081235)
*   [Copy file from linux to windows share with C# (.NET core)](https://stackoverflow.com/a/46818116/1273882)
*   [Backing SQL on Linux to Windows Share](https://dbain.wales/2018/11/11/backing-sql-on-linux-to-windows-share/)


                
