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
        public void AllThreeProjectCards_AreVisible()
        {
            Assert.Multiple(() =>
            {
                for (int i = 1; i <= 3; i++)
                    Assert.That(_projects.ProjectCard(i).Displayed, Is.True, $"Project card {i} not visible");
            });
        }

        [Test, Category("Regression")]
        public void EachProject_HasCompleteContent()
        {
            Assert.Multiple(() =>
            {
                for (int i = 1; i <= 3; i++)
                {
                    Assert.That(_projects.ProjectTitle(i).Text, Is.Not.Empty,        $"Project {i} title is empty");
                    Assert.That(_projects.ProjectStatus(i).Text, Is.Not.Empty,       $"Project {i} status is empty");
                    Assert.That(_projects.ProjectStack(i).Text, Is.Not.Empty,        $"Project {i} stack is empty");
                    Assert.That(_projects.ProjectDescription(i).Text, Is.Not.Empty,  $"Project {i} description is empty");
                }
            });
        }

        [Test, Category("Regression")]
        public void Project1_IsSeleniumFramework()
        {
            Assert.That(_projects.ProjectTitle(1).Text, Does.Contain("Selenium").IgnoreCase);
            Assert.That(_projects.ProjectStatus(1).Text, Does.Contain("passing").IgnoreCase);
            Assert.That(_projects.Project1GithubLink.GetAttribute("href"),
                Does.Contain("logangarbacki/react-portfolio-selenium-tests"));
        }

        [Test, Category("Regression")]
        public void Project2_IsLeadGenInDevelopment()
        {
            Assert.That(_projects.ProjectTitle(2).Text, Does.Contain("Lead Generation").IgnoreCase);
            Assert.That(_projects.ProjectStatus(2).Text, Does.Contain("development").IgnoreCase);
        }

        [Test, Category("Regression")]
        public void Project3_IsLittleLemonAndLive()
        {
            Assert.That(_projects.ProjectTitle(3).Text, Does.Contain("Little Lemon").IgnoreCase);
            Assert.That(_projects.Project3LiveLink.GetAttribute("href"),
                Does.Contain("vercel.app").IgnoreCase);
        }
    }
}
