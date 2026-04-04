using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestFramework
{
    public static class DriverUtils
    {
        public static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // visible browser
            // do NOT add "--headless"
            return new ChromeDriver(options);
        }
    }
}