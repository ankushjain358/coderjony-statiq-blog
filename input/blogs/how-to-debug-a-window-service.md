Title: How to debug a Window Service?
Published: 24/07/2017
Author: Ankush Jain
IsActive: true
Tags:
  - .NET
  - Windows Service
---
To debug a window service you can make use of below property of **Environment** class:

```cs
Environment.UserInteractive
```

When you run your code in debug mode, this property returns true because your code is running in user interactive mode but when you run your window service as a windows process or service, then this property returns false.

> It is recommended to do not show any popup, alert or dialog when this service runs as windows process.

```cs
static void Main(string[] args)
{
    if (Environment.UserInteractive)
    {
        // Your own logic to debug
        MyService myService = new MyService();
        myService.SomeTestMethod();
    }
    else
    {
        // Actual window service code
        ServiceBase[] ServicesToRun;
        ServicesToRun = new ServiceBase[] 
        { 
            new InvoiceProcessor() 
        };
        ServiceBase.Run(ServicesToRun);
    }
}
```

                