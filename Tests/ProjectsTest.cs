using NUnit.Framework;
using SeleniumTestFramework.Pages;
using OpenQA.Selenium;

namespace SeleniumTestFramework
{
    [TestFixture]
    public class ProjectsTests : BaseTest
    {
        private ProjectsPage _projects;

        [SetUp]
        public void SetUp()
        {
            _projects = new ProjectsPage(Driver);
            ((IJavaScriptExecutor)Driver).ExecuteScript(
                "arguments[0].scrollIntoView({behavior:'instant'});", 
                _projects.SectionTitle
            );
        }

        [Test, Category("Smoke")]
        public void ProjectsSectionTitle_IsVisible()
        {
            Assert.That(_projects.SectionTitle.Displayed, Is.True);
            StringAssert.Contains("Selected work", _projects.SectionTitle.Text);
        }

        [Test, Category("Regression")]
        public void ProjectTitles_AreVisibleAndNotEmpty()
        {
            for (int i = 1; i <= 3; i++) 
            {
                Assert.That(_projects.ProjectTitle(i).Displayed, Is.True);
                Assert.That(_projects.ProjectTitle(i).Text, Is.Not.Empty, $"Project {i} title is empty");
            }
        }

        [Test, Category("Regression")]
        public void ProjectMetrics_AreVisibleAndNotEmpty()
        {
            for (int i = 1; i <= 3; i++)
            {
                Assert.That(_projects.ProjectMetric(i).Displayed, Is.True);
                Assert.That(_projects.ProjectMetric(i).Text, Is.Not.Empty, $"Project {i} metric is empty");
            }
        }
    }
}