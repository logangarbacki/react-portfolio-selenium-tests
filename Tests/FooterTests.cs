using NUnit.Framework;
using SeleniumTestFramework.Pages;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("Footer")]
    public class FooterTests : BaseTest
    {
        private FooterPage _footer;

        [SetUp]
        public void SetUp() => _footer = new FooterPage(Driver);

        [Test, Category("Smoke")]
        public void Footer_IsVisible() =>
            Assert.That(_footer.Container.Displayed, Is.True);

        [Test, Category("Regression")]
        public void Footer_ShowsBrandLine() =>
            Assert.That(_footer.Container.Text, Does.Contain("logangarbacki.dev").IgnoreCase);
    }
}
