Title: How to enable RabbitMQ Management Plugin in Windows
Published: 09/07/2018
Author: Ankush Jain
IsActive: true
ImageFolder: how-to-enable-rabbitmq-management-plugin-in-windows
Tags:
  - RabbitMQ
---
To enable web user interface (User Management Plugin) for RabbitMQ. Just follow 4 easy steps given below.

1.  Open the command prompt & go to below location.

    ```bash
    C:\Program Files (x86)\RabbitMQ Server\rabbitmq_server-3.2.3\sbin
    ```

    ![enter image description here](/img/blogs/how-to-enable-rabbitmq-management-plugin-in-windows/rabbitmq-user-interface-1.png)

2.  Hit below command:

    ```bash
    rabbitmq-plugins enable rabbitmq_management
    ```

    This command will actually run `rabbitmq-plugins` batch file which is present inside `sbin` folder.

    ![enter image description here](/img/blogs/how-to-enable-rabbitmq-management-plugin-in-windows/rabbitmq-user-interface-2.png)

3.  Now, restart the RabbitMQ service.   

    ![enter image description here](/img/blogs/how-to-enable-rabbitmq-management-plugin-in-windows/rabbitmq-user-interface-4.png)

4.  Go to browser & hit this URL [http://localhost:15672](http://localhost:15672) 
    
    ![enter image description here](/img/blogs/how-to-enable-rabbitmq-management-plugin-in-windows/rabbitmq-user-interface-5.png)

That's all...:)

                
