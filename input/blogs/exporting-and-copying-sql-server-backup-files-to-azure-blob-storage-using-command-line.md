Title: Exporting and copying SQL Server backup files to Azure Blob Storage using Command Line
Published: 05/06/2021
Author: Ankush Jain
IsActive: true
Tags:
  - Azure
  - SQL Server
  - Azure SQL Database
---
In this post, we will understand how can to export the SQL Server database via the command line and copy it to Azure Blob storage.

## Problem Statement & Solution
It is a very common practice to schedule daily nightly backups of the SQL Server database to prevent the application's data from any hardware failure or any other human-made error. 

In this post, we will be storing these automated backup files in your Azure Storage account. Storing data in an Azure Storage account is cheap as compared to the hard disk that we purchase. Also, Azure is more reliable as your data is stored in the cloud and you can access it at any time.

So, now let's start.

## Export SQL Server database using Command Line

Our first task is to export the database `.bacpac` file for our SQL Server database.

For this, follow the below steps:

### Step 1: Locate SQLPackage.exe file
Locate the **SQLPackage.exe** file on your system. On my system, it was located at `C:\Program Files (x86)\Microsoft SQL Server\140\DAC\bin`.

If it is not on your system, you can download and install it. Click here to [Download SQLPackage.exe](https://docs.microsoft.com/en-us/sql/tools/sqlpackage/sqlpackage-download?view=sql-server-ver15#get-sqlpackage-for-windows)

### Step 2: Export the database to a .bacpac file
Run the below command to export the database into a .bacpac file.

```bash
cd "C:"
cd "C:\Program Files\Microsoft SQL Server\150\DAC\bin"
sqlpackage.exe /Action:Export /SourceServerName:.\SQLEXPRESS /SourceDatabaseName:InventoryDB /TargetFile:D:\DatabaseBackups\InventoryDB.bacpac
```

All parameters are self-explanatory.

## Copy .bacpac file to Azure Blob Storage
Now, to copy the files to Azure Blob Storage, we will follow the below steps.

### Step 1: Install AzCopy

**AzCopy** is a command-line utility that you can use to copy blobs or files to or from a storage account. 👉 [Click here to download AzCopy](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azcopy-v10)

After downloading, copy it somewhere on your system. I copied it inside the **C:\azcopy** directory.

### Step2: Prepare Azure Storage account
Before you copy the files to Azure, make sure you are done below steps:
*   Create Storage Account
*   Create a Blob Container
*   **Generate a SAS Token for the Blob Container (With required permissions)**


### Step 3: Copy the .bacpac file using AzCopy
Run the below command to copy the **.bacpac** file to the Azure Storage account.
```bash
cd "C:"
cd "C:\azcopy"
azcopy.exe copy "D:\DatabaseBackups\InventoryDB.bacpac"  "https://[account].blob.core.windows.net/[container]/[path/to/blob]?[SASToken]"
```

That's all.

## Automate daily backups

To automate this process, you can do the following:
*   Create a batch file that does both **export** and **copy**
*   Create a task in **Task Scheduler** that will execute this batch file once a day

This way, you will be able to export your daily SQL backups in Azure Storage.

                