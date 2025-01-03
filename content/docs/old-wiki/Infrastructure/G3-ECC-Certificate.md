# Certificates

## ECC for internal API authentication JWTs

Create a custom cert request via MMC
Proceed without enrolment policy (won't auto renew because there isn't a template for what I want yet)
Set Properties
- Friendly Name > G3ApiAuth-UAT
- Key Usage > Digital Signature, Key Encipherment, Data Encipherment (b0)
- Private Key
  - Crypto Service Provider > ECDH_P256, Microsoft Software Key Storage Provider
  - Make private key exportable
