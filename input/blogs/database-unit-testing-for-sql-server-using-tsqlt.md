Title: Database Unit Testing for SQL Server using tSQLt
Published: 22/03/2019
Author: Ankush Jain
IsActive: true
Tags:
  - SQL Server
---
In this blog, I am sharing the key points that I noted while learning the basics of database unit testing for SQL Server.

## Installation:
*   `tSQLt` must be installed on the SQL Server database.
*   Download the .zip file from its website.
*   Unzip that file, there will be mainly 3 SQL files.
    *   `SetClrEnabled.sql`
    *   `tSQLt.class.sql`
    *   `Example.sql`
*   First Enable CLR from the first file.
*   Second, set the database trustworthy from the script given in the [link](https://tsqlt.org/user-guide/quick-start/#InstallToDevDb)
*   Third, run `tSQLt.class.sql`
*   These 3 steps will install `tSQLt` on your database.

## Creating a Test Class
*   A Test Class is basically a database schema with some special properties applied so that `tSQLt` can recognize them as a test class.
*   A Test Class can contain many Test Cases. *(Note: A Test Case is nothing but a Stored Procedure.)*
*   To create a Test Class, we must run the below command. 

```sql
EXEC tSQLt.NewTestClass 'MyTestClass'; 
GO
```

## Creating a Test Case
*   Creating a test case is easy. You only need to create a stored procedure on your test class schema.
*   The procedure name must begin with "test".

## Running Test Cases
*   **RunAll** - RunAll executes all test cases on all test classes. 
    *   i.e `EXEC tSQLt.RunAll;`
*   **Run** - Run is a versatile procedure for executing test cases. It can be called in three ways: 	
    *   With a test class name	
    *   With a qualified test case name (i.e. the schema name and the test    case name)
    *   With no parameter
*   [Creating a Test Class, Test Case & Running them all](https://tsqlt.org/130/creating-and-running-test-cases-in-tsqlt)


## Important Points:
*   Every individual test case is wrapped in a transaction that is rolled back at the end of the test.
*   Click here to know [how Test Cases are executed by tSQLt](https://tsqlt.org/user-guide/test-creation-and-execution/)


                