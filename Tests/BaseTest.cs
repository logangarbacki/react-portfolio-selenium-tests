using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumTestFramework
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void BaseSetUp()
        {
            Driver = DriverUtils.CreateChromeDriver();
            Driver.Navigate().GoToUrl(TestConfig.BaseUrl);

            ((IJavaScriptExecutor)Driver).ExecuteScript(
                "document.getAnimations().forEach(a => { try { a.finish(); } catch(e) {} });"
            );
        }

        [TearDown]
        public void BaseTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                DriverUtils.TakeScreenshot(Driver, TestContext.CurrentContext.Test.Name);
            }

            Driver?.Quit();
            Driver?.Dispose();

            foreach (var p in System.Diagnostics.Process.GetProcessesByName("chromedriver"))
            {
                try { p.Kill(); } catch { }
            }
        }
    }
}
