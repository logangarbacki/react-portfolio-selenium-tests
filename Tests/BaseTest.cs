using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
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
            // test-form=1 makes the contact form skip the real Formspree POST,
            // so CI doesn't send an email on every run.
            var sep = TestConfig.BaseUrl.Contains("?") ? "&" : "?";
            var url = $"{TestConfig.BaseUrl}{sep}test-form=1";
            Driver.Navigate().GoToUrl(url);

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
