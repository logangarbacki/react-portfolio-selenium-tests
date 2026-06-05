using NUnit.Framework;
using SeleniumTestFramework.Pages;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("Projects")]
    public class ProjectsTests : BaseTest
    {
        private ProjectsPage _projects;

        [SetUp]
        public void SetUp() => _projects = new ProjectsPage(Driver);

        [Test, Category("Smoke")]
        public void ProjectsSection_IsVisible() =>
            Assert.That(_projects.Section.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void AllProjectCards_AreVisible()
        {
            Assert.Multiple(() =>
            {
                for (int i = 1; i <= 4; i++)
                    Assert.That(_projects.ProjectCard(i).Displayed, Is.True, $"Project card {i} not visible");
            });
        }

        [Test, Category("Regression")]
        public void EachProject_HasCompleteContent()
        {
            Assert.Multiple(() =>
            {
                for (int i = 1; i <= 4; i++)
                {
                    Assert.That(_projects.ProjectTitle(i).Text, Is.Not.Empty,        $"Project {i} title is empty");
                    Assert.That(_projects.ProjectStatus(i).Text, Is.Not.Empty,       $"Project {i} status is empty");
                    Assert.That(_projects.ProjectStack(i).Text, Is.Not.Empty,        $"Project {i} stack is empty");
                    Assert.That(_projects.ProjectDescription(i).Text, Is.Not.Empty,  $"Project {i} description is empty");
                }
            });
        }

        [Test, Category("Regression")]
        public void Project1_IsPrintScanRegressionFramework()
        {
            Assert.That(_projects.ProjectTitle(1).Text,
                Does.Contain("PrintScan").IgnoreCase.And.Contain("Regression").IgnoreCase);
            // Role/date label, not a pass/fail state
            Assert.That(_projects.ProjectStatus(1).Text, Does.Contain("QA Specialist").IgnoreCase);
        }

        [Test, Category("Regression")]
        public void Project2_IsPrintScanLocationSearchAndLive()
        {
            Assert.That(_projects.ProjectTitle(2).Text, Does.Contain("Location Search").IgnoreCase);
            Assert.That(_projects.ProjectStatus(2).Text, Does.Contain("production").IgnoreCase);
            Assert.That(_projects.LocationSearchLiveLink.GetAttribute("href"),
                Does.Contain("printscan.com/Locations").IgnoreCase);
        }

        [Test, Category("Regression")]
        public void Project3_IsSeleniumFrameworkAndPassing()
        {
            Assert.That(_projects.ProjectTitle(3).Text, Does.Contain("Selenium").IgnoreCase);
            Assert.That(_projects.ProjectStatus(3).Text, Does.Contain("passing").IgnoreCase);
            Assert.That(_projects.SeleniumGithubLink.GetAttribute("href"),
                Does.Contain("logangarbacki/react-portfolio-selenium-tests"));
        }

        [Test, Category("Regression")]
        public void Project4_IsLeadGenAndLive()
        {
            Assert.That(_projects.ProjectTitle(4).Text, Does.Contain("Lead Generation").IgnoreCase);
            Assert.That(_projects.ProjectStatus(4).Text, Does.Contain("live").IgnoreCase);
            Assert.That(_projects.LeadGenLiveLink.GetAttribute("href"),
                Does.Contain("garbackidigital.com/platform").IgnoreCase);
        }
    }
}
