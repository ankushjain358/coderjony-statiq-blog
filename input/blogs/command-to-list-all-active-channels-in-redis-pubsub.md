Title: Command to list all active channels in Redis Pub/Sub
Published: 10/12/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
In Redis Pub/Sub, we create different Redis channels as per the application requirement. Each application using Redis Pub/Sub will use these channels for either publishing purpose or subscribing purpose. 

Whenever any application publishes a message to a channel, all subscriber client applications which have subscribed to that channel will be notified immediately for that message. 

Below we know about two important commands used in Redis PUB/SUB implementation.

## Command to list all active channels in Redis Pub/Sub

Below command will list out all active channels for connected Redis instance.

`PUBSUB CHANNELS`

## Command to list the number of subscribers subscribed to a Redis channel

If you want to know the number of subscribers to a channel, then you can use below command. This will return number of subscribers to a particular channel.

`PUBSUB NUMSUB channelName`

                