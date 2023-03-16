// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Microsoft.Playwright;
using OtpNet;

public static class Program
{
    public static async Task Main(string[] args)
    {
        /*
        NOTE: In production scenarios you should keep the credentials & secrets in Key Vault NOT Environment Variables.
        */

        using IPlaywright playwright = await Playwright.CreateAsync();
        await using IBrowser browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 2000 // Add pause to each step so that you can see automation in action!
        });

        // Configure AAD 2FA: https://mysignins.microsoft.com/security-info
        await AadSignIn(browser);

        // Configure MSA 2FA: https://account.microsoft.com/security
        await MsaSignIn(browser);
    }

    private static async Task AadSignIn(IBrowser browser)
    {
        IBrowserContext context = await browser.NewContextAsync();
        IPage page = await context.NewPageAsync();

        await page.GotoAsync("https://mysignins.microsoft.com/security-info");

        await page.GetByPlaceholder("Email address or phone number").FillAsync(Environment.GetEnvironmentVariable("PLAYWRIGHT_AAD_ACCOUNT_USERNAME")!);
        await page.GetByRole(AriaRole.Button, new() { Name = "Next" }).ClickAsync();

        // There seem to be different sign-in UIs, you may need this step, depending on the site you're signing into
        // await page.GetByRole(AriaRole.Button, new() { NameRegex = new Regex("Work or school account Created by your IT department", RegexOptions.IgnoreCase) }).ClickAsync();
        await page.Locator("#i0118").FillAsync(Environment.GetEnvironmentVariable("PLAYWRIGHT_AAD_ACCOUNT_PASSWORD")!);
        await page.Locator("#i0118").PressAsync("Enter");

        await page.GetByRole(AriaRole.Textbox, new() { Name = "Enter code" }).FillAsync(GenerateTwoFactorAuthCode(Environment.GetEnvironmentVariable("PLAYWRIGHT_AAD_ACCOUNT_TOTP")!));
        await page.GetByLabel("Don't ask").CheckAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "Verify" }).ClickAsync();
        await page.GetByText("Don't show this again").ClickAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "Yes" }).ClickAsync();
    }

    private static async Task MsaSignIn(IBrowser browser)
    {
        IBrowserContext context = await browser.NewContextAsync();
        IPage page = await context.NewPageAsync();

        await page.GotoAsync("https://login.live.com/");
        await page.GetByPlaceholder("Email, phone or Skype").FillAsync(Environment.GetEnvironmentVariable("PLAYWRIGHT_MSA_ACCOUNT_USERNAME")!);
        await page.GetByRole(AriaRole.Button, new() { Name = "Next" }).ClickAsync();

        // There seem to be different sign-in UIs, you may need this step, depending on the site you're signing into
        // await page.GetByRole(AriaRole.Button, new() { NameRegex = new Regex("Personal account Created by you", RegexOptions.IgnoreCase) }).ClickAsync();
        await page.GetByPlaceholder("Password").FillAsync(Environment.GetEnvironmentVariable("PLAYWRIGHT_MSA_ACCOUNT_PASSWORD")!);
        await page.GetByRole(AriaRole.Button, new() { Name = "Sign in" }).ClickAsync();
        await page.GetByPlaceholder("Code").FillAsync(GenerateTwoFactorAuthCode(Environment.GetEnvironmentVariable("PLAYWRIGHT_MSA_ACCOUNT_TOTP")!));
        await page.GetByLabel("Don't ask me again on this device").CheckAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "Verify" }).ClickAsync();
        await page.GetByText("Don't show this again").ClickAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "Yes" }).ClickAsync();
    }

    private static string GenerateTwoFactorAuthCode(string secret)
    {
        Totp totp = new(secretKey: Base32Encoding.ToBytes(secret));
        
        return totp.ComputeTotp();
    }
}