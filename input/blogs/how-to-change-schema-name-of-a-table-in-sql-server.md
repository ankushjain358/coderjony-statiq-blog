Title: How to change schema name of a table in SQL Server?
Published: 26/03/2018
Author: Ankush Jain
IsActive: true
Tags:
  - SQL Server
---
Use below script to change schema name of a table in SQL Server.

Generalized Syntax:
```sql
ALTER SCHEMA NewSchema TRANSFER CurrentSchema.TableName;
```

For example, if you want to change your **dbo.Customers** table to **Config.Customers**, then you can use below SQL command.
```sql
ALTER SCHEMA Config TRANSFER dbo.Customers;
```

                