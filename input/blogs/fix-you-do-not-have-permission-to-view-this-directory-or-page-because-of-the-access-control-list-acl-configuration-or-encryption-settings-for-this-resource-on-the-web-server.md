Title: Fix- You do not have permission to view this directory or page because of the access control list (ACL) configuration or encryption settings for this resource on the Web server.
Published: 17/05/2017
Author: Ankush Jain
IsActive: true
ImageFolder: fix-you-do-not-have-permission-to-view-this-directory-or-page-because-of-the-access-control-list-acl-configuration-or-encryption-settings-for-this-resource-on-the-web-server
Tags:
  - IIS
---
Yesterday, I uploaded one of my ASP.NET MVC application on local IIS. I got above error message when I tried to access a web page that returns pdf file.

Message was saying: 
> You do not have permission to view this directory or page because of the access control list (ACL) configuration or encryption settings for this resource on the Web server.

## Fix
1.  Open IIS.

2.  Select your application and on right panel double click on **Authentication** icon.

    ![enter image description here](/img/blogs/fix-you-do-not-have-permission-to-view-this-directory-or-page-because-of-the-access-control-list-acl-configuration-or-encryption-settings-for-this-resource-on-the-web-server/fix_1.png)

3.  You will see a list of authentication options.

4.  From the list select **Anonymous Authentication** and double click on it. A popup will open, select **Application Pool Identity** option. 
    
    ![enter image description here](/img/blogs/fix-you-do-not-have-permission-to-view-this-directory-or-page-because-of-the-access-control-list-acl-configuration-or-encryption-settings-for-this-resource-on-the-web-server/fix_2.png)

Issue will be fixed. Cheers !!

                
