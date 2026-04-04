using OpenQA.Selenium;
using System;
using System.Threading;

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
                    driver?.Quit();
                }
                else
                {
                    Console.WriteLine("❌ Test Failed: URL does NOT contain #about");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Test Failed: " + ex.Message);
            }
            finally
            {
                driver?.Quit();
            }
        }
    }
}