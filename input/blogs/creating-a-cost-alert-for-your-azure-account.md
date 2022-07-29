Title: Creating a Cost Alert for Your Azure Account
Published: 23/04/2021
Author: Ankush Jain
IsActive: true
Tags:
  - Azure
---
In this post, we will create a **Cost Alert** for your Azure account. So, let's understand the purpose of the Cost Alert and how can it help.

## Objective of Cost Alert
The main purpose of **Cost Alert** is that you want to be aware of your Azure spending while running your Azure account. 

Let's say, you start a business and you run your website and all your services in Azure. In the beginning, you won't know exactly what will be your spending in Azure. For this, you can create a budget in Azure, and set alerts on top of that. This way you would be notified once your spending reaches your defined budget. 

Creating a **Cost Alert** in Azure simply means that you are saying - *"Hey Azure! Please notify me once my spending reaches 80%, 90%, or X% of my defined budget."* 

## Step by Step - Creating a Cost Alert

1.  Navigate to Azure Portal from [portal.azure.com](https://portal.azure.com/). Select the **subscription** you want to set alerts on. 

    ![Creating a Cost Alert for Your Azure Account](/img/blogs/creating-a-cost-alert-for-your-azure-account/1-creating-a-billing-alarm-for-your-azure-account.png)

2.  Select **Budgets** option from the left-hand side menu and click on **Add** button. 
    
    ![Creating a Cost Alert for Your Azure Account](/img/blogs/creating-a-cost-alert-for-your-azure-account/2-creating-a-billing-alarm-for-your-azure-account.png)

3.  As you can see, this is a two-step process. First, we need to create a budget and second, we need to set alerts for that budget.   

    Now, please select the **Scope** for the budget. Here, **scope** is a level at which you want to track the spending. In our case, the scope is **Subscription**, but you can also change it as per your need. [Click here](https://docs.microsoft.com/en-us/azure/role-based-access-control/scope-overview) to read more about scope. 
    
    ![Creating a Cost Alert for Your Azure Account](/img/blogs/creating-a-cost-alert-for-your-azure-account/3-creating-a-billing-alarm-for-your-azure-account.png)   

4.  Enter budget details - **Budget name, Budget creation & expiration date,** and **Budget amount**. Also, note that the currency for the budget amount will be the same as your billing currency. Here, I have put INR 5000 as my monthly development budget. 

    ![Creating a Cost Alert for Your Azure Account](/img/blogs/creating-a-cost-alert-for-your-azure-account/4-creating-a-billing-alarm-for-your-azure-account.png)

5.  In the second step, select **Alert Conditions**. Here **% of budget** says that you will be notified once your spending reaches x% of your defined budget. In my case, I have set it to 80%, which means, I will be notified once my spending reaches INR 4000.  

    Apart from this, also enter the email Id where you want to get alert notifications. 
  
    ![Creating a Cost Alert for Your Azure Account](/img/blogs/creating-a-cost-alert-for-your-azure-account/5-creating-a-billing-alarm-for-your-azure-account.png)

6.  After creating an alert, you will get a success notification. 

    ![Creating a Cost Alert for Your Azure Account](/img/blogs/creating-a-cost-alert-for-your-azure-account/6-creating-a-billing-alarm-for-your-azure-account.png)

7.  Also, you can see that a new budget is showing up on the list now. Let's select this budget to review the configuration. 

    ![Creating a Cost Alert for Your Azure Account](/img/blogs/creating-a-cost-alert-for-your-azure-account/7-creating-a-billing-alarm-for-your-azure-account.png)

8.  Review and verify that all the details on this page are the same as you entered earlier. 

    ![Creating a Cost Alert for Your Azure Account](/img/blogs/creating-a-cost-alert-for-your-azure-account/8-creating-a-billing-alarm-for-your-azure-account.png)

9.  This is an **Example Alert Email Notification** that you will receive as a **Budget Alert** from Azure. 

    ![Creating a Cost Alert for Your Azure Account](/img/blogs/creating-a-cost-alert-for-your-azure-account/9-creating-a-billing-alarm-for-your-azure-account.png)

Great! We're all done. That's all with this post. I hope this would be helpful to you.

                