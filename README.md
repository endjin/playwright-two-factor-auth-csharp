# Playwright 2FA Authentication with Entra ID (AAD) or MSA

This sample demonstrates how to use the Playwright C# SDK to automatically authenticate against a web application which is protected by either Entra Id (Azure Active Directory) or a Microsoft Account which has two-factor authentication.

Read the [full walkthrough blog post](https://endjin.com/blog/2023/03/using-the-playwright-csharp-sdk-to-automate-2fa-authentication-for-aad-and-msa).

### Environment Variables

Add the following:

```
PLAYWRIGHT_AAD_ACCOUNT_USERNAME
PLAYWRIGHT_AAD_ACCOUNT_PASSWORD
PLAYWRIGHT_AAD_ACCOUNT_TOTP
PLAYWRIGHT_MSA_ACCOUNT_USERNAME
PLAYWRIGHT_MSA_ACCOUNT_PASSWORD
PLAYWRIGHT_MSA_ACCOUNT_TOTP
```

TOTP values should be the Secret key from the 2FA set up step.

You will need to restart Visual Studio for the settings to be picked up.

## Licenses

[![GitHub license](https://img.shields.io/badge/License-Apache%202-blue.svg)](https://raw.githubusercontent.com/endjin/playwright-two-factor-auth-csharp/main/LICENSE)

This sample is available under the Apache 2.0 open source license.

For any licensing questions, please email [&#108;&#105;&#99;&#101;&#110;&#115;&#105;&#110;&#103;&#64;&#101;&#110;&#100;&#106;&#105;&#110;&#46;&#99;&#111;&#109;](&#109;&#97;&#105;&#108;&#116;&#111;&#58;&#108;&#105;&#99;&#101;&#110;&#115;&#105;&#110;&#103;&#64;&#101;&#110;&#100;&#106;&#105;&#110;&#46;&#99;&#111;&#109;)

## Project Sponsor

This project is sponsored by [endjin](https://endjin.com), a UK-based technology consultancy who are corporate sponsors of the .NET Foundation.

For more information about our products and services, or for commercial support of this project, please [contact us](https://endjin.com/contact-us). 

We produce two free weekly newsletters; [Azure Weekly](https://azureweekly.info) for all things about the Microsoft Azure Platform, and [Power BI Weekly](https://powerbiweekly.info).

Keep up with everything that's going on at endjin via our [blog](https://blogs.endjin.com/), follow us on [Twitter](https://twitter.com/endjin), or [LinkedIn](https://www.linkedin.com/company/1671851/).

Our other Open Source projects can be found on [GitHub](https://github.com/endjin)

## Code of conduct

This project has adopted a code of conduct adapted from the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community. This code of conduct has been [adopted by many other projects](http://contributor-covenant.org/adopters/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [&#104;&#101;&#108;&#108;&#111;&#064;&#101;&#110;&#100;&#106;&#105;&#110;&#046;&#099;&#111;&#109;](&#109;&#097;&#105;&#108;&#116;&#111;:&#104;&#101;&#108;&#108;&#111;&#064;&#101;&#110;&#100;&#106;&#105;&#110;&#046;&#099;&#111;&#109;) with any additional questions or comments.
