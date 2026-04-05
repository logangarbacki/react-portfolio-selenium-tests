using NUnit.Framework;
using SeleniumTestFramework.Pages;
using OpenQA.Selenium;

namespace SeleniumTestFramework
{
    [TestFixture]
    public class SkillsTests : BaseTest
    {
        private SkillsPage _skills;

        [SetUp]
        public void SetUp()
        {
            _skills = new SkillsPage(Driver);
            ((IJavaScriptExecutor)Driver).ExecuteScript(
                "arguments[0].scrollIntoView({behavior:'instant'});", 
                _skills.SkillsHeading
            );
        }

        [Test, Category("Smoke")]
        public void SkillsHeading_IsVisible()
        {
            Assert.That(_skills.SkillsHeading.Displayed, Is.True);
        }

        [Test, Category("Regression")]
        public void SkillsHeading_ContainsExpectedText()
        {
            StringAssert.Contains("work", _skills.SkillsHeading.Text);
        }

        [Test, Category("Regression")]
        public void AutomationToolsHeader_ContainsExpectedText()
        {
            
            Assert.That(_skills.AutomationToolsHeader.Text, Does.Contain("Automation Tools").IgnoreCase);
        }

        [Test, Category("Regression")]
        public void CertificationsHeading_IsVisible()
        {
            Assert.That(_skills.CertificationsHeading.Displayed, Is.True);
        }

        [Test, Category("Regression")]
        public void CertificationsHeading_ContainsCheckmark()
        {
            StringAssert.Contains("✓", _skills.CertificationsHeading.Text);
        }
    }
}