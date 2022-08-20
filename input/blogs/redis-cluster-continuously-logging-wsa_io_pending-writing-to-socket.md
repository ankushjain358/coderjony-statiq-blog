Title: Redis Cluster continuously logging - WSA_IO_PENDING writing to socket
Published: 09/05/2018
Author: Ankush Jain
IsActive: true
ImageFolder: redis-cluster-continuously-logging-wsa_io_pending-writing-to-socket
Tags:
  - Redis
---
I came across this issue when I was checking Redis log file on server. When I looked at the Redis Log File, I wondered after seeing its size. It was about 4GB. When I tried to open that file, I got a prompt saying **File is too large to open in notepad**.

I further analyzed & stopped Redis Service and re-named the file. When I again started the service, I saw that Redis created a new file again with the same name as **redis_log.txt** on the same place. But this time it's size was 0KB.

Now, I went to browser & ran my application. After running my application for few minutes I again checked this file & found that there are multiple entries with the same information. See below:

```
[17764] 09 May 11:45:51.590 # WSA_IO_PENDING writing to socket fd 24
[17764] 09 May 11:45:51.590 # clusterWriteDone written 2416 fd 15
```

These were two main entries which were logged thousands of time in that log file & due to this, log file size was increasing rapidly.

## Solution
1.  Go to this location `C:\Program Files\Redis`.
2.  Open file `redis.windows-service.conf` in notepad.
3.  There you will see a section like below:
    ```bash
    # Specify the server verbosity level.
    # This can be one of:
    # debug (a lot of information, useful for development/testing)
    # verbose (many rarely useful info, but not a mess like the debug level)
    # notice (moderately verbose, what you want in production probably)
    # warning (only very important / critical messages are logged)
    loglevel notice

    # Specify the log file name. Also 'stdout' can be used to force
    # Redis to log on the standard output.
    logfile "Logs/redis_log.txt"
    ```

This section tells us that there are 4 levels of logging. I had selected `notice` which is recommended for production but this was creating lot of entries & continuously printing above messages. 

In my opinion, you can change `loglevel` to `warning` from `notice`. I hope, after changing `loglevel` to `warning`, only important messages will be logged. Hence, your issue will be resolved automatically.
                
