Title: Solution- An unhandled exception of type 'System.BadImageFormatException' occurred in SomeService.exe.
Published: 06/02/2020
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
Please checkout the root cause and solution for below error message.

## Error Message

> **An unhandled exception of type 'System.BadImageFormatException' occurred in SomeService.exe.**
> 
>  Additional information: Could not load file or assembly 'SomeAssembly, Version=1.0.0.XXXXX, Culture=neutral, PublicKeyToken=null' or one of its dependencies. An attempt was made to load a program with an incorrect format.

## Problem (Root Cause)

It seems like you have taken the reference of any assembly whose target platform is `x64` and your current project's target platform is `x86 (32 bit)` or vice versa.

## Solution

To fix the issue, you have to make sure that your **current project** and the **DLL** your project is referencing, both should have the same **target platform**.

                