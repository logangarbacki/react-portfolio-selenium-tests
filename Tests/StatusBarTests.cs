using NUnit.Framework;
using SeleniumTestFramework.Pages;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("StatusBar")]
    public class StatusBarTests : BaseTest
    {
        private StatusBarPage _bar;

        [SetUp]
        public void SetUp() => _bar = new StatusBarPage(Driver);

        [Test, Category("Smoke")]
        public void StatusBar_IsVisible() =>
            Assert.That(_bar.Container.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void StatusBar_AllSegmentsDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_bar.Host.Displayed, Is.True);
                Assert.That(_bar.Branch.Displayed, Is.True);
                Assert.That(_bar.Build.Displayed, Is.True);
                Assert.That(_bar.Age.Displayed, Is.True);
                Assert.That(_bar.LiveTag.Displayed, Is.True);
            });
        }

        [Test, Category("Regression")]
        public void StatusBar_ShowsHostname() =>
            Assert.That(_bar.Host.Text, Does.Contain("logangarbacki.dev").IgnoreCase);

        [Test, Category("Regression")]
        public void StatusBar_ShowsBranchName() =>
            Assert.That(_bar.Branch.Text, Is.Not.Empty);
    }
}
