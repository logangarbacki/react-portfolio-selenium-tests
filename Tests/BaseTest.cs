using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumTestFramework
{
    [Parallelizable(ParallelScope.Fixtures)]
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

            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
