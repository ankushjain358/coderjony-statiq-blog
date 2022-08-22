Title: How to deploy dacpac using SQLPackage.exe
Published: 18/06/2018
Author: Ankush Jain
IsActive: true
ImageFolder: how-to-deploy-dacpac-using-sqlpackageexe
Tags:
  - SQL Server
---
To deploy the database from dacpac, we will be using **SQLPackage.exe**. 

> SQLPackage.exe is a command line utility that allow us to perform many database related operations from the command line.

You can follow below steps to deploy a database to SQL Server from the .dacpac file. 

1.  First, you have to go to the location where SQLPackage.exe is placed on your system. On my system, it is placed on below location:

    ```cs
    C:\Program Files (x86)\Microsoft SQL Server\120\DAC\bin\SqlPackage.exe
    ```

    You can follow this [StackOverflow answer](https://stackoverflow.com/questions/44003929/find-sqlpackage-exe-on-client-machine-to-install-dacpac#answer-44019258) to find out the location of this file on your system.

2.  Go to SQLPackage.exe file location from command line. See below picture. ![enter image description here](/img/blogs/how-to-deploy-dacpac-using-sqlpackageexe/delpoy-dacpac-from-sqlpackageexe-1.png)

    Now run below command to deploy the dacpac from SQLPackage.exe.

    **Generalised Command:**

    ```bash
    SqlPackage.exe /Action:Publish /SourceFile:"<DACPAC File Path>" /TargetDatabaseName: <DatabaseName> /TargetServerName:"<Server Name>"
    ```

    **Actual Command:**

    ```bash
    SqlPackage.exe /Action:Publish /SourceFile:"C:\Users\ankushjain\Documents\SQL Server Management Studio\DAC Packages\dbHMS.dacpac" /TargetDatabaseName:HospitalManagementSystem /TargetServerName:"localhost"
    ```

    **Actual Screenshot:** 

    ![enter image description here](/img/blogs/how-to-deploy-dacpac-using-sqlpackageexe/delpoy-dacpac-from-sqlpackageexe-2.png)

This is how you can deploy dacpac from SQLPackage.exe. 

> In above example, we tried to deploy the dacpac on the localhost. But if you want to deploy it on the remote server then you can use `/TargetConnectionString:` parameter while executing SQLPackage.exe.

You can find more detail about more detail about [SQLPackage.exe](https://msdn.microsoft.com/en-us/library/hh550080%28v=vs.103%29.aspx) and it's parameters from its [official page](https://msdn.microsoft.com/en-us/library/hh550080%28v=vs.103%29.aspx).

                
