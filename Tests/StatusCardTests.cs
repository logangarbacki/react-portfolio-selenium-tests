using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumTestFramework.Pages;
using System;
using System.Text.RegularExpressions;

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

        // The status word starts as "Checking" and settles once the GitHub and
        // Allure fetches finish. Returns the settled word.
        private string WaitForSettledBadge()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(8));
            wait.Until(d =>
            {
                var text = _card.Badge.Text;
                return !string.IsNullOrEmpty(text) && text != "Checking";
            });
            return _card.Badge.Text;
        }

        private void SkipIfOffline(string badge)
        {
            if (badge.Equals("Offline", StringComparison.OrdinalIgnoreCase))
                Assert.Inconclusive("GitHub API was unreachable, so run details aren't shown.");
        }

        [Test, Category("Smoke")]
        public void StatusCard_IsVisible() =>
            Assert.That(_card.Container.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void StatusCard_AllMetricsRendered()
        {
            SkipIfOffline(WaitForSettledBadge());
            Assert.Multiple(() =>
            {
                Assert.That(_card.Badge.Displayed, Is.True);
                Assert.That(_card.Tests.Displayed, Is.True);
                Assert.That(_card.LastRun.Displayed, Is.True);
                Assert.That(_card.Duration.Displayed, Is.True);
                Assert.That(_card.Commit.Displayed, Is.True);
                Assert.That(_card.Strip.Displayed, Is.True);
            });
        }

        [Test, Category("Regression")]
        public void StatusCard_PopulatesWithLiveData()
        {
            var badge = WaitForSettledBadge();
            // Vocabulary: Passing, Failing, Offline, or "N known-fail"
            // (GitHub concluded success but the Allure report has failures).
            Assert.That(badge, Does.Match("Passing|Failing|Offline|known-fail").IgnoreCase,
                $"Status resolved to an unexpected value: {badge}");
        }

        [Test, Category("Regression")]
        public void StatusCard_ShowsShortCommitHash()
        {
            SkipIfOffline(WaitForSettledBadge());
            Assert.That(_card.Commit.Text, Does.Match("^[0-9a-f]{7}$"));
        }

        [Test, Category("Regression")]
        public void TestStrip_HasOneSquarePerTest()
        {
            WaitForSettledBadge();
            // metric-tests reads "<passed> of <total>"
            var match = Regex.Match(_card.Tests.Text, @"(\d+)\s+of\s+(\d+)");
            Assert.That(match.Success, Is.True, $"Unexpected test count text: {_card.Tests.Text}");
            var total = int.Parse(match.Groups[2].Value);
            Assert.That(_card.StripCells.Count, Is.EqualTo(total),
                "The strip should draw exactly one square per test in the report");
        }
    }
}
