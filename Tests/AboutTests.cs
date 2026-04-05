using NUnit.Framework;
using SeleniumTestFramework.Pages;
using OpenQA.Selenium;

namespace SeleniumTestFramework
{
    [TestFixture]
    public class AboutTests : BaseTest
    {
        private AboutPage _about;

        [SetUp]
        public void SetUp()
        {
            _about = new AboutPage(Driver);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({behavior:'instant'});", _about.Heading);
        }

        [Test, Category("Smoke")]
        public void AboutHeading_IsVisible()
        {
            Assert.That(_about.Heading.Displayed, Is.True);
        }

        [Test, Category("Regression")]
        public void AboutHeading_ContainsExpectedText()
        {
            StringAssert.Contains("Quality first", _about.Heading.Text);
        }

        [Test, Category("Regression")]
        public void IntroParagraph_ContainsSelfTaughtQA()
        {
            StringAssert.Contains("self-taught QA Engineer", _about.IntroParagraph.Text);
        }

        [Test, Category("Regression")]
        public void LocationBadge_ContainsHicksvilleAndRemote()
        {
            StringAssert.Contains("Hicksville, NY", _about.LocationBadge.Text);
            StringAssert.Contains("Open to Remote", _about.LocationBadge.Text);
        }

        [Test, Category("Regression")]
        public void CertificationsStat_IsFive()
        {
            Assert.AreEqual("5", _about.CertificationsStat.Text);
        }
    }
}