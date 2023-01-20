Title: Installing MySQL on Amazon Linux 2 EC2 Instance and configure it for remote connections
Published: 20/01/2023
Author: Ankush Jain
IsActive: true
ImageFolder: installing-mysql-on-amazon-linux-2-ec2-instance-and-configure-it-for-remote-connections
Tags:
  - AWS
  - Linux
  - Amazon EC2
---
In this post, you will learn how to install MySQL on an Amazon Linux EC2 instance. You will also learn, how to configure it to accept remote connections, so that you can connect MySQL server running on an EC2 from any other remote server or local machine.

## 1. Create an Amazon Linux 2 EC2 instance
In the first step, you have to create an Amazon Linux 2 EC2 instance. Though, in this post, we won't focus much on creating a Linux EC2 instance step by step. But there are certain things that you must know while provisioning the EC2 instance.

### 1.1. Make sure you select the right AMI - Amazon Linux 2 
Select the Amazon Linux 2 AMI as shown in the below picture. For CPU architecture, you can choose either x86 or ARM. In this post, I have chosen x86 as ARM instances were not available in t2 or t3 instance family.

![image](/img/blogs/installing-mysql-on-amazon-linux-2-ec2-instance-and-configure-it-for-remote-connections/1.png)

### 1.2. Make sure, the Security Group allows access on ports 22 & 3306

- Port 22 will be used for SSH
- Port 3306 will be used by the MySQL

![image](/img/blogs/installing-mysql-on-amazon-linux-2-ec2-instance-and-configure-it-for-remote-connections/2.png)

## 2. Connect with your Linux EC2 using SSH
Now that the Linux EC2 instance has been created. The next step is to establish an SSH connection with this instance.

Simply click the **Connect** button as seen in the photo below, and you will be presented with a few choices. 

![image](/img/blogs/installing-mysql-on-amazon-linux-2-ec2-instance-and-configure-it-for-remote-connections/3.png)

Select **SSH client** tab and copy the command highlighted below.

To connect with the Linux instance, issue the command in **Bash** or the **Command Line**. The `<private-key>.pem` file that you might have generated during the EC2 creation is also necessary for this command.

![image](/img/blogs/installing-mysql-on-amazon-linux-2-ec2-instance-and-configure-it-for-remote-connections/4.png)

## 3. Installing MySQL on Amazon Linux 2 EC2 instance
Now that you have established an SSH connection with the Linux EC2 instance, it's time to install the MySQL server.

We're going to install MariaDB (a fork of MySQL) because Amazon's [documentation](https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-lamp-amazon-linux-2.html) appears to recommend it over MySQL. Because MariaDB is a fork of MySQL, it supports the same features as MySQL while also adding new ones.


To install MySQL, run the commands listed below one by one. I've added enough comments before each command to make it self-explanatory.

```bash
#  this command updates all packages to the latest version
sudo yum update -y 

# this command installs MySQL server on your machine, it also creates a systemd service
sudo yum install -y mariadb-server

# this command enables the service created in previous step
sudo systemctl enable mariadb

# this command starts the MySQL server service on your Linux instance
sudo systemctl start mariadb

# this command helps you to set root user password and improve your DB security
sudo mysql_secure_installation
```

The final command, `sudo mysql_secure_installation` prompts you with a few questions, which may appear as shown below.
```bash
# Here, just hit enter as we have not set any password yet
Enter current password for root (enter for none): 

# Here, reply with Y
Set root password [Y/n]

# Enter new password
New Password:

# Re-enter new password
Re-enter new Password:

## Say Y
Remove anonymous users? [Y/n]

## Say Y
Disallow root login remotely? [Y/n]

## Say N, as we would need them for verification 
Remove test database and access to it? [Y/n] y

## Say Y
Reload privilege tables now? [Y/n] y
```

## 4. Verifying the installation
Now that you've installed MySQL server on your EC2 instance, it's time to make sure it's working properly and you are able to connect to it. So, let us begin the verification process.

To connect to the MySQL instance, run the following command.
```bash
mysql -h localhost -u root -p
```

Once connected, run below command.
```sql
SHOW DATABASES;
```
It should print the names of all the test databases. If this prints, we can assume that the MySQL server installation was successful.

## 5. Configure MySQL to accept remote connections
The MySQL server is currently only accessible within the EC2 instance. However, if you want to connect to this MySQL server from your local machine or another server, you must configure it to accept remote connections.

Follow the steps below to configure MySQL to accept remote connections.
1. Run `cd /` to go on the root directory.
2. Run `sudo nano /etc/my.cnf` to open `my.cnf` file in the nano editor.
3. Update the file to include `bind-address=0.0.0.0` line as well.
4. After update, the file looks like below.
   ![image](/img/blogs/installing-mysql-on-amazon-linux-2-ec2-instance-and-configure-it-for-remote-connections/5.png)
5. Run `sudo systemctl restart mariadb` to restart the service.
6. Now execute the following commands on the MySQL server from `root` user.
   ```sql
   CREATE USER 'ankush'@'localhost' IDENTIFIED BY 'ankushpassword';

   CREATE USER 'ankush'@'%' IDENTIFIED BY 'ankushpassword';

   GRANT ALL PRIVILEGES ON *.* to ankush@localhost IDENTIFIED BY 'ankushpassword' WITH GRANT OPTION;

   GRANT ALL PRIVILEGES ON *.* to ankush@'%' IDENTIFIED BY 'ankushpassword' WITH GRANT OPTION;

   FLUSH PRIVILEGES;

   EXIT
   ```
7. After running above command, MySQL server can be remotely accessed by entering public DNS/IP of your instance as MySQL Host Address, username as `ankush` and password as `ankushpassword`.
8. Here is a screenshot of successful connection with MySQL server running on Amazon Linux 2 EC2 instance.
   ![image](/img/blogs/installing-mysql-on-amazon-linux-2-ec2-instance-and-configure-it-for-remote-connections/6.png)

## Conclusion
In this post, we learned, how to run MySQL server on an Amazon Linux 2 EC2 instance, as well as how to configure it to accept remote connections. Please share your thoughts and feedback in the section below.

Thank You ❤️

                
