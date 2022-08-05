Title: How to check code point value of a Unicode character in SQL Server?
Published: 23/10/2018
Author: Ankush Jain
IsActive: true
Tags:
  - SQL Server
---
To determine the code-point value of a Unicode character in SQL Server, you can use `UNICODE()` function which is provided by default in SQL Server.

### What is Code Point?
- Every character in a character set (ASCII, UNICODE etc.) is assigned a numeric value, which is known as Code Point.
- A Unicode Code Point is a unique number assigned to each Unicode character.

For example, if you want to determine the code-point value of the English letter `A`, then you simply need to write the below command in SQL Server.

```sql
SELECT UNICODE('A')
```

This will output its code-point value.

You may have to prefix `N` before the character if the character is a Non-ASCII character. `N` stands for **National Language Character Set**.

```sql
SELECT UNICODE(N'ह')
```

See the below example image:

![How to check code point value of a Unicode character in SQL Server?](/img/blogs/how-to-check-code-point-value-of-a-unicode-character-in-sql-server/determine-unicode-character-code-point-value.png)