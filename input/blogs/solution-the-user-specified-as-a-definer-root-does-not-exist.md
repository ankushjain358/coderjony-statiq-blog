Title: Solution - The user specified as a definer ('root'@'%') does not exist.
Published: 07/12/2019
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Most of the time we get this issue when we copy a MySQL database from one source to another.

## Solution:

The simple solution to this problem is to run below command on the MySQL server.

`GRANT ALL ON *.* TO 'root'@'%' IDENTIFIED BY 'yourPassword' WITH GRANT OPTION;`

Below points will help you in understanding the above command.

*   `*.*` denotes all the tables of all the databases. Here `*` is a wild card for database and table names.

*   `'root'@'%'` means the root user of any host. Here `%` is a wild card for the hostname.



Generalized Form:

`GRANT ALL PRIVILEGES ON db_name.table_name TO 'user_name'@'host_name' IDENTIFIED BY 'password' WITH GRANT OPTION;`

For more information, refer this link - [MySQL Reference Manual - GRANT Statement](https://dev.mysql.com/doc/refman/5.5/en/grant.html).

                