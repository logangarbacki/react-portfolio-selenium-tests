using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTestFramework
{
    [TestFixture]
    public class NavbarTests : BaseTest
    {
        private NavbarPage _navbarPage;

        [SetUp]
        public void SetUp()
        {
            _navbarPage = new NavbarPage(Driver);
        }

        [Test]
        [Category("Smoke")]
        public void ClickingAboutLink_NavigatesToAboutSection()
        {
            _navbarPage.ClickAbout();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("#about"));
            Assert.That(Driver.Url, Does.Contain("#about"));
        }

        [Test]
        [Category("Smoke")]
        public void ClickingContactLink_NavigatesToContactSection()
        {
            _navbarPage.ClickContact();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("#contact"));
            Assert.That(Driver.Url, Does.Contain("#contact"));
        }
    }
}