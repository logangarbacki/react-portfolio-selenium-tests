using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestFramework
{
    public static class DriverUtils
    {
        public static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");         
            options.AddArgument("--window-size=1920,1080"); 
            options.AddArgument("--no-sandbox");          
            return new ChromeDriver(options);
        }
    }
}