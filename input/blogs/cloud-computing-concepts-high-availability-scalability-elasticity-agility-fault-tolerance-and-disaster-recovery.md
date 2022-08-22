Title: Cloud Computing Concepts - High Availability, Scalability, Elasticity, Agility, Fault Tolerance and Disaster Recovery
Published: 29/12/2020
Author: Ankush Jain
IsActive: true
ImageFolder: cloud-computing-concepts-high-availability-scalability-elasticity-agility-fault-tolerance-and-disaster-recovery
Tags:
  - Azure
  - AWS
---
Compute Power & Storage are the two most basic services provided by all cloud providers.
*   **Compute Power**  - Compute Power is how much processing your computer can do. *i.e. RAM, Processor*
*   **Storage** -  Storage is the volume of data that you can store on your computer. *i.e. Hard Drive*


# What is Cloud Computing

Delivery of services like **compute, storage** and **networking** over the internet is known as **Cloud Computing**, and the provider of such services is known as **Cloud Provider**.

# Cloud Concepts
Below are major cloud concepts in Azure or any other cloud platform.
*   Scalability
*   Elasticity
*   Agility
*   Fault Tolerance 
*   Disaster Recovery
*   High Availability


### Scalability
Scalability is the ability of a system to scale to support the desired workload. 

> Scaling is the process of of allocating (adding) and deallocating (removing) resources to support desired workload.

There are 2 types of scaling:
- **Vertical Scaling**: In this type of scaling, compute capacity of an existing resource is increased by adding more compute power (RAM or CPU) to support increased workload. Later, the same can be reduced when the workload decreases. Adding more compute power is **scaling-up**, and reducing the same is **scaling-down**.

- **Horizontal Scaling**: In this type of scaling, compute capacity can be increased by adding more instances to support increased workload. Similarly, we can reduce the active instances once the workload goes down. Adding more instances to scale is **scaling-out**, and reducing the number of instances is **scaling-in**.

### Elasticity
Elasticity is the ability of the system to scale automatically. Elasticity is basically auto-scaling.

### Agility
Agility is the ability to react quickly. 

In the cloud, it takes a minute or two to create a Virtual Machine that is up and running. On the other hand, it takes days or weeks when we submit a request to purchase a physical server and by when it gets delivered.

Agility enables users to be able to allocate and deallocate resources very quickly, and that is a huge benefit of the cloud.

### Fault Tolerance
Fault Tolerance is the ability of a system to remain up and running during component and service failure. 

For example, your application hosted on an App Service, VM or any other compute service, should remain up and running even if underlying server hardware fails. 

A fault-tolerant cloud system will be able to manage to quickly shift to another copy of the server in the data center whenever any failure is identified.

### Disaster Recovery
Disaster Recovery is the ability of a system to recover from a disaster such as floods, thunder-storm, earth-quake, or any other natural or human-induced disaster that has destroyed the primary data center.

By taking advantage of azure backups (GRS - Geo-redundant), deploying your applications in multiple regions, and data-replication in another region, you can confidently build apps knowing that your data is safe in case of any disaster occurs.

Below are 3 main application components, and respective DR methods.

*   Web Applications - Deploy in multiple regions
*   Database - Enable GRS backups and Geo-replication
*   Storage - Enable Geo-replication

### High Availability
High Availability is the ability of the system to be up and running with very little (planned or unplanned) downtime. Azure offers SLA (Service Level Agreement) for every azure resource for High Availability.

High Availability can be calculated by a simple formula: HA = Up Time / Life Time
