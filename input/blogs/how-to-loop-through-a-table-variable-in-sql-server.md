Title: How to loop through a table variable in SQL Server?
Published: 26/12/2019
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Let's assume you want to loop through a table variable having the structure like below. 

```
    DECLARE @tempCategories TABLE 
    (
      Id INT,
      CategoryName NVARCHAR(500),
    )
    ```

To iterate through this table, just add one more column (`Processed`) in this table variable. Now the table should look like this.

```
    DECLARE @tempCategories TABLE 
    (
      Id INT, -- Make sure, you have one unique column in the table
      CategoryName NVARCHAR(500),
      Processed INT DEFAULT 0 -- This is the main column that will help us in looping through the table.
    )
    ```

> **Important**: Make sure, you have one unique column in the table. If it is `Id` then very good, else create a new one.

After that, use below SQL.

```
    -- 1. Declare a variable to hold unique column value of table variable
    DECLARE @Id INT

    -- 2. Run code till even a single record is present which is un-processed
    WHILE (SELECT COUNT(*) FROM @tempCategories WHERE Processed = 0) > 0
    BEGIN

        -- A. Select first un-processed item from the table variable
        -- Note: Here, you can fetch any column as per your need
        SELECT TOP 1 @Id = Id FROM @tempCategories WHERE Processed = 0

        -- B. Do some processing here with your custom logic
        -- Your custom logic
        -- Your custom logic
        -- Your custom logic

        -- C. Finally, update the table variable, set the 'Processed' column of the processed row to 1. 
        UPDATE @tempCategories SET Processed = 1 Where Id = @Id 

    END
    ```

That's it 😊.

                