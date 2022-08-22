Title: Understand Socket Programming in Web Applications
Published: 01/02/2018
Author: Ankush Jain
IsActive: true
ImageFolder: understand-socket-programming-in-web-applications
Tags:
  - Web Development
---
## What is a Socket?
Socket is an endpoint with an IP Address & a port number. For example, we can call this IP address **192.22.56.345:3000** as a socket. Here **192.22.56.345** is an IP Address & **3000** is a port number. 

**In context of web applications,** this socket will get created in your browser (more specifically, a browser tab) when you open a website that is providing you real time updates. i.e. Stock Exchange Website, Live Cricket Score Website, Facebook etc.   

## What is Socket Programming?
Socket programming is nothing but just just a way of establishing a two way or duplex communication between two sockets. Best example is a Chat Application. Others are stackoverflow, facebook, gmail or any other website which is providing you real time updates.   

## How does it work?
Socket communication is purely based on TCP protocol. TCP Protocol allows us to establish a duplex or bi-directional communication. 

In web-applications, we use web-sockets (ws protocol) to establish a connection between a browser (consider it as a socket here) and a TCP Server or any other Socket. Once connection gets established, a channel is created between two endpoints, this channel is purely bi-directional, it means that both endpoint can send data to each other at the same time & they will be using TCP IP protocol in the background.

TCP IP Protocol is purely based on IP. This whole Duplex Communication is happening between two different IP Addresses. Here IP Address means **IP Address:Port Number**.

                
