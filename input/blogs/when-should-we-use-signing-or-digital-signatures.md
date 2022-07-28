Title: When should we use Signing or Digital Signatures?
Published: 28/08/2021
Author: Ankush Jain
IsActive: true
Tags:
  - Security
---
In signing, a **Digital Signature** is shared with the recipient. The recipient uses this signature to verify the authenticity of the issuer.

👉 Digital Signature is nothing, just a string encrypted with a secure private key.

# What is Digital Signing
By definition, in signing, the issuer encrypts information with the private key and shares it with the recipient. The recipient on other hand uses the public key to decrypt the information. If decryption is successful, then the Receiver trusts the issuer, and if decryption fails, that means the message has been malformed by some attacker or untrusted party.

# Real World example
You can co-relate this digital signature with a human hand signature. For example, when you issue a cheque to someone to withdraw some money from the bank, then an employee at Bank will verify your signature to make sure that you are a genuine issuer of the cheque. If someone tries to fake your signature then he will be caught by the Bank. 

💁Though bank employees sometimes may fail to identify the fake signatures. But, here we are focusing on understanding the concept.

# How to identify the need for Digital Signing?
Whenever we feel that our users should have some mechanism to ensure that they are accessing information from genuine resources, we can consider that a use case where we can use signing to improve security.

# Use cases of Digital Signing

- **JWT Token** - Third parties such as Google, Facebook, Microsoft, or any other Identity Provider include the signature in JWT. That signature is encrypted with their private key. And once you decrypt it with their public key and decryption is successful, then you can be sure that the signature was issued by the authenticated party.

- **Webhook** - Webhook providers may include a signature in each webhook event that they send to your application endpoint. You can verify the signature in each webhook message. This allows you to verify that the events were sent by original providers.

- **SSL Certificate** - The SSL certificate is a perfect example. We submit CSR (Certificate Signing Request) to Certificate Authority such as DigiCert, ZeroSSL, etc. They use their secure private key to sign our CSR. This signed CSR (SSL Certificate) is then sent to the browser. Browser use distributed public keys by those Certificate Authorities to verify the certificate's authenticity.

Thank you!

                