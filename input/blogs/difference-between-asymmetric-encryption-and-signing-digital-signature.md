Title: Difference between Asymmetric Encryption and Signing (Digital Signature)
Published: 07/08/2020
Author: Ankush Jain
IsActive: true
Tags:
  - Security
  - Cryptography
---
I often get confused between Encryption and Signing as both processes use the public key and private key. So, I thought to write a blog post about it so that I can look up to it the next time I get confused.

## Difference between Asymmetric Encryption and Signing

-   **For Asymmetric Encryption**, the sender uses a public key to encrypt the data and the receiver uses the private key to decrypt the encrypted data.

-   **For Signing**, the sender uses the private key to create the message's signature and the receiver uses the public key to verify the signature. 

    If the signature is verified, then we can say that the message we have received is accurate and has not been altered or hampered in between.

    Some of the examples where signing is used are - SSL Certificates, JWT Tokens, etc.

Now let's understand each one by one.

## 1. Asymmetric Encryption
Asymmetric Encryption is a process of encrypting the message with the public key and getting back the original message by decrypting the encrypted message with the private key. 

### Key Points
- The private key is owned by the receiver.
- The public key is shared with other parties that want to send the sensitive data to the recipient.

![How encryption works](/img/blogs/difference-between-asymmetric-encryption-and-signing-digital-signature/how-encryption-works.png)

### Symmetric vs Asymmetric Encryption
- Here we are talking about **Asymmetric Encryption**.
- Symmetric Encryption uses the same key for both encryption and decryption.
- Asymmetric Encryption uses both public and private keys. The public key for encryption and the private key for decryption.

## 2. Signing / Digital Signature
The process of signing begins with creating the cryptographic hash of the message known as a digest and then encrypting this digest with the sender's private key to generate the signature (signed digest). This signature is then sent along with the actual message.

On the receiver side, the receiver decrypts the signature (signed digest) with the public key and gets the digest, creates a digest again from the message itself, and compares both. If they both match, then it guarantees that the integrity of the message is intact.

### Key Points
- The private key is owned by the issuer.
- The public key is shared with other parties that want to verify the signature.

### How signing works
Let's try to understand the process of signing. Suppose, you have a message (plain text or a file) and you need to sign it. After signing it, you need to send it to the other end where the signature can be verified. For this, we will follow the below steps.

### On the sender's side
- **Step 1**: Apply hash on the message using any hash algorithm such as MD5, SHA and create a message digest
- **Step 2**: Encrypt the message digest with the private key to get the signature
- **Step 3**: Send both - the message and its signature to the receiver's end

> **Message Digest** - Message Digest is basically the result of some hashing. Hashing is used to limit a variable-length message into a fixed-length message.

![How signing /digital signature works](/img/blogs/difference-between-asymmetric-encryption-and-signing-digital-signature/how-signing-works-sender.png)

One of the important things to know about signing is that it carries two things - one is the actual message (payload) and the other is its signature. While in encryption, only encrypted data is sent.

### On the receiver's side
- **Step 1**: Receiver will receive two things - a message & its signature
- **Step 2**: Apply hash on the message using the same hash algorithm used earlier and create a message digest
- **Step 3**: Decrypt the signature with the public key to get an unsigned message digest
- **Step 4**: Now, compare both digests. Ideally, both should match if everything is fine, otherwise, they won't match.

![How signing /digital signature works](/img/blogs/difference-between-asymmetric-encryption-and-signing-digital-signature/how-signing-works-receiver.png)

### Why use signing?
Signing is more about data integrity. Though data is sent in clear along with its signature. But even if someone tries to manipulate it, then his effort will go in vain. Because at the receiver's end, the signature of new modified data will not match with the signature that is coming along with the message. Because both signatures use two different keys.

## References:
- [Message digest & digital signature](https://pt.slideshare.net/dkodam92/message-digest-digital-signature/)
- [What is the difference between encrypting and signing in asymmetric encryption?](https://stackoverflow.com/a/454103/1273882)
- [What does “signing” a file really mean?](https://security.stackexchange.com/a/198428)