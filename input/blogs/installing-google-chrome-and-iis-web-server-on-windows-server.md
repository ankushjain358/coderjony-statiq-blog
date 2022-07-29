Title: Installing Google Chrome and IIS Web Server on Windows Server
Published: 22/05/2021
Author: Ankush Jain
IsActive: true
Tags:
  - IIS
  - Windows Server
---
Installing **Google Chrome** and **IIS Web Server** are the 2 most basic tasks that I do whenever I create a new Windows Server machine either on the Cloud or On-Premises.

> Windows Server ships with an Internet Explorer that is configured with `Internet Explorer Enhanced Security Configuration`. These configurations somehow don't allow us to download any file or browse any modern JavaScript-enabled website. So, in such cases, it becomes necessary to download some web browser that we could use as we normally do. I recommend Google Chrome personally.

So, in this post we will do the following on a Windows Server:
*   Download & Install Google Chrome
*   Install IIS Web Server and IIS Manager


So, let's start.

## Download & Install Google Chrome

**Step 1:** Log into the Server via RDP.

**Step 2:** Open **Windows PowerShell** and run the below script.

```powershell
$LocalTempDir = $env:TEMP; $ChromeInstaller = "ChromeInstaller.exe"; (new-object    System.Net.WebClient).DownloadFile('http://dl.google.com/chrome/install/375.126/chrome_installer.exe', "$LocalTempDir\$ChromeInstaller"); & "$LocalTempDir\$ChromeInstaller" /silent /install; $Process2Monitor =  "ChromeInstaller"; Do { $ProcessesFound = Get-Process | ?{$Process2Monitor -contains $_.Name} | Select-Object -ExpandProperty Name; If ($ProcessesFound) { "Still running: $($ProcessesFound -join ', ')" | Write-Host; Start-Sleep -Seconds 2 } else { rm "$LocalTempDir\$ChromeInstaller" -ErrorAction SilentlyContinue -Verbose } } Until (!$ProcessesFound)
```

This script will download & install Google Chrome in a few seconds. 

You will see a screen like the below during the installation. And after the installation, it will create a **Google Chrome** shortcut on the desktop as you can see in the below picture. 

![Installing Google Chrome and IIS Web Server on Windows Server](/img/blogs/installing-google-chrome-and-iis-web-server-on-windows-server/1-installing-google-chrome-and-iis-on-windows-server.png)

Google Chrome is now successfully installed on your machine.   

## Install IIS Web Server and IIS Manager

**Step 1:** Log into the Server via RDP.

**Step 2:** Open **Windows Powershell** and run the below command to install **Web Server (IIS)**.

```powershell
Install-WindowsFeature -Name Web-Server
```

![Installing Google Chrome and IIS Web Server on Windows Server](/img/blogs/installing-google-chrome-and-iis-web-server-on-windows-server/2-installing-google-chrome-and-iis-on-windows-server.png)

To verify the IIS installation, open Google Chrome, and type **http://localhost**.

![Installing Google Chrome and IIS Web Server on Windows Server](/img/blogs/installing-google-chrome-and-iis-web-server-on-windows-server/3-installing-google-chrome-and-iis-on-windows-server.png)

**Step 3:** Now run the below command to install **IIS Management tools**.

```powershell
Install-WindowsFeature -Name Web-Mgmt-Tools
```

 ![Installing Google Chrome and IIS Web Server on Windows Server](/img/blogs/installing-google-chrome-and-iis-web-server-on-windows-server/4-installing-google-chrome-and-iis-on-windows-server.png)

To verify this, just type **IIS** in the search box and see if **IIS Manager** appears in the search result like below or not. 

![Installing Google Chrome and IIS Web Server on Windows Server](/img/blogs/installing-google-chrome-and-iis-web-server-on-windows-server/5-installing-google-chrome-and-iis-on-windows-server.png)

That's all.

This is how we can easily install **Google Chrome** and **Web Server (IIS)** on any Windows Server machine. Hope this post will help you.

                