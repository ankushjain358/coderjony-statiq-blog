Title: How to find Stored Procedures containing specific text in SQL Server?
Published: 27/09/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Below small query will list all the procedures that contains specific text.

```
    SELECT OBJECT_NAME(object_id), definition
    FROM sys.sql_modules 
    WHERE OBJECTPROPERTY(object_id, 'IsProcedure') = 1
    AND definition LIKE '%SearchText%'
    ```

                