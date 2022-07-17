Title: How to change schema name of a table in SQL Server?
Published: 26/03/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Use below script to change schema name of a table in SQL Server.

Generalized Syntax:

    `ALTER SCHEMA NewSchema TRANSFER CurrentSchema.TableName; `

For example, if you want to change your **dbo.Customers** table to **Config.Customers**, then you can use below SQL command.

    `ALTER SCHEMA Config TRANSFER dbo.Customers;`

                