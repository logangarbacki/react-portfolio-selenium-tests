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
        public void Nav_IsVisible() =>
            Assert.That(_navbar.Nav.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void NavName_IsVisible() =>
            Assert.That(_navbar.NavName.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void NavLinks_AreAllVisible()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_navbar.AboutLink.Displayed, Is.True);
                Assert.That(_navbar.ProjectsLink.Displayed, Is.True);
                Assert.That(_navbar.ContactLink.Displayed, Is.True);
                Assert.That(_navbar.ResumeLink.Displayed, Is.True);
            });
        }

        [Test, Category("Smoke"), Retry(2)]
        [TestCase(NavSection.About)]
        [TestCase(NavSection.Projects)]
        [TestCase(NavSection.Contact)]
        public void Navigation_Works_For_All_Sections(NavSection section)
        {
            _navbar.ClickNavLink(section);
            DriverUtils.WaitForUrlContains(Driver, section.ToString().ToLower());

            Assert.That(_navbar.IsSectionVisible(section), Is.True);
            Assert.That(Driver.Url, Does.Contain(section.ToString()).IgnoreCase);
        }

        [Test, Category("Regression")]
        public void ResumeLink_PointsToPdf() =>
            Assert.That(_navbar.ResumeLink.GetAttribute("href"),
                Does.Contain("Logan_Garbacki_Resume.pdf").IgnoreCase);

        [Test, Category("Regression")]
        public void NavName_ShowsLogan() =>
            Assert.That(_navbar.NavName.Text, Does.Contain("logan").IgnoreCase);
    }
}
