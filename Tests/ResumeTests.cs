using NUnit.Framework;
using SeleniumTestFramework.Pages;

namespace SeleniumTestFramework
{
    [TestFixture]
    public class ResumeTest : BaseTest
    {
        private ResumePage _resume;

        [SetUp]
        public void SetUp() => _resume = new ResumePage(Driver);

        [Test, Category("Smoke")]
        public void ResumeHeading_IsVisible() =>
            Assert.That(_resume.Heading.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void Resume_LoadsCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_resume.Heading.Displayed, Is.True);
                Assert.That(_resume.Heading.Text, Is.Not.Empty);
                Assert.That(_resume.Blurb.Displayed, Is.True);
                Assert.That(_resume.DownloadButton.Displayed, Is.True);
            });
        }

        [Test, Category("Regression")]
        public void Resume_Content_IsCorrect()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_resume.Heading.Text, Does.Contain("Full"));
                Assert.That(_resume.Blurb.Text, Does.Contain("Detail-oriented QA Engineer").IgnoreCase);
            });
        }

        [Test, Category("Regression")]
        public void Education_IsCorrect()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_resume.EducationName.Displayed, Is.True);
                Assert.That(_resume.EducationName.Text, Is.Not.Empty);
                Assert.That(_resume.EducationDegree.Displayed, Is.True);
                Assert.That(_resume.EducationDegree.Text, Is.Not.Empty);
            });
        }

        [Test, Category("Regression")]
        public void Experience_IsComplete()
        {
            Assert.Multiple(() =>
            {
                for (int i = 1; i <= 2; i++)
                {
                    Assert.That(_resume.ExperienceRole(i).Text, Is.Not.Empty, $"Experience {i} role is empty");
                    Assert.That(_resume.ExperienceCompany(i).Text, Is.Not.Empty, $"Experience {i} company is empty");
                    Assert.That(_resume.ExperiencePeriod(i).Text, Is.Not.Empty, $"Experience {i} period is empty");
                }
            });
        }

        [Test, Category("Regression")]
        public void DownloadButton_IsVisible() =>
            Assert.That(_resume.DownloadButton.Displayed, Is.True);
    }
}
