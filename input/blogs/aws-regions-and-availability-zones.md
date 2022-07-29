Title: AWS Regions and Availability Zones
Published: 06/08/2020
Author: Ankush Jain
IsActive: true
Tags:
  - AWS
---
AWS has many data centers in various geographic locations on this earth. AWS has categorized them into the regions and then further in availability zones.

![AWS Regions and Availability Zones](/img/blogs/aws-regions-and-availability-zones/aws.png)

## Regions
Regions are the physical locations around the world where AWS has its data centers. 

But AWS does not keep a single data center in a region, instead, it keeps multiple data centers inside a region and those data centers are further grouped to make an Availability Zone. 

It means that a Region can have multiple Availability Zones and each Availability Zone can further have one or more datacenter.

## Availability Zones
An Availability Zone can be considered as a collection of one more data center inside the same region. 

### Key Points
- All AZs within the same region are interconnected with high internet bandwidth and low latency networking.
- Each AZ is physically separated by another AZ within the same region, but all AZs are within 100 KM of each other. This guarantees that failure of any one AZ due to any natural crisis such as flood, thunderstorm, earthquake, or any human error would not affect the other one.


### Deploying applications and databases in multiple AZs has certain benefits
- **Increased availability** - High availability because of fault-tolerant behavior. For example, even if one AZ was destroyed completely due to some natural disaster, your data will be secure and remain available in other AZ.
- **Scalability** - Scalability due to load distribution.
- **Automatic failover to standby (Database)** – Automatic failover to standby. (A failover is done when the primary database fails or has become unreachable and one of the standby databases is transitioned to take over the primary role.)


                