Title: What is Thread Starvation in ASP.NET applications?
Published: 03/11/2017
Author: Ankush Jain
IsActive: true
ImageFolder: what-is-thread-starvation-in-aspnet-applications
Tags:
  - IIS
---
## How IIS Process a Web Request?
In ASP.NET, web requests are processed by IIS. Once your request arrives at IIS, a thread (also known as Worker Thread) is taken from the CLR Thread Pool to process your request. Once your request's processing completes, that thread is given back to the Thread Pool.

## What is Thread Pool
A Thread Pool is a pool of threads or we can say a collection of threads.

## What is Thread Starvation?
Now, suppose we have hosted our application on an IIS whose Thread-Pool's size is 200. Now, assume that each web-request of our web-application takes 5 seconds to process. Now if 200 users simultaneously access our application, then all 200 worker threads will get busy for next 5 seconds. Now, some new user comes and tries to access our application (this is 201st user) then IIS will not be able to process this request because, all worker threads are already busy in processing previous requests. So, now IIS will wait some time for the threads to get free, if any thread gets free in the waiting time then it will be used to process our request otherwise IIS will return the user with the message **503 - Server Too Busy**. This state is called Thread Starvation.

In small words, the condition or state when all the threads of the Thread Pool are in use and IIS don't have any available or free thread to process a request, called the state of starvation & this is called Thread Starvation.

## When does it happens?
It usually happens when your website's traffic is very high. 

For example, It may happen if you create an Online Examination System, on which thousands of users will give exam on the same time. So, you will have to write code in such manner that a thread should not block the request or should not take much time to process a request.

## Solution: Async & Await
Main use of Async & Await in Web Applications is to free the thread. Async & Await will not run your code faster - this is a misconception that using Async & Await in code will run your code faster. They are used for scalability purpose. If you use Async & Await in your web-application properly, then it will make your application scalable enough to handle more requests with same resources.

I found below a better answer on What is use of Asnc/Await in web applications? 

[https://stackoverflow.com/questions/30566848/when-should-i-use-async-controllers-in-asp-net-mvc/30574578#30574578](https://stackoverflow.com/questions/30566848/when-should-i-use-async-controllers-in-asp-net-mvc/30574578#30574578)

                
