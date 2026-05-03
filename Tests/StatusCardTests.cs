using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestFramework.Pages;
using System;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("StatusCard")]
    public class StatusCardTests : BaseTest
    {
        private StatusCardPage _card;

        [SetUp]
        public void SetUp() => _card = new StatusCardPage(Driver);

        [Test, Category("Smoke")]
        public void StatusCard_IsVisible() =>
            Assert.That(_card.Container.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void StatusCard_AllMetricsRendered()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_card.Badge.Displayed, Is.True);
                Assert.That(_card.LastRun.Displayed, Is.True);
                Assert.That(_card.Conclusion.Displayed, Is.True);
                Assert.That(_card.Tests.Displayed, Is.True);
                Assert.That(_card.Duration.Displayed, Is.True);
                Assert.That(_card.Commit.Displayed, Is.True);
            });
        }

        [Test, Category("Regression")]
        public void StatusCard_PopulatesWithLiveData()
        {
            // The badge starts as "SYNCING" and resolves to PASSING / FAILURE / OFFLINE
            // once both fetches complete. Wait for it to settle.
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(8));
            wait.Until(d =>
            {
                var text = _card.Badge.Text;
                return text != "SYNCING" && !string.IsNullOrEmpty(text);
            });

            var badge = _card.Badge.Text;
            Assert.That(badge, Is.AnyOf("PASSING", "FAILURE", "OFFLINE", "PENDING"),
                $"Status badge resolved to unexpected value: {badge}");
        }

        [Test, Category("Regression")]
        public void StatusCard_CommitOrFallbackVisible()
        {
            // Commit field shows a 7-char SHA when the GitHub fetch succeeds, or "—" otherwise.
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(8));
            wait.Until(d => !string.IsNullOrEmpty(_card.Commit.Text));
            Assert.That(_card.Commit.Text, Is.Not.Empty);
        }
    }
}
