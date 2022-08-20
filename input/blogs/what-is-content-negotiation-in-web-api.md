Title: What is Content Negotiation in WEB API?
Published: 19/09/2017
Author: Ankush Jain
IsActive: true
Tags:
  - Web API
---
## What is WEB API?
WEB API is a framework developed by Microsoft to build REST APIs. Building REST APIs using WEB API is very easy. 

Response provided by WEB API or a REST API can be in two formats - XML or JSON.   

## What is Content Negotiation in WEB API?
Content Negotiation is a mechanism that allows a user to decide what kind of response he want to get from the API. 

*To get JSON response pass "application/json" in Accept Header.*

*To get XML response pass "application/xml" in Accept Header.*   

 ## More Explanation
Suppose, a developer is friendly with JSON and he wants that all of the API response should be in JSON format, then he just need to send an **"Accept"** header with **"application/json"** value. Web API will read this header and will provide all the response in JSON format.

The same thing applies for XML as well. To get all response in XML format, developer need to pass **"application/xml"** in **"Accept"** header of API request.

                