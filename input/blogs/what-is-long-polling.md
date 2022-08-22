Title: What is Long Polling?
Published: 17/04/2017
Author: Ankush Jain
IsActive: true
ImageFolder: what-is-long-polling
Tags:
  - Web Development
---
Long polling is a process where browser sends a request to server. Server holds that request and keep the request thread open until any data is available. Once data is available at server, it sends the response to the browser and closes request thread. Once browser receive the response, it initiates another request and the process continues. This is called long polling in web development.

## Usage
We can use long polling when we want to get real time updates from server. For example, to display live cricket score, to display latest share prices etc.

## Pros
1.  We can get real time updates from server.
2.  Easy to implement.

## Cons
1.  It consumes server resources and increases load on server if incoming request are large.
2.  Applications with intense calculation and business processing may cause high latency time.

**Long Polling is an old picture, Now you can achieve the same thing in a better way using Web Sockets technology.**

                
