using NUnit.Framework;
using SeleniumTestFramework.Pages;
using SeleniumTestFramework.Enums;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("Navbar")]
    public class NavbarTests : BaseTest
    {
        private NavbarPage _navbar;

        [SetUp]
        public void SetUp() => _navbar = new NavbarPage(Driver);

        [Test, Category("Smoke")]
        public void NavLogo_IsVisible() =>
            Assert.That(_navbar.Logo.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void NavStatusButton_IsVisible() =>
            Assert.That(_navbar.StatusButton.Displayed, Is.True);

        [Test, Category("Smoke")]
        [TestCase(NavSection.About)]
        [TestCase(NavSection.Projects)]
        [TestCase(NavSection.Skills)]
        [TestCase(NavSection.Resume)]
        [TestCase(NavSection.Contact)]
        public void Navigation_Works_For_All_Sections(NavSection section)
        {
            _navbar.ClickNavLink(section);
            DriverUtils.WaitForUrlContains(Driver, section.ToString().ToLower());

            Assert.That(_navbar.IsSectionVisible(section), Is.True);
            Assert.That(Driver.Url, Does.Contain(section.ToString()).IgnoreCase);
        }

        [Test, Category("Regression")]
        public void NavLogo_LinksToHome() =>
            Assert.That(_navbar.Logo.GetAttribute("href"), Does.Contain("#home").IgnoreCase);

        [Test, Category("Regression")]
        public void NavStatusButton_ShowsAvailability() =>
            Assert.That(_navbar.StatusButton.Text, Does.Contain("available").IgnoreCase);
    }
}
