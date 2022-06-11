Title: Installing MongoDB in 10 easy steps
Published: 16/04/2017
Author: Ankush Jain
Tags:
  - ASP.NET
  - C#
ImageFolder: installing-mongodb
IsActive: true
---
MongoDB is famous NoSQL database. NoSQL database stores data in JSON format in text file or similar. These are very famous now a days and used widely because reading data from a NoSQL database is much much faster than a RDBMS like SQL Server, MySQL or other.
- **RDBMS** > Database > Table > Row
- **NoSQL** > Database > Collections > Documents

## Installation
1. Install it on windows by it's windows installer.
2. It will be installed at `C:\Program Files\MongoDB`.
3. Go to bin folder `C:\Program Files\MongoDB\Server\3.0\bin`. Here you will see a bunch of executables.
4. You will need to work with only mongod.exe and mongo.exe.
5. `mongod.exe` - runs the actual mongo DB. (this is the actual server)
6. `mongo.exe` - used to connect with the database of mongo db and perform add edit update delete operations.
7. Run `mongod.exe` from the command line (first, it will ask for a folder `C:\data\db` to store mongo database data. So create those folders.)
8. Run `mongod.exe` again. Now it will run and will be waiting for some connection.
9. Now run `mongo.exe` from the command line and create database or perform some other operations.
10. You will see in that commend windows that are running `mongod.exe` is showing some logs. It's all done with the setup now.