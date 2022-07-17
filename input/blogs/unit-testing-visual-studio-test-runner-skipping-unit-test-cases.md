Title: Unit Testing - Visual Studio Test Runner Skipping Unit Test Cases
Published: 25/05/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Yesterday when I was running my **Unit Test Cases** from **Visual Studio Test Explorer**, I found that few of my test cases have been skipped by **Visual Studio**. I wondered why it happened. Then I did some googling & found that it a piece of code in my Unit Test case which was causing **Visual Studio Test Explorer** to display status as **Skipped** instead of **Completed**.

`Assert.Inconclusive("Warning Message");
`

Yes, It was `Assert.Inconclusive()` method that was causing the issue. Whenever test runner encounter this line of code in your unit test, it marks that unit test case as skipped & displays it with a warning triangle. 

> In this case, Test Runner actually is not skipping any of your tests cases but somehow misguiding you with its status :)

                