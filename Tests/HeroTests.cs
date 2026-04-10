using NUnit.Framework;
using SeleniumTestFramework.Pages;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("Hero")]
    public class HeroTests : BaseTest
    {
        private HeroPage _hero;

        [SetUp]
        public void SetUp() => _hero = new HeroPage(Driver);


        [Test, Category("Smoke")]
        public void HeroTitle_IsVisible() =>
            Assert.That(_hero.Title.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void ViewWorkButton_IsVisible() =>
            Assert.That(_hero.ViewWorkButton.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void DownloadResumeButton_IsVisible() =>
            Assert.That(_hero.DownloadResumeButton.Displayed, Is.True);

        [Test, Category("Regression")]
        public void HeroTitle_ContainsName()
        {
            var text = DriverUtils.GetInnerText(Driver, _hero.Title);
            Assert.That(text, Does.Contain("Logan").And.Contain("Garbacki"));
        }

        [Test, Category("Regression")]
        public void HeroEyebrow_ContainsJobTitle() =>
            Assert.That(_hero.Eyebrow.Text, Does.Contain("QA Engineer").IgnoreCase);

        [Test, Category("Smoke")]
        public void HeroTagline_IsVisible() =>
            Assert.That(_hero.Tagline.Displayed, Is.True);

        [Test, Category("Regression")]
        public void HeroTechStack_ContainsExpected()
        {
            var text = _hero.TechStack.Text;
            Assert.Multiple(() =>
            {
                Assert.That(text, Does.Contain("Selenium"));
                Assert.That(text, Does.Contain("React"));
                Assert.That(text, Does.Contain("C#"));
            });
        }

        [Test, Category("Regression"), Retry(2)]
        public void ClickingViewWork_NavigatesToProjectsSection()
        {
            _hero.ClickViewWork();
            DriverUtils.WaitForUrlContains(Driver, "#projects");
            Assert.That(Driver.Url, Does.Contain("#projects"));
        }

        [Test, Category("Regression"), Retry(2)]
        public void ClickingDownloadResume_NavigatesToResumeSection()
        {
            _hero.ClickDownloadResume();
            DriverUtils.WaitForUrlContains(Driver, "#resume");
            Assert.That(Driver.Url, Does.Contain("#resume"));
        }
    }
}
