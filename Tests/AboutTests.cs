using NUnit.Framework;
using SeleniumTestFramework.Pages;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("About")]
    public class AboutTests : BaseTest
    {
        private AboutPage _about;

        [SetUp]
        public void SetUp() => _about = new AboutPage(Driver);

        [Test, Category("Smoke")]
        public void AboutSection_IsVisible() =>
            Assert.That(_about.Section.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void About_LoadsCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_about.Section.Displayed, Is.True);
                Assert.That(_about.FirstParagraph.Displayed, Is.True);
                Assert.That(_about.SecondParagraph.Displayed, Is.True);
                Assert.That(_about.AgencyLink.GetAttribute("href"),
                    Does.Contain("garbackidigital.com/work").IgnoreCase);
            });
        }

        [Test, Category("Regression")]
        public void About_FirstParagraph_DescribesEngineerRole()
        {
            var text = _about.FirstParagraph.Text;
            Assert.Multiple(() =>
            {
                Assert.That(text, Does.Contain("Long Island").IgnoreCase);
                Assert.That(text, Does.Contain("engineer").IgnoreCase);
                Assert.That(text, Does.Contain("C#").IgnoreCase);
            });
        }

        [Test, Category("Regression")]
        public void About_SecondParagraph_DescribesLiveCiCdLink()
        {
            var text = _about.SecondParagraph.Text;
            Assert.Multiple(() =>
            {
                Assert.That(text, Does.Contain("production").IgnoreCase);
                Assert.That(text, Does.Contain("Selenium").IgnoreCase);
                Assert.That(text, Does.Contain("Allure").IgnoreCase);
            });
        }
    }
}
