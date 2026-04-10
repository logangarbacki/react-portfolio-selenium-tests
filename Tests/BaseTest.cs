using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using NUnit.Framework.Interfaces;
using Allure.Net.Commons;

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
            if(TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var dir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "screenshots");
                Directory.CreateDirectory(dir);
                var fileName = $"Failure_{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                var filePath = Path.Combine(dir, fileName);
                screenshot.SaveAsFile(filePath);
                AllureApi.AddAttachment("Failure Screenshot", "image/png", filePath);
                TestContext.AddTestAttachment(filePath, "Screenshot on Failure");
             }
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
