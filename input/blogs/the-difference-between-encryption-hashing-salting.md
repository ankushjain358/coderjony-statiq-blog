Title: The difference between Encryption, Hashing & Salting
Published: 20/12/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
You might have heard these terms very often – Encryption, Hashing & Salting. In this post, I have tried to explain you all these terms in a very easy way.

## Encryption

Encryption is the process of converting the information from one form to another using an encryption key. Encryption also allows us to recover the original information back using the corresponding encryption key. 

*   Encryption is always done with the intention of recovering the original information back.

*   Encryption is a two-way process. It allows us to encrypt as well as decrypt the information.

*   Encryption & decryption key remains the same in case of Symmetric Encryption while in case of Asymmetric Encryption, they both are different.



## Hashing

Hashing is the process of converting information from one form to another, but in case of hashing, information is not recoverable. Once a value is hashed, we can not get the original value from it’s hashed value.

*   Hashing is always done with the intention when we do not want to get
   the original data back.

*   Hashing is a one-way process. We can only encrypt a value but can’t
   decrypt it.

*   Hashing is mostly used to store passwords. We store the hashed
   password in the database & whenever the user enters his password, we
   hash it & compare it with the hashed password stored in the database.
   If both matches, only then a user is considered authenticated.



## Salting

Salting is the process of adding additional data to the information before hashing it. For example, 

1.  **Step 1:** I want to hash my password - `Pas$w0rd`

2.  **Step 2:** My Salt is – `SALT`

3.  **Step 3:** I will append the salt with password – `Pas$w0rdSALT`

4.  **Step 4:** Now I will hash this value `Pas$w0rdSALT`



Salting with hashing makes your information more confidential & not easily hackable. 

Your Salt should always be very confidential. Though even if someone knows your salt cannot hack your information as hashing is itself very secure. But if an attacker tries various possible passwords & append your salt, then there is a possibility that he might end up with cracking the password.

                