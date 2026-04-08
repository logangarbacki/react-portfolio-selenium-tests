using NUnit.Framework;
using SeleniumTestFramework.Pages;
using OpenQA.Selenium;

namespace SeleniumTestFramework
{
    [TestFixture]
    public class ResumeTest : BaseTest
    {
        private ResumePage _resume;

        [SetUp]
        public void SetUp()
        {
            _resume = new ResumePage(Driver);
            ((IJavaScriptExecutor)Driver).ExecuteScript(
                "arguments[0].scrollIntoView({behavior:'instant'});", 
                _resume.Heading
            );
        }

        [Test, Category("Smoke")]
        public void ResumeHeading_IsVisible()
        {
            Assert.That(_resume.Heading.Displayed, Is.True);
        }

        [Test, Category("Regression")]
        public void ResumeHeading_ContainsExpectedText()
        {
            StringAssert.Contains("Full", _resume.Heading.Text);
        }

        [Test, Category("Regression")]
        public void ResumeBlurb_ContainsExpectedText()
        {
            
            Assert.That(_resume.Blurb.Text, Does.Contain("Detail-oriented QA Engineer").IgnoreCase);
        }

        [Test, Category("Regression")]
        public void DownloadButton_IsVisible()
        {
            Assert.That(_resume.DownloadButton.Displayed, Is.True);
        }
    }
}