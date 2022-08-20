Title: Solution- CLUSTERDOWN Hash slot not served in case of single master failure
Published: 17/10/2018
Author: Ankush Jain
IsActive: true
ImageFolder: solution-clusterdown-hash-slot-not-served-in-case-of-single-master-failure
Tags:
  - Redis
---
If you are **not using** Redis in cluster mode or master-slave mode & still getting this error **CLUSTERDOWN Hash slot not served** then you must try the below solution. That should fix the issue.

## Solution:

Just go to the config file & change **cluster-enabled** value to **no**.

                
