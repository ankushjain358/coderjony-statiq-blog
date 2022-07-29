Title: Step by Step - Creating a Virtual Machine in a Virtual Network (VNET) in Azure
Published: 14/02/2021
Author: Ankush Jain
IsActive: true
Tags:
  - Azure
  - Virtual Machine
---
In this post, we will understand how can we create a **Virtual Machine** in Azure inside a **Virtual Network (VNET)**.

### Table of Contents

*   Creating a Resource Group
*   Creating a Virtual Network and Subnet
*   Creating an Application Security Group
*   Creating a Network Security Group (NSG)
*   Creating a Virtual Machine
*   Attaching ASG to Virtual Machine
*   Connecting with Remote Desktop


## 1. Creating a Resource Group
First, create a new resource group in Azure. We will be using the same resource group for creating further resources in this tutorial.

> In Azure, **Resource Group** acts as a logical container for other Azure resources.

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/1.png)

## 2. Creating a Virtual Network and Subnet
Next, we will create a **Virtual Network (VNET)** as we can't create a VM without a VNET in Azure. So, we will first create a VNET and later put our VM inside that VNET.

> **Good to know**:
> 
> *   A VNET can have multiple subnets.
> *   Create a Subnet to divide a VNET into multiple sub-networks.
> *   In Azure, while creating a VNET, a default subnet is created automatically.

### 2.1. Creating a Virtual Network
Create a VNET in the same **Resource Group (RG)**. See the below picture, we have used the same RG that we created above. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/21.png)

### 2.2. Creating Subnet
Move on to the next tab **IP Addresses**. Here you will get the following things:
*   IP address range for the VNET
*   Default subnet

We won't modify anything here, and will go with the defaults. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/22.png)

## 3.  Creating an Application Security Group
Create an **Application Security Group (ASG)** in the same RG. 

> **Good to know**:
> 
> Purpose of creating an ASG is to get more control over security policy.
> 
>  For example, you have 6 VMs in your resource group. Out of those, 3 belongs to frontend and 3 belongs to backend.
> 
> *   Now, you can create 2 ASGs,  one for each i.e. **Frontend-ASG** & **Backend-ASG**.
> *   You can attach these ASGs to respective category Virtual Machine's **Network Interface Card**.
> *   Later, you can create 2 different NSGs with different security rules.
> *   Finally, you can attach frontend NSG <> Frontend-ASG & backend NSG <> Backend-ASG.
> 
> This ways, ASG provides you more flexibility to logically group your Azure Resources as per their nature or role, and also enables you to apply NSG or security rules at more granular level.

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/3.png)

## 4. Creating a Network Security Group (NSG)
Next, we will create an NSG that will allow 3389 port for **remote desktop** access.

### 4.1. Creating Network Security Group

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/41.png)

### 4.2. Add Inbound rule for RDP (Port 3389)

Click on **Inbound Security rules** on the left blade and click on **Add** button. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/42.png)

Now, select **Application Security Group** and allow port **3389** as shown below. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/43.png)

You can see that a rule for remote desktop access is now added to the inbound rules. This will allow RDP access to only those Virtual Machines (**Network Interface** more specifically) which are part of the selected ASG.

> A **Network Interface Card (NIC)** is a component without which a computer can not be connected over a network. NIC acts as a bridge between a computer and a computer-network.

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/44.png)

### 4.3. Attach NSG to Subnet

Now, attach the NSG that we created above to the subnet. 

> Remember, we can either attach an NSG to a **Subnet level** or an **NIC level**.

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/45.png)

## 5. Creating a Virtual Machine
Now, we will create a Virtual Machine step by step by following the wizard.

### 5.1. Create Virtual Machine

Go to the **Compute** and select **Virtual Machine**. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/51.png)

Fill out basic information as given below. Remember, to keep the RG same. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/52.png)

Next, fill out the **username and password** for the VM. Also, select **None** in **public inbound ports**, because, if you allow inbound ports from here, then it will create a new NSG, and we don't want that as we have already created one. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/53.png)

Next tab, **Disks**, select **Premium SSD**. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/54.png)

Next tab, **Networking**
- **Step 1 & 2:** Create a Public IP for the VM.
- **Step 3:** Don't attach NSG to NIC as we have already attached NSG with default subnet.
- **Step 4:** Go to the Management tab.

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/55.png)

Now click next, next and press **Review + Create** in the last tab. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/56.png)

After successful validation, click on create button. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/57.png)

Once the Virtual Machine is provisioned successfully, you will see a screen like the one below. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/58.png)

### 5.2. Revisit Resource Group
Now, let's go back to our resource group and see how many resources have been created so far. You can see that once you provision a Virtual Machine, a **Network Interface Card** and **OS Disk** resource are also provisioned in the background. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/59.png)

## 6. Attaching ASG to Virtual Machine
Now, go to the **Virtual Machine** and **Networking** tab, and click on configure ASG as per the below picture. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/510.png)

Select the ASG that we created above. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/512.png)

See that the selected ASG is now attached to the NIC of VM. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/511.png)

## 7. Connecting with Remote Desktop
Now, let's go to the Virtual Machine again and click on **connect** and download **RDP** file. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/513.png)

Double click on RDP file and enter the credential that you created in the first step of Wizard. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/514.png)

After successful authentication, you will be able to access your VM through RDP. 

![Creating a Virtual Machine in a Virtual Network (VNET) in Azure](/img/blogs/step-by-step-creating-a-virtual-machine-in-a-virtual-network-vnet-in-azure/515.png)

## Conclusion

That's how we created and configured a Virtual Machine step by step in Azure. Also, we understood the concepts of ASG and NSG, and how to leverage them to implement security.

## References
* [Azure — Application Security Group (ASG) Overview](https://medium.com/awesome-azure/azure-application-security-group-asg-1e5e2e5321c3)
* [Step-By-Step Demo Of Creating Azure Virtual Network, Subnets And Network Security Groups](https://www.c-sharpcorner.com/article/creating-azure-virtual-network-subnets-and-network-security-groups-part-1/)


                