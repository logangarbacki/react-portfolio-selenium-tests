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
        private ContactPage _contact;

        [SetUp]
        public void SetUp()
        {
            _navbar   = new NavbarPage(Driver);
            _projects = new ProjectsPage(Driver);
            _contact  = new ContactPage(Driver);
        }

        [Test, Category("Negative")]
        public void Navbar_HasNo_HeroLink()
        {
            // Hero is the implicit landing — nav has no #hero or #home link.
            var heroLinks = Driver.FindElements(
                OpenQA.Selenium.By.CssSelector("[data-testid='nav'] a[href='#hero'], [data-testid='nav'] a[href='#home']")
            );
            Assert.That(heroLinks, Is.Empty, "Navbar should not contain a hero/home anchor link");
        }

        [Test, Category("Negative")]
        public void Navbar_HasNo_SkillsOrResumeAnchor()
        {
            // Skills and Resume sections were removed; only the resume PDF link remains.
            var orphanAnchors = Driver.FindElements(
                OpenQA.Selenium.By.CssSelector("[data-testid='nav'] a[href='#skills'], [data-testid='nav'] a[href='#resume']")
            );
            Assert.That(orphanAnchors, Is.Empty, "Navbar should not contain anchor links to removed sections");
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
        public void ContactForm_RequiredFields_AreEnforcedByMarkup()
        {
            // Inputs use the `required` attribute — sanity check that none is missing.
            Assert.Multiple(() =>
            {
                Assert.That(_contact.NameInput.GetAttribute("required"), Is.Not.Null.And.Not.Empty);
                Assert.That(_contact.EmailInput.GetAttribute("required"), Is.Not.Null.And.Not.Empty);
                Assert.That(_contact.MessageInput.GetAttribute("required"), Is.Not.Null.And.Not.Empty);
            });
        }

        [Test, Category("Negative")]
        public void AfterNavigatingToContact_UrlDoesNotContain_Projects()
        {
            _navbar.ClickNavLink(NavSection.Contact);
            DriverUtils.WaitForUrlContains(Driver, "#contact");
            Assert.That(Driver.Url, Does.Not.Contain("#projects"),
                "URL should not reference #projects after navigating to contact");
        }
    }
}
