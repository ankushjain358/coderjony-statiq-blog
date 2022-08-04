Title: How to check number of bytes used by a variable in SQL Server?
Published: 12/11/2018
Author: Ankush Jain
IsActive: true
Tags:
  - SQL Server
---
To check bytes used by a variable in SQL Server, you can use `DATALENGTH` function.

```sql
DECLARE @temp NVARCHAR(MAX)
SET @temp =  N'化字'
SELECT DATALENGTH(@temp)
```

This will display the number of bytes used `@temp` variable to represent a character or expression.