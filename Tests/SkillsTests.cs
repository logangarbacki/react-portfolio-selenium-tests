using NUnit.Framework;
using SeleniumTestFramework.Pages;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.Attributes.AllureSuite("Skills")]
    public class SkillsTests : BaseTest
    {
        private SkillsPage _skills;

        [SetUp]
        public void SetUp() => _skills = new SkillsPage(Driver);

        [Test, Category("Smoke")]
        public void SkillsHeading_IsVisible() =>
            Assert.That(_skills.Heading.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void Skills_LoadsCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_skills.Heading.Displayed, Is.True);
                Assert.That(_skills.Heading.Text, Is.Not.Empty);
                for (int i = 1; i <= 4; i++)
                    Assert.That(_skills.SkillGroupHeader(i).Displayed, Is.True, $"Skill group {i} header not visible");
                Assert.That(_skills.CertsSection.Displayed, Is.True);
            });
        }

        [Test, Category("Regression")]
        public void SkillGroups_Content_IsCorrect()
        {
            Assert.Multiple(() =>
            {
                for (int i = 1; i <= 4; i++)
                    Assert.That(_skills.SkillGroupHeader(i).Text, Is.Not.Empty, $"Skill group {i} header is empty");
            });
        }

        [Test, Category("Regression")]
        public void Certifications_AreComplete()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_skills.CertsHeader.Displayed, Is.True);
                Assert.That(_skills.CertsHeader.Text, Does.Contain("✓"));
                Assert.That(_skills.GetCertCount(), Is.EqualTo(5));
            });
        }
    }
}
