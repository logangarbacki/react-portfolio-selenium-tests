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
        public void ResumeButton_IsVisible() =>
            Assert.That(_hero.ResumeButton.Displayed, Is.True);

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
            // Label is typed in via JS one char at a time (~30ms/char).
            // Full string is ~41 chars → ~1.3s total. Wait until it stops growing.
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
                Assert.That(text, Does.Contain("full-stack").IgnoreCase);
                Assert.That(text, Does.Contain("CI/CD").IgnoreCase);
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
        public void ResumeButton_LinksToResumePdf()
        {
            var href = _hero.ResumeButton.GetAttribute("href");
            Assert.That(href, Does.Contain("Logan_Garbacki_Resume.pdf").IgnoreCase);
        }
    }
}
