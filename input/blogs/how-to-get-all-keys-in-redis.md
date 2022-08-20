Title: How to get all keys in Redis?
Published: 08/05/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Redis
---
If you are using Redis-CLI & want to get all keys in Redis, then you can use below command in Command Prompt. This will return all available keys in Redis Data Store.

```bash
KEYS *
```

## Steps: To Get All Keys in Redis

1.  **Step 1:** Open command prompt, type `redis-cli KEYS *` like below & hit enter.

    ![Redis command to get all keys](/img/blogs/how-to-get-all-keys-in-redis/redis-get-all-keys.png)

2.  **Step 2:** See result below:

    ![Redis command result to display all keys](/img/blogs/how-to-get-all-keys-in-redis/redis-get-all-keys-result.png)


## Steps: To Get Specific Key in Redis

Now, suppose we want to get a specific key from Redis then we use below commands:

1.  To get key by specific key-name, use command `redis-cli KEYS KeyName`.  See example below:  
    
    ![Redis command to get key by name](/img/blogs/how-to-get-all-keys-in-redis/redis-get-key-by-name.png)

2.  To get keys that starts with particular text, use command `redis-cli KEYS StartingText*`. This will return all keys that starts with text **StartingText**.  See example below: 

    ![Redis command to get key that starts with some text](/img/blogs/how-to-get-all-keys-in-redis/redis-get-keys-with-some-starting-text.png)


                