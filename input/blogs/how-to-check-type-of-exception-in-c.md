Title: How to check type of exception in c#?
Published: 25/04/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
You can determine type of exception in c# in two ways.

## Way 1

`catch (Exception ex) 
{
    if (ex is System.ServiceModel.FaultException) 
    {
     // do something
    } 
    else if (ex is System.Web.HttpException) 
    {
     // do something
    }
}
`

## Way 2

This is useful when you don't have assembly reference of exception type. In that case, you can use string comparison.

`catch (Exception ex) 
{
     if (ex.GetType().FullName == "System.ServiceModel.FaultException") 
     {
      // do something
     } 
     else if (ex.GetType().FullName == "System.Web.HttpException") 
     {
      // do something
     }
}
`

                