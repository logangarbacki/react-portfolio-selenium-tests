using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumTestFramework.Pages;
using SeleniumTestFramework.Enums;
using System;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
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
            // Hero on load
            Assert.That(_hero.Section.Displayed, Is.True, "Hero section should be visible on load");
            var name = DriverUtils.GetInnerText(Driver, _hero.Name);
            Assert.That(name, Does.Contain("Logan").And.Contain("Garbacki"),
                "Hero name should be present");

            // Click "view projects" → URL anchors to #projects
            _hero.ClickViewProjects();
            DriverUtils.WaitForUrlContains(Driver, "#projects");
            Assert.That(Driver.Url, Does.Contain("#projects"), "URL should update to #projects");

            // Projects section visible with all three cards
            Assert.That(_projects.Section.Displayed, Is.True, "Projects section should be visible");
            for (int i = 1; i <= 3; i++)
                Assert.That(_projects.ProjectTitle(i).Text, Is.Not.Empty,
                    $"Project {i} title should not be empty");

            // Navigate to About
            _navbar.ClickNavLink(NavSection.About);
            DriverUtils.WaitForUrlContains(Driver, "#about");
            Assert.That(Driver.Url, Does.Contain("#about"), "URL should update to #about");
            Assert.That(_about.FirstParagraph.Displayed, Is.True, "About paragraph should be visible");

            // Navigate to Contact
            _navbar.ClickNavLink(NavSection.Contact);
            DriverUtils.WaitForUrlContains(Driver, "#contact");
            Assert.That(Driver.Url, Does.Contain("#contact"), "URL should update to #contact");

            // Contact form submission flow
            Assert.That(_contact.Form.Displayed, Is.True, "Contact form should be visible");
            _contact.Fill("E2E Visitor", "e2e@example.com", "End-to-end smoke message");
            _contact.Submit();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => _contact.SuccessVisible);
            // The success line types out "POST /contact → ok" — wait for it to land.
            wait.Until(d => _contact.SuccessBlock.Text.IndexOf("ok", StringComparison.OrdinalIgnoreCase) >= 0);

            Assert.That(_contact.SuccessBlock.Text, Does.Contain("ok").IgnoreCase,
                "Contact form should show ok success state after submission");
        }
    }
}
