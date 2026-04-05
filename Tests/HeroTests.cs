using System;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestFramework
{
    [TestFixture]
    public class HeroTests : BaseTest
    {
        private HeroPage _hero;

        [SetUp]
        public void SetUp()
        {
            _hero = new HeroPage(Driver);
        }

        [Test, Category("Smoke")]
        public void HeroTitle_IsVisible()
        {
            Assert.That(_hero.Title.Displayed, Is.True);
        }

        [Test, Category("Regression")]
        public void HeroTitle_ContainsName()
        {
            Assert.That(_hero.Title.Text, Does.Contain("Logan").And.Contain("Garbacki"));
        }

        [Test, Category("Regression")]
        public void HeroEyebrow_ContainsJobTitle()
        {
            Assert.That(_hero.Eyebrow.Text, Does.Contain("QA Engineer").IgnoreCase);
        }

        [Test, Category("Regression")]
        public void HeroTagline_IsVisible()
        {
            Assert.That(_hero.Tagline.Displayed, Is.True);
        }

        [Test, Category("Regression")]
        public void HeroTechStack_ContainsExpectedTechnologies()
        {
            var text = _hero.TechStack.Text;
            Assert.That(text, Does.Contain("Selenium"));
            Assert.That(text, Does.Contain("React"));
            Assert.That(text, Does.Contain("C#"));
        }

        [Test, Category("Smoke")]
        public void ViewWorkButton_IsVisible()
        {
            Assert.That(_hero.ViewWorkButton.Displayed, Is.True);
        }

        [Test, Category("Regression")]
        public void ClickingViewWork_NavigatesToProjectsSection()
        {
            _hero.ClickViewWork();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("#projects"));
            Assert.That(Driver.Url, Does.Contain("#projects"));
        }

        [Test, Category("Regression")]
        public void DownloadResumeButton_IsVisible()
        {
            Assert.That(_hero.DownloadResumeButton.Displayed, Is.True);
        }
    }
}