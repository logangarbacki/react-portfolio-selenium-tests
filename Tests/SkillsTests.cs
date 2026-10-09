using NUnit.Framework;
using SeleniumTestFramework.Pages;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("Skills")]
    public class SkillsTests : BaseTest
    {
        private SkillsPage _skills;

        [SetUp]
        public void SetUp() => _skills = new SkillsPage(Driver);

        [Test, Category("Smoke")]
        public void SkillsSection_ShowsAllThreeGroups()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_skills.Section.Displayed, Is.True);
                Assert.That(_skills.Testing.Displayed, Is.True);
                Assert.That(_skills.Development.Displayed, Is.True);
                Assert.That(_skills.Workflow.Displayed, Is.True);
            });
        }

        [Test, Category("Regression")]
        public void Skills_ListCoreTestingAndDevelopmentTools()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_skills.Testing.Text, Does.Contain("Selenium"));
                Assert.That(_skills.Testing.Text, Does.Contain("NUnit"));
                Assert.That(_skills.Development.Text, Does.Contain("C#"));
                Assert.That(_skills.Workflow.Text, Does.Contain("GitHub Actions"));
            });
        }
    }
}
