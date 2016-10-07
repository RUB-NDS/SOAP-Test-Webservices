# SOAP Test Web Services
This repository contains several sample web services built with the four frameworks:
- Apache Axis2 (v1.7.3, *Apache Rampart v1.7.0*)
- Apache CXF (v3.1.7)
- Metro (v2.3.1)
- Windows Communication Foundation (*.NET* v4.6.2)

The sample web services use different WS-Security configurations. There are 8 different configurations, however some web services can't be built with all frameworks:

1. "1": This web service doesn't use any features to secure the messages. It provides two different functions to make it possible to execute the "SOAPAction Spoofing" attack. It also is the base for all other web services.
2. "Enc": This web service is based on the first one and makes use of encryption. The first child element of the SOAP-Body is encrypted.
3. "Sign": This web service adds a signature to the first web service. The signed element is the SOAP-Body.
4. "TS": This web service makes use of timestamps to "prevent" replay attacks. *Note: The timestamps are not signed so that they can be easily manipulated.*
5. "Enc+Sign": This web service is the combination of the web services 2 and 3. First the first child element of the SOAP-Body is encrypted, then the SOAP-Body is signed.
6. "Enc+TS": This web service is the combination of the web services 2 and 4. The first child element of the SOAP-Body is encrypted and a timestamp is added to the message. *Note: The timestamps are not signed so that they can be easily manipulated.*
7. "TS+Sign": This web service is the combination of the web services 3 and 4. First a timestamp is added to the message, then the SOAP-Body and the timestamp are signed.
8. "Enc+TS+Sign": This web service is the combination of the web services 2, 3 and 4. The first child element of the SOAP-Body is encrypted and a timestamp is added to the message. Afterwards the SOAP-Body and the timestamp are signed.

*All web services make use of the SOAPAction parameter and have WS-Addressing support.*

The web services can be used for tests with the web service penetration testing tool WS-Attacker (https://github.com/RUB-NDS/WS-Attacker/).

A guide that explains the set up of a test environment with the sample web services is provided in the web service attack wiki WS-Attacks.org (http://ws-attacks.org/Test_environment).
