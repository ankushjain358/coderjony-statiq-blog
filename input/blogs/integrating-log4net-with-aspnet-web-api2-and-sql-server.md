Title: Integrating Log4Net with ASP.NET Web API2 and SQL Server
Published: 17/10/2019
Author: Ankush Jain
IsActive: true
Tags:
  - .NET
  - Web API
---
In this post, we will understand how can we integrate the famous **.NET Logging Library - Log4Net** into our ASP.NET project. Though particularly in this post I am using an ASP.NET Web API project, but the implementation will almost remain the same even if you want to integrate Log4Net in other ASP.NET applications such as **MVC** & **Web Forms**.

## Log4Net Integration with ASP.NET WEB API 2 and SQL Server

**Step 1:** Select **ASP.NET Web Application (.NET Framework)** project type from the list to create any ASP.NET Application (Web Forms, MVC or Web API). 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-1.png)

**Step 2:** Now select the Web API project template as your ASP.NET Application. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-2.png)

**Step 3:** Once you select the WEB API project template, Visual Studio will create a solution for you with the Web API project. You will see a similar page on your screen after creating this project. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-3.png)

**Step 4:** Now, install `log4net` Nuget package in your Web API project. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-4.png)

**Step 5:** Now that you have installed `log4net` Nuget package, you can open the References node of the project & verify that `log4net` DLL is present there. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-5.png)

> **Note:** So far we have done the stuff to create the Web API project & install the Nuget package of `log4net`. Now, in next few steps - we will work with SQL Server to create the database where we will be logging the information, errors, warnings etc.

**Step 6:** Open **SQL Server Management Studio** & connect with the server using valid credentials. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-6.png)

**Step 7:** Once you are inside SQL Server, create a new database like the below. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-7.png)

**Step 8:** Just type the name of the database in the text box like below. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-8.png)

**Step 9:** Now, execute the below script on this newly created database. This script will create the table where `log4net` will log the records.

```sql
CREATE TABLE [dbo].[Log] (
    [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Date] [datetime] NOT NULL,
    [Thread] [varchar](255) NOT NULL,
    [Level] [varchar](50) NOT NULL,
    [Logger] [varchar](255) NOT NULL,
    [Message] [varchar](4000) NOT NULL,
    [Exception] [varchar](2000) NULL
)
```

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-9.png)

**Step 10:** Once you execute the above script, `Log` table will look like the one below in SQL Server. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-10.png)

**Step 11:** Now you need to add some configurations in your `web.config` file that `Log4Net` uses to log records. We will add these configurations in two steps. 

First, add `log4net` section inside `configSections` like below.

```xml
<configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
</configSections>
```

Secondly, add the below `log4net` section in the root `configuration` node. *(**Note**: Update connection string according to your environment)*.

```xml
<log4net>
    <appender name="AdoNetAppender" type="log4net.Appender.AdoNetAppender">
      <bufferSize value="1" />
      <connectionType value="System.Data.SqlClient.SqlConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
      <connectionString value="data source=localhost;initial catalog=Log4Net_Demo;persist security info=True;user id=sa;password=yourPassword;" />
      <commandText value="INSERT INTO Log ([Date],[Thread],[Level],[Logger],[Message],[Exception]) VALUES (@log_date, @thread, @log_level, @logger, @message, @exception)" />
      <parameter>
        <parameterName value="@log_date" />
        <dbType value="DateTime" />
        <layout type="log4net.Layout.RawTimeStampLayout" />
      </parameter>
      <parameter>
        <parameterName value="@thread" />
        <dbType value="String" />
        <size value="255" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%thread" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@log_level" />
        <dbType value="String" />
        <size value="50" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%level" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@logger" />
        <dbType value="String" />
        <size value="255" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%logger" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@message" />
        <dbType value="String" />
        <size value="4000" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%message" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@exception" />
        <dbType value="String" />
        <size value="2000" />
        <layout type="log4net.Layout.ExceptionLayout" />
      </parameter>
    </appender>
    <root>
      <appender-ref ref="AdoNetAppender"/>
    </root>
</log4net>
```

> **Important**: In current post, we are using `AdoNetAppender` appender that is used to log data in SQL Server. If we want to change the target, we can use different type of log4net appender. For example, we have different types of Appenders in Log4Net.
> 
> *   AdoNetAppender
> *   FileAppender
> *   SmtpAppender
> *   [Complete List of Appenders](https://logging.apache.org/log4net/log4net-1.2.13/release/sdk/log4net.Appender.html)

The below picture will give you more clarity on where you need to place the above configurations in `web.config` file. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-11.png)

**Step 12:** Now, back in the Web API project. Open `Global.asax` file and add `XmlConfigurator.Configure();` at the end of `Application_Start` event handler. `Log4Net` uses this method to read the configurations from the config file and do its initialization stuff. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-12.png)

**Step 13:** Now, modify the code of `ValuesController` like below, just to test the `Log4Net` integration. You can also copy & paste the code from here.
```cs
public class ValuesController : ApiController
{
    private readonly ILog log = LogManager.GetLogger("API Logger");

    public IEnumerable<string> Get()
    {
        log.Info("Log Info Message");
        log.Debug("Log Debug Message");
        log.Error("Log Error Message");
        log.Warn("Log Warning Message");

        return new string[] { "value1", "value2" };
    }
}
```

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-13.png)

**Step 14:** Press the `F5` button to run the application and hit the Values controller like below. *(**Note**: Application port may vary from below picture)* 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-14.png)

**Step 15:** You will see that the application hits the break-point when you access the Values controller from the browser. And it will also log the records in your connected database. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-15.png)

**Step 16:** Just verify the data in `Logs` table by executing the script `Select * FROM [dbo].[Logs]`. You will find that all log data have been logged successfully into your SQL Server database. 

![Integrating Log4Net with ASP.NET Web API2 and SQL Server](/img/blogs/integrating-log4net-with-aspnet-web-api2-and-sql-server/log4net-integration-with-aspnet-web-api-2-with-sql-server-16.png)

That's all. Please share your comments, suggestions or feedback in below comment box.

                