Title: System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
Published: 14/08/2018
Author: Ankush Jain
IsActive: true
ImageFolder: systemio__errorwinioerror-int32-errorcode-string-maybefullpath
Tags:
  - PowerShell
---
Normally, the application gets this error when it tries to access a file that is being used or locked by some another process.

## Solution:
Ensure that the file you are trying to access is not being used by any other process.

Following points could help you in troubleshooting:
1.  Ensure that the file is not opened in any editor or IDE i.e. Notepad, Visual Studio etc.
2.  Ensure that the file is not opened on the same machine by some other user in the same network. You can ask that user to verify if he/she has opened the same file in some process from his account.
3.  Ensure that you close the data stream once it has been used.

                
