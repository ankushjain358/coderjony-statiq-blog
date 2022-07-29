Title: Migrate Local SQL Server Database to Azure SQL Database
Published: 26/12/2020
Author: Ankush Jain
IsActive: true
Tags:
  - Azure
  - SQL Server
---
Moving a local SQL Server database to Azure SQL Database is quite straightforward. 

> **Pre-requisites:** Before you move your local database, make sure you have created a [Logical SQL Server](https://docs.microsoft.com/en-us/azure/azure-sql/database/logical-servers) on Azure already. Because we will be creating a copy of this local database on that Logical SQL Server.

Follow these simple steps:

1.  Open **SQL Server Management Studio**, right-click on the database, and select **Tasks >> Deploy Database to Microsoft Azure SQL Database**

    ![Moving Local SQL Server Database to Azure SQL Database](/img/blogs/migrate-local-sql-server-database-to-azure-sql-database/1-moving-local-sql-server-database-to-azure-sql-database.png)

2.  Click on the ***Connect*** button to establish a server connection with your Azure Database. 

    ![Moving Local SQL Server Database to Azure SQL Database](/img/blogs/migrate-local-sql-server-database-to-azure-sql-database/2-moving-local-sql-server-database-to-azure-sql-database.png)

3.  Enter your ***Azure SQL Database Server Name, Login & Password*** in the popup window.  
 
    ![Moving Local SQL Server Database to Azure SQL Database](/img/blogs/migrate-local-sql-server-database-to-azure-sql-database/3-moving-local-sql-server-database-to-azure-sql-database.png)

4.  After the successful connection, select the ***Service Tier (Compute Size) and Storage Size*** for your database and then click Next. Refer to this link for more details - [Service tiers in the DTU-based purchase model](https://docs.microsoft.com/en-us/azure/azure-sql/database/service-tiers-dtu). 
    
    ![Moving Local SQL Server Database to Azure SQL Database](/img/blogs/migrate-local-sql-server-database-to-azure-sql-database/5-moving-local-sql-server-database-to-azure-sql-database.png)

5.  Wait for the operation to complete. This may take longer depending on the size of the database. 

    ![Moving Local SQL Server Database to Azure SQL Database](/img/blogs/migrate-local-sql-server-database-to-azure-sql-database/4-moving-local-sql-server-database-to-azure-sql-database.png)

That's all !!

                