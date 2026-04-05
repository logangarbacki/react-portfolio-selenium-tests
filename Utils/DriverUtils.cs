using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
        public static IWebElement Find(IWebDriver driver, By by, int timeoutSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));

            var element = wait.Until(d => d.FindElement(by));

            ((IJavaScriptExecutor)driver).ExecuteScript(
                "arguments[0].scrollIntoView({behavior:'instant', block:'center'});", element);

            wait.Until(d => !string.IsNullOrEmpty(element.Text));

            return element;
        }
        
    }
}