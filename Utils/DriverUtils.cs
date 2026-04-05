using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

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

        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            if (driver is not ITakesScreenshot screenshotDriver) return;

            var screenshot = screenshotDriver.GetScreenshot();
            var folder = Path.Combine(AppContext.BaseDirectory, "Screenshots");
            Directory.CreateDirectory(folder);

            var fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            screenshot.SaveAsFile(Path.Combine(folder, fileName));
        }
    }
}