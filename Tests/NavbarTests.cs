using NUnit.Framework;
using SeleniumTestFramework.Pages;
using SeleniumTestFramework.Enums;

namespace SeleniumTestFramework
{
    [TestFixture]
    public class NavbarTests : BaseTest
    {
        private NavbarPage _navbar;

        [SetUp]
        public void SetUp() => _navbar = new NavbarPage(Driver);

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
    }
}
