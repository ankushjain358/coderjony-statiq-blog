Title: What is Network Security Group in Azure
Published: 24/12/2020
Author: Ankush Jain
IsActive: true
ImageFolder: what-is-network-security-group-in-azure
Tags:
  - Azure
  - Security
---
**Network Security Group (NSG)** defines a set of access rules to control the incoming and outgoing traffic for an Azure Resource. We can think of it as a firewall in Azure. We can apply this NSG to either of the two levels.

*   Subnet level 
*   VM (NIC) level

NSG acts as a filter for the inbound and outbound traffic for the resource.

Any web request made to an azure resource (configured with NSG) has to pass all the filters to enter the resource, and the same applies to outgoing requests as well.

Typically, NSG rules look like this in Azure. 

![What are Network Security Groups in Azure](/img/blogs/what-is-network-security-group-in-azure/nsg.png)

                
