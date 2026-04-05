using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumTestFramework
{
    public static class DriverUtils
    {
        public static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            return new ChromeDriver(service, options);
        }
    }
}