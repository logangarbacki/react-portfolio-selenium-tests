using NUnit.Framework;
using SeleniumTestFramework.Pages;
using SeleniumTestFramework.Enums;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.Attributes.AllureSuite("E2E")]
    public class UserFlowTests : BaseTest
    {
        private HeroPage _hero;
        private NavbarPage _navbar;
        private ProjectsPage _projects;
        private AboutPage _about;
        private ContactPage _contact;

        [SetUp]
        public void SetUp()
        {
            _hero     = new HeroPage(Driver);
            _navbar   = new NavbarPage(Driver);
            _projects = new ProjectsPage(Driver);
            _about    = new AboutPage(Driver);
            _contact  = new ContactPage(Driver);
        }

        [Test, Category("E2E")]
        public void Visitor_Flows_From_Home_Through_Projects_About_To_Contact()
        {
            // Home page assertions
            Assert.That(_hero.Title.Displayed, Is.True, "Hero title should be visible on load");
            Assert.That(_hero.Eyebrow.Text, Does.Contain("QA Engineer").IgnoreCase, "Eyebrow should show job title");

            // Clicks "View Work" goes to /#projects
            _hero.ClickViewWork();
            DriverUtils.WaitForUrlContains(Driver, "#projects");
            Assert.That(Driver.Url, Does.Contain("#projects"), "URL should update to #projects");

            // Projects page assertions
            Assert.That(_projects.Heading.Displayed, Is.True, "Projects heading should be visible");
            for (int i = 1; i <= 3; i++)
                Assert.That(_projects.ProjectTitle(i).Text, Is.Not.Empty, $"Project {i} title should not be empty");

            // Navigate to About via navbar
            _navbar.ClickNavLink(NavSection.About);
            DriverUtils.WaitForUrlContains(Driver, "#about");
            Assert.That(Driver.Url, Does.Contain("#about"), "URL should update to #about");

            // About page assertions
            Assert.That(_about.Heading.Displayed, Is.True, "About heading should be visible");
            Assert.That(_about.LocationBadge.Displayed, Is.True, "Location badge should be visible");
            Assert.That(_about.StatsGrid.Displayed, Is.True, "Stats grid should be visible");

            // Navigate to Contact via navbar
            _navbar.ClickNavLink(NavSection.Contact);
            DriverUtils.WaitForUrlContains(Driver, "#contact");
            Assert.That(Driver.Url, Does.Contain("#contact"), "URL should update to #contact");

            // Content page assertions
            Assert.That(_contact.Heading.Displayed, Is.True, "Contact heading should be visible");
            Assert.That(_contact.EmailLink.Displayed, Is.True, "Email link should be visible");
            Assert.That(_contact.EmailLink.GetAttribute("href"), Does.Contain("mailto:"), "Email link should have mailto href");
        }
    }
}
