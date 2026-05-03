using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestFramework.Pages;
using System;

namespace SeleniumTestFramework
{
    /// <summary>
    /// Boot overlay tests bypass BaseTest's auto-skip query param so we can
    /// observe the actual boot sequence end-to-end.
    /// </summary>
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("BootOverlay")]
    public class BootOverlayTests
    {
        private IWebDriver _driver;
        private BootOverlayPage _boot;

        [SetUp]
        public void SetUp()
        {
            _driver = DriverUtils.CreateChromeDriver();
            // Navigate without ?skip-boot=1 so the overlay actually plays.
            _driver.Navigate().GoToUrl(TestConfig.BaseUrl);
            _boot = new BootOverlayPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }

        [Test, Category("Smoke")]
        public void BootOverlay_IsVisibleOnFreshLoad() =>
            Assert.That(_boot.IsVisible, Is.True, "Boot overlay should be visible on fresh page load");

        [Test, Category("Regression")]
        public void BootOverlay_AutoCompletes_WithinExpectedDuration()
        {
            // The boot is paced to ~3.5s — give it a little headroom for slow networks.
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            _boot.WaitForCompletion(timeoutSeconds: 8);
            stopwatch.Stop();

            Assert.Multiple(() =>
            {
                Assert.That(_boot.IsVisible, Is.False, "Boot overlay should be dismissed");
                Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(2500),
                    "Boot should take at least ~2.5s — too fast suggests it short-circuited");
                Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThanOrEqualTo(7000),
                    "Boot should complete well within 7s");
            });
        }

        [Test, Category("Regression")]
        public void BootOverlay_SkipButton_DismissesImmediately()
        {
            _boot.ClickSkip();
            // After clicking skip, the overlay fades out — wait briefly for it to clear.
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            wait.Until(d => !_boot.IsVisible);

            Assert.That(_boot.IsVisible, Is.False, "Boot overlay should disappear after clicking skip");
        }
    }
}
