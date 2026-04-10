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
        public void ProjectsHeading_IsVisible() =>
            Assert.That(_projects.Heading.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void Projects_LoadsCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_projects.Heading.Displayed, Is.True);
                Assert.That(_projects.Heading.Text, Is.Not.Empty);
                for (int i = 1; i <= 3; i++)
                    Assert.That(_projects.ProjectTitle(i).Displayed, Is.True, $"Project {i} title not visible");
            });
        }

        [Test, Category("Regression")]
        public void Projects_Content_IsCorrect()
        {
            Assert.Multiple(() =>
            {
                for (int i = 1; i <= 3; i++)
                {
                    Assert.That(_projects.ProjectTitle(i).Text, Is.Not.Empty, $"Project {i} title is empty");
                    Assert.That(_projects.ProjectYear(i).Text, Is.Not.Empty, $"Project {i} year is empty");
                    Assert.That(_projects.ProjectType(i).Text, Is.Not.Empty, $"Project {i} type is empty");
                    Assert.That(_projects.ProjectDescription(i).Text, Is.Not.Empty, $"Project {i} description is empty");
                    Assert.That(_projects.ProjectMetric(i).Text, Is.Not.Empty, $"Project {i} metric is empty");
                }
            });
        }
    }
}
