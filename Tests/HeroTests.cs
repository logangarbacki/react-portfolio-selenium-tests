using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumTestFramework.Pages;
using System;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("Hero")]
    public class HeroTests : BaseTest
    {
        private HeroPage _hero;

        [SetUp]
        public void SetUp() => _hero = new HeroPage(Driver);

        [Test, Category("Smoke")]
        public void HeroSection_IsVisible() =>
            Assert.That(_hero.Section.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void HeroName_IsVisible() =>
            Assert.That(_hero.Name.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void ViewProjectsButton_IsVisible() =>
            Assert.That(_hero.ViewProjectsButton.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void ContactButton_IsVisible() =>
            Assert.That(_hero.ContactButton.Displayed, Is.True);

        [Test, Category("Regression")]
        public void HeroName_ContainsLoganGarbacki()
        {
            // Name renders as per-character spans, so use innerText to flatten.
            var text = DriverUtils.GetInnerText(Driver, _hero.Name);
            Assert.That(text, Does.Contain("Logan").And.Contain("Garbacki"));
        }

        [Test, Category("Regression")]
        public void HeroLabel_ContainsRoleAndLocation()
        {
            // Label now renders statically (the typed-in animation was removed);
            // wait until it's present and contains the location.
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d =>
            {
                var t = DriverUtils.GetInnerText(d, _hero.Label);
                return t.IndexOf("long island", StringComparison.OrdinalIgnoreCase) >= 0;
            });

            var text = DriverUtils.GetInnerText(Driver, _hero.Label);
            Assert.Multiple(() =>
            {
                Assert.That(text, Does.Contain("qa").IgnoreCase);
                Assert.That(text, Does.Contain("developer").IgnoreCase);
                Assert.That(text, Does.Contain("long island").IgnoreCase);
            });
        }

        [Test, Category("Regression")]
        public void HeroSummary_DescribesBreadthOfWork()
        {
            var text = _hero.Summary.Text;
            Assert.Multiple(() =>
            {
                Assert.That(text, Does.Contain("QA").IgnoreCase);
                Assert.That(text, Does.Contain("Selenium").IgnoreCase);
                Assert.That(text, Does.Contain("deploy").IgnoreCase);
            });
        }

        [Test, Category("Regression"), Retry(2)]
        public void ClickingViewProjects_NavigatesToProjectsAnchor()
        {
            _hero.ClickViewProjects();
            DriverUtils.WaitForUrlContains(Driver, "#projects");
            Assert.That(Driver.Url, Does.Contain("#projects"));
        }

        [Test, Category("Regression")]
        public void GetInTouchButton_LinksToContact()
        {
            Assert.That(_hero.ContactButton.GetAttribute("href"), Does.Contain("#contact"));
        }
    }
}
