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
            var js = (IJavaScriptExecutor)driver;

            return wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(by);
                    js.ExecuteScript("arguments[0].scrollIntoView({block:'center'});", el);
                    return el.Displayed ? el : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }

        public static void WaitForUrlContains(IWebDriver driver, string fragment, int timeoutSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(d => d.Url.Contains(fragment, StringComparison.OrdinalIgnoreCase));
        }
    }
}
