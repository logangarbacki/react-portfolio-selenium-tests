using NUnit.Framework;
using SeleniumTestFramework.Pages;

namespace SeleniumTestFramework
{
    [TestFixture]
    public class AboutTests : BaseTest
    {
        private AboutPage _about;

        [SetUp]
        public void SetUp() => _about = new AboutPage(Driver);

        [Test, Category("Smoke")]
        public void AboutHeading_IsVisible() =>
            Assert.That(_about.Heading.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void About_LoadsCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_about.Heading.Displayed, Is.True);
                Assert.That(_about.Heading.Text, Is.Not.Empty);
                Assert.That(_about.LocationBadge.Displayed, Is.True);
                Assert.That(_about.IntroParagraph.Displayed, Is.True);
                Assert.That(_about.StatsGrid.Displayed, Is.True);
            });
        }

        [Test, Category("Regression")]
        public void About_Content_IsCorrect()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_about.Heading.Text, Does.Contain("Quality first"));
                Assert.That(_about.IntroParagraph.Text, Does.Contain("self-taught QA Engineer"));
                Assert.That(_about.LocationBadge.Text, Does.Contain("Hicksville, NY"));
                Assert.That(_about.LocationBadge.Text, Does.Contain("Open to Remote"));
            });
        }

        [Test, Category("Regression")]
        public void AboutStats_AreComplete()
        {
            Assert.Multiple(() =>
            {
                for (int i = 1; i <= 4; i++)
                {
                    Assert.That(_about.StatValue(i).Displayed, Is.True, $"Stat {i} value not visible");
                    Assert.That(_about.StatValue(i).Text, Is.Not.Empty, $"Stat {i} value is empty");
                    Assert.That(_about.StatLabel(i).Displayed, Is.True, $"Stat {i} label not visible");
                    Assert.That(_about.StatLabel(i).Text, Is.Not.Empty, $"Stat {i} label is empty");
                }

                Assert.That(_about.CertificationsStat.Text, Is.EqualTo("5"));
            });
        }
    }
}
