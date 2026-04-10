using NUnit.Framework;
using SeleniumTestFramework.Pages;
using SeleniumTestFramework.Enums;
using System.Linq;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("Negative")]
    public class NegativeTests : BaseTest
    {
        private NavbarPage _navbar;
        private ProjectsPage _projects;
        private SkillsPage _skills;
        private ContactPage _contact;
        private ResumePage _resume;

        [SetUp]
        public void SetUp()
        {
            _navbar   = new NavbarPage(Driver);
            _projects = new ProjectsPage(Driver);
            _skills   = new SkillsPage(Driver);
            _contact  = new ContactPage(Driver);
            _resume   = new ResumePage(Driver);
        }

        [Test, Category("Negative")]
        public void Navbar_DoesNotHave_HeroLink()
        {
            // The hero section (id="home") intentionally has no navbar link.
            var heroLink = Driver.FindElements(
                OpenQA.Selenium.By.CssSelector("nav.navbar a[href='#hero']")
            );
            Assert.That(heroLink, Is.Empty, "Navbar should not contain a #hero link");
        }

        [Test, Category("Negative")]
        public void ProjectTitles_AreUnique()
        {
            var titles = Enumerable.Range(1, 3)
                .Select(i => _projects.ProjectTitle(i).Text)
                .ToList();

            Assert.That(titles, Is.Unique, "Each project title should be distinct");
        }

        [Test, Category("Negative")]
        public void ProjectYears_AreNotPlaceholders()
        {
            Assert.Multiple(() =>
            {
                for (int i = 1; i <= 3; i++)
                    Assert.That(_projects.ProjectYear(i).Text, Does.Not.Contain("0000"),
                        $"Project {i} year should not be a placeholder");
            });
        }

        [Test, Category("Negative")]
        public void SkillGroupHeaders_AreUnique()
        {
            var headers = Enumerable.Range(1, 4)
                .Select(i => _skills.SkillGroupHeader(i).Text)
                .ToList();

            Assert.That(headers, Is.Unique, "Each skill group header should be distinct");
        }

        [Test, Category("Negative")]
        public void ContactEmail_IsNotPlaceholder()
        {
            var href = _contact.EmailLink.GetAttribute("href");
            Assert.Multiple(() =>
            {
                Assert.That(href, Does.Not.Contain("example.com"), "Email should not be a placeholder");
                Assert.That(href, Does.Not.EqualTo("mailto:"), "Email href should not be empty mailto");
            });
        }

        [Test, Category("Negative")]
        public void DownloadButton_HrefIsNotBroken()
        {
            var href = _resume.DownloadButton.GetAttribute("href");
            Assert.Multiple(() =>
            {
                Assert.That(href, Is.Not.Null.And.Not.Empty, "Download button href should not be null or empty");
                Assert.That(href, Does.Not.EqualTo("#"), "Download button href should not be a dead link");
            });
        }

        [Test, Category("Negative")]
        public void AfterNavigatingToContact_UrlDoesNotContain_Hero()
        {
            _navbar.ClickNavLink(NavSection.Contact);
            DriverUtils.WaitForUrlContains(Driver, "#contact");
            Assert.That(Driver.Url, Does.Not.Contain("#hero"), "URL should not reference #hero after navigating to contact");
        }
    }
}
