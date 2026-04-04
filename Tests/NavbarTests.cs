using OpenQA.Selenium;
using System;

namespace SeleniumTestFramework
{
    class NavbarTests
    {
        static void Main()
        {
            IWebDriver driver = null;

            try
            {
                driver = DriverUtils.CreateChromeDriver();
                driver.Navigate().GoToUrl("https://www.logangarbacki.dev");

                Console.WriteLine("Browser opened, navigating to site...");

                var aboutLink = driver.FindElement(By.CssSelector("a[href='#about']"));
                aboutLink.Click();
                Console.WriteLine("Clicked About link");

                if (driver.Url.Contains("#about"))
                {
                    Console.WriteLine("✅ Test Passed: URL contains #about");
                }
                else
                {
                    Console.WriteLine("❌ Test Failed: URL does NOT contain #about");
                    Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Test Failed: " + ex.Message);
                Environment.Exit(1);
            }
            finally
            {
                driver?.Quit();
                driver?.Dispose();
            }
        }
    }
}