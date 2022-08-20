Title: How to use live domain for your localhost websites running in IIS
Published: 01/05/2018
Author: Ankush Jain
IsActive: true
ImageFolder: how-to-use-live-domain-for-your-localhost-websites-running-in-iis
Tags:
  - IIS
---
In this blog I am going to show you how you can use live domains for the websites which are running on your local IIS.

Yes, this is possible & is quite useful when you want to test your application for live scenarios without actually going live.

> For example: You want to test payment gateway functionality in your app. All payment gateway first takes user to their website & later redirect them to their own website. In this case, you can capture the user's request once he comes back on your website & debug your application, read the query string parameters sent by Payment Gateway's website.

## Steps to use live domain for your local website

1.  Go to host file location & open it in any editor with Administrator mode. (Remember to open it administrator mode otherwise you won't be able to modify your host file.)

2.  Host file location in windows will be **C:\Windows\System32\drivers\etc**.

3.  Add this entry `127.0.0.1 www.mylivewebsite.com` in the end of host file. 

    > Host file works as your local DNS. Any web request you make in your browser first goes to host file, it checks if domain name is present there then it uses that domain name and redirect to respective IP address.

    Here we have given IP Address of localhost. So, whenever you hit `www.mylivewebsite.com`, your browser will forward the request to your local IIS. Now it's responsibility of local IIS to respond on this request.

    ![host file](/img/blogs/how-to-use-live-domain-for-your-localhost-websites-running-in-iis/host-file.png)

4.  Now, open IIS & create a new website from left panel. Fill all the required information in **Add Website** popup. You can see below picture for reference. Here, the most import thing is Binding section. You should put IP Address as `127.0.0.1` & Host Name to the domain name which you want to run your website on. Here, I have put it `www.mylivewebsite.com`.   

    ![enter image description here](/img/blogs/how-to-use-live-domain-for-your-localhost-websites-running-in-iis/live-domain-for-local-website-in-iis.png)

5.  Till now, we have made changes in host file & have also created a website in IIS. 

6.  Now, we have to make sure that whenever we type `www.mylivewebsite.com` in browser, it should point to localhost. To ensure this we have to open command prompt & type `ping www.mylivewebsite.com`. If we get reply from 127.0.0.1 then we are on right track. If not, then we may try below options. \

  - Hit this command in command prompt `ipconfig /flushdns`. 
  - Try by closing the browser & reopening it. 
  - Try again by pinging the domain in command prompt .   
 
    Now it might also happen that your are getting reply from `127.0.0.1` from ping command `ping www.mylivewebsite.com` but your site is not working on live domain. In that case, you may try to open the same domain in different browser as like Edge or Internet Explorer etc. 
    
    ![enter image description here](/img/blogs/how-to-use-live-domain-for-your-localhost-websites-running-in-iis/ping-live-domain.png) 
