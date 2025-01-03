## App Security Checklist

- Certificate
  - Check [www.ssllabs.com](https://www.ssllabs.com/ssltest) (Click the do not show box)
  - Score should be A-
  - Cert Chain Issues
  - TLS 1.3 (Cyphers)
    - TLS_AES_256_GCM_SHA384 
    - TLS_AES_128_GCM_SHA256 
  - TLS 1.2 (Cyphers)
    - TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256 
    - TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384
  - Secure Renegotiation is off
- Whitelisting
  - Limted, shouldn't include ZScaler IPs
- CSP 
  - Enable "Secure Javascript"
  - Reporting Mode should be disabled
  - Check with [csp-evaluator.withgoogle.com](https://csp-evaluator.withgoogle.com/) (may need to copy-and-paste CSP header as it will probably be blocked)
  - Trusted types should be setup
  - Check the browser console and G3.CSPReports table
- Throttles
  - Check the view 
    ```
    select * from g3.vw_Apis where total>10
    ```
  - Inividiual methods can have a multipler in G3.ServicePaths instead of a higher trottle for the whole service



